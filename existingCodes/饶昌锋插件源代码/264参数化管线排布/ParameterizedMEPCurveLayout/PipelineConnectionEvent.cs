using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ParameterizedMEPCurveLayout
{
    public class PipelineConnectionEvent : IExternalEventHandler
    {
        public List<MEPCurveGroup> mEPCurveGroups { get; set; }
        public IList<MEPCurve> mEPCurves { get; set; }
        public string inputInterval { get; set; }
        public void Execute(UIApplication app)
        {
            Document doc = app.ActiveUIDocument.Document;
            using (Transaction tran = new Transaction(doc, "重新连接排序"))
            {
                tran.Start();
                foreach (MEPCurveGroup item in mEPCurveGroups)
                {
                    Connector startConnector = null;
                    Connector endConnector = null;
                    foreach (Connector con in item.list[0].ConnectorManager.Connectors)
                    {
                        if (con.Id == 1)
                        {
                            startConnector = con;
                        }
                    }
                    foreach (Connector con in item.list[2].ConnectorManager.Connectors)
                    {
                        if (con.Id == 0)
                        {
                            endConnector = con;
                        }
                    }
                    foreach (Connector con in item.list[1].ConnectorManager.Connectors)
                    {
                        if (con.Id == 0)
                        {
                            startConnector.ConnectTo(con);
                        }
                        if (con.Id == 1)
                        {
                            endConnector.ConnectTo(con);
                        }
                    }
                }
                RayMovement.SelectLinkPost(doc, int.Parse(inputInterval), mEPCurves);
                tran.Commit();
            }
        }

        public string GetName()
        {
            return "";
        }
    }
}
