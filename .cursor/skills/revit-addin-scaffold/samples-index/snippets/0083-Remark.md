# Sample Snippet: Remark

Source project: `existingCodes\品成插件源代码\通用\Remark\Remark\Remark`

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

namespace Remark
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
            Selection sel = uiapp.ActiveUIDocument.Selection;
            OverrideGraphicSettings setting = GetRemarkSetting(doc);

            // Remark
            while (true)
            {
                try
                {
                    using (Transaction t = new Transaction(doc, "BimtransArchiTools.Remark"))
                    {
                        t.Start();
                        doc.ActiveView.SetElementOverrides(sel.PickObject(ObjectType.Element).ElementId, setting);
                        t.Commit();
                    }
                }
                catch
                {
                    TaskDialog.Show("Revit", "取消操作，程序结束！");
                    break;
                }
            }

            return Result.Succeeded;
        }

        #region 获得标记参数设置
        /// <summary>
        /// 获得标记参数设置
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        private OverrideGraphicSettings GetRemarkSetting(Document doc)
        {
            // 得到一个实体填充图案
            ElementId fillPatternId = ElementId.InvalidElementId;
            FilteredElementCollector coll = new FilteredElementCollector(doc);
            coll.OfClass(typeof(FillPatternElement));
            foreach (Element e in coll.ToElements())
            {
                FillPatternElement fe = e as FillPatternElement;
                if (fe.GetFillPattern().IsSolidFill)
                {
                    fillPatternId = e.Id;
                    break;
                }
            }
            // 设置颜色和填充图案
            OverrideGraphicSettings setting = new OverrideGraphicSettings();
            // 截面填充图案
            //setting.SetSurfaceTransparency(0);
            //setting.SetCutFillColor(new Color(255, 0, 0));
            //setting.SetCutFillPatternId(fillPatternId);
            // 表面填充图案
            setting.SetProjectionFillColor(new Color(255, 255, 0));
            setting.SetProjectionFillPatternId(fillPatternId);
            return setting;
        }
        #endregion

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
[assembly: AssemblyTitle("Remark")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyProduct("Remark")]
[assembly: AssemblyCopyright("Copyright © Microsoft 2019")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// 将 ComVisible 设置为 false 会使此程序集中的类型
//对 COM 组件不可见。如果需要从 COM 访问此程序集中的类型
//请将此类型的 ComVisible 特性设置为 true。
[assembly: ComVisible(false)]

// 如果此项目向 COM 公开，则下列 GUID 用于类型库的 ID
[assembly: Guid("7419681e-33dd-4987-aa23-607db4df040c")]

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

