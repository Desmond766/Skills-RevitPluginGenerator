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
                        if (length <= 400)
                        {
                            lines.Add(line);
                        }
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
                            if (blockEntity is Line blockLine && blockLine.Layer == layerName)
                            {
                                var p0 = blockLine.StartPoint;
                                var p1 = blockLine.EndPoint;
                                p0 = p0.TransformBy(blockRefTransform);
                                p1 = p1.TransformBy(blockRefTransform);
                                Line newLine = new Line(p0, p1);
                                lines.Add(newLine);
                            }
                        }
                    }

                }
                tr.Commit();
            }
            // 记录已经进行二次分组的直线
            List<Line> linesHasGroup = new List<Line>();
            // 记录二次分组后的直线集合
            List<List<Line>> finalLines = new List<List<Line>>();
            // 按长度分组
            var groupedLines = lines
                .GroupBy(line => line.Length)
                .OrderBy(group => group.Key)
                .ToList();
            foreach (var group in groupedLines)
            {
                var linesInGroup = group.ToList();
                //ed.WriteMessage($"\n{linesHasGroup.Count}");
                for (int i = 0; i < linesInGroup.Count - 1; i++)
                {
                    Line line1 = linesInGroup[i];
                    if (linesHasGroup.Contains(line1)) continue;
                    List<Line> filterLines = new List<Line>();
                    filterLines.Add(line1);
                    linesHasGroup.Add(line1);
                    for (int k = 0; k < linesInGroup.Count - 1; k++)
                    {
                        Line line2 = linesInGroup[k];
                        if (line2 == line1 || linesHasGroup.Contains(line2)) continue;
                        if (CanFormRectangle(line1, line2))
                        {
                            filterLines.Add(line2);
                            linesHasGroup.Add(line2);
                        }
                    }
                    finalLines.Add(filterLines);
                }

            }
            //ed.WriteMessage($"\n{lines.Count}" + $"|||{finalLines.Count}");
            int count = 0;
            foreach (var item in finalLines)
            {
                if (item.Count <= 1)
                {
                    count++;
                }
            }
            //ed.WriteMessage($"\n{count}" + $"|||{finalLines.Count}");
            using (Transaction tr = doc.Database.TransactionManager.StartTransaction())
            {
                // 获取块表记录（模型空间）
                BlockTable blockTable = (BlockTable)tr.GetObject(db.BlockTableId, OpenMode.ForWrite);
                BlockTableRecord btr = (BlockTableRecord)tr.GetObject(blockTable[BlockTableRecord.ModelSpace], OpenMode.ForWrite);

                foreach (var item in finalLines)
                {
                    List<List<Line>> hasCreateGroup = new List<List<Line>>();
                    if (item.Count <= 1) continue;
                    for (int i = 0; i < item.Count - 1; i++)
                    {
                        Line line1 = item[i];
                        List<Line> lines1 = item.Select(x => x).OrderBy(x => Distance(x, item[i])).ToList();
                        lines1.Remove(lines1.First());

                        int createCount = 0;
                        foreach (var line in lines1)
                        {
                            createCount++;
                            if (hasCreateGroup.Any(x => x.Contains(line1) && x.Contains(line))) continue;

                            List<Line> newLines = GetDotLines(line1, line);
                            foreach (var newLine in newLines)
                            {
                                // 将直线添加到模型空间
                                btr.AppendEntity(newLine);
                                tr.AddNewlyCreatedDBObject(newLine, true);
                                //newLine.UpgradeOpen();
                                //newLine.Layer = layerName;
                            }


                            if (createCount == 2) break;
                        }
                    }

                }



                tr.Commit();
            }
            ed.WriteMessage("\n完成");
        }

        private List<Line> GetDotLines(Line line1, Line line)
        {
            List<Line> newLines = new List<Line>();
            var p1 = line1.StartPoint;
            var p2 = line1.EndPoint;
            var p3 = line.StartPoint;
            var p4 = line.EndPoint;
            if (IsPerpendicular(p1, p2, p3))
            {
                newLines.Add(new Line(p2, p3));
                newLines.Add(new Line(p1, p4));
            }
            else
            {
                newLines.Add(new Line(p1, p3));
                newLines.Add(new Line(p2, p4));
            }

            return newLines;
        }

        private double Distance(Line line1, Line line2)
        {
            Point3d p1 = GetCenterP(line1);
            Point3d p2 = GetCenterP(line2);
            return p1.DistanceTo(p2);
        }

        private Point3d GetCenterP(Line line)
        {

            Point3d p1 = line.StartPoint;
            Point3d p2 = line.EndPoint;
            Point3d point3D = new Point3d((p1.X + p2.X) / 2, (p1.Y + p2.Y) / 2, (p1.Z + p2.Z) / 2);

            return point3D;
        }

        private bool CanFormRectangle(Line line1, Line line2)
        {
            if (!AreLinesParallel(line1, line2)) return false;
            Point3d p10 = line1.StartPoint;
            Point3d p11 = line1.EndPoint;
            Point3d p20 = line2.StartPoint;
            Point3d p21 = line2.EndPoint;
            if (IsPerpendicular(p10, p11, p20))
            {
                if (IsPerpendicular(p20, p21, p10))
                {
                    return true;
                }
            }
            else if (IsPerpendicular(p10, p11, p21))
            {
                if (IsPerpendicular(p21, p20, p10))
                {
                    return true;
                }
            }
            return false;

        }
        public bool AreLinesParallel(Line line1, Line line2)
        {
            // 获取两条直线的方向向量
            Vector3d direction1 = line1.EndPoint - line1.StartPoint;
            Vector3d direction2 = line2.EndPoint - line2.StartPoint;

            // 计算两条直线方向向量的点积
            double dotProduct = direction1.DotProduct(direction2);

            // 计算两条直线方向向量的长度
            double length1 = direction1.Length;
            double length2 = direction2.Length;

            // 判断两条直线的方向向量是否平行
            // 两条直线平行当且仅当它们的点积等于两个向量长度乘积
            return Math.Abs(Math.Abs(dotProduct) - length1 * length2) < 0.001;
        }
        // 计算两个向量的点积，判断是否垂直
        public static bool IsPerpendicular(Point3d p1, Point3d p2, Point3d p3)
        {
            Vector3d direction1 = p1 - p2;
            Vector3d direction2 = p2 - p3;
            return Math.Abs(direction1.DotProduct(direction2)) < 0.0001;
        }
    }
}
