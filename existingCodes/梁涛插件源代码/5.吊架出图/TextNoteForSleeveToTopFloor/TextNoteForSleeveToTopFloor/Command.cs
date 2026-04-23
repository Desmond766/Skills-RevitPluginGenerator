using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using View = Autodesk.Revit.DB.View;

namespace TextNoteForSleeveToTopFloor
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;

            View3D view3D;
            if (!(doc.ActiveView is ViewPlan))
            {
                message = "请在平面视图运行该插件!";
                elements.Insert(doc.ActiveView);
                return Result.Failed;
            }

            List<ElementFilter> elementFilters = new List<ElementFilter>()
            {
                new ElementCategoryFilter(BuiltInCategory.OST_PipeAccessory),
                new ElementCategoryFilter(BuiltInCategory.OST_MechanicalEquipment),
                new ElementCategoryFilter(BuiltInCategory.OST_PipeFitting)
            };
            LogicalOrFilter orFilter = new LogicalOrFilter(elementFilters);
            var pipeFitts = new FilteredElementCollector(doc, doc.ActiveView.Id).WherePasses(orFilter).OfClass(typeof(FamilyInstance)).Where(x => x.Name.Contains("套管")).ToList();

            var view3Ds = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Views).OfClass(typeof(View3D)).Cast<View3D>().ToList();
            view3D = view3Ds.FirstOrDefault(v => v.Name == "3D 支吊架");
            if (view3D == null) view3D = view3Ds.FirstOrDefault();
            if (view3D == null)
            {
                message = "未在该项目中找到三维视图，无法运行插件!";
                return Result.Failed;
            }
            
            bool startOpen = uidoc.GetOpenUIViews().FirstOrDefault(x => x.ViewId == view3D.Id) != null;
            View activeView = uidoc.ActiveView;
            uidoc.ActiveView = view3D;
            uidoc.ActiveView = activeView;
            //return Result.Succeeded;

            int count = 0;
            using (Transaction t = new Transaction(doc, "创建文字注释"))
            {
                t.Start();

                foreach (var pipeFit in pipeFitts)
                {
                    XYZ point = (pipeFit.Location as LocationPoint).Point;
                    XYZ min = pipeFit.get_BoundingBox(null).Min;
                    XYZ newPoint = new XYZ(min.X, min.Y, point.Z);
                    double dis;
                    try
                    {
                        dis = GetClearHeightUp(doc, view3D, newPoint);
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                    CreateTextNote(uidoc, "板下" + (Math.Round(dis * 304.8, 0)).ToString(), point, pipeFit);
                    count++;
                }

                t.Commit();
            }
            // 获取所有已打开的视图窗口
            IList<UIView> openViews = uidoc.GetOpenUIViews();
            var closeView = openViews.FirstOrDefault(x => x.ViewId == view3D.Id);
            if (closeView != null && !startOpen) closeView.Close();

            MessageBox.Show($"运行结束\n使用三维视图: {view3D.Name}\n有" + count + "个套管成功生成文字注释\n有" + (pipeFitts.Count - count) + "个套管未成功生成文字注释", $"Revit-{view3D.Name}");

            return Result.Succeeded;
        }
        public void CreateTextNote(UIDocument uidoc, string text, XYZ centerP, Element elem)
        {
            Document doc = uidoc.Document;
            FilteredElementCollector collector1 = new FilteredElementCollector(doc);
            ICollection<Element> textNoteTypes = collector1.OfClass(typeof(TextNoteType)).ToElements();
            TextNoteType textNoteType = null;
            foreach (TextNoteType textType in textNoteTypes)
            {
                if (textType?.FamilyName == "文字")
                {
                    textNoteType = textType;
                    break;
                }
            }
            View view = uidoc.ActiveView;
            TextNote textNote = TextNote.Create(doc, view.Id, centerP, text, textNoteType.Id);

            //移动文本 使得文本下边中心对其元素中点
            textNoteType.get_Parameter(BuiltInParameter.LEADER_OFFSET_SHEET).Set(0);
            textNoteType.get_Parameter(BuiltInParameter.TEXT_SIZE).SetValueString("1.5 mm");
            view.Document.Regenerate();
            double scale = view.Scale;
            double textNoteWidth = textNote.Width * scale;

            // 计算偏移量，使对齐点为文本的下边中心
            XYZ offset = new XYZ(-textNoteWidth / 2, 1.25, 0);

            // 移动文本注释的位置
            ElementTransformUtils.MoveElement(doc, textNote.Id, offset);

            LocationPoint locationPoint = elem.Location as LocationPoint;
            double rota = locationPoint.Rotation;

            Line axis = Line.CreateBound(centerP, centerP + new XYZ(0, 0, 1));
            if (elem.Name == "风管法兰吊架-上固定" || elem.Name == "风管法兰吊架-下固定" || elem.Name.Contains("风管法兰抗震吊架"))
            {

                ElementTransformUtils.RotateElement(doc, textNote.Id, axis, rota + (Math.PI / 2));
            }
            else
            {
                ElementTransformUtils.RotateElement(doc, textNote.Id, axis, rota);
            }
            return;
            while (true)
            {
                if (((textNote.get_BoundingBox(view).Max + (textNote.get_BoundingBox(view).Min)) / 2).Y > centerP.Y)
                {
                    break;
                }
                else if (((textNote.get_BoundingBox(view).Max + (textNote.get_BoundingBox(view).Min)) / 2).Y == centerP.Y)
                {
                    if (((textNote.get_BoundingBox(view).Max + (textNote.get_BoundingBox(view).Min)) / 2).X < centerP.X)
                    {
                        break;
                    }
                }
                ElementTransformUtils.RotateElement(doc, textNote.Id, axis, Math.PI);
            }
        }

        #region 获得套管向上投影的净高
        public static double GetClearHeightUp(Document doc, View3D view, XYZ point_Do)
        {
            double distance = 0.0;
            //梁的计算点point_Do 

            List<ElementFilter> filterList = new List<ElementFilter>();
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_Floors));
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_StructuralFraming));
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_Ceilings));
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_StructuralFoundation));
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_RvtLinks));

            LogicalOrFilter floorOrCeiling = new LogicalOrFilter(filterList);


            //相交
            ReferenceIntersector referenceIntersector = new ReferenceIntersector(floorOrCeiling, FindReferenceTarget.Face, view);
            referenceIntersector.FindReferencesInRevitLinks = true;

            ReferenceWithContext referenceWithContext = referenceIntersector.FindNearest(point_Do, XYZ.BasisZ);

            Reference r = referenceWithContext.GetReference();
            distance = r.GlobalPoint.DistanceTo(point_Do);
            //if (doc.GetElement(r) is RevitLinkInstance revitLinkInstance)
            //{
            //    Document linkDoc = revitLinkInstance.GetLinkDocument();
            //    Element linkElem = linkDoc.GetElement(r.LinkedElementId);
            //    if (linkElem.Category.Id.IntegerValue == -2001320 && linkElem is FamilyInstance familyInstance && familyInstance.StructuralType == Autodesk.Revit.DB.Structure.StructuralType.Beam)
            //    {
            //        XYZ dir = XYZ.BasisX;
            //        if ((familyInstance.Location as LocationCurve).Curve is Line line)
            //        {
            //            XYZ lineDir = line.Direction;
            //            dir = new XYZ(-lineDir.Y, lineDir.X, 0);
            //        }
            //        XYZ newPoint = point_Do + dir * (600 / 304.8);
            //        var rw2 = referenceIntersector.FindNearest(newPoint, XYZ.BasisZ);
            //        var newR = rw2.GetReference();
            //        distance = newR.GlobalPoint.DistanceTo(newPoint);
            //    }
            //}

            //DrawModelCurve(doc, point_Do, r2.GlobalPoint);

            return distance;

        }
        #endregion
    }
}
