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
using System.Windows.Controls;
using System.Windows.Interop;
using OperationCanceledException = Autodesk.Revit.Exceptions.OperationCanceledException;

//C型钢吊架型号尺寸标注，生成定位标注
namespace PositioningMarkingOfCShapedSteelHanger
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        private bool IsCShape;
        private bool IsTag;
        private bool UpSet;
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uIDoc = commandData.Application.ActiveUIDocument;
            Document doc = uIDoc.Document;

            View3D view3D = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Views).FirstOrDefault(x => x is View3D && x.Name == "3D 支吊架") as View3D;
            // 获取当前活动的视图
            View previousView = uIDoc.ActiveView;
            // 获取默认的三维视图的视图 ID
            ElementId default3DViewId = new FilteredElementCollector(doc)
                .OfClass(typeof(View3D))
                .FirstOrDefault(v => v.Name == "3D 支吊架")?.Id;
            
            if (default3DViewId != null)
            {
                // 激活默认的三维视图
                uIDoc.ActiveView = doc.GetElement(default3DViewId) as View;
            }
            uIDoc.ActiveView = previousView;
            if (view3D == null)
            {
                TaskDialog.Show("Revit", "未找到三维视图:3D 支吊架");
                return Result.Failed;
            }
            MainWindow mainWindow = new MainWindow();
            IntPtr intPtr = commandData.Application.MainWindowHandle;
            WindowInteropHelper windowInteropHelper = new WindowInteropHelper(mainWindow);
            windowInteropHelper.Owner = intPtr;
            mainWindow.ShowDialog();
            if (mainWindow.DialogResult == false)
            {
                return Result.Cancelled;
            }
            IsCShape = mainWindow.IsCShape;
            IsTag = mainWindow.IsTag;
            UpSet = mainWindow.UpSet;

            //List<FamilyInstance> hangers = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_MechanicalEquipment).OfClass(typeof(FamilyInstance)).Cast<FamilyInstance>().Where(x => x.Symbol.Family.Name.Contains("吊架")).ToList();
            IList<Reference> references;
            RevitUtils.ListenUtils listenUtils = new RevitUtils.ListenUtils();
            try
            {
                listenUtils.startListen();
                references = uIDoc.Selection.PickObjects(ObjectType.Element, new HangerFilter(), "框选吊架 空格完成选择");
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
            if (textNoteType == null) textNoteType = textNoteTypes.Cast<TextNoteType>().ToList().Where(x => x.FamilyName == "文字").FirstOrDefault(x => x.Name.Contains("2.5"));
            if (textNoteType == null) textNoteType = textNoteTypes.Cast<TextNoteType>().ToList().Where(x => x.FamilyName == "文字").FirstOrDefault();
            View view = uIDoc.ActiveView;

            if (IsCShape)
            {
                if (IsTag)
                {
                    CShapeHangerCreateTag(doc, view, hangers);
                }
                else
                {
                    CShapeHangerCreateTextNote(doc, view, textNoteType, hangers);
                }
            }
            else
            {
                PMHangerCreateTextNote(doc, view, textNoteType, hangers);
            }

            return Result.Succeeded;
        }
        private void CShapeHangerCreateTextNote(Document doc, View view, TextNoteType textNoteType, List<FamilyInstance> hangers)
        {
            using (Transaction t = new Transaction(doc, "C型钢吊架定位标注(文字注释)"))
            {
                t.Start();
                foreach (var item in hangers)
                {
                    if (item.Name.Contains("双吊架-双层") || item.Name.Contains("双吊架-单层") || item.Name.Contains("单吊架-单层") || item.Name.Contains("单吊架-双层") || item.Name.Contains("C型钢-楼板固定") || item.Name.Contains("C型钢丝杆吊架") || item.Name.Contains("单层丝杆吊架"))
                    {
                        string upPara = "";
                        string downPara = "";
                        string length = "";
                        string high = "";
                        string t1 = "";
                        string t2 = "";
                        string info = "";
                        if (!(item.Name.Contains("C型钢丝杆吊架") || item.Name.Contains("单层丝杆吊架")))
                        {
                            foreach (Parameter para in item.Parameters)
                            {
                                if (para.Definition.Name == "上层吊架型号") upPara = para.AsString();
                                if (para.Definition.Name == "底层吊架型号") downPara = para.AsString();
                                if (para.Definition.Name == "吊架宽度（标注）") length = para.AsValueString();
                                if (para.Definition.Name == "吊架高度（平面）") high = para.AsValueString();
                            }
                            info = upPara + " " + downPara + " L≈" + length + "*H≈" + high;
                        }
                        else
                        {
                            foreach (Parameter para in item.Parameters)
                            {
                                if (para.Definition.Name == "专业标注") t1 = para.AsString();
                                if (para.Definition.Name == "风管固定方式") t2 = para.AsString();
                                if (para.Definition.Name == "吊架宽度（标注）") length = para.AsValueString();
                                if (para.Definition.Name == "吊架高度（平面）") high = para.AsValueString();
                            }
                            info = t1 + "L≈" + length + "*H≈" + high + "-" + t2;
                        }
                        XYZ pt = (item.Location as LocationPoint).Point;

                        TextNote textNoteUp = TextNote.Create(doc, view.Id, pt, info, textNoteType.Id);
                        //移动文本 使得文本下边中心对其元素中点
                        textNoteType.get_Parameter(BuiltInParameter.LEADER_OFFSET_SHEET).Set(0);
                        view.Document.Regenerate();
                        double scaleUp = view.Scale;
                        double textNoteWidthUp = textNoteUp.Width * scaleUp;
                        // 计算偏移量，使对齐点为文本的下边中心
                        XYZ offsetUp = null;
                        if (UpSet)
                        {
                            offsetUp = new XYZ(-textNoteWidthUp / 2, 1.75, 0);
                        }
                        else
                        {
                            offsetUp = new XYZ(-textNoteWidthUp / 2, -1.25, 0);
                        }
                        //XYZ offsetUp = new XYZ(-textNoteWidthUp / 2, 1.75, 0);
                        //XYZ offsetUp = new XYZ(-textNoteWidthUp / 2, -1.25, 0);
                        // 移动文本注释的位置
                        ElementTransformUtils.MoveElement(doc, textNoteUp.Id, offsetUp);
                        LocationPoint locationPointUp = item.Location as LocationPoint;
                        double rotaUp = locationPointUp.Rotation;
                        Line axisUp = Line.CreateBound(pt, pt + new XYZ(0, 0, 1));
                        ElementTransformUtils.RotateElement(doc, textNoteUp.Id, axisUp, rotaUp);
                    }
                }
                t.Commit();
            }
        }
        private void CShapeHangerCreateTag(Document doc, View view, List<FamilyInstance> hangers)
        {
            FamilySymbol hangerSymbol = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_MechanicalEquipmentTags).OfClass(typeof(FamilySymbol))
                .Cast<FamilySymbol>().FirstOrDefault(hs => hs.FamilyName.Contains("普通吊架平面标注"));
            if (hangerSymbol == null)
            {
                TaskDialog.Show("Revit", "未找到吊架标记族：普通吊架平面标注");
                return;
            }
            using (Transaction t = new Transaction(doc, "C型钢吊架定位标注(标记)"))
            {
                t.Start();
                foreach (var hanger in hangers)
                {
                    XYZ hangerP = (hanger.Location as LocationPoint).Point;
                    XYZ hangerDir = hanger.GetTransform().OfVector(XYZ.BasisX);

                    TagOrientation tagOrientation;
                    double horAngle = Math.Min(hangerDir.AngleTo(XYZ.BasisX), hangerDir.AngleTo(XYZ.BasisX.Negate()));
                    double verAngle = Math.Min(hangerDir.AngleTo(XYZ.BasisY), hangerDir.AngleTo(XYZ.BasisY.Negate()));
                    if (horAngle < verAngle) tagOrientation = TagOrientation.Horizontal;
                    else tagOrientation = TagOrientation.Vertical;

                    var tag = IndependentTag.Create(doc, hangerSymbol.Id, view.Id, new Reference(hanger), false, tagOrientation, hangerP);
                    if (UpSet)
                    {
                        if (tagOrientation == TagOrientation.Horizontal) tag.Location.Move(view.UpDirection * 1.75);
                        else tag.Location.Move(view.RightDirection.Negate() * 1.75);
                    }
                    //else
                    //{
                    //    if (tagOrientation == TagOrientation.Horizontal) tag.Location.Move(view.UpDirection * -1.25);
                    //    else tag.Location.Move(view.RightDirection.Negate() * -1.25);
                    //}
                }
                t.Commit();
            }
        }
        private void PMHangerCreateTextNote(Document doc, View view, TextNoteType textNoteType, List<FamilyInstance> hangers)
        {
            using (Transaction t = new Transaction(doc, "品茗吊架定位标注(文字注释)"))
            {
                t.Start();
                foreach (var item in hangers)
                {
                    if (item.Name.Contains("PM"))
                    {
                        string type = "";
                        string l = "";
                        string h = "";
                        string info = "";

                        foreach (Parameter para in item.Parameters)
                        {
                            if (para.Definition.Name.Contains("型钢规格") && para.StorageType == StorageType.String && !string.IsNullOrEmpty(para.AsString()))
                            {
                                type = para.AsString();
                                break;
                            }
                        }
                        l = item.LookupParameter("支吊架宽度").AsValueString();
                        h = item.LookupParameter("顶层间距").AsValueString();
                        try
                        {
                            double hangerL = Convert.ToInt32(l);
                            double hangerH = Convert.ToInt32(h);
                            if (type.Contains("L40X4"))
                            {
                                hangerL += 80;
                                hangerH -= 5;
                            }
                            else if (type.Contains("L50X5"))
                            {
                                hangerL += 100;
                                hangerH -= 10;
                            }
                            else if (type.Contains("6") && type.Contains("#"))
                            {
                                hangerL += 130;
                                hangerH -= 10;
                            }
                            else if (type.Contains("8") && type.Contains("#"))
                            {
                                hangerL += 150;
                                hangerH -= 10;
                            }
                            l = hangerL.ToString();
                            h = hangerH.ToString();
                        }
                        catch (Exception)
                        {
                            continue;
                        }

                        type = type.Replace("槽钢", "").Replace("角钢", "");
                        info = type + " L ≈ " + l + "xH ≈ " + h;

                        XYZ pt = (item.Location as LocationPoint).Point;

                        TextNote textNoteUp = TextNote.Create(doc, view.Id, pt, info, textNoteType.Id);
                        //移动文本 使得文本下边中心对其元素中点
                        textNoteType.get_Parameter(BuiltInParameter.LEADER_OFFSET_SHEET).Set(0);
                        view.Document.Regenerate();
                        double scaleUp = view.Scale;
                        double textNoteWidthUp = textNoteUp.Width * scaleUp;
                        // 计算偏移量，使对齐点为文本的下边中心
                        XYZ offsetUp = null;
                        if (UpSet)
                        {
                            offsetUp = new XYZ(-textNoteWidthUp / 2, 1.75, 0);
                        }
                        else
                        {
                            offsetUp = new XYZ(-textNoteWidthUp / 2, -1.25, 0);
                        }
                        //XYZ offsetUp = new XYZ(-textNoteWidthUp / 2, 1.75, 0);
                        //XYZ offsetUp = new XYZ(-textNoteWidthUp / 2, -1.25, 0);
                        // 移动文本注释的位置
                        ElementTransformUtils.MoveElement(doc, textNoteUp.Id, offsetUp);
                        LocationPoint locationPointUp = item.Location as LocationPoint;
                        double rotaUp = locationPointUp.Rotation;
                        Line axisUp = Line.CreateBound(pt, pt + new XYZ(0, 0, 1));
                        ElementTransformUtils.RotateElement(doc, textNoteUp.Id, axisUp, rotaUp);
                    }
                }
                t.Commit();
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
