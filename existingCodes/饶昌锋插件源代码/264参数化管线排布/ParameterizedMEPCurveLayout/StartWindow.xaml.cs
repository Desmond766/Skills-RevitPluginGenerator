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

namespace ParameterizedMEPCurveLayout
{
    /// <summary>
    /// StartWindow.xaml 的交互逻辑
    /// </summary>
    public partial class StartWindow : Window
    {
        private string structDistance;
        public Page page = new InsulationPage();
        public bool insulatedRadioButtonIsChecked;

        //事件
        public event EventHandler MEPCurveOperationEventHandler;
        public event EventHandler ReOrderAndIntervalHandler;
        public event EventHandler PipelineConnectionHandler;
        public event EventHandler BottomAlignmentHeightDifferenceHandler;


        /// <summary>
        /// 获取保温与非保温的单选框
        /// </summary>
        public void GetInsulatedRadioButton()
        {
            InsulationPage insulationPage = (InsulationPage)Windows.Content;
            RadioButton insulatedRadioButton = insulationPage.GetInsulatedRadioButton();
            insulatedRadioButtonIsChecked = (bool)insulatedRadioButton.IsChecked;
        }


        /// <summary>
        /// 获取结构净距的值
        /// </summary>
        /// <returns></returns>
        public string GetInsulatedTextBoxValue()
        {
            InsulationPage insulationPage = (InsulationPage)Windows.Content;
            TextBox textBox = insulationPage.GetInsulatedTextBox();
            return textBox.Text;
        }

        public void SetStructDistance(string structDistance)
        {
            this.structDistance = structDistance;
        }

        /// <summary>
        /// 获取参照管线间距的值
        /// </summary>
        /// <returns></returns>
        public string GetInputIntervalTextBoxValue()
        {
            ReOrderAndIntervalPage orderAndIntervalPage = (ReOrderAndIntervalPage)Windows.Content;
            System.Windows.Controls.TextBox textBox = orderAndIntervalPage.GetTextBox();
            return textBox.Text;
        }

        public StartWindow()
        {
            InitializeComponent();
            Windows.Navigate(page);
            if (page is InsulationPage)
            {
                PreviousClick.IsEnabled = false;
            }
        }

        /// <summary>
        /// 上一步的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Previous_Click(object sender, RoutedEventArgs e)
        {
            if (page is ReOrderAndIntervalPage)
            {
                page = new InsulationPage();
                Windows.Navigate(page);
                PreviousClick.IsEnabled = false;
            }
        }

        /// <summary>
        /// 下一步的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if (page is InsulationPage)
            {
                MEPCurveOperationEventHandler.Invoke(this, EventArgs.Empty);
                page = new ReOrderAndIntervalPage();
                Windows.Navigate(page);
                PreviousClick.IsEnabled = true;
            }
        }


        /// <summary>
        /// 完成的时间 执行管道连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CompleteClick_Click(object sender, RoutedEventArgs e)
        {
            PipelineConnectionHandler.Invoke(this, EventArgs.Empty);
            this.Close();
        }

        /// <summary>
        /// 页面转跳
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WindowsNavigated(object sender, NavigationEventArgs e)
        {
            if (page is ReOrderAndIntervalPage)
            {
                ReOrderAndIntervalPage page = Windows.Content as ReOrderAndIntervalPage;
                page.ReOrderAndIntervalHandler += ReOrderAndIntervalHandler;
                page.BottomAlignmentHeightDifferenceHandler += BottomAlignmentHeightDifferenceHandler;
            }
            if (page is InsulationPage)
            {
                InsulationPage page = Windows.Content as InsulationPage;
                page.GetInsulatedTextBox().Text = structDistance;
            }
        }
    }
}
