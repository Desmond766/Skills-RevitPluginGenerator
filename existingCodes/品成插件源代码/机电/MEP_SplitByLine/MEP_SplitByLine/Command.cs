using System;
using System.Collections.Generic;
using System.Text;
using Autodesk.Revit;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.DB.Electrical;
using System.Windows.Forms;

namespace MEP_SplitByLine
{
    #region 枚举
    public enum SplitTypeList
    {
        Plane,
        Vertical
    }
    #endregion

    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        #region 字段属性
        private static SplitTypeList _splitType;
        public static SplitTypeList SplitType
        {
            get { return Command._splitType; }
            set { Command._splitType = value; }
        }

        UIApplication uiapp;
        Document doc;
        Selection sel;
        Curve splitCurve;
        #endregion

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
          
            //注册验证
            string licFile = string.Format("{0}\\Key.lic",
    System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
            if (!BTAddInHelper.Utils.CheckReg(licFile))
            {
                return Result.Cancelled;
            }

            uiapp = commandData.Application;
            doc = uiapp.ActiveUIDocument.Document;
            sel = uiapp.ActiveUIDocument.Selection;

            // 过滤选择集
            List<ModelCurve> modelCurveList = new List<ModelCurve>();
            List<MEPCurve> mepCurveList = new List<MEPCurve>();
            Element e;
            foreach (ElementId id in sel.GetElementIds())
            {
                e = doc.GetElement(id);
                if (e is ModelCurve)
                {
                    modelCurveList.Add(e as ModelCurve);
                }
                if (e is MEPCurve)
                {
                    mepCurveList.Add(e as MEPCurve);
                }
            }
            if (modelCurveList.Count != 1)
            {
                message = "仅支持【一条】模型线切割！";
                return Result.Failed;
            }
            splitCurve = (modelCurveList[0].Location as LocationCurve).Curve;
            if (!IsOnXYPlane(splitCurve))
            {
                message = "切割模型线必须在【XY平面上】！";
                return Result.Failed;
            }

            // 弹出对话框
            using (SettingForm sf = new SettingForm())
            {
                if (DialogResult.OK != sf.ShowDialog())
                {
                    return Result.Failed;
                }
            }

            // 立面切割模型判断
            if (IsVertical(splitCurve))
            {
                XYZ dir = (splitCurve as Line).Direction;
                if (!dir.IsAlmostEqualTo(XYZ.BasisX) && !dir.IsAlmostEqualTo(XYZ.BasisX.Negate()) && !dir.IsAlmostEqualTo(XYZ.BasisY) && !dir.IsAlmostEqualTo(XYZ.BasisY.Negate()))
                {
                    message = "立面切割模型线必须沿【X轴】或【Y轴】！";
                    return Result.Failed;
                }
            }

            // 切割
            using (Transaction t = new Transaction(doc, "BimtransMEPTools.SplitByLine"))
            {
                t.Start();
                foreach (MEPCurve elem in mepCurveList)
                {
                    SplitByLine(elem);
                }
                t.Commit();
            }
            return Result.Succeeded;
        }

        #region SplitByLine
        /// <summary>
        /// SplitByLine
        /// </summary>
        /// <param name="elem"></param>
        private void SplitByLine(MEPCurve elem)
        {
            Curve curve = (elem.Location as LocationCurve).Curve;
            XYZ splitPoint = FindIntersection(curve);
            if (null != splitPoint)
            {
                Split(doc, elem, splitPoint);
            }
        }
        #endregion

        #region 计算交点
        /// <summary>
        /// 计算交点
        /// </summary>
        /// <param name="curve"></param>
        /// <returns></returns>
        private XYZ FindIntersection(Curve curve)
        {
            Curve curve1 = curve;
            Curve curve2;
            // 平面打断，过滤出水平管计算交点
            if (SplitType == SplitTypeList.Plane && IsOnXYPlane(curve))
            {
                curve2 = splitCurve.CreateTransformed(Transform.CreateTranslation(new XYZ(0, 0, curve1.GetEndPoint(0).Z - splitCurve.GetEndPoint(0).Z)));
            }
            // 立面打断，过滤出立管计算交点
            else if (SplitType == SplitTypeList.Vertical && IsVertical(curve))
            {
                XYZ dir = (splitCurve as Line).Direction;
                if (dir.IsAlmostEqualTo(XYZ.BasisX) || dir.IsAlmostEqualTo(XYZ.BasisX.Negate()))
                {
                    curve2 = splitCurve.CreateTransformed(Transform.CreateTranslation(new XYZ(0, curve1.GetEndPoint(0).Y - splitCurve.GetEndPoint(0).Y, 0)));
                }
                else if (dir.IsAlmostEqualTo(XYZ.BasisY) || dir.IsAlmostEqualTo(XYZ.BasisY.Negate()))
                {
                    curve2 = splitCurve.CreateTransformed(Transform.CreateTranslation(new XYZ(curve1.GetEndPoint(0).X - splitCurve.GetEndPoint(0).X, 0, 0)));
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
            // 计算交点
            IntersectionResultArray results;
            SetComparisonResult result = curve1.Intersect(curve2, out results);
            XYZ intersection = null;
            //有交点，并且交点数是1个
            if (SetComparisonResult.Overlap == result && results.Size == 1)
            {
                intersection = results.get_Item(0).XYZPoint;
            }
            return intersection;
        }
        #endregion

        #region 是否在XY平面上
        /// <summary>
        /// 是否在XY平面上
        /// </summary>
        /// <param name="curve"></param>
        /// <returns></returns>
        private bool IsOnXYPlane(Curve curve)
        {
            if (Math.Abs(curve.GetEndPoint(0).Z - curve.GetEndPoint(1).Z) < 0.001)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 是否是垂直
        /// <summary>
        /// 是否是垂直
        /// </summary>
        /// <param name="curve"></param>
        /// <returns></returns>
        private bool IsVertical(Curve curve)
        {
            if (Math.Abs(curve.GetEndPoint(0).X - curve.GetEndPoint(1).X) < 0.001 && Math.Abs(curve.GetEndPoint(0).Y - curve.GetEndPoint(1).Y) < 0.001)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 智能打断
        /// <summary>
        /// 智能打断
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="elem"></param>
        /// <param name="splitPoint"></param>
        public static void Split(Document doc, MEPCurve elem, XYZ splitPoint)
        {
            Line center = (elem.Location as LocationCurve).Curve as Line;
            // 计算关键点
            XYZ startPoint = center.GetEndPoint(0);
            XYZ endPoint = center.GetEndPoint(1);

            // 起点、终点连接件
            Connector startConn = Utils.FindConnectedTo(elem, startPoint);
            Connector endConn = Utils.FindConnectedTo(elem, endPoint);

            if (elem is Pipe)
            {
                Pipe originalPipe = elem as Pipe;
                // 绘制第一段
                Pipe startPipe = null;
                if (null != startConn)
                {
                    startPipe = Pipe.Create(doc, originalPipe.PipeType.Id, originalPipe.ReferenceLevel.Id, startConn, splitPoint);
                }
                else
                {
                    startPipe = Pipe.Create(doc, originalPipe.MEPSystem.GetTypeId(), originalPipe.PipeType.Id, originalPipe.ReferenceLevel.Id, startPoint, splitPoint);
                }
                Utils.CopyParameters(originalPipe, startPipe);
                // 绘制第二段
                Pipe endPipe = null;
                if (null != endConn)
                {
                    endPipe = Pipe.Create(doc, originalPipe.PipeType.Id, originalPipe.ReferenceLevel.Id, endConn, splitPoint);
                }
                else
                {
                    endPipe = Pipe.Create(doc, originalPipe.MEPSystem.GetTypeId(), originalPipe.PipeType.Id, originalPipe.ReferenceLevel.Id, endPoint, splitPoint);
                }
                Utils.CopyParameters(originalPipe, endPipe);
                // 删除原管
                doc.Delete(originalPipe.Id);
            }
            if (elem is Duct)
            {
                Duct originalDuct = elem as Duct;
                // 绘制第一段
                Duct startDuct = Duct.Create(doc, originalDuct.MEPSystem.GetTypeId(), originalDuct.DuctType.Id, originalDuct.ReferenceLevel.Id, startPoint, splitPoint);
                Utils.CopyParameters(originalDuct, startDuct);
                if (null != startConn)
                {
                    startConn.ConnectTo(Utils.FindConnector(startDuct, startPoint));
                }
                // 绘制第二段
                Duct endDuct = Duct.Create(doc, originalDuct.MEPSystem.GetTypeId(), originalDuct.DuctType.Id, originalDuct.ReferenceLevel.Id, endPoint, splitPoint);
                Utils.CopyParameters(originalDuct, endDuct);
                if (null != endConn)
                {
                    endConn.ConnectTo(Utils.FindConnector(endDuct, endPoint));
                }
                // 删除原管
                doc.Delete(originalDuct.Id);
            }
            if (elem is CableTray)
            {
                CableTray originalCableTray = elem as CableTray;
                // 绘制第一段
                CableTray startCableTray = CableTray.Create(doc, originalCableTray.GetTypeId(), startPoint, splitPoint, originalCableTray.ReferenceLevel.Id);
                Utils.CopyParameters(originalCableTray, startCableTray);
                if (null != startConn)
                {
                    startConn.ConnectTo(Utils.FindConnector(startCableTray, startPoint));
                }
                // 绘制第二段
                CableTray endCableTray = CableTray.Create(doc, originalCableTray.GetTypeId(), endPoint, splitPoint, originalCableTray.ReferenceLevel.Id);
                Utils.CopyParameters(originalCableTray, endCableTray);
                if (null != endConn)
                {
                    endConn.ConnectTo(Utils.FindConnector(endCableTray, endPoint));
                }
                // 删除原管
                doc.Delete(originalCableTray.Id);
            }
            if (elem is Conduit)
            {
                Conduit originalConduit = elem as Conduit;
                // 绘制第一段
                Conduit startConduit = Conduit.Create(doc, originalConduit.GetTypeId(), startPoint, splitPoint, originalConduit.ReferenceLevel.Id);
                Utils.CopyParameters(originalConduit, startConduit);
                if (null != startConn)
                {
                    startConn.ConnectTo(Utils.FindConnector(startConduit, startPoint));
                }
                // 绘制第二段
                Conduit endConduit = Conduit.Create(doc, originalConduit.GetTypeId(), endPoint, splitPoint, originalConduit.ReferenceLevel.Id);
                Utils.CopyParameters(originalConduit, endConduit);
                if (null != endConn)
                {
                    endConn.ConnectTo(Utils.FindConnector(endConduit, endPoint));
                }
                // 删除原管
                doc.Delete(originalConduit.Id);
            }
        }
        #endregion
    }
}
