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
    public class TitleBlockInfoCmd : IExternalCommand
    {
        string drawBy = null;
        string checkBy = null;
        public string designBy = null;
        public string p1 = null;
        public string v1 = null;
        public string p2 = null;
        public string v2 = null;
        public string p3 = null;
        public string v3 = null;
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            if (!CEGToolsHelper.Utils.CheckReg())
            {
                return Result.Cancelled;
            }

            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;

            //1.check active view
            if (!doc.ActiveView.IsAssemblyView || !(doc.ActiveView is ViewSheet))
            {
                message = "tool should run inside a assembly sheet!";
                return Result.Cancelled;
            }

            //2.show dialog
            TitleBlockInfoFrm frm = new TitleBlockInfoFrm();
            if (DialogResult.OK != frm.ShowDialog())
            {
                return Result.Cancelled;
            }
            drawBy = frm.drawBy;
            checkBy = frm.checkBy;
            designBy = frm.designBy;
            p1 = frm.p1;
            v1 = frm.v1;
            p2 = frm.p2;
            v2 = frm.v2;
            p3 = frm.p3;
            v3 = frm.v3;

            ViewSheet currentSheet = doc.GetElement(doc.ActiveView.Id) as ViewSheet;
            AssemblyInstance currentAssembly = doc.GetElement(currentSheet.AssociatedAssemblyInstanceId)
                as AssemblyInstance;
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
                if (doc.GetElement(id).Name == currentAssembly.Name)
                {
                    sheetList.Add(sheet);
                }
            }

            using (Transaction t = new Transaction(doc, "TitleBlockInfo"))
            {
                t.Start();

                foreach (ViewSheet s in sheetList)
                {
                    Parameter param_DB = s.GetParameters("Drawn By").First();
                    if (param_DB != null && !string.IsNullOrEmpty(drawBy))
                    {
                        param_DB.Set(drawBy);
                    }
                    Parameter param_CB = s.GetParameters("Checked By").First();
                    if (param_CB != null && !string.IsNullOrEmpty(checkBy))
                    {
                        param_CB.Set(checkBy);
                    }
                    Parameter param_DEB = s.GetParameters("Designed By").First();
                    if (param_DEB != null && !string.IsNullOrEmpty(designBy))
                    {
                        param_DEB.Set(designBy);
                    }

                    //custom parameter

                    if (!string.IsNullOrEmpty(p1))
                    {
                        Parameter param_p1 = s.GetParameters(p1).First();
                        if (param_p1 != null && !string.IsNullOrEmpty(v1))
                        {
                            param_p1.Set(v1);
                        }
                    }
                    if (!string.IsNullOrEmpty(p2))
                    {
                        Parameter param_p2 = s.GetParameters(p2).First();
                        if (param_p2 != null && !string.IsNullOrEmpty(v2))
                        {
                            param_p2.Set(v2);
                        }
                    }
                    if (!string.IsNullOrEmpty(p3))
                    {
                        Parameter param_p3 = s.GetParameters(p3).First();
                        if (param_p3 != null && !string.IsNullOrEmpty(v3))
                        {
                            param_p3.Set(v3);
                        }
                    }
                }

                t.Commit();
            }

            return Result.Succeeded;
        }
    }
}
