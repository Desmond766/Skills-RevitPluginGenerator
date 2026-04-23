using Autodesk.Revit.UI;
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

namespace AdjustCableTray
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public double Dis { get; private set; }
        public MainWindow()
        {
            InitializeComponent();
            Dis_TB.Text = Properties.Settings.Default.distance.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Dis = Convert.ToDouble(Dis_TB.Text);
                if (Dis < 0)
                {
                    TaskDialog.Show("提示", "输入的值不能小于0");
                    Close();

                }
                else
                {
                    Properties.Settings.Default.distance = Dis;
                    Properties.Settings.Default.Save();
                    DialogResult = true;
                    Close();
                }

            }
            catch (Exception)
            {
                TaskDialog.Show("提示", "请输入正确的数值");
                Close();
            }

        }
    }
}
