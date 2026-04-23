using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace HangerUpdate
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            tb_search_scope.Text = Properties.Settings.Default.Radius.ToString();
            tb_down_scope.Text = Properties.Settings.Default.DownRayScope.ToString();

            var hangerSymbols = Properties.Settings.Default.HangerSymbol.Trim(',').Split(',').Cast<string>().ToList();
            var hangerFamilies = Properties.Settings.Default.HangerFamily.Trim(',').Split(',').Cast<string>().ToList();

            hangerSymbols.ForEach(x => cb_symbol.Items.Add(x));
            hangerFamilies.ForEach(x => cb_family.Items.Add(x));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.HangerFamily = string.Join(",", cb_family.Items.Cast<string>().ToList());
            Properties.Settings.Default.HangerSymbol = string.Join(",", cb_symbol.Items.Cast<string>().ToList());
            Properties.Settings.Default.Radius = Convert.ToDouble(tb_search_scope.Text);
            Properties.Settings.Default.DownRayScope = Convert.ToDouble(tb_down_scope.Text);
            Properties.Settings.Default.Save();
            DialogResult = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(cb_family.Text) && !cb_family.Items.Cast<string>().Contains(cb_family.Text))
            {
                cb_family.Items.Add(cb_family.Text);
                cb_family.Text = "";
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(cb_symbol.Text) && !cb_symbol.Items.Cast<string>().Contains(cb_symbol.Text))
            {
                cb_symbol.Items.Add(cb_symbol.Text);
                cb_symbol.Text = "";
            }
        }

        private void DeleteItem_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show((sender as Button).Tag.ToString());
            cb_family.Items.Remove((sender as Button).Tag);
        }

        private void DeleteItem_Click_2(object sender, RoutedEventArgs e)
        {
            cb_symbol.Items.Remove((sender as Button).Tag);
        }
    }
    //public class HangerSymbolInfo : INotifyPropertyChanged
    //{
    //    private string _hangerSymbol;
    //    public string HangerSymbol
    //    {
    //        get { return _hangerSymbol; }
    //        set
    //        {
    //            if (_hangerSymbol != value)
    //            {
    //                _hangerSymbol = value;
    //                OnPropertyChanged(nameof(HangerSymbol));
    //            }
    //        }
    //    }

    //    public event PropertyChangedEventHandler PropertyChanged;
    //    protected virtual void OnPropertyChanged(string propertyName)
    //    {
    //        // 展示数据变化
    //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    //    }
    //}
    //public class HangerFamilyInfo : INotifyPropertyChanged
    //{
    //    private string _hangerFamily;
    //    public string HangerFamily
    //    {
    //        get { return _hangerFamily; }
    //        set
    //        {
    //            if (_hangerFamily != value)
    //            {
    //                _hangerFamily = value;
    //                OnPropertyChanged(nameof(HangerFamily));
    //            }
    //        }
    //    }

    //    public event PropertyChangedEventHandler PropertyChanged;
    //    protected virtual void OnPropertyChanged(string propertyName)
    //    {
    //        // 展示数据变化
    //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    //    }
    //}
}
