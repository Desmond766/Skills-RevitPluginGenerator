# Sample Snippet: ImproveEquipmentInformation

Source project: `existingCodes\梁涛插件源代码\8.算量插件集合\拆分（旧）\ImproveEquipmentInformation\ImproveEquipmentInformation`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
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
// ... truncated ...
```

## Properties\AssemblyInfo.cs

```csharp
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// 有关程序集的一般信息由以下
// 控制。更改这些特性值可修改
// 与程序集关联的信息。
[assembly: AssemblyTitle("ImproveEquipmentInformation")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("ImproveEquipmentInformation")]
[assembly: AssemblyCopyright("Copyright ©  2025")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// 将 ComVisible 设置为 false 会使此程序集中的类型
//对 COM 组件不可见。如果需要从 COM 访问此程序集中的类型
//请将此类型的 ComVisible 特性设置为 true。
[assembly: ComVisible(false)]

// 如果此项目向 COM 公开，则下列 GUID 用于类型库的 ID
[assembly: Guid("4fcaf539-ab99-4ed6-b0fa-30bfa7e4a8e0")]

// 程序集的版本信息由下列四个值组成: 
//
//      主版本
//      次版本
//      生成号
//      修订号
//
//可以指定所有这些值，也可以使用“生成号”和“修订号”的默认值
//通过使用 "*"，如下所示:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

```

