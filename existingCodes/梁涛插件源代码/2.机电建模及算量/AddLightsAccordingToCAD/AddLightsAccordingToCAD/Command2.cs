using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// TODO:LT:改为创建灯具或修改灯具所在位置 24.12.19

namespace AddLightsAccordingToCAD
{
    [Transaction(TransactionMode.Manual)]
    public class Command2 : IExternalCommand
    {
        UIDocument uiDoc = null;
        Document doc = null;
        Transform transform = null;
        View3D view3D = null;
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            uiDoc = commandData.Application.ActiveUIDocument;
            doc = uiDoc.Document;

            //程序在3D 支吊架视图中完成
            //改为
            //先找当前视图 对应的3D视图， 找不到再用3D 支吊架，命名规则 3D {当前视图名称}
            View3D default3Dview = null;
            View3D target3Dview = null;
            FilteredElementCollector fristCollector = new FilteredElementCollector(doc).OfClass(typeof(View3D));
            foreach (View3D view3 in fristCollector)
            {
                if ("3D 机电".Equals(view3.Name))
                {
                    default3Dview = view3;
                }
                if (string.Format("3D {0}", doc.ActiveView.Name).Equals(view3.Name))
                {
                    target3Dview = view3;
                }
            }
            if (null != target3Dview)
            {
                view3D = target3Dview;
            }
            else
            {
                if (null != default3Dview)
                {
                    view3D = default3Dview;
                }
                else
                {
                    message = string.Format("未找到3D视图： 3D 机电 或 3D {0}", doc.ActiveView.Name);
                    return Result.Cancelled;
                }
            }

            Reference reference = uiDoc.Selection.PickObject(ObjectType.PointOnElement);
            Element dwg = doc.GetElement(reference);
            ImportInstance importInstance = dwg as ImportInstance;
            transform = importInstance.GetTransform();
            List<GeometryInstance> instances = GetAllGeometryInstanceInCAD(dwg);
            using (Transaction trans = new Transaction(doc, "Add Lights"))
            {
                trans.Start();
                CreateInstances(instances);
                trans.Commit();
            }
            return Result.Succeeded;
        }
        public static List<GeometryInstance> GetAllGeometryInstanceInCAD(Element dwg)
        {
            List<GeometryInstance> result = new List<GeometryInstance>();
            foreach (GeometryObject item in dwg.get_Geometry(new Options()))
            {
                if (item is GeometryInstance dwgInstance)
                {
                    foreach (GeometryObject item2 in dwgInstance.GetSymbolGeometry())
                    {
                        if (item2 is GeometryInstance geometryInstance)
                        {
                            result.Add(geometryInstance);
                        }
                    }
                }
            }
            return result;
        }
        //创建荧光灯
        private void CreateInstances(List<GeometryInstance> geometryInstances)
        {
            //Level level = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Levels).OfClass(typeof(Level)).WhereElementIsNotElementType().ToElements().Where(m => m.Name == "标高 1").ToList().FirstOrDefault() as Level;
            ElementId elementId = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_LightingFixtures).OfClass(typeof(FamilySymbol)).Where(x => x.Name.Contains("单管荧光灯")).First().Id;
            FamilySymbol familySymbol = doc.GetElement(elementId) as FamilySymbol;
            if (!familySymbol.IsActive)
            {
                familySymbol.Activate();
            }
            foreach (GeometryInstance geometryInstance in geometryInstances)
            {
                XYZ p = geometryInstance.Transform.Origin;
                double Z = GetZ(p);
                p = new XYZ(p.X, p.Y, p.Z + Z);
                p = transform.OfPoint(p);
                CableTray cableTray = FindCableTray(p);// 射线上下寻找
                if (cableTray == null)
                {
                    double radius = 1000 / 304.8;
                    Curve circle1 = Arc.Create(p, radius, 0, Math.PI, XYZ.BasisX, XYZ.BasisY);
                    Curve circle2 = Arc.Create(p, radius, Math.PI, 2 * Math.PI, XYZ.BasisX, XYZ.BasisY);
                    List<Curve> curveList = new List<Curve> { circle1, circle2 };
                    CurveLoop curveLoop = CurveLoop.Create(curveList);
                    IList<CurveLoop> curves = new List<CurveLoop> { curveLoop };
                    Solid solid = GeometryCreationUtilities.CreateExtrusionGeometry(curves, XYZ.BasisZ, 3200 / 304.8);
                    ElementIntersectsSolidFilter solidFilter = new ElementIntersectsSolidFilter(solid);
                    List<CableTray> cableTrays = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_CableTray).OfClass(typeof(CableTray)).WherePasses(solidFilter).Cast<CableTray>().ToList();
                    if (cableTrays.Count == 1)
                    {
                        double maxLength = double.MinValue;
                        Line line1 = null;
                        cableTray = cableTrays.First();
                        XYZ direction = ((cableTray.Location as LocationCurve).Curve as Line).Direction;
                        foreach (GeometryObject item in geometryInstance.GetSymbolGeometry())
                        {
                            if (item is Line line && line.Length > maxLength)
                            {
                                maxLength = line.Length;
                                line1 = line;
                            }
                        }
                        //if (!(direction.IsAlmostEqualTo(line1.Direction) || direction.Negate().IsAlmostEqualTo(line1.Direction)))
                        //{
                        //    cableTray = null;
                        //}
                    }
                    if (cableTrays.Count == 2)
                    {
                        double maxLength = double.MinValue;
                        Line line1 = null;
                        int count = 0;
                        List<ElementId> ids = new List<ElementId>();
                        foreach (GeometryObject item in geometryInstance.GetSymbolGeometry())
                        {
                            if (item is Line line && line.Length > maxLength)
                            {
                                maxLength = line.Length;
                                line1 = line;
                            }
                        }
                        foreach (CableTray item in cableTrays)
                        {
                            XYZ direction = ((item.Location as LocationCurve).Curve as Line).Direction;
                            if (direction.IsAlmostEqualTo(line1.Direction) || direction.Negate().IsAlmostEqualTo(line1.Direction))
                            {
                                count++;
                                cableTray = item;
                                ids.Add(item.Id);
                            }
                        }
                        if (count == 2)
                        {
                            cableTray = null;
                            uiDoc.Selection.SetElementIds(ids);
                        }
                    }
                }
                if (cableTray != null)
                {
                    ElementId levelId = cableTray.get_Parameter(BuiltInParameter.RBS_START_LEVEL_PARAM).AsElementId();
                    Options options = new Options();
                    options.ComputeReferences = true;
                    foreach (GeometryObject item in cableTray.get_Geometry(options))
                    {
                        if (item is Solid)
                        {
                            Solid solid = item as Solid;
                            FaceArray faceArray = solid.Faces;
                            double area = double.MinValue;
                            Face face = null;
                            foreach (PlanarFace item1 in faceArray)
                            {
                                if (item1.Area > area && -1.00001 < item1.FaceNormal.Z && item1.FaceNormal.Z < -0.99999)
                                {
                                    area = item1.Area;
                                    face = item1;
                                }
                            }
                            if (face != null)
                            {
                                XYZ direction = GetDirection(cableTray);
                                if (direction.IsAlmostEqualTo(XYZ.BasisX) || direction.IsAlmostEqualTo(XYZ.BasisX.Negate()))
                                {
                                    p = new XYZ(p.X, (cableTray.Location as LocationCurve).Curve.GetEndPoint(0).Y, p.Z);
                                }
                                else if (direction.IsAlmostEqualTo(XYZ.BasisY) || direction.IsAlmostEqualTo(XYZ.BasisY.Negate()))
                                {
                                    p = new XYZ((cableTray.Location as LocationCurve).Curve.GetEndPoint(0).X, p.Y, p.Z);
                                }
                                else
                                {
                                    Line line = (cableTray.Location as LocationCurve).Curve as Line;
                                    p = line.Project(p).XYZPoint;
                                }
                                FamilyInstance familyInstance = doc.Create.NewFamilyInstance(face, p, direction, familySymbol);
                                familyInstance.get_Parameter(BuiltInParameter.INSTANCE_SCHEDULE_ONLY_LEVEL_PARAM).Set(levelId);
                            }
                        }
                    }
                }
                //if (cableTray == null)
                //{
                //    FamilyInstance familyInstance = doc.Create.NewFamilyInstance(p, familySymbol, doc.GetElement(new ElementId(6398403)), Autodesk.Revit.DB.Structure.StructuralType.NonStructural);
                //}
            }
        }
        //射线寻找上方的照明线槽
        private CableTray FindCableTray(XYZ point)
        {
            CableTray result = null;
            ElementCategoryFilter elementCategoryFilter = new ElementCategoryFilter(BuiltInCategory.OST_CableTray);
            ReferenceIntersector referenceIntersector = new ReferenceIntersector(elementCategoryFilter, FindReferenceTarget.Face, view3D);
            ReferenceWithContext referenceWithContext = referenceIntersector.FindNearest(point, XYZ.BasisZ.Negate());
            if (referenceWithContext == null)
            {
                referenceWithContext = referenceIntersector.FindNearest(point, XYZ.BasisZ);
            }
            if (referenceWithContext != null)
            {
                result = doc.GetElement(referenceWithContext.GetReference()) as CableTray;
            }
            return result;
        }
        private double GetZ(XYZ point)
        {
            double Z = 0.0;
            ElementCategoryFilter elementCategoryFilter = new ElementCategoryFilter(BuiltInCategory.OST_CableTray);
            ReferenceIntersector referenceIntersector = new ReferenceIntersector(elementCategoryFilter, FindReferenceTarget.Face, view3D);
            ReferenceWithContext referenceWithContext = referenceIntersector.FindNearest(point, XYZ.BasisZ);
            if (referenceWithContext == null)
            {
                referenceWithContext = referenceIntersector.FindNearest(point, XYZ.BasisZ.Negate());
            }
            if (referenceWithContext != null)
            {
                Z = referenceWithContext.GetReference().GlobalPoint.Z;
            }
            return Z;
        }
        //获取照明线槽的方向作为荧光灯的布置方向
        private XYZ GetDirection(CableTray cableTray)
        {
            XYZ direction = null;
            Curve curve = (cableTray.Location as LocationCurve).Curve;
            XYZ startPoint = curve.GetEndPoint(0);
            XYZ endPoint = curve.GetEndPoint(1);
            direction = (startPoint - endPoint).Normalize();

            return direction;
        }
    }
}
