using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetHeightAnalysis
{
    public class FillInfo
    {
        public double Min { get; set; }
        public double Max { get; set; }
        public string FilledRegionTypeName { get; set; }
        public FilledRegionType FilledRegionType { get; set; }
    }
}
