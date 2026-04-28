using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEGShopTicketHelper.AutoTicketingHelper
{
    public class EmbedFilter : ISelectionFilter
    {
        public bool AllowElement(Element elem)
        {
            if (elem == null) { return false; }
            if (!(elem is FamilyInstance)) { return false; }
            return elem.Category.Id.IntegerValue == (int)BuiltInCategory.OST_SpecialityEquipment;
            //return elem is FamilyInstance;
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            return true;
        }
    }
}
