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

namespace MovePointElement
{
    /// <summary>
    /// TestWindow.xaml 的交互逻辑
    /// </summary>
    public partial class TestWindow : Window
    {
        TestEvent testEvent = null;
        ExternalEvent externalEvent = null;
        public TestWindow()
        {
            InitializeComponent();
            list.Items.Add("5272273");
            list.Items.Add("5272275");
            list.Items.Add("5272271");
            list.Items.Add("5272269");
            testEvent = new TestEvent();
            externalEvent = ExternalEvent.Create(testEvent);
        }

        private void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int seli = list.SelectedIndex;
            switch (seli)
            {
                case 0: testEvent.Ids = new List<ElementId>() { new ElementId(5272273) };
                    break;
                case 1: testEvent.Ids = new List<ElementId>() { new ElementId(5272275) };
                    break;
                case 2: testEvent.Ids = new List<ElementId>() { new ElementId(5272271) };
                    break;
                case 3: testEvent.Ids = new List<ElementId>() { new ElementId(5272269) };
                    break;
                default:
                    break;
            }
            if (testEvent.Ids.Count > 0)
            {
                externalEvent.Raise();
            }
        }
    }
    public class TestEvent : IExternalEventHandler
    {
        public List<ElementId> Ids { get; set; }
        public void Execute(UIApplication app)
        {
            UIDocument uidoc = app.ActiveUIDocument;
            Document doc = uidoc.Document;

            try
            {
                using (Transaction t = new Transaction(doc, "临时隐藏"))
                {
                    t.Start();

                    doc.ActiveView.TemporaryViewModes.DeactivateAllModes();

                    Element e = doc.GetElement(Ids[0]);
                    Autodesk.Revit.DB.View activeView = app.ActiveUIDocument.ActiveView;
                    UIView uiView = app.ActiveUIDocument.GetOpenUIViews()
                        .Where(v => v.ViewId == activeView.Id).First();
                    BoundingBoxXYZ bbx = e.get_BoundingBox(activeView);
                    bbx = new BoundingBoxXYZ();
                    bbx.Min = e.get_BoundingBox(activeView).Min;
                    bbx.Max = e.get_BoundingBox(activeView).Max;
                    uiView.ZoomAndCenterRectangle(bbx.Min, bbx.Max);
                    doc.ActiveView.IsolateElementsTemporary(Ids);

                    t.Commit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        public string GetName()
        {
            return "test";
        }
    }
}
