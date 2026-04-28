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

namespace CopySameParameterValue
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<CategoryInfo> CategoryInfos { get; set; } = new List<CategoryInfo>();
        public Document Doc { get; set; }

        public Category SelCategory { get; private set; }
        public Parameter SourcePara { get; private set; }
        public Parameter TargetPara { get; private set; }
        public MainWindow(Document doc, List<CategoryInfo> categoryInfos)
        {
            InitializeComponent();
            Doc = doc;
            CategoryInfos = categoryInfos;
            cb_cate.ItemsSource = CategoryInfos;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (cb_target.SelectedIndex == -1)
            {
                MessageBox.Show("未选择要赋值的参数");
                return;
            }
            else if ((cb_target.SelectedItem as ParameterInfo).IsReadOnly == true)
            {
                MessageBox.Show("选择的参数是只读的，无法赋值");
                return;
            }
            SelCategory = (cb_cate.SelectedItem as CategoryInfo).Category;
            SourcePara = (cb_source.SelectedItem as ParameterInfo).Parameter;
            TargetPara = (cb_target.SelectedItem as ParameterInfo).Parameter;
            DialogResult = true;
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void cb_cate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CategoryInfo categoryInfo = (sender as ComboBox).SelectedItem as CategoryInfo;
            List<ParameterInfo> parameterInfos = new List<ParameterInfo>();
            using (FilteredElementCollector elemCol = new FilteredElementCollector(Doc, Doc.ActiveView.Id).WherePasses(new ElementCategoryFilter(categoryInfo.Category.Id)))
            {
                Element element = elemCol.FirstOrDefault();
                if (element != null)
                {
                    foreach (Parameter para in element.Parameters)
                    {
                        parameterInfos.Add(new ParameterInfo() { Parameter = para, ParaName = LabelUtils.GetLabelFor(para.Definition.ParameterGroup) + "-" + para.Definition.Name, IsReadOnly = para.IsReadOnly, IsEnabled = !para.IsReadOnly });
                    }
                }
                parameterInfos = parameterInfos.OrderBy(p => p.ParaName).ToList();

                cb_source.ItemsSource = parameterInfos;
                parameterInfos = parameterInfos.OrderBy(p => p.IsReadOnly).ThenBy(p => p.ParaName).ToList();
                cb_target.ItemsSource = parameterInfos;
            }
        }
    }
}
