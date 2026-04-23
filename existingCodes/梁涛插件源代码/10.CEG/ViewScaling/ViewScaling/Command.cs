using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewScaling.Properties;
using Settings = ViewScaling.Properties.Settings;

namespace ViewScaling
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uIDoc = commandData.Application.ActiveUIDocument;
            Selection sel = uIDoc.Selection;
            Document doc = uIDoc.Document;

            View view = doc.ActiveView;

            MainWindow mainWindow = new MainWindow(doc);
            mainWindow.ShowDialog();
            if (mainWindow.Cancel)
            {
                return Result.Cancelled;
            }
            //double scaling = doc.ActiveView.Scale / Settings.Default.scale;
            double scaling = 1 - Settings.Default.scale / doc.ActiveView.Scale;

            List<Dimension> dimensions = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_Dimensions).WhereElementIsNotElementType().Cast<Dimension>().ToList();

            List<DetailLine> detailLines = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory((BuiltInCategory)(-2000051)).WhereElementIsCurveDriven().Where(x => x is DetailLine && x.GroupId.IntegerValue == -1).Cast<DetailLine>().ToList();
            //TaskDialog.Show("revit", detailLines.Count.ToString());
            List<TextNote> textNotes = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_TextNotes).WhereElementIsNotElementType().Cast<TextNote>().ToList();

            FamilyInstance familyInstance = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_StructuralFraming)
                .WhereElementIsNotElementType().Cast<FamilyInstance>().ToList().FirstOrDefault();

            AssemblyInstance assemblyInstance = new FilteredElementCollector(doc,doc.ActiveView.Id).OfCategoryId(new ElementId(-2000267)).WhereElementIsNotElementType().Cast<AssemblyInstance>().ToList().FirstOrDefault();

            XYZ max = assemblyInstance.get_BoundingBox(doc.ActiveView).Max;
            XYZ min = assemblyInstance.get_BoundingBox(doc.ActiveView).Min;
            if (familyInstance == null || assemblyInstance == null)
            {
                TaskDialog.Show("错误", "未能找到该视图的结构框架或部件");
                return Result.Cancelled;
            }

            XYZ famPoint = (familyInstance.Location as LocationPoint).Point;

            Transform transform = familyInstance.GetTransform();

            Options options = new Options();
            options.ComputeReferences = true;
            options.DetailLevel = ViewDetailLevel.Medium;
            GeometryElement geometryElement = familyInstance.get_Geometry(options);

            TransactionGroup TG = new TransactionGroup(doc, "View Scaling");
            TG.Start();
            // 1.移动尺寸标注
            Transaction t1 = new Transaction(doc, "Move Dim");
            t1.Start();
            foreach (var item in dimensions)
            {
                //Line line = ((item.Location as LocationCurve).Curve as Line);
                Line line = item.Curve as Line;
                XYZ lineDir = line.Direction;
                XYZ p = line.Origin;
                if (lineDir.IsAlmostEqualTo(view.UpDirection) || lineDir.IsAlmostEqualTo(view.UpDirection.Negate()))
                {

                    XYZ pp = p.GetProjectionPoint(view.RightDirection);
                    XYZ fampp = famPoint.GetProjectionPoint(view.RightDirection);
                    if ((pp - fampp).Normalize().IsAlmostEqualTo(view.RightDirection))
                    {
                        //XYZ nearP = GetNearestPoint(geometryElement, transform, view.RightDirection, p);
                        XYZ nearP = null;
                        if ((max.GetProjectionPoint(view.RightDirection) - min.GetProjectionPoint(view.RightDirection)).Normalize().IsAlmostEqualTo(view.RightDirection))
                        {
                            nearP = max.GetProjectionPoint(view.RightDirection);
                        }
                        else
                        {
                            nearP = min.GetProjectionPoint(view.RightDirection);
                        }
                        double moveDis = pp.DistanceTo(nearP) * scaling;
                        item.Location.Move(view.RightDirection.Negate() * moveDis);
                    }
                    else if ((pp - fampp).Normalize().IsAlmostEqualTo(view.RightDirection.Negate()))
                    {
                        //XYZ nearP = GetNearestPoint(geometryElement, transform, view.RightDirection.Negate(), p);
                        XYZ nearP = null;
                        if ((max.GetProjectionPoint(view.RightDirection.Negate()) - min.GetProjectionPoint(view.RightDirection.Negate())).Normalize().IsAlmostEqualTo(view.RightDirection.Negate()))
                        {
                            nearP = max.GetProjectionPoint(view.RightDirection.Negate());
                        }
                        else
                        {
                            nearP = min.GetProjectionPoint(view.RightDirection.Negate());
                        }
                        double moveDis = pp.DistanceTo(nearP) * scaling;
                        item.Location.Move(view.RightDirection * moveDis);
                    }
                }
                else if (lineDir.IsAlmostEqualTo(view.RightDirection) || lineDir.IsAlmostEqualTo(view.RightDirection.Negate()))
                {
                    XYZ pp = p.GetProjectionPoint(view.UpDirection);
                    XYZ fampp = famPoint.GetProjectionPoint(view.UpDirection);
                    if ((pp - fampp).Normalize().IsAlmostEqualTo(view.UpDirection))
                    {
                        //XYZ nearP = GetNearestPoint(geometryElement, transform, view.UpDirection, p);
                        XYZ nearP = null;
                        if ((max.GetProjectionPoint(view.UpDirection) - min.GetProjectionPoint(view.UpDirection)).Normalize().IsAlmostEqualTo(view.UpDirection))
                        {
                            nearP = max.GetProjectionPoint(view.UpDirection);
                        }
                        else
                        {
                            nearP = min.GetProjectionPoint(view.UpDirection);
                        }
                        double moveDis = pp.DistanceTo(nearP) * scaling;
                        item.Location.Move(view.UpDirection.Negate() * moveDis);
                    }
                    else if ((pp - fampp).Normalize().IsAlmostEqualTo(view.UpDirection.Negate()))
                    {
                        //XYZ nearP = GetNearestPoint(geometryElement, transform, view.UpDirection.Negate(), p);
                        XYZ nearP = null;
                        if ((max.GetProjectionPoint(view.UpDirection.Negate()) - min.GetProjectionPoint(view.UpDirection.Negate())).Normalize().IsAlmostEqualTo(view.UpDirection.Negate()))
                        {
                            nearP = max.GetProjectionPoint(view.UpDirection.Negate());
                        }
                        else
                        {
                            nearP = min.GetProjectionPoint(view.UpDirection.Negate());
                        }
                        double moveDis = pp.DistanceTo(nearP) * scaling;
                        item.Location.Move(view.UpDirection * moveDis);
                    }
                }
            }
            t1.Commit();
            // 2.移动并缩放不成组的详图线
            using(Transaction t2 = new Transaction(doc, "Change DetailLine"))
            {
                t2.Start();
                foreach (var item in detailLines)
                {
                    Line line = ((item.Location as LocationCurve).Curve as Line);
                    XYZ lineDir = line.Direction;
                    XYZ p = line.Origin;
                    XYZ nearP = null;

                    XYZ faceP = null;

                    if (lineDir.IsAlmostEqualTo(view.UpDirection) || lineDir.IsAlmostEqualTo(view.UpDirection.Negate()))
                    {
                        
                        XYZ pp = p.GetProjectionPoint(view.RightDirection);
                        XYZ fampp = famPoint.GetProjectionPoint(view.RightDirection);
                        if ((pp - fampp).Normalize().IsAlmostEqualTo(view.RightDirection))
                        {
                            //nearP = GetNearestPoint(geometryElement, transform, view.RightDirection, p, out faceP);
                            if ((max.GetProjectionPoint(view.RightDirection) - min.GetProjectionPoint(view.RightDirection)).Normalize().IsAlmostEqualTo(view.RightDirection))
                            {
                                nearP = max.GetProjectionPoint(view.RightDirection);
                                faceP = max;
                            }
                            else
                            {
                                nearP = min.GetProjectionPoint(view.RightDirection);
                                faceP = min;
                            }
                            double moveDis = pp.DistanceTo(nearP) * scaling;
                            item.Location.Move(view.RightDirection.Negate() * moveDis);
                        }
                        else if ((pp - fampp).Normalize().IsAlmostEqualTo(view.RightDirection.Negate()))
                        {
                            //nearP = GetNearestPoint(geometryElement, transform, view.RightDirection.Negate(), p, out faceP);
                            if ((max.GetProjectionPoint(view.RightDirection.Negate()) - min.GetProjectionPoint(view.RightDirection.Negate())).Normalize().IsAlmostEqualTo(view.RightDirection.Negate()))
                            {
                                nearP = max.GetProjectionPoint(view.RightDirection.Negate());
                                faceP = max;
                            }
                            else
                            {
                                nearP = min.GetProjectionPoint(view.RightDirection.Negate());
                                faceP = min;
                            }
                            double moveDis = pp.DistanceTo(nearP) * scaling;
                            item.Location.Move(view.RightDirection * moveDis);
                        }
                    }
                    else if (lineDir.IsAlmostEqualTo(view.RightDirection) || lineDir.IsAlmostEqualTo(view.RightDirection.Negate()))
                    {
                        XYZ pp = p.GetProjectionPoint(view.UpDirection);
                        XYZ fampp = famPoint.GetProjectionPoint(view.UpDirection);
                        if ((pp - fampp).Normalize().IsAlmostEqualTo(view.UpDirection))
                        {
                            //nearP = GetNearestPoint(geometryElement, transform, view.UpDirection, p, out faceP);
                            if ((max.GetProjectionPoint(view.UpDirection) - min.GetProjectionPoint(view.UpDirection)).Normalize().IsAlmostEqualTo(view.UpDirection))
                            {
                                nearP = max.GetProjectionPoint(view.UpDirection);
                                faceP = max;
                            }
                            else
                            {
                                nearP = min.GetProjectionPoint(view.UpDirection);
                                faceP = min;
                            }
                            double moveDis = pp.DistanceTo(nearP) * scaling;
                            item.Location.Move(view.UpDirection.Negate() * moveDis);
                        }
                        else if ((pp - fampp).Normalize().IsAlmostEqualTo(view.UpDirection.Negate()))
                        {
                            //nearP = GetNearestPoint(geometryElement, transform, view.UpDirection.Negate(), p, out faceP);
                            if ((max.GetProjectionPoint(view.UpDirection.Negate()) - min.GetProjectionPoint(view.UpDirection.Negate())).Normalize().IsAlmostEqualTo(view.UpDirection.Negate()))
                            {
                                nearP = max.GetProjectionPoint(view.UpDirection.Negate());
                                faceP = max;
                            }
                            else
                            {
                                nearP = min.GetProjectionPoint(view.UpDirection.Negate());
                                faceP = min;
                            }
                            double moveDis = pp.DistanceTo(nearP) * scaling;
                            item.Location.Move(view.UpDirection * moveDis);
                        }
                    }
                    if (!item.IsLineConnect(detailLines) && faceP != null)
                    {
                        if (line.GetEndPoint(0).DistanceTo(faceP) < line.GetEndPoint(1).DistanceTo(faceP))
                        {
                            XYZ newP = line.GetEndPoint(1) - lineDir * (line.Length * scaling);
                            Line line1 = Line.CreateBound(line.GetEndPoint(0), newP);
                            (item.Location as LocationCurve).Curve = line1;
                        }
                        else
                        {
                            XYZ newP = line.GetEndPoint(0) + lineDir * (line.Length * scaling);
                            Line line1 = Line.CreateBound(newP, line.GetEndPoint(1));
                            (item.Location as LocationCurve).Curve = line1;
                        }
                    }
                }
                t2.Commit();
            }

            // 3.移动文字注释
            using (Transaction t3 = new Transaction(doc, "Move TextNote"))
            {
                t3.Start();
                foreach (var item in textNotes)
                {
                    XYZ textP = item.Coord;
                    XYZ textDir = item.BaseDirection;
                    // 判断文字注释在结构框架的左边还是右边
                    if ((textP.GetProjectionPoint(view.RightDirection) -  famPoint.GetProjectionPoint(view.RightDirection)).Normalize().IsAlmostEqualTo(view.RightDirection))
                    {
                        //XYZ nearP = GetNearestPoint(geometryElement, transform, view.RightDirection, textP);
                        XYZ nearP = null;
                        if (textDir.IsAlmostEqualTo(view.RightDirection) ||textDir.IsAlmostEqualTo(view.RightDirection.Negate()))
                        {
                            nearP = GetNearestPoint(geometryElement, transform, view.RightDirection, textP);
                        }
                        else
                        {
                            if ((max.GetProjectionPoint(view.RightDirection) - min.GetProjectionPoint(view.RightDirection)).Normalize().IsAlmostEqualTo(view.RightDirection))
                            {
                                nearP = max.GetProjectionPoint(view.RightDirection);
                            }
                            else
                            {
                                nearP = min.GetProjectionPoint(view.RightDirection);
                            }
                        }
                        XYZ textpp = textP.GetProjectionPoint(view.RightDirection);
                        double moveDis = textpp.DistanceTo(nearP) * scaling;
                        item.Location.Move(view.RightDirection.Negate() * moveDis);
                    }
                    else
                    {
                        //XYZ nearP = GetNearestPoint(geometryElement, transform, view.RightDirection.Negate(), textP);
                        XYZ nearP = null;
                        if (textDir.IsAlmostEqualTo(view.RightDirection) || textDir.IsAlmostEqualTo(view.RightDirection.Negate()))
                        {
                            nearP = GetNearestPoint(geometryElement, transform, view.RightDirection.Negate(), textP);
                        }
                        else
                        {
                            if ((max.GetProjectionPoint(view.RightDirection.Negate()) - min.GetProjectionPoint(view.RightDirection.Negate())).Normalize().IsAlmostEqualTo(view.RightDirection.Negate()))
                            {
                                nearP = max.GetProjectionPoint(view.RightDirection.Negate());
                            }
                            else
                            {
                                nearP = min.GetProjectionPoint(view.RightDirection.Negate());
                            }
                        }

                        XYZ textpp = textP.GetProjectionPoint(view.RightDirection.Negate());
                        double moveDis = textpp.DistanceTo(nearP) * scaling;
                        item.Location.Move(view.RightDirection * moveDis);
                    }
                    // 判断文字注释在结构框架的上方还是下方
                    if ((textP.GetProjectionPoint(view.UpDirection) - famPoint.GetProjectionPoint(view.UpDirection)).Normalize().IsAlmostEqualTo(view.UpDirection))
                    {
                        //XYZ nearP = GetNearestPoint(geometryElement, transform, view.UpDirection, textP);
                        XYZ nearP = null;
                        if (textDir.IsAlmostEqualTo(view.UpDirection) || textDir.IsAlmostEqualTo(view.UpDirection.Negate()))
                        {
                            nearP = GetNearestPoint(geometryElement, transform, view.UpDirection, textP);
                        }
                        else
                        {
                            if ((max.GetProjectionPoint(view.UpDirection) - min.GetProjectionPoint(view.UpDirection)).Normalize().IsAlmostEqualTo(view.UpDirection))
                            {
                                nearP = max.GetProjectionPoint(view.UpDirection);
                            }
                            else
                            {
                                nearP = min.GetProjectionPoint(view.UpDirection);
                            }
                        }
                        
                        XYZ textpp = textP.GetProjectionPoint(view.UpDirection);
                        double moveDis = textpp.DistanceTo(nearP) * scaling;
                        item.Location.Move(view.UpDirection.Negate() * moveDis);
                    }
                    else
                    {
                        //XYZ nearP = GetNearestPoint(geometryElement, transform, view.UpDirection.Negate(), textP);
                        XYZ nearP = null;
                        if (textDir.IsAlmostEqualTo(view.UpDirection) || textDir.IsAlmostEqualTo(view.UpDirection.Negate()))
                        {
                            nearP = GetNearestPoint(geometryElement, transform, view.UpDirection.Negate(), textP);
                        }
                        else
                        {
                            if ((max.GetProjectionPoint(view.UpDirection.Negate()) - min.GetProjectionPoint(view.UpDirection.Negate())).Normalize().IsAlmostEqualTo(view.UpDirection.Negate()))
                            {
                                nearP = max.GetProjectionPoint(view.UpDirection.Negate());
                            }
                            else
                            {
                                nearP = min.GetProjectionPoint(view.UpDirection.Negate());
                            }
                        }

                        XYZ textpp = textP.GetProjectionPoint(view.UpDirection.Negate());
                        double moveDis = textpp.DistanceTo(nearP) * scaling;
                        item.Location.Move(view.UpDirection * moveDis);
                    }
                }


                t3.Commit();
            }
            // 4.缩放视图比例
            Transaction t4 = new Transaction(doc, "View Scaling");
            t4.Start();
            
            view.Scale = Convert.ToInt32(mainWindow.Scale.Text);


            t4.Commit();
            TG.Assimilate();
            //uIDoc.ShowElements(detailLines.Select(d => d.Id).ToList());
            //uIDoc.Selection.SetElementIds(detailLines.Select(d => d.Id).ToList());

            return Result.Succeeded;
        }

        public XYZ GetNearestPoint(GeometryElement geometryElement, Transform transform, XYZ viewDir, XYZ pointOnLine)
        {
            XYZ nearPoint = null;
            Solid solid = null;
            foreach (var item in geometryElement)
            {
                if (item is GeometryInstance geometryInstance && geometryInstance.GetSymbolGeometry() != null)
                {
                    GeometryElement geoE = geometryInstance.GetSymbolGeometry();
                    foreach (GeometryObject obj in geoE)
                    {
                        if (obj is Solid solid1 && solid1.Volume > 0)
                        {
                            solid = solid1;
                            solid = SolidUtils.CreateTransformed(solid, transform);
                            //TaskDialog.Show("rerr", solid.ComputeCentroid().ToString() + solid1.Volume);
                            break;
                        }
                    }
                }
                else if (item is Solid solid1 && solid1.Volume > 0)
                {
                    solid = solid1;
                    //solid = SolidUtils.CreateTransformed(solid1, transform);
                    break;
                }
            }
            if (solid == null) return nearPoint;
            double minValue = double.MaxValue;
            XYZ pp = pointOnLine.GetProjectionPoint(viewDir);
            Face face = null;
            foreach (Face item in solid.Faces)
            {
                if (item is PlanarFace planarFace && planarFace.FaceNormal.IsAlmostEqualTo(viewDir))
                {
                    XYZ p = planarFace.Origin;
                    //p = transform.OfPoint(p);
                    p = p.GetProjectionPoint(viewDir);
                    if (pp.DistanceTo(p) < minValue)
                    {
                        minValue = pp.DistanceTo(p);
                        nearPoint = p;
                        face = item;
                    }
                }
            }
            return nearPoint;
        }
        public XYZ GetNearestPoint(GeometryElement geometryElement, Transform transform, XYZ viewDir, XYZ pointOnLine,out XYZ faceP)
        {
            XYZ nearPoint = null;
            Solid solid = null;
            faceP = null;
            foreach (var item in geometryElement)
            {
                if (item is GeometryInstance geometryInstance && geometryInstance.GetSymbolGeometry() != null)
                {
                    GeometryElement geoE = geometryInstance.GetSymbolGeometry();
                    foreach (GeometryObject obj in geoE)
                    {
                        if (obj is Solid solid1 && solid1.Volume > 0)
                        {
                            solid = solid1;
                            solid = SolidUtils.CreateTransformed(solid, transform);
                            //TaskDialog.Show("rerr", solid.ComputeCentroid().ToString() + solid1.Volume);
                            break;
                        }
                    }
                }
                else if (item is Solid solid1 && solid1.Volume > 0)
                {
                    solid = solid1;
                    solid = SolidUtils.CreateTransformed(solid1, transform);
                    break;
                }
            }
            if (solid == null) return nearPoint;
            double minValue = double.MaxValue;
            XYZ pp = pointOnLine.GetProjectionPoint(viewDir);
            Face face = null;
            foreach (Face item in solid.Faces)
            {
                if (item is PlanarFace planarFace && planarFace.FaceNormal.IsAlmostEqualTo(viewDir))
                {
                    XYZ p = planarFace.Origin;
                    //p = transform.OfPoint(p);
                    XYZ pp2 = p.GetProjectionPoint(viewDir);
                    if (pp.DistanceTo(pp2) < minValue)
                    {
                        minValue = pp.DistanceTo(pp2);
                        nearPoint = pp2;
                        faceP = p;
                        face = item;
                    }
                }
            }
            return nearPoint;
        }
    }
    public static class Extensoin
    {
        //获取坐标点在向量上的投影点
        public static XYZ GetProjectionPoint(this XYZ point, XYZ direction)
        {
            // 定义点P和向量v
            XYZ pointP = point;
            XYZ vectorV = direction;

            // 计算点P到原点的向量OP
            XYZ vectorOP = pointP;

            // 计算点P在向量v上的投影
            double dotProduct = vectorOP.DotProduct(vectorV);
            double magnitudeSquared = vectorV.DotProduct(vectorV);
            double projectionCoefficient = dotProduct / magnitudeSquared;

            XYZ projection = projectionCoefficient * vectorV;

            return projection;
        }
        public static Element GetElement(this Reference reference, Document doc)
        {
            return doc.GetElement(reference);
        }
        public static bool IsLineConnect(this DetailLine detailLine, List<DetailLine> detailLines)
        {
            List<DetailLine> newLines = detailLines.Where(x => x != detailLine).ToList();
            List<XYZ> linePoints = new List<XYZ>();
            foreach (DetailLine item in newLines)
            {
                Line line = (item.Location as LocationCurve).Curve as Line;
                linePoints.Add(line.GetEndPoint(0));
                linePoints.Add(line.GetEndPoint(1));
            }
            XYZ p0 = detailLine.GetLinePoint(0);
            XYZ p1 = detailLine.GetLinePoint(1);
            foreach (var p in linePoints)
            {
                if (p0.IsAlmostEqualTo(p) || (p1.IsAlmostEqualTo(p)))
                {
                    return true;
                }
            }
            return false;

        }
        public static XYZ GetLinePoint(this DetailLine detailLine, int i)
        {
            XYZ linePoint = null;
            Line line = (detailLine.Location as LocationCurve).Curve as Line;
            try
            {
                linePoint = line.GetEndPoint(i);
            }
            catch (Exception)
            {

            }
            return linePoint;
        }
    }
}
