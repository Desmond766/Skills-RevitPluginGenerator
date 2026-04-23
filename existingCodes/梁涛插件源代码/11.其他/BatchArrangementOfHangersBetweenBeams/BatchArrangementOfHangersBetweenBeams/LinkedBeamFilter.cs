using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;

namespace BatchArrangementOfHangersBetweenBeams
{
    public class LinkedBeamFilter : ISelectionFilter
    {
        Reference reference = null;
        Document linkDoc = null;
        public LinkedBeamFilter(Reference reference)
        {
            this.reference = reference;
        }
        public LinkedBeamFilter() { }

        public bool AllowElement(Element elem)
        {
            if (elem is RevitLinkInstance)
            {
                linkDoc = (elem as RevitLinkInstance).GetLinkDocument();
                return true;
            }

            return false;
        }

        public bool AllowReference(Reference refer, XYZ position)
        {
            if (reference != null && linkDoc.GetElement(refer.LinkedElementId).Category.Id.IntegerValue == (int)BuiltInCategory.OST_StructuralFraming && linkDoc.GetElement(refer.LinkedElementId).Id != linkDoc.GetElement(reference.LinkedElementId).Id)
            {
                return true;
            }
            if (reference == null && linkDoc.GetElement(refer.LinkedElementId).Category.Id.IntegerValue == (int)BuiltInCategory.OST_StructuralFraming)
            {
                return true;
            }
            return false;
        }
    }
}
