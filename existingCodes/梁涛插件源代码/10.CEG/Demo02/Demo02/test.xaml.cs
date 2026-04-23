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

namespace Demo02
{
    /// <summary>
    /// test.xaml 的交互逻辑
    /// </summary>
    public partial class test : Window
    {
        EventCommand handlerCommand = null;
        ExternalEvent handlerEvent = null;
        public test()
        {
            InitializeComponent();
            handlerCommand = new EventCommand();
            handlerEvent = ExternalEvent.Create(handlerCommand);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool first1;
            if (first.IsChecked == true)
            {
                first1 = true;
            }
            else
            {
                first1 = false;
            }
            handlerCommand.first = first1;
            //handlerCommand = new EventCommand(first1);
            //handlerEvent = ExternalEvent.Create(handlerCommand);
            handlerEvent.Raise();
        }
    }
}
