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
    class SheetCreaterCmd : IExternalCommand
    {
        //ElementId titleBlockId = new ElementId(7114050);//titleBlockSymbolId
        public List<AssemblyInstance> selectedList = new List<AssemblyInstance>();
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;

            Reference r = sel.PickObject(ObjectType.Element);
            Element e = doc.GetElement(r);
            ElementId titleBlockId = e.GetTypeId();




            //show dialog
            AssemblyFrm frm = new AssemblyFrm(doc);
            frm.ShowDialog();
            selectedList = frm.selectedList;

            ////show dialog
            //TitleBlockFrm frm1 = new TitleBlockFrm(doc);
            //frm1.ShowDialog();

            using (Transaction tran = new Transaction(doc, "Sheet Creater"))
            {
                tran.Start();
                foreach (AssemblyInstance assembly in selectedList)
                {
                    ViewSheet sheet = AssemblyViewUtils.CreateSheet(doc, assembly.Id, titleBlockId);
                }


                tran.Commit();
            }

            return Result.Succeeded;
        }
    }
}
