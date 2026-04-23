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

namespace HangerAlignment
{
    /// <summary>
    /// AligningControl.xaml 的交互逻辑
    /// </summary>
    public partial class VerticalAligningControl : Window
    {
        private bool isClicked = false;

        public bool IsClicked { get => isClicked; set => isClicked = value; }

        public VerticalAligningControl()
        {
            InitializeComponent();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.IsClicked = true;
            this.Close();
        }

    }
}
