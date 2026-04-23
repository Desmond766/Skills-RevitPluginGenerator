using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrangeHangerAccordingToNozzle
{
    public class PipeFilter : ISelectionFilter
    {
        public bool AllowElement(Element elem)
        {
            MEPCurve mEPCurve = elem as MEPCurve;
            XYZ p0 = (mEPCurve.Location as LocationCurve).Curve.GetEndPoint(0);
            XYZ p1 = (mEPCurve.Location as LocationCurve).Curve.GetEndPoint(1);
            double x = Math.Abs(p0.Z - p1.Z);
            if (elem is Pipe && x > 0.001)
            {
                return true;
            }
            return false;
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            return false;
        }
    }
}
