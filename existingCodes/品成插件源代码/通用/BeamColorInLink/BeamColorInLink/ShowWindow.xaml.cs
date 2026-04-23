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

namespace BeamColorInLink
{
    /// <summary>
    /// ShowWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ShowWindow : Window
    {
        ShowEventCommand _showEventCommand = null;
        ExternalEvent externalEvent = null;
        public ShowWindow()
        {
            InitializeComponent();
            _showEventCommand = new ShowEventCommand();
            externalEvent = ExternalEvent.Create(_showEventCommand);
        }

        private void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BeamInfo beamInfo = list.SelectedItem as BeamInfo;
            _showEventCommand.TextNoteId = beamInfo.TextNoteId;
            externalEvent.Raise();
        }
    }

    public class ShowEventCommand : IExternalEventHandler
    {
        public ElementId TextNoteId { get; set; }
        public void Execute(UIApplication app)
        {
            UIDocument uIDoc = app.ActiveUIDocument;
            try
            {
                uIDoc.ShowElements(TextNoteId);
                uIDoc.Selection.SetElementIds(new List<ElementId>() { TextNoteId });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public string GetName()
        {
            return "ShowEventCommand";
        }
    }
}
