using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.Exceptions;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interop;
using OperationCanceledException = Autodesk.Revit.Exceptions.OperationCanceledException;

namespace InspectionWellElevationAdjustment
{
    // 检查井标高调整
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;
            IntPtr intPtr = commandData.Application.MainWindowHandle;

            //var testRefer = sel.PickObject(ObjectType.Element);
            //FamilyInstance familyInstance = doc.GetElement(testRefer) as FamilyInstance;

            //var boundingBox = familyInstance.get_BoundingBox(null);
            //LogicalAndFilter andFilter = CreateMixFilter(boundingBox.Min, boundingBox.Max, 200, out var solid);
            //using (FilteredElementCollector pipeCol = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_PipeCurves).WherePasses(andFilter))
            //{
            //    if (pipeCol.Count() > 0)
            //    {
            //        var pipes = pipeCol.ToList();
            //        double minZ = GetMinPoint(pipes).Z;
            //        using (Transaction t = new Transaction(doc, "检查井标高调整"))
            //        {
            //            t.Start();
            //            XYZ wellPoint = (familyInstance.Location as LocationPoint).Point;
            //            double depth = wellPoint.Z - minZ;
            //            depth = CeilingToHundreds(depth * 304.8) / 304.8;
            //            familyInstance.LookupParameter("深度").Set(depth);
            //            t.Commit();
            //        }
            //    }
                
            //}

            //return Result.Succeeded;

            //List<FamilyInstance> wells = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_GenericModel).OfClass(typeof(FamilyInstance))
            //    .Cast<FamilyInstance>().Where(f => f.Symbol.Name.Contains("井")).ToList();

            MainWindow mainWindow = new MainWindow(doc);
            WindowInteropHelper windowInteropHelper = new WindowInteropHelper(mainWindow);
            windowInteropHelper.Owner = intPtr;
            mainWindow.ShowDialog();
            if (mainWindow.DialogResult == false) return Result.Cancelled;

            List<FamilyInstance> wells = new List<FamilyInstance>();
            FilteredElementCollector wellCol;
            int wellScope = Properties.Settings.Default.WellScope;
            if (wellScope == 0)
            {
                RevitUtils.ListenUtils listenUtils = new RevitUtils.ListenUtils();
                try
                {
                    listenUtils.startListen();
                    var wellRefers = sel.PickObjects(ObjectType.Element, new WellFilter(), "框选检查井(ESC键取消 空格键确定)");
                    listenUtils.stopListen();
                    List<ElementId> wellIds = wellRefers.Select(wr => wr.ElementId).ToList();
                    if(wellIds.Count == 0)
                    {
                        message = "未选择任何检查井";
                        return Result.Failed;
                    }
                    wellCol = new FilteredElementCollector(doc, wellIds);
                }
                catch (OperationCanceledException)
                {
                    listenUtils.stopListen();
                    return Result.Cancelled;
                }
            }
            else if (wellScope == 1)
            {
                wellCol = new FilteredElementCollector(doc, doc.ActiveView.Id);
            }
            else
            {
                wellCol = new FilteredElementCollector(doc);
            }

            

            List<WellInfo> wellInfos = mainWindow.WellInfos.ToList();
            List<string> wellNames = wellInfos.Select(w => w.WellTypeName).ToList();

            wells = wellCol.OfCategory(BuiltInCategory.OST_GenericModel).OfClass(typeof(FamilyInstance))
                .Cast<FamilyInstance>().Where(f => f.Symbol.FamilyName.Contains("井") && wellNames.Contains(f.Symbol.FamilyName) && f.LookupParameter("深度") != null).ToList();

            int successCount = 0;
            using (Transaction t = new Transaction(doc, "检查井标高调整"))
            {
                t.Start();
                foreach (var well in wells)
                {
                    string wellFamilyName = well.Symbol.FamilyName;
                    if (!wellNames.Contains(wellFamilyName)) continue;
                    WellInfo wellInfo = wellInfos.First(w => w.WellTypeName == wellFamilyName);
                    string[] pipeTypeNames = wellInfo.PipeTypeNames.Split('\n');

                    var boundingBox = well.get_BoundingBox(null);
                    LogicalAndFilter andFilter = CreateMixFilter(boundingBox.Min, boundingBox.Max, 200, out var solid);
                    using (FilteredElementCollector pipeCol = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_PipeCurves).WherePasses(andFilter))
                    {
                        var pipes = pipeCol.Cast<Pipe>().Where(p => pipeTypeNames.Contains(p.PipeType.Name)).ToList();
                        if (pipes.Count() > 0)
                        {
                            double minZ = GetMinPoint(pipes).Z;

                            XYZ wellPoint = (well.Location as LocationPoint).Point;
                            double depth = wellPoint.Z - minZ;
                            depth = CeilingToHundreds(depth * 304.8) / 304.8;
                            well.LookupParameter("深度").Set(depth);
                        }
                    }
                }
                t.Commit();
            }

            TaskDialog.Show("BIMTRANS", "完成!");
            return Result.Succeeded;
        }
        private double CeilingToHundreds(double number)
        {
            return Math.Ceiling(number / 100.0) * 100.0;
        }
        private XYZ GetMinPoint(List<Pipe> elements)
        {
            double minValue = double.MaxValue;
            XYZ minPoint = new XYZ();
            foreach (var elem in elements)
            {
                var min = elem.get_BoundingBox(null).Min;
                if (min.Z < minValue)
                {
                    minValue = min.Z;
                    minPoint = min;
                }
            }

            return minPoint;
        }
        private LogicalAndFilter CreateMixFilter(XYZ min, XYZ max, double findHigh, out Solid solid)
        {
            var boxFilter = CreateBoundingBoxIntersectsFilter(min - XYZ.BasisZ * findHigh, max + XYZ.BasisZ * findHigh);
            var solidFilter = CreateSolidFilter(min, max, findHigh, out solid);

            return new LogicalAndFilter(boxFilter, solidFilter);
        }
        private BoundingBoxIntersectsFilter CreateBoundingBoxIntersectsFilter(XYZ min, XYZ max)
        {
            return new BoundingBoxIntersectsFilter(new Outline(min, max));
        }
        private ElementIntersectsSolidFilter CreateSolidFilter(XYZ min, XYZ max, double findHigh, out Solid solid)
        {
            XYZ p1 = new XYZ(min.X, min.Y, min.Z - findHigh);
            XYZ p2 = new XYZ(min.X, max.Y, min.Z - findHigh);
            XYZ p3 = new XYZ(max.X, max.Y, min.Z - findHigh);
            XYZ p4 = new XYZ(max.X, min.Y, min.Z - findHigh);
            //放样
            List<CurveLoop> loops = new List<CurveLoop>();
            List<Curve> curveList = new List<Curve> { Line.CreateBound(p1, p2), Line.CreateBound(p2, p3), Line.CreateBound(p3, p4), Line.CreateBound(p4, p1) };
            CurveLoop curveLoop = CurveLoop.Create(curveList);
            loops.Add(curveLoop);
            solid = GeometryCreationUtilities.CreateExtrusionGeometry(loops, XYZ.BasisZ, findHigh * 2);
            ElementIntersectsSolidFilter filter = new ElementIntersectsSolidFilter(solid);
            return filter;
        }
    }
    public class WellFilter : ISelectionFilter
    {
        public bool AllowElement(Element elem)
        {
            if (elem is FamilyInstance familyInstance && familyInstance.Symbol.FamilyName.Contains("井") && familyInstance.LookupParameter("深度") != null)
            {
                return true;
            }
            return false;
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            return false;
        }
    }
}
