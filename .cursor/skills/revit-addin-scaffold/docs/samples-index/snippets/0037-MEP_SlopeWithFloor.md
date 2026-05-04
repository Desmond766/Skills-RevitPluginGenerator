# Sample Snippet: MEP_SlopeWithFloor

Source project: `existingCodes\品成插件源代码\机电\MEP_SlopeWithFloor\MEP_SlopeWithFloor`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI.Selection;
using System.Windows.Forms;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.DB.Electrical;

namespace MEP_SlopeWithFloor
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public static double Distance { get; set; }
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            #region 判断加密
            //        //注册验证
            //        string licFile = string.Format("{0}\\Key.lic",
            //System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
            //        if (!BTAddInHelper.Utils.CheckReg(licFile))
            //        {
            //            return Result.Cancelled;
            //        }
            #endregion

            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;

            // 判断是否存在三维视图
            //View3D view = Get3DView(doc);
            View3D view = doc.ActiveView as View3D;
            if (null == view)
            {
                message = "错误1：请在三维视图下执行程序！";
                return Result.Failed;
            }



            //弹出对话框
            using (SettingForm sf = new SettingForm())
            {
                if (DialogResult.OK != sf.ShowDialog())
                {
                    return Result.Failed;
                }
            }
            //插件运行前先选择机电管线（可框选，插件会过滤处机电管线）
            //否则搜索当前视图中可见的机电管线
            Selection selection = uiapp.ActiveUIDocument.Selection;
            List<Element> meps = new List<Element>();
            meps = selection.GetElementIds()
                .Select(u => doc.GetElement(u))
                .Where(u => u is MEPCurve).ToList();
            if (meps.Count == 0)
            {
                //过滤出机电管线
                FilteredElementCollector mepCollector = new FilteredElementCollector(doc, doc.ActiveView.Id);
                meps = mepCollector.OfClass(typeof(MEPCurve)).WhereElementIsNotElementType().ToList();
            }

            //选择垂直坡度方向
            XYZ flatDir = XYZ.Zero;
            Reference edgeRef = selection.PickObject(ObjectType.Edge, "选择垂直坡度方向");
            Edge edge = doc.GetElement(edgeRef).GetGeometryObjectFromReference(edgeRef) as Edge;
            if (null != edge)
            {
                Curve curve = edge.AsCurve();
                flatDir = (curve as Line).Direction;
            }
            else
            {
                Curve curve = (doc.GetElement(edgeRef).Location as LocationCurve).Curve;
                flatDir = (curve as Line).Direction;
            }

            //收集起点、终点连接件最后删掉
            List<ElementId> fittingIdList = new List<ElementId>();
            using (Transaction trans = new Transaction(doc, "SlopeWithFloor"))
            {
                trans.Start();
                foreach (var elem in meps)
                {
// ... truncated ...
```

## Utils.cs

```csharp
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.DB.Plumbing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEP_SlopeWithFloor
{
    public static class Utils
    {
        #region FindConnectedTo
        /// <summary>
        /// FindConnectedTo
        /// </summary>
        /// <param name="curve"></param>
        /// <param name="conXYZ"></param>
        /// <returns></returns>
        public static Connector FindConnectedTo(Connector connItself)
        {
            ConnectorSet connSet = connItself.AllRefs;
            foreach (Connector conn in connSet)
            {
                if (conn.Owner.Id.IntegerValue != connItself.Owner.Id.IntegerValue
                    && conn.ConnectorType != ConnectorType.Logical)//&& conn.ConnectorType == ConnectorType.End
                {
                    return conn;
                }
            }
            return null;
        }
        #endregion

        #region 获得ConSet
        /// <summary>
        /// 获得ConSet
        /// </summary>
        /// <param name="elem"></param>
        /// <returns></returns>
        public static ConnectorSet GetConSet(Element elem)
        {
            // 获得conSet
            ConnectorSet conSet = null;
            if (elem is MEPCurve)
            {
                conSet = (elem as MEPCurve).ConnectorManager.Connectors;
            }
            else if (elem is FamilyInstance)
            {
                conSet = (elem as FamilyInstance).MEPModel.ConnectorManager.Connectors;
            }
            return conSet;
        }
        #endregion

        #region 获得连接到的构件
        /// <summary>
        /// 获得连接到的构件
        /// </summary>
        /// <param name="elem"></param>
        public static List<Element> FindConnectedToList(Element elem)
        {
            List<Element> connToList = new List<Element>();
            // 获得conSet
            ConnectorSet conSet = Utils.GetConSet(elem);
            foreach (Connector con in conSet)
            {
                Connector connToCon = Utils.FindConnectedTo(con);
                if (null != connToCon)
                {
                    connToList.Add(connToCon.Owner);
                }
            }
            return connToList;
        }
        #endregion

        #region 获得指定位置处管道的连接件
        /// <summary>
        /// 获得指定位置处管道的连接件
        /// </summary>
        /// <param name="pipe">管道</param>
        /// <param name="conXYZ">位置</param>
        /// <returns>连接件</returns>
        public static Connector FindConnector(MEPCurve curve, XYZ conXYZ)
        {
            ConnectorSet conns = curve.ConnectorManager.Connectors;
// ... truncated ...
```

