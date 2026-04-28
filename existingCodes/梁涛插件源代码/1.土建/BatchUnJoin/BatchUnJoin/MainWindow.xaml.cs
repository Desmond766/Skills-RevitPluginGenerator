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
    }
}
