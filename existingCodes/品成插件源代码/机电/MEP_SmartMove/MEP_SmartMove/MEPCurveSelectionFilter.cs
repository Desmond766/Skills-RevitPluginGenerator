using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEP_SmartMove
{
    public class MEPCurveSelectionFilter : ISelectionFilter
    {
        public bool AllowElement(Element element)
        {
            if (element is MEPCurve)
            {
                if ((element.Location as LocationCurve).Curve is Line)
                {
                    return true;
                }
            }
            return false;
        }
        public bool AllowReference(Reference refer, XYZ point)
        {
            return false;
        }
    }
}
