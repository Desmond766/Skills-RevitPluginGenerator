# Sample Snippet: CreateThresholdStone

Source project: `existingCodes\梁涛插件源代码\1.土建\CreateThresholdStone\CreateThresholdStone`

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
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interop;
using OperationCanceledException = Autodesk.Revit.Exceptions.OperationCanceledException;

namespace CreateThresholdStone
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        // 创建门槛石
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;

            if (!(doc.ActiveView is View3D))
            {
                message = "请在三维视图中运行该插件!";
                return Result.Failed;
            }

            MainWindow window = new MainWindow();
            // 获取运行该插件的进程的句柄(两种方法)
            IntPtr intPtr = commandData.Application.MainWindowHandle;
            // 一个提供WPF窗体和win32之间互相操作的类，允许开发者获取WPF窗体的hwnd和设置WPF窗体的所有者
            WindowInteropHelper windowInteropHelper = new WindowInteropHelper(window);
            windowInteropHelper.Owner = intPtr;
            window.ShowDialog();
            if (window.DialogResult == false)
            {
                return Result.Cancelled;
            }
            double thickness = window.thickness / 304.8;

            Next:
            Reference reference;
            try
            {
                reference = sel.PickObject(ObjectType.Element, new WallOrDoorFilter(), "选择要创建门槛石的幕墙或门(按ESC键结束创建)");
            }
            catch (OperationCanceledException)
            {
                TaskDialog.Show("BIMTRANS", "结束创建！");
                return Result.Succeeded;
            }

            Element element = doc.GetElement(reference);
            CurveArray cu = new CurveArray();
            if (element is Wall wall)
            {
                Line line = (wall.Location as LocationCurve).Curve as Line;
                XYZ dir = line.Direction;
                XYZ verDir = dir.CrossProduct(XYZ.BasisZ).Normalize();
                XYZ p0 = line.GetEndPoint(0);
                XYZ p1 = line.GetEndPoint(1);

                double defaultHalfWidth = 50 / 304.8;
                double halfWidth = GetHalfStoneWidth(p0.Add(p1) / 2, verDir, doc.ActiveView as View3D);
                if (halfWidth != -1) defaultHalfWidth = halfWidth;

                XYZ cp1 = p0 + verDir * defaultHalfWidth;
                XYZ cp2 = p0 - verDir * defaultHalfWidth;
                XYZ cp3 = p1 - verDir * defaultHalfWidth;
                XYZ cp4 = p1 + verDir * defaultHalfWidth;
                cu.Append(Line.CreateBound(cp1, cp2));
                cu.Append(Line.CreateBound(cp2, cp3));
                cu.Append(Line.CreateBound(cp3, cp4));
                cu.Append(Line.CreateBound(cp4, cp1));
            }
            else if (element is FamilyInstance familyInstance)
            {
                XYZ dir = familyInstance.GetTransform().OfVector(XYZ.BasisX);
                XYZ verDir = dir.CrossProduct(XYZ.BasisZ).Normalize();
                XYZ point = (familyInstance.Location as LocationPoint).Point;
                FamilySymbol familySymbol = doc.GetElement(familyInstance.GetTypeId()) as FamilySymbol;
                // 门槛石长度 = 门宽度
                double length = familySymbol.LookupParameter("宽度").AsDouble();
                double halfLength = length / 2;

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

namespace CreateThresholdStone
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public double thickness { get; private set; } = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                thickness = Convert.ToDouble(tb_thickness.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
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

