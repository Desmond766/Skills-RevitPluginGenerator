using Autodesk.Revit.DB;
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

namespace MoveParkingNumber
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window 
    {
        public double ErrorValue { get; private set; } = 0;
        public double Angle { get; private set; } = 0;
        public MainWindow()
        {
            InitializeComponent();
            tb_max_scope.Text = Properties.Settings.Default.ErrorValue.ToString();
            tb_max_angle.Text = Properties.Settings.Default.Angle.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ErrorValue = Convert.ToDouble(tb_max_scope.Text);
                Angle = Convert.ToDouble(tb_max_angle.Text);
                if (ErrorValue < 0 || Angle < 0 )
                {
                    MessageBox.Show("不能输入负数值");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            Properties.Settings.Default.ErrorValue = ErrorValue;
            Properties.Settings.Default.Angle = Angle;
            Properties.Settings.Default.Save();
            DialogResult = true;
        }
    }
}
