# Sample Snippet: ChangeDimensionText

Source project: `existingCodes\梁涛插件源代码\10.CEG\ChangeDimensionText\ChangeDimensionText`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeDimensionText
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uIDoc = commandData.Application.ActiveUIDocument;
            Document doc = uIDoc.Document;
            using (Transaction t = new Transaction(doc, "change dimension text"))
            {
                t.Start();
                List<Dimension> dimensions = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Dimensions).OfClass(typeof(Dimension)).Cast<Dimension>().ToList();
                foreach (var item in dimensions)
                {
                    DimensionSegmentArray dimensionSegmentArray = item.Segments;
                    foreach (DimensionSegment segment in dimensionSegmentArray)
                    {
                        if (segment.Below == "Ø36 TEMINATOR ANCHOR")
                        {
                            segment.Below = "36mmØ HEADED BARS";
                        }
                    }
                }
                t.Commit();
            }
            return Result.Succeeded; 
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
[assembly: AssemblyTitle("ChangeDimensionText")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("ChangeDimensionText")]
[assembly: AssemblyCopyright("Copyright ©  2024")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// 将 ComVisible 设置为 false 会使此程序集中的类型
//对 COM 组件不可见。如果需要从 COM 访问此程序集中的类型
//请将此类型的 ComVisible 特性设置为 true。
[assembly: ComVisible(false)]

// 如果此项目向 COM 公开，则下列 GUID 用于类型库的 ID
[assembly: Guid("480ba8a8-a2b0-4cca-8d09-68f351e81147")]

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

