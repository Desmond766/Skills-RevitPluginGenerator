# Sample Snippet: ExportSchedule

Source project: `existingCodes\品成插件源代码\通用\ExportSchedule\ExportSchedule`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI.Selection;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace ExportSchedule
{
    public enum ScheduleExportMode
    {
        OneFileMulitSheet = 0,
        OneFileOneSheet = 1,
        MulitFileMulitSheet
    }

    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        List<ViewSchedule> selectedSchedules;
        ScheduleExportMode exportMode;
        List<string> scheduleNameList;
        List<string> assemblyNameList;
        string scheduleName;
        bool isExportTitle;

        string _tempFolder = Path.GetTempPath();
        string _desktopFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string _ext = ".txt";
        string _ext2 = ".xlsx";
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;

            //if (!CEGToolsHelper.Utils.CheckReg())
            //{
            //    return Result.Cancelled;
            //}

            // show dialog
            SettingForm frm = new SettingForm(doc);
            if (DialogResult.OK != frm.ShowDialog())
            {
                return Result.Cancelled;
            }
            // user input
            selectedSchedules = frm._selectedSchedules;
            exportMode = frm._exportMode;
            scheduleNameList = frm._scheduleNameList;
            assemblyNameList = frm._assemblyNameList;
            scheduleName = frm._scheduleName;
            isExportTitle = frm._isExportTitle;

            // export excel
            switch (exportMode)
            {
                case ScheduleExportMode.OneFileMulitSheet:
                    if (selectedSchedules.Count > 0)
                    {
                        CreateOneFileMulitSheet(selectedSchedules, doc.Title);
                    }
                    break;
                case ScheduleExportMode.OneFileOneSheet:
                    if (assemblyNameList.Count > 0 && !string.IsNullOrEmpty(scheduleName))
                    {
                        //MessageBox.Show(assemblyNameList.Count.ToString());
                        CreateOneFileOneSheet(doc, assemblyNameList, scheduleName);
                    }
                    break;
                case ScheduleExportMode.MulitFileMulitSheet:
                    if (assemblyNameList.Count > 0 && scheduleNameList.Count > 0)
                    {
                        CreateMulitFileMulitSheet(doc, assemblyNameList, scheduleNameList);
                    }
                    break;
                default:
                    break;
            }
            return Result.Succeeded;
        }

        private string GetScheduleName(ViewSchedule v)
// ... truncated ...
```

## Utils.cs

```csharp
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
// ... truncated ...
```

