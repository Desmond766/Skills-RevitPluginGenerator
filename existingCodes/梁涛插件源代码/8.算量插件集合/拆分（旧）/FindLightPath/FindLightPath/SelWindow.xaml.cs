using Autodesk.Revit.DB;
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

namespace FindLightPath
{
    /// <summary>
    /// SelWindow.xaml 的交互逻辑
    /// </summary>
    public partial class SelWindow : Window
    {
        public string LightNum { get; private set; }
        public int RunNum { get; private set; }
        public SelWindow(Document doc, string selLightNum)
        {
            InitializeComponent();
            var lightNums = new FilteredElementCollector(doc, doc.ActiveView.Id)
                .OfCategory(BuiltInCategory.OST_GenericModel)
                .Where(x => x.LookupParameter("灯具编号") != null && !string.IsNullOrEmpty(x.LookupParameter("灯具编号").AsString()))
                .Select(y => y.LookupParameter("灯具编号").AsString())
                .ToList().Distinct().OrderBy(x => x);
            cb_light_num.ItemsSource = lightNums;
            if (lightNums.Count() > 0) cb_light_num.SelectedIndex = 0;
            if (selLightNum != string.Empty)
            {
                cb_light_num.Text = selLightNum;
                cb_light_num.IsEnabled = false;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LightNum = cb_light_num.Text;
            try
            {
                RunNum = Convert.ToInt32(tb_run_num.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            DialogResult = true;
        }
    }
}
