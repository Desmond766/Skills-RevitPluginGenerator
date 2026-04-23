using ArrangeSingleOrMultiplePipeHangersInTheLinkedModel;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Shapes;
using Line = Autodesk.Revit.DB.Line;

namespace BatchArrangementOfHangersBetweenBeams
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        View3D view3D = null;
        Document doc = null;
        double floorBottomHeight = 0;
        Level level = null;
        FamilySymbol singleFamilySymbol = null;
        double hangerLength = 0;
        Element pipeLine1 = null;
        Element pipeLine2 = null;
        Line midLine = null;
        string singleLayer = "单层";
        FamilySymbol familySymbol = null;
        bool uprighPole = false;

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uIDoc = commandData.Application.ActiveUIDocument;
            doc = uIDoc.Document;

            if (!(doc.ActiveView is ViewPlan))
            {
                TaskDialog.Show("Revit", "请在平面视图中运行插件！");
                return Result.Cancelled;
            }
            View view = doc.ActiveView;

            //程序在3D 支吊架视图中完成
            //改为
            //先找当前视图 对应的3D视图， 找不到再用3D 支吊架，命名规则 3D {当前视图名称}
            View3D default3Dview = null;
            View3D target3Dview = null;
            FilteredElementCollector fristCollector = new FilteredElementCollector(doc).OfClass(typeof(View3D));
            foreach (View3D view3 in fristCollector)
            {
                if ("3D 支吊架".Equals(view3.Name))
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
                    message = string.Format("未找到3D视图： 3D 支吊架 或 3D {0}", doc.ActiveView.Name);
                    return Result.Cancelled;
                }
            }
            UserControl1 userControl1 = new UserControl1(doc);
            

            userControl1.ShowDialog();
            if (userControl1.cancel)
            {
                return Result.Cancelled;
            }
            string centerPointPosition = userControl1.comboBox.Text;
            //double halfBeamWidth = 200 / 304.8;
            
            if (userControl1.bilayer.IsChecked == true)
            {
                singleLayer = "双层";
            }
            if (userControl1.uprightPole.IsChecked == true)
            {
                uprighPole = true;
            }
            Reference beamRef1, beamRef2, pipeLineRef1, pipeLineRef2;
            Element beam1, beam2;
            try
            {
                //点选两根梁 一根风管
                beamRef1 = uIDoc.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.LinkedElement, new LinkedBeamFilter(), "选择第一根梁");// new BeamSelectionFilter()    
                RevitLinkInstance revitLinkInstance1 = doc.GetElement(beamRef1.ElementId) as RevitLinkInstance;
                Document linkdoc1 = revitLinkInstance1.GetLinkDocument();
                //获取元素
                beam1 = linkdoc1.GetElement(beamRef1.LinkedElementId);
                //获取对应的reference
                beamRef2 = uIDoc.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.LinkedElement, new LinkedBeamFilter(beamRef1), "选择第二根梁");// new BeamSelectionFilter()
                RevitLinkInstance revitLinkInstance2 = doc.GetElement(beamRef2.ElementId) as RevitLinkInstance;
                Document linkdoc2 = revitLinkInstance2.GetLinkDocument();
                beam2 = linkdoc2.GetElement(beamRef2.LinkedElementId);
                //if (beam1.Id == beam2.Id)
                //{
                //    //TaskDialog.Show("提示", $"{beam1.Id},{beam2.Id}");
                //    TaskDialog.Show("提示", "不能选取相同的梁");
                //    return Result.Cancelled;
                //}
                pipeLineRef1 = uIDoc.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.Element, new PipeLineFilter(), "选取第一根管线");
                pipeLineRef2 = uIDoc.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.Element, new PipeLineFilter(), "选取第二根管线");
            }
            catch (Autodesk.Revit.Exceptions.OperationCanceledException)
            {
                TaskDialog.Show("提示", "已取消布置");
                return Result.Cancelled;
            }
            //分别获取两根梁的梁宽的一半
            double halfBeamWidth1 = (beam1 as FamilyInstance).Symbol.LookupParameter("b").AsDouble() / 2;
            double halfBeamWidth2 = (beam2 as FamilyInstance).Symbol.LookupParameter("b").AsDouble() / 2;
            //获取布置吊架的宽度
            pipeLine1 = doc.GetElement(pipeLineRef1);
            pipeLine2 = doc.GetElement(pipeLineRef2);
            Curve curve1 = (pipeLine1.Location as LocationCurve).Curve;
            Curve curve2 = (pipeLine2.Location as LocationCurve).Curve;
            Curve beamCurve1 = (beam1.Location as LocationCurve).Curve;
            Curve beamCurve2 = (beam2.Location as LocationCurve).Curve;
            XYZ pipeLinePoint1 = pipeLineRef1.GlobalPoint;
            XYZ pipeLinePoint2 = curve2.Project(pipeLinePoint1).XYZPoint;
            pipeLinePoint1 = new XYZ(pipeLinePoint1.X, pipeLinePoint1.Y, pipeLinePoint2.Z);
            double halfWidth1 = 0.0;
            double halfWidth2 = 0.0;
            foreach (Parameter para in pipeLine1.Parameters)
                if (para.Definition.Name == "直径")
                    halfWidth1 = para.AsDouble() / 2;
            foreach (Parameter para in pipeLine1.Parameters)
                if (para.Definition.Name == "宽度")
                    halfWidth1 = para.AsDouble() / 2;
            foreach (Parameter para in pipeLine2.Parameters)
                if (para.Definition.Name == "直径")
                    halfWidth2 = para.AsDouble() / 2;
            foreach (Parameter para in pipeLine2.Parameters)
                if (para.Definition.Name == "宽度")
                    halfWidth2 = para.AsDouble() / 2;
            hangerLength = pipeLinePoint1.DistanceTo(pipeLinePoint2) + halfWidth1 + halfWidth2;

            if (floorBottomHeight == 0)
            {
                floorBottomHeight = Utils.GetClearHeight(view3D, doc, pipeLinePoint1) + Utils.GetClearHeightUp(view3D, doc, pipeLinePoint1);
            }
            level = doc.GetElement(pipeLine1.get_Parameter(BuiltInParameter.RBS_START_LEVEL_PARAM).AsElementId()) as Level;

            Line referenceLine = Line.CreateBound(pipeLinePoint1, pipeLinePoint2);
            // 获取参考直线的中点
            XYZ midPoint = referenceLine.Evaluate(0.5, true);

            // 创建垂直于参考直线的方向向量
            XYZ perpendicularDirection = new XYZ(-referenceLine.Direction.Y, referenceLine.Direction.X, 0);

            // 定义新直线的起点和终点
            XYZ startPoint = midPoint - curve1.Length * perpendicularDirection;
            XYZ endPoint = midPoint + curve1.Length * perpendicularDirection;
            //族类型
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            collector.OfClass(typeof(FamilySymbol)).OfCategory(BuiltInCategory.OST_MechanicalEquipment);
            singleFamilySymbol = collector.First(m => m.Name == "单层丝杆吊架（基于楼板）") as FamilySymbol;

            familySymbol = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_MechanicalEquipment).OfClass(typeof(FamilySymbol)).First(x => x.Name == "C型钢-楼板固定") as FamilySymbol;

            if (!singleFamilySymbol.IsActive)
            {
                singleFamilySymbol.Activate();
            }
            if (!familySymbol.IsActive)
            {
                familySymbol.Activate();
            }
            //获取管线被两根梁截出的线段
            midLine = Line.CreateBound(startPoint, endPoint);
            XYZ startPoint1 = beamCurve1.GetEndPoint(0);
            startPoint1 = new XYZ(startPoint1.X, startPoint1.Y, startPoint.Z);
            XYZ endPoint1 = beamCurve1.GetEndPoint(1);
            endPoint1 = new XYZ(endPoint1.X, endPoint1.Y, startPoint.Z);
            XYZ startPoint2 = beamCurve2.GetEndPoint(0);
            startPoint2 = new XYZ(startPoint2.X, startPoint2.Y, startPoint.Z);
            XYZ endPoint2 = beamCurve2.GetEndPoint(1);
            endPoint2 = new XYZ(endPoint2.X, endPoint2.Y, startPoint.Z);
            Line beamLine1 = Line.CreateBound(startPoint1, endPoint1);
            Line beamLine2 = Line.CreateBound(startPoint2, endPoint2);
            XYZ intersection1 = GetIntersectionPoint(midLine, beamLine1);
            XYZ intersection2 = GetIntersectionPoint(midLine, beamLine2);
            //创建吊架需要的参数
            if (intersection1 != null && intersection2 != null)
            {
                Level level = doc.GetElement(pipeLine1.get_Parameter(BuiltInParameter.RBS_START_LEVEL_PARAM).AsElementId()) as Level;
                Line line1 = Line.CreateBound(intersection1, intersection2);
                XYZ createDirection = line1.Direction.Normalize();
                XYZ createStartPoint = line1.GetEndPoint(0) + halfBeamWidth1 * createDirection /*150 / 304.8 * createDirection*/;
                XYZ createEndPoint = line1.GetEndPoint(1) - halfBeamWidth2 * createDirection /*150 / 304.8 * createDirection*/;
                using (Transaction t = new Transaction(doc,$"梁间批量创建{centerPointPosition}吊架 间距:{GetSpacing(createStartPoint,createEndPoint)}mm"))
                {
                    t.Start();
                    if (CentralLayout(createStartPoint,createEndPoint))
                    {
                        CreateHanger(createStartPoint, createEndPoint);
                    }
                    else
                    {
                        CreateHanger2(createStartPoint, createEndPoint, createDirection);
                    }
                    t.Commit();
                }
            }
            return Result.Succeeded;
        }
        private XYZ GetIntersectionPoint(Line line1, Line line2)
        {
            // 判断两条直线是否相交
            SetComparisonResult result = line1.Intersect(line2, out IntersectionResultArray intersectionResult);

            // 如果相交，获取交点坐标
            if (result == SetComparisonResult.Overlap)
            {
                XYZ intersectionPoint = intersectionResult.get_Item(0).XYZPoint;
                return intersectionPoint;
            }
            else
            {
                // 如果不相交，返回null或者抛出异常
                return null;
            }
        }

        private void CreateHanger(XYZ createStartPoint,XYZ createEndPoint)
        {
            XYZ midPoint = (createStartPoint + createEndPoint) / 2;
            Line createLine = Line.CreateBound(createStartPoint, createEndPoint);
            FamilyInstance familyInstance = doc.Create.NewFamilyInstance(midPoint, familySymbol, level, Autodesk.Revit.DB.Structure.StructuralType.NonStructural);
            //设置吊架的参数
            familyInstance.LookupParameter("标高中的高程").Set(0);
            foreach (Parameter para in familyInstance.Parameters)
                if (para.Definition.Name == "c_风管宽" || para.Definition.Name == "c_桥架宽")
                    para.Set(hangerLength);
            //familyInstance.LookupParameter("c_风管宽").Set(hangerLength);
            double pipelineBottomHeight = pipeLine1.LookupParameter("底部高程").AsDouble();
            familyInstance.LookupParameter("b_底层管道底高").Set(pipelineBottomHeight);
            familyInstance.LookupParameter("a_楼板底高").Set(floorBottomHeight);
            if (uprighPole)
            {
                foreach (Parameter para in familyInstance.Parameters)
                    if (para.Definition.Name == "中立杆")
                        para.Set(1);
            }
            if (singleLayer == "双层")
            {
                //foreach (Parameter para in familyInstance.Parameters)
                //{
                //    if (para.Definition.Name == "双层吊架")
                //        para.Set(1);
                //}
                //以管线宽的一半为中点，宽为直径放样，先向下600mm找管线，未找到再向上600mm找管线
                double halfHeight = 0.0;
                foreach (Parameter para in pipeLine2.Parameters)
                    if (para.Definition.Name == "高度" || para.Definition.Name == "外径")
                    {
                        halfHeight = para.AsDouble() / 2;
                        break;
                    }
                XYZ centerPointDown = midPoint + (halfHeight + 0.001) * XYZ.BasisZ.Negate();
                //XYZ centerPointDown = midPoint + 200 / 304.8 * XYZ.BasisZ.Negate();
                Curve circle1 = Arc.Create(centerPointDown, hangerLength, 0, Math.PI, XYZ.BasisX, XYZ.BasisY);
                Curve circle2 = Arc.Create(centerPointDown, hangerLength, Math.PI, 2 * Math.PI, XYZ.BasisX, XYZ.BasisY);
                List<Curve> curveList = new List<Curve> { circle1, circle2 };
                CurveLoop curveLoop = CurveLoop.Create(curveList);
                IList<CurveLoop> curves = new List<CurveLoop> { curveLoop };
                Solid solidDown = GeometryCreationUtilities.CreateExtrusionGeometry(curves, XYZ.BasisZ.Negate(), 600 / 304.8);
                ElementIntersectsSolidFilter solidFilterDown = new ElementIntersectsSolidFilter(solidDown);
                ElementCategoryFilter cableTrayFilter = new ElementCategoryFilter(BuiltInCategory.OST_CableTray);
                ElementCategoryFilter pipeFilter = new ElementCategoryFilter(BuiltInCategory.OST_PipeCurves);
                LogicalOrFilter logicalOrFilter = new LogicalOrFilter(cableTrayFilter, pipeFilter);
                List<Element> pipeAndCableTraysDown = new FilteredElementCollector(doc).WherePasses(logicalOrFilter).WherePasses(solidFilterDown).ToElements().ToList();
                if (pipeAndCableTraysDown.Count() != 0)
                {
                    Element pipeAndCableTrayDown = pipeAndCableTraysDown.First();
                    foreach (Parameter para in pipeAndCableTrayDown.Parameters)
                        if (para.Definition.Name == "底部高程")
                        {
                            familyInstance.LookupParameter("b_底层管道底高").Set(para.AsDouble());
                            familyInstance.LookupParameter("上层横担间距").Set(pipelineBottomHeight - para.AsDouble());
                        }
                    foreach (Parameter para in familyInstance.Parameters)
                    {
                        if (para.Definition.Name == "双层吊架")
                            para.Set(1);
                    }
                }
                if(pipeAndCableTraysDown.Count() == 0)
                {
                    XYZ centerPointUp = midPoint + (halfHeight + 0.001) * XYZ.BasisZ;
                    Curve circle3 = Arc.Create(centerPointUp, hangerLength / 2, 0, Math.PI, XYZ.BasisX, XYZ.BasisY);
                    Curve circle4 = Arc.Create(centerPointUp, hangerLength / 2, Math.PI, 2 * Math.PI, XYZ.BasisX, XYZ.BasisY);
                    List<Curve> curveListUp = new List<Curve> { circle3, circle4 };
                    CurveLoop curveLoopUp = CurveLoop.Create(curveListUp);
                    IList<CurveLoop> curvesUp = new List<CurveLoop> { curveLoopUp };
                    Solid solidUp = GeometryCreationUtilities.CreateExtrusionGeometry(curvesUp, XYZ.BasisZ, 600 / 304.8);
                    ElementIntersectsSolidFilter solidFilterUp = new ElementIntersectsSolidFilter(solidUp);
                    List<Element> pipeAndCableTraysUp = new FilteredElementCollector(doc).WherePasses(logicalOrFilter).WherePasses(solidFilterUp).ToElements().ToList();

                    if (pipeAndCableTraysUp.Count() != 0)
                    {
                        foreach (Parameter para in familyInstance.Parameters)
                        {
                            if (para.Definition.Name == "双层吊架")
                                para.Set(1);
                        }
                        Element pipeAndCableTrayUp = pipeAndCableTraysUp.First();
                        foreach (Parameter para in pipeAndCableTrayUp.Parameters)
                            if (para.Definition.Name == "底部高程")
                                familyInstance.LookupParameter("上层横担间距").Set(para.AsDouble() - pipelineBottomHeight);
                    }
                }
            }
            //旋转吊架
            XYZ directionVector = midLine.Direction.Normalize();
            double angle = directionVector.AngleTo(XYZ.BasisX);
            Line axis = Line.CreateBound(midPoint, new XYZ(midPoint.X, midPoint.Y, 0));
            if (angle > 0.5 * Math.PI)
            {
                angle = Math.PI - angle;
            }
            ElementTransformUtils.RotateElement(doc, familyInstance.Id, axis, 0.5 * Math.PI - angle);
            Transform transform = familyInstance.GetTransform();

            if (Math.Abs(transform.OfVector(XYZ.BasisX).AngleTo(directionVector) - 0.5 * Math.PI) > 0.001)
            {
                ElementTransformUtils.RotateElement(doc, familyInstance.Id, axis, -2 * (0.5 * Math.PI - angle));
                //ElementTransformUtils.RotateElement(doc, familyInstance.Id, axis, 0.5 * Math.PI);
            }
            if (createLine.Length * 304.8 / 4 > 1800)
            {
                CreateHanger(createStartPoint, midPoint);
                CreateHanger(midPoint, createEndPoint);
            }

        }

        private int GetSpacing(XYZ createStartPoint, XYZ createEndPoint)
        {
            Line createLine = Line.CreateBound(createStartPoint, createEndPoint);
            int spacing = Convert.ToInt32(createLine.Length * 304.8);
            if (CentralLayout(createStartPoint, createEndPoint))
            {
                do
                {
                    spacing = spacing / 2;
                } while (spacing > 1800);
                return spacing * 2;
            }
            else
            {
                int num = 0;
                double length = createStartPoint.DistanceTo(createEndPoint);
                for (int i = 1; i < 20; i++)
                {
                    double spacing1 = length / (i + 1);
                    if (spacing1 > 1800 / 304.8 && spacing1 < 2500 / 304.8)
                    {
                        num = i;
                        length = spacing1;
                        break;
                    }
                }
                if (num == 0)
                {
                    for (int i = 1; i < 20; i++)
                    {
                        double spacing1 = length / (i + 1);
                        if (spacing1 > 1667 / 304.8 && spacing1 < 1800 / 304.8)
                        {
                            num = i;
                            length = spacing1;
                            break;
                        }
                    }
                }
                return Convert.ToInt32(length * 304.8);
            }
        }
        private bool CentralLayout(XYZ createStartPoint, XYZ createEndPoint)
        {
            double length = createStartPoint.DistanceTo(createEndPoint);
            for (int i = 0; i < 10; i++)
            {
                length = length / 2;
                if (length > 1800 / 304.8 && length < 2500 / 304.8)
                {
                    return true;
                }
            }
            return false;
        }

        private void CreateHanger2(XYZ createStartPoint, XYZ createEndPoint,XYZ direction)
        {

            int num = 0;
            XYZ midPoint = createStartPoint;
            double length = createStartPoint.DistanceTo(createEndPoint);
            for (int i = 1; i < 20; i++)
            {
                double spacing = length / (i + 1);
                if (spacing > 1800 / 304.8 && spacing < 2500 / 304.8)
                {
                    num = i;
                    length = spacing;
                    break;
                }
            }
            if (num == 0)
            {
                for (int i = 1; i < 20; i++)
                {
                    double spacing = length / (i + 1);
                    if (spacing > 1667 / 304.8 && spacing < 1800 / 304.8)
                    {
                        num = i;
                        length = spacing;
                        break;
                    }
                }
            }
            if (num == 0)
            {
                TaskDialog.Show("提示", "此梁间距未找到合适的布置方案");
            }
            for (int j = 0; j < num; j++)
            {
                midPoint = midPoint + length * direction;
                FamilyInstance familyInstance = doc.Create.NewFamilyInstance(midPoint, familySymbol, level, Autodesk.Revit.DB.Structure.StructuralType.NonStructural);
                //设置吊架的参数
                familyInstance.LookupParameter("标高中的高程").Set(0);
                foreach (Parameter para in familyInstance.Parameters)
                    if (para.Definition.Name == "c_风管宽" || para.Definition.Name == "c_桥架宽")
                        para.Set(hangerLength);
                //familyInstance.LookupParameter("c_风管宽").Set(hangerLength);
                double pipelineBottomHeight = pipeLine1.LookupParameter("底部高程").AsDouble();
                familyInstance.LookupParameter("b_底层管道底高").Set(pipelineBottomHeight);
                familyInstance.LookupParameter("a_楼板底高").Set(floorBottomHeight);
                if (uprighPole)
                {
                    foreach (Parameter para in familyInstance.Parameters)
                        if (para.Definition.Name == "中立杆")
                            para.Set(1);
                }
                if (singleLayer == "双层")
                {
                    //foreach (Parameter para in familyInstance.Parameters)
                    //{
                    //    if (para.Definition.Name == "双层吊架")
                    //        para.Set(1);
                    //}
                    //以管线宽的一半为中点，宽为直径放样，先向下600mm找管线，未找到再向上600mm找管线
                    double halfHeight = 0.0;
                    foreach (Parameter para in pipeLine2.Parameters)
                        if (para.Definition.Name == "高度" || para.Definition.Name == "外径")
                        {
                            halfHeight = para.AsDouble() / 2;
                            break;
                        }
                    XYZ centerPointDown = midPoint + (halfHeight + 0.001) * XYZ.BasisZ.Negate();
                    //XYZ centerPointDown = midPoint + 200 / 304.8 * XYZ.BasisZ.Negate();
                    Curve circle1 = Arc.Create(centerPointDown, hangerLength, 0, Math.PI, XYZ.BasisX, XYZ.BasisY);
                    Curve circle2 = Arc.Create(centerPointDown, hangerLength, Math.PI, 2 * Math.PI, XYZ.BasisX, XYZ.BasisY);
                    List<Curve> curveList = new List<Curve> { circle1, circle2 };
                    CurveLoop curveLoop = CurveLoop.Create(curveList);
                    IList<CurveLoop> curves = new List<CurveLoop> { curveLoop };
                    Solid solidDown = GeometryCreationUtilities.CreateExtrusionGeometry(curves, XYZ.BasisZ.Negate(), 600 / 304.8);
                    ElementIntersectsSolidFilter solidFilterDown = new ElementIntersectsSolidFilter(solidDown);
                    ElementCategoryFilter cableTrayFilter = new ElementCategoryFilter(BuiltInCategory.OST_CableTray);
                    ElementCategoryFilter pipeFilter = new ElementCategoryFilter(BuiltInCategory.OST_PipeCurves);
                    LogicalOrFilter logicalOrFilter = new LogicalOrFilter(cableTrayFilter, pipeFilter);
                    List<Element> pipeAndCableTraysDown = new FilteredElementCollector(doc).WherePasses(logicalOrFilter).WherePasses(solidFilterDown).ToElements().ToList();
                    if (pipeAndCableTraysDown.Count() != 0)
                    {
                        Element pipeAndCableTrayDown = pipeAndCableTraysDown.First();
                        foreach (Parameter para in pipeAndCableTrayDown.Parameters)
                            if (para.Definition.Name == "底部高程")
                            {
                                familyInstance.LookupParameter("b_底层管道底高").Set(para.AsDouble());
                                familyInstance.LookupParameter("上层横担间距").Set(pipelineBottomHeight - para.AsDouble());
                            }
                        foreach (Parameter para in familyInstance.Parameters)
                        {
                            if (para.Definition.Name == "双层吊架")
                                para.Set(1);
                        }
                    }
                    if (pipeAndCableTraysDown.Count() == 0)
                    {
                        XYZ centerPointUp = midPoint + (halfHeight + 0.001) * XYZ.BasisZ;
                        Curve circle3 = Arc.Create(centerPointUp, hangerLength / 2, 0, Math.PI, XYZ.BasisX, XYZ.BasisY);
                        Curve circle4 = Arc.Create(centerPointUp, hangerLength / 2, Math.PI, 2 * Math.PI, XYZ.BasisX, XYZ.BasisY);
                        List<Curve> curveListUp = new List<Curve> { circle3, circle4 };
                        CurveLoop curveLoopUp = CurveLoop.Create(curveListUp);
                        IList<CurveLoop> curvesUp = new List<CurveLoop> { curveLoopUp };
                        Solid solidUp = GeometryCreationUtilities.CreateExtrusionGeometry(curvesUp, XYZ.BasisZ, 600 / 304.8);
                        ElementIntersectsSolidFilter solidFilterUp = new ElementIntersectsSolidFilter(solidUp);
                        List<Element> pipeAndCableTraysUp = new FilteredElementCollector(doc).WherePasses(logicalOrFilter).WherePasses(solidFilterUp).ToElements().ToList();

                        if (pipeAndCableTraysUp.Count() != 0)
                        {
                            foreach (Parameter para in familyInstance.Parameters)
                            {
                                if (para.Definition.Name == "双层吊架")
                                    para.Set(1);
                            }
                            Element pipeAndCableTrayUp = pipeAndCableTraysUp.First();
                            foreach (Parameter para in pipeAndCableTrayUp.Parameters)
                                if (para.Definition.Name == "底部高程")
                                    familyInstance.LookupParameter("上层横担间距").Set(para.AsDouble() - pipelineBottomHeight);
                        }
                    }
                }
                //旋转吊架
                XYZ directionVector = midLine.Direction.Normalize();
                double angle = directionVector.AngleTo(XYZ.BasisX);
                Line axis = Line.CreateBound(midPoint, new XYZ(midPoint.X, midPoint.Y, 0));
                if (angle > 0.5 * Math.PI)
                {
                    angle = Math.PI - angle;
                }
                ElementTransformUtils.RotateElement(doc, familyInstance.Id, axis, 0.5 * Math.PI - angle);
                Transform transform = familyInstance.GetTransform();

                if (Math.Abs(transform.OfVector(XYZ.BasisX).AngleTo(directionVector) - 0.5 * Math.PI) > 0.001)
                {
                    ElementTransformUtils.RotateElement(doc, familyInstance.Id, axis, -2 * (0.5 * Math.PI - angle));
                    //ElementTransformUtils.RotateElement(doc, familyInstance.Id, axis, 0.5 * Math.PI);
                }
            }
        }
    }
}
