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
                    }
                    else if (obj is DBText text2 && text2.Layer == beamTextLayer)
                    {
                        beamTexts.Add(text2);
                    }
                    else if (obj is Line line1 && line1.Layer == redLayer)
                    {
                        redLines.Add(line1);
                    }
                    else if (obj is Line line2 && line2.Layer == beamLineLayer)
                    {
                        beamLines.Add(line2);
                    }
                }

                //return;
                // 2.获取梁注释对应梁宽高
                foreach (DBText labelText in llDBtexts)
                {
                    Point3d labelPoint = labelText.Position;
                    Line redL = redLines.Where(rl => rl.GetMinDis(labelPoint) <= 2000).OrderBy(x => x.GetMinDis(labelPoint)).FirstOrDefault(); // res1
                    if (redL == null) continue;
                    Point3d farP = redL.GetFarPoint(labelPoint); // 红线离标注远点
                    Line beamL = beamLines.FirstOrDefault(bl =>
                    {
                        Point3dCollection collection = new Point3dCollection();
                        bl.IntersectWith(redL, Intersect.OnBothOperands, collection, IntPtr.Zero, IntPtr.Zero);
                        if (collection.Count > 0) return true;
                        return false;
                    }); // res2
                    if (beamL == null) continue;
                    DBText beamDBT = beamTexts.Where(b => Math.Abs(b.Rotation - beamL.Angle) < 0.174 || Math.Abs(Math.Abs(b.Rotation - beamL.Angle) - Math.PI) < 0.174).Where(x => x.Position.DistanceTo(farP) < 2000)
                        .OrderBy(bx => bx.Position.DistanceTo(farP)).FirstOrDefault(); // res3 误差10°

                    labelInfos.Add(new LabelInfo(labelText, redL, beamDBT, beamL));
                }

                tr.Commit();
            }
            //foreach (var item in labelInfos.Where(l => l.LabelDBT.TextString == "LL18" && l.BeamDBT != null))
            //{
            //    ed.WriteMessage("\n" + item.BeamLine.StartPoint + ":" + item.BeamDBT.TextString);
            //}
            //ed.WriteMessage("\nLL18::" + labelInfos.Where(l => l.LabelDBT.TextString == "LL18" && l.BeamDBT != null).Count());
            int count = 0;
            using (Transaction tr = db.TransactionManager.StartTransaction())
            {
                BlockTable bt = (BlockTable)tr.GetObject(db.BlockTableId, OpenMode.ForWrite);
                BlockTableRecord btr = (BlockTableRecord)tr.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite);

                var labelGroup = labelInfos.GroupBy(lb => lb.LabelDBT.TextString);
                foreach (var infos in labelGroup)
                {
                    var textInfo = infos.ToList().FirstOrDefault(x => x.BeamDBT != null);
                    if (textInfo == null) continue;
                    string text = textInfo.BeamDBT.TextString;
                    var filterInfos = infos.ToList().Where(x => x.BeamDBT == null);
                    //if (infos.Key == "LL18") ed.WriteMessage($"\n{infos.First().LabelDBT.TextString}:{filterInfos.Count()}:{infos.Count()}");
                    //continue;
                    foreach (var item in filterInfos)
                    {
                        var p0 = item.BeamLine.StartPoint;
                        var p1 = item.BeamLine.EndPoint;
                        var createPoint = new Point3d((p0.X + p1.X) / 2, (p0.Y + p1.Y) / 2, (p0.Z + p1.Z) / 2);

                        DBText dBText = new DBText();
                        dBText.TextString = text;
                        dBText.Position = createPoint;
                        if (item.BeamLine.Angle - Math.PI >= 0)
                            dBText.Rotation = item.BeamLine.Angle - Math.PI;
                        else dBText.Rotation = item.BeamLine.Angle;
                        dBText.Height = textInfo.BeamDBT.Height;
                        dBText.WidthFactor = textInfo.BeamDBT.WidthFactor;
                        dBText.Layer = textInfo.BeamDBT.Layer;

                        btr.AppendEntity(dBText);
                        tr.AddNewlyCreatedDBObject(dBText, true);

                        count++;
                    }
                }

                tr.Commit();
            }

            ed.WriteMessage($"\n完成!创建梁宽高文字数量:" + count);
        }
    }
    public class LabelInfo
    {
        public LabelInfo(DBText labelDBT, Line labelLine, DBText beamDBT, Line beamLine)
        {
            LabelDBT = labelDBT;
            LabelLine = labelLine;
            BeamDBT = beamDBT;
            BeamLine = beamLine;
        }
        public DBText LabelDBT { get; set; } // 梁标注文字
        public Line LabelLine { get; set; } // 标注对应红线
        public DBText BeamDBT { get; set; } // 梁宽高文字
        public Line BeamLine { get; set; } // 红线对应梁线
    }

    public static class Extension
    {
        public static double GetMinDis(this Line line, Point3d point)
        {
            double dis = double.MaxValue;
            double dis1 = line.StartPoint.DistanceTo(point);
            if (dis > dis1) dis = dis1;
            double dis2 = line.EndPoint.DistanceTo(point);
            if (dis > dis2) dis = dis2;

            return dis;
        }
        public static Point3d GetFarPoint(this Line line, Point3d point)
        {
            Point3d resP;
            var p1 = line.StartPoint;
            var p2 = line.EndPoint;
            if (p1.DistanceTo(point) > p2.DistanceTo(point)) resP = p1;
            else resP = p2;

            return resP;
        }
    }
}
