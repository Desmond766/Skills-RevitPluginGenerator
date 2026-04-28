using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomComponentInformationAssignment
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uIDoc = commandData.Application.ActiveUIDocument;
            Document doc = uIDoc.Document;

            List<Room> rooms = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Rooms).WhereElementIsNotElementType().Cast<Room>().ToList();


            TransactionGroup TG = new TransactionGroup(doc, "构件安装位置赋值");
            TG.Start();
            foreach (Room room in rooms)
            {
                XYZ min = null;
                XYZ max = null;

                GeometryElement geometryElement = room.ClosedShell;
                Solid solid = null;
                foreach (var item in geometryElement)
                {
                    if (item is Solid solidRoom)
                    {
                        solid = solidRoom;
                        BoundingBoxXYZ boundingBox = solid.GetBoundingBox();
                        min = boundingBox.Transform.OfPoint(boundingBox.Min);
                        max = boundingBox.Transform.OfPoint(boundingBox.Max);
                        break;
                    }
                }

                ElementIntersectsSolidFilter solidFilter = new ElementIntersectsSolidFilter(solid);
                Outline outline = new Outline(min, max);
                BoundingBoxIntersectsFilter intersectsFilter = new BoundingBoxIntersectsFilter(outline);
                List<Pipe> pipes = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_PipeCurves).WhereElementIsNotElementType().WherePasses(intersectsFilter).WherePasses(solidFilter).Cast<Pipe>().ToList();
                string roomName = room.Name;

                using (Transaction t = new Transaction(doc, "构件安装位置赋值"))
                {
                    t.Start();
                    foreach (var pipe in pipes)
                    {
                        try
                        {
                            pipe.LookupParameter("安装位置").Set(roomName);
                        }
                        catch (Exception)
                        {
                            continue;
                        }
                    }
                    t.Commit();
                }
            }
            TG.Assimilate();
            


            return Result.Succeeded;
        }
    }
}
