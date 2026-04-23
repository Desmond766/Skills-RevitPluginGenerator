using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveParkingNumber
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            // TODO: 添加误差与寻找范围窗口、添加对链接模型的坐标转换，否则在一些项目调整会出错误;
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;

            TaskDialog taskDialog = new TaskDialog("运行前提示");
            taskDialog.MainInstruction = "确认当前视图为三维视图且停车位、照明线槽桥架、车位号在当前视图中都可见后点击确定运行插件";
            taskDialog.CommonButtons = TaskDialogCommonButtons.Ok | TaskDialogCommonButtons.Cancel;
            var res = taskDialog.Show();
            if (res != TaskDialogResult.Ok)
            {
                return Result.Cancelled;
            }

            MainWindow window = new MainWindow();
            window.ShowDialog();
            if (window.DialogResult == false)
            {
                return Result.Cancelled;
            }
            double errorValue = window.ErrorValue / 304.8;
            double angle = (window.Angle / 180.0) * Math.PI;

            if (!(doc.ActiveView is View3D))
            {
                TaskDialog.Show("提示", "请在三维视图中运行该插件");
                return Result.Cancelled;
            }
            View3D view3D = (View3D)doc.ActiveView;

            List<RevitLinkInstance> linkInstances = new FilteredElementCollector(doc).WhereElementIsNotElementType()
                .OfCategory(BuiltInCategory.OST_RvtLinks)
                .Cast<RevitLinkInstance>().ToList();
                
            // 所有链接模型中的桥架
            List<LinkCableTrayInfo> linkCableTrays = new List<LinkCableTrayInfo>();

            foreach (var linkInstance in linkInstances)
            {
                Transform linkTransform = linkInstance.GetTransform();
                Document linkDoc = linkInstance.GetLinkDocument();
                List<CableTray> linkCables = new FilteredElementCollector(linkDoc).OfCategory(BuiltInCategory.OST_CableTray).WhereElementIsNotElementType().Where(c => c.Name.Contains("照明线槽")).Cast<CableTray>().ToList();

                List<FamilyInstance> parkings = new FilteredElementCollector(linkDoc).OfCategory(BuiltInCategory.OST_StructuralColumns).WhereElementIsNotElementType().Where(x => x.Name.Contains("普通车位")).Cast<FamilyInstance>().ToList();

                foreach (var linkCable in linkCables)
                {
                    LinkCableTrayInfo linkCableTray = TransformCableTray(linkInstance, linkCable);
                    linkCableTrays.Add(linkCableTray);
                }
            }

            // 车牌号
            List<FamilyInstance> parkingNumbers = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_StructuralColumns).WhereElementIsNotElementType()
                .Where(p => p.Name.Contains("车位号")).Cast<FamilyInstance>().ToList();

            int count = 0;
            List<ElementId> failedResult = new List<ElementId>();
            List<ElementId> result = new List<ElementId>();
            using (Transaction t = new Transaction(doc, "调整车位号"))
            {
                ElementId ruleParamId = new ElementId(BuiltInParameter.ELEM_TYPE_PARAM);
                FilterRule filteRule = ParameterFilterRuleFactory.CreateContainsRule(ruleParamId, "普通车位", false);
                ElementParameterFilter paramFilter = new ElementParameterFilter(filteRule);

                ElementCategoryFilter categoryFilter = new ElementCategoryFilter(BuiltInCategory.OST_StructuralColumns);

                LogicalAndFilter andFilter = new LogicalAndFilter(paramFilter, categoryFilter);

                t.Start();

                foreach (var pn in parkingNumbers)
                {
                    XYZ pnPoint = (pn.Location as LocationPoint).Point;
                    pnPoint += XYZ.BasisZ * (533 / 304.8);
                    ReferenceIntersector intersector = new ReferenceIntersector(andFilter, FindReferenceTarget.Element, view3D);
                    intersector.FindReferencesInRevitLinks = true;
                    ReferenceWithContext rw = intersector.FindNearest(pnPoint, XYZ.BasisZ.Negate());

                    if (rw != null && doc.GetElement(rw.GetReference()) is RevitLinkInstance linkInstance)
                    {
                        Transform linkTransform = linkInstance.GetTransform();
                        Document linkDoc = linkInstance.GetLinkDocument();
                        FamilyInstance park = linkDoc.GetElement(rw.GetReference().LinkedElementId) as FamilyInstance;

                        LinkCableTrayInfo nearCableTray = null;
                        foreach (var gee in park.get_Geometry(new Options() { IncludeNonVisibleObjects = false, DetailLevel = ViewDetailLevel.Fine }))
                        {
                            if (gee is GeometryInstance gei)
                            {
                                var gee2 = gei.GetInstanceGeometry();
                                foreach (var geo2 in gee2)
                                {
                                    if (geo2 is Solid solid && solid.SurfaceArea != 0 && solid.Volume != 0 && solid.Faces.Size == 5 && Math.Abs(solid.SurfaceArea - 2.7198314) < 0.001 && Math.Abs(solid.Volume - 0.0088091) < 0.001)
                                    {
                                        XYZ point = linkTransform.OfPoint(solid.ComputeCentroid());
                                        //double angle = (15 / 180.0) * Math.PI; // 两个都为int类型时相除不会保存小数部分
                                        nearCableTray = GetNearCableTray(errorValue, angle, linkCableTrays, pn, XYZ.BasisY, point);
                                        // 寻找桥架时需使用坐标转换
                                        break;
                                    }
                                }
                            }
                            else if (gee is Solid fSolid && fSolid.SurfaceArea != 0 && fSolid.Volume != 0 && fSolid.Faces.Size == 5 && Math.Abs(fSolid.SurfaceArea - 2.7198314) < 0.001 && Math.Abs(fSolid.Volume - 0.0088091) < 0.001)
                            {
                                XYZ point = linkTransform.OfPoint(fSolid.ComputeCentroid());
                                //double angle = (15 / 180.0) * Math.PI; // 两个都为int类型时相除不会保存小数部分
                                nearCableTray = GetNearCableTray(errorValue, angle, linkCableTrays, pn, XYZ.BasisY, point);

                                break;
                            }
                        }

                        if (nearCableTray != null)
                        {
                            MoveParkNumber(doc, XYZ.BasisY, pn, nearCableTray);
                            count++;
                        }
                        else failedResult.Add(pn.Id);
                    }
                    else failedResult.Add(pn.Id);
                }

                t.Commit();
            }
            //TaskDialog.Show("revit", count.ToString() + "\n" + parkSpaceIds.Count + "\n" + result.Distinct().Count() + "\n" + parkingNumbers.Count);
            TaskDialog.Show("提示", $"运行完成！\n成功调整的车位号数量：{count}/{parkingNumbers.Count}\n未调整的车位号数量：" + (parkingNumbers.Count - count) + "/" + parkingNumbers.Count);
            FailWindow failWindow = new FailWindow(uidoc);
            failWindow.list.ItemsSource = failedResult;
            failWindow.Show();
            return Result.Succeeded;
        }

        private LinkCableTrayInfo TransformCableTray(RevitLinkInstance linkInstance, CableTray linkCable)
        {
            LinkCableTrayInfo result = null;

            Transform linkTransform = linkInstance.GetTransform();
            Line line = GetLine(linkCable);
            Line newLine = Line.CreateBound(linkTransform.OfPoint(line.GetEndPoint(0)), linkTransform.OfPoint(line.GetEndPoint(1)));
            Line unboundLine = line.Clone() as Line;
            unboundLine.MakeUnbound();

            double centerZ = line.Evaluate(0.5, true).Z;

            double minZ = linkTransform.OfPoint(linkCable.get_BoundingBox(null).Min).Z;

            result = new LinkCableTrayInfo() { LinkLine = newLine, UnboundLinkLine = unboundLine, LineCenterZ = centerZ, LinkMinZ = minZ, LinkCableId = linkCable.Id };
            //if (linkCable.Id.IntegerValue == 6151578)
            //{
            //    TaskDialog.Show("revit", newLine.GetEndPoint(0) + "\n" + newLine.GetEndPoint(1) + "\n" + centerZ + "\n" + minZ);
            //}

            return result;
        }

        private void MoveParkNumbers(Document doc, double errorValue, double angle, List<FamilyInstance> parkNumbers, List<CableTray> cableTrays, XYZ baseParkNumberDir)
        {
            foreach (var parkNumber in parkNumbers)
            {
                XYZ parkNumberPoint = (parkNumber.Location as LocationPoint).Point;
                Transform parkNumberTransform = parkNumber.GetTransform();
                XYZ parkNumberDir = parkNumberTransform.OfVector(baseParkNumberDir);

                var cableTray = cableTrays.Where(x => IsParallel(parkNumberDir, x, angle) && InDistance(parkNumberPoint, x, errorValue))
                    .OrderBy(t => GetLine(t, out double centerZ).Project(new XYZ(parkNumberPoint.X, parkNumberPoint.Y, centerZ)).XYZPoint.DistanceTo(new XYZ(parkNumberPoint.X, parkNumberPoint.Y, centerZ))).FirstOrDefault();

                if (cableTray == null) continue;

                Line line = GetLine(cableTray);

                // 旋转灯具使其与桥架平行
                RotateParkNumber(doc, line, parkNumber, baseParkNumberDir);
                // 获取旋转后的灯具的坐标点
                parkNumberPoint = (parkNumber.Location as LocationPoint).Point;

                double Z = cableTray.get_BoundingBox(null).Min.Z;
                line.MakeUnbound();

                XYZ pp = line.Project(parkNumberPoint).XYZPoint;

                pp = new XYZ(pp.X, pp.Y, Z);
                XYZ moveDir = (pp - parkNumberPoint).Normalize();
                double moveDis = pp.DistanceTo(parkNumberPoint);

                parkNumber.Location.Move(moveDir * moveDis);
            }
        }
        private LinkCableTrayInfo GetNearCableTray(double errorValue, double angle, List<LinkCableTrayInfo> cableTrays, FamilyInstance parkNumber, XYZ baseParkNumberDir, XYZ solidPoint)
        {
            LinkCableTrayInfo result = null;

            //XYZ parkNumberPoint = (parkNumber.Location as LocationPoint).Point;
            Transform parkNumberTransform = parkNumber.GetTransform();
            XYZ parkNumberDir = parkNumberTransform.OfVector(baseParkNumberDir);

            result = cableTrays.Where(x => IsParallel(parkNumberDir, x, angle) && InDistance(solidPoint, x, errorValue))
                .OrderBy(t => t.LinkLine.Project(new XYZ(solidPoint.X, solidPoint.Y, t.LineCenterZ)).XYZPoint.DistanceTo(new XYZ(solidPoint.X, solidPoint.Y, t.LineCenterZ))).FirstOrDefault();

            return result;
        }
        private void MoveParkNumber(Document doc, /*double errorValue, double angle,*/ XYZ baseParkNumberDir, FamilyInstance parkNumber, CableTray cableTray)
        {
            Line line = GetLine(cableTray);

            // 旋转灯具使其与桥架平行
            RotateParkNumber(doc, line, parkNumber, baseParkNumberDir);
            // 获取旋转后的灯具的坐标点
            XYZ parkNumberPoint = (parkNumber.Location as LocationPoint).Point;

            double Z = cableTray.get_BoundingBox(null).Min.Z;
            line.MakeUnbound();

            XYZ pp = line.Project(parkNumberPoint).XYZPoint;

            pp = new XYZ(pp.X, pp.Y, Z);
            XYZ moveDir = (pp - parkNumberPoint).Normalize();
            double moveDis = pp.DistanceTo(parkNumberPoint);

            parkNumber.Location.Move(moveDir * moveDis);
            //foreach (var parkNumber in parkNumbers)
            //{
            //    XYZ parkNumberPoint = (parkNumber.Location as LocationPoint).Point;
            //    Transform parkNumberTransform = parkNumber.GetTransform();
            //    XYZ parkNumberDir = parkNumberTransform.OfVector();

            //    var cableTray = cableTrays.Where(x => IsParallel(parkNumberDir, x, angle) && InDistance(parkNumberPoint, x, errorValue))
            //        .OrderBy(t => GetLine(t, out double centerZ).Project(new XYZ(parkNumberPoint.X, parkNumberPoint.Y, centerZ)).XYZPoint.DistanceTo(new XYZ(parkNumberPoint.X, parkNumberPoint.Y, centerZ))).FirstOrDefault();

            //    if (cableTray == null) continue;

                
            //}
        }
        private void MoveParkNumber(Document doc, /*double errorValue, double angle,*/ XYZ baseParkNumberDir, FamilyInstance parkNumber, LinkCableTrayInfo cableTray)
        {
            Line line = cableTray.LinkLine;

            // 旋转灯具使其与桥架平行
            RotateParkNumber(doc, line, parkNumber, baseParkNumberDir);
            // 获取旋转后的灯具的坐标点
            XYZ parkNumberPoint = (parkNumber.Location as LocationPoint).Point;
            parkNumberPoint += XYZ.BasisZ * (533 / 304.8);

            double Z = cableTray.LinkMinZ;
            //line.MakeUnbound();

            XYZ pp = cableTray.UnboundLinkLine.Project(parkNumberPoint).XYZPoint;

            pp = new XYZ(pp.X, pp.Y, Z);
            XYZ moveDir = (pp - parkNumberPoint).Normalize();
            double moveDis = pp.DistanceTo(parkNumberPoint);
            //if (parkNumber.Id.IntegerValue == 5272401)
            //{
            //    TaskDialog.Show("revit", (moveDir * moveDis) + "\n" + Z + "\n" + pp + "\n" + moveDir + "\n" + moveDis + "\n" + cableTray.LinkCableId);
            //}
            parkNumber.Location.Move(moveDir * moveDis);
        }

        /// <summary>
        /// 旋转灯具使其与桥架平行
        /// </summary>
        /// <param name="line">桥架的线</param>
        /// <param name="light">灯具</param>
        /// <exception cref="NotImplementedException"></exception>
        private void RotateParkNumber(Document doc, Line line, FamilyInstance parkNumber, XYZ baseParkNumberDir)
        {
            //XYZ lightPoint = (light.Location as LocationPoint).Point;
            XYZ parkNumberPoint = parkNumber.get_BoundingBox(null).Max.Add(parkNumber.get_BoundingBox(null).Min) / 2;
            Transform parkNumberTransform = parkNumber.GetTransform();
            XYZ parkNumberDir = parkNumberTransform.OfVector(baseParkNumberDir);

            XYZ cableTrayDir = line.Direction;

            double angle = parkNumberDir.AngleTo(cableTrayDir);
            double angle90 = 90 / 180 * Math.PI;
            if (angle > angle90) angle -= angle90;

            // 误差小于1度时不进行旋转
            if (angle < 0.0175 || Math.Abs(Math.PI - angle) < 0.0175) return;

            ElementTransformUtils.RotateElement(doc, parkNumber.Id, Line.CreateBound(parkNumberPoint, parkNumberPoint + XYZ.BasisZ), angle);

            XYZ newLightDir = parkNumber.GetTransform().OfVector(baseParkNumberDir);
            if (!(newLightDir.IsAlmostEqualTo(cableTrayDir) || newLightDir.IsAlmostEqualTo(cableTrayDir.Negate())))
            {
                ElementTransformUtils.RotateElement(doc, parkNumber.Id, Line.CreateBound(parkNumberPoint, parkNumberPoint + XYZ.BasisZ), -2 * angle);
            }

        }

        private bool InDistance(XYZ point, Element elem, double scope)
        {
            Location location = elem.Location;
            if (location is LocationPoint locationPoint)
            {
                if (locationPoint.Point.DistanceTo(point) <= scope)
                    return true;
                return false;
            }
            else if (location is LocationCurve locationCurve)
            {
                Curve curve = locationCurve.Curve;

                XYZ cP = curve.Evaluate(0.5, true);
                point = new XYZ(point.X, point.Y, cP.Z);

                if (curve.Project(point).XYZPoint.DistanceTo(point) < scope)
                    return true;
                return false;
            }
            return false;

        }
        private bool InDistance(XYZ point, LinkCableTrayInfo linkCable, double scope)
        {
            Line linkLine = linkCable.LinkLine;
            point = new XYZ(point.X, point.Y, linkLine.Evaluate(0.5, true).Z);
            return linkLine.Project(point).XYZPoint.DistanceTo(point) < scope;
            //try
            //{
            //    Line linkLine = linkCable.LinkLine;
            //    point = new XYZ(point.X, point.Y, linkLine.Evaluate(0.5, true).Z);
            //    return linkLine.Project(point).XYZPoint.DistanceTo(point) < scope;
            //}
            //catch (Exception)
            //{
            //    failC++;
            //    return false;
            //}
            

        }

        public Line GetLine(Element element, out double centerZ)
        {
            centerZ = 0;
            Location location = element.Location;
            if (location is LocationCurve locationCurve)
            {
                Curve curve = locationCurve.Curve;
                if (curve is Line line)
                {
                    centerZ = line.Evaluate(0.5, true).Z;
                    return line;
                }
            }
            return null;
        }
        public Line GetLine(Element element)
        {
            Location location = element.Location;
            if (location is LocationCurve locationCurve)
            {
                Curve curve = locationCurve.Curve;
                if (curve is Line line)
                {
                    return line;
                }
            }
            return null;
        }
        private bool IsParallel(XYZ dir, Element elem, double angle)
        {
            Location location = elem.Location;
            if (location is LocationCurve locationCurve)
            {
                Curve curve = locationCurve.Curve;
                if (curve is Line line)
                {
                    XYZ dir2 = line.Direction;
                    if (dir.IsAlmostEqualTo(dir2, angle) || dir.IsAlmostEqualTo(dir2.Negate(), angle))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private bool IsParallel(XYZ dir, LinkCableTrayInfo linkCable, double angle)
        {
            XYZ linkDir = linkCable.LinkLine.Direction;
            return dir.IsAlmostEqualTo(linkDir, angle) || dir.IsAlmostEqualTo(linkDir.Negate(), angle);
        }
    }
    public class LinkCableTrayInfo
    {
        public Line LinkLine { get; set; }
        public double LineCenterZ { get; set; }

        public double LinkMinZ { get; set; }
        public Line UnboundLinkLine { get; set; }
        public ElementId LinkCableId { get; set; }
    }
}
