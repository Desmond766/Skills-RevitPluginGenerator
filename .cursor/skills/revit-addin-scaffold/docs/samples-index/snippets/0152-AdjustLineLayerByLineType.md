# Sample Snippet: AdjustLineLayerByLineType

Source project: `existingCodes\梁涛插件源代码\7.CAD插件\AdjustLineLayerByLineType\AdjustLineLayerByLineType`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## AdjustLineLayerByLineType.cs

```csharp
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustLineLayerByLineType
{
    public class AdjustLineLayerByLineType
    {
        [CommandMethod("ALBLT")]
        public void ChangeLineLayerByLineType()
        {
            // 活动文档
            Document doc = Application.DocumentManager.MdiActiveDocument;
            // 数据库
            Database db = doc.Database;
            // 编辑器
            Editor ed = doc.Editor;

            PromptEntityOptions entityOptions = new PromptEntityOptions("\n选择一条线段");
            entityOptions.AllowNone = false;
            entityOptions.SetRejectMessage("\n只能选择一条线段");
            entityOptions.AddAllowedClass(typeof(Line), true);
            entityOptions.AddAllowedClass(typeof(Polyline), true);
            var eResult = ed.GetEntity(entityOptions);
            if (eResult.Status != PromptStatus.OK)
            {
                ed.WriteMessage("\n用户取消操作");
                return;
            }
            //

            // 提示用户框选范围
            //PromptSelectionOptions options = new PromptSelectionOptions
            //{
            //    MessageForAdding = "选择一条线段: "
            //};

            //// 捕获用户的选择
            //PromptSelectionResult result = ed.GetSelection(options);

            //if (result.Status != PromptStatus.OK)
            //{
            //    ed.WriteMessage("\n未选择任何线段或操作取消.");
            //    return;
            //}

            //// 获取选择的对象
            //SelectionSet selectionSet = result.Value;

            // 打开数据库进行处理
            using (Transaction tr = doc.Database.TransactionManager.StartTransaction())
            {
                Entity selectedEntity = tr.GetObject(eResult.ObjectId, OpenMode.ForRead) as Entity;
                //ed.WriteMessage($"\n图层名称:{selectedEntity.Layer}线型:{selectedEntity.Linetype}");

                string lineType = selectedEntity.Linetype;
                //foreach (SelectedObject selObj in selectionSet)
                //{
                //    if (selObj != null)
                //    {
                //        Entity entity = tr.GetObject(selObj.ObjectId, OpenMode.ForRead) as Entity;

                //        if (entity != null && (entity is Polyline || entity is Line))
                //        {
                //            lineType = entity.Linetype;
                //            break;
                //        }
                //        else
                //        {
                //            ed.WriteMessage("\n所选对象不是线段");
                //            return;
                //        }
                //    }
                //}
                ed.WriteMessage($"\n所选线段线型为：{lineType}");

                // 新图层的名称
                PromptStringOptions stringOptions = new PromptStringOptions("\n输入一个新的图层名称");
                stringOptions.AllowSpaces = true;
                var inputString = ed.GetString(stringOptions);
                if (inputString.Status != PromptStatus.OK)
                {
                    ed.WriteMessage("\n已取消操作");
                    return;
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
[assembly: AssemblyTitle("AdjustLineLayerByLineType")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("AdjustLineLayerByLineType")]
[assembly: AssemblyCopyright("Copyright ©  2025")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// 将 ComVisible 设置为 false 会使此程序集中的类型
//对 COM 组件不可见。如果需要从 COM 访问此程序集中的类型
//请将此类型的 ComVisible 特性设置为 true。
[assembly: ComVisible(false)]

// 如果此项目向 COM 公开，则下列 GUID 用于类型库的 ID
[assembly: Guid("566309ad-4018-4967-a82d-ed3eb3ec89f8")]

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

