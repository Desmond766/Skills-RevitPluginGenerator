using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interop;
using System.Windows.Media;
using Color = System.Drawing.Color;
using Transform = Autodesk.Revit.DB.Transform;

// 车位族净高分析
namespace NetHeightAnalysis
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;

            //Reference linkRefer = sel.PickObject(ObjectType.LinkedElement);
            //RevitLinkInstance linkInstance = doc.GetElement(linkRefer) as RevitLinkInstance;
            //Document linkDoc = linkInstance.GetLinkDocument();
            //Floor floor = (Floor)linkDoc.GetElement(linkRefer.LinkedElementId);
            //var face = HostObjectUtils.GetTopFaces(floor);
            //TaskDialog.Show("revit", (face.Count).ToString());

            //return Result.Succeeded;

            
            //Reference reference = sel.PickObject(ObjectType.Element);
            //XYZ po = (doc.GetElement(reference).Location as LocationPoint).Point;
            //Transaction ttt = new Transaction(doc, "创建标注");
            //ttt.Start();
            //IndependentTag independentTag = IndependentTag.Create(doc, doc.ActiveView.Id, reference, false, TagMode.TM_ADDBY_CATEGORY, TagOrientation.Horizontal, po);
            //ttt.Commit();
            //return Result.Succeeded;

            //Reference linkRefer = sel.PickObject(ObjectType.LinkedElement, "选择车道边界线所在链接模型");
            //RevitLinkInstance revitLinkInstance = doc.GetElement(linkRefer) as RevitLinkInstance;
            //Document linkDoc = revitLinkInstance.GetLinkDocument();
            //Floor linkFloor = linkDoc.GetElement(linkRefer.LinkedElementId) as Floor;

            //var faceRef = HostObjectUtils.GetTopFaces(linkFloor);
            //Face face = linkFloor.GetGeometryObjectFromReference(faceRef.First()) as Face;
            //IList<CurveLoop> loopss = face.GetEdgesAsCurveLoops();
            //List<CurveLoop> newLoops = new List<CurveLoop>();
            //foreach (var loop in loopss)
            //{
            //    CurveLoop curves = new CurveLoop();
            //    foreach (var curve in loop)
            //    {
            //        curves.Append(curve.CreateTransformed(revitLinkInstance.GetTransform()));
            //    }
            //    newLoops.Add(curves);
            //}

            //FilledRegionType frTypess = null;
            //using (FilteredElementCollector fillTypeCol = new FilteredElementCollector(doc))
            //{
            //    fillTypeCol.OfCategory(BuiltInCategory.OST_DetailComponents).OfClass(typeof(FilledRegionType));
            //    var types = fillTypeCol.Cast<FilledRegionType>().ToList();
            //    frTypess = types.First();
            //}
            //Transaction tt = new Transaction(doc, "楼板色块");
            //tt.Start();
            //FilledRegion.Create(doc, frTypess.Id, doc.ActiveView.Id, newLoops);
            //tt.Commit();


            //return Result.Succeeded;

            SelWindow selWindow = new SelWindow(doc);
            IntPtr intPtr = commandData.Application.MainWindowHandle;
            WindowInteropHelper windowInteropHelper = new WindowInteropHelper(selWindow);
            windowInteropHelper.Owner = intPtr;
            selWindow.ShowDialog();
            if (selWindow.DialogResult == false)
            {
                return Result.Cancelled;
            }

            List<FillInfo> fillInfos = selWindow.FillInfos.ToList();
            //return Result.Succeeded;

            List<ClearHeightInfo> clearHeightInfos = new List<ClearHeightInfo>();

            ElementMulticategoryFilter multicategoryFilter = new ElementMulticategoryFilter(new List<BuiltInCategory>()
            {
                BuiltInCategory.OST_PipeCurves,
                BuiltInCategory.OST_PipeAccessory,
                BuiltInCategory.OST_PipeFitting,
                BuiltInCategory.OST_PipeInsulations,
                BuiltInCategory.OST_FlexPipeCurves,
                BuiltInCategory.OST_Sprinklers,
                BuiltInCategory.OST_DuctCurves,
                BuiltInCategory.OST_DuctFitting,
                BuiltInCategory.OST_DuctAccessory,
                BuiltInCategory.OST_DuctInsulations,
                BuiltInCategory.OST_DuctTerminal,
                BuiltInCategory.OST_FlexDuctCurves,
                BuiltInCategory.OST_CableTray,
                BuiltInCategory.OST_CableTrayFitting,
                BuiltInCategory.OST_MechanicalEquipment,
                BuiltInCategory.OST_LightingFixtures,
                BuiltInCategory.OST_StructuralFraming,
                BuiltInCategory.OST_Floors,
                BuiltInCategory.OST_Stairs
            });
            List<FamilyInstance> parkingSpaces = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_GenericModel)
                .Where(e => e is FamilyInstance f && f.Symbol.FamilyName.Contains("代替车位族")).Cast<FamilyInstance>().ToList();

            foreach (var ps in parkingSpaces)
            {
                XYZ point = (ps.Location as LocationPoint).Point;
                var box = ps.get_BoundingBox(null);
                XYZ min = box.Min;
                XYZ max = box.Max + XYZ.BasisZ * 2000;
                var boxFilter = CreateBoundingBoxIntersectsFilter(min, max);

                IList<CurveLoop> loops = GetParkingSpaceBoundary(ps, out var topFace);
                var solidFilter = CreateSolidFilter(loops, 2000, out var createSolid);

                LogicalAndFilter andFilter = new LogicalAndFilter(boxFilter, solidFilter);

                List<Solid> solids = new List<Solid>();
                List<SolidInfo> solidInfos = new List<SolidInfo>();
                using (FilteredElementCollector cateCol = new FilteredElementCollector(doc, doc.ActiveView.Id).WherePasses(multicategoryFilter).WherePasses(andFilter))
                {
                    List<Element> results = cateCol.ToList();
                    foreach (var elem in results)
                    {
                        var elemSolids = GetSolids(doc, elem);
                        foreach (var es in elemSolids)
                        {
                            try
                            {
                                Solid inSolid = BooleanOperationsUtils.ExecuteBooleanOperation(es, createSolid, BooleanOperationsType.Intersect);
                                if (inSolid != null && inSolid.Volume > 0 && inSolid.SurfaceArea > 0)
                                {
                                    solids.Add(inSolid);
                                    solidInfos.Add(new SolidInfo() { Solid = inSolid, InId = elem.Id });
                                }
                            }
                            catch (Exception)
                            {
                                // 俩solid由于形状过于复杂导致报错
                                continue;
                            }
                        }
                    }
                }
                XYZ globalLowest = null;
                double minZ = double.MaxValue;
                ElementId finalId = null;
                //foreach (Solid solid in solids)
                //{
                //    XYZ p = GetSolidLowestPoint(solid);

                //    if (p != null && p.Z < minZ)
                //    {
                //        minZ = p.Z;
                //        globalLowest = p;
                //    }
                //}
                foreach (var solidInfo in solidInfos)
                {
                    Solid solid = solidInfo.Solid;
                    XYZ p = GetSolidLowestPoint(solid);

                    if (p != null && p.Z < minZ)
                    {
                        minZ = p.Z;
                        globalLowest = p;
                        finalId = solidInfo.InId;
                    }
                }
                if (globalLowest == null)
                {
                    clearHeightInfos.Add(new ClearHeightInfo(ElementId.InvalidElementId, ps.Id, point, "无", double.NaN, loops));
                }
                else
                {
                    double minDis = topFace.Project(globalLowest).XYZPoint.DistanceTo(globalLowest);
                    XYZ pp = GetFaceLineIntersection(topFace, Line.CreateUnbound(globalLowest, XYZ.BasisZ));
                    if (pp != null) minDis = pp.DistanceTo(globalLowest);
                    clearHeightInfos.Add(new ClearHeightInfo(finalId, ps.Id, point, doc.GetElement(finalId).Category.Name, Math.Round(minDis * 304.8, 2, MidpointRounding.AwayFromZero), loops));
                }
            }

            //MainWindow mainWindow = new MainWindow(uidoc, clearHeightInfos);
            //mainWindow.Show();

            // 在代替车位族实例上方创建填充区域
            TextNoteType textNoteType = selWindow.TextNoteType;
            using (Transaction t = new Transaction(doc, "区域填充"))
            {
                t.Start();
                foreach (var chInfo in clearHeightInfos)
                {
                    if (chInfo.ClearHeight.ToString() != "NaN")
                    {
                        XYZ point = chInfo.FloorPos;
                        string text = "净高=" + Math.Round(chInfo.ClearHeight / 1000.0, 2, MidpointRounding.AwayFromZero) + "m";
                        TextNote textNote = TextNote.Create(doc, doc.ActiveView.Id, point, text, textNoteType.Id);
                        textNote.Location.Move(XYZ.BasisX.Negate() * (600 / 304.8));
                        textNote.Location.Move(XYZ.BasisY * (200 / 304.8));
                    }
                    
                    if (chInfo.Loops == null) continue;
                    var frType = GetFilledRegionTypeByClearHeight(fillInfos, chInfo.ClearHeight);
                    if (frType == null) continue;

                    FilledRegion.Create(doc, frType.Id, doc.ActiveView.Id, chInfo.Loops);
                    Autodesk.Revit.DB.Color color = frType.ForegroundPatternColor;
                    chInfo.Color = ColorTranslator.ToHtml(Color.FromArgb(color.Red, color.Green, color.Blue)); 
                }
                t.Commit();
            }

            //TaskDialog.Show("提示", "完成");
            MainWindow mainWindow = new MainWindow(uidoc, clearHeightInfos);
            mainWindow.Show();
            return Result.Succeeded;
        }
        private FilledRegionType GetFilledRegionTypeByClearHeight(List<FillInfo> fillInfos, double clearHeight)
        {
            FilledRegionType result = null;
            FillInfo fillInfo = fillInfos.FirstOrDefault(f => f.Min <= clearHeight && f.Max > clearHeight);
            if (fillInfo != null) result = fillInfo.FilledRegionType;
            return result;
        }
        private List<Solid> GetSolids(Document doc, Element element)
        {
            List<Solid> solids = new List<Solid>();

            Options opt = new Options();
            opt.DetailLevel = ViewDetailLevel.Fine;
            opt.ComputeReferences = true;
            opt.IncludeNonVisibleObjects = false;

            GeometryElement geoElem = element.get_Geometry(opt);

            foreach (GeometryObject geoObj in geoElem)
            {
                if (geoObj is Solid solid && solid.Volume > 1e-6)
                {
                    if (element.Category.Id.IntegerValue == -2001120 && solid.GraphicsStyleId != null && doc.GetElement(solid.GraphicsStyleId).Name.Contains("光源")) continue;
                    solids.Add(solid);
                }
                else if (geoObj is GeometryInstance geoInst)
                {
                    GeometryElement instGeo = geoInst.GetInstanceGeometry();
                    Transform transform = geoInst.Transform;

                    foreach (GeometryObject instObj in instGeo)
                    {
                        if (instObj is Solid instSolid && instSolid.Volume > 1e-6)
                        {
                            //solids.Add(SolidUtils.CreateTransformed(instSolid, transform));
                            if (element.Category.Id.IntegerValue == -2001120 && instSolid.GraphicsStyleId != null && doc.GetElement(instSolid.GraphicsStyleId)?.Name == "光源") continue;
                            solids.Add(instSolid);
                        }
                    }
                }
            }

            return solids;
        }
        private XYZ GetSolidLowestPoint(Solid solid)
        {
            XYZ lowestPoint = null;
            double minZ = double.MaxValue;

            foreach (Face face in solid.Faces)
            {
                Mesh mesh = face.Triangulate();

                foreach (XYZ point in mesh.Vertices)
                {
                    if (point.Z < minZ)
                    {
                        minZ = point.Z;
                        lowestPoint = point;
                    }
                }
            }

            return lowestPoint;
        }
        private IList<CurveLoop> GetParkingSpaceBoundary(FamilyInstance ps, out PlanarFace topFace)
        {
            topFace = null;

            Options options = new Options()
            {
                DetailLevel = ViewDetailLevel.Fine,
                IncludeNonVisibleObjects = false
            };
            var gee = ps.get_Geometry(options);
            foreach (var geo in gee)
            {
                if (geo is GeometryInstance gei)
                {
                    foreach (var geo2 in gei.GetInstanceGeometry())
                    {
                        if (geo2 is Solid solid && solid.Volume > 0)
                        {
                            foreach (Face face in solid.Faces)
                            {
                                if (face is PlanarFace planarFace && planarFace.FaceNormal.IsAlmostEqualTo(XYZ.BasisZ))
                                {
                                    topFace = planarFace;
                                    return planarFace.GetEdgesAsCurveLoops();
                                }
                            }
                        }
                    }
                }
            }
            return null;
        }
        private BoundingBoxIntersectsFilter CreateBoundingBoxIntersectsFilter(XYZ min, XYZ max)
        {
            return new BoundingBoxIntersectsFilter(new Outline(min, max));
        }
        private ElementIntersectsSolidFilter CreateSolidFilter(IList<CurveLoop> loops, double findHigh, out Solid solid)
        {
            solid = GeometryCreationUtilities.CreateExtrusionGeometry(loops, XYZ.BasisZ, findHigh);
            ElementIntersectsSolidFilter filter = new ElementIntersectsSolidFilter(solid);
            return filter;
        }
        private XYZ GetFaceLineIntersection(Face face, Line line)
        {
            IntersectionResultArray resultArray;

            SetComparisonResult result = face.Intersect(line, out resultArray);

            if (result == SetComparisonResult.Overlap && resultArray != null)
            {
                foreach (IntersectionResult ir in resultArray)
                {
                    XYZ intersectionPoint = ir.XYZPoint;
                    return intersectionPoint; // 返回第一个交点
                }
            }

            return null; // 没有交点
        }
    }

    public class SolidInfo
    {
        public ElementId InId { get; set; }
        public Solid Solid { get; set; }
    }
}
