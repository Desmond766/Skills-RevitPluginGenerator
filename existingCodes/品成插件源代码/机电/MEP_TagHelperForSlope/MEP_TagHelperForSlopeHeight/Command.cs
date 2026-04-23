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


namespace MEP_TagHelperForSlopeHeight
{
    [Transaction(TransactionMode.Manual)]
    class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {

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
                    solid = GeometryCreationUtilities.CreateExtrusionGeometry(curveLoopList, XYZ.BasisZ, 20000000.0 / 304.8);
                }
                catch
                {
                    TaskDialog.Show("Revit", "不合法的三个点，无法形成三角形，请重新选择！");
                    return Result.Cancelled;
                }

                double height = 20000000.0 / 304.8;
                Outline outline = GetOutLine(new XYZ[] { pt1, pt2, pt3 }, height);
                BoundingBoxIntersectsFilter boxIntersectsFilter = new BoundingBoxIntersectsFilter(outline);

                //【3】根据创建的solid查找管线————————————————————————————————————————————————————————————————————————————————————————————————————————————————
                ElementIntersectsSolidFilter filter = new ElementIntersectsSolidFilter(solid);
                FilteredElementCollector collector = new FilteredElementCollector(doc, doc.ActiveView.Id);
                collector.WherePasses(boxIntersectsFilter).WherePasses(filter).OfClass(typeof(MEPCurve));

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
                    opts.TypeId = doc.GetDefaultElementTypeId(ElementTypeGroup.TextNoteType);
                    TextNote tn = null;
                    XYZ projectPoint = XYZ.Zero;
                    XYZ projectPointDo = XYZ.Zero;
                    XYZ point_Do = XYZ.Zero;
                    int index = 0;
                    //循环收集器
                    foreach (Element element in collectorToList)
                    {
                        Curve curve = ((element as MEPCurve).Location as LocationCurve).Curve;
                        XYZ p = Utils.GetMinZPoint(curve.GetEndPoint(0), curve.GetEndPoint(1));
                        ElementId id = element.Id;
                        Line flatLine = Line.CreateBound(new XYZ(curve.GetEndPoint(0).X, curve.GetEndPoint(0).Y, p.Z), new XYZ(curve.GetEndPoint(1).X, curve.GetEndPoint(1).Y, p.Z));
                        IntersectionResult iResult = flatLine.Project(pt2);
                        projectPoint = iResult.XYZPoint;

                        projectPoint = curve.Project(pt2).XYZPoint;

                        projectPointDo = Utils.GetReflectPoint(view3D, projectPoint + XYZ.BasisZ.Negate() * (1000 / 304.8), XYZ.BasisZ, id);
                        point_Do = new XYZ(projectPointDo.X, projectPointDo.Y, projectPointDo.Z - (1000 / 304.8));

                        //底部净高
                        double netHeight = Utils.GetClearHeight(view3D, doc, projectPoint, element.Id);

                        XYZ elbowLocation = new XYZ(pt2.X, pt2.Y, projectPoint.Z) + tagSpacing * index * crossDirection.Normalize();
                        XYZ tagHeadLocation = elbowLocation + tagDirection * headLeaderLength;
                        XYZ textPt = elbowLocation + tagDirection * (1000 / 304.8);

                        //水管、圆形风管算中心
                        if (element is Pipe)//水管
                        {
                            //double d = element.get_Parameter(BuiltInParameter.RBS_PIPE_OUTER_DIAMETER).AsDouble();
                            //netHeight = Math.Round(netHeight + 0.5 * d * 304.8, 0);
                            //netHeight = Math.Round(netHeight / 10, 0);
                            //int netHeightInt = (int)netHeight * 10;
                            netHeight = Math.Round(netHeight / 10, 0);
                            int netHeightInt = (int)netHeight * 10;
                            tn = TextNote.Create(doc, view.Id, textPt, "H+" + netHeightInt.ToString(), opts);
                        }
                        else if (element is Duct duct)
                        {
                            string eid = element.get_Parameter(BuiltInParameter.ELEM_FAMILY_PARAM).AsValueString();
                            if (eid == "圆形风管")//圆形风管
                            {
                                //double d1 = element.get_Parameter(BuiltInParameter.RBS_CURVE_DIAMETER_PARAM).AsDouble();
                                //netHeight = Math.Round(netHeight + 0.5 * d1 * 304.8, 0);
                                //netHeight = Math.Round(netHeight / 10, 0);
                                netHeight = Math.Round(netHeight / 10, 0);
                                int netHeightInt = (int)netHeight * 10;
                                tn = TextNote.Create(doc, view.Id, textPt, "H+" + netHeightInt.ToString(), opts);
                            }
                            else//矩形风管
                            {
                                double halfHeight = (duct.Height / 2) * 304.8;
                                netHeight = Math.Round(netHeight - halfHeight, 0);
                                netHeight = Math.Round(netHeight / 10, 0);
                                int netHeightInt = (int)netHeight * 10;
                                tn = TextNote.Create(doc, view.Id, textPt, "B+" + netHeightInt.ToString(), opts);
                            }
                        }
                        else//桥架
                        {
                            CableTray cableTray = (CableTray)element;
                            double halfHeight = (cableTray.Height / 2) * 304.8;
                            netHeight = Math.Round(netHeight - halfHeight, 0);
                            netHeight = Math.Round(netHeight / 10, 0);
                            int netHeightInt = (int)netHeight * 10;
                            tn = TextNote.Create(doc, view.Id, textPt, "B+" + netHeightInt.ToString(), opts);
                        }

                        if (isXDirectionCurve)
                        {
                            Leader l1 = tn.AddLeader(TextNoteLeaderTypes.TNLT_STRAIGHT_L);
                            l1.Elbow = elbowLocation + XYZ.BasisY.Negate() * 0.87;
                            l1.End = projectPoint;

                            //创建引线头详图
                            if (!arrowDetialSymbol.IsActive)
                            {
                                arrowDetialSymbol.Activate();
                            }
                            FamilyInstance arrowDetial = doc.Create.NewFamilyInstance(projectPoint, arrowDetialSymbol, view);
                            //tn.Location.Move(XYZ.BasisY * 0.85);
                        }
                        else//其他方向
                        {
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

                            tn.Location.Rotate(Line.CreateBound(textPt, textPt + XYZ.BasisZ * 1.0), XYZ.BasisX.AngleTo(tagDirection));
                            tn.Location.Move(XYZ.BasisX.Negate() * 0.85);
                            //tn.Location.Move(crossDirection.Normalize() * 2);
                            //TaskDialog.Show("a", "a");
                        }

                        index++;
                    }

                    t.Commit();

                }

            }

            return Result.Succeeded;
        }

        private Outline GetOutLine(XYZ[] points, double height)
        {
            List<double> sortX = points.Select(p => p.X).OrderBy(p => p).ToList();
            List<double> sortY = points.Select(p => p.Y).OrderBy(p => p).ToList();
            List<double> sortZ = points.Select(p => p.Z).OrderBy(p => p).ToList();
            XYZ min = new XYZ(sortX.First(), sortY.First(), sortZ.First());
            XYZ max = new XYZ(sortX.Last(), sortY.Last(), sortZ.Last() + height);
            Outline outline = new Outline(min, max);
            return outline;
        }
    }
}
