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

                            if (match2.Success) pipeNum = match2.Groups[1].Value;
                            else continue;

                            if(number != pipeNum)
                            {
                                string symbolName = name.Replace(number, pipeNum);

                                FamilySymbol familySymbol = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_PipeAccessory).WhereElementIsElementType()
                                    .Cast<FamilySymbol>().Where(x => x.FamilyName == item.Symbol.FamilyName && x.Name == symbolName).FirstOrDefault();

                                if (familySymbol == null) continue;
                                if (!familySymbol.IsActive) familySymbol.Activate();



                                item.ChangeTypeId(familySymbol.Id);

                                count++;
                                inff += item.Id + "\n";

                                break;
                            }

                        }
                    }
                }
                t.Commit();
            }
            TaskDialog.Show("提示", "此次运行插件修正压力的闸阀个数：" + count + "\n" + "新增连接方式参数的闸阀个数：" + count2);
            return Result.Succeeded;
        }
    }
}
