using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddInfoBetweenPointLocation
{
    [Transaction(TransactionMode.Manual)]
    // 根据导入的Excel表格在配电箱上创建线管
    public class CreateConduitByExcelCmd : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;

            var routeInfos = new List<RouteInfo>();

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.csv";
            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                //routeInfos = ExcelUtils.ReadExcelFile(filePath);
                TaskDialog.Show("revit", ExcelUtils.ReadExcelFile(filePath));
            }



            return Result.Succeeded;
        }
    }
}
