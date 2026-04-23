using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DynamicModelUpdate
{
    public class MyListener : IExternalEventHandler
    {
        private readonly Element _element1;
        private readonly Element _element2;
        private readonly Document _doc;
        private XYZ _initialBridge1Position;
        public MyListener(Element element1, Element element2, Document doc,  XYZ initialBridge1Position)
        {
            _element1 = element1;
            _element2 = element2;
            _doc = doc;
            _initialBridge1Position= initialBridge1Position;
        }

        public void Execute(UIApplication app)
        {
            XYZ currentBridge1Position = GetLocationCurveCenterPoint(_element1);
            //TaskDialog.Show("Asdasd", currentBridge1Position.ToString() + "\n" + _initialBridge1Position.ToString());
            XYZ moveDistance = currentBridge1Position - _initialBridge1Position;
            using (Transaction trans = new Transaction(_doc, "Move Bridge 2"))
            {
                trans.Start();
                ElementTransformUtils.MoveElement(_doc, _element2.Id, moveDistance);
                trans.Commit();
            }
            _initialBridge1Position = currentBridge1Position;
        }

        public string GetName()
        {
            return "My Listener";
        }
        private XYZ GetLocationCurveCenterPoint(Element element)
        {
            LocationCurve locationCurve = element.Location as LocationCurve;
            Curve curve = locationCurve.Curve;
            return (curve.GetEndPoint(0)+curve.GetEndPoint(1))/2;
        }
    }

}
