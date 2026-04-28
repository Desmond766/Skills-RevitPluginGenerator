using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//N点布置吊件side lifter
namespace Demo02
{
    [Transaction(TransactionMode.Manual)]
    public class Command06 : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uIDoc = commandData.Application.ActiveUIDocument;
            Document doc = uIDoc.Document;

            Element element1 = doc.GetElement(uIDoc.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.Element,new SpecializedEquipmentFilter(), "Select a pre arranged family instance in the view that is the same face as the one you will be arranging next"));
            Reference edgeRef = uIDoc.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.Edge, "Select the outermost edge of the face to be arranged");

            Element elem = uIDoc.Document.GetElement(edgeRef);
            Edge edge1 = elem.GetGeometryObjectFromReference(edgeRef) as Edge;
            Line line = edge1.AsCurve() as Line;
            //FamilySymbol familySymbol = (element1 as FamilyInstance).Symbol;
            //XYZ point = (element1.Location as LocationPoint).Point;
            //XYZ point1 = (element2.Location as LocationPoint).Point;
            //Line line = Line.CreateBound(point, point1);
            //XYZ p1 = point + line.Direction.Normalize() * line.Length * 0.25;
            //XYZ p2 = point + line.Direction.Normalize() * line.Length * 0.75;
            //using (Transaction trans = new Transaction(doc))
            //{
            //    trans.Start("Create Dedicated Devices");
            //    doc.Create.NewFamilyInstance(p1, familySymbol, Autodesk.Revit.DB.Structure.StructuralType.NonStructural);
            //    doc.Create.NewFamilyInstance(p2, familySymbol, Autodesk.Revit.DB.Structure.StructuralType.NonStructural);
            //    trans.Commit();
            //}

            FamilySymbol familySymbol = (element1 as FamilyInstance).Symbol;//要创建的族类型
            XYZ point = (element1.Location as LocationPoint).Point;

            FamilyInstance familyInstance = element1 as FamilyInstance;//要创建的族实例
            Face face1 = null;


            Transform transform = familyInstance.GetTransform();
            XYZ direction = transform.OfVector(XYZ.BasisZ);

            Element element = doc.GetElement((element1 as FamilyInstance).Host.Id); //宿主元素
            FamilyInstance familyInstance2 = element as FamilyInstance;
            double length = line.Length;
            //Line line = null;

            UserControl01 userControl01 = new UserControl01();
            userControl01.ShowDialog();
            if (userControl01.cancel)
            {
                return Result.Cancelled;
            }
            int num = Convert.ToInt32(userControl01.textBox.Text);

            XYZ hostPoint = (familyInstance2.Location as LocationPoint).Point;

            Options options = new Options();
            options.ComputeReferences = true;
            GeometryElement geometryElement = element.get_Geometry(options);
            if (element.Category.Id.IntegerValue.Equals(-2001350))
            {
                FamilyInstance familyInstance1 = element1 as FamilyInstance;
                foreach (var item in geometryElement)
                {
                    if (item is GeometryInstance geometryInstance)
                    {
                        GeometryElement geometryElement1 = geometryInstance.GetSymbolGeometry();
                        foreach (var item1 in geometryElement1)
                        {
                            if (item1 is Solid solid)
                            {
                                foreach (PlanarFace face in solid.Faces)
                                {
                                    if (face.Reference.ConvertToStableRepresentation(doc).Equals(familyInstance.HostFace.ConvertToStableRepresentation(doc)))
                                    {
                                        face1 = face;
                                        //foreach (EdgeArray edgeArray in face.EdgeLoops)
                                        //{
                                        //    foreach (Edge edge in edgeArray)
                                        //    {
                                        //        if (edge.AsCurve().Length > length)
                                        //        {
                                        //            //line = edge.AsCurve() as Line;
                                        //            //length = edge.AsCurve().Length;
                                        //        }
                                        //    }
                                        //}
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
                //View3D view3D = new FilteredElementCollector(doc).OfClass(typeof(View3D)).Cast<View3D>().ToList().First(x => x.Name == "{三维 - Administrator}");
                //ElementCategoryFilter elementCategoryFilter = new ElementCategoryFilter(BuiltInCategory.OST_StructuralFraming);
                //ReferenceIntersector referenceIntersector = new ReferenceIntersector(elementCategoryFilter,FindReferenceTarget.Face,view3D);
                //ReferenceWithContext referenceWithContext = referenceIntersector.FindNearest(point, direction);
                //FamilyInstance familyInstance3 = doc.GetElement(referenceWithContext.GetReference()) as FamilyInstance;

            }
            else if (element.Category.Id.IntegerValue.Equals(-2001320))
            {
                foreach (var item in geometryElement)
                {
                    if (item is Solid solid)
                    {
                        foreach (PlanarFace face in solid.Faces)
                        {
                            if (face.Reference.ConvertToStableRepresentation(doc).Equals(familyInstance.HostFace.ConvertToStableRepresentation(doc)))
                            {
                                face1 = face;
                                //foreach (EdgeArray edgeArray in face.EdgeLoops)
                                //{
                                //    foreach (Edge edge in edgeArray)
                                //    {
                                //        if (edge.AsCurve().Length > length)
                                //        {
                                //            //line = edge.AsCurve() as Line;
                                //            //length = edge.AsCurve().Length;
                                //        }
                                //    }
                                //}
                                break;
                            }
                        }
                    }
                }
            }
            XYZ startPoint = line.Origin;
            Transform transform1 = familyInstance2.GetTransform();
            XYZ referenceDirection = null;
            if (line.Direction.IsAlmostEqualTo(XYZ.BasisZ) || line.Direction.IsAlmostEqualTo(XYZ.BasisZ.Negate()))
            {
                referenceDirection = XYZ.BasisZ;
                if (direction.IsAlmostEqualTo(XYZ.BasisX) || direction.IsAlmostEqualTo(XYZ.BasisX.Negate()))
                {
                    //startPoint = transform1.OfPoint(startPoint);
                    startPoint = new XYZ(point.X, point.Y, startPoint.Z);
                }
                if (direction.IsAlmostEqualTo(XYZ.BasisY) || direction.IsAlmostEqualTo(XYZ.BasisY.Negate()))
                {
                    //startPoint = transform1.OfPoint(startPoint);
                    startPoint = new XYZ(point.X, point.Y, startPoint.Z);
                }
            }
            if (line.Direction.IsAlmostEqualTo(XYZ.BasisX) || line.Direction.IsAlmostEqualTo(XYZ.BasisX.Negate()))
            {
                referenceDirection = XYZ.BasisX;
                startPoint = new XYZ(startPoint.X, point.Y, point.Z);
            }
            if (line.Direction.IsAlmostEqualTo(XYZ.BasisY) || line.Direction.IsAlmostEqualTo(XYZ.BasisY.Negate()))
            {
                referenceDirection = XYZ.BasisY;
                startPoint = new XYZ(point.X, startPoint.Y, point.Z);
            }

            double spacing = length / num;

            XYZ layoutDirection = line.Direction;
            using (Transaction trans = new Transaction(doc, "Create Dedicated Devices"))
            {
                trans.Start();
                HashSet<FamilyInstance> elements1 = new HashSet<FamilyInstance>();
                AssemblyInstance assemblyInstance = doc.GetElement(familyInstance.AssemblyInstanceId) as AssemblyInstance;
                for (int i = 0; i < num; i++)
                {
                    double halfSpaing = i == 0 ? (spacing / 2) : spacing;
                    startPoint = startPoint + layoutDirection * halfSpaing;
                    FamilyInstance familyInstance1 = doc.Create.NewFamilyInstance(face1, startPoint, referenceDirection, familySymbol);
                    elements1.Add(familyInstance1);
                }
                ICollection<ElementId> elementIds2 = new HashSet<ElementId>() { element1.Id };
                doc.Delete(elementIds2);
                trans.Commit();
                trans.Start();
                foreach (FamilyInstance item in elements1)
                {
                    IList<ElementId> elementIds = item.GetDependentElements(null);
                    assemblyInstance.AddMemberIds(elementIds);
                }
                trans.Commit();
            }
            return Result.Succeeded;
        }
    }
}
