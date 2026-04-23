using System;
using System.Collections.Generic;
using System.Text;
using Autodesk.Revit;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.DB.Mechanical;
using System.Linq;

namespace MEP_SmartTrim
{
    [Transaction(TransactionMode.Manual)]
    class Command : IExternalCommand
    {
        XYZ startPoint;
        XYZ endPoint;
        XYZ fittingPoint1;
        XYZ fittingPoint2;
        XYZ corner1;
        XYZ corner2;
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //注册验证
            string licFile = string.Format("{0}\\Key.lic",
    System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
            if (!BTAddInHelper.Utils.CheckReg(licFile))
            {
                return Result.Cancelled;
            }

            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;

            // 选择构件
            Reference r1 = sel.PickObject(ObjectType.Element, new MepSelFilter(), "选择管道\\风管\\桥架1");
            Reference r2 = sel.PickObject(ObjectType.Element, new MepSelFilter(doc.GetElement(r1)), "选择管道\\风管\\桥架2");
            MEPCurve mEPCurve1 = doc.GetElement(r1) as MEPCurve;
            MEPCurve mEPCurve2 = doc.GetElement(r2) as MEPCurve;
            Line line1 = (mEPCurve1.Location as LocationCurve).Curve as Line;
            Line line2 = (mEPCurve2.Location as LocationCurve).Curve as Line;

            // 判断起点、终点
            double maxDistance = 0.0;
            double distance;
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    distance = line1.GetEndPoint(i).DistanceTo(line2.GetEndPoint(j));
                    if (distance > maxDistance)
                    {
                        maxDistance = distance;
                        startPoint = line1.GetEndPoint(i);
                        fittingPoint1 = line1.GetEndPoint(1 - i);
                        endPoint = line2.GetEndPoint(j);
                        fittingPoint2 = line2.GetEndPoint(1 - j);
                    }
                }
            }

            // 计算关键点
            XYZ projectivePoint = Utils.GetProjectivePoint(line2, startPoint);
            XYZ direction1 = (startPoint - projectivePoint).Normalize();
            XYZ direction2 = (endPoint - projectivePoint).Normalize();
            if (!direction1.IsAlmostEqualTo(line1.Direction) && !direction1.IsAlmostEqualTo(line1.Direction.Negate()))
            {
                message = "构件不垂直！";
                return Result.Failed;
            }
            //double trimDistance = mEPCurve1.get_Parameter(BuiltInParameter.RBS_PIPE_DIAMETER_PARAM).AsDouble() * 1.6;
            double trimDistance = (mEPCurve1.get_Parameter(BuiltInParameter.RBS_PIPE_DIAMETER_PARAM)?.AsDouble() ?? mEPCurve1.Width) * 1.6;
            corner1 = projectivePoint + direction1 * trimDistance;
            corner2 = projectivePoint + direction2 * trimDistance;

            //using (Transaction t = new Transaction(doc, "BimtransMEPTools.SmartTrim"))
            //{
            //    t.Start();
            //    Trim(doc, mEPCurve1 as Pipe, mEPCurve2 as Pipe);
            //    t.Commit();
            //}
            //using (TransactionGroup TG = new TransactionGroup(doc, "BimtransMEPTools.SmartTrim"))
            //{
            //    TG.Start();
            //    Trim(doc, mEPCurve1, mEPCurve2);
            //    TG.Assimilate();
            //}
            using (Transaction t = new Transaction(doc, "BimtransMEPTools.SmartTrim"))
            {
                t.Start();
                Trim(doc, mEPCurve1, mEPCurve2);
                t.Commit();
            }

            return Result.Succeeded;
        }

        #region 45度倒角
        /// <summary>
        /// 45度倒角
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="pipe1"></param>
        /// <param name="pipe2"></param>
        private void Trim(Document doc, Pipe pipe1, Pipe pipe2)
        {
            // 原管属性
            Parameter parameter = pipe1.get_Parameter(BuiltInParameter.RBS_START_LEVEL_PARAM);
            ElementId levelId = parameter.AsElementId();
            ElementId systemTypeId = pipe1.MEPSystem.GetTypeId();
            PipeType pipeType = pipe1.PipeType;

            // 【1】绘制倒角管道
            Pipe middlePipe = Pipe.Create(doc, systemTypeId, pipe1.PipeType.Id, levelId, corner1, corner2);
            // 复制参数
            Utils.CopyParameters(pipe1, middlePipe);

            // 起点、终点连接件
            Connector startConn = Utils.FindConnectedTo(pipe1, startPoint);
            Connector endConn = Utils.FindConnectedTo(pipe2, endPoint);

            // 【2】创建起点处管道
            Pipe startPipe = null;
            if (null != startConn)
            {
                startPipe = Pipe.Create(doc, pipe1.PipeType.Id, levelId, startConn, corner1);
            }
            else
            {
                startPipe = Pipe.Create(doc, systemTypeId, pipe1.PipeType.Id, levelId, startPoint, corner1);
            }
            // 复制参数
            Utils.CopyParameters(pipe1, startPipe);
            // 创建弯头
            Connector connStart1 = Utils.FindConnector(startPipe, corner1);
            Connector connStart2 = Utils.FindConnector(middlePipe, corner1);
            doc.Create.NewElbowFitting(connStart1, connStart2);

            // 【3】创建起点处管道
            Pipe endPipe = null;
            if (null != endConn)
            {
                endPipe = Pipe.Create(doc, pipe1.PipeType.Id, levelId, endConn, corner2);
            }
            else
            {
                endPipe = Pipe.Create(doc, systemTypeId, pipe1.PipeType.Id, levelId, endPoint, corner2);
            }
            // 复制参数
            Utils.CopyParameters(pipe2, endPipe);
            // 创建弯头
            Connector connEnd1 = Utils.FindConnector(endPipe, corner2);
            Connector connEnd2 = Utils.FindConnector(middlePipe, corner2);
            doc.Create.NewElbowFitting(connEnd1, connEnd2);

            // 【3】删除原管道
            Connector connFitting1 = Utils.FindConnectedTo(pipe1, fittingPoint1);
            if (null != connFitting1)
            {
                doc.Delete(connFitting1.Owner.Id);
            }
            Connector connFitting2 = Utils.FindConnectedTo(pipe2, fittingPoint2);
            if (null != connFitting2)
            {
                doc.Delete(connFitting2.Owner.Id);
            }
            doc.Delete(pipe1.Id);
            doc.Delete(pipe2.Id);
        }
        
        //private void Trim(Document doc, MEPCurve mEPCurve1, MEPCurve mEPCurve2)
        //{
        //    ElementId id = ElementTransformUtils.CopyElement(doc, mEPCurve1.Id, XYZ.Zero).First();
        //    MEPCurve middleMEPCurve = doc.GetElement(id) as MEPCurve;
        //    (middleMEPCurve.Location as LocationCurve).Curve = Line.CreateBound(corner1, corner2);

        //    // 起点、终点连接件
        //    Connector startConn = Utils.FindConnectedTo(mEPCurve1, startPoint);
        //    Connector endConn = Utils.FindConnectedTo(mEPCurve2, endPoint);

        //    // 【2】创建起点处管道
        //    if (null != startConn)
        //    {
        //        Line oldLine = (mEPCurve1.Location as LocationCurve).Curve as Line;
        //        Line newLine = Line.CreateBound(startConn.Origin, corner2);
        //        if (oldLine.Direction.IsAlmostEqualTo(newLine.Direction))
        //        {
        //            (mEPCurve1.Location as LocationCurve).Curve = newLine;
        //        }
        //        else
        //        {
        //            (mEPCurve1.Location as LocationCurve).Curve = Line.CreateBound(corner1, startConn.Origin);
        //        }

        //        //(mEPCurve1.Location as LocationCurve).Curve = Line.CreateBound(startConn.Origin, corner1);
        //        //(mEPCurve1.Location as LocationCurve).Curve = Line.CreateBound(corner1, startConn.Origin);
        //    }
        //    else
        //    {
        //        (mEPCurve1.Location as LocationCurve).Curve = Line.CreateBound(startPoint, corner1);
        //    }

        //    // 创建弯头
        //    //Connector connStart1 = Utils.FindConnector(mEPCurve1, corner1);
        //    //Connector connStart2 = Utils.FindConnector(middleMEPCurve, corner1);
        //    Utils.GetNearConnector(mEPCurve1, middleMEPCurve, out var connStart1, out var connStart2);

        //    doc.Create.NewElbowFitting(connStart1, connStart2);

        //    // 【3】创建起点处管道
        //    if (null != endConn)
        //    {
        //        Line oldLine = (mEPCurve2.Location as LocationCurve).Curve as Line;
        //        Line newLine = Line.CreateBound(endConn.Origin, corner2);
        //        if (oldLine.Direction.IsAlmostEqualTo(newLine.Direction))
        //        {
        //            (mEPCurve2.Location as LocationCurve).Curve = newLine;
        //        }
        //        else
        //        {
        //            (mEPCurve2.Location as LocationCurve).Curve = Line.CreateBound(corner2, endConn.Origin);
        //        }

        //        //(mEPCurve2.Location as LocationCurve).Curve = Line.CreateBound(endConn.Origin, corner2);
        //        //(mEPCurve2.Location as LocationCurve).Curve = Line.CreateBound(corner2, endConn.Origin);
        //    }
        //    else
        //    {
        //        (mEPCurve2.Location as LocationCurve).Curve = Line.CreateBound(endPoint, corner2);
        //    }

        //    // 创建弯头
        //    //Connector connEnd1 = Utils.FindConnector(mEPCurve2, corner2);
        //    //Connector connEnd2 = Utils.FindConnector(middleMEPCurve, corner2);
        //    Utils.GetNearConnector(mEPCurve2, middleMEPCurve, out var connEnd1, out var connEnd2);

        //    doc.Create.NewElbowFitting(connEnd1, connEnd2);
        //}
        private void Trim(Document doc, MEPCurve mEPCurve1, MEPCurve mEPCurve2)
        {
            ElementId id = ElementTransformUtils.CopyElement(doc, mEPCurve1.Id, XYZ.Zero).First();
            MEPCurve middleMEPCurve = doc.GetElement(id) as MEPCurve;
            (middleMEPCurve.Location as LocationCurve).Curve = Line.CreateBound(corner1, corner2);

            // 起点、终点连接件
            Connector startConn = Utils.FindConnectedTo(mEPCurve1, startPoint);
            Connector endConn = Utils.FindConnectedTo(mEPCurve2, endPoint);

            // 【2】创建起点处管道
            if (null != startConn)
            {
                Line oldLine = (mEPCurve1.Location as LocationCurve).Curve as Line;
                Line newLine = Line.CreateBound(startConn.Origin, corner1);
                if (oldLine.Direction.IsAlmostEqualTo(newLine.Direction))
                {
                    (mEPCurve1.Location as LocationCurve).Curve = newLine;
                }
                else
                {
                    (mEPCurve1.Location as LocationCurve).Curve = Line.CreateBound(corner1, startConn.Origin);
                }

                //(mEPCurve1.Location as LocationCurve).Curve = Line.CreateBound(startConn.Origin, corner1);
                //(mEPCurve1.Location as LocationCurve).Curve = Line.CreateBound(corner1, startConn.Origin);
            }
            else
            {
                (mEPCurve1.Location as LocationCurve).Curve = Line.CreateBound(startPoint, corner1);
            }

            // 创建弯头
            Connector connStart1 = Utils.FindConnector(mEPCurve1, corner1);
            Connector connStart2 = Utils.FindConnector(middleMEPCurve, corner1);
            //Utils.GetNearConnector(mEPCurve1, middleMEPCurve, out var connStart1, out var connStart2);

            doc.Create.NewElbowFitting(connStart1, connStart2);

            // 【3】创建起点处管道
            if (null != endConn)
            {
                Line oldLine = (mEPCurve2.Location as LocationCurve).Curve as Line;
                Line newLine = Line.CreateBound(endConn.Origin, corner2);
                if (oldLine.Direction.IsAlmostEqualTo(newLine.Direction))
                {
                    (mEPCurve2.Location as LocationCurve).Curve = newLine;
                }
                else
                {
                    (mEPCurve2.Location as LocationCurve).Curve = Line.CreateBound(corner2, endConn.Origin);
                }

                //(mEPCurve2.Location as LocationCurve).Curve = Line.CreateBound(endConn.Origin, corner2);
                //(mEPCurve2.Location as LocationCurve).Curve = Line.CreateBound(corner2, endConn.Origin);
            }
            else
            {
                (mEPCurve2.Location as LocationCurve).Curve = Line.CreateBound(endPoint, corner2);
            }

            // 创建弯头
            Connector connEnd1 = Utils.FindConnector(mEPCurve2, corner2);
            Connector connEnd2 = Utils.FindConnector(middleMEPCurve, corner2);
            //Utils.GetNearConnector(mEPCurve2, middleMEPCurve, out var connEnd1, out var connEnd2);

            doc.Create.NewElbowFitting(connEnd1, connEnd2);
        }
        #endregion

    }

    #region PipeSelectionFilter
    public class MepSelFilter : ISelectionFilter
    {
        public Element Element { get; set; }
        public MepSelFilter() { }
        public MepSelFilter(Element element)
        {
            Element = element;
        }
        public bool AllowElement(Element element)
        {
            
            if (Element != null)
            {
                if (Element.Category.Id == element.Category.Id && Element.Id != element.Id) return true;
                return false;
            }
            else if (element is Pipe || element is CableTray || element is Duct)
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
