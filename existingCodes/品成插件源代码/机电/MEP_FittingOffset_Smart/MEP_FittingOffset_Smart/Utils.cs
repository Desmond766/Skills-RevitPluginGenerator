using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEP_FittingOffset_Smart
{
    class Utils
    {
        #region 获得连接到的构件
        /// <summary>
        /// 获得连接到的构件
        /// </summary>
        /// <param name="elem"></param>
        public static List<Element> FindConnectedToList(Element elem)
        {
            List<Element> connToList = new List<Element>();
            // 获得conSet
            ConnectorSet conSet = Utils.GetConSet(elem);
            foreach (Connector con in conSet)
            {
                Connector connToCon = Utils.FindConnectedTo(con);
                if (null != connToCon)
                {
                    connToList.Add(connToCon.Owner);
                }
            }
            return connToList;
        }
        #endregion

        #region 获得ConSet
        /// <summary>
        /// 获得ConSet
        /// </summary>
        /// <param name="elem"></param>
        /// <returns></returns>
        public static ConnectorSet GetConSet(Element elem)
        {
            // 获得conSet
            ConnectorSet conSet = null;
            if (elem is MEPCurve)
            {
                conSet = (elem as MEPCurve).ConnectorManager.Connectors;
            }
            else if (elem is FamilyInstance)
            {
                conSet = (elem as FamilyInstance).MEPModel.ConnectorManager.Connectors;
            }
            return conSet;
        }
        #endregion

        #region FindConnectedTo
        /// <summary>
        /// FindConnectedTo
        /// </summary>
        /// <param name="curve"></param>
        /// <param name="conXYZ"></param>
        /// <returns></returns>
        public static Connector FindConnectedTo(Connector connItself)
        {
            ConnectorSet connSet = connItself.AllRefs;
            foreach (Connector conn in connSet)
            {
                if (conn.Owner.Id.IntegerValue != connItself.Owner.Id.IntegerValue
                    && conn.ConnectorType != ConnectorType.Logical)//&& conn.ConnectorType == ConnectorType.End
                {
                    return conn;
                }
            }
            return null;
        }
        #endregion

        #region 获得两段线的端点，按顺序排列
        /// <summary>
        /// 获得两段线的端点，按顺序排列
        /// </summary>
        /// <param name="line1"></param>
        /// <param name="line2"></param>
        /// <returns></returns>
        public static List<XYZ> GetEndPoint(Line line1, Line line2)
        {
            List<XYZ> endPointList = new List<XYZ>();
            double maxDistance = 0.0;
            double distance;
            XYZ p1 = null;
            XYZ p2 = null;
            XYZ p3 = null;
            XYZ p4 = null;
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    distance = line1.GetEndPoint(i).DistanceTo(line2.GetEndPoint(j));
                    if (distance > maxDistance)
                    {
                        maxDistance = distance;
                        p1 = line1.GetEndPoint(i);
                        p2 = line1.GetEndPoint(1 - i);
                        p3 = line2.GetEndPoint(1 - j);
                        p4 = line2.GetEndPoint(j);

                    }
                }
            }
            endPointList.Add(p1);
            endPointList.Add(p2);
            endPointList.Add(p3);
            endPointList.Add(p4);
            return endPointList;
        }
        #endregion

        #region 找到管道上距离配件较近的点
        public static XYZ GetClosedPt(MEPCurve mepcurve, Element elem)
        {
            LocationPoint elemLocationPt = elem.Location as LocationPoint;
            XYZ elemPt = elemLocationPt.Point;//配件位置

            //找管道上距离配件近的点
            XYZ gPt = new XYZ();
            Line gMEPLine = (mepcurve.Location as LocationCurve).Curve as Line;
            if (gMEPLine.GetEndPoint(0).DistanceTo(elemPt) < gMEPLine.GetEndPoint(1).DistanceTo(elemPt))
            {
                gPt = gMEPLine.GetEndPoint(0);
            }
            else
            {
                gPt = gMEPLine.GetEndPoint(1);
            }


            return gPt;
        }

        #endregion

        #region 找到管道上距离配件较远的点
        public static XYZ GetFarPt(MEPCurve mepcurve, Element elem)
        {
            LocationPoint elemLocationPt = elem.Location as LocationPoint;
            XYZ elemPt = elemLocationPt.Point;//配件位置

            //找管道上距离配件近的点
            XYZ gPt = new XYZ();
            Line gMEPLine = (mepcurve.Location as LocationCurve).Curve as Line;
            if (gMEPLine.GetEndPoint(0).DistanceTo(elemPt) > gMEPLine.GetEndPoint(1).DistanceTo(elemPt))
            {
                gPt = gMEPLine.GetEndPoint(0);
            }
            else
            {
                gPt = gMEPLine.GetEndPoint(1);
            }


            return gPt;
        }

        #endregion

        #region 复制参数

        /// <summary>
        /// 复制工作集
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        private static void CopyPartition(Element source, Element target)
        {
            Parameter partition = source.get_Parameter(BuiltInParameter.ELEM_PARTITION_PARAM);
            if (null != partition)
            {
                target.get_Parameter(BuiltInParameter.ELEM_PARTITION_PARAM).Set(partition.AsInteger());
            }
        }

        /// <summary>
        /// 管道
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        public static void CopyParameters(Pipe source, Pipe target)
        {
            double diameter = source.get_Parameter(BuiltInParameter.RBS_PIPE_DIAMETER_PARAM).AsDouble();
            target.get_Parameter(BuiltInParameter.RBS_PIPE_DIAMETER_PARAM).Set(diameter);
            CopyPartition(source, target);
        }

        /// <summary>
        /// 风管
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        public static void CopyParameters(Duct source, Duct target)
        {
            if (null != source.get_Parameter(BuiltInParameter.RBS_CURVE_WIDTH_PARAM))
            {
                double width = source.get_Parameter(BuiltInParameter.RBS_CURVE_WIDTH_PARAM).AsDouble();
                double height = source.get_Parameter(BuiltInParameter.RBS_CURVE_HEIGHT_PARAM).AsDouble();
                target.get_Parameter(BuiltInParameter.RBS_CURVE_WIDTH_PARAM).Set(width);
                target.get_Parameter(BuiltInParameter.RBS_CURVE_HEIGHT_PARAM).Set(height);
            }
            else
            {
                double diameter = source.get_Parameter(BuiltInParameter.RBS_CURVE_DIAMETER_PARAM).AsDouble();
                target.get_Parameter(BuiltInParameter.RBS_CURVE_DIAMETER_PARAM).Set(diameter);
            }
            CopyPartition(source, target);
        }

        /// <summary>
        /// 桥架
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        public static void CopyParameters(CableTray source, CableTray target)
        {
            double width = source.get_Parameter(BuiltInParameter.RBS_CABLETRAY_WIDTH_PARAM).AsDouble();
            double height = source.get_Parameter(BuiltInParameter.RBS_CABLETRAY_HEIGHT_PARAM).AsDouble();
            target.get_Parameter(BuiltInParameter.RBS_CABLETRAY_WIDTH_PARAM).Set(width);
            target.get_Parameter(BuiltInParameter.RBS_CABLETRAY_HEIGHT_PARAM).Set(height);
            CopyPartition(source, target);
        }

        /// <summary>
        /// 线管
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        public static void CopyParameters(Conduit source, Conduit target)
        {
            double diameter = source.get_Parameter(BuiltInParameter.RBS_CONDUIT_DIAMETER_PARAM).AsDouble();
            target.get_Parameter(BuiltInParameter.RBS_CONDUIT_DIAMETER_PARAM).Set(diameter);
            CopyPartition(source, target);
        }

        #endregion

        #region 获得指定位置处管道连接对象的连接件
        /// <summary>
        /// 获得指定位置处管道连接对象的连接件
        /// </summary>
        /// <param name="pipe">管道</param>
        /// <param name="conXYZ">位置</param>
        /// <returns>连接件</returns>
        public static Connector FindConnectedTo(MEPCurve curve, XYZ conXYZ)
        {
            Connector connItself = FindConnector(curve, conXYZ);
            ConnectorSet connSet = connItself.AllRefs;
            foreach (Connector conn in connSet)
            {
                if (conn.Owner.Id.IntegerValue != curve.Id.IntegerValue &&
                    conn.ConnectorType == ConnectorType.End)
                {
                    return conn;
                }
            }
            return null;
        }
        #endregion

        #region 获得指定位置处管道的连接件
        /// <summary>
        /// 获得指定位置处管道的连接件
        /// </summary>
        /// <param name="pipe">管道</param>
        /// <param name="conXYZ">位置</param>
        /// <returns>连接件</returns>
        public static Connector FindConnector(MEPCurve curve, XYZ conXYZ)
        {
            ConnectorSet conns = curve.ConnectorManager.Connectors;
            foreach (Connector conn in conns)
            {
                if (conn.Origin.IsAlmostEqualTo(conXYZ))
                {
                    return conn;
                }
            }
            return null;
        }
        #endregion

        #region 绘制模型线
        /// <summary>
        /// 绘制模型线
        /// </summary>
        /// <param name="p1">点1</param>
        /// <param name="p2">点2</param>
        public static void DrawModelCurve(Document doc, XYZ p1, XYZ p2)
        {
            SketchPlane sketchPlane = SketchPlane.Create(doc, new Plane((p1 - p2).CrossProduct(p1), p2));
            doc.Create.NewModelCurve(Line.CreateBound(p1, p2), sketchPlane);
        }
        #endregion
    }
}
