using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlippingBeam
{
    public class CompareEvent : IExternalEventHandler
    {
        public ElementId beamId { get; set; }
        public string beamName { get; set; }
        public void Execute(UIApplication app)
        {
            throw new NotImplementedException();
        }

        public string GetName()
        {
            return "CompareEvent";
        }
    }
}
