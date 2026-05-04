# Sample Snippet: MEP_SmartOffset

Source project: `existingCodes\品成插件源代码\机电\MEP_SmartOffset\MEP_SmartOffset`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
//using System.Windows.Forms;
using System.IO;
using System.Windows.Forms;

namespace MEP_SmartOffset
{
    [Transaction(TransactionMode.Manual)]
    public class Command:IExternalCommand
    {
        public static string rbtn_Angle = "45度";
        public static double cbx_Distance = 100;
        public static double cbx_DistanceHor = 100;
        public Result Execute(ExternalCommandData commandData, ref string message, Autodesk.Revit.DB.ElementSet elements)
        {

            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;

            //弹出设置窗口
            using (SettingForm sf = new SettingForm())
            {
                if (DialogResult.OK != sf.ShowDialog())
                {
                    return Result.Failed;
                }
            }


            //拾取障碍构件
            TaskDialog.Show("提示：", "请拾取障碍管线");
            Reference r1 = sel.PickObject(ObjectType.Element, new MEPCurveSelectionFilter(), "选择机电管线");

            //选择爬升构件
            TaskDialog.Show("提示：", "选择要爬升的管线，点击左上角“完成”按钮结束选择");
            IList<Reference> iList = sel.PickObjects(ObjectType.Element, new MEPCurveSelectionFilter(), "选择要爬升的构件");

            Resolver resolver = new Resolver(commandData);
            
             using (Transaction t = new Transaction(doc, "机电管线避让"))
             {
                 t.Start();
                 resolver.Resolve(r1, iList);
                 t.Commit();
             }

            return Result.Succeeded;
        }
    }
}

```

## MEPHelper.cs

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

namespace MEP_SmartOffset
{
    class MEPHelper
    {
        #region 创建管线
        public static MEPCurve CreateMEPCurve(Document doc, MEPCurve mepCurve, XYZ startPoint, XYZ endPoint)
        {
            MEPCurve newCurve = null;

            //标高
            Parameter parameter = mepCurve.get_Parameter(BuiltInParameter.RBS_START_LEVEL_PARAM);
            ElementId levelId = parameter.AsElementId();

            if (mepCurve is Pipe)
            {
                Pipe pipe = mepCurve as Pipe;
                ElementId systemTypeId = pipe.MEPSystem.GetTypeId();
                PipeType pipeType = pipe.PipeType;
                //创建管道
                newCurve = Pipe.Create(doc, systemTypeId, pipeType.Id, levelId, startPoint, endPoint);
                //复制参数
                Utils.CopyParameters(pipe, newCurve as Pipe);
            }
            else if (mepCurve is Duct)
            {
                Duct duct = mepCurve as Duct;
                ElementId systemTypeId = duct.MEPSystem.GetTypeId();
                DuctType ductType = duct.DuctType;
                //创建风管
                newCurve = Duct.Create(doc, systemTypeId, ductType.Id, levelId, startPoint, endPoint);
                //复制参数
                Utils.CopyParameters(duct, newCurve as Duct);
                RotateFix(doc, newCurve, duct);
            }
            else if (mepCurve is CableTray)
            {
                CableTray cableTray = mepCurve as CableTray;
                ElementId cabletrayType = cableTray.GetTypeId();
                //创建桥架
                newCurve = CableTray.Create(doc, cabletrayType, startPoint, endPoint, levelId);
                //复制参数
                Utils.CopyParameters(cableTray, newCurve as CableTray);
                RotateFix(doc, newCurve, cableTray);
            }
            else if (mepCurve is Conduit)
            {
                Conduit conduit = mepCurve as Conduit;
                ElementId conduitType = conduit.GetTypeId();
                //创建线管
                newCurve = Conduit.Create(doc, conduitType, startPoint, endPoint, levelId);
                //复制参数
                Utils.CopyParameters(conduit, newCurve as Conduit);
            }

            return newCurve;
        }

        public static MEPCurve CreateMEPCurve(Document document, MEPCurve mepCurve, Connector startConn, XYZ endPoint)
        {
            MEPCurve newCurve = CreateMEPCurve(document, mepCurve, startConn.Origin, endPoint);
            Connector con = Utils.FindConnector(newCurve, startConn.Origin);
            startConn.ConnectTo(con);
            return newCurve;
        }

        public static MEPCurve CreateMEPCurve(Document document, MEPCurve mepCurve, XYZ startPoint, Connector endConn)
        {
            MEPCurve newCurve = CreateMEPCurve(document, mepCurve, startPoint, endConn.Origin);
            Connector con = Utils.FindConnector(newCurve, endConn.Origin);
            endConn.ConnectTo(con);
            return newCurve;
        }

        public static MEPCurve CreateMEPCurve(Document document, MEPCurve mepCurve, Connector startConn, Connector endConn)
        {
            MEPCurve newCurve = CreateMEPCurve(document, mepCurve, startConn.Origin, endConn.Origin);
            Connector con1 = Utils.FindConnector(newCurve, startConn.Origin);
            Connector con2 = Utils.FindConnector(newCurve, endConn.Origin);
            startConn.ConnectTo(con1);
            endConn.ConnectTo(con2);
// ... truncated ...
```

## Utils.cs

```csharp
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEP_SmartOffset
{
    enum FittingType { Transition, Elbow, Tee, Cross };
    enum DuctElbowType { ElbowPlane, ElbowOffset };

    class Utils
    {
        #region 获得点在直线上的投影点坐标
        /// <summary>
        /// 获得点在直线上的投影点坐标
        /// </summary>
        /// <param name="p1">直线起点</param>
        /// <param name="p2">直线终点</param>
        /// <param name="q">直线外的点</param>
        /// <returns>投影点</returns>
        public static XYZ GetProjectivePoint(XYZ p1, XYZ p2, XYZ q)
        {
            XYZ u = p2 - p1;
            XYZ pq = q - p1;
            XYZ w2 = pq - u.Multiply(pq.DotProduct(u) / (u.GetLength() * u.GetLength()));
            XYZ point = q - w2;
            return point;
        }

        /// <summary>
        /// 获得点在直线上的投影点坐标
        /// </summary>
        /// <param name="l">直线</param>
        /// <param name="q">直线外的点</param>
        /// <returns>投影点</returns>
        public static XYZ GetProjectivePoint(Line l, XYZ q)
        {
            XYZ u = l.Direction;
            XYZ pq = q - l.GetEndPoint(0);
            XYZ w2 = pq - u.Multiply(pq.DotProduct(u) / (u.GetLength() * u.GetLength()));
            XYZ point = q - w2;
            return point;
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
            foreach (Connector conn in conns)
            {
                if (conn.Origin.IsAlmostEqualTo(conXYZ))
                {
                    return conn;
                }
// ... truncated ...
```

