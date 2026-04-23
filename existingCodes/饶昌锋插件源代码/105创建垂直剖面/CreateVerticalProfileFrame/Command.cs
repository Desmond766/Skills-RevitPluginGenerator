using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateVerticalProfileFrame
{
    [TransactionAttribute(TransactionMode.Manual)]
    [RegenerationAttribute(RegenerationOption.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;
            //获取元素
            ElementFilter filter = new ElementFilter();
            Element element;
            try
            {
                element = uidoc.Selection.PickObject(ObjectType.Element, filter).GetElement(doc);
            }
            catch (Autodesk.Revit.Exceptions.OperationCanceledException)
            {
                return Result.Cancelled;
            }
            #region 当element为门时 进行预处理

            FamilyInstance door = null;
            FamilySymbol doorSymbol = null;
            if (element.Category.Id.IntegerValue == ((int)BuiltInCategory.OST_Doors))
            {
                door = element as FamilyInstance;
                doorSymbol = door.Symbol;
            }
            if (door != null)
            {
                element = door.Host;
            }
            #endregion
            //判断元素水平或垂直
            string direction = element.IsHorizontal();
            XYZ centPoint = Utils.GetMEPCurveCentrePoint(element);
            BoundingBoxXYZ boundingBoxXYZ = new BoundingBoxXYZ();
            XYZ minPoint = null;
            XYZ maxPoint = null;
            double height = 0;
            double framing = 0;
            //对不同的元素设置不同的剖面Y轴高度
            if (element is Wall)
            {
                height = element.get_Parameter(BuiltInParameter.WALL_USER_HEIGHT_PARAM).AsDouble();
            }
            else if (element.Category.Id.IntegerValue == (int)BuiltInCategory.OST_StructuralFraming)
            {
                framing = 1000 / 304.8;
            }
            if (door != null)
            {
                height = doorSymbol.LookupParameter("高度").AsDouble();
                centPoint = (door.Location as LocationPoint).Point;
            }
            if (direction == "horizontal")
            {
                direction = "vertical";
                minPoint = new XYZ(centPoint.Y - 1000 / 304.8, centPoint.Z - framing, centPoint.X);
                maxPoint = new XYZ(centPoint.Y + 1000 / 304.8, centPoint.Z + height, centPoint.X + 500 / 304.8);
            }
            else
            {
                if (direction == "vertical")
                {
                    direction = "horizontal";
                }
                if (direction == null)
                {
                    direction = null;
                }
                minPoint = new XYZ(-centPoint.X - 1000 / 304.8, centPoint.Z - framing, centPoint.Y);
                maxPoint = new XYZ(-centPoint.X + 1000 / 304.8, centPoint.Z + height, centPoint.Y + 500 / 304.8);
            }
            ViewSection sectionView;
            doc.NewTransaction("创建剖面框", () =>
            {
                // 创建剖面视图
                // 获取剖面类型
                ElementId viewFamilyTypeId = null;
                FilteredElementCollector collector1 = new FilteredElementCollector(doc);
                ICollection<Element> viewTypes = collector1.OfClass(typeof(ViewFamilyType)).ToElements();
                foreach (ViewFamilyType view in viewTypes)
                {
                    // 检查视图是否为剖面视图
                    // 获取 ViewFamilyType
                    //ViewFamilyType familyType = doc.GetElement(view.GetTypeId()) as ViewFamilyType;
                    if (view?.FamilyName == "剖面")
                    {
                        viewFamilyTypeId = view.Id;
                        break;
                    }
                }
                collector1.Dispose();
                if (direction == "vertical")
                {
                    //竖向 方向向右 minPoint z是剖面宽度  x是长度 y是深度
                    //TaskDialog.Show("asdas", minPoint.ToString() + "\n" + maxPoint.ToString());
                    //TaskDialog.Show("asdas", firstPoint.ToString());
                    //坐标转换
                    XYZ newViewDirection = new XYZ(0, 1, 0);
                    XYZ upDirection = new XYZ(0, 0, 1);
                    boundingBoxXYZ.Min = minPoint;
                    boundingBoxXYZ.Max = maxPoint;
                    Transform transform = Transform.Identity;
                    transform.BasisX = newViewDirection.Normalize();
                    transform.BasisY = upDirection.Normalize();
                    transform.BasisZ = newViewDirection.CrossProduct(upDirection).Normalize();
                    boundingBoxXYZ.Transform = transform;
                }
                else if (direction == "horizontal" || direction == null)
                {
                    //TaskDialog.Show("asdasdasda","Asdasdasdasd");
                    //minPoint = new XYZ(-centPoint.X - 1000 / 304.8, centPoint.Z, centPoint.Y);
                    //maxPoint = new XYZ(-centPoint.X + 1000 / 304.8, centPoint.Z + 2000 / 304.8, centPoint.Y + 600 / 304.8);
                    //MessageBox.Show(minPoint.ToString());
                    //MessageBox.Show(maxPoint.ToString());
                    //坐标转换
                    XYZ newViewDirection = new XYZ(-1, 0, 0);
                    XYZ upDirection = new XYZ(0, 0, 1);
                    boundingBoxXYZ.Min = minPoint;
                    boundingBoxXYZ.Max = maxPoint;
                    Transform transform = Transform.Identity;
                    transform.BasisX = newViewDirection.Normalize();
                    transform.BasisY = upDirection.Normalize();
                    transform.BasisZ = new XYZ(0, 1, 0);
                    boundingBoxXYZ.Transform = transform;
                }
                //TaskDialog.Show("Asda",maxPoint.ToString()+"  "+minPoint);
                //创建
                sectionView = ViewSection.CreateSection(doc, viewFamilyTypeId, boundingBoxXYZ);
                //旋转
                if (direction == null)
                {
                    //TaskDialog.Show("Asdasd","Asda");
                    XYZ east = new XYZ(1, 0, 0);
                    XYZ p1 = (element.Location as LocationCurve).Curve.GetEndPoint(0);
                    XYZ p2 = (element.Location as LocationCurve).Curve.GetEndPoint(1);
                    XYZ p = p2 - p1;
                    var angle = p.AngleTo(east);
                    if (angle > 1.5707963268)
                    {
                        angle = 3.1415926536 - angle;
                    }
                    if ((p1.X < p2.X && p1.Y > p2.Y) || (p1.X > p2.X && p1.Y < p2.Y))
                    {
                        angle = -angle;
                    }
                    angle -= 1.5707963268;
                    ElementId elementId = sectionView.Id;
                    elementId = new ElementId(elementId.IntegerValue - 1);
                    Element fileFrameView = doc.GetElement(elementId);
                    //TaskDialog.Show("Asda",max.ToString()+" " +min);
                    ElementTransformUtils.RotateElement(doc, fileFrameView.Id, Line.CreateBound(centPoint, centPoint + new XYZ(0, 0, 5)), angle);
                }
            });
            return Result.Succeeded;
        }
    }
}
