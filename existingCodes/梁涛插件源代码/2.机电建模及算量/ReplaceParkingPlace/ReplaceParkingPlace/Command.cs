using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReplaceParkingPlace
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;

            var refer = sel.PickObject(ObjectType.LinkedElement, "选择链接模型");
            //var refer = sel.PickObject(ObjectType.PointOnElement, "选择链接模型");
            var linkInstance = doc.GetElement(refer) as RevitLinkInstance;
            Transform linkTransform = linkInstance.GetTransform();
            Document linkDoc = linkInstance.GetLinkDocument();

            //FamilyInstance familyInstance1 = linkDoc.GetElement(refer.LinkedElementId) as FamilyInstance;
            //GeometryObject geo = familyInstance1.GetGeometryObjectFromReference(refer.CreateReferenceInLink());
            //if (geo is PlanarFace planarFace)
            //{
            //    TaskDialog.Show("revit", planarFace.FaceNormal.ToString());
            //};
            //FamilySymbol familySymbol2 = null;
            //using (var symbolCol = new FilteredElementCollector(doc).WhereElementIsElementType())
            //{
            //    familySymbol2 = symbolCol.OfCategory(BuiltInCategory.OST_GenericModel)
            //        .Where(e => e is FamilySymbol).Cast<FamilySymbol>()
            //        .FirstOrDefault(s => s.Name.Contains("代替车位族"));
            //}
            //ReplaceElement(doc, linkDoc.GetElement(refer.LinkedElementId) as FamilyInstance, linkTransform, familySymbol2);
            //return Result.Succeeded;

            //FamilyInstance linkelem = linkDoc.GetElement(refer.LinkedElementId) as FamilyInstance;
            //TaskDialog.Show("e", (linkelem.GetTransform().Multiply(linkTransform).OfVector(XYZ.BasisY.Negate()).AngleTo(XYZ.BasisY) % Math.PI).ToString());
            //return Result.Succeeded;

            List<FamilyInstance> linkElems = new List<FamilyInstance>();

            using (FilteredElementCollector linkElemCol = new FilteredElementCollector(linkDoc))
            {
                //LogicalOrFilter orFilter = new LogicalOrFilter(new ElementCategoryFilter(BuiltInCategory.OST_StructuralColumns), new ElementCategoryFilter(BuiltInCategory.OST_GenericModel));
                var linkParkingPlaces = linkElemCol.WhereElementIsNotElementType().OfCategory(BuiltInCategory.OST_StructuralColumns)
                    .Where(le => le is FamilyInstance).Cast<FamilyInstance>().Where(e => e.Symbol.FamilyName.Contains("停车位"));

                linkElems.AddRange(linkParkingPlaces);
            }

            FamilySymbol familySymbol = null;
            using (var symbolCol = new FilteredElementCollector(doc).WhereElementIsElementType())
            {
                familySymbol = symbolCol.OfCategory(BuiltInCategory.OST_GenericModel)
                    .Where(e => e is FamilySymbol).Cast<FamilySymbol>()
                    .FirstOrDefault(s => s.Name.Contains("代替车位族"));
            }
            if (familySymbol == null)
            {
                TaskDialog.Show("提示", "未找代替车位族类型");
                return Result.Cancelled;
            }

            using (Transaction t = new Transaction(doc, "车位族实例替换"))
            {
                t.Start();

                // 激活车位族类型
                if (!familySymbol.IsActive)
                {
                    familySymbol.Activate();
                }

                foreach (var elem in linkElems)
                {
                    if (elem.Location == null || !(elem.Location is LocationPoint)) continue;

                    XYZ point = (elem.Location as LocationPoint).Point;
                    point = linkTransform.OfPoint(point);
                    //point = point + XYZ.BasisZ * 100;

                    double width = (double)(elem.Symbol.LookupParameter("车位宽")?.AsDouble() ?? elem.Symbol.LookupParameter("车位宽度")?.AsDouble());
                    double length = (double)(elem.Symbol.LookupParameter("车位长")?.AsDouble() ?? elem.Symbol.LookupParameter("车位长度")?.AsDouble());

                    //var parkVector = familyInstance.GetTransform().OfVector(XYZ.BasisY);

                    var linkVector = elem.GetTransform().Multiply(linkTransform).OfVector(XYZ.BasisY.Negate());

                    var angle = XYZ.BasisY.AngleTo(linkVector);
                    //Line axis = Line.CreateBound(point, point + XYZ.BasisZ);
                    //Line axis = Line.CreateBound(point, point + XYZ.BasisY.CrossProduct(linkVector));

                    var familyInstance = doc.Create.NewFamilyInstance(point, familySymbol, Autodesk.Revit.DB.Structure.StructuralType.NonStructural);

                    var verDir = XYZ.BasisY.CrossProduct(linkVector);
                    if (verDir.GetLength() > 0.0000001)
                    {
                        Line axis = Line.CreateUnbound(point, verDir);
                        familyInstance.Location.Rotate(axis, angle);
                        //familyInstance.Location.Rotate(axis, Math.PI);
                    }

                    double? otherWidth = elem.Symbol.LookupParameter("盲道宽度")?.AsDouble() ?? elem.Symbol.LookupParameter("\u007f无障碍通道")?.AsDouble();
                    if (otherWidth != null)
                    {
                        width += (double)otherWidth;
                        familyInstance.Location.Move(elem.GetTransform().Multiply(linkTransform).OfVector(XYZ.BasisX) * ((double)otherWidth / 2));
                    }

                    familyInstance.LookupParameter("长")?.Set(length);
                    familyInstance.LookupParameter("宽")?.Set(width);
                }

                t.Commit();
            }
            TaskDialog.Show("提示", "运行完成");
            return Result.Succeeded;
        }
        private void ReplaceElement(Document doc, FamilyInstance elem, Transform linkTransform, FamilySymbol familySymbol)
        {
            if (elem.Location == null || !(elem.Location is LocationPoint)) return;

            XYZ point = (elem.Location as LocationPoint).Point;
            point = linkTransform.OfPoint(point);
            point = point + XYZ.BasisZ * 100;

            double? width = elem.Symbol.LookupParameter("车位宽")?.AsDouble() ?? elem.Symbol.LookupParameter("车位宽度")?.AsDouble();
            double? length = elem.Symbol.LookupParameter("车位长")?.AsDouble() ?? elem.Symbol.LookupParameter("车位长度")?.AsDouble();

            //var parkVector = familyInstance.GetTransform().OfVector(XYZ.BasisY);

            var linkVector = elem.GetTransform().Multiply(linkTransform).OfVector(XYZ.BasisY.Negate());

            var angle = XYZ.BasisY.AngleTo(linkVector);
            //Line axis = Line.CreateBound(point, point + XYZ.BasisY.CrossProduct(linkVector));
            Line axis = Line.CreateBound(point, point + XYZ.BasisZ);
            //TaskDialog.Show("revit", angle + "\n" + XYZ.BasisY.CrossProduct(linkVector));

            Transaction t = new Transaction(doc, "元素替换");
            t.Start();
            // 激活车位族类型
            if (!familySymbol.IsActive)
            {
                familySymbol.Activate();
            }
            var familyInstance = doc.Create.NewFamilyInstance(point, familySymbol, Autodesk.Revit.DB.Structure.StructuralType.NonStructural);

            familyInstance.Location.Rotate(axis, angle);
            familyInstance.LookupParameter("长")?.Set((double)length);
            familyInstance.LookupParameter("宽")?.Set((double)width);
            t.Commit();
        }
    }
}
