# Sample Snippet: AttributeAssignmentOfConduitPath

Source project: `existingCodes\梁涛插件源代码\8.算量插件集合\拆分（旧）\AttributeAssignmentOfConduitPath\AttributeAssignmentOfConduitPath`

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
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeAssignmentOfConduitPath
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uIDoc = commandData.Application.ActiveUIDocument;
            Document doc = uIDoc.Document;

            SelWindow window = new SelWindow();
            window.ShowDialog();
            if (window.DialogResult == false)
            {
                return Result.Cancelled;
            }
            

            List<Conduit> conduits = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_Conduit).WhereElementIsNotElementType().Cast<Conduit>().ToList();
            List<FamilyInstance> familyInstances = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_ElectricalFixtures).WhereElementIsNotElementType().Where(x => x.Name.Contains("接线盒")).Cast<FamilyInstance>().ToList();
            //记录在其他回路中的线管，后续遍历中不再进行判断
            List<ElementId> hasCC = new List<ElementId>();
            List<ElementId> hasCF = new List<ElementId>();

            if (window.Import) goto AttributeByExcel;

            Transaction t = new Transaction(doc, "线管通路赋值");
            t.Start();
            foreach (var conduit in conduits)
            {
                //if (conduit.LookupParameter("电气-线管管材").AsString() == null || conduit.LookupParameter("电气系统").AsString() == null || conduit.LookupParameter("导线规格").AsString() == null || conduit.LookupParameter("导线型号").AsString() == null
                //    || conduit.LookupParameter("电气-线管管材").AsString() == "" || conduit.LookupParameter("电气系统").AsString() == "" || conduit.LookupParameter("导线规格").AsString() == "" || conduit.LookupParameter("导线型号").AsString() == ""
                //    || hasCC.Contains(conduit.Id)) continue;

                // 获取文字组内参数不为空的线管
                var paras = conduit.Parameters.Cast<Parameter>();
                paras = paras.Where(p => p.Definition.ParameterGroup == BuiltInParameterGroup.PG_TEXT && p.StorageType == StorageType.String);
                if (paras.Where(p => !string.IsNullOrEmpty(p.AsString())).Count() == 0) continue; 

                List<ElementId> allConELems = new List<ElementId>();
                GetAllConnect(conduit, ref allConELems);
                if (allConELems.Count == 1) continue;
                allConELems.Remove(conduit.Id);
                //获取要给回路赋值各参数的值
                //电气系统
                string para1 = conduit.LookupParameter("电气系统").AsString();
                //电气-线管管材
                string para2 = conduit.LookupParameter("电气-线管管材").AsString();
                //导线规格
                string para3 = conduit.LookupParameter("导线规格").AsString();
                //导线规格1
                string para4 = conduit.LookupParameter("导线规格1").AsString();
                //导线型号
                string para5 = conduit.LookupParameter("导线型号").AsString();
                //导线型号1
                string para6 = conduit.LookupParameter("导线型号1").AsString();
                //工作集
                int para7 = conduit.get_Parameter(BuiltInParameter.ELEM_PARTITION_PARAM).AsInteger();

                foreach (var id in allConELems)
                {
                    Element elem;
                    try
                    {
                        elem = id.GetElement(doc);
                        if (elem.LookupParameter("电气系统").AsString() != para1) elem.LookupParameter("电气系统").Set(para1);
                        if (elem.LookupParameter("电气-线管管材").AsString() != para2) elem.LookupParameter("电气-线管管材").Set(para2);
                        if (elem.LookupParameter("导线规格").AsString() != para3) elem.LookupParameter("导线规格").Set(para3);
                        if (elem.LookupParameter("导线规格1").AsString() != para4) elem.LookupParameter("导线规格1").Set(para4);
                        if (elem.LookupParameter("导线型号").AsString() != para5) elem.LookupParameter("导线型号").Set(para5);
                        if (elem.LookupParameter("导线型号1").AsString() != para6) elem.LookupParameter("导线型号1").Set(para6);
                        if (elem.get_Parameter(BuiltInParameter.ELEM_PARTITION_PARAM).AsInteger() != para7) elem.get_Parameter(BuiltInParameter.ELEM_PARTITION_PARAM).Set(para7);
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                    if (elem is Conduit) hasCC.Add(id);
// ... truncated ...
```

## SelWindow.xaml.cs

```csharp
using Microsoft.Office.Interop.Excel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Application = Microsoft.Office.Interop.Excel.Application;
using DataTable = System.Data.DataTable;
using Window = System.Windows.Window;

namespace AttributeAssignmentOfConduitPath
{
    /// <summary>
    /// SelWindow.xaml 的交互逻辑
    /// </summary>
    public partial class SelWindow : Window
    {
        public bool Import { get; set; }
        public string FilePath { get; set; }

        public DataTable DataTable { get; set; }
        public SelWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Import = false;
            DialogResult = true;
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Import = true;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.csv";
            if (openFileDialog.ShowDialog() == true)
            {
                FilePath = openFileDialog.FileName;
                var m_dt = ReadExcelFile(FilePath);
                m_dt.TableName = "弱电线管规格表";
                DataTable = m_dt;
                DialogResult = true;
            }
            Close();
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
// ... truncated ...
```

