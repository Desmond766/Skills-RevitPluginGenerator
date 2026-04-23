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

namespace NetHeightAnalysis
{
    /// <summary>
    /// SelWindow.xaml 的交互逻辑
    /// </summary>
    public partial class SelWindow : Window
    {
        Document Doc { get; set; }
        List<TextNoteType> TextNoteTypes = new List<TextNoteType>();

        public ObservableCollection<FillInfo> FillInfos = new ObservableCollection<FillInfo>();
        public TextNoteType TextNoteType { get; set; }
        public SelWindow(Document doc)
        {
            InitializeComponent();
            Doc = doc;
            FilteredElementCollector collector1 = new FilteredElementCollector(doc);
            TextNoteTypes = collector1.OfClass(typeof(TextNoteType)).ToElements().Cast<TextNoteType>().ToList();
            var texts = TextNoteTypes.Where(x => x.FamilyName == "文字").Select(t => t.Name).OrderBy(n => n);
            cb_text_type.ItemsSource = texts;

            
            using (FilteredElementCollector fillTypeCol = new FilteredElementCollector(doc))
            {
                fillTypeCol.OfCategory(BuiltInCategory.OST_DetailComponents).OfClass(typeof(FilledRegionType));
                var types = fillTypeCol.Cast<FilledRegionType>().ToList();
                //foreach (var type in types)
                //{
                //    FillInfos.Add(new FillInfo() { FilledRegionType = type, FilledRegionTypeName = type.Name, Min = 0, Max = 0 });
                //}
                cb_fill_type.ItemsSource = types.Select(t => t.Name).OrderBy(n => n);
            }
            list.ItemsSource = FillInfos;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (cb_text_type.SelectedIndex == -1)
            {
                MessageBox.Show("请选择文字注释类型");
                return;
            }
            try
            {
                string text = cb_text_type.SelectedValue.ToString();
                TextNoteType = TextNoteTypes.First(t => t.Name == text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            //MessageBox.Show(FillInfos.Count.ToString());
            DialogResult = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (cb_fill_type.SelectedIndex == -1)
            {
                MessageBox.Show("请选择填充类型");
                return;
            }
            double min = -1;
            double max = -1;
            FilledRegionType type = null;
            try
            {
                min = Convert.ToDouble(tb_min.Text);
                max = Convert.ToDouble(tb_max.Text);

                using (FilteredElementCollector fillTypeCol = new FilteredElementCollector(Doc))
                {
                    fillTypeCol.OfCategory(BuiltInCategory.OST_DetailComponents).OfClass(typeof(FilledRegionType));
                    var types = fillTypeCol.Cast<FilledRegionType>().ToList();
                    type = types.First(t => t.Name == cb_fill_type.SelectedValue.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            FillInfos.Add(new FillInfo() { FilledRegionType = type, Min = min, Max = max, FilledRegionTypeName = type.Name });

            tb_min.Text = null;
            tb_max.Text = null;
            cb_fill_type.SelectedIndex = -1;
        }
    }
}
