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

namespace MEP_TagHelper
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {

    //        #region 判断加密
    //        //注册验证
    //        string licFile = string.Format("{0}\\Key.lic",
    //System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
    //        if (!BTAddInHelper.Utils.CheckReg(licFile))
    //        {
    //            return Result.Cancelled;
    //        }
    //        #endregion

            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;

            //【1】判断视图————————————————————————————————————————————————————————————————————————————————————————————————————————————————
            if (!(doc.ActiveView is ViewPlan))
            {
                TaskDialog.Show("Revit", "请在平面视图中运行插件！");
                return Result.Cancelled;
            }
            View view = doc.ActiveView;

            while (true)
            {

                //【2】选择三点————————————————————————————————————————————————————————————————————————————————————————————————————————————————
                XYZ pt1 = XYZ.Zero;
                XYZ pt2 = XYZ.Zero;
                XYZ pt3 = XYZ.Zero;
                try
                {
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

                //根据三点创建拉伸Solid
                Solid solid = null;
                try
                {
                    pt1 = new XYZ(pt1.X, pt1.Y, -20000 / 304.8);
                    pt2 = new XYZ(pt2.X, pt2.Y, -20000 / 304.8);
                    pt3 = new XYZ(pt3.X, pt3.Y, -20000 / 304.8);
                    XYZ pt4 = pt2 + (pt3 - pt2).Normalize() * 10 / 304.8;

                    Curve c1 = Line.CreateBound(pt1, pt2);
                    Curve c2 = Line.CreateBound(pt2, pt4);
                    Curve c3 = Line.CreateBound(pt4, pt1);
                    List<Curve> curveList = new List<Curve>() { c1, c2, c3 };
                    CurveLoop curveLoop = CurveLoop.Create(curveList);
                    List<CurveLoop> curveLoopList = new List<CurveLoop>() { curveLoop };
                    //向上拉伸5000
                    solid = GeometryCreationUtilities.CreateExtrusionGeometry(curveLoopList, XYZ.BasisZ, 500000.0 / 304.8);
                }
                catch
                {
                    TaskDialog.Show("Revit", "不合法的三个点，无法形成三角形，请重新选择！");
                    return Result.Succeeded;
                }

                //【3】根据创建的solid查找管线————————————————————————————————————————————————————————————————————————————————————————————————————————————————
                ElementIntersectsSolidFilter filter = new ElementIntersectsSolidFilter(solid);
                FilteredElementCollector collector = new FilteredElementCollector(doc, doc.ActiveView.Id);
                collector.WherePasses(filter).OfClass(typeof(MEPCurve));

                if (collector.Count() == 0)
                {
                    TaskDialog.Show("Revit", "未找到要标注的管线！");
                    return Result.Succeeded;
                }


                //【4】管线方向向量，判断管线是否平行————————————————————————————————————————————————————————————————————————————————————————————————————————————————
                Curve mepCurve = ((collector.First() as MEPCurve).Location as LocationCurve).Curve;
                if (!(mepCurve is Line) || Math.Abs(mepCurve.GetEndPoint(0).Z - mepCurve.GetEndPoint(1).Z) > 0.0001)
                {
                    TaskDialog.Show("Revit", "仅支持水平直线管线！");
                    return Result.Succeeded;
                }
                Line mepLine = mepCurve as Line;
                XYZ mepDirection = mepLine.Direction;

                //【5】标注前——————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————
                //判断管线方向
                bool isXDirectionCurve = false;
                if (mepDirection.IsAlmostEqualTo(XYZ.BasisX) || mepDirection.IsAlmostEqualTo(XYZ.BasisX.Negate()))
                {
                    isXDirectionCurve = true;
                }
                //确定标签方向
                XYZ tagDirection = mepDirection;
                if ((pt2 + mepDirection * 1.0).DistanceTo(pt3) > pt2.DistanceTo(pt3))
                {
                    tagDirection = tagDirection.Negate();
                }
                //确定引线方向
                XYZ crossDirection = mepDirection.CrossProduct(XYZ.BasisZ);
                if ((pt2 + crossDirection * 1.0).DistanceTo(pt1) < pt2.DistanceTo(pt1))
                {
                    crossDirection = crossDirection.Negate();
                }

                //用户自定义参数
                double tagSpacing = 550 / 304.8;
                double headLeaderLength = 600.0 / 304.8;

                //根据名称找标签族

                var tagFamilyName_RightAlign_CT = "PC_桥架标记_右对齐";
                var tagFamilyName_LeftAlign_CT = "PC_桥架标记_左对齐";
                ElementId tagTypeId_RightAlign_CT = null;
                ElementId tagTypeId_LeftAlign_CT = null;

                var tagFamilyName_RightAlign_DT = "PC_风管标记_右对齐";
                var tagFamilyName_LeftAlign_DT = "PC_风管标记_左对齐";
                ElementId tagTypeId_RightAlign_DT = null;
                ElementId tagTypeId_LeftAlign_DT = null;

                var tagFamilyName_RightAlign_PI = "PC_水管标记_右对齐";
                var tagFamilyName_LeftAlign_PI = "PC_水管标记_左对齐";
                ElementId tagTypeId_RightAlign_PI = null;
                ElementId tagTypeId_LeftAlign_PI = null;
                //try
                //{
                    tagTypeId_RightAlign_CT = Utils.FindTypeIdByFamilyName(doc, tagFamilyName_RightAlign_CT);
                    tagTypeId_LeftAlign_CT = Utils.FindTypeIdByFamilyName(doc, tagFamilyName_LeftAlign_CT);

                    tagTypeId_RightAlign_DT = Utils.FindTypeIdByFamilyName(doc, tagFamilyName_RightAlign_DT);
                    tagTypeId_LeftAlign_DT = Utils.FindTypeIdByFamilyName(doc, tagFamilyName_LeftAlign_DT);

                    tagTypeId_RightAlign_PI = Utils.FindTypeIdByFamilyName(doc, tagFamilyName_RightAlign_PI);
                    tagTypeId_LeftAlign_PI = Utils.FindTypeIdByFamilyName(doc, tagFamilyName_LeftAlign_PI);
                //}
                //catch
                //{
                //    TaskDialog.Show("提示", "检查是否载入品成标记族,\r\n位置：" + @"\\192.168.0.254\pc_2017\品成项目_2017\品成插件工作\0PC_标注族");
                //    return Result.Cancelled;
                //}
                ElementId tagTypeId = null;



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

                //按照构件到pt1距离降序排序收集到的构件
                List<Element> collectorToList = new List<Element>();
                foreach (var item in collector)
                {
                    collectorToList.Add(item);
                }

                collectorToList = collectorToList.OrderBy(u => pt1.DistanceTo
                    (Utils.GetProjectivePoint(((u as MEPCurve).Location as LocationCurve).Curve.GetEndPoint(0), ((u as MEPCurve).Location as LocationCurve).Curve.GetEndPoint(1), pt1))).ToList();

                //【6】创建标签———————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————
                using (Transaction t = new Transaction(doc, "TAGHELPER"))
                {
                    t.Start();

                    int index = 0;
                    //循环收集器
                    foreach (Element element in collectorToList)
                    {
                        //IndependentTag tag = doc.Create.NewTag(view, element, true, TagMode.TM_ADDBY_CATEGORY, TagOrientation.Horizontal, XYZ.Zero);
                        IndependentTag tag = IndependentTag.Create(doc, view.Id, new Reference(element), true, TagMode.TM_ADDBY_CATEGORY, TagOrientation.Horizontal, XYZ.Zero);
                        XYZ elbowLocation = pt2 + tagSpacing * index * crossDirection;
                        tag.TagHeadPosition = elbowLocation + tagDirection * headLeaderLength;

                        //X方向
                        if (isXDirectionCurve)
                        {
                            tag.LeaderElbow = elbowLocation;
                            Curve curve = ((element as MEPCurve).Location as LocationCurve).Curve;
                            IntersectionResult iResult = curve.Project(pt2);
                            XYZ projectPoint = iResult.XYZPoint;
                            //创建引线头详图
                            if (!arrowDetialSymbol.IsActive)
                            {
                                arrowDetialSymbol.Activate();
                            }
                            FamilyInstance arrowDetial = doc.Create.NewFamilyInstance(projectPoint, arrowDetialSymbol, view);
                        }
                        else//其他方向
                        {
                            tag.HasLeader = false;
                            //创建详图线
                            Curve curve = ((element as MEPCurve).Location as LocationCurve).Curve;
                            IntersectionResult iResult = curve.Project(pt2);
                            XYZ projectPoint = iResult.XYZPoint;
                            projectPoint = new XYZ(projectPoint.X, projectPoint.Y, pt2.Z);
                            doc.Create.NewDetailCurve(view, Line.CreateBound(projectPoint, elbowLocation));
                            doc.Create.NewDetailCurve(view, Line.CreateBound(elbowLocation, elbowLocation + tagDirection * headLeaderLength));
                            //创建引线头详图
                            if (!arrowDetialSymbol.IsActive)
                            {
                                arrowDetialSymbol.Activate();
                            }
                            FamilyInstance arrowDetial = doc.Create.NewFamilyInstance(projectPoint, arrowDetialSymbol, view);
                        }

                        if (element is CableTray)
                        {
                            tagTypeId = tagTypeId_LeftAlign_CT;
                            //修正tagTypeId
                            if (Utils.LeftOfLine(pt3, pt1, pt2))
                            {
                                tagTypeId = tagTypeId_RightAlign_CT;
                            }
                        }
                        else if (element is Duct)
                        {
                            tagTypeId = tagTypeId_LeftAlign_DT;
                            //修正tagTypeId
                            if (Utils.LeftOfLine(pt3, pt1, pt2))
                            {
                                tagTypeId = tagTypeId_RightAlign_DT;
                            }
                        }
                        else
                        {
                            tagTypeId = tagTypeId_LeftAlign_PI;
                            //修正tagTypeId
                            if (Utils.LeftOfLine(pt3, pt1, pt2))
                            {
                                tagTypeId = tagTypeId_RightAlign_PI;
                            }
                        }


                        //替换族类型
                        if (tag.GetTypeId() != tagTypeId)
                        {
                            tag.ChangeTypeId(tagTypeId);
                        }

                        index++;
                    }
                    t.Commit();
                }

            }



            return Result.Succeeded;
        }

    }
}
