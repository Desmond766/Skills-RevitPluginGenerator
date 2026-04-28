# Sample Snippet: ReviewParkingSpaceSpacing

Source project: `existingCodes\梁涛插件源代码\1.土建\ReviewParkingSpaceSpacing\ReviewParkingSpaceSpacing`

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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Interop;
using OperationCanceledException = Autodesk.Revit.Exceptions.OperationCanceledException;

namespace ReviewParkingSpaceSpacing
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;
            IntPtr intPtr = commandData.Application.MainWindowHandle;

            MainWindow window = new MainWindow();
            WindowInteropHelper windowInteropHelper = new WindowInteropHelper(window);
            windowInteropHelper.Owner = intPtr;
            window.ShowDialog();
            if (window.DialogResult == false)
            {
                return Result.Cancelled;
            }
            Document linkDoc = null;

            if (window.ElementInLink)
            {
                Reference linkReference;
                try
                {
                    linkReference = sel.PickObject(ObjectType.LinkedElement, "选择链接墙、柱所在链接模型");
                }
                catch (OperationCanceledException)
                {
                    TaskDialog.Show("BIMTRANS", "已取消操作");
                    return Result.Cancelled;
                }
                RevitLinkInstance linkInstance = doc.GetElement(linkReference) as RevitLinkInstance;
                linkDoc = linkInstance.GetLinkDocument();
            }
            Document linkOrLocalDoc = linkDoc ?? doc;

            List<ParkingSpaceInfo> infos = new List<ParkingSpaceInfo>();

            // 获取视图中所有停车位
            List<FamilyInstance> parkingSpaces = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_StructuralColumns).OfClass(typeof(FamilyInstance))
                .Cast<FamilyInstance>().Where(f => f.Symbol.FamilyName.Contains("停车位")).ToList();

            foreach (var ps in parkingSpaces)
            {
                Transform transform = ps.GetTransform();
                XYZ point = (ps.Location as LocationPoint).Point;
                XYZ xDir = transform.OfVector(XYZ.BasisX);
                XYZ yDir = transform.OfVector(XYZ.BasisY);
                double width = ps.Symbol.LookupParameter("车位宽").AsDouble();
                double length = ps.Symbol.LookupParameter("车位长").AsDouble();
                // UPDATE:26.2.5新增1mm误差
                double halfWidth = (width / 2) + (299 / 304.8);
                double halfLength = (length / 2) - (1500 / 304.8);
                //halfLength = length;
                var solidFilter = CreateSolidFilter(point, halfWidth, halfLength, xDir, yDir);

                XYZ min = ps.get_BoundingBox(null).Min;
                XYZ max = ps.get_BoundingBox(null).Max;
                min = min - XYZ.BasisX * (1000 / 304.8) - XYZ.BasisY * (1000 / 304.8);
                max = max + XYZ.BasisX * (1000 / 304.8) + XYZ.BasisY * (1000 / 304.8);
                var boxFilter = new BoundingBoxIntersectsFilter(new Outline(min, max));
                var orFilter = new LogicalOrFilter(new ElementCategoryFilter(BuiltInCategory.OST_StructuralColumns), new ElementCategoryFilter(BuiltInCategory.OST_Walls));


                using (FilteredElementCollector columnAndWallCol = new FilteredElementCollector(linkOrLocalDoc).WherePasses(orFilter))
                {
                    columnAndWallCol.WherePasses(boxFilter).WherePasses(solidFilter);

                    var filterElems = columnAndWallCol.ToList();
                    filterElems = filterElems.Where(e => !GetFamilyName(e).Contains("停车位")).ToList();
                    if (filterElems.Count > 0)
                    {
                        infos.Add(new ParkingSpaceInfo() { Id = ps.Id, Name = ps.Name, Point = point });
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

namespace ReviewParkingSpaceSpacing
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool ElementInLink { get; private set; } = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ElementInLink = true;
            DialogResult = true;
            Close();
        }
    }
}

```

