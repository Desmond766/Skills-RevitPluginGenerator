using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI.Selection;

namespace WallOffsetAndJoin
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        UIApplication uiapp;
        Document doc;
        Selection sel;

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            uiapp = commandData.Application;
            doc = uiapp.ActiveUIDocument.Document;
            sel = uiapp.ActiveUIDocument.Selection;

            //Reference reference;
            Element elem;
            FilteredElementCollector collector;
            List<Element> intersectList;
            Element elemIntersect;

            OverrideGraphicSettings setting = GetRemarkSetting(doc);

            double elevation;
            double elevationTemp;

            Level topLevel;
            double topOffset;

            Level bottomLevel;
            double bottomOffset;

            double wallHeight;
            

            ICollection<ElementId> ids = sel.GetElementIds();
            if (ids.Count == 0)
            {
                TaskDialog.Show("R", "请先选择墙，再运行插件！");
                return Result.Cancelled;
            }

            int num_done = 0;
            int num_skip = 0;

            #region 批量处理
            foreach (var item in ids)
            {
                // 选择墙
                elem = doc.GetElement(item);

                if (!(elem is Wall))
                {
                    continue;
                }

                if ((elem as Wall).StructuralUsage 
                    != Autodesk.Revit.DB.Structure.StructuralWallUsage.NonBearing)
                {
                    continue;
                }

                // 过滤出与之碰撞的构件
                collector = new FilteredElementCollector(doc, doc.ActiveView.Id);
                collector.WherePasses(new ElementIntersectsElementFilter(elem));

                // 找到与之碰撞的最高板的底标高
                intersectList = new List<Element>();
                elevation = -1000000.0;
                elevationTemp = -1000000.0;
                foreach (ElementId id in collector.ToElementIds())
                {
                    elemIntersect = doc.GetElement(id);
                    intersectList.Add(elemIntersect);
                    if (elemIntersect.Category.Id.IntegerValue == (int)BuiltInCategory.OST_Floors)
                    {
                        elevationTemp = GetFloorElevation(elemIntersect);
                        if (elevationTemp > elevation)
                        {
                            elevation = elevationTemp;
                        }
                    }
                }

                // 标高没有被重新赋值，即没有找到相交的板
                if (elevation == -1000000.0)
                {
                    foreach (Element e in intersectList)
                    {
                        if (e.Category.Id.IntegerValue == (int)BuiltInCategory.OST_StructuralFraming)
                        {
                            elevationTemp = GetBeamElevation(e);
                            if (elevationTemp > elevation)
                            {
                                elevation = elevationTemp;
                            }
                        }
                    }
                    // 如果标高还没有被重新赋值，即也没有找到相交的梁
                    if (elevation == -1000000.0)
                    {
                        //TaskDialog.Show("Revit", "没有找到与墙相交的板或梁");
                        num_skip += 1;
                        continue;
                    }
                }

                using (Transaction t = new Transaction(doc, "WallOffsetAndJoin"))
                {
                    t.Start();

                    //底部限制条件
                    bottomLevel = doc.GetElement(elem.get_Parameter(BuiltInParameter.WALL_BASE_CONSTRAINT).AsElementId()) as Level;
                    bottomOffset = elem.get_Parameter(BuiltInParameter.WALL_BASE_OFFSET).AsDouble();

                    //墙高
                    wallHeight = elevation - (bottomLevel.Elevation + bottomOffset);
                    if (wallHeight <= 0)
                    {
                        continue;
                    }

                    //顶部约束
                    topLevel = doc.GetElement(elem.get_Parameter(BuiltInParameter.WALL_HEIGHT_TYPE).AsElementId()) as Level;
                    if (null == topLevel)
                    {
                        //墙无连接高度
                        elem.get_Parameter(BuiltInParameter.WALL_USER_HEIGHT_PARAM).Set(wallHeight);
                    }
                    else
                    {
                        //墙顶部偏移
                        topOffset = elevation - topLevel.Elevation;
                        elem.get_Parameter(BuiltInParameter.WALL_TOP_OFFSET).Set(topOffset);
                    }

                    //连接墙
                    foreach (Element e in intersectList)
                    {
                        if (e.Category.Id.IntegerValue == (int)BuiltInCategory.OST_StructuralFraming)
                        {
                            try
                            {
                                JoinGeometryUtils.JoinGeometry(doc, elem, e);
                            }
                            catch (Exception)
                            {
                                continue;
                            }
                        }
                    }
                    num_done += 1;
                    doc.ActiveView.SetElementOverrides(item, setting);
                    t.Commit();
                }
            }
            #endregion

            #region 循环选择
            //while (true)
            //{
            //    try
            //    {
            //        // 选择墙
            //        reference = sel.PickObject(ObjectType.Element);
            //        elem = doc.GetElement(reference);

            //        // 过滤出与之碰撞的构件
            //        collector = new FilteredElementCollector(doc);
            //        collector.WherePasses(new ElementIntersectsElementFilter(elem));

            //        // 找到与之碰撞的最高板的底标高
            //        intersectList = new List<Element>();
            //        elevation = -1000000.0;
            //        elevationTemp = -1000000.0;
            //        foreach (ElementId id in collector.ToElementIds())
            //        {
            //            elemIntersect = doc.GetElement(id);
            //            intersectList.Add(elemIntersect);
            //            if (elemIntersect.Category.Id.IntegerValue == (int)BuiltInCategory.OST_Floors)
            //            {
            //                elevationTemp = GetFloorElevation(elemIntersect);
            //                if (elevationTemp > elevation)
            //                {
            //                    elevation = elevationTemp;
            //                }
            //            }
            //        }

            //        // 标高没有被重新赋值，即没有找到相交的板
            //        if (elevation == -1000000.0)
            //        {
            //            foreach (Element e in intersectList)
            //            {
            //                if (e.Category.Id.IntegerValue == (int)BuiltInCategory.OST_StructuralFraming)
            //                {
            //                    elevationTemp = GetBeamElevation(e);
            //                    if (elevationTemp > elevation)
            //                    {
            //                        elevation = elevationTemp;
            //                    }
            //                }
            //            }
            //            // 如果标高还没有被重新赋值，即也没有找到相交的梁
            //            if (elevation == -1000000.0)
            //            {
            //                TaskDialog.Show("Revit", "没有找到与墙相交的板或梁");
            //                continue;
            //            }
            //        }

            //        using (Transaction t = new Transaction(doc, "WallOffsetAndJoin"))
            //        {
            //            t.Start();
            //            // 偏移墙
            //            wallElevation = (doc.GetElement(elem.get_Parameter(BuiltInParameter.WALL_HEIGHT_TYPE).AsElementId()) as Level).Elevation;
            //            topOffset = elevation - wallElevation;
            //            elem.get_Parameter(BuiltInParameter.WALL_TOP_OFFSET).Set(topOffset);
            //            // 连接墙
            //            foreach (Element e in intersectList)
            //            {
            //                JoinGeometryUtils.JoinGeometry(doc, elem, e);
            //            }
            //            t.Commit();
            //        }
            //    }
            //    catch
            //    {
            //        TaskDialog.Show("Revit", "程序结束");
            //        break;
            //    }
            //}
            #endregion

            TaskDialog.Show("r", string.Format("成功处理{0}个，找不到相交的梁板跳过{1}个"
                , num_done, num_skip));

            return Result.Succeeded;
        }

        #region 获得楼板底标高
        /// <summary>
        ///  获得楼板底标高
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private double GetFloorElevation(Element e)
        {
            double level = (doc.GetElement(e.get_Parameter(BuiltInParameter.LEVEL_PARAM).AsElementId()) as Level).Elevation;
            double offset = e.get_Parameter(BuiltInParameter.FLOOR_HEIGHTABOVELEVEL_PARAM).AsDouble();
            double thickness = e.get_Parameter(BuiltInParameter.FLOOR_ATTR_THICKNESS_PARAM).AsDouble();
            return level + offset - thickness;
        }
        #endregion

        #region 获得梁顶标高
        /// <summary>
        /// 获得梁顶标高
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private double GetBeamElevation(Element e)
        {
            double level = (doc.GetElement(e.get_Parameter(BuiltInParameter.INSTANCE_REFERENCE_LEVEL_PARAM).AsElementId()) as Level).Elevation;
            double startOffset = e.get_Parameter(BuiltInParameter.STRUCTURAL_BEAM_END0_ELEVATION).AsDouble();
            double endOffset = e.get_Parameter(BuiltInParameter.STRUCTURAL_BEAM_END1_ELEVATION).AsDouble();
            double zOffset = e.get_Parameter(BuiltInParameter.Z_OFFSET_VALUE).AsDouble();
            return level + (startOffset + endOffset) / 2.0 + zOffset;
        }
        #endregion

        #region 获得标记参数设置
        /// <summary>
        /// 获得标记参数设置
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        private OverrideGraphicSettings GetRemarkSetting(Document doc)
        {
            // 得到一个实体填充图案
            ElementId fillPatternId = ElementId.InvalidElementId;
            FilteredElementCollector coll = new FilteredElementCollector(doc);
            coll.OfClass(typeof(FillPatternElement));
            foreach (Element e in coll.ToElements())
            {
                FillPatternElement fe = e as FillPatternElement;
                if (fe.GetFillPattern().IsSolidFill)
                {
                    fillPatternId = e.Id;
                    break;
                }
            }
            // 设置颜色和填充图案
            OverrideGraphicSettings setting = new OverrideGraphicSettings();
            // 截面填充图案
            //setting.SetSurfaceTransparency(0);
            //setting.SetCutFillColor(new Color(255, 0, 0));
            //setting.SetCutFillPatternId(fillPatternId);
            // 表面填充图案
            setting.SetProjectionFillColor(new Color(255, 255, 0));
            setting.SetProjectionFillPatternId(fillPatternId);
            return setting;
        }
        #endregion

    }
}
