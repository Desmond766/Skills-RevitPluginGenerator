using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NewTextNoteForSlope
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uIDoc = commandData.Application.ActiveUIDocument;
            Selection sel = uIDoc.Selection;
            Document doc = uIDoc.Document;

            //MainWindow mainWindow = new MainWindow();
            //PreviewControl previewControl = new PreviewControl(doc, uIDoc.ActiveGraphicalView.Id);
            //mainWindow.main_grid.Children.Add(previewControl);
            //mainWindow.ShowDialog();
            //return Result.Succeeded;

            if (!(doc.ActiveView is ViewPlan))
            {
                TaskDialog.Show("Revit", "请在平面视图中运行插件！");
                return Result.Cancelled;
            }
            View view = doc.ActiveView;

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

            // 打开指定视图中楼板的可见性
            var openIds = DisplayFloor(doc, view3D, out bool isHidden);

        //using (Transaction t = new Transaction(doc, "ds"))
        //{
        //    t.Start();
        //    uIDoc.RefreshActiveView();
        //    doc.Regenerate();
        //    t.Commit();
        //}
        SelectPipeLine:
            XYZ p1 = null;
            XYZ p2 = null;
            XYZ p3 = null;
            try
            {
                p1 = sel.PickPoint();
                p2 = sel.PickPoint();
                p3 = sel.PickPoint();
            }
            catch (Exception)
            {
                // 恢复视图中楼板的可见性
                HiddenFloor(doc, view3D, openIds, isHidden);
                TaskDialog.Show("提示", "结束布置");
                return Result.Succeeded;
            }
            XYZ min = p1;
            XYZ max = p2;
            if (p1.X > p2.X)
            {
                min = new XYZ(p2.X, min.Y, min.Z);
                max = new XYZ(p1.X, max.Y, max.Z);
            }
            if (p1.Y > p2.Y)
            {
                min = new XYZ(min.X, p2.Y, min.Z);
                max = new XYZ(max.X, p1.Y, max.Z);
            }
            min = new XYZ(min.X, min.Y, min.Z - 20000 / 304.8);
            max = new XYZ(max.X, max.Y, 20000000.0 / 304.8);
            Outline outline = new Outline(min, max);
            BoundingBoxIntersectsFilter intersectsFilter = new BoundingBoxIntersectsFilter(outline);

            List<Element> mepCurves = new FilteredElementCollector(doc, doc.ActiveView.Id)
                .WherePasses(intersectsFilter).OfClass(typeof(MEPCurve)).ToList();
            if (mepCurves.Count == 0)
            {
                TaskDialog.Show("提示", "未找到要标注的管线！");
                return Result.Succeeded;
            }
            Curve firstCurve = ((mepCurves.First() as MEPCurve).Location as LocationCurve).Curve;
            if (!(firstCurve is Line))
            {
                TaskDialog.Show("提示", "仅支持直线管线");
                return Result.Succeeded;
            }
            //对mepcurve进行排序
            mepCurves = mepCurves.OrderByDescending(m => m.GetLength(p3)).ToList();

            Line mepLine = firstCurve as Line;
            XYZ endPoint0 = mepLine.GetEndPoint(0);
            XYZ endPoint1 = mepLine.GetEndPoint(1);
            endPoint0 = new XYZ(endPoint0.X, endPoint0.Y, p2.Z);
            endPoint1 = new XYZ(endPoint1.X, endPoint1.Y, p2.Z);
            XYZ mepDirection = (endPoint1 - endPoint0).Normalize();
            //确定标签方向
            XYZ tagDirection = mepDirection;
            if ((p2 + mepDirection * 1.0).DistanceTo(p3) > p2.DistanceTo(p3))
            {
                tagDirection = tagDirection.Negate();
            }
            //确定引线方向
            XYZ crossDirection = mepDirection.CrossProduct(XYZ.BasisZ);
            if ((p2 + crossDirection * 1.0).DistanceTo(p1) < p2.DistanceTo(p1))
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
                TaskDialog.Show("提示", "检查是否载入品成标记点");
                return Result.Cancelled;
            }
            XYZ flp = (new XYZ(p1.X,p1.Y,0)).DistanceTo(new XYZ(p3.X,p3.Y,0)) < (new XYZ(p2.X, p2.Y, 0)).DistanceTo(new XYZ(p3.X, p3.Y, 0))
                ? p1 : p2;
            int i = 0;

            TransactionGroup TG = new TransactionGroup(doc, "平面注释");
            TG.Start();
            using (Transaction tView = new Transaction(doc, "设置视图详细程度"))
            {
                tView.Start();

                view3D.get_Parameter(BuiltInParameter.VIEW_DETAIL_LEVEL).Set(3);

                tView.Commit();
            }
            foreach (var item in mepCurves)
            {
                Transaction t = new Transaction(doc, "平面标注");
                t.Start();
                double clearHight = 0;
                string createInfo = "";
                //1.创建引线
                Line line = ((item as MEPCurve).Location as LocationCurve).Curve as Line;
                flp = new XYZ(flp.X, flp.Y, line.Evaluate(0.5, true).Z);
                Line newLine = line.Clone() as Line;
                newLine.MakeUnbound();
                XYZ pp = newLine.Project(flp).XYZPoint;
                try
                {
                    /* TODO:两个问题：1.在三维视图关闭与开启时，模型的solid可能发生变化导致高度错误
                     2.更改模型详细程度后文档未及时更新，导致无法找到管线等元素从而导致无法创建文字注释 25.1.14*/
                    clearHight = Utils.GetClearHeight(view3D, doc, pp);
                    //TaskDialog.Show("revit", pp.ToString() + view3D.get_Parameter(BuiltInParameter.VIEW_DETAIL_LEVEL).AsValueString() + clearHight);
                    //clearHight = 2800;
                }
                catch (Exception e)
                {
                    t.RollBack();
                    TaskDialog.Show("Error", "未在3D 机电视图中找到楼板，无法计算高度");
                    break;
                }
                XYZ op = new XYZ(flp.X, flp.Y, pp.Z) + crossDirection * tagSpacing * i;
                XYZ tnp = op + tagDirection * headLeaderLength;
                doc.Create.NewDetailCurve(view, Line.CreateBound(pp, op));
                doc.Create.NewDetailCurve(view, Line.CreateBound(op, tnp));
                i++;
                //2.创建引线头
                //创建引线头详图
                if (!arrowDetialSymbol.IsActive)
                {
                    arrowDetialSymbol.Activate();
                }
                FamilyInstance arrowDetial = doc.Create.NewFamilyInstance(pp, arrowDetialSymbol, view);
                //3.获取文字注释内容并创建文字注释
                createInfo = item.GetTextNoteInfo2(clearHight);
                //获取当前视图的比例
                int scale = doc.ActiveView.Scale;

                TextNoteOptions opts = new TextNoteOptions();
                opts.HorizontalAlignment = HorizontalTextAlignment.Center;
                Element element1 = new FilteredElementCollector(doc).OfClass(typeof(TextNoteType)).FirstOrDefault();
                opts.TypeId = element1.Id;
                TextNote textNote = TextNote.Create(doc, doc.ActiveView.Id, tnp, createInfo, opts);
                t.Commit();
                Transaction t2 = new Transaction(doc, "移动旋转注释");
                t2.Start();
                double angle;
                double _90angle = Math.PI * 0.5;
                XYZ translation = tagDirection * (textNote.Width * scale / 2);
                if (tagDirection.IsAlmostEqualTo(XYZ.BasisY) || tagDirection.IsAlmostEqualTo(XYZ.BasisY.Negate()))
                {
                    if (crossDirection.IsAlmostEqualTo(XYZ.BasisX))
                    {
                        //TaskDialog.Show("revit", "tagdir:y,crossdir:x");
                        translation -= crossDirection * (textNote.Height * scale / 2);
                    }
                    else
                    {
                        //TaskDialog.Show("revit", "tagdir:y,!crossdir:x");
                        translation += crossDirection * (textNote.Height * scale / 2);
                    }
                }
                else if (tagDirection.IsAlmostEqualTo(XYZ.BasisX) || tagDirection.IsAlmostEqualTo(XYZ.BasisX.Negate()))
                {
                    if (crossDirection.IsAlmostEqualTo(XYZ.BasisY))
                    {
                        //TaskDialog.Show("revit", "tagdir:x,crossdir:y");
                        translation += crossDirection * (textNote.Height * scale / 2);
                    }
                    else
                    {
                        //TaskDialog.Show("revit", "tagdir:x,!crossdir:y");
                        translation -= crossDirection * (textNote.Height * scale / 2);
                    }
                }
                else if ((endPoint0.Y - endPoint1.Y) / (endPoint0.X - endPoint1.X) > 0)
                {
                    if (crossDirection.AngleTo(XYZ.BasisX) > _90angle)
                    {
                        translation += crossDirection * (textNote.Height * scale / 2);
                    }
                    else
                    {
                        translation -= crossDirection * (textNote.Height * scale / 2);
                    }
                }
                else if ((endPoint0.Y - endPoint1.Y) / (endPoint0.X - endPoint1.X) < 0)
                {
                    if (crossDirection.AngleTo(XYZ.BasisX) > _90angle)
                    {
                        translation -= crossDirection * (textNote.Height * scale / 2);
                    }
                    else
                    {
                        translation += crossDirection * (textNote.Height * scale / 2);
                    }
                }
                //TaskDialog.Show("revit", $"{crossDirection.AngleTo(XYZ.BasisX)}\n{_45angle}\n{crossDirection}");
                if (XYZ.BasisX.AngleTo(tagDirection) > Math.PI / 2)
                {
                    angle = Math.Abs(XYZ.BasisX.AngleTo(tagDirection) - Math.PI);
                }
                else
                {
                    angle = XYZ.BasisX.AngleTo(tagDirection);
                    //translation = translation - crossDirection * (textNote.Height * scale);
                }

                textNote.Location.Move(translation);

                //var boungdingbox = textNote.get_BoundingBox(doc.ActiveView);
                XYZ rotatePoint = textNote.Coord;
                //rotatePoint = boungdingbox.Min.Add(boungdingbox.Max) / 2;

                Line rotateLine = Line.CreateBound(rotatePoint, rotatePoint + XYZ.BasisZ * 1);
                // 标注位置不准的原因，只影响平行于xy轴的管道 25.7.9
                bool isVerLine = mepLine.Direction.IsAlmostEqualTo(XYZ.BasisX) || mepLine.Direction.IsAlmostEqualTo(XYZ.BasisX.Negate()) || mepLine.Direction.IsAlmostEqualTo(XYZ.BasisY) || mepLine.Direction.IsAlmostEqualTo(XYZ.BasisY.Negate());
                if (!isVerLine && (endPoint0.Y - endPoint1.Y) / (endPoint0.X - endPoint1.X) < 0)
                {
                    rotateLine = Line.CreateBound(rotatePoint, rotatePoint + XYZ.BasisZ.Negate() * 1);
                }
                textNote.Location.Rotate(rotateLine, angle);

                //TaskDialog.Show("re", XYZ.BasisX.AngleTo(tagDirection).ToString());
                t2.Commit();
            }
            TG.Assimilate();
            goto SelectPipeLine;
        }
        private void HiddenFloor(Document doc, View3D view3D, List<ElementId> openIds, bool isHidden)
        {
            using (Transaction t = new Transaction(doc, "可见性设置"))
            {
                t.Start();
                try
                {
                    foreach (var id in openIds)
                    {
                        view3D.SetFilterVisibility(id, false);
                    }
                    if (isHidden) view3D.SetCategoryHidden(new ElementId(-2000032), true);
                }
                catch (Exception)
                {
                    t.RollBack();
                    return;
                }

                t.Commit();
            }
        }

        private List<ElementId> DisplayFloor(Document doc, View view3D, out bool isHidden)
        {
            var closeIds = new List<ElementId>();
            var filterIds = view3D.GetFilters();
            using (Transaction t = new Transaction(doc, "可见性设置"))
            {
                t.Start();

                try
                {
                    foreach (var id in filterIds)
                    {
                        var filter = doc.GetElement(id);
                        if (filter.Name.Contains("结构板") || filter.Name.Contains("楼板"))
                        {
                            if (view3D.GetFilterVisibility(id)) continue;
                            view3D.SetFilterVisibility(id, true);
                            closeIds.Add(id);
                        }
                    }
                    //TaskDialog.Show("revit", view3D.GetCategoryHidden(new ElementId(-2000032)).ToString());
                    isHidden = view3D.GetCategoryHidden(new ElementId(-2000032));
                    if (isHidden) view3D.SetCategoryHidden(new ElementId(-2000032), false);
                }
                catch (Exception)
                {
                    isHidden = false;
                    closeIds = new List<ElementId>();
                    t.RollBack();
                    return closeIds;
                }

                t.Commit();
            }
            return closeIds;
        }
    }
    public static class Extension
    {
        public static double GetLength(this Element element, XYZ point)
        {
            double length = 0;
            MEPCurve mEPCurve = element as MEPCurve;
            Line line = (mEPCurve.Location as LocationCurve).Curve as Line;
            XYZ pp = line.Project(point).XYZPoint;
            XYZ oldPoint = new XYZ(point.X, point.Y, pp.Z);
            length = pp.DistanceTo(oldPoint);

            return length;
        }
        public static string GetTextNoteInfo(this Element item, double clearHight)
        {
            string createInfo = "";
            if (item is Pipe pipe)
            {
                // 中间高程-底部高程
                double downR = item.get_Parameter(BuiltInParameter.RBS_OFFSET_PARAM).AsDouble() - item.get_Parameter(BuiltInParameter.RBS_PIPE_BOTTOM_ELEVATION).AsDouble();
                clearHight = Math.Round(clearHight + downR * 304.8, 0);
                clearHight = Math.Round(clearHight / 10, 0) * 10;

                string sysName = pipe.get_Parameter(BuiltInParameter.RBS_DUCT_PIPE_SYSTEM_ABBREVIATION_PARAM).AsString();
                double d = pipe.get_Parameter(BuiltInParameter.RBS_PIPE_DIAMETER_PARAM).AsDouble() * 304.8;
                createInfo = sysName + " DN" + d + " CL+" + clearHight;
            }
            else if (item is Duct duct)
            {
                string eid = duct.get_Parameter(BuiltInParameter.ELEM_FAMILY_PARAM).AsValueString();
                if (eid == "圆形风管")
                {
                    double r = duct.get_Parameter(BuiltInParameter.RBS_CURVE_DIAMETER_PARAM).AsDouble() / 2 * 304.8;
                    clearHight = Math.Round(clearHight + r, 0);
                    clearHight = Math.Round(clearHight / 10, 0) * 10;

                    string sysName = duct.get_Parameter(BuiltInParameter.RBS_DUCT_PIPE_SYSTEM_ABBREVIATION_PARAM).AsString();
                    string d = duct.get_Parameter(BuiltInParameter.RBS_CURVE_DIAMETER_PARAM).AsValueString();

                    createInfo = sysName + " D" + d + " CL+" + clearHight;

                }
                else//矩形
                {
                    clearHight = Math.Round(clearHight / 10, 0) * 10;

                    string sysName = duct.get_Parameter(BuiltInParameter.RBS_DUCT_PIPE_SYSTEM_ABBREVIATION_PARAM).AsString();
                    string width = duct.get_Parameter(BuiltInParameter.RBS_CURVE_WIDTH_PARAM).AsValueString();
                    string high = duct.get_Parameter(BuiltInParameter.RBS_CURVE_HEIGHT_PARAM).AsValueString();

                    createInfo = sysName + " " + width + "×" + high + " BL+" + clearHight;
                }
            }
            else//桥架
            {
                clearHight = Math.Round(clearHight / 10, 0) * 10;

                string symbolName = item.get_Parameter(BuiltInParameter.ELEM_TYPE_PARAM).AsValueString();
                double width = item.get_Parameter(BuiltInParameter.RBS_CABLETRAY_WIDTH_PARAM).AsDouble() * 304.8;
                double high = item.get_Parameter(BuiltInParameter.RBS_CABLETRAY_HEIGHT_PARAM).AsDouble() * 304.8;

                createInfo = symbolName + " " + width + "×" + high + " BL+" + clearHight;
            }

            return createInfo;
        }
        public static string GetTextNoteInfo2(this Element item, double clearHight)
        {
            string createInfo = "";
            if (item is Pipe pipe)
            {
                // 中间高程-底部高程
                //double downR = item.get_Parameter(BuiltInParameter.RBS_OFFSET_PARAM).AsDouble() - item.get_Parameter(BuiltInParameter.RBS_PIPE_BOTTOM_ELEVATION).AsDouble();
                //clearHight = Math.Round(clearHight + downR * 304.8, 0);
                clearHight = Math.Round(clearHight / 10, 0) * 10;

                string sysName = pipe.get_Parameter(BuiltInParameter.RBS_DUCT_PIPE_SYSTEM_ABBREVIATION_PARAM).AsString();
                double d = pipe.get_Parameter(BuiltInParameter.RBS_PIPE_DIAMETER_PARAM).AsDouble() * 304.8;
                createInfo = sysName + " DN" + d + " CL+" + clearHight;
            }
            else if (item is Duct duct)
            {
                string eid = duct.get_Parameter(BuiltInParameter.ELEM_FAMILY_PARAM).AsValueString();
                if (eid == "圆形风管")
                {
                    //double r = duct.get_Parameter(BuiltInParameter.RBS_CURVE_DIAMETER_PARAM).AsDouble() / 2 * 304.8;
                    //clearHight = Math.Round(clearHight + r, 0);
                    clearHight = Math.Round(clearHight / 10, 0) * 10;

                    string sysName = duct.get_Parameter(BuiltInParameter.RBS_DUCT_PIPE_SYSTEM_ABBREVIATION_PARAM).AsString();
                    string d = duct.get_Parameter(BuiltInParameter.RBS_CURVE_DIAMETER_PARAM).AsValueString();

                    createInfo = sysName + " D" + d + " CL+" + clearHight;

                }
                else//矩形
                {
                    double halfHigh = duct.Height * 304.8 / 2;
                    clearHight = Math.Round(clearHight - halfHigh, 0);
                    clearHight = Math.Round(clearHight / 10, 0) * 10;

                    string sysName = duct.get_Parameter(BuiltInParameter.RBS_DUCT_PIPE_SYSTEM_ABBREVIATION_PARAM).AsString();
                    string width = duct.get_Parameter(BuiltInParameter.RBS_CURVE_WIDTH_PARAM).AsValueString();
                    string high = duct.get_Parameter(BuiltInParameter.RBS_CURVE_HEIGHT_PARAM).AsValueString();

                    createInfo = sysName + " " + width + "×" + high + " BL+" + clearHight;
                }
            }
            else//桥架
            {
                MEPCurve mEPCurve = item as MEPCurve;
                double halfHigh = mEPCurve.Height * 304.8 / 2;
                clearHight = Math.Round(clearHight - halfHigh, 0);
                clearHight = Math.Round(clearHight / 10, 0) * 10;

                string symbolName = item.get_Parameter(BuiltInParameter.ELEM_TYPE_PARAM).AsValueString();
                double width = item.get_Parameter(BuiltInParameter.RBS_CABLETRAY_WIDTH_PARAM).AsDouble() * 304.8;
                double high = item.get_Parameter(BuiltInParameter.RBS_CABLETRAY_HEIGHT_PARAM).AsDouble() * 304.8;

                createInfo = symbolName + " " + width + "×" + high + " BL+" + clearHight;
            }

            return createInfo;
        }
    }
}
