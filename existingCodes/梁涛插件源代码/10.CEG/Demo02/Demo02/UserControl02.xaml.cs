using Autodesk.Revit.DB;
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

namespace Demo02
{
    /// <summary>
    /// UserControl02.xaml 的交互逻辑
    /// </summary>
    public partial class UserControl02 : Window
    {
        public string value { get; private set; } = "";
        public bool cancel { get; private set; } = true;
        public UserControl02()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (comboBox.SelectionBoxItem.ToString() != "Please Select The Structural Framework")
            {
                value = comboBox.SelectionBoxItem.ToString();
                cancel = false;
                this.Close();
            }
            else
            {
                TaskDialog.Show("Tips", "Please Select The Structural Framework");
                this.Close();
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
