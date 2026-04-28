using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Events;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Odbc;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;

namespace FlippingBeam
{
    [Transaction(TransactionMode.Manual)]
    public class Compare : IExternalCommand
    {
        UIDocument uIDoc = null;
        Document doc = null;
        public static HashSet<ElementId> ids = null;
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            uIDoc = commandData.Application.ActiveUIDocument;
            doc = uIDoc.Document;

            //string input = ((TextNote)doc.GetElement(commandData.Application.ActiveUIDocument.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.Element))).Text;
            //input = input.Replace("\r", "");
            //input = input.Replace("\n", "");
            //TaskDialog.Show("revit", input);
            //string pattern = @"(\d+)\s*[xX×*]\s*(\d+)";
            //Match match = Regex.Match(input, pattern);
            //if (match.Success && int.TryParse(match.Groups[1].Value, out int left) && int.TryParse(match.Groups[2].Value, out int right))
            //{
            //    TaskDialog.Show("dd", left + "\n" + right); // 输出: 123 x 456
            //}
            //else
            //{
            //    TaskDialog.Show("dd2", match.Groups[1].Value + "\n" + match.Groups[2].Value);
            //}
            //return Result.Succeeded;

            ids = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_StructuralFraming).OfClass(typeof(FamilyInstance)).Select(x => x.Id).ToHashSet();
            //List<Beamx> beamxs = new List<Beamx>();
            ObservableCollection<Beamx> beamxs = new ObservableCollection<Beamx>();
            // UPDATE: 26.3.23 只复核"数字X|x|×|*数字"类型的CAD文字信息
            List<TextNote> textNotes = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_TextNotes).OfClass(typeof(TextNote)).Cast<TextNote>().Where(t => IsBeamTextNote(t)).ToList();

            List<ElementId> textNotesCopy = (from t in textNotes select t.Id).ToList();
            List<FamilyInstance> beams = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_StructuralFraming).OfClass(typeof(FamilyInstance)).Cast<FamilyInstance>().Where(x => x.Symbol.Family.Name.Contains("梁") && x.Location as LocationCurve != null).ToList();
            double totalZ = 0;
            if (beams.Count == 0)
            {
                TaskDialog.Show("提示", "未在该视图中找到梁");
                return Result.Cancelled;
            }
            else
            {
                foreach (var item in beams)
                {
                    try
                    {
                        XYZ p = ((item.Location as LocationCurve).Curve as Line).Origin;
                        totalZ += p.Z;
                    }
                    catch (Exception)
                    {

                        continue;
                    }

                }
            }
            double aveZ = totalZ / beams.Count - 50;
            using (Transaction t = new Transaction(doc, "修改文字注释高度"))
            {
                t.Start();
                foreach (var item in textNotes)
                {
                    item.Coord = new XYZ(item.Coord.X, item.Coord.Y, aveZ);
                }
                t.Commit();
            }
            List<TextNoteInfo> textNoteInfos = new List<TextNoteInfo>();
            //记录已经找到文本注释的梁与已经使用过的文本注释
            List<FamilyInstance> beamsCopy = new List<FamilyInstance>();
            foreach (var item in beams)
            {
                beamsCopy.Add(item);
            }
            List<TextNoteInfo> notesCopy = textNoteInfos;
            textNoteInfos = GetBeamsByLofting(textNotes, doc);
            foreach (var item in beams)
            {
                if (item.Location as LocationCurve == null) continue;
                if (!((item.Location as LocationCurve).Curve is Line)) continue;
                //梁的线
                Line line = (item.Location as LocationCurve).Curve as Line;
                //梁的旋转角
                double angle = line.Direction.AngleTo(XYZ.BasisX);
                //梁的反向旋转角
                double angleNegate = line.Direction.AngleTo(XYZ.BasisX.Negate());
                //梁的宽高信息
                string beamName = item.Name;
                // TODO:LT:正则表达式规则需进一步优化 2024/12/20
                string newBeamName = Regex.Replace(beamName, @"[^0-9]+", "");
                //是否找到对应的文字注释
                bool find = false;
                foreach (var item1 in textNoteInfos)
                {
                    XYZ point = item1.point;
                    XYZ noteDirection = item1.noteDirection;
                    string noteText = item1.noteText;
                    noteText = noteText.Replace("\r", "");
                    string newNoteText = Regex.Replace(noteText, @"[^0-9]+", "");
                    double noteAngle = noteDirection.AngleTo(XYZ.BasisX);
                    List<FilterBeam> filterBeams = item1.filterBeams;
                    List<FamilyInstance> oldBeams = item1.oldBeams;
                    if (filterBeams.Count == 0)
                    {
                        continue;
                    }
                    else if (filterBeams.Count == 1)
                    {
                        if (filterBeams.First().beam.Id != item.Id) continue;
                        if (Math.Abs(angle - noteAngle) < 0.5 || Math.Abs(angleNegate - noteAngle) < 0.5)
                        {
                            find = true;
                            string info;
                            if (newNoteText == newBeamName)
                            {
                                info = "是";
                            }
                            else
                            {
                                info = "否";
                            }
                            Beamx beamx = new Beamx() { beamName = item.Name, beamId = item.Id, correct = info, noteText = noteText, noteID = item1.noteID, beamCou = item1.beamCou, textColor = info == "是" ? "green" : "red", isBold = info == "是" ? false : true, textBackColor = info == "是" ? "" : "blue" };
                            beamxs.Add(beamx);
                            if (textNotesCopy.Contains(item1.noteID))
                            {
                                textNotesCopy.Remove(item1.noteID);
                            }
                            beamsCopy.Remove(item);
                            notesCopy.Remove(item1);

                            break;
                        }
                    }
                    else if (filterBeams.Count > 1)
                    {
                        //double maxArea = double.MinValue;
                        //FamilyInstance familyInstance = null;
                        //先将文字注释与梁之间角度大于10度的梁排除
                        List<FilterBeam> newFilterBeams = new List<FilterBeam>();
                        foreach (var item2 in filterBeams)
                        {
                            LocationCurve locationCurve = item2.beam.Location as LocationCurve;
                            if (locationCurve == null) continue;
                            Curve curve = (locationCurve).Curve;
                            Line line2 = curve as Line;
                            if (line2 == null && (item2.beam.Location as LocationCurve).Curve is Arc arc)
                            {
                                XYZ p0 = arc.GetEndPoint(0);
                                XYZ p1 = arc.GetEndPoint(1);
                                XYZ canterP = arc.Evaluate(0.5, true);
                                XYZ arcDir1 = (p0 - canterP).Normalize();
                                XYZ arcDir2 = (p1 - canterP).Normalize();
                                double arcAngle1 = arcDir1.AngleTo(XYZ.BasisX);
                                double arcAngleNe1 = arcDir1.AngleTo(XYZ.BasisX.Negate());
                                double arcAngle2 = arcDir2.AngleTo(XYZ.BasisX);
                                double arcAngleNe2 = arcDir2.AngleTo(XYZ.BasisX.Negate());
                                if (Math.Abs(arcAngle1 - noteAngle) < 0.175 || Math.Abs(arcAngleNe1 - noteAngle) < 0.175
                                 || Math.Abs(arcAngle2 - noteAngle) < 0.175 || Math.Abs(arcAngleNe2 - noteAngle) < 0.175)
                                    newFilterBeams.Add(item2);
                                continue;
                            }
                            double filterBeamAngle = line2.Direction.AngleTo(XYZ.BasisX);
                            double filterBeamAngleNe = line2.Direction.AngleTo(XYZ.BasisX.Negate());
                            if (Math.Abs(filterBeamAngle - noteAngle) < 0.175 || Math.Abs(filterBeamAngleNe - noteAngle) < 0.175)
                            {
                                newFilterBeams.Add(item2);
                            }
                        }
                        foreach (var item2 in filterBeams)
                        {
                            //if (filterBeams.First().beam.Id != item.Id) break;
                            if (newFilterBeams.Count == 0 || newFilterBeams.First().beam.Id != item.Id) break;
                            //if (item2.beam.Id != item.Id) continue;
                            if (Math.Abs(angle - noteAngle) < 0.175 || Math.Abs(angleNegate - noteAngle) < 0.175)
                            {
                                find = true;
                                string info;
                                if (newNoteText == newBeamName)
                                {
                                    info = "是";
                                }
                                else
                                {
                                    info = "否";
                                }
                                Beamx beamx = new Beamx() { beamName = item.Name, beamId = item.Id, correct = info, noteText = noteText, noteID = item1.noteID, beamCou = item1.beamCou, textColor = info == "是" ? "green" : "red", isBold = info == "是" ? false : true, textBackColor = info == "是" ? "" : "blue" };
                                beamxs.Add(beamx);
                                if (textNotesCopy.Contains(item1.noteID))
                                {
                                    textNotesCopy.Remove(item1.noteID);
                                }
                                beamsCopy.Remove(item);
                                notesCopy.Remove(item1);
                                break;
                            }
                        }
                    }
                    if (find) break;
                }
                //if (!find)
                //{
                //    Beamx beamx2 = new Beamx() { beamName = item.Name, beamId = item.Id, correct = "未知", noteText = "未找到", noteID = new ElementId(1111111), beamCou = 0 };
                //    beamxs.Add(beamx2);
                //}
            }
            //foreach (var item in beamsCopy)
            foreach (var item in beamsCopy)
            {
                //if (item.Location as LocationCurve == null)
                //{
                //    TaskDialog.Show("revit", item.Id.ToString());
                //    return Result.Failed;
                //}
                if (!((item.Location as LocationCurve).Curve is Line)) continue;
                //梁的线
                Line line = (item.Location as LocationCurve).Curve as Line;
                //梁的旋转角
                double angle = line.Direction.AngleTo(XYZ.BasisX);
                //梁的反向旋转角
                double angleNegate = line.Direction.AngleTo(XYZ.BasisX.Negate());

                string beamName = item.Name;
                string newBeamName = Regex.Replace(beamName, @"[^0-9]+", "");
                bool find = false;
                foreach (var item1 in notesCopy)
                {
                    XYZ noteDirection = item1.noteDirection;
                    double noteAngle = noteDirection.AngleTo(XYZ.BasisX);
                    string noteText = item1.noteText;
                    noteText = noteText.Replace("\r", "");
                    string newNoteText = Regex.Replace(noteText, @"[^0-9]+", "");
                    string info;
                    if (newBeamName == newNoteText)
                    {
                        info = "是";
                    }
                    else
                    {
                        info = "否";
                    }
                    if (item1.filterBeams.Count == 0) continue;
                    if (item1.filterBeams.Count == 1 && item1.filterBeams.First().beam.Id == item.Id)
                    {
                        find = true;
                        Beamx beamx = new Beamx() { beamName = item.Name, beamId = item.Id, correct = info, noteText = noteText, noteID = item1.noteID, beamCou = item1.beamCou, textColor = info == "是" ? "green" : "red", isBold = info == "是" ? false : true, textBackColor = info == "是" ? "" : "blue" };
                        beamxs.Add(beamx);
                        if (textNotesCopy.Contains(item1.noteID))
                        {
                            textNotesCopy.Remove(item1.noteID);
                        }
                    }
                    else if (item1.filterBeams.Count > 1)
                    {
                        foreach (var item2 in item1.filterBeams)
                        {
                            if (item2.beam.Id != item.Id) continue;
                            if (Math.Abs(angle - noteAngle) < 0.175 || Math.Abs(angleNegate - noteAngle) < 0.175)
                            {
                                find = true;
                                Beamx beamx = new Beamx() { beamName = item.Name, beamId = item.Id, correct = info, noteText = noteText, noteID = item1.noteID, beamCou = item1.beamCou, textColor = info == "是" ? "green" : "red", isBold = info == "是" ? false : true, textBackColor = info == "是" ? "" : "blue" };
                                beamxs.Add(beamx);
                                if (textNotesCopy.Contains(item1.noteID))
                                {
                                    textNotesCopy.Remove(item1.noteID);
                                }
                            }
                        }
                        if (find) break;
                    }
                }
                if (!find)
                {
                    Beamx beamx = new Beamx() { beamName = item.Name, beamId = item.Id, correct = "未知", noteText = "未找到", noteID = new ElementId(1111111), beamCou = 0, textColor = "yellow", isBold = true };
                    beamxs.Add(beamx);
                }
            }
            foreach (var item in textNotesCopy)
            {
                TextNote textNote = doc.GetElement(item) as TextNote;
                string noteText = textNote.Text;
                noteText = noteText.Replace("\r", "");
                Beamx beamx = new Beamx() { beamName = "无", beamId = new ElementId(1111111), correct = "未知", noteText = noteText, noteID = item, beamCou = 0, textColor = "yellow", isBold = true };
                beamxs.Add(beamx);
            }
            // UPDATE: 26.3.23 梁尺寸与CAD文字不一致时自动匹配与CAD文字信息一致的梁族类型
            var beamSymbols = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_StructuralFraming).OfClass(typeof(FamilySymbol)).Cast<FamilySymbol>().Where(x => x.Family.Name.Contains("梁")).OrderBy(y => Regex.Replace(y.Name, @"[^0-9]+", "")).ToList();
            foreach (var beamx in beamxs.Where(b => b.correct == "否"))
            {
                if (HasSameBeamSymbol(beamx.noteText, beamSymbols, out string newSymbolName))
                {
                    beamx.Status = newSymbolName;
                    beamx.NewBeamSymbolName = newSymbolName;
                }
            }
            // UPDATE: 26.3.23 对复核信息进行排序，优先显示错误的梁信息
            beamxs = SortBeamInfo(beamxs);
            /*
            //foreach (var item in beams)
            //{
            //    //获取梁的线
            //    Line line = (item.Location as LocationCurve).Curve as Line;
            //    //获取梁的旋转角
            //    double angle = line.Direction.AngleTo(XYZ.BasisX);
            //    //梁反方向旋转角
            //    double angleNegate = line.Direction.AngleTo(XYZ.BasisX.Negate());
            //    //梁的宽x高
            //    string beamName = item.Name;
            //    string newBeamName = Regex.Replace(beamName, @"[^0-9]+", "");
            //    //是否找到梁
            //    bool find = false;
            //    foreach (var item1 in textNoteInfos)
            //    {
            //        //标注的坐标
            //        XYZ point = item1.point;
            //        //标注的方向
            //        XYZ noteDirection = item1.noteDirection;
            //        //标注的内容
            //        string noteText = item1.noteText;
            //        noteText = noteText.Replace("\r", "");
            //        string newNoteText = Regex.Replace(noteText, @"[^0-9]+", "");
            //        //标注的旋转角
            //        double noteAngle = noteDirection.AngleTo(XYZ.BasisX);
            //        List<FilterBeam> filterBeams = item1.filterBeams;
            //        if (filterBeams.Count == 0)
            //        {
            //            continue;
            //        }
            //        else if (filterBeams.Count == 1)
            //        {
            //            if (filterBeams.First().beam.Id != item.Id) continue;
            //            if (Math.Abs(angle - noteAngle) < 0.5 || Math.Abs(angleNegate - noteAngle) < 0.5)
            //            {
            //                find = true;
            //                string info;
            //                if (newNoteText == newBeamName)
            //                {
            //                    info = "是";
            //                }
            //                else
            //                {
            //                    info = "否";
            //                }
            //                Beamx beamx = new Beamx() { beamName = item.Name, beamId = item.Id, correct = info, noteText = noteText };
            //                beamxs.Add(beamx);
            //                break;
            //            }
            //        }
            //        else if (filterBeams.Count > 1)
            //        {
            //            double maxArea = double.MinValue;
            //            FamilyInstance familyInstance = null;
            //            foreach (var item2 in filterBeams)
            //            {
            //                if (item2.beam.Id != item.Id) continue;
            //                if (Math.Abs(angle - noteAngle) < 0.175 || Math.Abs(angleNegate - noteAngle) < 0.175)
            //                {
            //                    find = true;
            //                    string info;
            //                    if (newNoteText == newBeamName)
            //                    {
            //                        info = "是";
            //                    }
            //                    else
            //                    {
            //                        info = "否";
            //                    }
            //                    Beamx beamx = new Beamx() { beamName = item.Name, beamId = item.Id, correct = info, noteText = noteText };
            //                    beamxs.Add(beamx);
            //                }

            //            }
            //        }
            //        if (find) break;
            //    }
            //    //foreach (var item1 in textNotes)
            //    //{
            //    //    XYZ point = item1.Coord;
            //    //    XYZ noteDirection = item1.BaseDirection;
            //    //    string noteText = item1.Text;
            //    //    noteText = noteText.Replace("\r", "");
            //    //    string newNoteText = Regex.Replace(noteText, @"[^0-9]+", "");
            //    //    double noteAngle = noteDirection.AngleTo(XYZ.BasisX);
            //    //    //放样
            //    //    double radius = 1000 / 304.8;
            //    //    Curve circle1 = Arc.Create(point, radius, 0, Math.PI, XYZ.BasisX, XYZ.BasisY);
            //    //    Curve circle2 = Arc.Create(point, radius, Math.PI, 2 * Math.PI, XYZ.BasisX, XYZ.BasisY);
            //    //    List<CurveLoop> loops = new List<CurveLoop>();
            //    //    List<Curve> curveList = new List<Curve> { circle1, circle2 };
            //    //    CurveLoop curveLoop = CurveLoop.Create(curveList);
            //    //    loops.Add(curveLoop);
            //    //    //拉伸
            //    //    Solid solid1 = GeometryCreationUtilities.CreateExtrusionGeometry(loops, XYZ.BasisZ, 200);
            //    //    ElementIntersectsSolidFilter filter = new ElementIntersectsSolidFilter(solid1);
            //    //    List<FamilyInstance> filterBeams = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_StructuralFraming).OfClass(typeof(FamilyInstance)).WherePasses(filter).Cast<FamilyInstance>().Where(x => x.Symbol.FamilyName.Contains("梁")).ToList();
            //    //    if (filterBeams.Count == 0)
            //    //    {
            //    //        continue;
            //    //    }
            //    //    else if (filterBeams.Count == 1)
            //    //    {
            //    //        if (filterBeams.First().Id != item.Id) continue;
            //    //        if (Math.Abs(angle - noteAngle) < 0.5 || Math.Abs(angleNegate - noteAngle) < 0.5)
            //    //        {
            //    //            find = true;
            //    //            string info;
            //    //            if (newNoteText == newBeamName)
            //    //            {
            //    //                info = "是";
            //    //            }
            //    //            else
            //    //            {
            //    //                info = "否";
            //    //            }
            //    //            Beamx beamx = new Beamx() { beamName = item.Name, beamId = item.Id, correct = info, noteText = noteText};
            //    //            beamxs.Add(beamx);
            //    //            break;
            //    //        }
            //    //    }
            //    //    else if (filterBeams.Count > 1)
            //    //    {
            //    //        foreach (var item2 in filterBeams)
            //    //        {
            //    //            if (item2.Id != item.Id) continue;
            //    //            if (Math.Abs(angle - noteAngle) < 0.5 || Math.Abs(angleNegate - noteAngle) < 0.5)
            //    //            {
            //    //                find = true;
            //    //                string info;
            //    //                if (newNoteText == newBeamName)
            //    //                {
            //    //                    info = "是";
            //    //                }
            //    //                else
            //    //                {
            //    //                    info = "否";
            //    //                }
            //    //                Beamx beamx = new Beamx() { beamName = item.Name, beamId = item.Id, correct = info, noteText = item1.Text };
            //    //                beamxs.Add(beamx);
            //    //                break;
            //    //            }
            //    //            if (find) break;
            //    //        }
            //    //    }
            //    //    if (find) break;
            //    //}
            //    if (!find)
            //    {
            //        Beamx beamx2 = new Beamx() { beamName = item.Name, beamId = item.Id, correct = "未知", noteText = "未找到" };
            //        beamxs.Add(beamx2);
            //    }
            //}
            */
            List<string> familySymbolNames = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_StructuralFraming).OfClass(typeof(FamilySymbol)).Cast<FamilySymbol>().Where(x => x.Family.Name.Contains("梁")).Select(y => y.Name).ToList();
            Position position = new Position(beamxs, doc, uIDoc);
            //position.WindowStartupLocation = System.Windows.WindowStartupLocation.Manual;
            //position.Left = 0;
            //position.Top = 0;
            GlobalResources.Position1 = position;
            position.Show();
            Application app = commandData.Application.Application;
            app.DocumentChanged += OnDocumentChanged;
            return Result.Succeeded;
        }

        private bool HasSameBeamSymbol(string noteText, List<FamilySymbol> beamSymbols, out string newSymbolName)
        {
            newSymbolName = string.Empty;
            if (HasBeamInfo(noteText, out var beamWidth, out var beamHeight))
            {
                FamilySymbol familySymbol = beamSymbols.Where(bs =>
                {
                    var widthPara = bs.LookupParameter("b") ?? bs.LookupParameter("宽度");
                    var heightPara = bs.LookupParameter("h") ?? bs.LookupParameter("高度");
                    if (widthPara != null && heightPara != null && int.TryParse(widthPara.AsValueString(), out var width) && int.TryParse(heightPara.AsValueString(), out var height))
                    {
                        if (width == beamWidth && height == beamHeight) return true;
                    }
                    return false;
                }).OrderByDescending(fs => Regex.Matches(fs.Name, @"\d").Count).FirstOrDefault();
                if (familySymbol != null)
                {
                    newSymbolName = familySymbol.Name;
                    return true;
                }
            }

            return false;
        }

        private ObservableCollection<Beamx> SortBeamInfo(ObservableCollection<Beamx> beamxs)
        {
            ObservableCollection<Beamx> result = new ObservableCollection<Beamx>();

            List<Beamx> oldBeamxs = beamxs.OrderByDescending(b => b.correct == "否").ThenByDescending(b => b.correct == "未知")
                .ThenByDescending(b => b.noteText == "未找到").ThenByDescending(b => b.beamName == "无")
                .ThenBy(b => b.noteText).ThenBy(b => b.beamName).ToList();

            //beamxs.Clear();

            foreach (Beamx beam in oldBeamxs) { result.Add(beam); }


            return result;
        }
        private bool HasBeamInfo(string text, out int beamWidth, out int beamHeight)
        {
            bool result = false;
            beamWidth = -1;
            beamHeight = -1;

            string input = text;
            string pattern = @"(\d+)\s*[xX×*]\s*(\d+)";
            Match match = Regex.Match(input, pattern);
            if (match.Success && int.TryParse(match.Groups[1].Value, out int left) && int.TryParse(match.Groups[2].Value, out int right))
            {
                beamWidth = left;
                beamHeight = right;
                return true;
            }
            return result;
        }
        private bool IsBeamTextNote(TextNote textNote)
        {
            string input = textNote.Text;
            string pattern = @"(\d+)\s*[xX×*]\s*(\d+)";
            Match match = Regex.Match(input, pattern);
            if (match.Success && int.TryParse(match.Groups[1].Value, out int left) && int.TryParse(match.Groups[2].Value, out int right))
            {
                return true;
            }
            return false;
        }
        public bool FindNewBeam()
        {
            if (null != GlobalResources.Position1.list.SelectedItem)
            {
                Beamx beamx = GlobalResources.Position1.list.SelectedItem as Beamx;
                //获取用户手动创建的梁
                FamilyInstance beam = GetNewCreateBeam();
                if (beam == null) return false;
                if (beamx.beamId.IntegerValue == 1111111)
                {
                    string newNoteText = Regex.Replace(beamx.noteText, @"[^0-9]+", "");
                    string newBeamName = Regex.Replace(beam.Name, @"[^0-9]+", "");
                    string corr;
                    bool isBold;
                    string color;
                    string backColor;
                    if (newNoteText.Equals(newBeamName))
                    {
                        corr = "是";
                        isBold = false;
                        color = "black";
                        backColor = "";
                    }
                    else
                    {
                        corr = "否";
                        isBold = true;
                        color = "red";
                        backColor = "blue";
                    }
                    XYZ beamCP = (beam.Location as LocationCurve).Curve.Evaluate(0.5, true);
                    beamCP = beamCP - XYZ.BasisZ * beamCP.Z;
                    XYZ textNoteP = (doc.GetElement(beamx.noteID) as TextNote).Coord;
                    textNoteP = textNoteP - XYZ.BasisZ * textNoteP.Z;
                    if (beamCP.DistanceTo(textNoteP) > 2000 / 304.8) return false;
                    beamx.isBold = isBold;
                    beamx.correct = corr;
                    beamx.beamId = beam.Id;
                    beamx.beamName = beam.Name;
                    beamx.textColor = color;
                    beamx.textBackColor = backColor;
                    //刷新datagrid数据
                    GlobalResources.Position1.list.Items.Refresh();
                    //datagrid控件重新获得焦点
                    GlobalResources.Position1.list.Focus();
                    //滚动到当前行
                    GlobalResources.Position1.list.ScrollIntoView(GlobalResources.Position1.list.SelectedItem);
                    return true;
                }
            }
            return false;
        }

        public FamilyInstance GetNewCreateBeam()
        {
            HashSet<ElementId> newIds = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_StructuralFraming).OfClass(typeof(FamilyInstance)).Select(x => x.Id).ToList().ToHashSet();
            HashSet<ElementId> onlyNewHasIds = new HashSet<ElementId>(newIds);
            onlyNewHasIds.ExceptWith(ids);
            if (onlyNewHasIds.Count == 1)
            {
                ids = newIds;
                return doc.GetElement(onlyNewHasIds.First()) as FamilyInstance;
            }
            else
            {
                return null;
            }

        }
        /// <summary>
        /// 获取文字注释与梁的对应关系
        /// </summary>
        /// <param name="textNotes"></param>
        /// <param name="doc"></param>
        /// <returns></returns>
        public List<TextNoteInfo> GetBeamsByLofting(List<TextNote> textNotes, Document doc)
        {
            List<TextNoteInfo> textNoteInfos = new List<TextNoteInfo>();
            foreach (var item in textNotes)
            {
                XYZ point = item.Coord;
                XYZ noteDirection = item.BaseDirection;
                string noteText = item.Text;
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
                List<FamilyInstance> filterBeams = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_StructuralFraming).OfClass(typeof(FamilyInstance)).WherePasses(filter).Cast<FamilyInstance>().Where(x => x.Symbol.FamilyName.Contains("梁")).ToList();
                //if (filterBeams.Count == 0)
                //{
                //    Solid solid2 = GeometryCreationUtilities.CreateExtrusionGeometry(loops, XYZ.BasisZ.Negate(), 200);
                //    ElementIntersectsSolidFilter filter2 = new ElementIntersectsSolidFilter(solid2);
                //    filterBeams = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_StructuralFraming).OfClass(typeof(FamilyInstance)).WherePasses(filter2).Cast<FamilyInstance>().Where(x => x.Symbol.FamilyName.Contains("梁")).ToList();
                //}
                //TaskDialog.Show("re", filterBeams.Count.ToString());
                //uIDoc.Selection.SetElementIds(filterBeams.Select(x => x.Id).ToList());
                List<FilterBeam> filterBeams1 = new List<FilterBeam>();
                foreach (var beam in filterBeams)
                {
                    Options options = new Options();
                    options.ComputeReferences = true;
                    options.DetailLevel = ViewDetailLevel.Fine;
                    Solid solid2 = null;
                    GeometryElement geometryElement = beam.get_Geometry(options);
                    bool hasSolid = false;
                    foreach (var geo in geometryElement)
                    {
                        if (geo is Solid solid && solid.SurfaceArea != 0)
                        {
                            hasSolid = true;
                            solid2 = solid; break;
                        }
                    }
                    if (!hasSolid)
                    {
                        foreach (var geo in geometryElement)
                        {
                            if (geo is GeometryInstance geometryInstance)
                            {
                                foreach (var geo2 in geometryInstance.GetSymbolGeometry())
                                {
                                    if (geo2 is Solid solid && solid.SurfaceArea != 0)
                                    {
                                        solid2 = solid;
                                    }
                                }
                            }
                        }
                    }
                    double v = 0;
                    try
                    {
                        Solid temp0 = BooleanOperationsUtils.ExecuteBooleanOperation(solid1, solid2, BooleanOperationsType.Intersect);
                        v = temp0.Volume;
                        FilterBeam filterBeam = new FilterBeam() { beam = beam, intersectionArea = v };
                        filterBeams1.Add(filterBeam);
                    }
                    catch (Exception)
                    {
                        FilterBeam filterBeam = new FilterBeam() { beam = beam, intersectionArea = v };
                        filterBeams1.Add(filterBeam);
                    }

                }
                //List<FilterBeam> filterBeams2 = filterBeams1.OrderByDescending(x => x.intersectionArea).ToList();
                List<FilterBeam> filterBeams2 = filterBeams1.OrderByDescending(x => x.intersectionArea).ToList();
                TextNoteInfo textNoteInfo = new TextNoteInfo() { point = point, noteDirection = noteDirection, noteText = noteText, filterBeams = filterBeams2, noteID = item.Id, beamCou = filterBeams2.Count, oldBeams = filterBeams };
                textNoteInfos.Add(textNoteInfo);
            }
            return textNoteInfos;
        }
        public static void OnDocumentChanged(object sender, DocumentChangedEventArgs e)
        {
            Document doc = e.GetDocument();
            List<FamilySymbol> familySymbols = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_StructuralFraming).OfClass(typeof(FamilySymbol)).Cast<FamilySymbol>().Where(x => x.Family.Name.Contains("梁")).ToList().OrderBy(y => Regex.Replace(y.Name, @"[^0-9]+", "")).ToList();
            GlobalResources.Position1.cb.ItemsSource = familySymbols.Select(x => x.Name);

            Compare compare = new Compare();
            compare.doc = doc;
            bool succeed = compare.FindNewBeam();
            //TaskDialog.Show("ll", succeed.ToString());


            //position.cb.ItemsSource = familySymbols;
        }

    }
    public static class GlobalResources
    {
        public static Position Position1 { get; set; }
    }

    public class TextNoteInfo
    {
        public List<FamilyInstance> oldBeams { get; set; }
        public List<FilterBeam> filterBeams { get; set; }
        public XYZ point { get; set; }
        public XYZ noteDirection { get; set; }
        public string noteText { get; set; }
        //文字注释ID
        public ElementId noteID { get; set; }
        //文字注释包含梁数量
        public int beamCou { get; set; }

    }
    public class FilterBeam
    {
        public double intersectionArea { get; set; }
        public FamilyInstance beam { get; set; }
    }
    //public class Document_changed : IExternalApplication
    //{
    //    public Result OnShutdown(UIControlledApplication application)
    //    {
    //        application.ControlledApplication.DocumentChanged -= new EventHandler<DocumentChangedEventArgs>(application_DocumentChanged);
    //        return Result.Succeeded;
    //    }

    //    public Result OnStartup(UIControlledApplication application)
    //    {
    //        // 假设uiApp是一个UIApplication实例
    //        application.ControlledApplication.DocumentChanged += new EventHandler<DocumentChangedEventArgs>(application_DocumentChanged);
    //        return Result.Succeeded;

    //    }
    //    public void application_DocumentChanged(object sender, DocumentChangedEventArgs args)
    //    {
    //        Document doc = args.GetDocument();
    //        List<FamilySymbol> familySymbols = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_StructuralFraming).OfClass(typeof(FamilySymbol)).Cast<FamilySymbol>().Where(x => x.Family.Name.Contains("梁")).ToList().OrderBy(y => Regex.Replace(y.Name, @"[^0-9]+", "")).ToList();
    //    }
    //}
}
