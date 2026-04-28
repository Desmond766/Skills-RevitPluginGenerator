using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CutFloor
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;

            //TaskDialog.Show("revit", sel.PickPoint().ToString() + "\n" + Convert.ToInt32(0.51));
            //return Result.Succeeded;

            Reference reference = sel.PickObject(ObjectType.Element, new FloorPlanarFaceFilter(), "选择一块楼板");
            Floor floor = doc.GetElement(reference) as Floor;

            XYZ selP0 = sel.PickObject(ObjectType.PointOnElement, "选择两点以确定拆分方向（第一点）").GlobalPoint;
            XYZ selP1 = sel.PickObject(ObjectType.PointOnElement, "选择两点以确定拆分方向（第二点）").GlobalPoint;

            MainWindow window = new MainWindow();
            window.ShowDialog();
            if (window.DialogResult == false)
            {
                return Result.Cancelled;
            }

            var faceRef = HostObjectUtils.GetTopFaces(floor);
            Face face = floor.GetGeometryObjectFromReference(faceRef.First()) as Face;

            FloorParaInfo floorParaInfo;

            TransactionGroup TG2 = new TransactionGroup(doc, "拆分楼板");
            TG2.Start();
            using (Transaction t = new Transaction(doc, "删除旧楼板"))
            {
                List<Parameter> paras = new List<Parameter>();
                paras = floor.Parameters.Cast<Parameter>().ToList();

                floorParaInfo = new FloorParaInfo() {FloorType = floor.FloorType, LevelId = floor.LevelId
                    , IsStructural = floor.get_Parameter(BuiltInParameter.FLOOR_PARAM_IS_STRUCTURAL).AsInteger()
                    , HeightOffset = floor.get_Parameter(BuiltInParameter.FLOOR_HEIGHTABOVELEVEL_PARAM)?.AsDouble()
                    , Paras = paras
                };
                t.Start();
                doc.Delete(floor.Id);
                t.Commit();
            }
            selP0 = GetProjectPointToFace(selP0, face as PlanarFace);
            selP1 = GetProjectPointToFace(selP1, face as PlanarFace);

            Line intersectLine = Line.CreateBound(selP0, selP1);
            XYZ horDir = intersectLine.Direction;
            XYZ verDir = (face as PlanarFace).FaceNormal.CrossProduct(horDir);
            List<Line> testLines = face.EdgeLoops.Cast<EdgeArray>().First().Cast<Edge>().Select(e => e.AsCurve() as Line).ToList();
            //TaskDialog.Show("revit", verDir.ToString());
            //TaskDialog.Show("revit", selP0 + "\n" + verDir + "\n" + testLines[0].GetEndPoint(0));

            int num;
            double space;
            if (window.SplitBySpace)
            {
                space = window.Space;
                num = GetSplitNum(selP0, intersectLine, testLines, space, out var newStartP);
                selP0 = newStartP;
            }
            else
            {
                num = window.Num;
                space = GetSplitSpace(selP0, intersectLine, testLines, num, out var newStartP);
                selP0 = newStartP;
            }
            
            
            

            for (int i = 0; i < num; i++)
            {
                XYZ startP = selP0 + horDir * space;
                Line testLine = Line.CreateUnbound(startP, verDir);

                //TaskDialog.Show("result", JudgePointSide(line1, reference.GlobalPoint).ToString() + "\n" + lines.Count + "\n" + lines.First().GetEndPoint(0) + "\n" + reference.GlobalPoint);
                //return Result.Succeeded;
                testLines = GetCutLines(testLines, testLine, out XYZ testCenterP0, out XYZ testCenterP1);

                if (testCenterP0 == null || testCenterP1 == null)
                {
                    CreateSubFloor(doc, testLines, floorParaInfo);
                    break;
                }

                Line testCenterLine = Line.CreateBound(testCenterP0, testCenterP1);

                List<Line> testLeftLines = GetSubSideLines(testLines, 1, testCenterLine, Line.CreateBound(startP, startP + verDir));
                List<Line> testRightLines = GetSubSideLines(testLines, -1, testCenterLine, Line.CreateBound(startP, startP + verDir));

                //TaskDialog.Show("revit", (testCenterP0 == null) + "\n" + (testCenterP1 == null) + "\n" + testLines.Count + "\n" + testRightLines.Count);

                // 创建楼板
                CreateSubFloor(doc, testLeftLines, floorParaInfo);
                //if (i == 7 - 1) CreateSubFloor(doc, testRightLines);
                
                //break;
                testLines = testRightLines;
                selP0 = startP;
            }
            TG2.Assimilate();

            return Result.Succeeded;

            //List<Line> lines = face.EdgeLoops.Cast<EdgeArray>().First().Cast<Edge>().Select(e => e.AsCurve() as Line).ToList();

            ////TaskDialog.Show("result", JudgePointSide(line1, reference.GlobalPoint).ToString() + "\n" + lines.Count + "\n" + lines.First().GetEndPoint(0) + "\n" + reference.GlobalPoint);
            ////return Result.Succeeded;

            //lines = GetCutLines(lines, intersectLine, out XYZ centerP0, out XYZ centerP1);

            //Line centerLine = Line.CreateBound(centerP0, centerP1);

            //List<Line> leftLines = GetSubSideLines(lines, 1, centerLine, Line.CreateBound(startP, startP + verDir));
            //List<Line> rightLines = GetSubSideLines(lines, -1, centerLine, Line.CreateBound(startP, startP + verDir));

            //TransactionGroup TG = new TransactionGroup(doc, "拆分楼板");
            //TG.Start();
            //CreateSubFloor(doc, leftLines);
            //CreateSubFloor(doc, rightLines);
            //TG.Assimilate();

            //return Result.Succeeded;
        }

        private int GetSplitNum(XYZ startP, Line selLine, List<Line> faceLines, double space, out XYZ newStartP)
        {
            int num;
            List<XYZ> points = new List<XYZ>();
            foreach (var line in faceLines)
            {
                points.Add(line.GetEndPoint(0));
                points.Add(line.GetEndPoint(1));
            }
            Line cloneLine = selLine.Clone() as Line;
            cloneLine.MakeUnbound();
            XYZ lineDir = cloneLine.Direction;
            //points = points.OrderBy(p =>
            //{
            //    Line compareLine = Line.CreateBound(startP, p);
            //    XYZ compareDir = compareLine.Direction;
            //    return lineDir.DotProduct(compareDir);

            //}).ToList();

            List<XYZ> filterPoints1 = points.Where(p => {
                Line compareLine = Line.CreateBound(startP, p);
                XYZ compareDir = compareLine.Direction;
                return lineDir.DotProduct(compareDir) < 0;
            }).OrderByDescending(p => cloneLine.Project(p).XYZPoint.DistanceTo(startP)).ToList();
            XYZ min1 = filterPoints1.FirstOrDefault();
            XYZ max1 = filterPoints1.LastOrDefault();

            List<XYZ> filterPoints2 = points.Where(p => {
                Line compareLine = Line.CreateBound(startP, p);
                XYZ compareDir = compareLine.Direction;
                return lineDir.DotProduct(compareDir) == 0;
            }).ToList();
            XYZ min2 = filterPoints2.FirstOrDefault();
            XYZ max2 = filterPoints2.LastOrDefault();

            List<XYZ> filterPoints3 = points.Where(p => {
                Line compareLine = Line.CreateBound(startP, p);
                XYZ compareDir = compareLine.Direction;
                return lineDir.DotProduct(compareDir) > 0;
            }).OrderBy(p => cloneLine.Project(p).XYZPoint.DistanceTo(startP)).ToList();
            XYZ min3 = filterPoints3.FirstOrDefault();
            XYZ max3 = filterPoints3.LastOrDefault();

            XYZ min = min1 ?? min2 ?? min3;
            newStartP = min;
            XYZ max = max3 ?? max2 ?? max1;
            min = cloneLine.Project(min).XYZPoint;
            max = cloneLine.Project(max).XYZPoint;

            num = Convert.ToInt32(min.DistanceTo(max) / space);
            if (min.DistanceTo(max) / space - num <= 0.5 && min.DistanceTo(max) / space - num != 0) num++;
            //TaskDialog.Show("reit", (min.DistanceTo(max) / space) + "\n" + num + "\n" + (min.DistanceTo(max) / space - num));

            return num;
        }

        private double GetSplitSpace(XYZ startP, Line selLine, List<Line> faceLines, int num, out XYZ newStartP)
        {
            double space;
            List<XYZ> points = new List<XYZ>();
            foreach (var line in faceLines)
            {
                points.Add(line.GetEndPoint(0));
                points.Add(line.GetEndPoint(1));
            }
            Line cloneLine = selLine.Clone() as Line;
            cloneLine.MakeUnbound();
            XYZ lineDir = cloneLine.Direction;
            points = points.OrderBy(p =>
            {
                Line compareLine = Line.CreateBound(startP, p);
                XYZ compareDir = compareLine.Direction;
                return lineDir.DotProduct(compareDir);

            }).ToList();

            List<XYZ> filterPoints1 = points.Where(p => {
                Line compareLine = Line.CreateBound(startP, p);
                XYZ compareDir = compareLine.Direction;
                return lineDir.DotProduct(compareDir) < 0;
            }).OrderByDescending(p => cloneLine.Project(p).XYZPoint.DistanceTo(startP)).ToList();
            XYZ min1 = filterPoints1.FirstOrDefault();
            XYZ max1 = filterPoints1.LastOrDefault();

            List<XYZ> filterPoints2 = points.Where(p => {
                Line compareLine = Line.CreateBound(startP, p);
                XYZ compareDir = compareLine.Direction;
                return lineDir.DotProduct(compareDir) == 0;
            }).ToList();
            XYZ min2 = filterPoints2.FirstOrDefault();
            XYZ max2 = filterPoints2.LastOrDefault();

            List<XYZ> filterPoints3 = points.Where(p => {
                Line compareLine = Line.CreateBound(startP, p);
                XYZ compareDir = compareLine.Direction;
                return lineDir.DotProduct(compareDir) > 0;
            }).OrderBy(p => cloneLine.Project(p).XYZPoint.DistanceTo(startP)).ToList();
            XYZ min3 = filterPoints3.FirstOrDefault();
            XYZ max3 = filterPoints3.LastOrDefault();

            XYZ min = min1 ?? min2 ?? min3;
            newStartP = min;
            XYZ max = max3 ?? max2 ?? max1;

            //TaskDialog.Show("revit", min + "\n" + max);
            min = cloneLine.Project(min).XYZPoint;
            max = cloneLine.Project(max).XYZPoint;

            space = min.DistanceTo(max) / num;


            return space;
        }

        /// <summary>
        /// 获取楼板拆分后指定边的闭合轮廓线集合
        /// </summary>
        /// <param name="lines"></param>
        /// <param name="i">相对centerLine向量的方位，1:左侧;-1:右侧;-2:重合</param>
        /// <param name="centerLine"></param>
        /// <returns></returns>
        private List<Line> GetSubSideLines(List<Line> lines, int i, Line centerLine, Line dirLine)
        {
            List<Line> subLines = lines.Where(l => MaxPointSide(dirLine, l) == i).ToList();
            subLines.Add(centerLine);
            return subLines;
        }
        private List<Line> GetCutLines(List<Line> lines, Line intersectLine, out XYZ centerP0, out XYZ centerP1)
        {
            centerP0 = null;
            centerP1 = null;
            Line cloneLine = intersectLine.Clone() as Line;
            cloneLine.MakeUnbound();
            //TaskDialog.Show("revit", intersectLine.GetEndPoint(0) + "\n" + intersectLine.GetEndPoint(1));
            List<Line> filterLines = lines.Where(l => l.Intersect(cloneLine) == SetComparisonResult.Overlap).ToList();
            //TaskDialog.Show("revit", filterLines.Count.ToString());
            foreach (var line in filterLines)
            {
                XYZ p0 = line.GetEndPoint(0);
                XYZ p1 = line.GetEndPoint(1);
                line.Intersect(cloneLine, out var res);
                XYZ cP = res.get_Item(0).XYZPoint;

                if (filterLines[0] == line) centerP0 = cP;
                if (centerP0 != null && centerP0.DistanceTo(cP) > 0.0001) centerP1 = cP;

                if (p0.DistanceTo(cP) < 0.0001 || p1.DistanceTo(cP) < 0.0001) continue;
                Line newLine1 = Line.CreateBound(p0, cP);
                Line newLine2 = Line.CreateBound(cP, p1);
                lines.Remove(line);
                lines.Add(newLine1);
                lines.Add(newLine2);
            }

            return lines;
        }
        private double GetClosestDis(XYZ compareP, XYZ p1, XYZ p2, out XYZ minP, out XYZ otherP)
        {
            double min;
            if (compareP.DistanceTo(p1) < compareP.DistanceTo(p2))
            {
                min = compareP.DistanceTo(p1);
                minP = p1;
                otherP = p2;
            }
            else
            {
                min = compareP.DistanceTo(p2);
                minP = p2;
                otherP = p1;
            }

            return min;
        }

        private void CreateSubFloor(Document doc, List<Line> lines, FloorParaInfo floorParaInfo)
        {
            List<Line> copyLines = lines.Select(l => l).ToList();

            CurveArray curveArray = new CurveArray();

            Line startLine = lines.First();
            XYZ startP = startLine.GetEndPoint(1);
            curveArray.Append(startLine);
            copyLines.Remove(startLine);

            while (copyLines.Count > 0)
            {
                XYZ minP = null;
                XYZ otherP = null;
                Line next = copyLines.OrderBy(m => GetClosestDis(startP, m.GetEndPoint(0), m.GetEndPoint(1), out minP, out otherP))
                    .FirstOrDefault(m => GetClosestDis(startP, m.GetEndPoint(0), m.GetEndPoint(1), out minP, out otherP) < 1 / 304.8);

                if (next == null)
                {
                    //TaskDialog.Show("revit", curveArray.Size.ToString());
                    break;
                }

                curveArray.Append(Line.CreateBound(startP, otherP));
                startP = otherP;
                startLine = next;
                //startLine = next ?? copyLines.FirstOrDefault();
                if (!copyLines.Remove(next)) break;
                //if (!copyLines.Remove(next))
                //{
                //    if (!copyLines.Remove(copyLines.FirstOrDefault())) break;
                //}

            }

            if (copyLines.Count != 0)
            {
                TaskDialog.Show("BIMTRANS", "创建楼板失败");
                return;
            }

            using (Transaction t = new Transaction(doc, "拆分楼板"))
            {
                t.Start();

                try
                {
                    Floor newFloor = doc.Create.NewFloor(curveArray, floorParaInfo.FloorType, doc.GetElement(floorParaInfo.LevelId) as Level, false);
                    SynchronizationParameters(floorParaInfo, newFloor);
                    t.Commit();
                }
                catch (Exception e)
                {
                    if (t.HasStarted()) t.RollBack();
                    TaskDialog.Show("Error", "创建楼板失败：" + e.Message);
                }

            }
        }
        // 同步参数
        private void SynchronizationParameters(FloorParaInfo floorParaInfo, Floor newFloor)
        {
            // 结构参数
            newFloor.get_Parameter(BuiltInParameter.FLOOR_PARAM_IS_STRUCTURAL).Set(floorParaInfo.IsStructural);

            // 标高偏移（需单位转换）
            double? heightOffset = floorParaInfo.HeightOffset;
            if (heightOffset != null)
            {
                Parameter newHeightOffsetPara = newFloor.get_Parameter(BuiltInParameter.FLOOR_HEIGHTABOVELEVEL_PARAM);
                if (!newHeightOffsetPara.IsReadOnly) newHeightOffsetPara.Set((double)heightOffset);
            }

            // 同步其他共享参数（可选）
            SyncSharedParameters(floorParaInfo.Paras, newFloor);
        }
        // 同步共享参数（示例）
        private void SyncSharedParameters(List<Parameter> paras, Element target)
        {
            foreach (Parameter param in paras)
            {
                if (param.IsShared)
                {
                    Parameter targetParam = target.LookupParameter(param.Definition.Name);
                    if (targetParam != null && !targetParam.IsReadOnly)
                    {
                        switch (param.StorageType)
                        {
                            case StorageType.Double:
                                targetParam.Set(param.AsDouble());
                                break;
                            case StorageType.Integer:
                                targetParam.Set(param.AsInteger());
                                break;
                            case StorageType.String:
                                targetParam.Set(param.AsString());
                                break;
                            default: 
                                break;
                        }
                    }
                }
            }
        }

        private int MaxPointSide(Line intersectLine, Line line)
        {
            XYZ p0 = line.GetEndPoint(0);
            XYZ p1 = line.GetEndPoint(1);
            //TaskDialog.Show("revit", JudgePointSide(intersectLine, p0) + "\n" + JudgePointSide(intersectLine, p1));
            return Math.Max(JudgePointSide(intersectLine, p0), JudgePointSide(intersectLine, p1));
        }
        private int JudgePointSide(Line line, XYZ point)
        {
            // 获取线段的起点和终点
            XYZ a = line.GetEndPoint(0);
            XYZ b = line.GetEndPoint(1);

            // 计算向量AB和AP
            double abX = b.X - a.X;
            double abY = b.Y - a.Y;
            double apX = point.X - a.X;
            double apY = point.Y - a.Y;

            // 计算叉积
            double cross = abX * apY - abY * apX;

            // 判断叉积的符号
            if (cross > 0 + 0.0001)
                return 1;   // 点在线段左侧
            else if (cross < 0 - 0.0001)
                return -1;  // 点在线段右侧
            else
                return -2;   // 点在直线上
                return 0;   // 点在直线上
        }
        private XYZ GetProjectPointToFace(XYZ point, PlanarFace planarFace)
        {
            XYZ planeNormal = planarFace.FaceNormal;
            // 计算点到平面的向量
            XYZ pointToPlane = point - planarFace.Origin;

            // 计算点到平面的投影
            double dotProduct = pointToPlane.DotProduct(planeNormal);
            double normalDotProduct = planeNormal.DotProduct(planeNormal);

            // 投影点计算
            XYZ projectedPoint = point - (dotProduct / normalDotProduct) * planeNormal;

            return projectedPoint;
        }
    }
    public class FloorPlanarFaceFilter : ISelectionFilter
    {
        public bool AllowElement(Element elem)
        {
            if (elem is Floor)
            {
                return true;
            }return false;
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            return false;
        }
    }

    public class FloorParaInfo
    {
        // 楼板类型
        public FloorType FloorType { get; set; }
       // 标高ID
        public ElementId LevelId { get; set; }
        // 结构
        public int IsStructural { get; set; }
        // 标高偏移
        public double? HeightOffset { get; set; }
        // 旧楼板所有参数
        public List<Parameter> Paras { get; set; } = new List<Parameter>();
    }
}
