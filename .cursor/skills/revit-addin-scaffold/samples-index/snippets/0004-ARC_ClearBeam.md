# Sample Snippet: ARC_ClearBeam

Source project: `existingCodes\品成插件源代码\土建\ARC_ClearBeam\ARC_ClearBeam`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;
using System.Diagnostics;

namespace ARC_ClearBeam
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {  
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //注册验证
            string licFile = string.Format("{0}\\Key.lic",
    System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
            if (!BTAddInHelper.Utils.CheckReg(licFile))
            {
                return Result.Cancelled;
            }

            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            //计时开始
            Stopwatch sw = new Stopwatch();
            sw.Start();
            //主程序开始
            int num_Clear = 0;
            //遍历文档中的梁，修改族类型
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            collector.OfCategory(BuiltInCategory.OST_StructuralFraming).OfClass(typeof(FamilyInstance));
            List<FamilyInstance> beams = collector.Cast<FamilyInstance>().Where(x => x.StructuralType == Autodesk.Revit.DB.Structure.StructuralType.Beam).ToList();
            List<FamilyInstance> errorBeam = new List<FamilyInstance>();
            using (Transaction t = new Transaction(doc, "ClearBeam"))
            {
                t.Start();
                foreach (FamilyInstance beam in beams)
                {
                    bool isErrorBeam = false;
                    SetSymbol(doc, beam, out isErrorBeam);
                    if (isErrorBeam)
                    {
                        errorBeam.Add(beam);
                    }
                }
                //清理HW-矩形梁族内未使用的族类型
                Family family_HWBeam = GetFamily(doc, "HW-矩形梁");
                if (null != family_HWBeam)
                {
                    //遍历族下的所有类型
                    List<ElementId> symbolIds = family_HWBeam.GetFamilySymbolIds().ToList();
                    if (symbolIds.Count != 0)
                    {
                        foreach (ElementId id in symbolIds)
                        {
                            FilteredElementCollector c = new FilteredElementCollector(doc);
                            FamilyInstanceFilter fif = new FamilyInstanceFilter(doc, id);
                            c.WherePasses(fif);
                            if (c.Count() == 0)
                            {
                                doc.Delete(id);
                                num_Clear += 1;
                            }
                        }
                    }
                }
                //将错误的梁赋上红色
                if (errorBeam.Count != 0)
                {
                    foreach (FamilyInstance beam in errorBeam)
                    {
                        //梁材质为实例参数
                        beam.get_Parameter(BuiltInParameter.STRUCTURAL_MATERIAL_PARAM).Set(GetMyErrorMaterial(doc));
                    }
                }
                t.Commit();
            }
            //结束计时
            sw.Stop();
            //输出程序运行结果
            string info = "遍历" + beams.Count().ToString() + "根梁；\n其中" + errorBeam.Count.ToString() + "根梁出错，标示为红色；\n清理" + num_Clear.ToString() + "个未使用的梁类型；\n用时" + sw.Elapsed.ToString();
            TaskDialog.Show("Revit", info);


            return Result.Succeeded;
// ... truncated ...
```

## Properties\AssemblyInfo.cs

```csharp
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// 有关程序集的常规信息通过以下
// 特性集控制。更改这些特性值可修改
// 与程序集关联的信息。
[assembly: AssemblyTitle("ARC_ClearBeam")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyProduct("ARC_ClearBeam")]
[assembly: AssemblyCopyright("Copyright © Microsoft 2019")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// 将 ComVisible 设置为 false 使此程序集中的类型
// 对 COM 组件不可见。  如果需要从 COM 访问此程序集中的类型，
// 则将该类型上的 ComVisible 特性设置为 true。
[assembly: ComVisible(false)]

// 如果此项目向 COM 公开，则下列 GUID 用于类型库的 ID
[assembly: Guid("f94fdc2e-e3eb-4037-8035-540920dedb2d")]

// 程序集的版本信息由下面四个值组成: 
//
//      主版本
//      次版本 
//      生成号
//      修订号
//
// 可以指定所有这些值，也可以使用“生成号”和“修订号”的默认值，
// 方法是按如下所示使用“*”: 
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

```

