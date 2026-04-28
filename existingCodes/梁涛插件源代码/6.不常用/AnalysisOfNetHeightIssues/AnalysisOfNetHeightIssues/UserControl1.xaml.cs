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

namespace AnalysisOfNetHeightIssues
{
    /// <summary>
    /// UserControl1.xaml 的交互逻辑
    /// </summary>
    public partial class UserControl1 : Window
    {
        public bool cancel { get; private set; } = true;
        public UserControl1()
        {
            InitializeComponent();
            tb.Text = Properties.Settings.Default.spacing.ToString();
            floorHeight.Text = Properties.Settings.Default.floorHeight.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            cancel = false;
            Properties.Settings.Default.spacing = Convert.ToDouble(tb.Text);
            Properties.Settings.Default.floorHeight = Convert.ToDouble(floorHeight.Text);
            Properties.Settings.Default.Save();
            Close();
        }

        private void cs_Checked(object sender, RoutedEventArgs e)
        {
            if (cs.IsChecked == true)
            {
                floorHeight.IsEnabled = true;
            }
        }

        private void height_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
