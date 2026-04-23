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

namespace ReviewDoorClearHeight
{
    /// <summary>
    /// SelWindow.xaml 的交互逻辑
    /// </summary>
    public partial class SelWindow : Window
    {
        public SelWindow()
        {
            InitializeComponent();
            switch (Properties.Settings.Default.FindType)
            {
                case 0:
                    rb_link.IsChecked = true;
                    break;
                case 1:
                    rb_local.IsChecked = true;
                    break;
                case 2:
                    rb_both.IsChecked = true;
                    break;
                default:
                    break;
            }
            if (Properties.Settings.Default.IsLinkDoor)
            {
                rb_link_door.IsChecked = true;
            }
            else
            {
                rb_local_door.IsChecked = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (rb_link.IsChecked == true)
                {
                    Properties.Settings.Default.FindType = 0;
                }
                else if (rb_local.IsChecked == true)
                {
                    Properties.Settings.Default.FindType = 1;
                }
                else if (rb_both.IsChecked == true)
                {
                    Properties.Settings.Default.FindType = 2;
                }

                if (rb_link_door.IsChecked == true)
                {
                    Properties.Settings.Default.IsLinkDoor = true;
                }
                else
                {
                    Properties.Settings.Default.IsLinkDoor = false;
                }

                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            DialogResult = true;
            Close();
        }
    }
}
