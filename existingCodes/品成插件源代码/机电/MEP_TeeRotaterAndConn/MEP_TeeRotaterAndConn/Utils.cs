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
using System.Windows.Forms;

namespace MEP_TeeRotaterAndConn
{
    class Utils
    {
        #region 获得硬盘序列号
        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern long GetVolumeInformation(
            string PathName,
            StringBuilder VolumeNameBuffer,
            UInt32 VolumeNameSize,
            ref UInt32 VolumeSerialNumber,
            ref UInt32 MaximumComponentLength,
            ref UInt32 FileSystemFlags,
            StringBuilder FileSystemNameBuffer,
            UInt32 FileSystemNameSize);

        public static string GetVolumeSerial(string strDriveLetter)
        {
            uint serNum = 0;
            uint maxCompLen = 0;
            StringBuilder VolLabel = new StringBuilder(256); // Label
            UInt32 VolFlags = new UInt32();
            StringBuilder FSName = new StringBuilder(256); // File System Name
            strDriveLetter += "://"; // fix up the passed-in drive letter for the API call
            long Ret = GetVolumeInformation(strDriveLetter, VolLabel, (UInt32)VolLabel.Capacity, ref serNum, ref maxCompLen, ref VolFlags, FSName, (UInt32)FSName.Capacity);
            return Convert.ToString(serNum);
        }
        #endregion

        #region 给一个字符串进行MD5加密
        /// <summary>  
        /// 给一个字符串进行MD5加密
        /// </summary>  
        /// <param name="strText">待加密字符串</param>  
        /// <returns>加密后的字符串</returns>  
        public static string MD5Encrypt(string strText)
        {
            char[] md5Chars = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f' };
            System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] result = md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(strText));
            char[] chars = new char[result.Length * 2];
            int i = 0;
            foreach (byte b in result)
            {
                char c0 = md5Chars[(b & 0xf0) >> 4];
                chars[i++] = c0;
                char c1 = md5Chars[b & 0xf];
                chars[i++] = c1;
            }
            return new String(chars);
        }
        #endregion

        #region 验证注册
        /// <summary>
        /// 验证注册
        /// </summary>
        /// <returns></returns>
        public static bool AddInCheckIn()
        {
            var assemblyPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var path = Path.Combine(Path.GetDirectoryName(assemblyPath), "BimtransToolReg.log");
            if (!File.Exists(path))
            {
                MessageBox.Show("插件未注册！请联系福建品成建设工程顾问有限公司，电话：0591-87310215");
                return false;
            }
            var regData = File.ReadAllLines(path);
            if (regData.Length != 2)
            {
                MessageBox.Show("注册信息错误，请重新注册！请联系福建品成建设工程顾问有限公司，电话：0591-87310215");
                return false;
            }
            var seriesNum = regData[0];
            var localKey = regData[1];
            var diskNum = GetVolumeSerial("C");
            var generateKey = MD5Encrypt(seriesNum + diskNum);
            if (generateKey != localKey)
            {
                MessageBox.Show("注册信息错误，请重新注册！请联系福建品成建设工程顾问有限公司，电话：0591-87310215");
                return false;
            }
            return true;
        }
        #endregion


        //public static void CopyParameters(Pipe source, Pipe target)
        //{
        //    double diameter = source.get_Parameter(BuiltInParameter.RBS_PIPE_DIAMETER_PARAM).AsDouble();
        //    target.get_Parameter(BuiltInParameter.RBS_PIPE_DIAMETER_PARAM).Set(diameter);
        //    CopyPartition(source, target);
        //}

        //public static void CopyParameters1(Pipe source, Pipe target)
        //{

        //    CopyPartition(source, target);
        //}

        //private static void CopyPartition(Element source, Element target)
        //{
        //    Parameter partition = source.get_Parameter(BuiltInParameter.ELEM_PARTITION_PARAM);
        //    if (null != partition)
        //    {
        //        target.get_Parameter(BuiltInParameter.ELEM_PARTITION_PARAM).Set(partition.AsInteger());
        //    }
        //}

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

        public static Connector FindUnusedConnector(MEPCurve curve)
        {
            ConnectorSet conns = curve.ConnectorManager.UnusedConnectors;
            foreach (Connector conn in conns)
            {
                if (conns.Size == 1)
                {
                    return conn;
                }
            }
            return null;
        }

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

        #region FindConnectorCloseToPoint
        /// <summary>
        /// FindConnectorCloseToPoint
        /// </summary>
        /// <param name="curve"></param>
        /// <param name="conXYZ"></param>
        /// <returns></returns>
        public static Connector FindConnectorCloseToPoint(Element e, XYZ point)
        {
            ConnectorSet connectorSet = GetConSet(e);
            List<Connector> connectorList = new List<Connector>();
            Connector connector;
            foreach (Connector conn in connectorSet)
            {
                connectorList.Add(conn);
            }
            if ((connectorList[0].Origin.DistanceTo(point)) < (connectorList[1].Origin.DistanceTo(point)))
            {
                connector = connectorList[0];
            }
            else
            {
                connector = connectorList[1];
            }
            return connector;
        }
        #endregion


        #region FindConnectorFarToPoint
        /// <summary>
        /// FindConnectorFarToPoint
        /// </summary>
        /// <param name="curve"></param>
        /// <param name="conXYZ"></param>
        /// <returns></returns>
        public static Connector FindConnectorFarToPoint(Element e, XYZ point)
        {
            ConnectorSet connectorSet = GetConSet(e);
            List<Connector> connectorList = new List<Connector>();
            Connector connector;
            foreach (Connector conn in connectorSet)
            {
                connectorList.Add(conn);
            }
            if ((connectorList[0].Origin.DistanceTo(point)) < (connectorList[1].Origin.DistanceTo(point)))
            {
                connector = connectorList[1];
            }
            else
            {
                connector = connectorList[0];
            }
            return connector;
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

        /// <summary>
        /// Utility method for getting the intersection between two lines.
        /// </summary>
        /// <param name="line1">The first line.</param>
        /// <param name="line2">The second line.</param>
        /// <returns>The intersection point.</returns>
        /// <exception cref="InvalidOperationException">Thrown when an intersection can't be found.</exception>
        public static XYZ GetIntersection(Line line1, Line line2)
        {
            IntersectionResultArray results;//交点数组
            Autodesk.Revit.DB.SetComparisonResult result = line1.Intersect(line2, out results);

            if (result != Autodesk.Revit.DB.SetComparisonResult.Overlap)//重叠，没有重叠就是平行
                throw new InvalidOperationException("Input lines did not intersect.");

            if (results == null || results.Size != 1)//没有交点或者交点不是1个
                throw new InvalidOperationException("Could not extract intersection point for lines.");

            IntersectionResult iResult = results.get_Item(0);//取得交点
            XYZ intersectionPoint = iResult.XYZPoint;//取得交点坐标

            return intersectionPoint;
        }



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
        /// 修改20170703：实现圆形风管也可以被智能打断
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
            XYZ point1 = new XYZ(point.X, point.Y, q.Z);
            return point1;
        }
        #endregion
    }
}
