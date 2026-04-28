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

namespace ReviewDoorClearHeight
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        UIDocument Uidoc;
        public MainWindow(UIDocument uidoc, List<ClearHeightInfo> clearHeightInfos)
        {
            InitializeComponent();
            Uidoc = uidoc;
            list.ItemsSource = clearHeightInfos;
        }

        private void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                ClearHeightInfo info = list.SelectedItem as ClearHeightInfo;
                if (Properties.Settings.Default.IsLinkDoor)
                {
                    UIView uIView = Uidoc.GetOpenUIViews().FirstOrDefault(uiv => uiv.ViewId == Uidoc.ActiveView.Id);

                    uIView?.ZoomToFit();
                    //Uidoc.ShowElements(id);
                    XYZ point = info.Point;
                    XYZ min = point - XYZ.BasisX * (3000 / 304.8) - XYZ.BasisY * (3000 / 304.8);
                    XYZ max = point + XYZ.BasisX * (3000 / 304.8) + XYZ.BasisY * (3000 / 304.8);
                    uIView?.ZoomAndCenterRectangle(min, max);
                }
                else
                {
                    ElementId id = info.DoorId;
                    Uidoc.ShowElements(id);
                    Uidoc.Selection.SetElementIds(new ElementId[] { id });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
    }
}
