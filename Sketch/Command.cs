using System;
using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;

namespace RevitAddins.Sketch
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class Command : IExternalCommand
    {
        private const double TolFt = 0.003; // ~1 mm

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            View view = uidoc.ActiveView;

            if (!IsViewSupported(view))
            {
                message = "请在平面、立面、剖面或详图视图中运行 Sketch（不支持三维视图）。";
                return Result.Failed;
            }

            var previewIds = new List<ElementId>();

            try
            {
                XYZ pDiag1 = uidoc.Selection.PickPoint(
                    ObjectSnapTypes.None,
                    "Sketch：请点击矩形框的第一个角点（例如屏幕上的右下角）。");
                XYZ pDiag2 = uidoc.Selection.PickPoint(
                    ObjectSnapTypes.None,
                    "Sketch：请点击矩形框的对角点（例如屏幕上的左上角）。");

                ViewUv.Project(view, pDiag1, out double u1, out double v1);
                ViewUv.Project(view, pDiag2, out double u2, out double v2);
                var rect = new UvRect(u1, v1, u2, v2);

                using (var txPreview = new Transaction(doc, "Sketch 预览矩形"))
                {
                    txPreview.Start();
                    CreateRectangleDetailLines(doc, view, rect, previewIds);
                    txPreview.Commit();
                }

                List<ElementId> targets = FindMepCurvesTouchingRect(doc, view, rect).ToList();
                uidoc.Selection.SetElementIds(targets);

                if (targets.Count == 0)
                {
                    message = "与虚线框相交或接触的水管、风管、桥架：未找到任何图元。";
                    DeletePreviewElements(doc, previewIds);
                    return Result.Failed;
                }

                XYZ ref1 = uidoc.Selection.PickPoint(
                    ObjectSnapTypes.None,
                    "Sketch：请点击移动的参考点 1（起点）。");
                XYZ ref2 = uidoc.Selection.PickPoint(
                    ObjectSnapTypes.None,
                    "Sketch：请点击移动的参考点 2（终点；管线端点将沿各自轴线按该位移拉伸）。");

                XYZ move = ref2 - ref1;
                if (move.GetLength() < doc.Application.ShortCurveTolerance)
                {
                    message = "两个参考点几乎重合，未做拉伸。";
                    DeletePreviewElements(doc, previewIds);
                    return Result.Cancelled;
                }

                using (var txStretch = new Transaction(doc, "Sketch 拉伸管线"))
                {
                    txStretch.Start();
                    try
                    {
                        int changed = ApplyStretch(doc, view, rect, targets, move);
                        DeletePreviewElements(doc, previewIds);
                        txStretch.Commit();
                        if (changed == 0)
                            message = "没有端点落在框内，未修改任何管线。";
                    }
                    catch
                    {
                        if (txStretch.GetStatus() == TransactionStatus.Started)
                            txStretch.RollBack();
                        DeletePreviewElements(doc, previewIds);
                        throw;
                    }
                }

                return Result.Succeeded;
            }
            catch (Autodesk.Revit.Exceptions.OperationCanceledException)
            {
                DeletePreviewElements(doc, previewIds);
                return Result.Cancelled;
            }
            catch (Exception ex)
            {
                DeletePreviewElements(doc, previewIds);
                message = ex.Message;
                return Result.Failed;
            }
        }

        private static bool IsViewSupported(View view)
        {
            if (view is View3D)
                return false;
            return view is ViewPlan || view is ViewSection || view is ViewDrafting;
        }

        private static void CreateRectangleDetailLines(Document doc, View view, UvRect rect, List<ElementId> outIds)
        {
            XYZ c00 = ViewUv.Corner(view, rect.U0, rect.V0);
            XYZ c10 = ViewUv.Corner(view, rect.U1, rect.V0);
            XYZ c11 = ViewUv.Corner(view, rect.U1, rect.V1);
            XYZ c01 = ViewUv.Corner(view, rect.U0, rect.V1);

            var loop = new[] { (c00, c10), (c10, c11), (c11, c01), (c01, c00) };
            foreach ((XYZ a, XYZ b) in loop)
            {
                Line ln = Line.CreateBound(a, b);
                DetailCurve dc = doc.Create.NewDetailCurve(view, ln);
                outIds.Add(dc.Id);
                TrySetDashedLineStyle(doc, dc);
            }
        }

        private static void TrySetDashedLineStyle(Document doc, DetailCurve dc)
        {
            GraphicsStyle pick = new FilteredElementCollector(doc)
                .OfClass(typeof(GraphicsStyle))
                .Cast<GraphicsStyle>()
                .FirstOrDefault(g =>
                    g.Name.IndexOf("Dash", StringComparison.OrdinalIgnoreCase) >= 0
                    || g.Name.IndexOf("虚线", StringComparison.OrdinalIgnoreCase) >= 0);

            if (pick == null)
                return;

            try
            {
                dc.LineStyle = pick;
            }
            catch
            {
                // 忽略：模板可能没有可写线型
            }
        }

        private static void DeletePreviewElements(Document doc, List<ElementId> previewIds)
        {
            if (previewIds == null || previewIds.Count == 0)
                return;

            try
            {
                using var tx = new Transaction(doc, "Sketch 清除预览");
                tx.Start();
                ICollection<ElementId> toDel = previewIds.Where(id => id != ElementId.InvalidElementId).ToList();
                if (toDel.Count > 0)
                    doc.Delete(toDel);
                tx.Commit();
            }
            catch
            {
                // 忽略清理失败
            }
            finally
            {
                previewIds.Clear();
            }
        }

        private static IEnumerable<ElementId> FindMepCurvesTouchingRect(Document doc, View view, UvRect rect)
        {
            var categories = new[]
            {
                BuiltInCategory.OST_PipeCurves,
                BuiltInCategory.OST_DuctCurves,
                BuiltInCategory.OST_CableTray
            };

            foreach (BuiltInCategory bic in categories)
            {
                foreach (Element e in new FilteredElementCollector(doc, view.Id).OfCategory(bic).WhereElementIsNotElementType())
                {
                    if (e is not MEPCurve mc)
                        continue;
                    if (mc.Location is not LocationCurve lc || lc.Curve is not Line line)
                        continue;

                    XYZ a = line.GetEndPoint(0);
                    XYZ b = line.GetEndPoint(1);
                    ViewUv.Project(view, a, out double ua, out double va);
                    ViewUv.Project(view, b, out double ub, out double vb);

                    if (rect.TouchesSegment(ua, va, ub, vb, TolFt))
                        yield return e.Id;
                }
            }
        }

        /// <summary>
        /// 框内端点沿管线切向移动 (move·dir)·dir；两端都在框内时整段平移，长度不变。
        /// </summary>
        private static int ApplyStretch(Document doc, View view, UvRect rect, List<ElementId> targets, XYZ move)
        {
            int changed = 0;

            foreach (ElementId id in targets)
            {
                if (doc.GetElement(id) is not MEPCurve mc)
                    continue;
                if (mc.Location is not LocationCurve lc || lc.Curve is not Line line)
                    continue;

                XYZ p0 = line.GetEndPoint(0);
                XYZ p1 = line.GetEndPoint(1);
                XYZ dir = (p1 - p0).Normalize();

                ViewUv.Project(view, p0, out double u0, out double v0);
                ViewUv.Project(view, p1, out double u1, out double v1);

                bool in0 = rect.Contains(u0, v0, TolFt);
                bool in1 = rect.Contains(u1, v1, TolFt);

                if (!in0 && !in1)
                    continue;

                double s = move.DotProduct(dir);
                XYZ q0 = p0;
                XYZ q1 = p1;

                if (in0)
                    q0 = p0 + s * dir;
                if (in1)
                    q1 = p1 + s * dir;

                if (q0.DistanceTo(q1) < doc.Application.ShortCurveTolerance * 4.0)
                    continue;

                lc.Curve = Line.CreateBound(q0, q1);
                changed++;
            }

            return changed;
        }
    }
}
