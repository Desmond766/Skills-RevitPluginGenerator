using Autodesk.Revit.UI;
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
    public class LegendViewPopulatorCmd : IExternalCommand
    {
        public List<ElementId> selectedSheetList = new List<ElementId>();
        public List<LegendViewInfo> legendInfoList = new List<LegendViewInfo>();

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            if (!CEGToolsHelper.Utils.CheckReg())
            {
                return Result.Cancelled;
            }

            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;

            // select
            if (sel.GetElementIds().Count == 0)
            {
                message = "Select LegendView First!";
                return Result.Cancelled;
            }

            // collect info
            foreach (ElementId id in sel.GetElementIds())
            {
                Element elem = doc.GetElement(id);
                if (elem is Viewport)
                {
                    Viewport port = elem as Viewport;
                    Autodesk.Revit.DB.View view = doc.GetElement(port.ViewId) as Autodesk.Revit.DB.View;
                    if (view.ViewType == ViewType.Legend)
                    {
                        LegendViewInfo info = new LegendViewInfo(port);
                        legendInfoList.Add(info);
                    }
                }
            }
            if(legendInfoList.Count == 0)
            {
                message = "No LegendView Slected!";
                return Result.Cancelled;
            }

            //show dialog
            AssemblySheetFrm frm = new AssemblySheetFrm(doc);
            frm.ShowDialog();
            selectedSheetList = frm.selectedSheetList;

            using (Transaction tran = new Transaction(doc, "LegendPopulate"))
            {
                tran.Start();
                foreach (ElementId id in selectedSheetList)
                {
                    try
                    {
                        ViewSheet sheet = doc.GetElement(id) as ViewSheet;
                        if (null != sheet)
                        {
                            //添加到图纸中
                            foreach (LegendViewInfo info in legendInfoList)
                            {
                                Viewport port = Viewport.Create(
                                doc, sheet.Id, info.ViewId, info.Position);
                                port.get_Parameter(BuiltInParameter.ELEM_TYPE_PARAM).Set(info.TypeId);
                                port.get_Parameter(BuiltInParameter.VIEW_DESCRIPTION).Set(info.TitleOnSheet);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        //
                        continue;
                    }
                }
                tran.Commit();
            }

            return Result.Succeeded;
        }

    }

    
}
