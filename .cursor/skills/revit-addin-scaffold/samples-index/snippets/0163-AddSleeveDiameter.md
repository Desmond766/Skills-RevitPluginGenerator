# Sample Snippet: AddSleeveDiameter

Source project: `existingCodes\梁涛插件源代码\8.算量插件集合\拆分（旧）\AddSleeveDiameter\AddSleeveDiameter`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddSleeveDiameter
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;

            //FamilyInstance familyInstance = doc.GetElement(sel.PickObject(ObjectType.Element)) as FamilyInstance;
            //using (Transaction t = new Transaction(doc, "sss"))
            //{
            //    t.Start();

            //    var gee = familyInstance.get_Geometry(new Options() { IncludeNonVisibleObjects = true });
            //    foreach (var item in gee)
            //    {
            //        if (item is Solid solid)
            //        {
            //            var box = familyInstance.get_BoundingBox(null);
            //            Outline outline = new Outline(box.Min, box.Max);
            //            BoundingBoxIntersectsFilter boxIntersectsFilter = new BoundingBoxIntersectsFilter(outline);
            //            ElementIntersectsSolidFilter solidFilter = new ElementIntersectsSolidFilter(solid);
            //            LogicalAndFilter andFilter = new LogicalAndFilter(solidFilter, boxIntersectsFilter);
            //            var pips = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_PipeCurves).WherePasses(andFilter);
            //            TaskDialog.Show("dd", pips.Count().ToString());
            //            break;
            //        }
            //    }

            //    t.Commit();
            //}
            //return Result.Succeeded;

            //Pipe pipe = doc.GetElement(sel.PickObject(ObjectType.Element)) as Pipe;
            //XYZ p = (familyInstance.Location as LocationPoint).Point;
            //Line line = (pipe.Location as LocationCurve).Curve as Line;
            //XYZ pp = line.Project(p).XYZPoint;
            //var pipeCol = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_PipeCurves).WherePasses(new ElementIntersectsElementFilter(familyInstance));
            //TaskDialog.Show("dd", pipeCol.Count().ToString() + "\n" + p.DistanceTo(pp));
            //return Result.Succeeded;

            int gxCount = 0;
            int rxCount = 0;
            int mbCount = 0;
            int gCount = 0;
            // 获取指定名称的套管
            FilteredElementCollector sleeveCol = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_MechanicalEquipment).WhereElementIsNotElementType();

            var sleeves = sleeveCol.Where(f => f is FamilyInstance).Cast<FamilyInstance>().Where(s => s.Symbol.Name.Contains("柔性防水套管") || s.Symbol.FamilyName.Contains("柔性防水套管") || s.Symbol.Name.Contains("刚性防水套管") || s.Symbol.FamilyName.Contains("刚性防水套管")
            || s.Symbol.Name.Contains("密闭套管") || s.Symbol.FamilyName.Contains("密闭套管")
            || ((s.Symbol.Name.Contains("钢套管") || s.Symbol.FamilyName.Contains("钢套管")) && s.LookupParameter("系统名称") != null && !string.IsNullOrEmpty(s.LookupParameter("系统名称").AsString()) && s.LookupParameter("系统名称").AsString().Contains("ZP"))).ToList();

            using (Transaction t = new Transaction(doc, "套管管径标识参数赋值"))
            {
                t.Start();

                foreach (var sl in sleeves)
                {
                    //if (sl.LookupParameter("系统名称") == null || sl.LookupParameter("系统名称").AsString() == null || !sl.LookupParameter("系统名称").AsString().Contains("ZP"))
                    //{
                    //    continue;
                    //}
                    double pipeDim = 0;
                    using (FilteredElementCollector pipeCol = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_PipeCurves))
                    {
                        var box = sl.get_BoundingBox(null);
                        Outline outline = new Outline(box.Min, box.Max);
                        BoundingBoxIntersectsFilter intersectsFilter = new BoundingBoxIntersectsFilter(outline);
                        ElementIntersectsSolidFilter solidFilter = null;
                        var gee = sl.get_Geometry(new Options() { IncludeNonVisibleObjects = true });
                        foreach (var geo in gee)
                        {
                            if (geo is Solid solid)
                            {
                                solidFilter = new ElementIntersectsSolidFilter(solid);
                                break;
// ... truncated ...
```

## Properties\AssemblyInfo.cs

```csharp
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// 有关程序集的一般信息由以下
// 控制。更改这些特性值可修改
// 与程序集关联的信息。
[assembly: AssemblyTitle("AddSleeveDiameter")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("AddSleeveDiameter")]
[assembly: AssemblyCopyright("Copyright ©  2025")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// 将 ComVisible 设置为 false 会使此程序集中的类型
//对 COM 组件不可见。如果需要从 COM 访问此程序集中的类型
//请将此类型的 ComVisible 特性设置为 true。
[assembly: ComVisible(false)]

// 如果此项目向 COM 公开，则下列 GUID 用于类型库的 ID
[assembly: Guid("1c65cf96-372f-46bc-a5f7-4adebf35fc67")]

// 程序集的版本信息由下列四个值组成: 
//
//      主版本
//      次版本
//      生成号
//      修订号
//
//可以指定所有这些值，也可以使用“生成号”和“修订号”的默认值
//通过使用 "*"，如下所示:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

```

