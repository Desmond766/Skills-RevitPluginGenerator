using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.ApplicationServices;

namespace AddPipelineInformation // 埋地管道参数填写+房间构件安装位置赋值 合并
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uIDoc = commandData.Application.ActiveUIDocument;
            Document doc = uIDoc.Document;

            View3D view3D = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Views).WhereElementIsNotElementType()
                .Where(x => x is View3D).Cast<View3D>().FirstOrDefault(y => y.Name.Contains("3D 机电"));
            if (view3D == null)
            {
                TaskDialog.Show("提示", "未找到视图：3D 机电");
                return Result.Cancelled;
            }

            // 打开指定视图中楼板的可见性
            var openIds = DisplayFloor(doc, view3D, out bool isHidden);

            List<Room> rooms = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Rooms).WhereElementIsNotElementType().Cast<Room>().ToList();

            List<Pipe> pipes = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_PipeCurves).WhereElementIsNotElementType().Cast<Pipe>().ToList();

            TransactionGroup TG = new TransactionGroup(doc, "埋地管道参数填写+房间构件安装位置赋值");
            TG.Start();
            foreach (Room room in rooms)
            {
                XYZ min = null;
                XYZ max = null;

                GeometryElement geometryElement = room.ClosedShell;
                Solid solid = null;
                foreach (var item in geometryElement)
                {
                    if (item is Solid solidRoom)
                    {
                        solid = solidRoom;
                        BoundingBoxXYZ boundingBox = solid.GetBoundingBox();
                        min = boundingBox.Transform.OfPoint(boundingBox.Min);
                        max = boundingBox.Transform.OfPoint(boundingBox.Max);
                        break;
                    }
                }

                ElementIntersectsSolidFilter solidFilter = new ElementIntersectsSolidFilter(solid);
                Outline outline = new Outline(min, max);
                BoundingBoxIntersectsFilter intersectsFilter = new BoundingBoxIntersectsFilter(outline);
                List<Pipe> pipes2 = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_PipeCurves).WhereElementIsNotElementType().WherePasses(intersectsFilter).WherePasses(solidFilter).Cast<Pipe>().ToList();
                string roomName = room.Name;

                using (Transaction t = new Transaction(doc, "构件安装位置赋值"))
                {
                    t.Start();
                    foreach (var pipe in pipes2)
                    {
                        try
                        {
                            var para = pipe.LookupParameter("安装位置");
                            para.DissociateFromGlobalParameter();
                            para.Set(roomName);
                        }
                        catch (Exception)
                        {
                            continue;
                        }
                    }
                    t.Commit();
                }
            }



            using (Transaction t = new Transaction(doc, "埋地管道参数赋值"))
            {
                t.Start();
                foreach (var pipe in pipes)
                {
                    Line line = (pipe.Location as LocationCurve).Curve as Line;
                    XYZ p0 = line.GetEndPoint(0);
                    XYZ p1 = line.GetEndPoint(1);
                    if (!IsPipeUnderFloor(view3D, p0) && !IsPipeUnderFloor(view3D, p1)) continue;

                    try
                    {
                        pipe.LookupParameter("安装方式").Set("埋地");
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
                t.Commit();
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
        public bool IsPipeUnderFloor(View3D view3D, XYZ point)
        {
            List<ElementFilter> filterList = new List<ElementFilter>();
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_Floors));
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_Ceilings));
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_StructuralFoundation));
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_RvtLinks));

            LogicalOrFilter floorOrCeiling = new LogicalOrFilter(filterList);
            ReferenceIntersector referenceIntersector = new ReferenceIntersector(floorOrCeiling, FindReferenceTarget.Element, view3D);
            referenceIntersector.FindReferencesInRevitLinks = true;
            ReferenceWithContext referenceWithContext = referenceIntersector.FindNearest(point, XYZ.BasisZ.Negate());

            if (referenceWithContext != null) return false;
            return true;
        }
    }
}
