using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Demo02
{
    [Transaction(TransactionMode.Manual)]
    public class EventCommand : IExternalEventHandler
    {
        public bool first { get; set; }
        public void Execute(UIApplication app)
        {
            UIDocument uIDoc = app.ActiveUIDocument;
            Document doc = uIDoc.Document;
            if (first)
            {
                MessageBox.Show("first");
            }
            else
            {
                MessageBox.Show("second");
            }

        }

        public string GetName()
        {
            return "EventCommand";
        }
    }
}
