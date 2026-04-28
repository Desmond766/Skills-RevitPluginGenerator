# Sample Snippet: WallOffsetAndJoin

Source project: `existingCodes\品成插件源代码\土建\WallOffsetAndJoin\WallOffsetAndJoin`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
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
[assembly: AssemblyTitle("WallOffsetAndJoin")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyProduct("WallOffsetAndJoin")]
[assembly: AssemblyCopyright("Copyright © Microsoft 2019")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// 将 ComVisible 设置为 false 会使此程序集中的类型
//对 COM 组件不可见。如果需要从 COM 访问此程序集中的类型
//请将此类型的 ComVisible 特性设置为 true。
[assembly: ComVisible(false)]

// 如果此项目向 COM 公开，则下列 GUID 用于类型库的 ID
[assembly: Guid("1787ad80-4aee-4d54-87b9-cb67773c2618")]

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

