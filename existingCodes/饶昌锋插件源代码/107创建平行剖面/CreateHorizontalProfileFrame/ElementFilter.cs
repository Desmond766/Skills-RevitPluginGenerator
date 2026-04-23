using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateHorizontalProfileFrame
{
    public class ElementFilter : ISelectionFilter
    {
        public bool AllowElement(Element elem)
        {
            return elem is Wall || elem.Category.Id.IntegerValue == ((int)BuiltInCategory.OST_Doors) || elem.Category.Id.IntegerValue == (int)BuiltInCategory.OST_StructuralFraming;
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            throw new NotImplementedException();
        }
    }
}
