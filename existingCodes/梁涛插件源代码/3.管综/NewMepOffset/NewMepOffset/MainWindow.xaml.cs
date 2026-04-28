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

namespace NewMepOffset
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public double Dis { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            cb_dis.ItemsSource = new List<int>()
            {
                100,150,200,250,300,350,400,450,500,
                -100,-150,-200,-250,-300,-350,-400,-450,-500,
            };
            cb_dis.SelectedIndex = Properties.Settings.Default.Select;

            var c1 = grid1.Children;
            foreach (UIElement c in c1)
            {
                if (c is RadioButton radioButton)
                {
                    if (radioButton.Content.ToString() == (Properties.Settings.Default.UpDown == true ? "升降":"偏移"))
                    {
                        radioButton.IsChecked = true;
                    }
                }
            }
            var c2 = grid2.Children;
            foreach (UIElement c in c2)
            {
                if (c is RadioButton radioButton)
                {
                    if (radioButton.Content.ToString() == Properties.Settings.Default.Angle.ToString())
                    {
                        radioButton.IsChecked = true;
                    }
                }
            }
            var c3 = grid3.Children;
            foreach (UIElement c in c3)
            {
                if (c is RadioButton radioButton)
                {
                    if (radioButton.Content.ToString() == (Properties.Settings.Default.SingleSide == true ? "单侧" : "两侧"))
                    {
                        radioButton.IsChecked = true;
                    }
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (cb_dis.SelectedItem == null)
            {
                Dis = Convert.ToDouble(cb_dis.Text) / 304.8;
            }
            else
            {
                Dis = (int)cb_dis.SelectedItem / 304.8;
                Properties.Settings.Default.Select = cb_dis.SelectedIndex;
                Properties.Settings.Default.Save();
            }
            
            DialogResult = true;
            Close();
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            string text = radioButton.Content.ToString();
            switch (text)
            {
                case ("单侧"):
                    Properties.Settings.Default.SingleSide = true;
                    break;
                case ("两侧"):
                    Properties.Settings.Default.SingleSide = false;
                    break;
                case ("升降"):
                    Properties.Settings.Default.UpDown = true;
                    break;
                case ("偏移"):
                    Properties.Settings.Default.UpDown = false;
                    break;
                case ("15"):
                    Properties.Settings.Default.Angle = 15;
                    break;
                case ("30"):
                    Properties.Settings.Default.Angle = 30;
                    break;
                case ("45"):
                    Properties.Settings.Default.Angle = 45;
                    break;
                case ("60"):
                    Properties.Settings.Default.Angle = 60;
                    break;
                case ("90"):
                    Properties.Settings.Default.Angle = 90;
                    break;
                default:
                    break;
            }
            Properties.Settings.Default.Save();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Close();
            }
        }
    }
}
