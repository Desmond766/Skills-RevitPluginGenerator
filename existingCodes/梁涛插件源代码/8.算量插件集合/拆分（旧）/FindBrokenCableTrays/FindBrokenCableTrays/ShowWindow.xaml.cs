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

namespace FindBrokenCableTrays
{
    /// <summary>
    /// ShowWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ShowWindow : Window
    {
        UIDocument uidoc = null;
        public ShowWindow(List<CableTrayInfo> cableTrayInfos, UIDocument uidoc)
        {
            InitializeComponent();
            list.ItemsSource = cableTrayInfos;
            this.uidoc = uidoc;
        }

        private void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (list.SelectedItem != null)
            {
                CableTrayInfo cableTrayInfo = list.SelectedItem as CableTrayInfo;
                uidoc.ShowElements(cableTrayInfo.CableTrayId);
                uidoc.Selection.SetElementIds(new ElementId[] { cableTrayInfo.CableTrayId });
            }
        }
    }
}
