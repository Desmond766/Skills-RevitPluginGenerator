using System;
using System.Collections.Generic;
using System.Text;
using Autodesk.Revit;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.DB.Electrical;
using System.Windows.Forms;

namespace MEP_SmartConnect
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        private static string _datum;
        public static string Datum
        {
            get { return Command._datum; }
            set { Command._datum = value; }
        }
        private static double _angle;
        public static double Angle
        {
            get { return Command._angle; }
            set { Command._angle = value; }
        }

        XYZ startPoint;
        XYZ middlePoint1;
        XYZ datumPoint;
        XYZ middlePoint2;
        XYZ endPoint;
        XYZ cornerPoint1;
        XYZ cornerPoint2;
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            #region 判断加密
            //注册验证
            string licFile = string.Format("{0}\\Key.lic",
    System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
            if (!BTAddInHelper.Utils.CheckReg(licFile))
            {
                return Result.Cancelled;
            }

            #endregion

            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;

            // 弹出对话框
            using (SettingForm sf = new SettingForm())
            {
                if (DialogResult.OK != sf.ShowDialog())
                {
                    return Result.Failed;
                }
            }

            while (true)
            {
                try
                {
                    // 选择构件
                    Reference r1 = sel.PickObject(ObjectType.Element, new MEPSelectionFilter(), "点击【管道】、【风管】、【桥架】、【线管】");
                    Reference r2 = sel.PickObject(ObjectType.Element, new MEPSelectionFilter(), "点击【管道】、【风管】、【桥架】、【线管】");
                    MEPCurve e1 = doc.GetElement(r1) as MEPCurve;
                    MEPCurve e2 = doc.GetElement(r2) as MEPCurve;
                    Line line1 = (e1.Location as LocationCurve).Curve as Line;
                    Line line2 = (e2.Location as LocationCurve).Curve as Line;

                    if (!line1.Direction.IsAlmostEqualTo(line2.Direction) && !line1.Direction.IsAlmostEqualTo(line2.Direction.Negate()))
                    {
                        message = "请选择两个【平行】的机电管线";
                        return Result.Failed;
                    }

                    // 判断起点、终点
                    List<XYZ> endPointList = Utils.GetEndPoint(line1, line2);
                    startPoint = endPointList[0];
                    middlePoint1 = endPointList[1];
                    middlePoint2 = endPointList[2];
                    endPoint = endPointList[3];
                    if (_datum == "FirstPick")
                    {
                        datumPoint = middlePoint1;
                    }
                    else if (_datum == "SecondPick")
                    {
                        datumPoint = middlePoint2;
                    }
                    else// Center
                    {
                        datumPoint = (middlePoint1 + middlePoint2) / 2.0;
                    }

                    // 计算关键点
                    cornerPoint1 = Utils.GetProjectivePoint(line1, datumPoint);
                    cornerPoint2 = Utils.GetProjectivePoint(line2, datumPoint);
                    // 角度产生的偏移
                    if (_angle != 90.0)
                    {
                        XYZ direction1 = (startPoint - middlePoint1).Normalize();
                        XYZ direction2 = (endPoint - middlePoint2).Normalize();
                        double distance = (cornerPoint1.DistanceTo(cornerPoint2) / 2.0) / Math.Tan(Math.PI * _angle / 180.0);
                        cornerPoint1 += direction1 * distance;
                        cornerPoint2 += direction2 * distance;
                    }

                    using (Transaction t = new Transaction(doc, "BimtransMEPTools.SmartConnect"))
                    {
                        t.Start();
                        Connect(doc, e1, e2);
                        t.Commit();
                    }
                }
                catch
                {
                    break;
                }
            }

            return Result.Succeeded;
        }
        #region 智能连接
        /// <summary>
        /// 智能连接
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="e1"></param>
        /// <param name="e2"></param>
        private void Connect(Document doc, MEPCurve e1, MEPCurve e2)
        {
            // 起点、终点连接件
            Connector startConn = Utils.FindConnectedTo(e1, startPoint);
            Connector endConn = Utils.FindConnectedTo(e2, endPoint);

            if (e1 is Pipe && e2 is Pipe)
            {
                // 绘制第一段
                Pipe originalStartPipe = e1 as Pipe;
                Pipe startPipe = null;
                if (null != startConn)
                {
                    startPipe = Pipe.Create(doc, originalStartPipe.PipeType.Id, originalStartPipe.ReferenceLevel.Id, startConn, cornerPoint1);
                }
                else
                {
                    startPipe = Pipe.Create(doc, originalStartPipe.MEPSystem.GetTypeId(), originalStartPipe.PipeType.Id, originalStartPipe.ReferenceLevel.Id, startPoint, cornerPoint1);
                }
                Utils.CopyParameters(originalStartPipe, startPipe);
                // 绘制第二段
                Pipe originalEndPipe = e2 as Pipe;
                Pipe endPipe = null;
                if (null != endConn)
                {
                    endPipe = Pipe.Create(doc, originalEndPipe.PipeType.Id, originalEndPipe.ReferenceLevel.Id, endConn, cornerPoint2);
                }
                else
                {
                    endPipe = Pipe.Create(doc, originalEndPipe.MEPSystem.GetTypeId(), originalEndPipe.PipeType.Id, originalEndPipe.ReferenceLevel.Id, endPoint, cornerPoint2);
                }
                Utils.CopyParameters(originalEndPipe, endPipe);
                // 绘制中间段
                Pipe middlePipe = Pipe.Create(doc, originalStartPipe.MEPSystem.GetTypeId(), originalStartPipe.PipeType.Id, originalStartPipe.ReferenceLevel.Id, cornerPoint1, cornerPoint2);
                Utils.CopyParameters(originalStartPipe, middlePipe);
                // 创建弯头
                Connector connStart1 = Utils.FindConnector(startPipe, cornerPoint1);
                Connector connStart2 = Utils.FindConnector(middlePipe, cornerPoint1);
                doc.Create.NewElbowFitting(connStart1, connStart2);
                Connector connStart3 = Utils.FindConnector(endPipe, cornerPoint2);
                Connector connStart4 = Utils.FindConnector(middlePipe, cornerPoint2);
                doc.Create.NewElbowFitting(connStart3, connStart4);
            }
            if (e1 is Duct && e2 is Duct)
            {
                // 绘制第一段
                Duct originalStartDuct = e1 as Duct;
                Duct startDuct = Duct.Create(doc, originalStartDuct.MEPSystem.GetTypeId(), originalStartDuct.DuctType.Id, originalStartDuct.ReferenceLevel.Id, startPoint, cornerPoint1);
                Utils.CopyParameters(originalStartDuct, startDuct);
                if (null != startConn)
                {
                    startConn.ConnectTo(Utils.FindConnector(startDuct, startPoint));
                }
                // 绘制第二段
                Duct originalEndDuct = e2 as Duct;
                Duct endDuct = Duct.Create(doc, originalEndDuct.MEPSystem.GetTypeId(), originalEndDuct.DuctType.Id, originalEndDuct.ReferenceLevel.Id, endPoint, cornerPoint2);
                Utils.CopyParameters(originalEndDuct, endDuct);
                if (null != endConn)
                {
                    endConn.ConnectTo(Utils.FindConnector(endDuct, endPoint));
                }
                // 绘制中间段
                Duct middleDuct = Duct.Create(doc, originalStartDuct.MEPSystem.GetTypeId(), originalStartDuct.DuctType.Id, originalStartDuct.ReferenceLevel.Id, cornerPoint1, cornerPoint2);
                Utils.CopyParameters(originalStartDuct, middleDuct);
                // 创建弯头
                Connector connStart1 = Utils.FindConnector(startDuct, cornerPoint1);
                Connector connStart2 = Utils.FindConnector(middleDuct, cornerPoint1);
                doc.Create.NewElbowFitting(connStart1, connStart2);
                Connector connStart3 = Utils.FindConnector(endDuct, cornerPoint2);
                Connector connStart4 = Utils.FindConnector(middleDuct, cornerPoint2);
                doc.Create.NewElbowFitting(connStart3, connStart4);
            }
            if (e1 is CableTray && e2 is CableTray)
            {
                // 绘制第一段
                CableTray originalStartCableTray = e1 as CableTray;
                CableTray startCableTray = CableTray.Create(doc, originalStartCableTray.GetTypeId(), startPoint, cornerPoint1, originalStartCableTray.ReferenceLevel.Id);
                Utils.CopyParameters(originalStartCableTray, startCableTray);
                if (null != startConn)
                {
                    startConn.ConnectTo(Utils.FindConnector(startCableTray, startPoint));
                }
                // 绘制第二段
                CableTray originalEndCableTray = e2 as CableTray;
                CableTray endCableTray = CableTray.Create(doc, originalEndCableTray.GetTypeId(), endPoint, cornerPoint2, originalEndCableTray.ReferenceLevel.Id);
                Utils.CopyParameters(originalEndCableTray, endCableTray);
                if (null != endConn)
                {
                    endConn.ConnectTo(Utils.FindConnector(endCableTray, endPoint));
                }
                // 绘制中间段
                CableTray middleCableTray = CableTray.Create(doc, originalStartCableTray.GetTypeId(), cornerPoint1, cornerPoint2, originalStartCableTray.ReferenceLevel.Id);
                Utils.CopyParameters(originalEndCableTray, middleCableTray);
                // 创建弯头
                Connector connStart1 = Utils.FindConnector(startCableTray, cornerPoint1);
                Connector connStart2 = Utils.FindConnector(middleCableTray, cornerPoint1);
                doc.Create.NewElbowFitting(connStart1, connStart2);
                Connector connStart3 = Utils.FindConnector(endCableTray, cornerPoint2);
                Connector connStart4 = Utils.FindConnector(middleCableTray, cornerPoint2);
                doc.Create.NewElbowFitting(connStart3, connStart4);
            }
            if (e1 is Conduit && e2 is Conduit)
            {
                // 绘制第一段
                Conduit originalStartConduit = e1 as Conduit;
                Conduit startConduit = Conduit.Create(doc, originalStartConduit.GetTypeId(), startPoint, cornerPoint1, originalStartConduit.ReferenceLevel.Id);
                Utils.CopyParameters(originalStartConduit, startConduit);
                if (null != startConn)
                {
                    startConn.ConnectTo(Utils.FindConnector(startConduit, startPoint));
                }
                // 绘制第二段
                Conduit originalEndConduit = e2 as Conduit;
                Conduit endConduit = Conduit.Create(doc, originalEndConduit.GetTypeId(), endPoint, cornerPoint2, originalEndConduit.ReferenceLevel.Id);
                Utils.CopyParameters(originalEndConduit, endConduit);
                if (null != endConn)
                {
                    endConn.ConnectTo(Utils.FindConnector(endConduit, endPoint));
                }
                // 绘制中间段
                Conduit middleConduit = Conduit.Create(doc, originalStartConduit.GetTypeId(), cornerPoint1, cornerPoint2, originalStartConduit.ReferenceLevel.Id);
                Utils.CopyParameters(originalStartConduit, middleConduit);
                // 创建弯头
                Connector connStart1 = Utils.FindConnector(startConduit, cornerPoint1);
                Connector connStart2 = Utils.FindConnector(middleConduit, cornerPoint1);
                doc.Create.NewElbowFitting(connStart1, connStart2);
                Connector connStart3 = Utils.FindConnector(endConduit, cornerPoint2);
                Connector connStart4 = Utils.FindConnector(middleConduit, cornerPoint2);
                doc.Create.NewElbowFitting(connStart3, connStart4);
            }
            // 删除原管
            doc.Delete(e1.Id);
            doc.Delete(e2.Id);
        }
        #endregion
    }
    #region MEPSelectionFilter
    public class MEPSelectionFilter : ISelectionFilter
    {
        public bool AllowElement(Element element)
        {
            if (element is Pipe || element is Duct || element is CableTray || element is Conduit)
            {
                return true;
            }
            return false;
        }
        public bool AllowReference(Reference refer, XYZ point)
        {
            return false;
        }
    }
    #endregion
}
