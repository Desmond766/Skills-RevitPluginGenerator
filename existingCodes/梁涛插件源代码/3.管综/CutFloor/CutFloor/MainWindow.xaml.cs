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

namespace CutFloor
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool SplitByNum { get; private set; }
        public bool SplitBySpace { get; private set; }
        public int Num { get; private set; }
        public double Space { get; private set; }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (rb_num.IsChecked == true)
            {
                SplitByNum = true;
                try
                {
                    Num = Convert.ToInt32(tb_num.Text);
                    if (Num <= 0)
                    {
                        MessageBox.Show("输入的数需大于0");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            else
            {
                SplitBySpace = true;
                try
                {
                    Space = Convert.ToDouble(tb_space.Text) / 304.8;
                    if (Space <= 0)
                    {
                        MessageBox.Show("输入的数需大于0");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            DialogResult = true;
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
