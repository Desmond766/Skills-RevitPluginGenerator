using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//视图样板刷
namespace Demo02
{
    [Transaction(TransactionMode.Manual)]
    public class Command04 : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uIDoc = commandData.Application.ActiveUIDocument;
            Document doc = uIDoc.Document;

            Reference referenceNone = uIDoc.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.Element, new ViewPortFilter(), "Select The Viewport To Set The View Template For");
            Reference referenceHave = uIDoc.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.Element, new ViewPortFilter(), "Select the viewport of the view template to copy");

            Viewport viewportNone = doc.GetElement(referenceNone) as Viewport;
            Viewport viewportHave = doc.GetElement(referenceHave) as Viewport;


            using (Transaction t = new Transaction(doc, "View Template Brush"))
            {
                t.Start();
                ElementId elementId = viewportHave.get_Parameter(BuiltInParameter.VIEW_TEMPLATE).AsElementId();
                viewportNone.get_Parameter(BuiltInParameter.VIEW_TEMPLATE).Set(elementId);
                t.Commit();
            }

            return Result.Succeeded;
        }
    }
}
