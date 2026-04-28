using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewDoorClearHeight
{
    public class DoorInfo
    {
        public FamilyInstance Door { get; set; }
        public XYZ Point { get; set; }
    }
}
