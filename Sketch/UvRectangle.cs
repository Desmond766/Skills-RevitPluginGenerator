using System;
using Autodesk.Revit.DB;

namespace RevitAddins.Sketch
{
    /// <summary>
    /// 当前视图平面内的 UV 轴对齐矩形（U = RightDirection，V = UpDirection）。
    /// </summary>
    internal readonly struct UvRect
    {
        public readonly double U0;
        public readonly double U1;
        public readonly double V0;
        public readonly double V1;

        public UvRect(double uA, double vA, double uB, double vB)
        {
            U0 = Math.Min(uA, uB);
            U1 = Math.Max(uA, uB);
            V0 = Math.Min(vA, vB);
            V1 = Math.Max(vA, vB);
        }

        public bool Contains(double u, double v, double tol)
        {
            return u >= U0 - tol && u <= U1 + tol && v >= V0 - tol && v <= V1 + tol;
        }

        /// <summary>线段与矩形相交，或任一端点在矩形内（含边界）。</summary>
        public bool TouchesSegment(double ua, double va, double ub, double vb, double tol)
        {
            if (Contains(ua, va, tol) || Contains(ub, vb, tol))
                return true;

            return SegmentIntersectsAxisAlignedRect(ua, va, ub, vb, U0, U1, V0, V1, tol);
        }

        private static bool SegmentIntersectsAxisAlignedRect(
            double x1, double y1, double x2, double y2,
            double rx0, double rx1, double ry0, double ry1,
            double tol)
        {
            double dx = x2 - x1;
            double dy = y2 - y1;

            if (Math.Abs(dx) < 1e-12 && Math.Abs(dy) < 1e-12)
                return false;

            double tEnter = 0.0;
            double tExit = 1.0;

            if (!ClipParam(-dx, x1 - rx0 - tol, ref tEnter, ref tExit)) return false;
            if (!ClipParam(dx, rx1 + tol - x1, ref tEnter, ref tExit)) return false;
            if (!ClipParam(-dy, y1 - ry0 - tol, ref tEnter, ref tExit)) return false;
            if (!ClipParam(dy, ry1 + tol - y1, ref tEnter, ref tExit)) return false;

            return tExit >= tEnter;
        }

        private static bool ClipParam(double p, double q, ref double tEnter, ref double tExit)
        {
            if (Math.Abs(p) < 1e-12)
                return q <= 0;

            double r = q / p;
            if (p < 0)
            {
                if (r > tExit) return false;
                if (r > tEnter) tEnter = r;
            }
            else
            {
                if (r < tEnter) return false;
                if (r < tExit) tExit = r;
            }

            return tEnter <= tExit;
        }
    }

    internal static class ViewUv
    {
        public static void Project(View view, XYZ p, out double u, out double v)
        {
            XYZ o = view.Origin;
            XYZ d = p - o;
            u = d.DotProduct(view.RightDirection);
            v = d.DotProduct(view.UpDirection);
        }

        public static XYZ Corner(View view, double u, double v)
        {
            return view.Origin + u * view.RightDirection + v * view.UpDirection;
        }
    }
}
