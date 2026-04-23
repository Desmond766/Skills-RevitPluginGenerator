using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateVerticalBridges
{
    public static class Util
    {
        /// <summary>
        /// 载入插件资源中的族到Revit中
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="data"></param>
        /// <param name="familyName"></param>
        /// <returns></returns>
        public static Family LoadFamily(Document doc, byte[] data, string familyName)
        {
            Family family;
            string tempFilePath = CreateTempFileFromBytes(data, familyName);
            using (Transaction t = new Transaction(doc, "载入族"))
            {
                t.Start();
                doc.LoadFamily(tempFilePath, out family);
                t.Commit();
            }
            return family;
        }
        private static string CreateTempFileFromBytes(byte[] data, string suggestedFileName)
        {
            // 获取临时文件夹路径，并确保文件名以 .rfa 结尾
            string tempDir = Path.GetTempPath();
            string tempFileName = Path.ChangeExtension(suggestedFileName, ".rfa");
            string tempFilePath = Path.Combine(tempDir, tempFileName);

            // 如果目标文件已存在，则删除（可选，根据你的需求决定）
            if (File.Exists(tempFilePath))
            {
                File.Delete(tempFilePath);
            }

            // 将字节数组写入文件
            File.WriteAllBytes(tempFilePath, data);
            return tempFilePath;
        }
        /// <summary>
        /// 获取元素桥架中心点
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static XYZ GetLocationCurveCenterPoint(Element element)
        {
            LocationCurve locationCurve = element.Location as LocationCurve;
            Curve curve = locationCurve.Curve;
            return (curve.GetEndPoint(0) + curve.GetEndPoint(1)) / 2;
        }
        /// <summary>
        /// 获取桥架端点
        /// </summary>
        /// <param name="mEPCurve"></param>
        /// <returns></returns>
        public static XYZ GetEndPoint(this MEPCurve mEPCurve, int i)
        {
            LocationCurve locationCurve = mEPCurve.Location as LocationCurve;
            Curve curve = locationCurve.Curve;
            return curve.GetEndPoint(i);
        }

        /// <summary>
        /// 获取两个桥架相近的两个连接器
        /// </summary>
        /// <param name="element1"></param>
        /// <param name="element2"></param>
        /// <returns></returns>
        public static void GetClosePoint(MEPCurve element1, MEPCurve element2, out Connector conn1, out Connector conn2)
        {
            double minVal = double.MaxValue;
            IList<Connector> connectors = new List<Connector>();
            conn1 = null;
            conn2 = null;
            foreach (Connector con1 in element1.ConnectorManager.Connectors)
            {
                foreach (Connector con2 in element2.ConnectorManager.Connectors)
                {
                    double distance = con1.Origin.DistanceTo(con2.Origin);
                    if (distance < minVal)
                    {
                        minVal = distance;
                        conn1 = con1;
                        conn2 = con2;
                    }
                }
            }
        }
        public static Line GetAlignHorLine(MEPCurve horMep, MEPCurve changeMep)
        {
            GetClosePoint(horMep, changeMep, out var conn1, out var conn2);

            Connector conn0 = conn2.OtherConn();
            if (conn0.Id == 0)
            {
                return Line.CreateBound(conn0.Origin, new XYZ(conn1.Origin.X, conn1.Origin.Y, conn2.Origin.Z));
            }
            else
            {
                return Line.CreateBound(new XYZ(conn1.Origin.X, conn1.Origin.Y, conn2.Origin.Z), conn0.Origin);
            }
        }

        public static Connector OtherConn(this Connector con1)
        {
            Connector con = null;
            CableTray cable = con1.Owner as CableTray;
            foreach (Connector conn in cable.ConnectorManager.Connectors)
            {
                if (conn.Id != con1.Id)
                {
                    con = conn;
                }
            }
            return con;
        }

        /// <summary>
        /// 旋转桥架
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="cableTray"></param>
        /// <param name="element"></param>
        public static void RotatingBridge(Document doc, CableTray cableTray, MEPCurve element, bool createDown, Connector connector = null)
        {
            XYZ northVector = new XYZ(0, 1, 0).Normalize();
            Connector starCon = null;
            Connector endCon = null;
            foreach (Connector item in element.ConnectorManager.Connectors)
            {
                if (item.IsConnected == true)
                {
                    starCon = item;
                }
            }
            if (connector != null) starCon = connector;
            //TaskDialog.Show("revit", (endCon == null).ToString());
            endCon = starCon.OtherConn();
            XYZ rotatingXYZ = (endCon.Origin - starCon.Origin).Normalize();
            //TaskDialog.Show("asd", endCon.Origin + " " + starCon.Origin + " " + rotatingXYZ);
            //TaskDialog.Show("asda", endCon.Origin.ToString()+"   "+starCon.Origin.ToString());
            double angle = rotatingXYZ.AngleTo(northVector);
            if (rotatingXYZ.X < 0)
            {
                angle = -angle;
            }
            if (Math.Abs(1.56414140898657E-15 - Math.Abs(angle)) < 0.0001)
            {
                if (angle>0)
                {
                    angle = 3.1415926536;
                }
                else
                {
                    angle = 0;
                }
                
            }
            //TaskDialog.Show("sad", angle.ToString());
            Curve curve = (cableTray.Location as LocationCurve).Curve;
            //TaskDialog.Show("asdasd",angle.ToString());
            if (createDown) angle = XYZ.BasisY.AngleTo(((element.Location as LocationCurve).Curve as Line).Direction);
            Line axis = Line.CreateBound(curve.GetEndPoint(0), curve.GetEndPoint(1));
            ElementTransformUtils.RotateElement(doc, cableTray.Id, axis, angle);
        }
        public static void RotatingBridge(Document doc, CableTray cableTray, Connector con1, Connector con2)
        {
            XYZ northVector = new XYZ(0, 1, 0).Normalize();
            Connector con = con1.OtherConn();
            CableTray cable = con1.Owner as CableTray;
            XYZ rotatingXYZ = (con1.Origin - con.Origin).Normalize();
            //TaskDialog.Show("asda", endCon.Origin.ToString()+"   "+starCon.Origin.ToString());
            double angle = rotatingXYZ.AngleTo(northVector);
            if (con1.Origin.X > con2.Origin.X)
            {
                angle = -angle;
            }
            Curve curve = (cableTray.Location as LocationCurve).Curve;
            //TaskDialog.Show("asdasd",angle.ToString());
            Line axis = Line.CreateBound(curve.GetEndPoint(0), curve.GetEndPoint(1));
            ElementTransformUtils.RotateElement(doc, cableTray.Id, axis, angle);
        }
    }
}
