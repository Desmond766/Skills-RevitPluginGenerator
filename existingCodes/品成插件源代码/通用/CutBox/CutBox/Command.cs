using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.DB.Structure;


namespace CutBox
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        UIApplication uiapp;
        Document doc;
        Selection sel;
        XYZ max;
        XYZ min;
        Solid sectionBox;
        SolidCurveIntersectionOptions intersectOptions = new SolidCurveIntersectionOptions();
        SolidCurveIntersection intersection;

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //注册验证
            string licFile = string.Format("{0}\\Key.lic",
    System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
            if (!BTAddInHelper.Utils.CheckReg(licFile))
            {
                return Result.Cancelled;
            }

            uiapp = commandData.Application;
            doc = uiapp.ActiveUIDocument.Document;
            sel = uiapp.ActiveUIDocument.Selection;

            View3D view3D = doc.ActiveView as View3D;
            if (null == view3D)
            {
                TaskDialog.Show("Revit", "必须在三维视图下运行插件！");
                return Result.Failed;
            }
            if (view3D.IsSectionBoxActive)// 模式一：剖面框切割
            {
                BoundingBoxXYZ box = view3D.GetSectionBox();
                max = box.Transform.OfPoint(box.Max);
                min = box.Transform.OfPoint(box.Min);
                // 剖面框范围
                sectionBox = CreatBox(max, min);
            }
            else // 模式二：体量切割
            {
                Reference r = sel.PickObject(ObjectType.Element);
                Options opt = new Options();
                GeometryElement geo = doc.GetElement(r).get_Geometry(opt);
                foreach (GeometryObject obj in geo)
                {
                    Solid solid = obj as Solid;
                    if (solid != null)
                    {
                        sectionBox = solid;
                        break;
                    }
                }
                max = sectionBox.GetBoundingBox().Max;
                min = sectionBox.GetBoundingBox().Min;
            }

            // 过滤没有碰撞的物体
            FilteredElementCollector colOfUnIntersect = new FilteredElementCollector(doc).WherePasses(new ElementIntersectsSolidFilter(sectionBox, true));
            ICollection<ElementId> elemToDelete = colOfUnIntersect.ToElementIds();
            // 过滤碰撞的物体
            FilteredElementCollector colOfIntersect = new FilteredElementCollector(doc, view3D.Id);
            Location location;

            using (Transaction t = new Transaction(doc, "CutBox"))
            {
                t.Start();
                try
                {
                    foreach (Element elem in colOfIntersect)
                    {
                        location = elem.Location;
                        if (null == location)
                            continue;
                        // 板
                        if (elem is Floor && view3D.IsSectionBoxActive)
                        {
                            SlabCut(elem);
                        }
                        // 柱
                        else if (elem.Category.Id.IntegerValue == (int)BuiltInCategory.OST_Columns
                            || elem.Category.Id.IntegerValue == (int)BuiltInCategory.OST_StructuralColumns)
                        {
                            ColumnCut(elem);
                        }
                        // 门、窗
                        else if (elem.Category.Id.IntegerValue == (int)BuiltInCategory.OST_Doors
                            || elem.Category.Id.IntegerValue == (int)BuiltInCategory.OST_Windows)
                        {
                            if (!IsInside((elem.Location as LocationPoint).Point))
                            {
                                elemToDelete.Add(elem.Id);
                            }
                        }
                        // 线型构件，墙特殊处理
                        else if (location is LocationCurve)
                        {
                            if (elem.Category.Id.IntegerValue == (int)BuiltInCategory.OST_Walls)
                            {
                                WallCut(elem);
                            }
                            else
                            {
                                CurveElementCut(elem);
                            }
                        }
                    }
                    doc.Delete(elemToDelete);
                }
                catch (Exception ex)
                {
                    // CODE HERE
                }
                t.Commit();
            }

            return Result.Succeeded;
        }

        #region 绘制立方体
        /// <summary>
        /// 绘制立方体
        /// </summary>
        /// <param name="max"></param>
        /// <param name="min"></param>
        private void DrawBox(XYZ max, XYZ min)
        {
            XYZ dirX = new XYZ(max.X - min.X, 0, 0);
            XYZ dirY = new XYZ(0, max.Y - min.Y, 0);
            XYZ dirZ = new XYZ(0, 0, max.Z - min.Z);
            // 绘制立方体的十二条边线
            Utils.DrawModelCurve(doc, min, min + dirX);
            Utils.DrawModelCurve(doc, min, min + dirY);
            Utils.DrawModelCurve(doc, min, min + dirZ);
            Utils.DrawModelCurve(doc, max, max - dirX);
            Utils.DrawModelCurve(doc, max, max - dirY);
            Utils.DrawModelCurve(doc, max, max - dirZ);
            Utils.DrawModelCurve(doc, min + dirX, max - dirY);
            Utils.DrawModelCurve(doc, min + dirY, max - dirX);
            Utils.DrawModelCurve(doc, min + dirZ, max - dirY);
            Utils.DrawModelCurve(doc, min + dirZ, max - dirX);
            Utils.DrawModelCurve(doc, max - dirZ, min + dirX);
            Utils.DrawModelCurve(doc, max - dirZ, min + dirY);
        }
        #endregion

        #region 创建实体
        /// <summary>
        /// 创建实体
        /// </summary>
        /// <param name="max"></param>
        /// <param name="min"></param>
        /// <returns></returns>
        private Solid CreatBox(XYZ max, XYZ min)
        {
            XYZ dirX = new XYZ(max.X - min.X, 0, 0);
            XYZ dirY = new XYZ(0, max.Y - min.Y, 0);
            XYZ dirZ = new XYZ(0, 0, max.Z - min.Z);

            // 创建四条线
            Line l1 = Line.CreateBound(min, min + dirX);
            Line l2 = Line.CreateBound(min + dirX, max - dirZ);
            Line l3 = Line.CreateBound(max - dirZ, min + dirY);
            Line l4 = Line.CreateBound(min + dirY, min);
            // 封闭曲线
            CurveLoop profile = new CurveLoop();
            profile.Append(l1);
            profile.Append(l2);
            profile.Append(l3);
            profile.Append(l4);

            List<CurveLoop> loops = new List<CurveLoop>();
            loops.Add(profile);
            // 创建实体的方法(底面，拉伸方向，拉伸高度)
            return GeometryCreationUtilities.CreateExtrusionGeometry(loops, dirZ, dirZ.GetLength());
        }
        #endregion

        #region 柱切割
        /// <summary>
        /// 柱切割
        /// </summary>
        /// <param name="elem"></param>
        private void ColumnCut(Element elem)
        {
            // 可能出现柱与sectionBox有交点，但柱中心线与sectionBox没有交点的情况
            // 所以，此处将point由柱的LocationPoint改为裁剪框的中心点
            // 是为了保证柱中心线与sectionBox有交点
            // XYZ point = (elem.Location as LocationPoint).Point;
            XYZ point = (max + min) / 2.0;
            double baseLevel = (doc.GetElement(elem.get_Parameter(BuiltInParameter.FAMILY_BASE_LEVEL_PARAM).AsElementId()) as Level).Elevation;
            double baseLevelOffset = elem.get_Parameter(BuiltInParameter.FAMILY_BASE_LEVEL_OFFSET_PARAM).AsDouble();
            double topLevel = (doc.GetElement(elem.get_Parameter(BuiltInParameter.FAMILY_TOP_LEVEL_PARAM).AsElementId()) as Level).Elevation;
            double topLevelOffset = elem.get_Parameter(BuiltInParameter.FAMILY_TOP_LEVEL_OFFSET_PARAM).AsDouble();
            if (baseLevel + baseLevelOffset < min.Z || topLevel + topLevelOffset > max.Z)
            {
                Line columnLine = Line.CreateBound(new XYZ(point.X, point.Y, baseLevel + baseLevelOffset), new XYZ(point.X, point.Y, topLevel + topLevelOffset));
                intersection = sectionBox.IntersectWithCurve(columnLine, intersectOptions);
                Curve curveInside;
                for (int segment = 0; segment < intersection.SegmentCount; segment++)
                {
                    curveInside = intersection.GetCurveSegment(segment);
                    // 更新顶底偏移
                    if (curveInside.GetEndPoint(0).Z > curveInside.GetEndPoint(1).Z)
                    {
                        elem.get_Parameter(BuiltInParameter.FAMILY_TOP_LEVEL_OFFSET_PARAM).Set(curveInside.GetEndPoint(0).Z - topLevel);
                        elem.get_Parameter(BuiltInParameter.FAMILY_BASE_LEVEL_OFFSET_PARAM).Set(curveInside.GetEndPoint(1).Z - baseLevel);
                    }
                    else
                    {
                        elem.get_Parameter(BuiltInParameter.FAMILY_TOP_LEVEL_OFFSET_PARAM).Set(curveInside.GetEndPoint(1).Z - topLevel);
                        elem.get_Parameter(BuiltInParameter.FAMILY_BASE_LEVEL_OFFSET_PARAM).Set(curveInside.GetEndPoint(0).Z - baseLevel);
                    }
                }
            }
        }
        #endregion

        #region 线型构件切割
        /// <summary>
        /// 线型构件切割
        /// </summary>
        /// <param name="elem"></param>
        private void CurveElementCut(Element elem)
        {
            Curve curve = (elem.Location as LocationCurve).Curve;
            intersection = sectionBox.IntersectWithCurve(curve, intersectOptions);
            Curve curveInside;
            // 如果是梁，使用get_ElementsAtJoin()方法重新连接
            // 如果是MEPCurve，使用ConnectTo()方法重新连接
            for (int segment = 0; segment < intersection.SegmentCount; segment++)
            {
                curveInside = intersection.GetCurveSegment(segment);
                if (!IsSameCurve(curve, curveInside))
                {
                    (elem.Location as LocationCurve).Curve = curveInside;
                }
            }
        }
        #endregion

        #region 墙切割
        /// <summary>
        /// 墙切割
        /// </summary>
        /// <param name="elem"></param>
        private void WallCut(Element elem)
        {
            Curve curveInside;
            // 修改墙高
            XYZ point = (max + min) / 2.0;
            double baseConstraint = (doc.GetElement(elem.get_Parameter(BuiltInParameter.WALL_BASE_CONSTRAINT).AsElementId()) as Level).Elevation;
            double baseOffset = elem.get_Parameter(BuiltInParameter.WALL_BASE_OFFSET).AsDouble();
            double height = elem.get_Parameter(BuiltInParameter.WALL_USER_HEIGHT_PARAM).AsDouble();
            if (baseConstraint + baseOffset < min.Z || baseConstraint + baseOffset + height > max.Z)
            {
                Line wallHeightLine = Line.CreateBound(new XYZ(point.X, point.Y, baseConstraint + baseOffset), new XYZ(point.X, point.Y, baseConstraint + baseOffset + height));
                intersection = sectionBox.IntersectWithCurve(wallHeightLine, intersectOptions);

                for (int segment = 0; segment < intersection.SegmentCount; segment++)
                {
                    curveInside = intersection.GetCurveSegment(segment);
                    // 更新顶底偏移
                    if (curveInside.GetEndPoint(0).Z > curveInside.GetEndPoint(1).Z)
                    {
                        if (-1 != elem.get_Parameter(BuiltInParameter.WALL_HEIGHT_TYPE).AsElementId().IntegerValue)
                        {
                            double heightType = (doc.GetElement(elem.get_Parameter(BuiltInParameter.WALL_HEIGHT_TYPE).AsElementId()) as Level).Elevation;
                            elem.get_Parameter(BuiltInParameter.WALL_TOP_OFFSET).Set(curveInside.GetEndPoint(0).Z - heightType);
                        }
                        else
                        {
                            elem.get_Parameter(BuiltInParameter.WALL_USER_HEIGHT_PARAM).Set(curveInside.Length);
                        }
                        elem.get_Parameter(BuiltInParameter.WALL_BASE_OFFSET).Set(curveInside.GetEndPoint(1).Z - baseConstraint);
                    }
                    else
                    {
                        if (-1 != elem.get_Parameter(BuiltInParameter.WALL_HEIGHT_TYPE).AsElementId().IntegerValue)
                        {
                            double heightType = (doc.GetElement(elem.get_Parameter(BuiltInParameter.WALL_HEIGHT_TYPE).AsElementId()) as Level).Elevation;
                            elem.get_Parameter(BuiltInParameter.WALL_TOP_OFFSET).Set(curveInside.GetEndPoint(1).Z - heightType);
                        }
                        else
                        {
                            elem.get_Parameter(BuiltInParameter.WALL_USER_HEIGHT_PARAM).Set(curveInside.Length);
                        }
                        elem.get_Parameter(BuiltInParameter.WALL_BASE_OFFSET).Set(curveInside.GetEndPoint(0).Z - baseConstraint);
                    }
                }
            }
            // 切割前进方向墙体
            Curve curve = (elem.Location as LocationCurve).Curve;
            double z1 = curve.GetEndPoint(0).Z;
            double z2 = ((min + max) / 2.0).Z;
            Curve offsetCurve = curve.CreateTransformed(Transform.CreateTranslation(XYZ.BasisZ * (z2 - z1)));
            intersection = sectionBox.IntersectWithCurve(offsetCurve, intersectOptions);
            for (int segment = 0; segment < intersection.SegmentCount; segment++)
            {
                curveInside = intersection.GetCurveSegment(segment);
                if (!IsSameCurve(offsetCurve, curveInside))
                {
                    WallUtils.DisallowWallJoinAtEnd(elem as Wall, 0);
                    WallUtils.DisallowWallJoinAtEnd(elem as Wall, 1);
                    (elem.Location as LocationCurve).Curve = curveInside.CreateTransformed(Transform.CreateTranslation(XYZ.BasisZ * (z1 - z2)));
                    WallUtils.AllowWallJoinAtEnd(elem as Wall, 0);
                    WallUtils.AllowWallJoinAtEnd(elem as Wall, 1);
                }
            }
        }
        #endregion

        #region 板切割
        /// <summary>
        /// 板切割
        /// </summary>
        /// <param name="elem"></param>
        private void SlabCut(Element elem)
        {
            CurveArray curveArray = new CurveArray();
            List<XYZ> pointList = new List<XYZ>();
            Options opt = new Options();
            opt.View = doc.ActiveView;
            GeometryElement geo = elem.get_Geometry(opt);
            foreach (GeometryObject obj in geo)
            {
                Solid solid = obj as Solid;
                if (solid != null)
                {
                    PlanarFace top = null;
                    FaceArray faces = solid.Faces;
                    foreach (Face f in faces)
                    {
                        // 比较表面原点的 Z 坐标来确定最上方的表面  
                        PlanarFace pf = f as PlanarFace;
                        if (null != pf && Utils.IsHorizontal(pf))
                        {
                            if ((null == top) || (pf.Origin.Z > top.Origin.Z))
                            {
                                top = pf;
                            }
                        }
                    }
                    if (null != top)
                    {
                        EdgeArrayArray loops = top.EdgeLoops;
                        foreach (EdgeArray loop in loops)
                        {
                            foreach (Edge e in loop)
                            {
                                //curveArray.Append(e.AsCurve());
                                //IList<XYZ> points = e.Tessellate();
                                if (!AlmostContain(pointList, e.Tessellate()[0]))
                                {
                                    pointList.Add(e.Tessellate()[0]);
                                }
                                if (!AlmostContain(pointList, e.Tessellate()[1]))
                                {
                                    pointList.Add(e.Tessellate()[1]);
                                }
                            }
                        }
                    }
                }
            }
            for (int i = 0; i < pointList.Count - 1; i++)
            {
                curveArray.Append(Line.CreateBound(pointList[i], pointList[i + 1]));
            }
            curveArray.Append(Line.CreateBound(pointList[pointList.Count - 1], pointList[0]));
            FloorType ft = (elem as Floor).FloorType;
            Level le = doc.GetElement(elem.LevelId) as Level;
            bool structuralUse = true;
            if (0 == elem.get_Parameter(BuiltInParameter.FLOOR_PARAM_IS_STRUCTURAL).AsInteger())
            {
                structuralUse = false;
            }
            // 创建楼板
            doc.Create.NewFloor(curveArray, ft, le, structuralUse);
            // 删除原楼板
            doc.Delete(elem.Id);
        }
        #endregion

        #region 近似包含
        /// <summary>
        /// 近似包含
        /// </summary>
        /// <param name="data"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        private bool AlmostContain(List<XYZ> data, XYZ target)
        {
            foreach (XYZ p in data)
            {
                if (p.IsAlmostEqualTo(target))
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region 判断是否是同一条曲线
        /// <summary>
        /// 判断是否是同一条曲线
        /// </summary>
        /// <param name="curve1"></param>
        /// <param name="curve2"></param>
        /// <returns></returns>
        private bool IsSameCurve(Curve curve1, Curve curve2)
        {
            if (curve1.GetEndPoint(0).IsAlmostEqualTo(curve2.GetEndPoint(0))
                && curve1.GetEndPoint(1).IsAlmostEqualTo(curve2.GetEndPoint(1)))
            {
                return true;
            }
            else if (curve1.GetEndPoint(0).IsAlmostEqualTo(curve2.GetEndPoint(1))
                && curve1.GetEndPoint(1).IsAlmostEqualTo(curve2.GetEndPoint(0)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 判断点是否在裁剪框范围内
        /// <summary>
        /// 判断点是否在裁剪框范围内
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private bool IsInside(XYZ p)
        {
            Line line = Line.CreateBound(p, p + XYZ.BasisZ * 0.01);
            intersection = sectionBox.IntersectWithCurve(line, intersectOptions);
            Curve curveInside;
            for (int segment = 0; segment < intersection.SegmentCount; segment++)
            {
                curveInside = intersection.GetCurveSegment(segment);
                if (!IsSameCurve(line, curveInside))
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

    }
}
