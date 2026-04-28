using System;
using System.Collections.Generic;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB.Structure;

namespace PlaceByCurve
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        //布置间距
        public static double spacing { get; set; }
        //起点偏移
        public static double offset { get; set; }

        const double smallLength = 2.0 / 304.8;

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //注册验证
            string licFile = string.Format("{0}\\Key.lic",
    System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
            if (!BTAddInHelper.Utils.CheckReg(licFile))
            {
                return Result.Cancelled;
            }

            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;

            //弹出对话框，获取用户输入
            using (SettingForm sf = new SettingForm())
            {
                if (sf.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                {
                    return Result.Cancelled;
                }
            }
            if (spacing < smallLength)
            {
                message = "间距过短";
                return Result.Cancelled;
            }

            //选择线条
            Reference reference = null;
            Curve curve = null;
            try
            {
                reference = sel.PickObject(ObjectType.Element, new ModelCurveSelectionFilter(), "请选择一条模型线");
                ModelCurve modelCurve = doc.GetElement(reference) as ModelCurve;
                curve = (modelCurve.Location as LocationCurve).Curve;
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("取消选择，程序结束！");
                return Result.Cancelled;
            }
            if (curve.Length < smallLength)
            {
                message = "线条过短";
                return Result.Cancelled;
            }

            //确认初始点
            XYZ hitPoint = reference.GlobalPoint;
            XYZ startPoint = curve.GetEndPoint(0);
            XYZ endPoint = curve.GetEndPoint(1);
            bool reverse = false;
            if (hitPoint.DistanceTo(curve.GetEndPoint(1)) < hitPoint.DistanceTo(curve.GetEndPoint(0)))//存在出错的几率
            {
                startPoint = curve.GetEndPoint(1);
                endPoint = curve.GetEndPoint(0);
                reverse = true;
            }

            //获得点集合
            var points = GetPoints(curve, offset, spacing, reverse);
            if (points.Count == 0)
            {
                message = "没有找到符合的点";
                return Result.Cancelled;
            }

            //选择实例
            FamilyInstance instance = null;
            try
            {
                Reference reference2 = sel.PickObject(ObjectType.Element, new FamilyInstanceSelectionFilter(), "请选择一个实例");
                instance = doc.GetElement(reference2) as FamilyInstance;
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("取消选择，程序结束！");
                return Result.Cancelled;
            }

            //布置并旋转
            using (Transaction t = new Transaction(doc, "按路径线布置"))
            {
                t.Start();
                for (int i = 0; i < points.Count; i++)
                {
                    //布置实例
                    var newInstance = doc.Create.NewFamilyInstance(points[i], instance.Symbol, StructuralType.NonStructural);
                    //直线
                    if (curve is Line)
                    {
                        var dir = endPoint - startPoint;
                        if (dir.Normalize().IsAlmostEqualTo(XYZ.BasisX)|| dir.Normalize().IsAlmostEqualTo(XYZ.BasisX.Negate()))
                        {
                            continue;
                        }
                        var angle = dir.AngleTo(XYZ.BasisX);
                        //试旋转
                        var rotateTest = Transform.CreateRotation(dir.CrossProduct(XYZ.BasisX), angle).OfVector(XYZ.BasisX);
                        if (rotateTest.AngleTo(dir) > 0.0001)
                        {
                            angle = -angle;
                        }
                        ElementTransformUtils.RotateElement(doc, newInstance.Id, Line.CreateBound(points[i], points[i] + dir.CrossProduct(XYZ.BasisX)), angle);
                    }
                    //弧线
                    else if (curve is Arc)
                    {
                        var origin = (curve as Arc).Center;
                        var dir = points[i] - origin;
                        var angle = dir.AngleTo(XYZ.BasisX);
                        //试旋转
                        var rotateTest = Transform.CreateRotation(XYZ.BasisZ, angle).OfVector(XYZ.BasisX);
                        if (rotateTest.AngleTo(dir) > 0.0001)
                        {
                            angle = -angle;
                        }
                        ElementTransformUtils.RotateElement(doc, newInstance.Id, Line.CreateBound(points[i], points[i] + XYZ.BasisZ), angle);//奇怪？这里直接用XYZ.BasisZ为旋转轴反而更好
                    }
                    //其他曲线
                    else
                    {
                        var dir = i == points.Count - 1 ? points[i] - endPoint : points[i] - points[i + 1];
                        //修正dir
                        if (dir.IsAlmostEqualTo(XYZ.Zero))//仅会发生于最后一个点与endPoint一样的情况下
                        {
                            if (points.Count > 1)
                            {
                                dir = points[i - 1] - endPoint;
                            }
                            else//更小概率发生
                            {
                                dir = startPoint - endPoint;
                            }
                        }
                        var angle = dir.AngleTo(XYZ.BasisX);
                        //试旋转
                        var rotateTest = Transform.CreateRotation(dir.CrossProduct(XYZ.BasisX), angle).OfVector(XYZ.BasisX);
                        if (rotateTest.AngleTo(dir) > 0.0001)
                        {
                            angle = -angle;
                        }
                        ElementTransformUtils.RotateElement(doc, newInstance.Id, Line.CreateBound(points[i], points[i] + dir.CrossProduct(XYZ.BasisX)), angle);
                    }
                }
                t.Commit();
            }

            return Result.Succeeded;
        }

        #region 根据起点偏移、步距在曲线上找点
        /// <summary>
        /// 根据起点偏移、步距在曲线上找点
        /// </summary>
        /// <param name="curve"></param>
        /// <param name="offset"></param>
        /// <param name="spacing"></param>
        /// <param name="reverse"></param>
        /// <returns></returns>
        private List<XYZ> GetPoints(Curve curve, double offset, double spacing, bool reverse)
        {
            var points = new List<XYZ>();

            double length = curve.Length;
            if (offset > length)
            {
                return points;
            }

            //不反转，以起点为初始点
            if (!reverse)
            {
                //第一点
                var point = curve.Evaluate(offset / length, true);
                points.Add(point);
                //其他点
                var pointsNumber = (length - offset) % spacing == 0 ? (((length - offset) / spacing) - 1) : Math.Floor(((length - offset) / spacing));
                for (var i = 1; i <= pointsNumber; i++)
                {
                    point = curve.Evaluate((offset + spacing * i) / length, true);
                    points.Add(point);
                }
            }
            else//反转
            {
                //第一点
                var point = curve.Evaluate(1.0 - offset / length, true);
                points.Add(point);
                //其他点
                var pointsNumber = (length - offset) % spacing == 0 ? (((length - offset) / spacing) - 1) : Math.Floor(((length - offset) / spacing));
                for (var i = 1; i <= pointsNumber; i++)
                {
                    point = curve.Evaluate(1.0 - (offset + spacing * i) / length, true);
                    points.Add(point);
                }
            }

            return points;
        }
        #endregion

    }

    public class ModelCurveSelectionFilter : ISelectionFilter
    {
        public bool AllowElement(Element elem)
        {
            if (elem is ModelCurve)
            {
                return true;
            }
            return false;
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            return false;
        }
    }

    public class FamilyInstanceSelectionFilter : ISelectionFilter
    {
        public bool AllowElement(Element elem)
        {
            if (elem is FamilyInstance)
            {
                return true;
            }
            return false;
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            return false;
        }
    }
}
