# Sample Snippet: ColumnCornerProtectorDirectionAdjustment

Source project: `existingCodes\梁涛插件源代码\1.土建\ColumnCornerProtectorDirectionAdjustment\ColumnCornerProtectorDirectionAdjustment`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interop;

namespace ColumnCornerProtectorDirectionAdjustment
{
    // 柱套护角方向调整（中海空心柱族）
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public List<ElementId> LinkLaneIds { get; set; } = new List<ElementId>();
        double FindLength = 0;
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;

            MainWindow mainWindow = new MainWindow();
            IntPtr intPtr = commandData.Application.MainWindowHandle;
            WindowInteropHelper windowInteropHelper = new WindowInteropHelper(mainWindow);
            windowInteropHelper.Owner = intPtr;
            mainWindow.ShowDialog();
            if (mainWindow.DialogResult == false)
            {
                return Result.Cancelled;
            }
            FindLength = Properties.Settings.Default.MaxDis / 304.8;

            //// 用该方法可以在不关闭Revit的情况下更新插件，但无法通过快捷键使用对应插件
            //var assembly = Assembly.LoadFrom(@"C:\Program Files\BIMTRANS\NewBTStore\ColoringOfStructuralPlates.dll");
            //var type = assembly.GetType("ColoringOfStructuralPlates.Command");
            //var realCommand = Activator.CreateInstance(type) as IExternalCommand;

            //return realCommand.Execute(commandData, ref message, elements);

            //return Result.Succeeded;

            //Wall wall = (Wall)doc.GetElement(sel.PickObject(ObjectType.Element, "选择幕墙"));
            //Mullion mullion = (Mullion)doc.GetElement(sel.PickObject(ObjectType.Element, "选择竖梃"));
            //var uLines = wall.CurtainGrid.GetUGridLineIds();
            //var vLines = wall.CurtainGrid.GetVGridLineIds();
            ////TaskDialog.Show("revit", uLines.Count + "\n" + vLines.Count);
            //CurtainGrid grid = wall.CurtainGrid;
            //Transaction transaction = new Transaction(doc, "添加网格");
            //transaction.Start();

            //foreach (var item in grid.GetVGridLineIds())
            //{
            //    CurtainGridLine gridLine = (CurtainGridLine)doc.GetElement(item);
            //    gridLine.AddMullions(gridLine.AllSegmentCurves.get_Item(2), mullion.MullionType, false);
            //}
            
            //transaction.Commit();
            //return Result.Succeeded;

            //// 修改楼板边界
            //Reference ref1 = sel.PickObject(ObjectType.Element, "Please pick a floor to edit");
            //Floor floor = doc.GetElement(ref1) as Floor;

            //Transaction transTemp = new Transaction(doc);
            //transTemp.Start("tempDelete");
            //ICollection<ElementId> ids = doc.Delete(floor.Id);
            //transTemp.RollBack();

            //List<ModelLine> mLines = new List<ModelLine>();
            //foreach (ElementId id in ids)
            //{
            //    Element ele = doc.GetElement(id);
            //    if (ele is ModelLine)
            //    {
            //        mLines.Add(ele as ModelLine);
            //    }
            //}
            //Transaction trans = new Transaction(doc);
            //trans.Start("ChangeFloor");
            //foreach (ModelLine mline in mLines)
            //{
            //    LocationCurve lCurve = mline.Location as LocationCurve;
            //    Line c = lCurve.Curve as Line;
            //    XYZ pt1 = c.GetEndPoint(0);
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

namespace ColumnCornerProtectorDirectionAdjustment
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            tb_max_dis.Text = Properties.Settings.Default.MaxDis.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Properties.Settings.Default.MaxDis = Convert.ToDouble(tb_max_dis.Text);
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            DialogResult = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

```

