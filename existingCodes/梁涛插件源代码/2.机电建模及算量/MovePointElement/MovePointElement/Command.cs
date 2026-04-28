using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;
using Line = Autodesk.Revit.DB.Line;

namespace MovePointElement
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;

            //TestWindow testWindow = new TestWindow();
            //testWindow.Show();
            //return Result.Succeeded;

            //using (Transaction t = new Transaction(doc, "重设"))
            //{
            //    t.Start();
            //    uidoc.ActiveView.IsolateElementsTemporary(new ElementId[] {new ElementId(5272273), new ElementId(5272275)  });
            //    doc.ActiveView.TemporaryViewModes.DeactivateAllModes();
            //    t.Commit();
            //}
            //using (Transaction t = new Transaction(doc, "重设2"))
            //{
            //    t.Start();
            //    uidoc.ActiveView.IsolateElementsTemporary(new ElementId[] {new ElementId(5272271), new ElementId(5272269)  });
            //    //doc.ActiveView.TemporaryViewModes.DeactivateAllModes();
            //    t.Commit();
            //}
            //return Result.Succeeded; 

            MainWindow mainWindow = new MainWindow(doc);
            mainWindow.ShowDialog();
            if (mainWindow.DialogResult == false)
            {
                //MessageBox.Show("已取消操作");
                //TaskDialog.Show("revit", mainWindow.btn_confirm.Margin.ToString() + "\n" + mainWindow.grid_parent.ActualWidth);
                return Result.Cancelled;
            }

            //TaskDialog.Show("revit", mainWindow.PointCategory + "\n" + mainWindow.PointName + "\n" + mainWindow.PointDirection + "\n" + mainWindow.IsScope + "\n" + mainWindow.HostCategory + "\n" + mainWindow.HostName);
            BuiltInCategory pointCategory = mainWindow.PointCategory;
            string pointName = mainWindow.PointName;
            XYZ pointDirection = mainWindow.PointDirection;
            bool isScope = mainWindow.IsScope;
            BuiltInCategory hostCategory = mainWindow.HostCategory;
            string hostName = mainWindow.HostName;

            double scopeValue = mainWindow.Distance / 304.8;
            double zError = mainWindow.ZError / 304.8;
            bool useZError = mainWindow.UseZError;
            double angle = (mainWindow.Angle / 180.0) * Math.PI;

            List<ElementId> pointIds = GetElementIds(doc, pointCategory, pointName, isScope);
            List<ElementId> hostIds = GetElementIds(doc, hostCategory, hostName, isScope, false);

            //TaskDialog.Show("revit", pointIds.Count + "\n" +  hostIds.Count);

            using (Transaction t = new Transaction(doc, "移动点元素"))
            {
                t.Start();

                MovePointElements(doc, scopeValue, angle, zError, useZError, pointDirection, pointIds, hostIds);

                t.Commit();
            }
            return Result.Succeeded;
        }

        private void MovePointElements(Document doc, double scopeValue, double angle, double zError, bool useZError, XYZ pointBaseDirection, List<ElementId> pointIds, List<ElementId> hostIds)
        {
            List<Element> hostElems = hostIds.Select(h => doc.GetElement(h)).ToList();
            foreach (var pointId in pointIds)
            {
                var pointElem = doc.GetElement(pointId) as FamilyInstance;

                XYZ pPoint = (pointElem.Location as LocationPoint).Point;
                Transform pointTransform = pointElem.GetTransform();
                XYZ lightDir = pointTransform.OfVector(pointBaseDirection);

                // UPDATE:26.2.2 新增行车线族类型
                Element hostElem = null;
                if (hostElems.Count > 0)
                {
                    if (hostElems.First() is Railing)
                    {
                        hostElem = hostElems.Where(x => IsParallelAndInDistance(x, pPoint, scopeValue, lightDir, angle))
                    .OrderBy(t => GetNearestRailingLine(t, pPoint, scopeValue, lightDir, angle, out double centerZ).Project(new XYZ(pPoint.X, pPoint.Y, centerZ)).XYZPoint.DistanceTo(new XYZ(pPoint.X, pPoint.Y, centerZ)))
                    .FirstOrDefault();
                    }
                    else
                    {
                        hostElem = hostElems.Where(x => IsParallel(lightDir, pPoint, x, angle) && InDistance(pPoint, x, scopeValue))
                    .OrderBy(t => GetLine(t, out double centerZ).Project(new XYZ(pPoint.X, pPoint.Y, centerZ)).XYZPoint.DistanceTo(new XYZ(pPoint.X, pPoint.Y, centerZ)))
                    .FirstOrDefault();
                    }
                }

                if (hostElem == null) continue;

                Line cableLine;
                if (hostElem is Railing)
                {
                    cableLine = GetNearestRailingLine(hostElem, pPoint, scopeValue, lightDir, angle, out var z);
                }
                else
                {
                    cableLine = GetLine(hostElem);
                }

                if (Math.Abs(angle - 2 * Math.PI) > 0.001) RotatePointElement(doc, cableLine, pointElem, pointBaseDirection);

                pPoint = (pointElem.Location as LocationPoint).Point;
                // UPDATE: 26.2.4 新增自定义是否调整点位高度
                if (useZError)
                {
                    pPoint = pPoint + XYZ.BasisZ * zError;

                    double Z = hostElem.get_BoundingBox(null).Min.Z;

                    cableLine.MakeUnbound();

                    XYZ pp = cableLine.Project(pPoint).XYZPoint;
                    pp = new XYZ(pp.X, pp.Y, Z);
                    XYZ moveDir = (pp - pPoint).Normalize();
                    double moveDis = pp.DistanceTo(pPoint);

                    pointElem.Location.Move(moveDir * moveDis);
                }
                else
                {
                    cableLine.MakeUnbound();

                    XYZ pp = cableLine.Project(pPoint).XYZPoint;
                    pp = new XYZ(pp.X, pp.Y, pPoint.Z);
                    XYZ moveDir = (pp - pPoint).Normalize();
                    double moveDis = pp.DistanceTo(pPoint);

                    pointElem.Location.Move(moveDir * moveDis);
                }
                
            }
        }

        private void RotatePointElement(Document doc, Line line, FamilyInstance pointElem, XYZ pointBaseDirection)
        {
            //XYZ lightPoint = (light.Location as LocationPoint).Point;
            XYZ pPoint = pointElem.get_BoundingBox(null).Max.Add(pointElem.get_BoundingBox(null).Min) / 2;
            Transform pTransform = pointElem.GetTransform();
            XYZ pDir = pTransform.OfVector(pointBaseDirection);

            XYZ cableTrayDir = line.Direction;

            double angle = pDir.AngleTo(cableTrayDir);
            double angle90 = 90 / 180 * Math.PI;
            if (angle > angle90) angle -= angle90;

            // 误差小于1度时不进行旋转
            if (angle < 0.0175 || Math.Abs(Math.PI - angle) < 0.0175) return;

            ElementTransformUtils.RotateElement(doc, pointElem.Id, Line.CreateBound(pPoint, pPoint + XYZ.BasisZ), angle);

            XYZ newLightDir = pointElem.GetTransform().OfVector(pointBaseDirection);
            if (!(newLightDir.IsAlmostEqualTo(cableTrayDir) || newLightDir.IsAlmostEqualTo(cableTrayDir.Negate())))
            {
                ElementTransformUtils.RotateElement(doc, pointElem.Id, Line.CreateBound(pPoint, pPoint + XYZ.BasisZ), -2 * angle);
            }

        }

        private List<ElementId> GetElementIds(Document doc, BuiltInCategory cate, string elemName, bool isScope, bool isLocationPoint = true)
        {
            List<ElementId> result = new List<ElementId>();
            FilteredElementCollector elemCol;
            if (isScope) elemCol = new FilteredElementCollector(doc, doc.ActiveView.Id).WhereElementIsNotElementType();
            else elemCol = new FilteredElementCollector(doc).WhereElementIsNotElementType();

            if (isLocationPoint) result = elemCol.OfCategory(cate).Where(e => e.Location != null && e.Location is LocationPoint && e.Name == elemName).Select(x => x.Id).ToList();
            else result = elemCol.OfCategory(cate)
                    .Where(e => ((e.Location != null && e.Location is LocationCurve locationCurve && locationCurve.Curve is Line) || (e is Railing railing && railing.GetPath().Count > 0)) && e.Name == elemName)
                    .Select(x => x.Id).ToList();

            return result;
        }

        private Line GetLine(Element element, out double centerZ)
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
        private Line GetNearestRailingLine(Element element, XYZ pPoint, double scope, XYZ dir, double angle, out double centerZ)
        {
            centerZ = 0;
            
            Line result = null;
            double minDis = double.MaxValue;
            if (element is Railing railing)
            {
                var curves = railing.GetPath().Where(c => c is Line && IsParallelAndInDistanceCurve(c, pPoint, scope, dir, angle));
                foreach (var curve in curves)
                {
                    double curveCenterZ = curve.Evaluate(0.5, true).Z;
                    pPoint = new XYZ(pPoint.X, pPoint.Y, curveCenterZ);
                    double dis = curve.Project(pPoint).XYZPoint.DistanceTo(pPoint);
                    if (result == null || dis < minDis)
                    {
                        result = curve as Line;
                        minDis = dis;
                        centerZ = curveCenterZ;
                    }
                }
            }

            return result;
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
        /// <summary>
        /// 判断行车线是否存在一段Curve与点位平行且在设置的范围内
        /// </summary>
        /// <param name="elem">行车线</param>
        /// <param name="point">点位坐标</param>
        /// <param name="scope">距离范围</param>
        /// <param name="dir">点位方向</param>
        /// <param name="angle">点位与行车线Curve的角度误差（吸顶点位建议设置为360度对应误差）</param>
        /// <returns></returns>
        private bool IsParallelAndInDistance(Element elem, XYZ point, double scope, XYZ dir, double angle)
        {
            if (elem is Railing railing) //UPDATE:26.2.2新增railing的判断
            {
                foreach (var curve in railing.GetPath())
                {
                    if (!(curve is Line)) continue;
                    bool result = IsParallelAndInDistanceCurve(curve, point, scope, dir, angle);
                    if (result) return result; 
                }
            }
            return false;
        }
        private bool IsParallelAndInDistanceCurve(Curve curve, XYZ point, double scope, XYZ dir, double angle)
        {
            XYZ cP = curve.Evaluate(0.5, true);
            point = new XYZ(point.X, point.Y, cP.Z);
            if (curve.Project(point).XYZPoint.DistanceTo(point) < scope)
            {
                if (curve is Line line)
                {
                    XYZ dir2 = line.Direction;
                    if (dir.IsAlmostEqualTo(dir2, angle) || dir.IsAlmostEqualTo(dir2.Negate(), angle))
                    {
                        return true;
                    }
                }
                else if (curve is Arc arc)
                {
                    XYZ pp = arc.Project(point).XYZPoint;
                    XYZ centerP = arc.Center;
                    centerP = new XYZ(centerP.X, centerP.Y, pp.Z);
                    XYZ verDir = (pp - centerP).Normalize();
                    XYZ dir2 = verDir.CrossProduct(XYZ.BasisZ).Normalize();
                    if (dir.IsAlmostEqualTo(dir2, angle) || dir.IsAlmostEqualTo(dir2.Negate(), angle))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private bool IsParallel(XYZ dir, XYZ pPoint, Element elem, double angle)
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
            else if (elem is Railing railing)
            {
                foreach (var curve in railing.GetPath())
                {
                    if (curve is Line line)
                    {
                        XYZ dir2 = line.Direction;
                        if (dir.IsAlmostEqualTo(dir2, angle) || dir.IsAlmostEqualTo(dir2.Negate(), angle))
                        {
                            return true;
                        }
                    }
                    else if (curve is Arc arc)
                    {
                        XYZ pp = arc.Project(pPoint).XYZPoint;
                        XYZ centerP = arc.Center;
                        centerP = new XYZ(centerP.X, centerP.Y, pp.Z);
                        XYZ verDir = (pp - centerP).Normalize();
                        XYZ dir2 = verDir.CrossProduct(XYZ.BasisZ).Normalize();
                        if (dir.IsAlmostEqualTo(dir2, angle) || dir.IsAlmostEqualTo(dir2.Negate(), angle))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
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
                //XYZ p0 = curve.GetEndPoint(0);
                //XYZ p1 = curve.GetEndPoint(1);
                XYZ cP = curve.Evaluate(0.5, true);
                point = new XYZ(point.X, point.Y, cP.Z);
                //if (p0.DistanceTo(point) < scope || p1.DistanceTo(point) < scope || cP.DistanceTo(point) < scope)
                if (curve.Project(point).XYZPoint.DistanceTo(point) < scope)
                    return true;
                return false;
            }
            else if (elem is Railing railing) //UPDATE:26.2.2新增railing的判断
            {
                foreach (var curve in railing.GetPath())
                {
                    XYZ cP = curve.Evaluate(0.5, true);
                    point = new XYZ(point.X, point.Y, cP.Z);
                    if (curve.Project(point).XYZPoint.DistanceTo(point) < scope)
                        return true;
                }
            }
            return false;

        }
    }
}
