# Sample Snippet: AddParaToBuriedPipe

Source project: `existingCodes\梁涛插件源代码\8.算量插件集合\拆分（旧）\AddParaToBuriedPipe\AddParaToBuriedPipe`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AddParaToBuriedPipe
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uIDoc = commandData.Application.ActiveUIDocument;
            Document doc = uIDoc.Document;

            View3D view3D = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Views).WhereElementIsNotElementType()
                .Where(x => x is View3D).Cast<View3D>().FirstOrDefault(y => y.Name.Contains("3D 机电"));
            if (view3D == null)
            {
                TaskDialog.Show("提示", "未找到视图：3D 机电");
                return Result.Cancelled;
            }

            List<Pipe> pipes = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_PipeCurves).WhereElementIsNotElementType().Cast<Pipe>().ToList();
            using (Transaction t = new Transaction(doc, "埋地管道参数赋值"))
            {
                t.Start();
                foreach (var pipe in pipes)
                {
                    Line line = (pipe.Location as LocationCurve).Curve as Line;
                    XYZ p0 = line.GetEndPoint(0);
                    XYZ p1 = line.GetEndPoint(1);
                    if (!IsPipeUnderFloor(view3D, p0) && !IsPipeUnderFloor(view3D, p1)) continue;

                    try
                    {
                        pipe.LookupParameter("安装方式").Set("埋地");
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
                t.Commit();
            }


            return Result.Succeeded;
        }

        public bool IsPipeUnderFloor(View3D view3D, XYZ point)
        {
            List<ElementFilter> filterList = new List<ElementFilter>();
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_Floors));
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_Ceilings));
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_StructuralFoundation));
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_RvtLinks));

            LogicalOrFilter floorOrCeiling = new LogicalOrFilter(filterList);
            ReferenceIntersector referenceIntersector = new ReferenceIntersector(floorOrCeiling, FindReferenceTarget.Element, view3D);
            referenceIntersector.FindReferencesInRevitLinks = true;
            ReferenceWithContext referenceWithContext = referenceIntersector.FindNearest(point, XYZ.BasisZ.Negate());

            if (referenceWithContext != null) return false;
            return true;
        }
    }
}

```

## Properties\AssemblyInfo.cs

```csharp
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// 有关程序集的一般信息由以下
// 控制。更改这些特性值可修改
// 与程序集关联的信息。
[assembly: AssemblyTitle("AddParaToBuriedPipe")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("AddParaToBuriedPipe")]
[assembly: AssemblyCopyright("Copyright ©  2024")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// 将 ComVisible 设置为 false 会使此程序集中的类型
//对 COM 组件不可见。如果需要从 COM 访问此程序集中的类型
//请将此类型的 ComVisible 特性设置为 true。
[assembly: ComVisible(false)]

// 如果此项目向 COM 公开，则下列 GUID 用于类型库的 ID
[assembly: Guid("b754480a-d63d-4ce0-9ef5-e9bbc6112d54")]

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

