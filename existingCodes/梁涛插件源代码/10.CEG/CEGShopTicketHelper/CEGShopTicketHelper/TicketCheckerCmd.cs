using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI.Selection;
using System.Windows.Forms;

namespace CEGShopTicketHelper
{
    [Transaction(TransactionMode.Manual)]
    public class TicketCheckerCmd : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //if (!CEGToolsHelper.Utils.CheckReg())
            //{
            //    return Result.Cancelled;
            //}

            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            
            // run in a assemblyView
            if (!doc.ActiveView.IsAssemblyView)
            {
                message = "TicketChecking only work for shopticket/assembly sheet";
                return Result.Cancelled;
            }
            ViewSheet currentSheet = doc.ActiveView as ViewSheet;
            if (null == currentSheet)
            {
                message = "TicketChecking only work for shopticket/assembly sheet";
                return Result.Cancelled;
            }
            AssemblyInstance currentAssemblyInst 
                = doc.GetElement(currentSheet.AssociatedAssemblyInstanceId)
                as AssemblyInstance;

            TicketChecker tChecker = new TicketChecker(currentAssemblyInst);

            TicketCheckerFrm frm = new TicketCheckerFrm();
            if (DialogResult.OK != frm.ShowDialog())
            {
                return Result.Cancelled;
            }


            List<CheckingItem> checkingItems = frm._checkingItems;
            //TaskDialog.Show("r", string.Join("\n", checkingItems.ToArray()));

            return Result.Succeeded;
        }

        private void RebarListCheck(TicketChecker tc)
        {

        }

    }
}
