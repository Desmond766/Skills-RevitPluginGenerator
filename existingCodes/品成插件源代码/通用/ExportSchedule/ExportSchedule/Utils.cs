using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;

namespace ExportSchedule
{
    public static class Utils
    {
        public static List<string> letterList = new List<string>() { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J",
            "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};


        #region 将DtList中数据写入XLS文件中
        /// <summary>
        /// 将DtList中数据写入XLS文件中
        /// </summary>
        /// <param name="dtList"></param>
        /// <param name="fileName"></param>
        public static void DataTableToExcel(List<System.Data.DataTable> dtList, string fileName)
        {
            if (dtList.Count == 0)
            {
                return;
            }
            // 创建xls
            object missing = System.Reflection.Missing.Value;
            Excel.Application excel = new Excel.Application();
            excel.Visible = true;
            Workbook workBook = excel.Workbooks.Add(missing);
            // 保存文件
            excel.ActiveWorkbook.SaveAs(fileName);
            Worksheet workSheet;
            for (int i = 0; i < dtList.Count; i++)
            {
                workSheet = (Worksheet)workBook.Worksheets.Add(missing, missing, missing, missing);
                DataTableToWorkSheet(dtList[dtList.Count - 1 - i], workSheet);
            }
            foreach (Worksheet ws in workBook.Worksheets)
            {
                if (ws.Name.Contains("Sheet"))
                {
                    ws.Delete();
                }
            }
        }
        #endregion

        #region 将DataTable中数据写入XLS文件中
        /// <summary>
        /// 将DataTable中数据写入XLS文件中
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="fileName"></param>
        public static void DataTableToExcel(System.Data.DataTable dt, string fileName)
        {
            List<System.Data.DataTable> dtList = new List<System.Data.DataTable>() { dt };
            DataTableToExcel(dtList, fileName);
        }
        #endregion

        #region DataTable导入WorkSheet
        /// <summary>
        /// DataTable导入WorkSheet
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="workSheet"></param>
        public static void DataTableToWorkSheet(System.Data.DataTable dt, Worksheet workSheet)
        {
            if (dt == null)
                return;
            // 删除ID列
            System.Data.DataTable dt_export = dt.Copy();
            if (dt_export.Columns.Contains("ID"))
            {
                dt_export.Columns.Remove("ID");
            }
            // 声明变量
            int rowNum = dt_export.Rows.Count;
            int columnNum = dt_export.Columns.Count;
            int rowIndex = 1;
            int columnIndex = 0;
            Excel.Application excel = workSheet.Application;
            workSheet.Name = dt.TableName;
            // 冻结首行
            //excel.ActiveWindow.SplitRow = rowIndex;
            //excel.ActiveWindow.FreezePanes = true;
            // 定义表格范围
            var range = workSheet.get_Range("A1", Utils.letterList[columnNum - 1] + (rowNum + 1).ToString());
            // 设置文字大小
            range.Font.Size = 10;
            // 添加边框
            range.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            // 表头范围
            var range_Title = workSheet.get_Range("A1", Utils.letterList[columnNum - 1] + rowIndex.ToString());
            // 表头文本水平居中
            range_Title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            // 表头加粗
            range_Title.Font.Bold = true;
            // 表头填充
            range_Title.Cells.Interior.Color = System.Drawing.Color.FromArgb(217, 217, 217).ToArgb();
            // 创建表头
            for (int i = 0; i < columnNum; i++)
            {
                workSheet.Cells[1, i + 1] = dt_export.Columns[i].ColumnName;
            }
            // 将DataTable中的数据导入Excel中
            for (int i = 0; i < rowNum; i++)
            {
                rowIndex++;
                columnIndex = 0;
                for (int j = 0; j < columnNum; j++)
                {
                    columnIndex++;
                    workSheet.Cells[rowIndex, columnIndex] = dt_export.Rows[i][j].ToString();
                }
            }
            // 自动调整列宽
            range.EntireColumn.AutoFit();
        }
        #endregion


        //https://blog.csdn.net/wdl1071705706/article/details/43308417
        /// <summary>
        /// 将datatable保存至excel
        /// Microsoft.Office.Interop.Excel
        /// </summary>
        /// <param name="srcDataTable">数据源</param>
        /// <param name="excelFilePath">要保存的路径</param>
        public static void DataTableToExcel3(System.Data.DataTable srcDataTable, string excelFilePath)
        {
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            object missing = System.Reflection.Missing.Value;


            //导出到execl 
            try
            {
                if (xlApp == null)
                {
                    return;
                }


                Microsoft.Office.Interop.Excel.Workbooks xlBooks = xlApp.Workbooks;
                Microsoft.Office.Interop.Excel.Workbook xlBook = xlBooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
                Microsoft.Office.Interop.Excel.Worksheet xlSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlBook.Worksheets[1];
                //range = (Microsoft.Office.Interop.Excel.Range)xlSheet.get_Range("A1", "K1");
                //xlSheet.Name
                //让后台执行设置为不可见，为true的话会看到打开一个Excel，然后数据在往里写
                xlApp.Visible = false;

                //将数据写入到一个二维数组中
                object[,] objData = new object[srcDataTable.Rows.Count + 2, srcDataTable.Columns.Count];//+1 标题 +1 列名
                //写入标题 
                objData[0, 0] = srcDataTable.TableName;
                //写入列名
                for (int i = 1; i < srcDataTable.Columns.Count; i++)
                {
                    objData[1, i] = srcDataTable.Columns[i].ColumnName;
                }
                //写入数据
                if (srcDataTable.Rows.Count > 0)
                {
                    for (int i = 0; i < srcDataTable.Rows.Count; i++)
                    {
                        for (int j = 0; j < srcDataTable.Columns.Count; j++)
                        {
                            objData[i + 2, j] = srcDataTable.Rows[i][j];
                        }
                    }
                }
                string startCol = "A";
                int iCnt = (srcDataTable.Columns.Count / 26);
                string endColSignal = (iCnt == 0 ? "" : ((char)('A' + (iCnt - 1))).ToString());
                string endCol = endColSignal + ((char)('A' + srcDataTable.Columns.Count - iCnt * 26 - 1)).ToString();
                Microsoft.Office.Interop.Excel.Range range = xlSheet.get_Range(startCol + "1", endCol + (srcDataTable.Rows.Count - iCnt * 26 + 2).ToString());//+1 标题 +1 列名
                //range.NumberFormatLocal = "@";     //设置单元格格式为文本
                range.Value = objData; //给Exccel中的Range整体赋值
                range.EntireColumn.AutoFit(); //设定Excel列宽度自适应
                range.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;//边框线
                xlSheet.get_Range(startCol + "1", endCol + "1").MergeCells = true;//合并单元格
                xlSheet.get_Range(startCol + "1", endCol + "1").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;//标题居中
                xlSheet.get_Range(startCol + "1", endCol + "2").Font.Bold = 1;//字体设定为Bold


                //设置禁止弹出保存和覆盖的询问提示框
                xlApp.DisplayAlerts = false;
                xlApp.AlertBeforeOverwriting = false;
                if (xlSheet != null)
                {
                    xlSheet.SaveAs(excelFilePath, missing, missing, missing, missing, missing, missing, missing, missing, missing);


                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                xlApp.Quit(); // 退出 Excel
                xlApp = null; // 将 Excel 实例设置为空
            }
        }


        public static void DataTableToWorkSheet2(System.Data.DataTable srcDataTable, Worksheet workSheet)
        {
            try
            {
                //将数据写入到一个二维数组中
                object[,] objData = new object[srcDataTable.Rows.Count + 2, srcDataTable.Columns.Count];//+1 标题 +1 列名
                //写入标题 
                objData[0, 0] = srcDataTable.TableName;
                //写入列名
                for (int i = 0; i < srcDataTable.Columns.Count; i++)
                {
                    objData[1, i] = srcDataTable.Columns[i].ColumnName;
                }
                //写入数据
                if (srcDataTable.Rows.Count > 0)
                {
                    for (int i = 0; i < srcDataTable.Rows.Count; i++)
                    {
                        for (int j = 0; j < srcDataTable.Columns.Count; j++)
                        {
                            objData[i + 2, j] = srcDataTable.Rows[i][j];
                        }
                    }
                }
                string startCol = "A";
                int iCnt = (srcDataTable.Columns.Count / 27);//*应该是27
                string endColSignal = (iCnt == 0 ? "" : ((char)('A' + (iCnt - 1))).ToString());
                string endCol = endColSignal + ((char)('A' + srcDataTable.Columns.Count - iCnt * 26 - 1)).ToString();
                Range range = workSheet.get_Range(startCol + "1", endCol + (srcDataTable.Rows.Count + 2).ToString());//+1 标题 +1 列名
                //range.NumberFormatLocal = "@";     //设置单元格格式为文本
                range.Value = objData; //给Exccel中的Range整体赋值
                range.EntireColumn.AutoFit(); //设定Excel列宽度自适应
                range.Borders.LineStyle = XlLineStyle.xlContinuous;//边框线
                workSheet.get_Range(startCol + "1", endCol + "1").MergeCells = true;//合并单元格
                workSheet.get_Range(startCol + "1", endCol + "1").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;//标题居中
                workSheet.get_Range(startCol + "1", endCol + "2").Font.Bold = 1;//字体设定为Bold
                workSheet.Name = srcDataTable.TableName;//工作表名

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        public static void DataTableToExcel2(List<System.Data.DataTable> dtList, string excelFilePath)
        {
            Application xlApp = new Application();
            object missing = System.Reflection.Missing.Value;

            //导出到execl 
            try
            {
                if (xlApp == null)
                {
                    return;
                }
                if (dtList.Count == 0)
                {
                    return;
                }

                //让后台执行设置为不可见，为true的话会看到打开一个Excel，然后数据在往里写
                xlApp.Visible = false;
                //设置禁止弹出保存和覆盖的询问提示框
                xlApp.DisplayAlerts = false;
                xlApp.AlertBeforeOverwriting = false;

                // 创建xls
                Workbooks xlBooks = xlApp.Workbooks;
                Workbook xlBook = xlBooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);

                // 创建工作表
                Worksheet workSheet;
                for (int i = 0; i < dtList.Count; i++)
                {
                    workSheet = (Worksheet)xlBook.Worksheets.Add(missing, missing, missing, missing);
                    DataTableToWorkSheet2(dtList[dtList.Count - 1 - i], workSheet);//倒叙添加
                }
                //删除默认工作表
                foreach (Worksheet ws in xlBook.Worksheets)
                {
                    if (ws.Name.Contains("Sheet"))
                    {
                        ws.Delete();
                    }
                }

                //最后保存文件
                xlBook.SaveAs(excelFilePath);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message + ex.StackTrace);
            }
            finally
            {
                xlApp.Quit(); // 退出 Excel
                xlApp = null; // 将 Excel 实例设置为空
            }
        }

        public static void DataTableToExcel2(System.Data.DataTable dt, string excelFilePath)
        {
            List<System.Data.DataTable> dtList = new List<System.Data.DataTable>() { dt };
            DataTableToExcel2(dtList, excelFilePath);
        }
    }
}
