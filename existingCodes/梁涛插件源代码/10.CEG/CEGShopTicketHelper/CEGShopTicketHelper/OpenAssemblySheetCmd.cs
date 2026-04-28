using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CEGShopTicketHelper
{
    [Transaction(TransactionMode.Manual)]
    public class OpenAssemblySheetCmd : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            if (!CEGToolsHelper.Utils.CheckReg())
            {
                return Result.Cancelled;
            }

            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            //Selection sel = uiapp.ActiveUIDocument.Selection;

            //show dialog
            OpenAssemblySheetFrm frm = new OpenAssemblySheetFrm();
            if (DialogResult.OK != frm.ShowDialog())
            {
                return Result.Cancelled;
            }
            if (DialogResult.OK !=
                MessageBox.Show("open all the sheet of " + frm._selectedAssembly + " ?", "CEG-China",
                MessageBoxButtons.OKCancel))
            {
                return Result.Cancelled;
            }
            string selectedAssembly = frm._selectedAssembly;

            List<ViewSheet> sheets = new FilteredElementCollector(doc)
                .OfClass(typeof(ViewSheet))
                .Cast<ViewSheet>().ToList();

            List<ViewSheet> sheetList = new List<ViewSheet>();
            //从整个项目中找到assmbly用的图纸
            foreach (ViewSheet sheet in sheets)
            {
                ElementId id = sheet.AssociatedAssemblyInstanceId;
                if (null == id) { continue; }
                if (null == doc.GetElement(id)) { continue; }
                if (doc.GetElement(id).Name == selectedAssembly)
                {
                    sheetList.Add(sheet);
                }
            }
            foreach (ViewSheet sheet in sheetList)
            {
                uiapp.ActiveUIDocument.ActiveView = sheet;
            }

            return Result.Succeeded;
        }
    }
}
