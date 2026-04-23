using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI.Selection;

namespace CEGShopTicketHelper
{
    [Transaction(TransactionMode.Manual)]
    public class RebarSketchCmd : IExternalCommand
    {
        string tagTypeName = "No Leaders";
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            if (!CEGToolsHelper.Utils.CheckReg())
            {
                return Result.Cancelled;
            }

            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;

            FilteredElementCollector col = new FilteredElementCollector(doc, doc.ActiveView.Id);
            List<Element> elems = col.OfCategory(BuiltInCategory.OST_SpecialityEquipment)
                .OfClass(typeof(FamilyInstance)).ToElements().ToList();

            List<string> rebarType = new List<string>();

            using (Transaction trans = new Transaction(doc, "tag"))
            {
                trans.Start();
                foreach (var e in elems)
                {
                    string barFamilyName = (e as FamilyInstance).Symbol.FamilyName;
                    if (barFamilyName != "V-BAR" && barFamilyName != "L-BAR(Corner Pin)"
                        && barFamilyName != "U-BAR" && barFamilyName != "T2-04"
                        && barFamilyName != "11-04") { continue; }

                    string barSymbolName = (e as FamilyInstance).Symbol.Name;
                    string barLength = Utils.GetParameterDoubleByName(e, "DIM_LENGTH").ToString();
                    if (rebarType.Contains(barFamilyName + barSymbolName + barLength)) { continue; }

                    string tagFamilyName = "";
                    
                    switch (barFamilyName)
                    {
                        case "V-BAR":
                            tagFamilyName = "REBAR_SKETCH(V-BAR)(LIVE)";
                            break;
                        case "L-BAR(Corner Pin)":
                            tagFamilyName = "REBAR_SKETCH(L-BAR)(LIVE)";
                            break;
                        case "U-BAR":
                            tagFamilyName = "REBAR_SKETCH(U-BAR)(LIVE)";
                            break;
                        case "T2-04":
                            tagFamilyName = "REBAR_SKETCH(T2)(LIVE)";
                            break;
                        case "11-04":
                            tagFamilyName = "REBAR_SKETCH(11)(LIVE)";
                            break;
                    }
                    if (!string.IsNullOrEmpty(tagFamilyName))
                    {
                        FamilySymbol fs = Utils.GetFamilySymbol(doc, tagFamilyName, tagTypeName);
                        if (fs == null)
                        {
                            TaskDialog.Show("r", "Can not find " + tagFamilyName + ":" + tagTypeName + " in the project!");
                        }
                        //create tag
                        IndependentTag tag = IndependentTag.Create(doc,
                            doc.ActiveView.Id,
                            new Reference(e),
                            true,
                            TagMode.TM_ADDBY_CATEGORY,
                            TagOrientation.Horizontal,
                            (e.Location as LocationPoint).Point);
                        tag.ChangeTypeId(fs.Id);
                        rebarType.Add(barFamilyName + barSymbolName + barLength);
                    }
                }
                trans.Commit();
            }

            return Result.Succeeded;
        }
    }
}
