using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitUtils
{
    public static class CurveUtils
    {
        public static Line GetLine(this Element element)
        {
            Line line = null;
            if (element.Location != null && element.Location is LocationCurve locationCurve && locationCurve.Curve is Line line1)
                line = line1;

            return line;
        }
        
        public static double GetDistance(this Element elem1, Element elem2)
        {
            double distance = double.MaxValue;
            XYZ point1 = elem1.GetCreatePoint();
            XYZ point2 = elem2.GetCreatePoint();
            if (point1 != null && point2 != null)
            {
                distance = point1.DistanceTo(point2);
            }
            return distance;
        }
    }
}
