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

namespace RampArrowParallelFloor
{
    /// <summary>
    /// PreviewWindow.xaml 的交互逻辑
    /// </summary>
    public partial class PreviewWindow : Window
    {
        public bool OppositeDir { get; set; }
        public PreviewWindow( Document doc, ElementId viewId)
        {
            InitializeComponent();
            PreviewControl previewControl = new PreviewControl(doc, viewId);
            grid_preview.Children.Add(previewControl);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (chb_opposite.IsChecked == true)
            {
                OppositeDir = true;
            }
            else
            {
                OppositeDir = false;
            }
            DialogResult = true;
            Close();
        }
    }
}
