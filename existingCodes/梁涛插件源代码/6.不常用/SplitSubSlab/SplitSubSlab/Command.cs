using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SplitSubSlab
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication application = commandData.Application;
            Document document = application.ActiveUIDocument.Document;
            Selection selection = application.ActiveUIDocument.Selection;
            //Floor floor1 = document.GetElement(application.ActiveUIDocument.Selection.PickObject(ObjectType.Element)) as Floor;
            //IList<ElementId> elementIds = floor1.GetDependentElements(null);
            //foreach (var item in elementIds)
            //{
            //    Element element = document.GetElement(item);
            //    if (element == null || element.Name == null || element.Category == null) continue;
            //    if (element.Category.Id.IntegerValue == -2000045 && element.Name == "坡度箭头")
            //    {
            //        TaskDialog.Show("p", element.GetType().ToString());
            //    }
            //}
            //return Result.Succeeded;
            bool flag = !(document.ActiveView is View3D);
            Result result;
            if (flag)
            {
                message = "请在三维视图下运行！";
                result =  Result.Cancelled;
            }
            else
            {
                while (true)
                {
                    try
                    {
                        Reference reference = selection.PickObject(ObjectType.Element, new OpeningSelectFilter());
                        Opening opening = document.GetElement(reference) as Opening;
                        Floor floor = opening.Host as Floor;
                        //Transaction transaction1 = new Transaction(document, "111");
                        //transaction1.Start();
                        //ElementTransformUtils.RotateElement(document, floor.Id, Line.CreateBound(new XYZ(), new XYZ() + XYZ.BasisY), 0.5);
                        //transaction1.Commit();
                        ElementId elementId = floor.get_Parameter(BuiltInParameter.LEVEL_PARAM).AsElementId();
                        Level level = document.GetElement(elementId) as Level;
                        FloorType floorType = floor.FloorType;
                        double num = floor.get_Parameter(BuiltInParameter.FLOOR_HEIGHTABOVELEVEL_PARAM).AsDouble();
                        List<XYZ> list = new List<XYZ>();
                        List<Curve> list2 = new List<Curve>();
                        foreach (Curve item in opening.BoundaryCurves)
                        {
                            list2.Add(item);
                        }
                        CurveUtils.SortCurvesContiguous(document.Application, list2, false);
                        CurveArray curveArray = application.Application.Create.NewCurveArray();
                        foreach (Curve current in list2)
                        {
                            list.Add(current.GetEndPoint(0));
                            curveArray.Append(current.CreateTransformed(Transform.CreateTranslation(XYZ.BasisZ * 10.0)));
                        }
                        Floor floor2 = null;
                        TransactionGroup transactionGroup = new TransactionGroup(document, "洞口填板");
                        transactionGroup.Start();
                        bool hasSlopeArrow = false;
                        //Level floorLevel = document.GetElement(floor.LevelId) as Level;
                        double floorHigh = level.Elevation;
                        foreach (ElementId item in floor.GetDependentElements(null))
                        {
                            Element element = document.GetElement(item);
                            if (element is ModelLine && element.Name.Contains("坡度箭头"))
                            {
                                hasSlopeArrow = true;
                                ModelLine modelLine = (ModelLine)element;
                                Line slopedArrow = (modelLine.Location as LocationCurve).Curve as Line;
                                double newZ = slopedArrow.Origin.Z;
                                double slope;
                                if (modelLine.get_Parameter(BuiltInParameter.SPECIFY_SLOPE_OR_OFFSET).AsValueString().Equals("坡度"))
                                {
                                    double newLineSZ;
                                    if (modelLine.LookupParameter("最低处标高").AsValueString().Equals("默认"))
                                    {
                                        newLineSZ = modelLine.LookupParameter("尾高度偏移").AsDouble() + floorHigh;
                                    }
                                    else
                                    {
                                        newLineSZ = modelLine.LookupParameter("尾高度偏移").AsDouble() +
                                            (document.GetElement(modelLine.LookupParameter("最低处标高").AsElementId()) as Level).Elevation;
                                    }
                                    num = newLineSZ - floorHigh + num;
                                    slope = modelLine.get_Parameter(BuiltInParameter.ROOF_SLOPE).AsDouble();
                                }
                                else
                                {
                                    
                                    double newLineSZ;
                                    double newLineEZ;
                                    if (modelLine.LookupParameter("最低处标高").AsValueString().Equals("默认"))
                                    {
                                        newLineSZ = modelLine.LookupParameter("尾高度偏移").AsDouble() + floorHigh;
                                    }
                                    else
                                    {
                                        newLineSZ = modelLine.LookupParameter("尾高度偏移").AsDouble() +
                                            (document.GetElement(modelLine.LookupParameter("最低处标高").AsElementId()) as Level).Elevation;
                                    }
                                    if (modelLine.LookupParameter("最高处标高").AsValueString().Equals("默认"))
                                    {
                                        newLineEZ = modelLine.LookupParameter("头高度偏移").AsDouble() + floorHigh;
                                    }
                                    else
                                    {
                                        newLineEZ = modelLine.LookupParameter("头高度偏移").AsDouble() +
                                            (document.GetElement(modelLine.LookupParameter("最高处标高").AsElementId()) as Level).Elevation;
                                    }

                                    //double verHigh = GetVerHigh(floor);
                                    //if (verHigh == -1)
                                    //{
                                    //    TaskDialog.Show("错误", "填板失败");
                                    //    transactionGroup.RollBack();
                                    //    return Result.Succeeded;
                                    //}
                                    //BoundingBoxXYZ boundingBox = floor.get_BoundingBox(document.ActiveView);
                                    //if (newLineSZ > newLineEZ)
                                    //{
                                    //    newLineSZ = boundingBox.Max.Z;
                                    //    newLineEZ = boundingBox.Min.Z + verHigh;
                                    //}
                                    //else
                                    //{
                                    //    newLineSZ = boundingBox.Min.Z + verHigh;
                                    //    newLineEZ = boundingBox.Max.Z;
                                    //}
                                    Line newLine = Line.CreateBound(new XYZ(slopedArrow.GetEndPoint(0).X, slopedArrow.GetEndPoint(0).Y, newLineSZ),
                                        new XYZ(slopedArrow.GetEndPoint(1).X, slopedArrow.GetEndPoint(1).Y, newLineEZ));
                                    num = newLineSZ - floorHigh + num;
                                    slope = slopedArrow.Direction.Normalize().AngleTo(newLine.Direction.Normalize());
                                    //double h = boundingBox.Max.Z - (boundingBox.Min.Z + verHigh);
                                    //double w = modelLine.LookupParameter("长度").AsDouble();
                                    //slope = Math.Atan(h / w);
                                    if (newLineSZ > newLineEZ) slope = -slope;
                                }
                                Transaction transaction = new Transaction(document, "sss");
                                transaction.Start();
                                Plane plane = Plane.CreateByNormalAndOrigin(XYZ.BasisZ, new XYZ(curveArray.get_Item(0).GetEndPoint(0).X, curveArray.get_Item(0).GetEndPoint(0).Y, newZ));
                                SketchPlane sketchPlane = SketchPlane.Create(document, plane);
                                for (int i = 0; i < curveArray.Size; i++)
                                {
                                    Curve curve = curveArray.get_Item(i);
                                    if (curve is Line line)
                                    {
                                        Line line1 = Line.CreateBound(new XYZ(line.GetEndPoint(0).X, line.GetEndPoint(0).Y, newZ), new XYZ(line.GetEndPoint(1).X, line.GetEndPoint(1).Y, newZ));
                                        curveArray.set_Item(i, line1);

                                        //ModelCurve modelCurve = document.Create.NewModelCurve(line1, sketchPlane);
                                    }
                                    else if (curve is Arc arc)
                                    {
                                        XYZ cP = arc.Evaluate(0.01, true);
                                        Arc arc1 = Arc.Create(new XYZ(arc.GetEndPoint(0).X, arc.GetEndPoint(0).Y, newZ), new XYZ(arc.GetEndPoint(1).X, arc.GetEndPoint(1).Y, newZ), new XYZ(cP.X, cP.Y, newZ));
                                        //Arc arc1 = Arc.Create(new XYZ(arc.GetEndPoint(1).X, arc.GetEndPoint(1).Y, newZ), new XYZ(arc.GetEndPoint(0).X, arc.GetEndPoint(0).Y, newZ), new XYZ(cP.X, cP.Y, newZ));
                                        curveArray.set_Item(i,arc1);
                                        

                                        //ModelCurve modelCurve = document.Create.NewModelCurve(arc1, sketchPlane);

                                    }
                                }
                                transaction.Commit();
                                //transactionGroup.Assimilate();
                                //return Result.Succeeded;

                                Transaction t = new Transaction(document, "创建带坡度的楼板");
                                t.Start();
                                //slope = -1.33332837107564;
                                //TODO:默认方式创建的楼板slope参数有偏差
                                floor2 = document.Create.NewSlab(curveArray, level, slopedArrow, slope, false);
                                //floor2 = document.Create.NewFloor(curveArray, floorType, level, false, XYZ.BasisZ);
                                floor2.get_Parameter(BuiltInParameter.FLOOR_HEIGHTABOVELEVEL_PARAM).Set(num);
                                //TaskDialog.Show("ll", slope.ToString());
                                t.Commit();
                                break;
                            }
                        }
                        if (hasSlopeArrow)
                        {
                            transactionGroup.Assimilate();
                            continue;
                        }
                        using (Transaction transaction = new Transaction(document, "SubSlab_Create"))
                        {
                            transaction.Start();
                            floor2 = document.Create.NewFloor(curveArray, floorType, level, false, XYZ.BasisZ);
                            //floor2 = document.Create.NewFloor(curveArray, floorType, level, false);
                            floor2.get_Parameter(BuiltInParameter.FLOOR_HEIGHTABOVELEVEL_PARAM).Set(num);
                            transaction.Commit();
                        }
                        bool flag2 = floor.SlabShapeEditor != null;
                        if (flag2)
                        {
                            bool flag3 = floor.SlabShapeEditor.SlabShapeVertices.Size == 0;
                            if (!flag3)
                            {
                                SlabShapeEditor slabShapeEditor = null;
                                using (Transaction transaction2 = new Transaction(document, "SubSlab_Enable"))
                                {
                                    transaction2.Start();
                                    slabShapeEditor = floor2.SlabShapeEditor;
                                    slabShapeEditor.Enable();
                                    transaction2.Commit();
                                }
                                List<double> offsetList = this.GetOffsetList(document, slabShapeEditor, floor);
                                using (Transaction transaction3 = new Transaction(document, "SubSlab_Edit"))
                                {
                                    transaction3.Start();
                                    for (int i = 0; i < slabShapeEditor.SlabShapeVertices.Size; i++)
                                    {
                                        slabShapeEditor.ModifySubElement(slabShapeEditor.SlabShapeVertices.get_Item(i), offsetList[i]);
                                    }
                                    transaction3.Commit();
                                }
                            }
                        }
                        transactionGroup.Assimilate();
                    }
                    catch (Exception ex)
                    {
                        bool flag4 = ex.Message == "The user aborted the pick operation.";
                        if (flag4)
                        {
                            TaskDialog.Show("Revit", "取消选择，程序结束");
                            break;
                        }
                        TaskDialog.Show("Revit", ex.Message + "\n" + ex.StackTrace.ToString());
                        break;
                    }
                }
                result = Result.Succeeded;
            }
            return result;
        }

        public double GetVerHigh(Floor floor)
        {
            GeometryElement geometryElem = floor.get_Geometry(new Options());
            foreach (GeometryObject geometry in geometryElem)
            {
                if (geometry is Solid solid && solid.Edges != null)
                {
                    foreach (Edge edge in solid.Edges)
                    {
                        Curve curve = edge.AsCurve();
                        if (curve is Line line && (line.Direction.IsAlmostEqualTo(XYZ.BasisZ) || line.Direction.IsAlmostEqualTo(XYZ.BasisZ.Negate())))
                        {
                            return line.Length;
                        }
                    }
                }
            }
            return -1;
        }

        private List<double> GetOffsetList(Document doc, SlabShapeEditor editor, Floor hostFloor)
        {
            double num = 10000.0;
            List<double> list = new List<double>();
            foreach (SlabShapeVertex slabShapeVertex in editor.SlabShapeVertices)
            {
                XYZ xYZ = slabShapeVertex.Position + XYZ.BasisZ * num;
                XYZ reflectPoint = this.GetReflectPoint(doc.ActiveView as View3D, xYZ, XYZ.BasisZ.Negate(), hostFloor);
                bool flag = reflectPoint != null;
                if (flag)
                {
                    list.Add(num - reflectPoint.DistanceTo(xYZ));
                }
                else
                {
                    list.Add(0.0);
                }
            }
            return list;
        }
        private XYZ GetReflectPoint(View3D view, XYZ point, XYZ direction, Floor hostFloor)
        {
            XYZ xYZ = point + direction.Normalize() * 1E-05;
            ReferenceIntersector referenceIntersector = new ReferenceIntersector(hostFloor.Id,FindReferenceTarget.All, view);
            referenceIntersector.FindReferencesInRevitLinks = true;
            ReferenceWithContext referenceWithContext = referenceIntersector.FindNearest(xYZ, direction);
            return (referenceWithContext == null) ? null : referenceWithContext.GetReference().GlobalPoint;
        }
        //private FloorSlopeArrowInfo GetSlopeArrowInfo(Floor floor)
        //{
        //    Document doc = floor.Document;
        //    List<Element> openings = new List<Element>();

        //    // 获取楼板上的所有Opening元素
        //    FilteredElementCollector collector = new FilteredElementCollector(doc, floor.Id)
        //        .OfClass(typeof(Opening));

        //    openings.AddRange(collector);

        //    foreach (Element opening in openings)
        //    {
        //        // 检查是否为坡度箭头
        //        if (opening.Name.Equals("Slope Arrow"))
        //        {
        //            // 获取坡度箭头的几何信息
        //            LocationCurve locationCurve = opening.Location as LocationCurve;
        //            if (locationCurve != null)
        //            {
        //                XYZ startPoint = locationCurve.Curve.GetEndPoint(0);
        //                XYZ endPoint = locationCurve.Curve.GetEndPoint(1);
        //                double slope = opening.get_Parameter(BuiltInParameter.).AsDouble();

        //                return new FloorSlopeArrowInfo
        //                {
        //                    StartPoint = startPoint,
        //                    EndPoint = endPoint,
        //                    Slope = slope
        //                };
        //            }
        //        }
        //    }

        //    return null;
        //}
    }
}
