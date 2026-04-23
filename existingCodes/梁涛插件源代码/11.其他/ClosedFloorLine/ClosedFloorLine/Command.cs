using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.Exceptions;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OperationCanceledException = Autodesk.Revit.Exceptions.OperationCanceledException;

namespace ClosedFloorLine
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;

            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();
            if (mainWindow.DialogResult == false)
            {
                return Result.Cancelled;
            }
            double extensionLength = Properties.Settings.Default.ExtensionLength / 304.8;

            Next:
            IList<Reference> refers;
            try
            {
                refers = sel.PickObjects(ObjectType.Element, new ModelLineFilter(), "框选要闭合的模型线（按ESC结束布置）");
                if (refers.Count < 3)
                {
                    TaskDialog.Show("BIMTRANS", "选择的模型线至少为3才能创建楼板");
                    return Result.Succeeded;
                }
            }
            catch (OperationCanceledException)
            {
                TaskDialog.Show("BIMTRANS", "结束布置");
                return Result.Succeeded;
            }
            CurveArray curveArray = new CurveArray();

            List<ElementId> delIds = refers.Select(r => r.ElementId).ToList();
            List<ModelLine> modelLines = refers.Select(r => doc.GetElement(r) as ModelLine).ToList();
            List<Line> lines = modelLines.Select(ml => GetLine(ml)).ToList();
            lines = ExtensionLines(lines, extensionLength);

            Line firstLine = lines.First();
            Line nextLine;
            nextLine = lines.FirstOrDefault(l => l != firstLine && l.Intersect(firstLine) == SetComparisonResult.Overlap);
            if (nextLine == null)
            {
                TaskDialog.Show("BIMTRANS", "未找到闭合轮廓线");
                goto Next;
                //return Result.Succeeded;
            }

            IntersectionResultArray result = null;
            var isOverlap = nextLine?.Intersect(firstLine, out result);
            XYZ point = null;
            if (isOverlap != null && isOverlap == SetComparisonResult.Overlap)
            {
                point = result.get_Item(0).XYZPoint;
            }

            while (lines.Count > 0)
            {
                Line findLine = lines.FirstOrDefault(l =>
                {
                    if (l != nextLine && nextLine.Intersect(l, out var resArr) == SetComparisonResult.Overlap)
                    {
                        if (resArr.get_Item(0).XYZPoint.DistanceTo(point) > 0.0001) return true;
                    }
                    return false;
                });
                if (findLine == null)
                {
                    break;
                }
                if (findLine.Intersect(nextLine, out var resultArray) == SetComparisonResult.Overlap)
                {
                    XYZ newPoint = resultArray.get_Item(0).XYZPoint;
                    try
                    {
                        curveArray.Append(Line.CreateBound(point, newPoint));
                    }
                    catch (Exception)
                    {
                        break;
                    }
                    
                    point = newPoint;
                    nextLine = findLine;
                    if (!lines.Remove(findLine))
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }

            }

            using (Transaction t = new Transaction(doc, "闭合楼板模型线并创建楼板"))
            {
                t.Start();

                try
                {
                    doc.Create.NewFloor(curveArray, false);
                    doc.Delete(delIds);
                    t.Commit();
                }
                catch (Exception e)
                {
                    if (t.HasStarted()) t.RollBack();
                    TaskDialog.Show("Error", "创建楼板失败：" + e.Message);
                }
            }
            goto Next;

            return Result.Succeeded;

        //var refer = sel.PickObject(ObjectType.Element);
        //Element element = doc.GetElement(refer);
        //var box = element.get_BoundingBox(doc.ActiveView);
        //TaskDialog.Show("re", ((box.Max.Z - box.Min.Z) * 304.8).ToString() + "\n" + box.Max.Add(box.Min) / 2 + "\n" + (element.Location as LocationPoint).Point);

        //return Result.Succeeded;

        #region 旧版本
        //Next:
        //    List<Reference> refers;
        //    try
        //    {
        //        refers = sel.PickObjects(ObjectType.Element, new ModelLineFilter(), "框选要闭合的模型线").ToList();
        //    }
        //    catch (OperationCanceledException)
        //    {
        //        TaskDialog.Show("BIMTRANS", "结束布置");
        //        return Result.Succeeded;
        //    }
            
        //    if (refers.Count < 3) return Result.Cancelled;

        //    CurveArray curveArray = new CurveArray();

        //    List<ModelLine> modelLines = refers.Select(r => doc.GetElement(r)).Cast<ModelLine>().ToList();
        //    List<ElementId> delIds = modelLines.Select(m => m.Id).ToList();
        //    ModelLine startLine = modelLines.First();
        //    //XYZ firstP = GetEndPoint(startLine, 0);
        //    XYZ startP = GetEndPoint(startLine, 1);
        //    curveArray.Append((startLine.Location as LocationCurve).Curve);
        //    modelLines.Remove(startLine);

        //    while (modelLines.Count > 0)
        //    {
        //        XYZ minP = null;
        //        XYZ otherP = null;
        //        ModelLine next = modelLines.OrderBy(m => GetClosestDis(startP, GetEndPoint(m, 0), GetEndPoint(m, 1), out minP, out otherP))
        //            .FirstOrDefault(m => /*m.Id != startLine.Id &&*/ GetClosestDis(startP, GetEndPoint(m, 0), GetEndPoint(m, 1), out minP, out otherP) < 5 / 304.8);

        //        if (next == null)
        //        {
        //            //TaskDialog.Show("revit", curveArray.Size.ToString());
        //            break;
        //        }

        //        curveArray.Append(Line.CreateBound(startP, otherP));
        //        startP = otherP;
        //        startLine = next;
        //        if (!modelLines.Remove(next)) break;

        //    }

        //    if (modelLines.Count != 0)
        //    {
        //        TaskDialog.Show("BIMTRANS", "创建楼板失败");
        //        goto Next;
        //    }

        //    using (Transaction t = new Transaction(doc, "闭合楼板模型线并创建楼板"))
        //    {
        //        t.Start();

        //        try
        //        {
        //            doc.Create.NewFloor(curveArray, false);
        //            doc.Delete(delIds);
        //            t.Commit();
        //        }
        //        catch (Exception e)
        //        {
        //            if(t.HasStarted()) t.RollBack();
        //            TaskDialog.Show("Error", "创建楼板失败：" + e.Message);
        //        }
               
        //    }
        //    goto Next;

        //    return Result.Succeeded;
            #endregion
        }
        private List<Line> ExtensionLines(List<Line> lines, double length)
        {
            List<Line> results = new List<Line>();
            foreach (var line in lines)
            {
                Line newLine = ExtensionLine(line, length);
                results.Add(newLine);
            }
            return results;
        }
        private Line ExtensionLine(Line line, double length)
        {
            XYZ p0 = line.GetEndPoint(0);
            XYZ p1 = line.GetEndPoint(1);
            XYZ dir = line.Direction;
            Line newLine = Line.CreateBound(p0 - dir * length, p1 + dir * length);

            return newLine;
        }
        private Line GetLine(ModelLine modelLine)
        {
            Line line = (modelLine.Location as LocationCurve).Curve as Line;
            return line;
        }

        // ------------------
        private XYZ GetEndPoint(ModelLine line, int i)
        {
            return (line.Location as LocationCurve).Curve.GetEndPoint(i);
        }
        private List<XYZ> GetPoints(ModelLine modelLine)
        {
            List<XYZ> result = new List<XYZ>();

            Curve curve = (modelLine.Location as LocationCurve).Curve;
            result = curve.Tessellate().ToList();

            return result;
        }
        private double GetClosestDis(XYZ compareP, XYZ p1, XYZ p2, out XYZ minP, out XYZ otherP)
        {
            double min;
            if (compareP.DistanceTo(p1) < compareP.DistanceTo(p2))
            {
                min = compareP.DistanceTo(p1);
                minP = p1;
                otherP = p2;
            }
            else
            {
                min = compareP.DistanceTo(p2);
                minP = p2;
                otherP = p1;
            }

            return min;
        }
        private double GetClosestDis(List<XYZ> ps1, List<XYZ> ps2, out XYZ minP1, out XYZ minP2)
        {
            double min = double.MaxValue;
            minP1 = null;
            minP2 = null;

            for (int i = 0; i < ps1.Count; i++)
            {
                XYZ p1 = ps1[i];
                for (int j = 0; j < ps2.Count; j++)
                {
                    XYZ p2 = ps2[j];
                    if (p1.DistanceTo(p2) < min)
                    {
                        min = p1.DistanceTo(p2);
                        minP1 = p1;
                        minP2 = p2;
                    }
                }
            }



            return min;
        }
    }
    public class ModelLineFilter : ISelectionFilter
    {
        public bool AllowElement(Element elem)
        {
            if (elem is ModelLine) return true;
            return false;
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            return false;
        }
    }
}
