using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
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

namespace RevitUtils
{
    /// <summary>
    /// TipWindow.xaml 的交互逻辑
    /// </summary>
    public partial class TipWindow : Window
    {
        public TipWindow(string tipContent, UIDocument uidoc)
        {
            InitializeComponent();
            lb_tip.Content = tipContent;
            this.Show();
            SetWindowPos(this, uidoc);
        }
        [DllImport("user32.dll")]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndlnsertAfter, int X, int Y, int cx, int cy, uint Flags);
        private bool SetWindowPos(Window tipWindow, UIDocument uidoc)
        {
            WindowInteropHelper windowInterop = new WindowInteropHelper(tipWindow);
            IntPtr showHandle = windowInterop.Handle;

            Autodesk.Revit.DB.Rectangle revitRectangle = GetActiveViewRectangle(uidoc);

            if (revitRectangle != null)
            {
                int statusBarWidth = revitRectangle.Right - revitRectangle.Left;
                bool res = SetWindowPos(showHandle, IntPtr.Zero, revitRectangle.Left, revitRectangle.Top, statusBarWidth, Convert.ToInt32(tipWindow.Height), 0x0040);
                return res;
            }
            return false;
        }
        private Autodesk.Revit.DB.Rectangle GetActiveViewRectangle(UIDocument uiDoc)
        {
            // 获取当前活动视图
            View activeView = uiDoc.ActiveView;

            // 遍历所有打开的UI视图
            foreach (UIView uiView in uiDoc.GetOpenUIViews())
            {
                // 匹配当前活动视图的ID
                if (uiView.ViewId == activeView.Id)
                {
                    // 直接获取视图窗口句柄
                    return uiView.GetWindowRectangle();
                }
            }
            return null; // 未找到返回空句柄
        }
    }
}
