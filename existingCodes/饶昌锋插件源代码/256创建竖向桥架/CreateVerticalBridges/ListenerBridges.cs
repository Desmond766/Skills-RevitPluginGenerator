using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Events;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Events;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Controls;
using System.Xml.Linq;

namespace CreateVerticalBridges
{
    public class ListenerBridges
    {
        private Stopwatch stopwatch;
        private ExternalEvent myListenerEvent;
        private Element _element1;
        private Element _element2;
        private UIApplication _uiApp;
        public ListenerBridges(Element element1, Element element2, UIApplication uiApp)
        {
            _element1 = element1;
            _element2 = element2;
            _uiApp = uiApp;
        }
        public bool Executer()
        {
            UIDocument uidoc = _uiApp.ActiveUIDocument;
            Document doc = uidoc.Document;
            //Reference reference1 = uidoc.Selection.PickObject(ObjectType.Element, "请选择主桥架(被垂直的桥架)");
            //_element1 = doc.GetElement(reference1) as MEPCurve;
            //Reference reference2 = uidoc.Selection.PickObject(ObjectType.Element, "请选择支线桥架");
            //_element2 = doc.GetElement(reference2) as MEPCurve;
            //获取移动前的中心点
            XYZ initialBridge1Position = Util.GetLocationCurveCenterPoint(_element1);
            double initialLength = _element1.get_Parameter(BuiltInParameter.CURVE_ELEM_LENGTH).AsDouble();
            //创建监听器
            MyListener myListener = new MyListener(_element1, _element2, doc, initialBridge1Position, initialLength);
            myListenerEvent = ExternalEvent.Create(myListener);
            //创建延时器
            stopwatch = new Stopwatch();
            _uiApp.Idling += UiApp_Idling;
            _uiApp.Application.DocumentChanged += MyListenerEventHandler;
            return true;
        }


        /// <summary>
        /// 延时器  一定时间后关闭监听器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UiApp_Idling(object sender, IdlingEventArgs e)
        {
            if (!stopwatch.IsRunning)
            {
                stopwatch.Start();
            }
            else
            {
                //5分钟
                if (stopwatch.ElapsedMilliseconds >= 300000)
                {
                    // 如果已经过去了一定时间，就停止计时器，并在Revit中弹出一个提示框
                    //TaskDialog.Show("提示", "监听器已关闭！");
                    _uiApp.Application.DocumentChanged -= MyListenerEventHandler;
                    stopwatch.Reset();
                    _uiApp.Idling -= UiApp_Idling;
                }
            }
        }
        /// <summary>
        /// 监听器 监听指定元素
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyListenerEventHandler(object sender, DocumentChangedEventArgs e)
        {
            ICollection<ElementId> modifiedElementIds = e.GetModifiedElementIds();
            foreach (ElementId item in modifiedElementIds)
            {
                if (item == _element1.Id)
                {
                    myListenerEvent.Raise();
                }
            }
        }




    }
}
