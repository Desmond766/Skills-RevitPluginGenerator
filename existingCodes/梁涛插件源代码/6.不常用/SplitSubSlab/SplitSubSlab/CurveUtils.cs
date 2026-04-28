using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitSubSlab
{
    internal class CurveUtils
    {
        public enum FailureCondition
        {
            Success,
            CurvesNotContigous,
            CurveLoopAboveTarget,
            NoIntersection
        }
        private const double _inch = 0.083333333333333329;
        private const double _sixteenth = 0.005208333333333333;
        public static bool IsSupported(Curve curve)
        {
            return curve is Line || curve is Arc;
        }
        private static Curve CreateReversedCurve(Application creapp, Curve orig)
        {
            bool flag = !CurveUtils.IsSupported(orig);
            if (flag)
            {
                throw new NotImplementedException("CreateReversedCurve for type " + orig.GetType().Name);
            }
            bool flag2 = orig is Line;
            Curve result;
            if (flag2)
            {
                result = Line.CreateBound(orig.GetEndPoint(1), orig.GetEndPoint(0));
            }
            else
            {
                bool flag3 = orig is Arc;
                if (!flag3)
                {
                    throw new Exception("CreateReversedCurve - Unreachable");
                }
                result = Arc.Create(orig.GetEndPoint(1), orig.GetEndPoint(0), orig.Evaluate(0.5, true));
            }
            return result;
        }
        public static void SortCurvesContiguous(Application creapp, IList<Curve> curves, bool debug_output)
        {
            int count = curves.Count;
            for (int i = 0; i < count; i++)
            {
                Curve curve = curves[i];
                XYZ endPoint = curve.GetEndPoint(1);
                if (debug_output)
                {
                }
                bool flag = i + 1 >= count;
                for (int j = i + 1; j < count; j++)
                {
                    XYZ endPoint2 = curves[j].GetEndPoint(0);
                    bool flag2 = 0.005208333333333333 > endPoint2.DistanceTo(endPoint);
                    if (flag2)
                    {
                        bool flag3 = i + 1 == j;
                        if (flag3)
                        {
                            if (debug_output)
                            {
                                Debug.Print("{0} start point match, no need to swap", new object[]
                                {
                                    j,
                                    i + 1
                                });
                            }
                        }
                        else
                        {
                            if (debug_output)
                            {
                                Debug.Print("{0} start point, swap with {1}", new object[]
                                {
                                    j,
                                    i + 1
                                });
                            }
                            Curve value = curves[i + 1];
                            curves[i + 1] = curves[j];
                            curves[j] = value;
                        }
                        flag = true;
                        break;
                    }
                    endPoint2 = curves[j].GetEndPoint(1);
                    bool flag4 = 0.005208333333333333 > endPoint2.DistanceTo(endPoint);
                    if (flag4)
                    {
                        bool flag5 = i + 1 == j;
                        if (flag5)
                        {
                            if (debug_output)
                            {
                                Debug.Print("{0} end point, reverse {1}", new object[]
                                {
                                    j,
                                    i + 1
                                });
                            }
                            curves[i + 1] = CurveUtils.CreateReversedCurve(creapp, curves[j]);
                        }
                        else
                        {
                            if (debug_output)
                            {
                                Debug.Print("{0} end point, swap with reverse {1}", new object[]
                                {
                                    j,
                                    i + 1
                                });
                            }
                            Curve value2 = curves[i + 1];
                            curves[i + 1] = CurveUtils.CreateReversedCurve(creapp, curves[j]);
                            curves[j] = value2;
                        }
                        flag = true;
                        break;
                    }
                }
                bool flag6 = !flag;
                if (flag6)
                {
                    throw new Exception("SortCurvesContiguous: non-contiguous input curves");
                }
            }
        }
        public static IList<Curve> GetContiguousCurvesFromSelectedCurveElements(Document doc, IList<Reference> boundaries, bool debug_output)
        {
            List<Curve> list = new List<Curve>();
            foreach (Reference current in boundaries)
            {
                CurveElement curveElement = doc.GetElement(current) as CurveElement;
                list.Add(curveElement.GeometryCurve.Clone());
            }
            CurveUtils.SortCurvesContiguous(doc.Application, list, debug_output);
            return list;
        }
        public static bool IsCurveInXYPlane(Curve curve)
        {
            double value = curve.GetEndPoint(1).Z - curve.GetEndPoint(0).Z;
            bool flag = Math.Abs(value) > 1E-05;
            bool result;
            if (flag)
            {
                result = false;
            }
            else
            {
                bool flag2 = !(curve is Line) && !curve.IsCyclic;
                if (flag2)
                {
                    CurveLoop curveLoop = CurveLoop.Create(new List<Curve>
                    {
                        curve
                    });
                    XYZ xYZ = curveLoop.GetPlane().Normal.Normalize();
                    bool flag3 = !xYZ.IsAlmostEqualTo(XYZ.BasisZ) && !xYZ.IsAlmostEqualTo(XYZ.BasisZ.Negate());
                    if (flag3)
                    {
                        result = false;
                        return result;
                    }
                }
                result = true;
            }
            return result;
        }
    }
}
