# Sample Snippet: AddLightsAccordingToCAD

Source project: `existingCodes\梁涛插件源代码\2.机电建模及算量\AddLightsAccordingToCAD\AddLightsAccordingToCAD`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
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
// ... truncated ...
```

## Command2.cs

```csharp
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

// TODO:LT:改为创建灯具或修改灯具所在位置 24.12.19

namespace AddLightsAccordingToCAD
{
    [Transaction(TransactionMode.Manual)]
    public class Command2 : IExternalCommand
    {
        UIDocument uiDoc = null;
        Document doc = null;
        Transform transform = null;
        View3D view3D = null;
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            uiDoc = commandData.Application.ActiveUIDocument;
            doc = uiDoc.Document;

            //程序在3D 支吊架视图中完成
            //改为
            //先找当前视图 对应的3D视图， 找不到再用3D 支吊架，命名规则 3D {当前视图名称}
            View3D default3Dview = null;
            View3D target3Dview = null;
            FilteredElementCollector fristCollector = new FilteredElementCollector(doc).OfClass(typeof(View3D));
            foreach (View3D view3 in fristCollector)
            {
                if ("3D 机电".Equals(view3.Name))
                {
                    default3Dview = view3;
                }
                if (string.Format("3D {0}", doc.ActiveView.Name).Equals(view3.Name))
                {
                    target3Dview = view3;
                }
            }
            if (null != target3Dview)
            {
                view3D = target3Dview;
            }
            else
            {
                if (null != default3Dview)
                {
                    view3D = default3Dview;
                }
                else
                {
                    message = string.Format("未找到3D视图： 3D 机电 或 3D {0}", doc.ActiveView.Name);
                    return Result.Cancelled;
                }
            }

            Reference reference = uiDoc.Selection.PickObject(ObjectType.PointOnElement);
            Element dwg = doc.GetElement(reference);
            ImportInstance importInstance = dwg as ImportInstance;
            transform = importInstance.GetTransform();
            List<GeometryInstance> instances = GetAllGeometryInstanceInCAD(dwg);
            using (Transaction trans = new Transaction(doc, "Add Lights"))
            {
                trans.Start();
                CreateInstances(instances);
                trans.Commit();
            }
            return Result.Succeeded;
        }
        public static List<GeometryInstance> GetAllGeometryInstanceInCAD(Element dwg)
        {
            List<GeometryInstance> result = new List<GeometryInstance>();
            foreach (GeometryObject item in dwg.get_Geometry(new Options()))
            {
                if (item is GeometryInstance dwgInstance)
                {
                    foreach (GeometryObject item2 in dwgInstance.GetSymbolGeometry())
                    {
                        if (item2 is GeometryInstance geometryInstance)
                        {
                            result.Add(geometryInstance);
                        }
                    }
                }
// ... truncated ...
```

