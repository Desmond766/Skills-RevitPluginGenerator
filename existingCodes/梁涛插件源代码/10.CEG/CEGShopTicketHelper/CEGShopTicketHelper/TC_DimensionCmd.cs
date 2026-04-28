using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;

namespace CEGShopTicketHelper
{
    [Transaction(TransactionMode.Manual)]
    public class TC_DimensionCmd : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            if (!CEGToolsHelper.Utils.CheckReg())
            {
                return Result.Cancelled;
            }

            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Selection sel = uiapp.ActiveUIDocument.Selection;

            //选择dimension
            //多选
            IList<Reference> allRef = sel.PickObjects(ObjectType.Element, new DimensionFilter(), "Select Dimension");
            List<Element> list = new List<Element>();
            foreach (Reference item in allRef)
            {
                list.Add(doc.GetElement(item));
            }

            if (list.Count() == 0)
            {
                return Result.Cancelled;
            }
            //TaskDialog.Show("a", list.Count.ToString());

            //用来收集出错的Dimension
            List<ElementId> ids = new List<ElementId>();

            foreach (Element item in list)
            {
                Double tL = 0.0;
                Double sL = 0.0;
                double tL1 = 0.0;

                //获取Dimension的总长
                Parameter totalL = item.get_Parameter(BuiltInParameter.DIM_TOTAL_LENGTH);
                tL = totalL.AsDouble();

                Dimension dimension = item as Dimension;
                if (dimension.Value == null)
                {
                    DimensionSegmentArray dsa = dimension.Segments;
                    if (dsa != null)
                    {
                        foreach (DimensionSegment ds in dsa)
                        {

                            string s = ds.ValueString;
                            string pre = ds.Prefix;
                            string suf = ds.Suffix;

                            if (!string.IsNullOrEmpty(pre))
                            {
                                s = s.Substring(pre.Length + 1, s.Length - pre.Length - 1);

                            }
                            if (!string.IsNullOrEmpty(suf))
                            {
                                s = s.Substring(0, s.Length - suf.Length - 1);

                            }
                            //TaskDialog.Show("a", s);

                            sL = Utils.ConvertFeet(s);
                            tL1 = tL1 + sL;

                        }

                        //TaskDialog.Show("a", tL.ToString() + "\n" + tL1.ToString() + "\n" + Math.Abs(tL - tL1).ToString());
                        if (Math.Abs(tL - tL1) >= 0.005)//比较
                        {
                            ids.Add(item.Id);
                        }
                    }
                    //else
                    //{
                    //    tL1 = tL;
                    //}
                }


            }
            if (ids.Count > 0)
            {
                using (Transaction t = new Transaction(doc, "TicketChecker-Dimension"))
                {
                    t.Start();
                    foreach (ElementId dimenId in ids)
                    {
                        //override 成红色
                        OverrideGraphicSettings overrideGraphicSettings = new OverrideGraphicSettings();
                        overrideGraphicSettings = doc.ActiveView.GetElementOverrides(dimenId);

                        overrideGraphicSettings.SetProjectionLineColor(new Autodesk.Revit.DB.Color(255, 0, 0));
                        doc.ActiveView.SetElementOverrides(dimenId, overrideGraphicSettings);
                        doc.Regenerate();
                    }

                    t.Commit();
                }
            }
            TaskDialog.Show("CEG-China Ticket checker", "Found Dimension error:" + ids.Count().ToString());

            return Result.Succeeded;
        }
    }

    internal class DimensionFilter : ISelectionFilter
    {
        public bool AllowElement(Element elem)
        {
            if (elem.Category.Id.IntegerValue == (int)BuiltInCategory.OST_Dimensions)
            {
                return true;
            }

            return false;
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            return false;
        }
    }

}
