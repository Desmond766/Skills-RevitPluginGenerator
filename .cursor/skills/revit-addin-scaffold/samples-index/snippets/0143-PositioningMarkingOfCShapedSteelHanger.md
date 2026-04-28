# Sample Snippet: PositioningMarkingOfCShapedSteelHanger

Source project: `existingCodes\梁涛插件源代码\5.吊架出图\PositioningMarkingOfCShapedSteelHanger\PositioningMarkingOfCShapedSteelHanger`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.Exceptions;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Interop;
using OperationCanceledException = Autodesk.Revit.Exceptions.OperationCanceledException;

//C型钢吊架型号尺寸标注，生成定位标注
namespace PositioningMarkingOfCShapedSteelHanger
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        private bool IsCShape;
        private bool IsTag;
        private bool UpSet;
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uIDoc = commandData.Application.ActiveUIDocument;
            Document doc = uIDoc.Document;

            View3D view3D = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Views).FirstOrDefault(x => x is View3D && x.Name == "3D 支吊架") as View3D;
            // 获取当前活动的视图
            View previousView = uIDoc.ActiveView;
            // 获取默认的三维视图的视图 ID
            ElementId default3DViewId = new FilteredElementCollector(doc)
                .OfClass(typeof(View3D))
                .FirstOrDefault(v => v.Name == "3D 支吊架")?.Id;
            
            if (default3DViewId != null)
            {
                // 激活默认的三维视图
                uIDoc.ActiveView = doc.GetElement(default3DViewId) as View;
            }
            uIDoc.ActiveView = previousView;
            if (view3D == null)
            {
                TaskDialog.Show("Revit", "未找到三维视图:3D 支吊架");
                return Result.Failed;
            }
            MainWindow mainWindow = new MainWindow();
            IntPtr intPtr = commandData.Application.MainWindowHandle;
            WindowInteropHelper windowInteropHelper = new WindowInteropHelper(mainWindow);
            windowInteropHelper.Owner = intPtr;
            mainWindow.ShowDialog();
            if (mainWindow.DialogResult == false)
            {
                return Result.Cancelled;
            }
            IsCShape = mainWindow.IsCShape;
            IsTag = mainWindow.IsTag;
            UpSet = mainWindow.UpSet;

            //List<FamilyInstance> hangers = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_MechanicalEquipment).OfClass(typeof(FamilyInstance)).Cast<FamilyInstance>().Where(x => x.Symbol.Family.Name.Contains("吊架")).ToList();
            IList<Reference> references;
            RevitUtils.ListenUtils listenUtils = new RevitUtils.ListenUtils();
            try
            {
                listenUtils.startListen();
                references = uIDoc.Selection.PickObjects(ObjectType.Element, new HangerFilter(), "框选吊架 空格完成选择");
                listenUtils.stopListen();
            }
            catch (OperationCanceledException)
            {
                listenUtils.stopListen();
                return Result.Cancelled;
            }
            List<FamilyInstance> hangers = new List<FamilyInstance>(); 
            foreach (Reference reference in references)
            {
                FamilyInstance familyInstance = doc.GetElement(reference) as FamilyInstance;
                hangers.Add(familyInstance);
            }
            FilteredElementCollector collector1 = new FilteredElementCollector(doc);
            ICollection<Element> textNoteTypes = collector1.OfClass(typeof(TextNoteType)).ToElements();
            TextNoteType textNoteType = null;
            foreach (TextNoteType textType in textNoteTypes)
            {
                if (textType?.FamilyName == "文字" && textType?.Name == "支吊架信息标记")
                {
                    textNoteType = textType;
                    break;
                }
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

namespace PositioningMarkingOfCShapedSteelHanger
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool IsCShape { get; private set; } = false;
        public bool IsTag { get; private set; } = false;
        public bool UpSet { get; private set; } = false;
        public MainWindow()
        {
            InitializeComponent();
            var p = Properties.Settings.Default;
            if(p.IsTag) rb_tag.IsChecked = true;
            else rb_text.IsChecked = true;
            if (p.IsCShape) rb_cs.IsChecked = true;
            else rb_pm.IsChecked = true;
            if (p.UpSet) rb_upset.IsChecked = true;
            else rb_downset.IsChecked = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (rb_cs.IsChecked == true) IsCShape = true;
                if (rb_tag.IsChecked == true) IsTag = true;
                if (rb_upset.IsChecked == true) UpSet = true;

                Properties.Settings.Default.IsCShape = IsCShape;
                Properties.Settings.Default.IsTag = IsTag;
                Properties.Settings.Default.UpSet = UpSet;
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            DialogResult = true;
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            if (radioButton.IsChecked == true)
            {
                rb_tag.IsEnabled = false;
                rb_text.IsChecked = true;
            }
            else if (radioButton.IsChecked == false)
            {
                rb_tag.IsEnabled = true;
            }
        }

        private void rb_cs_Click(object sender, RoutedEventArgs e)
        {
            if (rb_cs.IsChecked == true)
            {
                rb_tag.IsEnabled = true;
            }
        }
    }
}

```

