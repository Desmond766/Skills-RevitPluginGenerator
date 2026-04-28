# Sample Snippet: PipelineAlignment

Source project: `existingCodes\梁涛插件源代码\3.管综\PipelineAlignment\PipelineAlignment`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interop;
using System.Windows;
using Autodesk.Revit.Exceptions;
using OperationCanceledException = Autodesk.Revit.Exceptions.OperationCanceledException;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.DB.Electrical;
using System.Threading;
using System.Windows.Threading;
using RevitUtils;

namespace PipelineAlignment
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        // 管线对齐（选择对齐管道顶、中心、底对齐）
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;

            //int rou = (int)Math.Round(2.5, 0, MidpointRounding.AwayFromZero);
            //MEPCurve mep2 = doc.GetElement(sel.PickObject(ObjectType.Element)) as MEPCurve;
            //TaskDialog.Show("revit", rou.ToString()+"\n"+mep2.Width);
            //return Result.Succeeded;

            MainWindow mainWindow = new MainWindow();
            var intPtr = commandData.Application.MainWindowHandle;
            // 一个提供WPF窗体和win32之间互相操作的类，允许开发者获取WPF窗体的hwnd和设置WPF窗体的所有者
            WindowInteropHelper windowInteropHelper = new WindowInteropHelper(mainWindow);
            windowInteropHelper.Owner = intPtr;
            mainWindow.Show();

            ListenUtils listenUtils = new ListenUtils();
        Next:
            Reference refer;
            IList<Reference> references;
            try
            {
                listenUtils.startListen();
                refer = sel.PickObject(ObjectType.Element, new MEPFilter(), "选择基准管线(关闭窗口结束)");
                references = sel.PickObjects(ObjectType.Element, new MEPFilter(), "选择要对齐的管线(按空格键完成框选，关闭窗口结束)");
                listenUtils.stopListen();

                MEPCurve mEPCurve = doc.GetElement(refer) as MEPCurve;
                bool addInsulationLayer = Properties.Settings.Default.InsulationLayer;
                int alignment = Properties.Settings.Default.Alignment;
                using (TransactionGroup TG = new TransactionGroup(doc, "横管对齐"))
                {
                    TG.Start();

                    double selHeight = GetAlignmentHeight(mEPCurve, addInsulationLayer, alignment);
                    foreach (var reference in references)
                    {
                        MEPCurve mep = doc.GetElement(reference) as MEPCurve;
                        double height = GetAlignmentHeight(mep, addInsulationLayer, alignment);
                        SetAlignmentHeight(doc, mep, selHeight - height, alignment);
                    }
                    TG.Assimilate();
                }
            }
            catch (OperationCanceledException)
            {
                listenUtils.stopListen();
                if (mainWindow.IsClose == true) return Result.Succeeded;
                else goto Next;
            }
            if (mainWindow.IsClose == false) goto Next;
            //TaskDialog.Show("revit", (mainWindow.cb_thickness.IsChecked == true) + "\n" + (mainWindow.rb_bottom.IsChecked));
            //mainWindow.Close();

            return Result.Succeeded;
        }
        private double GetAlignmentHeight(MEPCurve mEPCurve, bool addLayer, int alignment)
        {
            double height = 0;

            if (alignment == 1)
            {
// ... truncated ...
```

## ExternalEvent.cs

```csharp
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineAlignment
{
    public class ExternalEvent : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            UIDocument uidoc = app.ActiveUIDocument;
            Selection sel = uidoc.Selection;
            Document doc = uidoc.Document;

            Next:
            Reference refer;
            IList<Reference> references;
            try
            {
                refer = sel.PickObject(ObjectType.Element, new MEPFilter(), "选择基准管线");
                references = sel.PickObjects(ObjectType.Element, new MEPFilter(), "选择要对齐的管线");
                using (Transaction t = new Transaction(doc, "横管对齐"))
                {
                    t.Start();


                    t.Commit();
                }
            }
            catch (OperationCanceledException)
            {
                return;
            }
            goto Next;
        }

        public string GetName()
        {
            return "ExternalEvent";
        }
    }
}

```

