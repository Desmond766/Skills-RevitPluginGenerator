# Sample Snippet: CreateBoxByPointLocation

Source project: `existingCodes\梁涛插件源代码\8.算量插件集合\拆分（旧）\CreateBoxByPointLocation\CreateBoxByPointLocation`

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
using System.Threading.Tasks;
using System.Windows.Controls;
using DataTable = System.Data.DataTable;
using Line = Autodesk.Revit.DB.Line;
using Parameter = Autodesk.Revit.DB.Parameter;

namespace CreateBoxByPointLocation
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;

            var elemFilter = new List<ElementFilter>()
            {
                new ElementCategoryFilter(BuiltInCategory.OST_CommunicationDevices), // 通讯设备
                new ElementCategoryFilter(BuiltInCategory.OST_SecurityDevices), // 安全设备
                new ElementCategoryFilter(BuiltInCategory.OST_LightingFixtures), // 照明设备
                new ElementCategoryFilter(BuiltInCategory.OST_DataDevices), // 数据设备
                new ElementCategoryFilter(BuiltInCategory.OST_TelephoneDevices), // 电话设备
                new ElementCategoryFilter(BuiltInCategory.OST_NurseCallDevices), // 护理呼叫设备
                new ElementCategoryFilter(BuiltInCategory.OST_FireAlarmDevices), // 火警设备
                new ElementCategoryFilter(BuiltInCategory.OST_MechanicalEquipment) // 机械设备
            };

            LogicalOrFilter orFilter = new LogicalOrFilter(elemFilter);

            var elems = new FilteredElementCollector(doc, doc.ActiveView.Id).WherePasses(orFilter).WhereElementIsNotElementType().Cast<FamilyInstance>();
            FamilySymbol familySymbol1 = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_ElectricalFixtures).WhereElementIsElementType().Where(x => x.Name == ("01 接线盒(墙内)")).Cast<FamilySymbol>().FirstOrDefault();
            FamilySymbol familySymbol2 = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_ElectricalFixtures).WhereElementIsElementType().Where(x => x.Name == ("01 接线盒(板内)")).Cast<FamilySymbol>().FirstOrDefault();

            if (familySymbol1 == null)
            {
                TaskDialog.Show("提示", "未找到 \"01 接线盒(墙内)\"，请手动载入族");
                return Result.Cancelled;
            }
            if (familySymbol2 == null)
            {
                TaskDialog.Show("提示", "未找到 \"01 接线盒(板内)\"，请手动载入族");
                return Result.Cancelled;
            }

            DataTable dt = new DataTable();
            dt.TableName = "电气点位高度表";

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "选择要导入的电气点位高度表";
            openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.csv";
            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                dt = ReadExcelFile(filePath);
            }
            else
            {
                return Result.Cancelled;
            }

            var plNames = dt.Rows.Cast<DataRow>().Where(d => !string.IsNullOrEmpty(d["构件名称"].ToString())).Select(dr => dr["构件名称"].ToString());


            using (Transaction t = new Transaction(doc, "创建接线盒"))
            {
                t.Start();
                if (!familySymbol2.IsActive)
                {
                    familySymbol2.Activate();
                }
                if (!familySymbol1.IsActive)
                {
                    familySymbol1.Activate();
                }
                // 点位集合
                foreach (var item in elems)
                {
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
[assembly: AssemblyTitle("CreateBoxByPointLocation")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("CreateBoxByPointLocation")]
[assembly: AssemblyCopyright("Copyright ©  2024")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// 将 ComVisible 设置为 false 会使此程序集中的类型
//对 COM 组件不可见。如果需要从 COM 访问此程序集中的类型
//请将此类型的 ComVisible 特性设置为 true。
[assembly: ComVisible(false)]

// 如果此项目向 COM 公开，则下列 GUID 用于类型库的 ID
[assembly: Guid("65435985-e585-46ee-8a70-2aca66808af1")]

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

