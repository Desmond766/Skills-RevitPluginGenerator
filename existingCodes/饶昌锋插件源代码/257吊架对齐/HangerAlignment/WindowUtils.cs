using Autodesk.Revit.DB.Macros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HangerAlignment
{
    public class WindowUtils
    {
        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        internal static extern IntPtr FindWindow(string ClassName, string WindowNamw);
        [DllImport("user32.dll")]
        internal static extern int SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, int lParam);
        internal const int WM_CLICK = 0x00f5;
        [DllImport("user32")]
        internal static extern bool EnumChildWindows(IntPtr window, EnumWindowProc callback, IntPtr lparam);
        internal delegate bool EnumWindowProc(IntPtr hWnd, IntPtr parameter);//回调函数
        [DllImport("user32.dll", EntryPoint = "FindWindowEx")]
        internal static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);
        [DllImport("user32.dll")]
        internal static extern bool SetForegroundWindow(IntPtr hWnd);  //设置窗体获得焦点
        internal static IntPtr finish;

        // 点击Revit窗口上名为"完成"的按钮
        public static void SetOk()
        {
            IntPtr Revit = Autodesk.Windows.ComponentManager.ApplicationWindow;
            if (Revit != IntPtr.Zero)
            {
                FindChildClassHwnd(Revit, IntPtr.Zero);
                SendMessage(finish, WM_CLICK, IntPtr.Zero, 0);
            }
        }

        // 获取当前Revit窗口中名为"完成"的按钮的句柄(值为整数)
        internal static bool FindChildClassHwnd(IntPtr hwndParent, IntPtr lParam)
        {
            EnumWindowProc childProc = new EnumWindowProc(FindChildClassHwnd);
            IntPtr hwnd = FindWindowEx(hwndParent, IntPtr.Zero, "Button", "完成");
            if (hwnd != IntPtr.Zero)
            {
                finish = hwnd;
                return false;
            }
            EnumChildWindows(hwndParent, childProc, IntPtr.Zero);
            return true;
        }
    }
}
