using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrangeSingleOrMultiplePipeHangersInTheLinkedModel
{
    class SelectionFilter4MEPCurve : ISelectionFilter
    {
        Document linkDoc = null;
        public bool AllowElement(Element element)
        {
            if (element is RevitLinkInstance)
            {
                linkDoc = (element as RevitLinkInstance).GetLinkDocument();
                return true;
            }

            return false;
        }
        public bool AllowReference(Reference refer, XYZ point)
        {
            if (linkDoc.GetElement(refer.LinkedElementId).Category.Id.IntegerValue == (int)BuiltInCategory.OST_CableTray
                || linkDoc.GetElement(refer.LinkedElementId).Category.Id.IntegerValue == (int)BuiltInCategory.OST_DuctCurves
                || linkDoc.GetElement(refer.LinkedElementId).Category.Id.IntegerValue == (int)BuiltInCategory.OST_PipeCurves
                || linkDoc.GetElement(refer.LinkedElementId).Category.Id.IntegerValue == (int)BuiltInCategory.OST_Conduit)
            {
                return true;
            }
            return false;
        }
    }
}
