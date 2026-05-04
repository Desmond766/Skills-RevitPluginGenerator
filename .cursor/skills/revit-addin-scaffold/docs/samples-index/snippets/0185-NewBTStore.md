# Sample Snippet: NewBTStore

Source project: `existingCodes\梁涛插件源代码\9.新品成插件商店\NewBTStore\NewBTStore`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Autodesk.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UIFramework;
using TaskDialog = Autodesk.Revit.UI.TaskDialog;
using RibbonPanel = Autodesk.Revit.UI.RibbonPanel;
using System.IO;
using static NewBTStore.Ribbon;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using static UIFramework.WorksharingNotificationWindow;
using System.Threading;
using System.Diagnostics;

namespace NewBTStore
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll", EntryPoint = "GetCursorPos")]
        public static extern bool GetCursorPos(ref POINTAPI lpPoint);

        [DllImport("user32.dll", EntryPoint = "WindowFromPoint")]
        public static extern IntPtr WindowFromPoint(int xPoint, int yPoint);
        [StructLayout(LayoutKind.Sequential)]
        public struct POINTAPI
        {
            public int X;
            public int Y;
        }
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll", EntryPoint = "FindWindowEx")]
        internal static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);
        [DllImport("user32.dll")]
        static extern IntPtr GetFocus();
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            UIApplication uiapp = commandData.Application;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;

            //TaskDialog.Show("rveit", GetFocus().ToString("X8"));
            //return Result.Succeeded;

            //TaskDialog.Show("rr", ComponentManager.ApplicationWindow.ToString());
            //ShowWindow(ComponentManager.ApplicationWindow, 6);
            //ShowWindow(ComponentManager.ApplicationWindow, 9);
            //Thread.Sleep(2000);
            //SetForegroundWindow(ComponentManager.ApplicationWindow);
            //SetForegroundWindow(new IntPtr(2296570));

            //IntPtr desktop = FindWindow("Button", "临时隐藏/隔离");
            //var parentW = ComponentManager.ApplicationWindow;
            //IntPtr intPtr = FindWindowEx(parentW, IntPtr.Zero, "Button", "临时隐藏/隔离");
            //TaskDialog.Show("revit", desktop.ToString() + "\n" + parentW);
            //return Result.Succeeded;
            //PageWindow.SetActiveWindow(desktop);

            //PageWindow.SetActiveWindow(new IntPtr(856686));
            //return Result.Succeeded;

            //POINTAPI point = new POINTAPI();
            //GetCursorPos(ref point);
            //var hwnd2 = WindowFromPoint(point.X, point.Y);
            //var hwnd = FindWindow(null, "");
            //if (hwnd.ToInt32() != 0) SetForegroundWindow(hwnd);
            //TaskDialog.Show("revit", hwnd2.ToString() + "\n" + ComponentManager.ApplicationWindow);
            //return Result.Succeeded;

            //PageWindow.active = Autodesk.Windows.ComponentManager.ApplicationWindow;

            //string key = EncryptionUtils.MD5Encrypt("419191045", "BIMTRANS");
            //TaskDialog.Show("revit", key);
            //return Result.Succeeded;
// ... truncated ...
```

## Utils.cs

```csharp
using Autodesk.Revit.UI;
using Autodesk.Windows;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using UIFramework;
using TaskDialog = Autodesk.Revit.UI.TaskDialog;

namespace NewBTStore
{
    public class Utils
    {
        // 远程部署的程序集路径
        static string assemblyPath = @"\\192.168.0.251\在制项目2\品成Revit插件商店\品成Revit插件商店\BTAddinHelper.dll";

        // 加载远程程序集
        static Assembly remoteAssembly = Assembly.UnsafeLoadFrom(assemblyPath);
        // 载入Ribbon
        public static void LoadRibbon(UIControlledApplication uiapp)
        {
            if (string.IsNullOrEmpty(Store.StorePath)) return;
            try
            {
                CopyFilesFlat(Store.StorePath, @"C:\Program Files\BIMTRANS\NewBTStore\");
            }
            catch (Exception e)
            {
                TaskDialog.Show("Error", e.Message);
                return;
            }


            var cSVInfos = CSVInfo.ReadCSVInfo(Path.Combine(Store.StorePath, "新插件版本记录表.csv"));
            cSVInfos = cSVInfos.OrderBy(x => Convert.ToInt32(x.Serial)).ToList();

            // 创建Ribbon
            foreach (var item in cSVInfos)
            {
                string dllPath = Path.Combine(Store.StorePath, item.Serial + item.Name, item.DllPath);
                //dllPath = Path.Combine(@"C:\Program Files\BIMTRANS\NewBTStore", item.Serial + item.Name, item.DllPath);
                //dllPath = @"C:\Program Files\BIMTRANS\BTAddInStore\addins\FlippingBeam.dll";
                //dllPath = @"C:\Users\Administrator\Desktop\24.9.20算量插件\QuantityTools\QuantityTools\bin\Debug\QuantityTools.dll";
                dllPath = @"C:\Program Files\BIMTRANS\NewBTStore\" + item.DllPath;
                Assembly assembly;
                try
                {
                    byte[] assemblyBuffer = File.ReadAllBytes(dllPath);

                    //assembly = Assembly.LoadFrom(dllPath);
                    assembly = Assembly.Load(assemblyBuffer);
                }
                catch (Exception e)
                {
                    continue;
                }

                Type commandType = assembly.GetTypes()
                .FirstOrDefault(t => typeof(IExternalCommand).IsAssignableFrom(t) && !t.IsAbstract && t.FullName == item.ClassName);
                if (commandType == null) continue;

                PushButtonData buttonData;
                // 创建新按钮
                buttonData = new PushButtonData(
                    item.DllPath.Replace(".dll", ""),      // 使用唯一的内部名称
                    item.Name,           // 先使用文件名作为显示名称
                    dllPath,               // 使用完整路径
                    commandType.FullName); // 完整的类型名称

                var panel = uiapp.GetRibbonPanels("新品成插件商店").FirstOrDefault(p => p.Name == item.Subject);
                if (panel == null) continue;

                // 添加按钮并设置属性
                PushButton newButton = panel.AddItem(buttonData) as PushButton;
                newButton.Image = Ribbon.ConvertBitmapToImageSource(ImageResource.bimtrans16px);
                newButton.LargeImage = Ribbon.ConvertBitmapToImageSource(ImageResource.bimtrans);
                newButton.ToolTip = "";
                if (!string.IsNullOrEmpty(item.Description)) newButton.ToolTip = item.Description;
            }
        }
// ... truncated ...
```

## AfterUpdateWpf.xaml.cs

```csharp
using Autodesk.Revit.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
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
using Application = Autodesk.Revit.ApplicationServices.Application;

namespace NewBTStore
{
    /// <summary>
    /// AfterUpdateWpf.xaml 的交互逻辑
    /// </summary>
    public partial class AfterUpdateWpf : Window
    {
        public bool UpdateNow { get; private set; } = false;
        public bool AfterUpdate { get; private set; } = false;
        public bool CloseUpdate { get; private set; } = false;
        public AfterUpdateWpf(Application app)
        {
            InitializeComponent();
            
            string versionNum = app.VersionNumber;
            string fileName = Path.Combine(BTStoreUpdate.TargetPath, versionNum, BTStoreUpdate.DllName);
            string currentVersion = FileVersionInfo.GetVersionInfo(fileName).FileVersion;
            string sourceVersion = FileVersionInfo.GetVersionInfo(BTStoreUpdate.SourcePath).FileVersion;
            lb_update_info.Content = $"发现新版本：{currentVersion} → {sourceVersion}";
        }

// ... truncated ...
```

