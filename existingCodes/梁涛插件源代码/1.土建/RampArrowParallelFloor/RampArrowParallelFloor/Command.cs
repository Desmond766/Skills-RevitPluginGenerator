using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.Exceptions;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using System.Xml.Linq;
using FileNotFoundException = System.IO.FileNotFoundException;
using OperationCanceledException = Autodesk.Revit.Exceptions.OperationCanceledException;
using Point = Autodesk.Revit.DB.Point;

namespace RampArrowParallelFloor
{
    // 阵列坡道箭头平行于楼板
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
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
                try
                {
                    LoadFamily(doc, Resource1.坡道箭头, "坡道箭头");
                }
                catch (Exception)
                {

                }
                familySymbol = new FilteredElementCollector(doc).WhereElementIsElementType().OfCategory(BuiltInCategory.OST_GenericModel).Where(f => f is FamilySymbol).Cast<FamilySymbol>()
                .FirstOrDefault(f => f.Name.Contains("坡道箭头"));
                if (familySymbol == null)
                {
                    //TaskDialog.Show("提示", " 未找到族类型: '坡道箭头'");
                    MessageBox.Show("未找到族类型: '坡道箭头'");
                    return Result.Cancelled;
                }
            }

            //return Result.Succeeded;

            TipWindow tipWindow = new TipWindow("选择模型线或元素边线");
            SetWindowPos(tipWindow, uidoc);

            Reference lineRefer;
            try
            {
                lineRefer = sel.PickObject(ObjectType.PointOnElement, new LineFilter(doc), "选择模型线或元素边线");
            }
            catch (Exception)
            {
                MessageBox.Show("已取消操作");
                tipWindow.Close();
                return Result.Cancelled;
            }

            Line line = null;
            Element lineElem = doc.GetElement(lineRefer);
            if (lineElem is ModelLine)
            {
                line = (lineElem.Location as LocationCurve).Curve as Line;
            }
            else if (lineElem is RevitLinkInstance linkInstance)
            {
                Document linkDoc = linkInstance.GetLinkDocument();
                Element linkElem = linkDoc.GetElement(lineRefer.LinkedElementId);
                Reference linkRefer = lineRefer.CreateReferenceInLink();
                GeometryObject linkGeo = linkElem.GetGeometryObjectFromReference(linkRefer);
                if (linkGeo is Edge edge)
                {
                    line = edge.AsCurve() as Line;
                }
                else
                {
                    line = linkGeo as Line;
                }
            }
            else
            {
                var geo = lineElem.GetGeometryObjectFromReference(lineRefer);
                if (geo is Edge edge)
                {
                    line = edge.AsCurve() as Line;
                }
                else
                {
                    line = geo as Line;
                }
            }

            XYZ lineDir = line.Direction;

            Reference faceRefer;
            try
            {
                tipWindow.lb_tip.Content = "选择一个面作为坡道箭头放置面";
                faceRefer = sel.PickObject(ObjectType.Face, new PlanarFaceFilter(doc), "选择一个面作为坡道箭头放置面");
            }
            catch (Exception)
            {
                MessageBox.Show("已取消操作");
                tipWindow.Close();
                return Result.Cancelled;
            }
            tipWindow.Close();

            Element element = doc.GetElement(faceRefer);
            Face face = element.GetGeometryObjectFromReference(faceRefer) as Face;
            PlanarFace finalFace = null;

            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();
            if (mainWindow.DialogResult == false)
            {
                return Result.Cancelled;
            }
            double space = Properties.Settings.Default.Space / 304.8;
            space += 850 / 304.8;

            bool oppositeDir = Properties.Settings.Default.OppositeDirection;
            oppositeDir = false;

            // 创建几何选项，并开启引用计算
            Options geomOptions = new Options
            {
                ComputeReferences = true,
                DetailLevel = ViewDetailLevel.Fine,
                IncludeNonVisibleObjects = false
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
                        Reference refer = face2.Reference;
                        if (refer.ConvertToStableRepresentation(doc) == faceRefer.ConvertToStableRepresentation(doc))
                        {
                            finalFace = face2 as PlanarFace;
                            break;
                        }
                    }
                }
            }

            List<ElementId> ids = new List<ElementId>();

            TransactionGroup TG = new TransactionGroup(doc, "坡道箭头平行楼板");
            TG.Start();
            using (Transaction t = new Transaction(doc, "生成坡道箭头"))
            {
                t.Start();

                if (!familySymbol.IsActive)
                {
                    familySymbol.Activate();
                }

                XYZ p0 = line.GetEndPoint(0);
                int count = (int)((line.Length - (325 / 304.8)) / space);
                for (int i = 0; i <= count; i++)
                {
                    if (i == 0) p0 += lineDir * (325 / 304.8); // 坡道箭头末端到创建点距离
                    ElementId id = doc.Create.NewFamilyInstance(finalFace, p0, lineDir, familySymbol).Id;

                    ids.Add(id);
                    p0 += lineDir * space;
                }

                //ElementId elementId = doc.Create.NewFamilyInstance(finalFace, refer2.GlobalPoint, (finalFace as PlanarFace).XVector, familySymbol).Id;

                t.Commit();
            }
            using (Transaction t = new Transaction(doc, "旋转"))
            {
                t.Start();
                foreach (var id in ids)
                {
                    FamilyInstance familyInstance = doc.GetElement(id) as FamilyInstance;
                    XYZ elemUpDir = familyInstance.GetTransform().OfVector(XYZ.BasisY);
                    XYZ elemPoint = (familyInstance.Location as LocationPoint).Point;
                    XYZ upMaxPoint = elemPoint + elemUpDir * (900 / 304.8);
                    // 使坡道箭头创建坐标点在视图中相对于元素在底部
                    if (elemPoint.Z > upMaxPoint.Z) ElementTransformUtils.RotateElement(doc, id, Line.CreateBound(elemPoint, elemPoint + familyInstance.GetTransform().OfVector(XYZ.BasisZ)), Math.PI);
                }

                t.Commit();
            }

            //TG.Assimilate();
            //return Result.Succeeded;

            #region code1
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

            //ViewSection viewSection;
            //if (doc.ActiveView is ViewSection)
            //{
            //    viewSection = doc.ActiveView as ViewSection;
            //}
            //else
            //{
            //    TaskDialog.Show("提示", "需在剖面视图中运行此插件");
            //    return Result.Cancelled;
            //}
            //XYZ viewDir = viewSection.ViewDirection;
            #endregion


            #region code2
            //TipWindow tip = new TipWindow("框选坡道箭头");
            //SetWindowPos(tip, uidoc);
            //IList<Reference> references;
            //try
            //{
            //    references = sel.PickObjects(ObjectType.Element, new ArrowFilter());
            //}
            //catch (OperationCanceledException)
            //{
            //    tip.Close();
            //    return Result.Cancelled;
            //}
            //tip.Close();
            //TipWindow tip1 = new TipWindow("选择楼板面上的两点");
            //SetWindowPos(tip1, uidoc);

            //IntPtr revitIntPtr = commandData.Application.MainWindowHandle;
            //SetForegroundWindow(revitIntPtr);

            //XYZ p1;
            //XYZ p2;
            //try
            //{
            //    p1 = sel.PickPoint("选择第一个坐标点");
            //    p2 = sel.PickPoint("选择第二个坐标点");
            //}
            //catch (OperationCanceledException)
            //{
            //    tip1.Close();
            //    return Result.Cancelled;
            //}
            //tip1.Close();
            #endregion

            //Line line = line1;
            //XYZ lineDir = line.Direction;
            XYZ viewDir = (finalFace).FaceNormal;
            XYZ viewRightSection = (finalFace).XVector;
            XYZ viewUpSection = (finalFace).YVector;

            using (Transaction t = new Transaction(doc, "坡道箭头平行楼板"))
            {
                t.Start();

                foreach (var id in ids)
                {
                    double distance = Properties.Settings.Default.Distance / 304.8;

                    Element elem = doc.GetElement(id) as FamilyInstance;
                    XYZ elemPoint = (elem.Location as LocationPoint).Point;

                    FamilyInstance familyInstance = elem as FamilyInstance;
                    XYZ elemUpDir = familyInstance.GetTransform().OfVector(XYZ.BasisY);
                    XYZ elemViewDir = familyInstance.GetTransform().OfVector(XYZ.BasisZ);

                    XYZ elemUpPoint = elemPoint + elemUpDir * (900 / 304.8);
                    XYZ elemCenterPoint = elemPoint.Add(elemUpPoint) / 2;
                    if (oppositeDir)
                    {
                        ElementTransformUtils.RotateElement(doc, id, Line.CreateBound(elemCenterPoint, elemCenterPoint + elemViewDir), Math.PI);
                        // 若旋转，则元素坐标点较元素在最高点
                        //familyInstance.Location.Move(distance * familyInstance.GetTransform().OfVector(XYZ.BasisY.Negate()));
                        familyInstance.Location.Move(distance * elemUpDir);
                    }
                    else
                    {
                        // 未旋转时，元素坐标点较元素在最低点
                        //familyInstance.Location.Move(distance * familyInstance.GetTransform().OfVector(XYZ.BasisY));
                        familyInstance.Location.Move(distance * elemUpDir);
                    }



                    #region code3
                    //Transform transform = familyInstance.GetTransform();
                    //XYZ elemDir = transform.OfVector(XYZ.BasisX);
                    //double angle = lineDir.AngleTo(elemDir);
                    //if (angle > 45 / 180.0 * Math.PI)
                    //{
                    //    angle = lineDir.Negate().AngleTo(elemDir);
                    //}
                    //ElementTransformUtils.RotateElement(doc, elem.Id, Line.CreateBound(elemPoint, elemPoint + viewDir), angle);

                    //if (!familyInstance.GetTransform().OfVector(XYZ.BasisX).IsAlmostEqualTo(lineDir, 0.0001) && !familyInstance.GetTransform().OfVector(XYZ.BasisX).IsAlmostEqualTo(lineDir.Negate(), 0.0001))
                    //{
                    //    ElementTransformUtils.RotateElement(doc, elem.Id, Line.CreateBound(elemPoint, elemPoint + viewDir), -angle * 2);
                    //}
                    #endregion

                    #region code4
                    //XYZ newDir = familyInstance.GetTransform().OfVector(XYZ.BasisX);
                    //XYZ verDir = newDir.CrossProduct(viewDir);
                    //if (verDir.AngleTo(viewRightSection) > verDir.AngleTo(viewUpSection.Negate())) verDir = verDir.Negate();

                    //XYZ newPoint = (elem.Location as LocationPoint).Point;
                    //Plane plane = Plane.CreateByOriginAndBasis(lineRefer.GlobalPoint, lineDir, viewDir);
                    //XYZ pp = ProjectPointToPlane(plane, newPoint);

                    // FINISH：对于是否增加900mm的判断25.10.13
                    //if (familyInstance.GetTransform().OfVector(XYZ.BasisX).AngleTo(viewRightSection) > familyInstance.GetTransform().OfVector(XYZ.BasisX).AngleTo(viewRightSection.Negate())) distance += 900 / 304.8;

                    // HACK: 待修改：判断逻辑有问题 25.10.16
                    //if (familyInstance.GetTransform().OfVector(XYZ.BasisX).AngleTo(viewRightSection) > familyInstance.GetTransform().OfVector(XYZ.BasisX).AngleTo(viewRightSection.Negate())) distance += 900 / 304.8;
                    //familyInstance.Location.Move((distance - newPoint.DistanceTo(pp)) * verDir);
                    #endregion

                }

                t.Commit();
            }

            List<ElementId> showIds = new List<ElementId>();
            showIds = ids.Select(i => i).ToList();
            showIds.Add(lineElem.Id);
            showIds.Add(element.Id);

            ViewSection viewSection = CreateViewSection(doc, element, finalFace, showIds);
            PreviewWindow previewWindow = new PreviewWindow(doc, viewSection.Id);
            previewWindow.ShowDialog();

            if (previewWindow.DialogResult == false)
            {
                MessageBox.Show("已取消操作");
                return Result.Cancelled;
            }

            if (previewWindow.OppositeDir == true)
            {
                OppositeElementDirection(doc, ids);
            }

            using (Transaction t = new Transaction(doc, "删除临时剖面"))
            {
                t.Start();
                doc.Delete(viewSection.Id);
                t.Commit();
            }

            TG.Assimilate();
            return Result.Succeeded;
            
        }
        private void OppositeElementDirection(Document doc, List<ElementId> ids)
        {
            using (Transaction t = new Transaction(doc, "元素旋转180度"))
            {
                t.Start();

                foreach (var id in ids)
                {
                    FamilyInstance familyInstance = doc.GetElement(id) as FamilyInstance;

                    XYZ elemUpDir = familyInstance.GetTransform().OfVector(XYZ.BasisY);
                    XYZ elemViewDir = familyInstance.GetTransform().OfVector(XYZ.BasisZ);
                    XYZ point = (familyInstance.Location as LocationPoint).Point;
                    XYZ centerP = point + elemUpDir * (450 / 304.8);

                    ElementTransformUtils.RotateElement(doc, id, Line.CreateBound(centerP, centerP + elemViewDir), Math.PI);

                }

                t.Commit();
            }
        }
        private ViewSection CreateViewSection(Document doc, Element element, PlanarFace planarFace, List<ElementId> ids)
        {
            ViewSection viewSection = null;
            ViewFamilyType viewType = new FilteredElementCollector(doc)
                .OfClass(typeof(ViewFamilyType))
                .Cast<ViewFamilyType>()
                .FirstOrDefault(x => x.ViewFamily == ViewFamily.Section);

            if (viewType == null) return viewSection;

            var elemBox = element.get_BoundingBox(doc.ActiveView);
            var boxUV = planarFace.GetBoundingBox();

            double sectionLength = boxUV.Min.DistanceTo(boxUV.Max) / 2 + 50 / 304.8;
            double sectionHeight = (elemBox.Max.Z - elemBox.Min.Z) / 2 + 50 / 304.8;
            double sectionDepth = 20 / 304.8;
            XYZ elemCenter = elemBox.Max.Add(elemBox.Min) / 2;

            XYZ min = new XYZ(-sectionLength, -sectionHeight, -sectionDepth);
            XYZ max = new XYZ(sectionLength, sectionHeight, sectionDepth);

            Transform transform = Transform.Identity;
            transform.Origin = elemCenter; // 剖面中心位于墙中心

            // 设置剖面的观察方向（BasisZ）为墙的方向
            transform.BasisZ = planarFace.FaceNormal.Negate();
            // 设置剖面的上方为Z轴正方向
            transform.BasisY = XYZ.BasisZ;
            // 通过叉积计算右方向，确保坐标系为右手系
            transform.BasisX = -planarFace.FaceNormal.Negate().CrossProduct(XYZ.BasisZ).Normalize();

            BoundingBoxXYZ sectionBox = new BoundingBoxXYZ();
            sectionBox.Transform = transform;
            sectionBox.Min = min;
            sectionBox.Max = max;

            using (Transaction trans = new Transaction(doc, "创建临时剖面"))
            {
                trans.Start();

                viewSection = ViewSection.CreateSection(doc, viewType.Id, sectionBox);

                // 配置视图属性
                viewSection.Name = "临时剖面" + DateTime.Now.ToString().Replace(":", "").Replace("/", "").Replace(" ", "");
                viewSection.CropBoxActive = true; // 激活裁剪框
                viewSection.DetailLevel = ViewDetailLevel.Fine; // 详细程度设为精细
                viewSection.DisplayStyle = DisplayStyle.ShadingWithEdges; // 显示模式为着色带边
                //viewSection.IsolateElementTemporary(wall.Id); // 临时隔离所选墙体
                viewSection.IsolateElementsTemporary(ids); // 临时隔离所选墙体

                trans.Commit();
            }
            return viewSection;
        }
        private Family LoadFamily(Document doc, byte[] data, string familyName)
        {
            Family family;
            string tempFilePath = CreateTempFileFromBytes(data, familyName);
            using (Transaction t = new Transaction(doc, "载入族"))
            {
                t.Start();
                doc.LoadFamily(tempFilePath, out family);
                t.Commit();
            }
            return family;
        }
        private string CreateTempFileFromBytes(byte[] data, string suggestedFileName)
        {
            // 获取临时文件夹路径，并确保文件名以 .rfa 结尾
            string tempDir = Path.GetTempPath();
            string tempFileName = Path.ChangeExtension(suggestedFileName, ".rfa");
            string tempFilePath = Path.Combine(tempDir, tempFileName);

            // 如果目标文件已存在，则删除（可选，根据你的需求决定）
            if (File.Exists(tempFilePath))
            {
                File.Delete(tempFilePath);
            }

            // 将字节数组写入文件
            File.WriteAllBytes(tempFilePath, data);
            return tempFilePath;
        }
        //private string ExtractEmbeddedResource(string resourceName)
        //{
        //    Assembly assembly = Assembly.GetExecutingAssembly();
        //    string tempPath = Path.GetTempFileName();
        //    // 建议修改后缀为.rfa，避免潜在问题
        //    tempPath = Path.ChangeExtension(tempPath, ".rfa");

        //    using (Stream resourceStream = assembly.GetManifestResourceStream(resourceName))
        //    {
        //        if (resourceStream == null)
        //        {
        //            throw new FileNotFoundException("嵌入的资源未找到。", resourceName);
        //        }
        //        using (FileStream fileStream = new FileStream(tempPath, FileMode.Create))
        //        {
        //            resourceStream.CopyTo(fileStream);
        //        }
        //    }
        //    return tempPath;
        //}
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
    public class PlanarFaceFilter : ISelectionFilter
    {
        public Document Doc { get; set; }
        public PlanarFaceFilter(Document doc)
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
            GeometryObject geo = element.GetGeometryObjectFromReference(reference);
            if (geo != null && geo is PlanarFace)
            {
                return true;
            }
            return false;
        }
    }

    public class LineFilter : ISelectionFilter
    {
        public Document Doc { get; set; }
        public LineFilter(Document document)
        {
            Doc = document;
        }
        public bool AllowElement(Element elem)
        {
            return true;
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            Element element = Doc.GetElement(reference);
            GeometryObject geo = element.GetGeometryObjectFromReference(reference);
            //if (element.Location != null && element.Location is LocationCurve && (element.Location as LocationCurve).Curve is Line || obj is Curve || obj is Edge)
            //{
            //    return true;
            //}
            if (element is RevitLinkInstance linkInstance)
            {
                Document linkDoc = linkInstance.GetLinkDocument();
                Element linkElem = linkDoc.GetElement(reference.LinkedElementId);

                Reference linkRefer = reference.CreateReferenceInLink();
                var linkGeo = linkElem.GetGeometryObjectFromReference(linkRefer);
                if (linkGeo is Curve || linkGeo is Edge edge && edge.AsCurve() is Line) return true;
            }
            else if (element is ModelLine || geo is Curve || geo is Edge edge && edge.AsCurve() is Line)
            {
                return true;
            }
            return false;
        }
    }
}
