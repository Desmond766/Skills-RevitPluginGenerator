using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.Exceptions;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using OperationCanceledException = Autodesk.Revit.Exceptions.OperationCanceledException;
using Point = Autodesk.Revit.DB.Point;

namespace RampArrowParallelFloor
{
    // 阵列坡道箭头平行于楼板
    [Transaction(TransactionMode.Manual)]
    public class Command3 : IExternalCommand
    {
        [DllImport("user32.dll")]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndlnsertAfter, int X, int Y, int cx, int cy, uint Flags);

        [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "SetForegroundWindow")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;


            FamilySymbol familySymbol = new FilteredElementCollector(doc).WhereElementIsElementType().OfCategory(BuiltInCategory.OST_GenericModel).Where(f => f is FamilySymbol).Cast<FamilySymbol>()
                .FirstOrDefault(f => f.Name.Contains("坡道箭头"));
            if (familySymbol == null)
            {
                return Result.Cancelled;
            }

            var lineRefer = sel.PickObject(ObjectType.Element);
            Line line1 = null;
            Element lineElem = doc.GetElement(lineRefer);
            line1 = (lineElem.Location as LocationCurve).Curve as Line;

            var refer2 = sel.PickObject(ObjectType.Face);
            Element element = doc.GetElement(refer2);
            Face face1 = element.GetGeometryObjectFromReference(refer2) as Face;
            Face finalFace = null;

            // 创建几何选项，并开启引用计算
            Options geomOptions = new Options
            {
                ComputeReferences = true, // 这是解决此问题的关键！
                DetailLevel = ViewDetailLevel.Fine, // 建议设置所需的详细程度
                IncludeNonVisibleObjects = false // 根据需求决定是否包含不可见对象
            };

            // 获取元素的几何图形
            GeometryElement geometryElement = element.get_Geometry(geomOptions);

            // 遍历几何图形以找到所需的面 (Face)
            foreach (GeometryObject geomObj in geometryElement)
            {
                Solid solid = geomObj as Solid;
                if (solid != null && solid.Volume > 0)
                {
                    foreach (Face face2 in solid.Faces)
                    {
                        // 现在，face.Reference 不再是 null
                        Reference faceRef = face2.Reference;
                        if (faceRef.ConvertToStableRepresentation(doc) == refer2.ConvertToStableRepresentation(doc))
                        {
                            finalFace = face2;
                            break;
                        }
                    }
                }
            }

            List<ElementId> ids = new List<ElementId>();
            using (Transaction t = new Transaction(doc, "生成坡道箭头"))
            {
                t.Start();

                if (!familySymbol.IsActive)
                {
                    familySymbol.Activate();
                }

                XYZ p0 = line1.GetEndPoint(0);
                XYZ lineDir1 = line1.Direction;
                for (int i = 0; i < 5; i++)
                {
                    doc.Create.NewFamilyInstance(finalFace, p0, lineDir1.Negate(), familySymbol);
                    p0 = p0 + lineDir1 * (3000 / 304.8);
                }

                //ElementId elementId = doc.Create.NewFamilyInstance(finalFace, refer2.GlobalPoint, (finalFace as PlanarFace).XVector, familySymbol).Id;

                t.Commit();
            }

            return Result.Succeeded;

            //View3D view3D;
            //if (doc.ActiveView is View3D)
            //{
            //    view3D = doc.ActiveView as View3D;
            //}
            //else
            //{
            //    TaskDialog.Show("提示", "需在三维视图中运行此插件");
            //    return Result.Cancelled;
            //}
            ViewSection viewSection;
            if (doc.ActiveView is ViewSection)
            {
                viewSection = doc.ActiveView as ViewSection;
            }
            else
            {
                TaskDialog.Show("提示", "需在剖面视图中运行此插件");
                return Result.Cancelled;
            }
            XYZ viewDir = viewSection.ViewDirection;

            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();
            if (mainWindow.DialogResult == false)
            {
                return Result.Cancelled;
            }
            double distance = Properties.Settings.Default.Distance / 304.8;

            TipWindow tip = new TipWindow("框选坡道箭头");
            SetWindowPos(tip, uidoc);
            IList<Reference> references;
            try
            {
                references = sel.PickObjects(ObjectType.Element, new ArrowFilter());
            }
            catch (OperationCanceledException)
            {
                tip.Close();
                return Result.Cancelled;
            }
            tip.Close();
            TipWindow tip1 = new TipWindow("选择楼板面上的两点");
            SetWindowPos(tip1, uidoc);

            IntPtr revitIntPtr = commandData.Application.MainWindowHandle;
            SetForegroundWindow(revitIntPtr);

            XYZ p1;
            XYZ p2;
            try
            {
                p1 = sel.PickPoint("选择第一个坐标点");
                p2 = sel.PickPoint("选择第二个坐标点");
            }
            catch (OperationCanceledException)
            {
                tip1.Close();
                return Result.Cancelled;
            }
            tip1.Close();

            Line line = Line.CreateBound(p1, p2);
            XYZ lineDir = line.Direction;

            using (Transaction t = new Transaction(doc, "坡道箭头平行楼板"))
            {
                t.Start();

                foreach (var refer in references)
                {
                    Element elem = doc.GetElement(refer);
                    if (!elem.Name.Contains("坡道箭头")) continue;
                    FamilyInstance familyInstance = elem as FamilyInstance;
                    XYZ elemPoint = (familyInstance.Location as LocationPoint).Point;

                    //TaskDialog.Show("revit", p1 + "\n" + p2 + "\n" + elemPoint);
                    //TaskDialog.Show("revit", familyInstance.GetTransform().OfVector(XYZ.BasisX).AngleTo(viewSection.RightDirection).ToString());
                    //break;

                    Transform transform = familyInstance.GetTransform();
                    XYZ elemDir = transform.OfVector(XYZ.BasisX);
                    double angle = lineDir.AngleTo(elemDir);
                    if (angle > 45 / 180.0 * Math.PI)
                    {
                        angle = lineDir.Negate().AngleTo(elemDir);
                    }
                    ElementTransformUtils.RotateElement(doc, elem.Id, Line.CreateBound(elemPoint, elemPoint + viewDir), angle);

                    if (!familyInstance.GetTransform().OfVector(XYZ.BasisX).IsAlmostEqualTo(lineDir, 0.0001) && !familyInstance.GetTransform().OfVector(XYZ.BasisX).IsAlmostEqualTo(lineDir.Negate(), 0.0001))
                    {
                        ElementTransformUtils.RotateElement(doc, elem.Id, Line.CreateBound(elemPoint, elemPoint + viewDir), -angle * 2);
                    }
                    // 25.8.15 旋转后移动元素使其在正确高度
                    /*XYZ newPoint = (elem.Location as LocationPoint).Point;
                    Plane plane = Plane.CreateByOriginAndBasis(p1, lineDir, viewDir);
                    XYZ pp = ProjectPointToPlane(plane, newPoint);
                    //TaskDialog.Show("rev", (newPoint.DistanceTo(pp)*304.8).ToString() + "\n" + pp + "\n" + newPoint +"\n" );
                    familyInstance.Location.Move((distance - newPoint.DistanceTo(pp)) * XYZ.BasisZ);
                    */
                    
                    XYZ newDir = familyInstance.GetTransform().OfVector(XYZ.BasisX);
                    XYZ verDir = newDir.CrossProduct(viewSection.ViewDirection);
                    if (verDir.AngleTo(viewSection.UpDirection) > verDir.AngleTo(viewSection.UpDirection.Negate())) verDir = verDir.Negate();

                    XYZ newPoint = (elem.Location as LocationPoint).Point;
                    Plane plane = Plane.CreateByOriginAndBasis(p1, lineDir, viewDir);
                    XYZ pp = ProjectPointToPlane(plane, newPoint);

                    if (familyInstance.GetTransform().OfVector(XYZ.BasisX).AngleTo(viewSection.RightDirection) > familyInstance.GetTransform().OfVector(XYZ.BasisX).AngleTo(viewSection.RightDirection.Negate())) distance += 900 / 304.8;
                    familyInstance.Location.Move((distance - newPoint.DistanceTo(pp)) * verDir);
                    

                }

                t.Commit();
            }
            return Result.Succeeded;
            foreach (var item in references)
            {
                var fami = doc.GetElement(item) as FamilyInstance;
                XYZ dir = fami.GetTransform().OfVector(XYZ.BasisX).CrossProduct(viewSection.ViewDirection);
                TaskDialog.Show("dsd", fami.GetTransform().OfVector(XYZ.BasisX).AngleTo(viewSection.RightDirection) + "\n" + fami.GetTransform().OfVector(XYZ.BasisX).AngleTo(viewSection.RightDirection.Negate()));
            }

            return Result.Succeeded;

            TipWindow tipWindow = new TipWindow("选择一个坡道箭头阵列组");
            //tipWindow.Show();
            // 设置提示窗口正确的长度与位置
            SetWindowPos(tipWindow, uidoc);

            Reference reference; 
            try
            {
                reference = sel.PickObject(ObjectType.Element, new GroupFilter(), "选择一个坡道箭头阵列组");
            }
            catch (OperationCanceledException)
            {
                tipWindow.Close();
                return Result.Cancelled;
            }
            tipWindow.Close();

            TipWindow tipWindow2 = new TipWindow("选择链接模型楼板上的一个面");
            SetWindowPos(tipWindow2, uidoc);
            Reference linkReference;
            try
            {
                linkReference = sel.PickObject(ObjectType.PointOnElement, new LinkFaceFilter(doc), "选择链接模型楼板上的一个面");
            }
            catch (OperationCanceledException)
            {
                tipWindow2.Close();
                return Result.Cancelled;
            }
            tipWindow2.Close();

            RevitLinkInstance linkInstance = doc.GetElement(linkReference) as RevitLinkInstance;
            Document linkDoc = linkInstance.GetLinkDocument();
            Element linkElem = linkDoc.GetElement(linkReference.LinkedElementId);

            Reference linkRef = linkReference.CreateReferenceInLink();
            Face face = linkElem.GetGeometryObjectFromReference(linkRef) as Face;

            Group group = doc.GetElement(reference) as Group;
            GroupType groupType = group.GroupType;
            var groupSet = groupType.Groups;
            if (groupSet.Size < 2)
            {
                return Result.Cancelled;
            }
            Group originalGroup = groupSet.Cast<Group>().First();
            Group lastGroup = groupSet.Cast<Group>().Last();

            using (Transaction t = new Transaction(doc, "坡道箭头平行楼板"))
            {
                t.Start();

                //ReferenceIntersector intersector = new ReferenceIntersector(new ElementId[] { linkInstance.Id }, FindReferenceTarget.Element, view3D);
                //intersector.FindReferencesInRevitLinks = true;
                FamilyInstance familyInstance = doc.GetElement(originalGroup.GetMemberIds().First()) as FamilyInstance;
                XYZ point = (familyInstance.Location as LocationPoint).Point;
                point = familyInstance.get_BoundingBox(null).Min;
                var result = face.Project(point);
                if (result != null)
                {
                    double dis = result.Distance;
                    XYZ pp = result.XYZPoint;
                    XYZ faceDir = (point - pp).Normalize();
                    //faceDir = new XYZ(0, 0, faceDir.Z);
                    faceDir = face.ComputeNormal(result.UVPoint).Normalize();
                    if (pp.Z > point.Z)
                    {
                        dis = -dis;
                        //faceDir = -faceDir;
                    }
                    //TaskDialog.Show("revit", (distance * 304.8)+ "\n" + (dis*304.8) + "\n" + (faceDir * (distance - dis)*304.8) + "\n" + ((faceDir * (distance - dis)).DotProduct(XYZ.BasisZ)*304.8) + "\n" + (point.Z * 304.8)+"\n"+(pp.Z * 304.8)+"\n"+linkElem.Id);
                    originalGroup.Location.Move((faceDir * (distance - dis)).DotProduct(XYZ.BasisZ) * XYZ.BasisZ);
                }

                XYZ point2 = ((doc.GetElement(lastGroup.GetMemberIds().First())).Location as LocationPoint).Point;
                point2 = (doc.GetElement(lastGroup.GetMemberIds().First())).get_BoundingBox(null).Min;
                var result2 = face.Project(point2);
                if (result2 != null)
                {
                    double dis = result2.Distance;
                    XYZ pp2 = result2.XYZPoint;
                    XYZ faceDir2 = (point2 - pp2).Normalize();
                    //faceDir2 = new XYZ(0, 0, faceDir2.Z);
                    faceDir2 = face.ComputeNormal(result2.UVPoint).Normalize();
                    // 获取该向量 * 距离在xyz.z方向上的投影
                    if (pp2.Z > point2.Z)
                    {
                        dis = -dis;
                        //faceDir2 = -faceDir2;
                    }

                    lastGroup.Location.Move((faceDir2 * (distance - dis)).DotProduct(XYZ.BasisZ) * XYZ.BasisZ);
                }
                //var withContexts = intersector.Find(point, XYZ.BasisZ.Negate());
                //var withContext = withContexts.FirstOrDefault(w => w.GetReference().LinkedElementId.Equals(linkElem.Id));
                //if (withContext != null)
                //{
                //    try
                //    {
                //        Reference faceReference = withContext.GetReference();
                //        Reference linkFaceReference = faceReference.CreateReferenceInLink();
                //        Face findFace = linkElem.GetGeometryObjectFromReference(linkFaceReference) as Face;

                //        var result = findFace.Project(point);
                //        if (result != null)
                //        {
                //            double dis = result.Distance;
                //            originalGroup.Location.Move(XYZ.BasisZ * (1000 / 304.8 - dis));
                //        }
                //    }
                //    catch (Exception ex)
                //    {
                //        TaskDialog.Show("revit", ex.Message);
                //    }

                //}



                t.Commit();
            }

            return Result.Succeeded;

            ReferenceIntersector ri = new ReferenceIntersector(new ElementId[] { linkInstance.Id}, FindReferenceTarget.Element, doc.ActiveView as View3D);
            ri.FindReferencesInRevitLinks = true;
            var rws = ri.Find(originalGroup.get_BoundingBox(null).Min, XYZ.BasisZ.Negate());
            var rws2 = ri.Find(lastGroup.get_BoundingBox(null).Min, XYZ.BasisZ.Negate());

            using (Transaction t = new Transaction(doc, "坡道箭头平行楼板"))
            {
                t.Start();

                var rw = rws.FirstOrDefault(r => r.GetReference().LinkedElementId.Equals(linkElem.Id));
                if (rw != null)
                {
                    //TaskDialog.Show("re", linkDoc.GetElement(rw.GetReference().LinkedElementId).Category.Name + "\n" + linkDoc.GetElement(rw.GetReference().LinkedElementId).Name + "\n" + rw.GetReference().LinkedElementId + "\n" + linkElem.Id);
                    double dis = rw.GetReference().GlobalPoint.DistanceTo(originalGroup.get_BoundingBox(null).Min);
                    originalGroup.Location.Move(XYZ.BasisZ * (UnitUtils.ConvertToInternalUnits(1000, DisplayUnitType.DUT_MILLIMETERS) - dis));
                    //TaskDialog.Show("revit", UnitUtils.ConvertToInternalUnits(1000, DisplayUnitType.DUT_MILLIMETERS) + "\n" + dis +"\n"+ (UnitUtils.ConvertToInternalUnits(1000, DisplayUnitType.DUT_MILLIMETERS) - dis));
                }
                var rw2 = rws2.FirstOrDefault(r => r.GetReference().LinkedElementId.Equals(linkElem.Id));
                if (rw2 != null)
                {
                    //TaskDialog.Show("re", linkDoc.GetElement(rw2.GetReference().LinkedElementId).Category.Name + "\n" + linkDoc.GetElement(rw2.GetReference().LinkedElementId).Name + "\n" + rw2.GetReference().LinkedElementId + "\n" + linkElem.Id);
                    double dis = rw2.GetReference().GlobalPoint.DistanceTo(lastGroup.get_BoundingBox(null).Min);
                    lastGroup.Location.Move(XYZ.BasisZ * (1000 / 304.8 - dis));
                }

                //originalGroup.Location.Move(XYZ.BasisZ * (500 / 304.8));
                //lastGroup.Location.Move(XYZ.BasisZ * (-500 / 304.8));

                t.Commit();
            }

            return Result.Succeeded;
        }
        private XYZ ProjectPointToPlane(Plane plane, XYZ point)
        {
            Transform tf = Transform.CreateTranslation(plane.Origin);
            tf.BasisX = plane.XVec;
            tf.BasisY = plane.YVec;
            tf.BasisZ = plane.Normal;

            XYZ localPt = tf.Inverse.OfPoint(point);
            return tf.OfPoint(new XYZ(localPt.X, localPt.Y, 0));
        }

        private bool SetWindowPos(Window tipWindow, UIDocument uidoc)
        {
            WindowInteropHelper windowInterop = new WindowInteropHelper(tipWindow);
            IntPtr showHandle = windowInterop.Handle;

            Autodesk.Revit.DB.Rectangle revitRectangle = GetActiveViewRectangle(uidoc);

            if (revitRectangle != null)
            {
                int statusBarWidth = revitRectangle.Right - revitRectangle.Left;
                bool res = SetWindowPos(showHandle, IntPtr.Zero, revitRectangle.Left, revitRectangle.Top, statusBarWidth, Convert.ToInt32(tipWindow.Height), 0x0040);
                return res;
            }
            return false;
        }
        public Autodesk.Revit.DB.Rectangle GetActiveViewRectangle(UIDocument uiDoc)
        {
            // 获取当前活动视图
            View activeView = uiDoc.ActiveView;

            // 遍历所有打开的UI视图
            foreach (UIView uiView in uiDoc.GetOpenUIViews())
            {
                // 匹配当前活动视图的ID
                if (uiView.ViewId == activeView.Id)
                {
                    // 直接获取视图窗口句柄
                    return uiView.GetWindowRectangle();
                }
            }
            return null; // 未找到返回空句柄
        }
    }
    public class ArrowFilter : ISelectionFilter
    {
        public bool AllowElement(Element elem)
        {
            if (elem is FamilyInstance familyInstance && familyInstance.Name.Contains("坡道箭头") && elem.Category.Id.IntegerValue == -2000151)
            {
                return true;
            }return false;
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            return false;
        }
    }

    public class GroupFilter : ISelectionFilter
    {
        public bool AllowElement(Element elem)
        {
            if (elem is Group)
            {
                return true;
            }return false;
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            throw new NotImplementedException();
        }
    }
    public class LinkFaceFilter : ISelectionFilter
    {
        readonly Document Doc;
        public LinkFaceFilter(Document doc)
        {
            Doc = doc;
        }
        public bool AllowElement(Element elem)
        {
            return true;
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            Element element = Doc.GetElement(reference);
            if (element is RevitLinkInstance linkInstance)
            {
                Document linkDoc = linkInstance.GetLinkDocument();
                var selectElem = linkDoc.GetElement(reference.LinkedElementId);

                Reference linkReference = reference.CreateReferenceInLink();
                var geo = selectElem.GetGeometryObjectFromReference(linkReference);
                if (geo is Face face/* && face.FaceNormal.AngleTo(XYZ.BasisZ) < 1.57*/) // 平面的法向量与Z轴正方向夹角小于90度
                {
                    return true;
                }
            }
            return false;
        }
    }
}
