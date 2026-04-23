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

namespace TextRecognitionInCAD
{
    public class ConduitConnectToElemCenter
    {
        [CommandMethod("CCTC")]
        public void ConduitConnectToPTCenter()
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            Editor ed = doc.Editor;

            List<Polyline> polylines = new List<Polyline>();
            List<BlockReference> blockReferences = new List<BlockReference>();

            // 1.1 提示用户选择多条多段线
            PromptSelectionOptions pso = new PromptSelectionOptions();
            pso.MessageForAdding = "\n请选择一条或多条多段线：";
            pso.AllowDuplicates = false;

            // 设置过滤器，只允许选择多段线
            SelectionFilter filter = new SelectionFilter(new TypedValue[] 
            {
                new TypedValue((int)DxfCode.Start, "LWPOLYLINE"), // 轻量多段线
                new TypedValue((int)DxfCode.Start, "POLYLINE")     // 旧式多段线
            });

            PromptSelectionResult psr = ed.GetSelection(pso);
            if (psr.Status != PromptStatus.OK)
            {
                ed.WriteMessage("\n未选择多段线或选择已取消。");
                return;
            }

            // 1.2 提取所选多段线的图层名（去重）
            using (Transaction tr = db.TransactionManager.StartTransaction())
            {

                // 使用 HashSet 避免重复的图层名
                HashSet<string> targetLayerNames = new HashSet<string>();

                foreach (SelectedObject selectedObj in psr.Value)
                {
                    if (selectedObj != null)
                    {
                        Entity ent = tr.GetObject(selectedObj.ObjectId, OpenMode.ForRead) as Entity;
                        if (ent != null)
                        {
                            targetLayerNames.Add(ent.Layer);
                        }
                    }
                }

                // 1.3 构建图层过滤器并选择目标图层上的所有多段线
                if (targetLayerNames.Count > 0)
                {
                    // 构建过滤器：图层名用逗号分隔
                    string layerFilter = string.Join(",", targetLayerNames);
                    TypedValue[] layerFilterList = new TypedValue[] 
                    {
                        new TypedValue((int)DxfCode.Operator, "<or"),
                        new TypedValue((int)DxfCode.Start, "LWPOLYLINE"),
                        new TypedValue((int)DxfCode.Start, "POLYLINE"),
                        new TypedValue((int)DxfCode.Operator, "or>"),
                        new TypedValue((int)DxfCode.LayerName, layerFilter)
                    };

                    SelectionFilter finalFilter = new SelectionFilter(layerFilterList);
                    PromptSelectionResult finalPsr = ed.SelectAll(finalFilter);

                    if (finalPsr.Status == PromptStatus.OK)
                    {
                        SelectionSet resultSet = finalPsr.Value;
                        ed.WriteMessage($"\n成功获取到图层 '{layerFilter}' 上的多段线数量：{resultSet.Count}");

                        // 1.4 遍历获取到的所有多段线对象进行处理
                        foreach (SelectedObject obj in resultSet)
                        {
                            Polyline pl = tr.GetObject(obj.ObjectId, OpenMode.ForRead) as Polyline;
                            if (pl != null)
                            {
                                polylines.Add(pl);
                                // 这里可以添加你的处理逻辑，例如读取顶点、计算面积等
                                // ed.WriteMessage($"\n多段线长度：{pl.Length}");
                            }
                        }
                    }
                    else
                    {
                        ed.WriteMessage("\n在目标图层上未找到多段线。");
                    }
                }
                else
                {
                    ed.WriteMessage("\n未能从所选对象中提取出有效的图层信息。");
                }
                tr.Commit();
            }

            // 2.1 提示用户选择一个块参照
            PromptEntityOptions peo = new PromptEntityOptions("\n请选择一个块参照来确定图层：");
            peo.SetRejectMessage("\n请选择一个有效的块参照！");
            peo.AddAllowedClass(typeof(BlockReference), false); // 限制只能选择块参照

            PromptEntityResult per = ed.GetEntity(peo);

            if (per.Status != PromptStatus.OK)
            {
                ed.WriteMessage("\n未选择块参照或操作已取消。");
                return;
            }

            // 2.2 获取所选块参照的图层名
            string targetLayerName;
            using (Transaction tr = db.TransactionManager.StartTransaction())
            {
                BlockReference sourceBlockRef = tr.GetObject(per.ObjectId, OpenMode.ForRead) as BlockReference;
                if (sourceBlockRef == null)
                {
                    ed.WriteMessage("\n错误：未能获取到块参照对象。");
                    return;
                }
                targetLayerName = sourceBlockRef.Layer; // 这是关键信息
                tr.Commit();
            }

            // 2.3 获取该图层上的所有块参照
            using (Transaction tr = db.TransactionManager.StartTransaction())
            {
                try
                {
                    // 构建选择过滤器：对象类型为“块参照”(INSERT)，且图层等于目标图层名
                    TypedValue[] filterList = new TypedValue[] 
                    {
                        new TypedValue((int)DxfCode.Start, "INSERT"), // 过滤块参照
                        new TypedValue((int)DxfCode.LayerName, targetLayerName) // 过滤指定图层
                    };

                    SelectionFilter filter2 = new SelectionFilter(filterList);

                    // 在全图范围内应用过滤器进行选择
                    PromptSelectionResult psr2 = ed.SelectAll(filter2);

                    if (psr2.Status == PromptStatus.OK)
                    {
                        SelectionSet selectionSet = psr2.Value;
                        ed.WriteMessage($"\n在图层 '{targetLayerName}' 上找到了 {selectionSet.Count} 个块参照。");

                        // 遍历选择集，处理每个块参照
                        foreach (SelectedObject selectedObj in selectionSet)
                        {
                            if (selectedObj != null)
                            {
                                BlockReference blockRef = tr.GetObject(selectedObj.ObjectId, OpenMode.ForRead) as BlockReference;
                                if (blockRef != null)
                                {
                                    blockReferences.Add(blockRef);

                                    //ed.WriteMessage($"\n块名：{blockRef.Name}, 位置：({blockRef.Position.X}, {blockRef.Position.Y})");
                                }
                            }
                        }
                    }
                    else
                    {
                        ed.WriteMessage($"\n在图层 '{targetLayerName}' 上未找到任何块参照。");
                    }
                    tr.Commit();
                }
                catch (System.Exception ex)
                {
                    ed.WriteMessage($"\n执行过程中发生错误：{ex.Message}");
                    tr.Abort();
                }
            }

            using (Transaction tr = doc.TransactionManager.StartTransaction())
            {
                List<Polyline> polylines1 = new List<Polyline>();
                foreach (var polyLine in polylines)
                {
                    polylines1.Add(tr.GetObject(polyLine.ObjectId, OpenMode.ForWrite) as Polyline);
                }

                foreach (var blockRef in blockReferences)
                {
                    foreach (var polyline in polylines1)
                    {
                        Point3dCollection intersectionPoints = new Point3dCollection();
                        polyline.IntersectWith(blockRef, Intersect.OnBothOperands, intersectionPoints, IntPtr.Zero, IntPtr.Zero);

                        if (intersectionPoints.Count > 0)
                        {
                            Point3d blockCenter = blockRef.Position;
                            int nearestVertexIndex = 0;
                            double minDistance = double.MaxValue;

                            for (int i = 0; i < polyline.NumberOfVertices; i++)
                            {
                                Point3d vertex = polyline.GetPoint3dAt(i);
                                double distance = vertex.DistanceTo(blockCenter);
                                if (distance < minDistance)
                                {
                                    minDistance = distance;
                                    nearestVertexIndex = i;
                                }
                            }

                            polyline.SetPointAt(nearestVertexIndex, new Point2d(blockCenter.X, blockCenter.Y));
                        }
                    }
                }


                tr.Commit();
            }

            ed.WriteMessage("\n完成！");
            return;

            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                try
                {
                    // 1. 选择多段线
                    PromptEntityOptions polylineOptions = new PromptEntityOptions("\n请选择一条多段线: ");
                    polylineOptions.SetRejectMessage("\n请选择一个多段线对象。");
                    polylineOptions.AddAllowedClass(typeof(Polyline), true);
                    PromptEntityResult polylineResult = ed.GetEntity(polylineOptions);
                    if (polylineResult.Status != PromptStatus.OK)
                    {
                        ed.WriteMessage("\n已取消操作");
                        return;
                    }


                    // 2. 选择块参照
                    PromptEntityOptions blockOptions = new PromptEntityOptions("\n请选择一个块参照: ");
                    blockOptions.SetRejectMessage("\n请选择一个块参照对象。");
                    blockOptions.AddAllowedClass(typeof(BlockReference), true);
                    PromptEntityResult blockResult = ed.GetEntity(blockOptions);
                    if (blockResult.Status != PromptStatus.OK)
                    {
                        ed.WriteMessage("\n已取消操作");
                        return;
                    }

                    // 3. 获取对象
                    Polyline polyline = trans.GetObject(polylineResult.ObjectId, OpenMode.ForRead) as Polyline;
                    BlockReference blockRef = trans.GetObject(blockResult.ObjectId, OpenMode.ForRead) as BlockReference;

                    if (polyline == null || blockRef == null)
                    {
                        ed.WriteMessage("\n错误：未能获取到有效的多段线或块参照。");
                        return;
                    }

                    // 4. 进行相交检测
                    // 使用 Intersect.OnBothOperands 选项
                    Point3dCollection intersectionPoints = new Point3dCollection();
                    polyline.IntersectWith(blockRef, Intersect.OnBothOperands, intersectionPoints, IntPtr.Zero, IntPtr.Zero);

                    // 5. 判断结果
                    if (intersectionPoints.Count > 0)
                    {
                        ed.WriteMessage("\n多段线与块参照 **相交**，共有 {0} 个交点。", intersectionPoints.Count);
                        // 如果需要，可以遍历 intersectionPoints 查看所有交点坐标
                        foreach (Point3d point in intersectionPoints)
                        {
                            ed.WriteMessage("\n交点坐标: ({0}, {1}, {2})", point.X, point.Y, point.Z);
                        }
                    }
                    else
                    {
                        ed.WriteMessage("\n多段线与块参照 **不相交**。");
                    }

                    trans.Commit();
                }
                catch (Exception ex)
                {
                    ed.WriteMessage("\n执行过程中发生错误: {0}", ex.Message);
                    trans.Abort();
                }
            }
        }
    }
}
