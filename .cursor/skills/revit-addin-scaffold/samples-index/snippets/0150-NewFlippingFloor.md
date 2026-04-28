# Sample Snippet: NewFlippingFloor

Source project: `existingCodes\梁涛插件源代码\6.不常用\NewFlippingFloor\NewFlippingFloor`

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
using System.Windows.Media;

namespace NewFlippingFloor
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uIDoc = commandData.Application.ActiveUIDocument;
            Document doc = uIDoc.Document;
            Reference reference = uIDoc.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.PointOnElement,new PlanarFaceFilter(doc));
            ImportInstance dwg = doc.GetElement(reference) as ImportInstance;
            var geoObj = (dwg as Element).GetGeometryObjectFromReference(reference);
            Autodesk.Revit.DB.Transform transform = dwg.GetTransform();
            PlanarFace planarFace = geoObj as PlanarFace;
            CurveArray curveArray = new CurveArray();
            List<CurveArray> curves = new List<CurveArray>();
            List<SolidIInfo> solidInfos = new List<SolidIInfo>();
            bool first = true;
            foreach (var item in planarFace.GetEdgesAsCurveLoops())
            {
                try
                {
                    List<CurveLoop> loops = new List<CurveLoop>() { item };
                    Solid solid2 = GeometryCreationUtilities.CreateExtrusionGeometry(loops, XYZ.BasisZ, 200 / 304.8);
                    solid2 = SolidUtils.CreateTransformed(solid2, transform);
                    double area = Math.Abs(solid2.SurfaceArea);
                    SolidIInfo solidInfo = new SolidIInfo() { SurFaceArea = area, Curves = item };
                    solidInfos.Add(solidInfo);
                }
                catch (Exception)
                {
                    continue;

                }
            }
            solidInfos = solidInfos.OrderByDescending(x => x.SurFaceArea).ToList();
            foreach (var item in solidInfos)
            {
                if (first)
                {
                    first = false;
                    foreach (var item2 in item.Curves)
                    {
                        Curve curve = item2.CreateTransformed(transform);
                        curveArray.Append(curve);
                    }
                }
                else
                {
                    CurveArray curveArray1 = new CurveArray();
                    foreach (var item2 in item.Curves)
                    {
                        Curve curve = item2.CreateTransformed(transform);
                        curveArray1.Append(curve);
                    }
                    curves.Add(curveArray1);
                }
            }
            MainWindow mainWindow = new MainWindow();
            List<Level> levels = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Levels).WhereElementIsNotElementType().Cast<Level>().ToList();
            List<FloorType> floorTypes = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Floors).WhereElementIsElementType().Cast<FloorType>().ToList();
            foreach (var level in levels)
            {
                mainWindow.cb_level.Items.Add(level.Name);
            }
            foreach (var floorType in floorTypes)
            {
                mainWindow.cb_high.Items.Add(floorType.Name);
            }
            mainWindow.ShowDialog();
            if (mainWindow.Cancel)
            {
                return Result.Cancelled;
            }
            string levelName = mainWindow.cb_level.Text;
            string floorTypeName = mainWindow.cb_high.Text;
            double levelOffset = 0;
            try
            {
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

namespace NewFlippingFloor
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool Cancel { get;set; } = true;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Cancel = false;
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

```

