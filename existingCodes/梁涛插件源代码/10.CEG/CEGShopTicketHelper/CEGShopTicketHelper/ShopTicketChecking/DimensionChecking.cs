using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace CEGShopTicketHelper.ShopTicketChecking
{
    [Transaction(TransactionMode.Manual)]
    public class DimensionChecking : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;

            //if (!CEGToolsHelper.Utils.CheckReg())
            //{
            //    return Result.Cancelled;
            //}

            //show setting frm
            DimensionCheckingSettingFrm frm = new DimensionCheckingSettingFrm();
            if (frm.ShowDialog() != DialogResult.OK)
            {
                return Result.Cancelled;
            }
            string titleContain = frm._titleContain;

            //init views per user setting
            List<Autodesk.Revit.DB.View> views = new List<Autodesk.Revit.DB.View>();
            if (string.IsNullOrEmpty(titleContain))//check active mode
            {
                if (!(doc.ActiveView is ViewSheet))
                {
                    message = "please run in a sheet view";
                    return Result.Cancelled;
                }
                views = GetAllViewInSheet(doc, doc.ActiveView as ViewSheet);
            }
            else//check title contian
            {
                List <Autodesk.Revit.DB.View> allViews = new FilteredElementCollector(doc)
                    .OfClass(typeof(Autodesk.Revit.DB.View))
                    .OfType<Autodesk.Revit.DB.View>()
                    .Where(u => !u.IsTemplate)
                    .Where(u => !u.IsTemplate)
                    .ToList();
                foreach (var item in allViews)
                {
                    string titleOnSheet = item.get_Parameter(BuiltInParameter.VIEW_DESCRIPTION).AsString();
                    string viewTitle = string.IsNullOrEmpty(titleOnSheet) ? item.Name : titleOnSheet;
                    if (viewTitle.Contains(titleContain))
                    {
                        views.Add(item);
                    }
                }
            }

            //result datatable
            DataTable dt = new DataTable();
            DataColumn dc1 = new DataColumn();
            dc1.ColumnName = "Assembly/Sheet";
            dt.Columns.Add(dc1);
            DataColumn dc2 = new DataColumn();
            dc2.ColumnName = "ViewTitle";
            dt.Columns.Add(dc2);
            DataColumn dc3 = new DataColumn();
            dc3.ColumnName = "Dimension";
            dt.Columns.Add(dc3);
            DataColumn dc4 = new DataColumn();
            dc4.ColumnName = "Warnning";
            dt.Columns.Add(dc4);

            Dictionary<int, Autodesk.Revit.DB.View> dict = new Dictionary<int, Autodesk.Revit.DB.View>();
            foreach (Autodesk.Revit.DB.View v in views)
            {
                //Assembly/Sheet
                string assemblyName = v.IsAssemblyView ?
                    doc.GetElement(v.AssociatedAssemblyInstanceId).Name
                    : v.get_Parameter(BuiltInParameter.VIEWER_SHEET_NUMBER).AsValueString();

                //ViewTitle
                string titleOnSheet = v.get_Parameter(BuiltInParameter.VIEW_DESCRIPTION).AsString();
                string viewTitle = string.IsNullOrEmpty(titleOnSheet) ? v.Name : titleOnSheet;

                List<Element> viewElements = new FilteredElementCollector(doc, v.Id)
                    .ToElements().ToList();
                foreach (Element e in viewElements)
                {
                    if (e is Dimension && !e.IsHidden(v))
                    {
                        Dimension dim = (Dimension)e;
                        bool flag1 = ValueOverrideCheck(dim);
                        if (!flag1)
                        {
                            DataRow dr = dt.NewRow();
                            dt.Rows.Add(dr);
                            dr[0] = assemblyName;
                            dr[1] = viewTitle;
                            dr[2] = GetDimStr(dim);
                            dr[3] = DimensionError.ValueOverrideError.ToString();
                            if (!dict.ContainsKey(e.Id.IntegerValue))
                            {
                                dict.Add(dim.Id.IntegerValue, dim.View);
                            }
                        }
                        bool flag2 = SumUpCheck(dim);
                        if (!flag2)
                        {
                            DataRow dr = dt.NewRow();
                            dt.Rows.Add(dr);
                            dr[0] = assemblyName;
                            dr[1] = viewTitle;
                            dr[2] = GetDimStr(dim);
                            dr[3] = DimensionError.SumUpError.ToString();
                            if (!dict.ContainsKey(e.Id.IntegerValue))
                            {
                                dict.Add(dim.Id.IntegerValue, dim.View);
                            }
                        }
                        DimensionError errorType = DimensionError.Null;
                        bool flag3 = SpacingFomulaCheck(dim, ref errorType);
                        if (!flag3)
                        {
                            DataRow dr = dt.NewRow();
                            dt.Rows.Add(dr);
                            dr[0] = assemblyName;
                            dr[1] = viewTitle;
                            dr[2] = GetDimStr(dim);
                            dr[3] = errorType.ToString();
                            if (!dict.ContainsKey(e.Id.IntegerValue))
                            {
                                dict.Add(dim.Id.IntegerValue, dim.View);
                            }
                        }
                        //bool flag4 = ReferencesCheck(dim);
                        //if (!flag4)
                        //{
                        //    DataRow dr = dt.NewRow();
                        //    dt.Rows.Add(dr);
                        //    dr[0] = assemblyName;
                        //    dr[1] = viewTitle;
                        //    dr[2] = GetDimStr(dim);
                        //    dr[3] = DimensionError.VariesReferencesError.ToString();
                        //    if (!dict.ContainsKey(e.Id.IntegerValue))
                        //    {
                        //        dict.Add(dim.Id.IntegerValue, dim.View);
                        //    }
                        //}
                    }
                }
            }

            //sort
            dt.DefaultView.Sort = "Assembly/Sheet ASC";

            ////override红色
            //if (dict.Count > 0)
            //{
            //    using (Transaction t = new Transaction(doc, "DimensionChecking"))
            //    {
            //        t.Start();
            //        foreach (int key in dict.Keys)
            //        {
            //            ElementId id = new ElementId(key);
            //            Autodesk.Revit.DB.View v = dict[key];
            //            OverrideGraphicSettings overrideGraphicSettings = v.GetElementOverrides(id);
            //            overrideGraphicSettings.SetProjectionLineColor(new Color(255, 0, 0));
            //            v.SetElementOverrides(id, overrideGraphicSettings);
            //            //doc.Regenerate();
            //        }
            //        t.Commit();
            //    }
            //}

            DimensionCheckingFrm resultFrm = new DimensionCheckingFrm(dt);
            //if (DialogResult.OK != frm.ShowDialog())
            //{
            //    return Result.Cancelled;
            //}
            resultFrm.Show();

            //Dimension dim = doc.GetElement(sel.PickObject(ObjectType.Element)) as Dimension;
            //ReferencesCheck(dim);

            return Result.Succeeded;
        }

        private List<Autodesk.Revit.DB.View> GetAllViewInSheet(Document doc, ViewSheet vs)
        {
            List<Element> ticketElements = new FilteredElementCollector(doc, vs.Id)
                .ToElements().ToList();

            List<Autodesk.Revit.DB.View> views = new List<Autodesk.Revit.DB.View>();
            foreach (Element e in ticketElements)
            {
                if (!(e is Viewport)) { continue; }
                Viewport port = e as Viewport;
                Autodesk.Revit.DB.View view = doc.GetElement(port.ViewId) as Autodesk.Revit.DB.View;
                //视图
                if (view.ViewType == ViewType.Detail 
                    || view.ViewType == ViewType.FloorPlan 
                    || view.ViewType == ViewType.Elevation
                    || view.ViewType == ViewType.Section)
                {
                    views.Add(view);
                }
            }

            return views;
        }

        private string GetDimStr(Dimension dim)
        {
            string dimStr = string.Empty;
            if (dim.Segments.Size == 0)
            {
                dimStr += dim.ValueString;
            }
            else
            {
                foreach (DimensionSegment seg in dim.Segments)
                {
                    dimStr += seg.ValueString + ";";
                }
            }
            return dimStr;
        }
        private bool ValueOverrideCheck(Dimension dim)
        {
            string LRMcode = "\u200e";
            if (dim.Segments.Size == 0)
            {
                if (!string.IsNullOrEmpty(dim.ValueOverride))
                {
                    return !dim.ValueOverride.Contains(LRMcode);
                }
            }
            else
            {
                foreach (DimensionSegment seg in dim.Segments) 
                {
                    if (!string.IsNullOrEmpty(seg.ValueOverride))
                    {
                        if(seg.ValueOverride.Contains(LRMcode))
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        private bool SumUpCheck(Dimension dim)
        {
            Document doc = dim.Document;
            if (dim.Segments.Size == 0) return true;
            double totalLength = dim.get_Parameter(BuiltInParameter.DIM_TOTAL_LENGTH).AsDouble();
            double sumUplength = 0.0;
            foreach (DimensionSegment seg in dim.Segments)
            {
                string vStr = GetVauleString(seg);
                double segLength = 0.0;
                if (doc.DisplayUnitSystem == DisplayUnit.IMPERIAL)//only ftin
                {
                    segLength = Utils.ConvertFeet2(vStr);
                }
                if (doc.DisplayUnitSystem == DisplayUnit.METRIC)//only mm
                {
                    segLength = double.Parse(vStr)/304.8;
                }
                sumUplength += segLength;
            }
            return Math.Abs(totalLength - sumUplength) < 0.003;
        }
        private bool SpacingFomulaCheck(Dimension dim, ref DimensionError errorType)
        {
            Document doc = dim.Document;
            string pattern = @"\(\d+\)@.*?";//(A)@B //.*?为任意字符
            Regex regex = new Regex(pattern);

            if (dim.Segments.Size == 0)
            {
                if (!string.IsNullOrEmpty(dim.Prefix) && regex.Match(dim.Prefix).Success)
                {
                    if (!dim.Prefix.Contains("="))
                    {
                        errorType = DimensionError.EqualSymbolError;
                        return false;
                    }
                    return SegmentSpacingFomula(doc,
                        dim.Prefix.Replace("=", ""), GetVauleString(dim), ref errorType);
                }
                if (!string.IsNullOrEmpty(dim.Below) && regex.Match(dim.Below).Success)
                {
                    if (dim.Below.Contains("="))
                    {
                        errorType = DimensionError.EqualSymbolError;
                        return false;
                    }
                    return SegmentSpacingFomula(doc,
                        dim.Below.Replace("=", ""), GetVauleString(dim), ref errorType);
                }
            }
            else
            {
                foreach (DimensionSegment seg in dim.Segments)
                {
                    if (!string.IsNullOrEmpty(seg.Prefix) && regex.Match(seg.Prefix).Success)
                    {
                        if (!seg.Prefix.Contains("="))
                        {
                            errorType = DimensionError.EqualSymbolError;
                            return false;
                        }
                        return SegmentSpacingFomula(doc,
                            seg.Prefix.Replace("=", ""), GetVauleString(seg), ref errorType);
                    }
                    if (!string.IsNullOrEmpty(seg.Below) && regex.Match(seg.Below).Success)
                    {
                        if (seg.Below.Contains("="))
                        {
                            errorType = DimensionError.EqualSymbolError;
                            return false;
                        }
                        return SegmentSpacingFomula(doc, 
                            seg.Below.Replace("=", ""), GetVauleString(seg), ref errorType);
                    }
                }
            }
            return true;
        }
        private bool SegmentSpacingFomula(Document doc,
            string fomulaStr, string vauleStr, ref DimensionError errorType)
        {
            double totalLength = 0.0;
            if (doc.DisplayUnitSystem == DisplayUnit.IMPERIAL)
            {
                totalLength = Utils.ConvertFeet2(vauleStr);
                if (totalLength == -1.0)
                {
                    errorType = DimensionError.FeetInchError;
                    return false;
                }
            }
            if (doc.DisplayUnitSystem == DisplayUnit.METRIC)
            {
                totalLength = double.Parse(vauleStr)/304.8;
            }

            fomulaStr = fomulaStr.Trim();
            double spacingLength = 0.0;

            string pattern = @"\(\d+\)@.*?";//(A)@B //.*?为任意字符
            Regex regex = new Regex(pattern);
            if (regex.Match(fomulaStr).Success)
            {
                string numStr = fomulaStr.Split('@')[0].Replace("(", "").Replace(")", "");
                int num = int.Parse(numStr);
                string spacingStr = fomulaStr.Split('@')[1].Trim();
                if (doc.DisplayUnitSystem == DisplayUnit.IMPERIAL)
                {
                    spacingLength = Utils.ConvertFeet2(spacingStr);
                    if (spacingLength == -1.0)
                    {
                        errorType = DimensionError.FeetInchError;
                        return false;
                    }
                }
                if (doc.DisplayUnitSystem == DisplayUnit.METRIC)
                {
                    spacingLength = double.Parse(spacingStr) / 304.8;
                }
                if (Math.Abs(num * spacingLength - totalLength) > 0.003)
                {
                    errorType = DimensionError.SpacingFormulaError;
                    return false;
                }
            }
            else
            {
                errorType = DimensionError.SpacingFormulaError;
                return false;
            }
            return true;
        }
        private string GetVauleString(Dimension dim)
        {
            string vStr = dim.ValueString;
            if (!string.IsNullOrEmpty(dim.Prefix))
            {
                vStr = vStr.Replace(dim.Prefix, "");
            }
            if (!string.IsNullOrEmpty(dim.Suffix))
            {
                vStr = vStr.Replace(dim.Suffix, "");
            }
            return vStr.Trim();
        }
        private string GetVauleString(DimensionSegment seg)
        {
            string vStr = seg.ValueString;
            if (!string.IsNullOrEmpty(seg.Prefix))
            {
                vStr = vStr.Replace(seg.Prefix, "");
            }
            if (!string.IsNullOrEmpty(seg.Suffix))
            {
                vStr = vStr.Replace(seg.Suffix, "");
            }
            return vStr.Trim();
        }
        private bool ReferencesCheck(Dimension dim)
        {
            Document doc = dim.Document;
            if (dim.References == null) { return true; }
            if (dim.References.Size <= 3) { return true; }
            string firstName = doc.GetElement(dim.References.get_Item(1)).Name;
            for (int i = 1; i < dim.References.Size - 1; i++)
            {
                //不比较第一个和最后一个
                string name = doc.GetElement(dim.References.get_Item(i)).Name;
                if (name != firstName)
                {
                    return false;
                }
            }
            return true;
        }
    }

    public enum DimensionError
    {
        Null = 0,
        ValueOverrideError = 1,//添加了LRM符号，用于尺寸替换
        SumUpError = 2,//分段相加不等于总长，斜板的时候
        FeetInchError = 3,//手填的英尺英尺错误，如1'-6'
        EqualSymbolError = 4,//等号错误,多填或少填
        SpacingFormulaError = 5,//间距公式错误，如(12)@1'- 0"=13'-0"
        VariesReferencesError = 6,//标注到不同的埋件
        SpellError = 7,//拼写错误
    }

}
