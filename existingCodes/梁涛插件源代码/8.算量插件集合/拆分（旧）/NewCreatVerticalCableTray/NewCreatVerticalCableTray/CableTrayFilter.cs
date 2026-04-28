using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCreatVerticalCableTray
{
    public class CableTrayFilter : ISelectionFilter
    {
        public bool AllowElement(Element elem)
        {
            if (elem is CableTray) return true;
            return false;
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            throw new NotImplementedException();
        }
    }
}
