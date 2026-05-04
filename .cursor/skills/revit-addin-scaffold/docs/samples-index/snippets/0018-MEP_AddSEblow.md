# Sample Snippet: MEP_AddSEblow

Source project: `existingCodes\品成插件源代码\机电\MEP_AddSEblow\MEP_AddSEblow`

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
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.DB.Plumbing;

namespace MEP_AddSEblow
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
    //        //注册验证
    //        string licFile = string.Format("{0}\\Key.lic",
    //System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
    //        if (!BTAddInHelper.Utils.CheckReg(licFile))
    //        {
    //            return Result.Cancelled;
    //        }

            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection selection = uiapp.ActiveUIDocument.Selection;
            //定义几个变量
            Reference ref_Drain = null;
            Reference ref_SEblow = null;
            PipeType pt = null;
            ElementId systemTypeId = null;
            //选择S弯或P弯进行布置
            try
            {
                ref_SEblow = selection.PickObject(ObjectType.Element, "请选择一个含有系统类型的存水弯");
                Element sEblow = doc.GetElement(ref_SEblow);
                if (sEblow.Category.Id.IntegerValue != (int)BuiltInCategory.OST_PipeAccessory
                    || !sEblow.get_Parameter(BuiltInParameter.ELEM_FAMILY_PARAM).AsValueString().Contains("存水弯"))
                {
                    TaskDialog.Show("revit", "选择的构件不是存水弯, 程序结束");
                    return Result.Failed;
                }
                pt = GetConnectorPipeType(doc, sEblow as FamilyInstance);
                systemTypeId = sEblow.get_Parameter(BuiltInParameter.RBS_PIPING_SYSTEM_TYPE_PARAM).AsElementId();
                if (null == systemTypeId)
                {
                    TaskDialog.Show("revit", "选择的存水弯没有初始系统类型, 程序结束");
                    return Result.Failed;
                }
            }
            catch
            {
                TaskDialog.Show("Revit", "操作取消，程序结束");
                return Result.Cancelled;
            }
            //主程序开始
            while (true)
            {
                try
                {
                    using (Transaction t = new Transaction(doc, "Add SEblow"))
                    {
                        t.Start();
                        //选择地漏
                        ref_Drain = selection.PickObject(ObjectType.Element, "点击地漏进行布置");
                        Element drain = doc.GetElement(ref_Drain);
                        if (drain.Category.Id.IntegerValue != (int)BuiltInCategory.OST_PipeAccessory
                            || !drain.get_Parameter(BuiltInParameter.ELEM_FAMILY_PARAM).AsValueString().Contains('漏'))
                        {
                            TaskDialog.Show("revit", "选择的构件不是地漏，跳过");
                            continue;
                        }
                        XYZ lPoint_drain = (drain.Location as LocationPoint).Point;
                        List<Connector> cons_drain = GetConnectors(drain as FamilyInstance);
                        XYZ conPoint_drain = cons_drain[0].Origin;
                        if (!(lPoint_drain - conPoint_drain).Normalize().IsAlmostEqualTo(XYZ.BasisZ))
                        {
                            TaskDialog.Show("revit", "仅支持向下的地漏，跳过");
                            continue;
                        }
                        //创建S弯或P弯
                        XYZ location = conPoint_drain + XYZ.BasisZ.Negate() * (500 / 304.8);
                        Element sEblow = doc.GetElement(ref_SEblow);
                        FamilySymbol sy = (sEblow as FamilyInstance).Symbol;
                        FamilyInstance new_SEblow = doc.Create.NewFamilyInstance(
                            location, sy, Autodesk.Revit.DB.Structure.StructuralType.NonStructural);
                        //修改S弯或P弯的公称直径
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
[assembly: AssemblyTitle("MEP_AddSEblow")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyProduct("MEP_AddSEblow")]
[assembly: AssemblyCopyright("Copyright © Microsoft 2019")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// 将 ComVisible 设置为 false 会使此程序集中的类型
//对 COM 组件不可见。如果需要从 COM 访问此程序集中的类型
//请将此类型的 ComVisible 特性设置为 true。
[assembly: ComVisible(false)]

// 如果此项目向 COM 公开，则下列 GUID 用于类型库的 ID
[assembly: Guid("1ff0e251-6c64-4916-b65c-4e44a2ff6e6f")]

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

