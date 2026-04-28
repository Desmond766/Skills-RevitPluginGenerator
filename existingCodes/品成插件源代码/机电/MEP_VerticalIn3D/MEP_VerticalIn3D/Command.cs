using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEP_VerticalIn3D
{
    [Transaction(TransactionMode.Manual)]
    public class Command:IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, Autodesk.Revit.DB.ElementSet elements)
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


                    //选择第一个管线，为基准
                    Reference r1 = sel.PickObject(ObjectType.Element);
                    Element e1 = doc.GetElement(r1.ElementId);
                    if (!(e1 is MEPCurve))
                    {
                        TaskDialog.Show("提示", "您所选的构件并非管线");
                        return Result.Cancelled;
                    }
                    //选择第二个管线，使其跟第一根垂直
                    Reference r2 = sel.PickObject(ObjectType.Element);
                    Element e2 = doc.GetElement(r2.ElementId);
                    if (!(e2 is MEPCurve))
                    {
                        TaskDialog.Show("提示", "您所选的构件并非管线");
                        return Result.Cancelled;
                    }
                    //基准管线的方向向量directin1
                    LocationCurve locationCurve1 = e1.Location as LocationCurve;
                    Line line1 = locationCurve1.Curve as Line;
                    XYZ direction1 = line1.Direction;
                    //第二个管线原始的方向向量directin2
                    LocationCurve locationCurve2 = e2.Location as LocationCurve;
                    Line line2 = locationCurve2.Curve as Line;
                    XYZ direction2 = line2.Direction;

                    //与基准管线方向向量垂直的向量，与垂直向量的叉乘crossProduct
                    XYZ crossProduct = (direction1.CrossProduct(new XYZ(0, 0, 1))).Normalize();

                    //第二个管线的两个端点secPoint1、secPoint2、长度length2
                    XYZ secPoint1 = line2.GetEndPoint(0);
                    XYZ secPoint2 = line2.GetEndPoint(1);
                    Double length2 = e2.get_Parameter(BuiltInParameter.CURVE_ELEM_LENGTH).AsDouble();

                    //求第二个管线新的方向向量
                    //判断方向向量
                    XYZ newDirection = crossProduct * length2;
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

                    using (Transaction t = new Transaction(doc, "使垂直"))
                    {
                        t.Start();

                        locationCurve2.Curve = newLocationLine;

                        t.Commit();
                    }
                    //TaskDialog.Show("a", crossProduct.ToString() + "\n" + direction2.Normalize().ToString() + "\n" + ((crossProduct.AngleTo(direction2)) / Math.PI * 180.0).ToString());
                }
            }
            catch
            {

            }

            return Result.Succeeded;
        }
    }
}
