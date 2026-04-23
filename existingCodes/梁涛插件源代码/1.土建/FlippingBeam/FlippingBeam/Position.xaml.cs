using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Color = System.Windows.Media.Color;
using ComboBox = System.Windows.Controls.ComboBox;

namespace FlippingBeam
{
    /// <summary>
    /// Position.xaml 的交互逻辑
    /// </summary>
    [Transaction(TransactionMode.Manual)]
    public partial class Position : Window
    {
        //补充的代码：创建外部事件
        //取消订阅事件
        private ExternalEvent _externalEvent;
        private UnsubscribeEventHandler _handler;
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
        // 一键修改梁族类型
        ChangeFamilySymbolByList changeFamilySymbolByList = null;
        ExternalEvent changeByListEvent = null;
        Document doc;
        UIDocument uIDoc;
        List<FamilySymbol> familySymbols = null;
        ObservableCollection<FamilySymbol> families = null;
        ObservableCollection<Beamx> beamxes = null;
        //public Position(List<Beamx> beams, Document doc, UIDocument uIDoc)
        public Position(ObservableCollection<Beamx> beams, Document doc, UIDocument uIDoc)
        {
            InitializeComponent();
            _handler = new UnsubscribeEventHandler();
            _externalEvent = ExternalEvent.Create(_handler);
            handlerCommand = new EventCommand();
            handlerEvent = ExternalEvent.Create(handlerCommand);
            delEventCommand = new DelEventCommand();
            externalEvent = ExternalEvent.Create(delEventCommand);
            changeFamilySymbol = new ChangeFamilySymbol();
            changeEvent = ExternalEvent.Create(changeFamilySymbol);
            colorCommand = new ColorCommand();
            colorEvent = ExternalEvent.Create(colorCommand);
            changeFamilySymbolByList = new ChangeFamilySymbolByList();
            changeByListEvent = ExternalEvent.Create(changeFamilySymbolByList);
            this.beamxes = beams;
            list.ItemsSource = beamxes;
            //list.DataContext = beams;
            this.doc = doc;
            this.uIDoc = uIDoc;
            familySymbols = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_StructuralFraming).OfClass(typeof(FamilySymbol)).Cast<FamilySymbol>().Where(x => x.Family.Name.Contains("梁")).ToList().OrderBy(y => Regex.Replace(y.Name, @"[^0-9]+", "")).ToList();
            families = new ObservableCollection<FamilySymbol>();
            foreach (FamilySymbol familySymbol in familySymbols)
            {
                families.Add(familySymbol);
            }
            //cb.ItemsSource = familySymbols.Select(x => x.Name);
            cb.ItemsSource = families.Select(x => x.Name);
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (list.SelectionMode == DataGridSelectionMode.Single)
            //{
            //    // SelectionMode设置为单选
            //    //TaskDialog.Show("sds", "选中了单行");
            //    File.AppendAllText(@"C:\Users\Administrator\Desktop\11.txt", "选中了单行" + "\n");
            //}
            //else if (list.SelectionMode == DataGridSelectionMode.Extended)
            //{
            //    // SelectionMode设置为多选
            //    if (list.SelectedItems.Count > 1)
            //    {
            //        //TaskDialog.Show("sds", "选中了多行");
            //        File.AppendAllText(@"C:\Users\Administrator\Desktop\11.txt", "选中了多行" + "\n");
            //    }
            //    else if (list.SelectedItems.Count == 1)
            //    {
            //        //TaskDialog.Show("sds", "虽然设置为多选，但当前只选中了单行");
            //        File.AppendAllText(@"C:\Users\Administrator\Desktop\11.txt", "虽然设置为多选，但当前只选中了单行" + "\n");
            //    }
            //    else
            //    {
            //        //TaskDialog.Show("sds", "没有选中任何行");
            //        File.AppendAllText(@"C:\Users\Administrator\Desktop\11.txt", "没有选中任何行" + "\n");
            //    }
            //}
            //return;
            cb.SelectedIndex = -1;
            Beamx beam = list.SelectedItem as Beamx;
            List<ElementId> ids = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_StructuralFraming).OfClass(typeof(FamilyInstance)).Cast<FamilyInstance>().Select(x => x.Id).ToList();
            if (!ids.Contains(beam.beamId))
            {
                List<ElementId> tnids = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_TextNotes).OfClass(typeof(TextNote)).Cast<TextNote>().Select(x => x.Id).ToList();
                //TaskDialog.Show("v", beam.noteID.ToString());
                if (!tnids.Contains(beam.noteID)) return;
                //TaskDialog.Show("v", beam.noteID.ToString());
                uIDoc.ShowElements(beam.noteID);
                uIDoc.Selection.SetElementIds(new List<ElementId> { beam.noteID});
                return;
            }
            beam.beamName = doc.GetElement(beam.beamId).Name;
            string oldBeamName = Regex.Replace(beam.beamName, @"[^0-9]+", "");
            string newNoteText = Regex.Replace(beam.noteText, @"[^0-9]+", "");
            string newBeamName = Regex.Replace(beam.beamName, @"[^0-9]+", "");
            if (beam.noteText == "未找到")
            {
                beam.correct = "已查看/已修改";
            }
            else if (beam.correct == "否")
            {
                if (newNoteText == newBeamName)
                {
                    //beam.correct = "是(已修改)";
                    beam.correct = "是";
                    beam.textColor = "black";
                    beam.textBackColor = "";
                }
            }
            else if (beam.correct == "是")
            {
                beam.correct = "是(已复核)";
            }
            if (beam.correct == "是(已复核)" || beam.correct == "是")
            {
                if (newNoteText != newBeamName)
                {
                    beam.correct = "否";
                    beam.textColor = "red";
                    beam.isBold = true;
                    beam.textBackColor = "blue";
                }
            }
            //刷新datagrid数据
            list.Items.Refresh();
            //datagrid控件重新获得焦点
            list.Focus();
            //滚动到当前行
            list.ScrollIntoView(list.SelectedItem);
            handlerCommand.beamId = beam.beamId;
            handlerEvent.Raise();
            //// 清除之前选中行的自定义样式
            //foreach (var item in e.RemovedItems)
            //{
            //    DataGridRow oldRow = (DataGridRow)(list.ItemContainerGenerator.ContainerFromItem(item));
            //    if (oldRow != null) oldRow.ClearValue(DataGridRow.BackgroundProperty);
            //}

            //// 设置新选中行的背景色
            //foreach (var item in e.AddedItems)
            //{
            //    DataGridRow newRow = (DataGridRow)(list.ItemContainerGenerator.ContainerFromItem(item));
            //    if (newRow != null) newRow.Background = new SolidColorBrush(Colors.Green); // 选中行的新背景色
            //}
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            delEventCommand.isTextNote = true;
            externalEvent.Raise();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            delEventCommand.isTextNote = false;
            externalEvent.Raise();
        }

        private void Window_DpiChanged(object sender, DpiChangedEventArgs e)
        {

        }

        private void cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (0 != list.SelectedItems.Count && null != cb.SelectedItem)
            {
                //TaskDialog.Show("ds",list.SelectedItems.Count.ToString());
                //if (list.SelectedItems.Count > 1)
                //{
                //    changeFamilySymbol.More = true;
                //}
                //else
                //{
                //    changeFamilySymbol.More = false;
                //}
                ElementId symbolId = familySymbols.Where(x => x.Name.Equals(cb.SelectedItem.ToString())).FirstOrDefault().Id;
                changeFamilySymbol.FamilySymbolId = symbolId;
                changeFamilySymbol.list = list;
                //changeFamilySymbol.familyInstanceId = instanceId;
                changeEvent.Raise();
                foreach (var item in list.SelectedItems)
                {
                    
                    //Beamx beam = list.SelectedItem as Beamx;
                    Beamx beam = item as Beamx;
                    List<ElementId> ids = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_StructuralFraming).OfClass(typeof(FamilyInstance)).Cast<FamilyInstance>().Select(x => x.Id).ToList();
                    if (!ids.Contains(beam.beamId)) return;
                    ElementId instanceId = beam.beamId;
                    
                    beam.beamName = doc.GetElement(beam.beamId).Name;
                    string oldBeamName = Regex.Replace(beam.beamName, @"[^0-9]+", "");
                    string newNoteText = Regex.Replace(beam.noteText, @"[^0-9]+", "");
                    string newBeamName = Regex.Replace(cb.SelectedItem.ToString(), @"[^0-9]+", "");
                    if (beam.noteText == "未找到")
                    {
                        beam.correct = "已查看/已修改";
                    }
                    else if (beam.correct == "否")
                    {
                        if (newNoteText == newBeamName)
                        {
                            //beam.correct = "是(已修改)";
                            beam.correct = "是";
                            beam.textColor = "black";
                            beam.textBackColor = "";
                        }
                    }
                    else if (beam.correct == "是")
                    {
                        beam.correct = "是(已复核)";
                    }
                    if (beam.correct == "是(已复核)" || beam.correct == "是")
                    {
                        if (newNoteText != newBeamName)
                        {
                            beam.correct = "否";
                            beam.textColor = "red";
                            beam.isBold = true;
                            beam.textBackColor = "blue";
                        }
                    }
                    if (list.SelectedItems.Count == 1)
                    {
                        handlerCommand.beamId = beam.beamId;
                        handlerEvent.Raise();
                    }
                    beamxes.First(x => x.beamId == beam.beamId).beamName = cb.SelectedItem.ToString();
                }
                uIDoc.RefreshActiveView();
                //刷新datagrid数据
                list.Items.Refresh();
                //datagrid控件重新获得焦点
                list.Focus();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            colorEvent.Raise();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _externalEvent.Raise();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Beamx beamx;
            Button button = sender as Button;
            int rowIndex = list.Items.IndexOf(button.DataContext);
            if (rowIndex < 0) return;
            beamx = list.Items[rowIndex] as Beamx;

            SelSymbolWindow selSymbolWindow = new SelSymbolWindow(doc, this);
            selSymbolWindow.ShowDialog();
            if (selSymbolWindow.DialogResult == true)
            {
                if (selSymbolWindow.Reset)
                {
                    beamx.NewBeamSymbolName = string.Empty;
                    beamx.Status = "未编辑";
                }
                else
                {
                    beamx.Status = selSymbolWindow.NewSymbolName;
                    beamx.NewBeamSymbolName = selSymbolWindow.NewSymbolName;
                    //beamx.beamName = selSymbolWindow.NewSymbolName;
                }
                //MessageBox.Show(beamx.NewBeamSymbolName + "\n "+beamx.Status);
            }
        }

        private void Button_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
            var button = sender as Button;
            button?.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            changeFamilySymbolByList.Beamxes = beamxes;
            changeFamilySymbolByList.List = list;
            if (cb_sel_para.SelectedIndex != -1)
            {
                changeFamilySymbolByList.ParaName = cb_sel_para.SelectedValue.ToString();
                cb_sel_para.SelectedIndex = -1;
            }
            changeByListEvent.Raise();
        }

        private void cb_sel_para_DropDownOpened(object sender, EventArgs e)
        {
            var beam = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_StructuralFraming).OfClass(typeof(FamilyInstance)).Cast<FamilyInstance>().FirstOrDefault();
            if (beam == null) return;
            List<string> beamParas = beam.Parameters.Cast<Parameter>().Where(para => para.IsReadOnly == false && para.StorageType == StorageType.Integer).Select(p => p.Definition.Name).OrderByDescending(name => name.Contains("修改")).ThenBy(name => name).ToList();
            cb_sel_para.ItemsSource = beamParas;
        }
    }

    public class Beamx : INotifyPropertyChanged
    {
        //梁的族类型
        public string beamName { get; set; }
        //梁ID
        public ElementId beamId { get; set; }
        //梁标记与文字注释是否一致
        public string correct { get; set; }
        //文字注释内容
        public string noteText{ get; set; }
        //文字注释ID
        public ElementId noteID{ get; set; }
        //文字注释包含梁数量
        public int beamCou{ get; set; }
        //字体颜色
        public string textColor { get; set; }
        //字体粗细
        public bool isBold { get; set; }
        //是否列的背景颜色
        public string textBackColor { get; set; }
        // 要修改梁的新族类型
        public string NewBeamSymbolName { get; set; } = string.Empty;
        // 状态
        public string _status = "未编辑";
        public string Status
        {
            get => _status;
            set
            {
                if (_status != value)
                {
                    _status = value;
                    OnPropertyChanged(nameof(Status)); // 通知属性更改
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class ChangeFamilySymbol : IExternalEventHandler
    {
        public ElementId FamilyInstanceId { get; set; }
        public ElementId FamilySymbolId { get; set; }
        public DataGrid list { get; set; }
        public bool More { get; set; }
        public void Execute(UIApplication app)
        {
            Document doc = app.ActiveUIDocument.Document;
            // 获取新的族类型
            FamilySymbol newFamilyType = doc.GetElement(FamilySymbolId) as FamilySymbol;
            
            using (Transaction t = new Transaction(doc, "修改族类型"))
            {
                t.Start();
                // 检查新的族类型是否已经激活，如果没有，则激活它
                if (!newFamilyType.IsActive)
                {
                    newFamilyType.Activate();
                    doc.Regenerate();
                }
                foreach (var item in list.SelectedItems)
                {
                    Beamx beam = item as Beamx;
                    FamilyInstanceId = beam.beamId;
                    List<ElementId> ids = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_StructuralFraming).OfClass(typeof(FamilyInstance)).Cast<FamilyInstance>().Select(x => x.Id).ToList();
                    if (!ids.Contains(beam.beamId)) return;
                    // 获取族实例
                    FamilyInstance familyInstance = doc.GetElement(FamilyInstanceId) as FamilyInstance;
                    // 修改族实例的族类型
                    familyInstance.Symbol = newFamilyType;
                }
                t.Commit();
            }
        }
        public string GetName()
        {
            return "ChangeFamilySymbol";
        }
    }
    public class ChangeFamilySymbolByList : IExternalEventHandler
    {
        public ObservableCollection<Beamx> Beamxes { get; set; } = new ObservableCollection<Beamx>();
        public DataGrid List { get; set; }
        public string ParaName { get; set; } = string.Empty;
        public void Execute(UIApplication app)
        {
            UIDocument uidoc = app.ActiveUIDocument;
            Document doc = app.ActiveUIDocument.Document;
            var filterBeamxes = Beamxes.Where(b => b.NewBeamSymbolName != string.Empty);

            using (Transaction t = new Transaction(doc, "批量修改族类型"))
            {
                t.Start();
                foreach (var beamx in filterBeamxes)
                {
                    //if (beamx.NewBeamSymbolName == string.Empty) continue;
                    // 获取新的族类型
                    FamilySymbol newFamilyType = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_StructuralFraming).OfClass(typeof(FamilySymbol)).Cast<FamilySymbol>().Where(x => x.Family.Name.Contains("梁")).FirstOrDefault(x => x.Name == beamx.NewBeamSymbolName);
                    if (newFamilyType == null) continue;
                    // 检查新的族类型是否已经激活，如果没有，则激活它
                    if (!newFamilyType.IsActive)
                    {
                        newFamilyType.Activate();
                        doc.Regenerate();
                    }

                    List<ElementId> ids = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_StructuralFraming).OfClass(typeof(FamilyInstance)).Cast<FamilyInstance>().Select(x => x.Id).ToList();
                    if (!ids.Contains(beamx.beamId)) continue;
                    // 获取族实例
                    FamilyInstance familyInstance = doc.GetElement(beamx.beamId) as FamilyInstance;
                    // 修改族实例的族类型
                    familyInstance.Symbol = newFamilyType;
                    // 修改族实例指定参数
                    if (ParaName != string.Empty) familyInstance.LookupParameter(ParaName)?.Set(1);


                }
                t.Commit();
            }

            RefreshList(doc, filterBeamxes.ToList());
            RestoreDefaultSettings(filterBeamxes.ToList());
            uidoc.RefreshActiveView();
            //刷新datagrid数据
            List.Items.Refresh();
            //datagrid控件重新获得焦点
            List.Focus();

            MessageBox.Show("修改完成！");
        }
        // 刷新列表数据
        private void RefreshList(Document doc, List<Beamx> beamxes)
        {
            foreach (var beam in beamxes)
            {
                List<ElementId> ids = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_StructuralFraming).OfClass(typeof(FamilyInstance)).Cast<FamilyInstance>().Select(x => x.Id).ToList();
                if (!ids.Contains(beam.beamId)) continue;
                ElementId instanceId = beam.beamId;

                beam.beamName = doc.GetElement(beam.beamId).Name;
                string oldBeamName = Regex.Replace(beam.beamName, @"[^0-9]+", "");
                string newNoteText = Regex.Replace(beam.noteText, @"[^0-9]+", "");
                string newBeamName = Regex.Replace(beam.NewBeamSymbolName, @"[^0-9]+", "");
                if (beam.noteText == "未找到")
                {
                    beam.correct = "已查看/已修改";
                }
                else if (beam.correct == "否")
                {
                    if (newNoteText == newBeamName)
                    {
                        //beam.correct = "是(已修改)";
                        beam.correct = "是";
                        beam.textColor = "black";
                        beam.textBackColor = "";
                    }
                }
                else if (beam.correct == "是")
                {
                    beam.correct = "是(已复核)";
                }
                if (beam.correct == "是(已复核)" || beam.correct == "是")
                {
                    if (newNoteText != newBeamName)
                    {
                        beam.correct = "否";
                        beam.textColor = "red";
                        beam.isBold = true;
                        beam.textBackColor = "blue";
                    }
                }
            }
        }
        private void RestoreDefaultSettings(List<Beamx> beamxes)
        {
            beamxes.ForEach(b => { b.Status = "未编辑"; b.NewBeamSymbolName = string.Empty; });
        }
        public string GetName()
        {
            return "ChangeFamilySymbolByList";
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
            using (Transaction t = new Transaction(doc,"更改文本注释颜色"))
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
            app.Application.DocumentChanged -= Compare.OnDocumentChanged;
        }

        public string GetName()
        {
            return "Unsubscribe Event Handler";
        }
    }
}
