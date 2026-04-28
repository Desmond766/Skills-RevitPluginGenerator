# Sample Snippet: OptimalCablePathByNode

Source project: `existingCodes\梁涛插件源代码\8.算量插件集合\拆分（旧）\OptimalCablePathByNode\OptimalCablePathByNode`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Autodesk.Revit.DB.Structure;
using static System.Net.WebRequestMethods;
using System.Threading;
using System.Reflection;
using System.Windows.Controls;
using Autodesk.Revit.ApplicationServices;
using System.Collections;
using System.Windows.Forms;
using Application = Autodesk.Revit.ApplicationServices.Application;
using static System.Net.Mime.MediaTypeNames;
using System.ComponentModel;
using Autodesk.Revit.Exceptions;
using System.Windows.Shell;

namespace OptimalCablePathByNode
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public List<Connector> fitHasConnect = new List<Connector>();

        public List<Connector> cabletrayHasConnect = new List<Connector>();

        ConduitType conduitType = null;

        ElementId levelId = null;

        FamilySymbol familySymbol = null;
        // 拓扑线实例集合
        List<Conduit> topologicalLines = new List<Conduit>();

        View3D view3D = null;
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;

            if (doc.ActiveView is View3D)
            {
                view3D = doc.ActiveView as View3D;
            }
            //else
            //{
            //    view3D = new FilteredElementCollector(doc).OfClass(typeof(View3D)).Cast<View3D>().FirstOrDefault();
            //    if (view3D == null)
            //    {
            //        TaskDialog.Show("错误", "当前项目中不存在三维视图，无法运行插件");
            //        return Result.Cancelled;
            //    }
            //}
            else
            {
                TaskDialog.Show("错误", "请在三维视图中运行插件");
                return Result.Cancelled;
            }
            List<FamilyInstance> instances = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_ElectricalEquipment).OfClass(typeof(FamilyInstance))
                .Cast<FamilyInstance>().Where(x => x.Symbol.FamilyName.Contains("配电箱") || x.Symbol.FamilyName.Contains("配电柜")).ToList();
            var insGroup = instances.GroupBy(y => y.LookupParameter("电气-配电编号").AsString());


            DateTime beforDT = DateTime.Now;

            // 拓扑线族类型
            conduitType = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Conduit).OfClass(typeof(ConduitType)).Cast<ConduitType>().Where(x => x.Name == "品成-拓扑线").FirstOrDefault();

            TransactionGroup TG2 = new TransactionGroup(doc, "载入族");
            if (conduitType == null)
            {

                TG2.Start();
                bool succeed = AddNewConduitType(doc);
                string dllPath = Assembly.GetExecutingAssembly().Location;
                string nodeFamilyPath = dllPath.Replace("OptimalCablePathByNode.dll", "品成-拓扑节点.rfa");
                LoadFamily(doc, nodeFamilyPath);
                TG2.Assimilate();
                if (!succeed) return Result.Cancelled;
// ... truncated ...
```

## Utils.cs

```csharp
using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.DB.Macros;

namespace OptimalCablePathByNode
{
    public static class Utils
    {
        /// <summary>
        /// 判断集合中是否包含该连接器
        /// </summary>
        /// <param name="createInfos"></param>
        /// <param name="connector"></param>
        /// <returns></returns>
        public static bool IsContains(this List<Connector> createInfos, Connector connector)
        {
            foreach (var item in createInfos)
            {
                if (item.Id == connector.Id && item.Owner.Id == connector.Owner.Id)
                {
                    return true;
                }
            }
            return false;
        }
        public static XYZ GetProjectionPoint(this XYZ point, Line line)
        {
            return line.Project(point).XYZPoint;
        }
        // 判断使用Line创建的族实例是否垂直
        public static bool IsVertical(this Element element)
        {
            if (element.Location is LocationCurve curve)
            {
                XYZ dir = (curve.Curve as Line).Direction;
                if (dir.IsAlmostEqualTo(XYZ.BasisZ, 0.26) || dir.IsAlmostEqualTo(XYZ.BasisZ.Negate(), 0.26))
                {
                    return true;
                }
            }
            return false;
        }
        // 获取MEPCurve类族实例的Line
        public static Line GetLine(this MEPCurve mEPCurve)
        {
            Line line = null;
            if (mEPCurve.Location is LocationCurve)
            {
                line = (mEPCurve.Location as LocationCurve).Curve as Line;
            }
            return line;
        }
        /// <summary>
        /// 判断坐标点是否在该线段上
        /// </summary>
        /// <param name="point">坐标点</param>
        /// <param name="line">线段</param>
        /// <returns></returns>
        public static bool IsPointOnLine(this XYZ point, Line line)
        {
            XYZ p0 = line.GetEndPoint(0);
            XYZ p1 = line.GetEndPoint(1);
            //TaskDialog.Show("TEST", line.Direction + "\n" + (point - p0).Normalize() + "\n" + p0.DistanceTo(point) * 304.8 + "\n" + p0.DistanceTo(p1) * 304.8 + "\n" + point.DistanceTo(p0) * 304.8 + "\n" + point.DistanceTo(p1) * 304.8);
            //判断是否平行的误差为5度
            if (line.Direction.IsAlmostEqualTo((point - p0).Normalize(), 0.088) && p0.DistanceTo(point) < p0.DistanceTo(p1) && point.DistanceTo(p0) > 20 / 304.8 && point.DistanceTo(p1) > 20 / 304.8)
            {
                return true;
            }
            return false;
        }
        public static T PickObject<T>(this UIDocument uIDoc)
        {
            Selection sel = uIDoc.Selection;
            Document doc = uIDoc.Document;

            Element element = sel.PickObject(ObjectType.Element).GetElement(doc);
            T tElem = (T)Convert.ChangeType(element, typeof(T));
            return tElem;
        }
        /// <summary>
        /// 获得MepCurve上离该连接器最近的连接器
        /// </summary>
        /// <returns></returns>
// ... truncated ...
```

## BeeFaceFailureHandler.cs

```csharp
using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimalCablePathByNode
{
    public class BeeFaceFailureHandler : IFailuresPreprocessor
    {
        public string ErrorMessage { set; get; }
        public string ErrorSeverity { set; get; }

        public BeeFaceFailureHandler()
        {
            ErrorMessage = "";
            ErrorSeverity = "";
        }
        public FailureProcessingResult PreprocessFailures(FailuresAccessor failuresAccessor)
        {
            IList<FailureMessageAccessor> failureMessages = failuresAccessor.GetFailureMessages();
            foreach (FailureMessageAccessor failureMessageAccessor in failureMessages)
            {
                FailureDefinitionId id = failureMessageAccessor.GetFailureDefinitionId();
                try
                {
                    ErrorMessage = failureMessageAccessor.GetDescriptionText();
                }
                catch
                {
                    ErrorMessage = "Unknown Error";
                }
                try
                {
                    FailureSeverity failureSeverity = failureMessageAccessor.GetSeverity();
                    ErrorSeverity = failureSeverity.ToString();
                    if (failureSeverity == FailureSeverity.Warning)
                    {
// ... truncated ...
```

