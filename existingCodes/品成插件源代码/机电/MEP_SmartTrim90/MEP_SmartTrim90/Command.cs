using System;
using System.Collections.Generic;
using System.Text;
using Autodesk.Revit;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.DB.Plumbing;

namespace MEP_SmartTrim90
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        XYZ startPoint;
        XYZ endPoint;
        XYZ fittingPoint1;
        XYZ fittingPoint2;
        XYZ corner1;
        XYZ corner2;

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;

            // 选择构件
            Reference r1 = sel.PickObject(ObjectType.Element, new PipeSelectionFilter(), "选择管道");
            Reference r2 = sel.PickObject(ObjectType.Element, new PipeSelectionFilter(), "选择管道");
            Pipe pipe1 = doc.GetElement(r1) as Pipe;
            Pipe pipe2 = doc.GetElement(r2) as Pipe;
            Line line1 = (pipe1.Location as LocationCurve).Curve as Line;
            Line line2 = (pipe2.Location as LocationCurve).Curve as Line;

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
                message = "构件不垂直或没有交点！";
                return Result.Failed;
            }
            double trimDistance = pipe1.get_Parameter(BuiltInParameter.RBS_PIPE_DIAMETER_PARAM).AsDouble() * 1.6;
            corner1 = projectivePoint + direction1 * trimDistance;
            corner2 = projectivePoint + direction2 * trimDistance;


            using (Transaction t = new Transaction(doc, "BimtransMEPTools.SmartTrim"))
            {
                t.Start();
                Trim90(doc, pipe1, pipe2);
                t.Commit();
            }

            return Result.Succeeded;
        }

        #region 90度弯头
        /// <summary>
        /// 90度弯头
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="pipe1"></param>
        /// <param name="pipe2"></param>
        private void Trim90(Document doc, Pipe pipe1, Pipe pipe2)
        {
            // 原管属性
            Parameter parameter = pipe1.get_Parameter(BuiltInParameter.RBS_START_LEVEL_PARAM);
            ElementId levelId = parameter.AsElementId();
            ElementId systemTypeId = pipe1.MEPSystem.GetTypeId();
            PipeType pipeType = pipe1.PipeType;

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
            Connector connStart1 = Utils.FindConnector(startPipe, corner1);
            Connector connEnd1 = Utils.FindConnector(endPipe, corner2);
            doc.Create.NewElbowFitting(connStart1, connEnd1);

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
        #endregion



    }
    #region PipeSelectionFilter
    public class PipeSelectionFilter : ISelectionFilter
    {
        public bool AllowElement(Element element)
        {
            if (element is Autodesk.Revit.DB.Plumbing.Pipe)
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
