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

namespace AddLightsAccordingToCAD
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public double Distance { get; private set; }
        public double Angle { get; private set; }
        public bool Cancel { get; private set; } = false;
        public MainWindow()
        {
            InitializeComponent();
            tb_dis.Text = Properties.Settings.Default.distance.ToString();
            tb_angle.Text = Properties.Settings.Default.angle.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            try
            {
                Distance = Convert.ToDouble(tb_dis.Text);
                Angle = Convert.ToDouble(tb_angle.Text);
            }
            catch (Exception ex)
            {
                Cancel = true;
                TaskDialog.Show("Error", ex.Message);
                Close();
                return;
            }
            Properties.Settings.Default.distance = Distance;
            Properties.Settings.Default.angle = Angle;
            Properties.Settings.Default.Save();
            Close();
        }
    }
}
