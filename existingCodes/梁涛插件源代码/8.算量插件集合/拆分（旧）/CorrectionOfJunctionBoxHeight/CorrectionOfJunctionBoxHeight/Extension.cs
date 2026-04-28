using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorrectionOfJunctionBoxHeight
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
        public static Element GetLinkElement(this Reference reference, Document doc)
        {
            Element elem = reference.GetElement(doc);
            if (!(elem is RevitLinkInstance)) return null;
            RevitLinkInstance revitLinkInstance = elem as RevitLinkInstance;
            Document linkDoc = revitLinkInstance.GetLinkDocument();
            Element linkElem = reference.LinkedElementId.GetElement(linkDoc);

            return linkElem;
        }
    }
}
