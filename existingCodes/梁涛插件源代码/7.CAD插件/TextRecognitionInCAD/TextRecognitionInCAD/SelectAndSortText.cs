using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Internal.Calculator;
using Autodesk.AutoCAD.Runtime;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Application = Autodesk.AutoCAD.ApplicationServices.Application;
using Application2 = Microsoft.Office.Interop.Excel.Application;
using Exception = System.Exception;

namespace TextRecognitionInCAD
{
    public class SelectAndSortText // 测试用
    {
        [CommandMethod("GetTextInArea")]
        public void SelectAndSortTextInArea()
        {
            // 获取当前文档和编辑器
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Editor editor = doc.Editor;
            Editor ed = doc.Editor;

            // 配电箱编号
            DBText boxText = null;

            // 提示用户框选范围
            PromptSelectionOptions options = new PromptSelectionOptions
            {
                MessageForAdding = "选择一个配电箱编号: "
            };

            // 捕获用户的选择
            PromptSelectionResult result = ed.GetSelection(options);

            if (result.Status != PromptStatus.OK)
            {
                ed.WriteMessage("\n未选择任何实体或操作取消.");
                //return;
            }

            // 获取选择的对象
            SelectionSet selectionSet = result.Value;

            // 打开数据库进行处理
            if (selectionSet == null) goto NEXT;
            using (Transaction tr = doc.Database.TransactionManager.StartTransaction())
            {
                foreach (SelectedObject selObj in selectionSet)
                {
                    if (selObj != null)
                    {
                        Entity entity = tr.GetObject(selObj.ObjectId, OpenMode.ForRead) as Entity;

                        if (entity != null && entity is DBText text)
                        {
                            boxText = text;
                            break;
                        }
                    }
                }
                tr.Commit();
            }
            NEXT:
            // 选择一个矩形范围
            PromptPointResult pt1 = editor.GetPoint("\n请选择矩形框选区域的第一个角点: ");
            if (pt1.Status != PromptStatus.OK) return;

            PromptPointResult pt2 = editor.GetPoint("\n请选择矩形框选区域的第二个角点: ");
            if (pt2.Status != PromptStatus.OK) return;

            // 创建选择区域的矩形
            Point2d lowerLeft = new Point2d(pt1.Value.X < pt2.Value.X ? pt1.Value.X : pt2.Value.X, pt1.Value.Y < pt2.Value.Y ? pt1.Value.Y : pt2.Value.Y);
            Point2d upperRight = new Point2d(pt1.Value.X > pt2.Value.X ? pt1.Value.X : pt2.Value.X, pt1.Value.Y > pt2.Value.Y ? pt1.Value.Y : pt2.Value.Y);
            Extents2d selectionArea = new Extents2d(lowerLeft, upperRight);

            // 获取数据库对象
            Database db = doc.Database;
            // 存储所有文字与其对应三维坐标
            List<TextInfo> textInfos = new List<TextInfo>();

            // 使用事务处理数据库
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                BlockTable blockTable = (BlockTable)trans.GetObject(db.BlockTableId, OpenMode.ForRead);
                BlockTableRecord blockRecord = (BlockTableRecord)trans.GetObject(blockTable[BlockTableRecord.ModelSpace], OpenMode.ForRead);

                // 存储文本对象的列表(直接获取)
                List<DBText> textList = new List<DBText>();
                List<MText> mTextList = new List<MText>();
                // 存储文本对象的列表(从块参照中获取)
                List<DBText> refTextList = new List<DBText>();
                List<MText> refMTextList = new List<MText>();
                Matrix3d matrix3D = new Matrix3d();
                int count = 0;

                // 遍历块记录中的所有实体，筛选出文本对象
                foreach (ObjectId objId in blockRecord)
                {
                    Entity entity = trans.GetObject(objId, OpenMode.ForRead) as Entity;
                    if (entity != null && entity is DBText)
                    {
                        DBText textEntity = entity as DBText;
                        Point3d position = textEntity.Position;

                        // 判断文本是否在选定范围内
                        if (IsTextInBox(lowerLeft, upperRight, position))
                        {
                            textList.Add(textEntity);
                            textInfos.Add(new TextInfo(textEntity.TextString, position));
                        }
                    }
                    else if (entity is MText mTextEntity)
                    {
                        Point3d position = mTextEntity.Location;
                        // 判断文本是否在选定范围内
                        if (IsTextInBox(lowerLeft, upperRight, position))
                        {
                            mTextList.Add(mTextEntity);
                            textInfos.Add(new TextInfo(mTextEntity.Text, position));
                        }
                    }
                    // 处理块参照（BlockReference）
                    else if (entity is BlockReference blockRef)
                    {
                        // 获取块参照坐标转换
                        var blockRefTransform = blockRef.BlockTransform;
                        matrix3D = blockRefTransform;

                        // 获取块定义（BlockTableRecord）
                        BlockTableRecord blockDef = (BlockTableRecord)trans.GetObject(blockRef.BlockTableRecord, OpenMode.ForRead);

                        // 遍历块参照中的所有元素，提取其中的文本
                        foreach (ObjectId blockObjId in blockDef)
                        {
                            Entity blockEntity = trans.GetObject(blockObjId, OpenMode.ForRead) as Entity;

                            if (blockEntity is DBText blockText)
                            {
                                Point3d position = blockText.Position;
                                position = position.TransformBy(blockRefTransform);
                                // 判断文本是否在选定范围内
                                if (IsTextInBox(lowerLeft, upperRight, position))
                                {
                                    //textList.Add(blockText);
                                    refTextList.Add(blockText);
                                    textInfos.Add(new TextInfo(blockText.TextString, position));
                                }
                            }
                            else if (blockEntity is MText blockMText)
                            {
                                Point3d position = blockMText.Location;
                                position = position.TransformBy(blockRefTransform);
                                // 判断文本是否在选定范围内
                                if (IsTextInBox(lowerLeft, upperRight, position))
                                {
                                    //mTextList.Add(blockMText);
                                    refMTextList.Add(blockMText);
                                    textInfos.Add(new TextInfo(blockMText.Text, position));
                                }
                            }
                        }
                    }
                }


                //// 按照文本对象的坐标排序
                //var sortedTextList = textList.OrderBy(text => text.Position.Y).ThenBy(text => text.Position.X).ToList();

                //// 输出排序后的文本内容
                //foreach (var text in sortedTextList)
                //{
                //    editor.WriteMessage($"\n文本: {text.TextString}，位置: {text.Position}");
                //    File.AppendAllText(@"C:\Users\Administrator\Desktop\新建文本文档 (3).txt","\n" + text.TextString + " --- " + text.Position);
                //}
                //foreach (var text in mTextList)
                //{
                //    editor.WriteMessage($"\n文本: {text.Text}，位置: {text.Location}");
                //    File.AppendAllText(@"C:\Users\Administrator\Desktop\新建文本文档 (3).txt","\n" + text.Text + " --- " + text.Location);
                //}
                //foreach (var text in refTextList)
                //{
                //    editor.WriteMessage($"\n文本: {text.TextString}，位置: {text.Position.TransformBy(matrix3D)}");
                //    File.AppendAllText(@"C:\Users\Administrator\Desktop\新建文本文档 (3).txt", "\n" + text.TextString + " --- " + text.Position.TransformBy(matrix3D));
                //}
                //File.AppendAllText(@"C:\Users\Administrator\Desktop\新建文本文档 (3).txt", "\n" + count);
                trans.Commit();
            }
            textInfos = textInfos.Where(t => FilterInfo.BoxInfos.Any(b => t.DBText.Contains(b)) || FilterInfo.DevInfos.Any(d => t.DBText.Contains(d)) ||
            FilterInfo.ConduitFrontInfos.Any(f => t.DBText.Contains(f)) || FilterInfo.MaterialInfos.Any(m => t.DBText.Contains(m)) ||
            FilterInfo.ConduitBackRegex.IsMatch(t.DBText) || FilterInfo.RouteNumRegex.IsMatch(t.DBText)).ToList();
            foreach (var text in textInfos)
            {
                //File.AppendAllText(@"C:\Users\Administrator\Desktop\新建文本文档 (3).txt", "\n" + text.DBText + " --- " + text.Point3D);
            }
            textInfos = textInfos.OrderByDescending(t => t.Point3D.Y).ToList();
            List<List<TextInfo>> sortTextInfos = new List<List<TextInfo>>();
            int c = 0;
            for (int i = 0; i < textInfos.Count; i++)
            {
                if (i == textInfos.Count - 1)
                {
                    //editor.WriteMessage("111");
                    if (c == 0)
                    {
                        sortTextInfos.Add(new List<TextInfo>(textInfos.GetRange(c, textInfos.Count - c)));
                    }
                    else
                    {
                        sortTextInfos.Add(new List<TextInfo>(textInfos.GetRange(c + 1, textInfos.Count - c - 1)));
                    }

                }
                else
                {
                    if (Math.Abs(textInfos[i].Point3D.Y - textInfos[i + 1].Point3D.Y) > 450)
                    {
                        int j = i;
                        if (c == 0)
                        {
                            sortTextInfos.Add(new List<TextInfo>(textInfos.GetRange(c, j - c + 1)));
                        }
                        else
                        {
                            sortTextInfos.Add(new List<TextInfo>(textInfos.GetRange(c + 1, j - c)));
                        }

                        c = j;
                    }
                }
            }
            string texts = "\n\n";
            foreach (var item in sortTextInfos)
            {
                var infos = item.OrderBy(t => t.Point3D.X);
                foreach (var info in infos)
                {
                    texts += info.DBText /*+ " " + info.Point3D*/ +" --- ";
                }
                texts += "\n";
            }

            // 如果配电箱不为空，将配电箱信息添加到每行第一列
            if (boxText != null)
            {
                TextInfo text = new TextInfo(boxText.TextString, boxText.Position);
                for (int i = 0; i < sortTextInfos.Count; i++)
                {
                    sortTextInfos[i].Insert(0, text);
                }
            }

            // 导出Excel文件
            ExportExcel(sortTextInfos, editor);
            //File.AppendAllText(@"C:\Users\Administrator\Desktop\新建文本文档 (3).txt", texts);
            //editor.WriteMessage("完成");
        }

        public bool IsTextInBox(Point2d lowerLeft, Point2d upperRight, Point3d position)
        {
            if (lowerLeft.X < position.X && upperRight.X > position.X && lowerLeft.Y < position.Y && upperRight.Y > position.Y)
                return true;
            return false;
        }

        public void ExportExcel(List<List<TextInfo>> sortTextInfos, Editor editor)
        {
            Application2 excelApp = new Application2();
            Workbook excelDoc = excelApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);

            Worksheet excelSheet = (Worksheet)excelDoc.Worksheets[1];

            for (int i = 1; i < sortTextInfos.Count + 1; i++)
            {
                var textInfos = sortTextInfos[i - 1].OrderBy(s => s.Point3D.X).ToList();
                for (int j = 1; j < textInfos.Count() + 1; j++)
                {
                    excelSheet.Cells[i, j].Value = textInfos[j - 1].DBText;
                }
            }

            string savePath = $@"C:\Users\Administrator\Desktop\CAD回路表{DateTime.Now:yyyy-MM-dd HHmmss}.xlsx";
            try
            {
                excelDoc.SaveAs(savePath);
            }
            catch (Exception ex)
            {
                excelDoc.Close();
                excelApp.Quit();
                editor.WriteMessage("导出失败");
                return;
            }
            excelDoc.Close();
            excelApp.Quit();
            editor.WriteMessage($"导出成功，文件路径：{savePath}");
        }
    }
    // 文字过滤条件
    public static class FilterInfo
    {
        // 电缆电线前缀代号
        public static List<string> ConduitFrontInfos = new List<string>()
        {
            "ZBN","ZB","WDZB","JHS","BV","BTLY","HS"
        };
        // 电缆电线后缀代号（以xN结尾，其中N表示任意连续数字）
        public static Regex ConduitBackRegex = new Regex(@"(.*x\d+(\.\d+)?)");
        //public static Regex ConduitBackRegex = new Regex(@"x\d+$");
        // 线管材质
        public static List<string> MaterialInfos = new List<string>()
        {
            "JDG", "SC", "PC"
        };
        // 线管管径
        // 回路编号(以W开头且长度小于等于5)
        public static Regex RouteNumRegex = new Regex(@"^W.{0,4}$");
        // 配电箱代号（配电箱与用电设备公用部分）
        public static List<string> BoxInfos = new List<string>()
        {
            "AL/ZAL", "AEZ", "ALE/ZALE", "AP/ZAP", "APE/ZAPE", "AT", "AC", "AW"
        };
        // 配电箱代码2（单独代表配电箱）
        public static List<string> BoxInfos2 = new List<string>()
        {
            "XF（J）", "FJ", "KT", "XFB", "SHB", "XHS", "PLB", "WYB", "ACQ", "XKS", "RD", "DXJ", 
            "GB", "ZB", "CDZ", "GG", "LH", "JG", "HK", "SY", "WG", "SQ", "RF", "BG", "GY", "D（X）T", "FT", "XF(J)", "XF (J)", "D(X)T", "D (X) T",
            "PY", "SF", "JY" // 25.2.20新增
        };
        // 用电设备
        public static List<string> DevInfos = new List<string>()
        {
            "风机", "CO", "AJL", "照明", "余压", "泄压阀", "泵", "插座", "电动阀", "臭氧自洁箱", "箱", 
            "AP", "AT", "AJL", "AEZ", "充电桩", "DB" // 25.2.20新增
        };
    }
}
