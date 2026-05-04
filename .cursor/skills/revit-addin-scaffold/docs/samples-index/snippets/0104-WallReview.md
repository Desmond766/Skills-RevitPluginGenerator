# Sample Snippet: WallReview

Source project: `existingCodes\梁涛插件源代码\1.土建\WallReview\WallReview`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WallReview
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uIDoc = commandData.Application.ActiveUIDocument;
            Application app = commandData.Application.Application;
            Document doc = uIDoc.Document;
            MainWindow mainWindow = new MainWindow(doc,uIDoc,app);
            mainWindow.Show();

            return Result.Succeeded;
        }
    }
}

```

## MainWindow.xaml.cs

```csharp
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Events;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
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
using Application = Autodesk.Revit.ApplicationServices.Application;

namespace WallReview
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        //取消订阅事件
        private ExternalEvent _externalEvent;
        private UnsubscribeEventHandler _handler;
        //更改底部顶部偏移事件
        public ExternalEvent changeOffsetEvent;
        public ChangeOffsetEventHandler changeOffsetHandler;
        public Document Doc { get; set; }
        public Application App { get; set; }
        public UIDocument UIDoc { get; set; }
        public List<Wall> walls = new List<Wall>();
        ObservableCollection<WallInfo> wallInfos = new ObservableCollection<WallInfo>();
        public MainWindow(Document doc, UIDocument uIDoc, Application app)
        {
            InitializeComponent();
            this.Doc = doc;
            this.UIDoc = uIDoc;
            this.App = app;
            app.DocumentChanged += OnDocumentChanged;
            walls = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Walls).WhereElementIsNotElementType().Cast<Wall>().ToList();
            foreach (var item in walls)
            {
                double buttomOffset = 0;
                double topOffset = 0;
                foreach (Parameter para in item.Parameters)
                    if (para.Definition.Name == "底部偏移") buttomOffset = para.AsDouble();
                foreach (Parameter para in item.Parameters)
                    if (para.Definition.Name == "顶部偏移") topOffset = para.AsDouble();
                WallInfo wallInfo = new WallInfo() { WallId = item.Id, WallName = item.Name, BottomOffset = buttomOffset * 304.8, TopOffset = topOffset * 304.8, Check = "否", TextColor = "red", IsBold = true };
                wallInfos.Add(wallInfo);
            }
            list.ItemsSource = wallInfos;
            _handler = new UnsubscribeEventHandler(this);
            _externalEvent = ExternalEvent.Create(_handler);
            changeOffsetHandler = new ChangeOffsetEventHandler();
            changeOffsetEvent = ExternalEvent.Create(changeOffsetHandler);
        }

        private void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            WallInfo wallInfo = list.SelectedItem as WallInfo;
            List<Wall> newWalls = new FilteredElementCollector(Doc).OfCategory(BuiltInCategory.OST_Walls).WhereElementIsNotElementType().Cast<Wall>().ToList();
            if (!newWalls.Select(x => x.Id).Contains(wallInfo.WallId)) return;
            wallInfo.Check = "是";
            wallInfo.IsBold = false;
            wallInfo.TextColor = "black";
            UIDoc.ShowElements(wallInfo.WallId);
            UIDoc.Selection.SetElementIds(new List<ElementId>() { wallInfo.WallId });
            Wall wall = Doc.GetElement(wallInfo.WallId) as Wall;
            foreach (Parameter para in wall.Parameters)
            {
                if (para.Definition.Name == "底部约束")
                {
                    lb_buttom.Content = "底部约束:" + para.AsValueString();
                }
                if (para.Definition.Name == "顶部约束")
                {
                    lb_top.Content = "顶部约束:" + para.AsValueString();
                }
// ... truncated ...
```

