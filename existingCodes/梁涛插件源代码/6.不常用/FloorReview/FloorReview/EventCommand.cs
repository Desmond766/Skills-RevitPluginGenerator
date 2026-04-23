using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloorReview
{
    public class EventCommand : IExternalEventHandler
    {
        public ElementId FloorId { get; set; }
        public void Execute(UIApplication app)
        {
            UIDocument uIDoc = app.ActiveUIDocument;
            Document doc = uIDoc.Document;
            try
            {
                uIDoc.ShowElements(FloorId);
                uIDoc.Selection.SetElementIds(new List<ElementId>() { FloorId });
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string GetName()
        {
            return "EventCommand";
        }
    }
}
