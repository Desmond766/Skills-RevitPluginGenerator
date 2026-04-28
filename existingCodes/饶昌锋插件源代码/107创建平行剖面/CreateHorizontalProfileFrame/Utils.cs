using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateHorizontalProfileFrame
{
    public static class Utils
    {
        public static XYZ GetMEPCurveCentrePoint(this Element elem)
        {
            LocationCurve locationCurve = elem.Location as LocationCurve;
            Curve curve = locationCurve.Curve;
            XYZ centerPoint = curve.Evaluate(0.5, true);
            return centerPoint;
        }
        public static double GetElementLength(this Element elem)
        {
            LocationCurve locationCurve = elem.Location as LocationCurve;
            double lenght = locationCurve.Curve.Length;
            return lenght;
        }

        public static Element GetElement(this Reference reference, Document doc)
        {
            Element elem = doc.GetElement(reference);
            return elem;
        }
        public static string IsHorizontal(this Element elem)
        {
            XYZ startPoint = (elem.Location as LocationCurve).Curve.GetEndPoint(0);
            XYZ endPoint = (elem.Location as LocationCurve).Curve.GetEndPoint(1);

            if (Math.Abs(startPoint.X - endPoint.X) < 0.000001)
            {
                return "vertical";
            }
            else if (Math.Abs(startPoint.Y - endPoint.Y) < 0.000001)
            {
                return "horizontal";
            }
            return null;

        }
    }
}
