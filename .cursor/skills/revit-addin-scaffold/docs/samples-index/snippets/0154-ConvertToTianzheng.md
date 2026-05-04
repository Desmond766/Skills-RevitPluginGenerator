# Sample Snippet: ConvertToTianzheng

Source project: `existingCodes\梁涛插件源代码\7.CAD插件\ConvertToTianzheng\ConvertToTianzheng`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertToTianzheng
{
    // 连接墙门洞两边的墙线
    public class Command
    {
        //[CommandMethod("CWL")]
        public void ConnectWallLine()
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            Editor ed = doc.Editor;

            //// 提示用户选择一个实体
            //PromptEntityOptions options2 = new PromptEntityOptions("\n请选择墙图层");

            //// 获取用户选择的实体
            //PromptEntityResult result2 = ed.GetEntity(options2);

            //// 提示用户选择一个实体
            //PromptEntityOptions options3 = new PromptEntityOptions("\n请选择墙图层");

            //// 获取用户选择的实体
            //PromptEntityResult result3 = ed.GetEntity(options3);
            //using (Transaction tr = doc.Database.TransactionManager.StartTransaction())
            //{
            //    Line lineSel1 = tr.GetObject(result2.ObjectId, OpenMode.ForRead) as Line;
            //    Line lineSel2 = tr.GetObject(result3.ObjectId, OpenMode.ForRead) as Line;
            //    var p0 = lineSel1.StartPoint;
            //    var p1 = lineSel1.EndPoint;
            //    var p2 = lineSel2.StartPoint;
            //    var p3 = lineSel2.EndPoint;
            //    ed.WriteMessage($"\nIsPerpendicular:{IsPerpendicular(p0, p1, p2)} + ‘ ’+ {IsPerpendicular(p0, p1, p3)}");
            //    ed.WriteMessage($"\nCanFormRectangle:{CanFormRectangle(lineSel1, lineSel2)}");
            //    ed.WriteMessage($"\nAreLinesParallel:{AreLinesParallel(lineSel1, lineSel2)}");
            //    ed.WriteMessage($"\nDistance:{Distance(lineSel1, lineSel2)}");

            //    tr.Commit();
            //}
            //return;

            string layerName = "";

            // 符合长度的线段集合
            List<Line> lines = new List<Line>();

            // 提示用户选择一个实体
            PromptEntityOptions options = new PromptEntityOptions("\n请选择墙图层");

            // 获取用户选择的实体
            PromptEntityResult result = ed.GetEntity(options);
            if (result.Status != PromptStatus.OK)
            {
                ed.WriteMessage("\n未选择或操作取消.");
                return;
            }

            // 获取选中的实体
            ObjectId entityId = result.ObjectId;

            using (Transaction tr = doc.Database.TransactionManager.StartTransaction())
            {
                Entity entitySel = tr.GetObject(entityId, OpenMode.ForRead) as Entity;
                layerName = entitySel.Layer;

                // 获取块表记录（模型空间）
                BlockTable blockTable = (BlockTable)tr.GetObject(db.BlockTableId, OpenMode.ForRead);
                BlockTableRecord btr = (BlockTableRecord)tr.GetObject(blockTable[BlockTableRecord.ModelSpace], OpenMode.ForRead);

                // 遍历模型空间中的所有实体
                foreach (ObjectId objId in btr)
                {
                    Entity entity = (Entity)tr.GetObject(objId, OpenMode.ForRead);

                    // 检查实体是否为直线且属于指定图层
                    if (entity is Line line && line.Layer == layerName)
                    {
                        // 过滤长度小于等于 400 的直线
                        double length = line.Length;
// ... truncated ...
```

## Command2.cs

```csharp
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConvertToTianzheng
{
    public class Command2
    {
        [CommandMethod("CWL2")]
        public void ConnectWallLine2()
        {

            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            Editor ed = doc.Editor;

            #region 测试
            //try
            //{
            //    // 1. 选择目标直线
            //    PromptEntityOptions lineOpts = new PromptEntityOptions("\n请选择一条直线:");
            //    lineOpts.SetRejectMessage("\n请选择一个直线对象。");
            //    lineOpts.AddAllowedClass(typeof(Line), true);
            //    PromptEntityResult lineResult = ed.GetEntity(lineOpts);
            //    if (lineResult.Status != PromptStatus.OK) return;

            //    // 2. 选择目标块参照
            //    PromptEntityOptions blkOpts = new PromptEntityOptions("\n请选择一个块参照:");
            //    blkOpts.SetRejectMessage("\n请选择一个块参照对象。");
            //    blkOpts.AddAllowedClass(typeof(BlockReference), true);
            //    PromptEntityResult blkResult = ed.GetEntity(blkOpts);
            //    if (blkResult.Status != PromptStatus.OK) return;

            //    using (Transaction trans = db.TransactionManager.StartTransaction())
            //    {
            //        // 获取选中的直线
            //        Line selectedLine = trans.GetObject(lineResult.ObjectId, OpenMode.ForRead) as Line;
            //        // 获取选中的块参照
            //        BlockReference blkRef = trans.GetObject(blkResult.ObjectId, OpenMode.ForRead) as BlockReference;

            //        if (selectedLine != null && blkRef != null)
            //        {
            //            // 3. 调用核心判断函数
            //            bool doIntersect = DoesLineIntersectBlockReference(selectedLine, blkRef, trans);

            //            if (doIntersect)
            //            {
            //                ed.WriteMessage("\n直线与块参照存在相交部分！");
            //            }
            //            else
            //            {
            //                ed.WriteMessage("\n直线与块参照不相交。");
            //            }
            //        }
            //        trans.Commit();
            //    }
            //}
            //catch (System.Exception ex)
            //{
            //    ed.WriteMessage($"\n错误: {ex.Message}");
            //}
            //return;
            #endregion

            //string wallLayerName = "";
            //string doorLayerName = "";
            // 门块参照图层名称集合
            List<string> doorLayerNames = new List<string>();
            // 墙线图层名称集合
            List<string> wallLayerNames = new List<string>();

            // 符合长度的线段集合
            // 不过滤长度
            List<Line> lines = new List<Line>();
            // 长度小于等于400
            List<Line> linesLT400 = new List<Line>();


            // 提示用户选择多个墙线图层
// ... truncated ...
```

## Command3.cs

```csharp
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exception = System.Exception;

namespace ConvertToTianzheng
{
    public class Command3
    {
        // 测试用
        [CommandMethod("TSI")]
        public void CheckLineAndBlockOverlap()
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            Editor ed = doc.Editor;

            try
            {
                // 1. 选择一条直线 (Line)
                PromptEntityOptions lineOptions = new PromptEntityOptions("\n请选择一条直线: ");
                lineOptions.SetRejectMessage("\n请选择直线实体。");
                lineOptions.AddAllowedClass(typeof(Line), false);
                PromptEntityResult lineResult = ed.GetEntity(lineOptions);
                if (lineResult.Status != PromptStatus.OK) return;

                // 2. 选择一个块参照（例如门的块参照）
                PromptEntityOptions blockOptions = new PromptEntityOptions("\n请选择一个块参照（门）: ");
                blockOptions.SetRejectMessage("\n请选择块参照实体。");
                blockOptions.AddAllowedClass(typeof(BlockReference), false);
                PromptEntityResult blockResult = ed.GetEntity(blockOptions);
                if (blockResult.Status != PromptStatus.OK) return;

// ... truncated ...
```

