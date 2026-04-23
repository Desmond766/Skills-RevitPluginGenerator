using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEGRegister
{
    class SelectionFilter4MEPCurve : ISelectionFilter
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
