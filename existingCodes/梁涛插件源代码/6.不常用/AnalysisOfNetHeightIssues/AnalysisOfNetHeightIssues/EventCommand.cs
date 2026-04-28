using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalysisOfNetHeightIssues
{
    public class EventCommand : IExternalEventHandler
    {
        public ElementId ductId {  get; set; }
        public void Execute(UIApplication app)
        {
            UIDocument uIDoc = app.ActiveUIDocument;
            Document doc = uIDoc.Document;
            uIDoc.ShowElements(ductId);
            uIDoc.Selection.SetElementIds(new List<ElementId>() { ductId });
            uIDoc.RefreshActiveView();
        }

        public string GetName()
        {
            return "EventCommand";
        }
    }
}
