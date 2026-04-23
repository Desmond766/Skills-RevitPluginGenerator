using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEGShopTicketHelper.AutoTicketingHelper
{
    public class DtTicketingHelper : PCaTicketingHelper
    {
        public string topViewName = "TOP VIEW IN FORM";
        //public string topViewTemplateName = "TICKET-3/16(DT TOP)";
        public string topViewTemplateName = "TICKET- DT-3/16\" TOP";
        public XYZ topViewLocation = new XYZ(0.5, 0.6, 0);

        public string elevationViewName = "ELEVATION VIEW";
        //public string elevationViewTemplateName = "TICKET-3/16(DT TOP)";
        public string elevationViewTemplateName = "TICKET- DT-3/16\" ELE";
        public XYZ elevationViewLocation = new XYZ(0.5, 0.4, 0);  
        
        public DtTicketingHelper(AssemblyInstance assembly) : base(assembly)
        {
            
        }

        public override void CreateAssemblyView()
        {
            using (Transaction trans = new Transaction(Doc, "CEG.CreateAssemblyView"))
            {
                trans.Start();
                CreateAssemblySheet();
                Create3DView();
                TopView = CreateAssemblyView(
                    AssemblyDetailViewOrientation.ElevationTop,
                    topViewName,
                    topViewTemplateName,
                    topViewLocation);
                FrontView = CreateAssemblyView(
                    AssemblyDetailViewOrientation.ElevationFront,
                    elevationViewName,
                    elevationViewTemplateName,
                    elevationViewLocation);
                trans.Commit();
            }
        }

        public override void TicketingView()
        {
            //TOP VIEW
            ViewAnnotatingHelper helper = new ViewAnnotatingHelper(Assembly, TopView);
            using (Transaction trans = new Transaction(Doc, "CEG.TopViewAnnotating"))
            {
                ////失败处理
                //FailureHandlingOptions failureHandlingOptions = trans.GetFailureHandlingOptions();
                //FailureHandler failureHandler = new FailureHandler();
                //failureHandlingOptions.SetFailuresPreprocessor(failureHandler);
                //// 这句话是关键
                //failureHandlingOptions.SetClearAfterRollback(true);
                //trans.SetFailureHandlingOptions(failureHandlingOptions);

                trans.Start();
                helper.AddSideEndText();
                helper.OverallSideDim();
                helper.OverallEndDim();
                helper.EndDim();
                helper.SideDim();
                //Utils.CreateModelLine(Doc, helper.PtLeftUpCorner, helper.PtRightDownCorner);
                //Utils.CreateModelLine(Doc, helper.PtLeftDownCorner, helper.PtRightUpCorner);
                trans.Commit();
            }
        }

    }
}
