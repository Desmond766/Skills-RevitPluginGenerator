using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CEGShopTicketHelper
{
    [Transaction(TransactionMode.Manual)]
    public class RebarMarkCmd : IExternalCommand
    {
        string scope = "Document";
        string prefix = "BarDiameter";
        string paramNameRead = "DIM_LENGTH";
        string paramNameWrite = "CONTROL_MARK";
        string idStr = string.Empty;
        double dimLength = 0.0;
        string dimLengthResult = string.Empty;
        string barDiameterStr = string.Empty;
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            if (!CEGToolsHelper.Utils.CheckReg())
            {
                return Result.Cancelled;
            }

            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;

            RebarMarkFrm frm = new RebarMarkFrm();
            if (DialogResult.OK != frm.ShowDialog())
            {
                return Result.Cancelled;
            }
            scope = frm._scope;
            prefix = frm._prefix;
            paramNameWrite = frm._paramName;

            FilteredElementCollector collector = null;
            if (scope == "Selected")
            {
                collector = new FilteredElementCollector(doc, sel.GetElementIds());
            }
            if (scope == "ActiveView")
            {
                collector = new FilteredElementCollector(doc, doc.ActiveView.Id);
            }
            if (scope == "Document")
            {
                collector = new FilteredElementCollector(doc);
            }

            List<FamilyInstance> fInstList
                = collector.OfClass(typeof(FamilyInstance))
                .OfCategory(BuiltInCategory.OST_SpecialityEquipment).
                Cast<FamilyInstance>().ToList();

            string ftStr;
            string inStr;
            using (Transaction trans = new Transaction(doc, "RebarMark"))
            {
                trans.Start();
                foreach (FamilyInstance fi in fInstList)
                {
                    if (fi.GroupId != ElementId.InvalidElementId) { continue; }//组内钢筋排除
                    idStr = Utils.GetParameterByName(fi.Symbol, "IDENTITY_DESCRIPTION");
                    if (idStr == null) { continue; }
                    if (!idStr.Contains("BAR")) { continue; }

                    //转换英尺英寸
                    dimLength = Utils.GetParameterDoubleByName(fi, paramNameRead);
                    double feet = Math.Truncate(dimLength);//整数部分
                    double inch = Math.Round((dimLength - feet) * 12.0);
                    if (inch == 12.0)
                    {
                        feet += 1;
                        inch = 0.0;
                    }
                    ftStr = feet.ToString().PadLeft(2, '0');
                    inStr = inch.ToString().PadLeft(2, '0');

                    //加前缀
                    if (prefix == "BarDiameter")
                    {
                        barDiameterStr = Utils.GetParameterByName(fi.Symbol, "BAR_DIAMETER");
                        string newPrefix = string.Empty;
                        switch (barDiameterStr)
                        {
                            case "0' - 0 3/8\"":
                                newPrefix = "3";
                                break;
                            case "0' - 0 1/2\"":
                                newPrefix = "4";
                                break;
                            case "0' - 0 5/8\"":
                                newPrefix = "5";
                                break;
                            case "0' - 0 3/4\"":
                                newPrefix = "6";
                                break;
                            case "0' - 0 7/8\"":
                                newPrefix = "7";
                                break;
                            case "0' - 1\"":
                                newPrefix = "8";
                                break;
                            case "0' - 1 1/8\"":
                                newPrefix = "9";
                                break;
                            case "0' - 1 1/4\"":
                                newPrefix = "10";
                                break;
                            case "0' - 1 3/8\"":
                                newPrefix = "11";
                                break;
                        }
                        dimLengthResult = newPrefix + ftStr + inStr;
                    }
                    else if (prefix == "NonePre")
                    {
                        dimLengthResult = ftStr + inStr;
                    }
                    else
                    {
                        dimLengthResult = prefix + ftStr + inStr;
                    }

                    //写参数
                    if (paramNameWrite == "Comments")
                    {

                        fi.get_Parameter(BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS)
                            .Set(dimLengthResult);
                    }
                    else
                    {
                        var pList = fi.GetParameters(paramNameWrite);
                        if (pList.Count > 0)
                        {
                            if (!pList.First().IsReadOnly)
                            {
                                pList.First().Set(dimLengthResult);
                            }
                        }
                    }
                }
                trans.Commit();
            }

            return Result.Succeeded;
        }
    }
}
