using System;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;

namespace RevitAddins.DuctOrthoElbowConnect
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class Command : IExternalCommand
    {
        /// <summary>判断“沿 X / 沿 Y”时，主方向分量至少达到多少（略允许坡度或略有偏角）。</summary>
        private const double MinPrimaryAxisComponent = 0.45;

        /// <summary>两中心线最近点允许的最大间距（英尺），约 6 mm。</summary>
        private const double MaxJunctionGapFt = 0.02;

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;

            try
            {
                Duct ductA = PickDuct(uidoc, "请点击一根大致沿全局 X 方向的风管（俯视下多为东西向）。");
                Duct ductB = PickDuct(uidoc, "请点击一根大致沿全局 Y 方向的风管（俯视下多为南北向）。");

                if (!ClassifyXY(ductA, ductB, out Duct xDuct, out Duct yDuct, out string orientMsg))
                {
                    message = orientMsg;
                    return Result.Failed;
                }

                if (!TryGetLineGeometry(xDuct, out Line xLine, out string hErr))
                {
                    message = hErr;
                    return Result.Failed;
                }

                if (!TryGetLineGeometry(yDuct, out Line yLine, out string vErr))
                {
                    message = vErr;
                    return Result.Failed;
                }

                ClosestPointsOnLines(xLine, yLine, out XYZ pOnX, out XYZ pOnY);
                double gap = pOnX.DistanceTo(pOnY);
                if (gap > MaxJunctionGapFt)
                {
                    message =
                        "两段风管的中心线在空间上不相交或偏差过大（>约 6 mm）。\n" +
                        "请在平面内使 X 向管与 Y 向管位于正交交汇位置后再试。";
                    return Result.Failed;
                }

                XYZ junction = pOnX.Add(pOnY).Multiply(0.5);
                double tol = doc.Application.VertexTolerance * 4.0;
                double minRun = Math.Max(doc.Application.ShortCurveTolerance * 4.0, 1.0 / 304.8 * 8.0);

                using (var tx = new Transaction(doc, "风管 X 向与 Y 向弯头连接"))
                {
                    tx.Start();
                    try
                    {
                        TrimOrExtendDuctToJunction(xDuct, junction, tol, minRun);
                        TrimOrExtendDuctToJunction(yDuct, junction, tol, minRun);

                        doc.Regenerate();

                        Connector cX = GetUnusedEndConnectorNear(xDuct, junction);
                        Connector cY = GetUnusedEndConnectorNear(yDuct, junction);

                        if (cX == null || cY == null)
                        {
                            message = "无法在交点处找到可用的风管端部连接件（请确认管段未被其他管件占满端头）。";
                            tx.RollBack();
                            return Result.Failed;
                        }

                        doc.Create.NewElbowFitting(cX, cY);
                        tx.Commit();
                    }
                    catch (Exception ex)
                    {
                        if (tx.GetStatus() == TransactionStatus.Started)
                            tx.RollBack();
                        message =
                            "操作未完成。若已修改风管长度，事务已回滚。\n" +
                            "创建弯头失败时，请检查系统类型、管件路由设置及是否加载异径弯头族。\n" +
                            ex.Message;
                        return Result.Failed;
                    }
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

        private static Duct PickDuct(UIDocument uidoc, string prompt)
        {
            Reference r = uidoc.Selection.PickObject(ObjectType.Element, new DuctSelectionFilter(), prompt);
            return (Duct)uidoc.Document.GetElement(r);
        }

        /// <summary>
        /// 按全局坐标系：一根风管轴线应主要平行于 X（|X| 为 |X|、|Y|、|Z| 中最大），另一根主要平行于 Y。
        /// 与“世界 Z 立管”无关；立管若沿 Z 走向会被判为既非 X 主导也非 Y 主导而失败。
        /// </summary>
        private static bool ClassifyXY(Duct a, Duct b, out Duct xDuct, out Duct yDuct, out string message)
        {
            message = null;
            xDuct = yDuct = null;

            bool aX = IsMainlyAlongX(GetTangent(a));
            bool aY = IsMainlyAlongY(GetTangent(a));
            bool bX = IsMainlyAlongX(GetTangent(b));
            bool bY = IsMainlyAlongY(GetTangent(b));

            if (aX && bY)
            {
                xDuct = a;
                yDuct = b;
                return true;
            }

            if (bX && aY)
            {
                xDuct = b;
                yDuct = a;
                return true;
            }

            message =
                "无法识别“沿全局 X + 沿全局 Y”的风管组合。\n" +
                "本命令中：水平走向 = 风管轴线以 X 方向为主；竖向 = 以 Y 方向为主（均相对项目全局坐标，与视图旋转无关）。\n" +
                "请避免选择与 X、Y 均成约 45° 的斜管，或沿 Z 的立管；若模型相对全局轴转了角度，请先旋转风管或改用与全局 X/Y 对齐的管段。";
            return false;
        }

        /// <summary>单位切向量下，|dx| 严格大于 |dy| 且为 |X|、|Y|、|Z| 中最大，且 |dx| 达到下限。</summary>
        private static bool IsMainlyAlongX(XYZ d)
        {
            double ax = Math.Abs(d.X);
            double ay = Math.Abs(d.Y);
            double az = Math.Abs(d.Z);
            return ax > ay && ax >= az && ax >= MinPrimaryAxisComponent;
        }

        private static bool IsMainlyAlongY(XYZ d)
        {
            double ax = Math.Abs(d.X);
            double ay = Math.Abs(d.Y);
            double az = Math.Abs(d.Z);
            return ay > ax && ay >= az && ay >= MinPrimaryAxisComponent;
        }

        private static XYZ GetTangent(Duct duct)
        {
            if (duct.Location is not LocationCurve lc || lc.Curve is not Line line)
                return XYZ.BasisZ;
            XYZ d = line.GetEndPoint(1) - line.GetEndPoint(0);
            if (d.GetLength() < 1e-9)
                return XYZ.BasisZ;
            return d.Normalize();
        }

        private static bool TryGetLineGeometry(Duct duct, out Line line, out string error)
        {
            line = null;
            error = null;
            if (duct.Location is not LocationCurve lc || lc.Curve is not Line ln)
            {
                error = "仅支持直线段风管（不支持柔性风管或非直线定位）。";
                return false;
            }

            line = ln;
            return true;
        }

        /// <summary>
        /// 两条三维直线（无限延长）上的最近点对；方向取线段单位方向。
        /// </summary>
        private static void ClosestPointsOnLines(Line line1, Line line2, out XYZ pointOn1, out XYZ pointOn2)
        {
            XYZ p1 = line1.GetEndPoint(0);
            XYZ p2 = line2.GetEndPoint(0);
            XYZ u = (line1.GetEndPoint(1) - p1).Normalize();
            XYZ v = (line2.GetEndPoint(1) - p2).Normalize();
            XYZ w0 = p1 - p2;

            double a = u.DotProduct(u);
            double b = u.DotProduct(v);
            double c = v.DotProduct(v);
            double d = u.DotProduct(w0);
            double e = v.DotProduct(w0);
            double denom = a * c - b * b;

            double sc;
            double tc;
            if (Math.Abs(denom) < 1e-12)
            {
                sc = 0.0;
                tc = c > 1e-12 ? e / c : 0.0;
            }
            else
            {
                sc = (b * e - c * d) / denom;
                tc = (a * e - b * d) / denom;
            }

            pointOn1 = p1 + sc * u;
            pointOn2 = p2 + tc * v;
        }

        /// <summary>
        /// 将风管中心线调整为从交点到原线段上离交点较远的端点（可延长或缩短）。
        /// </summary>
        private static void TrimOrExtendDuctToJunction(Duct duct, XYZ junction, double tol, double minRunLength)
        {
            if (duct.Location is not LocationCurve lc || lc.Curve is not Line line)
                throw new InvalidOperationException("风管无直线定位。");

            XYZ p0 = line.GetEndPoint(0);
            XYZ p1 = line.GetEndPoint(1);
            XYZ dir = (p1 - p0).Normalize();

            double tJ = (junction - p0).DotProduct(dir);
            XYZ projJ = p0 + tJ * dir;
            if (junction.DistanceTo(projJ) > tol)
                throw new InvalidOperationException("交点不在该风管中心线及其延长线上。");

            double t0 = 0.0;
            double t1 = (p1 - p0).DotProduct(dir);
            double farT = Math.Abs(t0 - tJ) >= Math.Abs(t1 - tJ) ? t0 : t1;
            XYZ keep = p0 + farT * dir;

            if (keep.DistanceTo(projJ) < minRunLength)
                throw new InvalidOperationException("风管在调整后长度过短。");

            lc.Curve = Line.CreateBound(projJ, keep);
        }

        /// <summary>在交点附近查找未连接的端部连接件（用于放置弯头）。</summary>
        private static Connector GetUnusedEndConnectorNear(Duct duct, XYZ junction)
        {
            const double maxDistFt = 0.25;
            Connector best = null;
            double bestD = double.MaxValue;
            foreach (Connector c in duct.ConnectorManager.Connectors)
            {
                if (c.ConnectorType != ConnectorType.End)
                    continue;
                if (c.IsConnected)
                    continue;
                double d = c.Origin.DistanceTo(junction);
                if (d < bestD)
                {
                    bestD = d;
                    best = c;
                }
            }

            if (best != null && bestD <= maxDistFt)
                return best;

            return null;
        }

        private sealed class DuctSelectionFilter : ISelectionFilter
        {
            public bool AllowElement(Element elem) => elem is Duct;

            public bool AllowReference(Reference reference, XYZ position) => false;
        }
    }
}
