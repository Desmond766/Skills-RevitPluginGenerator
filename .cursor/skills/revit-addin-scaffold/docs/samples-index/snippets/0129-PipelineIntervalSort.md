# Sample Snippet: PipelineIntervalSort

Source project: `existingCodes\梁涛插件源代码\3.管综\PipelineIntervalSort\PipelineIntervalSort`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.Exceptions;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OperationCanceledException = Autodesk.Revit.Exceptions.OperationCanceledException;

namespace PipelineIntervalSort
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;

            IList<Reference> refers;
            Reference reference;
            XYZ p1;
            XYZ p2;
            RevitUtils.ListenUtils listenUtils = new RevitUtils.ListenUtils();
            try
            {
                listenUtils.startListen();
                refers = sel.PickObjects(ObjectType.Element, new PipelineFilter(), "框选管线以排序（按空格键完成框选，ESC键取消）");
                reference = sel.PickObject(ObjectType.Element, new PipelineFilter(), "选择两点作为管线排序方向(第一点)");
                p1 = reference.GlobalPoint;
                p2 = sel.PickObject(ObjectType.Element, new PipelineFilter(), "选择两点作为管线排序方向(第二点)").GlobalPoint;
                listenUtils.stopListen();
            }
            catch (OperationCanceledException)
            {
                listenUtils.stopListen();
                return Result.Succeeded;
            }

            List<MEPCurve> mEPCurves = refers.Select(r => doc.GetElement(r) as MEPCurve).ToList();

            bool isMix = IsMix(mEPCurves);
            MainWindow mainWindow = new MainWindow(isMix);
            mainWindow.ShowDialog();
            if (mainWindow.DialogResult == false)
            {
                return Result.Cancelled;
            }

            p1 = new XYZ(p1.X, p1.Y, 0);
            p2 = new XYZ(p2.X, p2.Y, 0);

            XYZ sortDir = GetSortDir(doc.GetElement(reference), p1, p2);
            Line sortLine = Line.CreateUnbound(p1, sortDir);

            //TaskDialog.Show("re", Properties.Settings.Default.Distance.ToString());
            using (Transaction t = new Transaction(doc, "管线等间距排列"))
            {
                t.Start();
                if (isMix)
                {
                    SortMepCurves(mEPCurves, sortLine, p1, Properties.Settings.Default.Distance / 304.8, Properties.Settings.Default.CableMinToMax, Properties.Settings.Default.PipeMinToMax, Properties.Settings.Default.CableFirst);
                }
                else
                {
                    SortMepCurves(mEPCurves, sortLine, p1, Properties.Settings.Default.Distance / 304.8, Properties.Settings.Default.MinToMax, Properties.Settings.Default.CableFirst);
                }
                t.Commit();
            }

            return Result.Succeeded;
        }
        /// <summary>
        /// 判断mep集合中的是否存在多种类别
        /// </summary>
        /// <param name="meps"></param>
        /// <returns></returns>
        private bool IsMix(List<MEPCurve> meps)
        {
            bool result = false;

            var group = meps.GroupBy(m => m.Category.Id.IntegerValue);
            if (group.Count() >= 2)
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

namespace PipelineIntervalSort
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public double Distance { get; private set; }
        public bool MinToMax { get; private set; }
        public bool CableFirst { get; private set; }
        public bool CableMinToMax { get; set; }
        public bool PipeMinToMax { get; set; }
        private readonly bool IsMix;
        public MainWindow(bool isMix)
        {
            InitializeComponent();
            tb_dis.Text = (Properties.Settings.Default.Distance).ToString();

            if (Properties.Settings.Default.MinToMax) rb_min_to_max.IsChecked = true;
            else rb_max_to_min.IsChecked = true;

            if (Properties.Settings.Default.PipeMinToMax) rb_pipe_min_to_max.IsChecked = true;
            else rb_pipe_max_to_min.IsChecked = true;

            if (Properties.Settings.Default.CableMinToMax) rb_cable_min_to_max.IsChecked = true;
            else rb_cable_max_to_min.IsChecked = true;

            if (Properties.Settings.Default.CableFirst) rb_cable_first.IsChecked = true;
            else rb_pipe_first.IsChecked = true;

            IsMix = isMix;
            if (isMix)
            {
                //lb_dis.Margin = new Thickness(lb_dis.Margin.Left, lb_dis.Margin.Top + 40, 0, 0);
                //tb_dis.Margin = new Thickness(tb_dis.Margin.Left, tb_dis.Margin.Top + 40, 0, 0);
                //lb_unit.Margin = new Thickness(lb_unit.Margin.Left, lb_unit.Margin.Top + 40, 0, 0);
                grid_space.Margin = new Thickness(grid_space.Margin.Left, grid_space.Margin.Top + 40, grid_space.Margin.Right, grid_space.Margin.Bottom);
                grid_mix.Visibility = Visibility.Visible;
                grid_mix_first.Visibility = Visibility.Visible;
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Distance = Convert.ToDouble(tb_dis.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            if (IsMix)
            {
                CableFirst = rb_cable_first.IsChecked == true;
                CableMinToMax = rb_cable_min_to_max.IsChecked == true;
                PipeMinToMax = rb_pipe_min_to_max.IsChecked == true;
                Properties.Settings.Default.CableFirst = CableFirst;
                Properties.Settings.Default.CableMinToMax = CableMinToMax;
                Properties.Settings.Default.PipeMinToMax = PipeMinToMax;
            }
            else
            {
                MinToMax = rb_min_to_max.IsChecked == true;
                Properties.Settings.Default.MinToMax = MinToMax;
            }
            Properties.Settings.Default.Distance = Distance;
            Properties.Settings.Default.Save();
            DialogResult = true;
            Close();
        }

// ... truncated ...
```

