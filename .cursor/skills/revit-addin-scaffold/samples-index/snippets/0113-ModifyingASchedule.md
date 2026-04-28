# Sample Snippet: ModifyingASchedule

Source project: `existingCodes\梁涛插件源代码\10.CEG\ModifyingASchedule\ModifyingASchedule`

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

namespace ModifyingASchedule
{
    [TransactionAttribute(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uIDoc = commandData.Application.ActiveUIDocument;
            Document doc = uIDoc.Document;


            List<Element> elements1 = new List<Element>();
            ViewSheet view = doc.ActiveView as ViewSheet;
            ElementClassFilter classFilter = new ElementClassFilter(typeof(FamilyInstance));
            List<ElementId> ids = (doc.GetElement(view.AssociatedAssemblyInstanceId) as AssemblyInstance).GetDependentElements(null).ToList();
            foreach (var item in ids)
            {
                try
                {
                    Element element = doc.GetElement(item);
                    if (element.Category.Id.IntegerValue == -2001350)
                    {
                        elements1.Add(element);
                    }
                }
                catch (Exception)
                {

                    continue;
                }
            }
            string name = doc.GetElement(view.AssociatedAssemblyInstanceId).Name;
            name = GetStringUntilFirstSpace(name);
            //TaskDialog.Show("dd", name);
            int cou = -1;
            foreach (var item in elements1)
            {
                foreach (Parameter para in item.Parameters)
                {
                    try
                    {
                        if (para.Definition.Name == "CONTROL_MARK" && para.AsString().Contains("MK"))
                        {
                            string nameP = para.AsString();
                            nameP = nameP.Replace("MK", "");
                            int couP = Convert.ToInt32(nameP);
                            if (couP > cou)
                            {
                                cou = couP;
                            }
                            break;
                        }
                    }
                    catch (Exception)
                    {

                        continue;
                    }
                }
            }

            List<Element> _Ø = new List<Element>();
            foreach (var item in elements1)
            {
                foreach (Parameter para in item.Parameters)
                {
                    if (para.Definition.Name == "CONTROL_MARK" && para.AsString() != null && para.AsString().Contains("Ø"))
                    {
                        foreach (Parameter para2 in item.Parameters)
                        {
                            try
                            {
                                if (para2.Definition.Name == "全長")
                                {
                                    _Ø.Add(item);
                                }
                            }
                            catch (Exception)
                            {
                                continue;
                            }
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
[assembly: AssemblyTitle("ModifyingASchedule")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("ModifyingASchedule")]
[assembly: AssemblyCopyright("Copyright ©  2024")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// 将 ComVisible 设置为 false 会使此程序集中的类型
//对 COM 组件不可见。如果需要从 COM 访问此程序集中的类型
//请将此类型的 ComVisible 特性设置为 true。
[assembly: ComVisible(false)]

// 如果此项目向 COM 公开，则下列 GUID 用于类型库的 ID
[assembly: Guid("2c798633-6cff-477d-87da-cdbd4755cd2e")]

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

