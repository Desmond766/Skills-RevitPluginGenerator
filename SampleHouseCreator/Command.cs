using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI;

namespace SampleHouseCreator
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class Command : IExternalCommand
    {
        // Building footprint (metres, origin at SW corner of the house).
        //
        //  Y=8  +----------+----------+----------+
        //       |  Bed 1   |  Bed 2   |  Bed 3   |
        //       |  4 x 4   |  4 x 4   |  4 x 4   |
        //  Y=4  +----+-----+----------+-----+----+
        //       |    |                      |    |
        //       |Wash| Hallway  (3<x<9)     |Wash|
        //       | 1  |                      | 2  |
        //  Y=0  +----+----------------------+----+
        //       X=0  X=3    X=4       X=8  X=9   X=12
        //
        // Garden: open floor slab south of the house, Y in [-5,-1], X in [2,10].

        private const double WallHeightM  = 3.0;
        private const double DuctHeightM  = 2.7;
        private const double PipeHeightM  = 0.3;

        private static double M(double metres)
            => UnitUtils.ConvertToInternalUnits(metres, UnitTypeId.Meters);

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
                    message = "No Level found in the project.";
                    return Result.Failed;
                }

                WallType wallType = new FilteredElementCollector(doc)
                    .OfClass(typeof(WallType))
                    .Cast<WallType>()
                    .FirstOrDefault(t => t.Kind == WallKind.Basic);
                if (wallType == null)
                {
                    message = "No Basic Wall type found. Load a wall family or use a template with Basic Walls.";
                    return Result.Failed;
                }

                FloorType floorType = new FilteredElementCollector(doc)
                    .OfClass(typeof(FloorType))
                    .Cast<FloorType>()
                    .FirstOrDefault(t => !t.IsFoundationSlab);
                if (floorType == null)
                {
                    floorType = new FilteredElementCollector(doc)
                        .OfClass(typeof(FloorType))
                        .Cast<FloorType>()
                        .FirstOrDefault();
                }
                if (floorType == null)
                {
                    message = "No Floor type found.";
                    return Result.Failed;
                }

                DuctType ductType = new FilteredElementCollector(doc)
                    .OfClass(typeof(DuctType)).Cast<DuctType>().FirstOrDefault();
                MechanicalSystemType mechSys = new FilteredElementCollector(doc)
                    .OfClass(typeof(MechanicalSystemType)).Cast<MechanicalSystemType>()
                    .FirstOrDefault(s => s.SystemClassification == MEPSystemClassification.SupplyAir)
                    ?? new FilteredElementCollector(doc)
                        .OfClass(typeof(MechanicalSystemType)).Cast<MechanicalSystemType>().FirstOrDefault();

                PipeType pipeType = new FilteredElementCollector(doc)
                    .OfClass(typeof(PipeType)).Cast<PipeType>().FirstOrDefault();
                PipingSystemType pipeSys = new FilteredElementCollector(doc)
                    .OfClass(typeof(PipingSystemType)).Cast<PipingSystemType>()
                    .FirstOrDefault(s => s.SystemClassification == MEPSystemClassification.DomesticColdWater)
                    ?? new FilteredElementCollector(doc)
                        .OfClass(typeof(PipingSystemType)).Cast<PipingSystemType>().FirstOrDefault();

                var warnings = new List<string>();
                int wallCount = 0, roomCount = 0, ductCount = 0, pipeCount = 0, floorCount = 0;

                using (var tx = new Transaction(doc, "Create Sample House"))
                {
                    tx.Start();

                    double height = M(WallHeightM);
                    double z = level.Elevation;

                    var wallLines = new (double x1, double y1, double x2, double y2)[]
                    {
                        (0, 0, 12, 0),   // exterior south
                        (12, 0, 12, 8),  // exterior east
                        (12, 8, 0, 8),   // exterior north
                        (0, 8, 0, 0),    // exterior west
                        (0, 4, 12, 4),   // interior horizontal mid
                        (4, 4, 4, 8),    // bed1 / bed2 divider
                        (8, 4, 8, 8),    // bed2 / bed3 divider
                        (3, 0, 3, 4),    // wash1 / hallway divider
                        (9, 0, 9, 4),    // hallway / wash2 divider
                    };
                    foreach (var w in wallLines)
                    {
                        var line = Line.CreateBound(
                            new XYZ(M(w.x1), M(w.y1), z),
                            new XYZ(M(w.x2), M(w.y2), z));
                        Wall.Create(doc, line, wallType.Id, level.Id, height, 0.0, false, false);
                        wallCount++;
                    }

                    doc.Regenerate();

                    var roomSpecs = new (string name, double cx, double cy)[]
                    {
                        ("Bedroom 1",  2.0,  6.0),
                        ("Bedroom 2",  6.0,  6.0),
                        ("Bedroom 3",  10.0, 6.0),
                        ("Washroom 1", 1.5,  2.0),
                        ("Hallway",    6.0,  2.0),
                        ("Washroom 2", 10.5, 2.0),
                    };
                    foreach (var r in roomSpecs)
                    {
                        var uv = new UV(M(r.cx), M(r.cy));
                        Room room = doc.Create.NewRoom(level, uv);
                        if (room != null)
                        {
                            room.Name = r.name;
                            roomCount++;
                        }
                        else
                        {
                            warnings.Add($"Room '{r.name}' not placed (area may not be enclosed).");
                        }
                    }

                    var gardenLoop = new CurveLoop();
                    var gPts = new[]
                    {
                        new XYZ(M(2),  M(-5), z),
                        new XYZ(M(10), M(-5), z),
                        new XYZ(M(10), M(-1), z),
                        new XYZ(M(2),  M(-1), z),
                    };
                    for (int i = 0; i < gPts.Length; i++)
                    {
                        gardenLoop.Append(Line.CreateBound(gPts[i], gPts[(i + 1) % gPts.Length]));
                    }
                    Floor garden = Floor.Create(
                        doc,
                        new List<CurveLoop> { gardenLoop },
                        floorType.Id,
                        level.Id);
                    if (garden != null)
                    {
                        floorCount++;
                        Parameter commentsParam = garden.get_Parameter(BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS);
                        if (commentsParam != null && !commentsParam.IsReadOnly)
                        {
                            commentsParam.Set("Garden");
                        }
                    }

                    if (ductType != null && mechSys != null)
                    {
                        double zDuct = z + M(DuctHeightM);
                        var ductSegs = new (double x1, double y1, double x2, double y2)[]
                        {
                            (3,  2, 9,  2),   // supply trunk along hallway
                            (2,  2, 2,  6),   // branch to Bedroom 1
                            (6,  2, 6,  6),   // branch to Bedroom 2
                            (10, 2, 10, 6),   // branch to Bedroom 3
                        };
                        foreach (var d in ductSegs)
                        {
                            var p1 = new XYZ(M(d.x1), M(d.y1), zDuct);
                            var p2 = new XYZ(M(d.x2), M(d.y2), zDuct);
                            try
                            {
                                Duct.Create(doc, mechSys.Id, ductType.Id, level.Id, p1, p2);
                                ductCount++;
                            }
                            catch (Exception ex)
                            {
                                warnings.Add($"Duct segment failed: {ex.Message}");
                            }
                        }
                    }
                    else
                    {
                        warnings.Add("Ducts skipped: project has no DuctType or MechanicalSystemType. Use a template that includes MEP content.");
                    }

                    if (pipeType != null && pipeSys != null)
                    {
                        double zPipe = z + M(PipeHeightM);
                        var pipeSegs = new (double x1, double y1, double x2, double y2)[]
                        {
                            (3,   2, 9,    2),  // cold-water main along hallway
                            (1.5, 2, 3,    2),  // branch to Washroom 1
                            (9,   2, 10.5, 2),  // branch to Washroom 2
                        };
                        foreach (var p in pipeSegs)
                        {
                            var p1 = new XYZ(M(p.x1), M(p.y1), zPipe);
                            var p2 = new XYZ(M(p.x2), M(p.y2), zPipe);
                            try
                            {
                                Pipe.Create(doc, pipeSys.Id, pipeType.Id, level.Id, p1, p2);
                                pipeCount++;
                            }
                            catch (Exception ex)
                            {
                                warnings.Add($"Pipe segment failed: {ex.Message}");
                            }
                        }
                    }
                    else
                    {
                        warnings.Add("Pipes skipped: project has no PipeType or PipingSystemType. Use a template that includes MEP content.");
                    }

                    tx.Commit();
                }

                var summary = new StringBuilder();
                summary.AppendLine($"Walls:   {wallCount}");
                summary.AppendLine($"Rooms:   {roomCount}");
                summary.AppendLine($"Garden:  {floorCount} floor");
                summary.AppendLine($"Ducts:   {ductCount}");
                summary.AppendLine($"Pipes:   {pipeCount}");
                if (warnings.Count > 0)
                {
                    summary.AppendLine();
                    summary.AppendLine("Warnings:");
                    foreach (var w in warnings) summary.AppendLine("  - " + w);
                }

                var dlg = new TaskDialog("Sample House Created")
                {
                    MainInstruction = "Sample house created at the project origin.",
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
