using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineAlignment
{
    public class ExternalEvent : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            UIDocument uidoc = app.ActiveUIDocument;
            Selection sel = uidoc.Selection;
            Document doc = uidoc.Document;

            Next:
            Reference refer;
            IList<Reference> references;
            try
            {
                refer = sel.PickObject(ObjectType.Element, new MEPFilter(), "选择基准管线");
                references = sel.PickObjects(ObjectType.Element, new MEPFilter(), "选择要对齐的管线");
                using (Transaction t = new Transaction(doc, "横管对齐"))
                {
                    t.Start();


                    t.Commit();
                }
            }
            catch (OperationCanceledException)
            {
                return;
            }
            goto Next;
        }

        public string GetName()
        {
            return "ExternalEvent";
        }
    }
}
