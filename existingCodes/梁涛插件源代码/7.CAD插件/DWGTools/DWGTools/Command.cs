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
                        // 获取选中实体
                        Entity entity = (Entity)tr.GetObject(objId, OpenMode.ForRead);

                        // 判断是否为多段线
                        if (entity is Polyline polyline)
                        {
                            // 获取多段线的图层名称
                            string plLayerName = polyline.Layer;

                            polylineLayerNames.Add(plLayerName);
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

            // 电气点位块参照集合
            List<BlockReference> pointReferences = new List<BlockReference>();
            // 多段线集合
            List<Polyline> polylines = new List<Polyline>();

            using (Transaction tr = db.TransactionManager.StartTransaction())
            {
                BlockTable bt = tr.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;
                BlockTableRecord btr = (BlockTableRecord)tr.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForRead);

                foreach (ObjectId objId in btr)
                {
                    var obj = tr.GetObject(objId, OpenMode.ForRead);
                    if (obj is BlockReference blockReference && layerNames.Contains(blockReference.Layer) && blockNames.Contains(blockReference.Name))
                    {
                        pointReferences.Add(blockReference);
                    }
                    else if (obj is Polyline polyline && polylineLayerNames.Contains(polyline.Layer))
                    {
                        polylines.Add(polyline);
                    }

                }

                tr.Commit();
            }
            //ed.WriteMessage("\n" + polylines.Count + "\n" + blockNames.FirstOrDefault() + "\n" + blockNames.Count + "\n" + pointReferences.Count);

            List<PolyLineInfo> polyLineInfos = new List<PolyLineInfo>();
            List<BlockInfo> blockInfos = new List<BlockInfo>();

            foreach (Polyline polyline in polylines)
            {
                List<Line> lines = GetLinesFromPolyline(polyline);
                polyLineInfos.Add(new PolyLineInfo() { Polyline = polyline, Lines = lines });
            }

            foreach (BlockReference bf in pointReferences)
            {
                List<Line> lines = GetLinesFromBlockReference(bf);
                var extents3d = bf.GeometricExtents;
                Point3d minP = extents3d.MinPoint;
                Point3d maxP = extents3d.MaxPoint;
                Point3d cP = new Point3d(((minP.X + maxP.X) / 2 + maxP.X) / 2, ((minP.Y + maxP.Y) / 2 + maxP.Y) / 2, ((minP.Z + maxP.Z) / 2 + maxP.Z) / 2);
                blockInfos.Add(new BlockInfo() { BlockReference = bf, Lines = lines, CenterPoint = bf.Position, CreatePoint = cP });
            }

            // 将临时Line添加到模型空间中
            using (Transaction tr = db.TransactionManager.StartTransaction())
            {
                BlockTable bt = tr.GetObject(db.BlockTableId, OpenMode.ForWrite) as BlockTable;
                BlockTableRecord btr = tr.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite)as BlockTableRecord;
                foreach (var item in polyLineInfos)
                {
                    foreach (var line in item.Lines)
                    {
                        btr.AppendEntity(line);
                        tr.AddNewlyCreatedDBObject(line, true);
                    }
                }

                foreach (var item in blockInfos)
                {
                    foreach (var line in item.Lines)
                    {
                        btr.AppendEntity(line);
                        tr.AddNewlyCreatedDBObject(line, true);
                    }
                }

                tr.Commit();
            }

            int succeed = 0;
            using (Transaction tr = db.TransactionManager.StartTransaction())
            {
                BlockTable bt = (BlockTable)tr.GetObject(db.BlockTableId, OpenMode.ForWrite);
                BlockTableRecord btr = (BlockTableRecord)tr.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite);

                foreach (var blockInfo in blockInfos)
                {
                    int intersectCount = 0;
                    List<ObjectId> lineIds = new List<ObjectId>();
                    foreach (var item in blockInfo.Lines)
                    {                      
                        foreach (var item2 in polyLineInfos)
                        {
                            foreach (var item3 in item2.Lines)
                            {
                                var col = new Point3dCollection();
                                item.IntersectWith(item3, Intersect.OnBothOperands, col, IntPtr.Zero, IntPtr.Zero);
                                if (col.Count > 0 && !lineIds.Contains(item3.ObjectId))
                                {
                                    //ed.WriteMessage("\n" + item.ObjectId + "||" + item3.ObjectId + "||" + blockInfo.BlockReference.ObjectId);
                                    lineIds.Add(item3.ObjectId);
                                    intersectCount++;
                                    break;
                                }
                            }
                        }
                    }
                    if (intersectCount > 1)
                    {
                        succeed++;
                        DBText dBText = new DBText();
                        dBText.Height = 100;
                        dBText.TextString = intersectCount.ToString();
                        dBText.Position = blockInfo.CreatePoint;
                        dBText.Color = blockInfo.BlockReference.Color;
                        btr.AppendEntity(dBText);
                        tr.AddNewlyCreatedDBObject(dBText, true);

                        // 将文本添加到指定图层中，颜色与点位颜色保持一致 25.5.8
                        LayerTable lt = tr.GetObject(db.LayerTableId, OpenMode.ForRead) as LayerTable;
                        string newLayerName = blockInfo.BlockReference.Layer + "-" + intersectCount;

                        if (!lt.Has(newLayerName))
                        {
                            lt.UpgradeOpen();
                            LayerTableRecord ltr = new LayerTableRecord();
                            ltr.Name = newLayerName;
                            LayerTableRecord oldLtr = tr.GetObject(lt[blockInfo.BlockReference.Layer], OpenMode.ForRead) as LayerTableRecord;
                            ltr.Color = oldLtr.Color;
                            lt.Add(ltr);
                            tr.AddNewlyCreatedDBObject(ltr, true);
                        }

                        dBText.UpgradeOpen();
                        dBText.Layer = newLayerName;
                    }

                    //succeed++;
                    //DBText dBText = new DBText();
                    //dBText.Height = 100;
                    //dBText.TextString = intersectCount.ToString();
                    //dBText.Position = blockInfo.CreatePoint;
                    //dBText.Color = blockInfo.BlockReference.Color;
                    //btr.AppendEntity(dBText);
                    //tr.AddNewlyCreatedDBObject(dBText, true);

                    
                }
                tr.Commit();
            }

            // 删除多余的Line
            using (Transaction tr = db.TransactionManager.StartTransaction())
            {
                BlockTable bt = (BlockTable)tr.GetObject(db.BlockTableId, OpenMode.ForWrite);
                BlockTableRecord btr = (BlockTableRecord)tr.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite);
                foreach (var item in polyLineInfos)
                {
                    foreach (var line in item.Lines)
                    {
                        Line delLine = tr.GetObject(line.ObjectId, OpenMode.ForWrite) as Line;
                        delLine.Erase(true);
                    }
                }

                foreach (var item in blockInfos)
                {
                    foreach (var line in item.Lines)
                    {
                        Line delLine = tr.GetObject(line.ObjectId, OpenMode.ForWrite) as Line;
                        delLine.Erase(true);
                    }
                }

                tr.Commit();
            }

            ed.WriteMessage("\n完成！成功创建个数：" + succeed);
        }
        public List<Line> GetLinesFromPolyline(Polyline polyline)
        {
            List<Line> lines = new List<Line>();
            for (int i = 0; i < polyline.NumberOfVertices - 1; i++)
            {
                // 获取相邻两个顶点的线段
                LineSegment3d segment = polyline.GetLineSegmentAt(i);
                Line line = new Line(segment.StartPoint, segment.EndPoint);
                lines.Add(line);
            }
            return lines;
        }

        public List<Line> GetLinesFromBlockReference(BlockReference blockRef)
        {
            List<Line> allLines = new List<Line>();
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;

            using (Transaction tr = db.TransactionManager.StartTransaction())
            {
                // 获取块定义
                BlockTableRecord blockDef = tr.GetObject(blockRef.BlockTableRecord, OpenMode.ForRead) as BlockTableRecord;

                // 获取块参照的变换矩阵（用于坐标转换）
                Matrix3d transform = blockRef.BlockTransform;

                // 遍历块定义中的每个实体
                foreach (ObjectId entityId in blockDef)
                {
                    Entity entity = tr.GetObject(entityId, OpenMode.ForRead) as Entity;
                    if (entity == null) continue;

                    //// 处理嵌套块参照（递归调用）
                    //if (entity is BlockReference nestedBlockRef)
                    //{
                    //    List<Line> nestedLines = GetLinesFromBlockReference(nestedBlockRef);
                    //    allLines.AddRange(nestedLines);
                    //}
                    // 处理多段线
                    if (entity is Polyline pl)
                    {
                        // 将多段线分解为直线段（应用变换矩阵）
                        List<Line> lines = GetTransformedLinesFromPolyline(pl, transform);
                        allLines.AddRange(lines);
                    }
                }
                tr.Commit();
            }
            return allLines;
        }

        // 从Polyline生成直线段并应用坐标变换
        private List<Line> GetTransformedLinesFromPolyline(Polyline polyline, Matrix3d transform)
        {
            List<Line> lines = new List<Line>();
            for (int i = 0; i < polyline.NumberOfVertices - 1; i++)
            {
                LineSegment3d segment = polyline.GetLineSegmentAt(i);
                // 创建原始直线段
                Line line = new Line(segment.StartPoint, segment.EndPoint);
                // 应用块参照的变换矩阵
                line.TransformBy(transform);
                lines.Add(line);
            }
            return lines;
        }

    }
    public class PolyLineInfo
    {
        public Polyline Polyline { get; set; }
        public List<Line> Lines { get; set; }
    }
    public class BlockInfo
    {
        public BlockReference BlockReference { get; set; }
        public List<Line> Lines { get; set; }
        public Point3d CenterPoint { get; set; }
        public Point3d CreatePoint { get; set; }
    }
}
