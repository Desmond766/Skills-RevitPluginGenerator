using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Drawing;
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
using Color = System.Drawing.Color;

namespace ColoringOfStructuralPlates
{
    /// <summary>
    /// ShowGroup.xaml 的交互逻辑
    /// </summary>
    public partial class ShowGroup : Window
    {
        //取消订阅事件
        private ExternalEvent _externalEvent;
        private UnsubscribeEventHandler _handler;
        // 更换颜色事件
        private ChangeFloorColor changeFloorColor;
        private ExternalEvent changeEvent;
        private UIDocument UIDoc { get; set; }
        public ShowGroup(bool high, bool isCeiling, UIDocument uidoc, List<ColorInfo> colorInfos)
        {
            InitializeComponent();

            list.ItemsSource = colorInfos;

            _handler = new UnsubscribeEventHandler();
            _externalEvent = ExternalEvent.Create(_handler);
            changeFloorColor = new ChangeFloorColor();
            changeEvent = ExternalEvent.Create(changeFloorColor);
            UIDoc = uidoc;
            if (isCeiling)
            {
                high_or_level.Header = "自标高高度偏移(mm)";
                Title = "天花板赋色";
            }
            else if (high)
            {
                high_or_level.Header = "板厚(mm)";
                Title = "楼板赋色";
            }
            else
            {
                high_or_level.Header = "顶部高程(mm)";
                Title = "楼板赋色";
                this.Width = 320;
                dgt_high.Visibility = Visibility.Visible;
            }

            //cb_title.Items.Add("相对");
            cb_title.Items.Add("测量点");
            cb_title.Items.Add("项目基点");



            cb_title.SelectedIndex = 0;
        }

        private void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _externalEvent.Raise();
        }

        private void list_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selIndex = list.SelectedIndex;
            if (selIndex != -1)
            {
                var selItem = list.ItemContainerGenerator.ContainerFromIndex(selIndex) as DataGridRow;
                if (selItem != null && selItem.IsMouseOver && e.ChangedButton == MouseButton.Left)
                {
                    var colorInfo = list.SelectedItem as ColorInfo;
                    ColorSelectionDialog colorDialog = new ColorSelectionDialog();
                    colorDialog.OriginalColor = colorInfo.Color;
                    if (colorDialog.Show() == ItemSelectionDialogResult.Confirmed)
                    {
                        var color = colorDialog.SelectedColor;
                        colorInfo.Color = color;
                        //colorInfo.FloorColor = new Command().RgbToHex2(color.Red, color.Green, color.Blue);
                        //Button button = FindVisualChild<Button>(selItem);
                        //button.Background = new SolidColorBrush(Color.FromRgb(color.Red, color.Green, color.Blue));
                        colorInfo.FloorColor = ColorTranslator.ToHtml(Color.FromArgb(color.Red, color.Green, color.Blue));

                        changeFloorColor.Color = colorDialog.SelectedColor;
                        changeFloorColor.ElemIds = colorInfo.ElemIds;
                        changeEvent.Raise();
                    }

                }
            }
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

        private void cb_title_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgt_high.Visibility == Visibility.Collapsed || dgt_high.Visibility == Visibility.Hidden) return;
            string selValue = cb_title.SelectedValue.ToString();
            var infos = list.ItemsSource as List<ColorInfo>;
            if (selValue == "项目基点")
            {
                infos.ForEach(i => i.MeasureOrProject = i.HighOrTop);
            }
            else if (selValue == "测量点")
            {
                Command.UpdateBasePointData(infos, UIDoc.Document);
            }
        }
    }

    public class UnsubscribeEventHandler : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            app.Application.DocumentChanged -= Command.OnDocumentChanged;
        }

        public string GetName()
        {
            return "UnsubscribeEventHandler";
        }
    }
}
