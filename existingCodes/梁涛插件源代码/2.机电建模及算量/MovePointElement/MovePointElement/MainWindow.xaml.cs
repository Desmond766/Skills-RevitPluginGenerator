using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
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
using Line = Autodesk.Revit.DB.Line;

namespace MovePointElement
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public BuiltInCategory PointCategory { get; private set; }
        public string PointName { get; private set; }
        public XYZ PointDirection { get; private set; } = XYZ.BasisY;
        public bool IsScope { get; private set; } = true;
        public BuiltInCategory HostCategory { get; private set; }
        public string HostName { get; private set; }
        public double Distance { get; private set; }
        public double Angle { get; private set; }
        public double ZError { get; private set; } = 0;
        public bool UseZError { get; private set; } = true;
        Document Doc = null;
        private readonly List<ElemInfo> PointElemInfos = new List<ElemInfo>();
        private readonly List<ElemInfo> HostElemInfos = new List<ElemInfo>();
        public MainWindow(Document doc)
        {
            InitializeComponent();
            Doc = doc;
            cb_point_direction.SelectedIndex = 1;

            tb_dis.Text = Properties.Settings.Default.distance.ToString();
            tb_angle.Text = Properties.Settings.Default.angle.ToString();
            tb_z_error.Text = Properties.Settings.Default.zError.ToString();

            //var pointTypeData = new FilteredElementCollector(doc).WhereElementIsNotElementType()
            //    .Where(e => e.Location != null && e.Location is LocationPoint)
            //    .GroupBy(x => x.Category.Name).Select(y => new { PointTypeName = y.Key, Count = y.ToList().Count }).ToList();

            // 点元素类型
            using (var pointCol = new FilteredElementCollector(doc).WhereElementIsNotElementType())
            {
                var pointGroup = pointCol.Where(e => e.Location != null && e.Location is LocationPoint && e.Category != null).GroupBy(x => x.Category.Id);
                pointGroup = pointGroup.OrderBy(g => Category.GetCategory(doc, g.Key).Name);
                foreach (var item in pointGroup)
                {
                    var cate = Category.GetCategory(doc, item.Key);
                    List<string> elemNames = item.ToList().GroupBy(x => x.Name).Select(y => y.Key).OrderBy(z => z).ToList();
                    PointElemInfos.Add(new ElemInfo(cate.Name, (BuiltInCategory)cate.Id.IntegerValue, elemNames));
                }
            }
            // 宿主元素类型
            using (var hostCol = new FilteredElementCollector(doc).WhereElementIsNotElementType())
            {
                var hostGroup = hostCol.Where(e => e.Location != null && e.Location is LocationCurve locationCurve && locationCurve.Curve is Line && e.Category != null).GroupBy(x => x.Category.Id);
                hostGroup = hostGroup.Where(g => g.Key != null && Category.GetCategory(doc, g.Key) != null).OrderBy(g => Category.GetCategory(doc, g.Key).Name);
                foreach (var item in hostGroup)
                {
                    var cate = Category.GetCategory(doc, item.Key);
                    List<string> elemNames = item.ToList().GroupBy(x => x.Name).Select(y => y.Key).OrderBy(z => z).ToList();
                    HostElemInfos.Add(new ElemInfo(cate.Name, (BuiltInCategory)cate.Id.IntegerValue, elemNames));
                }
                
            }
            // 特殊宿主元素：行车线
            using (var hostCol2 = new FilteredElementCollector(doc).WhereElementIsNotElementType())
            {
                var host = hostCol2.Where(e => e is Railing railing && railing.GetPath().Count > 0);
                if (host.Count() > 0)
                {
                    Element hostElem = host.FirstOrDefault();
                    List<string> elemNames = host.GroupBy(x => x.Name).Select(y => y.Key).OrderBy(z => z).ToList();
                    HostElemInfos.Add(new ElemInfo(hostElem.Category.Name, (BuiltInCategory)hostElem.Category.Id.IntegerValue, elemNames));
                }
            }
            cb_point_type.ItemsSource = PointElemInfos;
            cb_host_type.ItemsSource = HostElemInfos;
        }

        private void cb_point_type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cb_point_type.SelectedIndex == -1) return;
            ElemInfo elemInfo = cb_point_type.SelectedItem as ElemInfo;
            cb_point_name.SelectedIndex = -1;
            cb_point_name.ItemsSource = elemInfo.ElemNames;
            //MessageBox.Show(cb_point_type.SelectedItem as new { string = PointTypeName , Count });
        }

        private void cb_host_type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cb_host_type.SelectedIndex == -1) return;
            ElemInfo elemInfo = cb_host_type.SelectedItem as ElemInfo;
            cb_host_name.SelectedIndex = -1;
            cb_host_name.ItemsSource = elemInfo.ElemNames;
        }

        private void btn_confirm_Click(object sender, RoutedEventArgs e)
        {
            if (cb_point_type.SelectedIndex == -1)
            {
                MessageBox.Show("未选择点元素类型！");
                return;
            }
            if (cb_point_name.SelectedIndex == -1)
            {
                MessageBox.Show("未选择点元素实例名称！");
                return;
            }
            if (cb_host_type.SelectedIndex == -1)
            {
                MessageBox.Show("未选择宿主元素类型！");
                return;
            }
            if (cb_host_name.SelectedIndex == -1)
            {
                MessageBox.Show("未选择宿主元素实例名称！");
                return;
            }

            try
            {
                Distance = Convert.ToDouble(tb_dis.Text);
                Angle = Convert.ToDouble(tb_angle.Text);
                if (UseZError) ZError = Convert.ToDouble(tb_z_error.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                return;
            }
            Properties.Settings.Default.distance = Distance;
            Properties.Settings.Default.angle = Angle;
            if (UseZError) Properties.Settings.Default.zError = ZError;
            Properties.Settings.Default.Save();

            ElemInfo pointInfo = cb_point_type.SelectedItem as ElemInfo;
            PointCategory = pointInfo.ElemCategory;
            PointName = cb_point_name.SelectedItem as string;
            if (rb_scope.IsChecked == false) IsScope = false;

            ElemInfo hostInfo = cb_host_type.SelectedItem as ElemInfo;
            HostCategory = hostInfo.ElemCategory;
            HostName = cb_host_name.SelectedItem as string;

            DialogResult = true;
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            if (checkBox.IsChecked == false)
            {
                cb_host_type.SelectedIndex = -1;
                cb_host_name.SelectedIndex = -1;

                cb_link.SelectedItem = -1;
                cb_link.IsEnabled = false;
            }
            else if (checkBox.IsChecked == true)
            {
                cb_host_type.SelectedIndex = -1;
                cb_host_name.SelectedIndex = -1;

                cb_link.IsEnabled = true;
            }
        }

        private void CheckBox_Click_1(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            if (checkBox.IsChecked == false)
            {
                tb_z_error.IsEnabled = false;
                UseZError = false;
            }
            else if (checkBox.IsChecked == true)
            {
                tb_z_error.IsEnabled = true;
                UseZError = true;
            }
        }
    }
    public class ElemInfo
    {
        public string ElemCategoryName { get; set; }
        public BuiltInCategory ElemCategory { get; set; }
        public List<string> ElemNames { get; set; }
        public XYZ BasisDirection { get; set; }
        public ElemInfo(string elemCategoryName, BuiltInCategory elemCategory, List<string> elemNames)
        {
            ElemCategoryName = elemCategoryName;
            ElemCategory = elemCategory;
            ElemNames = elemNames;
        }
    }
}
