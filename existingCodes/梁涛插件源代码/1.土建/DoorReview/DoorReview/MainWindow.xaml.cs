using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
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
using Color = System.Windows.Media.Color;
using Grid = System.Windows.Controls.Grid;
using Line = System.Windows.Shapes.Line;

namespace DoorReview
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public UIDocument Uidoc { get; set; }
        ChangeSymbolEvent changeSymbolEvent = null;
        ExternalEvent _externalEvent = null;
        List<DoorSymbolInfo> doorSymbolInfos = new List<DoorSymbolInfo>();
        List<ElementId> DoorIds = new List<ElementId>();
        public MainWindow(UIDocument uidoc)
        {
            InitializeComponent();
            Uidoc = uidoc;

            changeSymbolEvent = new ChangeSymbolEvent();
            _externalEvent = ExternalEvent.Create(changeSymbolEvent);

            DoorIds = new FilteredElementCollector(uidoc.Document).OfCategory(BuiltInCategory.OST_Doors).OfClass(typeof(FamilyInstance)).Select(x => x.Id).ToList();

            var familySymbols = new Autodesk.Revit.DB.FilteredElementCollector(uidoc.Document).OfCategory(Autodesk.Revit.DB.BuiltInCategory.OST_Doors).WhereElementIsElementType()
                .Cast<Autodesk.Revit.DB.FamilySymbol>();
            familySymbols = familySymbols.OrderBy(f => f.Name);
            
            foreach (var familySymbol in familySymbols)
            {
                doorSymbolInfos.Add(new DoorSymbolInfo() { SymbolName = familySymbol.Name, FamilySymbol = familySymbol });
            }

            cb_select_symbol.ItemsSource = doorSymbolInfos;
        }
        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            //list.Items.Add(e.LeftButton.ToString());
            Grid grid = FindVisualChild<Grid>(sender as Button);
            grid.Background = new SolidColorBrush() { Color = Color.FromRgb(232, 17, 35) };


            var lines = FindVisualChilds<Line>(grid);
            lines.ForEach(l => l.Stroke = Brushes.White);
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            Grid grid = FindVisualChild<Grid>(sender as Button);
            grid.Background = Brushes.Transparent;

            var lines = FindVisualChilds<Line>(grid);
            lines.ForEach(l => l.Stroke = Brushes.Black);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Grid grid = FindVisualChild<Grid>(sender as Button);
            grid.Background = new SolidColorBrush() { Color = Color.FromArgb(50, 232, 17, 35) };
        }

        private childItem FindVisualChild<childItem>(DependencyObject obj)
        where childItem : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if (child != null && child is childItem)
                {
                    return (childItem)child;
                }
                else
                {
                    childItem childOfChild = FindVisualChild<childItem>(child);
                    if (childOfChild != null)
                        return childOfChild;
                }
            }
            return null;
        }

        private List<childItem> FindVisualChilds<childItem>(DependencyObject obj)
        where childItem : DependencyObject
        {
            List<childItem> items = new List<childItem>();
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if (child != null && child is childItem)
                {
                    items.Add((childItem)child);
                }
            }
            return items;
        }

        private void list_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selIndex = list.SelectedIndex;
            if (selIndex != -1)
            {
                var selItem = list.ItemContainerGenerator.ContainerFromIndex(selIndex) as DataGridRow;
                if (selItem != null && selItem.IsMouseOver && e.ChangedButton == MouseButton.Left)
                {
                    ElementId doorId = (list.SelectedItem as DoorInfo).DoorId;
                    using (FilteredElementCollector doorCol = new FilteredElementCollector(Uidoc.Document).OfCategory(BuiltInCategory.OST_Doors).OfClass(typeof(FamilyInstance)))
                    {
                        DoorIds = doorCol.Select(x => x.Id).ToList();
                        if (!DoorIds.Contains(doorId))
                        {
                            MessageBox.Show("该行对应门实例已被删除");
                            return;
                        }
                    }
                    Uidoc.Selection.SetElementIds(new ElementId[] { doorId });
                    Uidoc.ShowElements(doorId);
                    var door = Uidoc.Document.GetElement((list.SelectedItem as DoorInfo).DoorId) as FamilyInstance;
                    cb_select_symbol.SelectedItem = doorSymbolInfos.First(x => x.FamilySymbol.Id.IntegerValue == door.Symbol.Id.IntegerValue);
                }
            }
        }

        private void cb_select_symbol_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //MessageBox.Show(cb_select_symbol.SelectedValue + "\n" + cb_select_symbol.SelectedItem + "\n" + cb_select_symbol.Text + "\n");
            try
            {
                DoorSymbolInfo doorSymbolInfo = cb_select_symbol.SelectedItem as DoorSymbolInfo;
                if (list.SelectedIndex != -1 && (list.SelectedItem as DoorInfo).FamilySymbol.Id.IntegerValue != doorSymbolInfo.FamilySymbol.Id.IntegerValue)
                {
                    ElementId doorId = (list.SelectedItem as DoorInfo).DoorId;
                    using (FilteredElementCollector doorCol = new FilteredElementCollector(Uidoc.Document).OfCategory(BuiltInCategory.OST_Doors).OfClass(typeof(FamilyInstance)))
                    {
                        DoorIds = doorCol.Select(x => x.Id).ToList();
                        if (!DoorIds.Contains(doorId))
                        {
                            MessageBox.Show("该行对应门实例已被删除");
                            return;
                        }
                    }

                    DoorInfo doorInfo = list.SelectedItem as DoorInfo;
                    doorInfo.FamilySymbol = doorSymbolInfo.FamilySymbol;
                    doorInfo.DoorName = doorSymbolInfo.SymbolName;

                    changeSymbolEvent.Door = doorInfo.Door;
                    changeSymbolEvent.DoorSymbol = doorSymbolInfo.FamilySymbol;
                    
                    _externalEvent.Raise();

                    IsCorrect(doorInfo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }

        private void IsCorrect(DoorInfo doorInfo)
        {
            if (string.IsNullOrEmpty(doorInfo.NoteText))
            {
                doorInfo.Correct = "未知";
                doorInfo.TextColor = "yellow";
                doorInfo.TextBackColor = null;

            }
            else
            {
                string text = doorInfo.NoteText;
                text = text.Replace("\r", "");
                text = text.Replace("\n", "");
                string num = Regex.Replace(text, "[^0-9]+", "");
                if (num.Count() != 4)
                {
                    doorInfo.Correct = "未知";
                    doorInfo.TextColor = "yellow";
                    doorInfo.TextBackColor = null;
                }

                double noteWidth = (Convert.ToDouble(num[0].ToString() + num[1].ToString()) * 100) / 304.8;
                double noteHeight = (Convert.ToDouble(num[2].ToString() + num[3].ToString()) * 100) / 304.8;
                double doorWidth = doorInfo.FamilySymbol.get_Parameter(BuiltInParameter.FURNITURE_WIDTH).AsDouble();
                double doorHeight = doorInfo.FamilySymbol.get_Parameter(BuiltInParameter.FAMILY_HEIGHT_PARAM).AsDouble();

                if (Math.Abs(noteWidth - doorWidth) < 0.001 && Math.Abs(noteHeight - doorHeight) < 0.001)
                {
                    doorInfo.Correct = "是";
                    doorInfo.TextColor = "black";
                    doorInfo.TextBackColor = null;
                }
                else
                {
                    doorInfo.Correct = "否";
                    doorInfo.TextColor = "red";
                    doorInfo.TextBackColor = "blue";
                }
            }

        }

    }
}
