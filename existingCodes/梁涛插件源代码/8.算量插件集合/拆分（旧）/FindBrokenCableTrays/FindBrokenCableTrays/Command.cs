using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindBrokenCableTrays
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;

            var cableTrays = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_CableTray)
                .OfClass(typeof(CableTray)).Cast<CableTray>();

            var infos = new List<CableTrayInfo>();

            foreach (var item in cableTrays)
            {
                foreach (Connector con in item.ConnectorManager.Connectors)
                {
                    if (!con.IsConnected && con.ConnectorType == ConnectorType.End)
                    {
                        infos.Add(new CableTrayInfo() { CableTrayId = item.Id, CableTrayName = item.Name}); break;
                    }
                }
            }
            ShowWindow showWindow = new ShowWindow(infos, uidoc);
            showWindow.Show();


            return Result.Succeeded;
        }
    }
}
