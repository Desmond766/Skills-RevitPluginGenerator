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
    public class UpdateQtyCmd : IExternalCommand
    {
        //public string qtyParamName = "Piece_Count";
        public string qtyParamName = "TKT_TOTAL_REQUIRED";
        public string ctrlNoParamName = "Number";
        //public string ctrlNoParamName = "TKT_CONTROL_01";
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            if (!CEGToolsHelper.Utils.CheckReg())
            {
                return Result.Cancelled;
            }

            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;

            //1.check active view
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

            //2.get all the sheet
            List<ViewSheet> viewSheets = FindAllSheetInAssembly(doc, currentSheet.AssociatedAssemblyInstanceId);

            //3.check qty parameter
            var qtyParamList = currentSheet.GetParameters(qtyParamName);
            if (qtyParamList.Count == 0)
            {
                message = "couldn't find share parameter " + qtyParamName 
                    + " in sheet, please setup the parameters and try again.";
                return Result.Cancelled;
            }

            //4.find piece by controlMark
            string controlMark = string.Empty;
            List<Element> pieceList = FindPiecesByControlMark(doc, ref controlMark);
            if (pieceList.Count == 0)
            {
                message = "Couldn't find any piece with control mark " + controlMark;
                return Result.Cancelled;
            }
            string controlNumber = GetControlNumberStr(pieceList);

            //5.set the parameter
            using (Transaction trans = new Transaction(doc,"Update Mark and No"))
            {
                trans.Start();
                foreach (ViewSheet sheet in viewSheets)
                {
                    sheet.GetParameters(qtyParamName).First().Set(pieceList.Count.ToString());
                    //if there is no ctrlNoParam then skip
                    var ctrlNoParamList = sheet.GetParameters(ctrlNoParamName);
                    if (ctrlNoParamList.Count > 0)
                    {
                        sheet.GetParameters(ctrlNoParamName).First().Set(controlNumber);
                    }
                }
                trans.Commit();
            }

            return Result.Succeeded;
        }

        public List<Element> FindPiecesByControlMark(Document doc, ref string controlMark)
        {
            ViewSheet currentSheet = doc.ActiveView as ViewSheet;

            Element currentAssembly = doc.GetElement(currentSheet.AssociatedAssemblyInstanceId);
            //Get ControlMark
            //todo get control mark from pca panel parameter?
            //get control mark from name
            controlMark = currentAssembly.Name;

            //filter in model
            List<Element> elementList = new List<Element>();//element found

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
                            elementList.Add(e);
                        }
                    }
                }
            }
            return elementList;
        }

        public string GetControlNumberStr(List<Element> pieceList)
        {
            List<string> controlNumList = new List<string>();
            List<string> errorList = new List<string>();
            foreach (Element e in pieceList)
            {
                string num = e.GetParameters("CONTROL_NUMBER").First().AsString();
                if (!string.IsNullOrEmpty(num))
                {
                    //num = int.Parse(num).ToString();
                    controlNumList.Add(num);
                }
                else//if not found, show the RevitId
                {
                    errorList.Add("RId" + e.Id.IntegerValue.ToString());
                }
            }
            controlNumList.Sort(new StringComparer(true));
            string info = "";
            if (controlNumList.Count > 0)
            {
                info += string.Join(", ", controlNumList);
            }
            if (errorList.Count > 0)
            {
                info += ", " + string.Join(", ", errorList);
            }
            return info;
        }

        public List<ViewSheet> FindAllSheetInAssembly(Document doc, ElementId assemblyInstId)
        {
            FilteredElementCollector viewSheetCol = new FilteredElementCollector(doc);
            List<ViewSheet> viewSheetList = viewSheetCol.OfClass(typeof(ViewSheet))
                .ToElements().Cast<ViewSheet>().Where(u => u.IsAssemblyView)
                .Where(u => u.AssociatedAssemblyInstanceId.IntegerValue == assemblyInstId.IntegerValue)
                .ToList();
            return viewSheetList;
        }
    }
}
