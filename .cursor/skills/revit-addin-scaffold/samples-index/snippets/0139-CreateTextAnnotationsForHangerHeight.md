# Sample Snippet: CreateTextAnnotationsForHangerHeight

Source project: `existingCodes\梁涛插件源代码\5.吊架出图\CreateTextAnnotationsForHangerHeight\CreateTextAnnotationsForHangerHeight`

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
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using OperationCanceledException = Autodesk.Revit.Exceptions.OperationCanceledException;

//生成吊架底部标高文字注释
namespace CreateTextAnnotationsForHangerHeight
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uIDoc = commandData.Application.ActiveUIDocument;
            Document doc = uIDoc.Document;

            View3D view3D = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Views).FirstOrDefault(x => x is View3D && x.Name == "{三维}") as View3D;
            // 获取当前活动的视图
            View previousView = uIDoc.ActiveView;
            // 获取默认的三维视图的视图 ID
            ElementId default3DViewId = new FilteredElementCollector(doc)
                .OfClass(typeof(View3D))
                .FirstOrDefault(v => v.Name == "{三维}")?.Id;

            if (default3DViewId != null)
            {
                // 激活默认的三维视图
                uIDoc.ActiveView = doc.GetElement(default3DViewId) as View;
            }
            uIDoc.ActiveView = previousView;
            if (!(doc.ActiveView is ViewPlan) || !doc.ActiveView.Name.Contains("出图"))
            {
                TaskDialog.Show("Revit", "请在出图运行该插件！");
                return Result.Failed;
            }
            if (view3D == null)
            {
                TaskDialog.Show("Revit", "未找到三维视图:{三维}");
                return Result.Failed;
            }

            // 判断需要标注的是横杆底标高还是横杆顶标高
            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();
            if (mainWindow.DialogResult == false)
            {
                return Result.Cancelled;
            }
            bool downLevel = mainWindow.DownLevel;

            //List<FamilyInstance> hangers1 = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_MechanicalEquipment).OfClass(typeof(FamilyInstance)).Cast<FamilyInstance>().Where(x => x.Symbol.Family.Name.Contains("吊架")).ToList();
            IList<Reference> references;
            RevitUtils.ListenUtils listenUtils = new RevitUtils.ListenUtils();
            try
            {
                listenUtils.startListen();
                references = uIDoc.Selection.PickObjects(Autodesk.Revit.UI.Selection.ObjectType.Element, new HangerFilter(), "框选吊架（按空格键完成框选，ESC键取消）");
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
            //Element element = doc.GetElement(uIDoc.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.Element));
            //XYZ p = (element.Location as LocationPoint).Point;
            FilteredElementCollector collector1 = new FilteredElementCollector(doc);
            ICollection<Element> textNoteTypes = collector1.OfClass(typeof(TextNoteType)).ToElements();
            TextNoteType textNoteType = null;
            foreach (TextNoteType textType in textNoteTypes)
            {
                if (textType?.FamilyName == "文字" && textType?.Name == "支吊架信息标记")
                {
                    textNoteType = textType;
                    break;
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

namespace CreateTextAnnotationsForHangerHeight
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool DownLevel { get; private set; }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DownLevel = true;
            DialogResult = true;
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DownLevel = false;
            DialogResult = true;
            Close();
        }
    }
}

```

