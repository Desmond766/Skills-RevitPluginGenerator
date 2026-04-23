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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
