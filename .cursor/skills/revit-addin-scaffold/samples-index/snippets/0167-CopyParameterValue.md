# Sample Snippet: CopyParameterValue

Source project: `existingCodes\梁涛插件源代码\8.算量插件集合\拆分（旧）\CopyParameterValue\CopyParameterValue`

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

namespace CopyParameterValue
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;

            //string cateInfo = "";
            //var cates = new FilteredElementCollector(doc).WhereElementIsElementType().Where(x => x.Category != null).Select(x => x.Category.Name).ToList();
            //cates.Distinct();
            //foreach ( var cate in cates )
            //{
            //    cateInfo += cate + "\n";
            //}
            //TaskDialog.Show("revit", cateInfo);

            //MainWindow window =  new MainWindow();
            //window.ShowDialog();
            //return Result.Succeeded;

            List<string> boxFamilyNames = new List<string>() { "配电箱", "配电柜", "控制箱", "动力箱", "接线箱", "隔离器", "端子箱", "控制器" };

            var boxs = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_ElectricalEquipment).OfClass(typeof(FamilyInstance))
                    .Cast<FamilyInstance>().Where(x => boxFamilyNames.Any(y => x.Symbol.FamilyName.Contains(y)))
                    .Where(y => y.LookupParameter("电气-配电箱编号") != null);

            int count = 0;

            using (Transaction t = new Transaction(doc, "编号参数赋值"))
            {
                t.Start();

                foreach (var box in boxs)
                {
                    var para = box.LookupParameter("编号");
                    if (para != null && para.StorageType == StorageType.String && para.IsReadOnly == false)
                    {
                        para.Set(box.LookupParameter("电气-配电箱编号").AsString());
                        count++;
                    }
                }

                t.Commit();
            }
            TaskDialog.Show("提示", $"运行完成!\n当前视图共找到配电箱：{boxs.Count()}个\n成功复制参数的配电箱：{count}个");

            return Result.Succeeded;
        }
    }
}

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

namespace CopyParameterValue
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
    }
}

```

