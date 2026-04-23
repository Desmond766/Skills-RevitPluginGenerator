using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.GraphicsInterface;
using Autodesk.AutoCAD.Runtime;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Application = Autodesk.AutoCAD.ApplicationServices.Application;
using Line = Autodesk.AutoCAD.DatabaseServices.Line;
using Polyline = Autodesk.AutoCAD.DatabaseServices.Polyline;

namespace TextRecognitionInCAD
{
    public class ModifyLayerOfLight
    {
        // 修改CAD图中灯具的图层
        //[CommandMethod("ModifyLayerOfLight")]
        [CommandMethod("MLOL")]
        public void MLOL()
        {
            // 活动文档
            Document doc = Application.DocumentManager.MdiActiveDocument;
            // 数据库
            Database db = doc.Database;
            // 编辑器
            Editor ed = doc.Editor;

            //// 图层名称
            //string layerName = "";
            //// 块参照名称
            //string name = "";

            // 块参照图层名称集合
            HashSet<string> layerNames = new HashSet<string>();
            // 块参照名称集合
            HashSet<string> blockNames = new HashSet<string>();

            // 提示用户选择多个块参照
            PromptSelectionOptions promptOptions = new PromptSelectionOptions();
            promptOptions.MessageForAdding = "\n请选择一个或多个不同灯具的块参照";
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
            //// 提示用户选择一个实体
            //PromptEntityOptions options = new PromptEntityOptions("\n请选择一个灯具");
            //options.SetRejectMessage("\n所选对象不是块参照.");
            //options.AddAllowedClass(typeof(BlockReference), true); // 只允许选择块参照

            //// 获取用户选择的实体
            //PromptEntityResult result = ed.GetEntity(options);
            //if (result.Status != PromptStatus.OK)
            //{
            //    ed.WriteMessage("\n未选择块参照或操作取消.");
            //    return;
            //}

            //// 获取选中的实体
            //ObjectId blockRefId = result.ObjectId;

            // 灯具块参照集合
            List<BlockReference> lightReferences = new List<BlockReference>();

            // 带"W"的单行文本集合
            List<DBText> texts = new List<DBText>();

            // 打开数据库进行访问
            using (Transaction tr = doc.Database.TransactionManager.StartTransaction())
            {
                //BlockReference blockRef = tr.GetObject(blockRefId, OpenMode.ForRead) as BlockReference;
                //if (blockRef != null)
                //{
                //    // 获取块参照所在的图层名称
                //    layerName = blockRef.Layer;
                //    name = blockRef.Name;

                //    ed.WriteMessage($"\n块参照所在的图层是: {layerName}");
                //}
                //else
                //{
                //    Entity entity = tr.GetObject(blockRefId, OpenMode.ForRead) as Entity;
                //    if (entity != null)
                //    {
                //        layerName = "\n实体所在图层是：" + entity.Layer;
                //        if (entity is DBText bText) layerName += "文字内容为：" + bText.TextString;
                //        ed.WriteMessage(layerName);
                //    }
                //}
                //打开块表
                BlockTable bt = (BlockTable)tr.GetObject(db.BlockTableId, OpenMode.ForRead);
                //打开块记录表
                BlockTableRecord btr = (BlockTableRecord)tr.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForRead);

                foreach (ObjectId objId in btr)
                {

                    var obj = tr.GetObject(objId, OpenMode.ForRead);
                    if (obj is BlockReference blockReference && layerNames.Contains(blockReference.Layer) && blockNames.Contains(blockReference.Name))
                    {
                        //ed.WriteMessage(blockReference.Position.ToString() + "\n" + blockReference.Name);
                        //break;
                        lightReferences.Add(blockReference);
                    }
                    else if (obj is DBText dBText && dBText.TextString.Contains("W") && dBText.TextString.Count() <= 4)
                    {
                        texts.Add(dBText);
                    }
                }

                // 更改灯具的图层
                foreach (BlockReference light in lightReferences)
                {
                    // HACK: 限定每个灯具获取灯具编号的范围，范围为半径1000mm
                    // 获取离该灯具最近的回路编号
                    DBText nearText = texts.Where(t => t.Position.DistanceTo(light.Position) < 1000.0).OrderBy(t => t.Position.DistanceTo(light.Position)).FirstOrDefault();

                    if (nearText == null) continue;
                    //if (nearText == null) nearText = texts.OrderBy(t => t.Position.DistanceTo(light.Position)).FirstOrDefault();

                    string newLayerName = light.Layer + "-" + nearText.TextString;

                    LayerTable lt = tr.GetObject(db.LayerTableId, OpenMode.ForRead) as LayerTable;
                    if (!lt.Has(newLayerName))
                    {
                        lt.UpgradeOpen();
                        LayerTableRecord ltr = new LayerTableRecord();
                        ltr.Name = newLayerName;
                        lt.Add(ltr);
                        tr.AddNewlyCreatedDBObject(ltr, true);
                    }

                    light.UpgradeOpen();
                    light.Layer = newLayerName;
                }

                ed.WriteMessage("\n完成!");
                tr.Commit();
            }

            //string layerName = pr.StringResult;
            //List<Entity> entities = new List<Entity>();
            //using (Transaction tr = db.TransactionManager.StartTransaction())
            //{
            //    //打开块表
            //    BlockTable bt = (BlockTable)tr.GetObject(db.BlockTableId, OpenMode.ForRead);
            //    //打开块记录表
            //    BlockTableRecord btr = (BlockTableRecord)tr.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForRead);

            //    foreach (ObjectId objId in btr)
            //    {

            //        Entity ent = tr.GetObject(objId, OpenMode.ForRead) as Entity;
            //        if (ent.Layer == layerName)
            //        {
            //            ed.WriteMessage(ent.)
            //        }
            //    }
            //}
        }

        // 修改线管的图层
        [CommandMethod("MLOC")]
        public void ModifyLayerOfConduit()
        {
            // 活动文档
            Document doc = Application.DocumentManager.MdiActiveDocument;
            // 数据库
            Database db = doc.Database;
            // 编辑器
            Editor ed = doc.Editor;

            // 线管图层名称
            string layerName = "";
            // 回路编号图层名称
            string routeLayerName = "";
            // 规则编号
            int rule;

            // 1.用户选择指定图层的线管，获取该图层的所有多段线
            // 提示用户选择一个实体
            PromptEntityOptions options = new PromptEntityOptions("\n请选择线管图层");
            //options.SetRejectMessage("\n所选对象不是多段线.");
            //options.AddAllowedClass(typeof(Polyline), true);

            // 获取用户选择的实体
            PromptEntityResult result = ed.GetEntity(options);
            if (result.Status != PromptStatus.OK)
            {
                ed.WriteMessage("\n未选择多段线或操作取消.");
                return;
            }

            // 获取选中的实体
            ObjectId entityId = result.ObjectId;

            // 2.用户选择回路编号所在图层，获取该图层中所有多段线与文字
            // 提示用户选择一个实体
            PromptEntityOptions options2 = new PromptEntityOptions("\n请选择回路编号图层");
            //options2.SetRejectMessage("\n所选对象不是实体.");
            //options2.AddAllowedClass(typeof(Entity), true);

            // 获取用户选择的实体
            PromptEntityResult result2 = ed.GetEntity(options2);
            if (result2.Status != PromptStatus.OK)
            {
                ed.WriteMessage("\n未选择实体或操作取消.");
                return;
            }

            // 配置输入选项
            PromptIntegerOptions optionsT = new PromptIntegerOptions("\n请输入文字提取规则:\n1:提取图层所有文本\n2:提取以字母开头数字结尾的文本\n3:提取纯数字的文本\n: ");
            optionsT.AllowNegative = false;   // 是否允许负数
            optionsT.AllowZero = false;        // 是否允许零
            optionsT.DefaultValue = 5;      // 默认值（按 Enter 时使用）

            // 获取用户输入
            PromptIntegerResult resultT = ed.GetInteger(optionsT);

            // 处理结果
            if (resultT.Status == PromptStatus.OK)
            {
                rule = resultT.Value;
                ed.WriteMessage($"\n使用规则: {rule}提取文字");
            }
            else
            {
                ed.WriteMessage("\n用户取消了输入或输入无效。");
                return;
            }

            // 获取选中的实体
            ObjectId entityId2 = result2.ObjectId;

            // 带"W"的单行文本集合
            List<DBText> texts = new List<DBText>();
            // 回路编号图层线段集合
            List<Line> lines = new List<Line>();
            // 线管多段线集合
            List<Polyline> polylines = new List<Polyline>();

            using (Transaction tr = doc.Database.TransactionManager.StartTransaction())
            {
                Entity entity = tr.GetObject(entityId, OpenMode.ForRead) as Entity;
                layerName = entity.Layer;
                ed.WriteMessage($"\n线管所在的图层是: {layerName}");
                Entity entity2 = tr.GetObject(entityId2, OpenMode.ForRead) as Entity;
                routeLayerName = entity2.Layer;
                ed.WriteMessage($"\n回路编号所在的图层是: {routeLayerName}");

                if (entity is Polyline polyline4 && entity2 is DBText text)
                {
                    //// 获取线段的起点和终点坐标
                    //Point3d startPoint = polyline4.StartPoint;
                    //Point3d endPoint = polyline4.EndPoint;

                    //// 计算中点坐标
                    //double midX = (startPoint.X + endPoint.X) / 2;
                    //double midY = (startPoint.Y + endPoint.Y) / 2;
                    //double midZ = (startPoint.Z + endPoint.Z) / 2;
                    //var point = new Point3d(midX, midY, midZ);
                    //ed.WriteMessage($"\n{point.DistanceTo(text.Position)}");
                    var p = polyline4.EndPoint;
                    p = polyline4.StartPoint;
                    var minP = new Point2d(p.X - 100, p.Y - 100);
                    var maxP = new Point2d(p.X + 100, p.Y + 100);
                    var extend1 = new Extents2d(minP, maxP);

                    Extents3d textExtend = text.Bounds.Value;
                    var minP2 = new Point2d(textExtend.MinPoint.X, textExtend.MinPoint.Y);
                    var maxP2 = new Point2d(textExtend.MaxPoint.X, textExtend.MaxPoint.Y);
                    var extend2 = new Extents2d(minP2, maxP2);

                    bool res = CheckCollision(extend1, extend2);
                    //if (res)
                    //{
                    //    ed.WriteMessage("\nTure");
                    //}

                    //return;
                }

                if (entity2 is Polyline polyline2 && entity is Polyline polyline3)
                {
                    //ed.WriteMessage("\nyes");
                    Point3dCollection point3Ds = new Point3dCollection();
                    for (int i = 0; i < polyline2.NumberOfVertices - 1; i++)
                    {
                        Point3d startPoint = polyline2.GetPoint3dAt(i);
                        Point3d endPoint = polyline2.GetPoint3dAt(i + 1);

                        startPoint = new Point3d(startPoint.X, startPoint.Y, 0);
                        endPoint = new Point3d(endPoint.X, endPoint.Y, 0);

                        Line line = new Line(startPoint, endPoint);
                        for (int j = 0; j < polyline3.NumberOfVertices - 1; j++)
                        {
                            Point3d startPoint2 = polyline3.GetPoint3dAt(j);
                            Point3d endPoint2 = polyline3.GetPoint3dAt(j + 1);

                            startPoint2 = new Point3d(startPoint2.X, startPoint2.Y, 0);
                            endPoint2 = new Point3d(endPoint2.X, endPoint2.Y, 0);

                            Line line2 = new Line(startPoint2, endPoint2);

                            line.IntersectWith(line2, Intersect.OnBothOperands, point3Ds, IntPtr.Zero, IntPtr.Zero);


                            //if (point3Ds.Count > 0)
                            //{
                            //    foreach (Point3d item in point3Ds)
                            //    {
                            //        ed.WriteMessage($"\n{item}{startPoint}{endPoint}{item.DistanceTo(endPoint)}\n{item.DistanceTo(startPoint)}");
                            //    }
                            //}
                            //else
                            //{
                            //    ed.WriteMessage($"\n{startPoint}{endPoint}{startPoint2}{endPoint2}");
                            //}
                        }
                    }

                    //return;

                }
                //打开块表
                BlockTable bt = (BlockTable)tr.GetObject(db.BlockTableId, OpenMode.ForRead);
                //打开块记录表
                BlockTableRecord btr = (BlockTableRecord)tr.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForRead);
                foreach (var objId in btr)
                {
                    var obj = tr.GetObject(objId, OpenMode.ForRead);
                    if (obj is Polyline polyline && polyline.Layer == layerName)
                    {
                        //// 迭代多段线的各个线段
                        //for (int i = 0; i < polyline.NumberOfVertices - 1; i++)
                        //{
                        //    Point3d startPoint = polyline.GetPoint3dAt(i);
                        //    Point3d endPoint = polyline.GetPoint3dAt(i + 1);

                        //    Line line = new Line(startPoint, endPoint);
                        //    lines.Add(line);
                        //}
                        polylines.Add(polyline);
                    }
                    else if (obj is Polyline polyline1 && polyline1.Layer == routeLayerName)
                    {
                        // 迭代多段线的各个线段
                        for (int i = 0; i < polyline1.NumberOfVertices - 1; i++)
                        {
                            Point3d startPoint = polyline1.GetPoint3dAt(i);
                            startPoint = new Point3d(startPoint.X, startPoint.Y, 0);
                            Point3d endPoint = polyline1.GetPoint3dAt(i + 1);
                            endPoint = new Point3d(endPoint.X, endPoint.Y, 0);

                            Line line = new Line(startPoint, endPoint);
                            lines.Add(line);
                        }
                    }
                    else if (obj is DBText dBText && dBText.Layer == routeLayerName && IsLetterStartAndDigitEnd(dBText.TextString, rule) && dBText.TextString.Count() <= 5)
                    {
                        texts.Add(dBText);
                    }
                }

                // 记录文字与线段对应关系
                List<TextConuitInfo> textConuitInfos = new List<TextConuitInfo>();
                double scope = lines.OrderByDescending(x => x.Length).First().Length / 2 + 500;
                //ed.WriteMessage($"\n{scope}");
                foreach (var line in lines)
                {
                    // 获取线段的起点和终点坐标
                    Point3d startPoint = line.StartPoint;
                    Point3d endPoint = line.EndPoint;

                    // 计算中点坐标
                    double midX = (startPoint.X + endPoint.X) / 2;
                    double midY = (startPoint.Y + endPoint.Y) / 2;
                    double midZ = (startPoint.Z + endPoint.Z) / 2;
                    var centerPoint = new Point3d(midX, midY, midZ);
                    // TODO: 根据回路编号的多段线长度来决定范围(待修改)
                    var filterTexts = texts.Where(t => PointInScope(line, t.Position, 3000)).Where(t2 => t2.Position.Y - midY > 0 && midX - t2.Position.X > 0).OrderBy(t3 => centerPoint.DistanceTo(t3.Position));
                    if (filterTexts.Count() > 0)
                    {
                        textConuitInfos.Add(new TextConuitInfo() { DBText = filterTexts.First(), Line = line });
                    }
                }

                // 3.对两图层进行判断，若回路编号图层有线段与线管图层的线段相交且末端坐标点在该线管图层线段上，就将回路编号赋值给该多段线
                int count = 0;
                foreach (var polyline in polylines)
                {
                    //var conduitLines = new List<Line>();
                    //string routeText = "";
                    // 迭代多段线的各个线段
                    for (int i = 0; i < polyline.NumberOfVertices - 1; i++)
                    {
                        Point3d startPoint = polyline.GetPoint3dAt(i);
                        startPoint = new Point3d(startPoint.X, startPoint.Y, 0);
                        Point3d endPoint = polyline.GetPoint3dAt(i + 1);
                        endPoint = new Point3d(endPoint.X, endPoint.Y, 0);

                        Line line = new Line(startPoint, endPoint);

                        
                        for (int j = 0; j < lines.Count; j++)
                        {

                            Point3dCollection point3Ds = new Point3dCollection();
                            //line.IntersectWith(lines[j], Intersect.OnBothOperands, point3Ds, IntPtr.Zero, IntPtr.Zero);
                            // 因为存在一些线段末端与线管线段有一定距离，所以需要延长回路编号的线段
                            line.IntersectWith(lines[j], Intersect.ExtendArgument, point3Ds, IntPtr.Zero, IntPtr.Zero);
                            if (point3Ds.Count == 0) continue;
                            foreach (Point3d point3D in point3Ds)
                            {
                                //if (point3D.DistanceTo(lines[j].StartPoint) < 0.1 || point3D.DistanceTo(lines[j].EndPoint) < 0.1)
                                if (point3D.DistanceTo(lines[j].StartPoint) < 10 || point3D.DistanceTo(lines[j].EndPoint) < 10)
                                {
                                    //var info = textConuitInfos.FirstOrDefault(x => x.Line == lines[j]);
                                    var startP = lines[j].StartPoint;
                                    var endP = lines[j].EndPoint;
                                    // 远离两线段相交点的回路编号线段创建坐标点
                                    var farP = point3D.DistanceTo(endP) < 10 ? startP : endP;

                                    double midX = (startP.X + endP.X) / 2;
                                    double midY = (startP.Y + endP.Y) / 2;
                                    double midZ = (startP.Z + endP.Z) / 2;
                                    var centerPoint = new Point3d(midX, midY, midZ);

                                    var minP = new Point2d(farP.X - 1000, farP.Y - 400);
                                    var maxP = new Point2d(farP.X + 1000, farP.Y + 400);
                                    var extend1 = new Extents2d(minP, maxP);
                                    DBText findText = texts/*.Where(t => PointInScope(line, t.Position, 3000))*/.Where(t4 => CheckCollision(extend1, GetExtents2D(t4)))
                                        .Where(t2 => t2.Position.Y - farP.Y > 0).OrderBy(t3 => centerPoint.DistanceTo(t3.Position)).FirstOrDefault();
                                    // 若视图朝向为右上，则需要用此过滤方法
                                    //DBText findText = texts/*.Where(t => PointInScope(line, t.Position, 3000))*/.Where(t4 => CheckCollision(extend1, GetExtents2D(t4)))
                                    //    .Where(t2 => t2.Position.Y - midY > 0).OrderBy(t3 => centerPoint.DistanceTo(t3.Position)).FirstOrDefault();
                                    if (findText == null) continue;

                                    count++;
                                    string newLayerNmae = polyline.Layer + "-" + findText.TextString;

                                    LayerTable lt = tr.GetObject(db.LayerTableId, OpenMode.ForRead) as LayerTable;
                                    if (!lt.Has(newLayerNmae))
                                    {
                                        lt.UpgradeOpen();
                                        LayerTableRecord ltr = new LayerTableRecord();
                                        ltr.Name = newLayerNmae;
                                        lt.Add(ltr);
                                        tr.AddNewlyCreatedDBObject(ltr, true);
                                    }

                                    polyline.UpgradeOpen();
                                    polyline.Layer = newLayerNmae;

                                    // 成功修改线管图层跳转到下一次循环
                                    goto Next;
                                }
                            }
                        }
                        //conduitLines.Add(line);
                    }
                Next:;

                }


                ed.WriteMessage($"\n选中线管图层多段线数量:{polylines.Count}\n成功修改数量:{count}\n完成!");
                tr.Commit();
            }




        }
        // 获取实体的边界框
        public Extents2d GetExtents2D(Entity entity)
        {
            Extents2d extend2d = new Extents2d();
            if (entity is DBText text)
            {
                Extents3d textExtend = text.Bounds.Value;
                var minP2 = new Point2d(textExtend.MinPoint.X, textExtend.MinPoint.Y);
                var maxP2 = new Point2d(textExtend.MaxPoint.X, textExtend.MaxPoint.Y);
                extend2d = new Extents2d(minP2, maxP2);
            }
            return extend2d;
        }
        // 判断两个边界框是否相交
        public bool CheckCollision(Extents2d box1, Extents2d box2)
        {
            // 判断X轴是否重叠
            bool xOverlap = box1.MaxPoint.X >= box2.MinPoint.X && box1.MinPoint.X <= box2.MaxPoint.X;

            // 判断Y轴是否重叠
            bool yOverlap = box1.MaxPoint.Y >= box2.MinPoint.Y && box1.MinPoint.Y <= box2.MaxPoint.Y;


            // 如果在三个方向上都有重叠，则认为两个边界框碰撞
            return xOverlap && yOverlap;
        }
        private bool PointInScope(Line line, Point3d position, double scope)
        {
            // 获取线段的起点和终点坐标
            Point3d startPoint = line.StartPoint;
            Point3d endPoint = line.EndPoint;

            // 计算中点坐标
            double midX = (startPoint.X + endPoint.X) / 2;
            double midY = (startPoint.Y + endPoint.Y) / 2;
            double midZ = (startPoint.Z + endPoint.Z) / 2;
            var point = new Point3d(midX, midY, midZ);
            return point.DistanceTo(position) <= scope;
        }

        /// <summary>
        /// 判断文字是否符合正则表达式
        /// </summary>
        /// <param name="input">输入的文字</param>
        /// <param name="rule">规则</param>
        /// <returns></returns>
        private bool IsLetterStartAndDigitEnd(string input, int rule)
        {
            if (rule == 2)
            {
                // 正则表达式：以字母开始，数字结尾，中间可以有任意字符
                string pattern = @"^[A-Za-z].*\d$";
                return Regex.IsMatch(input, pattern);
            }else if (rule == 3)
            {
                return !input.ToCharArray().Any(c => !Char.IsDigit(c));
            }
            else if (rule == 1)
            {
                return true;
            }
            return false;

        }
    }
    // 记录文字与对应路由图层的多段线对应关系
    public class TextConuitInfo
    {
        public DBText DBText { get; set; }
        public Line Line { get; set; }
    }
}
