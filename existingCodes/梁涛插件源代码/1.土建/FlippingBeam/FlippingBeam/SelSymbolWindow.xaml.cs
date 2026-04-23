using Autodesk.Revit.DB;
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

namespace FlippingBeam
{
    /// <summary>
    /// SelSymbolWindow.xaml 的交互逻辑
    /// </summary>
    public partial class SelSymbolWindow : Window
    {
        public string NewSymbolName { get; private set; }
        public bool Reset { get; private set; } = false;
        public SelSymbolWindow(Document doc, Window ownerWindow)
        {
            InitializeComponent();
            this.Owner = ownerWindow;
            list.ItemsSource = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_StructuralFraming).OfClass(typeof(FamilySymbol)).Cast<FamilySymbol>().Where(x => x.Family.Name.Contains("梁"))
            .OrderBy(f => (f.LookupParameter("b") ?? f.LookupParameter("宽度"))?.AsDouble()).ThenBy(f => (f.LookupParameter("h") ?? f.LookupParameter("高度"))?.AsDouble()).ThenBy(y => Regex.Replace(y.Name, @"[^0-9]+", "")).Select(x => x.Name).ToList();
        }

        private void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string beamSymbolName = list.SelectedItem.ToString();
            NewSymbolName = beamSymbolName;
            //MessageBox.Show(NewSymbolName);
            DialogResult = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Reset = true;
            DialogResult = true;
        }
    }
}
