using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Structure;
using Autodesk.Revit.UI;
using SetFitting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MepPractice
{
    [TransactionAttribute(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class CommandFit : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uiDoc = commandData.Application.ActiveUIDocument;
            Autodesk.Revit.DB.Document doc = uiDoc.Document;

            MainWindow mainWindow = new MainWindow();
            // 非模态窗口
             //mainWindow.Show();

            // 模态窗口,
            mainWindow.ShowDialog();

            if (!mainWindow.IsClickClosed)
            {
                return Result.Cancelled;
            }

            double gap = Convert.ToDouble(mainWindow.Text_btwSpace.Text);
            //if(null == gap)
            //{
            //    TaskDialog.Show("")
            //}
            double spaceBetween = ToFoot(gap);

            string CbxTypeString = mainWindow.Cbx_Type.Text.ToString();
            string CbxOriginString = mainWindow.Cbx_origin.Text.ToString();

            Reference beamRef1, beamRef2, ductRef;
            try
            {
                //点选两根梁 一根风管
                beamRef1 = uiDoc.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.Element, "选择第一根梁");// new BeamSelectionFilter()
                beamRef2 = uiDoc.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.Element, "选择第二根梁");// new BeamSelectionFilter()
                ductRef = uiDoc.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.Element, "选择风管");
            }
            catch (Autodesk.Revit.Exceptions.OperationCanceledException)
            {
                return Result.Cancelled;
            }

            // 获取选择的梁元素
            Element beam1 = doc.GetElement(beamRef1);
            Element beam2 = doc.GetElement(beamRef2);
            //获取选择的风管元素
            Element duct = doc.GetElement(ductRef);
            //获取风管的标高
            Level level = duct as Level;

            // 获取梁的几何信息
            LocationCurve locationCurve1 = beam1.Location as LocationCurve;
            LocationCurve locationCurve2 = beam2.Location as LocationCurve;
            Curve curve1 = locationCurve1.Curve;
            Curve curve2 = locationCurve2.Curve;

            //获取风管的几何信息
            LocationCurve locationCurveDuct = duct.Location as LocationCurve;
            Line lineDuct = locationCurveDuct.Curve as Line;
            XYZ referenceDirection = lineDuct.Direction;
            // 计算最短距离和相应的点
            XYZ closesPoint1, closesPoint2;
            double minDistance = GetClosesPoints(curve1, curve2, out closesPoint1, out closesPoint2);

            //TaskDialog.Show("最近点", $"最近的距离为：{minDistance}" +
            //$"\n点1坐标：{closesPoint1}" +
            //$"\n点2坐标：{closesPoint2}");
            Curve closesCurve = Line.CreateBound(closesPoint1, closesPoint2);
            XYZ beamMidPoint = closesCurve.Evaluate(0.5, true);
            //获得两条梁之间最短距离线段的中点到风管的投影点
            XYZ midPoint = GetProjectivePoint(lineDuct, beamMidPoint);

            //获得风管在平面上被梁截出的线段的中点
            XYZ movePoint0, movePoint1, movePoint2, movePoint3;
            Line MoveLine1 = GetMoveLine(doc, curve1, lineDuct, out movePoint0, out movePoint1);
            Line MoveLine2 = GetMoveLine(doc, curve2, lineDuct, out movePoint2, out movePoint3);
            XYZ intersectionPoint1 = GetIntersection(MoveLine1, lineDuct);       //获得梁1投影线段与风管的交点
            XYZ intersectionPoint2 = GetIntersection(MoveLine2, lineDuct);      //获得梁2投影线段与风管的交点

            Line lineBeamToDuct = Line.CreateBound(intersectionPoint1, intersectionPoint2);
            XYZ midDuctInBeam = lineBeamToDuct.Evaluate(0.5, true);  

            //TaskDialog.Show("交点坐标为:" , $"{intersectionPoint1}");



            using (Transaction trans = new Transaction(doc))
            {
                trans.Start("Creat Fitting");
                //CreateModelLine(doc, closesPoint1, closesPoint2);
                //CreateModelLine(doc, beamMidPoint, midPoint);
                if (CbxTypeString == "中心创建上固定" && CbxOriginString == "风管于梁之间的中心")
                {

                    SetMidUpFitting1(doc, referenceDirection, midDuctInBeam, intersectionPoint1, intersectionPoint2, spaceBetween, duct);
                }

                else if (CbxTypeString == "中心创建下固定" && CbxOriginString == "风管于梁之间的中心")
                {
                    SetMidDownFitting1(doc, referenceDirection, midDuctInBeam, intersectionPoint1, intersectionPoint2, spaceBetween, duct);
                }
                else if (CbxTypeString == "中心创建上固定" && CbxOriginString == "梁最短距离中心")
                {

                    SetMidUpFitting2(doc, referenceDirection, midPoint, intersectionPoint1, intersectionPoint2, spaceBetween, duct);
                }

                else if (CbxTypeString == "中心创建下固定" && CbxOriginString == "梁最短距离中心")
                {
                    SetMidDownFitting2(doc, referenceDirection, midPoint, intersectionPoint1, intersectionPoint2, spaceBetween, duct);
                }



                //SetMidDownFitting(doc, referenceDirection, midPoint, intersectionPoint1, intersectionPoint2, spaceBetween, duct);


                //CreatDuctFitting(doc, midDuctInBeam, referenceDirection, duct);
                trans.Commit();
            }






            return Result.Succeeded;
        }
        /// <summary>
        /// 创建下固定吊架
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="midPoint"></param>
        /// <param name="referenceDirection"></param>
        /// <param name="host"></param>
        /// <returns></returns>
        FamilyInstance CreatDownDuctFitting(Document doc, XYZ midPoint, XYZ referenceDirection, Element host)
        {
            FamilyInstance instance = null;

            FilteredElementCollector collector = new FilteredElementCollector(doc);
            //IEnumerable<Element> eleList = collector.OfClass(typeof(FamilySymbol)).OfCategory(BuiltInCategory.OST_DuctFitting);
            //  .Where(m => m.Name == "风管法兰吊架-下固定");
            //FamilySymbol DuctFittingType = eleList.First(m => m.Name == "风管法兰吊架-下固定") as FamilySymbol;

            collector.OfClass(typeof(FamilySymbol)).OfCategory(BuiltInCategory.OST_DuctFitting);
            FamilySymbol DuctFittingType = collector.First(m => m.Name == "风管法兰吊架-下固定") as FamilySymbol;

            
            if (!DuctFittingType.IsActive)
            {

                DuctFittingType.Activate();             //若未激活族则激活
            }
            if (null != DuctFittingType)
            {

                instance = doc.Create.NewFamilyInstance(midPoint, DuctFittingType, referenceDirection, host, StructuralType.NonStructural);
            }



            return instance;
        }

        /// <summary>
        /// 创建上固定架
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="midPoint"></param>
        /// <param name="referenceDirection"></param>
        /// <param name="host"></param>
        /// <returns></returns>
        FamilyInstance CreatUpDuctFitting(Document doc, XYZ midPoint, XYZ referenceDirection, Element host)
        {
            FamilyInstance instance = null;

            FilteredElementCollector collector = new FilteredElementCollector(doc);
            collector.OfClass(typeof(FamilySymbol)).OfCategory(BuiltInCategory.OST_DuctFitting);
            FamilySymbol DuctFittingType = collector.First(m => m.Name == "风管法兰吊架-上固定") as FamilySymbol;

            if (!DuctFittingType.IsActive)
            {

                DuctFittingType.Activate();
            }
            if (null != DuctFittingType)
            {

                instance = doc.Create.NewFamilyInstance(midPoint, DuctFittingType, referenceDirection, host, StructuralType.NonStructural);
            }



            return instance;
        }

        #region 绘制模型线
        /// <summary>
        /// 绘制模型线
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        public void CreateModelLine(Autodesk.Revit.DB.Document doc, XYZ p1, XYZ p2)
        {
            using (var line = Line.CreateBound(p1, p2))
            {
                using (var skPlane = SketchPlane.Create(doc, ToPlane(p1, p2)))
                {
                    if (doc.IsFamilyDocument)
                    {
                        doc.FamilyCreate.NewModelCurve(line, skPlane);
                    }
                    else
                    {
                        doc.Create.NewModelCurve(line, skPlane);
                    }
                }
            }
        }
        #endregion
        #region 点所在平面
        /// <summary>
        /// 点所在平面
        /// </summary>
        /// <param name="point"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        public Autodesk.Revit.DB.Plane ToPlane(XYZ point, XYZ other)
        {
            var v = other - point;
            if (v.Normalize().IsAlmostEqualTo(XYZ.BasisX)
                || v.Normalize().IsAlmostEqualTo(XYZ.BasisX.Negate()))
            {
                return Autodesk.Revit.DB.Plane.CreateByNormalAndOrigin(XYZ.BasisZ, point);
            }
            var angle = v.AngleTo(XYZ.BasisX);
            var norm = v.CrossProduct(XYZ.BasisX).Normalize();

            if (Math.Abs(angle - 0) < 1e-4)
            {
                angle = v.AngleTo(XYZ.BasisY);
                norm = v.CrossProduct(XYZ.BasisY).Normalize();
            }

            if (Math.Abs(angle - 0) < 1e-4)
            {
                angle = v.AngleTo(XYZ.BasisZ);
                norm = v.CrossProduct(XYZ.BasisZ).Normalize();
            }
            //return new Autodesk.Revit.DB.Plane(norm, point);
            return Autodesk.Revit.DB.Plane.CreateByNormalAndOrigin(norm, point);//2018
        }
        #endregion
        /// <summary>
        /// 计算最短距离和相应的点
        /// </summary>
        /// <param name="curve1">第一条线</param>
        /// <param name="curve2">第二条线</param>
        /// <param name="closesPoint1">第一个点</param>
        /// <param name="closesPoint2">第二个点</param>
        /// <returns></returns>
        private double GetClosesPoints(Curve curve1, Curve curve2, out XYZ closesPoint1, out XYZ closesPoint2)
        {
            //curve1.Tessellate()是一个Revit API中的方法，
            //用于获取曲线的离散化点集合。调用该方法会将曲线细分成一系列离散的点，
            //并返回一个迭代器（IEnumerable<XYZ>）。
            //通过调用.ToList()方法，可以将迭代器转换为List<XYZ>类型的集合。
            List<XYZ> pointsCurve1 = curve1.Tessellate().ToList();
            List<XYZ> pointsCurve2 = curve2.Tessellate().ToList();

            double minDistance = double.MaxValue;
            closesPoint1 = null;
            closesPoint2 = null;
            // 遍历两个曲线上的点对，计算它们之间的距离，并找到最小值及相应的点
            foreach (XYZ point1 in pointsCurve1)
            {
                foreach (XYZ point2 in pointsCurve2)
                {
                    double distance = point1.DistanceTo(point2);
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        closesPoint1 = point1;
                        closesPoint2 = point2;
                    }
                }
            }
            return minDistance;

        }

        #region 获得点在直线上的投影点坐标
        /// <summary>
        /// 获得点在直线上的投影点坐标
        /// </summary>
        /// <param name="p1">直线起点</param>
        /// <param name="p2">直线终点</param>
        /// <param name="q">直线外的点</param>
        /// <returns>投影点</returns>
        public static XYZ GetProjectivePoint(XYZ p1, XYZ p2, XYZ q)
        {
            XYZ u = p2 - p1;
            XYZ pq = q - p1;
            XYZ w2 = pq - u.Multiply(pq.DotProduct(u) / (u.GetLength() * u.GetLength()));
            XYZ point = q - w2;
            return point;
        }

        /// <summary>
        /// 获得点在直线上的投影点坐标
        /// </summary>
        /// <param name="l">直线</param>
        /// <param name="q">直线外的点</param>
        /// <returns>投影点</returns>
        public static XYZ GetProjectivePoint(Line l, XYZ q)
        {
            XYZ u = l.Direction;
            XYZ pq = q - l.GetEndPoint(0);
            XYZ w2 = pq - u.Multiply(pq.DotProduct(u) / (u.GetLength() * u.GetLength()));
            XYZ point = q - w2;
            return point;
        }

        #endregion


        /// <summary>
        /// 米转英尺
        /// </summary>
        /// <param name="var">米</param>
        /// <returns>英尺</returns>
        public double ToFoot(double var)
        {
            double foot = var / 304.8;
            return foot;

        }

        /// <summary>
        /// 获取不同平面直线投影的交点
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="beam"></param>
        /// <param name="duct"></param>
        /// <returns></returns>
        public static Line GetMoveLine(Document doc, Curve beam, Line duct, out XYZ movePoint0, out XYZ movePoint1)
        {
            XYZ beamPoint0 = beam.GetEndPoint(0);
            XYZ beamPoint1 = beam.GetEndPoint(1);
            XYZ ductPoint = duct.Evaluate(0.5, true);        //获取风管线段中点坐标
            movePoint0 = new XYZ(beamPoint0.X, beamPoint0.Y, ductPoint.Z); //将梁端点坐标的Z轴值改为与风管中点坐标Z值相等
            movePoint1 = new XYZ(beamPoint1.X, beamPoint1.Y, ductPoint.Z);
            Line moveLine = Line.CreateBound(movePoint0, movePoint1);
            return moveLine;
        }
        /// <summary>
        /// 获取两直线的交点（直线只有一个交点）
        /// </summary>
        /// <param name="line1"></param>
        /// <param name="line2"></param>
        /// <returns></returns>
        private Autodesk.Revit.DB.XYZ GetIntersection(Line line1, Line line2)
        {
            Autodesk.Revit.DB.XYZ intersectionPoint = null;
            IntersectionResultArray results; // 交点数组
            Autodesk.Revit.DB.SetComparisonResult result = line1.Intersect(line2, out results);

            if (result != Autodesk.Revit.DB.SetComparisonResult.Overlap) // 重叠，没有重叠就是平行
                return intersectionPoint;

            if (results == null || results.Size != 1) // 没有交点或者交点不是1个
                return intersectionPoint;

            IntersectionResult iResult = results.get_Item(0); // 取得交点
            intersectionPoint = iResult.XYZPoint; // 取得交点坐标
            return intersectionPoint;
        }
        private void SetMidDownFitting1(Document doc, XYZ referenceDirection, XYZ putPoint, XYZ startPoint, XYZ endPoint, double foot, Element host)
        {
            Line linePart1 = Line.CreateBound(putPoint, startPoint);
            Line linePart2 = Line.CreateBound(putPoint, endPoint);
            double length1 = linePart1.Length;
            double length2 = linePart2.Length;

            double Raw1Part1 = linePart1.GetEndParameter(0);

            double Raw1Part2 = linePart2.GetEndParameter(0);
            // int times = 0;
            //int i1 = (int)(length1 / foot);
            //int i2 = (int)(length2 / foot);
            double increase1 = foot;
            double increase2 = foot;

            int j = 0;

            double startPointDe = linePart1.GetEndParameter(1);
            double endPointDe = linePart2.GetEndParameter(1);
            XYZ startPoint100 = linePart1.Evaluate(startPointDe + ToFoot(100), false);
            XYZ endPoint100 = linePart2.Evaluate(endPointDe + ToFoot(100), false);
            CreatDownDuctFitting(doc, putPoint, referenceDirection, host);

            //通过对2取余是否为0判断插入支吊架的种类
            for (int i1 = (int)(length1 / foot); i1 > 0; i1--)
            {

                XYZ movePoint1 = linePart1.Evaluate(Raw1Part1 + increase1, false);
                if (j % 2 != 0)              
                {
                    if (increase1 != length1)
                    {
                        CreatDownDuctFitting(doc, movePoint1, referenceDirection, host);
                    }
                    else if (increase1 == length1)
                    {
                        CreatDownDuctFitting(doc, startPoint100, referenceDirection, host);
                    }



                    //if (length1 % foot == 0 && increase1 == foot)
                    //{

                    //    CreatDownDuctFitting(doc, startPoint100, referenceDirection, host);
                    //    i1--;
                    //}
                }

                else if (j % 2 == 0)
                {
                    if (increase1 != length1)
                    {
                        CreatUpDuctFitting(doc, movePoint1, referenceDirection, host);
                    }
                    else if (increase1 == length1)
                    {
                        CreatUpDuctFitting(doc, startPoint100, referenceDirection, host);
                    }


                    //if (length1 % foot == 0 && increase1 == foot)
                    //{

                    //    CreatDownDuctFitting(doc, startPoint100, referenceDirection, host);
                    //    i1--;
                    //}
                }
                increase1 += foot;
                j++;
            }

            for (int i2 = (int)(length2 / foot); i2 > 0; i2--)
            {
                XYZ movePoint2 = linePart2.Evaluate(Raw1Part2 + increase2, false);
                if (j % 2 != 0)
                {
                    if (increase2 != length2)
                    {
                        CreatDownDuctFitting(doc, movePoint2, referenceDirection, host);
                    }
                    else if (increase2 == length2)
                    {
                        CreatDownDuctFitting(doc, endPoint100, referenceDirection, host);
                    }

                    //if (length2 % foot == 0 && increase2 == foot)
                    //{

                    //    CreatDownDuctFitting(doc, endPoint100, referenceDirection, host);
                    //    i2--;
                    //}
                }

                else if (j % 2 == 0)
                {
                    if (increase2 != length2)
                    {
                        CreatUpDuctFitting(doc, movePoint2, referenceDirection, host);
                    }
                    else if (increase2 == length2)
                    {
                        CreatUpDuctFitting(doc, endPoint100, referenceDirection, host);
                    }

                    //if (length2 % foot == 0 && increase2 == foot)
                    //{

                    //    CreatDownDuctFitting(doc, endPoint100, referenceDirection, host);
                    //    i2--;
                    //}
                }
                increase2 += foot;
                j++;
            }

        }
        private void SetMidDownFitting2(Document doc, XYZ referenceDirection, XYZ putPoint, XYZ startPoint, XYZ endPoint, double foot, Element host)
        {
            Line linePart1 = Line.CreateBound(putPoint, startPoint);
            Line linePart2 = Line.CreateBound(putPoint, endPoint);
            double length1 = linePart1.Length;
            double length2 = linePart2.Length;

            double Raw1Part1 = linePart1.GetEndParameter(0);

            double Raw1Part2 = linePart2.GetEndParameter(0);
            //int i1 = (int)(length1 / foot);
            //int i2 = (int)(length2 / foot);
            double increase1 = foot;
            double increase2 = foot;

            int j = 0;

            double startPointDe = linePart1.GetEndParameter(1);
            double endPointDe = linePart2.GetEndParameter(1);
            XYZ startPoint100 = linePart1.Evaluate(startPointDe + ToFoot(100), false);
            XYZ endPoint100 = linePart2.Evaluate(endPointDe + ToFoot(100), false);

            CreatDownDuctFitting(doc, putPoint, referenceDirection, host);
            for (int i1 = (int)(length1 / foot); i1 > 0; i1--)
            {
                XYZ movePoint1 = linePart1.Evaluate(Raw1Part1 + increase1, false);
                if (j % 2 != 0)
                {
                    if (increase1 != length1)
                    {
                        CreatDownDuctFitting(doc, movePoint1, referenceDirection, host);
                    }
                    else if (increase1 == length1)
                    {
                        CreatDownDuctFitting(doc, startPoint100, referenceDirection, host);
                    }

                    //if (length1 % foot == 0 && increase1 == foot)
                    //{

                    //    CreatDownDuctFitting(doc, startPoint100, referenceDirection, host);
                    //    i1--;
                    //}
                }

                else if (j % 2 == 0)
                {
                    if (increase1 != length1)
                    {
                        CreatUpDuctFitting(doc, movePoint1, referenceDirection, host);
                    }
                    else if (increase1 == length1)
                    {
                        CreatUpDuctFitting(doc, startPoint100, referenceDirection, host);
                    }

                    //if (length1 % foot == 0 && increase1 == foot)
                    //{

                    //    CreatDownDuctFitting(doc, startPoint100, referenceDirection, host);
                    //    i1--;
                    //}
                }
                increase1 += foot;
                j++;
            }

            for (int i2 = (int)(length2 / foot); i2 > 0; i2--)
            {
                XYZ movePoint2 = linePart2.Evaluate(Raw1Part2 + increase2, false);
                if (j % 2 == 0)
                {
                    if (increase2 != length2)
                    {
                        CreatDownDuctFitting(doc, movePoint2, referenceDirection, host);
                    }
                    else if (increase2 == length2)
                    {
                        CreatDownDuctFitting(doc, endPoint100, referenceDirection, host);
                    }
                    //if (length2 % foot == 0 && increase2 == foot)
                    //{

                    //    CreatDownDuctFitting(doc, endPoint100, referenceDirection, host);
                    //    i2--;
                    //}
                }

                else if (j % 2 != 0)
                {
                    if (increase2 != length2)
                    {
                        CreatUpDuctFitting(doc, movePoint2, referenceDirection, host);
                    }
                    else if (increase2 == length2)
                    {
                        CreatUpDuctFitting(doc, endPoint100, referenceDirection, host);
                    }
                    //if (length2 % foot == 0 && increase2 == foot)
                    //{

                    //    CreatDownDuctFitting(doc, endPoint100, referenceDirection, host);
                    //    i2--;
                    //}
                }
                increase2 += foot;
                j++;
            }

        }
        private void SetMidUpFitting1(Document doc, XYZ referenceDirection, XYZ putPoint, XYZ startPoint, XYZ endPoint, double foot, Element host)
        {
            Line linePart1 = Line.CreateBound(putPoint, startPoint);
            Line linePart2 = Line.CreateBound(putPoint, endPoint);
            double length1 = linePart1.Length;
            double length2 = linePart2.Length;

            double Raw1Part1 = linePart1.GetEndParameter(0);

            double Raw1Part2 = linePart2.GetEndParameter(0);
            //int i1 = (int)(length1 / foot);
            //int i2 = (int)(length2 / foot);
            double increase1 = foot;
            double increase2 = foot;

            int j = 0;

            double startPointDe = linePart1.GetEndParameter(1);
            double endPointDe = linePart2.GetEndParameter(1);
            XYZ startPoint100 = linePart1.Evaluate(startPointDe + ToFoot(100), false);
            XYZ endPoint100 = linePart2.Evaluate(endPointDe + ToFoot(100), false);

            CreatUpDuctFitting(doc, putPoint, referenceDirection, host);
            for (int i1 = (int)(length1 / foot); i1 > 0; i1--)
            {
                XYZ movePoint1 = linePart1.Evaluate(Raw1Part1 + increase1, false);
                if (j % 2 == 0)
                {
                    if (increase1 != length1)
                    {
                        CreatDownDuctFitting(doc, movePoint1, referenceDirection, host);
                    }
                    else if (increase1 == length1)
                    {
                        CreatDownDuctFitting(doc, startPoint100, referenceDirection, host);
                    }
                    //if (length1 % foot == 0 && increase1 == foot)
                    //{

                    //    CreatDownDuctFitting(doc, startPoint100, referenceDirection, host);
                    //    i1--;
                    //}
                }

                else if (j % 2 != 0)
                {
                    if (increase1 != length1)
                    {
                        CreatUpDuctFitting(doc, movePoint1, referenceDirection, host);
                    }
                    else if (increase1 == length1)
                    {
                        CreatUpDuctFitting(doc, startPoint100, referenceDirection, host);
                    }
                    //if (length1 % foot == 0 && increase1 == foot)
                    //{

                        //    CreatDownDuctFitting(doc, startPoint100, referenceDirection, host);
                        //    i1--;
                        //}
                }
                increase1 += foot;
                j++;
            }

            for (int i2 = (int)(length2 / foot); i2 > 0; i2--)
            {
                XYZ movePoint2 = linePart2.Evaluate(Raw1Part2 + increase2, false);
                if (j % 2 == 0)
                {
                    if (increase2 != length2)
                    {
                        CreatDownDuctFitting(doc, movePoint2, referenceDirection, host);
                    }
                    else if(increase2 == length2)
                    {
                        CreatDownDuctFitting(doc, endPoint100, referenceDirection, host);
                    }
                    //if (length2 % foot == 0 && increase2 == foot)
                    //{

                    //    CreatDownDuctFitting(doc, endPoint100, referenceDirection, host);
                    //    i2--;
                    //}
                }

                else if (j % 2 != 0)
                {
                    if (increase2 != length2)
                    {
                        CreatUpDuctFitting(doc, movePoint2, referenceDirection, host);
                    }
                    else if (increase2 == length2)
                    {
                        CreatUpDuctFitting(doc, endPoint100, referenceDirection, host);
                    }
                    //if (length2 % foot == 0 && increase2 == foot)
                    //{

                    //    CreatDownDuctFitting(doc, endPoint100, referenceDirection, host);
                    //    i2--;
                    //}
                }
                increase2 += foot;
                j++;
            }


            //XYZ movePoint1 = linePart1.Evaluate(Raw1Part1 + ToFoot(foot), false);
            //XYZ movePoint2 = linePart2.Evaluate(Raw1Part2 + ToFoot(foot), false);

        }
        private void SetMidUpFitting2(Document doc, XYZ referenceDirection, XYZ putPoint, XYZ startPoint, XYZ endPoint, double foot, Element host)
        {
            Line linePart1 = Line.CreateBound(putPoint, startPoint);
            Line linePart2 = Line.CreateBound(putPoint, endPoint);
            double length1 = linePart1.Length;
            double length2 = linePart2.Length;

            double Raw1Part1 = linePart1.GetEndParameter(0);

            double Raw1Part2 = linePart2.GetEndParameter(0);
            //int i1 = (int)(length1 / foot);
            //int i2 = (int)(length2 / foot);
            double increase1 = foot;
            double increase2 = foot;

            int j = 0;

            double startPointDe = linePart1.GetEndParameter(1);
            double endPointDe = linePart2.GetEndParameter(1);
            XYZ startPoint100 = linePart1.Evaluate(startPointDe + ToFoot(100), false);
            XYZ endPoint100 = linePart2.Evaluate(endPointDe + ToFoot(100), false);

            CreatUpDuctFitting(doc, putPoint, referenceDirection, host);
            for (int i1 = (int)(length1 / foot); i1 > 0; i1--)
            {
                XYZ movePoint1 = linePart1.Evaluate(Raw1Part1 + increase1, false);
                if (j % 2 == 0)
                {
                    if(increase1!=length1)
                    {
                        CreatDownDuctFitting(doc, movePoint1, referenceDirection, host);
                    }
                    else if(increase1 == length1)
                    {
                        CreatDownDuctFitting(doc, startPoint100, referenceDirection, host);
                    }

                    //    if (length1 % foot == 0 && increase1 == foot)
                    //    {

                    //        CreatDownDuctFitting(doc, startPoint100, referenceDirection, host);
                    //        i1--;
                    //    }
                }

                else if (j % 2 != 0)
                {
                    if (increase1 != length1)
                    {
                        CreatUpDuctFitting(doc, movePoint1, referenceDirection, host);
                    }
                    else if (increase1 == length1)
                    {
                        CreatUpDuctFitting(doc, startPoint100, referenceDirection, host);
                    }
                    //if (length1 % foot == 0 && increase1 == foot)
                    //{

                        //    CreatDownDuctFitting(doc, startPoint100, referenceDirection, host);
                        //    i1--;
                        //}
                }
                increase1 += foot;
                j++;
            }

            for (int i2 = (int)(length2 / foot); i2 > 0; i2--)
            {
                XYZ movePoint2 = linePart2.Evaluate(Raw1Part2 + increase2, false);
                if (j % 2 == 0)
                {
                    if (increase2 != length2)
                    {
                        CreatUpDuctFitting(doc, movePoint2, referenceDirection, host);
                    }
                    else if(increase2 == length2)
                    {
                        CreatUpDuctFitting(doc, endPoint100, referenceDirection, host);
                    }

                    //if (length2 % foot == 0 && increase2 == foot)
                    //{

                    //    CreatDownDuctFitting(doc, endPoint100, referenceDirection, host);
                    //    i2--;
                    //}
                }

                else if (j % 2 != 0)
                {
                    if (increase2 != length2)
                    {
                        CreatDownDuctFitting(doc, movePoint2, referenceDirection, host);
                    }
                    else if(increase2 == length2)
                    {
                        CreatDownDuctFitting(doc, endPoint100, referenceDirection, host);
                    }
                    //if (length2 % foot == 0 && increase2 == foot)
                    //{

                    //    CreatDownDuctFitting(doc, endPoint100, referenceDirection, host);
                    //    i2--;
                    //}
                }
                increase2 += foot;
                j++;
            }


            //XYZ movePoint1 = linePart1.Evaluate(Raw1Part1 + ToFoot(foot), false);
            //XYZ movePoint2 = linePart2.Evaluate(Raw1Part2 + ToFoot(foot), false);

        }
    }



}
