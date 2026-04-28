using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using Line = Autodesk.Revit.DB.Line;
using Settings = ViewScaling.Properties.Settings;

namespace ViewScaling
{
    [Transaction(TransactionMode.Manual)]
    public class Command02 : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uIDoc = commandData.Application.ActiveUIDocument;
            Selection sel = uIDoc.Selection;
            Document doc = uIDoc.Document;

            //Dimension dimension = sel.PickObject(ObjectType.Element).GetElement(doc) as Dimension;
            //DetailLine detailLine = sel.PickObject(ObjectType.Element).GetElement(doc) as DetailLine;
            //Line dimLine = (dimension.Curve as Line);
            ////dimLine.MakeUnbound();
            //Line deLine = (detailLine.Location as LocationCurve).Curve as Line;
            ////deLine.MakeUnbound();
            //SetComparisonResult result = dimLine.Intersect(deLine);
            //if (result == SetComparisonResult.Superset)
            //{
            //    TaskDialog.Show("revit", GetPlanePoint(doc, deLine.GetEndPoint(0)).DistanceTo(GetPlanePoint(doc, dimLine.Origin)) + "\n" + deLine.Origin.DistanceTo(dimLine.Origin + dimLine.Direction * dimension.get_Parameter(BuiltInParameter.DIM_TOTAL_LENGTH).AsDouble() * 304.8));
            //}
            //return Result.Succeeded;

            //Dimension element = sel.PickObject(ObjectType.Element).GetElement(doc) as Dimension;
            //foreach (DimensionSegment segment in element.Segments)
            //{
            //    XYZ leader = segment.LeaderEndPosition;
            //    XYZ ori = segment.Origin;
            //    XYZ text = segment.TextPosition;
            //    TaskDialog.Show("revit", ori.DistanceTo(text) + "\n" + ori.DistanceTo(leader) + "\n" + segment.ValueString);
            //}
            //return Result.Succeeded;

            View view = doc.ActiveView;

            MainWindow mainWindow = new MainWindow(doc);
            mainWindow.ShowDialog();
            if (mainWindow.Cancel)
            {
                return Result.Cancelled;
            }

            double scaling = 1 - Settings.Default.scale / doc.ActiveView.Scale;

            List<Dimension> dimensions = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_Dimensions).WhereElementIsNotElementType().Cast<Dimension>().ToList();

            List<DetailLine> detailLines = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_Lines).WhereElementIsCurveDriven().Where(x => x is DetailLine && x.GroupId.IntegerValue == -1).Cast<DetailLine>().ToList();

            List<TextNote> textNotes = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_TextNotes).WhereElementIsNotElementType().Cast<TextNote>().ToList();

            List<IndependentTag> tags = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategoryId(new ElementId(-2005014)).WhereElementIsNotElementType().Cast<IndependentTag>().ToList();

            FamilyInstance familyInstance = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_StructuralFraming)
                .WhereElementIsNotElementType().Cast<FamilyInstance>().ToList().FirstOrDefault();

            AssemblyInstance assemblyInstance = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategoryId(new ElementId(-2000267)).WhereElementIsNotElementType().Cast<AssemblyInstance>().ToList().FirstOrDefault();


            if (familyInstance == null || assemblyInstance == null)
            {
                TaskDialog.Show("错误", "未能找到该视图的结构框架或部件");
                return Result.Cancelled;
            }
            XYZ assMax = assemblyInstance.get_BoundingBox(doc.ActiveView).Max;
            XYZ assMin = assemblyInstance.get_BoundingBox(doc.ActiveView).Min;
            XYZ famMax = familyInstance.get_BoundingBox(doc.ActiveView).Max;
            XYZ famMin = familyInstance.get_BoundingBox(doc.ActiveView).Min;
            TransactionGroup TG = new TransactionGroup(doc, "View Scaling");
            TG.Start();
            // 1.Move Dim assinstance
            using (Transaction t1 = new Transaction(doc, "Move Dim"))
            {
                double moveLength = 0;
                foreach (var item in dimensions)
                {
                    XYZ dimDir = (item.Curve as Line).Direction;
                    XYZ moveDir = GetMoveDirection(item, doc, assemblyInstance);

                    if (moveDir == null) continue;

                    double length = GetMoveLength(assMax, assMin, moveDir, (item.Curve as Line).Origin);
                    moveLength = length * scaling;
                    t1.Start();
                    // 如果距离大于100mm就放回原位
                    Line line = item.Curve as Line;
                    foreach (DimensionSegment seg in item.Segments)
                    {
                        if (seg.Value > 100 / 304.8)
                        {
                            XYZ segDir;
                            if (line.Direction.IsAlmostEqualTo(view.UpDirection) || line.Direction.IsAlmostEqualTo(view.UpDirection.Negate()))
                            {
                                segDir = view.RightDirection.Negate();
                            }else if (line.Direction.IsAlmostEqualTo(view.RightDirection) || line.Direction.IsAlmostEqualTo(view.RightDirection.Negate()))
                            {
                                segDir = view.UpDirection;
                            }
                            else
                            {
                                continue;
                            }
                            double segLength = 0.00164041994750619 * view.Scale;
                            seg.TextPosition = seg.Origin + segDir * segLength;
                        }

                    }
                    item.Location.Move(moveLength * moveDir);
                    t1.Commit();
                }

            }
            // 2.Change DetailLine Length And Move
            using (Transaction t2 = new Transaction(doc, "Change DetailLine Length"))
            {
                foreach (var item in detailLines)
                {
                    if (item.LineStyle.Name.Contains("Pen 01(Grout)") || item.LineStyle.Name.Contains("01 Gray Dash")) continue;
                    XYZ moveDir = GetMoveDirection(item, doc, familyInstance);
                    if (moveDir == null) continue;
                    double moveLength = GetMoveLength(assMax, assMin, moveDir, (item.GeometryCurve as Line).Origin) * scaling;
                    t2.Start();
                    item.Location.Move(moveDir * moveLength);
                    //item.Location.Move(moveDir * (doc.ActiveView.Scale - Convert.ToInt32(mainWindow.Scale.Text)) / 304.8);
                    Line line1 = item.GeometryCurve as Line;
                    int j = GetNearestPoint(line1, famMax);
                    if (j == 0)
                    {
                        item.GeometryCurve = Line.CreateBound(line1.GetEndPoint(0) - line1.Direction * (doc.ActiveView.Scale - Convert.ToInt32(mainWindow.Scale.Text)) / 304.8, line1.GetEndPoint(1));
                    }
                    else
                    {
                        item.GeometryCurve = Line.CreateBound(line1.GetEndPoint(0), line1.GetEndPoint(1) + line1.Direction * (doc.ActiveView.Scale - Convert.ToInt32(mainWindow.Scale.Text)) / 304.8);
                    }
                    if (!item.IsLineConnect(detailLines))
                    {
                        Line line = item.GeometryCurve as Line;
                        int i = GetNearestPoint(line, famMax);
                        if (i == 0)
                        {
                            Line newLine = Line.CreateBound(line.GetEndPoint(0), line.GetEndPoint(1) - line.Direction * line.Length * scaling);
                            item.GeometryCurve = newLine;
                        }
                        else
                        {
                            Line newLine = Line.CreateBound(line.GetEndPoint(0) + line.Direction * line.Length * scaling, line.GetEndPoint(1));
                            item.GeometryCurve = newLine;
                        }
                    }
                    t2.Commit();

                }

            }
            // 3.Move TextNote
            using (Transaction t3 = new Transaction(doc, "Move TextNote"))
            {
                t3.Start();
                foreach (var item in textNotes)
                {
                    XYZ centerP = item.get_BoundingBox(view).Min.Add(item.get_BoundingBox(view).Max) / 2;
                    // 1.判断上下需不需要移动（先部件后结构框架）
                    if (!NeedMove(view, view.UpDirection, assemblyInstance, item.Coord)
                        || !NeedMove(view, view.UpDirection, assemblyInstance, centerP))
                    {
                        if (NeedMove(view, view.UpDirection, familyInstance, item.Coord))
                        {
                            XYZ moveDir = GetMoveDirection(item, doc, famMax, view.UpDirection);
                            if (moveDir == null) continue;
                            double moveLength = GetMoveLength(famMax, famMin, moveDir, item.Coord);
                            moveLength *= scaling;
                            item.Location.Move(moveLength * moveDir);
                        }
                    }
                    else
                    {
                        XYZ moveDir = GetMoveDirection(item, doc, assMax, view.UpDirection);
                        if (moveDir == null) continue;
                        double moveLength = GetMoveLength(assMax, assMin, moveDir, item.Coord);
                        moveLength *= scaling;
                        item.Location.Move(moveLength * moveDir);
                    }


                    // 2.判断左右需不需要移动
                    if (!NeedMove(view, view.RightDirection, assemblyInstance, item.Coord)
                        || !NeedMove(view, view.RightDirection, assemblyInstance, centerP))
                    {
                        if (NeedMove(view, view.RightDirection, familyInstance, item.Coord))
                        {
                            XYZ moveDir = GetMoveDirection(item, doc, famMax, view.RightDirection);
                            if (moveDir == null) continue;
                            double moveLength = GetMoveLength(famMax, famMin, moveDir, item.Coord);
                            moveLength *= scaling;
                            item.Location.Move(moveLength * moveDir);
                        }
                    }
                    else
                    {
                        XYZ moveDir = GetMoveDirection(item, doc, assMax, view.RightDirection);
                        if (moveDir == null) continue;
                        double moveLength = GetMoveLength(assMax, assMin, moveDir, item.Coord);
                        moveLength *= scaling;
                        item.Location.Move(moveLength * moveDir);
                    }
                }
                t3.Commit();
            }
            // 4.Move Tag
            using (Transaction t4 = new Transaction(doc, "Move Tag"))
            {
                t4.Start();
                foreach (var item in tags)
                {
                    XYZ centerP = item.get_BoundingBox(view).Min.Add(item.get_BoundingBox(view).Max) / 2;
                    // 1.判断上下需不需要移动（先部件后结构框架）
                    if (!NeedMove(view, view.UpDirection, assemblyInstance, item.TagHeadPosition)
                        || !NeedMove(view, view.UpDirection, assemblyInstance, centerP))
                    {
                        if (NeedMove(view, view.UpDirection, familyInstance, item.TagHeadPosition))
                        {
                            XYZ moveDir = GetMoveDirection(item, doc, famMax, view.UpDirection);
                            if (moveDir == null) continue;
                            double moveLength = GetMoveLength(famMax, famMin, moveDir, item.TagHeadPosition);
                            moveLength *= scaling;
                            item.Location.Move(moveLength * moveDir);
                        }
                    }
                    else
                    {
                        XYZ moveDir = GetMoveDirection(item, doc, assMax, view.UpDirection);
                        if (moveDir == null) continue;
                        double moveLength = GetMoveLength(assMax, assMin, moveDir, item.TagHeadPosition);
                        moveLength *= scaling;
                        item.Location.Move(moveLength * moveDir);
                    }


                    // 2.判断左右需不需要移动
                    if (!NeedMove(view, view.RightDirection, assemblyInstance, item.TagHeadPosition)
                        || !NeedMove(view, view.RightDirection, assemblyInstance, centerP))
                    {
                        if (NeedMove(view, view.RightDirection, familyInstance, item.TagHeadPosition))
                        {
                            XYZ moveDir = GetMoveDirection(item, doc, famMax, view.RightDirection);
                            if (moveDir == null) continue;
                            double moveLength = GetMoveLength(famMax, famMin, moveDir, item.TagHeadPosition);
                            moveLength *= scaling;
                            item.Location.Move(moveLength * moveDir);
                        }
                    }
                    else
                    {
                        XYZ moveDir = GetMoveDirection(item, doc, assMax, view.RightDirection);
                        if (moveDir == null) continue;
                        double moveLength = GetMoveLength(assMax, assMin, moveDir, item.TagHeadPosition);
                        moveLength *= scaling;
                        item.Location.Move(moveLength * moveDir);
                    }
                }
                t4.Commit();
            }
            // 5.View Scaling
            using (Transaction t5 = new Transaction(doc, "View Scaling"))
            {
                t5.Start();
                view.Scale = Convert.ToInt32(mainWindow.Scale.Text);
                t5.Commit();
            }
            TG.Assimilate();

            return Result.Succeeded;
        }
        /// <summary>
        /// 判断文字注释或标记在指定方向是否需要移动
        /// </summary>
        /// <param name="view">视图</param>
        /// <param name="upDirection">指定方向</param>
        /// <param name="assOrFam">结构框架或部件</param>
        /// <param name="tnp">文字注释坐标点</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool NeedMove(View view, XYZ upDirection, Element assOrFam, XYZ tnp)
        {
            XYZ max = assOrFam.get_BoundingBox(view).Max;
            XYZ min = assOrFam.get_BoundingBox(view).Min;
            XYZ maxpp = max.GetProjectionPoint(upDirection);
            XYZ minpp = min.GetProjectionPoint(upDirection);
            XYZ tnpp = tnp.GetProjectionPoint(upDirection);
            if ((maxpp - tnpp).Normalize().IsAlmostEqualTo((minpp - tnpp).Normalize()))
            {
                return true;
            }return false;
        }

        private int GetNearestPoint(Line line, XYZ famMax)
        {
            return line.GetEndPoint(0).DistanceTo(famMax) < line.GetEndPoint(1).DistanceTo(famMax) ? 0 : 1;
        }

        private XYZ GetMoveDirection(Element elem, Document doc, Element assOrFam)
        {
            XYZ moveDir = null;

            XYZ elemDir = null;
            XYZ elemPoint = null;
            if (elem is Dimension dimension)
            {
                elemDir = (dimension.Curve as Line).Direction;
                elemPoint = (dimension.Curve as Line).Origin;
            }
            else if (elem is DetailLine detailLine)
            {
                //if (detailLine.Location == null) return null;
                Line line = (detailLine.Location as LocationCurve).Curve as Line;
                elemDir = line.Direction;
                elemPoint = line.Origin;

            }
            else if (elem is TextNote textNote)
            {
                elemDir = textNote.BaseDirection;
                elemPoint = textNote.Coord;
            }
            

            View view = doc.ActiveView;
            XYZ max = assOrFam.get_BoundingBox(view).Max;
            XYZ min = assOrFam.get_BoundingBox(view).Min;

            if (elemDir.IsAlmostEqualTo(view.RightDirection) || elemDir.IsAlmostEqualTo(view.RightDirection.Negate()))
            {
                XYZ maxpp = max.GetProjectionPoint(view.UpDirection);
                XYZ elempp = elemPoint.GetProjectionPoint(view.UpDirection);
                if ((maxpp - elempp).Normalize().IsAlmostEqualTo(view.UpDirection))
                {
                    moveDir = view.UpDirection;
                }
                else
                {
                    moveDir = view.UpDirection.Negate();
                }
            }
            else if (elemDir.IsAlmostEqualTo(view.UpDirection) || elemDir.IsAlmostEqualTo(view.UpDirection.Negate()))
            {
                XYZ maxpp = max.GetProjectionPoint(view.RightDirection);
                XYZ elempp = elemPoint.GetProjectionPoint(view.RightDirection);
                if ((maxpp - elempp).Normalize().IsAlmostEqualTo(view.RightDirection))
                {
                    moveDir = view.RightDirection;
                }
                else
                {
                    moveDir = view.RightDirection.Negate();
                }
            }
            return moveDir;
        }
        private XYZ GetMoveDirection(Element tnOrTag, Document doc, XYZ assOrFamP, XYZ dir)
        {
            XYZ tnp;
            if (tnOrTag is TextNote textNote)
            {
                tnp = textNote.Coord;
            }
            else if (tnOrTag is IndependentTag tag)
            {
                tnp = tag.TagHeadPosition;
            }
            else
            {
                return null;
            }
            XYZ tnpp = tnp.GetProjectionPoint(dir);
            XYZ assOrFampp = assOrFamP.GetProjectionPoint(dir);
            if ((assOrFampp - tnpp).Normalize().IsAlmostEqualTo(dir))
            {
                return dir;
            }
            else if ((assOrFampp - tnpp).Normalize().IsAlmostEqualTo(dir.Negate()))
            {
                return dir.Negate();
            }
            else
            {
                return null;
            }

        }
        /// <summary>
        /// 获取移动的长度
        /// </summary>
        /// <param name="assOrFamMax">部件或结构框架边界框最大坐标</param>
        /// <param name="assOrFamMin">部件或结构框架边界框最小坐标</param>
        /// <param name="moveDir">移动方向</param>
        /// <param name="point">元素的坐标</param>
        /// <returns></returns>
        public double GetMoveLength(XYZ assOrFamMax, XYZ assOrFamMin, XYZ moveDir, XYZ point)
        {
            XYZ assMaxpp = assOrFamMax.GetProjectionPoint(moveDir);
            XYZ assMinpp = assOrFamMin.GetProjectionPoint(moveDir);
            XYZ elempp = point.GetProjectionPoint(moveDir);

            double length = elempp.DistanceTo(assMaxpp) < elempp.DistanceTo(assMinpp) ? elempp.DistanceTo(assMaxpp) : elempp.DistanceTo(assMinpp);
            return length;
        }
        /// <summary>
        /// 将三维坐标转换为当前视图的平面坐标，并计算两点间的距离
        /// </summary>
        public XYZ GetPlanePoint(Document doc, XYZ point1)
        {
            // 获取当前视图
            View activeView = doc.ActiveView;

            XYZ upDirection = activeView.UpDirection;     
            XYZ rightDirection = activeView.RightDirection;

            XYZ projectedPoint1 = ProjectPointToViewPlane(point1, upDirection, rightDirection);

            return projectedPoint1;
        }

        /// <summary>
        /// 将三维点投影到视图平面上
        /// </summary>
        private XYZ ProjectPointToViewPlane(XYZ point, XYZ upDirection, XYZ rightDirection)
        {
            double x = point.DotProduct(rightDirection); // 点与右方向向量的点乘结果为平面X坐标
            double y = point.DotProduct(upDirection);    // 点与向上方向向量的点乘结果为平面Y坐标

            return new XYZ(x, y, 0); // 平面投影点的Z坐标为0
        }
    }
}
