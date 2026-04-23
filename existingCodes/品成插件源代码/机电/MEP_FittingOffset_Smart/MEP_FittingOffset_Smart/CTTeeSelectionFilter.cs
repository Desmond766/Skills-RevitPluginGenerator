using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI.Selection;

namespace MEP_FittingOffset_Smart
{
    class CTTeeSelectionFilter : ISelectionFilter
    {

        public bool AllowElement(Element elem)
        {
            if ((elem as FamilyInstance).Symbol.Family.Name=="槽式电缆桥架水平三通")
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
