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
        {
            if (v.IsAssemblyView)//not unique
            {
                return v.Document.GetElement(v.AssociatedAssemblyInstanceId).Name + v.Name;
            }
            else
            {
                return v.Name;
            }
        }

        private List<DataTable> ScheduleToDataTable(List<ViewSchedule> schedules)
        {
            // export txt
            ViewScheduleExportOptions opt = new ViewScheduleExportOptions();
            foreach (var v in schedules)
            {
                v.Export(_tempFolder, GetScheduleName(v) + _ext, opt);
            }

            //int number = 2000 * schedules.Count / 15;
            System.Threading.Thread.Sleep(2000);//参数以毫秒为单位

            // txt to datatable
            List<DataTable> dtList = new List<DataTable>();
            foreach (var v in schedules)
            {
                ScheduleDataParser sdp = new ScheduleDataParser(Path.Combine(_tempFolder, GetScheduleName(v) + _ext));
                sdp.Table.TableName = v.Name;
                dtList.Add(sdp.Table);
            }
            return dtList;
        }

        private List<DataTable> ScheduleToDataTable2(List<ViewSchedule> schedules)
        {
            List<DataTable> dtList = new List<DataTable>();
            DataTable dt;
            foreach (var schedule in schedules)
            {
                TableData table = schedule.GetTableData();
                TableSectionData section = table.GetSectionData(SectionType.Body);
                int nRows = section.NumberOfRows;
                int nColumns = section.NumberOfColumns;

                dt = new DataTable();
                //set title
                dt.TableName = schedule.Name;
                //get fields
                ScheduleDefinition definition = schedule.Definition;
                List<ScheduleField> fields = definition.GetFieldOrder()
                    .Select(u => definition.GetField(u))
                    .Where(u => !u.IsHidden)
                    .ToList();
                //MessageBox.Show(schedule.Name + " " + fields.Count.ToString());
                //set column
                foreach (var f in fields)
                {
                    string columnName = !string.IsNullOrEmpty(f.ColumnHeading) ? f.ColumnHeading : "";
                    DataColumn column = new DataColumn();
                    column.DataType = typeof(string);
                    column.ColumnName = columnName;
                    dt.Columns.Add(column);
                }
                //fill data
                int rowIndex = 0;
                if (definition.ShowHeaders)
                {
                    rowIndex = 1;
                }
                if (nRows > 1)
                {
                    while (rowIndex < nRows)
                    {
                        DataRow dr = dt.NewRow();
                        for (int j = 0; j < nColumns; j++)
                        {
                            dr[j] = schedule.GetCellText(SectionType.Body, rowIndex, j);
                        }
                        dt.Rows.Add(dr);
                        rowIndex++;
                    }
                }
                dtList.Add(dt);
            }
            return dtList;
        }

        private void CreateOneFileMulitSheet(List<ViewSchedule> schedules, string fileName)
        {
            //get dtList
            List<DataTable> dtList = ScheduleToDataTable2(schedules);
            //export dtList
            Utils.DataTableToExcel2(dtList, Path.Combine(_desktopFolder, fileName + _ext2));
        }

        private void CreateOneFileOneSheet(
            Document doc,
            List<string> assemblyNameList,
            string scheduleName)
        {
            //get scheduleList
            List<ViewSchedule> scheduleList = GetScheduleByNameContain(doc, assemblyNameList, scheduleName);
            var result = MessageBox.Show(scheduleList.Count.ToString() + " schedules found!",
                "CEG-China", MessageBoxButtons.OKCancel);
            if (result == DialogResult.Cancel)
            {
                return;
            }
            //get dtList
            List<DataTable> dtList = ScheduleToDataTable2(scheduleList);
            //combine dt
            var mainDt = dtList[0];
            mainDt.TableName = scheduleName;
            for (int i = 1; i < dtList.Count; i++)
            {
                foreach (DataRow dr in dtList[i].Rows)
                {
                    mainDt.ImportRow(dr);
                }
            }
            //export dt
            //Utils.DataTableToExcel(mainDt, Path.Combine(_desktopFolder, scheduleName + _ext2));//关键字作文件名
            Utils.DataTableToExcel2(mainDt, Path.Combine(_desktopFolder, scheduleName + _ext2));//关键字作文件名
        }

        private void CreateMulitFileMulitSheet(
            Document doc,
            List<string> assemblyNameList,
            List<string> scheduleNameList)
        {
            //get Mulit scheduleList
            List<List<ViewSchedule>> infos = GetMulitScheduleByNameContain(doc, assemblyNameList, scheduleNameList);
            MessageBox.Show(infos.Count.ToString() + " assemblies found!");
            //export them
            foreach (var item in infos)
            {
                //assemblyName
                string fileName = doc.GetElement(item[0].AssociatedAssemblyInstanceId).Name;
                CreateOneFileMulitSheet(item, fileName);
            }
        }

        private List<ViewSchedule> GetScheduleByNameContain(
            Document doc,
            List<string> assemblyNameList,
            string scheduleName)
        {
            List<ViewSchedule> scheduleList = new List<ViewSchedule>();
            FilteredElementCollector col = new FilteredElementCollector(doc);
            var list = col.OfCategory(BuiltInCategory.OST_Schedules)
                .Cast<ViewSchedule>()
                .Where(u => u.IsAssemblyView && !u.IsTemplate)
                .ToList();
            foreach (var schedule in list)
            {
                var assemblyName = doc.GetElement(schedule.AssociatedAssemblyInstanceId).Name;
                if (assemblyNameList.Contains(assemblyName))
                {
                    if (schedule.Name.Contains(scheduleName))
                    {
                        scheduleList.Add(schedule);
                    }
                }
            }
            scheduleList.Sort(new ScheduleCompaper());
            return scheduleList;
        }

        private List<List<ViewSchedule>> GetMulitScheduleByNameContain(
            Document doc,
            List<string> assemblyNameList,
            List<string> scheduleNameList)
        {
            List<ViewSchedule> scheduleList = new List<ViewSchedule>();
            FilteredElementCollector col = new FilteredElementCollector(doc);
            var list = col.OfCategory(BuiltInCategory.OST_Schedules)
                .Cast<ViewSchedule>()
                .Where(u => u.IsAssemblyView && !u.IsTemplate)
                .ToList();
            foreach (var schedule in list)
            {
                var assemblyName = doc.GetElement(schedule.AssociatedAssemblyInstanceId).Name;
                if (assemblyNameList.Contains(assemblyName))
                {
                    foreach (var item in scheduleNameList)
                    {
                        if (schedule.Name.Contains(item))
                        {
                            scheduleList.Add(schedule);
                        }
                    }
                }
            }
            List<List<ViewSchedule>> info = scheduleList
                .GroupBy(u => u.AssociatedAssemblyInstanceId.IntegerValue.ToString())
                .Select(u => u.ToList())
                .ToList();
            foreach (var item in info)
            {
                item.Sort(new ScheduleCompaper());
            }
            return info;
        }
    }
}
