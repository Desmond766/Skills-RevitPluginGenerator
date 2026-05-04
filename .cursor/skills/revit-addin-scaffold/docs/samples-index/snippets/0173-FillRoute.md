# Sample Snippet: FillRoute

Source project: `existingCodes\梁涛插件源代码\8.算量插件集合\拆分（旧）\FillRoute\FillRoute`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.DB.Macros;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.Exceptions;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using OperationCanceledException = Autodesk.Revit.Exceptions.OperationCanceledException;

namespace FillRoute
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        [DllImport("user32.dll", EntryPoint = "SetParent")]
        static extern int SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;

            MainWindow window = new MainWindow();
            window.ShowDialog();

            if (window.DialogResult == false) return Result.Cancelled;

            IList<Reference> references;
            try
            {
                references = sel.PickObjects(ObjectType.Element, "框选需要填充路由的MEP实例");
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show("已取消操作");
                return Result.Cancelled;
            }
            using (Transaction t = new Transaction(doc, "填充路由"))
            {
                t.Start();

                foreach (var refer in references)
                {
                    Element element = doc.GetElement(refer);
                    var routePara = element.LookupParameter("路由");
                    if (routePara == null || routePara.IsReadOnly == true || routePara.StorageType != StorageType.String) continue;

                    if (string.IsNullOrEmpty(routePara.AsString()))
                    {
                        routePara.Set(window.AddRouteInfo);
                    }
                    else
                    {
                        routePara.Set(routePara.AsString() + "|" + window.AddRouteInfo);
                    }
                }

                t.Commit();
            }


            return Result.Succeeded;
        }
    }
    public class RouteInfo : INotifyPropertyChanged
    {
        private string _routeName;
        public string RouteName { get => _routeName; set { _routeName = value; OnPropertyChanged(nameof(RouteName)); } }
        private string _routeState = "+";
        public string RouteState { get => _routeState; set { _routeState = value; OnPropertyChanged(nameof(RouteState)); } }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            // 展示数据变化
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
    }
// ... truncated ...
```

## MainWindow.xaml.cs

```csharp
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
// ... truncated ...
```

