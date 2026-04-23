using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace TagHelper
{
    class Utils
    {

        #region 根据族名称找族
        /// <summary>
        /// 根据族名称找族
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="familyName"></param>
        /// <returns></returns>
        public static Family FindFamilyByName(Document doc, string familyName)
        {
            var collector = new FilteredElementCollector(doc);
            var ids = collector.OfClass(typeof(Family)).ToElementIds();
            foreach (var id in ids)
            {
                if (doc.GetElement(id).Name == familyName)
                {
                    return doc.GetElement(id) as Family;
                }
            }
            return null;
        }
        #endregion


        #region 根据族名称找族下某类型名称ID

        public static ElementId FindTypeIdByFamilyName(Document doc,string familyName)
        {
            Family family = FindFamilyByName(doc, familyName);
            ISet<ElementId> iSetFamily = family.GetFamilySymbolIds();
            List<ElementId> listFamily = new List<ElementId>();
            foreach (var item in iSetFamily)
            {
                listFamily.Add(item);
            }
            ElementId elementId = listFamily[0];
            return elementId;

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
    }
}
