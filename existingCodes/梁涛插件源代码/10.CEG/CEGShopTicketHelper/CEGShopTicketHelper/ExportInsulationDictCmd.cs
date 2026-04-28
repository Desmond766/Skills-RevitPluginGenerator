using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEGShopTicketHelper
{
    [Transaction(TransactionMode.Manual)]
    public class ExportInsulationDictCmd : IExternalCommand
    {
        string InsulationFamilyName = "CEG - INSULATION -";
        //保温字典
        Dictionary<string, Insulation> insulationTypeDict
            = new Dictionary<string, Insulation>();

        string _desktopFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string _ext = ".txt";
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
            var list = insulationTypeDict.OrderBy(u => u.Key, new StringComparer(true)).ToList();

            //导出
            string[] contents = list.Select(u=> 
                string.Format("{0}|{1}|{2}", 
                u.Key, u.Value.IDescription, u.Value.IdentityInfo))
                .ToArray();
            string fileName = doc.Title;
            File.WriteAllLines(Path.Combine(_desktopFolder, fileName + _ext), contents);

            return Result.Succeeded;
        }
    }
}
