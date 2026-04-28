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
            }
            if (lb_buttom.Content.ToString().Contains("未连接"))
            {
                bt_change_buttom.IsEnabled = false;
            }
            else
            {
                bt_change_buttom.IsEnabled = true;
            }
            if (lb_top.Content.ToString().Contains("未连接"))
            {
                //bt_change_top.Visibility = System.Windows.Visibility.Hidden;
                bt_change_top.IsEnabled = false;
            }
            else
            {
                //bt_change_top.Visibility = System.Windows.Visibility.Visible;
                bt_change_top.IsEnabled = true;
            }
            //刷新datagrid数据
            list.Items.Refresh();
            //datagrid控件重新获得焦点
            list.Focus();
            //滚动到当前行
            list.ScrollIntoView(list.SelectedItem);
        }

        public void OnDocumentChanged(object sender, DocumentChangedEventArgs e)
        {
            if (null == list.SelectedItem) return;
            WallInfo wallInfo = list.SelectedItem as WallInfo;
            List<Wall> newWalls = new FilteredElementCollector(Doc).OfCategory(BuiltInCategory.OST_Walls).WhereElementIsNotElementType().Cast<Wall>().ToList();
            if (!newWalls.Select(x => x.Id).Contains(wallInfo.WallId)) return;
            Wall wall = Doc.GetElement(wallInfo.WallId) as Wall;
            double buttomOffset = 0;
            double topOffset = 0;
            foreach (Parameter para in wall.Parameters)
                if (para.Definition.Name == "底部偏移") buttomOffset = para.AsDouble();
            foreach (Parameter para in wall.Parameters)
                if (para.Definition.Name == "顶部偏移") topOffset = para.AsDouble();
            //TaskDialog.Show("dss", wall.Name);
            wallInfo.WallName = wall.Name;
            wallInfo.BottomOffset = buttomOffset * 304.8;
            wallInfo.TopOffset = topOffset * 304.8;
            foreach (Parameter para in wall.Parameters)
                if (para.Definition.Name == "底部约束")
                {
                    if(para.AsValueString() == "未连接")
                    {
                        bt_change_buttom.IsEnabled = false;
                    }
                    else
                    {
                        bt_change_buttom.IsEnabled = true;
                    }
                }
            foreach (Parameter para in wall.Parameters)
            {
                if (para.Definition.Name == "顶部约束")
                {
                    if (para.AsValueString() == "未连接")
                    {
                        bt_change_top.IsEnabled = false;
                    }
                    else
                    {
                        bt_change_top.IsEnabled = true;
                    }
                }
            }
            //刷新datagrid数据
            list.Items.Refresh();
            //datagrid控件重新获得焦点
            list.Focus();
            //滚动到当前行
            list.ScrollIntoView(list.SelectedItem);
        }

        private void bt_change_buttom_Click(object sender, RoutedEventArgs e)
        {
            if (null == list.SelectedItem) return;
            WallInfo wallInfo = list.SelectedItem as WallInfo;
            List<Wall> newWalls = new FilteredElementCollector(Doc).OfCategory(BuiltInCategory.OST_Walls).WhereElementIsNotElementType().Cast<Wall>().ToList();
            if (!newWalls.Select(x => x.Id).Contains(wallInfo.WallId)) return;
            Wall wall = Doc.GetElement(wallInfo.WallId) as Wall;
            double buttomOffset;
            try
            {
              buttomOffset = Convert.ToDouble(tb_buttom.Text);
            }
            catch (Exception ee)
            {
                Hide();
                TaskDialog.Show("错误", ee.Message);
                Show();
                return;
            }
            
            foreach (Parameter para in wall.Parameters)
                if (para.Definition.Name == "底部偏移")
                {
                    changeOffsetHandler.Para = para;
                    changeOffsetHandler.Offset = buttomOffset / 304.8;
                    changeOffsetEvent.Raise();
                    break;
                }
            Hide();
            TaskDialog.Show("提示", "修改成功");
            Show();
        }

        private void bt_change_top_Click(object sender, RoutedEventArgs e)
        {
            if (null == list.SelectedItem) return;
            WallInfo wallInfo = list.SelectedItem as WallInfo;
            List<Wall> newWalls = new FilteredElementCollector(Doc).OfCategory(BuiltInCategory.OST_Walls).WhereElementIsNotElementType().Cast<Wall>().ToList();
            if (!newWalls.Select(x => x.Id).Contains(wallInfo.WallId)) return;
            Wall wall = Doc.GetElement(wallInfo.WallId) as Wall;
            double topOffset;
            try
            {
                topOffset = Convert.ToDouble(tb_top.Text);
            }
            catch (Exception ee)
            {
                Hide();
                TaskDialog.Show("错误", ee.Message);
                Show();
                return;
            }
            foreach (Parameter para in wall.Parameters)
                if (para.Definition.Name == "顶部偏移")
                {
                    changeOffsetHandler.Para = para;
                    changeOffsetHandler.Offset = topOffset / 304.8;
                    changeOffsetEvent.Raise();
                    break;
                }
            Hide();
            TaskDialog.Show("提示", "修改成功");
            Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _externalEvent.Raise();
        }

        private void NumericTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9.]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void NumericTextBox_PreviewTextInput2(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9.]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }

    public class UnsubscribeEventHandler : IExternalEventHandler
    {
        public MainWindow Window { get; set; }
        public UnsubscribeEventHandler(MainWindow window)
        {
            Window = window;
        }
        public void Execute(UIApplication app)
        {
            app.Application.DocumentChanged -= Window.OnDocumentChanged;
        }

        public string GetName()
        {
            return "Unsubscribe Event Handler";
        }
    }

    public class ChangeOffsetEventHandler : IExternalEventHandler
    {
        public Parameter Para { get; set; }
        public double Offset { get; set; }

        public void Execute(UIApplication app)
        {
            Document doc = app.ActiveUIDocument.Document;
            using (Transaction t = new Transaction(doc, $"更改{Para.Definition.Name}"))
            {
                t.Start();
                Para.Set(Offset);
                t.Commit();
            }
        }

        public string GetName()
        {
            return "Change Offset Event Hanler";
        }
    }

    public class WallInfo
    {
        public string WallName { get; set; }
        public ElementId WallId { get; set; }
        public double TopOffset { get; set; }
        public double BottomOffset { get; set; }
        public string Check { get; set; }
        public string TextColor { get; set; }
        public bool IsBold { get; set; }
    }
}
