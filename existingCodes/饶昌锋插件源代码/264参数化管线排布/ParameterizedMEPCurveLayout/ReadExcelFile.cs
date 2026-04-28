using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Microsoft.Office.Interop.Excel;
using Application = Microsoft.Office.Interop.Excel.Application;

namespace ParameterizedMEPCurveLayout
{
    /// <summary>
    /// Excel操作
    /// </summary>
    public class ReadExcelFile
    {

        /// <summary>
        /// 获取管线边与边之间的间距
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="sheetIndex"></param>
        /// <returns></returns>
        public static int GetData(string row, string col,int sheetIndex)
        {
            int interval = 0;
            CloseExcel();
            Application excel = new Application();
            //string filePath = Assembly.GetExecutingAssembly().Location + "\\管线间距表.xlsx";
            //MessageBox.Show(filePath);
            //try { }catch(Exception ex) { }
            string filePath = @"D:\管线间距表.xlsx";
            //Console.WriteLine(filePath);
            Workbook workbook = excel.Workbooks.Open(filePath);
            //获取工作表 sheetIndex从1开始 不是0
            Worksheet worksheet = workbook.Worksheets[sheetIndex];
            //获取单元格
            Range range = worksheet.UsedRange;
            int rowCount = range.Rows.Count;
            int colCount = range.Columns.Count;
            int rowIndex = 0;
            int colIndex = 0;
            //从第二个开始是因为第一行或者第一列不是数据
            for (int i = 2; i <= rowCount; i++)
            {
                string value = (range.Cells[i, 1] as Range).Value.ToString();
                if (value == col)
                {
                    rowIndex = i;
                }
            }

            for (int i = 2; i <= colCount; i++)
            {
                string value = (range.Cells[1, i] as Range).Value.ToString();
                if (value == row)
                {
                    colIndex = i;
                }
            }
            if (rowIndex != 0 && colIndex != 0)
            {
                string cellValue = (range.Cells[rowIndex, colIndex] as Range).Value.ToString();
                interval = int.Parse(cellValue);
            }
            else
            {
                TaskDialog.Show("提示","该值不存在");
            }
            workbook.Close();
            excel.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);
            excel = null;
            return interval;
        }

        /// <summary>
        /// 杀死进程
        /// </summary>
        private static void CloseExcel()
        {
            //创建进程对象
            Process[] ExcelProcess = Process.GetProcessesByName("WPS");
            //关闭进程
            foreach (Process p in ExcelProcess)
            {
                p.Kill();
            }
        }
    }
}
