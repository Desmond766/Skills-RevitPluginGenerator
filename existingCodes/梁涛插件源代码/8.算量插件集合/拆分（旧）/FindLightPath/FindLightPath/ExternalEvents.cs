using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FindLightPath
{
    public class AddRouteParaCmd : IExternalEventHandler
    {
        public List<ElementId> Ids { get; set; } = new List<ElementId>();
        public string RouteValue { get; set; }
        public void Execute(UIApplication app)
        {
            UIDocument uidoc = app.ActiveUIDocument;
            Document doc = uidoc.Document;

            using (Transaction t = new Transaction(doc, "路由参数赋值"))
            {
                t.Start();

                foreach (var id in Ids)
                {
                    Element elem = doc.GetElement(id);
                    Parameter routePara = elem.LookupParameter("路由");
                    if (routePara == null || routePara.IsReadOnly) continue;
                    if (string.IsNullOrEmpty(routePara.AsString()))
                    {
                        routePara.Set(RouteValue);
                    }
                    else
                    {
                        routePara.Set(routePara.AsString() + "|" + RouteValue);
                    }
                }

                t.Commit();
            }
            MessageBox.Show("赋值成功!");
        }

        public string GetName()
        {
            return "AddRouteParaCmd";
        }
    }
}
