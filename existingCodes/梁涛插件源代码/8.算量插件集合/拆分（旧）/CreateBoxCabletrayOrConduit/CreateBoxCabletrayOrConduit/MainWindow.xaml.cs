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

namespace CreateBoxCabletrayOrConduit
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            rb_high.IsChecked = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void rb_import_Checked(object sender, RoutedEventArgs e)
        {
            if (rb_import.IsChecked == true)
            {
                rb_conduit.IsChecked = true;
                rb_symbol.IsEnabled = false;
            }
        }

        private void rb_import_Unchecked(object sender, RoutedEventArgs e)
        {
            rb_symbol.IsEnabled = true;
        }

        private void rb_high_Checked(object sender, RoutedEventArgs e)
        {
            tb_high.Text = "";
            tb_high.IsEnabled = false;
        }

        private void rb_high_Unchecked(object sender, RoutedEventArgs e)
        {
            tb_high.IsEnabled = true;
        }

        private void tb_high_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
