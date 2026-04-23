using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetHeightAnalysis
{
    public class ClearHeightInfo
    {
        public ElementId ElementId { get; set; }
        public ElementId FloorId { get; set; }
        public XYZ FloorPos { get; set; }
        public string ElementType { get; set; }
        public double ClearHeight { get; set; }
        public IList<CurveLoop> Loops { get; set; }
        public string Color { get; set; }
        public ClearHeightInfo(ElementId elementId, ElementId floorId, XYZ floorPos, string elementType, double clearHeight, IList<CurveLoop> loops)
        {
            ElementId = elementId;
            FloorId = floorId;
            FloorPos = floorPos;
            ElementType = elementType;
            ClearHeight = clearHeight;
            Loops = loops;
        }
    }
}
