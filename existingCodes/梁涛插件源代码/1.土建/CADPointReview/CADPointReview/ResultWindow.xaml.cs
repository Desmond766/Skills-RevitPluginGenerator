using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using RevitUtils;
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

namespace CADPointReview
{
    /// <summary>
    /// ResultWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ResultWindow : Window
    {
        UIDocument Uidoc = null;
        List<BlockInfo> BlockInfos;
        View3D View3D = null;
        public ResultWindow(UIDocument uidoc, List<BlockInfo> blockInfos, string title, View3D view3D)
        {
            InitializeComponent();
            this.Uidoc = uidoc;
            list.ItemsSource = blockInfos;
            BlockInfos = blockInfos;
            Title = title + Title;
            Width = 140 + Title.Length * 13;
            View3D = view3D;
        }

        private void list_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selIndex = list.SelectedIndex;
            if (selIndex != -1)
            {
                var selItem = list.ItemContainerGenerator.ContainerFromIndex(selIndex) as DataGridRow;
                if (selItem != null && selItem.IsMouseOver && e.ChangedButton == MouseButton.Left)
                {
                    ElementId id = (list.SelectedItem as BlockInfo).ElementId;
                    UIView uIView = Uidoc.GetOpenUIViews().FirstOrDefault(uiv => uiv.ViewId == Uidoc.ActiveView.Id);

                    if (id != null)
                    {
                        using (FilteredElementCollector elemCol = new FilteredElementCollector(Uidoc.Document).WhereElementIsNotElementType())
                        {
                            if (elemCol.Count(elem => elem.Id == id) > 0)
                            {
                                uIView?.ZoomToFit();
                                Uidoc.Selection.SetElementIds(new ElementId[] { id });
                                //Uidoc.ShowElements(id);
                                XYZ point = (list.SelectedItem as BlockInfo).Point;
                                XYZ min = point - XYZ.BasisX * (1000 / 304.8) - XYZ.BasisY * (1000 / 304.8);
                                XYZ max = point + XYZ.BasisX * (1000 / 304.8) + XYZ.BasisY * (1000 / 304.8);
                                uIView?.ZoomAndCenterRectangle(min, max);
                            }
                            else
                            {
                                MessageBox.Show("该行对应点位族实例已被删除");
                                XYZ point = (list.SelectedItem as BlockInfo).Point;
                                XYZ min = point - XYZ.BasisX * (1000 / 304.8) - XYZ.BasisY * (1000 / 304.8);
                                XYZ max = point + XYZ.BasisX * (1000 / 304.8) + XYZ.BasisY * (1000 / 304.8);
                                uIView?.ZoomAndCenterRectangle(min, max);

                                return;
                            }   
                        }
                    }
                    else
                    {
                        XYZ point = (list.SelectedItem as BlockInfo).Point;
                        XYZ min = point - XYZ.BasisX * (1000 / 304.8) - XYZ.BasisY * (1000 / 304.8);
                        XYZ max = point + XYZ.BasisX * (1000 / 304.8) + XYZ.BasisY * (1000 / 304.8);
                        uIView?.ZoomAndCenterRectangle(min, max);
                    }
                    
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Document doc = Uidoc.Document;
            for (int i = 0; i < BlockInfos.Count; i++)
            {
                if (BlockInfos[i].ElementId == null || BlockInfos[i].ElementType == "结构柱") continue;

                Element element = doc.GetElement(BlockInfos[i].ElementId);
                //XYZ point = Utils.GetPoint(element);
                XYZ point = element.get_BoundingBox(null).Min.Add(element.get_BoundingBox(null).Max) / 2;
                double minElemZ = Utils.GetMinPointBySolid(element).Z;

                point = new XYZ(point.X, point.Y, minElemZ);

                double dis = Utils.GetDistanceToFloorByRay(point, View3D, XYZ.BasisZ.Negate(), true);
                BlockInfos[i].PointHeight = Math.Round(dis * 304.8, 2);
            }
        }
    }
}
