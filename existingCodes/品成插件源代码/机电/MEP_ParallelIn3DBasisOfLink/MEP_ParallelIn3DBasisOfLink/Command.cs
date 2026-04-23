using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;

namespace MEP_ParallelIn3DBasisOfLink
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
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
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;
            try
            {
                while (true)
                {
                    //选择链接墙，为基准
                    Reference r1 = sel.PickObject(ObjectType.LinkedElement);
                    RevitLinkInstance linkIns = doc.GetElement(r1) as RevitLinkInstance;
                    Element e1 = linkIns.GetLinkDocument().GetElement(r1.LinkedElementId);
                    if (!(e1.Category.Id.IntegerValue == (int)BuiltInCategory.OST_Walls))
                    {
                        TaskDialog.Show("警告", "选择的不是墙");
                        return Result.Cancelled;
                    }
                    //选择管线，使其跟第一根平行
                    Reference r2 = sel.PickObject(ObjectType.Element);
                    Element e2 = doc.GetElement(r2.ElementId);
                    if (!(e2 is MEPCurve))
                    {
                        TaskDialog.Show("提示", "拾取的不是管线");
                        return Result.Cancelled;
                    }


                    //基链接墙的方向向量direction1
                    LocationCurve locationCuve1 = e1.Location as LocationCurve;
                    Line line1 = locationCuve1.Curve as Line;
                    XYZ direction1 = line1.Direction;
                    //管线原始的方向向量direction2
                    LocationCurve locationCuve2 = e2.Location as LocationCurve;
                    Line line2 = locationCuve2.Curve as Line;
                    XYZ direction2 = line2.Direction;

                    //管线的两个端点secPoint1、secPoint2、长度length2
                    XYZ secPoint1 = line2.GetEndPoint(0);
                    XYZ secPoint2 = line2.GetEndPoint(1);
                    Double length2 = e2.get_Parameter(BuiltInParameter.CURVE_ELEM_LENGTH).AsDouble();

                    //求管线新的方向向量
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
                    e1 = e2;
                    try
                    {
                        while (true)
                        {

                            Reference r3 = sel.PickObject(ObjectType.Element);
                            Element e3 = doc.GetElement(r3);
                            e2 = e3;
                            ParalleIn3DBasisOfLinkOfLink(e1, e2, doc);
                            e1 = e3;
                        }
                    }
                    catch
                    {

                    }

                }
            }
            catch
            {

            }
            return Result.Succeeded;
        }
        private void ParalleIn3DBasisOfLinkOfLink(Element e1, Element e2, Document doc)
        {
            //基链接墙的方向向量direction1
            LocationCurve locationCuve1 = e1.Location as LocationCurve;
            Line line1 = locationCuve1.Curve as Line;
            XYZ direction1 = line1.Direction;
            //管线原始的方向向量direction2
            LocationCurve locationCuve2 = e2.Location as LocationCurve;
            Line line2 = locationCuve2.Curve as Line;
            XYZ direction2 = line2.Direction;

            //管线的两个端点secPoint1、secPoint2、长度length2
            XYZ secPoint1 = line2.GetEndPoint(0);
            XYZ secPoint2 = line2.GetEndPoint(1);
            Double length2 = e2.get_Parameter(BuiltInParameter.CURVE_ELEM_LENGTH).AsDouble();

            //求管线新的方向向量
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
    }
}
