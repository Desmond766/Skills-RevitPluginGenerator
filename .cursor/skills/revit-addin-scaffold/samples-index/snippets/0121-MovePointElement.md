# Sample Snippet: MovePointElement

Source project: `existingCodes\梁涛插件源代码\2.机电建模及算量\MovePointElement\MovePointElement`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;
using Line = Autodesk.Revit.DB.Line;

namespace MovePointElement
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;

            //TestWindow testWindow = new TestWindow();
            //testWindow.Show();
            //return Result.Succeeded;

            //using (Transaction t = new Transaction(doc, "重设"))
            //{
            //    t.Start();
            //    uidoc.ActiveView.IsolateElementsTemporary(new ElementId[] {new ElementId(5272273), new ElementId(5272275)  });
            //    doc.ActiveView.TemporaryViewModes.DeactivateAllModes();
            //    t.Commit();
            //}
            //using (Transaction t = new Transaction(doc, "重设2"))
            //{
            //    t.Start();
            //    uidoc.ActiveView.IsolateElementsTemporary(new ElementId[] {new ElementId(5272271), new ElementId(5272269)  });
            //    //doc.ActiveView.TemporaryViewModes.DeactivateAllModes();
            //    t.Commit();
            //}
            //return Result.Succeeded; 

            MainWindow mainWindow = new MainWindow(doc);
            mainWindow.ShowDialog();
            if (mainWindow.DialogResult == false)
            {
                //MessageBox.Show("已取消操作");
                //TaskDialog.Show("revit", mainWindow.btn_confirm.Margin.ToString() + "\n" + mainWindow.grid_parent.ActualWidth);
                return Result.Cancelled;
            }

            //TaskDialog.Show("revit", mainWindow.PointCategory + "\n" + mainWindow.PointName + "\n" + mainWindow.PointDirection + "\n" + mainWindow.IsScope + "\n" + mainWindow.HostCategory + "\n" + mainWindow.HostName);
            BuiltInCategory pointCategory = mainWindow.PointCategory;
            string pointName = mainWindow.PointName;
            XYZ pointDirection = mainWindow.PointDirection;
            bool isScope = mainWindow.IsScope;
            BuiltInCategory hostCategory = mainWindow.HostCategory;
            string hostName = mainWindow.HostName;

            double scopeValue = mainWindow.Distance / 304.8;
            double zError = mainWindow.ZError / 304.8;
            bool useZError = mainWindow.UseZError;
            double angle = (mainWindow.Angle / 180.0) * Math.PI;

            List<ElementId> pointIds = GetElementIds(doc, pointCategory, pointName, isScope);
            List<ElementId> hostIds = GetElementIds(doc, hostCategory, hostName, isScope, false);

            //TaskDialog.Show("revit", pointIds.Count + "\n" +  hostIds.Count);

            using (Transaction t = new Transaction(doc, "移动点元素"))
            {
                t.Start();

                MovePointElements(doc, scopeValue, angle, zError, useZError, pointDirection, pointIds, hostIds);

                t.Commit();
            }
            return Result.Succeeded;
        }

        private void MovePointElements(Document doc, double scopeValue, double angle, double zError, bool useZError, XYZ pointBaseDirection, List<ElementId> pointIds, List<ElementId> hostIds)
        {
            List<Element> hostElems = hostIds.Select(h => doc.GetElement(h)).ToList();
            foreach (var pointId in pointIds)
            {
// ... truncated ...
```

## DynamicPositionConverter.cs

```csharp
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace MovePointElement
{
    public class DynamicPositionConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            double parentWidth = (double)values[0]; // 父容器宽度
            double threshold = 80; // 固定阈值
            double targetPosition = parentWidth - 400 + 80;
            // 若宽度 > 400，则返回一个结果使其离左侧距离为固定值，若宽度 < 400，则返回固定值80
            return new Thickness(0, 0, parentWidth > 400 ? targetPosition : threshold, 5);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

```

