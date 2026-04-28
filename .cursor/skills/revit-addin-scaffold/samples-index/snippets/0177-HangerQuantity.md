# Sample Snippet: HangerQuantity

Source project: `existingCodes\梁涛插件源代码\8.算量插件集合\拆分（旧）\HangerQuantity\HangerQuantity`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Visual;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using Application = Microsoft.Office.Interop.Excel.Application;
using MessageBox = System.Windows.MessageBox;
using View = Autodesk.Revit.DB.View;

namespace HangerQuantity
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;

            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();
            if (mainWindow.DialogResult == false || (mainWindow.WaterCheck == false && mainWindow.HVACCheck == false))
            {
                return Result.Cancelled;
            }

            var views = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Views).WhereElementIsNotElementType().Cast<View>();
            View waterView = null;
            View HVACView = null;
            if (mainWindow.WaterCheck == true)
            {
                waterView = views.FirstOrDefault(v => v.Name.Equals("水电抗震吊架出图"));
                if (waterView == null)
                {
                    message = "未找到视图：水电抗震吊架出图";
                    return Result.Cancelled;
                }
            }
            if (mainWindow.HVACCheck == true)
            {
                HVACView = views.FirstOrDefault(v => v.Name.Equals("暖通抗震吊架出图"));
                if (HVACView == null)
                {
                    message = "未找到视图：暖通抗震吊架出图";
                    return Result.Cancelled;
                }
            }
            List<TextNote> distinctTextNotes = new List<TextNote>();
            if (mainWindow.WaterCheck == true && mainWindow.HVACCheck == true)
            {
                var waterTextNotes = new FilteredElementCollector(doc, waterView.Id).OfCategory(BuiltInCategory.OST_TextNotes).OfClass(typeof(TextNote)).Cast<TextNote>().ToList();
                var HVACTextNotes = new FilteredElementCollector(doc, HVACView.Id).OfCategory(BuiltInCategory.OST_TextNotes).OfClass(typeof(TextNote)).Cast<TextNote>().ToList();
                distinctTextNotes = DistinctTextNotes(waterTextNotes, HVACTextNotes);
            }
            else if (mainWindow.WaterCheck == true)
            {
                var waterTextNotes = new FilteredElementCollector(doc, waterView.Id).OfCategory(BuiltInCategory.OST_TextNotes).OfClass(typeof(TextNote)).Cast<TextNote>().ToList();
                distinctTextNotes = waterTextNotes;
            }else if (mainWindow.HVACCheck == true)
            {
                var HVACTextNotes = new FilteredElementCollector(doc, HVACView.Id).OfCategory(BuiltInCategory.OST_TextNotes).OfClass(typeof(TextNote)).Cast<TextNote>().ToList();
                distinctTextNotes = HVACTextNotes;
            }
            var textNoteGroup = distinctTextNotes.GroupBy(dtn => dtn.Text).ToList();
            ExportExcel(textNoteGroup);

            return Result.Succeeded;
        }
        // 去除两个集合中文字相同且坐标相似的文字注释，避免重复计算算量
        private List<TextNote> DistinctTextNotes(List<TextNote> textNotes1, List<TextNote> textNotes2)
        {
            List<TextNote> result = new List<TextNote>();

            foreach (TextNote textNote in textNotes1)
            {
                var filterNotes = textNotes2.Where(t => t.Text.Equals(textNote.Text) && t.Coord.DistanceTo(textNote.Coord) < 0.001).ToList();
                filterNotes.ForEach(ft => textNotes2.Remove(ft));
            }
            result.AddRange(textNotes1);
            result.AddRange(textNotes2);

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

namespace HangerQuantity
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool WaterCheck { get; set; }
        public bool HVACCheck { get; set; }
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (cb_water.IsChecked == true) WaterCheck = true;
            if (cb_hvac.IsChecked == true) HVACCheck = true;
            DialogResult = true;
        }
    }
}

```

