using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddSleeveDiameter
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;

            //FamilyInstance familyInstance = doc.GetElement(sel.PickObject(ObjectType.Element)) as FamilyInstance;
            //using (Transaction t = new Transaction(doc, "sss"))
            //{
            //    t.Start();

            //    var gee = familyInstance.get_Geometry(new Options() { IncludeNonVisibleObjects = true });
            //    foreach (var item in gee)
            //    {
            //        if (item is Solid solid)
            //        {
            //            var box = familyInstance.get_BoundingBox(null);
            //            Outline outline = new Outline(box.Min, box.Max);
            //            BoundingBoxIntersectsFilter boxIntersectsFilter = new BoundingBoxIntersectsFilter(outline);
            //            ElementIntersectsSolidFilter solidFilter = new ElementIntersectsSolidFilter(solid);
            //            LogicalAndFilter andFilter = new LogicalAndFilter(solidFilter, boxIntersectsFilter);
            //            var pips = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_PipeCurves).WherePasses(andFilter);
            //            TaskDialog.Show("dd", pips.Count().ToString());
            //            break;
            //        }
            //    }

            //    t.Commit();
            //}
            //return Result.Succeeded;

            //Pipe pipe = doc.GetElement(sel.PickObject(ObjectType.Element)) as Pipe;
            //XYZ p = (familyInstance.Location as LocationPoint).Point;
            //Line line = (pipe.Location as LocationCurve).Curve as Line;
            //XYZ pp = line.Project(p).XYZPoint;
            //var pipeCol = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_PipeCurves).WherePasses(new ElementIntersectsElementFilter(familyInstance));
            //TaskDialog.Show("dd", pipeCol.Count().ToString() + "\n" + p.DistanceTo(pp));
            //return Result.Succeeded;

            int gxCount = 0;
            int rxCount = 0;
            int mbCount = 0;
            int gCount = 0;
            // 获取指定名称的套管
            FilteredElementCollector sleeveCol = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_MechanicalEquipment).WhereElementIsNotElementType();

            var sleeves = sleeveCol.Where(f => f is FamilyInstance).Cast<FamilyInstance>().Where(s => s.Symbol.Name.Contains("柔性防水套管") || s.Symbol.FamilyName.Contains("柔性防水套管") || s.Symbol.Name.Contains("刚性防水套管") || s.Symbol.FamilyName.Contains("刚性防水套管")
            || s.Symbol.Name.Contains("密闭套管") || s.Symbol.FamilyName.Contains("密闭套管")
            || ((s.Symbol.Name.Contains("钢套管") || s.Symbol.FamilyName.Contains("钢套管")) && s.LookupParameter("系统名称") != null && !string.IsNullOrEmpty(s.LookupParameter("系统名称").AsString()) && s.LookupParameter("系统名称").AsString().Contains("ZP"))).ToList();

            using (Transaction t = new Transaction(doc, "套管管径标识参数赋值"))
            {
                t.Start();

                foreach (var sl in sleeves)
                {
                    //if (sl.LookupParameter("系统名称") == null || sl.LookupParameter("系统名称").AsString() == null || !sl.LookupParameter("系统名称").AsString().Contains("ZP"))
                    //{
                    //    continue;
                    //}
                    double pipeDim = 0;
                    using (FilteredElementCollector pipeCol = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_PipeCurves))
                    {
                        var box = sl.get_BoundingBox(null);
                        Outline outline = new Outline(box.Min, box.Max);
                        BoundingBoxIntersectsFilter intersectsFilter = new BoundingBoxIntersectsFilter(outline);
                        ElementIntersectsSolidFilter solidFilter = null;
                        var gee = sl.get_Geometry(new Options() { IncludeNonVisibleObjects = true });
                        foreach (var geo in gee)
                        {
                            if (geo is Solid solid)
                            {
                                solidFilter = new ElementIntersectsSolidFilter(solid);
                                break;
                            }
                        }
                        if (solidFilter == null) continue;
                        LogicalAndFilter andFilter = new LogicalAndFilter(intersectsFilter, solidFilter);
                        var pipes = pipeCol.WherePasses(andFilter);
                        if (pipes.Count() == 0) continue;
                        if (pipes.Count() == 1) pipeDim = pipes.First().get_Parameter(BuiltInParameter.RBS_PIPE_DIAMETER_PARAM).AsDouble() * 304.8;
                        if (pipes.Count() > 1) pipeDim = GetNearPipe(pipes, sl).get_Parameter(BuiltInParameter.RBS_PIPE_DIAMETER_PARAM).AsDouble() * 304.8;
                    }

                    foreach (Parameter para in sl.Parameters)
                    {
                        if (para.Definition.ParameterGroup == BuiltInParameterGroup.PG_TEXT && para.Definition.Name == "管径标识")
                        {
                            para.DissociateFromGlobalParameter();
                            if (para.StorageType == StorageType.Double)
                            {
                                para.Set(pipeDim);
                            }
                            else if (para.StorageType == StorageType.String)
                            {
                                para.Set("DN"+pipeDim.ToString());
                            }
                            if (sl.Symbol.Name.Contains("刚性") || sl.Symbol.FamilyName.Contains("刚性"))
                            {
                                gxCount++;
                            }
                            else if (sl.Symbol.Name.Contains("柔性") || sl.Symbol.FamilyName.Contains("柔性"))
                            {
                                rxCount++;
                            }
                            else if (sl.Symbol.Name.Contains("密闭") || sl.Symbol.FamilyName.Contains("密闭"))
                            {
                                mbCount++;
                            }
                            else if (sl.Symbol.Name.Contains("钢套管") || sl.Symbol.FamilyName.Contains("钢套管"))
                            {
                                gCount++;
                            }
                            break;
                        }
                    }
                }

                t.Commit();
            }
            TaskDialog.Show("Revit", $"运行结束！成功填写参数的套管总数量：{gxCount + gCount + rxCount + mbCount}个\n其中：\n刚性套管数量：{gxCount}个\n柔性套管数量：{rxCount}个\n钢套管数量：{gCount}个\n密闭套管数量：{mbCount}个");


            return Result.Succeeded;
        }

        private Pipe GetNearPipe(FilteredElementCollector pipes, FamilyInstance sl)
        {
            XYZ p = (sl.Location as LocationPoint).Point;
            double minValue = double.MaxValue;
            Pipe nearPipe = null;

            foreach (var pipe in pipes)
            {
                Line line = (pipe.Location as LocationCurve).Curve as Line;
                double dis = line.Project(p).XYZPoint.DistanceTo(p);
                if (dis < minValue)
                {
                    minValue = dis;
                    nearPipe = (Pipe)pipe;
                }
            }

            return nearPipe;
        }
    }
}
