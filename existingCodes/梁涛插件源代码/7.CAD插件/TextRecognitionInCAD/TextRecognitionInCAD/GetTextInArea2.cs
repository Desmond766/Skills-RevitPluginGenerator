using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application2 = Microsoft.Office.Interop.Excel.Application;
using Application = Autodesk.AutoCAD.ApplicationServices.Application;
using Exception = System.Exception;
using System.Text.RegularExpressions;
using System.IO;
using static Autodesk.AutoCAD.LayerManager.LayerFilter;
using System.Windows.Forms;
using DialogResult = System.Windows.Forms.DialogResult;
using static System.Net.Mime.MediaTypeNames;

namespace TextRecognitionInCAD
{
    public class GetTextInArea2
    {
        [CommandMethod("GTIA2")]
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
            //PromptPointResult pt1 = editor.GetPoint("\n请选择矩形框选区域的第一个角点: ");
            //if (pt1.Status != PromptStatus.OK) return;

            //PromptPointResult pt2 = editor.GetPoint("\n请选择矩形框选区域的第二个角点: ");
            //if (pt2.Status != PromptStatus.OK) return;
            PromptPointResult pt1 = editor.GetPoint("\n请框选一个范围: ");
            if (pt1.Status != PromptStatus.OK)
            {
                ed.WriteMessage("\n已取消操作");
                return;
            }
            RectJig rectJig = new RectJig(pt1.Value);
            PromptResult PR = ed.Drag(rectJig);
            if (PR.Status != PromptStatus.OK)
            {
                ed.WriteMessage($"\n已取消操作");
                return;
            }
            Point3d pt2 = rectJig.AcquirePnt;


            // 创建选择区域的矩形
            //Point2d lowerLeft = new Point2d(pt1.Value.X < pt2.Value.X ? pt1.Value.X : pt2.Value.X, pt1.Value.Y < pt2.Value.Y ? pt1.Value.Y : pt2.Value.Y);
            //Point2d upperRight = new Point2d(pt1.Value.X > pt2.Value.X ? pt1.Value.X : pt2.Value.X, pt1.Value.Y > pt2.Value.Y ? pt1.Value.Y : pt2.Value.Y); 
            Point2d lowerLeft = new Point2d(pt1.Value.X < pt2.X ? pt1.Value.X : pt2.X, pt1.Value.Y < pt2.Y ? pt1.Value.Y : pt2.Y);
            Point2d upperRight = new Point2d(pt1.Value.X > pt2.X ? pt1.Value.X : pt2.X, pt1.Value.Y > pt2.Y ? pt1.Value.Y : pt2.Y);
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
                        continue;
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


                
                trans.Commit();
            }

            textInfos = textInfos.Where(t => FilterInfo.BoxInfos.Any(b => t.DBText.Contains(b)) || FilterInfo.DevInfos.Any(d => t.DBText.Contains(d)) ||
            FilterInfo.ConduitFrontInfos.Any(f => t.DBText.Contains(f)) || FilterInfo.MaterialInfos.Any(m => t.DBText.Contains(m)) ||
            FilterInfo.ConduitBackRegex.IsMatch(t.DBText) || FilterInfo.RouteNumRegex.IsMatch(t.DBText) || (t.DBText.StartsWith("W") && t.DBText.EndsWith(")"))).ToList();

            textInfos = textInfos.OrderByDescending(t => t.Point3D.Y).ToList();

            //string outputInfo = "";
            //textInfos.ForEach(t => outputInfo += "\n" + t.DBText + "---" + t.Point3D + "\n");
            //File.AppendAllText(@"C:\Users\Administrator\Desktop\新建文本文档 (3).txt", outputInfo);
            //return;
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
                    texts += info.DBText /*+ " " + info.Point3D*/ + " --- ";
                }
                texts += "\n";
            }

            // 如果配电箱不为空，将配电箱信息添加到每行第一列
            //if (boxText != null)
            //{
            //    TextInfo text = new TextInfo(boxText.TextString, boxText.Position);
            //    for (int i = 0; i < sortTextInfos.Count; i++)
            //    {
            //        sortTextInfos[i].Insert(0, text);
            //    }
            //}

            // 导出Excel文件
            ExportExcel(sortTextInfos, editor, boxText);
        }

        public bool IsTextInBox(Point2d lowerLeft, Point2d upperRight, Point3d position)
        {
            if (lowerLeft.X < position.X && upperRight.X > position.X && lowerLeft.Y < position.Y && upperRight.Y > position.Y)
                return true;
            return false;
        }

        public void ExportExcel(List<List<TextInfo>> sortTextInfos, Editor editor, DBText dBText, string boxName = "")
        {
            Application2 excelApp = new Application2();
            Workbook excelDoc = excelApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);

            Worksheet excelSheet = (Worksheet)excelDoc.Worksheets[1];

            //for (int i = 1; i < sortTextInfos.Count + 1; i++)
            //{
            //    var textInfos = sortTextInfos[i - 1].OrderBy(s => s.Point3D.X).ToList();
            //    for (int j = 1; j < textInfos.Count() + 1; j++)
            //    {
            //        excelSheet.Cells[i, j].Value = textInfos[j - 1].DBText;
            //    }
            //}
            excelSheet.Cells[1, 1].Value = "配电箱";
            excelSheet.Cells[1, 2].Value = "导线型号";
            excelSheet.Cells[1, 3].Value = "线管材质";
            excelSheet.Cells[1, 4].Value = "线管尺寸";
            excelSheet.Cells[1, 5].Value = "回路编号";
            excelSheet.Cells[1, 6].Value = "用电设备";

            int insertCount = 0;
            //// 配电箱列
            //if (dBText != null)
            //{
            //    string boxText = dBText.TextString;
            //    for (int i = 2; i < sortTextInfos.Count + 2; i++)
            //    {
            //        excelSheet.Cells[i + insertCount, 1].Value = boxText;
            //    }
            //}

            for (int i = 2; i < sortTextInfos.Count + 2; i++)
            {
                // 配电箱列
                if (dBText != null) excelSheet.Cells[i + insertCount, 1].Value = dBText.TextString;
                var textInfos = sortTextInfos[i - 2];
                // 回路编号列
                var routeInfo = textInfos.FirstOrDefault(t => FilterInfo.RouteNumRegex.IsMatch(t.DBText));
                if (routeInfo != null)
                {
                    if (dBText != null) excelSheet.Cells[i + insertCount, 5].Value = dBText.TextString + ":" + routeInfo.DBText;
                    else excelSheet.Cells[i + insertCount, 5].Value = routeInfo.DBText;
                }
                else
                {
                    routeInfo = textInfos.FirstOrDefault(t => t.DBText.StartsWith("W") && t.DBText.EndsWith(")"));
                    if (routeInfo != null) excelSheet.Cells[i + insertCount, 5].Value = routeInfo.DBText;
                }
                // 25.9.11 新增补全空缺部分(从第三行起上一行才有数据)
                if (routeInfo == null && i >= 3)
                {
                    //if (!string.IsNullOrEmpty(excelSheet.Cells[i + insertCount - 1, 2].Value)) excelSheet.Cells[i + insertCount, 2].Value = excelSheet.Cells[i + insertCount - 1, 2].Value;
                    //if (!string.IsNullOrEmpty(excelSheet.Cells[i + insertCount - 1, 3].Value)) excelSheet.Cells[i + insertCount, 3].Value = excelSheet.Cells[i + insertCount - 1, 3].Value;
                    //if (!string.IsNullOrEmpty(excelSheet.Cells[i + insertCount - 1, 4].Value)) excelSheet.Cells[i + insertCount, 4].Value = excelSheet.Cells[i + insertCount - 1, 4].Value;
                    //if (!string.IsNullOrEmpty(excelSheet.Cells[i + insertCount - 1, 5].Value)) excelSheet.Cells[i + insertCount, 5].Value = excelSheet.Cells[i + insertCount - 1, 5].Value;

                    //if (!string.IsNullOrEmpty(excelSheet.Cells[i + insertCount - 1, 6].Value)) excelSheet.Cells[i + insertCount, 1].Value = excelSheet.Cells[i + insertCount - 1, 6].Value;
                    excelSheet.Cells[i + insertCount, 2].Value = excelSheet.Cells[i + insertCount - 1, 2].Value;
                    excelSheet.Cells[i + insertCount, 3].Value = excelSheet.Cells[i + insertCount - 1, 3].Value;
                    excelSheet.Cells[i + insertCount, 4].Value = excelSheet.Cells[i + insertCount - 1, 4].Value;

                    string routeNum = excelSheet.Cells[i + insertCount - 1, 5].Value.ToString();
                    excelSheet.Cells[i + insertCount, 5].Value = IncrementLastNumber(routeNum);
                    //excelSheet.Cells[i + insertCount, 5].Value = excelSheet.Cells[i + insertCount - 1, 5].Value;


                    excelSheet.Cells[i + insertCount, 1].Value = excelSheet.Cells[i + insertCount - 1, 6].Value;
                }

                // 导线型号列 + 线管材质/尺寸列
                var conduitSymbol = textInfos.FirstOrDefault(t => FilterInfo.ConduitFrontInfos.Any(c => t.DBText.StartsWith(c)) && FilterInfo.ConduitBackRegex.IsMatch(t.DBText));
                Match match = null;
                Match match1 = null;
                string materialInfo = null;
                if (conduitSymbol != null)
                {
                    match = FilterInfo.ConduitBackRegex.Match(conduitSymbol.DBText);
                    excelSheet.Cells[i + insertCount, 2].Value = match.Value;
                    materialInfo = FindSubstring(conduitSymbol.DBText);
                    if (materialInfo != null)
                    {
                        excelSheet.Cells[i + insertCount, 3].Value = materialInfo;
                        //Regex regex = new Regex($@"{materialInfo}\d+");
                        Regex regex = new Regex(@"(?:JDG|SC|PC)(\d+)");
                        match1 = regex.Match(conduitSymbol.DBText);
                        string dValue = match1.Value.Replace(materialInfo, "");
                        if (match1 != null) excelSheet.Cells[i + insertCount, 4].Value = dValue;
                    }
                }
                // 用电名称列
                var devInfo = textInfos.FirstOrDefault(t => FilterInfo.DevInfos.Any(d => t.DBText.Contains(d)) || FilterInfo.BoxInfos.Any(b => t.DBText.Contains(b)));
                if (devInfo != null) excelSheet.Cells[i + insertCount, 6].Value = devInfo.DBText;


                // 判断是否有两条回路
                if (dBText != null && dBText.TextString.Contains("/") && routeInfo != null && routeInfo.DBText.EndsWith(")"))
                {
                    string str1 = dBText.TextString;  // 字符串1
                    string str2 = routeInfo.DBText;  // 字符串2

                    string[] parts1 = str1.Split('/');  // 根据 "/" 拆分字符串1
                    string[] parts2 = str2.Split(new char[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries);  // 根据 "(" 和 ")" 拆分字符串2

                    if (parts1.Length == 2 && parts2.Length == 2)
                    {
                        excelSheet.Cells[i + insertCount, 1].Value = parts1[0];
                        excelSheet.Cells[i + insertCount, 5].Value = parts1[0] + ":" + parts2[0];
                        insertCount++;
                        excelSheet.Cells[i + insertCount, 1].Value = parts1[1];
                        excelSheet.Cells[i + insertCount, 5].Value = parts1[1] + ":" + parts2[1];
                        if (conduitSymbol != null) excelSheet.Cells[i + insertCount, 2].Value = match.Value;
                        if (materialInfo != null) excelSheet.Cells[i + insertCount, 3].Value = materialInfo;
                        if (match1 != null) excelSheet.Cells[i + insertCount, 4].Value = match1.Value.Replace(materialInfo, "");
                        if (devInfo != null) excelSheet.Cells[i + insertCount, 6].Value = devInfo.DBText;
                    }
                }
            }

            string savePath = $@"C:\Users\Administrator\Desktop\CAD回路表{DateTime.Now:yyyy-MM-dd HHmmss}.xlsx";
            //选择文件夹
            //FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            //if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            //{
                
            //    savePath = folderBrowserDialog.SelectedPath;
            //    savePath += $@"\CAD回路表{DateTime.Now:yyyy-MM-dd HHmmss}.xlsx";

            //}
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.csv";
            saveFileDialog.Title = "选择保存路径";
            //saveFileDialog.FileName = $@"CAD回路表{DateTime.Now:yyyy-MM-dd HHmmss}.xlsx";
            saveFileDialog.FileName = $@"{dBText.TextString}.xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // 25.9.11 向总表中追加数据
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.csv";
                openFileDialog.Title = "选择一个总表";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    AddExcelFile(filePath, excelSheet, editor);
                }

                savePath = saveFileDialog.FileName;
                try
                {
                    excelDoc.SaveAs(savePath);
                    excelDoc.Close();
                    excelApp.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
                    excelApp = null;
                    editor.WriteMessage($"\n导出成功，文件路径：{savePath}");
                }
                catch (Exception)
                {
                    excelDoc.Close(false);
                    excelApp.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
                    excelApp = null;
                    editor.WriteMessage("\n导出失败");
                }
            }
            else
            {
                // 关闭该excel文件且不保存上面的工作簿
                excelDoc.Close(false);
                // 关闭App清理和释放资源，避免内存泄漏
                excelApp.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
                excelApp = null;
                editor.WriteMessage($"\n已取消导出操作");
            }

            
            //excelDoc.Close();
            //excelApp.Quit();
            //editor.WriteMessage($"\n导出成功，文件路径：{savePath}");
        }

        /// <summary>
        /// 匹配字符串末端连续的数字并返回其加一后的完整字符串
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string IncrementLastNumber(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            // 匹配字符串末尾的连续数字[1,6](@ref)
            string pattern = @"\d+$";
            Match match = Regex.Match(input, pattern);

            if (!match.Success)
                return input; // 末尾没有数字，直接返回原字符串[1](@ref)

            string numberStr = match.Value;
            try
            {
                // 将数字部分转换为整数并加一[1,5](@ref)
                long number = long.Parse(numberStr) + 1;
                string newNumberStr = number.ToString();

                // 处理前导零：保持数字位数一致（如"001"变为"002"）[1](@ref)
                if (newNumberStr.Length < numberStr.Length)
                {
                    newNumberStr = newNumberStr.PadLeft(numberStr.Length, '0');
                }

                // 拼接非数字部分和新的数字部分[1](@ref)
                return input.Substring(0, match.Index) + newNumberStr;
            }
            catch (OverflowException)
            {
                // 处理数字溢出的情况（如超过long的最大值）
                return input;
            }
        }

        /// <summary>
        /// 向指定表格追加数据
        /// </summary>
        /// <param name="filePath">要追加数据的表格路径</param>
        /// <param name="addWorksheet">追加的表格数据</param>
        public static void AddExcelFile(string filePath, Worksheet addWorksheet, Editor ed)
        {
            //ed.WriteMessage("\n" + addWorksheet.UsedRange.Rows.Count);
            //return;

            Application2 excelApp = new Application2();
            Workbook workbook = excelApp.Workbooks.Open(filePath);
            Worksheet worksheet = workbook.Sheets[1];

            Range usedRange = worksheet.UsedRange;
            int rowCount = usedRange.Rows.Count;

            for (int row = 2; row <= addWorksheet.UsedRange.Rows.Count; row++) // 从第二行开始，假设第一行为标题
            {
                try
                {
                    worksheet.Cells[rowCount + row - 1, 1].Value = addWorksheet.Cells[row, 1].Value;
                    worksheet.Cells[rowCount + row - 1, 2].Value = addWorksheet.Cells[row, 5].Value;
                    worksheet.Cells[rowCount + row - 1, 3].Value = addWorksheet.Cells[row, 2].Value;
                    worksheet.Cells[rowCount + row - 1, 6].Value = addWorksheet.Cells[row, 6].Value;
                }
                catch (Exception e)
                {
                    //TaskDialog.Show("error", e.Message);
                    continue;
                }
            }

            workbook.Close(true);
            excelApp.Quit();

        }
        static string FindSubstring(string input)
        {
            // 检查字符串是否包含 JDG, SC 或 PC 其中一个
            if (input.Contains("JDG"))
            {
                return "JDG";
            }
            else if (input.Contains("SC"))
            {
                return "SC";
            }
            else if (input.Contains("PC"))
            {
                return "PC";
            }
            else
            {
                return null;  // 如果不包含，返回 null
            }
        }
    }
}
