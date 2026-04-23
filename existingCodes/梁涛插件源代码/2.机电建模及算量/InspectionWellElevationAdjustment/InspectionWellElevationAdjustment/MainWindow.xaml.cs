using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Document Doc;
        private string PipeTypeNames = string.Empty;
        public ObservableCollection<WellInfo> WellInfos { get; set; } = new ObservableCollection<WellInfo>();
        public MainWindow(Document doc)
        {
            InitializeComponent();
            Doc = doc;
            list.ItemsSource = WellInfos;
            cb_well_type.ItemsSource = GetWellTypeNames(doc);

            switch (Properties.Settings.Default.WellScope)
            {
                case 0:
                    rb_sel.IsChecked = true;
                    break;
                case 1:
                    rb_current_view.IsChecked = true;
                    break;
                case 2:
                    rb_current_project.IsChecked = true;
                    break;
                default:
                    break;
            }
        }
        private List<string> GetWellTypeNames(Document doc)
        {
            List<string> result = new List<string>();

            result = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_GenericModel)
                .Where(e => e is FamilySymbol familySymbol && familySymbol.FamilyName.Contains("井"))
                .Cast<FamilySymbol>().Select(f => f.FamilyName).ToList();
            result = result.Distinct().ToList();


            return result;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddPipeTypeWindow addPipeTypeWindow = new AddPipeTypeWindow(Doc, this);
            addPipeTypeWindow.ShowDialog();

            if (addPipeTypeWindow.DialogResult == false)
            {
                return;
            }
            //addPipeTypeWindow.PipeTypeNames.ForEach(t => PipeTypeNames += t + "\n");
            //MessageBox.Show(PipeTypeNames);
            PipeTypeNames = string.Join("\n", addPipeTypeWindow.PipeTypeNames);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (PipeTypeNames == string.Empty)
                {
                    MessageBox.Show("未选择对应管道族类型");
                    return;
                }
                else if (cb_well_type.SelectedIndex == -1)
                {
                    MessageBox.Show("未选择检查井族类型");
                    return;
                }
                WellInfos.Add(new WellInfo() { WellTypeName = cb_well_type.SelectedValue.ToString(), PipeTypeNames = PipeTypeNames });
                cb_well_type.SelectedIndex = -1;
                PipeTypeNames = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
           
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                if (rb_sel.IsChecked == true)
                {
                    Properties.Settings.Default.WellScope = 0;
                }
                else if (rb_current_view.IsChecked == true)
                {
                    Properties.Settings.Default.WellScope = 1;
                }
                else
                {
                    Properties.Settings.Default.WellScope = 2;
                }
                Properties.Settings.Default.Save();
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
