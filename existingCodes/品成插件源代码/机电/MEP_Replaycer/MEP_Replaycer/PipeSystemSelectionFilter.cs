using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.DB.Plumbing;

namespace MEP_Replaycer
{
    class PipeSystemSelectionFilter : ISelectionFilter
    {
        public bool AllowElement(Element element)
        {
            if ((element as MEPCurve) is Pipe)
            {
                if ((element.Location as LocationCurve).Curve is Line)
                {
                    return true;
                }
            }
            if (element.Category.Name == "管件")
            {
                return true;
            }
            return false;
        }
        public bool AllowReference(Reference refer, XYZ point)
        {
            return false;
        }
    }
}

