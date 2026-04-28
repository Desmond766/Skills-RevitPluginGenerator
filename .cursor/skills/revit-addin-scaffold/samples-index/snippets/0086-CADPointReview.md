# Sample Snippet: CADPointReview

Source project: `existingCodes\梁涛插件源代码\1.土建\CADPointReview\CADPointReview`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
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

// ... truncated ...
```

## Utils.cs

```csharp
using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CADPointReview
{
    public class Utils
    {
        public static Solid CreateSolid(XYZ centerP, double r, double halfHeight)
        {
            Solid solid;

            centerP = centerP - XYZ.BasisZ * halfHeight;

            XYZ p1 = centerP - XYZ.BasisX * r + XYZ.BasisY * r;
            XYZ p2 = centerP + XYZ.BasisX * r + XYZ.BasisY * r;
            XYZ p3 = centerP + XYZ.BasisX * r - XYZ.BasisY * r;
            XYZ p4 = centerP - XYZ.BasisX * r - XYZ.BasisY * r;

            //放样
            List<CurveLoop> loops = new List<CurveLoop>();
            List<Curve> curveList = new List<Curve> { Line.CreateBound(p1, p2), Line.CreateBound(p2, p3), Line.CreateBound(p3, p4), Line.CreateBound(p4, p1) };
            CurveLoop curveLoop = CurveLoop.Create(curveList);
            loops.Add(curveLoop);
            //拉伸
            solid = GeometryCreationUtilities.CreateExtrusionGeometry(loops, XYZ.BasisZ, halfHeight * 2);
            ElementIntersectsSolidFilter filter = new ElementIntersectsSolidFilter(solid);

            return solid;
        }
        public static ElementIntersectsSolidFilter CreateSolidFilter(XYZ centerP, double r, double halfHeight)
        {
            Solid solid = CreateSolid(centerP, r, halfHeight);
            return new ElementIntersectsSolidFilter(solid);
        }
        public static BoundingBoxIntersectsFilter CreateBoxFilter(XYZ centerP, double r, double halfHeight)
        {
            XYZ min = centerP - XYZ.BasisX * r - XYZ.BasisY * r - XYZ.BasisZ * halfHeight;
            XYZ max = centerP + XYZ.BasisX * r + XYZ.BasisY * r + XYZ.BasisZ * halfHeight;

            return new BoundingBoxIntersectsFilter(new Outline(min, max));
        }
        /// <summary>
        /// 针对项目的结构柱过滤器
        /// </summary>
        /// <returns></returns>
        public static ElementFilter CreateColumnFilter(Param param, int paramValue)
        {
            ElementFilter elementFilter;

            ElementCategoryFilter categoryFilter = new ElementCategoryFilter(BuiltInCategory.OST_StructuralColumns);
            // 创建一个过滤器过滤出存在参数“结构”且strongtype为int32且值为1的元素
            ElementId ruleParamId = new ElementId((int)param);
            FilterRule filteRule = ParameterFilterRuleFactory.CreateEqualsRule(ruleParamId, paramValue);
            ElementParameterFilter paramFilter = new ElementParameterFilter(filteRule);

            elementFilter = new LogicalAndFilter(categoryFilter, paramFilter);
            return elementFilter;
        }
        public static ElementFilter CreateColumnFilter(List<Param> columnParams, int paramValue)
        {
            ElementFilter elementFilter;

            ElementCategoryFilter categoryFilter = new ElementCategoryFilter(BuiltInCategory.OST_StructuralColumns);
            if (columnParams.Count == 0) return categoryFilter;

            List<ElementFilter> elementFilters = new List<ElementFilter>();
            foreach (var param in columnParams)
            {
                // 创建一个过滤器过滤出存在参数“结构”且strongtype为int32且值为1的元素
                ElementId ruleParamId = new ElementId((int)param);
                FilterRule filteRule = ParameterFilterRuleFactory.CreateEqualsRule(ruleParamId, paramValue);
                ElementParameterFilter paramFilter = new ElementParameterFilter(filteRule);
                elementFilters.Add(paramFilter);
            }
            LogicalOrFilter orFilter = new LogicalOrFilter(elementFilters);

            elementFilter = new LogicalAndFilter(categoryFilter, orFilter);
            return elementFilter;
        }
        /// <summary>
        /// 获取选择geo对应的块参照名称
        /// </summary>
        /// <param name="geoSel">手动选择的元素部分</param>
        /// <param name="importInstance">链接CAD</param>
        /// <returns></returns>
        public static string GetSelBlockName(GeometryObject geoSel, ImportInstance importInstance)
// ... truncated ...
```

