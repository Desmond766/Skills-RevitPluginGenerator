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
    /// UserControl03.xaml 的交互逻辑
    /// </summary>
    public partial class UserControl03 : Window
    {
        public bool cancel { get; private set; } = true;
        public UserControl03()
        {
            InitializeComponent();
            this.textBox.Text = Settings.Default.length.ToString();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            cancel = false;
            Settings.Default.length = Convert.ToDouble(this.textBox.Text);
            Settings.Default.Save();
            Close();
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textBox.Text != "")
            {
                confirm.IsEnabled = true;
            }
        }
    }
}
