using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.Exceptions;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OperationCanceledException = Autodesk.Revit.Exceptions.OperationCanceledException;

namespace HangerUpdate
{
    [Transaction(TransactionMode.Manual)]
    public abstract class RevitCommand : IExternalCommand
    {
        public abstract void Action();
        public UIDocument Uidoc { get; set; }
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            
            try
            {
                Uidoc = commandData.Application.ActiveUIDocument;
                Action();

                return Result.Succeeded;
            }
            catch(OperationCanceledException ocex)
            {
                TaskDialog.Show("Revit", "已完成");
                return Result.Succeeded;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return Result.Failed;
            }
        }
    }
}
