using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AnalysisOfNetHeightIssues
{
    /// <summary>
    /// UserControl2.xaml 的交互逻辑
    /// </summary>
    public partial class UserControl2 : Window
    {
        //补充的代码：创建外部事件
        EventCommand handlerCommand = null;
        ExternalEvent handlerEvent = null;
        Document doc;
        public UserControl2(List<Difference> differences,Document doc)
        {
            InitializeComponent();
            handlerCommand = new EventCommand();
            handlerEvent = ExternalEvent.Create(handlerCommand);
            this.doc = doc;
            list.ItemsSource = differences;
        }

        private void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Duct> ducts = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_DuctCurves).OfClass(typeof(Duct)).Cast<Duct>().ToList();
            Difference difference = list.SelectedItem as Difference;
            if (!ducts.Select(x => x.Id).Contains(difference.ductId)) return;
            handlerCommand.ductId = difference.ductId;
            handlerEvent.Raise();
            //handlerCommand.name = list.Columns[1].GetCellContent(list.Items[0] as TextBlock).DataContext as string;
            //handlerEvent.Raise();
        }
    }
    public class Difference
    {
        public double spacing{ get; set; }
        public double inputValue { get; set; }
        public string result { get; set; }
        public ElementId beamId { get; set; }
        public ElementId ductId { get; set; }
        public string notes { get; set; }
    }
}
