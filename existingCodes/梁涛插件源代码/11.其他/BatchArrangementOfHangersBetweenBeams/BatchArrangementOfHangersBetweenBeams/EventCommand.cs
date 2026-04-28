using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchArrangementOfHangersBetweenBeams
{
    public class EventCommand : IExternalEventHandler
    {
        bool check = false;
        public static UserControl1 userControl2 { get; set; } = null;
        public EventCommand()
        {
        }
        public void Execute(UIApplication app)
        {
            UIDocument uIDoc = app.ActiveUIDocument;
            Document doc = uIDoc.Document;
            if (userControl2.check.IsChecked == true)
            {
                userControl2.tb.Visibility = System.Windows.Visibility.Visible;
                userControl2.lb.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                userControl2.tb.Visibility = System.Windows.Visibility.Hidden;
                userControl2.lb.Visibility = System.Windows.Visibility.Hidden;
            }

        }

        public string GetName()
        {
            return "EventCommand";
        }
    }
}
