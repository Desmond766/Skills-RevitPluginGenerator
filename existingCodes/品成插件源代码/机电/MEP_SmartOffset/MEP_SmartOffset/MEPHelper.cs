using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.DB.Plumbing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEP_SmartOffset
{
    class MEPHelper
    {
        #region 创建管线
        public static MEPCurve CreateMEPCurve(Document doc, MEPCurve mepCurve, XYZ startPoint, XYZ endPoint)
        {
            MEPCurve newCurve = null;

            //标高
            Parameter parameter = mepCurve.get_Parameter(BuiltInParameter.RBS_START_LEVEL_PARAM);
            ElementId levelId = parameter.AsElementId();

            if (mepCurve is Pipe)
            {
                Pipe pipe = mepCurve as Pipe;
                ElementId systemTypeId = pipe.MEPSystem.GetTypeId();
                PipeType pipeType = pipe.PipeType;
                //创建管道
                newCurve = Pipe.Create(doc, systemTypeId, pipeType.Id, levelId, startPoint, endPoint);
                //复制参数
                Utils.CopyParameters(pipe, newCurve as Pipe);
            }
            else if (mepCurve is Duct)
            {
                Duct duct = mepCurve as Duct;
                ElementId systemTypeId = duct.MEPSystem.GetTypeId();
                DuctType ductType = duct.DuctType;
                //创建风管
                newCurve = Duct.Create(doc, systemTypeId, ductType.Id, levelId, startPoint, endPoint);
                //复制参数
                Utils.CopyParameters(duct, newCurve as Duct);
                RotateFix(doc, newCurve, duct);
            }
            else if (mepCurve is CableTray)
            {
                CableTray cableTray = mepCurve as CableTray;
                ElementId cabletrayType = cableTray.GetTypeId();
                //创建桥架
                newCurve = CableTray.Create(doc, cabletrayType, startPoint, endPoint, levelId);
                //复制参数
                Utils.CopyParameters(cableTray, newCurve as CableTray);
                RotateFix(doc, newCurve, cableTray);
            }
            else if (mepCurve is Conduit)
            {
                Conduit conduit = mepCurve as Conduit;
                ElementId conduitType = conduit.GetTypeId();
                //创建线管
                newCurve = Conduit.Create(doc, conduitType, startPoint, endPoint, levelId);
                //复制参数
                Utils.CopyParameters(conduit, newCurve as Conduit);
            }

            return newCurve;
        }

        public static MEPCurve CreateMEPCurve(Document document, MEPCurve mepCurve, Connector startConn, XYZ endPoint)
        {
            MEPCurve newCurve = CreateMEPCurve(document, mepCurve, startConn.Origin, endPoint);
            Connector con = Utils.FindConnector(newCurve, startConn.Origin);
            startConn.ConnectTo(con);
            return newCurve;
        }

        public static MEPCurve CreateMEPCurve(Document document, MEPCurve mepCurve, XYZ startPoint, Connector endConn)
        {
            MEPCurve newCurve = CreateMEPCurve(document, mepCurve, startPoint, endConn.Origin);
            Connector con = Utils.FindConnector(newCurve, endConn.Origin);
            endConn.ConnectTo(con);
            return newCurve;
        }

        public static MEPCurve CreateMEPCurve(Document document, MEPCurve mepCurve, Connector startConn, Connector endConn)
        {
            MEPCurve newCurve = CreateMEPCurve(document, mepCurve, startConn.Origin, endConn.Origin);
            Connector con1 = Utils.FindConnector(newCurve, startConn.Origin);
            Connector con2 = Utils.FindConnector(newCurve, endConn.Origin);
            startConn.ConnectTo(con1);
            endConn.ConnectTo(con2);
            return newCurve;
        }

        #region 修正风管、桥架旋转角度
        /// <summary>
        /// 修正（矩形）风管、桥架旋转角度
        /// </summary>
        /// <param name="targetToRotate"></param>
        /// <param name="alignCurve"></param>
        private static void RotateFix(Document doc, MEPCurve targetToRotate, MEPCurve alignCurve)
        {
            //旋转
            Line tLine = (targetToRotate.Location as LocationCurve).Curve as Line;
            if (tLine.Direction.IsAlmostEqualTo(XYZ.BasisZ) || tLine.Direction.IsAlmostEqualTo(XYZ.BasisZ.Negate()))
            {
                Line aLine = (alignCurve.Location as LocationCurve).Curve as Line;
                double angleToRotate = aLine.Direction.AngleTo(XYZ.BasisY);
                // 利用XYZ.BasisY预旋转
                Transform tran = Transform.CreateRotation(tLine.Direction, angleToRotate);
                XYZ preRotate = tran.OfVector(XYZ.BasisY);
                if (preRotate.IsAlmostEqualTo(aLine.Direction) || preRotate.IsAlmostEqualTo(aLine.Direction.Negate()))
                {
                    ElementTransformUtils.RotateElement(doc, targetToRotate.Id, tLine, aLine.Direction.AngleTo(XYZ.BasisY));
                }
                else
                {
                    ElementTransformUtils.RotateElement(doc, targetToRotate.Id, tLine, aLine.Direction.AngleTo(XYZ.BasisY) * -1.0);
                }
            }
        }
        #endregion

        #endregion

        public static void CreateElbowFitting(Document doc, XYZ elbowFittingPt, MEPCurve zhiG1, MEPCurve zhiG2)
        {
            //管1距弯头位置点近的点
            XYZ zhiG1PtConn = new XYZ();
            Line zhiG1MEPLine = (zhiG1.Location as LocationCurve).Curve as Line;
            if (zhiG1MEPLine.GetEndPoint(0).DistanceTo(elbowFittingPt) < zhiG1MEPLine.GetEndPoint(1).DistanceTo(elbowFittingPt))
            {
                zhiG1PtConn = zhiG1MEPLine.GetEndPoint(0);
            }
            else
            {
                zhiG1PtConn = zhiG1MEPLine.GetEndPoint(1);
            }
            //管2距弯头位置点近的点
            XYZ zhiG2PtConn = new XYZ();
            Line zhiG2MEPLine = (zhiG2.Location as LocationCurve).Curve as Line;
            if (zhiG2MEPLine.GetEndPoint(0).DistanceTo(elbowFittingPt) < zhiG2MEPLine.GetEndPoint(1).DistanceTo(elbowFittingPt))
            {
                zhiG2PtConn = zhiG2MEPLine.GetEndPoint(0);
            }
            else
            {
                zhiG2PtConn = zhiG2MEPLine.GetEndPoint(1);
            }
            //直管上距弯头位置点近的连接件
            Connector zhiG1Conn = Utils.FindConnector(zhiG1, zhiG1PtConn);
            Connector zhiG2Conn = Utils.FindConnector(zhiG2, zhiG2PtConn);
            doc.Create.NewElbowFitting(zhiG1Conn, zhiG2Conn);


        }

    }
}
