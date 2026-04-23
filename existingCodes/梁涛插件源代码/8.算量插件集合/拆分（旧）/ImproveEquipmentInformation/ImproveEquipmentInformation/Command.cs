using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Microsoft.Office.Interop.Excel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DataTable = System.Data.DataTable;

namespace ImproveEquipmentInformation
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;

            //Element elem = new FilteredElementCollector(doc, doc.ActiveView.Id).WhereElementIsNotElementType()
            //    .FirstOrDefault(x => x.LookupParameter("设备编号") != null && x.LookupParameter("设备编号").AsString() == "1#洗消");
            //if (elem != null)
            //{
            //    ElementId id = elem.Id;
            //    uidoc.ShowElements(id);
            //    sel.SetElementIds(new ElementId[] { id });
            //}
            //return Result.Succeeded;

            View3D view3D = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Views).WhereElementIsNotElementType()
                .Where(x => x is View3D).Cast<View3D>().FirstOrDefault(y => y.Name.Contains("3D 机电"));
            if (view3D == null)
            {
                TaskDialog.Show("提示", "未找到视图：3D 机电");
                return Result.Cancelled;
            }

            DataTable dataTable = new DataTable();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.csv";
            string path = "";
            if (openFileDialog.ShowDialog() == true)
            {
                path = openFileDialog.FileName;
            }
            else
            {
                TaskDialog.Show("提示", "未选任何文件");
                return Result.Cancelled;
            }
            dataTable = ReadExcelFile(path);
            dataTable.TableName = "设备材料信息表";

            int dataCount = dataTable.Rows.Count;
            int succeed = 0;

            List<FamilyInstance> familyInstances = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_MechanicalEquipment)
                .WhereElementIsNotElementType().Where(x => x.LookupParameter("设备编号") != null && !string.IsNullOrEmpty(x.LookupParameter("设备编号").AsString()))
                .Cast<FamilyInstance>().ToList();

            // 打开指定视图中楼板的可见性
            var openIds = DisplayFloor(doc, view3D, out bool isHidden);

            foreach (DataRow dr in dataTable.Rows)
            {

            }
            using (Transaction t = new Transaction(doc, "补充设备信息"))
            {
                t.Start();

                foreach (FamilyInstance item in familyInstances)
                {
                    var dr = dataTable.Rows.Cast<DataRow>().FirstOrDefault(x => !string.IsNullOrEmpty(x["设备编号"].ToString()) && x["设备编号"].ToString() == item.LookupParameter("设备编号").AsString());
                    if (dr == null) continue;
                    // 风机只有功率，水泵有功率扬程，先判断参数中是否存在功率扬程，不存在则填入功率参数中


                    // 构件规格 string
                    var para1 = item.LookupParameter("构件规格");
                    // 功率KW/功率扬程 string
                    var para2 = item.LookupParameter("功率扬程");
                    var para3 = item.LookupParameter("功率KW");
                    // 风压 double
                    var para4 = item.LookupParameter("风压");
                    // 风量 double
                    var para5 = item.LookupParameter("风量");
                    // 安装方式 string
                    var para6 = item.LookupParameter("安装方式");
                    // 安装位置 string
                    var para7 = item.LookupParameter("安装位置");
                    //if (para1 == null || para3 == null || para4 == null || para5 == null || para6 == null || para7 == null) continue;
                    string col1 = dr["构件规格"].ToString();
                    string col2 = dr["功率扬程"].ToString();
                    string col3 = dr["功率"].ToString();
                    string col4 = dr["风压"].ToString();
                    double col4Num = -1;
                    if (!string.IsNullOrEmpty(col4)) col4Num = Convert.ToDouble(Regex.Replace(col4, @"\D", ""));
                    string col5 = dr["风量"].ToString();
                    double col5Num = -1;
                    if (!string.IsNullOrEmpty(col5)) col5Num = Convert.ToDouble(Regex.Replace(col5, @"\D", ""));
                    string col6 = dr["安装方式"].ToString();
                    string col7 = dr["安装位置"].ToString();
                    try
                    {
                        if (para1 != null && !string.IsNullOrEmpty(col1)) para1.Set(col1);
                        if (para2 != null && !string.IsNullOrEmpty(col2)) para2.Set(col2);
                        if (para3 != null && !string.IsNullOrEmpty(col3)) para3.Set(col3);
                        if (para4 != null && !string.IsNullOrEmpty(col4)) para4.Set(col4Num);
                        if (para5 != null && !string.IsNullOrEmpty(col5)) para5.Set(col5Num);
                        if (para6 != null && !string.IsNullOrEmpty(col6)) para6.Set(col6);
                        if (para7 != null && !string.IsNullOrEmpty(col7)) para7.Set(col7);
                    }
                    catch (Exception)
                    {
                        continue;
                    }

                    succeed++;
                }

                t.Commit();
            }

            // 恢复视图中楼板的可见性
            HiddenFloor(doc, view3D, openIds, isHidden);

            TaskDialog.Show("提示", $"运行结束！\n导入表格行数：{dataCount}\n成功修改个数：{succeed}");
            return Result.Succeeded;
        }
        private void HiddenFloor(Document doc, View3D view3D, List<ElementId> openIds, bool isHidden)
        {
            using (Transaction t = new Transaction(doc, "可见性设置"))
            {
                t.Start();
                try
                {
                    foreach (var id in openIds)
                    {
                        view3D.SetFilterVisibility(id, false);
                    }
                    if (isHidden) view3D.SetCategoryHidden(new ElementId(-2000032), true);
                }
                catch (Exception)
                {
                    t.RollBack();
                    return;
                }

                t.Commit();
            }
        }

        private List<ElementId> DisplayFloor(Document doc, View view3D, out bool isHidden)
        {
            var closeIds = new List<ElementId>();
            var filterIds = view3D.GetFilters();
            using (Transaction t = new Transaction(doc, "可见性设置"))
            {
                t.Start();

                try
                {
                    foreach (var id in filterIds)
                    {
                        var filter = doc.GetElement(id);
                        if (filter.Name.Contains("结构板") || filter.Name.Contains("楼板"))
                        {
                            if (view3D.GetFilterVisibility(id)) continue;
                            view3D.SetFilterVisibility(id, true);
                            closeIds.Add(id);
                        }
                    }
                    //TaskDialog.Show("revit", view3D.GetCategoryHidden(new ElementId(-2000032)).ToString());
                    isHidden = view3D.GetCategoryHidden(new ElementId(-2000032));
                    if (isHidden) view3D.SetCategoryHidden(new ElementId(-2000032), false);
                }
                catch (Exception)
                {
                    isHidden = false;
                    closeIds = new List<ElementId>();
                    t.RollBack();
                    return closeIds;
                }

                t.Commit();
            }
            return closeIds;
        }
        public static DataTable ReadExcelFile(string filePath)
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
                    var value = (usedRange.Cells[row, col] as Range)?.Value2;
                    if (value != null)
                    {
                        dr[col - 1] = value.ToString();
                    }
                }
                dt.Rows.Add(dr);
            }

            workbook.Close(false);
            excelApp.Quit();

            return dt;
        }
    }
}
