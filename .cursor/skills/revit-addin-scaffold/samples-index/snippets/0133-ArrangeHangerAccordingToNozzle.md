# Sample Snippet: ArrangeHangerAccordingToNozzle

Source project: `existingCodes\梁涛插件源代码\4.吊架布置\ArrangeHangerAccordingToNozzle（框选）\ArrangeHangerAccordingToNozzle`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.DB.Structure;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.Attributes;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace ArrangeHangerAccordingToNozzle
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        //int count3 = 0;
        UIDocument uIDoc = null;
        Document doc = null;
        View3D view3D = null;
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {

            uIDoc = commandData.Application.ActiveUIDocument;
            doc = uIDoc.Document;
            //判断视图
            if (!(doc.ActiveView is ViewPlan))
            {
                TaskDialog.Show("提示", "请在平面视图中运行插件！");
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
                if ("3D 支吊架".Equals(view3.Name))
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
                    message = string.Format("未找到3D视图： 3D 支吊架 或 3D {0}", doc.ActiveView.Name);
                    return Result.Cancelled;
                }
            }

            IList<Reference> references = new List<Reference>();
            try
            {
                  references = uIDoc.Selection.PickObjects(Autodesk.Revit.UI.Selection.ObjectType.Element, new SprinklerFilter(), "框选喷头");
            }
            catch (Exception)
            {
                TaskDialog.Show("提示", "已取消布置");
                return Result.Cancelled;
            }
            UserControl1 userControl1 = new UserControl1();
            userControl1.ShowDialog();
            if (userControl1.cancel)
            {
                return Result.Cancelled;
            }
            using (Transaction t = new Transaction(doc, "AddHanger"))
            {
                t.Start();
// ... truncated ...
```

## Utils.cs

```csharp
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrangeHangerAccordingToNozzle
{
    public class Utils
    {
        #region 获得向下投影到楼板的点
        public static XYZ GetClearHeightPoint(View3D view, Document doc, XYZ point_Do)
        {
            XYZ point;
            //梁的计算点point_Do 

            List<ElementFilter> filterList = new List<ElementFilter>();
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_Floors));
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_Ceilings));
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_StructuralFoundation));
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_RvtLinks));

            LogicalOrFilter floorOrCeiling = new LogicalOrFilter(filterList);
            //change
            //FilterRule filterRule = ParameterFilterRuleFactory.CreateHasValueParameterRule(new ElementId((int)BuiltInParameter.STRUCTURAL_ELEVATION_AT_TOP));
            FilterRule filterRule = ParameterFilterRuleFactory.CreateHasValueParameterRule(new ElementId(-1001598));
            ElementParameterFilter elementParameterFilter = new ElementParameterFilter(filterRule);
            LogicalAndFilter logicalAndFilter = new LogicalAndFilter(floorOrCeiling, elementParameterFilter);

            //相交                                                                    change
            //ReferenceIntersector referenceIntersector = new ReferenceIntersector(elementParameterFilter, FindReferenceTarget.All, view);
            //referenceIntersector.FindReferencesInRevitLinks = true;

            //ReferenceWithContext referenceWithContext = referenceIntersector.FindNearest(point_Do, XYZ.BasisZ.Negate());

            ReferenceIntersector referenceIntersector1 = new ReferenceIntersector(floorOrCeiling, FindReferenceTarget.All, view);
            referenceIntersector1.FindReferencesInRevitLinks = true;
            ReferenceWithContext referenceWithContext1 = referenceIntersector1.FindNearest(point_Do, XYZ.BasisZ.Negate());
            Reference r3 = referenceWithContext1.GetReference();
            XYZ point1 = r3.GlobalPoint;
            //Floor floor1 = doc.GetElement(r3) as Floor;

            //Reference r2 = referenceWithContext.GetReference();
            //point = r2.GlobalPoint;
            //Floor floor = doc.GetElement(r2) as Floor;
            //if (!(floor.get_Parameter(BuiltInParameter.FLOOR_ATTR_THICKNESS_PARAM).AsValueString().Equals(floor1.get_Parameter(BuiltInParameter.FLOOR_ATTR_THICKNESS_PARAM).AsValueString())))
            //{
            //    point = point + new XYZ(0, 0, floor1.get_Parameter(BuiltInParameter.FLOOR_ATTR_THICKNESS_PARAM).AsDouble());
            //}
            //DrawModelCurve(doc, point_Do, r2.GlobalPoint);

            return point1;

        }
        #endregion
        #region 获得向上投影到楼板的点
        public static XYZ GetClearHeightPoint1(View3D view, Document doc, XYZ point_Do)
        {
            XYZ point;
            //梁的计算点point_Do 

            List<ElementFilter> filterList = new List<ElementFilter>();
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_Floors));
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_Ceilings));
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_StructuralFoundation));
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_RvtLinks));

            LogicalOrFilter floorOrCeiling = new LogicalOrFilter(filterList);
            //change
            //FilterRule filterRule = ParameterFilterRuleFactory.CreateHasValueParameterRule(new ElementId((int)BuiltInParameter.STRUCTURAL_ELEVATION_AT_TOP));
            FilterRule filterRule = ParameterFilterRuleFactory.CreateHasValueParameterRule(new ElementId(-1001598));
            ElementParameterFilter elementParameterFilter = new ElementParameterFilter(filterRule);
            LogicalAndFilter logicalAndFilter = new LogicalAndFilter(floorOrCeiling, elementParameterFilter);

            //相交                                                                    change
            //ReferenceIntersector referenceIntersector = new ReferenceIntersector(elementParameterFilter, FindReferenceTarget.All, view);
            //referenceIntersector.FindReferencesInRevitLinks = true;

            //ReferenceWithContext referenceWithContext = referenceIntersector.FindNearest(point_Do, XYZ.BasisZ.Negate());

            ReferenceIntersector referenceIntersector1 = new ReferenceIntersector(floorOrCeiling, FindReferenceTarget.All, view);
            referenceIntersector1.FindReferencesInRevitLinks = true;
            ReferenceWithContext referenceWithContext1 = referenceIntersector1.FindNearest(point_Do, XYZ.BasisZ);
            Reference r3 = referenceWithContext1.GetReference();
            XYZ point1 = r3.GlobalPoint;
            //Floor floor1 = doc.GetElement(r3) as Floor;
// ... truncated ...
```

