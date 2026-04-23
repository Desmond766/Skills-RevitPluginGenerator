using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBuilder
{
    /// <summary>
    /// 实现过滤选择接口，过滤砖块
    /// </summary>
    class BrickSelectFilter : ISelectionFilter
    {
        public bool AllowElement(Element elem)
        {
            if (elem is FamilyInstance)
            {
                if (elem.get_Parameter(BuiltInParameter.ELEM_FAMILY_PARAM).AsValueString() == "PC_普通砖_水平")
                {
                    return true;
                }
            }
            return false;
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            return false;
        }
    }
}
