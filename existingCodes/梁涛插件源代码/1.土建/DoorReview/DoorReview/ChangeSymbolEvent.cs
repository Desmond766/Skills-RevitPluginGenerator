using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DoorReview
{
    internal class ChangeSymbolEvent : IExternalEventHandler
    {
        public FamilyInstance Door { get; set; }
        public FamilySymbol DoorSymbol { get; set; }
        public void Execute(UIApplication app)
        {
            UIDocument uidoc = app.ActiveUIDocument;
            Document document = app.ActiveUIDocument.Document;
            using (Transaction t = new Transaction(document, "更换门类型"))
            {
                t.Start();
                try
                {
                    Door.ChangeTypeId(DoorSymbol.Id);
                    t.Commit();
                }
                catch (Exception e)
                {
                    if (t.HasStarted()) t.RollBack();
                    MessageBox.Show(e.Message);
                }
                uidoc.Selection.SetElementIds(new ElementId[] { Door.Id });
            }
            
        }

        public string GetName()
        {
            return "ChangeSymbolEvent";
        }
    }
}
