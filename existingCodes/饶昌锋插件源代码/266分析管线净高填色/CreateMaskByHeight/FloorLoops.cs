using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateMaskByHeight
{
    public class FloorLoops
    {
        private List<CurveLoop> loopsList;
        public List<CurveLoop> LoopsList
        {
            get { return loopsList; }
            set { loopsList = value; }
        }
    }
}
