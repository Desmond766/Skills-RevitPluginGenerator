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

namespace CreateTextForBothEndsOfPipeline
{
    /// <summary>
    /// SelWindow.xaml 的交互逻辑
    /// </summary>
    public partial class SelWindow : Window
    {
        public SelWindow()
        {
            InitializeComponent();
            bool isRound = Properties.Settings.Default.IsRound;
            if (isRound)
            {
                rb_round.IsChecked = true;
            }
            else
            {
                rb_save.IsChecked = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (rb_round.IsChecked == true)
            {
                Properties.Settings.Default.IsRound = true;
            }
            else
            {
                Properties.Settings.Default.IsRound = false;
            }
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
