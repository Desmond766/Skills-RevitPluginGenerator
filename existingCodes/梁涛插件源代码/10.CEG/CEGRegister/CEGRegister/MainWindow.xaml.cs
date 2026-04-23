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

//276C型钢吊架标注
namespace CEGRegister
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool upSet { get; set; }
        public bool cancel { get; private set; } = true;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            upSet = true;
            cancel = false;
            Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            upSet = false;
            cancel = false;
            Close();
        }
    }
}
