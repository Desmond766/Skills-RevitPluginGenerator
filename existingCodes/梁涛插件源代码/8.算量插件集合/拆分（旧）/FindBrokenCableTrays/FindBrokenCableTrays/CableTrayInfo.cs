using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindBrokenCableTrays
{
    public class CableTrayInfo
    {
        public ElementId CableTrayId { get; set; }
        public string CableTrayName { get; set; }
    }
}
