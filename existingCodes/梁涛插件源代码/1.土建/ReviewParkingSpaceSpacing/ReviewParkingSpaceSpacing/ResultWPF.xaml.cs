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

namespace ReviewParkingSpaceSpacing
{
    /// <summary>
    /// ResultWPF.xaml 的交互逻辑
    /// </summary>
    public partial class ResultWPF : Window
    {
        UIDocument Uidoc = null;
        public ResultWPF(UIDocument uidoc, List<ParkingSpaceInfo> psInfos)
        {
            InitializeComponent();
            Uidoc = uidoc;
            list.ItemsSource = psInfos;
        }

        private void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ParkingSpaceInfo info = list.SelectedItem as ParkingSpaceInfo;
            try
            {
                //Uidoc.ShowElements(info.Id);

                UIView uIView = Uidoc.GetOpenUIViews().FirstOrDefault(uiv => uiv.ViewId == Uidoc.ActiveView.Id);
                uIView?.ZoomToFit();
                XYZ point = info.Point;
                XYZ min = point - XYZ.BasisX * (5000 / 304.8) - XYZ.BasisY * (5000 / 304.8);
                XYZ max = point + XYZ.BasisX * (5000 / 304.8) + XYZ.BasisY * (5000 / 304.8);
                uIView?.ZoomAndCenterRectangle(min, max);

                Uidoc.Selection.SetElementIds(new ElementId[] { info.Id });
                //刷新datagrid数据
                list.Items.Refresh();
                //datagrid控件重新获得焦点
                list.Focus();
                //滚动到当前行
                list.ScrollIntoView(list.SelectedItem);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
    }
}
