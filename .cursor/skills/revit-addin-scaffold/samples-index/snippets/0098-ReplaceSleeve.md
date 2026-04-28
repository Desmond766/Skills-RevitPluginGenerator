# Sample Snippet: ReplaceSleeve

Source project: `existingCodes\梁涛插件源代码\1.土建\ReplaceSleeve\ReplaceSleeve`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using Autodesk.Revit.Attributes;
using Autodesk.Revit.Creation;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using RevitUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Interop;
using Document = Autodesk.Revit.DB.Document;

namespace ReplaceSleeve
{
    // 一键替换空心套柱
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;

            // 获取项目中所有结构柱类型
            List<Family> columnFamilys = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_StructuralColumns).OfClass(typeof(FamilySymbol)).Cast<FamilySymbol>()
                .Select(fs => fs.Family).Distinct().Where(f => IsFindFamily(doc, f)).ToList();
            List<string> familyNames = columnFamilys.Select(f => f.Name).Distinct().ToList();
            MainWindow window = new MainWindow();
            window.cbb_old_type.ItemsSource = familyNames;
            window.cbb_new_type.ItemsSource = familyNames;
            IntPtr intPtr = commandData.Application.MainWindowHandle;
            // 一个提供WPF窗体和win32之间互相操作的类，允许开发者获取WPF窗体的hwnd和设置WPF窗体的所有者
            WindowInteropHelper windowInteropHelper = new WindowInteropHelper(window);
            windowInteropHelper.Owner = intPtr;
            window.ShowDialog();
            if (window.DialogResult == false)
            {
                return Result.Cancelled;
            }

            // 获取视图中的结构柱
            List<FamilyInstance> columns = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_StructuralColumns).OfClass(typeof(FamilyInstance)).Cast<FamilyInstance>()
                .Where(c => c.Symbol.FamilyName.Equals(window.cbb_old_type.SelectionBoxItem.ToString()) && c.Symbol.LookupParameter("宽度") != null && (c.Symbol.LookupParameter("长度") != null || c.Symbol.LookupParameter("深度") != null)).ToList();

            // 获取空心柱族
            FamilySymbol columnSymbol = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_StructuralColumns).WhereElementIsElementType()
                .Cast<FamilySymbol>().Where(s => s.FamilyName.Equals(window.cbb_new_type.SelectionBoxItem.ToString())).FirstOrDefault();
            if (columnSymbol == null)
            {
                message = "未找到空心柱族";
                return Result.Failed;
            }
            Family columnFamily = columnSymbol.Family;
            if (columnFamily.GetFamilySymbolIds().Count == 0)
            {
                message = "未找到空心柱族类型";
                return Result.Failed;
            }

            ProgressBarView pbv = new ProgressBarView();
            IntPtr revitIntPtr = commandData.Application.MainWindowHandle;
            WindowInteropHelper windowInteropHelper2 = new WindowInteropHelper(pbv);
            windowInteropHelper2.Owner = revitIntPtr;
            pbv.Topmost = true;
            pbv.SetProgressBar(0, columns.Count, "- 1/1", "一键替换柱中...");
            pbv.SetTotalProgress(1, 1);
            pbv.Show();

            //TaskDialog.Show("rebot", columnFamily.Id + "\n" + columnFamily.Name + "\n" + columnFamily.GetFamilySymbolIds().Count);
            using (TransactionGroup tg = new TransactionGroup(doc, "一键替换空心柱"))
            {
                tg.Start();

                foreach (var column in columns)
                {
                    if (pbv.Cancel == true)
                    {
                        pbv.Close();
                        return Result.Cancelled;
                    }
                    pbv.SetValue(columns.IndexOf(column) + 1, columns.Count);
                    pbv.SetNowProgress(columns.IndexOf(column) + 1, columns.Count);
                    System.Windows.Forms.Application.DoEvents();

                    double width = column.Symbol.LookupParameter("宽度").AsDouble();
// ... truncated ...
```

## MainWindow.xaml.cs

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

namespace ReplaceSleeve
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(cbb_old_type.SelectionBoxItem.ToString()) || string.IsNullOrEmpty(cbb_new_type.SelectionBoxItem.ToString()))
            {
                MessageBox.Show("不能为空");
                return;
            }
            DialogResult = true;
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

```

