using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI.Selection;
using System.Windows.Forms;

namespace CEGShopTicketHelper
{
    [Transaction(TransactionMode.Manual)]
    public class InsulationScheduleCmd : IExternalCommand
    {
        public static string thicknessStr = "2";
        public string CEGInsulationFamily = "CEG - INSULATION";
        public string LengthParam = "DIM_LENGTH";
        public string WidthParam = "DIM_WIDTH";
        public string ControlMarkParam = "CONTROL_MARK";
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            if (!CEGToolsHelper.Utils.CheckReg())
            {
                return Result.Cancelled;
            }

            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;

            //验证当前视图
            if (!doc.ActiveView.IsAssemblyView)
            {
                message = "please used in shopticket/assembly sheet";
                return Result.Cancelled;
            }

            //筛选正确的保温块
            List<FamilyInstance> insulList = new List<FamilyInstance>();
            foreach (ElementId id in sel.GetElementIds())
            {
                Element elem = doc.GetElement(id);
                FamilyInstance insulInst = elem as FamilyInstance;
                if (null == insulInst) { continue; }
                if (elem.Name.StartsWith(CEGInsulationFamily)
                    && elem.Category.Id.IntegerValue == (int)BuiltInCategory.OST_DetailComponents)
                {
                    insulList.Add(insulInst);
                }
            }
            if (insulList.Count == 0)
            {
                message = "please select insulation item before running this tool!";
                return Result.Cancelled;
            }
            var groups = insulList.GroupBy(u => Utils.GetParameterByName(u, ControlMarkParam))//根据controlmark分组
                        .OrderBy(u => u.Key, new StringComparer(false));

            ////收集insulation
            //FilteredElementCollector collector = new FilteredElementCollector(doc, doc.ActiveView.Id);
            //var groups = collector.OfClass(typeof(FamilyInstance))
            //    .OfCategory(BuiltInCategory.OST_DetailComponents)
            //    .ToElements()
            //    .Cast<FamilyInstance>()
            //    .Where(u => u.Name.StartsWith(CEGInsulationFamily))
            //    .ToList()
            //    .GroupBy(u => Utils.GetParameterByName(u, ControlMarkParam))//根据controlmark分组
            //    .OrderBy(u => u.Key, new StringComparer(false));

            if (groups.Count() == 0)
            {
                message = string.Format("can't find {0} instance in active view!", CEGInsulationFamily);
                return Result.Cancelled;
            }

            InsulationFrm frm = new InsulationFrm(thicknessStr);
            if (DialogResult.OK != frm.ShowDialog())
            {
                return Result.Cancelled;
            }
            thicknessStr = frm.m_thicknessStr.Trim();

            string result = "MK  QTY  LENGTH";
            string controlMark = "";
            string count = "";
            string lengthStr = "";
            string widthStr = "";
            string context = "";
            string symbolName = "";
            foreach (IGrouping<string, FamilyInstance> group in groups)
            {
                context = "";
                controlMark = group.Key;
                context += controlMark;
                context = context.PadRight(6);
                count = group.Count().ToString();
                context += count;
                context = context.PadRight(12);
                lengthStr = Utils.GetParameterByName(group.First(), LengthParam);//.Replace(" ", "");
                widthStr = Utils.GetParameterByName(group.First(), WidthParam);//.Replace(" ", "");
                result += "\n" + string.Format("{0} {1} x {2} x {3}\"", context, widthStr, lengthStr, thicknessStr);
                symbolName = group.First().Symbol.Name;
                if (symbolName != CEGInsulationFamily + " - A" && symbolName != CEGInsulationFamily + " - X")
                {
                    result += "(W/B.O.)";
                }
            }

            //选择文字更新
            Reference reference = null;
            try
            {
                reference = sel.PickObject(ObjectType.Element,
                "Please select a textNote to update insulation schedule.");
            }
            //ESC
            catch (Exception ex)
            {
                if (ex.Message == "The user aborted the pick operation.")
                {
                    //don't show up
                }
                else
                {
                    TaskDialog.Show("Revit",
                    ex.Message + "\n" + ex.StackTrace.ToString());
                }
                return Result.Cancelled;
            }
            TextNote txt = doc.GetElement(reference) as TextNote;

            if (null == txt)
            {
                message = "Please select a textNote to update insulation schedule!";
                return Result.Cancelled;
            }

            //更新
            using (Transaction trans = new Transaction(doc,"CEG Insulation Schedule"))
            {
                trans.Start();
                txt.Text = result;
                trans.Commit();
            }

            return Result.Succeeded;
        }
    }
}
