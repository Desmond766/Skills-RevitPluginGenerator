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

namespace MoveParkingNumber
{
    /// <summary>
    /// FailWindow.xaml 的交互逻辑
    /// </summary>
    public partial class FailWindow : Window
    {
        readonly UIDocument UIDoc = null;
        public FailWindow(UIDocument uidoc)
        {
            InitializeComponent();
            UIDoc = uidoc;
        }

        private void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                ElementId elementId = list.SelectedItem as ElementId;
                UIDoc.ShowElements(elementId);
                UIDoc.Selection.SetElementIds(new ElementId[] { elementId });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
