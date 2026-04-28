# Sample Snippet: AddParaBySymbol

Source project: `existingCodes\梁涛插件源代码\8.算量插件集合\拆分（旧）\AddParaBySymbol\AddParaBySymbol`

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

// 将有设备编号参数的族实例的族类型赋值给该参数
namespace AddParaBySymbol
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;

            int meCount = 0;
            int daCount = 0;
            int paCount = 0;
            var elemFilters = new List<ElementFilter>()
            {
                new ElementCategoryFilter(BuiltInCategory.OST_MechanicalEquipment),
                new ElementCategoryFilter(BuiltInCategory.OST_DuctAccessory),
                new ElementCategoryFilter(BuiltInCategory.OST_PipeAccessory),
            };
            LogicalOrFilter orFilter = new LogicalOrFilter(elemFilters);
            var collect = new FilteredElementCollector(doc, doc.ActiveView.Id).WhereElementIsNotElementType().WherePasses(orFilter).Where(x => x is FamilyInstance).Cast<FamilyInstance>();
            using (Transaction t = new Transaction(doc, "补充设备编号参数"))
            {
                t.Start();
                foreach (var item in collect)
                {
                    var para = item.LookupParameter("设备编号");
                    if (para != null)
                    {
                        // 该参数取消关联全局参数
                        para.DissociateFromGlobalParameter();
                        para.Set(item.Symbol.Name);
                        switch (item.Category.Id.IntegerValue)
                        {
                            case (int)BuiltInCategory.OST_MechanicalEquipment:
                                meCount++;
                                break;
                            case (int)BuiltInCategory.OST_DuctAccessory:
                                daCount++;
                                break;
                            case (int)BuiltInCategory.OST_PipeAccessory:
                                paCount++;
                                break;
                            default:
                                break;
                        }
                    }
                }

                t.Commit();
            }
            TaskDialog.Show("提示", $"运行结束！\n成功补充设备编号参数的族实例个数：\n机械设备：{meCount}\n风管附件：{daCount}\n管道附件：{paCount}");


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
[assembly: AssemblyTitle("AddParaBySymbol")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("AddParaBySymbol")]
[assembly: AssemblyCopyright("Copyright ©  2025")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// 将 ComVisible 设置为 false 会使此程序集中的类型
//对 COM 组件不可见。如果需要从 COM 访问此程序集中的类型
//请将此类型的 ComVisible 特性设置为 true。
[assembly: ComVisible(false)]

// 如果此项目向 COM 公开，则下列 GUID 用于类型库的 ID
[assembly: Guid("8070afef-e91d-42a4-a843-38d16195a6db")]

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

