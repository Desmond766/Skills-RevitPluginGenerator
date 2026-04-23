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

namespace HeightOFSprayPipeToTopPlate
{
    /// <summary>
    /// UserWindow.xaml 的交互逻辑
    /// </summary>
    public partial class UserWindow : Window
    {
        public List<string> ElemCategory { get; private set; } = new List<string>();
        public UserWindow()
        {
            InitializeComponent();
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                e.Handled = true;
                ConfirmButton.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            if (cb_bush.IsChecked == true)
            {
                ElemCategory.Add("套管");
            }
            if (cb_pipe.IsChecked == true)
            {
                ElemCategory.Add("喷淋支管");
            }
            this.Close();
        }
    }
}
