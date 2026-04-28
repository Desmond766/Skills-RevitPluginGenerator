# Sample Snippet: BatchUnJoin

Source project: `existingCodes\梁涛插件源代码\1.土建\BatchUnJoin\BatchUnJoin`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.Exceptions;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using RevitUtils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using OperationCanceledException = Autodesk.Revit.Exceptions.OperationCanceledException;

namespace BatchUnJoin
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;

            var cutCategoryCol = new FilteredElementCollector(doc).WhereElementIsNotElementType()
                .Where(x => JoinGeometryUtils.GetJoinedElements(doc, x).Count() > 0)
                .GroupBy(z => z.Category.Name)
                .Select(y => y.First().Category)
                .Distinct().ToList();
            List<CategoryInfo> categoryInfos = new List<CategoryInfo>();
            foreach ( var c in cutCategoryCol )
            {
                categoryInfos.Add(new CategoryInfo() { CategoryId = c.Id, CategoryName = c.Name });
            }

            MainWindow mainWindow = new MainWindow(categoryInfos);
            mainWindow.ShowDialog();

            if (mainWindow.DialogResult == false)
            {
                return Result.Cancelled;
            }

            bool isCurrentView = mainWindow.IsCurrentView;
            LogicalOrFilter orFilter = mainWindow.OrFilter;
            bool unJoinByCategory = mainWindow.UnJoinByCategory;

            ListenUtils listenUtils = new ListenUtils();
            List<Element> unJoinElements = new List<Element>();
            if (unJoinByCategory)
            {
                if (isCurrentView) unJoinElements = new FilteredElementCollector(doc, doc.ActiveView.Id).WherePasses(orFilter).WhereElementIsNotElementType().Where(e => JoinGeometryUtils.GetJoinedElements(doc, e).Count > 0).ToList();
                else unJoinElements = new FilteredElementCollector(doc).WherePasses(orFilter).WhereElementIsNotElementType().Where(e => JoinGeometryUtils.GetJoinedElements(doc, e).Count > 0).ToList();
            }
            else
            {
                try
                {
                    listenUtils.startListen();
                    unJoinElements = sel.PickObjects(ObjectType.Element, new UnJoinFilter(doc), "选择要取消连接的元素（按空格键完成框选，ESC键取消）").Select(re => doc.GetElement(re)).ToList();
                    listenUtils.stopListen();
                }
                catch (OperationCanceledException)
                {
                    listenUtils.stopListen();
                    MessageBox.Show("已取消操作");
                    return Result.Cancelled;
                }
            }

            using (TransactionGroup Tg = new TransactionGroup(doc, "批量取消连接"))
            {
                Tg.Start();

                foreach (var elem in unJoinElements)
                {
                    using (Transaction t = new Transaction(doc, "取消连接"))
                    {
                        t.Start();

                        var elemIds = JoinGeometryUtils.GetJoinedElements(doc, elem).ToList();
                        foreach (var id in elemIds)
                        {
                            JoinGeometryUtils.UnjoinGeometry(doc, elem, doc.GetElement(id));
                        }

                        t.Commit();
                    }
// ... truncated ...
```

## MainWindow.xaml.cs

```csharp
using Autodesk.Revit.DB;
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

namespace BatchUnJoin
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    
    public partial class MainWindow : Window
    {
        public List<CategoryInfo> CategoryInfos { get; set; }
        public bool UnJoinByCategory { get; private set; } = false;
        public bool IsCurrentView { get; private set; } = false;
        public LogicalOrFilter OrFilter { get; private set; }
        public MainWindow(List<CategoryInfo> categoryInfos)
        {
            InitializeComponent();
            CategoryInfos = categoryInfos;
            list.ItemsSource = CategoryInfos;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            if (button.DataContext is CategoryInfo categoryInfo)
            {
                if (button.Content.ToString() == "+")
                {
                    button.Content = "√";
                    categoryInfo.SelectCategory = true;
                }
                else
                {
                    button.Content = "+";
                    categoryInfo.SelectCategory = false;
                }
            }
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            RadioButton button = sender as RadioButton;
            if (button.Content.ToString() == "按类型")
            {
                list.Visibility = System.Windows.Visibility.Visible;
                gb_scope.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                list.Visibility = System.Windows.Visibility.Collapsed;
                gb_scope.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (CategoryInfos.Where(c => c.SelectCategory == true).Count() == 0 && rb_category.IsChecked == true)
            {
                MessageBox.Show("至少选择一个类别");
                return;
            }
            if (rb_category.IsChecked == true) UnJoinByCategory = true;
            if (rb_current_view.IsChecked == true) IsCurrentView = true;
            if (UnJoinByCategory)
            {
                var categoryFilters = new List<ElementFilter>();
                foreach (ElementId id in CategoryInfos.Where(c => c.SelectCategory == true).Select(y => y.CategoryId))
                {
                    categoryFilters.Add(new ElementCategoryFilter(id));
                }
                OrFilter = new LogicalOrFilter(categoryFilters);
            }

            DialogResult = true;
        }
// ... truncated ...
```

