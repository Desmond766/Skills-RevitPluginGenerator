using Autodesk.Revit.DB;
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
using Color = System.Windows.Media.Color;
using Grid = System.Windows.Controls.Grid;
using Line = System.Windows.Shapes.Line;

namespace RevitUtils
{
    /// <summary>
    /// JumpViewWpf.xaml 的交互逻辑
    /// </summary>
    public partial class JumpViewWpf : Window
    {
        internal JumpViewWpf(Document doc)
        {
            InitializeComponent();
            List<ViewInfo> viewInfos = new List<ViewInfo>();
            List<View3D> view3Ds = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Views).OfClass(typeof(View3D)).Cast<View3D>().ToList();
            view3Ds.ForEach(v3 => viewInfos.Add(new ViewInfo() { View3D = v3, View3DName = v3.Name }));
            viewInfos = viewInfos.OrderBy(v => v.View3DName).ToList();
            list.ItemsSource = viewInfos;
            if (viewInfos.Count > 0)
            {
                list.SelectedIndex = 0;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            //list.Items.Add(e.LeftButton.ToString());
            Grid grid = FindVisualChild<Grid>(sender as Button);
            grid.Background = new SolidColorBrush() { Color = Color.FromRgb(232, 17, 35) };
            //Line line = FindVisualChild<Line>(grid);
            //line.Stroke = Brushes.White;

            var lines = FindVisualChilds<Line>(grid);
            lines.ForEach(l => l.Stroke = Brushes.White);
        }

        private childItem FindVisualChild<childItem>(DependencyObject obj)
        where childItem : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if (child != null && child is childItem)
                {
                    return (childItem)child;
                }
                else
                {
                    childItem childOfChild = FindVisualChild<childItem>(child);
                    if (childOfChild != null)
                        return childOfChild;
                }
            }
            return null;
        }
        private List<childItem> FindVisualChilds<childItem>(DependencyObject obj)
        where childItem : DependencyObject
        {
            List<childItem> items = new List<childItem>();
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if (child != null && child is childItem)
                {
                    items.Add((childItem)child);
                }
            }
            return items;
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            Grid grid = FindVisualChild<Grid>(sender as Button);
            grid.Background = Brushes.Transparent;

            var lines = FindVisualChilds<Line>(grid);
            lines.ForEach(l => l.Stroke = Brushes.Black);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Grid grid = FindVisualChild<Grid>(sender as Button);
            grid.Background = new SolidColorBrush() { Color = Color.FromArgb(50, 232, 17, 35) };
        }

        private void Window_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selIndex = list.SelectedIndex;
            if (selIndex != -1)
            {
                var selItem = list.ItemContainerGenerator.ContainerFromIndex(selIndex) as ListBoxItem;
                if (selItem != null && selItem.IsMouseOver && e.ChangedButton == MouseButton.Left)
                {
                    DialogResult = true;
                }
            }
        }
    }
    public class ViewInfo
    {
        public View3D View3D { get; set; }
        public string View3DName { get; set; }
    }
}
