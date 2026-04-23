using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//276C型钢吊架标注
namespace CEGRegister
{
    [Transaction(TransactionMode.Manual)]
    public class Command08 : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            #region 判断加密
            //注册验证
            string licFile = string.Format("{0}\\Key.lic",
    System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
            if (!CheckRegClass.CheckReg(licFile))
            {
                return Result.Cancelled;
            }
            #endregion

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
            if (view3D == null)
            {
                TaskDialog.Show("Revit", "未找到三维视图:{三维}");
                return Result.Failed;
            }
            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();
            if (mainWindow.cancel)
            {
                return Result.Cancelled;
            }
            //List<FamilyInstance> hangers = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_MechanicalEquipment).OfClass(typeof(FamilyInstance)).Cast<FamilyInstance>().Where(x => x.Symbol.Family.Name.Contains("吊架")).ToList();
            IList<Reference> references = uIDoc.Selection.PickObjects(ObjectType.Element, new HangerFilter276(), "框选吊架");
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
            if (textNoteType == null) textNoteType = textNoteTypes.Cast<TextNoteType>().ToList().Where(x => x.FamilyName == "文字").First(x => x.Name.Contains("2.5"));
            View view = uIDoc.ActiveView;
            using (Transaction t = new Transaction(doc, "C型钢吊架定位标注"))
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
                        if (mainWindow.upSet)
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

            return Result.Succeeded;
        }
    }
    public class HangerFilter276 : ISelectionFilter
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
