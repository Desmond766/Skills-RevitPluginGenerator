using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using Outline = Autodesk.Revit.DB.Outline;

namespace FindLightPath
{
    public static class Extension
    {
    }
    public static class ElementUtils
    {
        /// <summary>
        /// 根据ID获取元素
        /// </summary>
        /// <param name="elementId"></param>
        /// <param name="doc"></param>
        /// <returns></returns>
        public static Element GetElement(this ElementId elementId, Document doc)
        {
            return doc.GetElement(elementId);
        }
        /// <summary>
        /// 根据引用获取元素
        /// </summary>
        /// <param name="reference"></param>
        /// <param name="doc"></param>
        /// <returns></returns>
        public static Element GetElement(this Reference reference, Document doc)
        {
            return doc.GetElement(reference);
        }
        /// <summary>
        /// 获取链接模型中的元素
        /// </summary>
        /// <param name="reference">链接模型中元素上的一点</param>
        /// <param name="doc"></param>
        /// <returns></returns>
        public static Element GetLinkElement(this Reference reference, Document doc)
        {
            Element linkElem = null;
            Element elem = doc.GetElement(reference);
            if (elem is RevitLinkInstance linkInstance)
            {
                Document linkDoc = linkInstance.GetLinkDocument();
                linkElem = linkDoc.GetElement(reference.LinkedElementId);
            }

            return linkElem;
        }

        /// <summary>
        /// 获取灯具的宿主元素
        /// </summary>
        /// <param name="element"></param>
        /// <param name="doc"></param>
        /// <param name="zDir"></param>
        /// <param name="findHeight"></param>
        /// <returns></returns>
        public static Element GetHostElement(this Element element, Document doc, XYZ zDir, double findHeight)
        {
            Element hostElem = null;

            var boundingBox = element.get_BoundingBox(null);
            XYZ min = boundingBox.Min;
            XYZ max = boundingBox.Max;
            Outline outline = new Outline(min, new XYZ(max.X, max.Y, max.Z + findHeight));

            XYZ cp = element.GetCenterPoint();
            Solid solid = SolidUtils.CreateSolid(XYZ.BasisX, cp, 50 / 304.8, 50 / 304.8, zDir, findHeight);

            List<Element> lightCables = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_CableTray).OfClass(typeof(CableTray)).WherePasses(new BoundingBoxIntersectsFilter(outline))
                .WherePasses(new ElementIntersectsSolidFilter(solid)).ToList();
            lightCables = lightCables.OrderBy(x => x.GetLine().Project(cp).XYZPoint.DistanceTo(cp)).ToList();
            hostElem = lightCables.FirstOrDefault();
            return hostElem;
        }
    }
    public static class CurveUtils
    {
        public static Line GetLine(this Element element)
        {
            Line line = null;
            if (element.Location != null && element.Location is LocationCurve locationCurve && locationCurve.Curve is Line line1)
                line = line1;

            return line;
        }
        public static XYZ GetCenterPoint(this Element element)
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
        public static double GetDistance(this Element elem1, Element elem2)
        {
            double distance = double.MaxValue;
            XYZ point1 = elem1.GetCenterPoint();
            XYZ point2 = elem2.GetCenterPoint();
            if (point1 != null && point2 != null)
            {
                distance = point1.DistanceTo(point2);
            }
            return distance;
        }
    }
    public static class SolidUtils
    {
        public static Solid CreateSolid(this Element elem, double halfWidth, double halfLength, XYZ zDir, double height)
        {
            Solid solid;

            XYZ lineDir = elem.GetLine().Direction;
            XYZ verDir = elem.GetVerDireciton();
            XYZ cp = elem.GetCenterPoint();

            solid = CreateSolid(lineDir, cp, halfWidth, halfLength, zDir, height);

            //XYZ p1 = cp + lineDir * halfLength + verDir * halfWidth;
            //XYZ p2 = cp + lineDir * halfLength - verDir * halfWidth;
            //XYZ p3 = cp - lineDir * halfLength - verDir * halfWidth;
            //XYZ p4 = cp - lineDir * halfLength + verDir * halfWidth;

            ////放样
            //List<CurveLoop> loops = new List<CurveLoop>();
            //List<Curve> curveList = new List<Curve> { Line.CreateBound(p1, p2), Line.CreateBound(p2, p3), Line.CreateBound(p3, p4), Line.CreateBound(p4, p1) };
            //CurveLoop curveLoop = CurveLoop.Create(curveList);
            //loops.Add(curveLoop);
            ////拉伸
            //solid = GeometryCreationUtilities.CreateExtrusionGeometry(loops, zDir, height);
            return solid;
        }
        public static Solid CreateSolid(this XYZ elemDir, XYZ elemPoint, double halfWidth, double halfLength, XYZ zDir, double height)
        {
            Solid solid;

            XYZ lineDir = elemDir;
            XYZ verDir = lineDir.GetVerDireciton();
            XYZ cp = elemPoint;

            XYZ p1 = cp + lineDir * halfLength + verDir * halfWidth;
            XYZ p2 = cp + lineDir * halfLength - verDir * halfWidth;
            XYZ p3 = cp - lineDir * halfLength - verDir * halfWidth;
            XYZ p4 = cp - lineDir * halfLength + verDir * halfWidth;

            //放样
            List<CurveLoop> loops = new List<CurveLoop>();
            List<Curve> curveList = new List<Curve> { Line.CreateBound(p1, p2), Line.CreateBound(p2, p3), Line.CreateBound(p3, p4), Line.CreateBound(p4, p1) };
            CurveLoop curveLoop = CurveLoop.Create(curveList);
            loops.Add(curveLoop);
            //拉伸
            solid = GeometryCreationUtilities.CreateExtrusionGeometry(loops, zDir, height);
            return solid;
        }
    }
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
    }
}
