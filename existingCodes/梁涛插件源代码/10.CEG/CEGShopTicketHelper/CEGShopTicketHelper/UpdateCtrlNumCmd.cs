using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI.Selection;

namespace CEGShopTicketHelper
{
    [Transaction(TransactionMode.Manual)]
    public class UpdateCtrlNumCmd : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            if (!CEGToolsHelper.Utils.CheckReg())
            {
                return Result.Cancelled;
            }

            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;

            //Get CurrentAssembly
            if (!doc.ActiveView.IsAssemblyView)
            {
                message = "please used in shopticket/assembly sheet";
                return Result.Cancelled;
            }
            ViewSheet currentSheet = doc.ActiveView as ViewSheet;
            if (null == currentSheet)
            {
                message = "please used in shopticket/assembly sheet";
                return Result.Cancelled;
            }
            Element currentAssembly = doc.GetElement(currentSheet.AssociatedAssemblyInstanceId);
            //Get ControlMark
            //todo get control mark from pca panel parameter?
            //get control mark from name
            string controlMark = currentAssembly.Name;

            //select a text to update
            Reference reference = null;
            try
            {
                reference = sel.PickObject(ObjectType.Element,
                "Please select a textNote to update control number.");
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
                message = "Please select a textNote to update control number!";
                return Result.Cancelled;
            }

            //filter in model
            List<string> controlNumList = new List<string>();
            List<string> errorList = new List<string>();
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            var elems = collector.OfClass(typeof(FamilyInstance))
                .OfCategory(BuiltInCategory.OST_StructuralFraming).ToElements();
            foreach (Element e in elems)
            {
                if (!e.Name.Contains("(DO NOT USE)"))
                {
                    if (e.GetParameters("CONTROL_MARK").Count != 0)
                    {
                        string mark = e.GetParameters("CONTROL_MARK").First().AsString();
                        if (mark == controlMark)
                        {
                            string num = e.GetParameters("CONTROL_NUMBER").First().AsString();
                            if (!string.IsNullOrEmpty(num))
                            {
                                //num = int.Parse(num).ToString();
                                controlNumList.Add(num);
                            }
                            else
                            {
                                errorList.Add(e.Id.IntegerValue.ToString());
                            }
                        }
                    }
                }
            }
            //controlNumList = new List<string>() { "023","011","015","019","111","125","001","222","201" };
            controlNumList.Sort(new StringComparer(true));

            //result
            string info = "";
            if (controlNumList.Count > 0)
            {
                info += string.Join(", ", controlNumList);
            }
            if (errorList.Count > 0)
            {
                info += "\n These pieces (revit Id) haven't been assigned a control number:" +string.Join(", ", errorList);
            }
            using (Transaction trans = new Transaction(doc,"Update Ctrl Num"))
            {
                trans.Start();
                txt.Text = info;
                trans.Commit();
            }

            //System.Windows.Forms.MessageBox.Show(string.Format("control mark {0} /control number {1}",
            //    controlMark, string.Join(",", controlNumList)));

            return Result.Succeeded;
        }
    }
}
