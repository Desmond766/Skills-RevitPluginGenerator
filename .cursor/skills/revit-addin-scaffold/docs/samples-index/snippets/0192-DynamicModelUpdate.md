# Sample Snippet: DynamicModelUpdate

Source project: `existingCodes\饶昌锋插件源代码\258吊架分类编号并标记\HangerClassificationAnnotation\DynamicModelUpdate`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## UpdateCommand.cs

```csharp
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicModelUpdate
{
    [Transaction(TransactionMode.Manual)]
    public class UpdateCommand : IExternalCommand
    {
        public static ChangeType ChangeType;
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Document doc = commandData.Application.ActiveUIDocument.Document;
            MyUpdater myUpdater = new MyUpdater(commandData.Application.ActiveAddInId);
            if (UpdaterRegistry.IsUpdaterRegistered(myUpdater.GetUpdaterId(),doc))
            {
                UpdaterRegistry.RemoveDocumentTriggers(myUpdater.GetUpdaterId(), doc);
                UpdaterRegistry.UnregisterUpdater(myUpdater.GetUpdaterId(), doc);
            }
            UpdaterRegistry.RegisterUpdater(myUpdater, doc,true);
            ElementFilter elementFilter = new ElementClassFilter(typeof(CableTray));
            UpdaterRegistry.AddTrigger(myUpdater.GetUpdaterId(), doc, elementFilter, Element.GetChangeTypeGeometry());
            throw new NotImplementedException();
        }
    }
}

```

## UpdaterSwitchCommand.cs

```csharp
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicModelUpdate
{
    [Transaction(TransactionMode.Manual)]
    public class UpdaterSwitchCommand : IExternalCommand
    {
       
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            MyUpdater myUpdater = new MyUpdater(commandData.Application.ActiveAddInId);
            if (UpdaterRegistry.IsUpdaterRegistered(myUpdater.GetUpdaterId()))
            {
                if (UpdaterRegistry.IsUpdaterEnabled(myUpdater.GetUpdaterId()))
                {
                    UpdaterRegistry.DisableUpdater(myUpdater.GetUpdaterId());
                }
                else
                {
                    UpdaterRegistry.EnableUpdater(myUpdater.GetUpdaterId());
                }
            }
            return Result.Succeeded;
        }
    }
}

```

## ListenerBridges.cs

```csharp
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
using System.Xml.Linq;

namespace DynamicModelUpdate
{
    [Transaction(TransactionMode.Manual)]
    public class ListenerBridges : IExternalCommand
    {
        Element element1;
        Element element2;
        ExternalEvent myListenerEvent;
        UIApplication uiApp;
        UIDocument uidoc;
        Document doc;
        Stopwatch stopwatch;
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            uiApp = commandData.Application;
            uidoc = uiApp.ActiveUIDocument;
            doc = uidoc.Document;
            Reference reference1 = uidoc.Selection.PickObject(ObjectType.Element, "请选择主桥架(被垂直的桥架)");
            element1 = doc.GetElement(reference1) as MEPCurve;
            Reference reference2 = uidoc.Selection.PickObject(ObjectType.Element, "请选择支线桥架");
            element2 = doc.GetElement(reference2) as MEPCurve;
            XYZ initialBridge1Position = GetLocationCurveCenterPoint(element1);
            MyListener myListener = new MyListener(element1, element2, doc, initialBridge1Position);
            myListenerEvent = ExternalEvent.Create(myListener);
            stopwatch = new Stopwatch();
            uiApp.Idling += UiApp_Idling;
            uiApp.Application.DocumentChanged += MyListenerEventHandler;
            return Result.Succeeded;
        }

        private void UiApp_Idling(object sender, IdlingEventArgs e)
        {
            if (!stopwatch.IsRunning)
            {
                stopwatch.Start();
            }
            else
            {
                // 如果计时器已经启动，就检查是否已经过去了5秒钟
                if (stopwatch.ElapsedMilliseconds >= 20000)
                {
                    // 如果已经过去了5秒钟，就停止计时器，并在Revit中弹出一个提示框
                    TaskDialog.Show("提示", "5秒已经过去了！");
                    uiApp.Application.DocumentChanged -= MyListenerEventHandler;
                    stopwatch.Reset();
                    uiApp.Idling-= UiApp_Idling;
                }
            }
        }

        private void MyListenerEventHandler(object sender, DocumentChangedEventArgs e)
        {
            ICollection<ElementId> modifiedElementIds = e.GetModifiedElementIds();
            foreach (ElementId item in modifiedElementIds)
            {
                if (item == element1.Id)
                {
                    myListenerEvent.Raise();
                }
            }
        }



        private XYZ GetLocationCurveCenterPoint(Element element)
        {
            LocationCurve locationCurve = element.Location as LocationCurve;
            Curve curve = locationCurve.Curve;
            return (curve.GetEndPoint(0) + curve.GetEndPoint(1)) / 2;
        }


    }
}

```

