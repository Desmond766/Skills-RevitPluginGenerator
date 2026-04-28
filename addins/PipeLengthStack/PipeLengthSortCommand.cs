using System;
using System.Collections.Generic;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI;

namespace RevitAddins.PipeLengthStack
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class PipeLengthSortCommand : IExternalCommand
    {
        private const double SpacingMeters = 0.1;

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiApp = commandData.Application;
            UIDocument uiDoc = uiApp.ActiveUIDocument;
            Document doc = uiDoc.Document;
            var sel = uiDoc.Selection.GetElementIds();
            if (sel == null || sel.Count == 0)
            {
                message = "请先选择至少一根管道。";
                return Result.Failed;
            }

            double spacing = UnitUtils.ConvertToInternalUnits(SpacingMeters, UnitTypeId.Meters);
            var items = new List<PipeInfo>();

            foreach (ElementId id in sel)
            {
                var e = doc.GetElement(id);
                if (e == null) continue;
                if (e.Category == null || e.Category.BuiltInCategory != BuiltInCategory.OST_PipeCurves) continue;
                if (!(e is MEPCurve mep)) continue;
                if (!(mep is Pipe || mep is FlexPipe)) continue;

                if (!TryGetLengthMidTangent(mep, out double len, out XYZ mid, out XYZ tangent, out string err))
                {
                    message = err;
                    return Result.Failed;
                }

                items.Add(new PipeInfo(mep, len, mid, tangent));
            }

            if (items.Count == 0)
            {
                message = "当前选择中没有有效的管段（需为「管道」类别，含 Pipe / FlexPipe）。";
                return Result.Failed;
            }

            items.Sort((a, b) =>
            {
                int c = a.Length.CompareTo(b.Length);
                if (c != 0) return c;
                return a.Curve.Id.Value.CompareTo(b.Curve.Id.Value);
            });

            // 以「最短管」的中点与走向为参考：在水平面内作侧向 10cm 阶梯，使多根管聚拢并排（平面可见）。
            XYZ refPoint = items[0].Mid;
            XYZ runDir = items[0].Tangent.GetLength() < 1e-9 ? XYZ.BasisX : items[0].Tangent.Normalize();
            XYZ stackDir = LateralInModelHorizontal(runDir);
            if (stackDir == null || stackDir.GetLength() < 1e-8)
                stackDir = XYZ.BasisY;
            else
                stackDir = stackDir.Normalize();

            int index = 0;
            var translations = new List<(MEPCurve curve, XYZ delta)>(items.Count);
            foreach (var it in items)
            {
                XYZ targetMid = refPoint + index * spacing * stackDir;
                XYZ delta = targetMid - it.Mid;
                if (delta.GetLength() > 1.0E-5)
                    translations.Add((it.Curve, delta));
                index++;
            }

            try
            {
                using (var tx = new Transaction(doc, "水管按长度并排挤布(10cm)"))
                {
                    tx.Start();
                    foreach (var t in translations)
                        ElementTransformUtils.MoveElement(doc, t.curve.Id, t.delta);
                    tx.Commit();
                }

                if (items.Count == 1)
                {
                    TaskDialog.Show("水管按长度并排挤布", "仅选了一根管道，已记录长度，无需平移。");
                }
                else if (translations.Count == 0)
                {
                    TaskDialog.Show("水管按长度并排挤布",
                        "按长度从短到长，各管中点本已在 10cm 阶梯位置上，未再平移。若需强制重排，请先略微分开管道再试。");
                }

                return Result.Succeeded;
            }
            catch (Autodesk.Revit.Exceptions.OperationCanceledException)
            {
                return Result.Cancelled;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return Result.Failed;
            }
        }

        /// <summary>在模型 XY 内取与走向垂直的平移方向（立管时退化为 X）。</summary>
        private static XYZ LateralInModelHorizontal(XYZ runDir)
        {
            var d = runDir.Normalize();
            if (d.IsAlmostEqualTo(XYZ.Zero))
                return null;

            // 走向接近竖直时，侧向用 X
            if (Math.Abs(d.DotProduct(XYZ.BasisZ)) > 0.99)
                return XYZ.BasisX;

            // 水平 / 斜向管：d × (0,0,1) 落在水平面内、且垂直于 d
            var n = d.CrossProduct(XYZ.BasisZ);
            if (n.GetLength() < 1e-8)
                return null;
            return n.Normalize();
        }

        private sealed class PipeInfo
        {
            public readonly MEPCurve Curve;
            public readonly double Length;
            public readonly XYZ Mid;
            public readonly XYZ Tangent;

            public PipeInfo(MEPCurve curve, double length, XYZ mid, XYZ tangent)
            {
                Curve = curve;
                Length = length;
                Mid = mid;
                Tangent = tangent;
            }
        }

        private static bool TryGetLengthMidTangent(
            MEPCurve mep, out double length, out XYZ mid, out XYZ tangent, out string err)
        {
            length = 0;
            mid = XYZ.Zero;
            tangent = XYZ.BasisX;
            err = null;

            if (mep.Location is LocationCurve lc)
            {
                var c = lc.Curve;
                if (c == null) { err = "无法读取管段的几何。"; return false; }
                length = c.Length;
                mid = c.Evaluate(0.5, true);
                tangent = TangentAtMid(c);
                return true;
            }

            if (mep.Location is LocationPoint lp)
            {
                length = GetCurveLengthParam(mep);
                if (length <= 1e-9) length = 1e-6;
                mid = lp.Point;
                tangent = XYZ.BasisZ;
                return true;
            }

            err = "管段无 LocationCurve，无法取定位。";
            return false;
        }

        private static XYZ TangentAtMid(Curve c)
        {
            if (c is Line line)
            {
                var t = line.GetEndPoint(1) - line.GetEndPoint(0);
                return t.GetLength() < 1e-9 ? XYZ.BasisX : t.Normalize();
            }

            // 弧线/样条等：在参量中点用导数
            var tr = c.ComputeDerivatives(0.5, true);
            var tan = tr.BasisX;
            return tan.GetLength() < 1e-9 ? XYZ.BasisX : tan.Normalize();
        }

        private static double GetCurveLengthParam(MEPCurve mep)
        {
            var p = mep.get_Parameter(BuiltInParameter.CURVE_ELEM_LENGTH);
            if (p != null && p.StorageType == StorageType.Double)
                return p.AsDouble();
            return 0;
        }
    }
}
