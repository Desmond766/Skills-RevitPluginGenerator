using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicModelUpdate
{
    [Transaction(TransactionMode.Manual)]
    public class UpdateCommand : IExternalCommand
    {
        public static ChangeType ChangeType;
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Document doc = commandData.Application.ActiveUIDocument.Document;
            MyUpdater myUpdater = new MyUpdater(commandData.Application.ActiveAddInId);
            if (UpdaterRegistry.IsUpdaterRegistered(myUpdater.GetUpdaterId(),doc))
            {
                UpdaterRegistry.RemoveDocumentTriggers(myUpdater.GetUpdaterId(), doc);
                UpdaterRegistry.UnregisterUpdater(myUpdater.GetUpdaterId(), doc);
            }
            UpdaterRegistry.RegisterUpdater(myUpdater, doc,true);
            ElementFilter elementFilter = new ElementClassFilter(typeof(CableTray));
            UpdaterRegistry.AddTrigger(myUpdater.GetUpdaterId(), doc, elementFilter, Element.GetChangeTypeGeometry());
            throw new NotImplementedException();
        }
    }
}
