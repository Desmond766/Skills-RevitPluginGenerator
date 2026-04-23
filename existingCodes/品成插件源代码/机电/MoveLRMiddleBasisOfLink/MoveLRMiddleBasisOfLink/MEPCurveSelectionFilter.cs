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

namespace MoveLRMiddleBasisOfLink
{
    class MEPCurveSelectionFilter : ISelectionFilter
    {
        public bool AllowElement(Element element)
        {
            if (element.Category.Id.IntegerValue == (int)BuiltInCategory.OST_CableTray
               || element.Category.Id.IntegerValue == (int)BuiltInCategory.OST_DuctCurves
               || element.Category.Id.IntegerValue == (int)BuiltInCategory.OST_PipeCurves
               || element.Category.Id.IntegerValue == (int)BuiltInCategory.OST_Conduit)
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
