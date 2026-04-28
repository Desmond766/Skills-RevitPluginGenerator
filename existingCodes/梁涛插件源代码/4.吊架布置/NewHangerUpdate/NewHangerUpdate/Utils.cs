using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NewHangerUpdate
{
    public class Utils
    {
        public static bool GetOutermostMEPCurves(List<MEPCurve> mEPCurves, out MEPCurve min, out MEPCurve max, out double bottomElevation)
        {
            min = null;
            max = null;
            bottomElevation = double.NaN;
            double minBottom = double.MaxValue;
            if (mEPCurves.Count == 0) return false;

            XYZ lineDir = ((mEPCurves.First().Location as LocationCurve).Curve as Line).Direction;
            XYZ verDir = lineDir.CrossProduct(XYZ.BasisZ).Normalize();

            Dictionary<MEPCurve, double> mepProjections = new Dictionary<MEPCurve, double>();
            foreach (var mepCurve in mEPCurves)
            {
                // 获取最低底部高程
                var bottomPara = mepCurve.LookupParameter("底部高程");
                if (bottomPara != null && bottomPara.StorageType == StorageType.Double && bottomPara.AsDouble() < minBottom)
                {
                    minBottom = bottomPara.AsDouble();
                }

                // 获取管道的中心点（使用定位线的中点）
                LocationCurve locationCurve = mepCurve.Location as LocationCurve;
                if (locationCurve != null)
                {
                    Curve curve = locationCurve.Curve;
                    XYZ pipeCenterPoint = (curve.GetEndPoint(0) + curve.GetEndPoint(1)) / 2.0;

                    double projectionValue = pipeCenterPoint.DotProduct(verDir);

                    mepProjections.Add(mepCurve, projectionValue);
                }
            }

            bottomElevation = minBottom;

            double minProjection = double.MaxValue;
            double maxProjection = double.MinValue;

            foreach (var kvp in mepProjections)
            {
                if (kvp.Value < minProjection)
                {
                    minProjection = kvp.Value;
                    min = kvp.Key;
                }
                if (kvp.Value > maxProjection)
                {
                    maxProjection = kvp.Value;
                    max = kvp.Key;
                }
            }
            return true;
        }

        /// <summary>
        /// 获取两mep之间的中心坐标点
        /// </summary>
        /// <param name="mEPCurve1"></param>
        /// <param name="mEPCurve2"></param>
        /// <returns></returns>
        public static XYZ GetMEPCenterPoint(XYZ point, MEPCurve mEPCurve1, MEPCurve mEPCurve2, out double distance)
        {
            point = new XYZ(point.X, point.Y, 0);

            double halfWidth1;
            double halfWidth2;
            if (mEPCurve1 is Pipe)
            {
                //halfWidth1 = mEPCurve1.get_Parameter(BuiltInParameter.RBS_PIPE_DIAMETER_PARAM).AsDouble() / 2;
                halfWidth1 = mEPCurve1.get_Parameter(BuiltInParameter.RBS_PIPE_OUTER_DIAMETER).AsDouble() / 2;
            }
            else
            {
                halfWidth1 = (mEPCurve1.LookupParameter("直径")?.AsDouble() ?? mEPCurve1.Width) / 2;
            }
            if (mEPCurve2 is Pipe)
            {
                //halfWidth2 = mEPCurve2.get_Parameter(BuiltInParameter.RBS_PIPE_DIAMETER_PARAM).AsDouble() / 2;
                halfWidth2 = mEPCurve2.get_Parameter(BuiltInParameter.RBS_PIPE_OUTER_DIAMETER).AsDouble() / 2;
            }
            else
            {
                halfWidth2 = (mEPCurve2.LookupParameter("直径")?.AsDouble() ?? mEPCurve2.Width) / 2;
            }

            Line oldLine1 = (mEPCurve1.Location as LocationCurve).Curve as Line;
            XYZ oldP10 = oldLine1.GetEndPoint(0);
            XYZ oldP11 = oldLine1.GetEndPoint(1);
            oldP10 = new XYZ(oldP10.X, oldP10.Y, 0);
            oldP11 = new XYZ(oldP11.X, oldP11.Y, 0);
            Line newLine1 = Line.CreateBound(oldP10, oldP11);
            newLine1.MakeUnbound();

            XYZ pp1 = newLine1.Project(point).XYZPoint;

            Line oldLine2 = (mEPCurve2.Location as LocationCurve).Curve as Line;
            XYZ oldP20 = oldLine2.GetEndPoint(0);
            XYZ oldP21 = oldLine2.GetEndPoint(1);
            oldP20 = new XYZ(oldP20.X, oldP20.Y, 0);
            oldP21 = new XYZ(oldP21.X, oldP21.Y, 0);
            Line newLine2 = Line.CreateBound(oldP20, oldP21);
            newLine2.MakeUnbound();

            XYZ pp2 = newLine2.Project(pp1).XYZPoint;

            XYZ dir = (pp2 - pp1).Normalize();

            pp1 -= dir * halfWidth1;
            pp2 += dir * halfWidth2;

            distance = pp1.DistanceTo(pp2);
            if (mEPCurve1.Id == mEPCurve2.Id) distance = halfWidth1 + halfWidth2;

            return pp1.Add(pp2) / 2;
        }

        /// <summary>
        /// 对指定族名称的吊架的宽度进行特调(内部无事务)
        /// </summary>
        /// <param name="hanger">吊架</param>
        /// <param name="width">吊架宽度</param>
        public static void ChangeHangerWidth(FamilyInstance hanger, double width)
        {
            Parameter widthPara = null;

            string familyName = hanger.Symbol.FamilyName;
            if (familyName.Contains("C型钢吊架")) // C型钢丝杆吊架
            {
                widthPara = hanger.LookupParameter("c_桥架宽");
            }
            else if (familyName.Contains("抗震支吊架-单管道")) // 抗震支吊架
            {
                widthPara = hanger.LookupParameter("管道公称直径");
            }
            else if (familyName.Contains("门型抗震吊架")) // 抗震支吊架
            {
                if (familyName.Contains("风管"))
                {
                    widthPara = hanger.LookupParameter("c_风管宽");
                }
                else
                {
                    widthPara = hanger.LookupParameter("c_桥架宽");
                }
            }
            else if (familyName.Contains("C型钢丝杆吊架-风管"))
            {
                widthPara = hanger.LookupParameter("c_风管宽");
            }
            else if (familyName.Contains("C型钢单层丝杆吊架"))
            {
                widthPara = hanger.LookupParameter("c_桥架宽");
            }
            else if (familyName.Contains("单层丝杆吊架（基于楼板）"))
            {
                widthPara = hanger.LookupParameter("c_风管宽");
            }
            else if (familyName.Contains("单管吊架-圆管"))
            {
                widthPara = hanger.LookupParameter("管道公称直径");
            }
            else if (familyName.Contains("PM-多拉杆槽钢吊架（一层）"))
            {
                widthPara = hanger.LookupParameter("支吊架宽度");
            }
            else if (familyName.Contains("PM-多拉杆角钢吊架（一层）"))
            {
                widthPara = hanger.LookupParameter("支吊架宽度");
            }
            else if (familyName.Contains("C型钢丝杆吊架-成排管线") || familyName.Contains("C型钢吊架(2-0)"))
            {
                widthPara = hanger.LookupParameter("c_桥架宽");
            }

            if (widthPara != null && widthPara.IsReadOnly == false) widthPara.Set(width);
        }
        /// <summary>
        /// 对指定族名称的吊架的底高进行特调（内部无事务）
        /// </summary>
        /// <param name="hanger"></param>
        /// <param name="bottomElevation"></param>
        public static void ChangeHangerBottom(FamilyInstance hanger, double bottomElevation)
        {
            Parameter bottomPara = null;

            string familyName = hanger.Symbol.FamilyName;
            if (familyName.Contains("抗震支吊架-单管道"))
            {
                bottomPara = hanger.LookupParameter("管道中心标高");
            }
            else if (familyName.Contains("门型抗震吊架") || familyName.Contains("C型钢丝杆吊架-风管") || familyName.Contains("C型钢单层丝杆吊架")
                || familyName.Contains("C型钢吊架") || familyName.Contains("单层丝杆吊架（基于楼板）") || familyName.Contains("C型钢丝杆吊架-成排管线") || familyName.Contains("C型钢吊架(2-0)")) // 11
            {
                bottomPara = hanger.LookupParameter("b_底层管道底高");
            }
            else if (familyName.Contains("单管吊架-圆管"))
            {
                bottomPara = hanger.LookupParameter("管道中心标高");
            }
            else if (familyName.Contains("PM-多拉杆槽钢吊架（一层）"))
            {
                //bottomPara = hanger.LookupParameter("顶层间距");
            }
            else if (familyName.Contains("PM-多拉杆角钢吊架（一层）"))
            {
                //bottomPara = hanger.LookupParameter("顶层间距");
            }

            if (bottomPara != null && bottomPara.IsReadOnly == false) bottomPara.Set(bottomElevation);
        }
        /// <summary>
        /// 对指定族名称的吊架的Z轴坐标进行特调（扣除吊杆部分长度；内部无事务）
        /// </summary>
        /// <param name="familyInstance"></param>
        public static void ChangeHangerHeight(FamilyInstance familyInstance)
        {
            double moveDis = 0;

            string familyName = familyInstance.Symbol.FamilyName;
            if (familyName.Contains("抗震支吊架-单管道"))
            {
                moveDis = 90 / 304.8;
            }
            else if (familyName.Contains("门型抗震吊架"))
            {
                if (familyName.Contains("风管") || familyName.Contains("桥架") || familyName.Contains("水管") || familyName.Contains("双层")) moveDis = 90 / 304.8;
                else if (familyName.Contains("三层")) moveDis = 101.4 / 304.8;
            }
            else if (familyName.Contains("C型钢丝杆吊架-风管") || familyName.Contains("C型钢单层丝杆吊架") || familyName.Contains("单层丝杆吊架（基于楼板）") || familyName.Contains("C型钢丝杆吊架-成排管线"))
            {
                moveDis = 90 / 304.8;
            }
            else if (familyName.Contains("C型钢吊架") || familyName.Contains("C型钢吊架(2-0)"))
            {
                moveDis = 80 / 304.8;
            }
            else if (familyName.Contains("单层吊架-圆管") || familyName.Contains("PM-多拉杆槽钢吊架（一层）") || familyName.Contains("PM-多拉杆角钢吊架（一层）"))
            {
                moveDis = 0;
            }

            familyInstance.Location.Move(moveDis * XYZ.BasisZ);
        }
        /// <summary>
        /// 调整多层吊架的管道底标高参数(内部无事务)
        /// </summary>
        /// <param name="familyInstance"></param>
        /// <param name="elements">管线集合(底部高程100mm内为同一层管线)</param>
        public static void ChangeMultiLayerHanger(FamilyInstance familyInstance, List<MEPCurve> elements)
        {
            string familyName = familyInstance.Symbol.FamilyName;
            List<double> layerLowestValues = GetHangerLayerLowestBottomValue(elements, 100.0 / 304.8);
            if (familyName.Contains("门型抗震吊架"))
            {
                if (familyName.Contains("双层"))
                {
                    if (layerLowestValues.Count >= 2) familyInstance.LookupParameter("上层管道底标高")?.Set(layerLowestValues[1]);
                }
                else if (familyName.Contains("三层"))
                {
                    if (layerLowestValues.Count >= 2) familyInstance.LookupParameter("第二层管道底标高")?.Set(layerLowestValues[1]);
                    if (layerLowestValues.Count >= 3) familyInstance.LookupParameter("上层管道底标高")?.Set(layerLowestValues[2]);
                }
            }
        }
        /// <summary>
        /// 获取吊架指定层最低的底部高程
        /// </summary>
        /// <param name="elements">管线集合</param>
        /// <param name="scope">底部高程范围</param>
        /// <returns></returns>
        public static List<double> GetHangerLayerLowestBottomValue(List<MEPCurve> elements, double scope)
        {
            List<double> result = new List<double>();
            if (elements.Count == 0) return result;

            var meps = elements.Select(e => e).Where(m => m.LookupParameter("底部高程")?.AsDouble() != null).ToList();
            double firstBottom = meps.OrderBy(m => m.LookupParameter("底部高程").AsDouble()).First().LookupParameter("底部高程").AsDouble();
            result.Add(firstBottom);

            double? secondBottom = meps.Where(m => m.LookupParameter("底部高程").AsDouble() - firstBottom >= scope).OrderBy(m => m.LookupParameter("底部高程").AsDouble()).FirstOrDefault()?.LookupParameter("底部高程").AsDouble();
            if (secondBottom == null) return result;
            result.Add((double)secondBottom);

            double? thirdBottom = meps.Where(m => m.LookupParameter("底部高程").AsDouble() - secondBottom >= scope).OrderBy(m => m.LookupParameter("底部高程").AsDouble()).FirstOrDefault()?.LookupParameter("底部高程").AsDouble();
            if ((thirdBottom == null)) return result;
            result.Add((double)thirdBottom);

            return result;
        }

    }
}
