# Sample Snippet: TextNoteForSleeveToTopFloor

Source project: `existingCodes\梁涛插件源代码\5.吊架出图\TextNoteForSleeveToTopFloor\TextNoteForSleeveToTopFloor`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using View = Autodesk.Revit.DB.View;

namespace TextNoteForSleeveToTopFloor
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;

            View3D view3D;
            if (!(doc.ActiveView is ViewPlan))
            {
                message = "请在平面视图运行该插件!";
                elements.Insert(doc.ActiveView);
                return Result.Failed;
            }

            List<ElementFilter> elementFilters = new List<ElementFilter>()
            {
                new ElementCategoryFilter(BuiltInCategory.OST_PipeAccessory),
                new ElementCategoryFilter(BuiltInCategory.OST_MechanicalEquipment),
                new ElementCategoryFilter(BuiltInCategory.OST_PipeFitting)
            };
            LogicalOrFilter orFilter = new LogicalOrFilter(elementFilters);
            var pipeFitts = new FilteredElementCollector(doc, doc.ActiveView.Id).WherePasses(orFilter).OfClass(typeof(FamilyInstance)).Where(x => x.Name.Contains("套管")).ToList();

            var view3Ds = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Views).OfClass(typeof(View3D)).Cast<View3D>().ToList();
            view3D = view3Ds.FirstOrDefault(v => v.Name == "3D 支吊架");
            if (view3D == null) view3D = view3Ds.FirstOrDefault();
            if (view3D == null)
            {
                message = "未在该项目中找到三维视图，无法运行插件!";
                return Result.Failed;
            }
            
            bool startOpen = uidoc.GetOpenUIViews().FirstOrDefault(x => x.ViewId == view3D.Id) != null;
            View activeView = uidoc.ActiveView;
            uidoc.ActiveView = view3D;
            uidoc.ActiveView = activeView;
            //return Result.Succeeded;

            int count = 0;
            using (Transaction t = new Transaction(doc, "创建文字注释"))
            {
                t.Start();

                foreach (var pipeFit in pipeFitts)
                {
                    XYZ point = (pipeFit.Location as LocationPoint).Point;
                    XYZ min = pipeFit.get_BoundingBox(null).Min;
                    XYZ newPoint = new XYZ(min.X, min.Y, point.Z);
                    double dis;
                    try
                    {
                        dis = GetClearHeightUp(doc, view3D, newPoint);
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                    CreateTextNote(uidoc, "板下" + (Math.Round(dis * 304.8, 0)).ToString(), point, pipeFit);
                    count++;
                }

                t.Commit();
            }
            // 获取所有已打开的视图窗口
            IList<UIView> openViews = uidoc.GetOpenUIViews();
            var closeView = openViews.FirstOrDefault(x => x.ViewId == view3D.Id);
            if (closeView != null && !startOpen) closeView.Close();

            MessageBox.Show($"运行结束\n使用三维视图: {view3D.Name}\n有" + count + "个套管成功生成文字注释\n有" + (pipeFitts.Count - count) + "个套管未成功生成文字注释", $"Revit-{view3D.Name}");

            return Result.Succeeded;
        }
        public void CreateTextNote(UIDocument uidoc, string text, XYZ centerP, Element elem)
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
[assembly: AssemblyTitle("TextNoteForSleeveToTopFloor")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("TextNoteForSleeveToTopFloor")]
[assembly: AssemblyCopyright("Copyright ©  2025")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// 将 ComVisible 设置为 false 会使此程序集中的类型
//对 COM 组件不可见。如果需要从 COM 访问此程序集中的类型
//请将此类型的 ComVisible 特性设置为 true。
[assembly: ComVisible(false)]

// 如果此项目向 COM 公开，则下列 GUID 用于类型库的 ID
[assembly: Guid("d37ab42e-fdd5-4d8b-a675-c169c3847ef3")]

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

