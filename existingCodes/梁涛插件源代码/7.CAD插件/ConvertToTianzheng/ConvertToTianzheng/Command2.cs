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
            PromptSelectionOptions wallOptions = new PromptSelectionOptions();
            wallOptions.MessageForAdding = "\n请选择一个或多个不同墙线图层";
            wallOptions.AllowDuplicates = false;  // 不允许重复选择

            // 获取用户选择的实体
            PromptSelectionResult wallResult = ed.GetSelection(wallOptions);

            // 如果用户选择了实体
            if (wallResult.Status == PromptStatus.OK)
            {
                SelectionSet selectedSet = wallResult.Value;
                using (Transaction tr = doc.TransactionManager.StartTransaction())
                {
                    // 获取墙线所在图层的名称
                    foreach (ObjectId objId in selectedSet.GetObjectIds())
                    {
                        Entity entity = (Entity)tr.GetObject(objId, OpenMode.ForRead);
                        wallLayerNames.Add(entity.Layer);
                    }
                    tr.Commit();
                }
                wallLayerNames.Distinct();
            }
            else
            {
                ed.WriteMessage("\n未选择任何墙线，已取消");
                return;
            }
            /* 单选墙线图层
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
                Entity entity = tr.GetObject(entityId, OpenMode.ForRead) as Entity;
                //if (entity is Line line)
                //{
                //    ed.WriteMessage($"\n{line.Angle}");
                //}
                wallLayerName = entity.Layer;
                tr.Commit();
            }
            */

            // 块参照图层名称集合
            //HashSet<string> layerNames = new HashSet<string>();
            // 块参照名称集合
            HashSet<string> blockNames = new HashSet<string>();

            // 提示用户选择多个块参照
            PromptSelectionOptions promptOptions = new PromptSelectionOptions();
            promptOptions.MessageForAdding = "\n请选择一个或多个不同Door的块参照";
            promptOptions.AllowDuplicates = false;  // 不允许重复选择

            // 获取用户选择的实体
            PromptSelectionResult selectionResult = ed.GetSelection(promptOptions);

            int succeedCount = 0;

            // 如果用户选择了实体
            if (selectionResult.Status == PromptStatus.OK)
            {
                SelectionSet selectedSet = selectionResult.Value;
                ObjectId idd = new ObjectId();
                // 开始事务，遍历选择集中的所有实体
                using (Transaction tr = doc.TransactionManager.StartTransaction())
                {
                    //Entity line3 = tr.GetObject(selectedSet.GetObjectIds()[0], OpenMode.ForRead) as Entity;
                    //Entity line4 = tr.GetObject(selectedSet.GetObjectIds()[1], OpenMode.ForRead) as Entity;

                    //Point3dCollection collection = new Point3dCollection();
                    //line3.IntersectWith(line4, Intersect.OnBothOperands, collection, IntPtr.Zero, IntPtr.Zero);
                    //ed.WriteMessage($"\n{collection.Count}\n{line3.Id}\n{line4.Id}");
                    //return;

                    // 1.获取选中门块参照的名称
                    foreach (ObjectId objId in selectedSet.GetObjectIds())
                    {
                        // 获取选中实体
                        Entity entity = (Entity)tr.GetObject(objId, OpenMode.ForRead);
                        idd = objId;
                        // 判断是否为块参照
                        if (entity is BlockReference blockRef)
                        {

                            // 递归查找真实块名
                            string realBlockName = GetRealBlockName(blockRef, tr);
                            //ed.WriteMessage("\n" + realBlockName);

                            // 获取块参照的块名称(可能是匿名块名称)
                            string blockName = blockRef.Name;
                            //ed.WriteMessage($"\n{blockRef.Rotation}");
                            blockNames.Add(realBlockName);

                            if (blockRef == null)
                                return;
                            //doorLayerName = blockRef.Layer;
                            doorLayerNames.Add(blockRef.Layer);
                        }
                    }
                    // 提交事务
                    tr.Commit();
                }

                // 2.炸开块中存在门块参照的块参照
                using (Transaction tr = doc.TransactionManager.StartTransaction())
                {
                    BlockTable blockTable = (BlockTable)tr.GetObject(db.BlockTableId, OpenMode.ForWrite);
                    BlockTableRecord btr = (BlockTableRecord)tr.GetObject(blockTable[BlockTableRecord.ModelSpace], OpenMode.ForWrite);
                    foreach (ObjectId objId in btr)
                    {
                        Entity entity = tr.GetObject(objId, OpenMode.ForWrite) as Entity;

                        if (entity is BlockReference blockRef && !doorLayerNames.Contains(blockRef.Layer))
                        {
                            // 打开图层表
                            using (LayerTable lt = (LayerTable)tr.GetObject(db.LayerTableId, OpenMode.ForRead))
                            {
                                if (lt.Has(blockRef.Layer))
                                {
                                    ObjectId layerId = lt[blockRef.Layer];
                                    LayerTableRecord ltr = (LayerTableRecord)tr.GetObject(layerId, OpenMode.ForWrite);
                                    // 关键步骤：将图层的锁定状态设置为false（解锁）
                                    ltr.IsLocked = false;
                                }
                            }
                            // 获取块定义（BlockTableRecord）
                            BlockTableRecord blockDef = (BlockTableRecord)tr.GetObject(blockRef.BlockTableRecord, OpenMode.ForWrite);
                            foreach (ObjectId blockObjId in blockDef)
                            {
                                // 打开图层表
                                using (LayerTable lt = (LayerTable)tr.GetObject(db.LayerTableId, OpenMode.ForRead))
                                {
                                    Entity be = tr.GetObject(blockObjId, OpenMode.ForRead) as Entity;
                                    if (lt.Has(be.Layer))
                                    {
                                        ObjectId layerId = lt[be.Layer];
                                        LayerTableRecord ltr = (LayerTableRecord)tr.GetObject(layerId, OpenMode.ForWrite);
                                        // 关键步骤：将图层的锁定状态设置为false（解锁）
                                        ltr.IsLocked = false;
                                    }
                                }
                                Entity blockEntity = tr.GetObject(blockObjId, OpenMode.ForWrite) as Entity;
                                if (blockEntity is BlockReference blockReference && doorLayerNames.Contains(blockReference.Layer))
                                {

                                    // 炸开块参照
                                    blockRef.ExplodeToOwnerSpace();
                                    blockRef.Erase();
                                    break;
                                }
                            }
                        }
                    }
                    tr.Commit();
                }
                
                // 3.遍历块记录表，获取所有选中图层中的墙直线
                using (Transaction tr = doc.TransactionManager.StartTransaction())
                {
                    BlockTable blockTable = (BlockTable)tr.GetObject(db.BlockTableId, OpenMode.ForWrite);
                    BlockTableRecord btr = (BlockTableRecord)tr.GetObject(blockTable[BlockTableRecord.ModelSpace], OpenMode.ForWrite);


                    foreach (ObjectId objId in btr)
                    {
                        Entity entity = (Entity)tr.GetObject(objId, OpenMode.ForRead);
                        // 检查实体是否为直线且属于指定图层
                        if (entity is Line line && wallLayerNames.Contains(line.Layer))
                        {
                            // 过滤长度小于等于 400 的直线
                            double length = line.Length;
                            lines.Add(line);
                            if (length <= 400)
                            {
                                //double angle = line.Angle;
                                //Point3d p0 = line.StartPoint;
                                //Point3d p1 = line.EndPoint;
                                //Point3d centerPoint = new Point3d((p0.X + p1.X) / 2, (p0.Y + p1.Y) / 2, (p0.Z + p1.Z) / 2);
                                //lineInfos.Add(new LineInfo() { Line = line, Angle = angle, CenterPoint = centerPoint });
                                linesLT400.Add(line);
                            }
                        }
                        else if (entity is Polyline polyline && wallLayerNames.Contains(polyline.Layer))
                        {
                            var poLines = GetPolylineLines(polyline, null);
                            lines.AddRange(poLines);
                            linesLT400.AddRange(poLines.Where(pl => pl.Length <= 400));
                        }
                        else if (entity is BlockReference blockRef)
                        {
                            var blockRefTransform = blockRef.BlockTransform;
                            // 获取块定义（BlockTableRecord）
                            BlockTableRecord blockDef = (BlockTableRecord)tr.GetObject(blockRef.BlockTableRecord, OpenMode.ForRead);
                            // 遍历块参照中的所有元素，提取其中的文本
                            foreach (ObjectId blockObjId in blockDef)
                            {
                                Entity blockEntity = tr.GetObject(blockObjId, OpenMode.ForRead) as Entity;
                                if (blockEntity is Line blockLine && wallLayerNames.Contains(blockLine.Layer))
                                {
                                    var p0 = blockLine.StartPoint;
                                    var p1 = blockLine.EndPoint;
                                    p0 = p0.TransformBy(blockRefTransform);
                                    p1 = p1.TransformBy(blockRefTransform);
                                    Line newLine = new Line(p0, p1);
                                    newLine.Layer = blockLine.Layer;
                                    lines.Add(newLine);
                                    if (blockLine.Length <= 400)
                                    {
                                        //double angle = newLine.Angle;
                                        //Point3d centerPoint = new Point3d((p0.X + p1.X) / 2, (p0.Y + p1.Y) / 2, (p0.Z + p1.Z) / 2);
                                        //lineInfos.Add(new LineInfo() { Line = newLine, Angle = angle, CenterPoint = centerPoint });
                                        linesLT400.Add(newLine);
                                    }
                                }
                                else if (blockEntity is Polyline blockPolyLine && wallLayerNames.Contains(blockPolyLine.Layer))
                                {
                                    var blockPoLines = GetPolylineLines(blockPolyLine, blockRefTransform);
                                    lines.AddRange(blockPoLines);
                                    linesLT400.AddRange(blockPoLines.Where(blpl => blpl.Length <= 400));
                                }
                            }
                        }
                    }
                    tr.Commit();
                }

                using (Transaction tr = doc.TransactionManager.StartTransaction())
                {
                    BlockTable blockTable = (BlockTable)tr.GetObject(db.BlockTableId, OpenMode.ForWrite);
                    BlockTableRecord btr = (BlockTableRecord)tr.GetObject(blockTable[BlockTableRecord.ModelSpace], OpenMode.ForWrite);
                    // 3.遍历块记录表，记录CAD图中所有的门块参照(包括在块参照中的门块参照)
                    List<BlockReference> blockReferences = new List<BlockReference>();
                    foreach (ObjectId objId in btr)
                    {
                        Entity entity = tr.GetObject(objId, OpenMode.ForRead) as Entity;

                        if (entity is BlockReference doorBlockRef && doorLayerNames.Contains(doorBlockRef.Layer)/* && blockNames.Contains(GetRealBlockName(blockRef, tr))*/)
                        {
                            blockReferences.Add(doorBlockRef);
                        }
                        //else if (entity is BlockReference blockRef)
                        //{
                        //    var blockRefTransform = blockRef.BlockTransform;
                        //    // 获取块定义（BlockTableRecord）
                        //    BlockTableRecord blockDef = (BlockTableRecord)tr.GetObject(blockRef.BlockTableRecord, OpenMode.ForRead);
                        //    // 遍历块参照中的所有元素，提取其中的门块参照
                        //    foreach (ObjectId blockObjId in blockDef)
                        //    {
                        //        Entity blockEntity = tr.GetObject(blockObjId, OpenMode.ForRead) as Entity;
                        //        if (blockEntity is BlockReference blockReference && blockReference.Layer == doorLayerName)
                        //        {
                        //            //blockReference.TransformBy(blockRefTransform);
                        //            blockReferences.Add(blockReference);
                        //        }
                        //    }
                        //}
                    }
                    // 4.在两墙线之间生成垂直的墙线
                    foreach (var blockRef in blockReferences)
                    {
                        // 获取块参照坐标转换
                        var blockRefTransform = blockRef.BlockTransform;

                        //var filterLines = lineInfos.Where(l => Math.Abs(GetAngle(l.Line, blockRef) - Math.PI / 2) < 0.0001).OrderBy(x => x.CenterPoint.DistanceTo(blockRef.Position)).ToList();
                        var filterLines = new List<Line>();
                        // ed.WriteMessage("\nlinesLT400:" + linesLT400.Count(l => Math.Abs(GetAngle(l, blockRef) - Math.PI / 2) <= 0.0001));
                        foreach (var line in linesLT400)
                        {
                            // REMARK: 25.12.4 将线与门块参照的误差更改至 +- 15度
                            //if (Math.Abs(GetAngle(line, blockRef) - Math.PI / 2) > 0.0001) continue;
                            if (Math.Abs(GetAngle(line, blockRef) - Math.PI / 2) >= (15.0 / 180) * Math.PI) continue;
                            Point3dCollection collection = new Point3dCollection();
                            // HACK: 25.10.11与块参照与直线有重合部分但显示无碰撞
                            line.IntersectWith(blockRef, Intersect.OnBothOperands, collection, IntPtr.Zero, IntPtr.Zero);
                            bool subEntityIntersect = DoesLineIntersectBlockReference(line, blockRef, tr, ed);
                            // ed.WriteMessage("\ncollection:" + collection.Count);
                            // 防止加入重合的直线导致重复生成
                            if ((collection.Count > 0 || subEntityIntersect) && !filterLines.Any(fl => fl.Length == line.Length && (fl.StartPoint.DistanceTo(line.StartPoint) < 0.1 || fl.StartPoint.DistanceTo(line.EndPoint) < 0.1))) filterLines.Add(line);
                            //else // HACK:若未找到则将块参照内的直线或多段线分解为直线再在两端各延长5mm后与原Line继续进行碰撞判断
                            //{
                            //    bool breakBlockRefIntersect = ExtensionLineToIntersect(tr, blockRef, line);
                            //    if (breakBlockRefIntersect && !filterLines.Any(fl => fl.Length == line.Length && (fl.StartPoint.DistanceTo(line.StartPoint) < 0.1 || fl.StartPoint.DistanceTo(line.EndPoint) < 0.1))) filterLines.Add(line);
                            //}
                        }
                        if (idd == blockRef.Id)
                        {
                            ed.WriteMessage($"\n{filterLines.Count}");
                        }
                        if (filterLines.Count() == 2 /*&& filterLines[0].Line.Length == filterLines[1].Line.Length*/)
                        {
                            Line line1 = filterLines[0];
                            Line line2 = filterLines[1];
                            Point3d firstStaP = new Point3d();
                            Point3d secStaP = new Point3d();

                            Point3d firstEndP = new Point3d();
                            Point3d secEndP = new Point3d();

                            if (Math.Abs(line1.Length - line2.Length) < 0.0001)
                            {
                                firstStaP = line1.StartPoint;
                                secStaP = line1.EndPoint;

                                firstEndP = line1.StartPoint.DistanceTo(line2.StartPoint) < line1.StartPoint.DistanceTo(line2.EndPoint) ? line2.StartPoint : line2.EndPoint;
                                secEndP = firstEndP == line2.StartPoint ? line2.EndPoint : line2.StartPoint;
                            }
                            else
                            {
                                Line longLine = line1.Length > line2.Length ? line1 : line2;
                                Line shortLine = line1.Length < line2.Length ? line1 : line2;
                                var findLines = new List<Line>();
                                foreach (var line in lines)
                                {
                                    if (line.Id == longLine.Id || Math.Abs(GetAngle(line, longLine) - Math.PI / 2) > 0.0001) continue;
                                    Point3dCollection collection = new Point3dCollection();
                                    longLine.IntersectWith(line, Intersect.OnBothOperands, collection, IntPtr.Zero, IntPtr.Zero);
                                    if (collection.Count > 0) findLines.Add(line);
                                }
                                if (findLines.Count != 2) continue;
                                Point3dCollection collection1 = new Point3dCollection();
                                Point3dCollection collection2 = new Point3dCollection();
                                shortLine.IntersectWith(findLines[0], Intersect.ExtendBoth, collection1, IntPtr.Zero, IntPtr.Zero);
                                shortLine.IntersectWith(findLines[1], Intersect.ExtendBoth, collection2, IntPtr.Zero, IntPtr.Zero);
                                if (collection1.Count == 0 || collection2.Count == 0) continue;

                                firstStaP = collection1[0];
                                secStaP = collection2[0];

                                firstEndP = firstStaP.DistanceTo(longLine.StartPoint) < firstStaP.DistanceTo(longLine.EndPoint) ? longLine.StartPoint : longLine.EndPoint;
                                secEndP = firstEndP == longLine.StartPoint ? longLine.EndPoint : longLine.StartPoint;

                                // 两边长度不一致时在短的一侧需额外添加一条墙线
                                Line newLine3 = new Line(firstStaP, secStaP);
                                btr.AppendEntity(newLine3);
                                tr.AddNewlyCreatedDBObject(newLine3, true);
                                newLine3.UpgradeOpen();
                                //newLine3.Layer = wallLayerName;
                                newLine3.Layer = line1.Layer;
                            }

                            // 将直线添加到模型空间
                            Line newLine1 = new Line(firstStaP, firstEndP);
                            btr.AppendEntity(newLine1);
                            tr.AddNewlyCreatedDBObject(newLine1, true);
                            newLine1.UpgradeOpen();
                            //newLine1.Layer = wallLayerName;
                            newLine1.Layer = line1.Layer;

                            Line newLine2 = new Line(secStaP, secEndP);
                            btr.AppendEntity(newLine2);
                            tr.AddNewlyCreatedDBObject(newLine2, true);
                            newLine2.UpgradeOpen();
                            //newLine2.Layer = wallLayerName;
                            newLine2.Layer = line1.Layer;
                            //ed.WriteMessage($"\n{newLine1.Length}\n{newLine2.Length}\n{newLine1.StartPoint}\n{newLine1.EndPoint}");

                            succeedCount++;
                        }
                    }
                    tr.Commit();
                }
            }
            else
            {
                ed.WriteMessage("\n没有选择任何实体或选择操作被取消");
                return;
            }

            ed.WriteMessage($"\n完成，成功生成墙线:{succeedCount}x2条");

        }
        private static bool ExtensionLineToIntersect(Transaction tr, BlockReference blockRef, Line line)
        {
            var blockTransform = blockRef.BlockTransform;
            BlockTableRecord btr = (BlockTableRecord)tr.GetObject(blockRef.BlockTableRecord, OpenMode.ForRead);

            // 接下来可以遍历btr内的实体
            foreach (ObjectId id in btr)
            {
                // 获取块定义中的每一个实体
                Entity ent = (Entity)tr.GetObject(id, OpenMode.ForRead);
                // 在循环内部，获取变换后的实体
                Entity transformedEnt = ent;
                if (transformedEnt is Line innerLine)
                {
                    // 延长逻辑：计算方向向量并延长两端各5mm
                    Vector3d direction = (innerLine.EndPoint - innerLine.StartPoint).GetNormal();
                    double extensionDistance = 5.0;

                    Point3d newStart = innerLine.StartPoint - direction * extensionDistance;
                    Point3d newEnd = innerLine.EndPoint + direction * extensionDistance;
                    newStart = newStart.TransformBy(blockTransform);
                    newEnd = newEnd.TransformBy(blockTransform);

                    // 创建一条新的延长后的直线进行碰撞检测
                    using (Line extendedLine = new Line(newStart, newEnd))
                    {
                        Point3dCollection innerPoints = new Point3dCollection();
                        extendedLine.IntersectWith(line, Intersect.OnBothOperands, innerPoints, IntPtr.Zero, IntPtr.Zero);
                        // 处理innerPoints中的碰撞点
                        if (innerPoints.Count > 0)
                        {
                            return true;
                        }
                    }
                }
                else if (transformedEnt is Polyline innerPline)
                {
                    // 分解多段线为直线段
                    for (int i = 0; i < innerPline.NumberOfVertices; i++)
                    {
                        Point3d startPt = innerPline.GetPoint3dAt(i);
                        Point3d endPt = innerPline.GetPoint3dAt((i + 1) % innerPline.NumberOfVertices);

                        // 创建代表多段线一个线段的直线
                        using (Line segmentLine = new Line(startPt, endPt))
                        {
                            // 对该线段进行和Line一样的延长操作
                            Vector3d segDirection = (segmentLine.EndPoint - segmentLine.StartPoint).GetNormal();
                            Point3d segNewStart = segmentLine.StartPoint - segDirection * 5.0;
                            Point3d segNewEnd = segmentLine.EndPoint + segDirection * 5.0;
                            segNewStart = segNewStart.TransformBy(blockTransform);
                            segNewEnd = segNewEnd.TransformBy(blockTransform);

                            using (Line extendedSegment = new Line(segNewStart, segNewEnd))
                            {
                                Point3dCollection segPoints = new Point3dCollection();
                                extendedSegment.IntersectWith(line, Intersect.OnBothOperands, segPoints, IntPtr.Zero, IntPtr.Zero);
                                // 处理segPoints中的碰撞点
                                if (segPoints.Count > 0)
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }
        private static bool DoesLineIntersectBlockReference(Line line, BlockReference blkRef, Transaction trans, Editor ed)
        {
            BlockTableRecord btr = (BlockTableRecord)trans.GetObject(blkRef.BlockTableRecord, OpenMode.ForRead);

            // 获取块参照的变换矩阵，用于将子实体从块定义空间转换到模型空间
            Matrix3d blkTransform = blkRef.BlockTransform;

            foreach (ObjectId id in btr)
            {
                Entity ent = trans.GetObject(id, OpenMode.ForRead) as Entity;
                if (ent != null)
                {
                    // 应用块参照的变换矩阵到子实体上，得到其在模型空间中的形态
                    Entity transformedEnt;
                    try
                    {
                        transformedEnt = ent.GetTransformedCopy(blkTransform);
                    }
                    catch (System.Exception)
                    {
                        continue;
                    }
                        

                    // 使用CAD API的IntersectWith方法进行相交检测
                    Point3dCollection intersectionPoints = new Point3dCollection();
                    try
                    {
                        ed.WriteMessage("\n" + (line == null) + "|" + (transformedEnt == null));
                        line.IntersectWith(transformedEnt, Intersect.OnBothOperands, intersectionPoints, IntPtr.Zero, IntPtr.Zero);

                        // 如果交点数大于0，则说明相交
                        if (intersectionPoints.Count > 0)
                        {
                            // 注意：这里创建的临时实体在使用后应妥善处理，在非托管环境中可能需要手动释放。
                            // 对于此示例，我们只是进行检查，找到第一个交点即可返回结果。
                            transformedEnt.Dispose(); // 释放临时创建的实体
                            return true;
                        }
                    }
                    finally
                    {
                        transformedEnt.Dispose(); // 确保临时实体被释放
                    }
                }
            }
            return false;
        }
        public double GetAngle(Line line, BlockReference blockRef)
        {
            double angle;
            angle = Math.Abs(line.Angle - blockRef.Rotation);
            if (angle > Math.PI)
            {
                angle = 2 * Math.PI - angle;
            }
            return angle;
        }
        public double GetAngle(Line line, Line line2)
        {
            double angle;
            angle = Math.Abs(line.Angle - line2.Angle);
            if (angle > Math.PI)
            {
                angle = 2 * Math.PI - angle;
            }
            return angle;
        }

        public string GetRealBlockName(BlockReference blockRef, Transaction tr)
        {
            // 获取匿名块的BlockTableRecord对象及名称
            BlockTableRecord anonymousBlock = null;
            string anonymousBlockName = "";
            if (blockRef.IsDynamicBlock)
            {
                anonymousBlock = blockRef.DynamicBlockTableRecord.GetObject(OpenMode.ForRead) as BlockTableRecord;
                anonymousBlockName = anonymousBlock.Name;
            }
            else
            {
                anonymousBlock = blockRef.BlockTableRecord.GetObject(OpenMode.ForRead) as BlockTableRecord;
                anonymousBlockName = anonymousBlock.Name;
            }
            return GetRealBlockName(anonymousBlock, tr);
        }
        // 递归查找真实块名
        public string GetRealBlockName(BlockTableRecord btr, Transaction tr)
        {
            if (btr.IsFromExternalReference)
            {
                // 如果匿名块在外部引用中，则需要打开外部参照数据库
                return "匿名块在外部引用中，则需要打开外部参照数据库";
            }
            else if (!btr.IsAnonymous)
            {
                // 如果匿名块不是匿名或是具名块，则返回块名称
                return btr.Name;
            }
            else
            {
                // 如果匿名块是匿名块，则继续查找其所属的块表记录
                foreach (ObjectId ownerId in btr.GetBlockReferenceIds(true, false))
                {
                    BlockReference br = tr.GetObject(ownerId, OpenMode.ForRead) as BlockReference;
                    if (br != null && br.IsDynamicBlock)
                    {
                        BlockTableRecord dynamicBtr = br.DynamicBlockTableRecord.GetObject(OpenMode.ForRead) as BlockTableRecord;
                        return GetRealBlockName(dynamicBtr, tr);
                    }
                }
            }

            return "";
        }
        /// <summary>
        /// 获取多段线中的所有直线段，并根据提供的变换矩阵进行转换
        /// </summary>
        /// <param name="poly">输入的多段线</param>
        /// <param name="transformation">变换矩阵（如果为空，则不进行变换）</param>
        /// <returns>直线列表</returns>
        public static List<Line> GetPolylineLines(Polyline poly, Matrix3d? transformation)
        {
            List<Line> lineSegments = new List<Line>();

            if (poly == null)
                return lineSegments;

            // 遍历多段线的所有顶点，获取直线段
            for (int i = 0; i < poly.NumberOfVertices - 1; i++)
            {
                if (poly.GetSegmentType(i) == SegmentType.Line)
                {
                    Point3d startPt = poly.GetPoint3dAt(i);
                    Point3d endPt = poly.GetPoint3dAt(i + 1);

                    // 如果提供了变换矩阵，则转换点坐标
                    if (transformation != null)
                    {
                        startPt = startPt.TransformBy((Matrix3d)transformation);
                        endPt = endPt.TransformBy((Matrix3d)transformation);
                    }
                    Line newLine = new Line(startPt, endPt);
                    newLine.Layer = poly.Layer;
                    lineSegments.Add(newLine);
                }
            }

            // 处理闭合多段线的情况（首尾相连）
            if (poly.Closed && poly.NumberOfVertices > 1)
            {
                int lastIndex = poly.NumberOfVertices - 1;
                if (poly.GetSegmentType(lastIndex) == SegmentType.Line)
                {
                    Point3d startPt = poly.GetPoint3dAt(lastIndex);
                    Point3d endPt = poly.GetPoint3dAt(0);

                    if (transformation != null)
                    {
                        startPt = startPt.TransformBy((Matrix3d)transformation);
                        endPt = endPt.TransformBy((Matrix3d)transformation);
                    }

                    Line newLine = new Line(startPt, endPt);
                    newLine.Layer = poly.Layer;
                    lineSegments.Add(newLine);
                }
            }

            return lineSegments;
        }

        /// <summary>
        /// 炸开块
        /// </summary>
        /// <param name="db"></param>
        public void ExportBlocks(Database db)
        {
            bool continu = false;
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                BlockTable blockTable = (BlockTable)trans.GetObject(db.BlockTableId, OpenMode.ForWrite);
                BlockTableRecord space = trans.GetObject(blockTable[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;

                foreach (var id in space)
                {
                    DBObject obj = trans.GetObject(id, OpenMode.ForWrite);
                    if (obj is BlockReference brf)
                    {
                        brf.ExplodeToOwnerSpace();
                        brf.Erase();
                        continu = true;
                    }
                }
                trans.Commit();

            }
            if (continu)
            {
                ExportBlocks(db);
            }

        }
    }

    public class LineInfo
    {
        public Line Line { get; set; }
        public double Angle { get; set; }
        public Point3d CenterPoint { get; set; }
    }
}
