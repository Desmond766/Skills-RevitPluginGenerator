using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Plumbing;
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

namespace InspectionWellElevationAdjustment
{
    /// <summary>
    /// AddPipeTypeWindow.xaml 的交互逻辑
    /// </summary>
    public partial class AddPipeTypeWindow : Window
    {
        public List<string> PipeTypeNames { get; set; } = new List<string>();
        public AddPipeTypeWindow(Document doc, Window ownerWindow)
        {
            InitializeComponent();
            Owner = ownerWindow;
            list.ItemsSource = GetPipeTypeNames(doc);
        }
        private List<string> GetPipeTypeNames(Document doc)
        {
            List<string> result = new List<string>();

            result = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_PipeCurves).Where(p => p is PipeType).Select(p => p.Name).ToList();
            result = result.Distinct().OrderBy(r => r).ToList();

            return result;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (list.SelectedItems.Count == 0)
            {
                MessageBox.Show("至少选择一种管道类型");
                return;
            }
            try
            {
                foreach (var item in list.SelectedItems)
                {
                    PipeTypeNames.Add(item.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            DialogResult = true;
        }
    }
}
