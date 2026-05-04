# Sample Snippet: DWGTools

Source project: `existingCodes\梁涛插件源代码\7.CAD插件\DWGTools\DWGTools`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;

namespace DWGTools
{
    public class Command
    {
        [CommandMethod("VPPC")]
        public void GetVerPointLocationConduitCount() // 获取与竖向点位相交的线管数量并创建文本 郭
        {
            // 获取当前文档和编辑器
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Editor ed = doc.Editor;
            Database db = doc.Database;

            // 块参照图层名称集合
            HashSet<string> layerNames = new HashSet<string>();
            // 块参照名称集合
            HashSet<string> blockNames = new HashSet<string>();
            // 多段线图层集合
            HashSet<string> polylineLayerNames = new HashSet<string>();

            // 提示用户选择多个块参照
            PromptSelectionOptions promptOptions = new PromptSelectionOptions();
            promptOptions.MessageForAdding = "\n请选择一个或多个不同竖向电气点位的块参照(按下回车键以完成选择)";
            promptOptions.AllowDuplicates = false;  // 不允许重复选择

            // 获取用户选择的实体
            PromptSelectionResult selectionResult = ed.GetSelection(promptOptions);

            // 如果用户选择了实体
            if (selectionResult.Status == PromptStatus.OK)
            {
                SelectionSet selectedSet = selectionResult.Value;

                // 开始事务，遍历选择集中的所有实体
                using (Transaction tr = doc.TransactionManager.StartTransaction())
                {
                    foreach (ObjectId objId in selectedSet.GetObjectIds())
                    {
                        // 获取选中实体
                        Entity entity = (Entity)tr.GetObject(objId, OpenMode.ForRead);

                        // 判断是否为块参照
                        if (entity is BlockReference blockRef)
                        {
                            // 获取块参照的块名称
                            string blockName = blockRef.Name;

                            blockNames.Add(blockName);
                            layerNames.Add(blockRef.Layer);
                        }
                    }

                    // 提交事务
                    tr.Commit();
                }
            }
            else
            {
                ed.WriteMessage("\n没有选择任何实体或选择操作被取消");
                return;
            }

            // 提示用户选择多条多段线，获取多段线所在图层
            PromptSelectionOptions promptOptions2 = new PromptSelectionOptions();
            promptOptions2.MessageForAdding = "\n请选择一个或多个不同图层的多段线(按下回车键以完成选择)";
            promptOptions2.AllowDuplicates = false;  // 不允许重复选择

            // 获取用户选择的实体
            PromptSelectionResult selectionResult2 = ed.GetSelection(promptOptions2);

            // 如果用户选择了实体
            if (selectionResult2.Status == PromptStatus.OK)
            {
                SelectionSet selectedSet = selectionResult2.Value;

                // 开始事务，遍历选择集中的所有实体
                using (Transaction tr = doc.TransactionManager.StartTransaction())
                {
                    foreach (ObjectId objId in selectedSet.GetObjectIds())
                    {
// ... truncated ...
```

## CreateBeamWidthHeightText.cs

```csharp
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.GraphicsInterface;
using Autodesk.AutoCAD.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWGTools
{
    public class CreateBeamWidthHeightText // 批量创建标注文字对应的梁宽高文字 谢
    {
        [CommandMethod("CBWH")]
        public void CreateBeamWidthHeightInfo()
        {
            var doc = Application.DocumentManager.MdiActiveDocument;
            var ed = doc.Editor;
            Database db = doc.Database;

            List<LabelInfo> labelInfos = new List<LabelInfo>();

            // 标注文字
            List<DBText> llDBtexts = new List<DBText>();
            string llLayer;

            // 标注线
            List<Line> redLines = new List<Line>();
            string redLayer;

            // 梁宽高文字
            List<DBText> beamTexts = new List<DBText>();
            DBText beamDBText;
            string beamTextLayer;

            // 梁线
            List<Line> beamLines = new List<Line>();
            string beamLineLayer;

            // 1. 标注文字
            var pEntOpts = new PromptEntityOptions("\n请选择一个标注文字");
            var pEntRes = ed.GetEntity(pEntOpts);
            if (pEntRes.Status != PromptStatus.OK) return;

            // 2. 红线
            var pEntOpts2 = new PromptEntityOptions("\n请选择标注旁的直线");
            var pEntRes2 = ed.GetEntity(pEntOpts2);
            if (pEntRes2.Status != PromptStatus.OK) return;

            // 3. 梁宽高文字
            var pEntOpts3 = new PromptEntityOptions("\n请选择任意已存在的梁宽高文字");
            pEntOpts3.SetRejectMessage("\n必须选择文字！");
            pEntOpts3.AddAllowedClass(typeof(DBText), true);
            var pEntRes3 = ed.GetEntity(pEntOpts3);
            if (pEntRes3.Status != PromptStatus.OK) return;

            // 4.梁图层
            var pEntOpts4 = new PromptEntityOptions("\n请选择梁图层");
            var pEntRes4 = ed.GetEntity(pEntOpts4);
            if (pEntRes4.Status != PromptStatus.OK) return;

            using (Transaction tr = doc.TransactionManager.StartTransaction())
            {
                Entity llText = tr.GetObject(pEntRes.ObjectId, OpenMode.ForRead) as Entity;
                llLayer = llText.Layer;

                Entity redLine = tr.GetObject(pEntRes2.ObjectId, OpenMode.ForRead) as Entity;
                redLayer = redLine.Layer;

                Entity beamText = tr.GetObject(pEntRes3.ObjectId, OpenMode.ForRead) as Entity;
                beamTextLayer = beamText.Layer;
                beamDBText = beamText as DBText;
                //ed.WriteMessage($"\n{beamDBText.Position}");

                Entity beamLine = tr.GetObject(pEntRes4.ObjectId, OpenMode.ForRead) as Entity;
                beamLineLayer = beamLine.Layer;

                BlockTable bt = tr.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;
                BlockTableRecord btr = (BlockTableRecord)tr.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForRead);

                // 1.获取梁标注文字、对应红线、梁宽高文字、梁直线信息
                foreach (ObjectId objId in btr)
                {
                    var obj = tr.GetObject(objId, OpenMode.ForRead);
                    if (obj is DBText text1 && text1.Layer == llLayer)
                    {
                        llDBtexts.Add(text1);
// ... truncated ...
```

