# Sample Snippet: InspectionWellElevationAdjustment

Source project: `existingCodes\梁涛插件源代码\2.机电建模及算量\InspectionWellElevationAdjustment\InspectionWellElevationAdjustment`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.Exceptions;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interop;
using OperationCanceledException = Autodesk.Revit.Exceptions.OperationCanceledException;

namespace InspectionWellElevationAdjustment
{
    // 检查井标高调整
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;
            IntPtr intPtr = commandData.Application.MainWindowHandle;

            //var testRefer = sel.PickObject(ObjectType.Element);
            //FamilyInstance familyInstance = doc.GetElement(testRefer) as FamilyInstance;

            //var boundingBox = familyInstance.get_BoundingBox(null);
            //LogicalAndFilter andFilter = CreateMixFilter(boundingBox.Min, boundingBox.Max, 200, out var solid);
            //using (FilteredElementCollector pipeCol = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_PipeCurves).WherePasses(andFilter))
            //{
            //    if (pipeCol.Count() > 0)
            //    {
            //        var pipes = pipeCol.ToList();
            //        double minZ = GetMinPoint(pipes).Z;
            //        using (Transaction t = new Transaction(doc, "检查井标高调整"))
            //        {
            //            t.Start();
            //            XYZ wellPoint = (familyInstance.Location as LocationPoint).Point;
            //            double depth = wellPoint.Z - minZ;
            //            depth = CeilingToHundreds(depth * 304.8) / 304.8;
            //            familyInstance.LookupParameter("深度").Set(depth);
            //            t.Commit();
            //        }
            //    }
                
            //}

            //return Result.Succeeded;

            //List<FamilyInstance> wells = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_GenericModel).OfClass(typeof(FamilyInstance))
            //    .Cast<FamilyInstance>().Where(f => f.Symbol.Name.Contains("井")).ToList();

            MainWindow mainWindow = new MainWindow(doc);
            WindowInteropHelper windowInteropHelper = new WindowInteropHelper(mainWindow);
            windowInteropHelper.Owner = intPtr;
            mainWindow.ShowDialog();
            if (mainWindow.DialogResult == false) return Result.Cancelled;

            List<FamilyInstance> wells = new List<FamilyInstance>();
            FilteredElementCollector wellCol;
            int wellScope = Properties.Settings.Default.WellScope;
            if (wellScope == 0)
            {
                RevitUtils.ListenUtils listenUtils = new RevitUtils.ListenUtils();
                try
                {
                    listenUtils.startListen();
                    var wellRefers = sel.PickObjects(ObjectType.Element, new WellFilter(), "框选检查井(ESC键取消 空格键确定)");
                    listenUtils.stopListen();
                    List<ElementId> wellIds = wellRefers.Select(wr => wr.ElementId).ToList();
                    if(wellIds.Count == 0)
                    {
                        message = "未选择任何检查井";
                        return Result.Failed;
                    }
                    wellCol = new FilteredElementCollector(doc, wellIds);
                }
                catch (OperationCanceledException)
                {
                    listenUtils.stopListen();
                    return Result.Cancelled;
                }
            }
            else if (wellScope == 1)
            {
// ... truncated ...
```

## AddPipeTypeWindow.xaml.cs

```csharp
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Plumbing;
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

namespace InspectionWellElevationAdjustment
{
    /// <summary>
    /// AddPipeTypeWindow.xaml 的交互逻辑
    /// </summary>
    public partial class AddPipeTypeWindow : Window
    {
        public List<string> PipeTypeNames { get; set; } = new List<string>();
        public AddPipeTypeWindow(Document doc, Window ownerWindow)
        {
            InitializeComponent();
            Owner = ownerWindow;
            list.ItemsSource = GetPipeTypeNames(doc);
        }
        private List<string> GetPipeTypeNames(Document doc)
        {
            List<string> result = new List<string>();

            result = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_PipeCurves).Where(p => p is PipeType).Select(p => p.Name).ToList();
            result = result.Distinct().OrderBy(r => r).ToList();

            return result;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (list.SelectedItems.Count == 0)
            {
                MessageBox.Show("至少选择一种管道类型");
                return;
            }
            try
            {
                foreach (var item in list.SelectedItems)
                {
                    PipeTypeNames.Add(item.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            DialogResult = true;
        }
    }
}

```

