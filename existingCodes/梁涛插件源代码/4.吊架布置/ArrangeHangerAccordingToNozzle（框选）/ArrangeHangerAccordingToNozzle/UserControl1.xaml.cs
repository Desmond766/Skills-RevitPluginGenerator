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

namespace ArrangeHangerAccordingToNozzle
{
    /// <summary>
    /// UserControl1.xaml 的交互逻辑
    /// </summary>
    public partial class UserControl1 : Window
    {
        public string value { get; private set; } = "";
        public bool cancel { get; private set; } = true;
        public UserControl1()
        {
            InitializeComponent();
            comboBox.Items.Add("上");
            comboBox.Items.Add("下");
            comboBox.Items.Add("左");
            comboBox.Items.Add("右");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            value = comboBox.SelectionBoxItem.ToString();
            cancel = false;
            this.Close();
        }
    }
}
