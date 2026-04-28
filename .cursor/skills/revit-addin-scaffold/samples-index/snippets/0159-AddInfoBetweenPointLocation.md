# Sample Snippet: AddInfoBetweenPointLocation

Source project: `existingCodes\梁涛插件源代码\8.算量插件集合\拆分（旧）\AddInfoBetweenPointLocation\AddInfoBetweenPointLocation`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddInfoBetweenPointLocation
{
    [Transaction(TransactionMode.Manual)]
    // 读取excel表格，将两点位（配电箱到点位或配电箱到配电箱）与其之间的线管回路赋值
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;

            Element elem = doc.GetElement(sel.PickObject(ObjectType.Element));
            var ids = new List<ElementId>();
            GetAllConnect(elem, ref ids);
            using (Transaction t = new Transaction(doc, "赋值"))
            {
                t.Start();
                foreach (var id in ids)
                {
                    Element element = doc.GetElement(id);
                    var para = element.LookupParameter("电气-线管管材");
                    if (para != null)
                    {
                        para.Set("SC25");
                    }
                    var para2 = element.LookupParameter("路由");
                    if (para2 != null)
                    {
                        para2.Set("WP4");
                    }
                }


                t.Commit();
            }


            return Result.Succeeded;
        }

        /// <summary>
        /// 获取管道/管件通路上所有元素ID
        /// </summary>
        /// <param name="element"></param>
        /// <param name="ids"></param>
        /// <returns></returns>
        private List<ElementId> GetAllConnect(Element element, ref List<ElementId> ids)
        {
            List<ElementId> result = new List<ElementId>();
            if (element is FamilyInstance familyInstance)
            {
                if (element.Category.Id.IntegerValue == -2001040)
                {
                    return ids;
                }
                if (!ids.Contains(familyInstance.Id)) ids.Add(familyInstance.Id);
                foreach (Connector item in familyInstance.MEPModel.ConnectorManager.Connectors)
                {
                    if (item.ConnectorType == ConnectorType.End && item.IsConnected)
                    {
                        foreach (Connector conRef in item.AllRefs)
                        {
                            if (!ids.Contains(conRef.Owner.Id))
                            {
                                ids.Add(conRef.Owner.Id);
                                //ids.AddRange(GetAllConnect(conRef.Owner, ids));
                                GetAllConnect(conRef.Owner, ref ids);
                            }
                        }
                    }
                }
            }
            else if (element is Conduit conduit)
            {
                if (!ids.Contains(conduit.Id)) ids.Add(conduit.Id);
                foreach (Connector item in conduit.ConnectorManager.Connectors)
                {
                    if (item.ConnectorType == ConnectorType.End && item.IsConnected)
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
// ... truncated ...
```

