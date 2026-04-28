using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEGShopTicketHelper.AutoTicketingHelper
{
    public class SpandrelTicketingHelper : PCaTicketingHelper
    {
        public string topViewName = "TOP VIEW IN FORM";
        public string topViewTemplateName = "TICKET - 1/4\" SP PLAN";
        public XYZ topViewLocation = new XYZ(0.4, 0.6, 0);

        public string reinforcingViewName = "REINFORCING VIEW";
        public string reinforcingViewTemplateName = "TICKET-1/4\" REINFOCING(LEGACY)";
        public XYZ reinforcingViewLocation = new XYZ(0.4, 0.2, 0);

        public SpandrelTicketingHelper(AssemblyInstance assembly) : base(assembly)
        {

        }

        public override void CreateAssemblyView()
        {
            using (Transaction trans = new Transaction(Doc, "CEG.CreateAssemblyView"))
            {
                trans.Start();
                CreateAssemblySheet();
                //Create3DView();
                TopView = CreateAssemblyView(
                    AssemblyDetailViewOrientation.ElevationTop,
                    topViewName,
                    topViewTemplateName,
                    topViewLocation);
                //View reinforcingView = CreateAssemblyView(
                //    AssemblyDetailViewOrientation.ElevationTop,
                //    reinforcingViewName,
                //    reinforcingViewTemplateName,
                //    reinforcingViewLocation);
                trans.Commit();
            }
        }

        public override void TicketingView()
        {
            ViewAnnotatingHelper helper = new ViewAnnotatingHelper(Assembly, TopView);
            using (Transaction trans = new Transaction(Doc, "CEG.TopViewAnnotating"))
            {
                trans.Start();
                helper.AddSideEndText();
                helper.OverallSideDim();
                helper.OverallEndDim();
                helper.EndDim();
                helper.SideDim();
                helper.TopDim();
                trans.Commit();
            }
        }
    }
}
