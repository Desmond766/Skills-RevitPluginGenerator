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

namespace FindLightPath
{
    /// <summary>
    /// LightRouteWindow.xaml 的交互逻辑
    /// </summary>
    public partial class LightRouteWindow : Window
    {
        public UIDocument UIDoc { get; set; }
        public List<LightRouteInfo> Lights { get; set; }
        Element PowerBox;
        string LightNum;

        // 回路赋值外部事件
        ExternalEvent AddRouteEvent = null;
        AddRouteParaCmd AddRouteParaCmd = null;
        public LightRouteWindow (List<LightRouteInfo> lights, UIDocument uidoc, double length, string lightNum, Element powerBox)
        {
            InitializeComponent();

            AddRouteParaCmd = new AddRouteParaCmd();
            AddRouteEvent = ExternalEvent.Create(AddRouteParaCmd);

            UIDoc = uidoc;
            Lights = lights;
            PowerBox = powerBox;
            LightNum = lightNum;
            list.ItemsSource = Lights;
            lb_length.Content = length + " M";
            lb_light_num.Content = lightNum;
            if (powerBox.LookupParameter("电气-配电箱编号") != null) lb_route_num.Content = powerBox.LookupParameter("电气-配电箱编号").AsString() + ":" + lightNum;
        }

        private void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                List<LightRouteInfo> lightRouteInfos = new List<LightRouteInfo>();
                foreach (var item in list.SelectedItems) lightRouteInfos.Add(item as LightRouteInfo);

                List<ElementId> ids = new List<ElementId>();
                foreach (var item in lightRouteInfos) 
                    if (item.PathIds != null) ids.AddRange(item.PathIds); 
                    else ids.Add(new ElementId(item.UnPowerLightId));
                //if (lightRouteInfo.PathIds != null && lightRouteInfo.PathIds.Count > 0)
                //{
                //    //MessageBox.Show(lightRouteInfo.PathIds.Count.ToString());
                //    UIDoc.ShowElements(lightRouteInfo.PathIds);
                //    UIDoc.Selection.SetElementIds(lightRouteInfo.PathIds);
                //}
                //else
                //{
                //    UIDoc.ShowElements(new ElementId(lightRouteInfo.UnPowerLightId));
                //    UIDoc.Selection.SetElementIds(new ElementId[] { new ElementId(lightRouteInfo.UnPowerLightId) });
                //}

                UIDoc.ShowElements(ids);
                UIDoc.Selection.SetElementIds(ids);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string routeValue;
                if (PowerBox.LookupParameter("电气-配电箱编号") == null)
                {
                    MessageBox.Show("未找到回路编号");
                    return;
                }
                else
                {
                    routeValue = PowerBox.LookupParameter("电气-配电箱编号").AsString() + ":" + LightNum;
                }
                if (list.SelectedIndex == -1 || list.SelectedItems.Count == 0)
                {
                    MessageBox.Show("未选择任何回路");
                    return;
                }
                List<LightRouteInfo> lightRouteInfos = new List<LightRouteInfo>();
                foreach (var item in list.SelectedItems)
                {
                    LightRouteInfo routeInfo = item as LightRouteInfo;
                    lightRouteInfos.Add(routeInfo);
                }
                List<ElementId> ids = new List<ElementId>();
                lightRouteInfos.ForEach(l => { if (l.PathIds != null) ids.AddRange(l.PathIds); });
                if (ids.Count == 0)
                {
                    MessageBox.Show("未找到任何可赋值的回路");
                    return;
                }

                AddRouteParaCmd.RouteValue = routeValue;
                AddRouteParaCmd.Ids = ids;
                AddRouteEvent.Raise();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                string routeValue;
                if (PowerBox.LookupParameter("电气-配电箱编号") == null)
                {
                    MessageBox.Show("未找到回路编号");
                    return;
                }
                else
                {
                    routeValue = PowerBox.LookupParameter("电气-配电箱编号").AsString() + ":" + LightNum;
                }
                List<LightRouteInfo> lightRouteInfos = new List<LightRouteInfo>();
                foreach (var item in list.ItemsSource)
                {
                    LightRouteInfo routeInfo = item as LightRouteInfo;
                    lightRouteInfos.Add(routeInfo);
                }
                List<ElementId> ids = new List<ElementId>();
                lightRouteInfos.ForEach(l => { if (l.PathIds != null && l.PathIds.Count > 0) ids.AddRange(l.PathIds); });
                if (ids.Count == 0)
                {
                    MessageBox.Show("未找到任何可赋值的回路");
                    return;
                }


                AddRouteParaCmd.RouteValue = routeValue;
                AddRouteParaCmd.Ids = ids;
                AddRouteEvent.Raise();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
