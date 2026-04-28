using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionWellElevationAdjustment
{
    public class WellInfo
    {
        //public FamilyInstance Well { get; set; }
        //public ElementId WellId { get; set; }
        public string WellTypeName { get; set; }
        public string PipeTypeNames { get; set; }
    }
}
