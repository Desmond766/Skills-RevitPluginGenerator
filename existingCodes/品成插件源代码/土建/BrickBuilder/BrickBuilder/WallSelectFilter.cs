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
    /// 实现过滤选择接口，过滤建筑墙
    /// </summary>
    class WallSelectFilter : ISelectionFilter
    {
        public bool AllowElement(Element elem)
        {
            if (elem is Wall)
            {
                if (elem.get_Parameter(BuiltInParameter.WALL_STRUCTURAL_USAGE_PARAM).AsInteger() == 0)
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
