# Sample Snippet: CopySameParameterValue

Source project: `existingCodes\梁涛插件源代码\6.不常用\CopySameParameterValue\CopySameParameterValue`

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
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CopySameParameterValue
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;

            List<Category> categories = new FilteredElementCollector(doc, doc.ActiveView.Id).Select(e => e.Category)
                .Where(c => c != null).Select(c => c.Id).Distinct().Select(id => Category.GetCategory(doc, id)).Where(c => c != null).ToList();
            //foreach (var item in categories)
            //{
            //    TaskDialog.Show("e", item.Name);
            //}
            //TaskDialog.Show("r", categories.Count.ToString());

            List<CategoryInfo> categoryInfos = new List<CategoryInfo>();
            foreach (Category c in categories)
            {
                categoryInfos.Add(new CategoryInfo() { Category = c, CategoryName = c.Name });
            }
            categoryInfos = categoryInfos.OrderBy(c => c.CategoryName).ToList();

            MainWindow mainWindow = new MainWindow(doc, categoryInfos);
            mainWindow.ShowDialog();

            if (mainWindow.DialogResult == false)
            {
                return Result.Cancelled;
            }

            using (Transaction t = new Transaction(doc, "参数复制"))
            {
                t.Start();

                var elems = new FilteredElementCollector(doc, doc.ActiveView.Id).WherePasses(new ElementCategoryFilter(mainWindow.SelCategory.Id));
                foreach (var elem in elems)
                {
                    dynamic value = GetParameterValue(elem, mainWindow.SourcePara, out var storageType);
                    SetParamenterValue(elem, mainWindow.TargetPara, value, storageType);
                }

                t.Commit();
            }

            MessageBox.Show("运行完成！");

            return Result.Succeeded;

            //List<ElementFilter> elementFilters = new List<ElementFilter>()
            //{
            //    new ElementCategoryFilter(BuiltInCategory.OST_MechanicalEquipment),
            //    new ElementCategoryFilter(BuiltInCategory.OST_ElectricalEquipment),
            //    new ElementCategoryFilter(BuiltInCategory.OST_PipeAccessory),
            //    new ElementCategoryFilter(BuiltInCategory.OST_DuctAccessory),
            //};
            //LogicalOrFilter orFilter = new LogicalOrFilter(elementFilters);
            //var elemCol = new FilteredElementCollector(doc).WherePasses(orFilter).WhereElementIsNotElementType();

            //using (Transaction t = new Transaction(doc, "统一相同参数值"))
            //{
            //    t.Start();

            //    foreach (var elem in elemCol)
            //    {
            //        var paras = elem.Parameters.Cast<Parameter>().ToList();
            //        var para1 = paras.FirstOrDefault(p => p.Definition.Name == "设备分类编码" && p.StorageType == StorageType.String && !string.IsNullOrEmpty(p.AsString()));
            //        var para2 = paras.FirstOrDefault(p => p.Definition.Name == "设备编号" && p.StorageType == StorageType.String && !string.IsNullOrEmpty(p.AsString()));
            //        var paras1 = paras.Where(p => p.Definition.Name == "设备分类编码" && !p.IsReadOnly && p.StorageType == StorageType.String && string.IsNullOrEmpty(p.AsString()));
            //        var paras2 = paras.Where(p => p.Definition.Name == "设备编号" && !p.IsReadOnly && p.StorageType == StorageType.String && string.IsNullOrEmpty(p.AsString()));

            //        if (para1 != null)
            //        {
            //            string paraValue1 = para1.AsString();
            //            foreach (var para in paras1)
            //            {
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

```

