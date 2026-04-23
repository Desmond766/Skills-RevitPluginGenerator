using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParameterizedMEPCurveLayout
{
    /// <summary>
    /// 框选过滤器 过滤MEPCurve
    /// </summary>
    internal class MEPCurveFilter : ISelectionFilter
    {
        public bool AllowElement(Element elem)
        {
            return elem is MEPCurve;
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            return true;
        }
    }
}
