using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.ApplicationServices;
using Application = Autodesk.AutoCAD.ApplicationServices.Application;
using Autodesk.AutoCAD.EditorInput;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using Autodesk.AutoCAD.GraphicsInterface;
using Polyline = Autodesk.AutoCAD.DatabaseServices.Polyline;

namespace ChangeLayerText2
{
    //修改文本信息至正确的图层（根据线段相交点的管道图层来判断）
    public class Class1
    {
        string layerName;
        int c;
        Editor ed;
        [CommandMethod("ChangeTextLayer")]
        public void ChangeTextLayer()
        {
            //活动文档
            Document doc = Application.DocumentManager.MdiActiveDocument;
            //数据库
            Database db = doc.Database;
            //编辑器
            ed = doc.Editor;

            //// 定义搜索范围
            //double range = 1000.0;

            PromptStringOptions pso = new PromptStringOptions("输入图层名称:");
            PromptResult pr = ed.GetString(pso);
            if (pr.Status != PromptStatus.OK)
                return;

            layerName = pr.StringResult;
            List<EntityInfo> entityInfos = new List<EntityInfo>();
            using (Transaction tr = db.TransactionManager.StartTransaction())
            {
                //打开块表
                BlockTable bt = (BlockTable)tr.GetObject(db.BlockTableId, OpenMode.ForRead);
                //打开块记录表
                BlockTableRecord btr = (BlockTableRecord)tr.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForRead);

                //获取所有多段线
                List<Polyline> polylines = new List<Polyline>();
                // 遍历模型空间中的所有对象
                foreach (ObjectId objId in btr)
                {
                    Entity ent = tr.GetObject(objId, OpenMode.ForRead) as Entity;
                    if (ent != null && ent is Polyline)
                    {
                        Polyline polyline = ent as Polyline;

                        polylines.Add(polyline);
                    }
                }
                List<Entity> entitiesInRange = new List<Entity>();
                List<ObjectId> hasAddObjId = new List<ObjectId>();
                //1.将选择图层的线段和文本进行分组
                // 遍历同图层的实体
                foreach (ObjectId objId in btr)
                {
                    if (hasAddObjId.Contains(objId) || !((tr.GetObject(objId, OpenMode.ForRead) as Entity) is Line)) continue;
                    List<Line> lines = new List<Line>();
                    List<DBText> dBTexts = new List<DBText>();
                    Entity ent = tr.GetObject(objId, OpenMode.ForRead) as Entity;
                    if (ent != null && ent.Layer == layerName)
                    {
                        if (ent is Line line) { lines.Add(line); FindNearest(line, btr, tr, lines, dBTexts, hasAddObjId); }
                        //if (ent is DBText dText) dBTexts.Add(dText);
                        //FindNearest(ent, btr);
                        if (lines.Count() > 2 * dBTexts.Count())
                        {
                            EntityInfo entityInfo = new EntityInfo() { Lines = lines, DBTexts = dBTexts };
                            entityInfos.Add(entityInfo);
                        }
                    }
                }
                //ed.WriteMessage($"\n在范围内找到 {entitiesInRange.Count} 个实体.");
                //ed.WriteMessage(entityInfos.Count().ToString()+"\n");
                //2.获取每组线段的交点
                List<PipeTextGroup> pipeTexts = new List<PipeTextGroup>();
                foreach (var item in entityInfos)
                {
                    List<PointInPipe> pointInPipes = new List<PointInPipe>();
                    // 检查两两线段之间的交点
                    for (int i = 0; i < item.Lines.Count; i++)
                    {
                        for (int j = i + 1; j < item.Lines.Count - i - 1; j++)
                        {
                            Point3d? intersectionPoint = GetIntersectionPoint(item.Lines[i], item.Lines[j]);
                            if (intersectionPoint.HasValue)
                            {
                                if (!AreLinesPerpendicular(item.Lines[i], item.Lines[j]))
                                {
                                    //获得交点上的多段线(管道)
                                    foreach (var item2 in polylines)
                                    {
                                        // 检查点是否在多段线上
                                        bool isPointOnPolyline = IsPointOnPolyline(item2, intersectionPoint.Value);
                                        if (isPointOnPolyline)
                                        {
                                            PointInPipe pointInPipe = new PointInPipe() { point3D = intersectionPoint.Value, pipe = item2 };
                                            pointInPipes.Add(pointInPipe);
                                            break;
                                        }
                                    }
                                }
                            }
                            if (j == item.Lines.Count - 1)
                            {
                                Point3d? intersectionPointLast = GetIntersectionPoint(item.Lines[0], item.Lines[j]);
                                if (intersectionPointLast.HasValue)
                                {
                                    if (!AreLinesPerpendicular(item.Lines[0], item.Lines[j]))
                                    {
                                        //获得交点上的多段线(管道)
                                        foreach (var item2 in polylines)
                                        {
                                            // 检查点是否在多段线上
                                            bool isPointOnPolyline = IsPointOnPolyline(item2, intersectionPointLast.Value);
                                            if (isPointOnPolyline)
                                            {
                                                PointInPipe pointInPipe = new PointInPipe() { point3D = intersectionPointLast.Value, pipe = item2 };
                                                pointInPipes.Add(pointInPipe);
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    PipeTextGroup pipeTextGroup = new PipeTextGroup() { DBTexts = item.DBTexts, PointInPipes = pointInPipes };
                    pipeTexts.Add(pipeTextGroup);
                }
                //3.判断坐标点与文本对应的关系，获取一一对应关系的管道（多段线）与文本
                List<(Polyline, DBText)> mappingInfos = new List<(Polyline, DBText)>();
                foreach (var item in pipeTexts)
                {
                    int c = 0;
                    List<DBText> dBTexts = new List<DBText>();
                    foreach (var i in item.DBTexts)
                    {
                        dBTexts.Add(i);
                    }
                    List<PointInPipe> pointsInPipes = new List<PointInPipe>();
                    foreach (var i in item.PointInPipes)
                    {
                        pointsInPipes.Add(i);
                    }
                    //ed.WriteMessage($"{dBTexts.Count}\n{pointsInPipes.Count}\n");
                    List<DBText> rdbT = new List<DBText>();
                    List<Polyline> nplL = new List<Polyline>();
                    while (dBTexts.Any() && pointsInPipes.Any() /*|| c > 2 * dBTexts.Count()*/)
                    {
                        c++;
                        double maxDistance = -1;
                        //Point3d? point3D = null;
                        DBText dBText = null;
                        PointInPipe pointInPipe = null;
                        foreach (var dbT in dBTexts)
                        {
                            foreach (var pIP in pointsInPipes)
                            {
                                double distance = dbT.Position.DistanceTo(pIP.point3D);
                                if (distance > maxDistance)
                                {
                                    maxDistance = distance;
                                    //point3D = pIP.point3D;
                                    dBText = dbT;
                                    pointInPipe = pIP;
                                }
                            }
                        }
                        //if (point3D.HasValue && dBText != null)
                        if (dBText != null && pointInPipe != null)
                        {
                            //mappingInfos.Add((pointInPipe.pipe, dBText));
                            rdbT.Add(dBText);
                            nplL.Add(pointInPipe.pipe);
                            dBTexts.Remove(dBText);
                            pointsInPipes.Remove(pointInPipe);
                        }
                        //if(mappingInfos.Count() > 2000)
                        if (rdbT.Count() > 2000 || nplL.Count() > 2000)
                        {
                            ed.WriteMessage("Error:OutOfMemoryException");
                            return;
                        }
                    }
                    if (rdbT.Count() > 0 && nplL.Count() == rdbT.Count())
                    {
                        rdbT.Reverse();
                        for (int i = 0; i < rdbT.Count(); i++)
                        {
                            mappingInfos.Add((nplL[i], rdbT[i]));
                        }
                    }
                }

                List<DBText> rDBTexts = mappingInfos.Select(group => group.Item2).ToList();
                rDBTexts.Reverse();

                //List<Polyline> newPolylines = mappingInfos.Select(x => x.Item1).ToList();
                //List<(Polyline, DBText)> newMappingInfos = mappingInfos.Select((group, index) => (group.Item1, rDBTexts[index])).ToList();
                //4.将文本图层名称改为与对应polyline图层名称相关的名称
                foreach (var group in mappingInfos)
                {
                    string pipeLayerName = group.Item1.Layer;
                    string newLayerName = pipeLayerName.Replace("PIPE-", "DIM_");
                    if (group.Item2.Layer == newLayerName) continue;
                    // 创建或切换到新图层
                    LayerTable lt = tr.GetObject(db.LayerTableId, OpenMode.ForRead) as LayerTable;
                    if (!lt.Has(newLayerName))
                    {
                        lt.UpgradeOpen();
                        LayerTableRecord ltr = new LayerTableRecord();
                        ltr.Name = newLayerName;
                        lt.Add(ltr);
                        tr.AddNewlyCreatedDBObject(ltr, true);
                    }

                    // 修改文字对象的图层
                    group.Item2.UpgradeOpen();
                    group.Item2.Layer = newLayerName;
                }
                //for (int i = 0; i < rDBTexts.Count(); i++)
                //{
                //    string pipeLayerName = newPolylines[i].Layer;
                //    string newLayerName = pipeLayerName.Replace("PIPE-", "DIM_");
                //    if (rDBTexts[rDBTexts.Count() - i - 1].Layer == newLayerName) continue;
                //    // 创建或切换到新图层
                //    LayerTable lt = tr.GetObject(db.LayerTableId, OpenMode.ForRead) as LayerTable;
                //    if (!lt.Has(newLayerName))
                //    {
                //        lt.UpgradeOpen();
                //        LayerTableRecord ltr = new LayerTableRecord();
                //        ltr.Name = newLayerName;
                //        lt.Add(ltr);
                //        tr.AddNewlyCreatedDBObject(ltr, true);
                //    }

                //    // 修改文字对象的图层
                //    rDBTexts[rDBTexts.Count() - i - 1].UpgradeOpen();
                //    rDBTexts[rDBTexts.Count() - i - 1].Layer = newLayerName;
                //}
                ed.WriteMessage("完成！");
                tr.Commit();
            }
        }
        public void FindNearest(Line ent, BlockTableRecord objIds, Transaction tr, List<Line> lines, List<DBText> dBTexts, List<ObjectId> hasAddObjId)
        {
            if (c > 500)
            {
                ed.WriteMessage("error");
                return;
            }

            // 获取线段的起点和终点
            Point3d startPoint = ent.StartPoint;
            Point3d endPoint = ent.EndPoint;

            // 计算搜索区域
            Extents3d searchArea = new Extents3d(
                new Point3d(Math.Min(startPoint.X, endPoint.X) - 1000, Math.Min(startPoint.Y, endPoint.Y) - 1000, 0),
                new Point3d(Math.Max(startPoint.X, endPoint.X) + 1000, Math.Max(startPoint.Y, endPoint.Y) + 1000, 0)
            );
            foreach (ObjectId objId in objIds)
            {
                if (c > 500)
                {
                    ed.WriteMessage("error");
                    return;
                }
                Entity entity = tr.GetObject(objId, OpenMode.ForRead) as Entity;
                // 检查实体类型
                if (entity.Layer == layerName && (entity is Line || entity is DBText) && objId != ent.ObjectId)
                {
                    // 获取实体的几何范围
                    Extents3d entityExtents;
                    try
                    {
                        entityExtents = entity.GeometricExtents;
                    }
                    catch
                    {
                        continue;
                    }
                    if (searchArea.Intersects(entityExtents))
                    {
                        if (entity is Line line && !lines.Contains(line))
                        {
                            lines.Add(line);
                            hasAddObjId.Add(objId);
                            c++;
                            FindNearest(line, objIds, tr, lines, dBTexts, hasAddObjId);
                        }
                        if (entity is DBText dBText && !dBTexts.Contains(dBText))
                        {
                            dBTexts.Add(dBText);
                        }
                    }
                }
            }

        }
        // 判断两条线段是否相交并返回交点
        private Point3d? GetIntersectionPoint(Line line1, Line line2)
        {
            Point3d p1 = line1.StartPoint;
            Point3d p2 = line1.EndPoint;
            Point3d p3 = line2.StartPoint;
            Point3d p4 = line2.EndPoint;

            Vector3d v1 = p2 - p1;
            Vector3d v2 = p4 - p3;

            double denominator = v1.X * v2.Y - v1.Y * v2.X;
            if (denominator == 0)
            {
                // 平行或重合
                return null;
            }

            double t1 = ((p3.X - p1.X) * v2.Y - (p3.Y - p1.Y) * v2.X) / denominator;
            double t2 = ((p3.X - p1.X) * v1.Y - (p3.Y - p1.Y) * v1.X) / denominator;

            if (t1 >= 0 && t1 <= 1 && t2 >= 0 && t2 <= 1)
            {
                return p1 + t1 * v1;
            }

            return null;
        }

        // 判断两条线段是否垂直
        private bool AreLinesPerpendicular(Line line1, Line line2)
        {
            Vector3d v1 = line1.EndPoint - line1.StartPoint;
            Vector3d v2 = line2.EndPoint - line2.StartPoint;
            return Math.Abs(v1.DotProduct(v2)) < 1e-6;
        }
        private bool IsPointOnPolyline(Polyline polyline, Point3d point)
        {
            // 迭代多段线的各个线段
            for (int i = 0; i < polyline.NumberOfVertices - 1; i++)
            {
                Point3d startPoint = polyline.GetPoint3dAt(i);
                Point3d endPoint = polyline.GetPoint3dAt(i + 1);

                if (IsPointOnLineSegment(startPoint, endPoint, point))
                {
                    return true;
                }
            }

            return false;
        }

        private bool IsPointOnLineSegment(Point3d start, Point3d end, Point3d point)
        {
            // 检查点是否在线段上
            Vector3d startToEnd = end - start;
            Vector3d startToPoint = point - start;
            double lengthSq = startToEnd.LengthSqrd;
            double projection = startToPoint.DotProduct(startToEnd) / lengthSq;

            // 检查投影是否在0到1之间，并且点到线段的距离是否为零（或在容差范围内）
            if (projection >= 0.0 && projection <= 1.0)
            {
                Point3d projectedPoint = start + projection * startToEnd;
                if (projectedPoint.IsEqualTo(point, new Tolerance(1e-6, 1e-6)))
                {
                    return true;
                }
            }

            return false;
        }
    }
    public static class Extents3dExtensions
    {
        public static bool Intersects(this Extents3d extents1, Extents3d extents2)
        {
            return extents1.MinPoint.X <= extents2.MaxPoint.X && extents1.MaxPoint.X >= extents2.MinPoint.X &&
                   extents1.MinPoint.Y <= extents2.MaxPoint.Y && extents1.MaxPoint.Y >= extents2.MinPoint.Y &&
                   extents1.MinPoint.Z <= extents2.MaxPoint.Z && extents1.MaxPoint.Z >= extents2.MinPoint.Z;
        }
    }
    public class EntityInfo
    {
        public List<Line> Lines { get; set; }
        public List<DBText> DBTexts { get; set; }
    }
    public class PointInPipe
    {
        public Point3d point3D { get; set; }
        public Polyline pipe { get; set; }
    }
    public class PipeTextGroup
    {
        public List<PointInPipe> PointInPipes { get; set; }
        public List<DBText> DBTexts { get; set; }
    }
}
