using System;
using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.DB.Mechanical;
using MEP_TagHelperForSlopeForSection;

namespace MEP_TagHelperForSlopForSection
{
    [Transaction(TransactionMode.Manual)]

    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;


            //【1】判断视图————————————————————————————————————————————————————————————————————————————————————————————————————————————————
            //if (!(doc.ActiveView is ViewPlan))
            View view = doc.ActiveView;

            View3D view3D = null;
            FilteredElementCollector fristCollector = new FilteredElementCollector(doc).OfClass(typeof(View3D));
            foreach (View3D view3 in fristCollector)
            {
                if ("3D 机电".Equals(view3.Name))
                {
                    view3D = view3;
                    break;
                }
            }
            if (null == view3D)
            {
                message = "未找到视图：3D 机电";
                return Result.Failed;
            }

            while (true)
            {
                //【2】选择三点—选择管线———————————————————————————————————————————————————————————————————————————————————————————————————————————————
                XYZ pt1 = XYZ.Zero;
                XYZ pt2 = XYZ.Zero;
                XYZ pt3 = XYZ.Zero;
                Reference r = null;
                MEPCurve mepCurve = null;
                Line mepLine = null;
                try
                {
                    r = sel.PickObject(ObjectType.Element, new MEPCurveSelectionFilter(), "选择机电管线");
                    mepCurve = doc.GetElement(r) as MEPCurve;
                    mepLine = (mepCurve.Location as LocationCurve).Curve as Line;

                    pt1 = sel.PickPoint();
                    pt2 = sel.PickPoint();
                    pt3 = sel.PickPoint();
                }
                catch (Exception ex)
                {

                    if (ex.Message == "The user aborted the pick operation.")
                    {
                        TaskDialog.Show("Revit", "结束布置");
                        break;
                    }
                    else
                    {
                        TaskDialog.Show("Revit",
                        ex.Message + "\n" + ex.StackTrace.ToString());
                        break;
                    }
                }

                //【3】底部净高————————————————————————————————————————————————————————————————————————————————————————————————————————————

                double netHeight = Utils.GetClearHeight(view3D, doc, mepLine.Project(pt1).XYZPoint, mepCurve);
                //TaskDialog.Show("a", netHeight.ToString());

                //【3】标注准备————————————————————————————————————————————————————————————————————————————————————————————————————————————

                #region 定位标签

                XYZ tagDirection = (new XYZ(pt3.X, pt2.Y, pt2.Z) - pt2).Normalize();

                //标签的起点tag.LeaderEnd=pt1
                //标签的转弯点tag.LeaderElbow
                XYZ elbowLocation = pt1 + XYZ.BasisZ * (pt1.DistanceTo(pt2));
                if (pt2.Z < pt1.Z)
                {
                    elbowLocation = pt1 + XYZ.BasisZ.Negate() * (pt1.DistanceTo(pt2));
                }

                //标签文字起点位置tag.TagHeadPosition
                XYZ tagHeadLocation = elbowLocation + tagDirection * (pt2.DistanceTo(pt3));

                //Utils.DrawModelCurve(doc, pt1, elbowLocation);
                //Utils.DrawModelCurve(doc, elbowLocation, tagHeadLocation);
                #endregion

                #region 根据名称找标签族
                
                var tagFamilyName_LeftAlign_CT = "PC_桥架系统尺寸_左对齐";
                ElementId tagTypeId_LeftAlign_CT = null;
                var tagFamilyName_LeftAlign_DT = "PC_风管系统尺寸_左对齐";
                ElementId tagTypeId_LeftAlign_DT = null;
                var tagFamilyName_LeftAlign_PI = "PC_水管系统尺寸_左对齐";
                ElementId tagTypeId_LeftAlign_PI = null;
                var tagFamilyName_LeftAlign_DT1 = "PC_圆形风管系统尺寸_左对齐";
                ElementId tagTypeId_LeftAlign_DT1 = null;

                try
                {
                    tagTypeId_LeftAlign_CT = Utils.FindTypeIdByFamilyName(doc, tagFamilyName_LeftAlign_CT);
                    tagTypeId_LeftAlign_DT = Utils.FindTypeIdByFamilyName(doc, tagFamilyName_LeftAlign_DT);
                    tagTypeId_LeftAlign_PI = Utils.FindTypeIdByFamilyName(doc, tagFamilyName_LeftAlign_PI);
                    tagTypeId_LeftAlign_DT1 = Utils.FindTypeIdByFamilyName(doc, tagFamilyName_LeftAlign_DT1);
                }
                catch
                {
                    TaskDialog.Show("提示", "检查是否载入品成标记族,\r\n位置：" + @"\\192.168.0.254\pc_2017\品成项目_2017\品成插件工作\0PC_标注族");
                    return Result.Cancelled;
                }

                ElementId tagTypeId = null;
                Element element = doc.GetElement(r);

                if (element is CableTray)
                {
                    tagTypeId = tagTypeId_LeftAlign_CT;
                }
                else if (element is Duct)
                {
                    string eid = element.get_Parameter(BuiltInParameter.ELEM_FAMILY_PARAM).AsValueString();
                    if (eid == "圆形风管")
                    {
                        tagTypeId = tagTypeId_LeftAlign_DT1;
                    }
                    else
                    {
                        tagTypeId = tagTypeId_LeftAlign_DT;
                    }

                }
                else
                {
                    tagTypeId = tagTypeId_LeftAlign_PI;
                }
                

                //根据名称找族
                var arrowDetialFamilyName = "PC_标记_实心点";
                FamilySymbol arrowDetialSymbol = null;
                try
                {
                    arrowDetialSymbol = doc.GetElement(Utils.FindTypeIdByFamilyName(doc, arrowDetialFamilyName)) as FamilySymbol;
                }
                catch (Exception)
                {
                    TaskDialog.Show("提示", "检查是否载入品成标记点,\r\n位置：" + @"\\192.168.0.254\pc_2017\品成项目_2017\品成插件工作\0PC_标注族");
                    return Result.Cancelled;
                }
                
                #endregion

                #region 定位文字
                XYZ textPt = XYZ.Zero;
                TextNote tn = null;



                #endregion

                //【4】标注——————————————————————————————————————————————————————————————————————————————
                using (Transaction t = new Transaction(doc, "TAGHELPER"))
                {
                    t.Start();

                    #region 生成标签
                    IndependentTag tag = IndependentTag.Create(doc, view.Id, r, true, TagMode.TM_ADDBY_CATEGORY, TagOrientation.Horizontal, pt1);
                    tag.LeaderEndCondition = LeaderEndCondition.Free;//自由端头
                    tag.LeaderEnd = pt1;
                    tag.LeaderElbow = elbowLocation;
                    tag.TagHeadPosition = tagHeadLocation;

                    if (!arrowDetialSymbol.IsActive)
                    {
                        arrowDetialSymbol.Activate();
                    }
                    FamilyInstance arrowDetial = doc.Create.NewFamilyInstance(pt1, arrowDetialSymbol, view);

                    //替换族类型
                    if (tag.GetTypeId() != tagTypeId)
                    {
                        tag.ChangeTypeId(tagTypeId);
                    }
                    #endregion


                    #region 生成文字

                    TextNoteOptions opts = new TextNoteOptions();
                    opts.HorizontalAlignment = HorizontalTextAlignment.Left;
                    opts.TypeId = doc.GetDefaultElementTypeId(ElementTypeGroup.TextNoteType);

                    //水管、圆形风管算中心
                    if (element is Pipe)//水管
                    {
                        textPt = tagHeadLocation + tagDirection * (2000 / 304.8) + XYZ.BasisZ * (350 / 304.8);
                        tn = TextNote.Create(doc, view.Id, textPt, "H+" + netHeight.ToString(), opts);
                    }
                    else if (element is Duct)
                    {
                        string eid = element.get_Parameter(BuiltInParameter.ELEM_FAMILY_PARAM).AsValueString();
                        if (eid == "圆形风管")//圆形风管
                        {
                            textPt = tagHeadLocation + tagDirection * (2000 / 304.8) + XYZ.BasisZ * (350 / 304.8);
                            tn = TextNote.Create(doc, view.Id, textPt, "H+" + netHeight.ToString(), opts);
                        }
                        else//矩形风管
                        {
                            textPt = tagHeadLocation + tagDirection * (3100 / 304.8) + XYZ.BasisZ * (350 / 304.8);
                            tn = TextNote.Create(doc, view.Id, textPt, "B+" + netHeight.ToString(), opts);
                        }
                    }
                    else//桥架
                    {
                        textPt = tagHeadLocation + tagDirection * (3800 / 304.8) + XYZ.BasisZ * (350 / 304.8);
                        tn = TextNote.Create(doc, view.Id, textPt, "B+" + netHeight.ToString(), opts);
                    }
                    #endregion
                    
                    t.Commit();

                }
            }

            return Result.Succeeded;
        }
    }
}
