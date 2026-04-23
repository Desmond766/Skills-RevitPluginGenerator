using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace FlippingBeam
{
    [Transaction(TransactionMode.Manual)]
    public class Positioning : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Assembly.UnsafeLoadFrom(@"C:\ProgramData\Autodesk\Revit\Addins\2020\Teigha_Net64\TD_Mgd.dll");
            UIDocument uIDoc = commandData.Application.ActiveUIDocument;
            Document doc = uIDoc.Document;

            Reference reference = uIDoc.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.PointOnElement);

            ImportInstance dwg = doc.GetElement(reference) as ImportInstance;
            Transform transform = dwg.GetTransform();
            var geoObj = (dwg as Element).GetGeometryObjectFromReference(reference);
            Element element = doc.GetElement(reference);
            CADLinkType cADLinkType = doc.GetElement(element.GetTypeId()) as CADLinkType;
            Class2 class2 = new Class2();
            List<CADTextModel> cADTextModels = class2.GetCADTextInfo(Class2.GetCADPath(cADLinkType.Id, doc));
            TextNote textNote = doc.GetElement(uIDoc.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.Element)) as TextNote;
            TaskDialog.Show("sd", textNote.BaseDirection.AngleTo(XYZ.BasisX.Negate()).ToString());
            //List<TextNote> textNotes = new List<TextNote>();
            //using (Transaction t = new Transaction(doc, "创建文字注释"))
            //{
            //    t.Start();
            //    foreach (var item in cADTextModels)
            //    {
            //        TextNote.Create(doc, uIDoc.ActiveView.Id, item.Location, item.Text, new ElementId(118235));
            //    }
            //    t.Commit();
            //}
            List<TextNote> textNotes = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_TextNotes).OfClass(typeof(TextNote)).Cast<TextNote>().ToList();
            List<IndependentTag> independentTags = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_StructuralFramingTags).OfClass(typeof(IndependentTag)).Cast<IndependentTag>().ToList();
            List<Beamx> beams = new List<Beamx>();
            foreach (var item in independentTags)
            {
                FamilyInstance familyInstance = item.GetTaggedLocalElement() as FamilyInstance;
                Line line = (familyInstance.Location as LocationCurve).Curve as Line;
                double angle1 = line.Direction.AngleTo(XYZ.BasisX);
                double angle2 = line.Direction.AngleTo(XYZ.BasisX.Negate());
                string tagText = item.TagText;
                string newTagText = Regex.Replace(tagText, @"[^0-9]+", "");
                bool find = false;
                foreach (var item1 in textNotes)
                {
                    XYZ point = item1.Coord;
                    XYZ noteDirection = item1.BaseDirection;
                    double noteAngle = noteDirection.AngleTo(XYZ.BasisX);
                    //放样
                    double radius = 1000 / 304.8;
                    Curve circle1 = Arc.Create(point, radius, 0, Math.PI, XYZ.BasisX, XYZ.BasisY);
                    Curve circle2 = Arc.Create(point, radius, Math.PI, 2 * Math.PI, XYZ.BasisX, XYZ.BasisY);
                    List<CurveLoop> loops = new List<CurveLoop>();
                    List<Curve> curveList = new List<Curve> { circle1, circle2 };
                    CurveLoop curveLoop = CurveLoop.Create(curveList);
                    loops.Add(curveLoop);
                    //拉伸
                    Solid solid1 = GeometryCreationUtilities.CreateExtrusionGeometry(loops, XYZ.BasisZ, 200);
                    ElementIntersectsSolidFilter filter = new ElementIntersectsSolidFilter(solid1);
                    List<FamilyInstance> beams1 = new FilteredElementCollector(doc,doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_StructuralFraming).OfClass(typeof(FamilyInstance)).WherePasses(filter).Cast<FamilyInstance>().Where(x => x.Symbol.FamilyName.Contains("梁")).ToList();
                    if (beams1.Count == 1)
                    {
                        if (familyInstance.Id != beams1.First().Id) continue;
                        string noteText =  item1.Text;
                        string newNoteText = Regex.Replace(noteText, @"[^0-9]+", "");

                        if (Math.Abs(noteAngle - angle1) < 0.5 || Math.Abs(noteAngle - angle2) < 0.5)
                        {
                            string info;
                            if (newTagText == newNoteText)
                            {
                                info = "是";
                            }
                            else
                            {
                                info = "否"; 
                            }
                            find = true;
                            Beamx beamx = new Beamx() { beamName = item.TagText, beamId = familyInstance.Id, correct = info};
                            beams.Add(beamx);
                            break;
                        }
                    }
                    else if (beams1.Count > 1)
                    {
                        foreach (var item2 in beams1)
                        {
                            if (familyInstance.Id != item2.Id) continue;
                            string noteText = item1.Text;
                            string newNoteText = Regex.Replace(noteText, @"[^0-9]+", "");
                            

                            if (Math.Abs(noteAngle - angle1) < 0.5 || Math.Abs(noteAngle - angle2) < 0.5)
                            {
                                string info;
                                if (newTagText == newNoteText)
                                {
                                    info = "是";
                                }
                                else
                                {
                                    info = "否";
                                }
                                find = true;
                                Beamx beamx = new Beamx() { beamName = item.TagText, beamId = familyInstance.Id, correct = info};
                                beams.Add(beamx);
                                break;
                            }
                        }
                        
                    }
                    if (find) break;
                }
                if (!find)
                {
                    Beamx beamx1 = new Beamx() {beamName = item.TagText, beamId = familyInstance.Id, correct = "未知" };
                    beams.Add(beamx1);
                }
            }
            //Position position = new Position(beams, doc, uIDoc);
            //position.Show();
            return Result.Succeeded;
        }
    }
}
