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
    public class PopulateCtrlNumCmd : IExternalCommand
    {
        public string paramName;
        public int startNum;
        public string format;

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            if (!CEGToolsHelper.Utils.CheckReg())
            {
                return Result.Cancelled;
            }

            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;

            //show frm
            using (PopulateCtrlNumFrm frm = new PopulateCtrlNumFrm())
            {
                if (DialogResult.OK != frm.ShowDialog())
                {
                    return Result.Cancelled;
                }
                paramName = frm.paramName;
                startNum = frm.startNum;
                format = frm.format;
            }

            int index = startNum;
            while (true)
            {
                try
                {
                    // select PCa
                    Reference reference = sel.PickObject(ObjectType.Element, new StructuralFramingFilter());
                    Element element = doc.GetElement(reference);
                    PopulateNum(doc, element, index);
                    index++;
                }
                catch (Exception ex)
                {
                    if (ex.Message == "The user aborted the pick operation.")
                    {
                        TaskDialog.Show("Revit", "Cancel!");
                        break;
                    }
                    else
                    {
                        TaskDialog.Show("Revit",
                        ex.Message + "\n" + ex.StackTrace.ToString());
                        break;
                    }
                }
            }

            return Result.Succeeded;
        }

        private void PopulateNum(Document doc, Element elem, int index)
        {
            foreach (var item in elem.GetParameters(paramName))
            {
                using (Transaction trans = new Transaction(doc, "CtrlNum"))
                {
                    trans.Start();
                    item.Set(index.ToString(format));
                    trans.Commit();
                }
            }
        }
    }
}
