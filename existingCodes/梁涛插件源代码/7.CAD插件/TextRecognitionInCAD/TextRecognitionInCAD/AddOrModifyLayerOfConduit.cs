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
            {
                ed.WriteMessage("\n用户取消了输入或输入无效。");
                return;
            }
            //// 提示用户选择一个实体
            //PromptEntityOptions options3 = new PromptEntityOptions("\n请选择线图层");

            //// 获取用户选择的实体
            //PromptEntityResult result3 = ed.GetEntity(options3);
            //if (result3.Status != PromptStatus.OK)
            //{
            //    ed.WriteMessage("\n未选择或操作取消.");
            //    return;
            //}
            //using (Transaction tr = db.TransactionManager.StartTransaction())
            //{
            //    Line selLine = tr.GetObject(result2.ObjectId, OpenMode.ForRead) as Line;
            //    Line selLine2 = tr.GetObject(result3.ObjectId, OpenMode.ForRead) as Line;
            //    var point3Ds = new Point3dCollection();
            //    selLine.IntersectWith(selLine2, Intersect.OnBothOperands, point3Ds, IntPtr.Zero, IntPtr.Zero);
            //    //ed.WriteMessage($"\n{AreCollinear(selLine2, selLine, ed)}\n{point3Ds.Count}\n{selLine.Id}\n{selLine2.Id}");
            //    //ed.WriteMessage($"\n{selLine.Color.Equals(selLine2.Color)}");

            //    tr.Commit();
            //}
            //return;

            var objId = result.ObjectId;
            ObjectId? selLineId = null;
            using (Transaction tr = doc.Database.TransactionManager.StartTransaction())
            {
                var obj = tr.GetObject(objId, OpenMode.ForRead);
                Line selLine = tr.GetObject(result2.ObjectId, OpenMode.ForRead) as Line;
                selLineId = selLine.Id;

                lineLayerName = selLine.Layer;
                //ed.WriteMessage($"\n{((Entity)tr.GetObject(result2.ObjectId, OpenMode.ForRead)).GetType().Name}");
                if (obj is BlockReference block)
                {
                    var blockTransform = block.BlockTransform;
                    blockName = block.Name;
                    blockLayerName = block.Layer;

                    string NValue = GetNValue(block, tr);

                    //ed.WriteMessage($"\n{IsIntersect(tr, block, selLine, new List<Matrix3d> { blockTransform })}");
                }
                tr.Commit();
            }
            using (Transaction tr = doc.Database.TransactionManager.StartTransaction())
            {
                //打开块表
                BlockTable bt = (BlockTable)tr.GetObject(db.BlockTableId, OpenMode.ForWrite);
                //打开块记录表(布局空间)
                BlockTableRecord psBtr = (BlockTableRecord)tr.GetObject(bt[BlockTableRecord.PaperSpace], OpenMode.ForWrite);
                //打开块记录表(模型空间)
                BlockTableRecord msBtr = (BlockTableRecord)tr.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite);

                foreach (var item in psBtr)
                {
                    Entity obj = (Entity)tr.GetObject(item, OpenMode.ForWrite);

                    if (obj != null && obj is Line line && line.Layer == lineLayerName) lineInfos.Add(new LineInfo(line) { Btr = psBtr });
                    else if (obj != null && obj is BlockReference blockReference && blockReference.Name == blockName && blockReference.Layer == blockLayerName)
                    {
                        blocks.Add(blockReference);
                    }
                }
                foreach (var item in msBtr)
                {
                    Entity obj = (Entity)tr.GetObject(item, OpenMode.ForWrite);
                    if (obj != null && obj is Line line && line.Layer == lineLayerName) lineInfos.Add(new LineInfo(line) { Btr = msBtr });
                    else if (obj != null && obj is BlockReference blockReference && blockReference.Name == blockName && blockReference.Layer == blockLayerName)
                    {
                        blocks.Add(blockReference);
                    }
                }
                // 1.当直线与块参照中的直线有相交部分时，获取该块参照的文字内容
                for (int i = 0; i < lineInfos.Count; i++)
                {
                    BlockReference blockReference = blocks.FirstOrDefault(b => IsIntersect(tr, b, lineInfos[i].Line, new List<Matrix3d>() { b.BlockTransform }));
                    if (blockReference != null) lineInfos[i].BlockN = GetNValue(blockReference, tr);
                }

                // 2.若直线没有对应块名称，则判断是否存在共线且有块名称的直线，若存在，则赋值相同块名称
                for (int i = 0; i < lineInfos.Count; i++)
                {
                    if (!string.IsNullOrEmpty(lineInfos[i].BlockN)) continue;
                    var filterIifos = lineInfos.Where(l => !string.IsNullOrEmpty(l.BlockN) && l.Line.Color.Equals(lineInfos[i].Line.Color)).Select(x => x);
                    var filterLine = filterIifos.FirstOrDefault(f => AreCollinear(lineInfos[i].Line, f.Line, null));
                    if (filterLine == null) continue;
                    lineInfos[i].BlockN = filterLine.BlockN;
                }
                //ed.WriteMessage($"\n{lineInfos.First(l => Convert.ToInt64(l.Line.Id.ToString().Replace("(", "").Replace(")", "")) == 2375037601792).BlockN}");
                // 3.判断是否有与该直线相交且有块名称的直线，若存在则赋值相同块名称
                for (int i = 0; i < lineInfos.Count; i++)
                {
                    if (!string.IsNullOrEmpty(lineInfos[i].BlockN)) continue;
                    var filterInfos = lineInfos.Where(l => !string.IsNullOrEmpty(l.BlockN) && lineInfos[i].Line.Color.Equals(l.Line.Color)).Select(x => x);

                    foreach (var item in filterInfos)
                    {
                        var col = new Point3dCollection();
                        item.Line.IntersectWith(lineInfos[i].Line, Intersect.OnBothOperands, col, IntPtr.Zero, IntPtr.Zero);
                        if (col.Count > 0)
                        {
                            lineInfos[i].BlockN = item.BlockN;
                            break;
                        }
                    }
                }
                LayerTable lt = tr.GetObject(db.LayerTableId, OpenMode.ForRead) as LayerTable;
                // 新增输入数值的判断，若相加大于输入值则将两条直线氛围两个图层5+3，输入4则分为两个-4图层
                lineInfos = lineInfos.Where(l => !string.IsNullOrEmpty(l.BlockN)).ToList();
                foreach (var item in lineInfos)
                {
                    List<string> nums = item.BlockN.Split('+').ToList();
                    double count = 0;
                    nums.ForEach(n => count += Convert.ToDouble(n));
                    if (item.BlockN.Contains("+"))
                    {
                        if (count <= number) continue;
                        double num1 = number;
                        double num2 = count - number;
                        string newLayerName1 = item.Line.Layer + "-" + num1;
                        string newLayerName2 = item.Line.Layer + "-" + num2;

                        // 2. 计算垂直偏移向量
                        Point3d startPt = item.Line.StartPoint;
                        Point3d endPt = item.Line.EndPoint;
                        Vector3d direction = endPt - startPt;
                        Vector3d perpendicular = direction.GetPerpendicularVector().Negate(); // 左偏移
                        perpendicular = perpendicular.GetNormal() * 20; // 20mm偏移

                        // 3. 计算新直线的起点和终点
                        Point3d newStart = startPt.Add(perpendicular);
                        Point3d newEnd = endPt.Add(perpendicular);

                        // 4. 创建新直线并设置属性
                        Line newLine = new Line(newStart, newEnd);
                        //newLine.Layer = item.Line.Layer; // 继承原图层
                        //newLine.Color = item.Line.Color;

                        // 5. 将新直线添加到模型空间
                        item.Btr.AppendEntity(newLine);
                        tr.AddNewlyCreatedDBObject(newLine, true);

                        ChangeLayer(lt, item.Line, newLayerName1, tr);
                        ChangeLayer(lt, newLine, newLayerName2, tr);
                    }
                    else
                    {
                        string newLayerName = item.Line.Layer + "-" + item.BlockN;
                        if (!lt.Has(newLayerName))
                        {
                            lt.UpgradeOpen();
                            LayerTableRecord ltr = new LayerTableRecord();
                            ltr.Name = newLayerName;
                            lt.Add(ltr);
                            tr.AddNewlyCreatedDBObject(ltr, true);
                        }
                        item.Line.UpgradeOpen();
                        item.Line.Layer = newLayerName;
                    }
                }


                tr.Commit();
            }



        }
        /// <summary>
        /// 更改实体所在图层
        /// </summary>
        /// <param name="lt"></param>
        /// <param name="entity"></param>
        /// <param name="newLayerName"></param>
        /// <param name="tr"></param>
        private void ChangeLayer(LayerTable lt, Entity entity, string newLayerName, Transaction tr)
        {
            if (!lt.Has(newLayerName))
            {
                lt.UpgradeOpen();
                LayerTableRecord ltr = new LayerTableRecord();
                ltr.Name = newLayerName;
                lt.Add(ltr);
                tr.AddNewlyCreatedDBObject(ltr, true);
            }
            entity.UpgradeOpen();
            entity.Layer = newLayerName;
        }
        // 判断两直线是否共线
        private bool AreCollinear(Line line1, Line line2, Editor ed)
        {
            bool result = false;
            Vector3d v1 = (line1.StartPoint - line1.EndPoint).GetNormal();
            Vector3d v2 = (line2.StartPoint - line2.EndPoint).GetNormal();

            Vector3d v3 = (line2.StartPoint - line2.EndPoint).GetNormal();
            Vector3d v4 = (line2.StartPoint - line1.EndPoint).GetNormal();
            Vector3d v5 = (line2.StartPoint - line1.StartPoint).GetNormal();
            //Tolerance tolerance = new Tolerance(1e-6, 30 * Math.PI / 180);
            //if (v1.IsEqualTo(v2,tolerance) || v1.IsEqualTo(v2.Negate(), tolerance))
            //{
            //    result = true;
            //    ed.WriteMessage($"\n{v1}||{v2}||{v1.X * v2.Y - v1.Y * v2.X}");
            //}
            //else
            //{
            //    ed.WriteMessage($"\n{v1}||{v2}||{v1.X * v2.Y - v1.Y * v2.X}");
            //}
            if (Math.Abs(v1.X * v2.Y - v1.Y * v2.X) < 0.1 && (Math.Abs(v3.X * v4.Y - v3.Y * v4.X) < 0.1 || Math.Abs(v3.X * v5.Y - v3.Y * v5.X) < 0.05))
            {
                result = true;
            }
            //ed.WriteMessage($"\n{v1}||{v2}||{v1.X * v2.Y - v1.Y * v2.X}");
            //ed.WriteMessage($"\n{v3}||{v4}||{v3.X * v4.Y - v3.Y * v4.X}");
            //ed.WriteMessage($"\n{v3}||{v5}||{v3.X * v5.Y - v3.Y * v5.X}");

            return result;
        }
        private bool IsIntersect(Transaction tr, BlockReference block, Line line, List<Matrix3d> blockTransform)
        {
            bool intersect = false;
            List<Matrix3d> tfs = blockTransform.Select(x => x).ToList();
            BlockTableRecord blockBtr = tr.GetObject(block.BlockTableRecord, OpenMode.ForRead) as BlockTableRecord;

            foreach (ObjectId id in blockBtr)
            {
                Entity entity = tr.GetObject(id, OpenMode.ForRead) as Entity;

                if (entity is BlockReference subRefer)
                {
                    Matrix3d subTranform = subRefer.BlockTransform;
                    BlockTableRecord subBtr = tr.GetObject(subRefer.BlockTableRecord, OpenMode.ForRead) as BlockTableRecord;
                    foreach (var subId in subBtr)
                    {
                        Entity subEntity = tr.GetObject(subId, OpenMode.ForRead) as Entity;
                        if (subEntity is Line line1)
                        {
                            tfs.Add(subTranform);
                            tfs.Reverse();
                            intersect = IsIntersect(line1, line, tfs);
                            break;
                        }
                    }
                }
            }
            return intersect;
        }
        private bool IsIntersect(Line subLine, Line selLine, List<Matrix3d> transforms)
        {
            bool intersect = false;
            Point3d subP0 = subLine.StartPoint;
            Point3d subP1 = subLine.EndPoint;
            transforms.ForEach(tf => subP0 = subP0.TransformBy(tf));
            transforms.ForEach(tf => subP1 = subP1.TransformBy(tf));

            Line subNewLine = new Line(subP0, subP1);
            Point3dCollection dCollection = new Point3dCollection();
            subNewLine.IntersectWith(selLine, Intersect.OnBothOperands, dCollection, IntPtr.Zero, IntPtr.Zero);
            if (dCollection.Count > 0) intersect = true;
            return intersect;
        }
        // 获取块参照中N参数的值
        private string GetNValue(BlockReference block, Transaction tr)
        {
            string NValue = "";
            foreach (ObjectId attrId in block.AttributeCollection)
            {
                AttributeReference attr = tr.GetObject(attrId, OpenMode.ForRead) as AttributeReference;
                if (attr.Tag.Equals("N", StringComparison.OrdinalIgnoreCase))
                {
                    NValue = attr.TextString;
                    //ed.WriteMessage($"\n属性N的值：{attr.TextString}");
                    break; // 找到后退出循环
                }
            }
            return NValue;
        }


    }
    public class LineInfo
    {
        // 线对应指定块中的文字内容
        public string BlockN { get; set; }
        // 选中指定图层中的线
        public Line Line { get; set; }
        // 直线所在空间（布局空间、模型空间）
        public BlockTableRecord Btr { get; set; }
        public LineInfo(Line line)
        {
            Line = line;
        }
    }
}
