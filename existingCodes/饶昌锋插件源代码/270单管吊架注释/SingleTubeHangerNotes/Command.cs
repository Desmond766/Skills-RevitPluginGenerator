using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleTubeHangerNotes
{
    [TransactionAttribute(TransactionMode.Manual)]
    [RegenerationAttribute(RegenerationOption.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;
            SingleFilter filter = new SingleFilter();
            IList<Reference> references= uidoc.Selection.PickObjects(ObjectType.Element,filter);
            
            View view = uidoc.ActiveView;
            using (Transaction tran = new Transaction(doc, "添加标记"))
            {
                tran.Start();
                foreach (Reference refs in references)
                {
                   Element elem= doc.GetElement(refs);
                    AddIndependentTag.Add(doc, elem, view);
                }
                tran.Commit();
            }
            return Result.Succeeded;
        }
    }
}
