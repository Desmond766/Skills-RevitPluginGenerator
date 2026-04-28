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

namespace HangerAlignment
{
    /// <summary>
    /// DirectionWPF.xaml 的交互逻辑
    /// </summary>
    public partial class DirectionWPF : Window
    {
        public bool IsPX { get; set; } = true;
        public bool ShowTip { get; set; } = false;
        public DirectionWPF()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (chb_tip.IsChecked == false) ShowTip = true;
            if (rb_px.IsChecked == false) IsPX = false;

            DialogResult = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
