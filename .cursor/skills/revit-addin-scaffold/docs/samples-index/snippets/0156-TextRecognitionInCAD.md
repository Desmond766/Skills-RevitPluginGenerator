# Sample Snippet: TextRecognitionInCAD

Source project: `existingCodes\梁涛插件源代码\7.CAD插件\TextRecognitionInCAD\TextRecognitionInCAD`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## AdskCommandHandler.cs

```csharp
using Autodesk.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TextRecognitionInCAD
{
    public class AdskCommandHandler : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            RibbonButton ribBtn = parameter as RibbonButton;
            if (ribBtn != null)
            {
                //execute the command 
                Autodesk.AutoCAD.ApplicationServices.Application
                  .DocumentManager.MdiActiveDocument
                  .SendStringToExecute(
                     (string)ribBtn.CommandParameter, true, false, true);
            }
        }
    }
}

```

## AddOrModifyLayerOfConduit.cs

```csharp
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Colors;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Application = Autodesk.AutoCAD.ApplicationServices.Application;
using Line = Autodesk.AutoCAD.DatabaseServices.Line;

namespace TextRecognitionInCAD
{
    // 根据信息更改直线所在图层或新增相同直线
    public class AddOrModifyLayerOfConduit
    {
        /* 1.选择块图层
         * 2.选择线图层
         * 3.输入数字
         * 4.获取块图层所有块，线图层所有直线
         * 5.获取与线图层有相交的块图层，获取块的具体信息（N）
         * 6.若块信息为两数字（如5+2），则距直线20mm位置黏贴一条相同直线
         */
        [CommandMethod("AOML")]
        public void AddOrModifyLayer()
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            Editor ed = doc.Editor;

            // 块名称
            string blockName = "";
            // 块图层名称
            string blockLayerName = "";
            // 线图层名称
            string lineLayerName = "";
            // 线信息
            List<LineInfo> lineInfos = new List<LineInfo>();
            // 指定图层块集合
            List<BlockReference> blocks = new List<BlockReference>();
            // 用户输入线条数
            double number = 0;

            

            // 提示用户选择一个实体
            PromptEntityOptions options = new PromptEntityOptions("\n请选择一个数字块参照");

            // 获取用户选择的实体
            PromptEntityResult result = ed.GetEntity(options);
            if (result.Status != PromptStatus.OK)
            {
                ed.WriteMessage("\n未选择或操作取消.");
                return;
            }

            // 提示用户选择一个实体
            PromptEntityOptions options2 = new PromptEntityOptions("\n请选择线图层");

            // 获取用户选择的实体
            PromptEntityResult result2 = ed.GetEntity(options2);
            if (result2.Status != PromptStatus.OK)
            {
                ed.WriteMessage("\n未选择或操作取消.");
                return;
            }


            // 配置输入选项
            PromptDoubleOptions optionsT = new PromptDoubleOptions("\n请输入一个数字: ");
            optionsT.AllowNegative = false;   // 是否允许负数
            optionsT.AllowZero = false;        // 是否允许零
            optionsT.DefaultValue = 5;      // 默认值（按 Enter 时使用）

            // 获取用户输入
            PromptDoubleResult resultT = ed.GetDouble(optionsT);

            // 处理结果
            if (resultT.Status == PromptStatus.OK)
            {
                number = resultT.Value;
                ed.WriteMessage($"\n您输入的数字是: {number}");
            }
            else
// ... truncated ...
```

