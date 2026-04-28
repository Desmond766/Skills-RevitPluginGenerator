using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WallColumnLevelBeamFloor
{
    public class LevelElemFilter : ISelectionFilter
    {
        public bool AddWall { get; set; }
        public bool AddColumn { get; set; }
        public LevelElemFilter(bool? addWall, bool? addColumn)
        {
            if (addWall == true) AddWall = true;
            else AddWall = false;
            if (addColumn == true) AddColumn = true;
            else AddColumn = false;
        }
        public bool AllowElement(Element elem)
        {
            if (AddWall && elem is Wall) return true;
            if (AddColumn && elem.Category.Id.IntegerValue == -2001330) return true;
            //if (elem is Wall) return true;
            //else if (elem.Category.Id.IntegerValue == -2001330/* || elem.Category.Id.IntegerValue == -2000100*/)
            //    return true;
            return false;
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            return false;
        }
    }
}
