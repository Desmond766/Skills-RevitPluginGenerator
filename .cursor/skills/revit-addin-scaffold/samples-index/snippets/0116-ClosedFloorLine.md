# Sample Snippet: ClosedFloorLine

Source project: `existingCodes\梁涛插件源代码\11.其他\ClosedFloorLine\ClosedFloorLine`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.Exceptions;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OperationCanceledException = Autodesk.Revit.Exceptions.OperationCanceledException;

namespace ClosedFloorLine
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;

            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();
            if (mainWindow.DialogResult == false)
            {
                return Result.Cancelled;
            }
            double extensionLength = Properties.Settings.Default.ExtensionLength / 304.8;

            Next:
            IList<Reference> refers;
            try
            {
                refers = sel.PickObjects(ObjectType.Element, new ModelLineFilter(), "框选要闭合的模型线（按ESC结束布置）");
                if (refers.Count < 3)
                {
                    TaskDialog.Show("BIMTRANS", "选择的模型线至少为3才能创建楼板");
                    return Result.Succeeded;
                }
            }
            catch (OperationCanceledException)
            {
                TaskDialog.Show("BIMTRANS", "结束布置");
                return Result.Succeeded;
            }
            CurveArray curveArray = new CurveArray();

            List<ElementId> delIds = refers.Select(r => r.ElementId).ToList();
            List<ModelLine> modelLines = refers.Select(r => doc.GetElement(r) as ModelLine).ToList();
            List<Line> lines = modelLines.Select(ml => GetLine(ml)).ToList();
            lines = ExtensionLines(lines, extensionLength);

            Line firstLine = lines.First();
            Line nextLine;
            nextLine = lines.FirstOrDefault(l => l != firstLine && l.Intersect(firstLine) == SetComparisonResult.Overlap);
            if (nextLine == null)
            {
                TaskDialog.Show("BIMTRANS", "未找到闭合轮廓线");
                goto Next;
                //return Result.Succeeded;
            }

            IntersectionResultArray result = null;
            var isOverlap = nextLine?.Intersect(firstLine, out result);
            XYZ point = null;
            if (isOverlap != null && isOverlap == SetComparisonResult.Overlap)
            {
                point = result.get_Item(0).XYZPoint;
            }

            while (lines.Count > 0)
            {
                Line findLine = lines.FirstOrDefault(l =>
                {
                    if (l != nextLine && nextLine.Intersect(l, out var resArr) == SetComparisonResult.Overlap)
                    {
                        if (resArr.get_Item(0).XYZPoint.DistanceTo(point) > 0.0001) return true;
                    }
                    return false;
                });
                if (findLine == null)
                {
                    break;
                }
                if (findLine.Intersect(nextLine, out var resultArray) == SetComparisonResult.Overlap)
                {
                    XYZ newPoint = resultArray.get_Item(0).XYZPoint;
                    try
// ... truncated ...
```

## MainWindow.xaml.cs

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ClosedFloorLine
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            tb_length.Text = Properties.Settings.Default.ExtensionLength.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Properties.Settings.Default.ExtensionLength = Convert.ToDouble(tb_length.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            Properties.Settings.Default.Save();

            DialogResult = true;
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

```

