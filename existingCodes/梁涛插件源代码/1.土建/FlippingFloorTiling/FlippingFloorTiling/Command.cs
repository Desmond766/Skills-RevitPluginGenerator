using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.Exceptions;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using RevitTemplate1.Https;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using OperationCanceledException = Autodesk.Revit.Exceptions.OperationCanceledException;

namespace FlippingFloorTiling
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;
            IntPtr intPtr = commandData.Application.MainWindowHandle;
            HttpHelper.SendLog(doc.Title, "地面铺砖翻模", 131, 1);

            FamilySymbol familySymbol = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_GenericModel).OfClass(typeof(FamilySymbol)).Cast<FamilySymbol>().FirstOrDefault(f => f.Name.Contains("美缝-5mm") && f.FamilyName.Contains("美缝"));
            if (familySymbol == null)
            {
                TaskDialog.Show("提示", "未找到美缝族");
                return Result.Cancelled;
            }

            Reference cadRefer;
            Reference floorOrWallRefer;
            Next:
            try
            {
                cadRefer = sel.PickObject(ObjectType.PointOnElement, new LinkCADFilter(doc), "选择链接CAD中的一条美缝(按ESC键结束操作)");
                floorOrWallRefer = sel.PickObject(ObjectType.Face, new FloorFilter(), "选择要创建美缝的楼板\\墙的面(按ESC键结束操作)");
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show("已结束操作");
                return Result.Succeeded;
            }
            ImportInstance importInstance = doc.GetElement(cadRefer) as ImportInstance;
            if (importInstance.IsLinked == false)
            {
                TaskDialog.Show("提示", "请在链接CAD中选择");
                return Result.Cancelled;
            }

            // 获取美缝线在CAD中的所在图层名称
            GeometryObject geoSel = importInstance.GetGeometryObjectFromReference(cadRefer);
            string layerName = GetSelectEntityLayerName(doc, geoSel);

            // 获取指定图层中所有线段(包含块参照中的线段)
            List<Line> lines = GetLinesInCADByLayerName(doc, importInstance, layerName);
            if (lines.Count == 0)
            {
                TaskDialog.Show("提示", "未找到该图层中的线段");
                goto Next;
            }

            Element floorOrWall = doc.GetElement(floorOrWallRefer);
            //PlanarFace floorFace = floor.GetGeometryObjectFromReference(HostObjectUtils.GetTopFaces(floor).First()) as PlanarFace;
            PlanarFace floorOrWallFace = floorOrWall.GetGeometryObjectFromReference(floorOrWallRefer) as PlanarFace;
            // 将面转换为带完整引用的面
            GetSameFaceWithComputeReference(doc, floorOrWall, ref floorOrWallFace);

            List<Line> createLines = new List<Line>();

            /*
            List<ModelCurve> createModels = new List<ModelCurve>();
            using (Transaction t = new Transaction(doc, "创建临时模型线"))
            {
                t.Start();

                foreach (var modelLine in lines)
                {
                    if (modelLine.Length < 0.01) continue;
                    Plane plane = Plane.CreateByNormalAndOrigin(doc.ActiveView.ViewDirection.CrossProduct(modelLine.Direction).Normalize(), modelLine.GetEndPoint(0));
                    SketchPlane sketchPlane = SketchPlane.Create(doc, plane);
                    ModelCurve modelCurve = doc.Create.NewModelCurve(modelLine, sketchPlane);
                    createModels.Add(modelCurve);
                }

                t.Commit();
            }
            List<ElementId> modelLineIds = createModels.Select(l => l.Id).ToList();
            */

            /*
            foreach (var line in lines)
            {
                //if (!DoesLineIntersectFace2D(line, floorFace)) continue;
                //var elem = doc.Create.NewFamilyInstance(floorFace, line.Origin, line.Direction.CrossProduct(XYZ.BasisZ).Normalize(), familySymbol);
                //elem.LookupParameter("高度").Set(line.Length);
                //ids.Add(elem.Id);

                var floorBox = floorOrWall.get_BoundingBox(null);

                XYZ centerP = line.GetEndPoint(0).Add(line.GetEndPoint(1)) / 2;
                centerP = new XYZ(centerP.X, centerP.Y, (floorBox.Min.Add(floorBox.Max) / 2).Z);

                using (var pointCol = new FilteredElementCollector(doc, new List<ElementId>() { floorOrWall.Id }).WherePasses(new BoundingBoxContainsPointFilter(centerP)))
                {
                    if (pointCol.Count() > 0) createLines.Add(line);
                }
            }
            */

            // 美缝族实例ID集合
            List<ElementId> instanceIds = new List<ElementId>();
            TransactionGroup tg = new TransactionGroup(doc, "创建美缝");
            tg.Start();
            using (Transaction t = new Transaction(doc, "创建美缝"))
            {
                t.Start();
                if (!familySymbol.IsActive)
                {
                    familySymbol.Activate();
                }
                foreach (var line in lines)
                {
                    var elem = doc.Create.NewFamilyInstance(floorOrWallFace, line.Origin, line.Direction.CrossProduct(floorOrWallFace.FaceNormal).Normalize(), familySymbol);
                    elem.LookupParameter("高度").Set(line.Length);
                    instanceIds.Add(elem.Id);
                }
                t.Commit();
            }
            List<ElementId> delIds = new List<ElementId>();
            foreach (var id in instanceIds)
            {
                FamilyInstance familyInstance = (FamilyInstance)doc.GetElement(id);
                if (familyInstance.Host == null || familyInstance.Host.Id != floorOrWall.Id) delIds.Add(id);
            }

            using (Transaction t = new Transaction(doc, "删除未附着面的美缝实例"))
            {
                t.Start();
                doc.Delete(delIds);
                t.Commit();
            }
            tg.Assimilate();

            goto Next;


        }
        private ElementIntersectsSolidFilter CreateSolidFilterByFace(PlanarFace planarFace)
        {
            // 创建平移变换
            XYZ translationVector = planarFace.FaceNormal.Negate().Multiply(2000);
            Transform translation = Transform.CreateTranslation(translationVector);
            //放样
            IList<CurveLoop> loops = new List<CurveLoop>();

            foreach (var curveLoop in planarFace.GetEdgesAsCurveLoops())
            {
                CurveLoop curves = new CurveLoop();
                foreach (var curve in curveLoop)
                {
                    Curve offsetCurve = curve.CreateTransformed(translation);
                    curves.Append(offsetCurve);
                }
                loops.Add(curves);
            }


            //拉伸
            Solid solid1 = GeometryCreationUtilities.CreateExtrusionGeometry(loops, planarFace.FaceNormal, 4000);
            ElementIntersectsSolidFilter filter = new ElementIntersectsSolidFilter(solid1);


            return filter;
        }
        private List<Line> GetLinesFromPolyline(PolyLine polyline, Transform transform = null)
        {
            List<Line> lines = new List<Line>();

            // 获取PolyLine的所有顶点
            IList<XYZ> vertices = polyline.GetCoordinates();

            if (vertices.Count < 2)
                return lines;

            // 连接相邻顶点创建直线
            for (int i = 0; i < vertices.Count - 1; i++)
            {
                if (vertices[i].DistanceTo(vertices[i + 1]) < 0.01) continue;
                Line line = Line.CreateBound(vertices[i], vertices[i + 1]);
                if (transform != null) line = line.CreateTransformed(transform) as Line;
                lines.Add(line);
            }
            return lines;
        }
        private void GetSameFaceWithComputeReference(Document doc, Element floor, ref PlanarFace floorFace)
        {
            XYZ topFaceDir = floorFace.FaceNormal;
            double topFaceArea = floorFace.Area;

            Options options = new Options();
            options.ComputeReferences = true;
            options.View = doc.ActiveView;

            GeometryElement gee = floor.get_Geometry(options);
            foreach (var geo in gee)
            {
                if (geo is Solid solid && solid.Volume > 0 && solid.SurfaceArea > 0)
                {
                    if (solid.Faces.Cast<Face>().Where(f => f is PlanarFace).Cast<PlanarFace>().Count(f => f != null && topFaceDir.IsAlmostEqualTo(f.FaceNormal) && Math.Abs(topFaceArea - f.Area) < 0.001) > 0)
                    {
                        floorFace = solid.Faces.Cast<PlanarFace>().First(f => f != null && topFaceDir.IsAlmostEqualTo(f.FaceNormal) && Math.Abs(topFaceArea - f.Area) < 0.001);
                        break;
                    }
                }
                else if (geo is GeometryInstance gei)
                {
                    foreach (var geo2 in gei.GetInstanceGeometry())
                    {
                        if (geo2 is Solid solid2 && solid2.Volume > 0 && solid2.SurfaceArea > 0)
                        {
                            if (solid2.Faces.Cast<PlanarFace>().Count(f => f != null && f.FaceNormal.IsAlmostEqualTo(XYZ.BasisZ)) > 0)
                            {
                                floorFace = solid2.Faces.Cast<PlanarFace>().First(f => f != null && f.FaceNormal.IsAlmostEqualTo(XYZ.BasisZ));
                                break;
                            }
                        }
                    }
                }
            }
        }
        // 判断直线在XY平面上是否与面（Face）相交
        public bool DoesLineIntersectFace2D(Line line, Face face, double tolerance = 1e-6)
        {
            XYZ start0 = line.GetEndPoint(0);
            XYZ start1 = line.GetEndPoint(1);
            XYZ dir = line.Direction;
            start0 = start0 - dir * (100.0 / 304.8);
            start1 = start1 + dir * (100.0 / 304.8);
            line = Line.CreateBound(start0, start1);
            // 获取直线在XY平面上的2D线段
            XYZ start2D = new XYZ(line.GetEndPoint(0).X, line.GetEndPoint(0).Y, 0);
            XYZ end2D = new XYZ(line.GetEndPoint(1).X, line.GetEndPoint(1).Y, 0);
            if (start2D.DistanceTo(end2D) < 0.01) return false;
            Line line2D = Line.CreateBound(start2D, end2D);

            // 获取面的边界（投影到XY平面）
            CurveLoop curveLoop = face.GetEdgesAsCurveLoops().First();
            List<Line> boundaryLines = new List<Line>();

            foreach (Curve curve in curveLoop)
            {
                if (curve is Line originalLine)
                {
                    // 将每条边界线投影到XY平面
                    XYZ p1 = new XYZ(originalLine.GetEndPoint(0).X, originalLine.GetEndPoint(0).Y, 0);
                    XYZ p2 = new XYZ(originalLine.GetEndPoint(1).X, originalLine.GetEndPoint(1).Y, 0);
                    if (p1.DistanceTo(p2) < 0.01) continue;
                    boundaryLines.Add(Line.CreateBound(p1, p2));
                }
            }

            // 判断直线是否与任一2D边界线相交
            foreach (Line boundary in boundaryLines)
            {
                if (DoesLinesIntersect2D(line2D, boundary, tolerance))
                {
                    return true;
                }
            }

            return false;
        }

        // 判断2D平面上两条线段是否相交
        public bool DoesLinesIntersect2D(Line line1, Line line2, double tolerance)
        {
            // 计算线段参数方程的交点
            XYZ p1 = line1.GetEndPoint(0);
            XYZ p2 = line1.GetEndPoint(1);
            XYZ p3 = line2.GetEndPoint(0);
            XYZ p4 = line2.GetEndPoint(1);

            // 计算叉积
            double denominator = (p4.Y - p3.Y) * (p2.X - p1.X) - (p4.X - p3.X) * (p2.Y - p1.Y);

            if (Math.Abs(denominator) < tolerance)
            {
                return false; // 平行或共线
            }

            double ua = ((p4.X - p3.X) * (p1.Y - p3.Y) - (p4.Y - p3.Y) * (p1.X - p3.X)) / denominator;
            double ub = ((p2.X - p1.X) * (p1.Y - p3.Y) - (p2.Y - p1.Y) * (p1.X - p3.X)) / denominator;

            // 检查交点是否在两线段上
            return (ua >= 0 - tolerance && ua <= 1 + tolerance)
                && (ub >= 0 - tolerance && ub <= 1 + tolerance);
        }
        private string GetSelectEntityLayerName(Document doc, GeometryObject geoSel)
        {
            string result = null;
            ElementId gsId = geoSel.GraphicsStyleId;
            GraphicsStyle graphicsStyle = doc.GetElement(gsId) as GraphicsStyle;
            result = graphicsStyle.GraphicsStyleCategory.Name;

            return result;
        }
        private List<Line> GetLinesInCADByLayerName(Document doc, ImportInstance importInstance, string layerName)
        {
            List<Line> lines = new List<Line>();

            GeometryElement geometryElement = importInstance.get_Geometry(new Options());
            foreach (var geo in geometryElement)
            {
                if (geo is GeometryInstance gei)
                {
                    Transform importTransform = gei.Transform;
                    foreach (var lineGeo in gei.GetSymbolGeometry())
                    {
                        if (lineGeo is Line line && GetSelectEntityLayerName(doc, line) == layerName)
                        {
                            lines.Add(line.CreateTransformed(importTransform) as Line);
                        }
                        else if (lineGeo is PolyLine pyLine && GetSelectEntityLayerName(doc, pyLine) == layerName)
                        {
                            var linesInPolyLine = GetLinesFromPolyline(pyLine, importTransform);
                            lines.AddRange(linesInPolyLine);
                        }
                        else if (lineGeo is GeometryInstance gei2)
                        {
                            Transform gei2Transform = gei2.Transform;
                            foreach (var lineGeo2 in gei2.GetSymbolGeometry())
                            {
                                if (lineGeo2 is Line line2 && GetSelectEntityLayerName(doc, line2) == layerName)
                                {
                                    lines.Add(line2.CreateTransformed(importTransform.Multiply(gei2Transform)) as Line);
                                }
                                else if (lineGeo2 is PolyLine pyLine2 && GetSelectEntityLayerName(doc, pyLine2) == layerName)
                                {
                                    var linesInPolyLine = GetLinesFromPolyline(pyLine2, importTransform.Multiply(gei2Transform));
                                    lines.AddRange(linesInPolyLine);
                                }
                            }
                        }
                    }
                }
            }


            return lines;
        }
    }
    public class FloorFilter : ISelectionFilter
    {
        public Document Doc { get; set; }
        public bool AllowElement(Element elem)
        {
            Doc = elem.Document;
            return true;
            if (elem is Floor floor)
            {
                var topRefer = HostObjectUtils.GetTopFaces(floor).FirstOrDefault();
                if (topRefer != null && (floor.GetGeometryObjectFromReference(topRefer) as Face) is PlanarFace)
                {
                    return true;
                }
            }
            return false;
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            Element element = Doc.GetElement(reference);
            if (element is Floor floor)
            {
                var geo = floor.GetGeometryObjectFromReference(reference);
                if (geo != null && geo is PlanarFace)
                {
                    return true;
                }
            }
            else if (element is Wall wall)
            {
                var geo = wall.GetGeometryObjectFromReference(reference);
                if (geo != null && geo is PlanarFace)
                {
                    return true;
                }
            }
            return false;
        }
    }

    public class LinkCADFilter : ISelectionFilter
    {
        public Document Doc { get; set; }
        public LinkCADFilter(Document doc)
        {
            Doc = doc;
        }
        public bool AllowElement(Element elem)
        {
            return true;
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            Element element = Doc.GetElement(reference);
            if (element is ImportInstance importInstance /*&& importInstance.IsLinked*/)
            {
                return true;
            }
            return false;
        }
    }
}
