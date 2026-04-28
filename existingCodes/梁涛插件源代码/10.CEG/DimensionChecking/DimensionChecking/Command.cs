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
using static Autodesk.Revit.DB.SpecTypeId;
using View = Autodesk.Revit.DB.View;

namespace DimensionChecking
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uIDocument = uiapp.ActiveUIDocument;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;

            if (!(doc.ActiveView is ViewSheet))
            {
                message = "please run in a sheet view";
                return Result.Cancelled;
            }
            string assemblyName = doc.GetElement(doc.ActiveView.AssociatedAssemblyInstanceId).Name;
            List<Autodesk.Revit.DB.View> views = GetAllViewInSheet(doc, doc.ActiveView as ViewSheet);

            DataTable dt = new DataTable();
            DataColumn dc1 = new DataColumn();
            dc1.ColumnName = "ViewName";
            dt.Columns.Add(dc1);
            DataColumn dc2 = new DataColumn();
            dc2.ColumnName = "Dimension";
            dt.Columns.Add(dc2);
            DataColumn dc3 = new DataColumn();
            dc3.ColumnName = "Warnning";
            dt.Columns.Add(dc3);


            //Dictionary<View,List<ElementId>> idGroup = new Dictionary<View,List<ElementId>>();
            //Dictionary<View, ElementId> idGroup = new Dictionary<View, ElementId>();
            List<DimensionInfo> idGroup = new List<DimensionInfo>();
            foreach (Autodesk.Revit.DB.View v in views)
            {
                List<Element> viewElements = new FilteredElementCollector(doc, v.Id)
                    .ToElements().ToList();
                List<Element> visibleDimensions = new List<Element>();

                // 遍历每个尺寸标注，检查其是否在当前视图中可见
                foreach (var dimension in viewElements)
                {
                    if (IsElementVisibleInView(doc, v, dimension))
                    {
                        visibleDimensions.Add(dimension);
                    }
                }
                //if (v.Name == "SECTION-E")
                //    v.UnhideElements(visibleDimensions.Select(x => x.Id).ToList());
                //List<ElementId> ids = new List<ElementId>();
                foreach (Element e in visibleDimensions)
                {
                    if (e is Dimension)
                    {
                        Dimension dim = (Dimension)e;
                        //if (dim.View.Name == "SECTION-E")
                        //{
                        //    //List<Element> elements1 = visibleDimensions.Where(x => x is Dimension).ToList();
                        //    //TaskDialog.Show("ll", elements1.Count.ToString());
                        //    //TaskDialog.Show("ll", dim.Id.ToString());
                        //    if (dim.CanBeHidden(v) == true)
                        //    {

                        //        if (dim.IsHidden(v) == false)
                        //        {
                        //            TaskDialog.Show("ll", dim.Id.ToString());
                        //        }
                        //    }
                        //}
                        bool flag1 = ValueOverrideCheck(dim);
                        if (!flag1)
                        {
                            DimensionInfo dimensionInfo = new DimensionInfo() { ActiveView = v ,dimId = dim.Id};
                            idGroup.Add(dimensionInfo);
                            DataRow dr = dt.NewRow();
                            dt.Rows.Add(dr);
                            dr[0] = dim.View.Name;
                            dr[1] = GetDimStr(dim);
                            dr[2] = DimensionError.ValueOverrideError.ToString();
                        }
                        DimensionError dimensionError = new DimensionError();
                        bool flag2 = SumUpCheck2(dim, ref dimensionError);
                        if (!flag2)
                        {
                            //TaskDialog.Show("tip", ((dim.Segments.get_Item(1).Value * 304.8) + dim.Segments.get_Item(0).Value * 304.8).ToString());
                            DimensionInfo dimensionInfo = new DimensionInfo() { ActiveView = v, dimId = dim.Id };
                            idGroup.Add(dimensionInfo);
                            DataRow dr = dt.NewRow();
                            dt.Rows.Add(dr);
                            dr[0] = dim.View.Name;
                            dr[1] = GetDimStr(dim);
                            //dr[2] = DimensionError.SumUpError.ToString();
                            dr[2] = dimensionError.ToString();
                        }
                    }
                }
            }

            using (Transaction t = new Transaction(doc, "TicketChecker-Dimension"))
            {
                t.Start();
                foreach (var info in idGroup)
                {
                    ElementId dimenId = info.dimId;
                    View view = info.ActiveView;
                    //override 成红色
                    OverrideGraphicSettings overrideGraphicSettings = new OverrideGraphicSettings();
                    overrideGraphicSettings = view.GetElementOverrides(dimenId);

                    overrideGraphicSettings.SetProjectionLineColor(new Autodesk.Revit.DB.Color(255, 0, 0));
                    view.SetElementOverrides(dimenId, overrideGraphicSettings);
                    doc.Regenerate();
                }

                t.Commit();
            }

            DimensionCheckingFrm frm = new DimensionCheckingFrm(dt);
            if (DialogResult.OK != frm.ShowDialog())
            {
                return Result.Cancelled;
            }

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
                if (view.ViewType == ViewType.Detail)
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
        //检查是否存在不可见字符
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
                        if (seg.ValueOverride.Contains(LRMcode))
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        //检查文字和实际长度之间的误差是否在范围内
        private bool SumUpCheck(Dimension dim)
        {
            if (dim.Segments.Size == 0) return true;
            double totalLength = dim.get_Parameter(BuiltInParameter.DIM_TOTAL_LENGTH).AsDouble();
            double sumUplength = 0.0;
            foreach (DimensionSegment seg in dim.Segments)
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
                double segLength = Utils.ConvertFeet2(vStr);
                sumUplength += segLength;
            }
            return Math.Abs(totalLength - sumUplength) < 0.005;
        }
        private bool SumUpCheck2(Dimension dim,ref DimensionError error)
        {
            if (dim.Segments.Size == 0) return true;
            double totalLength = dim.get_Parameter(BuiltInParameter.DIM_TOTAL_LENGTH).AsDouble() * 304.8;
            double sumUplength = 0.0;
            foreach (DimensionSegment seg in dim.Segments)
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
                //string pattern = @"\d+";
                string pattern = @"\d+(\.\d+)?";
                MatchCollection matches = Regex.Matches(vStr, pattern);
                if (matches.Count == 1)
                {
                    double segLength = Convert.ToDouble(matches[0].Value);
                    sumUplength += segLength;
                }
                else
                {
                    error = DimensionError.SpellError;
                    return false;
                }
                
            }
            if (Math.Abs(totalLength - sumUplength) >= 0.99998) error = DimensionError.SumUpError;
            return Math.Abs(totalLength - sumUplength) < 0.99998;
        }

        private bool SpacingFomulaCheck(Dimension dim, ref DimensionError errorType)
        {
            if (dim.Segments.Size == 0)
            {
                if (!string.IsNullOrEmpty(dim.Prefix))
                {
                    if (!dim.Prefix.Contains("="))
                    {
                        errorType = DimensionError.EqualSymbolError;
                        return false;
                    }
                    SegmentSpacingFomula(dim.Prefix.Replace("=", ""), dim.ValueString, ref errorType);
                }
                if (!string.IsNullOrEmpty(dim.Below))
                {
                    if (dim.Below.Contains("="))
                    {
                        errorType = DimensionError.EqualSymbolError;
                        return false;
                    }
                    SegmentSpacingFomula(dim.Below.Replace("=", ""), dim.ValueString, ref errorType);
                }
            }
            else
            {
                foreach (DimensionSegment seg in dim.Segments)
                {
                    if (!string.IsNullOrEmpty(seg.Prefix))
                    {
                        if (seg.Prefix == null)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private bool SegmentSpacingFomula(string fomulaStr, string vauleStr, ref DimensionError errorType)
        {
            double vaule = Utils.ConvertFeet2(vauleStr);

            fomulaStr = fomulaStr.Trim();
            string numStr = string.Empty;
            string feetInchStr = string.Empty;
            int num = 0;
            double feetInch = 0.0;

            string pattern = @"\(\d+\)@.*?";//(A)@B //.*?为任意字符
            Regex regex = new Regex(pattern);
            if (regex.Match(fomulaStr).Success)
            {
                numStr = fomulaStr.Split('@')[0].Replace("(", "").Replace(")", "");
                num = int.Parse(numStr);
                feetInchStr = fomulaStr.Split('@')[1].Trim();
                feetInch = Utils.ConvertFeet2(feetInchStr);
                if (feetInch == -1.0)
                {
                    //TaskDialog.Show("r", "-1.0");
                }
                //TaskDialog.Show("r", "num:"+num.ToString()+";feet:"+ feetInch.ToString());
            }
            else
            {
                errorType = DimensionError.SpacingFomulaError;
                return false;
                //TaskDialog.Show("r", "-1");
            }
            return true;
        }

        // 检查元素是否在当前视图中可见
        private bool IsElementVisibleInView(Document doc, View view, Element element)
        {
            BoundingBoxXYZ boundingBox = element.get_BoundingBox(view);

            // 如果元素没有绑定框（例如被隐藏），返回 false
            if (boundingBox == null)
            {
                return false;
            }

            // 获取视图的边界框
            BoundingBoxXYZ viewBoundingBox = view.get_BoundingBox(null);
            Transform transform = viewBoundingBox.Transform;
            viewBoundingBox.Max = transform.OfPoint(viewBoundingBox.Max);
            viewBoundingBox.Min = transform.OfPoint(viewBoundingBox.Min);
            // 检查元素的边界框是否与视图的边界框相交
            bool intersects = Intersects(boundingBox, viewBoundingBox);

            // 检查视图中是否可见
            return intersects;
        }

        // 检查两个边界框是否相交
        private bool Intersects(BoundingBoxXYZ box1, BoundingBoxXYZ box2)
        {
            if (box1 == null || box2 == null)
            {
                return false;
            }

            return (box1.Min.X <= box2.Max.X && box1.Max.X >= box2.Min.X) &&
                   (box1.Min.Y <= box2.Max.Y && box1.Max.Y >= box2.Min.Y) &&
                   (box1.Min.Z <= box2.Max.Z && box1.Max.Z >= box2.Min.Z);
        }
    }
    public enum DimensionError
    {
        ValueOverrideError = 0,//添加了LRM符号，用于尺寸替换
        SumUpError = 1,//分段相加不等于总长，斜板的时候
        SpacingFomulaError = 2,//间距公式错误，(12)@1'-6"=
        EqualSymbolError = 3,//等号错误
        VariesReferencesError = 4,//标注到不同的埋件？
        SpellError = 5,//拼写错误
    }
    public class DimensionInfo
    {
        public ElementId dimId { get; set; }
        public View ActiveView { get; set; }
    }
}
