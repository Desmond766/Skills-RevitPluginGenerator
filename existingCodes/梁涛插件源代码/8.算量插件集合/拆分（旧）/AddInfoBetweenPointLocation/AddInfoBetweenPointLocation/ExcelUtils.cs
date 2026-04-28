using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using DataTable = System.Data.DataTable;

namespace AddInfoBetweenPointLocation
{
    public class ExcelUtils
    {
        public static string ReadExcelFile(string filePath)
        {
            List<RouteInfo> routeInfos = new List<RouteInfo>();

            Application excelApp = new Application();
            Workbook workbook = excelApp.Workbooks.Open(filePath);
            Worksheet worksheet = workbook.Sheets[1];

            Range usedRange = worksheet.UsedRange;

            string info = " ";
            for (int col = 1; col < usedRange.Columns.Count + 1; col++)
            {
                var value = (usedRange.Cells[1, col] as Range)?.Value2;
                if (value != null)
                {
                    info += value.ToString() + "\n";
                }
            }
            for (int row = 2; row <= usedRange.Rows.Count; row++) // 从第二行开始，假设第一行为标题
            {
                RouteInfo routeInfo = new RouteInfo();
                try
                {
                    routeInfo.Start = (usedRange.Cells[row, 1] as Range)?.Value2.ToString();
                    routeInfo.RouteNumber = (usedRange.Cells[row, 2] as Range)?.Value2.ToString();
                    routeInfo.ModelSpecifications = (usedRange.Cells[row, 3] as Range)?.Value2.ToString();
                    routeInfo.End = (usedRange.Cells[row, 6] as Range)?.Value2.ToString();
                }
                catch (Exception e)
                {

                    //TaskDialog.Show("error", e.Message);
                    continue;
                }
                routeInfos.Add(routeInfo);
            }

            workbook.Close(false);
            excelApp.Quit();

            //return routeInfos;
            return info;
        }
        public static DataTable ReadExcelFile2(string filePath)
        {
            DataTable dt = new DataTable();
            

            Application excelApp = new Application();
            Workbook workbook = excelApp.Workbooks.Open(filePath);
            Worksheet worksheet = workbook.Sheets[1];

            Range usedRange = worksheet.UsedRange;

            int unknown = 0;
            for (int col = 1; col < usedRange.Columns.Count + 1; col++)
            {
                var value = (usedRange.Cells[1, col] as Range)?.Value2;
                if (value != null)
                {
                    DataColumn dc = new DataColumn(value.ToString().Trim());
                    dt.Columns.Add(dc);
                }
                else
                {
                    unknown++;
                    DataColumn dc = new DataColumn($"未知{unknown}");
                    dt.Columns.Add(dc);
                }
            }
            for (int row = 2; row <= usedRange.Rows.Count; row++) // 从第二行开始，假设第一行为标题
            {
                DataRow dr = dt.NewRow();
                for (int col = 1; col < usedRange.Columns.Count + 1; col++)
                {
                    var value = (usedRange.Cells[row,col] as Range)?.Value2;
                    if (value != null)
                    {
                        dr[col - 1] = value.ToString();
                        if (col == 8)
                        {
                            //TaskDialog.Show("ddd", value.ToString());
                        }
                    }
                }
                dt.Rows.Add(dr);
            }

            workbook.Close(false);
            excelApp.Quit();

            return dt;
        }

        public static DataTable OpenCSV(string fileName)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            //如果文件不存在，新建一个并添加表头
            if (!File.Exists(fileName))
            {
                return null;
            }
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            StreamReader sr = new StreamReader(fs, Encoding.Default);
            //记录每次读取的一行记录
            string strLine = "";
            //记录每行记录中的各字段内容
            string[] aryLine;
            //标示列数
            int columnCount = 0;
            //标示是否是读取的第一行
            bool IsFirst = true;

            //逐行读取CSV中的数据
            while ((strLine = sr.ReadLine()) != null)
            {
                aryLine = strLine.Split(',');
                if (IsFirst == true)
                {
                    IsFirst = false;
                    columnCount = aryLine.Length;
                    //创建列
                    for (int i = 0; i < columnCount; i++)
                    {
                        DataColumn dc = new DataColumn(aryLine[i].Trim());
                        dt.Columns.Add(dc);
                    }
                    string ingo = "";
                    foreach (var item in aryLine)
                    {
                        ingo += item + "\\";
                    }
                    TaskDialog.Show("revit", ingo);
                }
                else
                {
                    DataRow dr = dt.NewRow();
                    for (int j = 0; j < columnCount; j++)
                    {
                        dr[j] = aryLine[j].Trim();
                    }
                    dt.Rows.Add(dr);
                }
            }

            sr.Close();
            fs.Close();
            return dt;
        }
    }
}
