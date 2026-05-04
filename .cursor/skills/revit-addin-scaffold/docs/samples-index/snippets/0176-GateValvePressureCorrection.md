# Sample Snippet: GateValvePressureCorrection

Source project: `existingCodes\梁涛插件源代码\8.算量插件集合\拆分（旧）\GateValvePressureCorrection\GateValvePressureCorrection`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GateValvePressureCorrection
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uIDoc = commandData.Application.ActiveUIDocument;
            Document doc = uIDoc.Document;
            Selection sel = uIDoc.Selection;

            List<string> familyNames = new List<string>() { "Y型过滤器", "减压孔板", "压力表", "阀", "曲挠", "排水地漏", "水表", "水流指示器", "水龙头", "漏斗", "玻璃管液" };

            List<FamilyInstance> familyInstances = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_PipeAccessory).WhereElementIsNotElementType()
                .Cast<FamilyInstance>().Where(x => x.Symbol.Family.Name.Contains("阀") || familyNames.Any(n => x.Symbol.Family.Name.Contains(n))).ToList();
            //var familyGroup = familyInstances.GroupBy(x => x.Symbol.FamilyName);
            //string info = "";
            //foreach (var gou in familyGroup)
            //{
            //    info += gou.Key + "\n";
            //}
            //TaskDialog.Show("dsd", info);
            //return Result.Succeeded;

            int count = 0;
            int count2 = 0;
            string inff = "\n";

            using (Transaction t = new Transaction(doc, "闸阀压力修正"))
            {
                t.Start();
                foreach (var item in familyInstances)
                {
                    //修改闸阀连接方式
                    string pattern2 = @"C([\u4e00-\u9fa5]+)";
                    string symbolName2 = item.Symbol.Name;

                    Match match3 = Regex.Match(symbolName2, pattern2);

                    if (match3.Success)
                    {
                        string conName = match3.Groups[1].Value;
                        conName += "连接";
                        try
                        {
                            item.LookupParameter("连接方式").Set(conName);
                            count2++;
                        }
                        catch (Exception)
                        {
                        }
                    }


                    string number = "";

                    string name = item.Name;
                    string pattern = @"(\d+(\.\d+)?)\s*(?=mpa)";

                    Match match = Regex.Match(name, pattern, RegexOptions.IgnoreCase);

                    if (match.Success) number = match.Groups[1].Value;
                    else continue;

                    foreach (Connector con in item.MEPModel.ConnectorManager.Connectors)
                    {
                        if (con.IsConnected)
                        {
                            Element element = con.AllRefs.Cast<Connector>().First().Owner;

                            if (!(element is Pipe)) continue;
                            
                            string pipeName = element.Name;

                            string pipeNum = "";
                           
                            Match match2 = Regex.Match(pipeName, pattern, RegexOptions.IgnoreCase);

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
[assembly: AssemblyTitle("GateValvePressureCorrection")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("GateValvePressureCorrection")]
[assembly: AssemblyCopyright("Copyright ©  2024")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// 将 ComVisible 设置为 false 会使此程序集中的类型
//对 COM 组件不可见。如果需要从 COM 访问此程序集中的类型
//请将此类型的 ComVisible 特性设置为 true。
[assembly: ComVisible(false)]

// 如果此项目向 COM 公开，则下列 GUID 用于类型库的 ID
[assembly: Guid("c370feeb-6a0f-466a-9974-d3608f88ee5b")]

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

