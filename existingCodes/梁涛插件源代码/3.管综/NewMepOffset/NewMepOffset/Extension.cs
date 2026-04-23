using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewMepOffset
{
    public static class Extension
    {
        /// <summary>
        /// 获取创建管线的中心线
        /// </summary>
        /// <param name="mEPCurve"></param>
        /// <returns></returns>
        public static Line GetLine(this MEPCurve mEPCurve)
        {
            Line line;
            line = (mEPCurve.Location as LocationCurve).Curve as Line;
            return line;
        }
        /// <summary>
        /// 获取管线的连接器
        /// </summary>
        /// <param name="elem"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static Connector GetConnector(this Element elem, int i)
        {
            Connector connector = null;

            if (elem is MEPCurve mEPCurve)
            {
                foreach (Connector con in mEPCurve.ConnectorManager.Connectors)
                {
                    if (con.Id == i)
                    {
                        connector = con;
                        break;
                    }
                }
            }
            else if (elem is FamilyInstance familyInstance)
            {
                foreach (Connector con in familyInstance.MEPModel.ConnectorManager.Connectors)
                {
                    if (con.Id == i)
                    {
                        connector = con;
                        break;
                    }
                }
            }

            
            return connector;
        }
        public static Connector GetConnector(this Element elem, int? i)
        {
            Connector connector = null;

            if (elem is MEPCurve mEPCurve)
            {
                foreach (Connector con in mEPCurve.ConnectorManager.Connectors)
                {
                    if (con.Id == i)
                    {
                        connector = con;
                        break;
                    }
                }
            }
            else if (elem is FamilyInstance familyInstance)
            {
                foreach (Connector con in familyInstance.MEPModel.ConnectorManager.Connectors)
                {
                    if (con.Id == i)
                    {
                        connector = con;
                        break;
                    }
                }
            }


            return connector;
        }
        /// <summary>
        /// 判断管线连接器是否与其他元素的连接器相连，若存在则返回相连元素与其连接器ID
        /// </summary>
        /// <param name="mEPCurve"></param>
        /// <param name="i"></param>
        /// <param name="conElem"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        public static bool IsConnect(this Element elem,int i, out Element conElem, out int? j)
        {
            bool connect = false;
            conElem = null;
            j = null;
            if (elem is MEPCurve mEPCurve)
            {
                foreach (Connector con in mEPCurve.ConnectorManager.Connectors)
                {
                    if (con.Id == i)
                    {
                        if (!con.IsConnected) break;
                        Connector findCon = con.AllRefs.Cast<Connector>().FirstOrDefault(x => x.Owner.Id != elem.Id);
                        if (findCon == null) break;
                        conElem = findCon.Owner;
                        j = findCon.Id;
                        connect = true;
                        break;
                    }
                }
            }else if (elem is FamilyInstance familyInstance)
            {
                foreach (Connector con in familyInstance.MEPModel.ConnectorManager.Connectors)
                {
                    if (con.Id == i)
                    {
                        if (!con.IsConnected) break;
                        Connector findCon = con.AllRefs.Cast<Connector>().FirstOrDefault(x => x.Owner.Id != elem.Id);
                        if (findCon == null) break;
                        conElem = findCon.Owner;
                        j = findCon.Id;
                        connect = true;
                        break;
                    }
                }
            }


            return connect;
        }
        public static Connector GetNearUnConConnector(this Connector elemCon ,MEPCurve mEPCurve)
        {
            Connector con = null;
            double minValue = double.MaxValue;
            foreach (Connector conn in mEPCurve.ConnectorManager.Connectors)
            {
                if (!conn.IsConnected && conn.Origin.DistanceTo(elemCon.Origin) < minValue)
                {
                    minValue = conn.Origin.DistanceTo(elemCon.Origin);
                    con = conn;
                }
            }

            return con;
        }
        public static MEPCurve GetNearMep(this XYZ point, MEPCurve mEPCurve1, MEPCurve mEPCurve2)
        {
            MEPCurve nearMep = null;
            double minValue = double.MaxValue;
            foreach (Connector item in mEPCurve1.ConnectorManager.Connectors)
            {
                if (item.Origin.DistanceTo(point) < minValue)
                {
                    minValue = item.Origin.DistanceTo(point);
                    nearMep = mEPCurve1;
                }
            }
            foreach (Connector item in mEPCurve2.ConnectorManager.Connectors)
            {
                if (item.Origin.DistanceTo(point) < minValue)
                {
                    minValue = item.Origin.DistanceTo(point);
                    nearMep = mEPCurve2;
                }
            }


            return nearMep;
        }
    }
}
