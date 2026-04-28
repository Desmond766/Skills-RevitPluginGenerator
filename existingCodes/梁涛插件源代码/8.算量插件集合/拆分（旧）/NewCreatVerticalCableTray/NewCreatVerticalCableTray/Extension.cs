using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCreatVerticalCableTray
{
    public static class Extension
    {
        public static Element GetElement(this ElementId elementId, Document doc)
        {
            return doc.GetElement(elementId);
        }
        public static Element GetElement(this Reference reference, Document doc)
        {
            return doc.GetElement(reference);
        }
        public static Connector GetConnector(this Element ebOrCable, int i)
        {
            Connector connector = null;
            if (ebOrCable is FamilyInstance familyInstance)
            {
                foreach (Connector con in familyInstance.MEPModel.ConnectorManager.Connectors)
                {
                    if (con.Id == i)
                    {
                        connector = con;
                        break;
                    }
                }
            }
            else if (ebOrCable is MEPCurve ePCurve)
            {
                foreach (Connector con in ePCurve.ConnectorManager.Connectors)
                {
                    if (con.Id == i)
                    {
                        connector = con;
                        break;
                    }
                }
            }
            return connector;
        }
    }
}
