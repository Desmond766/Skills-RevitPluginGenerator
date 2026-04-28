# Sample Snippet: VerticalWaterPipeIdentify

Source project: `existingCodes\梁涛插件源代码\8.算量插件集合\拆分（旧）\VerticalWaterPipeIdentify\VerticalWaterPipeIdentify`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerticalWaterPipeIdentify
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;

            #region SQL语句测试
            //string mysqlCon = "server=192.168.11.202;database=bimquantitycalculation;user=fjpc;password=fjpc123456";
            //MySqlConnection con = new MySqlConnection(mysqlCon);
            //con.Open();

            ////string sql = "select * from conduit";
            ////using (MySqlCommand cmd = new MySqlCommand(sql, con))
            ////{
            ////    var countt = cmd.ExecuteReader();
            ////    while (countt.Read())
            ////    {
            ////        TaskDialog.Show("revit", countt.GetString("length"));
            ////    }
            ////}
            ////string sql = "insert into conduit (`conduit_id`,`project_id`,`remake`) values (2,3,'test')";
            ////using (MySqlCommand cmd = new MySqlCommand(sql, con))
            ////{
            ////    var countt = cmd.ExecuteNonQuery();
            ////    TaskDialog.Show("revit", countt.ToString());
            ////}
            ////string sql = "update conduit set remake='abc'";
            ////using (MySqlCommand cmd = new MySqlCommand(sql, con))
            ////{
            ////    var countt = cmd.ExecuteNonQuery();
            ////    TaskDialog.Show("revit", countt.ToString());
            ////}
            ////string sql = "delete from conduit where conduit_id=1 or conduit_id=3";
            ////using (MySqlCommand cmd = new MySqlCommand(sql, con))
            ////{
            ////    var countt = cmd.ExecuteNonQuery();
            ////    TaskDialog.Show("revit", countt.ToString());
            ////}

            //// 参数化查询，防止sql注入
            //int uname = 3;
            //int upwd = 2;
            //string sql2 = "select * from conduit where `conduit_id`=@name and `project_id`=@pwd";
            //using (MySqlCommand cmd = new MySqlCommand(sql2, con))
            //{
            //    cmd.Parameters.Add(new MySqlParameter("@name", uname));
            //    cmd.Parameters.Add(new MySqlParameter("@pwd", upwd));
            //    var reader = cmd.ExecuteReader();
            //    while (reader.Read())
            //    {
            //        if (!reader.IsDBNull(9)) TaskDialog.Show("revit", reader.GetString("remake"));
            //    }
            //}
            ////TaskDialog.Show("revit", "连接成功");

            //con.Close();


            //return Result.Succeeded;
            #endregion

            var pipes = new FilteredElementCollector(doc).WhereElementIsNotElementType().OfCategory(BuiltInCategory.OST_PipeCurves).Where(e => e is Pipe).Cast<Pipe>().ToList();

            var filterPipes1 = pipes.Where(p => p.get_Parameter(BuiltInParameter.RBS_PIPE_DIAMETER_PARAM).AsDouble() - (100 / 304.8) >= -0.001 /*&& (p.PipeType.Name.Contains("无压") || p.PipeType.Name.Contains("排水管"))*/);
            var filterPipes2 = pipes.Where(p => p.get_Parameter(BuiltInParameter.RBS_PIPE_DIAMETER_PARAM).AsDouble() - (50 / 304.8) >= -0.001 && (p.PipeType.Name.Contains("冷凝水") || p.PipeType.Name.Contains("燃气")));

            filterPipes1 = filterPipes1.Where(f => !HasTeeFittingConnect(f) && f.get_Parameter(BuiltInParameter.CURVE_ELEM_LENGTH).AsDouble() - (2500 / 304.8) >= -0.001 ||
            HasTeeFittingConnect(f) && Math.Abs(GetLine(f).GetEndPoint(0).Z - GetLine(f).GetEndPoint(1).Z) - (2500 / 304.8) >= -0.001).ToList();
            filterPipes2 = filterPipes2.Where(f => !HasTeeFittingConnect(f) && f.get_Parameter(BuiltInParameter.CURVE_ELEM_LENGTH).AsDouble() - (2500 / 304.8) >= -0.001 ||
            HasTeeFittingConnect(f) && Math.Abs(GetLine(f).GetEndPoint(0).Z - GetLine(f).GetEndPoint(1).Z) - (2500 / 304.8) >= -0.001).ToList();
            //var filterPipes = new List<Pipe>();
            //filterPipes.AddRange(filterPipes1);
            //filterPipes.AddRange(filterPipes2);
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
[assembly: AssemblyTitle("VerticalWaterPipeIdentify")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("VerticalWaterPipeIdentify")]
[assembly: AssemblyCopyright("Copyright ©  2025")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// 将 ComVisible 设置为 false 会使此程序集中的类型
//对 COM 组件不可见。如果需要从 COM 访问此程序集中的类型
//请将此类型的 ComVisible 特性设置为 true。
[assembly: ComVisible(false)]

// 如果此项目向 COM 公开，则下列 GUID 用于类型库的 ID
[assembly: Guid("a0894710-c706-4c16-8408-f2cec234f51f")]

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

