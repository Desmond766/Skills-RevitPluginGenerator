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

namespace RampArrowParallelFloor
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            tb_dis.Text = Properties.Settings.Default.Distance.ToString();
            tb_space.Text = Properties.Settings.Default.Space.ToString();
            chb_dir.IsChecked = Properties.Settings.Default.OppositeDirection;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (Convert.ToDouble(tb_space.Text) <= 0)
                {
                    MessageBox.Show("坡道箭头间距需大于0");
                    return;
                }
                Properties.Settings.Default.Distance = Convert.ToDouble(tb_dis.Text);
                Properties.Settings.Default.Space = Convert.ToDouble(tb_space.Text);
                Properties.Settings.Default.OppositeDirection = chb_dir.IsChecked ?? false;
                Properties.Settings.Default.Save();
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
