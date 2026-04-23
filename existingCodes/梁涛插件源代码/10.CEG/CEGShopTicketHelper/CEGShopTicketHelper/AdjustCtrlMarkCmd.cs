using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CEGShopTicketHelper
{
    [Transaction(TransactionMode.Manual)]
    public class AdjustCtrlMarkCmd : IExternalCommand
    {
        public string parameter;
        public string prefix;
        public int beginMark;
        public int endMark;
        public string operation;
        public int integerStep;
        public Result Execute(ExternalCommandData commandData, 
            ref string message, ElementSet elements)
        {
            if (!CEGToolsHelper.Utils.CheckReg())
            {
                return Result.Cancelled;
            }

            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;

            //改为预选择
            if (sel.GetElementIds().Count == 0)
            {
                message = "Please select the pc panel and run again!";
                return Result.Cancelled;
            }

            //1.弹出对话框
            AdjustCtrlMarkFrm frm = new AdjustCtrlMarkFrm();
            if (DialogResult.OK != frm.ShowDialog())
            {
                return Result.Cancelled;
            }
            parameter = frm._parameter;
            prefix = frm._prefix;
            beginMark = frm._beginMark; 
            endMark = frm._endMark;
            operation = frm._operation;
            integerStep = frm._integerStep;

            //2.找到目标构件
            List<Element> elemetList = new List<Element>();
            //List<Element> elems = new FilteredElementCollector(doc)
            //    .OfClass(typeof(FamilyInstance))
            //    .OfCategory(BuiltInCategory.OST_StructuralFraming)
            //    .ToElements().ToList();

            ICollection<ElementId> elemIds = sel.GetElementIds();
            foreach (ElementId id in elemIds)
            {
                Element e = doc.GetElement(id);
                if(e.Category.Id.IntegerValue != (int)BuiltInCategory.OST_StructuralFraming)
                {
                    continue;
                }
                if (!e.Name.Contains("(DO NOT USE)"))
                {
                    if (e.GetParameters("CONTROL_MARK").Count != 0)
                    {
                        elemetList.Add(e);
                    }
                }
            }
            //TaskDialog.Show("r", parameter + "," + prefix + "," + beginMark.ToString() + "," + endMark);
            //3.更新参数
            using (Transaction trans = new Transaction(doc, "adjust control mark"))
            {
                trans.Start();
                //elemetList = new List<Element>() { doc.GetElement(sel.GetElementIds().First()) };
                foreach (Element e in elemetList)
                {
                    string markStr = Utils.GetParameterByName(e, parameter);
                    if (string.IsNullOrEmpty(markStr)) { continue; }
                    if (parameter == "CONTROL_MARK")
                    {
                        string markPrefix = Utils.RemoveInteger(markStr);
                        if (string.IsNullOrEmpty(markPrefix)) { continue; }
                        string markIntegerStr = Utils.GetInteger(markStr);
                        if (string.IsNullOrEmpty(markIntegerStr)) { continue; }
                        int markInteger = int.Parse(markIntegerStr);//CONTROL MARK:A-XX
                        if (markPrefix == prefix)
                        {
                            if (markInteger >= beginMark && markInteger <= endMark)
                            {
                                //get new mark string
                                string newMarkStr = prefix + (markInteger + integerStep).ToString();
                                if (operation == "-")
                                {
                                    newMarkStr = prefix + (markInteger - integerStep).ToString();
                                }
                                e.GetParameters(parameter).First().Set(newMarkStr);
                            }
                        }
                    }
                    else//CONTROL_NUMBER
                    {
                        int markInteger = 0;
                        bool result = int.TryParse(markStr,out markInteger);//CONTROL NUMBER:0XX
                        if (!result) { continue; }
                        if (markInteger >= beginMark && markInteger <= endMark)
                        {
                            //get new mark string
                            prefix = markStr.StartsWith("00") ? "00" : markStr.StartsWith("0") ? "0" : "";
                            string newMarkStr = prefix + (markInteger + integerStep).ToString();
                            if (newMarkStr.Length > markStr.Length)
                            {
                                //009->0010 should be 010
                                newMarkStr = newMarkStr.Substring(newMarkStr.Length - markStr.Length, markStr.Length);
                            }
                            if (operation == "-")
                            {
                                newMarkStr = prefix + (markInteger - integerStep).ToString();
                            }
                            e.GetParameters(parameter).First().Set(newMarkStr);
                        }
                    }
                    
                }
                trans.Commit();
            }
            return Result.Succeeded;
        }
    }
}
