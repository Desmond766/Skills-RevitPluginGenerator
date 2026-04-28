using Autodesk.Revit.DB.Macros;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FillRoute
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<RouteInfo> RouteInfos = new List<RouteInfo>();
        public string AddRouteInfo { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            list_all_route.ItemsSource = RouteInfos;
            //list_add_route.ItemsSource = RouteInfos;
            if (File.Exists(@"C:\Users\Administrator\Desktop\Route.txt"))
            {
                tb_file_route.Text = @"C:\Users\Administrator\Desktop\Route.txt";

                string filePath = @"C:\Users\Administrator\Desktop\Route.txt";
                FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                byte[] b = new byte[fs.Length];
                fs.Read(b, 0, b.Length);
                fs.Close();
                string content = Encoding.UTF8.GetString(b);

                string[] routeNames = content.Split('\n');
                List<RouteInfo> newInfos = new List<RouteInfo>();

                try
                {
                    foreach (var route in routeNames)
                    {
                        newInfos.Add(new RouteInfo() { RouteName = route });
                    }
                    newInfos = newInfos.Distinct().ToList();
                    RouteInfos = newInfos;
                    //list_add_route.ItemsSource = RouteInfos;
                    list_all_route.ItemsSource = RouteInfos;
                    cb_start_route.ItemsSource = RouteInfos.GroupBy(x => x.RouteName.Split(':')[0]).Select(x => x.Key + ":");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "选择文件";
            openFileDialog.Filter = "文本文件| *.txt";
            if (openFileDialog.ShowDialog() == true)
            {
                tb_file_route.Text = openFileDialog.FileName;

                string filePath = openFileDialog.FileName;
                FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                byte[] b = new byte[fs.Length];
                fs.Read(b, 0, b.Length);
                fs.Close();
                string content = Encoding.UTF8.GetString(b);
                
                string[] routeNames = content.Split('\n');
                List<RouteInfo> newInfos = new List<RouteInfo>();

                try
                {
                    foreach (var route in routeNames)
                    {
                        newInfos.Add(new RouteInfo() { RouteName = route });
                    }
                    newInfos = newInfos.Distinct().ToList();
                    RouteInfos = newInfos;
                    //list_add_route.ItemsSource = RouteInfos;
                    list_all_route.ItemsSource = RouteInfos;
                    cb_start_route.ItemsSource = RouteInfos.GroupBy(x => x.RouteName.Split(':')[0]).Select(x => x.Key);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            tb_search.Text = "";

            //list_all_route.ItemsSource = RouteInfos;
            //cb_start_route.SelectedIndex = -1;
        }

        private void cb_start_route_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cb_start_route.SelectedIndex == -1) return;
            string startRouteName = cb_start_route.SelectedItem.ToString();
            list_all_route.ItemsSource = RouteInfos.Where(r => (r.RouteName.Split(':')[0] + ":").Equals(startRouteName));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (list_add_route.Items.Count == 0)
            {
                MessageBox.Show("至少选择一个路由来填充");
                return;
            }
            string addRouteInfo = "";
            for (int i = 0; i < list_add_route.Items.Count; i++)
            {
                RouteInfo routeInfo = list_add_route.Items[i] as RouteInfo;
                if (i == 0) addRouteInfo = routeInfo.RouteName;
                else addRouteInfo += "|" + routeInfo.RouteName;
            }
            AddRouteInfo = addRouteInfo;
            DialogResult = true;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            
            // 根据DataContext获取
            if ((sender as Button).DataContext is RouteInfo)
            {
                RouteInfo routeInfo = (sender as Button).DataContext as RouteInfo;

                bool hasAdd = false;
                foreach (var item in list_add_route.Items)
                {
                    RouteInfo routeInfo1 = item as RouteInfo;
                    if (routeInfo1.RouteName.Equals(routeInfo.RouteName))
                    {
                        hasAdd = true;
                        break;
                    }
                }
                if (!hasAdd)
                {
                    list_add_route.Items.Add(routeInfo);
                    button.Content = "√";
                }
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

            if ((sender as Button).DataContext is RouteInfo)
            {
                RouteInfo routeInfo = (sender as Button).DataContext as RouteInfo;
                list_add_route.Items.Remove(routeInfo);

                RouteInfos.Where(x => x.RouteName == routeInfo.RouteName).ToList().ForEach(y => y.RouteState = "+");

                //button.Content = "-";
            }
        }

        private void TextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            list_all_route.ItemsSource = RouteInfos.Where(r => r.RouteName.IndexOf(textBox.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }
    }
}
