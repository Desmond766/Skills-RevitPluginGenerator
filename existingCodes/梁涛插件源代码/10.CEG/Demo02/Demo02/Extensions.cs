using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;

namespace Demo02
{
    public static class Extensions
    {
        public static Element GetElement(this Reference refe, Document doc)
        {
            return doc.GetElement(refe);
        }
        public static Element GetElement(this ElementId id, Document doc)
        {
            return doc.GetElement(id);
        }
    }
}
