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
                TaskDialog.Show("提示", "布置完成");
                return Result.Succeeded;
            }
            if (references1.Count <= 0)
            {
                TaskDialog.Show("提示", "没有框选到元素");
                return Result.Succeeded;
            }
            XYZ movePoint;
            try
            {
                movePoint = uidoc.Selection.PickPoint("选择吊架放置点");
            }
            catch (Exception)
            {
                TaskDialog.Show("提示", "布置完成");
                return Result.Succeeded;
            }

            //string hangerdirection = HangerDirection(doc.GetElement(references1.First()));
            string hangerdirection;
            if (IsPX)
            {
                hangerdirection = "Vertical";
            }
            else
            {
                hangerdirection = "Horizontal";
            }

            //移动
            using (Transaction tran = new Transaction(doc, "吊架对齐"))
            {
                tran.Start();

                foreach (var reference in references1)
                {
                    MoveHanger(doc, reference, movePoint, hangerdirection);
                }

                tran.Commit();
            }
            goto Next;
            return Result.Succeeded;
        }

        /// <summary>
        /// 判断方向    法兰吊架相反 
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public string HangerDirection(Element element)
        {
            if (element.Category.Id.IntegerValue == (int)BuiltInCategory.OST_MechanicalEquipment)
            {
                LocationPoint locationPoint = element.Location as LocationPoint;
                if (Math.Abs(locationPoint.Rotation - Math.PI) < 0.00001 || locationPoint.Rotation == 0 || Math.Abs(locationPoint.Rotation - Math.PI * 2) < 0.00000001)
                {
                    //return "Vertical";
                    return "Horizontal";
                }
                //return "Horizontal";
                return "Vertical";
            }
            else
            {
                LocationPoint locationPoint = element.Location as LocationPoint;
                if (Math.Abs(locationPoint.Rotation - Math.PI) < 0.00001 || locationPoint.Rotation == 0 || Math.Abs(locationPoint.Rotation - Math.PI * 2) < 0.00000001)
                {
                    return "Vertical";
                    //return "Horizontal";
                }
                return "Horizontal";
                //return "Vertical";
            }

        }

        /// <summary>
        /// 移动吊架
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="element1"></param>
        /// <param name="element2"></param>
        public void MoveHanger(Document doc, Reference reference, XYZ movePoint, string direction)
        {
            Element element = doc.GetElement(reference);
            if (direction == "Horizontal")
            {
                XYZ moveDistance = new XYZ(movePoint.X - GetPoint(element).X, 0, 0);
                ElementTransformUtils.MoveElement(doc, element.Id, moveDistance);
            }
            else if (direction == "Vertical")
            {
                XYZ moveDistance = new XYZ(0, movePoint.Y - GetPoint(element).Y, 0);
                ElementTransformUtils.MoveElement(doc, element.Id, moveDistance);
            }
            //if (direction == "Vertical")
            //{
            //    XYZ moveDistance = new XYZ(movePoint.X - GetPoint(element).X, 0, 0);
            //    ElementTransformUtils.MoveElement(doc, element.Id, moveDistance);
            //}
            //else if (direction == "Horizontal")
            //{
            //    XYZ moveDistance = new XYZ(0, movePoint.Y - GetPoint(element).Y, 0);
            //    ElementTransformUtils.MoveElement(doc, element.Id, moveDistance);
            //}
        }

        /// <summary>
        /// 获取吊架的放置点
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public XYZ GetPoint(Element element)
        {
            return (element.Location as LocationPoint).Point;
        }
    }

    public class KeyboardHook //这部分代码来自网友
    {
        public event KeyEventHandler KeyDownEvent;
        public event KeyPressEventHandler KeyPressEvent;
        public event KeyEventHandler KeyUpEvent;

        public delegate int HookProc(int nCode, Int32 wParam, IntPtr lParam);
        static int hKeyboardHook = 0; //声明键盘钩子处理的初始值
        //值在Microsoft SDK的Winuser.h里查询
        public const int WH_KEYBOARD_LL = 13;   //线程键盘钩子监听鼠标消息设为2，全局键盘监听鼠标消息设为13
        HookProc KeyboardHookProcedure; //声明KeyboardHookProcedure作为HookProc类型
        //键盘结构
        [StructLayout(LayoutKind.Sequential)]
        public class KeyboardHookStruct
        {
            public int vkCode;  //定一个虚拟键码。该代码必须有一个价值的范围1至254
            public int scanCode; // 指定的硬件扫描码的关键
            public int flags;  // 键标志
            public int time; // 指定的时间戳记的这个讯息
            public int dwExtraInfo; // 指定额外信息相关的信息
        }
        //使用此功能，安装了一个钩子
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);

        //调用此函数卸载钩子
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern bool UnhookWindowsHookEx(int idHook);

        //使用此功能，通过信息钩子继续下一个钩子
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int CallNextHookEx(int idHook, int nCode, Int32 wParam, IntPtr lParam);

        // 取得当前线程编号（线程钩子需要用到）
        [DllImport("kernel32.dll")]
        static extern int GetCurrentThreadId();

        //使用WINDOWS API函数代替获取当前实例的函数,防止钩子失效
        [DllImport("kernel32.dll")]
        public static extern IntPtr GetModuleHandle(string name);

        public void Start()
        {
            // 安装键盘钩子
            if (hKeyboardHook == 0)
            {
                KeyboardHookProcedure = new HookProc(KeyboardHookProc);
                hKeyboardHook = SetWindowsHookEx(WH_KEYBOARD_LL, KeyboardHookProcedure, GetModuleHandle(System.Diagnostics.Process.GetCurrentProcess().MainModule.ModuleName), 0);
                //hKeyboardHook = SetWindowsHookEx(WH_KEYBOARD_LL, KeyboardHookProcedure, Marshal.GetHINSTANCE(Assembly.GetExecutingAssembly().GetModules()[0]), 0);
                //************************************
                //键盘线程钩子
                SetWindowsHookEx(13, KeyboardHookProcedure, IntPtr.Zero, GetCurrentThreadId());//指定要监听的线程idGetCurrentThreadId(),
                //键盘全局钩子,需要引用空间(using System.Reflection;)
                //SetWindowsHookEx( 13,MouseHookProcedure,Marshal.GetHINSTANCE(Assembly.GetExecutingAssembly().GetModules()[0]),0);
                //
                //关于SetWindowsHookEx (int idHook, HookProc lpfn, IntPtr hInstance, int threadId)函数将钩子加入到钩子链表中，说明一下四个参数：
                //idHook 钩子类型，即确定钩子监听何种消息，上面的代码中设为2，即监听键盘消息并且是线程钩子，如果是全局钩子监听键盘消息应设为13，
                //线程钩子监听鼠标消息设为7，全局钩子监听鼠标消息设为14。lpfn 钩子子程的地址指针。如果dwThreadId参数为0 或是一个由别的进程创建的
                //线程的标识，lpfn必须指向DLL中的钩子子程。 除此以外，lpfn可以指向当前进程的一段钩子子程代码。钩子函数的入口地址，当钩子钩到任何
                //消息后便调用这个函数。hInstance应用程序实例的句柄。标识包含lpfn所指的子程的DLL。如果threadId 标识当前进程创建的一个线程，而且子
                //程代码位于当前进程，hInstance必须为NULL。可以很简单的设定其为本应用程序的实例句柄。threaded 与安装的钩子子程相关联的线程的标识符
                //如果为0，钩子子程与所有的线程关联，即为全局钩子
                //************************************
                //如果SetWindowsHookEx失败
                if (hKeyboardHook == 0)
                {
                    Stop();
                    throw new Exception("安装键盘钩子失败");
                }
            }
        }
        public void Stop()
        {
            bool retKeyboard = true;
            if (hKeyboardHook != 0)
            {
                retKeyboard = UnhookWindowsHookEx(hKeyboardHook);
                hKeyboardHook = 0;
            }
            if (!(retKeyboard)) throw new Exception("卸载钩子失败！");
        }
        //ToAscii职能的转换指定的虚拟键码和键盘状态的相应字符或字符
        [DllImport("user32")]
        public static extern int ToAscii(int uVirtKey,
                                         int uScanCode,
                                         byte[] lpbKeyState,
                                         byte[] lpwTransKey,
                                         int fuState);
        //获取按键的状态
        [DllImport("user32")]
        public static extern int GetKeyboardState(byte[] pbKeyState);
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern short GetKeyState(int vKey);
        private const int WM_KEYDOWN = 0x100;//KEYDOWN
        private const int WM_KEYUP = 0x101;//KEYUP
        private const int WM_SYSKEYDOWN = 0x104;//SYSKEYDOWN
        private const int WM_SYSKEYUP = 0x105;//SYSKEYUP

        private int KeyboardHookProc(int nCode, Int32 wParam, IntPtr lParam)
        {
            // 侦听键盘事件
            if ((nCode >= 0) && (KeyDownEvent != null || KeyUpEvent != null || KeyPressEvent != null))
            {
                KeyboardHookStruct MyKeyboardHookStruct = (KeyboardHookStruct)Marshal.PtrToStructure(lParam, typeof(KeyboardHookStruct));
                // raise KeyDown
                if (KeyDownEvent != null && (wParam == WM_KEYDOWN || wParam == WM_SYSKEYDOWN))
                {
                    Keys keyData = (Keys)MyKeyboardHookStruct.vkCode;
                    KeyEventArgs e = new KeyEventArgs(keyData);
                    KeyDownEvent(this, e);
                }
                //键盘按下
                if (KeyPressEvent != null && wParam == WM_KEYDOWN)
                {
                    byte[] keyState = new byte[256];
                    GetKeyboardState(keyState);

                    byte[] inBuffer = new byte[2];
                    if (ToAscii(MyKeyboardHookStruct.vkCode, MyKeyboardHookStruct.scanCode, keyState, inBuffer, MyKeyboardHookStruct.flags) == 1)
                    {
                        KeyPressEventArgs e = new KeyPressEventArgs((char)inBuffer[0]);
                        KeyPressEvent(this, e);
                    }
                }
                // 键盘抬起
                if (KeyUpEvent != null && (wParam == WM_KEYUP || wParam == WM_SYSKEYUP))
                {
                    Keys keyData = (Keys)MyKeyboardHookStruct.vkCode;
                    KeyEventArgs e = new KeyEventArgs(keyData);
                    KeyUpEvent(this, e);
                }
            }
            //如果返回1，则结束消息，这个消息到此为止，不再传递。
            //如果返回0或调用CallNextHookEx函数则消息出了这个钩子继续往下传递，也就是传给消息真正的接受者
            return CallNextHookEx(hKeyboardHook, nCode, wParam, lParam);
        }
        ~KeyboardHook()
        {
            Stop();
        }
    }
}
