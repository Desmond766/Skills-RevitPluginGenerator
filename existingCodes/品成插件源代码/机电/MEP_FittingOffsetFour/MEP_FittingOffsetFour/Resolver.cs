using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.DB.Mechanical;

namespace MEP_FittingOffsetFour
{
    #region 枚举
    public enum DirectionList
    {
        LR,
        TB
    }
    public enum TypeList
    {
        OneSide,
        TwoSide
    }
    #endregion
    class Resolver
    {
        #region 字段属性
        private UIApplication m_uiapp;
        private Document m_doc;
        // 方向
        private static DirectionList _direction;
        public static DirectionList Direction
        {
            get { return Resolver._direction; }
            set { Resolver._direction = value; }
        }

        // 类型
        private static TypeList _type;
        public static TypeList Type
        {
            get { return Resolver._type; }
            set { Resolver._type = value; }
        }

        // 角度
        private static double _angle;
        public static double Angle
        {
            get { return Resolver._angle; }
            set { Resolver._angle = value; }
        }

        // 偏移距离
        private static double _distance;
        public static double Distance
        {
            get { return Resolver._distance; }
            set { Resolver._distance = value; }
        }

        // 错误信息
        private static string _message;
        public static string Message
        {
            get { return Resolver._message; }
            set { Resolver._message = value; }
        }

        // 关键点
        XYZ startPoint;
        XYZ endPoint;
        XYZ fittingPoint1;
        XYZ fittingPoint2;
        XYZ middlePoint1;
        XYZ middlePoint2;
        XYZ fourPoint1;
        XYZ fourPoint2;
        XYZ pickPoint1;
        XYZ pickPoint2;
        XYZ pickPoint3;
        XYZ pickPoint4;
        XYZ offsetPoint1;
        XYZ offsetPoint2;
        XYZ offsetPoint3;
        XYZ offsetPoint4;
        XYZ offset1;
        XYZ angleOffset1;
        XYZ angleOffset2;
        XYZ angleOffset3;
        XYZ angleOffset4;
        #endregion

        // 构造函数
        public Resolver(ExternalCommandData commandData)
        {
            m_uiapp = commandData.Application;
            m_doc = m_uiapp.ActiveUIDocument.Document;
        }

        public void Resolve(Reference r1, Reference r2, Reference r3, Reference r4)
        {
            // 原管线
            MEPCurve mepCurve1 = m_doc.GetElement(r1) as MEPCurve;
            MEPCurve mepCurve2 = m_doc.GetElement(r2) as MEPCurve;
            MEPCurve mepCurve3 = m_doc.GetElement(r3) as MEPCurve;
            MEPCurve mepCurve4 = m_doc.GetElement(r4) as MEPCurve;

            // 原管线中心线
            Line mepLine1 = (mepCurve1.Location as LocationCurve).Curve as Line;
            Line mepLine2 = (mepCurve2.Location as LocationCurve).Curve as Line;
            Line mepLine3 = (mepCurve3.Location as LocationCurve).Curve as Line;
            Line mepLine4 = (mepCurve4.Location as LocationCurve).Curve as Line;

            // 拾取点
            pickPoint1 = Utils.GetProjectivePoint(mepLine1, r1.GlobalPoint);
            pickPoint2 = Utils.GetProjectivePoint(mepLine2, r2.GlobalPoint);
            pickPoint3 = Utils.GetProjectivePoint(mepLine3, r3.GlobalPoint);
            pickPoint4 = Utils.GetProjectivePoint(mepLine4, r4.GlobalPoint);

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

            fourPoint1 = mepLine4.GetEndPoint(0);
            fourPoint2 = mepLine4.GetEndPoint(1);
            double distance3 = fourPoint1.DistanceTo(fittingPoint2);
            double distance4 = fourPoint2.DistanceTo(fittingPoint2);
            if (distance3 < distance4)
            {
                fourPoint1 = mepLine4.GetEndPoint(0);
                fourPoint2 = mepLine4.GetEndPoint(1);
            }
            else
            {
                fourPoint1 = mepLine4.GetEndPoint(1);
                fourPoint2 = mepLine4.GetEndPoint(0);
            }

            // 点击的前进方向
            XYZ forward1 = pickPoint1 - startPoint;
            XYZ forward2 = endPoint - pickPoint2;


            XYZ forward3 = middlePoint2 - middlePoint1;
            XYZ forward4 = fourPoint2 - fourPoint1;
            
            // 偏移量
            offset1 = XYZ.BasisZ * _distance / 304.8;

            // 角度产生的偏移
            if (_angle == 90.0)
            {
                angleOffset1 = angleOffset2 = angleOffset3 = angleOffset4 = XYZ.Zero;
            }
            else
            {
                angleOffset1 = forward1.Normalize() * (Math.Abs(_distance / 304.8) / Math.Tan(Math.PI * _angle / 180.0));
                angleOffset2 = forward2.Normalize() * (Math.Abs(_distance / 304.8) / Math.Tan(Math.PI * _angle / 180.0));
                angleOffset3 = forward3.Normalize() * (Math.Abs(_distance / 304.8) / Math.Tan(Math.PI * _angle / 180.0));
                angleOffset4 = forward4.Normalize() * (Math.Abs(_distance / 304.8) / Math.Tan(Math.PI * _angle / 180.0));
            }
            // 偏移后的点
            offsetPoint1 = pickPoint1 + offset1 + angleOffset1;
            offsetPoint2 = pickPoint2 + offset1 - angleOffset2;
            offsetPoint3 = pickPoint3 + offset1 - angleOffset3;
            offsetPoint4 = pickPoint4 + offset1 - angleOffset4;
            // ____________________________________________________________________________________________________________________________________________________

            // 原始属性
            Parameter parameter = mepCurve1.get_Parameter(BuiltInParameter.RBS_START_LEVEL_PARAM);
            ElementId levelId = parameter.AsElementId();

            #region 管道
            if (mepCurve1 is Pipe && mepCurve2 is Pipe && mepCurve3 is Pipe && mepCurve4 is Pipe)
            {
                Pipe pipe1 = mepCurve1 as Pipe;
                Pipe pipe2 = mepCurve2 as Pipe;
                Pipe pipe3 = mepCurve3 as Pipe;
                Pipe pipe4 = mepCurve4 as Pipe;
                ElementId systemTypeId = pipe1.MEPSystem.GetTypeId();
                PipeType pipeType = pipe1.PipeType;

                // 【1】创建两侧管道
                Pipe side1 = Pipe.Create(m_doc, systemTypeId, pipeType.Id, levelId, pickPoint1, offsetPoint1);
                Pipe side2 = Pipe.Create(m_doc, systemTypeId, pipeType.Id, levelId, offsetPoint2, pickPoint2);
                Pipe side3 = Pipe.Create(m_doc, systemTypeId, pipeType.Id, levelId, offsetPoint3, pickPoint3);
                Pipe side4 = Pipe.Create(m_doc, systemTypeId, pipeType.Id, levelId, offsetPoint4, pickPoint4);

                // 复制参数
                Utils.CopyParameters(pipe1, side1);
                Utils.CopyParameters(pipe2, side2);
                Utils.CopyParameters(pipe3, side3);
                Utils.CopyParameters(pipe4, side4);

                // 起点、终点连接件
                Connector startConn = Utils.FindConnectedTo(pipe1, startPoint);
                Connector endConn = Utils.FindConnectedTo(pipe2, endPoint);
                Connector midConn = Utils.FindConnectedTo(pipe3, middlePoint2);
                Connector fourConn = Utils.FindConnectedTo(pipe4, fourPoint2);
                // 配件两端连接件
                Connector fittingConn1 = Utils.FindConnectedTo(pipe1, fittingPoint1);
                Connector fittingConn2 = Utils.FindConnectedTo(pipe2, fittingPoint2);
                Connector fittingConn3 = Utils.FindConnectedTo(pipe3, middlePoint1);
                Connector fittingConn4 = Utils.FindConnectedTo(pipe4, fourPoint1);
                // 【2】创建起点处管道
                Pipe startPipe = null;
                if (null != startConn)
                {
                    startPipe = Pipe.Create(m_doc, pipe1.PipeType.Id, levelId, startConn, pickPoint1);
                }
                else
                {
                    startPipe = Pipe.Create(m_doc, systemTypeId, pipe1.PipeType.Id, levelId, startPoint, pickPoint1);
                }
                // 复制参数
                Utils.CopyParameters(pipe1, startPipe);
                // 创建弯头
                Connector connStart1 = Utils.FindConnector(startPipe, pickPoint1);
                Connector connStart2 = Utils.FindConnector(side1, pickPoint1);
                FamilyInstance f1 = m_doc.Create.NewElbowFitting(connStart1, connStart2);

                // 【3】创建终点处管道
                Pipe endPipe = null;
                if (null != endConn)
                {
                    endPipe = Pipe.Create(m_doc, pipe2.PipeType.Id, levelId, endConn, pickPoint2);
                }
                else
                {
                    endPipe = Pipe.Create(m_doc, systemTypeId, pipe2.PipeType.Id, levelId, endPoint, pickPoint2);
                }
                // 复制参数
                Utils.CopyParameters(pipe2, endPipe);
                // 创建弯头
                Connector connEnd1 = Utils.FindConnector(endPipe, pickPoint2);
                Connector connEnd2 = Utils.FindConnector(side2, pickPoint2);
                FamilyInstance f2 = m_doc.Create.NewElbowFitting(connEnd1, connEnd2);

                // 【3+】创建终点处2管道
                Pipe midPipe = null;
                if (null != midConn)
                {
                    midPipe = Pipe.Create(m_doc, pipe3.PipeType.Id, levelId, endConn, pickPoint3);
                }
                else
                {
                    midPipe = Pipe.Create(m_doc, systemTypeId, pipe3.PipeType.Id, levelId, middlePoint2, pickPoint3);
                }
                // 复制参数
                Utils.CopyParameters(pipe3, midPipe);
                // 创建弯头
                Connector connMiddle1 = Utils.FindConnector(midPipe, pickPoint3);
                Connector connMiddle2 = Utils.FindConnector(side3, pickPoint3);
                FamilyInstance f3 = m_doc.Create.NewElbowFitting(connMiddle1, connMiddle2);
                // 【3+1】创建终点处3管道
                Pipe fourPipe = null;
                if (null != fourConn)
                {
                    fourPipe = Pipe.Create(m_doc, pipe4.PipeType.Id, levelId, fourConn, pickPoint4);
                }
                else
                {
                    fourPipe = Pipe.Create(m_doc, systemTypeId, pipe4.PipeType.Id, levelId, fourPoint2, pickPoint4);
                }
                // 复制参数
                Utils.CopyParameters(pipe4, fourPipe);
                // 创建弯头
                Connector connFour1 = Utils.FindConnector(fourPipe, pickPoint4);
                Connector connFour2 = Utils.FindConnector(side4, pickPoint4);
                FamilyInstance f4 = m_doc.Create.NewElbowFitting(connFour1, connFour2);
                // 【4】偏移
                ElementTransformUtils.MoveElement(m_doc, pipe1.Id, offset1);

                //【5】创建配件两边的管道
                if (fittingConn1.Origin.IsAlmostEqualTo(fittingPoint1) || fittingConn2.Origin.IsAlmostEqualTo(fittingPoint2) || fittingConn3.Origin.IsAlmostEqualTo(middlePoint1) || fittingConn4.Origin.IsAlmostEqualTo(fourPoint1))
                {
                    // 说明没有被移动上来
                    TaskDialog.Show("警告", "不支持该操作");
                    m_doc.Delete(side1.Id);
                    m_doc.Delete(side2.Id);
                    m_doc.Delete(side3.Id);
                    m_doc.Delete(side4.Id);
                    m_doc.Delete(startPipe.Id);
                    m_doc.Delete(endPipe.Id);
                    m_doc.Delete(midPipe.Id);
                    m_doc.Delete(fourPipe.Id);
                    m_doc.Delete(f1.Id);
                    m_doc.Delete(f2.Id);
                    m_doc.Delete(f3.Id);
                    m_doc.Delete(f4.Id);

                    ElementTransformUtils.MoveElement(m_doc, pipe1.Id, -1 * offset1);
                    ElementTransformUtils.MoveElement(m_doc, pipe2.Id, -1 * offset1);
                    ElementTransformUtils.MoveElement(m_doc, pipe3.Id, -1 * offset1);
                    ElementTransformUtils.MoveElement(m_doc, pipe4.Id, -1 * offset1);

                    return;
                }
                Pipe fittingSide1 = Pipe.Create(m_doc, pipeType.Id, levelId, fittingConn1, offsetPoint1);
                Pipe fittingSide2 = Pipe.Create(m_doc, pipeType.Id, levelId, fittingConn2, offsetPoint2);
                Pipe fittingSide3 = Pipe.Create(m_doc, pipeType.Id, levelId, fittingConn3, offsetPoint3);
                Pipe fittingSide4 = Pipe.Create(m_doc, pipeType.Id, levelId, fittingConn4, offsetPoint4);
                // 复制参数
                Utils.CopyParameters(pipe1, fittingSide1);
                Utils.CopyParameters(pipe2, fittingSide2);
                Utils.CopyParameters(pipe3, fittingSide3);
                Utils.CopyParameters(pipe4, fittingSide4);
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
                Connector conn7 = Utils.FindConnector(side4, offsetPoint4);
                Connector conn8 = Utils.FindConnector(fittingSide4, offsetPoint4);
                m_doc.Create.NewElbowFitting(conn7, conn8);
                // 【6】删除原管道
                m_doc.Delete(pipe1.Id);
                m_doc.Delete(pipe2.Id);
                m_doc.Delete(pipe3.Id);
                m_doc.Delete(pipe4.Id);
            }
            #endregion

            #region 风管
            if (mepCurve1 is Duct && mepCurve2 is Duct && mepCurve3 is Duct && mepCurve4 is Duct)
            {
                Duct duct1 = mepCurve1 as Duct;
                Duct duct2 = mepCurve2 as Duct;
                Duct duct3 = mepCurve3 as Duct;
                Duct duct4 = mepCurve4 as Duct;
                ElementId systemTypeId = duct1.MEPSystem.GetTypeId();
                DuctType ductType = duct1.DuctType;

                // 【1】创建两侧风管
                Duct side1 = Duct.Create(m_doc, systemTypeId, duct1.DuctType.Id, levelId, pickPoint1, offsetPoint1);
                RotateFix(side1, duct1);
                Duct side2 = Duct.Create(m_doc, systemTypeId, duct2.DuctType.Id, levelId, offsetPoint2, pickPoint2);
                RotateFix(side2, duct2);
                Duct side3 = Duct.Create(m_doc, systemTypeId, duct3.DuctType.Id, levelId, offsetPoint3, pickPoint3);
                RotateFix(side3, duct3);
                Duct side4 = Duct.Create(m_doc, systemTypeId, duct4.DuctType.Id, levelId, offsetPoint4, pickPoint4);
                RotateFix(side4, duct4);

                // 复制参数
                Utils.CopyParameters(duct1, side1);
                Utils.CopyParameters(duct2, side2);
                Utils.CopyParameters(duct3, side3);
                Utils.CopyParameters(duct4, side4);

                // 起点、终点连接件
                Connector startConn = Utils.FindConnectedTo(duct1, startPoint);
                Connector endConn = Utils.FindConnectedTo(duct2, endPoint);
                Connector midConn = Utils.FindConnectedTo(duct3, middlePoint2);
                Connector fourConn = Utils.FindConnectedTo(duct4, fourPoint2);

                // 配件两端连接件
                Connector fittingConn1 = Utils.FindConnectedTo(duct1, fittingPoint1);
                Connector fittingConn2 = Utils.FindConnectedTo(duct2, fittingPoint2);
                Connector fittingConn3 = Utils.FindConnectedTo(duct3, middlePoint1);
                Connector fittingConn4 = Utils.FindConnectedTo(duct4, fourPoint1);

                // 【2】创建起点处风管
                Duct startDuct = Duct.Create(m_doc, systemTypeId, duct1.DuctType.Id, levelId, startPoint, pickPoint1);
                if (null != startConn)
                {
                    startConn.ConnectTo(Utils.FindConnector(startDuct, startPoint));
                }
                // 复制参数
                Utils.CopyParameters(duct1, startDuct);
                // 创建弯头
                Connector connStart1 = Utils.FindConnector(startDuct, pickPoint1);
                Connector connStart2 = Utils.FindConnector(side1, pickPoint1);
                FamilyInstance f1 = m_doc.Create.NewElbowFitting(connStart1, connStart2);

                // 【3】创建终点处风管
                Duct endDuct = Duct.Create(m_doc, systemTypeId, duct2.DuctType.Id, levelId, endPoint, pickPoint2);
                if (null != endConn)
                {
                    endConn.ConnectTo(Utils.FindConnector(endDuct, endPoint));
                }
                // 复制参数
                Utils.CopyParameters(duct2, endDuct);
                // 创建弯头
                Connector connEnd1 = Utils.FindConnector(endDuct, pickPoint2);
                Connector connEnd2 = Utils.FindConnector(side2, pickPoint2);
                FamilyInstance f2 = m_doc.Create.NewElbowFitting(connEnd1, connEnd2);

                // 【3+】创建终点处2管道
                Duct midDuct = Duct.Create(m_doc, systemTypeId, duct3.DuctType.Id, levelId, middlePoint2, pickPoint3);
                if (null != midConn)
                {
                    midConn.ConnectTo(Utils.FindConnector(midDuct, middlePoint2));
                }
                // 复制参数
                Utils.CopyParameters(duct3, midDuct);
                // 创建弯头
                Connector connMiddle1 = Utils.FindConnector(midDuct, pickPoint3);
                Connector connMiddle2 = Utils.FindConnector(side3, pickPoint3);
                FamilyInstance f3 = m_doc.Create.NewElbowFitting(connMiddle1, connMiddle2);

                // 【3+1】创建终点处3管道
                Duct fourDuct = Duct.Create(m_doc, systemTypeId, duct4.DuctType.Id, levelId, fourPoint2, pickPoint4);
                if (null != fourConn)
                {
                    fourConn.ConnectTo(Utils.FindConnector(fourDuct, fourPoint2));
                }
                // 复制参数
                Utils.CopyParameters(duct4, fourDuct);
                // 创建弯头
                Connector connFour1 = Utils.FindConnector(fourDuct, pickPoint4);
                Connector connFour2 = Utils.FindConnector(side4, pickPoint4);
                FamilyInstance f4= m_doc.Create.NewElbowFitting(connFour1, connFour2);

                // 【4】偏移
                ElementTransformUtils.MoveElement(m_doc, duct1.Id, offset1);

                //【5】创建配件两边的管道
                if (fittingConn1.Origin.IsAlmostEqualTo(fittingPoint1) || fittingConn2.Origin.IsAlmostEqualTo(fittingPoint2) || fittingConn3.Origin.IsAlmostEqualTo(middlePoint1) || fittingConn4.Origin.IsAlmostEqualTo(fourPoint1))
                {
                    // 说明没有被移动上来
                    TaskDialog.Show("警告", "不支持该操作");
                    m_doc.Delete(side1.Id);
                    m_doc.Delete(side2.Id);
                    m_doc.Delete(side3.Id);
                    m_doc.Delete(side4.Id);
                    m_doc.Delete(startDuct.Id);
                    m_doc.Delete(endDuct.Id);
                    m_doc.Delete(midDuct.Id);
                    m_doc.Delete(fourDuct.Id);
                    m_doc.Delete(f1.Id);
                    m_doc.Delete(f2.Id);
                    m_doc.Delete(f3.Id);
                    m_doc.Delete(f4.Id);

                    ElementTransformUtils.MoveElement(m_doc, duct1.Id, -1 * offset1);

                    return;
                }
                Duct fittingSide1 = Duct.Create(m_doc, systemTypeId, duct1.DuctType.Id, levelId, fittingConn1.Origin, offsetPoint1);
                fittingConn1.ConnectTo(Utils.FindConnector(fittingSide1, fittingConn1.Origin));
                Duct fittingSide2 = Duct.Create(m_doc, systemTypeId, duct2.DuctType.Id, levelId, fittingConn2.Origin, offsetPoint2);
                fittingConn2.ConnectTo(Utils.FindConnector(fittingSide2, fittingConn2.Origin));
                Duct fittingSide3 = Duct.Create(m_doc, systemTypeId, duct3.DuctType.Id, levelId, fittingConn3.Origin, offsetPoint3);
                fittingConn3.ConnectTo(Utils.FindConnector(fittingSide3, fittingConn3.Origin));
                Duct fittingSide4 = Duct.Create(m_doc, systemTypeId, duct4.DuctType.Id, levelId, fittingConn4.Origin, offsetPoint4);
                fittingConn4.ConnectTo(Utils.FindConnector(fittingSide4, fittingConn4.Origin));

                // 复制参数
                Utils.CopyParameters(duct1, fittingSide1);
                Utils.CopyParameters(duct2, fittingSide2);
                Utils.CopyParameters(duct3, fittingSide3);
                Utils.CopyParameters(duct4, fittingSide4);
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
                Connector conn7 = Utils.FindConnector(side4, offsetPoint4);
                Connector conn8 = Utils.FindConnector(fittingSide4, offsetPoint4);
                m_doc.Create.NewElbowFitting(conn7, conn8);
                // 【6】删除原管道
                m_doc.Delete(duct1.Id);
                m_doc.Delete(duct2.Id);
                m_doc.Delete(duct3.Id);
                m_doc.Delete(duct4.Id);
            }
            #endregion

            #region 桥架
            if (mepCurve1 is CableTray && mepCurve2 is CableTray && mepCurve3 is CableTray && mepCurve4 is CableTray)
            {
                CableTray cableTray1 = mepCurve1 as CableTray;
                CableTray cableTray2 = mepCurve2 as CableTray;
                CableTray cableTray3 = mepCurve3 as CableTray;
                CableTray cableTray4 = mepCurve4 as CableTray;
                ElementId cableTrayType = cableTray1.GetTypeId();

                // 【1】创建两侧桥架
                CableTray side1 = CableTray.Create(m_doc, cableTray1.GetTypeId(), pickPoint1, offsetPoint1, levelId);
                RotateFix(side1, cableTray1);
                CableTray side2 = CableTray.Create(m_doc, cableTray2.GetTypeId(), offsetPoint2, pickPoint2, levelId);
                RotateFix(side2, cableTray2);
                CableTray side3 = CableTray.Create(m_doc, cableTray3.GetTypeId(), offsetPoint3, pickPoint3, levelId);
                RotateFix(side3, cableTray3);
                CableTray side4 = CableTray.Create(m_doc, cableTray4.GetTypeId(), offsetPoint4, pickPoint4, levelId);
                RotateFix(side4, cableTray4);

                // 复制参数
                Utils.CopyParameters(cableTray1, side1);
                Utils.CopyParameters(cableTray2, side2);
                Utils.CopyParameters(cableTray3, side3);
                Utils.CopyParameters(cableTray4, side4);

                // 起点、终点连接件
                Connector startConn = Utils.FindConnectedTo(cableTray1, startPoint);
                Connector endConn = Utils.FindConnectedTo(cableTray2, endPoint);
                Connector midConn = Utils.FindConnectedTo(cableTray3, middlePoint2);
                Connector fourConn = Utils.FindConnectedTo(cableTray4, fourPoint2);
                // 配件两端连接件
                Connector fittingConn1 = Utils.FindConnectedTo(cableTray1, fittingPoint1);
                Connector fittingConn2 = Utils.FindConnectedTo(cableTray2, fittingPoint2);
                Connector fittingConn3 = Utils.FindConnectedTo(cableTray3, middlePoint1);
                Connector fittingConn4 = Utils.FindConnectedTo(cableTray4, fourPoint1);

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

                // 【3+1】创建终点处3管道
                CableTray fourCT = CableTray.Create(m_doc, cableTray4.GetTypeId(), fourPoint2, pickPoint4, levelId);
                if (null != fourConn)
                {
                    fourConn.ConnectTo(Utils.FindConnector(fourCT, fourPoint2));
                }
                // 复制参数
                Utils.CopyParameters(cableTray4, fourCT);
                // 创建弯头
                Connector connFour1 = Utils.FindConnector(fourCT, pickPoint4);
                Connector connFour2 = Utils.FindConnector(side4, pickPoint4);
                FamilyInstance f4 = m_doc.Create.NewElbowFitting(connFour1, connFour2);

                // 【4】偏移
                ElementTransformUtils.MoveElement(m_doc, cableTray1.Id, offset1);

                //【5】创建配件两边的管道
                if (fittingConn1.Origin.IsAlmostEqualTo(fittingPoint1) || fittingConn2.Origin.IsAlmostEqualTo(fittingPoint2) || fittingConn3.Origin.IsAlmostEqualTo(middlePoint1) || fittingConn4.Origin.IsAlmostEqualTo(fourPoint1))
                {
                    // 说明没有被移动上来
                    TaskDialog.Show("警告", "不支持该操作");
                    m_doc.Delete(side1.Id);
                    m_doc.Delete(side2.Id);
                    m_doc.Delete(side3.Id);
                    m_doc.Delete(side4.Id);
                    m_doc.Delete(startCT.Id);
                    m_doc.Delete(endCT.Id);
                    m_doc.Delete(midCT.Id);
                    m_doc.Delete(fourCT.Id);
                    m_doc.Delete(f1.Id);
                    m_doc.Delete(f2.Id);
                    m_doc.Delete(f3.Id);
                    m_doc.Delete(f4.Id);

                    ElementTransformUtils.MoveElement(m_doc, cableTray1.Id, -1 * offset1);

                    return;
                }
                CableTray fittingSide1 = CableTray.Create(m_doc, cableTray1.GetTypeId(), fittingConn1.Origin, offsetPoint1, levelId);
                fittingConn1.ConnectTo(Utils.FindConnector(fittingSide1, fittingConn1.Origin));
                CableTray fittingSide2 = CableTray.Create(m_doc, cableTray2.GetTypeId(), fittingConn2.Origin, offsetPoint2, levelId);
                fittingConn2.ConnectTo(Utils.FindConnector(fittingSide2, fittingConn2.Origin));
                CableTray fittingSide3 = CableTray.Create(m_doc, cableTray3.GetTypeId(), fittingConn3.Origin, offsetPoint3, levelId);
                fittingConn3.ConnectTo(Utils.FindConnector(fittingSide3, fittingConn3.Origin));
                CableTray fittingSide4 = CableTray.Create(m_doc, cableTray4.GetTypeId(), fittingConn4.Origin, offsetPoint4, levelId);
                fittingConn4.ConnectTo(Utils.FindConnector(fittingSide4, fittingConn4.Origin));

                // 复制参数
                Utils.CopyParameters(cableTray1, fittingSide1);
                Utils.CopyParameters(cableTray2, fittingSide2);
                Utils.CopyParameters(cableTray3, fittingSide3);
                Utils.CopyParameters(cableTray4, fittingSide4);
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
                Connector conn7 = Utils.FindConnector(side4, offsetPoint4);
                Connector conn8 = Utils.FindConnector(fittingSide4, offsetPoint4);
                m_doc.Create.NewElbowFitting(conn7, conn8);
                // 【6】删除原管道
                m_doc.Delete(cableTray1.Id);
                m_doc.Delete(cableTray2.Id);
                m_doc.Delete(cableTray3.Id);
                m_doc.Delete(cableTray4.Id);
            }
            #endregion

            #region 线管
            if (mepCurve1 is Conduit && mepCurve2 is Conduit && mepCurve3 is Conduit && mepCurve4 is Conduit)
            {
                Conduit conduit1 = mepCurve1 as Conduit;
                Conduit conduit2 = mepCurve2 as Conduit;
                Conduit conduit3 = mepCurve3 as Conduit;
                Conduit conduit4 = mepCurve4 as Conduit;
                ElementId conduitType = conduit1.GetTypeId();

                // 【1】创建两侧线管
                Conduit side1 = Conduit.Create(m_doc, conduit1.GetTypeId(), pickPoint1, offsetPoint1, levelId);
                Conduit side2 = Conduit.Create(m_doc, conduit2.GetTypeId(), offsetPoint2, pickPoint2, levelId);
                Conduit side3 = Conduit.Create(m_doc, conduit3.GetTypeId(), offsetPoint3, pickPoint3, levelId);
                Conduit side4 = Conduit.Create(m_doc, conduit4.GetTypeId(), offsetPoint4, pickPoint4, levelId);

                // 复制参数
                Utils.CopyParameters(conduit1, side1);
                Utils.CopyParameters(conduit2, side2);
                Utils.CopyParameters(conduit3, side3);
                Utils.CopyParameters(conduit4, side4);

                // 起点、终点连接件
                Connector startConn = Utils.FindConnectedTo(conduit1, startPoint);
                Connector endConn = Utils.FindConnectedTo(conduit2, endPoint);
                Connector midConn = Utils.FindConnectedTo(conduit3, middlePoint2);
                Connector fourConn = Utils.FindConnectedTo(conduit4, fourPoint2);
                // 配件两端连接件
                Connector fittingConn1 = Utils.FindConnectedTo(conduit1, fittingPoint1);
                Connector fittingConn2 = Utils.FindConnectedTo(conduit2, fittingPoint2);
                Connector fittingConn3 = Utils.FindConnectedTo(conduit3, middlePoint1);
                Connector fittingConn4 = Utils.FindConnectedTo(conduit4, fourPoint1);

                // 【2】创建起点处线管
                Conduit startConduit = Conduit.Create(m_doc, conduit1.GetTypeId(), startPoint, pickPoint1, levelId);
                if (null != startConn)
                {
                    startConn.ConnectTo(Utils.FindConnector(startConduit, startPoint));
                }
                // 复制参数
                Utils.CopyParameters(conduit1, startConduit);
                // 创建弯头
                Connector connStart1 = Utils.FindConnector(startConduit, pickPoint1);
                Connector connStart2 = Utils.FindConnector(side1, pickPoint1);
                FamilyInstance f1 = m_doc.Create.NewElbowFitting(connStart1, connStart2);

                // 【3】创建终点处线管
                Conduit endConduit = Conduit.Create(m_doc, conduit2.GetTypeId(), endPoint, pickPoint2, levelId);
                if (null != endConn)
                {
                    endConn.ConnectTo(Utils.FindConnector(endConduit, endPoint));
                }
                // 复制参数
                Utils.CopyParameters(conduit2, endConduit);
                // 创建弯头
                Connector connEnd1 = Utils.FindConnector(endConduit, pickPoint2);
                Connector connEnd2 = Utils.FindConnector(side2, pickPoint2);
                FamilyInstance f2 = m_doc.Create.NewElbowFitting(connEnd1, connEnd2);

                // 【3+】创建终点处2管道
                Conduit midConduit = Conduit.Create(m_doc, conduit3.GetTypeId(), middlePoint2, pickPoint3, levelId);
                if (null != midConn)
                {
                    midConn.ConnectTo(Utils.FindConnector(midConduit, middlePoint2));
                }
                // 复制参数
                Utils.CopyParameters(conduit3, midConduit);
                // 创建弯头
                Connector connMiddle1 = Utils.FindConnector(midConduit, pickPoint3);
                Connector connMiddle2 = Utils.FindConnector(side3, pickPoint3);
                FamilyInstance f3 = m_doc.Create.NewElbowFitting(connMiddle1, connMiddle2);

                // 【3+1】创建终点处3管道
                Conduit fourConduit = Conduit.Create(m_doc, conduit4.GetTypeId(), fourPoint2, pickPoint4, levelId);
                if (null != fourConn)
                {
                    fourConn.ConnectTo(Utils.FindConnector(fourConduit, fourPoint2));
                }
                // 复制参数
                Utils.CopyParameters(conduit4, fourConduit);
                // 创建弯头
                Connector connFour1 = Utils.FindConnector(fourConduit, pickPoint4);
                Connector connFour2 = Utils.FindConnector(side4, pickPoint4);
                FamilyInstance f4 = m_doc.Create.NewElbowFitting(connFour1, connFour2);

                // 【4】偏移
                ElementTransformUtils.MoveElement(m_doc, conduit1.Id, offset1);

                //【5】创建配件两边的管道
                if (fittingConn1.Origin.IsAlmostEqualTo(fittingPoint1) || fittingConn2.Origin.IsAlmostEqualTo(fittingPoint2) || fittingConn3.Origin.IsAlmostEqualTo(middlePoint1) || fittingConn4.Origin.IsAlmostEqualTo(fourPoint1))
                {
                    // 说明没有被移动上来
                    TaskDialog.Show("警告", "不支持该操作");
                    m_doc.Delete(side1.Id);
                    m_doc.Delete(side2.Id);
                    m_doc.Delete(side3.Id);
                    m_doc.Delete(side4.Id);
                    m_doc.Delete(startConduit.Id);
                    m_doc.Delete(endConduit.Id);
                    m_doc.Delete(midConduit.Id);
                    m_doc.Delete(fourConduit.Id);
                    m_doc.Delete(f1.Id);
                    m_doc.Delete(f2.Id);
                    m_doc.Delete(f3.Id);
                    m_doc.Delete(f4.Id);

                    ElementTransformUtils.MoveElement(m_doc, conduit1.Id, -1 * offset1);

                    return;
                }
                Conduit fittingSide1 = Conduit.Create(m_doc, conduit1.GetTypeId(), fittingConn1.Origin, offsetPoint1, levelId);
                fittingConn1.ConnectTo(Utils.FindConnector(fittingSide1, fittingConn1.Origin));
                Conduit fittingSide2 = Conduit.Create(m_doc, conduit2.GetTypeId(), fittingConn2.Origin, offsetPoint2, levelId);
                fittingConn2.ConnectTo(Utils.FindConnector(fittingSide2, fittingConn2.Origin));
                Conduit fittingSide3 = Conduit.Create(m_doc, conduit3.GetTypeId(), fittingConn3.Origin, offsetPoint3, levelId);
                fittingConn3.ConnectTo(Utils.FindConnector(fittingSide3, fittingConn3.Origin));
                Conduit fittingSide4 = Conduit.Create(m_doc, conduit4.GetTypeId(), fittingConn4.Origin, offsetPoint4, levelId);
                fittingConn4.ConnectTo(Utils.FindConnector(fittingSide4, fittingConn4.Origin));

                // 复制参数
                Utils.CopyParameters(conduit1, fittingSide1);
                Utils.CopyParameters(conduit2, fittingSide2);
                Utils.CopyParameters(conduit3, fittingSide3);
                Utils.CopyParameters(conduit4, fittingSide4);
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
                Connector conn7 = Utils.FindConnector(side4, offsetPoint4);
                Connector conn8 = Utils.FindConnector(fittingSide4, offsetPoint4);
                m_doc.Create.NewElbowFitting(conn7, conn8);
                // 【6】删除原管道
                m_doc.Delete(conduit1.Id);
                m_doc.Delete(conduit2.Id);
                m_doc.Delete(conduit3.Id);
                m_doc.Delete(conduit4.Id);
            }
            #endregion
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

