# Sample Snippet: NewBTStoreUpdater

Source project: `existingCodes\梁涛插件源代码\9.新品成插件商店\NewBTStoreUpdater\NewBTStoreUpdater`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Program.cs

```csharp
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Threading;

namespace NewBTStoreUpdater
{
    internal class Program
    {
        //[STAThread]
        static void Main(string[] args)
        {
            string sourcePath = @"\\192.168.0.251\在制项目2\品成Revit插件商店\品成商店升级方案\NewBTStore.dll";
            //UpdateWindow updateWindow = new UpdateWindow();
            //updateWindow.ShowDialog();
            //MessageBox.Show("succeed");
            //return;

            ShowWindow(Process.GetCurrentProcess().MainWindowHandle, SW_HIDE);
            if (args.Length == 0 || args[0] != "UseAutoUpdate")
            {
                MessageBox.Show("新品成商店自动更新程序，请勿手动点击", "警告", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            List<string> updateAddrs = new List<string>();
            updateAddrs = args.Select(x => x).ToList();
            updateAddrs.Remove(updateAddrs.First());
            //string info = string.Join("\n", updateAddrs);
            //MessageBox.Show(info + updateAddrs.Count() + "更新成功");
            //return;

            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("zh-CN");
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("zh-CN");
            int tryCount = 0;
            bool tryAgagin = true;
            while (tryAgagin)
            {
                tryCount++;
                Thread.Sleep(3000);
                try
                {
                    //File.Copy(@"C:\Users\Administrator\Desktop\NewBTStore\NewBTStore\bin\Debug\NewBTStore.dll", @"C:\ProgramData\Autodesk\Revit\Addins\2020\NewBTStore.dll", true);
                    foreach (var path in updateAddrs)
                    {
                        File.Copy(sourcePath, path, true);
                    }
                }
                catch (IOException ex)
                {
                    if (ex.Message.Contains("正由另一进程使用，因此该进程无法访问此文件。"))
                    {
                        if (tryCount <= 60)
                        {
                            Console.WriteLine($"TryCount:{tryCount}");
                            Console.WriteLine("Update Agagin");
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("Update Failed");
                            break;
                        }

                    }
                    Console.WriteLine("Update Failed");
                    break;
                }
                Console.WriteLine("Update Succeed");
                break;
            }

        }
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int SW_HIDE = 0;
        private const int SW_SHOW = 5; // 可根据需要选择显示或隐藏状态码
    }
}

```

## UpdateWindow.xaml.cs

```csharp
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

namespace NewBTStoreUpdater
{
    /// <summary>
    /// UpdateWindow.xaml 的交互逻辑
    /// </summary>
    public partial class UpdateWindow : Window
    {
        public UpdateWindow()
        {
            InitializeComponent();
        }
    }
}

```

## Properties\AssemblyInfo.cs

```csharp
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// 有关程序集的一般信息由以下
// 控制。更改这些特性值可修改
// 与程序集关联的信息。
[assembly: AssemblyTitle("NewBTStoreUpdater")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("NewBTStoreUpdater")]
[assembly: AssemblyCopyright("Copyright ©  2025")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// 将 ComVisible 设置为 false 会使此程序集中的类型
//对 COM 组件不可见。如果需要从 COM 访问此程序集中的类型
//请将此类型的 ComVisible 特性设置为 true。
[assembly: ComVisible(false)]

// 如果此项目向 COM 公开，则下列 GUID 用于类型库的 ID
[assembly: Guid("088a8a07-a6bb-411a-a7de-a7582aaf98f1")]

// 程序集的版本信息由下列四个值组成: 
//
//      主版本
//      次版本
//      生成号
//      修订号
//
//可以指定所有这些值，也可以使用“生成号”和“修订号”的默认值
//通过使用 "*"，如下所示:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.1")]

```

