//20171123修改判断newLocationLine位置的方法
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;

namespace MEP_ParallelIn3D
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, Autodesk.Revit.DB.ElementSet elements)
        {
            //        #region 判断加密
            //        //注册验证
            //        string licFile = string.Format("{0}\\Key.lic",
            //System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
            //        if (!BTAddInHelper.Utils.CheckReg(licFile))
            //        {
            //            return Result.Cancelled;
            //        }
            //        #endregion

            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;

            //try
            //{
            //    while (true)
            //    {
            //选择第一个管线，为基准
            Reference r1 = sel.PickObject(ObjectType.Element);
            Element e1 = doc.GetElement(r1.ElementId);
            if (!(e1 is MEPCurve))
            {
                TaskDialog.Show("提示", "拾取的不是管线");
                return Result.Cancelled;
            }
            //选择第二个管线，使其跟第一根平行
            Reference r2 = sel.PickObject(ObjectType.Element);
            Element e2 = doc.GetElement(r2.ElementId);
            if (!(e2 is MEPCurve))
            {
                TaskDialog.Show("提示", "拾取的不是管线");
                return Result.Cancelled;
            }
            //收集与第二个管线相连的直线上的管线
            ICollection < ElementId > iCol= null;


            //ElementTransformUtils.RotateElements();

            //基准管线的方向向量direction1
            LocationCurve locationCuve1 = e1.Location as LocationCurve;
            Line line1 = locationCuve1.Curve as Line;
            XYZ direction1 = line1.Direction;
            //第二个管线原始的方向向量direction2
            LocationCurve locationCuve2 = e2.Location as LocationCurve;
            Line line2 = locationCuve2.Curve as Line;
            XYZ direction2 = line2.Direction;

            //第二个管线的两个端点secPoint1、secPoint2、长度length2
            XYZ secPoint1 = line2.GetEndPoint(0);
            XYZ secPoint2 = line2.GetEndPoint(1);
            Double length2 = e2.get_Parameter(BuiltInParameter.CURVE_ELEM_LENGTH).AsDouble();

            //求第二个管线新的方向向量
            //判断方向向量
            XYZ newDirection = direction1.Normalize() * length2;
            XYZ newPoint1 = secPoint1 + newDirection;
            XYZ newPoint2 = secPoint1 - newDirection;
            Line newLocationLine = null;

            if (newPoint1.DistanceTo(secPoint2) - newPoint2.DistanceTo(secPoint2) < 0)
            {
                newLocationLine = Line.CreateBound(secPoint1, newPoint1);
            }
            else
            {
                newLocationLine = Line.CreateBound(secPoint1, newPoint2);
            }

            using (Transaction t = new Transaction(doc, "使平行"))
            {
                t.Start();

                locationCuve2.Curve = newLocationLine;

                t.Commit();
            }

            //e1 = e2;
            //try
            //{
            //    while (true)
            //    {

            //        Reference r3 = sel.PickObject(ObjectType.Element);
            //        Element e3 = doc.GetElement(r3);
            //        e2 = e3;
            //        ParalleIn3DIn3D(e1, e2, doc);
            //        e1 = e3;
            //    }
            //}
            //catch
            //{

            //}

            //    }
            //}
            //catch
            //{

            //}

            return Result.Succeeded;
        }

        private void ParalleIn3DIn3D(Element e1, Element e2, Document doc)
        {
            //基准管线的方向向量direction1
            LocationCurve locationCuve1 = e1.Location as LocationCurve;
            Line line1 = locationCuve1.Curve as Line;
            XYZ direction1 = line1.Direction;
            //第二个管线原始的方向向量direction2
            LocationCurve locationCuve2 = e2.Location as LocationCurve;
            Line line2 = locationCuve2.Curve as Line;
            XYZ direction2 = line2.Direction;

            //第二个管线的两个端点secPoint1、secPoint2、长度length2
            XYZ secPoint1 = line2.GetEndPoint(0);
            XYZ secPoint2 = line2.GetEndPoint(1);
            Double length2 = e2.get_Parameter(BuiltInParameter.CURVE_ELEM_LENGTH).AsDouble();

            //求第二个管线新的方向向量
            //判断方向向量
            XYZ newDirection = direction1.Normalize() * length2;
            XYZ newPoint1 = secPoint1 + newDirection;
            XYZ newPoint2 = secPoint1 - newDirection;
            Line newLocationLine = null;

            if (newPoint1.DistanceTo(secPoint2) - newPoint2.DistanceTo(secPoint2) < 0)
            {
                newLocationLine = Line.CreateBound(secPoint1, newPoint1);
            }
            else
            {
                newLocationLine = Line.CreateBound(secPoint1, newPoint2);
            }

            using (Transaction t = new Transaction(doc, "使平行"))
            {
                t.Start();

                locationCuve2.Curve = newLocationLine;

                t.Commit();
            }
        }

        private void PipeFind(Element elem, Document doc)
        {
              IList<ElementId> listId = new List<ElementId>();
              listId.Add(elem.Id);
            //找到管线连接的连接件
            //判断是三通
            //收集连接到的管线（与原管线平行的），循环
            //如果是阀件
            //收集阀件连接到的管线（与原管线平行的），循环
            //如果是弯头，不收集

        }
    }
}
