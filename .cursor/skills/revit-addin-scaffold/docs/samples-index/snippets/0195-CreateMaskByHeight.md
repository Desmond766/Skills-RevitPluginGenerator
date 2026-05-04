# Sample Snippet: CreateMaskByHeight

Source project: `existingCodes\饶昌锋插件源代码\266分析管线净高填色\CreateMaskByHeight`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CreateMaskByHeight
{
    [TransactionAttribute(TransactionMode.Manual)]
    [RegenerationAttribute(RegenerationOption.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;

            CreatMaskWindow window = new CreatMaskWindow();
            window.ShowDialog();
            int index = window.CreateType.SelectedIndex;
            int minValue = int.Parse(window.MinValue.Text);
            int maxValue = int.Parse(window.MaxValue.Text);
            bool flag = window.isSubmit;
            if (flag)
            {
                FilteredElementCollector collector = new FilteredElementCollector(doc, uidoc.ActiveView.Id);
                ElementCategoryFilter categoryFilter = new ElementCategoryFilter(BuiltInCategory.OST_Floors);
                List<Floor> floorList = new List<Floor>();

                //根据不同选项执行代码
                switch (index)
                {
                    case 0:
                        //车道
                        floorList = collector.OfCategory(BuiltInCategory.OST_Floors).ToElements().OfType<Floor>().Where(x => IsTargetFloor(x, "A-PB-地坪漆")).ToList();
                        CreateMask(uidoc, floorList, minValue, maxValue);
                        break;
                    case 1:
                        //车位
                        floorList = collector.OfCategory(BuiltInCategory.OST_Floors).ToElements().OfType<Floor>().Where(x => IsTargetFloor(x, "A-PB-停车位区域")).ToList();
                        CreateMask(uidoc, floorList, minValue, maxValue);
                        break;
                    case 2:
                        //房间
                        FloorFilter floorFilter = new FloorFilter();
                        floorList = uidoc.Selection.PickObjects(ObjectType.Element, floorFilter).ToFloors(doc);
                        CreateMask(uidoc, floorList, minValue, maxValue);
                        break;
                    default:
                        System.Windows.MessageBox.Show("创建失败");
                        return Result.Cancelled;
                }
                return Result.Succeeded;
            }

            return Result.Failed;
        }
        public void CreateMask(UIDocument uidoc, List<Floor> floorList, int minValue, int maxValue)
        {
            Document doc = uidoc.Document;
            Document linkDoc = null;
            doc.NewTransaction("创建遮罩层", () =>
            {

                foreach (Floor floor in floorList)
                {

                    Dictionary<ElementId, double> minElement = new Dictionary<ElementId, double>();
                    try
                    {
                        minElement = MaskCreat.Creat(uidoc, floor, minValue, maxValue, ref linkDoc);
                    }
                    catch (Exception e)
                    {
                        System.Windows.MessageBox.Show(e.ToString());
                        continue;
                    }
                    if (minElement != null)
                    {
                        if (minElement.Count() != 0)
                        {
                            MEPCurve mEP = linkDoc.GetElement(minElement.First().Key) as MEPCurve;

// ... truncated ...
```

## Utils.cs

```csharp
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace CreateMaskByHeight
{
    static class Utils
    {
        public static List<Floor> ToFloors(this IList<Reference> references, Document doc)
        {
            List<Floor> floors = new List<Floor>();
            foreach (Reference reference in references)
            {
                Floor floor = doc.GetElement(reference) as Floor;
                floors.Add(floor);
            }
            return floors;
        }
        public static List<XYZ> NewMethod(Element fitfm)
        {
            List<XYZ> dirList = new List<XYZ>();
            // XYZ rayDirection1 = new XYZ(0, 0, 1);//向上的法向量

            LocationCurve locationCureve = fitfm.Location as LocationCurve;
            Curve curve = locationCureve.Curve;
            XYZ start = curve.GetEndPoint(0);
            XYZ end = curve.GetEndPoint(1);

            XYZ vect1 = start.CrossProduct(end);     //两向量组成面的法向量
            XYZ rayDirection2 = new XYZ(vect1.X, vect1.Y, 0);

            XYZ vect2 = end.CrossProduct(start);
            XYZ rayDirection3 = new XYZ(vect2.X, vect2.Y, 0);

            dirList.Add(rayDirection2);
            dirList.Add(rayDirection3);
            return dirList;
        }
        /// <summary>
        /// 拿到当前项目里面的所有链接模型
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        public static List<RevitLinkInstance> GetRevitLinks(Document doc)
        {
            List<RevitLinkInstance> links = new List<RevitLinkInstance>();
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            links = collector.OfClass(typeof(RevitLinkInstance)).Cast<RevitLinkInstance>().ToList();
            return links;
        }
        public static ReferenceWithContext Ray(View3D view3D, XYZ rayDirection3, XYZ center, List<ElementFilter> elementFilters)
        {
            LogicalOrFilter logicalOrFilter = new LogicalOrFilter(elementFilters);//*逻辑过滤器 该过滤器适合两种及以上的类型
            ReferenceIntersector refIntersector = new ReferenceIntersector(logicalOrFilter, FindReferenceTarget.Element, view3D);
            ReferenceWithContext refWithContexts = refIntersector.FindNearest(center, rayDirection3);
            return refWithContexts;
        }
        public static List<CurveLoop> GetRoomLoop2(Room room)
        {
            var boudaries = room.GetBoundarySegments(new SpatialElementBoundaryOptions() { SpatialElementBoundaryLocation = SpatialElementBoundaryLocation.Finish });
            List<CurveLoop> loops = new List<CurveLoop>();
            foreach (var boundarys in boudaries)
            {
                List<Curve> curves = new List<Curve>();
                int setp = 0;
                int sum = boundarys.Count - 1;
                Curve before_curve = null;
                Curve one_curve = null;

                foreach (var boundary in boundarys)
                {
                    double lengths = (boundary.GetCurve().GetEndPoint(0).DistanceTo(boundary.GetCurve().GetEndPoint(1)) * 304.8);
                    if (setp == 0)
                    {
                        curves.Add(boundary.GetCurve());
                        one_curve = boundary.GetCurve();
                    }
                    if (setp > 0 && setp < sum)
                    {
                        // MessageBox.Show(setp.ToString() +"=="+ sum.ToString()); ;
                        if (before_curve.GetEndPoint(1).IsAlmostEqualTo(boundary.GetCurve().GetEndPoint(0)) == false)
                        {
// ... truncated ...
```

