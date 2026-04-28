using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloorReview
{
    public class DelEventCommand : IExternalEventHandler
    {
        public bool IsTextNote { get; set; }
        public void Execute(UIApplication app)
        {
            UIDocument uIDoc = app.ActiveUIDocument;
            Document doc = uIDoc.Document;

            if (IsTextNote)
            {
                List<ElementId> textNoteIds = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_TextNotes).OfClass(typeof(TextNote)).Cast<TextNote>().Select(x => x.Id).ToList();
                using (Transaction t = new Transaction(doc, "删除所有文字注释"))
                {
                    t.Start();
                    foreach (var item in textNoteIds)
                    {
                        doc.Delete(item);
                    }
                    t.Commit();
                }
            }
        }

        public string GetName()
        {
            return "DelEventCommand";
        }
    }
}
