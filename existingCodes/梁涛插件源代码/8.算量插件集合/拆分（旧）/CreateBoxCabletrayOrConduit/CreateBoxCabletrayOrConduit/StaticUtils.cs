using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateBoxCabletrayOrConduit
{
    public static class StaticUtils
    {
        public static XYZ GetDirection(this Element element)
        {
            if (element.Location is LocationCurve locationCurve)
            {
                Line line = locationCurve.Curve as Line;
                return line.Direction;
            }
            return null;
        }
        public static Line GetLine(this Element element)
        {
            if (element.Location is LocationCurve locationCurve)
            {
                return locationCurve.Curve as Line;
            }
            return null;
        }
        public static Connector GetConnector(this MEPCurve mEPCurve, int id)
        {
            foreach (Connector item in mEPCurve.ConnectorManager.Connectors)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null; ;
        }
    }
}
