using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerticalPipeElevationAdjustment
{
    public class MepCurveFilter : ISelectionFilter
    {
        public bool AllowElement(Element elem)
        {
            if (elem is Pipe || elem is Conduit || elem is CableTray)
            {
                XYZ dir = ((elem.Location as LocationCurve).Curve as Line).Direction;
                if (dir.IsAlmostEqualTo(XYZ.BasisZ) || dir.IsAlmostEqualTo(XYZ.BasisZ.Negate()))
                {
                    return true;
                }
            }return false;
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            return false;
        }
    }
}
