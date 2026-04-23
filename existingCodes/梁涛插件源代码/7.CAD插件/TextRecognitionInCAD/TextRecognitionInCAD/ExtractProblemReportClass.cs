using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Colors;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Documents;
using Table = Autodesk.AutoCAD.DatabaseServices.Table;

namespace TextRecognitionInCAD
{
    public class ExtractProblemReportClass
    {
        // 提取问题报告表格（直接输出版）
        //[CommandMethod("EPRED")]
        public void ExtractProblemReport()
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            Editor ed = doc.Editor;

            // 步骤1 & 2: 定义我们要查找的目标属性标记集合
            HashSet<string> targetTags = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            {
            "专业",
            "TAG",
            "问题"
            };
            // 使用HashSet并忽略大小写，使匹配更灵活。例如，“tag“和“TAG“都能匹配。

            // 用于存储最终结果的列表。每个元素是一个字典，代表一个块参照。
            // 字典键：参数名（Tag）， 字典值：参数值（TextString）
            List<Dictionary<string, string>> resultList = new List<Dictionary<string, string>>();

            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                try
                {
                    // 步骤3: 打开块表和模型空间的块表记录
                    BlockTable bt = trans.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;
                    BlockTableRecord btr = trans.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForRead) as BlockTableRecord;

                    // 步骤4: 遍历模型空间中的所有实体
                    foreach (ObjectId objId in btr)
                    {
                        // 步骤5: 判断实体是否为块参照
                        BlockReference blkRef = trans.GetObject(objId, OpenMode.ForRead) as BlockReference;
                        if (blkRef == null) continue; // 不是块参照，跳过

                        // 步骤6: 检查并获取属性
                        // 使用动态属性获取方法，兼容不同版本的API
                        AttributeCollection attCol = blkRef.AttributeCollection;
                        if (attCol == null || attCol.Count == 0) continue; // 无属性，跳过

                        // 临时字典，用于收集当前块中匹配到的目标属性值
                        Dictionary<string, string> foundAttributes = new Dictionary<string, string>();

                        // 遍历该块参照的所有属性
                        foreach (ObjectId attId in attCol)
                        {
                            AttributeReference attRef = trans.GetObject(attId, OpenMode.ForRead) as AttributeReference;
                            if (attRef == null) continue;

                            string currentTag = attRef.Tag;
                            string currentValue = attRef.TextString;

                            // 如果当前属性标记是我们的目标之一，则记录其值
                            if (targetTags.Contains(currentTag))
                            {
                                // 使用大写键名存储，方便后续判断，但保留原始值
                                foundAttributes[currentTag.ToUpper()] = currentValue;
                            }
                        }

                        // 步骤7: 判断是否找齐了所有目标属性
                        // 检查foundAttributes的键是否包含了所有目标标记（转为大写后）
                        if (targetTags.All(tag => foundAttributes.ContainsKey(tag.ToUpper())))
                        {
                            // 找齐了！将收集到的属性存入结果列表
                            // 这里可以创建一个新字典，键使用原始的目标Tag名称以保证输出一致性
                            Dictionary<string, string> qualifiedBlockData = new Dictionary<string, string>();
                            foreach (var targetTag in targetTags)
                            {
                                // 从foundAttributes中通过大写键取出，值对应的是原始标记的实际值
                                qualifiedBlockData[targetTag] = foundAttributes[targetTag.ToUpper()];
                            }
                            // 可选：将块参照的Id或句柄也存储，便于定位
                            qualifiedBlockData["块句柄"] = blkRef.Handle.ToString();

                            resultList.Add(qualifiedBlockData);
                        }
                    }

                    trans.Commit();
                }
                catch (System.Exception ex)
                {
                    ed.WriteMessage($"\n错误: {ex.Message}");
                    trans.Abort();
                }
            }
            // 步骤8: 输出结果
            OutputResults(ed, resultList);
        }
        private void OutputResults(Editor ed, List<Dictionary<string, string>> results)
        {
            if (results.Count == 0)
            {
                ed.WriteMessage("\n未找到同时包含[专业]、[TAG]、[问题]属性的块参照。");
                return;
            }

            ed.WriteMessage($"\n共找到 {results.Count} 个符合条件的块参照：\n");
            ed.WriteMessage("===========================================\n");

            int index = 1;
            foreach (var blockData in results)
            {
                ed.WriteMessage($"[块参照 #{index++}， 句柄: {blockData["块句柄"]}]\n");
                ed.WriteMessage($"  专业: {blockData["专业"]}\n");
                ed.WriteMessage($"  TAG : {blockData["TAG"]}\n");
                ed.WriteMessage($"  问题: {blockData["问题"]}\n");
                ed.WriteMessage("-------------------------------------------\n");
            }
        }
        // 提取问题报告表格(创建表格版)
        [CommandMethod("EPR")]
        public void ExtractProblemReport2()
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            //Database db = HostApplicationServices.WorkingDatabase;
            Database db = doc.Database;
            Editor ed = doc.Editor;

            // 步骤1：获取用户点击的插入点
            PromptPointOptions ppo = new PromptPointOptions("\n请点击表格插入点: ");
            PromptPointResult ppr = ed.GetPoint(ppo);

            if (ppr.Status != PromptStatus.OK)
            {
                ed.WriteMessage("\n操作已取消。");
                return;
            }

            Point3d insertionPoint = ppr.Value;

            // 步骤2：查询符合条件的块参照
            List<Dictionary<string, string>> blockData = QueryBlocksWithAttributes(db, ed);

            if (blockData.Count == 0)
            {
                ed.WriteMessage("\n未找到符合条件的块参照，表格创建取消。");
                return;
            }

            // 步骤3：创建并配置表格
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                try
                {
                    // 创建表格对象
                    Table table = CreateResultTable3(insertionPoint, blockData, db);

                    // 将表格添加到模型空间
                    BlockTableRecord btr = trans.GetObject(
                        SymbolUtilityServices.GetBlockModelSpaceId(db),
                        OpenMode.ForWrite
                    ) as BlockTableRecord;
                    //BlockTable bt = trans.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;
                    //BlockTableRecord btr = trans.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;

                    btr.AppendEntity(table);
                    trans.AddNewlyCreatedDBObject(table, true);

                    trans.Commit();

                    //ed.WriteMessage($"\n成功创建表格，共 {blockData.Count} 行数据。");
                }
                catch (System.Exception ex)
                {
                    ed.WriteMessage($"\n创建表格时出错: {ex.Message}");
                    trans.Abort();
                }
            }
        }
        /// <summary>
        /// 查询所有同时包含"专业"、"TAG"、"问题"属性的块参照
        /// </summary>
        private List<Dictionary<string, string>> QueryBlocksWithAttributes(Database db, Editor ed)
        {
            List<Dictionary<string, string>> resultList = new List<Dictionary<string, string>>();

            // 定义要查找的属性标记
            HashSet<string> targetTags = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            {
                "专业",
                "TAG",
                "问题",
                "问题描述",
                "会议结论"
            };

            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                try
                {
                    // 打开块表和模型空间
                    BlockTable bt = trans.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;
                    BlockTableRecord btr = trans.GetObject(
                        bt[BlockTableRecord.ModelSpace],
                        OpenMode.ForRead
                    ) as BlockTableRecord;

                    int foundCount = 0;

                    // 遍历所有实体
                    foreach (ObjectId objId in btr)
                    {
                        BlockReference blkRef = trans.GetObject(objId, OpenMode.ForRead) as BlockReference;
                        if (blkRef == null) continue;

                        // 检查属性
                        AttributeCollection attCol = blkRef.AttributeCollection;
                        if (attCol == null || attCol.Count == 0) continue;

                        // 临时字典，用于收集当前块中匹配到的目标属性值
                        Dictionary<string, string> foundAttributes = new Dictionary<string, string>();

                        // 遍历该块参照的所有属性
                        foreach (ObjectId attId in attCol)
                        {
                            AttributeReference attRef = trans.GetObject(attId, OpenMode.ForRead) as AttributeReference;
                            if (attRef == null) continue;

                            string currentTag = attRef.Tag;
                            string currentValue = attRef.TextString;

                            // 如果当前属性标记是我们的目标之一，则记录其值
                            if (targetTags.Contains(currentTag))
                            {
                                foundAttributes[currentTag.ToUpper()] = currentValue;
                            }
                        }

                        //// 判断是否找齐了所有目标属性
                        //if (targetTags.All(tag => foundAttributes.ContainsKey(tag.ToUpper())))
                        //{
                        //    // 创建数据字典
                        //    Dictionary<string, string> blockInfo = new Dictionary<string, string>
                        //    {
                        //        ["块句柄"] = blkRef.Handle.ToString(),
                        //        ["块名"] = blkRef.Name,
                        //        ["图层"] = blkRef.Layer,
                        //        ["X坐标"] = blkRef.Position.X.ToString("F2"),
                        //        ["Y坐标"] = blkRef.Position.Y.ToString("F2")
                        //    };

                        //    // 添加属性值
                        //    foreach (var targetTag in targetTags)
                        //    {
                        //        blockInfo[targetTag] = foundAttributes[targetTag.ToUpper()];
                        //    }
                        //    if (blockInfo.ContainsKey("专业"))
                        //    {
                        //        string[] chars = blockInfo["专业"].Split('-');
                        //        if (chars.Length >= 2)
                        //        {
                        //            //blockInfo["专业"] = chars[0];
                        //            blockInfo.Add("楼层", chars[1]);
                        //        }
                        //        else
                        //        {
                        //            //blockInfo["专业"] = "N/A";
                        //            blockInfo.Add("楼层", "N/A");
                        //        }
                        //    }
                        //    blockInfo.Add("版本", ExtractDate(blockInfo["图层"]).FirstOrDefault() ?? "N/A");

                        //    resultList.Add(blockInfo);
                        //    foundCount++;
                        //}
                        // 判断是否找齐了所有目标属性
                        if (foundAttributes.ContainsKey("专业") && foundAttributes.ContainsKey("TAG") && (foundAttributes.ContainsKey("问题") || foundAttributes.ContainsKey("问题描述")))
                        {
                            // 创建数据字典
                            Dictionary<string, string> blockInfo = new Dictionary<string, string>
                            {
                                ["块句柄"] = blkRef.Handle.ToString(),
                                ["块名"] = blkRef.Name,
                                ["图层"] = blkRef.Layer,
                                ["X坐标"] = blkRef.Position.X.ToString("F2"),
                                ["Y坐标"] = blkRef.Position.Y.ToString("F2")
                            };

                            // 添加属性值
                            foreach (var targetTag in targetTags)
                            {
                                if (foundAttributes.ContainsKey(targetTag)) blockInfo[targetTag] = foundAttributes[targetTag.ToUpper()];
                            }
                            if (blockInfo.ContainsKey("专业"))
                            {
                                string[] chars = blockInfo["专业"].Split('-');
                                if (chars.Length >= 2)
                                {
                                    //blockInfo["专业"] = chars[0];
                                    blockInfo.Add("楼层", chars[1]);
                                }
                                else
                                {
                                    //blockInfo["专业"] = "N/A";
                                    blockInfo.Add("楼层", "N/A");
                                }
                            }
                            blockInfo.Add("版本", ExtractDate(blockInfo["图层"]).FirstOrDefault() ?? "N/A");

                            resultList.Add(blockInfo);
                            foundCount++;
                        }
                    }

                    trans.Commit();
                    ed.WriteMessage($"\n扫描完成！共找到 {foundCount} 个符合条件的块参照。");
                }
                catch (System.Exception ex)
                {
                    ed.WriteMessage($"\n查询块参照时出错: {ex.Message}");
                    trans.Abort();
                }
            }

            return resultList;
        }
        /// <summary>
        /// 创建并配置结果表格
        /// </summary>
        private Table CreateResultTable(Point3d insertionPoint, List<Dictionary<string, string>> blockData, Database db)
        {
            // 步骤1：定义表格参数
            int rowCount = blockData.Count + 2;  // 行数 = 数据行 + 2行表头
            int columnCount = 5;  // 列数：版本、专业、楼层、问题总数、已解决问题个数（可根据需要调整）

            // 步骤2：创建表格对象
            Table table = new Table();
            table.SetDatabaseDefaults(db);
            table.TableStyle = db.Tablestyle;  // 使用当前表格样式

            // 步骤3：设置表格位置和大小
            //table.Position = new Point3d(0, 0, 0);
            table.Position = insertionPoint;
            table.SetSize(rowCount, columnCount);

            //// 步骤4：设置列宽（可根据内容调整）
            //double[] columnWidths = { 20, 20, 8, 150, 12 };  // 单位：图形单位
            //for (int col = 0; col < columnCount; col++)
            //{
            //    table.Columns[col].Width = columnWidths[col];
            //}

            // 步骤5：设置行高
            //table.SetRowHeight(8);  // 行高8个单位

            // 步骤6：设置表头
            Cell hearderCell = table.Cells[0, 0];  // 第0行是表头
            hearderCell.Value = "CAD问题个数汇总";
            string[] headers = { "版本", "专业", "楼层", "问题", "是否解决" };
            for (int col = 0; col < columnCount; col++)
            {
                // 设置表格列宽
                table.Columns[col].Width = headers[col].Count() * 10;

                // 设置表头单元格
                Cell cell = table.Cells[1, col];  // 第0行是表头
                cell.Value = headers[col];

                // 设置表头样式
                cell.Alignment = CellAlignment.MiddleCenter;
                cell.TextHeight = 5;  // 表头文字高度

                // 设置表头背景色（可选）
                cell.BackgroundColor = Autodesk.AutoCAD.Colors.Color.FromRgb(0, 255, 0);
                cell.IsBackgroundColorNone = true; // 改为false显示背景颜色
            }

            // 步骤7：填充数据行
            for (int row = 0; row < blockData.Count; row++)
            {
                var blockInfo = blockData[row];
                int tableRow = row + 2;  // 表格行索引（0是表头）

                // 填充各列数据
                var dates = ExtractDate(blockInfo["图层"]);
                table.Cells[tableRow, 0].Value = blockInfo.ContainsKey("版本") ? blockInfo["版本"] : "N/A";
                table.Cells[tableRow, 1].Value = blockInfo.ContainsKey("专业") ? blockInfo["专业"] : "N/A";
                table.Cells[tableRow, 2].Value = blockInfo.ContainsKey("楼层") ? blockInfo["楼层"] : "N/A";
                table.Cells[tableRow, 3].Value = blockInfo.ContainsKey("问题") ? blockInfo["问题"] : "N/A";
                table.Cells[tableRow, 4].Value = blockInfo.ContainsKey("图层") ? blockInfo["图层"].Contains("已解决") ? "是" : "否" : "N/A";

                // 设置数据行样式
                for (int col = 0; col < columnCount; col++)
                {
                    Cell cell = table.Cells[tableRow, col];
                    cell.Alignment = col == 3 ? CellAlignment.MiddleLeft : CellAlignment.MiddleCenter;  // 问题列左对齐
                    cell.TextHeight = 3.5;  // 数据行文字高度

                    // 隔行变色，提高可读性
                    if (row % 2 == 1)
                    {
                        cell.BackgroundColor = Autodesk.AutoCAD.Colors.Color.FromRgb(245, 245, 245);
                        cell.IsBackgroundColorNone = true;// 改为false显示背景颜色
                    }
                }
            }

            return table;
        }
        private Table CreateResultTable2(Point3d insertionPoint, List<Dictionary<string, string>> blockData, Database db)
        {
            var group = blockData.GroupBy(b => b["版本"] + "|" + b["专业"] + "|" + b["楼层"]).ToList();
            // 步骤1：定义表格参数
            int rowCount = group.Count() + 2;  // 行数 = 数据行 + 2行表头
            int columnCount = 5;  // 列数：版本、专业、楼层、问题总数、已解决问题个数（可根据需要调整）

            // 步骤2：创建表格对象
            Table table = new Table();
            table.SetDatabaseDefaults(db);
            table.TableStyle = db.Tablestyle;  // 使用当前表格样式

            // 步骤3：设置表格位置和大小
            //table.Position = new Point3d(0, 0, 0);
            table.Position = insertionPoint;
            table.SetSize(rowCount, columnCount);

            // 步骤4：设置列宽（可根据内容调整）
            double[] columnWidths = { 15000, 6000, 6000, 12000, 21000 };  // 单位：图形单位
            for (int col = 0; col < columnCount; col++)
            {
                table.Columns[col].Width = columnWidths[col];
            }

            // 步骤5：设置行高
            table.SetRowHeight(3000);

            // 步骤6：设置表头
            Cell hearderCell = table.Cells[0, 0];  // 第0行是表头
            hearderCell.Value = "CAD问题个数汇总";
            hearderCell.TextHeight = 2100;
            for (int col = 0; col < columnCount; col++)
            {
                Cell cell = table.Cells[1, col];
                cell.Alignment = CellAlignment.MiddleCenter;  // 问题列左对齐
                cell.TextHeight = 2100;  // 数据行文字高度
            }
            string[] headers = { "版本", "专业", "楼层", "问题总数", "已解决问题个数" };
            for (int col = 0; col < columnCount; col++)
            {
                //// 设置表格列宽
                //table.Columns[col].Width = headers[col].Count() * 2000;
                //if (col == 0) table.Columns[col].Width = headers[col].Count() * 2000 + 1000;
                // 设置表头单元格
                Cell cell = table.Cells[1, col];  // 第0行是表头
                cell.Value = headers[col];

                // 设置表头样式
                cell.Alignment = CellAlignment.MiddleCenter;
                cell.TextHeight = 1500;  // 表头文字高度

                // 设置表头背景色（可选）
                cell.BackgroundColor = Autodesk.AutoCAD.Colors.Color.FromRgb(0, 255, 0);
                cell.IsBackgroundColorNone = true; // 改为false显示背景颜色
            }

            // 步骤7：填充数据行
            for (int row = 0; row < group.Count(); row++)
            {
                var blockInfo = group[row];
                int tableRow = row + 2;  // 表格行索引（0是表头）

                // 填充各列数据
                table.Cells[tableRow, 0].Value = blockInfo.ToList().First().ContainsKey("版本") ? blockInfo.ToList().First()["版本"] : "N/A";
                table.Cells[tableRow, 1].Value = blockInfo.ToList().First().ContainsKey("专业") ? blockInfo.ToList().First()["专业"] : "N/A";
                table.Cells[tableRow, 2].Value = blockInfo.ToList().First().ContainsKey("楼层") ? blockInfo.ToList().First()["楼层"] : "N/A";
                table.Cells[tableRow, 3].Value = blockInfo.ToList().Count;
                table.Cells[tableRow, 4].Value = blockInfo.ToList().Count(b => b["图层"].Contains("已解决"));

                // 设置数据行样式
                for (int col = 0; col < columnCount; col++)
                {
                    Cell cell = table.Cells[tableRow, col];
                    cell.Alignment = CellAlignment.MiddleCenter;  // 问题列左对齐
                    cell.TextHeight = 2100;  // 数据行文字高度

                    //// 隔行变色，提高可读性
                    //if (row % 2 == 1)
                    //{
                    //    cell.BackgroundColor = Autodesk.AutoCAD.Colors.Color.FromRgb(245, 245, 245);
                    //    cell.IsBackgroundColorNone = true;// 改为false显示背景颜色
                    //}
                }
            }

            return table;
        }
        private Table CreateResultTable3(Point3d insertionPoint, List<Dictionary<string, string>> blockData, Database db)
        {
            var groupByDate = blockData.GroupBy(b => b["版本"]).Where(g => g.ToList().Count(subG => subG["图层"].Contains("已解决")) == g.ToList().Count).OrderBy(g => g.Key).ToList();
            //blockData = blockData.OrderBy(b => b["版本"]).ThenBy(b => b["楼层"]).ThenBy(b => b["专业"] + b["TAG"]).ToList();
            blockData = blockData.OrderBy(b => b["版本"]).ThenBy(b => b["楼层"]).ThenBy(b => b["专业"]).ThenBy(b =>
            {
                string tag = b["TAG"];
                int num = 0;
                Match match = Regex.Match(tag, @"\d+$");
                if (match.Success)
                {
                    num = Convert.ToInt32(match.Value);
                }
                return num;
            }).ToList();
            var filterData = blockData.Where(b => !b["图层"].Contains("已解决")).ToList();
            // 步骤1：定义表格参数
            int rowCount = filterData.Count() + 3 + groupByDate.Count();  // 行数 = 数据行 + 2行表头 + 尾部总计
            int columnCount = 7;  // 列数：版本、专业、楼层、问题总数、已解决问题个数（可根据需要调整）

            // 步骤2：创建表格对象
            Table table = new Table();
            table.SetDatabaseDefaults(db);
            table.TableStyle = db.Tablestyle;  // 使用当前表格样式

            // 步骤3：设置表格位置和大小
            //table.Position = new Point3d(0, 0, 0);
            table.Position = insertionPoint;
            table.SetSize(rowCount, columnCount);

            // 步骤4：设置列宽（可根据内容调整）
            double[] columnWidths = { 15000, 6000, 12000, 18000, 18000, 50000, 40000 };  // 单位：图形单位
            for (int col = 0; col < columnCount; col++)
            {
                table.Columns[col].Width = columnWidths[col];
            }

            // 步骤5：设置行高
            table.SetRowHeight(3000);

            // 步骤6：设置表头
            Cell hearderCell = table.Cells[0, 0];  // 第0行是表头
            hearderCell.Value = "CAD问题个数汇总";
            hearderCell.TextHeight = 2100;
            for (int col = 0; col < columnCount; col++)
            {
                Cell cell = table.Cells[1, col];
                cell.Alignment = CellAlignment.MiddleCenter;  // 问题列左对齐
                cell.TextHeight = 2100;  // 数据行文字高度
            }
            string[] headers = { "版本", "楼层", "问题总数", "已解决问题个数", "问题编号", "问题描述", "会议结论" };
            for (int col = 0; col < columnCount; col++)
            {
                //// 设置表格列宽
                //table.Columns[col].Width = headers[col].Count() * 2000;
                //if (col == 0) table.Columns[col].Width = headers[col].Count() * 2000 + 1000;
                // 设置表头单元格
                Cell cell = table.Cells[1, col];  // 第0行是表头
                cell.Value = headers[col];
                
                // 设置表头样式
                cell.Alignment = CellAlignment.MiddleCenter;
                cell.TextHeight = 1500;  // 表头文字高度

            }
            // 步骤7：填充数据行
            int versionRow = 2;
            int floorRow = 2;
            string firstVersionValue = filterData.Count > 0 ? filterData[0]["版本"] : "N/A";
            string firstFloorValue = filterData.Count > 0 ? filterData[0]["楼层"] : "N/A";
            for (int row = 0; row < filterData.Count; row++)
            {
                var blockInfo = filterData[row];
                int tableRow = row + 2;  // 表格行索引（0是表头）

                // 填充各列数据
                var dates = ExtractDate(blockInfo["图层"]);
                table.Cells[tableRow, 0].Value = blockInfo.ContainsKey("版本") ? blockInfo["版本"] : "N/A";
                table.Cells[tableRow, 1].Value = blockInfo.ContainsKey("楼层") ? blockInfo["楼层"] : "N/A";
                var totalProblems = blockData.Where(bd => bd["版本"].Equals(blockInfo["版本"]) && bd["楼层"].Equals(blockInfo["楼层"]));
                table.Cells[tableRow, 2].Value = totalProblems.Count();
                table.Cells[tableRow, 3].Value = totalProblems.Count(tb => tb["图层"].Contains("已解决"));
                table.Cells[tableRow, 4].Value = blockInfo.ContainsKey("专业") && blockInfo.ContainsKey("TAG") ? blockInfo["专业"] + blockInfo["TAG"] : "N/A";
                table.Cells[tableRow, 5].Value = blockInfo.ContainsKey("问题描述") ? blockInfo["问题描述"] : blockInfo.ContainsKey("问题") ? blockInfo["问题"] : "N/A";
                table.Cells[tableRow, 6].Value = blockInfo.ContainsKey("会议结论") ? blockInfo["会议结论"] : "N/A";

                // 设置数据行样式
                for (int col = 0; col < columnCount; col++)
                {
                    Cell cell = table.Cells[tableRow, col];
                    cell.Alignment = col == 5 ? CellAlignment.MiddleLeft : CellAlignment.MiddleCenter;  // 问题列左对齐
                    cell.TextHeight = 1500;
                    if (col == 5)
                    {
                        //cell.TextHeight = 1000;
                        
                    }
                }

                // 合并楼层、问题总数、已解决问题个数列
                //if (row == filterData.Count - 1)
                //{
                //    if (firstFloorValue == (blockInfo.ContainsKey("楼层") ? blockInfo["楼层"] : "N/A"))
                //    {
                //        table.MergeCells(CellRange.Create(table, floorRow, 1, tableRow, 1));
                //        table.MergeCells(CellRange.Create(table, floorRow, 2, tableRow, 2));
                //        table.MergeCells(CellRange.Create(table, floorRow, 3, tableRow, 3));
                //    }
                //}
                //else if (firstVersionValue != table.Cells[tableRow, 0].Value.ToString())
                //{
                //    table.MergeCells(CellRange.Create(table, floorRow, 1, tableRow - 1, 1));
                //    table.MergeCells(CellRange.Create(table, floorRow, 2, tableRow - 1, 2));
                //    table.MergeCells(CellRange.Create(table, floorRow, 3, tableRow - 1, 3));

                //    floorRow = tableRow;
                //    firstFloorValue = blockInfo.ContainsKey("楼层") ? blockInfo["楼层"] : "N/A";
                //}
                //else if (firstFloorValue != table.Cells[tableRow, 1].Value.ToString())
                //{
                //    table.MergeCells(CellRange.Create(table, floorRow, 1, tableRow - 1, 1));
                //    table.MergeCells(CellRange.Create(table, floorRow, 2, tableRow - 1, 2));
                //    table.MergeCells(CellRange.Create(table, floorRow, 3, tableRow - 1, 3));

                //    floorRow = tableRow;
                //    firstFloorValue = blockInfo.ContainsKey("楼层") ? blockInfo["楼层"] : "N/A";
                //}
                
                if (firstFloorValue != table.Cells[tableRow, 1].Value.ToString())
                {
                    table.MergeCells(CellRange.Create(table, floorRow, 1, tableRow - 1, 1));
                    table.MergeCells(CellRange.Create(table, floorRow, 2, tableRow - 1, 2));
                    table.MergeCells(CellRange.Create(table, floorRow, 3, tableRow - 1, 3));

                    floorRow = tableRow;
                    firstFloorValue = blockInfo.ContainsKey("楼层") ? blockInfo["楼层"] : "N/A";
                }
                else if (firstVersionValue != table.Cells[tableRow, 0].Value.ToString())
                {
                    table.MergeCells(CellRange.Create(table, floorRow, 1, tableRow - 1, 1));
                    table.MergeCells(CellRange.Create(table, floorRow, 2, tableRow - 1, 2));
                    table.MergeCells(CellRange.Create(table, floorRow, 3, tableRow - 1, 3));

                    floorRow = tableRow;
                    firstFloorValue = blockInfo.ContainsKey("楼层") ? blockInfo["楼层"] : "N/A";
                }
                else if (row == filterData.Count - 1)
                {
                    if (firstFloorValue == (blockInfo.ContainsKey("楼层") ? blockInfo["楼层"] : "N/A"))
                    {
                        table.MergeCells(CellRange.Create(table, floorRow, 1, tableRow, 1));
                        table.MergeCells(CellRange.Create(table, floorRow, 2, tableRow, 2));
                        table.MergeCells(CellRange.Create(table, floorRow, 3, tableRow, 3));
                    }
                }

                // 合并版本列
                if (/*versionRow != tableRow - 1 && */(firstVersionValue != table.Cells[tableRow, 0].Value.ToString() || row == filterData.Count - 1))
                {
                    //if (row == filterData.Count - 1) table.MergeCells(CellRange.Create(table, versionRow, 0, tableRow, 0));
                    //else
                    //{
                    //    table.MergeCells(CellRange.Create(table, versionRow, 0, tableRow - 1, 0));
                    //    versionRow = tableRow;
                    //    firstVersionValue = blockInfo.ContainsKey("版本") ? blockInfo["版本"] : "N/A";
                    //}
                    if (firstVersionValue != table.Cells[tableRow, 0].Value.ToString())
                    {
                        table.MergeCells(CellRange.Create(table, versionRow, 0, tableRow - 1, 0));
                        versionRow = tableRow;
                        firstVersionValue = blockInfo.ContainsKey("版本") ? blockInfo["版本"] : "N/A";
                    }
                    else
                    {
                        table.MergeCells(CellRange.Create(table, versionRow, 0, tableRow, 0));
                    }
                }

            }

            // 问题总数等于已解决问题个数行
            int c = 0;
            for (int i = rowCount - groupByDate.Count() - 1; i < rowCount - 1; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    Cell cell = table.Cells[i, j];
                    cell.Alignment = CellAlignment.MiddleCenter;
                    cell.TextHeight = 1500;  // 数据行文字高度
                }
                table.Cells[i, 0].Value = groupByDate[c].Key;
                table.Cells[i, 2].Value = groupByDate[c].ToList().Count;
                table.Cells[i, 3].Value = groupByDate[c].ToList().Count;
                c++;
            }

            // 8: 统计问题总数与已解决问题个数总数行
            for (int col = 0; col < columnCount; col++)
            {
                Cell cell = table.Cells[rowCount - 1, col];
                cell.Alignment = CellAlignment.MiddleCenter;
                cell.TextHeight = 1500;  // 数据行文字高度
            }
            table.Cells[rowCount - 1, 0].Value = "问题总计";
            table.Cells[rowCount - 1, 2].Value = blockData.Count.ToString();
            table.Cells[rowCount - 1, 3].Value = (blockData.Count - filterData.Count).ToString();

            return table;
        }
        public static string[] ExtractDate(string inputText)
        {
            // 定义正则表达式模式
            string pattern = @"(?<!\d)(\d{4}(0[1-9]|1[0-2])(0[1-9]|[12]\d|3[01]))(?!\d)";

            // 创建Regex实例，启用编译以提高性能（适用于多次使用）
            Regex regex = new Regex(pattern, RegexOptions.Compiled);

            // 匹配所有出现
            MatchCollection matches = regex.Matches(inputText);

            // 提取匹配值到数组
            string[] dates = new string[matches.Count];
            for (int i = 0; i < matches.Count; i++)
            {
                dates[i] = matches[i].Value; // 匹配的完整日期
            }

            return dates;
        }
    }
}
