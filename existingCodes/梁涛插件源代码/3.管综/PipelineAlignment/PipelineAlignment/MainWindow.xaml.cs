using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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

namespace PipelineAlignment
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        [DllImport("user32.dll", SetLastError = true)]
        private static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);

        // ESC键的虚拟键码
        private const byte VK_ESCAPE = 0x1B;

        // 按键标志
        private const uint KEYEVENTF_EXTENDEDKEY = 0x0001;
        private const uint KEYEVENTF_KEYUP = 0x0002;

        public bool IsClose { get; private set; } = false;
        public MainWindow()
        {
            InitializeComponent();
            cb_thickness.IsChecked = Properties.Settings.Default.InsulationLayer;
            switch (Properties.Settings.Default.Alignment)
            {
                case (1):
                    rb_top.IsChecked = true;
                    break;
                case (2):
                    rb_center.IsChecked = true;
                    break;
                case (3):
                    rb_bottom.IsChecked = true;
                    break;
                default:
                    break;
            }
        }

        private void rb_top_Checked(object sender, RoutedEventArgs e)
        {
            if (rb_top.IsChecked == true)
            {
                Properties.Settings.Default.Alignment = 1;
                Properties.Settings.Default.Save();
            }
        }

        private void rb_center_Checked(object sender, RoutedEventArgs e)
        {
            if (rb_center.IsChecked == true)
            {
                Properties.Settings.Default.Alignment = 2;
                Properties.Settings.Default.Save();
            }
        }

        private void rb_bottom_Checked(object sender, RoutedEventArgs e)
        {
            if (rb_bottom.IsChecked == true)
            {
                Properties.Settings.Default.Alignment = 3;
                Properties.Settings.Default.Save();
            }
        }

        private void cb_thickness_Checked(object sender, RoutedEventArgs e)
        {
            if (cb_thickness.IsChecked == true)
            {
                Properties.Settings.Default.InsulationLayer = true;
            }
            else
            {
                Properties.Settings.Default.InsulationLayer = false;
            }
            Properties.Settings.Default.Save();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            IsClose = true;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SimulateEscapePress();
        }

        /// <summary>
        /// 方法1：使用Windows API模拟ESC键
        /// </summary>
        private void SimulateEscapePress()
        {
            try
            {
                // 按下ESC键
                keybd_event(VK_ESCAPE, 0, KEYEVENTF_EXTENDEDKEY, UIntPtr.Zero);

                // 等待10毫秒
                System.Threading.Thread.Sleep(10);

                // 释放ESC键
                keybd_event(VK_ESCAPE, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
            }
            catch (Exception ex)
            {
                throw new Exception($"模拟ESC键失败: {ex.Message}");
            }
        }
    }
}
