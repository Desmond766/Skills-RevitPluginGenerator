using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.Exceptions;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OperationCanceledException = Autodesk.Revit.Exceptions.OperationCanceledException;

namespace AddLightsAccordingToCAD
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        Transform transform = null;
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;

            //CableTray cableTray = doc.GetElement(sel.PickObject(ObjectType.Element)) as CableTray;

            //// 获取元素指定方向的面引用
            //var refers = HostObjectUtils.GetBottomFaces(cableTray);
            //TaskDialog.Show("revit", refers.Count.ToString());
            //using (Transaction t = new Transaction(doc, "更改宿主"))
            //{
            //    t.Start();



            //    t.Commit();
            //}
            //return Result.Succeeded;

            //FamilyInstance familyInstance = doc.GetElement(sel.PickObject(ObjectType.Element)) as FamilyInstance;
            //Transform transform2 = familyInstance.GetTransform();
            //XYZ p = (familyInstance.Location as LocationPoint).Point;
            //XYZ dir = transform2.OfVector(XYZ.BasisX);
            //CableTray cableTray = doc.GetElement(sel.PickObject(ObjectType.Element)) as CableTray;
            //XYZ dir2 = ((cableTray.Location as LocationCurve).Curve as Line).Direction;
            //CableTray cableTray2 = doc.GetElement(sel.PickObject(ObjectType.Element)) as CableTray;
            //TaskDialog.Show("revit", GetLine(cableTray).Project(p).XYZPoint.DistanceTo(p) + "\n" + GetLine(cableTray2).Project(p).XYZPoint.DistanceTo(p));

            //CableTray cableTray3 = doc.GetElement(new ElementId(8961350)) as CableTray;
            //CableTray cableTray4 = doc.GetElement(new ElementId(8960958)) as CableTray;
            //TaskDialog.Show("revit", GetLine(cableTray3).Project(p).XYZPoint.DistanceTo(p) + "\n" + GetLine(cableTray4).Project(p).XYZPoint.DistanceTo(p));
            //return Result.Succeeded;


            MainWindow window = new MainWindow();
            window.ShowDialog();
            if (window.DialogResult == false || window.Cancel)
            {
                return Result.Cancelled;
            }
            double errorValue = Convert.ToDouble(window.tb_dis.Text) / 304.8;
            double angle = (Convert.ToDouble(window.tb_angle.Text) / 180) * Math.PI;

            //Reference reference;
            //try
            //{
            //    reference = sel.PickObject(ObjectType.PointOnElement);
            //}
            //catch (OperationCanceledException)
            //{
            //    TaskDialog.Show("Revit", "已取消操作");
            //    return Result.Cancelled;
            //}
            //Element dwg = doc.GetElement(reference);
            //ImportInstance importInstance = dwg as ImportInstance;
            //transform = importInstance.GetTransform();
            //List<GeometryInstance> instances = Command.GetAllGeometryInstanceInCAD(dwg);
            List<GeometryInstance> instances = null;
            using (Transaction t = new Transaction(doc, "灯具位置调整"))
            {
                t.Start();

                MoveLights(instances, doc, errorValue, angle);

                t.Commit();
            }


            return Result.Succeeded;
        }

        private void MoveLights(List<GeometryInstance> instances, Document doc, double errorValue, double angle)
        {
            var lights = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_LightingFixtures).OfClass(typeof(FamilyInstance)).Cast<FamilyInstance>().Where(x => x.Name.Contains("单管荧光灯"));
            var cableTrays = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_CableTray).OfClass(typeof(CableTray));
            // 获取GeometryInstance与Line的对应关系
            //List<CADLightInfo> infos = GetLightInfo(instances);
            foreach (var light in lights)
            {
                XYZ lightPoint = (light.Location as LocationPoint).Point;
                Transform lightTransform = light.GetTransform();
                XYZ lightDir = lightTransform.OfVector(XYZ.BasisX);

                var cableTray = cableTrays.Where(x => IsParallel(lightDir, x, angle) && InDistance(lightPoint, x, errorValue))
                    .OrderBy(t => GetLine(t, out double centerZ).Project(new XYZ(lightPoint.X, lightPoint.Y, centerZ)).XYZPoint.DistanceTo(new XYZ(lightPoint.X, lightPoint.Y, centerZ))).FirstOrDefault();

                if (cableTray == null) continue;

                Line line = GetLine(cableTray);

                // 旋转灯具使其与桥架平行
                RotateLight(line, light, doc);
                // 获取旋转后的灯具的坐标点
                lightPoint = (light.Location as LocationPoint).Point;
                //continue;

                double Z = cableTray.get_BoundingBox(null).Min.Z;
                line.MakeUnbound();

                XYZ pp = line.Project(lightPoint).XYZPoint;

                pp = new XYZ(pp.X, pp.Y, Z);
                XYZ moveDir = (pp - lightPoint).Normalize();
                double moveDis = pp.DistanceTo(lightPoint);

                /*if (new XYZ(pp.X, pp.Y, 0).DistanceTo(new XYZ(lightPoint.X, lightPoint.Y, 0)) > 10 / 304.8)*/ light.Location.Move(moveDir * moveDis);
            }
        }

        /// <summary>
        /// 旋转灯具使其与桥架平行
        /// </summary>
        /// <param name="line">桥架的线</param>
        /// <param name="light">灯具</param>
        /// <exception cref="NotImplementedException"></exception>
        private void RotateLight(Line line, FamilyInstance light, Document doc)
        {
            //XYZ lightPoint = (light.Location as LocationPoint).Point;
            XYZ lightPoint = light.get_BoundingBox(null).Max.Add(light.get_BoundingBox(null).Min) / 2;
            Transform lightTransform = light.GetTransform();
            XYZ lightDir = lightTransform.OfVector(XYZ.BasisX);

            XYZ cableTrayDir = line.Direction;

            double angle = lightDir.AngleTo(cableTrayDir);
            double angle90 = 90 / 180 * Math.PI;
            if (angle > angle90) angle -= angle90;

            // 误差小于1度时不进行旋转
            if (angle < 0.0175 || Math.Abs(Math.PI - angle) < 0.0175) return;

            ElementTransformUtils.RotateElement(doc, light.Id, Line.CreateBound(lightPoint, lightPoint + XYZ.BasisZ), angle);

            XYZ newLightDir = light.GetTransform().OfVector(XYZ.BasisX);
            if (!(newLightDir.IsAlmostEqualTo(cableTrayDir) || newLightDir.IsAlmostEqualTo(cableTrayDir.Negate())))
            {
                ElementTransformUtils.RotateElement(doc, light.Id, Line.CreateBound(lightPoint, lightPoint + XYZ.BasisZ), -2 * angle);
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
                //XYZ p0 = curve.GetEndPoint(0);
                //XYZ p1 = curve.GetEndPoint(1);
                XYZ cP = curve.Evaluate(0.5, true);
                point = new XYZ(point.X, point.Y, cP.Z);
                //if (p0.DistanceTo(point) < scope || p1.DistanceTo(point) < scope || cP.DistanceTo(point) < scope)
                if (curve.Project(point).XYZPoint.DistanceTo(point) < scope)
                    return true;
                return false;
            }
            return false;

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

        private List<CADLightInfo> GetLightInfo(List<GeometryInstance> instances)
        {
            var lightInfos = new List<CADLightInfo>();
            foreach (var geometryInstance in instances)
            {
                double maxLength = double.MinValue;
                Line lightLine = null;
                foreach (GeometryObject item in geometryInstance.GetSymbolGeometry())
                {
                    if (item is Line line && line.Length > maxLength)
                    {
                        maxLength = line.Length;
                        lightLine = line;
                    }
                }
                if (lightLine != null) lightInfos.Add(new CADLightInfo() { CADLight = geometryInstance, Line = lightLine });
            }
            return lightInfos;
        }
    }

    public class CADLightInfo
    {
        public GeometryInstance CADLight { get; set; }
        public Line Line { get; set; }
    }
}
