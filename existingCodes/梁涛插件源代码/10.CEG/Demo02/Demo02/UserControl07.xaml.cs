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
using Settings = Demo02.Properties.Settings;

namespace Demo02
{
    /// <summary>
    /// UserControl07.xaml 的交互逻辑
    /// </summary>
    public partial class UserControl07 : Window
    {
        public bool cancel { get; private set; } = true;
        public UserControl07()
        {
            InitializeComponent();
            tb.Text = Settings.Default.extensionLength.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            cancel = false;
            Settings.Default.extensionLength = Convert.ToDouble(tb.Text);
            Settings.Default.Save();
            Close();
        }
    }
}
