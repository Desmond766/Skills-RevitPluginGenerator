using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Structure;
using Autodesk.Revit.Exceptions;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using RevitUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using OperationCanceledException = Autodesk.Revit.Exceptions.OperationCanceledException;
using Transform = Autodesk.Revit.DB.Transform;

namespace WallColumnLevelBeamFloor
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        View3D view3D = null;
        bool LevelStruct;
        bool UpLevel;
        bool DownLevel;
        bool LevelBeam;
        bool LevelFloor;
        ElementParameterFilter ParamFilter;
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;

            //Element element = doc.GetElement(sel.PickObject(ObjectType.Element));
            //Element element2 = doc.GetElement(sel.PickObject(ObjectType.Element));
            //var reds = JoinGeometryUtils.AreElementsJoined(doc, element, element2);
            //var res = JoinGeometryUtils.IsCuttingElementInJoin(doc, element, element2);
            //TaskDialog.Show("d", reds.ToString()+"\n"+res);
            //return Result.Succeeded;

            //XYZ point = sel.PickPoint();
            //point = new XYZ(point.X, point.Y, 200000);
            //Transform transform = null;
            //Element elem = GetLinkFloorByRay(doc, doc.ActiveView as View3D, point, XYZ.BasisZ.Negate(), BuiltInCategory.OST_Floors, true, ref transform);
            //if (elem != null && elem.Document.IsLinked == true)
            //{
            //    TaskDialog.Show("revit", elem.Id.ToString());
            //    uidoc.ShowElements(elem);
            //    sel.SetElementIds(new ElementId[] { elem.Id });
            //}
            //return Result.Succeeded;

            //MainWindow mainWindow = new MainWindow();
            //mainWindow.ShowDialog();
            //return Result.Succeeded;

            //SelViewWindow selViewWindow = new SelViewWindow(doc);
            //selViewWindow.ShowDialog();
            //if (selViewWindow.DialogResult == true)
            //{
            //    MessageBox.Show((selViewWindow.list.SelectedItem as ViewInfo).View3D.Title);
            //}
            //return Result.Succeeded;

            //Assembly assembly = Assembly.LoadFrom(@"C:\Users\Administrator\Desktop\25.5.15后续新插件\RevitUtils\RevitUtils\bin\Debug\RevitUtils.dll");
            //Type type = assembly.GetType("RevitUtils.ViewUtils");
            //var flag = System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.InvokeMethod;
            //View re = (View)assembly.GetType("RevitUtils.ViewUtils").InvokeMember("SelectView3D", flag, Type.DefaultBinder, null, new object[] {doc });
            //string info = "";
            //foreach (var item in assembly.GetType("RevitUtils.ViewUtils").GetMethods())
            //{
            //    info += item.Name + ":" + item.GetParameters() + "\n";

            //}
            //TaskDialog.Show("rei", info);
            //TaskDialog.Show("reid", re.Name);
            //var instance = Activator.CreateInstance(type);
            //var method = type.GetMethod("SelectView3D", new Type[] { typeof(Document) });
            //View viewss = (View)method?.Invoke(instance, new object[] { doc });
            //TaskDialog.Show("rei", viewss.Name);

            //return Result.Succeeded;


            if (doc.ActiveView is View3D) view3D = (View3D)doc.ActiveView;
            else
            {
                SelViewWindow window = new SelViewWindow(doc);
                window.ShowDialog();
                if (window.DialogResult == false) return Result.Cancelled;
                view3D = (window.list.SelectedItem as ViewInfo).View3D;
                uidoc.ActiveView = view3D;
            }
            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();
            if (mainWindow.DialogResult == false) return Result.Cancelled;

            LevelStruct = mainWindow.rb_struct.IsChecked.Value;
            UpLevel = mainWindow.cb_upL.IsChecked.Value;
            DownLevel = mainWindow.cb_downL.IsChecked.Value;
            LevelBeam = mainWindow.cb_levelB.IsChecked.Value;
            LevelFloor = mainWindow.cb_levelF.IsChecked.Value;

            // 结构参数元素过滤器
            ElementId ruleParamId = new ElementId(BuiltInParameter.FLOOR_PARAM_IS_STRUCTURAL);//某个参数的ID
            FilterRule filteRule;
            if (LevelStruct) filteRule = ParameterFilterRuleFactory.CreateEqualsRule(ruleParamId, 1);
            else filteRule = ParameterFilterRuleFactory.CreateEqualsRule(ruleParamId, 0);
            ParamFilter = new ElementParameterFilter(filteRule); // 存在参数“结构”且值为0/1的元素过滤器

            ListenUtils listenUtils = new ListenUtils();
            IList<Reference> refers;
            try
            {
                listenUtils.startListen();
                refers = sel.PickObjects(ObjectType.Element, new LevelElemFilter(mainWindow.cb_wall.IsChecked, mainWindow.cb_column.IsChecked), "框选要切的墙/柱（按空格键完成框选，ESC键取消）");
                listenUtils.stopListen();
            }
            catch (OperationCanceledException)
            {
                listenUtils.stopListen();
                return Result.Cancelled;
            }

            List<Element> walls = new List<Element>();
            List<Element> columns = new List<Element>();
            walls = refers.Where(r => doc.GetElement(r) is Wall).Select(x => doc.GetElement(x)).ToList();
            columns = refers.Where(r => doc.GetElement(r) is FamilyInstance).Select(x => doc.GetElement(x)).ToList();

            int wallCount = 0;
            int columnCount = 0;
            int downWallCount = 0;
            int downColumnCount = 0;
            string showInfo = "运行结束！\n";
            string wallInfo = $"选中墙数量：{walls.Count}\n";
            string upWallInfo = "";
            string downWallInfo = "";
            string columnInfo = $"选中柱数量：{columns.Count}\n";
            string upColumnInfo = "";
            string downColumnInfo = "";

            CutUtils cutUtils = new CutUtils(LevelBeam, LevelFloor, view3D, ParamFilter);

            TransactionGroup TG = new TransactionGroup(doc, "墙柱齐梁板");
            TG.Start();

            // 25.5.27 新增对上齐下齐的判断
            if (UpLevel)
            {

                //LevelWall(doc, walls, ref wallSuccessfulCount);
                
                cutUtils.LevelWall(doc, walls, ref wallCount);
                if (walls.Count > 0) upWallInfo = $"上齐成功修改：{wallCount}\n上齐未成功修改：{walls.Count - wallCount}\n";

                //LevelColumns(doc, columns, ref columnSuccessfulCount);
                cutUtils.LevelColumns(doc, columns, ref columnCount);
                if (columns.Count > 0) upColumnInfo = $"上齐成功修改：{columnCount}\n上齐未成功修改：{columns.Count - columnCount}\n";
            }
            if (DownLevel)
            {
                cutUtils.DownLevelWall(doc, walls, ref downWallCount);
                if (walls.Count > 0) downWallInfo = $"下齐成功修改：{downWallCount}\n下齐未成功修改：{walls.Count - downWallCount}\n";
                //DownLevelWall(doc, walls, ref downWallCount);
                cutUtils.DownLevelColumns(doc, columns, ref downColumnCount);
                if (columns.Count > 0) downColumnInfo = $"下齐成功修改：{downColumnCount}\n下齐未成功修改：{columns.Count - downColumnCount}";
                //DownLevelColumns(doc, columns, ref downColumnCount);
            }


            TG.Assimilate();
            //TG.Commit();

            MessageBox.Show(showInfo + wallInfo + upWallInfo + downWallInfo + columnInfo + upColumnInfo + downColumnInfo);

            return Result.Succeeded;
        }

        #region 下对齐墙和柱
        private void DownLevelColumns(Document doc, List<Element> columns, ref int count) // TODO: 25.5.27碰撞与射线的集合判断，最后再使用一次射线计算斜板情况
        {
            foreach (var column in columns)
            {
                Transform linkTransform = null;
                string elemCategory;
                List<Element> filterElems = new List<Element>();
                Element result;
                double elevation;
                // 寻找与元素碰撞的楼板
                if (LevelFloor)
                {
                    var box = column.get_BoundingBox(null);
                    Outline outline = new Outline(box.Min, box.Max);
                    XYZ rayPoint = box.Min.Add(box.Max) / 2;
                    Element floor = GetFloorByRay(doc, view3D, rayPoint, XYZ.BasisZ.Negate(), BuiltInCategory.OST_Floors, true, ref linkTransform);
                    if (floor != null)
                    {
                        result = floor;
                        elevation = GetFloorElevation(doc, result, linkTransform);
                        count++;
                        elemCategory = linkTransform == null ? "板" : " 链接板";
                        filterElems.Add(floor);
                        goto StartTran;
                    }

                    filterElems = new FilteredElementCollector(doc, doc.ActiveView.Id).WherePasses(ParamFilter).WherePasses(new BoundingBoxIntersectsFilter(outline)).WherePasses(new ElementIntersectsElementFilter(column)).OfCategory(BuiltInCategory.OST_Floors).OfClass(typeof(Floor)).ToElements().ToList();
                    elemCategory = "板";
                    if (filterElems.Count == 0)
                    {
                        elemCategory = "链接板";
                        filterElems = GetLinkElems<Element>(doc, BuiltInCategory.OST_Floors, column, ref linkTransform);
                        if (filterElems.Count == 0) continue;
                    }
                }
                else continue;
                count++;

                if (filterElems.First() is Floor)
                {
                    result = filterElems.OrderBy(f => GetFloorElevation(doc, f, linkTransform)).FirstOrDefault();
                    elevation = GetFloorElevation(doc, result, linkTransform);
                }
                else
                {
                    result = filterElems.OrderBy(f => GetBeamElevation(doc, f, linkTransform)).FirstOrDefault();
                    elevation = GetBeamElevation(doc, result, linkTransform);
                }

            StartTran:
                elevation += result.get_Parameter(BuiltInParameter.FLOOR_ATTR_THICKNESS_PARAM).AsDouble(); // 获取楼板顶的高程(默认result为楼板)

                using (Transaction t = new Transaction(doc, $"{elemCategory}切柱"))
                {
                    t.Start();

                    var bottomLevel = (doc.GetElement(column.get_Parameter(BuiltInParameter.FAMILY_BASE_LEVEL_PARAM).AsElementId()) as Level).Elevation;
                    column.get_Parameter(BuiltInParameter.FAMILY_BASE_LEVEL_OFFSET_PARAM).Set(bottomLevel + elevation);
                    // column.get_Parameter(BuiltInParameter.FAMILY_BASE_LEVEL_OFFSET_PARAM).AsDouble() - (column.get_Parameter(BuiltInParameter.FAMILY_BASE_LEVEL_OFFSET_PARAM).AsDouble() - bottomLevel - elevation)

                    t.Commit();
                }
                double dis = GetDistanceToFloor(doc, column, new List<ElementId>() { filterElems.First().Id }, view3D, XYZ.BasisZ.Negate());
                if (dis > 0)
                {
                    using (Transaction t = new Transaction(doc, "斜板补充"))
                    {
                        t.Start();
                        dis = column.get_Parameter(BuiltInParameter.FAMILY_BASE_LEVEL_OFFSET_PARAM).AsDouble() - dis - result.get_Parameter(BuiltInParameter.FLOOR_ATTR_THICKNESS_PARAM).AsDouble() / 2;
                        column.get_Parameter(BuiltInParameter.FAMILY_BASE_LEVEL_OFFSET_PARAM).Set(dis);
                        t.Commit();
                    }
                }
            }
        }

        private void DownLevelWall(Document doc, List<Element> walls, ref int count)
        {
            foreach (var wall in walls)
            {
                Transform linkTransform = null;
                string elemCategory;
                List<Element> filterElems = new List<Element>();
                Element result;
                double elevation;
                // 寻找与元素碰撞的楼板
                if (LevelFloor)
                {
                    var box = wall.get_BoundingBox(null);
                    Outline outline = new Outline(box.Min, box.Max);
                    XYZ rayPoint = box.Min.Add(box.Max) / 2;
                    Element floor = GetFloorByRay(doc, view3D, rayPoint, XYZ.BasisZ.Negate(), BuiltInCategory.OST_Floors, true, ref linkTransform);
                    if (floor != null)
                    {
                        result = floor;
                        elevation = GetFloorElevation(doc, result, linkTransform);
                        count++;
                        elemCategory = linkTransform == null ? "板" : " 链接板";
                        filterElems.Add(floor);
                        goto StartTran;
                    }

                    filterElems = new FilteredElementCollector(doc, doc.ActiveView.Id).WherePasses(ParamFilter).WherePasses(new BoundingBoxIntersectsFilter(outline)).WherePasses(new ElementIntersectsElementFilter(wall)).OfCategory(BuiltInCategory.OST_Floors).OfClass(typeof(Floor)).ToElements().ToList();
                    elemCategory = "板";
                    if (filterElems.Count == 0)
                    {
                        elemCategory = "链接板";
                        filterElems = GetLinkElems<Element>(doc, BuiltInCategory.OST_Floors, wall, ref linkTransform);
                        if (filterElems.Count == 0) continue;
                    }
                }
                else continue;
                count++;

                if (filterElems.First() is Floor)
                {
                    result = filterElems.OrderBy(f => GetFloorElevation(doc, f, linkTransform)).FirstOrDefault();
                    elevation = GetFloorElevation(doc, result, linkTransform);
                }
                else
                {
                    result = filterElems.OrderBy(f => GetBeamElevation(doc, f, linkTransform)).FirstOrDefault();
                    elevation = GetBeamElevation(doc, result, linkTransform);
                }
                
            StartTran:
                elevation += result.get_Parameter(BuiltInParameter.FLOOR_ATTR_THICKNESS_PARAM).AsDouble(); // 默认为楼板
                Level topLevel;
                using (Transaction t = new Transaction(doc, $"{elemCategory}切墙(下齐)"))
                {
                    t.Start();

                    //底部限制条件
                    Level bottomLevel = doc.GetElement(wall.get_Parameter(BuiltInParameter.WALL_BASE_CONSTRAINT).AsElementId()) as Level;
                    double bottomOffset = wall.get_Parameter(BuiltInParameter.WALL_BASE_OFFSET).AsDouble();

                    //墙底距底板上距离
                    double wallToFloor = bottomLevel.Elevation + bottomOffset - elevation;
                    //顶部约束
                    topLevel = doc.GetElement(wall.get_Parameter(BuiltInParameter.WALL_HEIGHT_TYPE).AsElementId()) as Level;
                    if (null == topLevel)
                    {
                        wall.get_Parameter(BuiltInParameter.WALL_BASE_OFFSET).Set(wall.get_Parameter(BuiltInParameter.WALL_BASE_OFFSET).AsDouble() - wallToFloor);
                        //墙无连接高度
                        wall.get_Parameter(BuiltInParameter.WALL_USER_HEIGHT_PARAM).Set(wall.get_Parameter(BuiltInParameter.WALL_USER_HEIGHT_PARAM).AsDouble() + wallToFloor);

                    }
                    else
                    {
                        wall.get_Parameter(BuiltInParameter.WALL_BASE_OFFSET).Set(wall.get_Parameter(BuiltInParameter.WALL_BASE_OFFSET).AsDouble() - wallToFloor);
                    }
                    t.Commit();
                }
                if (null == topLevel)
                {
                    double dis = GetDistanceToFloor(doc, wall, new List<ElementId>() { filterElems.First().Id }, view3D, XYZ.BasisZ.Negate());
                    if (dis > 0)
                    {
                        using (Transaction t = new Transaction(doc, "斜板补充"))
                        {
                            t.Start();
                            wall.get_Parameter(BuiltInParameter.WALL_BASE_OFFSET).Set(wall.get_Parameter(BuiltInParameter.WALL_BASE_OFFSET).AsDouble() - dis);
                            dis += wall.get_Parameter(BuiltInParameter.WALL_USER_HEIGHT_PARAM).AsDouble();
                            wall.get_Parameter(BuiltInParameter.WALL_USER_HEIGHT_PARAM).Set(dis);
                            t.Commit();
                        }
                    }
                }
                else
                {
                    double dis = GetDistanceToFloor(doc, wall, new List<ElementId>() { filterElems.First().Id }, view3D, XYZ.BasisZ.Negate());
                    if (dis > 0)
                    {
                        using (Transaction t = new Transaction(doc, "斜板补充"))
                        {
                            t.Start();
                            wall.get_Parameter(BuiltInParameter.WALL_BASE_OFFSET).Set(wall.get_Parameter(BuiltInParameter.WALL_BASE_OFFSET).AsDouble() - dis);
                            t.Commit();
                        }
                    }
                }
            }
        }
        private Element GetFloorByRay(Document doc, View3D view3D, XYZ rayPoint, XYZ rayDirection, BuiltInCategory builtInCategory, bool findLink, ref Transform linkTransform)
        {
            Element element = null;
            var intersector = new ReferenceIntersector(new LogicalAndFilter(new ElementCategoryFilter(builtInCategory), ParamFilter), FindReferenceTarget.Element, view3D);
            intersector.FindReferencesInRevitLinks = findLink; // 是否寻找链接中的元素
            var rw = intersector.FindNearest(rayPoint, rayDirection);
            if (rw != null)
            {
                var reference = rw.GetReference();
                var elem = doc.GetElement(reference);
                if (elem is RevitLinkInstance linkInstance)
                {
                    linkTransform = linkInstance.GetTransform();
                    Document linkDoc = linkInstance.GetLinkDocument();
                    element = linkDoc.GetElement(reference.LinkedElementId);
                }
                else
                {
                    element = elem;
                }
            }

            return element;
        }
        #endregion


        #region 获得楼板顶标高
        /// <summary>
        ///  获得楼板底标高
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private double GetFloorElevation(Document doc, Element e, Transform transform/* = null*/)
        {
            // TODO:25/5/23 在链接模型中的楼板可能这两种方法都获取不到标高，可以使用边界盒的经过坐标转换后的min的Z坐标作为高程
            double level;
            try
            {
                level = (doc.GetElement(e.get_Parameter(BuiltInParameter.LEVEL_PARAM).AsElementId()) as Level).Elevation;
            }
            catch (Exception)
            {
                try
                {
                    level = (doc.GetElement(e.LevelId) as Level).Elevation; // 链接模型中的楼板
                }
                catch (Exception)
                {
                    return transform.OfPoint(e.get_BoundingBox(null).Min).Z;
                }
                
            }
            
            double offset = e.get_Parameter(BuiltInParameter.FLOOR_HEIGHTABOVELEVEL_PARAM).AsDouble();
            double thickness = e.get_Parameter(BuiltInParameter.FLOOR_ATTR_THICKNESS_PARAM).AsDouble();

            if (e.Document.IsLinked == true && transform != null) return level + offset - thickness + transform.BasisZ.Z * transform.Origin.Z;
            return level + offset - thickness;
        }
        #endregion

        #region 获得梁顶标高
        /// <summary>
        /// 获得梁顶标高
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private double GetBeamElevation(Document doc, Element e, Transform transform/* = null*/)
        {
            double level;
            try
            {
                level = (doc.GetElement(e.get_Parameter(BuiltInParameter.INSTANCE_REFERENCE_LEVEL_PARAM).AsElementId()) as Level).Elevation;
            }
            catch (Exception)
            {
                try
                {
                    level = (doc.GetElement(e.LevelId) as Level).Elevation; // 链接模型中的梁
                }
                catch (Exception)
                {
                    return transform.OfPoint(e.get_BoundingBox(null).Min).Z;
                }

            }
            //double level = (doc.GetElement(e.get_Parameter(BuiltInParameter.INSTANCE_REFERENCE_LEVEL_PARAM).AsElementId()) as Level).Elevation;
            double startOffset = e.get_Parameter(BuiltInParameter.STRUCTURAL_BEAM_END0_ELEVATION).AsDouble();
            double endOffset = e.get_Parameter(BuiltInParameter.STRUCTURAL_BEAM_END1_ELEVATION).AsDouble();
            double zOffset = e.get_Parameter(BuiltInParameter.Z_OFFSET_VALUE).AsDouble();
            if (e.Document.IsLinked == true && transform != null) return level + (startOffset + endOffset) / 2.0 + zOffset - (e.get_BoundingBox(null).Max.Z - e.get_BoundingBox(null).Min.Z) + transform.BasisZ.Z * transform.Origin.Z;
            return level + (startOffset + endOffset) / 2.0 + zOffset - (e.get_BoundingBox(null).Max.Z - e.get_BoundingBox(null).Min.Z);
        }
        #endregion
        private double GetElevation(Document doc, Element e, Transform transform)
        {
            if (e is Floor) return GetFloorElevation(doc, e, transform);
            return GetBeamElevation(doc, e, transform);
        }
        #region 上对齐墙和柱
        private void LevelWall(Document doc, List<Element> walls, ref int count) // TODO:25.6.5梁和楼板必须同时判断选最低，四个方法都需要修改。判断方法也得修改，运行插件出现墙顶低于墙底的情况，可能是最终找到的梁/楼板错误导致
        {
            /*
             * 1.梁和楼板同时判断，碰撞结果放进集合中
             * 2.使用射线计算离墙最近的梁/楼板，若射线未找到则用普通计算方法
             * 3.修改墙/柱高度
             */
            //var walls = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_Walls).OfClass(typeof(Wall));
            foreach (var wall in walls)
            {
                Transform linkTransform = null;
                string elemCategory;
                List<Element> filterElems;
                // 寻找与元素碰撞的楼板
                // 25.5.27 添加对齐梁齐板的选择判断(新增三个if判断)
                if (LevelBeam && LevelFloor)
                {
                    filterElems = new FilteredElementCollector(doc, doc.ActiveView.Id).WherePasses(ParamFilter).WherePasses(new ElementIntersectsElementFilter(wall)).OfCategory(BuiltInCategory.OST_Floors).OfClass(typeof(Floor)).ToElements().ToList();
                    elemCategory = "板";
                    if (filterElems.Count == 0)
                    {
                        elemCategory = "链接板";
                        filterElems = GetLinkElems<Element>(doc, BuiltInCategory.OST_Floors, wall, ref linkTransform);
                        if (filterElems.Count == 0)
                        {
                            elemCategory = "梁";
                            // 寻找与元素碰撞的梁
                            filterElems = new FilteredElementCollector(doc, doc.ActiveView.Id).WherePasses(new ElementIntersectsElementFilter(wall)).OfCategory(BuiltInCategory.OST_StructuralFraming).OfClass(typeof(FamilyInstance)).ToElements().ToList();
                            if (filterElems.Count == 0)
                            {
                                elemCategory = "链接梁";
                                filterElems = GetLinkElems<Element>(doc, BuiltInCategory.OST_StructuralFraming, wall, ref linkTransform);
                                if (filterElems.Count == 0) continue;
                            }
                        }
                    }
                }
                else if (LevelBeam && !LevelFloor)
                {
                    elemCategory = "梁";
                    // 寻找与元素碰撞的梁
                    filterElems = new FilteredElementCollector(doc, doc.ActiveView.Id).WherePasses(new ElementIntersectsElementFilter(wall)).OfCategory(BuiltInCategory.OST_StructuralFraming).OfClass(typeof(FamilyInstance)).ToElements().ToList();
                    if (filterElems.Count == 0)
                    {
                        elemCategory = "链接梁";
                        filterElems = GetLinkElems<Element>(doc, BuiltInCategory.OST_StructuralFraming, wall, ref linkTransform);
                        if (filterElems.Count == 0) continue;
                    }
                }
                else if (!LevelBeam && LevelFloor)
                {
                    filterElems = new FilteredElementCollector(doc, doc.ActiveView.Id).WherePasses(ParamFilter).WherePasses(new ElementIntersectsElementFilter(wall)).OfCategory(BuiltInCategory.OST_Floors).OfClass(typeof(Floor)).ToElements().ToList();
                    elemCategory = "板";
                    if (filterElems.Count == 0)
                    {
                        elemCategory = "链接板";
                        filterElems = GetLinkElems<Element>(doc, BuiltInCategory.OST_Floors, wall, ref linkTransform);
                        if (filterElems.Count == 0) continue;
                    }
                }
                else continue;
                
                count++;
                Element result;
                double elevation;
                if (filterElems.First() is Floor)
                {
                    //TaskDialog.Show("revit", (filterElems.First() == null).ToString());
                    result = filterElems.OrderByDescending(f => GetFloorElevation(doc, f, linkTransform)).FirstOrDefault();
                    elevation = GetFloorElevation(doc, result, linkTransform);
                }
                else
                {
                    result = filterElems.OrderByDescending(f => GetBeamElevation(doc, f, linkTransform)).FirstOrDefault();
                    elevation = GetBeamElevation(doc, result, linkTransform);
                }
                Level topLevel;
                using (Transaction t = new Transaction(doc, $"{elemCategory}切墙"))
                {
                    t.Start();

                    //底部限制条件
                    Level bottomLevel = doc.GetElement(wall.get_Parameter(BuiltInParameter.WALL_BASE_CONSTRAINT).AsElementId()) as Level;
                    double bottomOffset = wall.get_Parameter(BuiltInParameter.WALL_BASE_OFFSET).AsDouble();

                    //墙高
                    double wallHeight = elevation - (bottomLevel.Elevation + bottomOffset);

                    //顶部约束
                    topLevel = doc.GetElement(wall.get_Parameter(BuiltInParameter.WALL_HEIGHT_TYPE).AsElementId()) as Level;
                    if (null == topLevel)
                    {
                        //墙无连接高度
                        double dis = GetDistanceByRay(doc, wall, new List<ElementId>() { result.Id }, view3D, FindDirection.BasisZ);
                        if (dis != double.NaN) wall.get_Parameter(BuiltInParameter.WALL_USER_HEIGHT_PARAM).Set(wall.get_Parameter(BuiltInParameter.WALL_USER_HEIGHT_PARAM).AsDouble() + dis);
                        else wall.get_Parameter(BuiltInParameter.WALL_USER_HEIGHT_PARAM).Set(wallHeight);

                    }
                    else
                    {
                        //墙顶部偏移
                        double topOffset = elevation - topLevel.Elevation;

                        double dis = GetDistanceByRay(doc, wall, new List<ElementId>() { result.Id }, view3D, FindDirection.BasisZ);
                        if (dis != double.NaN) wall.get_Parameter(BuiltInParameter.WALL_TOP_OFFSET).Set(wall.get_Parameter(BuiltInParameter.WALL_TOP_OFFSET).AsDouble() + dis);
                        else wall.get_Parameter(BuiltInParameter.WALL_TOP_OFFSET).Set(topOffset);
                        TaskDialog.Show("revit", (topOffset * 304.8).ToString() + "\n" + (elevation * 304.8) + "\n" + (topLevel.Elevation * 304.8) + "\n" + (dis * 304.8));
                    }
                    t.Commit();
                }
                if (null == topLevel)
                {
                    double dis = GetDistanceToFloor(doc, wall, new List<ElementId>() { filterElems.First().Id }, view3D, XYZ.BasisZ);
                    if (dis > 0)
                    {
                        using (Transaction t = new Transaction(doc, "斜板补充"))
                        {
                            t.Start();
                            dis += wall.get_Parameter(BuiltInParameter.WALL_USER_HEIGHT_PARAM).AsDouble();
                            wall.get_Parameter(BuiltInParameter.WALL_USER_HEIGHT_PARAM).Set(dis);
                            t.Commit();
                        }
                    }
                }
                else
                {
                    double dis = GetDistanceToFloor(doc, wall, new List<ElementId>() { filterElems.First().Id }, view3D, XYZ.BasisZ);
                    if (dis > 0)
                    {
                        using (Transaction t = new Transaction(doc, "斜板补充"))
                        {
                            t.Start();
                            dis += wall.get_Parameter(BuiltInParameter.WALL_TOP_OFFSET).AsDouble();
                            wall.get_Parameter(BuiltInParameter.WALL_TOP_OFFSET).Set(dis);
                            t.Commit();
                        }
                    }
                }
            }
        }
        private void LevelColumns(Document doc, List<Element> columns, ref int count)
        {
            //var columns = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_StructuralColumns).OfClass(typeof(FamilyInstance));
            foreach (var column in columns)
            {
                string elemCategory;
                Transform linkTransform = null;
                List<Element> filterElems;
                // 寻找与元素碰撞的楼板
                if (LevelBeam && LevelFloor)
                {
                    filterElems = new FilteredElementCollector(doc, doc.ActiveView.Id).WherePasses(ParamFilter).WherePasses(new ElementIntersectsElementFilter(column)).OfCategory(BuiltInCategory.OST_Floors).OfClass(typeof(Floor)).ToElements().ToList();
                    elemCategory = "板";
                    if (filterElems.Count == 0)
                    {
                        elemCategory = "链接板";
                        filterElems = GetLinkElems<Element>(doc, BuiltInCategory.OST_Floors, column, ref linkTransform);
                        if (filterElems.Count == 0)
                        {
                            elemCategory = "梁";
                            // 寻找与元素碰撞的梁
                            filterElems = new FilteredElementCollector(doc, doc.ActiveView.Id).WherePasses(new ElementIntersectsElementFilter(column)).OfCategory(BuiltInCategory.OST_StructuralFraming).OfClass(typeof(FamilyInstance)).ToElements().ToList();
                            if (filterElems.Count == 0)
                            {
                                elemCategory = "链接梁";
                                filterElems = GetLinkElems<Element>(doc, BuiltInCategory.OST_StructuralFraming, column, ref linkTransform);
                                if (filterElems.Count == 0) continue;
                            }
                        }
                    }
                }
                else if (!LevelBeam && LevelFloor)
                {
                    filterElems = new FilteredElementCollector(doc, doc.ActiveView.Id).WherePasses(ParamFilter).WherePasses(new ElementIntersectsElementFilter(column)).OfCategory(BuiltInCategory.OST_Floors).OfClass(typeof(Floor)).ToElements().ToList();
                    elemCategory = "板";
                    if (filterElems.Count == 0)
                    {
                        elemCategory = "链接板";
                        filterElems = GetLinkElems<Element>(doc, BuiltInCategory.OST_Floors, column, ref linkTransform);
                        if (filterElems.Count == 0) continue;
                    }
                }
                else if (LevelBeam && !LevelFloor)
                {
                    elemCategory = "梁";
                    // 寻找与元素碰撞的梁
                    filterElems = new FilteredElementCollector(doc, doc.ActiveView.Id).WherePasses(new ElementIntersectsElementFilter(column)).OfCategory(BuiltInCategory.OST_StructuralFraming).OfClass(typeof(FamilyInstance)).ToElements().ToList();
                    if (filterElems.Count == 0)
                    {
                        elemCategory = "链接梁";
                        filterElems = GetLinkElems<Element>(doc, BuiltInCategory.OST_StructuralFraming, column, ref linkTransform);
                        if (filterElems.Count == 0) continue;
                    }
                }
                else continue;
                
                count++;
                Element result;
                double elevation;
                if (filterElems.First() is Floor)
                {
                    result = filterElems.OrderByDescending(f => GetFloorElevation(doc, f, linkTransform)).FirstOrDefault();
                    elevation = GetFloorElevation(doc, result, linkTransform);
                }
                else
                {
                    result = filterElems.OrderByDescending(f => GetBeamElevation(doc, f, linkTransform)).FirstOrDefault();
                    elevation = GetBeamElevation(doc, result, linkTransform);
                }
                using (Transaction t = new Transaction(doc, $"{elemCategory}切柱"))
                {
                    t.Start();

                    double columnHeight = column.get_BoundingBox(null).Max.Z;
                    column.get_Parameter(BuiltInParameter.FAMILY_TOP_LEVEL_OFFSET_PARAM).Set(column.get_Parameter(BuiltInParameter.FAMILY_TOP_LEVEL_OFFSET_PARAM).AsDouble() - columnHeight + elevation);

                    t.Commit();
                }
                double dis = GetDistanceToFloor(doc, column, new List<ElementId>() { filterElems.First().Id }, view3D, XYZ.BasisZ);
                if (dis > 0)
                {
                    using (Transaction t = new Transaction(doc, "斜板补充"))
                    {
                        t.Start();
                        dis += column.get_Parameter(BuiltInParameter.FAMILY_TOP_LEVEL_OFFSET_PARAM).AsDouble();
                        column.get_Parameter(BuiltInParameter.FAMILY_TOP_LEVEL_OFFSET_PARAM).Set(dis);
                        t.Commit();
                    }
                }
            }
        }
        #endregion
        /// <summary>
        /// 获取链接模型中与elem碰撞的指定类型的元素集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="doc"></param>
        /// <param name="filterCategory">指定与elem碰撞的链接模型元素类型</param>
        /// <param name="elem">与链接模型碰撞的元素</param>
        /// <returns></returns>
        private List<T> GetLinkElems<T>(Document doc, BuiltInCategory filterCategory, Element elem, ref Transform transform)
        {
            //25.5.22 若链接模型进行过移动/旋转，则使用过滤器无法正确过滤出对应元素
            List<T> elems = new List<T>();
            var links = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_RvtLinks).OfClass(typeof(RevitLinkInstance)).Cast<RevitLinkInstance>();

            foreach ( var link in links )
            {
                Transform linkTransform = link.GetTransform();
                Document linkDoc = link.GetLinkDocument();

                Solid elemTransformSolid = GetTransformSolid(linkTransform, elem);
                if (elemTransformSolid == null) continue;

                XYZ min = linkTransform.Inverse.OfPoint(elem.get_BoundingBox(null).Min);// 25.5.27 使用碰撞可能会找到墙上方楼板标高 应使用碰撞与射线集合，取高程最小的楼板
                XYZ max = linkTransform.Inverse.OfPoint(elem.get_BoundingBox(null).Max);
                Outline outline = new Outline(min, max);
                var intersectsFilter = new BoundingBoxIntersectsFilter(outline);
                var solidFilter = new ElementIntersectsSolidFilter(elemTransformSolid);
                // 快慢结合加快过滤速度
                LogicalAndFilter andFilter = new LogicalAndFilter(solidFilter, intersectsFilter);

                // 25.5.28 新增对选择结构板/建筑板的判断
                if (filterCategory == BuiltInCategory.OST_Floors) elems = new FilteredElementCollector(linkDoc).WherePasses(ParamFilter).OfCategory(filterCategory).WhereElementIsNotElementType().WherePasses(andFilter).Cast<T>().ToList();
                else elems = new FilteredElementCollector(linkDoc).OfCategory(filterCategory).WhereElementIsNotElementType().WherePasses(andFilter).Cast<T>().ToList();

                transform = linkTransform;
                //elems = new FilteredElementCollector(linkDoc).OfCategory(filterCategory).WhereElementIsNotElementType().WherePasses(new ElementIntersectsElementFilter(elem)).Cast<T>().ToList();
                if (elems.Count > 0)
                {
                    if (elems.First() is FamilyInstance)
                    {
                        elems = elems.Cast<FamilyInstance>().Where(e => e.StructuralType == StructuralType.Beam).Cast<T>().ToList();
                        break;
                    }
                    else break;
                }
            }

            return elems;
        }

        private Solid GetTransformSolid(Transform linkTransform, Element elem)
        {
            Solid solid = null;

            Transform reTransform = linkTransform.Inverse;
            var gee = elem.get_Geometry(new Options() { IncludeNonVisibleObjects = false, DetailLevel = ViewDetailLevel.Fine });
            gee = gee.GetTransformed(reTransform);

            foreach ( var element in gee )
            {
                if (element is Solid solid1 && solid1.Volume > 0)
                {
                    solid = solid1;
                    break;
                }
            }

            return solid;
        }

        private double GetDistanceToFloor(Document doc, Element e, List<ElementId> targetIds, View3D view, XYZ findDirection)
        {
            double dis = -1;
            // 只考虑斜板，不对梁进行判断
            if (!(doc.GetElement(targetIds.First()) is Floor)) return dis;

            //View3D view = doc.ActiveView as View3D;
            var box = e.get_BoundingBox(null);
            XYZ p = box.Min.Add(box.Max) / 2;
            if (findDirection.IsAlmostEqualTo(XYZ.BasisZ)) p = new XYZ(p.X, p.Y, box.Max.Z);
            else p = new XYZ(p.X, p.Y, box.Min.Z);

            ReferenceIntersector intersector = new ReferenceIntersector(targetIds, FindReferenceTarget.Element, view);
            intersector.FindReferencesInRevitLinks = true; // 25.6.5
            ReferenceWithContext rw = intersector.FindNearest(p, findDirection);
            if (rw != null)
            {
                dis = rw.GetReference().GlobalPoint.DistanceTo(p);
            }

            //dis = 0;
            return dis;
        }
        /// <summary>
        /// 获取两元素垂直距离
        /// </summary>
        /// <param name="doc">文档</param>
        /// <param name="e">射线起始坐标元素</param>
        /// <param name="findIds">被射线的元素</param>
        /// <param name="view3D">三维视图</param>
        /// <param name="findDirection">射线方向</param>
        /// <returns></returns>
        private double GetDistanceByRay(Document doc, Element e, List<ElementId> findIds, View3D view3D, FindDirection findDirection)
        {
            double dis = double.NaN;

            XYZ direction;

            var box = e.get_BoundingBox(null);
            double boxHeight = box.Max.Z - box.Min.Z;
            XYZ p = box.Min.Add(box.Max) / 2;
            if (findDirection == FindDirection.BasisZ)
            {
                direction = XYZ.BasisZ;
                //boxHeight = box.Max.Z - box.Min.Z;
                p = new XYZ(p.X, p.Y, box.Min.Z);
            }
            else
            {
                direction = XYZ.BasisZ.Negate();
                //boxHeight = -(box.Max.Z - box.Min.Z);
                p = new XYZ(p.X, p.Y, box.Max.Z);
            }
            ReferenceIntersector intersector = new ReferenceIntersector(findIds, FindReferenceTarget.Element, view3D);
            intersector.FindReferencesInRevitLinks = true;
            var rw = intersector.FindNearest(p, direction);
            if (rw != null)
            {
                dis = rw.GetReference().GlobalPoint.DistanceTo(p) - boxHeight;
            }



            return dis;
        }
        enum FindDirection
        {
            BasisZ,
            Negate
        }
    }
}
