using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.Exceptions;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OperationCanceledException = Autodesk.Revit.Exceptions.OperationCanceledException;

// 补充大样/垫梁
namespace SupplySleeperBeam
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;

            //var r1 = sel.PickObject(ObjectType.Edge);
            //var r2 = sel.PickObject(ObjectType.Edge);
            //Edge line = doc.GetElement(r1).GetGeometryObjectFromReference(r1) as Edge;
            //Edge line2 = doc.GetElement(r2).GetGeometryObjectFromReference(r2) as Edge;

            ////TaskDialog.Show("revit", (line == null).ToString() + "\n" + (line2 == null));
            //bool res = AreLinesParallel(line.AsCurve() as Line, line2.AsCurve() as Line, 0.18);
            //TaskDialog.Show("revit", res.ToString());

            //return Result.Succeeded;

            var levels = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Levels).OfClass(typeof(Level)).Cast<Level>().OrderBy(l => l.Elevation);

        Next:
            Element highElement;
            Element lowElement;
            try
            {
                highElement = doc.GetElement(sel.PickObject(ObjectType.Element, new FloorAndBeamFilter(), "选择第一个楼板或梁"));
                lowElement = doc.GetElement(sel.PickObject(ObjectType.Element, new FloorAndBeamFilter(highElement.Id), "选择第二个楼板或梁"));

                if (lowElement.get_BoundingBox(null).Max.Z > highElement.get_BoundingBox(null).Max.Z)
                {
                    Element tempElem = highElement;
                    highElement = lowElement;
                    lowElement = tempElem;
                }
            }
            catch (OperationCanceledException)
            {
                return Result.Succeeded;
            }
            try
            {
                if (highElement is Floor highFloor)
                {
                    if (lowElement is Floor lowFloor)
                    {
                        SupplyBetweenTwoFloor(doc, highFloor, lowFloor);
                    }
                    else if (lowElement is FamilyInstance instance && instance.StructuralType == Autodesk.Revit.DB.Structure.StructuralType.Beam)
                    {
                        SupplyBetweenFloorAndBeam(doc, highFloor, instance);
                    }
                }
                else
                {
                    SupplyBetweenBeamAndFloor(doc, highElement as FamilyInstance, lowElement as Floor);
                }
            }
            catch (Exception ex)
            {
                TaskDialog.Show("ERROR", ex.Message);
                return Result.Succeeded;
            }
            goto Next;

            return Result.Succeeded;
        }
        private void SupplyBetweenBeamAndFloor(Document doc, FamilyInstance beam, Floor lowFloor)
        {
            var botfaceRefer = HostObjectUtils.GetBottomFaces(lowFloor).First();
            PlanarFace botFace = lowFloor.GetGeometryObjectFromReference(botfaceRefer) as PlanarFace;

            List<Line> lowLines = new List<Line>();
            foreach (var curve in botFace.GetEdgesAsCurveLoops().First()) { if (curve is Line line) { lowLines.Add(line); } }

            PlanarFace botBeamFace = GetBeamPlanarFace(beam, XYZ.BasisZ.Negate());
            if (botBeamFace == null)
            {
                TaskDialog.Show("ERROR", "未找到梁底面");
                return;
            }

            //拉伸
            Solid solid = GeometryCreationUtilities.CreateExtrusionGeometry(botBeamFace.GetEdgesAsCurveLoops(), XYZ.BasisZ.Negate(), 2000);
            ElementIntersectsSolidFilter filter = new ElementIntersectsSolidFilter(solid);

            bool onTheFloor = false;
            using (FilteredElementCollector floorCol = new FilteredElementCollector(doc, new ElementId[] { lowFloor.Id }).WherePasses(filter))
            {
                if (floorCol.Count() > 0) onTheFloor = true;
            }

            ElementId levelId = (beam.LevelId == null || beam.LevelId == ElementId.InvalidElementId) ? beam.get_Parameter(BuiltInParameter.INSTANCE_REFERENCE_LEVEL_PARAM).AsElementId() : beam.LevelId;
            double wallWidth = beam.Symbol.LookupParameter("b")?.AsDouble() ?? beam.Symbol.LookupParameter("宽度").AsDouble();
            double wallHeight;
            double offset = GetWallOffset(beam);
            Curve createCurve = (beam.Location as LocationCurve).Curve;
            WallType wallType = new FilteredElementCollector(doc).WhereElementIsElementType().OfCategory(BuiltInCategory.OST_Walls).Cast<WallType>()
                .FirstOrDefault(wt => (wt.Name.Contains("垫梁") || wt.Name.Contains("大样")) && Math.Abs(wt.get_Parameter(BuiltInParameter.WALL_ATTR_WIDTH_PARAM).AsDouble() - wallWidth) < 0.001);
            if (wallType == null)
            {
                TaskDialog.Show("ERROR", "未找到指定族类型");
                return;
            }
            if (onTheFloor)
            {
                var topfaceRefer = HostObjectUtils.GetTopFaces(lowFloor).First();
                PlanarFace topFace = lowFloor.GetGeometryObjectFromReference(topfaceRefer) as PlanarFace;
                wallHeight = Math.Abs(topFace.Origin.Z - botBeamFace.Origin.Z);
            }
            else
            {
                wallHeight = Math.Abs(botFace.Origin.Z - botBeamFace.Origin.Z);
            }
            offset -= (wallHeight + GetBeamHeight(beam));
            using (Transaction t = new Transaction(doc, "补充大样/垫梁"))
            {
                t.Start();
                Wall.Create(doc, createCurve, wallType.Id, levelId, wallHeight, offset, false, false);
                t.Commit();
            }
        }
        private double GetBeamHeight(FamilyInstance beam)
        {
            return beam.Symbol.LookupParameter("梁高")?.AsDouble() ?? beam.Symbol.LookupParameter("高度").AsDouble();
        }
        private double GetWallOffset(FamilyInstance beam)
        {
            double offset;

            offset = beam.get_Parameter(BuiltInParameter.STRUCTURAL_BEAM_END0_ELEVATION).AsDouble() + beam.get_Parameter(BuiltInParameter.Z_OFFSET_VALUE).AsDouble();
            double beamHeight = beam.Symbol.LookupParameter("梁高")?.AsDouble() ?? beam.Symbol.LookupParameter("高度").AsDouble();
            Parameter para = beam.get_Parameter(BuiltInParameter.Z_JUSTIFICATION);
            switch (para.AsInteger())
            {
                case 0:// 顶
                    break;
                case 1:// 中心线
                    offset += beamHeight / 2.0;
                    break;
                case 2:// 原点
                    offset += beamHeight / 2.0;
                    break;
                case 3:// 底
                    offset += beamHeight;
                    break;
                default:
                    break;
            }

            return offset;
        }
        private PlanarFace GetBeamPlanarFace(FamilyInstance beam, XYZ faceNormal)
        {
            PlanarFace result = null;

            Options options = new Options() { IncludeNonVisibleObjects = false, DetailLevel = ViewDetailLevel.Fine };
            var gee = beam.get_Geometry(options);
            foreach (var geo in gee)
            {
                if (geo is Solid solid && solid.Volume > 0 && solid.SurfaceArea > 0)
                {
                    foreach (Face face in solid.Faces)
                    {
                        if (!(face is PlanarFace)) continue;
                        PlanarFace planarFace = (PlanarFace)face;
                        if (planarFace.FaceNormal.IsAlmostEqualTo(faceNormal))
                        {
                            result = planarFace;
                            break;
                        }
                    }
                }
                else if (geo is GeometryInstance gei)
                {
                    foreach (var subGeo in gei.GetInstanceGeometry())
                    {
                        if (subGeo is Solid subSolid && subSolid.Volume > 0 && subSolid.SurfaceArea > 0)
                        {
                            foreach (Face face in subSolid.Faces)
                            {
                                if (!(face is PlanarFace)) continue;
                                PlanarFace planarFace = (PlanarFace)face;
                                if (planarFace.FaceNormal.IsAlmostEqualTo(faceNormal))
                                {
                                    result = planarFace;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }
        private void SupplyBetweenFloorAndBeam(Document doc, Floor highFloor, FamilyInstance beam)
        {
            var topfaceRefer1 = HostObjectUtils.GetTopFaces(highFloor).First();
            PlanarFace topFace = highFloor.GetGeometryObjectFromReference(topfaceRefer1) as PlanarFace;

            List<Line> topLines = new List<Line>();
            foreach (var curve in topFace.GetEdgesAsCurveLoops().First()) { if (curve is Line line) { topLines.Add(line); } }

            PlanarFace topBeamFace = GetBeamPlanarFace(beam, XYZ.BasisZ);
            if (topBeamFace == null)
            {
                TaskDialog.Show("ERROR", "未找到梁顶面");
                return;
            }

            //拉伸
            Solid solid = GeometryCreationUtilities.CreateExtrusionGeometry(topBeamFace.GetEdgesAsCurveLoops(), XYZ.BasisZ, 2000);
            ElementIntersectsSolidFilter filter = new ElementIntersectsSolidFilter(solid);

            bool underTheFloor = false;
            using (FilteredElementCollector floorCol = new FilteredElementCollector(doc, new ElementId[] { highFloor.Id }).WherePasses(filter))
            {
                if (floorCol.Count() > 0) underTheFloor = true;
            }

            ElementId levelId = (beam.LevelId == null || beam.LevelId == ElementId.InvalidElementId) ? beam.get_Parameter(BuiltInParameter.INSTANCE_REFERENCE_LEVEL_PARAM).AsElementId() : beam.LevelId;
            double wallWidth = beam.Symbol.LookupParameter("b").AsDouble();
            double wallHeight;
            double offset = GetWallOffset(beam);
            Curve createCurve = (beam.Location as LocationCurve).Curve;
            WallType wallType = new FilteredElementCollector(doc).WhereElementIsElementType().OfCategory(BuiltInCategory.OST_Walls).Cast<WallType>()
                .FirstOrDefault(wt => (wt.Name.Contains("垫梁") || wt.Name.Contains("大样")) && Math.Abs(wt.get_Parameter(BuiltInParameter.WALL_ATTR_WIDTH_PARAM).AsDouble() - wallWidth) < 0.001);
            if (wallType == null)
            {
                TaskDialog.Show("ERROR", "未找到指定族类型");
                return;
            }
            if (underTheFloor)
            {

                var botfaceRefer = HostObjectUtils.GetBottomFaces(highFloor).First();
                PlanarFace botFace = highFloor.GetGeometryObjectFromReference(botfaceRefer) as PlanarFace;
                wallHeight = Math.Abs(botFace.Origin.Z - topBeamFace.Origin.Z);
            }
            else
            {
                wallHeight = Math.Abs(topFace.Origin.Z - topBeamFace.Origin.Z);
            }
            using (Transaction t = new Transaction(doc, "补充大样/垫梁"))
            {
                t.Start();
                Wall.Create(doc, createCurve, wallType.Id, levelId, wallHeight, offset, false, false);
                t.Commit();
            }
        }
        private void SupplyBetweenTwoFloor(Document doc, Floor highFloor, Floor lowFloor)
        {
            var topfaceRefer1 = HostObjectUtils.GetTopFaces(highFloor).First();
            PlanarFace face1 = highFloor.GetGeometryObjectFromReference(topfaceRefer1) as PlanarFace;
            var topfaceRefer2 = HostObjectUtils.GetBottomFaces(lowFloor).First();
            PlanarFace face2 = lowFloor.GetGeometryObjectFromReference(topfaceRefer2) as PlanarFace;

            List<Line> topLines = new List<Line>();
            foreach (var curve in face1.GetEdgesAsCurveLoops().First())
            {
                if (curve is Line line) { topLines.Add(line); }
            }
            List<Line> botLines = new List<Line>();
            foreach (var curve in face2.GetEdgesAsCurveLoops().First())
            {
                if (curve is Line line) { botLines.Add(line); }
            }

            //ElementId levelId = levels.FirstOrDefault(l => l.Elevation < lowFloor.get_BoundingBox(null).Max.Z + 1.0 / 304.8)?.Id;
            ElementId levelId = (lowFloor.LevelId == null || lowFloor.LevelId == ElementId.InvalidElementId) ? lowFloor.get_Parameter(BuiltInParameter.LEVEL_PARAM).AsElementId() : lowFloor.LevelId;
            double offset = lowFloor.get_Parameter(BuiltInParameter.FLOOR_HEIGHTABOVELEVEL_PARAM).AsDouble()
                - lowFloor.get_Parameter(BuiltInParameter.FLOOR_ATTR_THICKNESS_PARAM).AsDouble();

            double minDis = double.MaxValue;
            Line closestTopLine = null;
            Line closestBotLine = null;

            foreach (var topLine in topLines)
            {
                foreach (var botLine in botLines)
                {
                    // 判断两直线是否平行，误差10度
                    if (AreLinesParallel(botLine, topLine, 0.18))
                    {
                        double dis = DistanceBetweenTwoLines(topLine, botLine);
                        if (dis < minDis)
                        {
                            minDis = dis;
                            closestBotLine = botLine;
                            closestTopLine = topLine;
                        }
                    }
                }
            }
            double wallHeight = GetWallHeight(closestTopLine, closestBotLine);
            Line createLine = GetCreateLine(closestTopLine, closestBotLine);

            var wallTypes = new FilteredElementCollector(doc).WhereElementIsElementType().OfCategory(BuiltInCategory.OST_Walls).Cast<WallType>().Where(wt => wt.Name.Contains("垫梁") || wt.Name.Contains("大样")).ToList();
            WallType wallType = wallTypes.FirstOrDefault(wt => Math.Abs(wt.get_Parameter(BuiltInParameter.WALL_ATTR_WIDTH_PARAM).AsDouble() - minDis) < 0.001);
            if (wallType == null) wallType = wallTypes.FirstOrDefault(wt => Math.Abs(wt.get_Parameter(BuiltInParameter.WALL_ATTR_WIDTH_PARAM).AsDouble() - 200.0 / 304.8) < 0.001);
            if (wallType == null)
            {
                TaskDialog.Show("ERROR", "未找到指定族类型");
                return;
            }
            using (Transaction t = new Transaction(doc, "补充大样/垫梁"))
            {
                t.Start();

                Wall.Create(doc, createLine, wallType.Id, levelId, wallHeight, offset, false, false);
                //var curves = GetCreateWallCurves(createLine, wallHeight);
                //Wall.Create(doc, curves, wallType.Id, levelId, false);

                t.Commit();
            }
        }

        private Line GetCreateLine(Line closestTopLine, Line closestBotLine)
        {
            Line result;

            XYZ botP = closestBotLine.GetEndPoint(0).Add(closestBotLine.GetEndPoint(1)) / 2;
            Line cloneClosestTopLine = closestTopLine.Clone() as Line;
            cloneClosestTopLine.MakeUnbound();
            XYZ topP = cloneClosestTopLine.Project(botP).XYZPoint;

            botP = new XYZ(botP.X, botP.Y, 0);
            topP = new XYZ(topP.X, topP.Y, 0);

            double moveDis = botP.DistanceTo(topP) / 2;
            XYZ moveDir = (topP - botP).Normalize();

            XYZ createP0 = closestBotLine.GetEndPoint(0) + moveDir * moveDis;
            XYZ createP1 = closestBotLine.GetEndPoint(1) + moveDir * moveDis;

            result = Line.CreateBound(createP0, createP1);
            //if (result.Length > closestTopLine.Length)
            //{
            //    Line cloneLine = result.Clone() as Line;
            //    cloneLine.MakeUnbound();

            //    XYZ newP0 = cloneLine.Project(closestTopLine.GetEndPoint(0)).XYZPoint;
            //    XYZ newP1 = cloneLine.Project(closestTopLine.GetEndPoint(1)).XYZPoint;

            //    Line oldLine = result;
            //    result = Line.CreateBound(newP0, newP1);
            //    if (oldLine.Intersect(result, out var re) == SetComparisonResult.Equal)
            //    {
            //        result = Line.CreateBound(re.get_Item(0).XYZPoint, re.get_Item(1).XYZPoint);
            //    }
            //}
            Line cloneLine = result.Clone() as Line;
            cloneLine.MakeUnbound();

            XYZ newP0 = cloneLine.Project(closestTopLine.GetEndPoint(0)).XYZPoint;
            XYZ newP1 = cloneLine.Project(closestTopLine.GetEndPoint(1)).XYZPoint;

            Line oldLine = result.Clone() as Line;
            result = Line.CreateBound(newP0, newP1);
            if (oldLine.Intersect(result) == SetComparisonResult.Equal)
            {
                XYZ equalP0;
                XYZ equalP1;
                if (IsPointOnLine(oldLine.GetEndPoint(0), result)) equalP0 = oldLine.GetEndPoint(0);
                else equalP0 = oldLine.GetEndPoint(1);
                if (IsPointOnLine(result.GetEndPoint(0), oldLine)) equalP1 = result.GetEndPoint(0);
                else equalP1 = result.GetEndPoint(1);
                result = Line.CreateBound(equalP0, equalP1);
            }
            return result;
        }
        public bool IsPointOnLine(XYZ point, Line line)
        {
            XYZ p0 = line.GetEndPoint(0);
            XYZ p1 = line.GetEndPoint(1);
            //判断是否平行的误差为5度
            if (line.Direction.IsAlmostEqualTo((point - p0).Normalize(), 0.088) && p0.DistanceTo(point) < p0.DistanceTo(p1) && point.DistanceTo(p0) > 20 / 304.8 && point.DistanceTo(p1) > 20 / 304.8)
            {
                return true;
            }
            return false;
        }
        private List<Curve> GetCreateWallCurves(Line line, double wallHeight)
        {
            List<Curve> results = new List<Curve>();

            XYZ p0 = line.GetEndPoint(0);
            XYZ p1 = line.GetEndPoint(1);

            Line line1 = Line.CreateBound(p0, p1); results.Add(line1);
            Line line2 = Line.CreateBound(p1, p1 + XYZ.BasisZ * wallHeight); results.Add(line2);
            Line line3 = Line.CreateBound(p1 + XYZ.BasisZ * wallHeight, p0 + XYZ.BasisZ * wallHeight); results.Add(line3);
            Line line4 = Line.CreateBound(p0 + XYZ.BasisZ * wallHeight, p0); results.Add(line4);

            return results;
        }

        private double GetWallHeight(Line lineA, Line lineB)
        {
            XYZ cPA = lineA.GetEndPoint(0).Add(lineA.GetEndPoint(1)) / 2;
            XYZ cPB = lineB.Project(cPA).XYZPoint;

            return Math.Abs(cPA.Z - cPB.Z);
        }

        private double DistanceBetweenTwoLines(Line lineA, Line lineB)
        {
            double result = double.MaxValue;
            XYZ pA0 = lineA.GetEndPoint(0);
            pA0 = new XYZ(pA0.X, pA0.Y, 0);
            XYZ pA1 = lineA.GetEndPoint(1);
            pA1 = new XYZ(pA1.X, pA1.Y, 0);
            XYZ pB0 = lineB.GetEndPoint(0);
            pB0 = new XYZ(pB0.X, pB0.Y, 0);
            XYZ pB1 = lineB.GetEndPoint(1);
            pB1 = new XYZ(pB1.X, pB1.Y, 0);

            // 判断两线段是否存在重合部分
            Line newLineA = Line.CreateBound(pA0, pA1);
            Line newUnLineA = newLineA.Clone() as Line;
            newUnLineA.MakeUnbound();
            Line newLineB = Line.CreateBound(newUnLineA.Project(pB0).XYZPoint, newUnLineA.Project(pB1).XYZPoint);
            if (newLineA.Intersect(newLineB) != SetComparisonResult.Equal) return result;

            XYZ verDir = (pA0 - pA1).Normalize().CrossProduct(XYZ.BasisZ).Normalize();
            XYZ centerPA = pA0.Add(pA1) / 2;

            Line newVerLine = Line.CreateUnbound(centerPA, verDir);
            Line newHorLine = Line.CreateBound(pB0, pB1);
            newHorLine.MakeUnbound();
            if (newVerLine.Intersect(newHorLine, out var ra) == SetComparisonResult.Overlap)
            {
                XYZ intersectPB = ra.get_Item(0).XYZPoint;
                result = intersectPB.DistanceTo(centerPA);
            }

            return result;
        }

        // 方法：判断两条直线是否平行
        private static bool AreLinesParallel(Line lineA, Line lineB, double tolerance)
        {
            XYZ dirA = (lineA.GetEndPoint(1) - lineA.GetEndPoint(0)).Normalize();
            XYZ dirB = (lineB.GetEndPoint(1) - lineB.GetEndPoint(0)).Normalize();

            XYZ centerP1 = lineA.GetEndPoint(0).Add(lineA.GetEndPoint(1)) / 2;
            centerP1 = new XYZ(centerP1.X, centerP1.Y, 0);
            XYZ centerP2 = lineB.GetEndPoint(0).Add(lineB.GetEndPoint(1)) / 2;
            centerP2 = new XYZ(centerP2.X, centerP2.Y, 0);

            XYZ newDir = (centerP1 - centerP2).Normalize();
            XYZ compareDir = dirA.CrossProduct(XYZ.BasisZ).Normalize();

            // 判断向量平行（包括反向）
            return (dirA.IsAlmostEqualTo(dirB, tolerance) || dirA.IsAlmostEqualTo(-dirB, tolerance))
                /*&& (newDir.IsAlmostEqualTo(compareDir, tolerance) || newDir.IsAlmostEqualTo(-compareDir, tolerance))*/;
        }
    }
    public class FloorAndBeamFilter : ISelectionFilter
    {
        public ElementId Id = ElementId.InvalidElementId;
        public FloorAndBeamFilter(ElementId id)
        {
            Id = id;
        }
        public FloorAndBeamFilter() { }
        public bool AllowElement(Element elem)
        {
            if (elem.Id != Id && (elem is Floor || (elem is FamilyInstance instance && instance.StructuralType == Autodesk.Revit.DB.Structure.StructuralType.Beam)))
            {
                return true;
            }
            return false;
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            //return true;
            return false;
        }
    }
    public class FloorFilter : ISelectionFilter
    {
        public bool AllowElement(Element elem)
        {
            if (elem is Floor)
            {
                return true;
            }
            return false;
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            return false;
        }
    }
}
