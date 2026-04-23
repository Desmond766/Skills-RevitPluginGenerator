using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Events;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Tracing;
using System.Globalization;
using System.IO;
using System.Linq;
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

namespace FloorReview
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    [Transaction(TransactionMode.Manual)]
    public partial class MainWindow : Window
    {
        //取消订阅事件
        private ExternalEvent _externalEvent;
        private UnsubscribeEventHandler _handler;
        //更改楼板标高
        ChangeLevel changeLevel = null;
        ExternalEvent changeLevelEvent = null;
        //定位并高亮显示元素
        EventCommand handlerCommand = null;
        ExternalEvent handlerEvent = null;
        //删除所有文本注释或梁标记
        DelEventCommand delEventCommand = null;
        ExternalEvent externalEvent = null;
        //更改族类型
        ChangeFamilySymbol changeFamilySymbol = null;
        ExternalEvent changeEvent = null;
        //更改文字注释字体颜色
        ColorCommand colorCommand = null;
        ExternalEvent colorEvent = null;
        Document doc;
        UIDocument uIDoc;
        Autodesk.Revit.ApplicationServices.Application app;
        ObservableCollection<TextNoteInfo> textNoteInfos = null;
        List<FloorType> familySymbols = null;
        public MainWindow(ObservableCollection<TextNoteInfo> textNoteInfos, Document doc, UIDocument uIDoc, Autodesk.Revit.ApplicationServices.Application app)
        {
            InitializeComponent();
            app.DocumentChanged += OnDocumentChanged;
            this.textNoteInfos = textNoteInfos;
            this.doc = doc;
            this.uIDoc = uIDoc;
            this.app = app;
            list.ItemsSource = textNoteInfos;
            _handler = new UnsubscribeEventHandler();
            _externalEvent = ExternalEvent.Create(_handler);
            handlerCommand = new EventCommand();
            handlerEvent = ExternalEvent.Create(handlerCommand);
            delEventCommand = new DelEventCommand();
            externalEvent = ExternalEvent.Create(delEventCommand);
            changeFamilySymbol = new ChangeFamilySymbol();
            changeEvent = ExternalEvent.Create(changeFamilySymbol);
            changeLevel = new ChangeLevel();
            changeLevelEvent = ExternalEvent.Create(changeLevel);
            colorCommand = new ColorCommand();
            colorEvent = ExternalEvent.Create(colorCommand);
            familySymbols = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Floors).OfClass(typeof(FloorType)).Cast<FloorType>().ToList().OrderBy(y => Regex.Replace(y.Name, @"[^0-9]+", "")).ToList();
            cb.ItemsSource = familySymbols.Select(x => x.Name);
            llcb.ItemsSource = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Levels).WhereElementIsNotElementType().Cast<Level>().ToList().Select(x => x.Name);
        }
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            try
            {
                cb.SelectedIndex = -1;
                llcb.SelectedIndex = -1;
                TextNoteInfo noteInfo = list.SelectedItem as TextNoteInfo;
                List<ElementId> ids = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Floors).OfClass(typeof(Floor)).Cast<Floor>().Select(x => x.Id).ToList();
                List<ElementId> noteIds = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_TextNotes).OfClass(typeof(TextNote)).Cast<TextNote>().Select(x => x.Id).ToList();
                if (!noteIds.Contains(noteInfo.NoteID)) return;
                if (!ids.Contains(noteInfo.FloorID) && noteInfo.FloorName != "未找到") return;
                if (noteInfo.FloorName != "未找到")
                {
                    noteInfo.FloorName = doc.GetElement(noteInfo.FloorID).Name;
                    string input = noteInfo.FloorName;
                    string pattern = @"\d+(?=mm)";

                    Match match = Regex.Match(input, pattern);
                    noteInfo.FloorName = match.Value + "mm";
                }
                string newNoteText = Regex.Replace(noteInfo.NoteText, @"[^0-9]+", "");
                string newFloorName = noteInfo.FloorName;
                if (noteInfo.FloorName == "未找到")
                {
                    noteInfo.Correct = "已查看/已修改";
                }
                else if (noteInfo.Correct == "否")
                {
                    if (newNoteText == newFloorName)
                    {
                        noteInfo.Correct = "是";
                        noteInfo.TextColor = "black";

                    }
                }
                else if (noteInfo.Correct == "是")
                {
                    noteInfo.Correct = "是(已复核)";
                }
                if (noteInfo.Correct == "是(已复核)" || noteInfo.Correct == "是")
                {
                    if (newNoteText != newFloorName)
                    {
                        noteInfo.Correct = "否";
                        noteInfo.TextColor = "red";
                        noteInfo.IsBold = true;
                    }
                }
                //刷新datagrid数据
                list.Items.Refresh();
                //datagrid控件重新获得焦点
                list.Focus();
                //滚动到当前行
                list.ScrollIntoView(list.SelectedItem);
                if (!ids.Contains(noteInfo.FloorID))
                {
                    handlerCommand.FloorId = noteInfo.NoteID;
                    handlerEvent.Raise();
                }
                else
                {
                    handlerCommand.FloorId = noteInfo.FloorID;
                    handlerEvent.Raise();
                }
            }
            catch (Exception ee)
            {

                TaskDialog.Show("error", ee.Message);
            }
            
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            delEventCommand.IsTextNote = true;
            externalEvent.Raise();
        }
        private void cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (null == list.SelectedItem || null == cb.SelectedItem) return;
            ElementId symbolId = familySymbols.Where(x => x.Name.Equals(cb.SelectedItem.ToString())).FirstOrDefault().Id;
            TextNoteInfo noteInfo = list.SelectedItem as TextNoteInfo;
            List<ElementId> ids = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Floors).OfClass(typeof(Floor)).Cast<Floor>().Select(x => x.Id).ToList();
            if (!ids.Contains(noteInfo.FloorID)) return;
            ElementId instanceId = noteInfo.FloorID;
            changeFamilySymbol.familySymbolId = symbolId;
            changeFamilySymbol.familyInstanceId = instanceId;
            changeEvent.Raise();
            handlerCommand.FloorId = noteInfo.FloorID;
            handlerEvent.Raise();



            noteInfo.FloorName = doc.GetElement(noteInfo.FloorID).Name;
            string newNoteText = Regex.Replace(noteInfo.NoteText, @"[^0-9]+", "");
            newNoteText += "mm";
            string newFloorName = cb.SelectedItem.ToString();

            string input = newFloorName;
            string pattern = @"\d+(?=mm)";
            Match match = Regex.Match(input, pattern);
            newFloorName = match.Value + "mm";
            if (noteInfo.FloorName == "未找到")
            {
                noteInfo.Correct = "已查看/已修改";
            }
            else if (noteInfo.Correct == "否")
            {
                if (newNoteText == newFloorName)
                {
                    noteInfo.Correct = "是";
                    noteInfo.TextColor = "black";
                }
            }
            else if (noteInfo.Correct == "是")
            {
                noteInfo.Correct = "是(已复核)";
            }
            if (noteInfo.Correct == "是(已复核)" || noteInfo.Correct == "是")
            {
                if (newNoteText != newFloorName)
                {
                    noteInfo.Correct = "否";
                    noteInfo.TextColor = "red";
                    noteInfo.IsBold = true;
                }
            }
            uIDoc.RefreshActiveView();
            textNoteInfos.First(x => x.FloorID == noteInfo.FloorID).FloorName = newFloorName;
            //刷新datagrid数据
            list.Items.Refresh();
            //datagrid控件重新获得焦点
            list.Focus();
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            colorEvent.Raise();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //MessageBoxResult result = MessageBox.Show("确定要关闭窗口吗？", "关闭确认", MessageBoxButton.YesNo);
            //if (result == MessageBoxResult.No)
            //{
            //    // 如果用户选择“否”，取消关闭操作
            //    e.Cancel = true;
            //}
            _externalEvent.Raise();
        }
        public static void OnDocumentChanged(object sender, DocumentChangedEventArgs e)
        {
            Document doc = e.GetDocument();
            List<FloorType> familySymbols = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Floors).OfClass(typeof(FloorType)).Cast<FloorType>().ToList().OrderBy(y => Regex.Replace(y.Name, @"[^0-9]+", "")).ToList();
            GlobalResources.MainWindow1.cb.ItemsSource = familySymbols.Select(x => x.Name);
            //position.cb.ItemsSource = familySymbols;
            //TaskDialog.Show("sdsd", "qqqq");
            if (null == GlobalResources.MainWindow1.list.SelectedItem) return;
            TextNoteInfo noteInfo = GlobalResources.MainWindow1.list.SelectedItem as TextNoteInfo;
            if (noteInfo.FloorName != "未找到") return;
            List<Floor> floors = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_Floors).OfClass(typeof(Floor)).Cast<Floor>().ToList();
            //TaskDialog.Show("ds32",floors.Count.ToString());
            foreach (var item in floors)
            {
                BoundingBoxXYZ boundingBox = item.get_BoundingBox(null);
                TextNote textNote = doc.GetElement(noteInfo.NoteID) as TextNote;
                XYZ noteP = textNote.Coord;
                if (boundingBox != null && boundingBox.Min.X < noteP.X && boundingBox.Max.X > noteP.X && boundingBox.Min.Y < noteP.Y && boundingBox.Max.Y > noteP.Y)
                {
                    //TaskDialog.Show("1", "111");
                    string input = item.Name;
                    string pattern = @"\d+(?=mm)";
                    Match match = Regex.Match(input, pattern);
                    string newFloorName = match.Value + "mm";
                    TextNoteInfo textNoteInfo = new TextNoteInfo { Correct = noteInfo.NoteText == newFloorName ? "是" : "否", Floor = item, FloorID = item.Id, FloorName = newFloorName, IsBold = false, NoteID = noteInfo.NoteID, NoteText = noteInfo.NoteText, TextColor = "black" };
                    noteInfo.Correct = noteInfo.NoteText == newFloorName ? "是" : "否";
                    noteInfo.Floor = item;
                    noteInfo.FloorID = item.Id;
                    noteInfo.FloorName = newFloorName;
                    noteInfo.IsBold = noteInfo.Correct == "是" ? false : true;
                    noteInfo.TextColor = noteInfo.Correct == "是" ? "black" : "red";
                    noteInfo.Level = doc.GetElement(item.LevelId) as Level;
                    noteInfo.LevelName = (doc.GetElement(item.LevelId) as Level).Name;
                    //刷新datagrid数据
                    GlobalResources.MainWindow1.list.Items.Refresh();
                    //datagrid控件重新获得焦点
                    GlobalResources.MainWindow1.list.Focus();
                    //滚动到当前行
                    GlobalResources.MainWindow1.list.ScrollIntoView(GlobalResources.MainWindow1.list.SelectedItem);
                    break;
                }
            }
        }

        private void llcb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (null == list.SelectedItem || null == llcb.SelectedItem) return;
            ElementId levelId = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Levels).WhereElementIsNotElementType().Cast<Level>().FirstOrDefault(x => x.Name == llcb.SelectedItem.ToString()).Id;
            TextNoteInfo noteInfo = list.SelectedItem as TextNoteInfo;
            List<ElementId> ids = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Floors).OfClass(typeof(Floor)).Cast<Floor>().Select(x => x.Id).ToList();
            if (!ids.Contains(noteInfo.FloorID)) return;
            ElementId instanceId = noteInfo.FloorID;
            if (levelId == null) return;
            changeLevel.FamilyInstanceId = instanceId;
            changeLevel.LevelId = levelId;
            changeLevelEvent.Raise();
            handlerCommand.FloorId = noteInfo.FloorID;
            handlerEvent.Raise();
            noteInfo.LevelName = llcb.SelectedItem.ToString();
            //noteInfo.LevelName = (doc.GetElement(noteInfo.Floor.LevelId) as Level).Name;
            //刷新datagrid数据
            list.Items.Refresh();
            //datagrid控件重新获得焦点
            list.Focus();
            //滚动到当前行
            list.ScrollIntoView(list.SelectedItem);
        }
    }
    public class ChangeFamilySymbol : IExternalEventHandler
    {
        public ElementId familyInstanceId { get; set; }
        public ElementId familySymbolId { get; set; }
        public void Execute(UIApplication app)
        {
            Document doc = app.ActiveUIDocument.Document;
            // 获取族实例
            Floor familyInstance = doc.GetElement(familyInstanceId) as Floor;

            // 获取新的族类型
            FloorType newFamilyType = doc.GetElement(familySymbolId) as FloorType;

            using (Transaction t = new Transaction(doc, "修改族类型"))
            {
                t.Start();
                // 修改族实例的族类型
                familyInstance.FloorType = newFamilyType;
                t.Commit();
            }
        }
        public string GetName()
        {
            return "ChangeFamilySymbol";
        }
    }
    public class ChangeLevel : IExternalEventHandler
    {
        public ElementId FamilyInstanceId { get; set; }
        public ElementId LevelId { get; set; }
        public void Execute(UIApplication app)
        {
            Document doc = app.ActiveUIDocument.Document;
            Floor familyInstance = doc.GetElement(FamilyInstanceId) as Floor;
            using (Transaction t = new Transaction(doc,"更改标高"))
            {
                t.Start();
                familyInstance.get_Parameter(BuiltInParameter.LEVEL_PARAM).Set(LevelId);
                t.Commit();
            }
        }

        public string GetName()
        {
            return "ChangeLevel";
        }
    }

    public class ColorCommand : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            Document doc = app.ActiveUIDocument.Document;
            List<TextNoteType> textNotesType = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_TextNotes).OfClass(typeof(TextNote)).Cast<TextNote>().Select(x => x.TextNoteType).ToList();
            HashSet<TextNoteType> textNotesType1 = new HashSet<TextNoteType>();
            foreach (var item in textNotesType)
            {
                if (!textNotesType1.Select(x => x.Id).Contains(item.Id)) textNotesType1.Add(item);
            }
            using (Transaction t = new Transaction(doc, "更改文本注释颜色"))
            {
                t.Start();
                foreach (var item in textNotesType1)
                {
                    item.LookupParameter("颜色").Set(255);
                }
                t.Commit();
            }
        }
        public string GetName()
        {
            return "ColorCommand";
        }
    }
    public class UnsubscribeEventHandler : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            app.Application.DocumentChanged -= MainWindow.OnDocumentChanged;
        }

        public string GetName()
        {
            return "Unsubscribe Event Handler";
        }
    }

}
