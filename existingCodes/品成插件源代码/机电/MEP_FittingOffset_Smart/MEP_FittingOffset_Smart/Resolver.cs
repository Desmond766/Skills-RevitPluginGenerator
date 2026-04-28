using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.DB.Mechanical;

namespace MEP_FittingOffset_Smart
{
    class Resolver
    {
        //字段属性

        private UIApplication m_uiapp;
        private Document m_doc;
        // 关键点
        XYZ startPoint;
        XYZ endPoint;
        XYZ fittingPoint1;
        XYZ fittingPoint2;
        XYZ middlePoint1;
        XYZ middlePoint2;
        XYZ pickPoint1;
        XYZ pickPoint2;
        XYZ pickPoint3;
        XYZ offsetPoint1;
        XYZ offsetPoint2;
        XYZ offsetPoint3;
        XYZ offset1;
        XYZ angleOffset1;
        XYZ angleOffset2;
        XYZ angleOffset3;

        //构造函数
        public Resolver(ExternalCommandData commandData)
        {
            m_uiapp = commandData.Application;
            m_doc = m_uiapp.ActiveUIDocument.Document;
        }

        //方法
        public void Resolve(Element ele,double _distance)
        {
            //Element ele = m_doc.GetElement(r1);
            //找到三个原管线
            //收集构件0，1，2（三根横直管）
            List<Element> horLineGList = Utils.FindConnectedToList(ele);
            if (horLineGList.Count != 3)//管道假接的情况跳过
            {
                TaskDialog.Show("提示", "检查管道是否连接。");
                return;
            }

            Element horLineG0 = horLineGList[0];
            Element horLineG1 = horLineGList[1];
            Element horLineG2 = horLineGList[2];

            MEPCurve mepCurve1 = horLineG0 as MEPCurve;
            MEPCurve mepCurve2 = horLineG1 as MEPCurve;
            MEPCurve mepCurve3 = horLineG2 as MEPCurve;

            // 原管线中心线
            Line mepLine1 = (mepCurve1.Location as LocationCurve).Curve as Line;
            Line mepLine2 = (mepCurve2.Location as LocationCurve).Curve as Line;
            Line mepLine3 = (mepCurve3.Location as LocationCurve).Curve as Line;

            // 拾取点
            //管线距三通较近\较远的点
            XYZ mep1ClosePt = Utils.GetClosedPt(mepCurve1, ele);
            XYZ mep1FarPt = Utils.GetFarPt(mepCurve1, ele);
            XYZ mep2ClosePt = Utils.GetClosedPt(mepCurve2, ele);
            XYZ mep2FarPt = Utils.GetFarPt(mepCurve2, ele);
            XYZ mep3ClosePt = Utils.GetClosedPt(mepCurve3, ele);
            XYZ mep3FarPt = Utils.GetFarPt(mepCurve3, ele);
            
            ////////
            pickPoint1 = mep1ClosePt + (mep1FarPt - mep1ClosePt).Normalize() * 1500 / 304.8;
            pickPoint2 = mep2ClosePt + (mep2FarPt - mep2ClosePt).Normalize() * 1500 / 304.8;
            pickPoint3 = mep3ClosePt + (mep3FarPt - mep3ClosePt).Normalize() * 1500 / 304.8;

            // 判断起点、终点
            List<XYZ> endPointList = Utils.GetEndPoint(mepLine1, mepLine2);
            startPoint = endPointList[0];
            fittingPoint1 = endPointList[1];
            fittingPoint2 = endPointList[2];
            endPoint = endPointList[3];

            middlePoint1 = mepLine3.GetEndPoint(0);
            middlePoint2 = mepLine3.GetEndPoint(1);
            double distance1 = middlePoint1.DistanceTo(fittingPoint2);
            double distance2 = middlePoint2.DistanceTo(fittingPoint2);
            if (distance1 < distance2)
            {
                middlePoint1 = mepLine3.GetEndPoint(0);
                middlePoint2 = mepLine3.GetEndPoint(1);
            }
            else
            {
                middlePoint1 = mepLine3.GetEndPoint(1);
                middlePoint2 = mepLine3.GetEndPoint(0);
            }

            // 点击的前进方向
            XYZ forward1 = pickPoint1 - startPoint;
            XYZ forward2 = endPoint - pickPoint2;
            XYZ forward3 = middlePoint2 - middlePoint1;

            ////////
            
            double _angle = 30;

            // 偏移量
            offset1 = XYZ.BasisZ * _distance / 304.8;

            // 角度产生的偏移
            if (_angle == 90.0)
            {
                angleOffset1 = angleOffset2 = angleOffset3 = XYZ.Zero;
            }
            else
            {
                angleOffset1 = forward1.Normalize() * (Math.Abs(_distance / 304.8) / Math.Tan(Math.PI * _angle / 180.0));
                angleOffset2 = forward2.Normalize() * (Math.Abs(_distance / 304.8) / Math.Tan(Math.PI * _angle / 180.0));
                angleOffset3 = forward3.Normalize() * (Math.Abs(_distance / 304.8) / Math.Tan(Math.PI * _angle / 180.0));
            }
            // 偏移后的点
            offsetPoint1 = pickPoint1 + offset1 + angleOffset1;
            offsetPoint2 = pickPoint2 + offset1 - angleOffset2;
            offsetPoint3 = pickPoint3 + offset1 - angleOffset3;


            // 原始属性
            Parameter parameter = mepCurve1.get_Parameter(BuiltInParameter.RBS_START_LEVEL_PARAM);
            ElementId levelId = parameter.AsElementId();

            // ____________________________________________________________________________________________________________________________________________________
            //Utils.DrawModelCurve(m_doc, pickPoint1, offsetPoint1);
            //Utils.DrawModelCurve(m_doc, offsetPoint2, pickPoint2);
            //Utils.DrawModelCurve(m_doc, offsetPoint3, pickPoint3);
            //TaskDialog.Show("a", pickPoint1.ToString());
            
            CableTray cableTray1 = mepCurve1 as CableTray;
            CableTray cableTray2 = mepCurve2 as CableTray;
            CableTray cableTray3 = mepCurve3 as CableTray;

            // 【1】创建三侧桥架
            CableTray side1 = CableTray.Create(m_doc, cableTray1.GetTypeId(), pickPoint1, offsetPoint1, levelId);
            RotateFix(side1, cableTray1);
            CableTray side2 = CableTray.Create(m_doc, cableTray2.GetTypeId(), offsetPoint2, pickPoint2, levelId);
            RotateFix(side2, cableTray2);
            CableTray side3 = CableTray.Create(m_doc, cableTray3.GetTypeId(), offsetPoint3, pickPoint3, levelId);
            RotateFix(side3, cableTray3);
            // 复制参数
            Utils.CopyParameters(cableTray1, side1);
            Utils.CopyParameters(cableTray2, side2);
            Utils.CopyParameters(cableTray3, side3);

            // 起点、终点连接件
            Connector startConn = Utils.FindConnectedTo(cableTray1, startPoint);
            Connector endConn = Utils.FindConnectedTo(cableTray2, endPoint);
            Connector midConn = Utils.FindConnectedTo(cableTray3, middlePoint2);
            // 配件两端连接件
            Connector fittingConn1 = Utils.FindConnectedTo(cableTray1, fittingPoint1);
            Connector fittingConn2 = Utils.FindConnectedTo(cableTray2, fittingPoint2);
            Connector fittingConn3 = Utils.FindConnectedTo(cableTray3, middlePoint1);

            // 【2】创建起点处桥架
            CableTray startCT = CableTray.Create(m_doc, cableTray1.GetTypeId(), startPoint, pickPoint1, levelId);
            if (null != startConn)
            {
                startConn.ConnectTo(Utils.FindConnector(startCT, startPoint));
            }
            // 复制参数
            Utils.CopyParameters(cableTray1, startCT);
            // 创建弯头
            Connector connStart1 = Utils.FindConnector(startCT, pickPoint1);
            Connector connStart2 = Utils.FindConnector(side1, pickPoint1);
            FamilyInstance f1 = m_doc.Create.NewElbowFitting(connStart1, connStart2);

            // 【3】创建终点处桥架
            CableTray endCT = CableTray.Create(m_doc, cableTray2.GetTypeId(), endPoint, pickPoint2, levelId);
            if (null != endConn)
            {
                endConn.ConnectTo(Utils.FindConnector(endCT, endPoint));
            }
            // 复制参数
            Utils.CopyParameters(cableTray2, endCT);
            // 创建弯头
            Connector connEnd1 = Utils.FindConnector(endCT, pickPoint2);
            Connector connEnd2 = Utils.FindConnector(side2, pickPoint2);
            FamilyInstance f2 = m_doc.Create.NewElbowFitting(connEnd1, connEnd2);

            // 【3+】创建终点处2管道
            CableTray midCT = CableTray.Create(m_doc, cableTray3.GetTypeId(), middlePoint2, pickPoint3, levelId);
            if (null != midConn)
            {
                midConn.ConnectTo(Utils.FindConnector(midCT, middlePoint2));
            }
            // 复制参数
            Utils.CopyParameters(cableTray3, midCT);
            // 创建弯头
            Connector connMiddle1 = Utils.FindConnector(midCT, pickPoint3);
            Connector connMiddle2 = Utils.FindConnector(side3, pickPoint3);
            FamilyInstance f3 = m_doc.Create.NewElbowFitting(connMiddle1, connMiddle2);

            // 【4】偏移
            ElementTransformUtils.MoveElement(m_doc, cableTray1.Id, offset1);

            //【5】创建配件两边的管道
            if (fittingConn1.Origin.IsAlmostEqualTo(fittingPoint1) || fittingConn2.Origin.IsAlmostEqualTo(fittingPoint2) || fittingConn3.Origin.IsAlmostEqualTo(middlePoint1))
            {
                // 说明没有被移动上来
                TaskDialog.Show("警告", "不支持该操作");
                m_doc.Delete(side1.Id);
                m_doc.Delete(side2.Id);
                m_doc.Delete(side3.Id);
                m_doc.Delete(startCT.Id);
                m_doc.Delete(endCT.Id);
                m_doc.Delete(midCT.Id);
                m_doc.Delete(f1.Id);
                m_doc.Delete(f2.Id);
                m_doc.Delete(f3.Id);

                ElementTransformUtils.MoveElement(m_doc, cableTray1.Id, -1 * offset1);

                return;
            }
            CableTray fittingSide1 = CableTray.Create(m_doc, cableTray1.GetTypeId(), fittingConn1.Origin, offsetPoint1, levelId);
            fittingConn1.ConnectTo(Utils.FindConnector(fittingSide1, fittingConn1.Origin));
            CableTray fittingSide2 = CableTray.Create(m_doc, cableTray2.GetTypeId(), fittingConn2.Origin, offsetPoint2, levelId);
            fittingConn2.ConnectTo(Utils.FindConnector(fittingSide2, fittingConn2.Origin));
            CableTray fittingSide3 = CableTray.Create(m_doc, cableTray3.GetTypeId(), fittingConn3.Origin, offsetPoint3, levelId);
            fittingConn3.ConnectTo(Utils.FindConnector(fittingSide3, fittingConn3.Origin));

            // 复制参数
            Utils.CopyParameters(cableTray1, fittingSide1);
            Utils.CopyParameters(cableTray2, fittingSide2);
            Utils.CopyParameters(cableTray3, fittingSide3);
            // 创建弯头
            Connector conn1 = Utils.FindConnector(side1, offsetPoint1);
            Connector conn2 = Utils.FindConnector(fittingSide1, offsetPoint1);
            m_doc.Create.NewElbowFitting(conn1, conn2);
            Connector conn3 = Utils.FindConnector(side2, offsetPoint2);
            Connector conn4 = Utils.FindConnector(fittingSide2, offsetPoint2);
            m_doc.Create.NewElbowFitting(conn3, conn4);
            Connector conn5 = Utils.FindConnector(side3, offsetPoint3);
            Connector conn6 = Utils.FindConnector(fittingSide3, offsetPoint3);
            m_doc.Create.NewElbowFitting(conn5, conn6);
            // 【6】删除原管道
            m_doc.Delete(cableTray1.Id);
            m_doc.Delete(cableTray2.Id);
            m_doc.Delete(cableTray3.Id);


        }

        #region 修正风管、桥架旋转角度
        /// <summary>
        /// 修正（矩形）风管、桥架旋转角度
        /// </summary>
        /// <param name="targetToRotate"></param>
        /// <param name="alignCurve"></param>
        private void RotateFix(MEPCurve targetToRotate, MEPCurve alignCurve)
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
                    ElementTransformUtils.RotateElement(m_doc, targetToRotate.Id, tLine, aLine.Direction.AngleTo(XYZ.BasisY));
                }
                else
                {
                    ElementTransformUtils.RotateElement(m_doc, targetToRotate.Id, tLine, aLine.Direction.AngleTo(XYZ.BasisY) * -1.0);
                }
            }
        }
        #endregion

    }
}
