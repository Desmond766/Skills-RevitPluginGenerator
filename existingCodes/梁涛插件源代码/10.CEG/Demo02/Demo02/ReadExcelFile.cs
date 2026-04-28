using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Microsoft.Office.Interop.Excel;
using System.Windows;

namespace Demo02
{
    public class ReadExcelFile
    {

        /// <summary>
        /// 获取管线边与边之间的间距
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="sheetIndex"></param>
        /// <returns></returns>
        public static void GetData(Document doc, int sheetIndex,UserControl05 userControl05)
        {
            CloseExcel();
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();

            // 获取该位置的文件夹路径
            //string filePath = @"D:\参数.xlsx";
            string filePath = userControl05.textBox.Text;
            Workbook workbook = excel.Workbooks.Open(filePath);
            //获取工作表 sheetIndex从1开始 不是0
            Worksheet worksheet = workbook.Worksheets[sheetIndex];
            //获取单元格
            Range range = worksheet.UsedRange;
            int rowCount = range.Rows.Count;
            int colCount = range.Columns.Count;
            for (int i = 2; i <= rowCount; i++)
            {
                bool flag = false;
                string familyName = (range.Cells[i, 1] as Range).Value;
                string familySymbolName = (range.Cells[i, 2] as Range).Value;
                string parameterName = (range.Cells[i, 3] as Range).Value;
                string parameterValue = (range.Cells[i, 4] as Range).Text;

                ChangeParameter.changeParameter(doc, familyName, familySymbolName, parameterName, parameterValue, ref flag);
                if (!flag)
                {
                    (range.Cells[i, 5] as Range).Value = "NoChanged";
                }
            }



            workbook.Close();
            excel.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);
            excel = null;
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
