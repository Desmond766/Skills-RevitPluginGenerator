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
using System.Windows.Controls;

namespace VerticalPipeElevationAdjustment
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;

            View3D view3D = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Views).WhereElementIsNotElementType()
                .Where(x => x is View3D).Cast<View3D>().FirstOrDefault(y => y.Name.Contains("3D 机电"));

            if (view3D == null)
            {
                TaskDialog.Show("提示", "未找到视图：3D 机电");
                return Result.Cancelled;
            }




            //return Result.Succeeded;

            var references = sel.PickObjects(ObjectType.Element, new MepCurveFilter(), "框选立管");

            SelWindow selWindow = new SelWindow();
            selWindow.ShowDialog();
            if (selWindow.DialogResult == false)
            {
                return Result.Cancelled;
            }
            // 打开指定视图中楼板的可见性
            var openIds = DisplayFloor(doc, view3D, out bool isHidden);

            var pipes = references.Select(x => doc.GetElement(x) as MEPCurve);
            TransactionGroup TG = new TransactionGroup(doc, "立管两端标高调整");
            TG.Start();
            foreach (var pipe in pipes)
            {
                XYZ pointUp;
                XYZ pointDown;
                Line line = (pipe.Location as LocationCurve).Curve as Line;
                XYZ dir = line.Direction;
                if (dir.IsAlmostEqualTo(XYZ.BasisZ))
                {
                    pointUp = line.GetEndPoint(1);
                    pointDown = line.GetEndPoint(0);
                }
                else
                {
                    pointUp = line.GetEndPoint(0);
                    pointDown = line.GetEndPoint(1);
                }
                double upDis = 0;
                double downDis = 0;
                if (selWindow.cb_up.IsChecked == true)
                {
                    try
                    {
                        upDis = Convert.ToDouble(selWindow.tb_up.Text) / 304.8;
                    }
                    catch (Exception)
                    {
                        break;
                    }

                    if (GetDistanceToFloor(view3D, pointUp, XYZ.BasisZ, false, doc) == -1) continue;

                    double dis = upDis;

                    if (upDis > 0)
                    {
                        dis += GetDistanceToFloor(view3D, pointUp, XYZ.BasisZ, true, doc);
                    }
                    else
                    {
                        dis += GetDistanceToFloor(view3D, pointUp, XYZ.BasisZ, false, doc);
                    }
                    pointUp += XYZ.BasisZ * dis;

                }
                if (selWindow.cb_down.IsChecked == true)
                {
                    try
                    {
                        downDis = Convert.ToDouble(selWindow.tb_down.Text) / 304.8;
                    }
                    catch (Exception)
                    {
                        break;
                    }

                    if (GetDistanceToFloor(view3D, pointDown, XYZ.BasisZ.Negate(), false, doc) == -1) continue;

                    double dis = downDis;

                    if (downDis >= 0)
                    {
                        dis = GetDistanceToFloor(view3D, pointDown, XYZ.BasisZ.Negate(), true, doc) - dis;
                    }
                    else
                    {
                        dis = GetDistanceToFloor(view3D, pointDown, XYZ.BasisZ.Negate(), false, doc) - dis;
                    }
                    pointDown += XYZ.BasisZ.Negate() * dis;
                }
                using (Transaction t = new Transaction(doc, "立管两端标高调整"))
                {
                    t.Start();
                    Line newLine = Line.CreateBound(pointDown, pointUp);
                    (pipe.Location as LocationCurve).Curve = newLine;
                    t.Commit();
                }
            }
            TG.Assimilate();

            // 恢复视图中楼板的可见性
            HiddenFloor(doc, view3D, openIds, isHidden);

            return Result.Succeeded;
        }

        private void HiddenFloor(Document doc, View3D view3D, List<ElementId> openIds, bool isHidden)
        {
            using (Transaction t = new Transaction(doc, "可见性设置"))
            {
                t.Start();
                try
                {
                    foreach (var id in openIds)
                    {
                        view3D.SetFilterVisibility(id, false);
                    }
                    if (isHidden) view3D.SetCategoryHidden(new ElementId(-2000032), true);
                }
                catch (Exception)
                {
                    t.RollBack();
                    return;
                }

                t.Commit();
            }
        }

        private List<ElementId> DisplayFloor(Document doc, View view3D, out bool isHidden)
        {
            var closeIds = new List<ElementId>();
            var filterIds = view3D.GetFilters();
            using (Transaction t = new Transaction(doc, "可见性设置"))
            {
                t.Start();

                try
                {
                    foreach (var id in filterIds)
                    {
                        var filter = doc.GetElement(id);
                        if (filter.Name.Contains("结构板") || filter.Name.Contains("楼板"))
                        {
                            if (view3D.GetFilterVisibility(id)) continue;
                            view3D.SetFilterVisibility(id, true);
                            closeIds.Add(id);
                        }
                    }
                    //TaskDialog.Show("revit", view3D.GetCategoryHidden(new ElementId(-2000032)).ToString());
                    isHidden = view3D.GetCategoryHidden(new ElementId(-2000032));
                    if (isHidden) view3D.SetCategoryHidden(new ElementId(-2000032), false);
                }
                catch (Exception)
                {
                    isHidden = false;
                    closeIds = new List<ElementId>();
                    t.RollBack();
                    return closeIds;
                }

                t.Commit();
            }
            return closeIds;
        }

        // TODO:若立管末端已超过楼板，则使用碰撞方法寻找楼板（链接模型中的楼板可能无法使用碰撞方法寻找） 25.1.7
        public double GetDistanceToFloor(View3D view3D, XYZ point, XYZ dir, bool OnFloor, Document doc)
        {
            double height = 0;

            List<ElementFilter> filterList = new List<ElementFilter>();
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_Floors));
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_Ceilings));
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_StructuralFoundation));
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_RvtLinks));

            LogicalOrFilter floorOrCeiling = new LogicalOrFilter(filterList);
            ReferenceIntersector referenceIntersector = new ReferenceIntersector(floorOrCeiling, FindReferenceTarget.Element, view3D);
            referenceIntersector.FindReferencesInRevitLinks = true;
            ReferenceWithContext referenceWithContext = referenceIntersector.FindNearest(point, dir);

            if (referenceWithContext == null) return -1;

            XYZ pp = referenceWithContext.GetReference().GlobalPoint;
            height += pp.DistanceTo(point);

            if ((OnFloor && dir.IsAlmostEqualTo(XYZ.BasisZ)) || (!OnFloor && dir.IsAlmostEqualTo(XYZ.BasisZ.Negate()))) // 在楼板上方
            {
                Reference reference = referenceWithContext.GetReference();
                // 默认找到的为链接模型中的楼板
                RevitLinkInstance revitLinkInstance = doc.GetElement(reference) as RevitLinkInstance;
                Document linkDoc = revitLinkInstance.GetLinkDocument();
                Floor linkElem = linkDoc.GetElement(reference.LinkedElementId) as Floor;
                height += linkElem.get_Parameter(BuiltInParameter.FLOOR_ATTR_THICKNESS_PARAM).AsDouble();
            }

            return height;
        }
    }
}
