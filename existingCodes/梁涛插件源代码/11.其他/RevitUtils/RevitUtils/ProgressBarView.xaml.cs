using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace RevitUtils
{
    /// <summary>
    /// ProgressBarView.xaml 的交互逻辑
    /// </summary>
    public partial class ProgressBarView : Window
    {
        ExternalCommandData m_commandData = null;
        Thread thread = null;
        public bool Cancel { get; private set; } = false;
        public ProgressBarView(ExternalCommandData commandData)
        {
            InitializeComponent();
            m_commandData = commandData;
            
        }
        public ProgressBarView()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //thread = new Thread(excute);
            //thread.Start();
        }
        private void excute()
        {
            this.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, (ThreadStart)delegate () { StrightRigidFrameBridgeCreater(); });

        }
        public void StrightRigidFrameBridgeCreater()
        {
            UIDocument uidoc = m_commandData.Application.ActiveUIDocument;
            Document doc = m_commandData.Application.ActiveUIDocument.Document;
            var floors = new  FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_Floors);
            int addCount = 100 / floors.Count();

            Transaction t = new Transaction(doc, "修改板厚");
            t.Start();
            foreach (var item in floors)
            {
                //uidoc.ShowElements(item);
                uidoc.Selection.SetElementIds(new ElementId[] { item.Id });
                Thread.Sleep(500);
                if (item.get_Parameter(BuiltInParameter.FLOOR_HEIGHTABOVELEVEL_PARAM).IsReadOnly == false)
                {
                    item.get_Parameter(BuiltInParameter.FLOOR_HEIGHTABOVELEVEL_PARAM).Set(item.get_Parameter(BuiltInParameter.FLOOR_HEIGHTABOVELEVEL_PARAM).AsDouble() + 2000 / 304.8);
                }
                int nowCount = (int)(pb.Value + addCount);
                if (nowCount > 100)
                {
                    pb.Value = 100;
                }
                else
                {
                    pb.Value += addCount;
                }
                if (pb.Value >= 100) Close();
                System.Windows.Forms.Application.DoEvents();
            }
            pb.Value = 100;
            Close();
            t.Commit();
            //for (int i = 0; i <= 100; i++)
            //{
            //    Thread.Sleep(100);
            //    pb.Value = i;
            //    System.Windows.Forms.Application.DoEvents();

            //}
            
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            //thread.Abort();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Cancel = true;
            Close();
        }
        public void SetProgressBar(double min, double max, string total, string tranName)
        {
            pb.Minimum = min;
            pb.Maximum = max;
            lbl_totalCount.Content = total;
            lbl_tranName.Content = tranName;
        }
        public void SetValue(double value, string content)
        {
            pb.Value = value;
            lbl_percent.Content = content;
        }
        public void SetValue(double value, double totalCount)
        {
            pb.Value = value;
            lbl_percent.Content = Math.Round((((double)value / totalCount) * 100)) + "%";
        }
        public void SetNowProgress(string total, string tranName = null)
        {
            lbl_totalCount.Content = total;
            if (tranName != null) lbl_tranName.Content = tranName;
        }
        public void SetNowProgress(int nowCount, int totalCount, string tranName = null)
        {
            lbl_totalCount.Content = $"- {nowCount}/{totalCount}";
            if (tranName != null) lbl_tranName.Content = tranName;
        }
        public void SetTotalProgress(int nowCount, int totalCount)
        {
            lbl_total.Content = "总进度：" + nowCount + "/" + totalCount;
        }
    }
}
