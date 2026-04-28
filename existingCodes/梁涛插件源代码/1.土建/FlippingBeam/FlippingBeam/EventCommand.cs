using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FlippingBeam
{
    public class EventCommand : IExternalEventHandler
    {
        public ElementId beamId { get; set; }
        public string beamName { get; set; }
        public string correct { get; set; }
        public string noteText { get; set; }
        public void Execute(UIApplication app)
        {
            UIDocument uIDoc = app.ActiveUIDocument;
            Document doc = uIDoc.Document;
            //string newBeamName = Regex.Replace(doc.GetElement(beamId).Name, @"[^0-9]+", "");
            //if (noteText == "未找到")
            //{
            //    Position.correct = "未知";
            //}
            //else if (newBeamName == noteText )
            //{
            //    Position.correct = "是";
            //}
            //else
            //{
            //    Position.correct = "否";
            //}
            try
            {
                uIDoc.ShowElements(beamId);
                uIDoc.Selection.SetElementIds(new List<ElementId>() { beamId });
            }
            catch (Exception)
            {

                throw;
            }
            

            ////放样
            //double radius = 1000 / 304.8;
            //Curve circle1 = Arc.Create(point, radius, 0, Math.PI, XYZ.BasisX, XYZ.BasisY);
            //Curve circle2 = Arc.Create(point, radius, Math.PI, 2 * Math.PI, XYZ.BasisX, XYZ.BasisY);
            //List<CurveLoop> loops = new List<CurveLoop>();
            //List<Curve> curveList = new List<Curve> { circle1, circle2 };
            //CurveLoop curveLoop = CurveLoop.Create(curveList);
            //loops.Add(curveLoop);
            ////拉伸
            //Solid solid1 = GeometryCreationUtilities.CreateExtrusionGeometry(loops, XYZ.BasisZ, 200);
            //ElementIntersectsSolidFilter filter = new ElementIntersectsSolidFilter(solid1);
            //List<FamilyInstance> beams = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_StructuralFraming).OfClass(typeof(FamilyInstance)).WherePasses(filter).Cast<FamilyInstance>().Where(x => x.Symbol.FamilyName.Contains("梁")).ToList();
            //if (beams.Count == 0)
            //{
            //    uIDoc.ShowElements(noteId);
            //    uIDoc.Selection.SetElementIds(new List<ElementId>() { noteId });
            //}
            //else if (beams.Count == 1)
            //{
            //    Line line = (beams.First().Location as LocationCurve).Curve as Line;
            //    double angle1 = line.Direction.AngleTo(XYZ.BasisX);
            //    double angle2 = line.Direction.AngleTo(XYZ.BasisX.Negate());

            //    uIDoc.ShowElements(beams.First().Id);
            //    uIDoc.Selection.SetElementIds(new List<ElementId>() { beams.First().Id });
            //}
            //else
            //{
            //    double minDistance = double.MaxValue;
            //    FamilyInstance minBeam = null;
            //    foreach (var item in beams)
            //    {
            //        Line line = (item.Location as LocationCurve).Curve as Line;
            //        XYZ beamMidP = line.GetEndPoint(0).Add(line.GetEndPoint(1)) / 2;
            //        double distance = beamMidP.DistanceTo(point);
            //        if ( distance < minDistance)
            //        {
            //            minDistance = distance;
            //            minBeam = item;
            //        }
            //    }
            //    uIDoc.ShowElements(minBeam.Id);
            //    uIDoc.Selection.SetElementIds(new List<ElementId>() { minBeam.Id });
            //}
            //uIDoc.RefreshActiveView();
        }

        public string GetName()
        {
            return "EventCommand";
        }
    }
}
