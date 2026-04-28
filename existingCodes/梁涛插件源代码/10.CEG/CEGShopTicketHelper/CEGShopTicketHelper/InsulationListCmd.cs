using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI.Selection;
using System.Net;

namespace CEGShopTicketHelper
{
    [Transaction(TransactionMode.Manual)]
    public class InsulationListCmd : IExternalCommand
    {
        string InsulationFamilyName = "CEG - INSULATION -";
        //保温字典
        Dictionary<string, Insulation> insulationTypeDict 
            = new Dictionary<string, Insulation>();
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            if (!CEGToolsHelper.Utils.CheckReg())
            {
                return Result.Cancelled;
            }

            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;

            //找当前项目中的所有保温类型
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            List<Element> insulationList = collector.OfCategory(BuiltInCategory.OST_DetailComponents)
                .OfClass(typeof(FamilyInstance)).ToElements()
                .Where(u => u.Name.StartsWith(InsulationFamilyName)).ToList();

            foreach (Element e in insulationList)
            {
                string controlMark = Utils.GetParameterByName(e, "CONTROL_MARK");
                if (controlMark != "MKXX" && !string.IsNullOrEmpty(controlMark))
                {
                    if (!insulationTypeDict.ContainsKey(controlMark))
                    {
                        Insulation ins = new Insulation(e);
                        insulationTypeDict.Add(ins.ControlMark, ins);
                    }
                }
            }
            //TaskDialog.Show("r", insulationList.Count.ToString());
            //TaskDialog.Show("r", insulationTypeDict.Count.ToString());

            //找当前视图中的未命名的保温
            FilteredElementCollector collector2 = new FilteredElementCollector(doc, doc.ActiveView.Id);
            List<Element> unNamedInsulationList = collector2.OfCategory(BuiltInCategory.OST_DetailComponents)
                .OfClass(typeof(FamilyInstance)).ToElements()
                .Where(u => u.Name.StartsWith(InsulationFamilyName)).ToList();

            using (Transaction trans = new Transaction(doc, "CEG-Insulation"))
            {
                trans.Start();
                foreach (Element e in unNamedInsulationList)
                {
                    string controlMark = Utils.GetParameterByName(e, "CONTROL_MARK");
                    Insulation ins = new Insulation(e);
                    if (controlMark == "MKXX" || string.IsNullOrEmpty(controlMark))
                    {
                        AssignInsulationName(ins);
                        //设置参数
                        e.GetParameters("CONTROL_MARK").First().Set(ins.ControlMark);
                    }
                }
                trans.Commit();
            }

            return Result.Succeeded;
        }

        private void AssignInsulationName(Insulation ins)
        {
            foreach (Insulation item in insulationTypeDict.Values)
            {
                if (item.IsSameAs(ins))
                {
                    //找到相同的
                    ins.ControlMark = item.ControlMark;
                    return;
                }
            }
            //如果都没有，给一个新的编号
            string newNumber = (GetLastNumber(insulationTypeDict) + 1).ToString();
            //将新类型加入字典
            if (!insulationTypeDict.ContainsKey(newNumber))
            {
                ins.ControlMark = newNumber;
                insulationTypeDict.Add(newNumber, ins);
            }
            return;
        }

        private int GetLastNumber(Dictionary<string, Insulation> insulationTypeDict)
        {
            List<string> keyList = insulationTypeDict.Keys.ToList();
            if (keyList.Count == 0) { return 0; }
            keyList.Sort(new StringComparer(true));
            return int.Parse(keyList.Last());
        }
    }
}
