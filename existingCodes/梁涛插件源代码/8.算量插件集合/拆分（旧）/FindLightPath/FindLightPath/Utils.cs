using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.DB.Macros;

namespace FindLightPath
{
    public static class CpoyUtils
    {
        /// <summary>
        /// 判断集合中是否包含该连接器
        /// </summary>
        /// <param name="createInfos"></param>
        /// <param name="connector"></param>
        /// <returns></returns>
        public static bool IsContains(this List<Connector> createInfos, Connector connector)
        {
            foreach (var item in createInfos)
            {
                if (item.Id == connector.Id && item.Owner.Id == connector.Owner.Id)
                {
                    return true;
                }
            }
            return false;
        }
        public static XYZ GetProjectionPoint(this XYZ point, Line line)
        {
            return line.Project(point).XYZPoint;
        }
        // 判断使用Line创建的族实例是否垂直
        public static bool IsVertical(this Element element)
        {
            if (element.Location is LocationCurve curve)
            {
                XYZ dir = (curve.Curve as Line).Direction;
                if (dir.IsAlmostEqualTo(XYZ.BasisZ, 0.26) || dir.IsAlmostEqualTo(XYZ.BasisZ.Negate(), 0.26))
                {
                    return true;
                }
            }
            return false;
        }
        // 获取MEPCurve类族实例的Line
        public static Line GetLine(this MEPCurve mEPCurve)
        {
            Line line = null;
            if (mEPCurve.Location is LocationCurve)
            {
                line = (mEPCurve.Location as LocationCurve).Curve as Line;
            }
            return line;
        }
        // 将Line的Z轴变为0
        public static Line ZeroZ(this Line line)
        {
            Line newLine = null;

            XYZ p0 = line.GetEndPoint(0);
            XYZ p1 = line.GetEndPoint(1);
            newLine = Line.CreateBound(new XYZ(p0.X, p0.Y, 0), new XYZ(p1.X, p1.Y, 0));

            return newLine;
        }
        /// <summary>
        /// 判断坐标点是否在该线段上
        /// </summary>
        /// <param name="point">坐标点</param>
        /// <param name="line">线段</param>
        /// <returns></returns>
        public static bool IsPointOnLine(this XYZ point, Line line)
        {
            XYZ p0 = line.GetEndPoint(0);
            XYZ p1 = line.GetEndPoint(1);
            //TaskDialog.Show("TEST", line.Direction + "\n" + (point - p0).Normalize() + "\n" + p0.DistanceTo(point) * 304.8 + "\n" + p0.DistanceTo(p1) * 304.8 + "\n" + point.DistanceTo(p0) * 304.8 + "\n" + point.DistanceTo(p1) * 304.8);
            //判断是否平行的误差为5度
            if (line.Direction.IsAlmostEqualTo((point - p0).Normalize(), 0.088) && p0.DistanceTo(point) < p0.DistanceTo(p1) && point.DistanceTo(p0) > 20 / 304.8 && point.DistanceTo(p1) > 20 / 304.8)
            {
                return true;
            }
            return false;
        }
        public static T PickObject<T>(this UIDocument uIDoc)
        {
            Selection sel = uIDoc.Selection;
            Document doc = uIDoc.Document;

            Element element = sel.PickObject(ObjectType.Element).GetElement(doc);
            T tElem = (T)Convert.ChangeType(element, typeof(T));
            return tElem;
        }
        /// <summary>
        /// 获得MepCurve上离该连接器最近的连接器
        /// </summary>
        /// <returns></returns>
        public static Connector GetNearConnector(this Connector mainCon, MEPCurve mEPCurve)
        {
            Connector connector = null;
            double minDis = double.MaxValue;
            foreach (Connector con in mEPCurve.ConnectorManager.Connectors)
            {
                if (mainCon.Origin.DistanceTo(con.Origin) < minDis)
                {
                    connector = con;
                    minDis = mainCon.Origin.DistanceTo(con.Origin);
                }
            }
            return connector;
        }
        public static CableTray GetNearCableTray(this Connector con, List<CableTray> cableTrays, out Connector nearCon)
        {
            CableTray cableTray = null;
            double minDis = double.MaxValue;
            XYZ p = con.Origin;
            nearCon = null;

            //List<CableTray> filterCables = new List<CableTray>();
            //filterCables = cableTrays.Where(x => p.IsPointOnLine(x.GetLine())).ToList();
            //if (filterCables.Count > 0)
            //{
            //    foreach (var item in filterCables)
            //    {
            //        foreach (Connector connector in item.ConnectorManager.Connectors)
            //        {
            //            double dis = connector.Origin.DistanceTo(p);
            //            if (dis < minDis)
            //            {
            //                cableTray = item;
            //                minDis = dis;
            //                nearCon = connector;
            //            }
            //        }
            //    }
            //}
            //else
            //{
            //    foreach (var item in cableTrays)
            //    {
            //        foreach (Connector connector in item.ConnectorManager.Connectors)
            //        {
            //            double dis = connector.Origin.DistanceTo(p);
            //            if (dis < minDis)
            //            {
            //                cableTray = item;
            //                minDis = dis;
            //                nearCon = connector;
            //            }
            //        }
            //    }
            //}
            foreach (var item in cableTrays)
            {
                Line line = (item.Location as LocationCurve).Curve as Line;
                XYZ pp = line.Project(p).XYZPoint;
                double dis = pp.DistanceTo(p);
                if (dis < minDis)
                {
                    cableTray = item;
                    minDis = dis;
                    nearCon = item.ConnectorManager.Connectors.Cast<Connector>().OrderBy(c => c.Origin.DistanceTo(pp)).First();
                }
            }
            return cableTray;
        }
        //public static Element GetElement(this Reference reference, Document doc)
        //{
        //    Element element = doc.GetElement(reference);
        //    return element;
        //} 
        //public static Element GetElement(this ElementId id, Document doc)
        //{
        //    Element element = doc.GetElement(id);
        //    return element;
        //}
        public static double GetZDis(this Element element, double Z)
        {
            double distance = double.MaxValue;
            if (element.Location is LocationCurve locationCurve)
            {
                double z = locationCurve.Curve.GetEndPoint(0).Z;
                distance = Math.Abs(z - Z);
            }
            else if (element.Location is LocationPoint point)
            {
                double z = point.Point.Z;
                distance = Math.Abs(z - Z);
            }
            return distance;
        }
        // 获取连接器
        public static Connector GetConnector(this Element elem, int i)
        {
            Connector connector = null;
            if (elem is FamilyInstance instance)
            {
                var manager = instance.MEPModel.ConnectorManager;
                if (manager == null) return null;
                foreach (Connector con in manager.Connectors)
                {
                    if (con.Id == i)
                    {
                        return con;
                    }
                }
            }
            else if (elem is MEPCurve ePCurve)
            {
                foreach (Connector con in ePCurve.ConnectorManager.Connectors)
                {
                    if (con.Id == i)
                    {
                        return con;
                    }
                }
            }


            return connector;
        }
        // 打断管道（方法内部无事务）
        public static ElementId BreakCurve(this MEPCurve mEPCurve, XYZ breakPoint, Document doc)
        {
            Line line = (mEPCurve.Location as LocationCurve).Curve as Line;
            Line newLine1 = Line.CreateBound(line.GetEndPoint(0), breakPoint);
            Line newLine2 = Line.CreateBound(breakPoint, line.GetEndPoint(1));
            var newMepCurve = ElementTransformUtils.CopyElement(doc, mEPCurve.Id, new XYZ());
            (mEPCurve.Location as LocationCurve).Curve = newLine1;;
            (newMepCurve.First().GetElement(doc).Location as LocationCurve).Curve = newLine2;

            return newMepCurve.First();
        }
        /// <summary>
        /// 获取拓扑线对一个桥架族实例的type类型名称
        /// </summary>
        /// <param name="doc">文档</param>
        /// <param name="conduitId">拓扑线ID</param>
        /// <returns></returns>
        public static string GetTypeName(this Document doc, ElementId conduitId)
        {
            
            Element tuopuLine = doc.GetElement(conduitId);
            

            ElementId id = null;
            try
            {
                int cableId = tuopuLine.LookupParameter("对应桥架ID").AsInteger();
                id = new ElementId(cableId);
            }
            catch (Exception)
            {
                return null;
            }

            Element cableTray = doc.GetElement(id);
            Element type = doc.GetElement(cableTray.GetTypeId());
            return type.Name;
        }
        /// <summary>
        /// 判断某个桥架在当前视图中是否被隐藏
        /// </summary>
        /// <param name="elem"></param>
        /// <param name="view"></param>
        /// <returns></returns>
        public static bool IsHidden(this CableTray cableTray, Document doc)
        {
            using (var cableCol = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_CableTray).OfClass(typeof(CableTray)))
            {
                foreach (var item in cableCol)
                {
                    if (cableTray.Id == item.Id)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
