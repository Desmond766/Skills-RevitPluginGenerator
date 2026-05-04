# Sample Snippet: MEP_SmartMove

Source project: `existingCodes\品成插件源代码\机电\MEP_SmartMove\MEP_SmartMove`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.DB.Plumbing;
using System.Windows.Forms;

//TODOLIST
//1支管上是变径的情况
//2四通变三通

namespace MEP_SmartMove
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        private XYZ _planeNormal;
        private Dictionary<int, Element> _mainDict = new Dictionary<int, Element>();//干管构件
        private Dictionary<int, Element> _branchDict = new Dictionary<int, Element>();//支管构件
        List<Tuple<Connector, Connector>> _toConnect = new List<Tuple<Connector, Connector>>();//待连接的连接件

        private double _distance = 4000 / 304.8;//移动距离

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;

            //选择管线
            Reference reference = sel.PickObject(ObjectType.Element,
                new MEPCurveSelectionFilter(), "请选择一根管线进行移动！");
            Element element = doc.GetElement(reference);

            //添加第一个
            _mainDict.Add(element.Id.IntegerValue, element);

            MEPCurve mep = element as MEPCurve;
            Line mepLine = (mep.Location as LocationCurve).Curve as Line;
            _planeNormal = mepLine.Direction.CrossProduct(XYZ.BasisZ).Normalize();

            //绘制模型线判断方向
            ModelCurve modelCurve = null;
            using (Transaction t = new Transaction(doc, "createModelCurve"))
            {
                t.Start();
                modelCurve = Utils.DrawModelCurve(doc, reference.GlobalPoint, reference.GlobalPoint + _planeNormal * 3);
                t.Commit();
            }

            //弹出对话框
            FrmSetting fs = new FrmSetting();
            if (DialogResult.OK != fs.ShowDialog())
            {
                return Result.Cancelled;
            }
            if (fs.Distance < 0)
            {
                _planeNormal *= -1;
            }
            _distance = Math.Abs(fs.Distance);

            //删除模型线
            using (Transaction t = new Transaction(doc, "deleteModelCurve"))
            {
                t.Start();
                doc.Delete(modelCurve.Id);
                t.Commit();
            }

            //递归寻找干管构件、支管管件
            FindConnectTo(element);

            //根据移动距离判断是否需要另外处理
            using (Transaction t = new Transaction(doc, "SmartMove"))
            {
                t.Start();
                foreach (var item in _branchDict)
                {
                    MoveWithFitting(doc, item.Value as MEPCurve);
                }
                //移动
                ElementTransformUtils.MoveElement(doc, element.Id, _planeNormal * _distance);//TODO
                //连接连接件
                foreach (var item in _toConnect)
// ... truncated ...
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

namespace MEP_SmartMove
{
    class MEPHelper
    {
        public static MEPCurve Create(Document doc, MEPCurve mepCurve, XYZ startPoint, XYZ endPoint)
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

            //删除参考管线
            doc.Delete(mepCurve.Id);

            return newCurve;
        }

        public static MEPCurve Create(Document document, MEPCurve mepCurve, Connector startConn, XYZ endPoint)
        {
            MEPCurve newCurve = Create(document, mepCurve, startConn.Origin, endPoint);
            Connector con = Utils.FindConnector(newCurve, startConn.Origin);
            startConn.ConnectTo(con);
            return newCurve;
        }

        public static MEPCurve Create(Document document, MEPCurve mepCurve, XYZ startPoint, Connector endConn)
        {
            MEPCurve newCurve = Create(document, mepCurve, startPoint, endConn.Origin);
            Connector con = Utils.FindConnector(newCurve, endConn.Origin);
            endConn.ConnectTo(con);
            return newCurve;
        }

        public static MEPCurve Create(Document document, MEPCurve mepCurve, Connector startConn, Connector endConn)
        {
            MEPCurve newCurve = Create(document, mepCurve, startConn.Origin, endConn.Origin);
            Connector con1 = Utils.FindConnector(newCurve, startConn.Origin);
            Connector con2 = Utils.FindConnector(newCurve, endConn.Origin);
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

namespace MEP_SmartMove
{
    class Utils
    {
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
            }
            return null;
        }
        #endregion

        #region 获得指定位置处配件的连接件
        /// <summary>
        /// 获得指定位置处管道的连接件
        /// </summary>
        /// <param name="elem">配件</param>
// ... truncated ...
```

