using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;


namespace CEGShopTicketHelper
{
    [Transaction(TransactionMode.Manual)]
    public class InsulationListCmd2 : IExternalCommand
    {
        string dictPathParamName = "Insulation_Dict_Path";
        string InsulationFamilyName = "CEG - INSULATION -";
        string occupiedFlag = "Occupied";
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

            //仅支持中心模型
            string path = GetCentralServerPath(doc);
            if (string.IsNullOrEmpty(path))
            {
                message = "this is not a central model, program cancelled";
                return Result.Cancelled;
            }

            //找到项目信息中记录的保温板字典文件
            ProjectInfo pi = doc.ProjectInformation;
            var paramList = pi.GetParameters(dictPathParamName);
            if (paramList.Count == 0)
            {
                message = string.Format("couldn't find parameter \"{0}\" in project information!", dictPathParamName);
                return Result.Cancelled;
            }
            string dictPath = paramList.First().AsValueString();
            if (string.IsNullOrEmpty(dictPath))
            {
                message = string.Format("{0} is blank", dictPathParamName);
                return Result.Cancelled;
            }
            if (!File.Exists(dictPath))
            {
                message = string.Format("couldn't find file {0}", dictPath);
                return Result.Cancelled;
            }

            //打开文件后
            //判断最后一行是不是有“Occupied”标识符
            //如果有，结束程序
            //如果没有，添加一个字符串“Occupied”
            string[] data = File.ReadAllLines(dictPath);
            if (data.Last() == occupiedFlag)
            {
                message = string.Format("{0} is occupied, please try later", dictPath);
                return Result.Cancelled;
            }
            else
            {
                File.AppendAllText(dictPath, "\n" + occupiedFlag);
            }
            //Thread.Sleep(10000);

            //读取保温板字典
            foreach (string item in data)
            {
                if (item == "occupiedFlag" || string.IsNullOrEmpty(item)) { continue; }
                string[] info = item.Split('|');
                if (info.Count() == 3)//MARK|SYMBOL|ID
                {
                    string mark = info[0];
                    string symbol = info[1];
                    string id = info[2];
                    Insulation insulation = new Insulation(mark, symbol, id);
                    if (!insulationTypeDict.ContainsKey(mark))
                    {
                        insulationTypeDict.Add(mark, insulation);
                    }
                }
            }

            //找当前视图中的未命名的保温
            FilteredElementCollector collector = new FilteredElementCollector(doc, doc.ActiveView.Id);
            List<Element> unNamedInsulationList = collector.OfCategory(BuiltInCategory.OST_DetailComponents)
                .OfClass(typeof(FamilyInstance)).ToElements()
                .Where(u => u.Name.StartsWith(InsulationFamilyName)).ToList();

            using (Transaction trans = new Transaction(doc, "CEG-Insulation2"))
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

            //重新排序，将保温板字典写回
            var list = insulationTypeDict.OrderBy(u => u.Key, new StringComparer(true)).ToList();
            //导出
            string[] contents = list.Select(u =>
                string.Format("{0}|{1}|{2}",
                u.Key, u.Value.IDescription, u.Value.IdentityInfo))
                .ToArray();
            string fileName = doc.Title;
            File.WriteAllLines(dictPath, contents);

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

        private string GetCentralServerPath(Document doc)
        {
            var modelPath = doc.GetWorksharingCentralModelPath();
            var centralServerPath = ModelPathUtils.ConvertModelPathToUserVisiblePath(modelPath);

            return centralServerPath;
        }
    }
}
