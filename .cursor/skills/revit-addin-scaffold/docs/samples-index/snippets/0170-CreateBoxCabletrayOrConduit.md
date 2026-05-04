# Sample Snippet: CreateBoxCabletrayOrConduit

Source project: `existingCodes\梁涛插件源代码\8.算量插件集合\拆分（旧）\CreateBoxCabletrayOrConduit\CreateBoxCabletrayOrConduit`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using AddInfoBetweenPointLocation;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CreateBoxCabletrayOrConduit
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        View3D view3D = null;
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;

            if (!(doc.ActiveView is View3D))
            {
                TaskDialog.Show("revit", "请在三维视图中运行插件");
                return Result.Cancelled;
            }
            else
            {
                view3D = doc.ActiveView as View3D;
            }

            MainWindow window = new MainWindow();
            window.ShowDialog();
            if (window.DialogResult == false)
            {
                return Result.Cancelled;
            }


            List<FamilyInstance> boxs;
            ElementId symbolId;
            string elemName;
            double high = -1;
            DataTable dataTable = new DataTable();

            if (window.rb_import.IsChecked == true)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.csv";
                string path = "";
                if (openFileDialog.ShowDialog() == true)
                {
                    path = openFileDialog.FileName;
                }
                else
                {
                    return Result.Cancelled;
                }
                dataTable = ExcelUtils.ReadExcelFile2(path);
                dataTable.TableName = "配电箱设备表";
            }

            if (window.rb_scope.IsChecked == true)
            {
                boxs = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_ElectricalEquipment).WhereElementIsNotElementType().Cast<FamilyInstance>()/*.Where(x => x.Symbol.Family.Name.Contains("配电"))*/.ToList();
            }
            else if (window.rb_sel.IsChecked == true)
            {
                boxs = sel.PickObjects(ObjectType.Element, new BoxFilter(), "框选配电箱").Select(x => doc.GetElement(x)).Cast<FamilyInstance>().ToList();
            }
            else
            {
                boxs = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_ElectricalEquipment).WhereElementIsNotElementType()
                    .Where(x => x.LookupParameter("编号") != null && !string.IsNullOrEmpty(x.LookupParameter("编号").AsString()))
                    .Cast<FamilyInstance>()/*.Where(x => x.Symbol.Family.Name.Contains("配电"))*/.ToList();
            }

            if (window.rb_symbol.IsChecked == true)
            {
                symbolId = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_CableTray).WhereElementIsElementType().First().Id;
                elemName = "桥架";
            }
            else
            {
// ... truncated ...
```

## ExcelUtils.cs

```csharp
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
        //public static string ReadExcelFile(string filePath)
        //{
        //    List<RouteInfo> routeInfos = new List<RouteInfo>();

        //    Application excelApp = new Application();
        //    Workbook workbook = excelApp.Workbooks.Open(filePath);
        //    Worksheet worksheet = workbook.Sheets[1];

        //    Range usedRange = worksheet.UsedRange;

        //    string info = " ";
        //    for (int col = 1; col < usedRange.Columns.Count + 1; col++)
        //    {
        //        var value = (usedRange.Cells[1, col] as Range)?.Value2;
        //        if (value != null)
        //        {
        //            info += value.ToString() + "\n";
        //        }
        //    }
        //    for (int row = 2; row <= usedRange.Rows.Count; row++) // 从第二行开始，假设第一行为标题
        //    {
        //        RouteInfo routeInfo = new RouteInfo();
        //        try
        //        {
        //            routeInfo.Start = (usedRange.Cells[row, 1] as Range)?.Value2.ToString();
        //            routeInfo.RouteNumber = (usedRange.Cells[row, 2] as Range)?.Value2.ToString();
        //            routeInfo.ModelSpecifications = (usedRange.Cells[row, 3] as Range)?.Value2.ToString();
        //            routeInfo.End = (usedRange.Cells[row, 6] as Range)?.Value2.ToString();
        //        }
        //        catch (Exception e)
        //        {

        //            //TaskDialog.Show("error", e.Message);
        //            continue;
        //        }
        //        routeInfos.Add(routeInfo);
        //    }

        //    workbook.Close(false);
        //    excelApp.Quit();

        //    //return routeInfos;
        //    return info;
        //}
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
// ... truncated ...
```

## StaticUtils.cs

```csharp
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateBoxCabletrayOrConduit
{
    public static class StaticUtils
    {
        public static XYZ GetDirection(this Element element)
        {
            if (element.Location is LocationCurve locationCurve)
            {
                Line line = locationCurve.Curve as Line;
                return line.Direction;
            }
            return null;
        }
        public static Line GetLine(this Element element)
        {
            if (element.Location is LocationCurve locationCurve)
            {
                return locationCurve.Curve as Line;
            }
            return null;
        }
        public static Connector GetConnector(this MEPCurve mEPCurve, int id)
        {
            foreach (Connector item in mEPCurve.ConnectorManager.Connectors)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null; ;
        }
// ... truncated ...
```

