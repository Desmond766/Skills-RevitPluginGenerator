# Sample Snippet: PipeSetSlopeWithTerrian

Source project: `existingCodes\品成插件源代码\土建\PipeSetSlopeWithTerrian\PipeSetSlopeWithTerrian`

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
using System.Windows.Forms;

namespace PipeSetSlopeWithTerrian
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        bool _autoMode = false;
        double _offset = 500 / 304.8;

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;

            //过滤出管道
            List<MEPCurve> meps = new List<MEPCurve>();
            foreach (var item in sel.GetElementIds())
            {
                Element elem = doc.GetElement(item);
                if (elem is MEPCurve)
                {
                    meps.Add(elem as MEPCurve);
                }
            }
            if (meps.Count == 0)
            {
                message = "请先选择管道再运行插件";
                return Result.Cancelled;
            }

            //弹出对话框
            SettingForm sf = new SettingForm();
            if (DialogResult.OK != sf.ShowDialog())
            {
                return Result.Cancelled;
            }
            _autoMode = sf._autoMode;
            _offset = sf._offset;

            //起点集合终点集合
            List<XYZ> startPoints = new List<XYZ>();
            List<XYZ> endPoints = new List<XYZ>();

            if (!_autoMode)
            {
                //手动指定模式，指定要往下偏移的一侧
                XYZ pickPoint = sel.PickObject(ObjectType.Element).GlobalPoint;
                SeparateEndPoint(meps, pickPoint, ref startPoints, ref endPoints);
                using (Transaction tran = new Transaction(doc, "slopePipeSet_CustomMode"))
                {
                    tran.Start();
                    for (int i = 0; i < meps.Count; i++)
                    {
                        MEPHelper.Create(doc, meps[i],
                            startPoints[i] + XYZ.BasisZ.Negate() * _offset,
                            endPoints[i]);
                    }
                    tran.Commit();
                }
                return Result.Succeeded;
            }

            //找到最高的管道
            double highest = -10000.0;
            MEPCurve topCurve = null;
            XYZ startPoint = null;
            foreach (var mep in meps)
            {
                XYZ pt = (mep.Location as LocationCurve).Curve.GetEndPoint(0);

                //加上范围框的高度/2
                BoundingBoxXYZ bbox = mep.get_BoundingBox(doc.ActiveView);
                double halfTickness = (bbox.Max.Z - bbox.Min.Z) / 2.0;

                if (pt.Z + halfTickness > highest)
                {
                    highest = pt.Z + halfTickness;
                    topCurve = mep;
                    startPoint = pt + XYZ.BasisZ * halfTickness;
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

namespace PipeSetSlopeWithTerrian
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

namespace PipeSetSlopeWithTerrian
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

