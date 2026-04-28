//20171106
//添加新的加密方式
//20171115
//添加新的加密方式
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.Attributes;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;

namespace MoveLR
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        #region 声明字段和属性
        public static double distance = 100;
        ////声明一个私有的静态的【距离】字段
        //private static double _distance;
        ////声明一个公用的静态的【距离】属性
        //public static double Distance
        //{
        //    get { return Command._distance; }
        //    set { Command._distance = value; }
        //}
        #endregion

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            #region 判断加密
            //注册验证
            string licFile = string.Format("{0}\\Key.lic",
    System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
            if (!BTAddInHelper.Utils.CheckReg(licFile))
            {
                return Result.Cancelled;
            }

            #endregion

            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;
            try
            {
                while (true)
                {
                    //选择两个构件
                    Reference firstPick = sel.PickObject(ObjectType.Element, new MEPCurveSelectionFilter());
                    Element firstEle = doc.GetElement(firstPick);
                    Reference secondPick = sel.PickObject(ObjectType.Element, new MEPCurveSelectionFilter());
                    Element secondEle = doc.GetElement(secondPick);

                    //判断选择的构件是否有效
                    if (firstEle.Id == secondEle.Id)
                    {
                        TaskDialog.Show("警告", "选择的是同一个构件！");
                    }
                    else
                    {
                        //得到构件上的点
                        LocationCurve locationCurve1 = firstEle.Location as LocationCurve;
                        XYZ firstDir = (locationCurve1.Curve as Line).Direction;
                        XYZ firstPo = locationCurve1.Curve.GetEndPoint(0);
                        XYZ firstPo1 = locationCurve1.Curve.GetEndPoint(1);
                        LocationCurve locationCurve2 = secondEle.Location as LocationCurve;
                        XYZ secondDir = (locationCurve2.Curve as Line).Direction;
                        XYZ secondPo = locationCurve2.Curve.GetEndPoint(0);

                        XYZ newLocation = new XYZ();
                        //判断构件是否平行
                        if (!firstDir.IsAlmostEqualTo(secondDir, 1.5))
                        {
                            TaskDialog.Show("警告", "所选构件不平行");
                        }
                        else  //平行，进入程序
                        {
                            //弹出对话框，输入希望移动第二个构件后，两个构件的最后距离
                            using (Form1 form = new Form1())
                            {
                                if (form.ShowDialog() != DialogResult.OK)
                                {
                                    return Result.Failed;
                                }
                            }

                            XYZ pLine = GetProjectivePoint(firstPo, firstPo1, secondPo);
                       
                            double w1 = GetHalfWidth(firstEle);
                            double w2 = GetHalfWidth(secondEle);

                            //TaskDialog.Show("a", w1.ToString() + "\n" + w2.ToString());
                            double w = (w1 + w2) / 304.8;
                            double dAB = pLine.DistanceTo(secondPo);
                            //double dAB = PointToLine(firstPo, firstPo1, secondPo);
                            //TaskDialog.Show("a", (dAB*304.8).ToString());
                            
                            double dAC;
                            if (distance > 0)
                            {
                                dAC = dAB - w - distance / 304.8;
                            }
                            else
                            {
                                dAC = dAB + w + (Math.Abs(distance)) / 304.8;
                            }
                            newLocation = ((pLine - secondPo).Normalize() )* dAC;
                            //newLocation =new XYZ( ((pLine - secondPo).Normalize() * dAC).X,((pLine - secondPo).Normalize() * dAC).Y,0);

                            using (Transaction t = new Transaction(doc, "水平移动"))
                            {
                                t.Start();
                                //Utils.DrawModelCurve(doc, pLine, secondPo);
                                locationCurve2.Move(newLocation);
                                t.Commit();
                            }
                        }
                    }

                    firstEle = secondEle;
                    try
                    {
                        while (true)
                        {

                            Reference thirdPick = sel.PickObject(ObjectType.Element, new MEPCurveSelectionFilter());
                            Element thirdEle = doc.GetElement(thirdPick);
                            secondEle = thirdEle;
                            MoveLRLR(firstEle, secondEle, doc);
                            firstEle = thirdEle;
                        }
                    }
                    catch
                    {

                    }
                }
            }
            catch
            {

            }


            return Result.Succeeded;
        }

        private void MoveLRLR(Element firstEle, Element secondEle, Document doc)
        {
            //判断选择的构件是否有效
            if (firstEle.Id == secondEle.Id)
            {
                TaskDialog.Show("警告", "选择的是同一个构件！");
            }
            else
            {
                //得到构件上的点
                LocationCurve locationCurve1 = firstEle.Location as LocationCurve;
                XYZ firstDir = (locationCurve1.Curve as Line).Direction;
                XYZ firstPo = locationCurve1.Curve.GetEndPoint(0);
                XYZ firstPo1 = locationCurve1.Curve.GetEndPoint(1);
                LocationCurve locationCurve2 = secondEle.Location as LocationCurve;
                XYZ secondDir = (locationCurve2.Curve as Line).Direction;
                XYZ secondPo = locationCurve2.Curve.GetEndPoint(0);

                XYZ newLocation = new XYZ();
                //判断构件是否平行
                if (!firstDir.IsAlmostEqualTo(secondDir, 1.5))
                {
                    TaskDialog.Show("警告", "所选构件不平行");
                }
                else  //平行，进入程序
                {
                    XYZ pLine = GetProjectivePoint(firstPo, firstPo1, secondPo);
                    double w1 = GetHalfWidth(firstEle);
                    double w2 = GetHalfWidth(secondEle);
                    //TaskDialog.Show("a", w1.ToString() + "\n" + w2.ToString());
                    double w = (w1 + w2) / 304.8;
                    double dAB = pLine.DistanceTo(secondPo);
                    //double dAB = PointToLine(firstPo, firstPo1, secondPo);
                    double dAC;
                    if (distance > 0)
                    {
                        dAC = dAB - w - distance / 304.8;
                    }
                    else
                    {
                        dAC = dAB + w + (Math.Abs(distance)) / 304.8;
                    }
                    newLocation = (pLine - secondPo).Normalize() * dAC;
                    //newLocation =new XYZ( ((pLine - secondPo).Normalize() * dAC).X,((pLine - secondPo).Normalize() * dAC).Y,0);

                    using (Transaction t = new Transaction(doc, "水平移动"))
                    {
                        t.Start();
                        locationCurve2.Move(newLocation);
                        t.Commit();
                    }
                }
            }
        }

        #region 判断所选构件是否为机电管线
        private bool YorN(Element e1, Element e2)
        {
            if ((e1.Category.Id.IntegerValue == (int)BuiltInCategory.OST_CableTray
                || e1.Category.Id.IntegerValue == (int)BuiltInCategory.OST_DuctCurves
                || e1.Category.Id.IntegerValue == (int)BuiltInCategory.OST_PipeCurves
                || e1.Category.Id.IntegerValue == (int)BuiltInCategory.OST_Conduit)
                &&
                e2.Category.Id.IntegerValue == (int)BuiltInCategory.OST_CableTray
                || e2.Category.Id.IntegerValue == (int)BuiltInCategory.OST_DuctCurves
                || e2.Category.Id.IntegerValue == (int)BuiltInCategory.OST_PipeCurves
                || e2.Category.Id.IntegerValue == (int)BuiltInCategory.OST_Conduit)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region 传入Element和其上一点，得到两边y坐标值  没用到
        private List<double> FindEdge(Element e, XYZ point)
        {
            List<double> list = new List<double>();
            if (e.Category.Id.IntegerValue == (int)BuiltInCategory.OST_CableTray)
            {
                foreach (Parameter p in e.Parameters)
                {
                    if (p.Definition.Name == "宽度")
                    {
                        string s = p.AsValueString();
                        int idx = s.LastIndexOf(" ");
                        string value = s.Substring(0, idx);
                        double w = double.Parse(value);
                        list.Add(point.Y + (w / 2) / 304.8);
                        list.Add(point.Y - (w / 2) / 304.8);
                    }
                }
            }
            else if (e.Category.Id.IntegerValue == (int)BuiltInCategory.OST_DuctCurves)
            {
                foreach (Parameter p in e.Parameters)
                {
                    if (p.Definition.Name == "宽度")
                    {
                        double w = double.Parse(p.AsValueString());
                        list.Add(point.Y + (w / 2) / 304.8);
                        list.Add(point.Y - (w / 2) / 304.8);
                    }
                }
            }
            else if (e.Category.Id.IntegerValue == (int)BuiltInCategory.OST_PipeCurves
                || e.Category.Id.IntegerValue == (int)BuiltInCategory.OST_Conduit)
            {
                foreach (Parameter p in e.Parameters)
                {
                    if (p.Definition.Name == "外径")
                    {
                        string s = p.AsValueString();
                        int idx = s.LastIndexOf(" ");
                        string value = s.Substring(0, idx);
                        double w = double.Parse(value);
                        list.Add(point.Y + (w / 2) / 304.8);
                        list.Add(point.Y - (w / 2) / 304.8);
                    }
                }
            }
            return list;
        }

        #endregion

        #region 传入Element,得到其一半的宽度值
        private double GetHalfWidth(Element e)
        {
            double w = 0.0;
            if (e.Category.Id.IntegerValue == (int)BuiltInCategory.OST_CableTray)
            {
                Parameter p = e.get_Parameter(BuiltInParameter.RBS_CABLETRAY_WIDTH_PARAM);
                w = p.AsDouble() * 304.8 / 2;
            }
            else if (e.Category.Id.IntegerValue == (int)BuiltInCategory.OST_DuctCurves)
            {
                Parameter p = e.get_Parameter(BuiltInParameter.RBS_CURVE_WIDTH_PARAM);
                w = p.AsDouble() * 304.8 / 2;
            }
            else if (e.Category.Id.IntegerValue == (int)BuiltInCategory.OST_PipeCurves)
            {
                Parameter p = e.get_Parameter(BuiltInParameter.RBS_PIPE_OUTER_DIAMETER);
                w = p.AsDouble() * 304.8 / 2;
            }
            else if (e.Category.Id.IntegerValue == (int)BuiltInCategory.OST_Conduit)
            {
                Parameter p = e.get_Parameter(BuiltInParameter.RBS_CONDUIT_OUTER_DIAM_PARAM);
                w = p.AsDouble() * 304.8 / 2;
            }
            return w;
        }
        #endregion

        //#region 传入直线上两点和线外一点，得到线外点在直线上的投影点
        //private XYZ GetProjectivePoint(XYZ standardStartPoint, XYZ standardEndPoint, XYZ modifyStartPoint)
        //{
        //    XYZ pLine = new XYZ();
        //    double k = (standardEndPoint.Y - standardStartPoint.Y) / (standardEndPoint.X - standardStartPoint.X);
        //    if (Math.Abs(k) < 0.1) //if (k == 0)
        //    {
        //        pLine = new XYZ(modifyStartPoint.X, standardStartPoint.Y, 0);

        //    }
        //    else if (Math.Abs(standardEndPoint.X - standardStartPoint.X) < 0.1)
        //    {
        //        pLine = new XYZ(standardEndPoint.X, modifyStartPoint.Y, 0);
        //    }
        //    else
        //    {
        //        double x = (k * (standardStartPoint.X) + ((modifyStartPoint.X) / k) + modifyStartPoint.Y - standardStartPoint.Y) / (1 / k + k);
        //        double y = -1 / k * (x - modifyStartPoint.X) + modifyStartPoint.Y;
        //        pLine = new XYZ(x, y, 0);

        //    }
        //    return pLine;
        //}

        //#endregion

        public double PointToLine(XYZ standardStartPoint, XYZ standardEndPoint, XYZ modifyStartPoint)
        {
            double pointToLine;
            double length = new XYZ(standardStartPoint.X, standardStartPoint.Y, 0).DistanceTo(new XYZ(standardEndPoint.X, standardEndPoint.Y, 0));
            double startlength = new XYZ(modifyStartPoint.X, modifyStartPoint.Y, 0).DistanceTo(new XYZ(standardStartPoint.X, standardStartPoint.Y, 0));
            double endlength = new XYZ(modifyStartPoint.X, modifyStartPoint.Y, 0).DistanceTo(new XYZ(standardEndPoint.X, standardEndPoint.Y, 0));

            double p = (length + startlength + endlength) / 2;
            double area = Math.Sqrt(p * (p - endlength) * (p - startlength) * (p - length));
            pointToLine = 2 * area / length;

            return pointToLine;
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
            XYZ point1 =new XYZ(point.X,point.Y,q.Z);
            return point1;
        }
        #endregion


        ///// <summary>
        ///// 获得点在直线上的投影点坐标
        ///// </summary>
        ///// <param name="l">直线</param>
        ///// <param name="q">直线外的点</param>
        ///// <returns>投影点</returns>
        //public static XYZ GetProjectivePoint(XYZ p1, XYZ p2, XYZ q)
        //{
        //    XYZ point = new XYZ();
        //    var A = (p1.Y - p2.Y) / (p1.X - p2.X);
        //    var B = p1.Y - A * p1.X;
        //    var m = q.X + A * q.Y;
        //    if ((p1.X - p2.X == 0))
        //    {
        //        point = new XYZ(p1.X, q.Y, q.Z);
        //    }
        //    else
        //    {
        //        point = new XYZ((m - A * B) / (A * A + 1), A * (m - A * B) / (A * A + 1) + B, q.Z);
        //    }

        //    return point;
        //}


    }
}
