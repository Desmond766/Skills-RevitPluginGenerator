using Autodesk.Revit.Attributes;
using Autodesk.Revit.Creation;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Document = Autodesk.Revit.DB.Document;

namespace AnalysisOfNetHeightIssues
{
    [TransactionAttribute(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        View3D view3D = null;
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uIDoc = commandData.Application.ActiveUIDocument;
            Document doc = uIDoc.Document;

            if (!(doc.ActiveView is ViewPlan))
            {
                TaskDialog.Show("Revit", "请在平面视图中运行插件！");
                return Result.Cancelled;
            }
            View view = doc.ActiveView;

            //程序在3D 支吊架视图中完成
            //改为
            //先找当前视图 对应的3D视图， 找不到再用3D 支吊架，命名规则 3D {当前视图名称}
            View3D default3Dview = null;
            View3D target3Dview = null;
            FilteredElementCollector fristCollector = new FilteredElementCollector(doc).OfClass(typeof(View3D));
            foreach (View3D view3 in fristCollector)
            {
                if ("{三维}".Equals(view3.Name))
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
                    message = string.Format("未找到3D视图： {三维} 或 3D {0}", doc.ActiveView.Name);
                    return Result.Cancelled;
                }
            }

            //IList<Reference> references = uIDoc.Selection.PickObjects(Autodesk.Revit.UI.Selection.ObjectType.Element, new DuctFilter());

            FilteredElementCollector collector = new FilteredElementCollector(doc);
            RevitLinkInstance link = collector.OfClass(typeof(RevitLinkInstance)).Cast<RevitLinkInstance>().ToList().FirstOrDefault();

            Document linkDoc = link.GetLinkDocument();

            UserControl1 userControl = new UserControl1();
            userControl.ShowDialog();
            if (userControl.cancel)
            {
                return Result.Cancelled;
            }

            double spacing = Convert.ToDouble(userControl.tb.Text);
            List<Difference> differences = new List<Difference>();

            if (userControl.cs.IsChecked == false) 
            {
                Floor floor = new FilteredElementCollector(linkDoc).OfClass(typeof(Floor)).Where(x => x.Name.Contains("停车位")).Cast<Floor>().First();
                //楼板几何
                GeometryElement geometryElement = floor.get_Geometry(new Options());
                GeometryObject topFace = null;
                //获取楼板顶面
                foreach (GeometryObject geometryObject in geometryElement)
                {
                    if (geometryObject is Solid)
                    {
                        Solid solid1 = geometryObject as Solid;
                        foreach (PlanarFace face in solid1.Faces)
                        {
                            if (face.FaceNormal.Z > 0)
                            {
                                topFace = face;
                                break;
                            }
                        }
                        if (topFace != null)
                        {
                            break;
                        }
                    }
                }
                Face newTopFace = topFace as Face;
                //获取顶面的线

                List<FloorLoops> floorLoops = new List<FloorLoops>();
                foreach (EdgeArray edgeArray in newTopFace.EdgeLoops)
                {

                    List<CurveLoop> loops1 = new List<CurveLoop>();
                    List<Curve> curveList = new List<Curve>();
                    foreach (Edge edge in edgeArray)
                    {
                        Curve curve = edge.AsCurve();
                        //using (Transaction tran = new Transaction(doc, "Asda"))
                        //{
                        //    tran.Start();
                        //    Utils.CreateModelLine(doc, curve.GetEndPoint(0), curve.GetEndPoint(1));

                        //    tran.Commit();
                        //}
                        curveList.Add(curve);
                    }
                    CurveLoop curveLoop = CurveLoop.Create(curveList);
                    //MessageBox.Show("Asdasd");
                    loops1.Add(curveLoop);
                    floorLoops.Add(new FloorLoops() { LoopsList = loops1 });
                }
                IList<Solid> solids = new List<Solid>();
                //放样 创建solid


                foreach (FloorLoops item in floorLoops)
                {
                    Solid solid = GeometryCreationUtilities.CreateExtrusionGeometry(item.LoopsList, XYZ.BasisZ, 6000 / 304.8);
                    solids.Add(solid);
                }

                HashSet<Duct> ducts1 = new HashSet<Duct>();
                foreach (Solid solid in solids)
                {
                    ElementIntersectsSolidFilter filter = new ElementIntersectsSolidFilter(solid);
                    List<Duct> ducts = new FilteredElementCollector(doc).OfClass(typeof(Duct)).WherePasses(filter).Cast<Duct>().ToList();
                    if (ducts.Count > 0)
                    {
                        foreach (Duct item in ducts)
                        {
                            ducts1.Add(item);
                        }
                    }
                }

                //foreach (Reference reference in references)
                foreach (Duct duct in ducts1)
                {
                    //Duct duct = doc.GetElement(reference) as Duct;


                    XYZ min = duct.get_BoundingBox(uIDoc.ActiveView).Min;
                    XYZ max = duct.get_BoundingBox(uIDoc.ActiveView).Max;
                    XYZ p1 = new XYZ(min.X, min.Y, max.Z);
                    XYZ p2 = new XYZ(min.X, max.Y, max.Z);
                    XYZ p3 = new XYZ(max.X, max.Y, max.Z);
                    XYZ p4 = new XYZ(max.X, min.Y, max.Z);

                    List<CurveLoop> loops = new List<CurveLoop>();
                    List<Curve> curveList = new List<Curve> { Line.CreateBound(p1, p2), Line.CreateBound(p2, p3), Line.CreateBound(p3, p4), Line.CreateBound(p4, p1) };
                    CurveLoop curveLoop = CurveLoop.Create(curveList);
                    loops.Add(curveLoop);
                    Solid solid1 = GeometryCreationUtilities.CreateExtrusionGeometry(loops, XYZ.BasisZ, 2000 / 304.8);
                    ElementIntersectsSolidFilter filter = new ElementIntersectsSolidFilter(solid1);

                    FilteredElementCollector collector2 = new FilteredElementCollector(linkDoc);
                    //collector2.WherePasses(filter).ToElements();
                    List<FamilyInstance> beams = collector2.WherePasses(new ElementCategoryFilter(BuiltInCategory.OST_StructuralFraming)).WhereElementIsNotElementType().WherePasses(filter).Cast<FamilyInstance>().Where(x => x.Symbol.FamilyName.Contains("梁")).ToList();
                    foreach (FamilyInstance beam in beams)
                    {
                        XYZ point = beam.get_BoundingBox(view3D).Min;
                        double beamToFloor = GetClearHeightDown(view3D, linkDoc, point) * 304.8;
                        double ductToFloor = GetClearHeightDown(view3D, linkDoc, min) * 304.8;
                        if (ductToFloor == 0)
                        {
                            Difference difference = new Difference() { spacing = 0, inputValue = spacing, result = "无法判断", beamId = beam.Id, ductId = duct.Id, notes = "梁下方未找到楼板" };
                            differences.Add(difference);
                            continue;
                        }
                        //double ductHeight = duct.get_Parameter(BuiltInParameter.RBS_CURVE_HEIGHT_PARAM).AsDouble() * 304.8;

                        //TaskDialog.Show("1", beamToFloor + "|" + ductHeight);
                        //if (beamToFloor - (ductHeight + 140) < spacing)
                        if (ductToFloor - 140 < spacing)
                        {
                            Difference difference = new Difference() { spacing = ductToFloor - 140, inputValue = spacing, result = "不符合", beamId = beam.Id, ductId = duct.Id, notes = "净高无法满足所提供的标准值" };
                            differences.Add(difference);
                        }
                        else
                        {
                            Difference difference = new Difference() { spacing = ductToFloor - 140, inputValue = spacing, result = "符合", beamId = beam.Id, ductId = duct.Id, notes = "净高满足所提供的标准值" };
                            differences.Add(difference);
                        }
                    }
                }
            }
            else
            {
                double floorHeight = Convert.ToDouble(userControl.floorHeight.Text);
                List<Duct> ducts = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_DuctCurves).OfClass(typeof(Duct)).Cast<Duct>().ToList();
                foreach (var duct in ducts)
                {
                    XYZ min = duct.get_BoundingBox(uIDoc.ActiveView).Min;
                    XYZ max = duct.get_BoundingBox(uIDoc.ActiveView).Max;
                    XYZ p1 = new XYZ(min.X, min.Y, max.Z);
                    XYZ p2 = new XYZ(min.X, max.Y, max.Z);
                    XYZ p3 = new XYZ(max.X, max.Y, max.Z);
                    XYZ p4 = new XYZ(max.X, min.Y, max.Z);

                    List<CurveLoop> loops = new List<CurveLoop>();
                    List<Curve> curveList = new List<Curve> { Line.CreateBound(p1, p2), Line.CreateBound(p2, p3), Line.CreateBound(p3, p4), Line.CreateBound(p4, p1) };
                    CurveLoop curveLoop = CurveLoop.Create(curveList);
                    loops.Add(curveLoop);
                    Solid solid1 = GeometryCreationUtilities.CreateExtrusionGeometry(loops, XYZ.BasisZ, 2000 / 304.8);
                    ElementIntersectsSolidFilter filter = new ElementIntersectsSolidFilter(solid1);

                    FilteredElementCollector collector2 = new FilteredElementCollector(linkDoc);
                    //collector2.WherePasses(filter).ToElements();
                    List<FamilyInstance> beams = collector2.WherePasses(new ElementCategoryFilter(BuiltInCategory.OST_StructuralFraming)).WhereElementIsNotElementType().WherePasses(filter).Cast<FamilyInstance>().Where(x => x.Symbol.FamilyName.Contains("梁")).ToList();
                    foreach (FamilyInstance beam in beams)
                    {
                        XYZ point = beam.get_BoundingBox(view3D).Min;
                        double beamToFloor = GetClearHeightDown(view3D, linkDoc, point) * 304.8;
                        double ductToFloor = GetClearHeightDown(view3D, linkDoc, min) * 304.8;
                        if (ductToFloor == 0)
                        {
                            Difference difference = new Difference() { spacing = 0, inputValue = spacing, result = "无法判断", beamId = beam.Id, ductId = duct.Id, notes = "梁下方未找到楼板" };
                            differences.Add(difference);
                            continue;
                        }
                        //double ductHeight = duct.get_Parameter(BuiltInParameter.RBS_CURVE_HEIGHT_PARAM).AsDouble() * 304.8;

                        //TaskDialog.Show("1", beamToFloor + "|" + ductHeight);
                        //if (beamToFloor - (ductHeight + 140) < spacing)
                        if (ductToFloor - 140 - floorHeight < spacing)
                        {
                            Difference difference = new Difference() { spacing = ductToFloor - 140 - floorHeight, inputValue = spacing, result = "不符合", beamId = beam.Id, ductId = duct.Id, notes = "净高无法满足所提供的标准值" };
                            differences.Add(difference);
                        }
                        else
                        {
                            Difference difference = new Difference() { spacing = ductToFloor - 140 - floorHeight, inputValue = spacing, result = "符合", beamId = beam.Id, ductId = duct.Id, notes = "净高满足所提供的标准值" };
                            differences.Add(difference);
                        }
                    }
                }
            }
            //UIDocument uIDocument = new UIDocument(linkDoc);
            //uIDocument.ShowElements(differences.First().beamId);
            UserControl2 userControl2 = new UserControl2(differences, doc);
            userControl2.Show();
            return Result.Succeeded;
        }

        #region 获得梁底部向下投影的净高
        public double GetClearHeightDown(View3D view, Document doc, XYZ point_Do)
        {
            double distance = 0.0;
            //梁的计算点point_Do 

            List<ElementFilter> filterList = new List<ElementFilter>();
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_Floors));
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_Ceilings));
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_RvtLinks));
            //filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_GenericModel));

            LogicalOrFilter floorOrCeiling = new LogicalOrFilter(filterList);


            //相交
            ReferenceIntersector referenceIntersector = new ReferenceIntersector(floorOrCeiling, FindReferenceTarget.All, view);
            referenceIntersector.FindReferencesInRevitLinks = true;

            ReferenceWithContext referenceWithContext = referenceIntersector.FindNearest(point_Do, XYZ.BasisZ.Negate());
            if (referenceWithContext == null)
            {
                return distance;
            }
            Reference r2 = referenceWithContext.GetReference();
            distance = r2.GlobalPoint.DistanceTo(point_Do);
            //DrawModelCurve(doc, point_Do, r2.GlobalPoint);

            return distance;

        }
        #endregion
        #region 获得风管底部向上投影的净高
        public double GetClearHeightUp(View3D view, Document doc, XYZ point_Do)
        {
            double distance = 0.0;
            //梁的计算点point_Do 

            List<ElementFilter> filterList = new List<ElementFilter>();
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_Floors));
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_Ceilings));
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_RvtLinks));
            //filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_GenericModel));

            LogicalOrFilter floorOrCeiling = new LogicalOrFilter(filterList);


            //相交
            ReferenceIntersector referenceIntersector = new ReferenceIntersector(floorOrCeiling, FindReferenceTarget.All, view);
            referenceIntersector.FindReferencesInRevitLinks = true;

            ReferenceWithContext referenceWithContext = referenceIntersector.FindNearest(point_Do, XYZ.BasisZ);
            if (referenceWithContext == null)
            {
                return distance;
            }

            Reference r2 = referenceWithContext.GetReference();
            distance = r2.GlobalPoint.DistanceTo(point_Do);
            //DrawModelCurve(doc, point_Do, r2.GlobalPoint);

            return distance;

        }
        #endregion
    }
    //public class DuctFilter : ISelectionFilter
    //{
    //    public bool AllowElement(Element elem)
    //    {
    //        if (elem.Category.Id.IntegerValue == -2008000)
    //        {
    //            return true;
    //        }
    //        return false;
    //    }

    //    public bool AllowReference(Reference reference, XYZ position)
    //    {
    //        return false;
    //    }
    //}

    public class FloorLoops
    {
        public List<CurveLoop> LoopsList {  get; set; }
    }
}
