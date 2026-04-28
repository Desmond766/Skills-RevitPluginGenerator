using System;
using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI;

namespace PipeLengthSpacingSorter
{
    /// <summary>
    /// Sorts selected pipes by centerline length (shortest first) and lays out their
    /// midpoints along a line perpendicular to the shortest pipe's axis, 10 cm apart.
    /// </summary>
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class Command : IExternalCommand
    {
        private const double SpacingM = 0.10;

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;

            ICollection<ElementId> ids = uidoc.Selection.GetElementIds();
            if (ids == null || ids.Count == 0)
            {
                message = "请先选择至少一根管道。";
                return Result.Failed;
            }

            var pipes = new List<Pipe>();
            foreach (ElementId id in ids)
            {
                if (doc.GetElement(id) is Pipe p)
                    pipes.Add(p);
            }

            if (pipes.Count == 0)
            {
                message = "当前选择中没有管道（Pipe）。请只选择水管/风管等管道图元。";
                return Result.Failed;
            }

            double spacingFt = UnitUtils.ConvertToInternalUnits(SpacingM, UnitTypeId.Meters);

            var items = new List<(Pipe pipe, double length, Curve curve, XYZ mid)>();
            foreach (Pipe pipe in pipes)
            {
                if (pipe.Location is not LocationCurve lc)
                    continue;
                Curve c = lc.Curve;
                if (c == null || c.Length < 1e-9)
                    continue;
                XYZ mid = c.Evaluate(0.5, true);
                items.Add((pipe, c.Length, c, mid));
            }

            if (items.Count == 0)
            {
                message = "所选管道没有可用的定位曲线。";
                return Result.Failed;
            }

            items.Sort((a, b) => a.length.CompareTo(b.length));

            XYZ dir = GetCurveDirection(items[0].curve);
            XYZ perp = GetStablePerpendicular(dir);
            XYZ anchor = items[0].mid;

            try
            {
                using (var tx = new Transaction(doc, "按长度排序管道间距"))
                {
                    tx.Start();
                    for (int i = 0; i < items.Count; i++)
                    {
                        XYZ targetMid = anchor + i * spacingFt * perp;
                        XYZ delta = targetMid - items[i].mid;
                        if (delta.GetLength() > 1e-9)
                            ElementTransformUtils.MoveElement(doc, items[i].pipe.Id, delta);
                    }
                    tx.Commit();
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return Result.Failed;
            }

            var dlg = new TaskDialog("管道已排列")
            {
                MainInstruction = $"已按长度从短到长排列 {items.Count} 根管道，侧向间距 {SpacingM * 100:0} cm。",
                MainContent =
                    "排列方向：垂直于最短那根管道的轴线（在水平面内取侧向）。\n" +
                    "若管道方向很陡或几乎竖直，侧向向量会自动改用稳定基向量。"
            };
            dlg.Show();

            return Result.Succeeded;
        }

        private static XYZ GetCurveDirection(Curve c)
        {
            if (c is Line line)
            {
                XYZ d = line.GetEndPoint(1) - line.GetEndPoint(0);
                if (d.GetLength() < 1e-9)
                    return XYZ.BasisX;
                return d.Normalize();
            }

            Transform tr = c.ComputeDerivatives(0.5, true);
            XYZ t = tr.BasisX;
            if (t.GetLength() < 1e-9)
                return XYZ.BasisX;
            return t.Normalize();
        }

        /// <summary>
        /// Perpendicular to pipe axis, preferring horizontal separation (XY) for typical runs.
        /// </summary>
        private static XYZ GetStablePerpendicular(XYZ dir)
        {
            XYZ z = XYZ.BasisZ;
            XYZ cross = dir.CrossProduct(z);
            if (cross.GetLength() < 1e-6)
                cross = dir.CrossProduct(XYZ.BasisX);
            if (cross.GetLength() < 1e-6)
                cross = dir.CrossProduct(XYZ.BasisY);
            return cross.Normalize();
        }
    }
}
