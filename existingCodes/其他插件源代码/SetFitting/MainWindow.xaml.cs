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

namespace SetFitting
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    
    public partial class MainWindow : Window
    {
        public bool IsClickClosed { get; set; } = false;
        List<string> setTypeList = new List<string>();
        List<string> setOriginList = new List<string>();
        public MainWindow()
        {
            InitializeComponent();

            //Cbx_Type.DataContext = setTypeList;
            setTypeList.Add("中心创建上固定");
            setTypeList.Add("中心创建下固定");
            setOriginList.Add("梁最短距离中心");
            setOriginList.Add("风管于梁之间的中心");

            Cbx_Type.ItemsSource = setTypeList;
            Cbx_Type.SelectedIndex = -1;
            Cbx_origin.ItemsSource = setOriginList;
            Cbx_origin.SelectedIndex = -1;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            IsClickClosed = true;
            this.Close();
        }

        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Cbx_Type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

           
        }
        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Cbx_Type.ItemsSource = setTypeList;
        }

    }

}
