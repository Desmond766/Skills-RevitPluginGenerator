using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using static System.Net.Mime.MediaTypeNames;
using RevitUtils;

namespace HangerUpdate
{
    [Transaction(TransactionMode.Manual)]
    [Serializable]
    public class Command : MarshalByRefObject, IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;

            //TaskDialog.Show("rveit", "jdfdf");
            //return Result.Succeeded;

            //TaskDialog.Show("revit", System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
            View3D view3d = null;
            if (doc.ActiveView is View3D view3D) view3d = view3D;
            else view3d = ViewUtils.SelectView3D(doc);

            if (view3d == null)
            {
                return Result.Cancelled;
            }

            if (view3d.get_Parameter(BuiltInParameter.VIEW_DETAIL_LEVEL).AsInteger() != (int)ViewDetailLevel.Fine)
            {
                using (Transaction t = new Transaction(doc, "三维视图详细程度设置"))
                {
                    t.Start();
                    view3d.get_Parameter(BuiltInParameter.VIEW_DETAIL_LEVEL).Set((int)ViewDetailLevel.Fine);
                    t.Commit();
                }
            }

            MainWindow window = new MainWindow();
            window.ShowDialog();
            if (window.DialogResult == false)
            {
                return Result.Cancelled;
            }

            var hangerFamiles = Properties.Settings.Default.HangerFamily.Trim(',').Split(',').ToList();
            var hangerSymbols = Properties.Settings.Default.HangerSymbol.Trim(',').Split(',').ToList();
            var r = Properties.Settings.Default.Radius / 304.8;
            var rayDis = Properties.Settings.Default.DownRayScope / 304.8;

            var filterHangers = new FilteredElementCollector(doc, view3d.Id).OfCategory(BuiltInCategory.OST_MechanicalEquipment).OfClass(typeof(FamilyInstance))
                .Cast<FamilyInstance>().Where(f => hangerFamiles.Any(hf => f.Symbol.FamilyName.Contains(hf)) && hangerSymbols.Any(hs => f.Symbol.Name.Contains(hs))).ToList();

            var pipes = new FilteredElementCollector(doc, view3d.Id).OfCategory(BuiltInCategory.OST_PipeCurves).OfClass(typeof(Pipe)).Where(p => p.Name.Contains("喷淋") && p.get_Parameter(BuiltInParameter.RBS_PIPE_DIAMETER_PARAM) != null && p.get_Parameter(BuiltInParameter.RBS_PIPE_DIAMETER_PARAM).AsDouble() - 50 / 304.8 <= 0.0001).Cast<Pipe>().ToList();

            ProgressBarView pbv = new ProgressBarView(commandData);
            pbv.Topmost = true;
            pbv.SetProgressBar(0, filterHangers.Count(), "- 0/1", "吊架更新中...");
            pbv.Show();

            // 记录更新异常的吊架
            List<ElementId> failedIds = new List<ElementId>();

            using (TransactionGroup TG = new TransactionGroup(doc, "吊架更新"))
            {
                TG.Start();

                for (int i = 0; i < filterHangers.Count(); i++)
                {
                    if (pbv.Cancel == true)
                    {
                        if (TG.HasStarted()) TG.RollBack();
                        return Result.Failed;
                    }
                    pbv.SetValue(i, Math.Round((((double)i / filterHangers.Count) * 100)) + "%");
                    pbv.SetNowProgress($"- {i}/{filterHangers.Count}");
                    System.Windows.Forms.Application.DoEvents();

                    FamilyInstance hanger = filterHangers[i];
                    Hanger hangerCate = Hanger.其他;
                    if (hanger.Symbol.Name.Contains("喷淋") && hanger.Symbol.FamilyName.Contains("吊架-喷淋"))
                    {
                        hangerCate = Hanger.喷淋;
                    }
                    else if (hanger.Symbol.Name.Contains("照明和喷淋") && (hanger.Symbol.Name.Contains("垂直") || hanger.Symbol.Name.Contains("平行")) && hanger.Symbol.FamilyName.Contains("照明+喷淋"))
                    {
                        hangerCate = Hanger.照明和喷淋垂直平行;
                    }
                    else if (hanger.Symbol.Name.Contains("照明和喷淋") && hanger.Symbol.FamilyName.Contains("吊架-照明线槽"))
                    {
                        hangerCate = Hanger.照明;
                    }

                    var box = hanger.get_BoundingBox(view3d);

                    XYZ point = box.Max.Add(box.Min) / 2;
                    double halfBoxHigh = (box.Max.Z - box.Min.Z) / 2;
                    //ElementFilter elementFilter = null;
                    var filetrList = new List<ElementFilter>()
                        {
                            new ElementCategoryFilter(BuiltInCategory.OST_Floors),
                            new ElementCategoryFilter(BuiltInCategory.OST_Ceilings),
                            new ElementCategoryFilter(BuiltInCategory.OST_StructuralFoundation),
                            new ElementCategoryFilter(BuiltInCategory.OST_RvtLinks)
                        };
                    LogicalOrFilter orFilter = new LogicalOrFilter(filetrList);
                    double dis = RayUtils.GetDistanceByRay(point, orFilter, view3d, XYZ.BasisZ, true);
                    // 1.吊架对齐顶板
                    if (!dis.Equals(double.NaN))
                    {
                        using (Transaction t = new Transaction(doc, "吊架顶端对齐顶板"))
                        {
                            t.Start();
                            try
                            {
                                hanger.Location.Move((dis - halfBoxHigh) * XYZ.BasisZ);
                            }
                            catch (Exception)
                            {
                                if (t.HasStarted()) t.RollBack();
                                failedIds.Add(hanger.Id);
                                continue;
                            }

                            t.Commit();
                        }
                    }
                    //continue;

                    //XYZ min = point - XYZ.BasisX * (500 / 304.8) - XYZ.BasisY * (500 / 304.8) - XYZ.BasisZ * (20000 / 304.8);
                    //XYZ max = point + XYZ.BasisX * (500 / 304.8) + XYZ.BasisY * (500 / 304.8) + XYZ.BasisZ * (20000 / 304.8);
                    XYZ min = box.Max - XYZ.BasisX * r - XYZ.BasisY * r - XYZ.BasisZ * rayDis;
                    XYZ max = box.Max + XYZ.BasisX * r + XYZ.BasisY * r + XYZ.BasisZ * rayDis;

                    Outline outline = new Outline(min, max);
                    BoundingBoxIntersectsFilter intersectsFilter = new BoundingBoxIntersectsFilter(outline);

                    //Solid solid = XYZ.BasisX.CreateSolid(point + XYZ.BasisZ * (20000 / 304.8), 500 / 304.8, 500 / 304.8, XYZ.BasisZ.Negate(), 40000 / 304.8);
                    Solid solid = XYZ.BasisX.CreateSolid(box.Max + XYZ.BasisZ * rayDis, r, r, XYZ.BasisZ.Negate(), rayDis * 2);
                    ElementIntersectsSolidFilter solidFilter = new ElementIntersectsSolidFilter(solid);

                    LogicalAndFilter andFilter = new LogicalAndFilter(intersectsFilter, solidFilter);

                    // 2.吊架与喷淋管道对齐
                    using (FilteredElementCollector pipeCol = new FilteredElementCollector(doc, view3d.Id).OfCategory(BuiltInCategory.OST_PipeCurves).OfClass(typeof(Pipe)))
                    {

                        //var filterPipes = pipeCol.Cast<Pipe>().Where(p => !XYZUtils.IsVertical(p, 0.18)).Where(p => Math.Abs(p.get_Parameter(BuiltInParameter.RBS_PIPE_DIAMETER_PARAM).AsDouble() - hangerD) < 0.0001).Where(p => p.Name.Contains("喷淋"));
                        var filterPipes = pipeCol.WherePasses(andFilter).Cast<Pipe>().Where(p => !XYZUtils.IsVertical(p, 0.18)).Where(p => p.get_Parameter(BuiltInParameter.RBS_PIPE_DIAMETER_PARAM).AsDouble() - 50 / 304.8 < 0.0001).Where(p => p.Name.Contains("喷淋"));

                        XYZ hangerP = (hanger.Location as LocationPoint).Point;
                        if (hangerCate == Hanger.喷淋 || hangerCate == Hanger.照明和喷淋垂直平行)
                        {
                            double hangerR = hangerCate == Hanger.喷淋 ? hanger.LookupParameter("R").AsDouble() : hanger.LookupParameter("R(管夹半径)").AsDouble();
                            double newZ = hanger.LookupParameter("a_楼板底高").AsDouble()
                            + (hanger.Location as LocationPoint).Point.Z
                            - hanger.LookupParameter("H").AsDouble() - hangerR;

                            hangerP = new XYZ(hangerP.X, hangerP.Y, newZ);
                        }

                        filterPipes = filterPipes.OrderBy(pipe =>
                        {
                            Line line = pipe.GetLine();
                            //line.MakeUnbound();
                            XYZ pp = line.Project(hangerP).XYZPoint;
                            return pp.DistanceTo(hangerP);
                        });
                        //string sdsd = "";
                        //foreach (var item in filterPipes)
                        //{
                        //    sdsd += item.Id + "\n";
                        //}
                        if (filterPipes.Count() > 0)
                        {
                            Pipe result = filterPipes.First();
                            //TaskDialog.Show("revit", result.Id.ToString()+"\n"+hangerP);
                            using (Transaction t = new Transaction(doc, "调整套筒高度+吊架位置+直径"))
                            {
                                SubTransaction sub1 = new SubTransaction(doc);
                                SubTransaction sub2 = new SubTransaction(doc);
                                SubTransaction sub3 = new SubTransaction(doc);
                                try
                                {
                                    t.Start();

                                    // 调整吊架垂直方向，使吊架的套管与喷淋管中心线高度一致
                                    sub1.Start();
                                    if (hangerCate == Hanger.喷淋 || hangerCate == Hanger.照明和喷淋垂直平行)
                                    {
                                        var para = hanger.LookupParameter("管道中心标高");
                                        double pipeZ = result.GetLine().GetEndPoint(0).Z;
                                        para.Set(para.AsDouble() + (pipeZ - hangerP.Z));
                                    }
                                    sub1.Commit();

                                    double newZ = result.GetLine().GetEndPoint(0).Z;
                                    hangerP = new XYZ(hangerP.X, hangerP.Y, newZ);
                                    XYZ pp = result.GetLine().Project(hangerP).XYZPoint;
                                    double moveDis = pp.DistanceTo(hangerP);
                                    XYZ moveDir = (pp - hangerP).Normalize();

                                    // 调整吊架水平方向，使与喷淋管/照明线槽在上视图共线
                                    sub2.Start();
                                    hanger.Location.Move(moveDir * moveDis);
                                    sub2.Commit();

                                    // 调整套管直径
                                    sub3.Start();
                                    if (hangerCate == Hanger.喷淋 || hangerCate == Hanger.照明和喷淋垂直平行)
                                    {
                                        hanger.LookupParameter("管道公称直径").Set(result.get_Parameter(BuiltInParameter.RBS_PIPE_DIAMETER_PARAM).AsDouble());
                                    }
                                    sub3.Commit();

                                    t.Commit();
                                }
                                catch
                                {
                                    if (sub1.HasStarted()) sub1.RollBack();
                                    if (sub2.HasStarted()) sub2.RollBack();
                                    if (sub3.HasStarted()) sub3.RollBack();
                                    if (t.HasStarted()) t.RollBack();
                                    failedIds.Add(hanger.Id);
                                    continue;
                                }
                            }

                        }
                    }
                    if (hangerCate == Hanger.喷淋 || hangerCate == Hanger.其他) continue;
                    // 3.调整吊架桥架底标高
                    using (FilteredElementCollector cableCol = new FilteredElementCollector(doc, view3d.Id).OfCategory(BuiltInCategory.OST_CableTray).OfClass(typeof(CableTray)))
                    {
                        var filterCables = cableCol.WherePasses(andFilter).Cast<CableTray>().Where(c => c.Name.Contains("照明线槽"))
                            .Where(c => !XYZUtils.IsVertical(c, 0.18));
                        var newBox = hanger.get_BoundingBox(view3d);
                        var hangerP = newBox.Max.Add(newBox.Min) / 2;
                        hangerP = new XYZ(hangerP.X, hangerP.Y, newBox.Min.Z);
                        if (hangerCate == Hanger.照明 || hangerCate == Hanger.照明和喷淋垂直平行)
                        {
                            hangerP = new XYZ(hangerP.X, hangerP.Y, (hanger.Location as LocationPoint).Point.Z + hanger.LookupParameter("桥架底标高").AsDouble());
                        }

                        if (filterCables.Count() == 0) continue;

                        filterCables = filterCables.OrderBy(cable =>
                        {
                            Line line = cable.GetLine();
                            XYZ p0 = line.GetEndPoint(0);
                            XYZ p1 = line.GetEndPoint(1);
                            line = Line.CreateBound(new XYZ(p0.X, p0.Y, 0), new XYZ(p1.X, p1.Y, 0));
                            XYZ zeroHangerP = new XYZ(hangerP.X, hangerP.Y, 0);

                            var pp = line.Project(zeroHangerP).XYZPoint;
                            return pp.DistanceTo(zeroHangerP);
                        });
                        var result = filterCables.First();
                        using (Transaction t = new Transaction(doc, "调整吊架照明线槽套筒"))
                        {
                            try
                            {
                                t.Start();
                                double buttomOffset = result.get_BoundingBox(view3d).Min.Z;
                                // 有坡度的照明线槽的底部高度需重新计算
                                if (Math.Abs(result.get_Parameter(BuiltInParameter.RBS_END_OFFSET_PARAM).AsDouble() - result.get_Parameter(BuiltInParameter.RBS_START_OFFSET_PARAM).AsDouble()) > 0.0001)
                                {
                                    XYZ rayP = new XYZ(hangerP.X, hangerP.Y, (hanger.Location as LocationPoint).Point.Z + hanger.LookupParameter("a_楼板底高").AsDouble());
                                    double rayRes = RayUtils.GetDistanceByRay(rayP, new List<ElementId>() { result.Id }, view3d, XYZ.BasisZ.Negate(), false, FindReferenceTarget.Face);
                                    if (!rayRes.Equals(double.NaN))
                                    {
                                        buttomOffset = rayP.Z - rayRes;
                                    }
                                }

                                var para = hanger.LookupParameter("桥架底标高");
                                //TaskDialog.Show("revit", result.Id.ToString() + "\n" + hangerP.Z + "\n" + buttomOffset + "\n" + para.AsDouble() * 304.8 + "\n" + (hangerP.Z - buttomOffset) * 304.8);
                                para.Set(para.AsDouble() - (hangerP.Z - buttomOffset));
                                var widthPara = hanger.LookupParameter("吊架套筒长度");
                                widthPara.Set(result.Width);
                                XYZ movePoint = new XYZ(hangerP.X, hangerP.Y, 0);

                                Line line = result.GetLine();
                                XYZ p0 = line.GetEndPoint(0);
                                XYZ p1 = line.GetEndPoint(1);
                                line = Line.CreateBound(new XYZ(p0.X, p0.Y, 0), new XYZ(p1.X, p1.Y, 0));
                                line.MakeUnbound();
                                XYZ pp = line.Project(movePoint).XYZPoint;

                                hanger.Location.Move((pp - movePoint).Normalize() * pp.DistanceTo(movePoint));
                                t.Commit();
                            }
                            catch (Exception)
                            {
                                if (t.HasStarted()) t.RollBack();
                                failedIds.Add(hanger.Id);
                                continue;
                            }

                        }

                    }

                }


                TG.Assimilate();
            }
            pbv.Close();
            if (failedIds.Count != 0)
            {
                var res = TaskDialog.Show("Revit", $"运行结束\n共选中{filterHangers.Count()}个吊架，异常吊架{failedIds.Count}个，是否亮显异常吊架？", TaskDialogCommonButtons.Yes | TaskDialogCommonButtons.No);
                if (res == TaskDialogResult.Yes)
                {
                    uidoc.ShowElements(failedIds);
                    sel.SetElementIds(failedIds);
                }
            }
            else
            {
                TaskDialog.Show("Revit", $"运行完成！\n共选中{filterHangers.Count()}个吊架");
            }

            return Result.Succeeded;

        }
    }
    enum Hanger
    {
        喷淋,
        照明和喷淋垂直平行,
        照明,
        其他
    }
}
