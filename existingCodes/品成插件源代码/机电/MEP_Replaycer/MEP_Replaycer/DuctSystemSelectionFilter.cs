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

namespace MEP_Replaycer
{
    class DuctSystemSelectionFilter : ISelectionFilter
    {
        public bool AllowElement(Element element)
        {
            if ((element as MEPCurve) is Duct)
            {
                if ((element.Location as LocationCurve).Curve is Line)
                {
                    return true;
                }
            }
            if (element.Category.Name == "风管管件")
            {
                return true;
            }
            if (element.Category.Name == "风管附件")
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
