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
    /// UnconnectedWindow.xaml 的交互逻辑
    /// </summary>
    public partial class UnconnectedWindow : Window
    {
        //取消订阅事件
        private ExternalEvent _externalEvent;
        private UnsubscribeEventHandler _handler;

        UIDocument UIDoc { get; set; }
        public List<UnconnectedInfo> UnconnectedInfos { get; set; }
        public UnconnectedWindow(List<UnconnectedInfo> infos, UIDocument uidoc)
        {
            InitializeComponent();

            _handler = new UnsubscribeEventHandler();
            _externalEvent = ExternalEvent.Create(_handler);

            UnconnectedInfos = infos;
            UIDoc = uidoc;
            list.ItemsSource = infos;
        }

        private void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UnconnectedInfo info = list.SelectedItem as UnconnectedInfo;
            try
            {
                UIDoc.ShowElements(info.LineID);
                UIDoc.Selection.SetElementIds(new ElementId[] { info.LineID });
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

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _externalEvent.Raise();
        }
    }
    public class UnsubscribeEventHandler : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            app.Application.DocumentChanged -= ConnectAllCableTrayCmd.OnDocumentChanged;
        }

        public string GetName()
        {
            return "UnsubscribeEventHandler";
        }
    }
}
