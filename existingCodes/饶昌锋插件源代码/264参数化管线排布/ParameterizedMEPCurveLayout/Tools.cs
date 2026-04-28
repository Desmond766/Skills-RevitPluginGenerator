using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParameterizedMEPCurveLayout
{
    /// <summary>
    /// 工具类
    /// </summary>
    public class Tools
    {
        /// <summary>
        /// 判断管线是否为水平方向
        /// </summary>
        /// <param name="mEPCurve"></param>
        /// <returns></returns>
        public static bool IsHorizontal(MEPCurve mEPCurve)
        {
            XYZ startPoint = (mEPCurve.Location as LocationCurve).Curve.GetEndPoint(0);
            XYZ endPoint = (mEPCurve.Location as LocationCurve).Curve.GetEndPoint(1);
            if (startPoint.X == endPoint.X)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 判断管线竖直方向 true下 false上
        /// </summary>
        /// <param name="mEPCurve"></param>
        /// <returns></returns>
        public static bool VerticalDirection(MEPCurve mEPCurve)
        {
            XYZ point1 = new XYZ();
            XYZ point2 = new XYZ();
            foreach (Connector item in mEPCurve.ConnectorManager.Connectors)
            {
                if (item.Id == 0)
                {
                    point1 = item.Origin;
                }
                if (item.Id == 1)
                {
                    point2 = item.Origin;
                }
            }
            if (point1.Y < point2.Y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 判断管线水平方向 true右 false左
        /// </summary>
        /// <param name="mEPCurve"></param>
        /// <returns></returns>
        public static bool HorizontalDirection(MEPCurve mEPCurve)
        {
            XYZ point1 = new XYZ();
            XYZ point2 = new XYZ();
            foreach (Connector item in mEPCurve.ConnectorManager.Connectors)
            {
                if (item.Id == 0)
                {
                    point1 = item.Origin;
                }
                if (item.Id == 1)
                {
                    point2 = item.Origin;
                }
            }
            if (point1.X < point2.X)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 获取MEPCurve中心点
        /// </summary>
        /// <param name="mEPCurve"></param>
        /// <returns></returns>
        public static XYZ GetMEPCurveCentrePoint(MEPCurve mEPCurve)
        {
            LocationCurve locationCurve = mEPCurve.Location as LocationCurve;
            Curve curve = locationCurve.Curve;
            XYZ centerPoint = curve.Evaluate(0.5, true);
            return centerPoint;
        }

        /// <summary>
        /// 移动管线
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="element1"></param>
        /// <param name="element2"></param>
        public static void MoveMEPCurve(Document doc, MEPCurve elem, XYZ targetPoint)
        {
            XYZ elemPoint = GetMEPCurveCentrePoint(elem);
            XYZ moveDistance = targetPoint - elemPoint;
            ElementTransformUtils.MoveElement(doc, elem.Id, moveDistance);
        }

        /// <summary>
        /// 根据类型返回名称 用于获取管线间距
        /// </summary>
        /// <param name="mEPCurve"></param>
        /// <returns></returns>
        public static string FiltratePipeline(MEPCurve mEPCurve)
        {
            if (mEPCurve.Category.Id.IntegerValue == (int)BuiltInCategory.OST_DuctCurves)
            {
                return "风管";
            }
            if (mEPCurve.Category.Id.IntegerValue == (int)BuiltInCategory.OST_PipeCurves)
            {
                if (mEPCurve.get_Parameter(BuiltInParameter.RBS_PIPING_SYSTEM_TYPE_PARAM).AsValueString() == "N-空调热水回水系统" || mEPCurve.get_Parameter(BuiltInParameter.RBS_PIPING_SYSTEM_TYPE_PARAM).AsValueString() == "N-空调热水供水系统")
                {
                    return "采暖管";
                }
                return "水管";
            }
            if (mEPCurve.Category.Id.IntegerValue == (int)BuiltInCategory.OST_CableTray)
            {
                if (mEPCurve.Name == "照明线槽")
                {
                    return "照明线槽";
                }
                return "桥架";
            }
            return "";
        }
    }

}
