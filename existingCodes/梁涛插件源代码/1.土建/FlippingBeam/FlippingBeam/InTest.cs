using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlippingBeam
{
    [Transaction(TransactionMode.Manual)]
    public class InTest : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uIDoc = commandData.Application.ActiveUIDocument;
            Document doc = uIDoc.Document;

            Element duct = doc.GetElement(uIDoc.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.Element));
            Element duct2 = doc.GetElement(uIDoc.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.Element));

            //Options options = new Options();
            //options.ComputeReferences = true;
            //options.DetailLevel = ViewDetailLevel.Fine;
            //ElementIntersectsSolidFilter filter = null;
            //GeometryElement geometryElement = duct.get_Geometry(options);
            //foreach (var item in geometryElement)
            //{
            //    if (item is GeometryInstance geometryInstance && geometryInstance.GetSymbolGeometry() is GeometryElement geometryElement1)
            //    {
            //        TaskDialog.Show("sd", "yyy" + geometryElement1.Count());
            //        break;
            //    }
            //}
            //return Result.Succeeded;


            //ElementIntersectsSolidFilter filter = new ElementIntersectsSolidFilter(GetSolid(duct));
            //ElementIntersectsSolidFilter filter2 = new ElementIntersectsSolidFilter(GetSolid(duct2));
            ICollection<ElementId> ids = new HashSet<ElementId>() { duct2.Id};
            FilteredElementCollector elements1 = new FilteredElementCollector(doc,ids);
            double tolerance = 10 / 304.8;
            double boxDistance = duct.get_BoundingBox(doc.ActiveView).Max.DistanceTo(duct.get_BoundingBox(doc.ActiveView).Min);
            double scale = (boxDistance - tolerance) / boxDistance;
            Solid solid;
            Solid solid1;
            ScaleSolidOfFamilyInstance(duct2, 1, out solid1);
            List<Element> elements2 = elements1.WherePasses(ScaleSolidOfFamilyInstance(duct, 2, out solid)).ToElements().ToList();
            Solid temp0 = BooleanOperationsUtils.ExecuteBooleanOperation(solid, solid1, BooleanOperationsType.Intersect);
            //List<Element> elements2 = elements1.WherePasses(filter).ToElements().ToList();
            if (elements2.Count == 1)
            {
                TaskDialog.Show("sds", "111");
            }
            using (Transaction t = new Transaction(doc,"create"))
            {
                t.Start();
                DirectShape shape = DirectShape.CreateElement(doc, new ElementId(BuiltInCategory.OST_StructuralFoundation));
                shape.AppendShape(new List<GeometryObject>() { solid });
                //uIDoc.ShowElements(shape);
                //DirectShape directShape = ShowSolidWithoutTsInside(solid, doc);
                uIDoc.Selection.SetElementIds(new ElementId[] { shape.Id });

                t.Commit();
            }





            return Result.Succeeded;
        }
        // 获取特定族实例的Solid并进行缩放
        public ElementIntersectsSolidFilter ScaleSolidOfFamilyInstance(Element elem, double scaleFactor,out Solid solid1)
        {
            Options options = new Options();
            options.ComputeReferences = true;
            options.DetailLevel = ViewDetailLevel.Fine;
            ElementIntersectsSolidFilter filter = null;
            GeometryElement geometryElement = elem.get_Geometry(options);
            solid1 = null;
            foreach (GeometryObject geometryObject in geometryElement)
            {
                if (geometryObject is Solid solid)
                {
                    if (solid.SurfaceArea == 0) continue;
                    Transform newTs = Transform.Identity;
                    //newTs.Origin = ((elem.Location as LocationCurve).Curve as Line).GetEndPoint(0).Add(((elem.Location as LocationCurve).Curve as Line).GetEndPoint(1)) / 2;
                    newTs.Origin = ((elem.Location as LocationCurve).Curve as Line).GetEndPoint(0);
                    newTs.BasisX = solid.GetBoundingBox().Transform.BasisX;
                    newTs.BasisY = solid.GetBoundingBox().Transform.BasisY;
                    newTs.BasisZ = solid.GetBoundingBox().Transform.BasisZ;
                    newTs.Origin = new XYZ();//scale = 1
                    //newTs.Origin = solid.GetBoundingBox().Transform.Inverse.Origin;
                    newTs.Origin = solid.GetBoundingBox().Transform.Origin;
                    // 创建缩放矩阵
                    Transform scaleTransform = newTs.ScaleBasis(scaleFactor);
                    //Transform scaleTransform = Transform.Identity.ScaleBasisAndOrigin(scaleFactor); 
                    // 缩放Solid
                    Solid scaledSolid = SolidUtils.CreateTransformed(solid, scaleTransform);
                    solid1 = scaledSolid;
                    filter = new ElementIntersectsSolidFilter(scaledSolid);
                    break;
                }
                if (geometryObject is GeometryInstance geometryInstance)
                {
                    foreach (GeometryObject item in geometryInstance.GetSymbolGeometry())
                    {
                        if (item is Solid solid2)
                        {
                            if (solid2.SurfaceArea == 0) continue;
                            Transform newTs = Transform.Identity;
                            newTs.Origin = geometryInstance.Transform.Origin;
                            FamilyInstance familyInstance = elem as FamilyInstance;
                            newTs.BasisX = familyInstance.GetTransform().BasisX;
                            newTs.BasisY = familyInstance.GetTransform().BasisY;
                            newTs.BasisZ = familyInstance.GetTransform().BasisZ;
                            // 创建缩放矩阵
                            Transform scaleTransform = newTs.ScaleBasis(scaleFactor);
                            //Transform scaleTransform = Transform.Identity.ScaleBasisAndOrigin(scaleFactor); 

                            // 缩放Solid
                            Solid scaledSolid = SolidUtils.CreateTransformed(solid2, scaleTransform);
                            solid1 = scaledSolid;
                            filter = new ElementIntersectsSolidFilter(scaledSolid);

                            break;
                        }
                    }
                }
            }
            return filter;
        }
        public static DirectShape ShowSolidWithoutTsInside(Solid solid,Document doc)
        {
            DirectShape directShape = DirectShape.CreateElement(doc, new ElementId(BuiltInCategory.OST_GenericModel));
            List<GeometryObject> geometryObjects = new List<GeometryObject> { solid };
            directShape.SetShape(geometryObjects);
            DirectShapeType directShapeType = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_GenericModel).OfClass(typeof(DirectShapeType)).FirstOrDefault() as DirectShapeType;
            directShape.SetTypeId(directShapeType.Id);
            return directShape;
        }
        public Solid GetSolid(Element familyInstance)
        {
            Options options = new Options();
            options.ComputeReferences = true;
            options.DetailLevel = ViewDetailLevel.Fine;
            Solid solid = null;
            GeometryElement geometryElement = familyInstance.get_Geometry(options);

            foreach (GeometryObject geometryObject in geometryElement)
            {
                if (geometryObject is Solid solid1)
                {
                    solid = solid1;
                }
                break;
            }
            return solid;
        }
    }
}
