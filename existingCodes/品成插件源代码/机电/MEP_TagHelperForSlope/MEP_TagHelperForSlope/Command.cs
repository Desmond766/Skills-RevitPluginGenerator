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

namespace MEP_TagHelperForSlope
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //#region 判断加密
            ////注册验证
            //string licFile = string.Format("{0}\\Key.lic",
            //System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
            //if (!BTAddInHelper.Utils.CheckReg(licFile))
            //{
            //    return Result.Cancelled;
            //}
            //#endregion

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

            //JL UPDATE 2021-10-18
            //程序在3D 机电视图中完成
            //改为
            //先找当前视图 对应的3D视图， 找不到再用3D 机电，命名规则 3D {当前视图名称}
            View3D view3D = null;
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
                    //JL update: 2021-10-18
                    //将原来的 -20000/304.8 改为 pt1.Z-20000/304.8
                    //将起点由+-0 改为当前视图高度，然后再向下 向上拉伸查找管道
                    pt1 = new XYZ(pt1.X, pt1.Y, pt1.Z - 2000000 / 304.8);
                    pt2 = new XYZ(pt2.X, pt2.Y, pt2.Z - 2000000 / 304.8);
                    pt3 = new XYZ(pt3.X, pt3.Y, pt3.Z - 2000000 / 304.8);
                    XYZ pt4 = pt2 + (pt3 - pt2).Normalize() * 10 / 304.8;

                    Curve c1 = Line.CreateBound(pt1, pt2);
                    Curve c2 = Line.CreateBound(pt2, pt4);
                    Curve c3 = Line.CreateBound(pt4, pt1);
                    List<Curve> curveList = new List<Curve>() { c1, c2, c3 };
                    CurveLoop curveLoop = CurveLoop.Create(curveList);
                    List<CurveLoop> curveLoopList = new List<CurveLoop>() { curveLoop };
                    //向上拉伸5000
                    solid = GeometryCreationUtilities.CreateExtrusionGeometry(curveLoopList, XYZ.BasisZ, 20000000.0 / 304.8);
                }
                catch
                {
                    TaskDialog.Show("Revit", "不合法的三个点，无法形成三角形，请重新选择！");
                    return Result.Cancelled;
                }

                //【3】根据创建的solid查找管线————————————————————————————————————————————————————————————————————————————————————————————————————————————————
                ElementIntersectsSolidFilter filter = new ElementIntersectsSolidFilter(solid);
                FilteredElementCollector collector = new FilteredElementCollector(doc, doc.ActiveView.Id);
                collector.WherePasses(filter).OfClass(typeof(MEPCurve));

                TaskDialog.Show("re", (new FilteredElementCollector(doc, doc.ActiveView.Id).OfClass(typeof(MEPCurve))).Count().ToString() + pt1);

                if (collector.Count() == 0)
                {
                    TaskDialog.Show("Revit", "未找到要标注的管线！");
                    return Result.Cancelled;
                }

                //【4】管线方向向量，判断管线是否平行————————————————————————————————————————————————————————————————————————————————————————————————————————————————
                Curve mepCurve = ((collector.First() as MEPCurve).Location as LocationCurve).Curve;
                if (!(mepCurve is Line))
                {
                    TaskDialog.Show("Revit", "仅支持直线管线！");
                    return Result.Cancelled;
                }

                Line mepLine = mepCurve as Line;
                XYZ endPoint0 = mepLine.GetEndPoint(0);
                XYZ endPoint1 = mepLine.GetEndPoint(1);
                endPoint0 = new XYZ(endPoint0.X, endPoint0.Y, pt2.Z);
                endPoint1 = new XYZ(endPoint1.X, endPoint1.Y, pt2.Z);
                XYZ mepDirection = (endPoint1 - endPoint0).Normalize();
                //【5】标注前——————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————
                //判断管线方向
                bool isXDirectionCurve = false;
                if (mepDirection.IsAlmostEqualTo(XYZ.BasisX) || mepDirection.IsAlmostEqualTo(XYZ.BasisX.Negate()))
                {
                    isXDirectionCurve = true;
                }
                bool isYDirectionCurve = false;
                if (mepDirection.IsAlmostEqualTo(XYZ.BasisY) || mepDirection.IsAlmostEqualTo(XYZ.BasisY.Negate()))
                {
                    isYDirectionCurve = true;
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
                double tagSpacing = 450 / 304.8;
                double headLeaderLength = 300.0 / 304.8;


                //根据名称找标签族

                var tagFamilyName_RightAlign_CT = "PC_桥架系统尺寸_右对齐";
                var tagFamilyName_LeftAlign_CT = "PC_桥架系统尺寸_左对齐";
                ElementId tagTypeId_RightAlign_CT = null;
                ElementId tagTypeId_LeftAlign_CT = null;

                var tagFamilyName_RightAlign_DT = "PC_风管系统尺寸_右对齐";
                var tagFamilyName_LeftAlign_DT = "PC_风管系统尺寸_左对齐";
                ElementId tagTypeId_RightAlign_DT = null;
                ElementId tagTypeId_LeftAlign_DT = null;

                var tagFamilyName_RightAlign_PI = "PC_水管系统尺寸_右对齐";
                var tagFamilyName_LeftAlign_PI = "PC_水管系统尺寸_左对齐";
                ElementId tagTypeId_RightAlign_PI = null;
                ElementId tagTypeId_LeftAlign_PI = null;

                var tagFamilyName_RightAlign_DT1 = "PC_圆形风管系统尺寸_右对齐";
                var tagFamilyName_LeftAlign_DT1 = "PC_圆形风管系统尺寸_左对齐";
                ElementId tagTypeId_RightAlign_DT1 = null;
                ElementId tagTypeId_LeftAlign_DT1 = null;

                try
                {
                    tagTypeId_RightAlign_CT = Utils.FindTypeIdByFamilyName(doc, tagFamilyName_RightAlign_CT);
                    tagTypeId_LeftAlign_CT = Utils.FindTypeIdByFamilyName(doc, tagFamilyName_LeftAlign_CT);

                    tagTypeId_RightAlign_DT = Utils.FindTypeIdByFamilyName(doc, tagFamilyName_RightAlign_DT);
                    tagTypeId_LeftAlign_DT = Utils.FindTypeIdByFamilyName(doc, tagFamilyName_LeftAlign_DT);

                    tagTypeId_RightAlign_PI = Utils.FindTypeIdByFamilyName(doc, tagFamilyName_RightAlign_PI);
                    tagTypeId_LeftAlign_PI = Utils.FindTypeIdByFamilyName(doc, tagFamilyName_LeftAlign_PI);

                    tagTypeId_RightAlign_DT1 = Utils.FindTypeIdByFamilyName(doc, tagFamilyName_RightAlign_DT1);
                    tagTypeId_LeftAlign_DT1 = Utils.FindTypeIdByFamilyName(doc, tagFamilyName_LeftAlign_DT1);
                }
                catch
                {
                    TaskDialog.Show("提示", "检查是否载入品成标记族,\r\n位置：" + @"\\192.168.0.254\pc_2017\品成项目_2017\品成插件工作\0PC_标注族");
                    return Result.Cancelled;
                }
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

                    TextNoteOptions opts = new TextNoteOptions();
                    opts.HorizontalAlignment = HorizontalTextAlignment.Center;
                    //opts.TypeId = doc.GetDefaultElementTypeId(ElementTypeGroup.TextNoteType);
                    ElementId elemId = null;
                    Element element1 = new FilteredElementCollector(doc).OfClass(typeof(TextNoteType)).Where(x => x.LookupParameter("文字大小").AsDouble() == 2.5 / 304.8).FirstOrDefault();
                    if (element1 == null)
                    {
                        elemId = CreateTextNoteType(doc, 2.5).Id;
                    }
                    else
                    {
                        elemId = element1.Id;
                    }
                    opts.TypeId = elemId;
                    TextNote tn = null;
                    XYZ projectPoint = XYZ.Zero;
                    XYZ projectPointDo = XYZ.Zero;
                    XYZ point_Do = XYZ.Zero;
                    int index = 0;
                    //循环收集器
                    foreach (Element element in collectorToList)
                    {
                        Curve curve = ((element as MEPCurve).Location as LocationCurve).Curve;
                        //double dd = curve.GetEndPoint(0).Z - curve.GetEndPoint(1).Z;
                        //if (dd != 0)
                        //{
                        XYZ p = Utils.GetMinZPoint(curve.GetEndPoint(0), curve.GetEndPoint(1));
                        ElementId id = element.Id;
                        //TaskDialog.Show("a", dd.ToString());
                        Line flatLine = Line.CreateBound(new XYZ(curve.GetEndPoint(0).X, curve.GetEndPoint(0).Y, p.Z), new XYZ(curve.GetEndPoint(1).X, curve.GetEndPoint(1).Y, p.Z));
                        IntersectionResult iResult = flatLine.Project(pt2);
                        projectPoint = iResult.XYZPoint;
                        projectPointDo = Utils.GetReflectPoint(view3D, projectPoint + XYZ.BasisZ.Negate() * (1000 / 304.8), XYZ.BasisZ, id);
                        point_Do = new XYZ(projectPointDo.X, projectPointDo.Y, projectPointDo.Z - (1000 / 304.8));
                        // Utils.DrawModelCurve(doc, point_Do, point_Do + crossDirection * 10);
                        // }
                        //else
                        //{
                        //    IntersectionResult iResult = curve.Project(pt2);
                        //    projectPoint = iResult.XYZPoint;
                        //    projectPointDo = projectPoint;
                        //    point_Do = new XYZ(projectPointDo.X, projectPointDo.Y, projectPointDo.Z - (1000 / 304.8));
                        //}

                        //Utils.DrawModelCurve(doc, point_Do, point_Do + crossDirection * 10);
                        //Utils.DrawModelCurve(doc, projectPoint, projectPoint + crossDirection * 10);
                        //Utils.DrawModelCurve(doc, projectPointDo, projectPointDo + crossDirection * 10);

                        //底部净高
                        double netHeight = Utils.GetClearHeight(view3D, doc, point_Do, element.Id);




                        //TaskDialog.Show("a", netHeight.ToString());
                        Reference refe = new Reference(element);
                        IndependentTag tag = IndependentTag.Create(doc, view.Id, refe, true, TagMode.TM_ADDBY_CATEGORY, TagOrientation.Horizontal, XYZ.Zero);
                        XYZ elbowLocation = new XYZ(pt2.X, pt2.Y, projectPoint.Z) + tagSpacing * index * crossDirection.Normalize();
                        XYZ tagHeadLocation = elbowLocation + tagDirection * headLeaderLength;

                        tag.TagHeadPosition = tagHeadLocation;

                        XYZ textPt = projectPoint;


                        //水管、圆形风管算中心
                        if (element is Pipe)//水管
                        {
                            double d = element.get_Parameter(BuiltInParameter.RBS_PIPE_OUTER_DIAMETER).AsDouble();
                            netHeight = Math.Round(netHeight + 0.5 * d * 304.8, 0);
                            netHeight = Math.Round(netHeight / 10, 0);
                            int netHeightInt = (int)netHeight * 10;
                            //textPt = elbowLocation + tagDirection * (2500/304.8);

                            //Utils.GetProjectivePoint1(
                            //    elbowLocation, 
                            //    tagHeadLocation + (tagDirection - elbowLocation) * 100.0,
                            //    tn);
                            XYZ dirOffest = crossDirection;
                            if (crossDirection.AngleTo(doc.ActiveView.UpDirection) >= Math.PI)
                            {
                                dirOffest = crossDirection.Negate();
                            }
                            //textPt = tagHeadLocation + tagDirection * (2500 / 304.8) + dirOffest * (350 / 304.8);
                            textPt = tagHeadLocation + tagDirection * (2500 / 304.8) + XYZ.BasisZ * (350 / 304.8);
                            tn = TextNote.Create(doc, view.Id, textPt, "CL+" + netHeightInt.ToString(), opts);
                        }
                        else if (element is Duct)
                        {
                            string eid = element.get_Parameter(BuiltInParameter.ELEM_FAMILY_PARAM).AsValueString();
                            if (eid == "圆形风管")//圆形风管
                            {
                                double d1 = element.get_Parameter(BuiltInParameter.RBS_CURVE_DIAMETER_PARAM).AsDouble();
                                netHeight = Math.Round(netHeight + 0.5 * d1 * 304.8, 0);
                                netHeight = Math.Round(netHeight / 10, 0);
                                int netHeightInt = (int)netHeight * 10;
                                textPt = elbowLocation + tagDirection * (2500 / 304.8);
                                tn = TextNote.Create(doc, view.Id, textPt, "CL+" + netHeightInt.ToString(), opts);
                            }
                            else//矩形风管
                            {
                                netHeight = Math.Round(netHeight / 10, 0);
                                int netHeightInt = (int)netHeight * 10;
                                textPt = elbowLocation + tagDirection * (3100 / 304.8);
                                tn = TextNote.Create(doc, view.Id, textPt, "BL+" + netHeightInt.ToString(), opts);
                            }
                        }
                        else//桥架
                        {
                            netHeight = Math.Round(netHeight / 10, 0);
                            int netHeightInt = (int)netHeight * 10;
                            textPt = elbowLocation + tagDirection * (4200 / 304.8);
                            tn = TextNote.Create(doc, view.Id, textPt, "BL+" + netHeightInt.ToString(), opts);
                        }


                        //X方向
                        if (isXDirectionCurve)
                        {
                            tag.LeaderElbow = elbowLocation;
                            //创建引线头详图
                            if (!arrowDetialSymbol.IsActive)
                            {
                                arrowDetialSymbol.Activate();
                            }
                            FamilyInstance arrowDetial = doc.Create.NewFamilyInstance(projectPoint, arrowDetialSymbol, view);
                            tn.Location.Move(XYZ.BasisY * 0.85);
                        }
                        else//其他方向
                        {
                            tag.HasLeader = false;
                            //创建详图线
                            //projectPoint = new XYZ(projectPoint.X, projectPoint.Y, pt2.Z);
                            elbowLocation = new XYZ(elbowLocation.X, elbowLocation.Y, projectPoint.Z);
                            tagHeadLocation = new XYZ(tagHeadLocation.X, tagHeadLocation.Y, projectPoint.Z);

                            doc.Create.NewDetailCurve(view, Line.CreateBound(projectPoint, elbowLocation));
                            doc.Create.NewDetailCurve(view, Line.CreateBound(elbowLocation, tagHeadLocation));

                            //Utils.DrawModelCurve(doc, projectPoint, elbowLocation);
                            //Utils.DrawModelCurve(doc, elbowLocation, tagHeadLocation);
                            //创建引线头详图
                            if (!arrowDetialSymbol.IsActive)
                            {
                                arrowDetialSymbol.Activate();
                            }
                            FamilyInstance arrowDetial = doc.Create.NewFamilyInstance(projectPoint, arrowDetialSymbol, view);
                            double angle;
                            if (XYZ.BasisX.AngleTo(tagDirection) > Math.PI / 2)
                            {
                                angle = Math.Abs(XYZ.BasisX.AngleTo(tagDirection) - Math.PI);
                            }
                            else
                            {
                                angle = XYZ.BasisX.AngleTo(tagDirection);
                            }
                            tn.Location.Rotate(Line.CreateBound(textPt, textPt + XYZ.BasisZ * 1.0),angle);
                            tn.Location.Move(XYZ.BasisX.Negate() * 0.85);
                            //tn.Location.Move(crossDirection.Normalize() * 2);
                            //TaskDialog.Show("a", "a");
                        }
                        bool isRotaToXGreaterThan45;
                        double angleToX = flatLine.Direction.AngleTo(XYZ.BasisX);
                        if(angleToX > Math.PI / 2) angleToX = Math.Abs(angleToX - Math.PI);
                        if (angleToX > Math.PI / 4)
                        {
                            isRotaToXGreaterThan45 = true;
                        }
                        else
                        {
                            isRotaToXGreaterThan45= false;
                        }
                        //if (isYDirectionCurve)
                        if (isRotaToXGreaterThan45)
                        {

                            if (element is CableTray)
                            {
                                tagTypeId = tagTypeId_LeftAlign_CT;
                                //修正tagTypeId
                                if (Utils.YLeftOfLine(pt3, pt1, pt2))
                                {
                                    tagTypeId = tagTypeId_RightAlign_CT;
                                }
                            }
                            else if (element is Duct)
                            {
                                string eid = element.get_Parameter(BuiltInParameter.ELEM_FAMILY_PARAM).AsValueString();
                                if (eid == "圆形风管")
                                {
                                    tagTypeId = tagTypeId_LeftAlign_DT1;
                                    //修正tagTypeId
                                    if (Utils.YLeftOfLine(pt3, pt1, pt2))
                                    {
                                        tagTypeId = tagTypeId_RightAlign_DT1;
                                    }
                                }
                                else
                                {
                                    tagTypeId = tagTypeId_LeftAlign_DT;
                                    //修正tagTypeId
                                    if (Utils.YLeftOfLine(pt3, pt1, pt2))
                                    {
                                        tagTypeId = tagTypeId_RightAlign_DT;
                                    }
                                }

                            }
                            else
                            {
                                tagTypeId = tagTypeId_LeftAlign_PI;
                                //修正tagTypeId
                                if (Utils.YLeftOfLine(pt3, pt1, pt2))
                                {
                                    tagTypeId = tagTypeId_RightAlign_PI;
                                }
                            }
                        }
                        else
                        {
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
                                string eid = element.get_Parameter(BuiltInParameter.ELEM_FAMILY_PARAM).AsValueString();
                                if (eid == "圆形风管")
                                {
                                    tagTypeId = tagTypeId_LeftAlign_DT1;
                                    //修正tagTypeId
                                    if (Utils.LeftOfLine(pt3, pt1, pt2))
                                    {
                                        tagTypeId = tagTypeId_RightAlign_DT1;
                                    }
                                }
                                else
                                {
                                    tagTypeId = tagTypeId_LeftAlign_DT;
                                    //修正tagTypeId
                                    if (Utils.LeftOfLine(pt3, pt1, pt2))
                                    {
                                        tagTypeId = tagTypeId_RightAlign_DT;
                                    }
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

        public TextNoteType CreateTextNoteType(Document doc, double newFontSize)
        {
            // 获取文档中第一个 TextNoteType 作为模板
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            TextNoteType templateTextNoteType = collector.OfClass(typeof(TextNoteType))
                                                         .FirstOrDefault() as TextNoteType;
            string newTextTypeName = newFontSize + "mm";

            if (templateTextNoteType == null)
            {
                TaskDialog.Show("Error", "No TextNoteType found in the document.");
                return null;
            }

            // 复制模板 TextNoteType 创建新的 TextNoteType
            ElementId newTextNoteTypeId = templateTextNoteType.Duplicate(newTextTypeName).Id;

            TextNoteType newTextNoteType = doc.GetElement(newTextNoteTypeId) as TextNoteType;

            if (newTextNoteType == null)
            {
                TaskDialog.Show("Error", "Failed to create new TextNoteType.");
                return null;
            }

            // 修改新的 TextNoteType 的字体大小
            //using (Transaction trans = new Transaction(doc, "设置字体大小"))
            //{
            //    trans.Start();

                // 字体大小属性名称因版本不同可能会有不同，这里假设是 "Text Size"
                newTextNoteType.get_Parameter(BuiltInParameter.TEXT_SIZE).Set(newFontSize / 304.8);

            //    trans.Commit();
            //}
            return newTextNoteType;
        }
    }
}
