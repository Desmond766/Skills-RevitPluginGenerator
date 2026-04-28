# Sample Snippet: HangerAlignment

Source project: `existingCodes\饶昌锋插件源代码\257吊架对齐\HangerAlignment`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows;
using System.Runtime.InteropServices;
using System.Windows.Forms;
//遇到吊架无法移动的 120行 增加类型
namespace HangerAlignment
{
    [TransactionAttribute(TransactionMode.Manual)]
    [RegenerationAttribute(RegenerationOption.Manual)]
    public class Command : IExternalCommand
    {
        private KeyEventHandler myKeyEventHandeler = null;//按键钩子
        private KeyboardHook k_hook = new KeyboardHook();
        private void hook_KeyDown(object sender, KeyEventArgs e)
        {
            //TaskDialog.Show("revit", e.KeyValue.ToString() + (e.KeyValue == 32).ToString());
            //  这个地方认为按下了键盘上的空格键
            if (e.KeyValue == 32)
            {
                WindowUtils.SetOk();
                stopListen();
            }
            else if (e.KeyValue == 27) // ESC键
            {
                stopListen();
            }

        }
        public void startListen()
        {
            myKeyEventHandeler = new KeyEventHandler(hook_KeyDown);
            k_hook.KeyDownEvent += myKeyEventHandeler;//钩住键按下
            k_hook.Start();//安装键盘钩子
        }
        public void stopListen()
        {
            if (myKeyEventHandeler != null)
            {
                k_hook.KeyDownEvent -= myKeyEventHandeler;//取消按键事件
                myKeyEventHandeler = null;
                k_hook.Stop();//关闭键盘钩子
            }
        }

        public bool ShowTip { get; set; } = true;
        public bool IsPX { get; set; }
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;

            Next:

            if (ShowTip)
            {
                DirectionWPF directionWPF = new DirectionWPF();
                directionWPF.ShowDialog();

                if (directionWPF.DialogResult == false)
                {
                    TaskDialog.Show("提示", "布置完成");
                    return Result.Succeeded;
                }
                ShowTip = directionWPF.ShowTip;
                IsPX = directionWPF.IsPX;
            }

            IList<Reference> references1 = new List<Reference>();
            IList<Reference> references2 = new List<Reference>();
            //过滤器 
            HangerFilter filter = new HangerFilter();
            //获取元素
            try
            {
                startListen();
                references1 = uidoc.Selection.PickObjects(ObjectType.Element, filter, "请框选元素。按下空格键完成选择。");
                stopListen();
                //references2 = uidoc.Selection.PickObjects(ObjectType.Element, filter, "请框选元素。");
            }
            catch (Autodesk.Revit.Exceptions.OperationCanceledException)
            {
                stopListen();
// ... truncated ...
```

## WindowUtils.cs

```csharp
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

```

