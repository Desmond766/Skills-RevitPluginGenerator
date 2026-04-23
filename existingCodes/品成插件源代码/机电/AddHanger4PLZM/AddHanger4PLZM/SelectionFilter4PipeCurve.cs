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

namespace AddHanger4PLZM
{
    class SelectionFilter4PipeCurve : ISelectionFilter
    {
        public bool AllowElement(Element elem)
        {
            if ( elem.Category.Id.IntegerValue == (int)BuiltInCategory.OST_PipeCurves)
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
