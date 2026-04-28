using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.Exceptions;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using OperationCanceledException = Autodesk.Revit.Exceptions.OperationCanceledException;

//生成吊架底部标高文字注释
namespace CreateTextAnnotationsForHangerHeight
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uIDoc = commandData.Application.ActiveUIDocument;
            Document doc = uIDoc.Document;

            View3D view3D = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Views).FirstOrDefault(x => x is View3D && x.Name == "{三维}") as View3D;
            // 获取当前活动的视图
            View previousView = uIDoc.ActiveView;
            // 获取默认的三维视图的视图 ID
            ElementId default3DViewId = new FilteredElementCollector(doc)
                .OfClass(typeof(View3D))
                .FirstOrDefault(v => v.Name == "{三维}")?.Id;

            if (default3DViewId != null)
            {
                // 激活默认的三维视图
                uIDoc.ActiveView = doc.GetElement(default3DViewId) as View;
            }
            uIDoc.ActiveView = previousView;
            if (!(doc.ActiveView is ViewPlan) || !doc.ActiveView.Name.Contains("出图"))
            {
                TaskDialog.Show("Revit", "请在出图运行该插件！");
                return Result.Failed;
            }
            if (view3D == null)
            {
                TaskDialog.Show("Revit", "未找到三维视图:{三维}");
                return Result.Failed;
            }

            // 判断需要标注的是横杆底标高还是横杆顶标高
            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();
            if (mainWindow.DialogResult == false)
            {
                return Result.Cancelled;
            }
            bool downLevel = mainWindow.DownLevel;

            //List<FamilyInstance> hangers1 = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_MechanicalEquipment).OfClass(typeof(FamilyInstance)).Cast<FamilyInstance>().Where(x => x.Symbol.Family.Name.Contains("吊架")).ToList();
            IList<Reference> references;
            RevitUtils.ListenUtils listenUtils = new RevitUtils.ListenUtils();
            try
            {
                listenUtils.startListen();
                references = uIDoc.Selection.PickObjects(Autodesk.Revit.UI.Selection.ObjectType.Element, new HangerFilter(), "框选吊架（按空格键完成框选，ESC键取消）");
                listenUtils.stopListen();
            }
            catch (OperationCanceledException)
            {
                listenUtils.stopListen();
                return Result.Cancelled;
            }
            List<FamilyInstance> hangers = new List<FamilyInstance>();
            foreach (Reference reference in references)
            {
                FamilyInstance familyInstance = doc.GetElement(reference) as FamilyInstance;
                hangers.Add(familyInstance);
            }
            //Element element = doc.GetElement(uIDoc.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.Element));
            //XYZ p = (element.Location as LocationPoint).Point;
            FilteredElementCollector collector1 = new FilteredElementCollector(doc);
            ICollection<Element> textNoteTypes = collector1.OfClass(typeof(TextNoteType)).ToElements();
            TextNoteType textNoteType = null;
            foreach (TextNoteType textType in textNoteTypes)
            {
                if (textType?.FamilyName == "文字" && textType?.Name == "支吊架信息标记")
                {
                    textNoteType = textType;
                    break;
                }
            }
            if (textNoteType == null) textNoteType = textNoteTypes.Cast<TextNoteType>().ToList().Where(x => x.FamilyName == "文字").First();
            View view = uIDoc.ActiveView;
            ElementCategoryFilter categoryFilter = new ElementCategoryFilter(BuiltInCategory.OST_Floors);
            ReferenceIntersector referenceIntersector = new ReferenceIntersector(categoryFilter, FindReferenceTarget.All, view3D);
            referenceIntersector.FindReferencesInRevitLinks = true;
            bool hasNull = false;
            bool hasNull2 = false;
            using (Transaction t = new Transaction(doc, "吊架增加横担标高文字注释"))
            {
                t.Start();
                foreach (var item in hangers)
                {
                    //if (item.Name.Contains("双吊架-双层") || item.Name.Contains("双吊架-单层") || item.Name.Contains("单吊架-单层") || item.Name.Contains("单吊架-双层") || item.Name.Contains("C型钢-楼板固定") || item.Name.Contains("C型钢丝杆吊架"))
                    //{
                    //    string upPara = "";
                    //    string downPara = "";
                    //    string length = "";
                    //    string high = "";
                    //    string t1 = "";
                    //    string t2 = "";
                    //    string info = "";
                    //    if (!item.Name.Contains("C型钢丝杆吊架"))
                    //    {
                    //        foreach (Parameter para in item.Parameters)
                    //        {
                    //            if (para.Definition.Name == "上层吊架型号") upPara = para.AsString();
                    //            if (para.Definition.Name == "底层吊架型号") downPara = para.AsString();
                    //            if (para.Definition.Name == "吊架宽度（标注）") length = para.AsValueString();
                    //            if (para.Definition.Name == "吊架高度（平面）") high = para.AsValueString();
                    //        }
                    //        info = upPara + " " + downPara + " L≈" + length + "*H≈" + high;
                    //    }
                    //    else
                    //    {
                    //        foreach (Parameter para in item.Parameters)
                    //        {
                    //            if (para.Definition.Name == "专业标注") t1 = para.AsString();
                    //            if (para.Definition.Name == "风管固定方式") t2 = para.AsString();
                    //            if (para.Definition.Name == "吊架宽度（标注）") length = para.AsValueString();
                    //            if (para.Definition.Name == "吊架高度（平面）") high = para.AsValueString();
                    //        }
                    //        info = t1 + "L≈" + length + "*H≈" + high + "-" + t2;
                    //    }
                    //    XYZ pt = (item.Location as LocationPoint).Point;

                    //    //FamilySymbol familySymbol = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_MechanicalEquipmentTags)
                    //    //    .WhereElementIsElementType().Cast<FamilySymbol>().FirstOrDefault(x => x.Name.Contains("标准") && x.FamilyName.Contains("普通吊架平面标注(1.0)"));
                    //    //IndependentTag tag = IndependentTag.Create(doc, familySymbol.Id, doc.ActiveView.Id, new Reference(item), false, TagOrientation.Horizontal, pt);
                    //    //Line axis = Line.CreateBound(pt, pt + XYZ.BasisZ);
                    //    //if (!item.Name.Contains("C型钢-楼板固定") && !item.Name.Contains("C型钢丝杆吊架"))
                    //    //{
                    //    //    ElementTransformUtils.MoveElement(doc, tag.Id, item.FacingOrientation * 1.75);
                    //    //}


                    //    TextNote textNoteUp = TextNote.Create(doc, view.Id, pt, info, textNoteType.Id);
                    //    //移动文本 使得文本下边中心对其元素中点
                    //    textNoteType.get_Parameter(BuiltInParameter.LEADER_OFFSET_SHEET).Set(0);
                    //    view.Document.Regenerate();
                    //    double scaleUp = view.Scale;
                    //    double textNoteWidthUp = textNoteUp.Width * scaleUp;
                    //    // 计算偏移量，使对齐点为文本的下边中心
                    //    XYZ offsetUp = new XYZ(-textNoteWidthUp / 2, 1.75, 0);
                    //    // 移动文本注释的位置
                    //    ElementTransformUtils.MoveElement(doc, textNoteUp.Id, offsetUp);
                    //    LocationPoint locationPointUp = item.Location as LocationPoint;
                    //    double rotaUp = locationPointUp.Rotation;
                    //    Line axisUp = Line.CreateBound(pt, pt + new XYZ(0, 0, 1));
                    //    ElementTransformUtils.RotateElement(doc, textNoteUp.Id, axisUp, rotaUp);
                    //}
                    XYZ p = (item.Location as LocationPoint).Point;
                    Level level = doc.GetElement(item.LevelId) as Level;
                    if (level == null) continue;
                    double h = level.ProjectElevation;
                    double spacing = 0;
                    foreach (Parameter item2 in item.Parameters)
                        if (item2.Definition.Name.Equals("顶层间距"))
                        {
                            spacing = item2.AsDouble();
                            break;
                        }
                    double topOffset = 9999999;
                    foreach (Parameter item2 in item.Parameters)
                        if (item2.Definition.Name.Equals("顶部偏移"))
                        {
                            topOffset = item2.AsDouble();
                            break;
                        }
                    if (!hasNull2 && (spacing == 0 || topOffset == 9999999))
                    {
                        hasNull2 = true;
                        TaskDialog.Show("提示", "有不存在顶层间距或顶部偏移参数的吊架，因此此类吊架无法正确生成文字注释");
                        continue;
                    }
                    else if (spacing == 0 || topOffset == 9999999)
                    {
                        continue;
                    }
                    p = new XYZ(p.X, p.Y, h - spacing + topOffset);
                    ReferenceWithContext referenceWithContext = referenceIntersector.FindNearest(p, XYZ.BasisZ.Negate());

                    bool notFind = false;
                    if (referenceWithContext != null)
                    {
                        Transform transform = doc.ActiveView.get_BoundingBox(null).Transform;

                        XYZ p1 = referenceWithContext.GetReference().GlobalPoint;
                        string info = "B + ";
                        int num = ProcessDigit(Convert.ToInt32(p.DistanceTo(p1) * 304.8));
                        if (mainWindow.DownLevel == false)
                        {
                            double hangerHigh = GetHangerThickness(item);
                            if (hangerHigh == -1) continue;
                            num = ProcessDigit(Convert.ToInt32((p.DistanceTo(p1) + hangerHigh) * 304.8));
                        }
                        //TaskDialog.Show("wds", p.ToString() +"\n" + num);
                        info += num;
                        foreach (Parameter item2 in item.Parameters)
                            if (item2.Definition.Name.Equals("一二层间距"))
                            {
                                double distanceBetweenTwo = item2.AsDouble();
                                double upDis = ProcessDigit(Convert.ToInt32((p.DistanceTo(p1) + distanceBetweenTwo) * 304.8));
                                double downDis = ProcessDigit(Convert.ToInt32((p.DistanceTo(p1) - distanceBetweenTwo) * 304.8));
                                if (mainWindow.DownLevel == false)
                                {
                                    double hangerThickness = GetHangerThickness(item);
                                    if (hangerThickness == -1)
                                    {
                                        notFind = true;
                                        break;
                                    }
                                    downDis = ProcessDigit(Convert.ToInt32((p.DistanceTo(p1) - distanceBetweenTwo + hangerThickness) * 304.8));
                                    num = ProcessDigit(Convert.ToInt32((p.DistanceTo(p1) + hangerThickness) * 304.8));
                                }
                                //info = "下 B + " + num;
                                //string upInfo = "上 B + " + upDis;
                                info = "下 B + " + downDis;
                                string upInfo = "上 B + " + num;
                                TextNote textNoteUp = TextNote.Create(doc, view.Id, p, upInfo, textNoteType.Id);
                                //移动文本 使得文本下边中心对其元素中点
                                //TextNoteType textNoteType = textNote.TextNoteType;
                                textNoteType.get_Parameter(BuiltInParameter.LEADER_OFFSET_SHEET).Set(0);
                                //textNoteType.get_Parameter(BuiltInParameter.TEXT_SIZE).SetValueString("1.5 mm");
                                view.Document.Regenerate();
                                double scaleUp = view.Scale;
                                double textNoteWidthUp = textNoteUp.Width * scaleUp;
                                // 计算偏移量，使对齐点为文本的下边中心
                                XYZ offsetUp = new XYZ(-textNoteWidthUp / 2, 1.75, 0);
                                // 移动文本注释的位置
                                ElementTransformUtils.MoveElement(doc, textNoteUp.Id, offsetUp);
                                LocationPoint locationPointUp = item.Location as LocationPoint;
                                double rotaUp = locationPointUp.Rotation;
                                XYZ dir = RotateVector(XYZ.BasisX, rotaUp);
                                dir = transform.Inverse.OfVector(dir);
                                rotaUp = dir.AngleTo(XYZ.BasisX);
                                Line axisUp = Line.CreateBound(p, p + new XYZ(0, 0, 1));
                                ElementTransformUtils.RotateElement(doc, textNoteUp.Id, axisUp, rotaUp);
                                break;
                            }
                        if (notFind) continue;
                        //TaskDialog.Show("ds", (p.DistanceTo(p1) * 304.8).ToString());
                        //XYZ centerP = (item.Location as LocationPoint).Point;
                        TextNote textNote = TextNote.Create(doc, view.Id, p, info, textNoteType.Id);
                        //移动文本 使得文本下边中心对其元素中点
                        //TextNoteType textNoteType = textNote.TextNoteType;
                        textNoteType.get_Parameter(BuiltInParameter.LEADER_OFFSET_SHEET).Set(0);
                        //textNoteType.get_Parameter(BuiltInParameter.TEXT_SIZE).SetValueString("1.5 mm");
                        view.Document.Regenerate();
                        double scale = view.Scale;
                        double textNoteWidth = textNote.Width * scale;
                        // 计算偏移量，使对齐点为文本的下边中心
                        XYZ offset = new XYZ(-textNoteWidth / 2, 1.25, 0);
                        if (info.Contains("下")) offset = new XYZ(-textNoteWidth / 2, 1.75, 0);
                        // 移动文本注释的位置
                        ElementTransformUtils.MoveElement(doc, textNote.Id, offset);
                        LocationPoint locationPoint = item.Location as LocationPoint;
                        double rota = locationPoint.Rotation;
                        Line axis = Line.CreateBound(p, p + new XYZ(0, 0, 1));
                        ElementTransformUtils.RotateElement(doc, textNote.Id, axis, rota);
                        ElementTransformUtils.RotateElement(doc, textNote.Id, axis, Math.PI);
                    }
                    else if (!hasNull)
                    {
                        hasNull = true;
                        TaskDialog.Show("提示", "有部分吊架未成功增加文字注释，请检查三维视图:{三维}中的楼板可见性");
                    }
                    
                }
                t.Commit();
            }
            return Result.Succeeded;
        }

        private double GetHangerThickness(FamilyInstance item)
        {
            double thickness = -1;

            if (item.Symbol.Name.Contains("槽钢"))
            {
                var para = item.LookupParameter("H1");
                if (para == null) return thickness;
                thickness = para.AsDouble();
            }
            else if (item.Symbol.Name.Contains("角钢"))
            {
                var para = item.LookupParameter("B1");
                if (para == null) return thickness;
                thickness = para.AsDouble();
            }
            return thickness;
        }

        public XYZ RotateVector(XYZ vector, double angle)
        {

            // 计算旋转矩阵
            double cosAngle = Math.Cos(angle);
            double sinAngle = Math.Sin(angle);

            // 旋转后的向量
            double xNew = vector.X * cosAngle - vector.Y * sinAngle;
            double yNew = vector.X * sinAngle + vector.Y * cosAngle;
            double zNew = vector.Z;  // 保持 Z 轴不变（如果只在 XY 平面旋转）

            return new XYZ(xNew, yNew, zNew);
        }
        public int ProcessDigit(int number)
        {
            // 获取个位数
            int lastDigit = number % 10;

            // 如果个位数为5，则不改变
            if (lastDigit == 5)
            {
                return number;
            }
            // 如果个位数在0-4之间，则舍去
            else if (lastDigit >= 0 && lastDigit <= 4)
            {
                return number / 10 * 10; // 舍去个位数
            }
            // 如果个位数在6-9之间，则进一位
            else
            {
                return (number / 10 + 1) * 10; // 进一位
            }
        }
    }
    public class HangerFilter : ISelectionFilter
    {
        public bool AllowElement(Element elem)
        {
            if (elem.Category.Id.IntegerValue == -2001140
                && elem is FamilyInstance familyInstance 
                && familyInstance.Symbol.Family.Name.Contains("吊架"))
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
}
