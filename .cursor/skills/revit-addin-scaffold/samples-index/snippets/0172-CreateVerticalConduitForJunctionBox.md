# Sample Snippet: CreateVerticalConduitForJunctionBox

Source project: `existingCodes\梁涛插件源代码\8.算量插件集合\拆分（旧）\CreateVerticalConduitForJunctionBox\CreateVerticalConduitForJunctionBox`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
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

namespace CreateVerticalConduitForJunctionBox
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uIDoc = commandData.Application.ActiveUIDocument;
            Document doc = uIDoc.Document;
            Selection sel = uIDoc.Selection;

            int successCount = 0;
            List<ElementId> ids = new List<ElementId>();

            View3D view3D = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Views).WhereElementIsNotElementType()
                .Where(x => x is View3D).Cast<View3D>().FirstOrDefault(y => y.Name.Contains("3D 机电"));
            if (view3D == null)
            {
                TaskDialog.Show("提示", "未找到视图：3D 机电");
                return Result.Cancelled;
            }

            DataTable m_dt;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.csv";
            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                m_dt = ReadExcelFile(filePath);

            }
            else
            {
                TaskDialog.Show("提示", "未导入Excel文件");
                return Result.Cancelled;
            }
            // 打开指定视图中楼板的可见性
            var openIds = DisplayFloor(doc, view3D, out bool isHidden);

            List<FamilyInstance> familyInstances = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_ElectricalFixtures).WhereElementIsNotElementType()
                .Where(x => x.Name.Contains("接线盒") && x.Name.Contains("墙内")).Cast<FamilyInstance>().ToList();

            ConduitType defaultType = new FilteredElementCollector(doc).OfClass(typeof(ConduitType)).Cast<ConduitType>().First();

            Transaction t = new Transaction(doc, "墙内接线盒创建竖向线管");
            t.Start();
            foreach (var item in familyInstances)
            {

                // 判断点位是否在弱电线管规格表中
                var dataRows = m_dt.Rows.Cast<DataRow>().Where(dr => !string.IsNullOrEmpty(dr["用电名称"].ToString()) && dr["用电名称"].ToString() == item.LookupParameter("").AsString());
                if (dataRows.Count() == 0) continue;
                var dataRow = dataRows.First();
                var lineStand = dataRow["导线规格"].ToString();
                var routNum = dataRow["回路编号"].ToString();
                item.LookupParameter("回路编号").Set(routNum);
                item.LookupParameter("导线规格").Set(lineStand);
                //foreach (DataRow dr in m_dt.Rows)
                //{
                //    if (!string.IsNullOrEmpty(dr["用电名称"].ToString()))
                //    {
                //        string name = dr["用电名称"].ToString();
                //        if (!string.IsNullOrEmpty(dr["连接材料"].ToString()))
                //        {
                //            string info = dr["连接材料"].ToString();
                //            string eng = Regex.Replace(info, "[^A-Za-z]", "").Trim();
                //            string num = Regex.Replace(info, "[^0-9]", "").Trim();
                //            if (item.Name == name)
                //            {
                                
                //                break;
                //            }

                //        }
// ... truncated ...
```

## Extension.cs

```csharp
using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateVerticalConduitForJunctionBox
{
    public static class Extension
    {
        public static Connector GetConnector(this Element ebOrCable, int i)
        {
            Connector connector = null;
            if (ebOrCable is FamilyInstance familyInstance)
            {
                foreach (Connector con in familyInstance.MEPModel.ConnectorManager.Connectors)
                {
                    if (con.Id == i)
                    {
                        connector = con;
                        break;
                    }
                }
            }
            else if (ebOrCable is MEPCurve ePCurve)
            {
                foreach (Connector con in ePCurve.ConnectorManager.Connectors)
                {
                    if (con.Id == i)
                    {
                        connector = con;
                        break;
                    }
                }
            }
            return connector;
        }
    }
}

```

