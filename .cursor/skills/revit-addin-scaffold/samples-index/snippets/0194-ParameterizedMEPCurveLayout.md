# Sample Snippet: ParameterizedMEPCurveLayout

Source project: `existingCodes\饶昌锋插件源代码\264参数化管线排布\ParameterizedMEPCurveLayout`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace ParameterizedMEPCurveLayout
{
    [TransactionAttribute(TransactionMode.Manual)]
    [RegenerationAttribute(RegenerationOption.Manual)]
    public class Command : IExternalCommand
    {
        private StartWindow window;
        private System.Windows.Controls.Frame frame;
        //事件
        MEPCurveOperationEvent mEPCurveOperationEvent;
        ExternalEvent mEPCurveOperationExternalEvent;

        ReOrderAndIntervalEvent reOrderAndIntervalEvent;
        ExternalEvent reOrderAndIntervalExternalEvent;

        PipelineConnectionEvent pipelineConnectionEvent;
        ExternalEvent pipelineConnectionExternalEvent;

        BottomAlignmentHeightDifferenceEvent bottomAlignmentHeightDifferenceEvent;
        ExternalEvent bottomAlignmentHeightDifferenceExternalEvent;


        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;

            //截断的中间管线
            IList<MEPCurve> mEPCurves = new List<MEPCurve>();
            //遍历元素 打断管线
            List<MEPCurveGroup> mEPCurveGroups = new List<MEPCurveGroup>();
            GetTargetMEPCurve.GetMEPCurveElement(uidoc, ref mEPCurves, ref mEPCurveGroups);
            double sructDistance = ProfileFrame.GetStructuralClearance(doc, mEPCurves);
            //StatrApplication.Main(uidoc);
            //WindowControl window = new WindowControl();
            window = new StartWindow();
            window.SetStructDistance(sructDistance.ToString());
            //外部事件的注册
            mEPCurveOperationEvent = new MEPCurveOperationEvent();
            mEPCurveOperationEvent.mEPCurves = mEPCurves;
            mEPCurveOperationExternalEvent = ExternalEvent.Create(mEPCurveOperationEvent);

            reOrderAndIntervalEvent = new ReOrderAndIntervalEvent();
            reOrderAndIntervalExternalEvent = ExternalEvent.Create(reOrderAndIntervalEvent);

            pipelineConnectionEvent = new PipelineConnectionEvent
            {
                mEPCurveGroups = mEPCurveGroups,
                mEPCurves = mEPCurves
            };
            pipelineConnectionExternalEvent = ExternalEvent.Create(pipelineConnectionEvent);

            bottomAlignmentHeightDifferenceEvent = new BottomAlignmentHeightDifferenceEvent();
            bottomAlignmentHeightDifferenceEvent.mEPCurves = mEPCurves;
            bottomAlignmentHeightDifferenceExternalEvent = ExternalEvent.Create(bottomAlignmentHeightDifferenceEvent);

            //外部事件的触发
            window.MEPCurveOperationEventHandler += Window_MEPCurveOperationEventHandler;
            window.ReOrderAndIntervalHandler += Window_ReOrderAndIntervalHandler;
            window.PipelineConnectionHandler += Window_PipelineConnectionHandler;
            window.BottomAlignmentHeightDifferenceHandler += Window_BottomAlignmentHeightDifferenceHandler;

            window.Show();
            frame = window.Windows;


            return Result.Succeeded;
        }

        /// <summary>
        /// 下对齐及高度间距修改的外部事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void Window_BottomAlignmentHeightDifferenceHandler(object sender, EventArgs e)
        {
            bottomAlignmentHeightDifferenceExternalEvent.Raise();
// ... truncated ...
```

## StatrApplication.cs

```csharp
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System.Collections.Generic;

namespace ParameterizedMEPCurveLayout
{
    /// <summary>
    /// 主程序 废弃！ 未使用
    /// </summary>
    public class StatrApplication
    {
        public static void Main(UIDocument uidoc)
        {
            Document doc = uidoc.Document;
            //过滤管线 框选元素 并单机获取一点
            MEPCurveFilter filter = new MEPCurveFilter();
            IList<Reference> refs = uidoc.Selection.PickObjects(ObjectType.Element, filter, "请框选管线");
            XYZ point = uidoc.Selection.PickPoint();
            //截断的中间管线
            IList<MEPCurve> mEPCurves = new List<MEPCurve>();
            //遍历元素 打断管线
            List<MEPCurveGroup> mEPCurveGroups = new List<MEPCurveGroup>();
            using (Transaction tran = new Transaction(doc, "打断管线"))
            {
                tran.Start();
                foreach (Reference item in refs)
                {
                    MEPCurve elem = doc.GetElement(item) as MEPCurve;
                    Curve curve = (elem.Location as LocationCurve).Curve;
                    //获取投影点
                    XYZ breakCurve = curve.Project(point).XYZPoint;
                    XYZ point1 = new XYZ(breakCurve.X - 1000 / 304.8, breakCurve.Y, breakCurve.Z);
                    XYZ point2 = new XYZ(breakCurve.X + 1000 / 304.8, breakCurve.Y, breakCurve.Z);
                    if (!Tools.HorizontalDirection(elem))
                    {
                        XYZ temp = point1;
                        point1 = point2;
                        point2 = temp;
                    }
                    MEPCurve newMEPCurve1 = MEPCurveOperation.BreakCurve(doc, elem, point1);
                    MEPCurve newMEPCurve2 = MEPCurveOperation.BreakCurve(doc, newMEPCurve1, point2);
                    //mEPCurves.Add(elem);
                    MEPCurveGroup mEPCurveGroup = new MEPCurveGroup();
                    mEPCurveGroup.code = newMEPCurve1.Id.ToString();
                    mEPCurveGroup.list = new List<MEPCurve> { elem, newMEPCurve1, newMEPCurve2 };
                    mEPCurves.Add(newMEPCurve1);
                    mEPCurveGroups.Add(mEPCurveGroup);
                    //mEPCurves.Add(newMEPCurve2);
                }
                tran.Commit();
            }
            MEPCurveOperation.MEPCurveGroupSort(doc, mEPCurves, 1);
            using (Transaction tran = new Transaction(doc, "重新连接排序"))
            {
                tran.Start();
                foreach (MEPCurveGroup item in mEPCurveGroups)
                {
                    Connector startConnector = null;
                    Connector endConnector = null;
                    foreach (Connector con in item.list[0].ConnectorManager.Connectors)
                    {
                        if (con.Id == 1)
                        {
                            startConnector = con;
                        }
                    }
                    foreach (Connector con in item.list[2].ConnectorManager.Connectors)
                    {
                        if (con.Id == 0)
                        {
                            endConnector = con;
                        }
                    }
                    foreach (Connector con in item.list[1].ConnectorManager.Connectors)
                    {
                        if (con.Id == 0)
                        {
                            startConnector.ConnectTo(con);
                        }
                        if (con.Id == 1)
                        {
                            endConnector.ConnectTo(con);
                        }
                    }
                }
                foreach (MEPCurve mEP in mEPCurves)
                {
                    XYZ targetPoint = Tools.GetMEPCurveCentrePoint(mEP);
                    Tools.MoveMEPCurve(doc, mEP, new XYZ(targetPoint.X, targetPoint.Y + 1, targetPoint.Z));
// ... truncated ...
```

## BottomAlignmentHeightDifferenceEvent.cs

```csharp
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ParameterizedMEPCurveLayout
{
    public class BottomAlignmentHeightDifferenceEvent : IExternalEventHandler
    {
        public IList<MEPCurve> mEPCurves { get; set; }
        public void Execute(UIApplication app)
        {
            //TaskDialog.Show("Ada",  "asdas");
            Document doc = app.ActiveUIDocument.Document;
            //排序分组写入到MEPCurveGroup类
            List<MEPCurveGroup> groups = mEPCurves.GroupBy(x => getOffsetParam(x).AsValueString()).OrderByDescending(x => x.Key).Select(x => new MEPCurveGroup() { list = x.ToList() }).ToList();
            //TaskDialog.Show("sda",groups.Count().ToString());
            using (Transaction tran = new Transaction(doc, "调整高度间距及下对齐"))                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   
            {
                tran.Start();
                bool flag = true;
                //遍历MEPCurveGroup中的List 获取上一个的底部高程和下一个的顶部高程
                if (groups.Count==1)
                {
                    foreach (MEPCurve item in groups[0].list)
                    {
                        MEPCurve bottomElevationMEPC = groups[0].list.OrderBy(x => getBottomParam(x).AsDouble()).ToList().First();
                        getBottomParam(item).Set(getBottomParam(bottomElevationMEPC).AsDouble());
                    }
                }
                for (int i = 1; i < groups.Count; i++)
                {
                    MEPCurve bottomElevationMEPC = groups[i - 1].list.OrderBy(x => getBottomParam(x).AsDouble()).ToList().First();
                    MEPCurve topElevationMEPC = groups[i].list.OrderByDescending(x => getTopParam(x).AsDouble()).ToList().First();
                    //TaskDialog.Show("asda", topElevationMEPC.Id.ToString());
                    getTopParam(topElevationMEPC).Set(getBottomParam(bottomElevationMEPC).AsDouble() - 100 / 304.8);
// ... truncated ...
```

