using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangerAlignment
{
    public class HangerFilter : ISelectionFilter
    {
        public bool AllowElement(Element elem)
        {
            bool flag = elem.Category.Id.IntegerValue == (int)BuiltInCategory.OST_MechanicalEquipment || elem.Name== "风管法兰吊架-上固定" || elem.Name == "风管法兰吊架-下固定";
            return flag;
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            return true;
        }
    }
}
