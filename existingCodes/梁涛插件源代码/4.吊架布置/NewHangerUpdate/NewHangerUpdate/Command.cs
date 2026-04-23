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
using static System.Net.Mime.MediaTypeNames;
using RevitUtils;
using System.Windows.Controls;
using System.Windows.Forms;
using Autodesk.Revit.Exceptions;
using OperationCanceledException = Autodesk.Revit.Exceptions.OperationCanceledException;

namespace NewHangerUpdate
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

            //var refers = sel.PickObjects(ObjectType.Element, new MEPFilter());
            //var meps = refers.Select(r1 => doc.GetElement(r1) as MEPCurve).ToList();
            //MEPCurve mEPCurve1;
            //MEPCurve mEPCurve2;
            //Utils.GetOutermostMEPCurves(meps, out mEPCurve1, out mEPCurve2);
            //if (mEPCurve1 != null)
            //{
            //    sel.SetElementIds(new ElementId[] { mEPCurve1.Id, mEPCurve2.Id });
            //}

            //var hangerReference = sel.PickObject(ObjectType.Element);
            //Element hanger2 = doc.GetElement(hangerReference);
            //XYZ point2 = (hanger2.Location as LocationPoint).Point;
            //point2 = new XYZ(point2.X, point2.Y, 0);

            //XYZ cp = Utils.GetMEPCenterPoint(point2, mEPCurve1, mEPCurve2);
            //TaskDialog.Show("revit", cp + "\n" + point2);

            //using (Transaction t = new Transaction(doc, "Move"))
            //{
            //    t.Start();

            //    hanger2.Location.Move(cp - point2);

            //    t.Commit();
            //}


            //return Result.Succeeded;

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

            bool isManualSelection;
            double r = 0;
            double rayDis = 0;

            SelWindow selWindow = new SelWindow();
            selWindow.ShowDialog();
            if (selWindow.DialogResult == false)
            {
                return Result.Cancelled;
            }
            isManualSelection = selWindow.IsManualSelection;
            //isManualSelection = true;

            Next:
            List<FamilyInstance> filterHangers = new List<FamilyInstance>();
            List<MEPCurve> selMEPCurves = new List<MEPCurve>();
            if (isManualSelection)
            {
                IList<Reference> mepRefers;
                IList<Reference> hangerRefers;

                try
                {
                    mepRefers = sel.PickObjects(ObjectType.Element, new MEPFilter(), "框选管道、风管、桥架");
                    hangerRefers = sel.PickObjects(ObjectType.Element, new HangerFilter(), "框选吊架");
                }
                catch (OperationCanceledException)
                {
                    TaskDialog.Show("提示", "结束布置");
                    return Result.Succeeded;
                }

                if (mepRefers.Count == 0 || hangerRefers.Count == 0)
                {
                    TaskDialog.Show("提示", "选择的数量需大于0！");
                    return Result.Succeeded;
                }
                filterHangers = hangerRefers.Select(h => doc.GetElement(h) as FamilyInstance).ToList();
                selMEPCurves = mepRefers.Select(m => doc.GetElement(m) as MEPCurve).ToList();
            }
            else
            {
                MainWindow window = new MainWindow();
                window.ShowDialog();
                if (window.DialogResult == false)
                {
                    return Result.Cancelled;
                }
                var hangerFamiles = Properties.Settings.Default.HangerFamily.Trim(',').Split(',').ToList();
                var hangerSymbols = Properties.Settings.Default.HangerSymbol.Trim(',').Split(',').ToList();
                r = Properties.Settings.Default.Radius / 304.8;
                rayDis = Properties.Settings.Default.DownRayScope / 304.8;

                filterHangers = new FilteredElementCollector(doc, view3d.Id).OfCategory(BuiltInCategory.OST_MechanicalEquipment).OfClass(typeof(FamilyInstance))
                    .Cast<FamilyInstance>().Where(f => hangerFamiles.Any(hf => f.Symbol.FamilyName.Contains(hf)) && hangerSymbols.Any(hs => f.Symbol.Name.Contains(hs))).ToList();
            }

            

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
                        //return Result.Failed;
                        return Result.Succeeded;
                    }
                    pbv.SetValue(i, Math.Round((((double)i / filterHangers.Count) * 100)) + "%");
                    pbv.SetNowProgress($"- {i}/{filterHangers.Count}");
                    System.Windows.Forms.Application.DoEvents();

                    FamilyInstance hanger = filterHangers[i];

                    #region 高度暂时不调整
                    bool verMove = MoveToTopFloor(doc, hanger, view3d, out var failedId);
                    if (!verMove)
                    {
                        failedIds.Add(failedId);
                        continue;
                    }
                    #endregion

                    bool horMove;
                    ElementId failedId1;
                    if (isManualSelection)
                    {
                        horMove = HorizontalMoveToMEPCurvesCenter(doc, hanger, selMEPCurves, out failedId1);
                    }
                    else
                    {
                        horMove = HorizontalMoveToMEPCurvesCenter(doc, hanger, view3d, r, rayDis, out failedId1);
                    }

                    if (!horMove)
                    {
                        failedIds.Add(failedId1);
                        continue;
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
            if (isManualSelection) goto Next;

            return Result.Succeeded;

        }
        private bool MoveToTopFloor(Document doc, FamilyInstance hanger, View3D view3d, out ElementId failedId)
        {
            bool result = true;
            failedId = null;

            var box = hanger.get_BoundingBox(view3d);

            XYZ point = box.Max.Add(box.Min) / 2;
            point = new XYZ(point.X, point.Y, box.Min.Z);
            double halfBoxHigh = (box.Max.Z - box.Min.Z) / 2;
            double boxHigh = box.Max.Z - box.Min.Z;
            //ElementFilter elementFilter = null;
            var filterList = new List<ElementFilter>()
            {
                new ElementCategoryFilter(BuiltInCategory.OST_Floors),
                new ElementCategoryFilter(BuiltInCategory.OST_Ceilings),
                new ElementCategoryFilter(BuiltInCategory.OST_StructuralFoundation),
                new ElementCategoryFilter(BuiltInCategory.OST_RvtLinks)
            };
            LogicalOrFilter orFilter = new LogicalOrFilter(filterList);
            double dis = RayUtils.GetDistanceByRay(point, orFilter, view3d, XYZ.BasisZ, true);
            //TaskDialog.Show("revit", (RayUtils.GetDistanceByRay(box.Min, orFilter, view3d, XYZ.BasisZ, true) * 304.8).ToString() + "\n" + (boxHigh * 304.8));
            // 1.吊架对齐顶板
            if (!dis.Equals(double.NaN))
            {
                using (Transaction t = new Transaction(doc, "吊架顶端对齐顶板"))
                {
                    t.Start();
                    try
                    {
                        if (hanger.GroupId != null && hanger.GroupId != ElementId.InvalidElementId)
                        {
                            doc.GetElement(hanger.GroupId).Location.Move((dis - boxHigh) * XYZ.BasisZ);
                            //TaskDialog.Show("revit", "1" + "\n" + (dis - halfBoxHigh));
                        }
                        else
                        {
                            hanger.Location.Move((dis - boxHigh) * XYZ.BasisZ);
                            //hanger.Location.Move((dis - boxHigh + 80 / 304.8) * XYZ.BasisZ);
                            //TaskDialog.Show("revit", "2" + "\n" + ((dis - halfBoxHigh) * XYZ.BasisZ));
                        }

                        Utils.ChangeHangerHeight(hanger);
                        
                        t.Commit();
                    }
                    catch (Exception)
                    {
                        if (t.HasStarted()) t.RollBack();
                        failedId = hanger.Id;
                        result = false;
                    }
                }
            }

            return result;
        }

        private bool HorizontalMoveToMEPCurvesCenter(Document doc, FamilyInstance hanger, Autodesk.Revit.DB.View view3d, double r, double rayDis, out ElementId failedId)
        {
            bool result = true;
            failedId = null;

            var box = hanger.get_BoundingBox(view3d);
            XYZ min = box.Max - XYZ.BasisX * r - XYZ.BasisY * r - XYZ.BasisZ * rayDis;
            XYZ max = box.Max + XYZ.BasisX * r + XYZ.BasisY * r + XYZ.BasisZ * rayDis;

            Outline outline = new Outline(min, max);
            BoundingBoxIntersectsFilter intersectsFilter = new BoundingBoxIntersectsFilter(outline);

            Solid solid = XYZ.BasisX.CreateSolid(box.Max + XYZ.BasisZ * rayDis, r, r, XYZ.BasisZ.Negate(), rayDis * 2);
            ElementIntersectsSolidFilter solidFilter = new ElementIntersectsSolidFilter(solid);

            LogicalAndFilter andFilter = new LogicalAndFilter(intersectsFilter, solidFilter);

            // 2.吊架与管道、桥架、风管对齐
            List<ElementFilter> elementFilters = new List<ElementFilter>()
                    {
                        new ElementCategoryFilter(BuiltInCategory.OST_PipeCurves),
                        new ElementCategoryFilter(BuiltInCategory.OST_CableTray),
                        new ElementCategoryFilter(BuiltInCategory.OST_DuctCurves),
                    };

            LogicalOrFilter orCateFilter = new LogicalOrFilter(elementFilters);
            using (FilteredElementCollector mEPCol = new FilteredElementCollector(doc, view3d.Id).WherePasses(orCateFilter))
            {
                // 25.10.28 有些非矩形mepcurve没有width的属性
                var filterMEPCurves = mEPCol.WherePasses(andFilter).Cast<MEPCurve>().Where(m => !XYZUtils.IsVertical(m, 0.18)).ToList();

                XYZ hangerP = (hanger.Location as LocationPoint).Point;

                //filterMEPCurves = filterMEPCurves.OrderBy(mep =>
                //{
                //    Line line = mep.GetLine();
                //    //line.MakeUnbound();
                //    XYZ pp = line.Project(hangerP).XYZPoint;
                //    return pp.DistanceTo(hangerP);
                //}).ToList();

                if (filterMEPCurves.Count() > 0)
                {
                    Utils.GetOutermostMEPCurves(filterMEPCurves, out var mEP1, out var mEP2, out var bottomElevation);
                    XYZ finalPoint = Utils.GetMEPCenterPoint(hangerP, mEP1, mEP2, out var dis);

                    using (Transaction t = new Transaction(doc, "调整吊架位置"))
                    {
                        try
                        {
                            t.Start();

                            // 调整吊架水平方向，使与喷淋管/照明线槽在上视图共线
                            hangerP = new XYZ(hangerP.X, hangerP.Y, 0);
                            if (hanger.GroupId != null && hanger.GroupId != ElementId.InvalidElementId)
                            {
                                doc.GetElement(hanger.GroupId).Location.Move(finalPoint - hangerP);
                            }
                            else
                            {
                                hanger.Location.Move(finalPoint - hangerP);
                            }

                            Utils.ChangeHangerWidth(hanger, dis);
                            Utils.ChangeHangerBottom(hanger, bottomElevation);
                            // 吊架层数大等于2
                            Utils.ChangeMultiLayerHanger(hanger, filterMEPCurves);

                            t.Commit();
                        }
                        catch
                        {
                            if (t.HasStarted()) t.RollBack();
                            failedId = hanger.Id;
                            result = false;
                        }
                    }

                }
            }
            return result;
        }
        private bool HorizontalMoveToMEPCurvesCenter(Document doc, FamilyInstance hanger, List<MEPCurve> mEPCurves, out ElementId failedId)
        {
            bool result = true;
            failedId = null;

            XYZ hangerP = (hanger.Location as LocationPoint).Point;
            //if (hanger.GroupId != null && hanger.GroupId != ElementId.InvalidElementId) hangerP = (doc.GetElement(hanger.GroupId).Location as LocationPoint).Point;

            Utils.GetOutermostMEPCurves(mEPCurves, out var mEP1, out var mEP2, out var bottomElevation);
            XYZ finalPoint = Utils.GetMEPCenterPoint(hangerP, mEP1, mEP2, out var dis);

            using (Transaction t = new Transaction(doc, "调整吊架位置"))
            {
                try
                {
                    t.Start();

                    // 调整吊架水平方向，使与喷淋管/照明线槽在上视图共线
                    hangerP = new XYZ(hangerP.X, hangerP.Y, 0);
                    if (hanger.GroupId != null && hanger.GroupId != ElementId.InvalidElementId)
                    {
                        doc.GetElement(hanger.GroupId).Location.Move(finalPoint - hangerP);
                    }
                    else
                    {
                        hanger.Location.Move(finalPoint - hangerP);
                    }
                    Utils.ChangeHangerWidth(hanger, dis);
                    Utils.ChangeHangerBottom(hanger, bottomElevation);
                    // 吊架层数大等于2
                    Utils.ChangeMultiLayerHanger(hanger, mEPCurves);

                    t.Commit();
                }
                catch
                {
                    if (t.HasStarted()) t.RollBack();
                    failedId = hanger.Id;
                    result = false;
                }
            }



            return result;
        }
    }
    public class MEPFilter : ISelectionFilter
    {
        public bool AllowElement(Element elem)
        {
            if (elem is MEPCurve)
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
    public class HangerFilter : ISelectionFilter
    {
        public bool AllowElement(Element elem)
        {
            if (elem.Category.Id.IntegerValue == -2001140 && elem is FamilyInstance familyInstance && familyInstance.Symbol.FamilyName.Contains("吊架"))
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

    enum Hanger
    {
        喷淋,
        照明和喷淋垂直平行,
        照明,
        其他
    }
}
