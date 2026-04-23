using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ComboBox = System.Windows.Controls.ComboBox;

namespace ChangeDoorSymbolAngle
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<DoorSymbolInfo> Doors { get; set; } = new List<DoorSymbolInfo>();
        public MainWindow(List<DoorSymbolInfo> doors)
        {
            InitializeComponent();
            Doors = doors;
            this.DataContext = doors;
            //dgcb.ItemsSource = new List<string>() {"0","45","90" };
            //foreach (var item in dataGrid.ItemsSource)
            //{
            //    var fw = dgcb.GetCellContent(item);

            //}
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

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (chb_angle.IsChecked == true)
            {
                tb_angle.IsReadOnly = false;
                bt_angle.IsEnabled = true;
            }
            else
            {
                tb_angle.IsReadOnly = true;
                bt_angle.IsEnabled = false;
            }
        }

        private void bt_angle_Click(object sender, RoutedEventArgs e)
        {
            Doors.ForEach(ds => ds.AngleValue = Convert.ToDouble(tb_angle.Text));
            //foreach (var item in dataGrid.SelectedItems)
            //{
            //    var info = item as DoorSymbolInfo;
            //    info.AngleValue = Convert.ToDouble(tb_angle.Text);
            //}
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            Doors.ForEach(ds => ds.AngleValue = ds.Angle.AsDouble() * 180 / Math.PI);
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

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGrid.SelectedIndex == -1) return;
            return;

            try
            {
                foreach (var item in dataGrid.SelectedItems)
                {
                    DataGridRow data = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromItem(item);
                    if (data == null) MessageBox.Show("null");

                    var cellContent = dataGrid.Columns[4].GetCellContent(data);
                    ComboBox comboBox = FindVisualChild<ComboBox>(cellContent);

                    MessageBox.Show("The text of the TextBlock of the selected list item: "
            + comboBox.Text);
                }
                
            }
            catch (Exception ex)
            {
                TaskDialog.Show("revit", ex.Message);
                Activate();
            }
            
        }

        private void cbb_angle_GotFocus(object sender, RoutedEventArgs e)
        {
            
            ComboBox comboBox = (ComboBox)sender;
            var dataItem = comboBox.DataContext;
            int rowIndex = dataGrid.Items.IndexOf(dataItem);

            List<int> selIndexs = new List<int>();
            foreach (var item in dataGrid.SelectedItems)
            {
                selIndexs.Add(dataGrid.Items.IndexOf(item));
            }
            if (!selIndexs.Any(s => s == rowIndex)) dataGrid.SelectedIndex = rowIndex;
            //MessageBox.Show(comboBox.Text+"\n"+rowIndex);
            //dataGrid.SelectedIndex = rowIndex;
            //MessageBox.Show((dataItem as DoorSymbolInfo).AngleValue.ToString());
        }

        private void cbb_angle_TextChanged(object sender, TextChangedEventArgs e)
        {
            // MessageBox.Show(((ComboBox)sender).Text + "\n" + dataGrid.SelectedItems.Count);
            if (dataGrid.SelectedIndex != -1 )
            {
                foreach (var item in dataGrid.SelectedItems)
                {
                    DoorSymbolInfo doorSymbolInfo = item as DoorSymbolInfo;
                    if (!string.IsNullOrEmpty((sender as ComboBox).Text)) doorSymbolInfo.AngleValue = Convert.ToDouble((sender as ComboBox).Text.Replace(" ",""));
                }
            }
        }

        private void cbb_angle_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }
    }
}
