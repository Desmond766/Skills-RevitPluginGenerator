using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CreateDimensions
{
    internal class LinkedBeamWallFilter : ISelectionFilter
    {
        Document linkDoc = null;
        public bool AllowElement(Element elem)
        {
            if (elem is RevitLinkInstance)
            {
                linkDoc = (elem as RevitLinkInstance).GetLinkDocument();
                return true;
            }

            return false;
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            if (linkDoc.GetElement(reference.LinkedElementId).Category.Id.IntegerValue == (int)BuiltInCategory.OST_Walls
                || linkDoc.GetElement(reference.LinkedElementId).Category.Id.IntegerValue == (int)BuiltInCategory.OST_StructuralFraming 
                || linkDoc.GetElement(reference.LinkedElementId).Category.Id.IntegerValue == (int)BuiltInCategory.OST_StructuralColumns)
            {
                return true;
            }
            return false;
        }
    }
}
