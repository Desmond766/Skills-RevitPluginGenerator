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

namespace MEP_OffsetCanceller
{
    class Utils
    {

        #region 获得点在直线上的投影点坐标
        /// <summary>
        /// 获得点在直线上的投影点坐标
        /// </summary>
        /// <param name="p1">直线起点</param>
        /// <param name="p2">直线终点</param>
        /// <param name="q">直线外的点</param>
        /// <returns>投影点</returns>
        public static XYZ GetProjectivePoint(XYZ p1, XYZ p2, XYZ q)
        {
            XYZ u = p2 - p1;
            XYZ pq = q - p1;
            XYZ w2 = pq - u.Multiply(pq.DotProduct(u) / (u.GetLength() * u.GetLength()));
            XYZ point = q - w2;
            return point;
        }

        /// <summary>
        /// 获得点在直线上的投影点坐标
        /// </summary>
        /// <param name="l">直线</param>
        /// <param name="q">直线外的点</param>
        /// <returns>投影点</returns>
        public static XYZ GetProjectivePoint(Line l, XYZ q)
        {
            XYZ u = l.Direction;
            XYZ pq = q - l.GetEndPoint(0);
            XYZ w2 = pq - u.Multiply(pq.DotProduct(u) / (u.GetLength() * u.GetLength()));
            XYZ point = q - w2;
            return point;
        }

        #endregion

        #region 获得指定连接件连接到的构件
        /// <summary>
        /// 获得指定连接件连接到的构件
        /// </summary>
        /// <param name="pipe">管道</param>
        /// <param name="conXYZ">位置</param>
        /// <returns>连接件</returns>
        public static Element FindConnectorToElem(Element elem, XYZ conXYZ)
        {
            Element goalElem = null;
            List<Element> elemList = FindConnectedToList(elem);
            foreach (Element element in elemList)
            {
                ConnectorSet connSet = GetConSet(element);
                foreach (Connector conn in connSet)
                {
                    if (conn.Origin.IsAlmostEqualTo(conXYZ))
                    {
                        goalElem = conn.Owner;
                    }
                }
            }

            return goalElem;
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

        #region 获得UsedConSet
        /// <summary>
        /// 获得UsedConSet
        /// </summary>
        /// <param name="elem"></param>
        /// <returns></returns>
        public static ConnectorSet GetUsedConSet(Element elem)
        {
            ConnectorSet usedConSet = new ConnectorSet();
            ConnectorSet conSet = GetConSet(elem);
            if (null != conSet)
            {
                foreach (Connector con in conSet)
                {
                    if (con.ConnectorType != ConnectorType.MasterSurface)
                    {
                        if (con.IsConnected)
                        {
                            usedConSet.Insert(con);
                        }
                    }
                }
            }
            return usedConSet;
        }
        #endregion

        #region 获得ConList
        /// <summary>
        /// 获得ConList
        /// </summary>
        /// <param name="conSet"></param>
        /// <returns></returns>
        public static List<Connector> GetConList(ConnectorSet conSet)
        {
            List<Connector> conList = new List<Connector>();
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

        #region GetInstanceCenter
        /// <summary>
        /// GetInstanceCenter
        /// </summary>
        /// <param name="fi"></param>
        /// <returns></returns>
        public static XYZ GetInstanceCenter(FamilyInstance fi)
        {
            ConnectorSet connSet = fi.MEPModel.ConnectorManager.Connectors;
            XYZ locationPoint = (fi.Location as LocationPoint).Point;
            if (connSet.Size == 2)
            {
                List<Connector> connList = new List<Connector>();
                foreach (Connector con in connSet)
                {
                    connList.Add(con);
                }
                if (connList[0].Origin.IsAlmostEqualTo(locationPoint) || connList[1].Origin.IsAlmostEqualTo(locationPoint))
                {
                    return (connList[0].Origin + connList[1].Origin) / 2.0;
                }
            }
            return locationPoint;
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

        #region 是否近视相等
        /// <summary>
        /// 是否近视相等
        /// </summary>
        /// <param name="d1"></param>
        /// <param name="d2"></param>
        /// <returns></returns>
        public static bool IsAlmostEqual(double d1, double d2)
        {
            if (Math.Abs(d1 - d2) < 0.0001)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region Txt转List
        /// <summary>
        /// Txt转List
        /// </summary>
        /// <param name="path">文件</param>
        /// <returns></returns>
        public static List<string> TxtToList(string path)
        {
            List<string> data = new List<string>();

            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs, Encoding.Default);

            string strLine = "";
            while ((strLine = sr.ReadLine()) != null)
            {
                data.Add(strLine);
            }
            return data;
        }
        #endregion

        #region 创建弯头
        public static void CreateElbowFitting(Document doc, XYZ elbowFittingPt, MEPCurve zhiG1, MEPCurve zhiG2)
        {
            //管1距弯头位置点近的点
            XYZ zhiG1PtConn = new XYZ();
            Line zhiG1MEPLine = (zhiG1.Location as LocationCurve).Curve as Line;
            if (zhiG1MEPLine.GetEndPoint(0).DistanceTo(elbowFittingPt) < zhiG1MEPLine.GetEndPoint(1).DistanceTo(elbowFittingPt))
            {
                zhiG1PtConn = zhiG1MEPLine.GetEndPoint(0);
            }
            else
            {
                zhiG1PtConn = zhiG1MEPLine.GetEndPoint(1);
            }
            //管2距弯头位置点近的点
            XYZ zhiG2PtConn = new XYZ();
            Line zhiG2MEPLine = (zhiG2.Location as LocationCurve).Curve as Line;
            if (zhiG2MEPLine.GetEndPoint(0).DistanceTo(elbowFittingPt) < zhiG2MEPLine.GetEndPoint(1).DistanceTo(elbowFittingPt))
            {
                zhiG2PtConn = zhiG2MEPLine.GetEndPoint(0);
            }
            else
            {
                zhiG2PtConn = zhiG2MEPLine.GetEndPoint(1);
            }
            //直管上距弯头位置点近的连接件
            Connector zhiG1Conn = FindConnector(zhiG1, zhiG1PtConn);
            Connector zhiG2Conn = FindConnector(zhiG2, zhiG2PtConn);
            doc.Create.NewElbowFitting(zhiG1Conn, zhiG2Conn);
        }
        #endregion

        #region 创建三通
        public static void CreateTeeFitting(Document doc, XYZ teeFittingPt, MEPCurve zhiG1, MEPCurve zhiG2, MEPCurve zhiG3)
        {
            //管1距三通位置点近的点
            XYZ zhiG1PtConn = new XYZ();
            Line zhiG1MEPLine = (zhiG1.Location as LocationCurve).Curve as Line;
            if (zhiG1MEPLine.GetEndPoint(0).DistanceTo(teeFittingPt) < zhiG1MEPLine.GetEndPoint(1).DistanceTo(teeFittingPt))
            {
                zhiG1PtConn = zhiG1MEPLine.GetEndPoint(0);
            }
            else
            {
                zhiG1PtConn = zhiG1MEPLine.GetEndPoint(1);
            }
            //管2距三通位置点近的点
            XYZ zhiG2PtConn = new XYZ();
            Line zhiG2MEPLine = (zhiG2.Location as LocationCurve).Curve as Line;
            if (zhiG2MEPLine.GetEndPoint(0).DistanceTo(teeFittingPt) < zhiG2MEPLine.GetEndPoint(1).DistanceTo(teeFittingPt))
            {
                zhiG2PtConn = zhiG2MEPLine.GetEndPoint(0);
            }
            else
            {
                zhiG2PtConn = zhiG2MEPLine.GetEndPoint(1);
            }
            //管3距三通位置点近的点
            XYZ zhiG3PtConn = new XYZ();
            Line zhiG3MEPLine = (zhiG3.Location as LocationCurve).Curve as Line;
            if (zhiG3MEPLine.GetEndPoint(0).DistanceTo(teeFittingPt) < zhiG3MEPLine.GetEndPoint(1).DistanceTo(teeFittingPt))
            {
                zhiG3PtConn = zhiG3MEPLine.GetEndPoint(0);
            }
            else
            {
                zhiG3PtConn = zhiG3MEPLine.GetEndPoint(1);
            }
            //直管上距弯头位置点近的连接件
            Connector zhiG1Conn = FindConnector(zhiG1, zhiG1PtConn);
            Connector zhiG2Conn = FindConnector(zhiG2, zhiG2PtConn);
            Connector zhiG3Conn = FindConnector(zhiG3, zhiG3PtConn);
            doc.Create.NewTeeFitting(zhiG1Conn, zhiG2Conn, zhiG3Conn);
        }
        #endregion

        #region 得到构件连接的  不在List中的构件
        public static Element GetGoalElement(Element elem, List<ElementId> elementDel)
        {
            //收集构件01，11，21(翻弯的上配件1、上配件2、上配件3)
            //01
            List<Element> goalElemList = Utils.FindConnectedToList(elem);
            Element goalElem = null;
            foreach (var item in goalElemList)
            {
                if (false == elementDel.Contains(item.Id))
                {
                    goalElem = item;
                }
            }
            return goalElem;
        }
        #endregion

        #region 找到要补直管的两个点,创建管道
        public static void GetPtToCreateMEPCurve(Document doc, MEPCurve gMEPCurve, Element elem)
        {

            LocationPoint elemLocationPt = elem.Location as LocationPoint;
            XYZ elemPt = elemLocationPt.Point;//配件位置

            //找管道上距离配件远的点
            XYZ gPt = new XYZ();
            Line gMEPLine = (gMEPCurve.Location as LocationCurve).Curve as Line;
            if (gMEPLine.GetEndPoint(0).DistanceTo(elemPt) > gMEPLine.GetEndPoint(1).DistanceTo(elemPt))
            {
                gPt = gMEPLine.GetEndPoint(0);
            }
            else
            {
                gPt = gMEPLine.GetEndPoint(1);
            }
            //找到管道这个位置的连接件
            Connector gPtConn = Utils.FindConnector(gMEPCurve, gPt);

            //找到配件上距离这个点最近的连接件
            ConnectorSet connSet = Utils.GetConSet(elem);
            List<Connector> connList = Utils.GetConList(connSet);
            Connector gElemPtConn = null;
            double d = 1000000.0;
            foreach (var item in connList)
            {
                if (item.Origin.DistanceTo(gPt) < d)
                {
                    gElemPtConn = item;
                    d = item.Origin.DistanceTo(gPt);
                }
            }

            //DrawModelCurve(doc, gPtConn.Origin, gElemPtConn.Origin);

            //判断这个点的高度与配件位置的高度是否相等
            if (Math.Abs(gPtConn.Origin.Z - elemPt.Z) < 0.001)
            {
                //判断管道是否还连接其他，如果有，返回连接的连接件
                if (gPtConn.IsConnected == true)
                {
                    gPtConn = FindConnectedTo(gMEPCurve, gPtConn.Origin);
                    MEPHelper.Create(doc, gMEPCurve, gPtConn, gElemPtConn);
                }
                else
                {
                    MEPHelper.Create(doc, gMEPCurve, gPtConn, gElemPtConn);
                }
            }
            else
            {
                XYZ gPtToCreate = new XYZ(gPtConn.Origin.X, gPtConn.Origin.Y, gElemPtConn.Origin.Z);
                MEPHelper.Create(doc, gMEPCurve, gPtToCreate, gElemPtConn);
            }

        }
        #endregion

        #region 找到三通垂直面上的连接件
        public static Connector GetTeeEndConn(Element teeElem)
        {
            Connector teeEndConn = null;

             LocationPoint elemLocationPt =teeElem.Location as LocationPoint;
            XYZ elemPt = elemLocationPt.Point;//配件位置

            List<Connector> teeConnList = Utils.GetConList(Utils.GetConSet(teeElem));
            XYZ k1 = teeConnList[0].Origin - elemPt;
            XYZ k2 = teeConnList[1].Origin - elemPt;
            XYZ k3 = teeConnList[2].Origin - elemPt;
            if (Math.Abs(k1.AngleTo(k2)) == 0.5 || Math.Abs(k1.AngleTo(k2)) == 1.5)
            {
                if (Math.Abs(k1.AngleTo(k3)) == 0.5 || Math.Abs(k1.AngleTo(k3)) == 1.5)
                {
                    teeEndConn = teeConnList[0];
                }
                else
                {
                    teeEndConn = teeConnList[1];
                }

            }
            else
            {
                teeEndConn = teeConnList[2];
            }
            
            return teeEndConn;
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
    }
}
