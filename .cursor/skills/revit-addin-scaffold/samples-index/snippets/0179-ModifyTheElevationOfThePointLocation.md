# Sample Snippet: ModifyTheElevationOfThePointLocation

Source project: `existingCodes\梁涛插件源代码\8.算量插件集合\拆分（旧）\ModifyTheElevationOfThePointLocation\ModifyTheElevationOfThePointLocation`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModifyTheElevationOfThePointLocation
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        View3D view3D = null;
        Document doc = null;
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            doc = uidoc.Document;
            Selection sel = uidoc.Selection;

            FilteredElementCollector fristCollector = new FilteredElementCollector(doc).OfClass(typeof(View3D));
            foreach (View3D view3 in fristCollector)
            {
                if ("3D 机电".Equals(view3.Name))
                {
                    view3D = view3;
                    break;
                }
            }
            if (view3D == null)
            {
                TaskDialog.Show("提示", "未找到视图：3D 机电");
                return Result.Cancelled;
            }

            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();
            if (mainWindow.DialogResult == false)
            {
                return Result.Cancelled;
            }

            List<ElementId> categoryIds = mainWindow.SelInfos.Select(x => x.CategoryId).ToList();

            List<Element> elems = new List<Element>();

            // 1.获取要调整标高的元素
            if (mainWindow.rb_sel_byself.IsChecked == true)
            {
                IList<Reference> references = null;
            selElem:
                try
                {
                    references = sel.PickObjects(ObjectType.Element, new DevFilter(categoryIds), "框选点位");
                }
                catch (Exception)
                {
                    TaskDialog dialog = new TaskDialog("提示");
                    dialog.MainInstruction = "用户已取消操作";
                    dialog.CommonButtons = TaskDialogCommonButtons.Ok | TaskDialogCommonButtons.Retry;
                    TaskDialogResult result = dialog.Show();
                    if (result == TaskDialogResult.Retry)
                    {
                        goto selElem;
                    }
                    return Result.Cancelled;
                }
                if (references.Count == 0)
                {
                    TaskDialog dialog = new TaskDialog("提示");
                    dialog.MainInstruction = "未框选到任何元素，是否重试？";
                    dialog.CommonButtons = TaskDialogCommonButtons.Ok | TaskDialogCommonButtons.Cancel;
                    TaskDialogResult result = dialog.Show();
                    if (result == TaskDialogResult.Ok)
                    {
                        goto selElem;
                    }
                    return Result.Cancelled;
                }
                elems = references.Select(r => doc.GetElement(r)).ToList();
            }
            else
            {
                List<ElementFilter> elementFilters = new List<ElementFilter>();
                foreach (var item in categoryIds)
                {
// ... truncated ...
```

## MainWindow.xaml.cs

```csharp
using Autodesk.Revit.UI;
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

namespace ModifyTheElevationOfThePointLocation
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        List<CategoryInfo> CategoryInfos = new List<CategoryInfo>();
        public List<CategoryInfo> SelInfos { get; private set; } = new List<CategoryInfo>();
        public MainWindow()
        {
            InitializeComponent();
            CategoryInfos.Add(new CategoryInfo(-2001060, "电气装置", 0));
            CategoryInfos.Add(new CategoryInfo(-2008081, "通讯设备", 0));
            CategoryInfos.Add(new CategoryInfo(-2008085, "火警设备", 0));
            CategoryInfos.Add(new CategoryInfo(-2008079, "安全设备", 0));
            lv_main.ItemsSource = CategoryInfos;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            SelInfos = CategoryInfos.Where(x => x.IsChecked == true).ToList();
            Close();
        }
    }
}

```

