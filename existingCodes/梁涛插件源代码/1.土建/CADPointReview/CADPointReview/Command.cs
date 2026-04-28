using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using RevitUtils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using static System.Net.Mime.MediaTypeNames;

namespace CADPointReview
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;

            // col中ids的数量必须大于0
            // 逻辑过滤器中elemFilters集合的数量必须大于0

            //Reference reference2 = sel.PickObject(ObjectType.Element);
            //Element findElem = doc.GetElement(reference2);
            //var box = findElem.get_BoundingBox(null);
            //UIView uIView = uidoc.GetOpenUIViews().FirstOrDefault(uiv => uiv.ViewId == doc.ActiveView.Id);
            //if (uIView != null)
            //{
            //    double rr = Properties.Settings.Default.R / 304.8;
            //    uIView.ZoomAndCenterRectangle(box.Min - XYZ.BasisX * rr - XYZ.BasisY * rr, box.Max + XYZ.BasisX * rr + XYZ.BasisY * rr);
            //}
            //else
            //{
            //    TaskDialog.Show("reit", "UNFInd");
            //}
            //return Result.Succeeded;

            //TaskDialog.Show("re", sel.PickPoint().ToString());
            //return Result.Succeeded;

            //FamilyInstance familyInstance = doc.GetElement(sel.PickObject(ObjectType.Element)) as FamilyInstance;
            //XYZ res = Utils.GetMinPointByGeo(familyInstance);
            //TaskDialog.Show("revit", res.ToString() + "\n" + Utils.GetMaxPointBySolid(familyInstance) + "\n" + Utils.GetMinPointBySolid(familyInstance));
            //return Result.Succeeded;

            if (!(doc.ActiveView is ViewPlan))
            {
                TaskDialog.Show("提示", "请在平面运行插件");
                return Result.Cancelled;
            }

            Reference reference;
            try
            {
                reference = sel.PickObject(ObjectType.PointOnElement, new LinkCADFilter(doc), "选择链接CAD中一个块参照");
            }
            catch (Exception)
            {
                MessageBox.Show("已取消操作");
                return Result.Cancelled;
            }

            ImportInstance importInstance = doc.GetElement(reference) as ImportInstance;
            if (importInstance.IsLinked == false)
            {
                TaskDialog.Show("提示", "请在链接CAD中选择");
                return Result.Cancelled;
            }

            GeometryObject geoSel = importInstance.GetGeometryObjectFromReference(reference);
            string blockName = Utils.GetSelBlockName(geoSel, importInstance);
            if (string.IsNullOrEmpty(blockName))
            {
                TaskDialog.Show("提示", "未找到相关块参照");
                return Result.Cancelled;
            }

            var points = Utils.GetSelBlockPoints(blockName, importInstance);
            points = points.OrderBy(p => new UV(p.X, p.Y).DistanceTo(new UV(reference.GlobalPoint.X, reference.GlobalPoint.Y))).ToList();

            //var elem = doc.GetElement(sel.PickObject(ObjectType.Element));
            //TaskDialog.Show("revit", blockName + "\n" + points.Count + "\n" + points.First() + "\n" + (elem.Location as LocationPoint).Point + "\n" + (Utils.GetUVPoint(Utils.GetPoint(elem)).DistanceTo(Utils.GetUVPoint(points.First())) * 304.8));
            //return Result.Succeeded;

            string showBlockName = Regex.Replace(blockName, @".*?dwg\.", "", RegexOptions.IgnoreCase);
            MainWindow mainWindow = new MainWindow(showBlockName);
            mainWindow.ShowDialog();

            if (mainWindow.DialogResult == false) { return Result.Cancelled; }
            //List<string> familyNames = mainWindow.FamilyNames;
            //BuiltInCategory category = mainWindow.Category;
            List<CategoryInfo> categoryInfos = mainWindow.CategoryInfos;
            double r = Properties.Settings.Default.R / 304.8;
            double halfHeight = 2000;
            var columnParams = mainWindow.ColumnParams;
            // 点位名称
            string pointName = mainWindow.ShowFamilyName;

            //ElementId id = FindElement(doc, categoryInfos, points.First(), halfHeight, r, columnParams);
            //if (id != null)
            //{
            //    sel.SetElementIds(new ElementId[] { id });
            //    uidoc.ShowElements(id);
            //}
            //else
            //{
            //    TaskDialog.Show("revit", "未找到");
            //}
            //return Result.Succeeded;


            var blockInfos = FindElements(doc, categoryInfos, points, halfHeight, r, columnParams);
            blockInfos = blockInfos.OrderByDescending(bi => bi.Find).ToList();

            //string addTitle = "(" + blockInfos.Count(bi => bi.ElementId != null) + "/" + points.Count + ")-" + pointName + "-";
            string addTitle = pointName + "-";

            View3D view3D = ViewUtils.SelectView3D(doc);

            if (view3D == null)
            {
                MessageBox.Show("未选择三维视图");
                return Result.Cancelled;
            }

            ResultWindow resultWindow = new ResultWindow(uidoc, blockInfos, addTitle, view3D);
            resultWindow.Show();
            //TaskDialog.Show("revit", blockInfos.Count + "/" + points.Count + "\n");
            //HACK: 25.11.4 结果窗口新增距地高度列

            return Result.Succeeded;
        }

        /// <summary>
        /// 在坐标点一定范围内通过包围盒与实体过滤器判断是否存在对应元素
        /// </summary>
        /// <param name="familyNames">族名称</param>
        /// <param name="points">中心坐标点集合</param>
        /// <param name="category">类型</param>
        /// <param name="halfHeight">一半寻找高度</param>
        /// <param name="r">寻找半径</param>
        /// <param name="columnParams">结构柱上设备的ID集合</param>
        /// <returns></returns>
        private List<BlockInfo> FindElements(Document doc, List<string> familyNames, List<XYZ> points, BuiltInCategory category, double halfHeight, double r, List<Param> columnParams)
        {
            List<BlockInfo> results = new List<BlockInfo>();
            // 指定参数与参数值的结构柱过滤
            ElementFilter columnFilter = Utils.CreateColumnFilter(columnParams, 1);
            // 指定类别的元素过滤
            ElementCategoryFilter  categoryFilter = new ElementCategoryFilter(category);
            // 符合类别与族名称的元素ID
            List<ElementId> categoryElemIds = new List<ElementId>();
            using (FilteredElementCollector cateElemCol = new FilteredElementCollector(doc, doc.ActiveView.Id).WherePasses(categoryFilter))
            {
                var filterElems = cateElemCol.Where(e => e is FamilyInstance f && familyNames.Contains(f.Symbol.FamilyName));
                categoryElemIds.AddRange(filterElems.Select(f => f.Id));
            }
            // 符合拥有指定参数与其值的结构柱ID集合
            List<ElementId> columnIds = new List<ElementId>();

            if (columnParams.Count > 0)
            using (FilteredElementCollector columnCol = new FilteredElementCollector(doc, doc.ActiveView.Id).WherePasses(columnFilter))
            {
                columnIds.AddRange(columnCol.Select(c => c.Id));
            }

            foreach (var point in points)
            {
                List<Element> elements = new List<Element>();

                BoundingBoxIntersectsFilter boxFilter = Utils.CreateBoxFilter(point, r, halfHeight);
                ElementIntersectsSolidFilter solidFilter = Utils.CreateSolidFilter(point, r, halfHeight);

                // 区域过滤
                LogicalAndFilter andFilter = new LogicalAndFilter(boxFilter, solidFilter);

                //LogicalOrFilter orFilter = new LogicalOrFilter(categoryFilter, columnFilter);

                if(categoryElemIds.Count > 0)
                using (FilteredElementCollector elemCol = new FilteredElementCollector(doc, categoryElemIds).WherePasses(andFilter))
                {
                    elements.AddRange(elemCol.ToList());
                }

                if(columnParams.Count > 0 && columnIds.Count > 0)
                using (FilteredElementCollector columnCol = new FilteredElementCollector(doc, columnIds).WherePasses(andFilter))
                {
                    elements.AddRange(columnCol.ToList());
                }

                if (elements.Count() > 0)
                {
                    results.Add(new BlockInfo());
                }
            }


            return results;
        }
        private List<BlockInfo> FindElements(Document doc, List<CategoryInfo> categoryInfos, List<XYZ> points, double halfHeight, double r, List<Param> columnParams)
        {
            List<BlockInfo> results = new List<BlockInfo>();
            // 指定参数与参数值的结构柱过滤
            ElementFilter columnFilter = Utils.CreateColumnFilter(columnParams, 1);
            // 符合类别与族名称的元素ID
            List<ElementId> categoryElemIds = new List<ElementId>();

            foreach (var info in categoryInfos)
            {
                var category = info.Category;
                var familyNames = info.FamilyNames;
                // 指定类别的元素过滤
                ElementCategoryFilter categoryFilter = new ElementCategoryFilter(category);
                using (FilteredElementCollector cateElemCol = new FilteredElementCollector(doc, doc.ActiveView.Id).WherePasses(categoryFilter))
                {
                    var filterElems = cateElemCol.Where(e => e is FamilyInstance f && familyNames.Contains(f.Symbol.FamilyName));
                    categoryElemIds.AddRange(filterElems.Select(f => f.Id));
                }
            }
            
            // 符合拥有指定参数与其值的结构柱ID集合
            List<ElementId> columnIds = new List<ElementId>();

            if (columnParams.Count > 0)
            using (FilteredElementCollector columnCol = new FilteredElementCollector(doc, doc.ActiveView.Id).WherePasses(columnFilter))
            {
                columnIds.AddRange(columnCol.Select(c => c.Id));
            }

            // 收集在一定范围内未找到CAD中点位的Revit点位Id
            List<ElementId> unFindIds = new List<ElementId>();
            unFindIds.AddRange(categoryElemIds);
            unFindIds.AddRange(columnIds);

            foreach (var point in points)
            {
                List<ElementId> elementIds = new List<ElementId>();
                List<Element> elements = new List<Element>();

                BoundingBoxIntersectsFilter boxFilter = Utils.CreateBoxFilter(point, r, halfHeight);
                ElementIntersectsSolidFilter solidFilter = Utils.CreateSolidFilter(point, r, halfHeight);

                // 区域过滤
                LogicalAndFilter andFilter = new LogicalAndFilter(boxFilter, solidFilter);

                //LogicalOrFilter orFilter = new LogicalOrFilter(categoryFilter, columnFilter);

                if (categoryElemIds.Count > 0)
                {
                    using (FilteredElementCollector elemCol = new FilteredElementCollector(doc, categoryElemIds).WherePasses(boxFilter))
                    {
                        //if (elemCol.Count() > 0)
                        //{
                        //    FilteredElementCollector elemCol2 = new FilteredElementCollector(doc, elemCol.ToElementIds()).WherePasses(solidFilter);
                        //    if (elemCol2.Count() > 0) elementIds.AddRange(elemCol2.ToElementIds());
                        //}
                        var resultElems = elemCol.Where(e => Utils.GetPoint(e) != null && Utils.GetUVPoint(Utils.GetPoint(e)).DistanceTo(Utils.GetUVPoint(point)) < r)
                            .OrderBy(e => Utils.GetUVPoint(Utils.GetPoint(e)).DistanceTo(Utils.GetUVPoint(point)));
                        if (resultElems.Any()) elementIds.Add(resultElems.First().Id);
                    }
                }


                if (columnParams.Count > 0 && columnIds.Count > 0)
                {
                    using (FilteredElementCollector columnCol = new FilteredElementCollector(doc, columnIds).WherePasses(boxFilter))
                    {
                        //if (columnCol.Count() > 0)
                        //{
                        //    FilteredElementCollector columnCol2 = new FilteredElementCollector(doc, columnCol.ToElementIds()).WherePasses(solidFilter);
                        //    if (columnCol2.Count() > 0) elementIds.AddRange(columnCol2.ToElementIds());
                        //}
                        var resultElems = columnCol.Where(e => Utils.GetPoint(e) != null && Utils.GetUVPoint(Utils.GetPoint(e)).DistanceTo(Utils.GetUVPoint(point)) < r)
                           .OrderBy(e => Utils.GetUVPoint(Utils.GetPoint(e)).DistanceTo(Utils.GetUVPoint(point)));
                        if (resultElems.Any()) elementIds.Add(resultElems.First().Id);
                    }
                }


                if (elementIds.Count() >= 1)
                {
                    UV uvPoint = Utils.GetUVPoint(point);
                    ElementId finalId = elementIds.OrderBy(id => Utils.GetUVPoint(Utils.GetPoint(doc.GetElement(id))).DistanceTo(uvPoint)).FirstOrDefault();
                    // 从未找到的ID集合中移除
                    unFindIds.Remove(finalId);
                    //ElementId finalId = elementIds.First();
                    results.Add(new BlockInfo() { ElementId = finalId, Find = "是", Point = point, UVPoint = Utils.GetUVPoint(point, 2).ToString(), ElementType = doc.GetElement(finalId).Category?.Name });
                }
                else
                {
                    results.Add(new BlockInfo() { ElementId = null, Find = "否", Point = point, UVPoint = Utils.GetUVPoint(point, 2).ToString() });
                }
            }

            foreach (var id in unFindIds)
            {
                results.Add(new BlockInfo() { ElementId = id, Find = "否", Point = Utils.GetPoint(doc.GetElement(id)), UVPoint = Utils.GetUVPoint(Utils.GetPoint(doc.GetElement(id)), 2).ToString(), ElementType = doc.GetElement(id).Category?.Name });
            }


            return results;
        }
        // 测试用
        private ElementId FindElement(Document doc, List<CategoryInfo> categoryInfos, XYZ point, double halfHeight, double r, List<Param> columnParams)
        {
            ElementId result = null;
            // 指定参数与参数值的结构柱过滤
            ElementFilter columnFilter = Utils.CreateColumnFilter(columnParams, 1);
            // 符合类别与族名称的元素ID
            List<ElementId> categoryElemIds = new List<ElementId>();

            foreach (var info in categoryInfos)
            {
                var category = info.Category;
                var familyNames = info.FamilyNames;
                // 指定类别的元素过滤
                ElementCategoryFilter categoryFilter = new ElementCategoryFilter(category);
                using (FilteredElementCollector cateElemCol = new FilteredElementCollector(doc, doc.ActiveView.Id).WherePasses(categoryFilter))
                {
                    var filterElems = cateElemCol.Where(e => e is FamilyInstance f && familyNames.Contains(f.Symbol.FamilyName));
                    categoryElemIds.AddRange(filterElems.Select(f => f.Id));
                }
            }
            
            // 符合拥有指定参数与其值的结构柱ID集合
            List<ElementId> columnIds = new List<ElementId>();

            if (columnParams.Count > 0)
            using (FilteredElementCollector columnCol = new FilteredElementCollector(doc, doc.ActiveView.Id).WherePasses(columnFilter))
            {
                columnIds.AddRange(columnCol.Select(c => c.Id));
            }

            List<ElementId> elementIds = new List<ElementId>();
            List<Element> elements = new List<Element>();

            BoundingBoxIntersectsFilter boxFilter = Utils.CreateBoxFilter(point, r, halfHeight);
            ElementIntersectsSolidFilter solidFilter = Utils.CreateSolidFilter(point, r, halfHeight);

            // 区域过滤
            LogicalAndFilter andFilter = new LogicalAndFilter(boxFilter, solidFilter);

            //LogicalOrFilter orFilter = new LogicalOrFilter(categoryFilter, columnFilter);

            if (categoryElemIds.Count > 0)
            {
                using (FilteredElementCollector elemCol = new FilteredElementCollector(doc, categoryElemIds).WherePasses(boxFilter))
                {
                    //if (elemCol.Count() > 0)
                    //{
                    //    FilteredElementCollector elemCol2 = new FilteredElementCollector(doc, elemCol.ToElementIds()).WherePasses(solidFilter);
                    //    if (elemCol2.Count() > 0) elementIds.AddRange(elemCol2.ToElementIds());
                    //}
                    var resultElems = elemCol.Where(e => Utils.GetPoint(e) != null && Utils.GetUVPoint(Utils.GetPoint(e)).DistanceTo(Utils.GetUVPoint(point)) < r)
                        .OrderBy(e => Utils.GetUVPoint(Utils.GetPoint(e)).DistanceTo(Utils.GetUVPoint(point)));
                    if (resultElems.Any()) elementIds.Add(resultElems.First().Id);
                }
            }


            if (columnParams.Count > 0 && columnIds.Count > 0)
            {
                using (FilteredElementCollector columnCol = new FilteredElementCollector(doc, columnIds).WherePasses(boxFilter))
                {
                    //if (columnCol.Count() > 0)
                    //{
                    //    FilteredElementCollector columnCol2 = new FilteredElementCollector(doc, columnCol.ToElementIds()).WherePasses(solidFilter);
                    //    if (columnCol2.Count() > 0) elementIds.AddRange(columnCol2.ToElementIds());
                    //}
                    var resultElems = columnCol.Where(e => Utils.GetPoint(e) != null && Utils.GetUVPoint(Utils.GetPoint(e)).DistanceTo(Utils.GetUVPoint(point)) < r)
                       .OrderBy(e => Utils.GetUVPoint(Utils.GetPoint(e)).DistanceTo(Utils.GetUVPoint(point)));
                    if (resultElems.Any()) elementIds.Add(resultElems.First().Id);
                }
            }


            if (elementIds.Count() > 0)
            {
                result = elementIds.First();
            }


            return result;
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
    public class BlockInfo : INotifyPropertyChanged
    {
        // 是否找到
        public string Find { get; set; }
        // 找到的元素ID
        public ElementId ElementId { get; set; }
        // 链接CAD中点位的坐标点
        public XYZ Point { get; set; }
        // 链接CAD块参照UV坐标点
        public string UVPoint { get; set; }
        // 元素类型
        public string ElementType { get; set; }
        // 距地高度
        private double _pointHeight = double.NaN;
        public double PointHeight
        {
            get => _pointHeight;
            set
            {
                if (_pointHeight != value)
                {
                    _pointHeight = value;
                    OnPropertyChanged(nameof(PointHeight));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public enum Param
    {
        无 = 0,
        声光报警 = 3397523,
        应急照明 = 3397522,
        手动报警按钮 = 3397524,
        消防广播 = 3495544,
        疏散指示灯左右 = 3496572,
        疏散指示牌右 = 3397525,
        疏散指示牌左 = 3397526,
        监控 = 3397527,
        监控右 = 3397663,
        监控左 = 3397664
    }
}
