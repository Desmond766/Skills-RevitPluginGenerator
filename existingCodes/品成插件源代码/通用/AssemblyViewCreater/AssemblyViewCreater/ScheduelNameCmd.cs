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

namespace AssemblyViewCreater
{
    [Transaction(TransactionMode.Manual)]
    class ScheduelNameCmd : IExternalCommand
    {
        public List<ElementId> selectedScheduelList = new List<ElementId>();
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;

            //show dialog
            AssemblySheetFrm frm = new AssemblySheetFrm(doc);
            frm.ShowDialog();
            selectedScheduelList = frm.selectedSheetList;



            using (Transaction tran = new Transaction(doc, "Sheet Name"))
            {
                tran.Start();
                foreach (ElementId id in selectedScheduelList)
                {
                    ViewSchedule sheet = doc.GetElement(id) as ViewSchedule;
                    if (null != sheet)
                    {
                        string scheduelNamebefore = sheet.Name;
                        string old = "SCHE_Concrete";//SCHE_Rebar  SCHE_Embed  SCHE_Concrete
                        string scheduelNameafter = scheduelNamebefore.Replace(old, "コンクリート");//鉄筋 副資材 コンクリート

                        //TaskDialog.Show("a", "1");
                        sheet.Name = scheduelNameafter;

                    }
                }

                tran.Commit();
                TaskDialog.Show("a", "end");
            }



            return Result.Succeeded;
        }
    }
}
