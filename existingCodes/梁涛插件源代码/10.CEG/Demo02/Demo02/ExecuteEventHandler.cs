using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI.Events;
using Autodesk.Revit.UI.Selection;
using System.Windows;
using Autodesk.Revit.DB.Architecture;
using System.IO;

namespace Demo02
{
    public class ExecuteEventHandler : IExternalEventHandler
    {
        public string Name { get; private set; }

        public Action<UIApplication> ExecuteAction { get; set; }

        public ExecuteEventHandler(string name)
        {
            Name = name;
        }

        public void Execute(UIApplication app)
        {
            if (ExecuteAction != null)
            {
                try
                {
                    ExecuteAction(app);
                }
                catch
                { }
            }
        }

        public string GetName()
        {
            return Name;
        }
    }

}
