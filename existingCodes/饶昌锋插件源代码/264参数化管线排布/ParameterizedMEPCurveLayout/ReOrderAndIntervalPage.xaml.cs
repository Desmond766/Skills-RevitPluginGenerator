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

namespace ParameterizedMEPCurveLayout
{
    /// <summary>
    /// ReOrderAndIntervalPage.xaml 的交互逻辑
    /// 重新选择并排序 同时计算间距
    /// </summary>
    public partial class ReOrderAndIntervalPage : Page
    {
        public event EventHandler ReOrderAndIntervalHandler;
        public event EventHandler BottomAlignmentHeightDifferenceHandler;

        public ReOrderAndIntervalPage()
        {
            InitializeComponent();
        }

        public Button GetReOrderButton()
        {
            return ReOrderButton;
        }

        public TextBox GetTextBox()
        {
            return inputIntervalTextBox;
        }

        private void ReOrderButton_Click(object sender, RoutedEventArgs e)
        {
            ReOrderAndIntervalHandler?.Invoke(this, EventArgs.Empty);
        }

        private void AligningAndElevation_Click(object sender, RoutedEventArgs e)
        {
            BottomAlignmentHeightDifferenceHandler?.Invoke(this, EventArgs.Empty);
        }
    }
}
