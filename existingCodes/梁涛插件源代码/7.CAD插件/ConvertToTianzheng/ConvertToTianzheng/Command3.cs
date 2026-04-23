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

                using (Transaction tr = db.TransactionManager.StartTransaction())
                {
                    // 获取直线实体
                    Line line = tr.GetObject(lineResult.ObjectId, OpenMode.ForRead) as Line;
                    var dir = (line.EndPoint - line.StartPoint).GetNormal();
                    var newStartPoint = line.StartPoint + dir.Negate() * 5;
                    var newEndPoint = line.EndPoint + dir * 5;
                    Line newLine = new Line(newStartPoint, newEndPoint);

                    // 获取块参照实体
                    BlockReference blockRef = tr.GetObject(blockResult.ObjectId, OpenMode.ForRead) as BlockReference;

                    if (line != null && blockRef != null)
                    {
                        // 3. 检查相交
                        Point3dCollection intersectionPoints = new Point3dCollection();
                        line.IntersectWith(blockRef, Intersect.OnBothOperands, intersectionPoints, IntPtr.Zero, IntPtr.Zero);

                        if (intersectionPoints.Count > 0)
                        {
                            //ed.WriteMessage($"\n直线与块参照相交，交点数量: {intersectionPoints.Count}\n{line.Angle}\n{blockRef.Rotation}\n{new Command2().GetAngle(line, blockRef)}");
                            ed.WriteMessage($"\n直线与块参照相交，交点数量: {intersectionPoints.Count}");
                            // 遍历交点（如果需要）
                            foreach (Point3d point in intersectionPoints)
                            {
                                ed.WriteMessage($"\n交点坐标: ({point.X}, {point.Y}, {point.Z})");
                            }
                        }
                        else
                        {
                            ed.WriteMessage("\n直线与块参照没有相交部分。");
                            var blockTransform = blockRef.BlockTransform;
                            BlockTableRecord btr = (BlockTableRecord)tr.GetObject(blockRef.BlockTableRecord, OpenMode.ForRead);

                            // 接下来可以遍历btr内的实体
                            foreach (ObjectId id in btr)
                            {
                                // 获取块定义中的每一个实体
                                Entity ent = (Entity)tr.GetObject(id, OpenMode.ForRead);
                                // 在循环内部，获取变换后的实体
                                Entity transformedEnt = ent;
                                //try
                                //{
                                //    transformedEnt = ent.GetTransformedCopy(blockTransform);
                                //}
                                //catch (Exception ww)
                                //{
                                //    ed.WriteMessage("\nerrr:" + ww.Message);
                                //    break;
                                //}
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
                                            ed.WriteMessage("\n存在Line碰撞");
                                            break;
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
                                                    ed.WriteMessage("\n存在polyline碰撞");
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            
                        }

                        Vector3d lineVector = (line.EndPoint - line.StartPoint).GetNormal();
                        double blockRo = blockRef.Rotation;
                        Vector3d blockVector = new Vector3d(Math.Cos(blockRo), Math.Sin(blockRo), 0);
                        blockVector = blockVector.GetNormal();
                        double dotProduct = lineVector.X * blockVector.X + lineVector.Y * blockVector.Y + lineVector.Z * blockVector.Z;
                        double angleRadians = Math.Acos(dotProduct); // 夹角弧度
                        double angleDegrees = angleRadians * (180 / Math.PI); // 转换为角度
                        //ed.WriteMessage($"\n{dotProduct}\n{angleRadians}\n{angleDegrees}");
                    }
                    tr.Commit();
                }
            }
            catch (System.Exception ex)
            {
                ed.WriteMessage($"\n错误: {ex.Message}");
            }
        }
        //[CommandMethod("AUTOWALL")]
        public void AutoGenerateWalls()
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            Editor ed = doc.Editor;

            using (Transaction tr = db.TransactionManager.StartTransaction())
            {
                try
                {
                    // 配置参数
                    string[] windowDoorLayers = { "门窗", "DOOR", "WINDOW" }; // 门窗图层名称
                    string wallLayer = "WALL"; // 目标墙图层

                    // 获取所有块参照
                    BlockTable bt = tr.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;
                    BlockTableRecord modelSpace = tr.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForRead) as BlockTableRecord;

                    int createdLines = 0;

                    foreach (ObjectId id in modelSpace)
                    {
                        BlockReference br = tr.GetObject(id, OpenMode.ForRead) as BlockReference;
                        if (br == null) continue;

                        // 检查是否属于门窗图层
                        if (Array.IndexOf(windowDoorLayers, br.Layer) == -1) continue;

                        // 获取块的实际宽度（考虑缩放）
                        double width = GetBlockWidth(br);
                        if (width <= 0) continue;

                        // 生成墙线
                        GenerateWallLines(tr, db, br, width, wallLayer);
                        createdLines++;
                    }

                    ed.WriteMessage($"\n成功生成 {createdLines} 条墙线");
                }
                catch (Exception ex)
                {
                    ed.WriteMessage($"\n错误: {ex.Message}");
                }
                finally
                {
                    tr.Commit();
                }
            }
        }

        private double GetBlockWidth(BlockReference br)
        {
            // 方法1：通过几何范围计算宽度
            Extents3d ext = br.GeometricExtents;
            Vector3d size = ext.MaxPoint - ext.MinPoint;

            // 方法2：通过动态块参数获取（示例）
            /*try
            {
                DynamicBlockReferencePropertyCollection props = br.DynamicBlockReferencePropertyCollection;
                foreach (DynamicBlockReferenceProperty prop in props)
                {
                    if (prop.PropertyName == "宽度" || prop.PropertyName == "Width")
                    {
                        return Convert.ToDouble(prop.Value);
                    }
                }
            }
            catch {}*/

            // 根据旋转角度返回正确尺寸
            double rotation = br.Rotation;
            return Math.Abs(size.X * Math.Cos(rotation) + size.Y * Math.Sin(rotation));
        }

        private void GenerateWallLines(Transaction tr, Database db, BlockReference br, double width, string wallLayer)
        {
            BlockTable bt = tr.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;
            BlockTableRecord modelSpace = tr.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;

            double angle = br.Rotation;
            Point3d center = br.Position;

            // 计算垂直方向
            Vector3d direction = new Vector3d(Math.Cos(angle), Math.Sin(angle), 0);
            Vector3d perpendicular = direction.GetPerpendicularVector();

            // 计算墙线端点
            Point3d start = center - perpendicular * width / 2;
            Point3d end = center + perpendicular * width / 2;

            // 创建墙线
            Line wallLine = new Line(start, end)
            {
                Layer = wallLayer,
                ColorIndex = 7,  // 白色
                Linetype = "Continuous"
            };

            // 旋转墙线到正确方向
            wallLine.TransformBy(Matrix3d.Rotation(angle + Math.PI / 2, Vector3d.ZAxis, center));

            modelSpace.AppendEntity(wallLine);
            tr.AddNewlyCreatedDBObject(wallLine, true);
        }
    }
}
