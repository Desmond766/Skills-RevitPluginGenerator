using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitUtils
{
    public static class XYZUtils
    {
        /// <summary>
        /// 获取与某一个方向垂直的方向(在XY轴平面)
        /// </summary>
        /// <param name="elem"></param>
        /// <returns></returns>
        public static XYZ GetVerDireciton(this Element elem)
        {
            XYZ verDir = null;
            if (elem.Location != null && elem.Location is LocationCurve locationCurve && locationCurve.Curve is Line line)
            {
                XYZ lineDir = line.Direction;
                XYZ p0 = line.GetEndPoint(0);
                XYZ p1 = line.GetEndPoint(1);
                XYZ centerP = p0.Add(p1) / 2;

                XYZ vertical1 = p0.CrossProduct(p1);
                verDir = new XYZ(vertical1.X, vertical1.Y, lineDir.Z).Normalize();
            }

            return verDir;
        }

        public static XYZ GetVerDireciton(this XYZ elemDir)
        {
            XYZ verDir = null;
            XYZ lineDir = elemDir;
            XYZ p0 = new XYZ(1, 1, 1);
            XYZ p1 = p0 + lineDir * 2;

            XYZ vertical1 = p0.CrossProduct(p1);
            verDir = new XYZ(vertical1.X, vertical1.Y, lineDir.Z).Normalize();

            return verDir;
        }

        public static XYZ GetCreatePoint(this Element element)
        {
            XYZ point = null;
            Location location = element.Location;
            if (location == null) return point;
            if (location is LocationPoint locationPoint)
            {
                point = locationPoint.Point;
            }
            else if (location is LocationCurve locationCurve)
            {
                point = locationCurve.Curve.GetEndPoint(0).Add(locationCurve.Curve.GetEndPoint(1)) / 2;
            }
            else
            {

            }

            return point;
        }
        public static bool IsVertical(MEPCurve mEPCurve, double tolerance)
        {
            foreach (Connector con in mEPCurve.ConnectorManager.Connectors)
            {
                if (con.CoordinateSystem.BasisZ.IsAlmostEqualTo(XYZ.BasisZ, tolerance) || con.CoordinateSystem.BasisZ.Negate().IsAlmostEqualTo(XYZ.BasisZ, tolerance))
                {
                    return true;
                }
            }  
            return false;
        }
    }
}
