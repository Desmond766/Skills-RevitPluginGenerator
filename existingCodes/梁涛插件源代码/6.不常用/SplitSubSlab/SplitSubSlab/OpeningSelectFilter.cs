using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitSubSlab
{
    internal class OpeningSelectFilter : ISelectionFilter
    {
        public bool AllowElement(Element elem)
        {
            return elem is Opening;
        }
        public bool AllowReference(Reference reference, XYZ position)
        {
            return true;
        }
    }
}
