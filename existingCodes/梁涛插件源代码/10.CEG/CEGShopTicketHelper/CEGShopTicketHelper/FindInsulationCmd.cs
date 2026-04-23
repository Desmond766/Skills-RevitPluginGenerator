using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI.Selection;
using System.Windows.Forms;

//use to find the views which contain this insulation
namespace CEGShopTicketHelper
{
    [Transaction(TransactionMode.Manual)]
    public class FindInsulationCmd : IExternalCommand
    {
        string InsulationFamilyName = "CEG - INSULATION -";
        string controlMarkParam = "CONTROL_MARK";
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            if (!CEGToolsHelper.Utils.CheckReg())
            {
                return Result.Cancelled;
            }

            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;

            FindInsulationFrm frm = new FindInsulationFrm();
            if (DialogResult.OK != frm.ShowDialog())
            {
                return Result.Cancelled;
            }
            string controlMark = frm.controlMark;

            //collect insulation in document by controlMark
            List<string> resultList = new List<string>();
            FilteredElementCollector collector = new FilteredElementCollector(doc);

            List<FamilyInstance> insulationList = 
                collector.OfClass(typeof(FamilyInstance))
                .OfCategory(BuiltInCategory.OST_DetailComponents)
                .Cast<FamilyInstance>()
                .Where(u => u.Symbol.FamilyName.StartsWith(InsulationFamilyName))
                .ToList();

            foreach (FamilyInstance fi in insulationList)
            {
                if (controlMark == Utils.GetParameterByName(fi, controlMarkParam))
                {
                    ElementId id = fi.OwnerViewId;
                    if (null != id)
                    {
                        Autodesk.Revit.DB.View v = doc.GetElement(id) as Autodesk.Revit.DB.View;
                        if (null != v) 
                        {
                            ElementId aId = v.AssociatedAssemblyInstanceId;
                            if (null != aId)
                            {
                                resultList.Add(doc.GetElement(aId).Name);
                            }
                        }
                    }
                }
            }
            resultList = resultList.Distinct().ToList();
            resultList.Sort(new StringComparer(true));

            if (resultList.Count == 0)
            {
                message = "couldn't find any Insulation " + controlMark + " in this job";
                return Result.Cancelled;
            }

            //at least one
            System.Windows.Forms.MessageBox.Show(
                "Insulation " + controlMark + " is used to assembly below:\n"
                + string.Join("\n", resultList.ToArray())
                , "CEG Find Insulation");

            return Result.Succeeded;
        }
    }
}
