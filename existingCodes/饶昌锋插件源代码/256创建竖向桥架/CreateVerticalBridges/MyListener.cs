using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CreateVerticalBridges
{
    public class MyListener : IExternalEventHandler
    {
        private readonly Element _element1;
        private readonly Element _element2;
        private readonly Document _doc;
        private XYZ _initialBridge1Position;
        private double _initialLength;
        public MyListener(Element element1, Element element2, Document doc, XYZ initialBridge1Position, double initialLength)
        {
            _element1 = element1;
            _element2 = element2;
            _doc = doc;
            _initialBridge1Position = initialBridge1Position;
            _initialLength = initialLength;
        }

        public void Execute(UIApplication app)
        {
            //获取当前桥架长度
            double currentLength = _element1.get_Parameter(BuiltInParameter.CURVE_ELEM_LENGTH).AsDouble();
            //TaskDialog.Show("asdas", currentLength.ToString() + "\n" + _initialLength.ToString());
            //判断创建的竖向桥架长度 长度变化走false 不变化走true
            if (Math.Abs(currentLength - _initialLength) < 0.000001)
            {
                //获取当前中心点并移动对应的元素
                XYZ currentBridge1Position = Util.GetLocationCurveCenterPoint(_element1);
                XYZ moveDistance = currentBridge1Position - _initialBridge1Position;
                using (Transaction trans = new Transaction(_doc, "Move Bridge 2"))
                {
                    trans.Start();
                    ElementTransformUtils.MoveElement(_doc, _element2.Id, moveDistance);
                    trans.Commit();
                }
                //改变初始值
                _initialBridge1Position = currentBridge1Position;
            }
            else
            {
                //改变初始值
                _initialLength = currentLength;
            }

        }

        public string GetName()
        {
            return "My Listener";
        }
    }
}
