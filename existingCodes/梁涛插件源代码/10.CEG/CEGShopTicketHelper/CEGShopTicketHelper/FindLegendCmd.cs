using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI.Selection;

//use to find the sheets which contain this legend
namespace CEGShopTicketHelper
{
    [Transaction(TransactionMode.Manual)]
    public class FindLegendCmd : IExternalCommand
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

            Element elem = null;
            try
            {
                elem = doc.GetElement(sel.PickObject(ObjectType.Element));
            }
            //ESC
            catch (Exception ex)
            {
                if (ex.Message == "The user aborted the pick operation.")
                {
                    return Result.Cancelled;
                }
            }
            Viewport viewPort = elem as Viewport;
            if (null == viewPort)
            {
                message = "Please select a legend viewport on shopticket!";
                return Result.Cancelled;
            }
            View view = doc.GetElement(viewPort.ViewId) as View;
            if (view.ViewType != ViewType.Legend)
            {
                message = "Please select a legend viewport on shopticket!";
                return Result.Cancelled;
            }
            string legendName = view.Name;
            
            //collect sheet Name
            List<string> sheetNameList = new List<string>();
            FilteredElementCollector collector = new FilteredElementCollector(doc)
                .OfClass(typeof(View));
            
            foreach (ElementId id in collector.ToElementIds())
            {
                ViewSheet sheet = doc.GetElement(id) as ViewSheet;
                if (null != sheet)
                {
                    if (sheet.IsAssemblyView)
                    {
                        foreach (ElementId id2 in sheet.GetAllViewports())
                        {
                            Viewport vp = doc.GetElement(id2) as Viewport;
                            if (null != vp)
                            {
                                View v = doc.GetElement(vp.ViewId) as View;
                                if (v.Name == legendName && v.ViewType == ViewType.Legend)
                                {
                                    sheetNameList.Add("[" + sheet.SheetNumber + "=>" + sheet.Name + "]");
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            sheetNameList.Sort(new StringComparer(true));
            //at least one
            System.Windows.Forms.MessageBox.Show(
                "This Legend used to sheets below:\n"
                + string.Join("\n", sheetNameList.ToArray())
                , "CEG Find Legend");

            return Result.Succeeded;
        }
    }
}
