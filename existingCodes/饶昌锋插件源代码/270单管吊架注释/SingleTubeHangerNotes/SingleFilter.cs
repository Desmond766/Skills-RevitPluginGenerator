using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleTubeHangerNotes
{
    public class SingleFilter : ISelectionFilter
    {
        public bool AllowElement(Element elem)
        {
            return elem.Name == "单管吊架";
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            throw new NotImplementedException();
        }
    }
}
