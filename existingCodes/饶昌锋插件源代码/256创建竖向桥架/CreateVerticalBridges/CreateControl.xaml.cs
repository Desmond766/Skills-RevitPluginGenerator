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

namespace CreateVerticalBridges
{
    /// <summary>
    /// CreateControl.xaml 的交互逻辑
    /// </summary>
    public partial class CreateControl : Window
    {
        private bool confirmButtonFlag = false;
        public CreateControl()
        {
            InitializeComponent();
            int createType = Properties.Settings.Default.CreateType;
            switch (createType)
            {
                case (1):
                    LineCreate.IsChecked = true;
                    break;
                case (2):
                    TTypeCreate.IsChecked = true;
                    break;
                case (3):
                    LTypeCreate.IsChecked = true;
                    break;
                default:
                    break;
            }
            if (Properties.Settings.Default.CreateMethod == 1)
            {
                rb_create_both.IsChecked = true;
            }
            else
            {
                rb_create_only_cabletray.IsChecked = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            if (LineCreate.IsChecked == true)
            {
                Properties.Settings.Default.CreateType = 1;
            }
            else if (TTypeCreate.IsChecked == true)
            {
                Properties.Settings.Default.CreateType = 2;
            }
            else if (LTypeCreate.IsChecked == true)
            {
                Properties.Settings.Default.CreateType = 3;
            }

            if (rb_create_both.IsChecked == true)
            {
                Properties.Settings.Default.CreateMethod = 1;
            }
            else
            {
                Properties.Settings.Default.CreateMethod = 2;
            }

            Properties.Settings.Default.Save();

            this.confirmButtonFlag = true;
            this.Close();
        }

        public bool ConfirmButtonFlag {
            get { return confirmButtonFlag; }
            set { confirmButtonFlag = value; } 
        }
    }
    
}
