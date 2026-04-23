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

namespace DoorReview
{
    /// <summary>
    /// ScopeWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ScopeWindow : Window
    {
        public double Scope { get; private set; }
        public bool Full { get; private set; } = false;
        public ScopeWindow()
        {
            InitializeComponent();
            tb_scope.Text = Properties.Settings.Default.Scope.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.Reset();
            Properties.Settings.Default.Save();
            tb_scope.Text = Properties.Settings.Default.Scope.ToString();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                Scope = Convert.ToInt32(tb_scope.Text);
                Properties.Settings.Default.Scope = Scope;
                Properties.Settings.Default.Save();
                if (rb_full.IsChecked == true)
                {
                    Full = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            DialogResult = true;
            Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
