using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI.Selection;

//根据板块类型自动出图

namespace CEGShopTicketHelper
{
    [Transaction(TransactionMode.Manual)]
    public class AutoTicketingHelperCmd : IExternalCommand
    {
        public string settingFileName = "CEGTicketHelperSetting.txt";
        public string settingFileDir = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);//桌面
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //if (!CEGToolsHelper.Utils.CheckReg())
            //{
            //    return Result.Cancelled;
            //}

            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;

            Reference reference = sel.PickObject(ObjectType.Element);
            AssemblyInstance assembly = doc.GetElement(reference) as AssemblyInstance;

            //AutoTicketingHelper.PrecastCategory cegCategory = Utils.CheckCEGCategory(assembly.);
            AutoTicketingHelper.PCaTicketingHelper helper = null;

            helper = new AutoTicketingHelper.DtTicketingHelper(assembly);
            //helper = new AutoTicketingHelper.SpandrelTicketingHelper(assembly);
            helper.CreateAssemblyView();
            helper.TicketingView();


            return Result.Succeeded;
        }
    }
}
