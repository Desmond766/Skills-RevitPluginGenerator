using System;
using System.Linq;
using System.Text;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace WallAreaLister
{
    [Transaction(TransactionMode.ReadOnly)]
    [Regeneration(RegenerationOption.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiApp = commandData.Application;
            UIDocument uiDoc = uiApp.ActiveUIDocument;
            Document doc = uiDoc.Document;

            try
            {
                var walls = new FilteredElementCollector(doc, doc.ActiveView.Id)
                    .OfCategory(BuiltInCategory.OST_Walls)
                    .WhereElementIsNotElementType()
                    .Cast<Wall>()
                    .ToList();

                if (walls.Count == 0)
                {
                    TaskDialog.Show("Wall Areas", "No walls found in the active view.");
                    return Result.Succeeded;
                }

                var lines = new StringBuilder();
                double totalM2 = 0.0;

                foreach (Wall w in walls.OrderBy(x => x.Name).ThenBy(x => x.Id.Value))
                {
                    Parameter p = w.get_Parameter(BuiltInParameter.HOST_AREA_COMPUTED);
                    double areaInternal = (p != null && p.HasValue) ? p.AsDouble() : 0.0;
                    double areaM2 = UnitUtils.ConvertFromInternalUnits(areaInternal, UnitTypeId.SquareMeters);
                    totalM2 += areaM2;

                    lines.AppendLine(string.Format(
                        "[{0}] {1} - {2:F2} m^2",
                        w.Id.Value,
                        string.IsNullOrEmpty(w.Name) ? "(unnamed)" : w.Name,
                        areaM2));
                }

                lines.AppendLine();
                lines.AppendLine(string.Format("Total: {0} walls, {1:F2} m^2", walls.Count, totalM2));

                var dlg = new TaskDialog("Wall Areas")
                {
                    MainInstruction = string.Format("{0} wall(s) in the active view", walls.Count),
                    MainContent = lines.ToString()
                };
                dlg.Show();

                return Result.Succeeded;
            }
            catch (Autodesk.Revit.Exceptions.OperationCanceledException)
            {
                return Result.Cancelled;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return Result.Failed;
            }
        }
    }
}
