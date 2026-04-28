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
using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;

namespace Demo02
{
    /// <summary>
    /// UserControl3.xaml 的交互逻辑
    /// </summary>
    public partial class UserControl4 : Window
    {
        public List<Collision> datalist;
        ExecuteEventHandler _executeEventHandler = null;
        ExternalEvent _externalEvent = null;
        public UserControl4(List<Collision> pathVMS, ExecuteEventHandler executeEventHandler, ExternalEvent externalEvent)
        {
            InitializeComponent();
            this.datalist33.ItemsSource = pathVMS;
            _executeEventHandler = executeEventHandler;
            _externalEvent = externalEvent;
        }



        private void datalist33_SelectedCellsChanged_1(object sender, SelectedCellsChangedEventArgs e)
        {
            int rownum = this.datalist33.SelectedIndex;
            Collision bb = (this.datalist33.SelectedItem as Collision);
            if (_externalEvent != null)
            {
                _executeEventHandler.ExecuteAction = new Action<UIApplication>((app) =>
                {
                    if (app.ActiveUIDocument == null || app.ActiveUIDocument.Document == null)
                        return;

                    Document revitDoc = app.ActiveUIDocument.Document;
                    using (Transaction transaction = new Transaction(revitDoc, "Creat Line1"))
                    {
                        transaction.Start();
           
                        ElementId elementId = bb.eid;
                        ICollection<ElementId> selectedElementIds = new List<ElementId>();
              
                        selectedElementIds.Add(elementId);
                        app.ActiveUIDocument.RefreshActiveView();
                        string bb2 = app.ActiveUIDocument.Document.GetElement(elementId).Name;
                
                        app.ActiveUIDocument.Selection.SetElementIds(selectedElementIds);

                        selectedElementIds.Add(elementId);
                        app.ActiveUIDocument.ShowElements(app.ActiveUIDocument.Document.GetElement(elementId));


                        transaction.Commit();
                    }
                });
                _externalEvent.Raise();
            }
        }

        private void datalist33_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = e.Row.GetIndex() + 1;
        }

        private void datalist33_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
