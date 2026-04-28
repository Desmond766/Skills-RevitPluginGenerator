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
using ViewScaling.Properties;
using Settings = ViewScaling.Properties.Settings;

namespace ViewScaling
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public Document Doc { get; set; }
        public bool Cancel { get; private set; } = true;
        public MainWindow(Document doc)
        {
            InitializeComponent();
            Doc = doc;
            double scale = Settings.Default.scale;
            if (scale == 0)
            {
                Scale.Text = Doc.ActiveView.Scale.ToString();
            }
            else
            {
                Scale.Text = scale.ToString();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Convert.ToInt32(Scale.Text);
            }
            catch (Exception)
            {
                Close();
                return;
            }
            if (Doc.ActiveView.Scale != Convert.ToInt32(Scale.Text))
            {
                Cancel = false;
                Settings.Default.scale = Convert.ToInt32(Scale.Text);
                Settings.Default.Save();
                Close();
            }
            Close();
        }
    }
}
