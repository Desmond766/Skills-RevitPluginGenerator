using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.DB.Plumbing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEP_SmartMove
{
    class Utils
    {
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

        #region 获得指定位置处配件的连接件
        /// <summary>
        /// 获得指定位置处管道的连接件
        /// </summary>
        /// <param name="elem">配件</param>
        /// <param name="conXYZ">位置</param>
        /// <returns>连接件</returns>
        public static Connector FindConnector(Element elem, XYZ conXYZ)
        {
            try
            {
                ConnectorSet conns = (elem as FamilyInstance).MEPModel.ConnectorManager.Connectors;
                foreach (Connector conn in conns)
                {
                    if (conn.Origin.IsAlmostEqualTo(conXYZ))
                    {
                        return conn;
                    }
                }
                return null;
            }
            catch
            {
                return null;
            }
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

        #region 获得指定位置处配件连接对象的连接件
        /// <summary>
        /// 获得指定位置处管道连接对象的连接件
        /// </summary>
        /// <param name="elem">配件</param>
        /// <param name="conXYZ">位置</param>
        /// <returns>连接件</returns>
        public static Connector FindConnectedTo(Element elem, XYZ conXYZ)
        {
            Connector connItself = FindConnector(elem, conXYZ);
            ConnectorSet connSet = connItself.AllRefs;
            foreach (Connector conn in connSet)
            {
                if (conn.Owner.Id.IntegerValue != elem.Id.IntegerValue &&
                    conn.ConnectorType == ConnectorType.End)
                {
                    return conn;
                }
            }
            return null;
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

        #region 获得构件的连接件集合ConList
        /// <summary>
        /// 获得ConList
        /// </summary>
        /// <param name="elem"></param>
        /// <returns></returns>
        public static List<Connector> GetConList(Element elem)
        {
            List<Connector> conList = new List<Connector>();
            ConnectorSet conSet = GetConSet(elem);
            if (null != conSet)
            {
                foreach (Connector con in conSet)
                {
                    conList.Add(con);
                }
            }
            return conList;
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

        #region 绘制模型线
        /// <summary>
        /// 绘制模型线
        /// </summary>
        /// <param name="p1">点1</param>
        /// <param name="p2">点2</param>
        public static ModelCurve DrawModelCurve(Document doc, XYZ p1, XYZ p2)
        {
            SketchPlane sketchPlane = SketchPlane.Create(doc, new Plane((p1 - p2).CrossProduct(p1), p2));
            return doc.Create.NewModelCurve(Line.CreateBound(p1, p2), sketchPlane);
        }
        #endregion

    }
}
