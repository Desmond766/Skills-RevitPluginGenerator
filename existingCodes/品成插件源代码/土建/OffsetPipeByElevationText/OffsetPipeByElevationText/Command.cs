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

namespace OffsetPipeByElevationText
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        double startOffset = 100.0 / 304.8;
        double endOffset = -100 / 304.8;
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            
            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;

            FilteredElementCollector collector = new FilteredElementCollector(doc);
            PipeType pipeType = collector.OfClass(typeof(PipeType)).First() as PipeType;

            //first pick mepcurve
            Reference reference1 = sel.PickObject(ObjectType.Element);
            Element element1 = doc.GetElement(reference1);
            //second pick startText
            Reference reference2 = sel.PickObject(ObjectType.Element);
            Element element2 = doc.GetElement(reference2);
            //3rd pick endText
            Reference reference3 = sel.PickObject(ObjectType.Element);
            Element element3 = doc.GetElement(reference3);
            if (!(element1 is MEPCurve) || !(element2 is TextNote) || !(element3 is TextNote))
            {
                message = "首先选择管道起点，再选择起点标高文字，最后选择终点标高文字";
                return Result.Cancelled;
            }

            // mepCurve
            MEPCurve mepCurve = element1 as MEPCurve;
            Curve curve = (mepCurve.Location as LocationCurve).Curve;
            XYZ startPoint = curve.GetEndPoint(0);
            XYZ endPoint = curve.GetEndPoint(1);
            XYZ splitPoint = GetProjectivePoint(startPoint, endPoint, reference1.GlobalPoint);
            if (splitPoint.DistanceTo(startPoint) > splitPoint.DistanceTo(endPoint))
            {
                startPoint = curve.GetEndPoint(1);
                startPoint = curve.GetEndPoint(0);
            }
            double diameter = mepCurve.get_Parameter(BuiltInParameter.RBS_PIPE_DIAMETER_PARAM).AsDouble();
            // startText & endText
            TextNote startText = element2 as TextNote;
            TextNote endText = element3 as TextNote;
            try
            {
                startOffset = double.Parse(startText.Text) / 0.3048 + diameter / 2.0;
                endOffset = double.Parse(endText.Text) / 0.3048 + diameter / 2.0;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return Result.Cancelled;
            }
            startPoint = new XYZ(startPoint.X, startPoint.Y, startOffset);
            endPoint = new XYZ(endPoint.X, endPoint.Y, endOffset);

            Transaction trans = new Transaction(doc, "SlopePipe");
            trans.Start();
            //create new Pipe
            Pipe newPipe = Pipe.Create(doc,
                mepCurve.MEPSystem.GetTypeId(),
                mepCurve.GetTypeId(),
                mepCurve.ReferenceLevel.Id,
                startPoint, endPoint);
            //copy parameters
            CopyParameters(mepCurve as Pipe, newPipe);
            //delete old pipe
            doc.Delete(mepCurve.Id);
            trans.Commit();


            return Result.Succeeded;
        }

        #region 获得点在直线上的投影点坐标
        /// <summary>
        /// 获得点在直线上的投影点坐标
        /// </summary>
        /// <param name="p1">直线起点</param>
        /// <param name="p2">直线终点</param>
        /// <param name="q">直线外的点</param>
        /// <returns>投影点</returns>
        public XYZ GetProjectivePoint(XYZ p1, XYZ p2, XYZ q)
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
        public XYZ GetProjectivePoint(Line l, XYZ q)
        {
            XYZ u = l.Direction;
            XYZ pq = q - l.GetEndPoint(0);
            XYZ w2 = pq - u.Multiply(pq.DotProduct(u) / (u.GetLength() * u.GetLength()));
            XYZ point = q - w2;
            return point;
        }

        #endregion

        /// <summary>
        /// 复制工作集
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        private void CopyPartition(Element source, Element target)
        {
            Parameter partition = source.get_Parameter(BuiltInParameter.ELEM_PARTITION_PARAM);
            if (null != partition)
            {
                target.get_Parameter(BuiltInParameter.ELEM_PARTITION_PARAM).Set(partition.AsInteger());
            }
        }

        public void CopyParameters(Pipe source, Pipe target)
        {
            double diameter = source.get_Parameter(BuiltInParameter.RBS_PIPE_DIAMETER_PARAM).AsDouble();
            target.get_Parameter(BuiltInParameter.RBS_PIPE_DIAMETER_PARAM).Set(diameter);
            CopyPartition(source, target);
        }
    }
}
