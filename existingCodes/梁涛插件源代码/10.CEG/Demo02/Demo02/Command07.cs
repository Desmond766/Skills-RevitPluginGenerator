using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelDataReader;
using System.IO;
using System.Data;
using System.Windows;
using Autodesk.Revit.UI.Selection;
using System.Windows.Controls;
using System.Windows.Shapes;
using Line = Autodesk.Revit.DB.Line;

//延长详图线
namespace Demo02
{
    [Transaction(TransactionMode.Manual)]
    public class Command07 : IExternalCommand
    {
        UIDocument uIDoc = null;
        Document doc = null;
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            uIDoc = commandData.Application.ActiveUIDocument;
            doc = uIDoc.Document;

            Reference reference1 = uIDoc.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.Element, new StructuralFrameworkFilter(), "Select the structural framework where the detail line is located");
            FamilyInstance familyInstance = reference1.GetElement(doc) as FamilyInstance;
            double angle = (familyInstance.Location as LocationPoint).Rotation;

            Reference reference = uIDoc.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.Element,new DetailLineFilter(), "Select the detail line to extend");
            DetailLine detailLine  = doc.GetElement(reference) as DetailLine;
            GraphicsStyle graphicsStyle = detailLine.LineStyle as GraphicsStyle;
            Line line = (detailLine.Location as LocationCurve).Curve as Line;//已存在的详图线的Line

            XYZ intersection1 = IntersectionMethod(line, angle);
            XYZ intersection2 = IntersectionMethod(line, angle);
            Line line1 = Line.CreateBound(intersection1, intersection2);
            using (Transaction t = new Transaction(doc))
            {
                t.Start("Extend Detail Line");
                DetailCurve detailCurve = doc.Create.NewDetailCurve(uIDoc.ActiveView, line1);
                detailCurve.LineStyle = graphicsStyle;
                doc.Delete(new List<ElementId>() { detailLine.Id});
                t.Commit();
            }

            return Result.Succeeded;
        }

        private XYZ GetIntersectionPoint(Line line1, Line line2)
        {
            // 判断两条直线是否相交
            SetComparisonResult result = line1.Intersect(line2, out IntersectionResultArray intersectionResult);

            // 如果相交，获取交点坐标
            if (result == SetComparisonResult.Overlap)
            {
                XYZ intersectionPoint = intersectionResult.get_Item(0).XYZPoint;
                return intersectionPoint;
            }
            else
            {
                // 如果不相交，返回null或者抛出异常
                return null;
            }
        }

        private XYZ IntersectionMethod(Line line ,double angle)
        {
            Reference edgeRef = uIDoc.Selection.PickObject(ObjectType.Edge, "Select the edge to extend the detail line to");
            Element elem = uIDoc.Document.GetElement(edgeRef);
            Edge edge = elem.GetGeometryObjectFromReference(edgeRef) as Edge;
            Line line1 = edge.AsCurve() as Line;//选择的边的Line
            //FamilyInstance familyInstance = doc.GetElement(edge.Reference.ElementId) as FamilyInstance;

            XYZ detailLineStartPoint = line.GetEndPoint(0);
            XYZ detailLineEndPoint = line.GetEndPoint(1);

            XYZ edgeStartPoint = line1.GetEndPoint(0);
            XYZ edgeEndPoint = line1.GetEndPoint(1);

            //double angle = (familyInstance.Location as LocationPoint).Rotation;
            angle = angle * 180 / Math.PI;
            int angle1 = Convert.ToInt32(Math.Round(angle));
            if (angle1 == 90 || angle1 == 270)
            {
                edgeStartPoint = new XYZ(detailLineStartPoint.X, edgeStartPoint.Y, edgeStartPoint.Z);
                edgeEndPoint = new XYZ(detailLineStartPoint.X, edgeEndPoint.Y, edgeEndPoint.Z);
            }
            else if (angle1 == 0 || angle1 == 180 || angle1 == 360)
            {
                edgeStartPoint = new XYZ(edgeStartPoint.X, detailLineStartPoint.Y, edgeStartPoint.Z);
                edgeEndPoint = new XYZ(edgeEndPoint.X, detailLineStartPoint.Y, edgeEndPoint.Z);
            }

            Line line2 = Line.CreateBound(edgeStartPoint, edgeEndPoint);
            Line line3 = Line.CreateBound(detailLineStartPoint + line.Direction.Negate() * 100, detailLineEndPoint + line.Direction * 100);
            XYZ intersection = GetIntersectionPoint(line2, line3);
            return intersection;
        }

    }
    public class DetailLineFilter : ISelectionFilter
    {
        public bool AllowElement(Element elem)
        {
            if (elem.Category.Id.IntegerValue.Equals(-2000051))
            {
                return true;
            }
            return false;
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            throw new NotImplementedException();
        }
    }

    public class StructuralFrameworkFilter : ISelectionFilter
    {
        public bool AllowElement(Element elem)
        {
            if (elem.Category.Id.IntegerValue.Equals(-2001320))
            {
                return true;
            }
            return false;
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            throw new NotImplementedException();
        }
    }
}
