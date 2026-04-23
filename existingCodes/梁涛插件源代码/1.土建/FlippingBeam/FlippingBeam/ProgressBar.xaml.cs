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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace FlippingBeam
{
    /// <summary>
    /// ProgressBar.xaml 的交互逻辑
    /// </summary>
    public partial class ProgressBar : Window
    {
        public ProgressBar()
        {
            InitializeComponent();
        }

        private void pgb_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void TaskMethod()
        {
            for (int i = 1; i <= 100; i++)
            {
                Thread.Sleep(50);
                Dispatcher.BeginInvoke((ThreadStart)delegate
                {
                    pgb.Value = i;
                }, DispatcherPriority.Normal);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Task task = new Task(TaskMethod);
            task.Start();
        }
    }
}
