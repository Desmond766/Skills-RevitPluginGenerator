using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
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

namespace NetHeightAnalysis
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private UIDocument Uidoc { get; set; }
        private readonly List<ClearHeightInfo> ClearHeightInfos = new List<ClearHeightInfo>();

        public ChangeColorEvent ChangeColorEvent = null;
        public ExternalEvent ExternalEvent = null;
        public MainWindow(UIDocument uidoc, List<ClearHeightInfo> clearHeightInfos)
        {
            InitializeComponent();
            list.ItemsSource = clearHeightInfos;
            this.Uidoc = uidoc;
            this.ClearHeightInfos = clearHeightInfos;
            ChangeColorEvent = new ChangeColorEvent();
            ExternalEvent = ExternalEvent.Create(ChangeColorEvent);
        }

        private void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                ClearHeightInfo clearHeightInfo = list.SelectedItem as ClearHeightInfo;
                List<ElementId> showIds = new List<ElementId>();
                if (clearHeightInfo.ElementId != null && clearHeightInfo.ElementId != ElementId.InvalidElementId)
                {
                    showIds.Add(clearHeightInfo.ElementId);
                }
                if (clearHeightInfo.FloorId != null && clearHeightInfo.FloorId != ElementId.InvalidElementId) showIds.Add(clearHeightInfo.FloorId);
                if (showIds.Count > 0)
                {
                    Uidoc.ShowElements(showIds);
                    Uidoc.Selection.SetElementIds(showIds);
                }
            }
            catch (Exception)
            {
                return;
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ChangeColorEvent.ClearHeightInfos = ClearHeightInfos;
            ExternalEvent.Raise();
            Close();
        }
    }
}
