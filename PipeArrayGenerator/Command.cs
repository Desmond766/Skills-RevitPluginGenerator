using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI;

namespace PipeArrayGenerator
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class Command : IExternalCommand
    {
        // Nominal diameters in millimetres. One pipe per size, DN25 -> DN200.
        private static readonly int[] DnSizesMm =
            { 25, 32, 40, 50, 65, 80, 100, 125, 150, 200 };

        private const double PipeLengthM = 10.0;
        private const double PipeSpacingM = 0.5;
        private const double PipeElevationM = 0.3;

        private static double ToFt(double metres)
            => UnitUtils.ConvertToInternalUnits(metres, UnitTypeId.Meters);

        private static double MmToFt(double mm)
            => UnitUtils.ConvertToInternalUnits(mm, UnitTypeId.Millimeters);

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Document doc = commandData.Application.ActiveUIDocument.Document;

            try
            {
                Level level = new FilteredElementCollector(doc)
                    .OfClass(typeof(Level))
                    .Cast<Level>()
                    .OrderBy(l => l.Elevation)
                    .FirstOrDefault();
                if (level == null)
                {
                    message = "No Level found in the project. Open a project template that contains at least one Level.";
                    return Result.Failed;
                }

                PipeType pipeType = new FilteredElementCollector(doc)
                    .OfClass(typeof(PipeType))
                    .Cast<PipeType>()
                    .FirstOrDefault();
                if (pipeType == null)
                {
                    message = "No PipeType found. Use a project/template that includes MEP content (e.g. the Mechanical template).";
                    return Result.Failed;
                }

                PipingSystemType pipeSystem = new FilteredElementCollector(doc)
                    .OfClass(typeof(PipingSystemType))
                    .Cast<PipingSystemType>()
                    .FirstOrDefault(s => s.SystemClassification == MEPSystemClassification.DomesticColdWater)
                    ?? new FilteredElementCollector(doc)
                        .OfClass(typeof(PipingSystemType))
                        .Cast<PipingSystemType>()
                        .FirstOrDefault();
                if (pipeSystem == null)
                {
                    message = "No PipingSystemType found. Use a project/template that includes MEP content.";
                    return Result.Failed;
                }

                double z = level.Elevation + ToFt(PipeElevationM);
                double xStart = 0.0;
                double xEnd = ToFt(PipeLengthM);
                double spacingFt = ToFt(PipeSpacingM);

                var warnings = new List<string>();
                var created = new List<(int dn, ElementId id)>();

                using (var tx = new Transaction(doc, "Generate Pipe Array"))
                {
                    tx.Start();

                    for (int i = 0; i < DnSizesMm.Length; i++)
                    {
                        int dn = DnSizesMm[i];
                        double y = i * spacingFt;
                        XYZ p1 = new XYZ(xStart, y, z);
                        XYZ p2 = new XYZ(xEnd, y, z);

                        try
                        {
                            Pipe pipe = Pipe.Create(doc, pipeSystem.Id, pipeType.Id, level.Id, p1, p2);

                            // Set nominal diameter. Revit snaps to the nearest size in the routing preferences.
                            Parameter diamParam = pipe.get_Parameter(BuiltInParameter.RBS_PIPE_DIAMETER_PARAM);
                            if (diamParam != null && !diamParam.IsReadOnly)
                            {
                                diamParam.Set(MmToFt(dn));
                            }

                            created.Add((dn, pipe.Id));
                        }
                        catch (Exception ex)
                        {
                            warnings.Add($"DN{dn}: {ex.Message}");
                        }
                    }

                    tx.Commit();
                }

                var summary = new StringBuilder();
                summary.AppendLine($"Created {created.Count} of {DnSizesMm.Length} pipes.");
                summary.AppendLine();
                summary.AppendLine("Layout:");
                summary.AppendLine($"  X: 0 m -> {PipeLengthM} m");
                summary.AppendLine($"  Y: 0 m -> {(DnSizesMm.Length - 1) * PipeSpacingM} m ({PipeSpacingM} m spacing)");
                summary.AppendLine($"  Z: +{PipeElevationM} m above level '{level.Name}'");
                summary.AppendLine();
                summary.AppendLine("Sizes (bottom -> top):");
                foreach (var c in created)
                {
                    summary.AppendLine($"  DN{c.dn}");
                }
                if (warnings.Count > 0)
                {
                    summary.AppendLine();
                    summary.AppendLine("Warnings:");
                    foreach (var w in warnings) summary.AppendLine("  - " + w);
                }

                var dlg = new TaskDialog("Pipe Array Created")
                {
                    MainInstruction = "Pipe array generated at the project origin.",
                    MainContent = summary.ToString()
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
                message = ex.Message + "\n" + ex.StackTrace;
                return Result.Failed;
            }
        }
    }
}
