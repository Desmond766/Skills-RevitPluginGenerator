using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicModelUpdate
{
    [Transaction(TransactionMode.Manual)]
    public class UpdaterSwitchCommand : IExternalCommand
    {
       
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            MyUpdater myUpdater = new MyUpdater(commandData.Application.ActiveAddInId);
            if (UpdaterRegistry.IsUpdaterRegistered(myUpdater.GetUpdaterId()))
            {
                if (UpdaterRegistry.IsUpdaterEnabled(myUpdater.GetUpdaterId()))
                {
                    UpdaterRegistry.DisableUpdater(myUpdater.GetUpdaterId());
                }
                else
                {
                    UpdaterRegistry.EnableUpdater(myUpdater.GetUpdaterId());
                }
            }
            return Result.Succeeded;
        }
    }
}
