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

namespace WallColumnLevelBeamFloor
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // 保留上次设置的选项
            if (Properties.Settings.Default.SelWall == false) cb_wall.IsChecked = false;
            if (Properties.Settings.Default.SelColumn == false) cb_column.IsChecked = false;
            if (Properties.Settings.Default.UpLevel == false) cb_upL.IsChecked = false;
            if (Properties.Settings.Default.DownLevel == false) cb_downL.IsChecked = false;
            if (Properties.Settings.Default.LevelBeam == false) cb_levelB.IsChecked = false;
            if (Properties.Settings.Default.LevelFloor == false) cb_levelF.IsChecked = false;
            if (Properties.Settings.Default.StructuralFloor == false)
            {
                rb_struct.IsChecked = false;
                rb_build.IsChecked = true;
            }
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (rb_struct.IsChecked == true) Properties.Settings.Default.StructuralFloor = true;
            else Properties.Settings.Default.StructuralFloor = false;

            Properties.Settings.Default.Save();
            DialogResult = true;
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            string boxName = checkBox.Content.ToString();
            switch (boxName)
            {
                case "墙":
                    if (checkBox.IsChecked == true) Properties.Settings.Default.SelWall = true;
                    else Properties.Settings.Default.SelWall = false;
                    break;
                case ("柱"):
                    if (checkBox.IsChecked == true) Properties.Settings.Default.SelColumn = true;
                    else Properties.Settings.Default.SelColumn = false;
                    break;
                case ("上齐"):
                    if (checkBox.IsChecked == true) Properties.Settings.Default.UpLevel = true;
                    else Properties.Settings.Default.UpLevel = false;
                    break;
                case ("下齐"):
                    if (checkBox.IsChecked == true) Properties.Settings.Default.DownLevel = true;
                    else Properties.Settings.Default.DownLevel = false;
                    break;
                case ("齐梁"):
                    if (checkBox.IsChecked == true) Properties.Settings.Default.LevelBeam = true;
                    else Properties.Settings.Default.LevelBeam = false;
                    break;
                case ("齐板"):
                    if (checkBox.IsChecked == true) Properties.Settings.Default.LevelFloor = true;
                    else Properties.Settings.Default.LevelFloor = false;
                    break;
                default:
                    break;
            }
        }
    }
}
