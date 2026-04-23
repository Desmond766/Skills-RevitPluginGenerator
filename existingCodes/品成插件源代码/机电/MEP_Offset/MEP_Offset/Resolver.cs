using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.DB.Mechanical;

namespace MEP_Offset
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
        XYZ pickPoint1;
        XYZ pickPoint2;
        XYZ offsetPoint1;
        XYZ offsetPoint2;
        XYZ offset;
        XYZ offset1;
        XYZ offset2;
        XYZ angleOffset;
        XYZ angleOffset1;
        XYZ angleOffset2;
        #endregion

        // 构造函数
        public Resolver(ExternalCommandData commandData)
        {
            m_uiapp = commandData.Application;
            m_doc = m_uiapp.ActiveUIDocument.Document;
        }

        //方法
        public void Resolve(Reference r1, Reference r2)
        {
            if (r1.ElementId.IntegerValue == r2.ElementId.IntegerValue)
            {
                // 原管线
                MEPCurve mepCurve = m_doc.GetElement(r1) as MEPCurve;
                // 原管线中心线 
                Line mepLine = (mepCurve.Location as LocationCurve).Curve as Line;
                // 拾取点
                pickPoint1 = Utils.GetProjectivePoint(mepLine, r1.GlobalPoint);
                pickPoint2 = Utils.GetProjectivePoint(mepLine, r2.GlobalPoint);
                // 判断起点、终点
                if (mepLine.GetEndPoint(0).DistanceTo(pickPoint1) < mepLine.GetEndPoint(0).DistanceTo(pickPoint2))
                {
                    startPoint = mepLine.GetEndPoint(0);
                    endPoint = mepLine.GetEndPoint(1);
                }
                else
                {
                    startPoint = mepLine.GetEndPoint(1);
                    endPoint = mepLine.GetEndPoint(0);
                }
                // 点击的前进方向
                XYZ forward = endPoint - startPoint;
                // 偏移量
                if (_direction == DirectionList.LR)
                {
                    offset = forward.CrossProduct(XYZ.BasisZ).Normalize() * _distance / 304.8;

                    //Utils.DrawModelCurve(m_doc, pickPoint1, offset);
                }
                else
                {
                    offset = XYZ.BasisZ * _distance / 304.8;
                }
                // 角度产生的偏移
                if (_angle == 90.0)
                {
                    angleOffset = XYZ.Zero;
                }
                else
                {
                    angleOffset = forward.Normalize() * (Math.Abs(_distance / 304.8) / Math.Tan(Math.PI * _angle / 180.0));
                }
                // 偏移后的点
                offsetPoint1 = pickPoint1 + offset + angleOffset;
                offsetPoint2 = pickPoint2 + offset - angleOffset;
                // 偏移
                if (_type == TypeList.OneSide)
                {
                    OneSideOffset(mepCurve);
                }
                else
                {
                    TwoSideOffset(mepCurve);
                }
            }
            else if (m_doc.GetElement(r1).Category.Name == m_doc.GetElement(r2).Category.Name)// 带配件爬升
            {
                // 原管线
                MEPCurve mepCurve1 = m_doc.GetElement(r1) as MEPCurve;
                MEPCurve mepCurve2 = m_doc.GetElement(r2) as MEPCurve;
                // 原管线中心线
                Line mepLine1 = (mepCurve1.Location as LocationCurve).Curve as Line;
                Line mepLine2 = (mepCurve2.Location as LocationCurve).Curve as Line;
                // 拾取点
                pickPoint1 = Utils.GetProjectivePoint(mepLine1, r1.GlobalPoint);
                pickPoint2 = Utils.GetProjectivePoint(mepLine2, r2.GlobalPoint);
                // 判断起点、终点
                List<XYZ> endPointList = Utils.GetEndPoint(mepLine1, mepLine2);
                startPoint = endPointList[0];
                fittingPoint1 = endPointList[1];
                fittingPoint2 = endPointList[2];
                endPoint = endPointList[3];
                // 点击的前进方向
                XYZ forward1 = pickPoint1 - startPoint;
                XYZ forward2 = endPoint - pickPoint2;
                // 偏移量
                if (_direction == DirectionList.LR)
                {
                    offset1 = forward1.CrossProduct(XYZ.BasisZ).Normalize() * _distance / 304.8;
                    offset2 = forward2.CrossProduct(XYZ.BasisZ).Normalize() * _distance / 304.8;
                }
                else
                {
                    offset1 = offset2 = XYZ.BasisZ * _distance / 304.8;
                }
                // 角度产生的偏移
                if (_angle == 90.0)
                {
                    angleOffset1 = angleOffset2 = XYZ.Zero;
                }
                else
                {
                    angleOffset1 = forward1.Normalize() * (Math.Abs(_distance / 304.8) / Math.Tan(Math.PI * _angle / 180.0));
                    angleOffset2 = forward2.Normalize() * (Math.Abs(_distance / 304.8) / Math.Tan(Math.PI * _angle / 180.0));
                }
                // 偏移后的点
                offsetPoint1 = pickPoint1 + offset1 + angleOffset1;
                offsetPoint2 = pickPoint2 + offset2 - angleOffset2;
                // 偏移
                if (_type == TypeList.OneSide)
                {
                    OneSideOffsetWithFitting(mepCurve1, mepCurve2);
                }
                else
                {
                    TwoSideOffsetWithFitting(mepCurve1, mepCurve2);
                }
            }
        }
        #region 单侧偏移
        /// <summary>
        /// 单侧偏移
        /// </summary>
        /// <param name="mepCurve"></param>
        private void OneSideOffset(MEPCurve mepCurve)
        {
            // 原始属性
            Parameter parameter = mepCurve.get_Parameter(BuiltInParameter.RBS_START_LEVEL_PARAM);
            ElementId levelId = parameter.AsElementId();

            #region 管道
            if (mepCurve is Pipe)
            {
                Pipe pipe = mepCurve as Pipe;
                ElementId systemTypeId = pipe.MEPSystem.GetTypeId();
                PipeType pipeType = pipe.PipeType;

                // 【1】创建中间管道
                Pipe pipe1 = Pipe.Create(m_doc, systemTypeId, pipeType.Id, levelId, pickPoint1, offsetPoint1);
                // 复制参数
                Utils.CopyParameters(pipe, pipe1);

                // 起点、终点连接件
                Connector startConn = Utils.FindConnectedTo(pipe, startPoint);
                Connector endConn = Utils.FindConnectedTo(pipe, endPoint);

                // 【2】创建起点处管道
                Pipe startPipe = null;
                if (null != startConn)
                {
                    startPipe = Pipe.Create(m_doc, pipeType.Id, levelId, startConn, pickPoint1);
                }
                else
                {
                    startPipe = Pipe.Create(m_doc, systemTypeId, pipeType.Id, levelId, startPoint, pickPoint1);
                }
                // 复制参数
                Utils.CopyParameters(pipe, startPipe);
                // 创建弯头
                Connector connStart1 = Utils.FindConnector(startPipe, pickPoint1);
                Connector connStart2 = Utils.FindConnector(pipe1, pickPoint1);
                m_doc.Create.NewElbowFitting(connStart1, connStart2);

                // 【3】创建终点处管道
                Pipe endPipe = null;
                if (null != endConn)
                {
                    endPipe = Pipe.Create(m_doc, pipeType.Id, levelId, endConn, pickPoint1 + angleOffset);
                }
                else
                {
                    endPipe = Pipe.Create(m_doc, systemTypeId, pipeType.Id, levelId, endPoint, pickPoint1 + angleOffset);
                }
                // 复制参数
                Utils.CopyParameters(pipe, endPipe);
                // 偏移
                ElementTransformUtils.MoveElement(m_doc, endPipe.Id, offset);
                // 创建弯头
                Connector connEnd1 = Utils.FindConnector(endPipe, offsetPoint1);
                Connector connEnd2 = Utils.FindConnector(pipe1, offsetPoint1);
                m_doc.Create.NewElbowFitting(connEnd1, connEnd2);

                // 删除原管道
                m_doc.Delete(pipe.Id);
            }
            #endregion

            #region 风管
            else if (mepCurve is Duct)
            {
                Duct duct = mepCurve as Duct;
                ElementId systemTypeId = duct.MEPSystem.GetTypeId();
                DuctType ductType = duct.DuctType;

                // 【1】创建中间风管
                Duct duct1 = Duct.Create(m_doc, systemTypeId, ductType.Id, levelId, pickPoint1, offsetPoint1);
                // 复制参数
                Utils.CopyParameters(duct, duct1);
                RotateFix(duct1, duct);

                // 起点、终点连接件
                Connector startConn = Utils.FindConnectedTo(duct, startPoint);
                Connector endConn = Utils.FindConnectedTo(duct, endPoint);

                // 【2】创建起点处风管
                Duct startDuct = Duct.Create(m_doc, systemTypeId, ductType.Id, levelId, startPoint, pickPoint1);
                if (null != startConn)
                {
                    startConn.ConnectTo(Utils.FindConnector(startDuct, startPoint));
                }

                // 复制参数
                Utils.CopyParameters(duct, startDuct);
                // 创建弯头
                Connector connStart1 = Utils.FindConnector(startDuct, pickPoint1);
                Connector connStart2 = Utils.FindConnector(duct1, pickPoint1);
                m_doc.Create.NewElbowFitting(connStart1, connStart2);

                // 【3】创建终点处风管
                Duct endDuct = Duct.Create(m_doc, systemTypeId, ductType.Id, levelId, endPoint, pickPoint1 + angleOffset);
                if (null != endConn)
                {
                    endConn.ConnectTo(Utils.FindConnector(endDuct, endPoint));
                }
                // 复制参数
                Utils.CopyParameters(duct, endDuct);
                // 偏移
                ElementTransformUtils.MoveElement(m_doc, endDuct.Id, offset);
                // 创建弯头
                Connector connEnd1 = Utils.FindConnector(endDuct, offsetPoint1);
                Connector connEnd2 = Utils.FindConnector(duct1, offsetPoint1);
                m_doc.Create.NewElbowFitting(connEnd1, connEnd2);

                // 删除原风管
                m_doc.Delete(duct.Id);
            }
            #endregion

            #region 桥架
            else if (mepCurve is CableTray)
            {
                CableTray cableTray = mepCurve as CableTray;
                ElementId cabletrayType = cableTray.GetTypeId();

                // 【1】创建中间桥架
                CableTray cableTray1 = CableTray.Create(m_doc, cabletrayType, pickPoint1, offsetPoint1, levelId);
                // 复制参数
                Utils.CopyParameters(cableTray, cableTray1);
                RotateFix(cableTray1, cableTray);

                // 起点、终点连接件
                Connector startConn = Utils.FindConnectedTo(cableTray, startPoint);
                Connector endConn = Utils.FindConnectedTo(cableTray, endPoint);

                // 【2】创建起点处桥架
                CableTray startCT = CableTray.Create(m_doc, cabletrayType, startPoint, pickPoint1, levelId);
                if (null != startConn)
                {
                    startConn.ConnectTo(Utils.FindConnector(startCT, startPoint));
                }

                // 复制参数
                Utils.CopyParameters(cableTray, startCT);
                // 创建弯头
                Connector connStart1 = Utils.FindConnector(startCT, pickPoint1);
                Connector connStart2 = Utils.FindConnector(cableTray1, pickPoint1);
                m_doc.Create.NewElbowFitting(connStart1, connStart2);

                // 【3】创建终点处桥架
                CableTray endCT = CableTray.Create(m_doc, cabletrayType, endPoint, pickPoint1 + angleOffset, levelId);
                if (null != endConn)
                {
                    endConn.ConnectTo(Utils.FindConnector(endCT, endPoint));
                }
                // 复制参数
                Utils.CopyParameters(cableTray, endCT);
                // 偏移
                ElementTransformUtils.MoveElement(m_doc, endCT.Id, offset);
                // 创建弯头
                Connector connEnd1 = Utils.FindConnector(endCT, offsetPoint1);
                Connector connEnd2 = Utils.FindConnector(cableTray1, offsetPoint1);
                m_doc.Create.NewElbowFitting(connEnd1, connEnd2);

                // 删除原桥架
                m_doc.Delete(cableTray.Id);
            }
            #endregion

            #region 线管
            else if (mepCurve is Conduit)
            {
                Conduit conduit = mepCurve as Conduit;
                ElementId conduitType = conduit.GetTypeId();

                // 【1】创建中间线管
                Conduit conduit1 = Conduit.Create(m_doc, conduitType, pickPoint1, offsetPoint1, levelId);
                // 复制参数
                Utils.CopyParameters(conduit, conduit1);

                // 起点、终点连接件
                Connector startConn = Utils.FindConnectedTo(conduit, startPoint);
                Connector endConn = Utils.FindConnectedTo(conduit, endPoint);

                // 【2】创建起点处线管
                Conduit startConduit = Conduit.Create(m_doc, conduitType, startPoint, pickPoint1, levelId);
                if (null != startConn)
                {
                    startConn.ConnectTo(Utils.FindConnector(startConduit, startPoint));
                }

                // 复制参数
                Utils.CopyParameters(conduit, startConduit);
                // 创建弯头
                Connector connStart1 = Utils.FindConnector(startConduit, pickPoint1);
                Connector connStart2 = Utils.FindConnector(conduit1, pickPoint1);
                m_doc.Create.NewElbowFitting(connStart1, connStart2);

                // 【3】创建终点处线管
                Conduit endConduit = Conduit.Create(m_doc, conduitType, endPoint, pickPoint1 + angleOffset, levelId);
                if (null != endConn)
                {
                    endConn.ConnectTo(Utils.FindConnector(endConduit, endPoint));
                }
                // 复制参数
                Utils.CopyParameters(conduit, endConduit);
                // 偏移
                ElementTransformUtils.MoveElement(m_doc, endConduit.Id, offset);
                // 创建弯头
                Connector connEnd1 = Utils.FindConnector(endConduit, offsetPoint1);
                Connector connEnd2 = Utils.FindConnector(conduit1, offsetPoint1);
                m_doc.Create.NewElbowFitting(connEnd1, connEnd2);

                // 删除原线管
                m_doc.Delete(conduit.Id);
            }
            #endregion

        }
        #endregion

        #region 两侧偏移
        /// <summary>
        /// 两侧偏移
        /// </summary>
        /// <param name="mepCurve"></param>
        private void TwoSideOffset(MEPCurve mepCurve)
        {
            // 原始属性
            Parameter parameter = mepCurve.get_Parameter(BuiltInParameter.RBS_START_LEVEL_PARAM);
            ElementId levelId = parameter.AsElementId();

            #region 管道
            if (mepCurve is Pipe)
            {
                Pipe pipe = mepCurve as Pipe;
                ElementId systemTypeId = pipe.MEPSystem.GetTypeId();
                PipeType pipeType = pipe.PipeType;

                // 【1】创建U型管道
                Pipe pipe1 = Pipe.Create(m_doc, systemTypeId, pipeType.Id, levelId, pickPoint1, offsetPoint1);
                Pipe pipe2 = Pipe.Create(m_doc, systemTypeId, pipeType.Id, levelId, offsetPoint1, offsetPoint2);
                Pipe pipe3 = Pipe.Create(m_doc, systemTypeId, pipeType.Id, levelId, offsetPoint2, pickPoint2);
                // 复制参数
                Utils.CopyParameters(pipe, pipe1);
                Utils.CopyParameters(pipe, pipe2);
                Utils.CopyParameters(pipe, pipe3);
                // 创建弯头
                Connector conn1 = Utils.FindConnector(pipe1, offsetPoint1);
                Connector conn2 = Utils.FindConnector(pipe2, offsetPoint1);
                m_doc.Create.NewElbowFitting(conn1, conn2);
                Connector conn3 = Utils.FindConnector(pipe2, offsetPoint2);
                Connector conn4 = Utils.FindConnector(pipe3, offsetPoint2);
                m_doc.Create.NewElbowFitting(conn3, conn4);

                // 起点、终点连接件
                Connector startConn = Utils.FindConnectedTo(pipe, startPoint);
                Connector endConn = Utils.FindConnectedTo(pipe, endPoint);

                // 【2】创建起点处管道
                Pipe startPipe = null;
                if (null != startConn)
                {
                    startPipe = Pipe.Create(m_doc, pipeType.Id, levelId, startConn, pickPoint1);
                }
                else
                {
                    startPipe = Pipe.Create(m_doc, systemTypeId, pipeType.Id, levelId, startPoint, pickPoint1);
                }
                // 复制参数
                Utils.CopyParameters(pipe, startPipe);
                // 创建弯头
                Connector connStart1 = Utils.FindConnector(startPipe, pickPoint1);
                Connector connStart2 = Utils.FindConnector(pipe1, pickPoint1);
                m_doc.Create.NewElbowFitting(connStart1, connStart2);

                // 【3】创建终点处管道
                Pipe endPipe = null;
                if (null != endConn)
                {
                    endPipe = Pipe.Create(m_doc, pipeType.Id, levelId, endConn, pickPoint2);
                }
                else
                {
                    endPipe = Pipe.Create(m_doc, systemTypeId, pipeType.Id, levelId, endPoint, pickPoint2);
                }
                // 复制参数
                Utils.CopyParameters(pipe, endPipe);
                // 创建弯头
                Connector connEnd1 = Utils.FindConnector(endPipe, pickPoint2);
                Connector connEnd2 = Utils.FindConnector(pipe3, pickPoint2);
                m_doc.Create.NewElbowFitting(connEnd1, connEnd2);

                // 删除原管道
                m_doc.Delete(pipe.Id);
            }
            #endregion

            #region 风管
            else if (mepCurve is Duct)
            {
                Duct duct = mepCurve as Duct;
                ElementId systemTypeId = duct.MEPSystem.GetTypeId();
                DuctType ductType = duct.DuctType;

                // 【1】创建U型风管
                Duct duct1 = Duct.Create(m_doc, systemTypeId, ductType.Id, levelId, pickPoint1, offsetPoint1);
                RotateFix(duct1, duct);
                Duct duct2 = Duct.Create(m_doc, systemTypeId, ductType.Id, levelId, offsetPoint1, offsetPoint2);
                Duct duct3 = Duct.Create(m_doc, systemTypeId, ductType.Id, levelId, offsetPoint2, pickPoint2);
                RotateFix(duct3, duct);
                // 复制参数
                Utils.CopyParameters(duct, duct1);
                Utils.CopyParameters(duct, duct2);
                Utils.CopyParameters(duct, duct3);
                // 创建弯头
                Connector conn1 = Utils.FindConnector(duct1, offsetPoint1);
                Connector conn2 = Utils.FindConnector(duct2, offsetPoint1);
                m_doc.Create.NewElbowFitting(conn1, conn2);
                Connector conn3 = Utils.FindConnector(duct2, offsetPoint2);
                Connector conn4 = Utils.FindConnector(duct3, offsetPoint2);
                m_doc.Create.NewElbowFitting(conn3, conn4);

                // 起点、终点连接件
                Connector startConn = Utils.FindConnectedTo(duct, startPoint);
                Connector endConn = Utils.FindConnectedTo(duct, endPoint);

                // 【2】创建起点处风管
                Duct startDuct = Duct.Create(m_doc, systemTypeId, ductType.Id, levelId, startPoint, pickPoint1);
                if (null != startConn)
                {
                    startConn.ConnectTo(Utils.FindConnector(startDuct, startPoint));
                }
                // 复制参数
                Utils.CopyParameters(duct, startDuct);
                // 创建弯头
                Connector connStart1 = Utils.FindConnector(startDuct, pickPoint1);
                Connector connStart2 = Utils.FindConnector(duct1, pickPoint1);
                m_doc.Create.NewElbowFitting(connStart1, connStart2);

                // 【3】创建终点处风管
                Duct endDuct = Duct.Create(m_doc, systemTypeId, ductType.Id, levelId, endPoint, pickPoint2);
                if (null != endConn)
                {
                    endConn.ConnectTo(Utils.FindConnector(endDuct, endPoint));
                }
                // 复制参数
                Utils.CopyParameters(duct, endDuct);
                // 创建弯头
                Connector connEnd1 = Utils.FindConnector(endDuct, pickPoint2);
                Connector connEnd2 = Utils.FindConnector(duct3, pickPoint2);
                m_doc.Create.NewElbowFitting(connEnd1, connEnd2);

                // 删除原风管
                m_doc.Delete(duct.Id);
            }
            #endregion

            #region 桥架
            else if (mepCurve is CableTray)
            {
                CableTray cableTray = mepCurve as CableTray;
                ElementId cabletrayType = cableTray.GetTypeId();

                // 【1】创建U型桥架
                CableTray cableTray1 = CableTray.Create(m_doc, cabletrayType, pickPoint1, offsetPoint1, levelId);
                RotateFix(cableTray1, cableTray);
                CableTray cableTray2 = CableTray.Create(m_doc, cabletrayType, offsetPoint1, offsetPoint2, levelId);
                CableTray cableTray3 = CableTray.Create(m_doc, cabletrayType, offsetPoint2, pickPoint2, levelId);
                RotateFix(cableTray3, cableTray);
                // 复制参数
                Utils.CopyParameters(cableTray, cableTray1);
                Utils.CopyParameters(cableTray, cableTray2);
                Utils.CopyParameters(cableTray, cableTray3);
                // 创建弯头
                Connector conn1 = Utils.FindConnector(cableTray1, offsetPoint1);
                Connector conn2 = Utils.FindConnector(cableTray2, offsetPoint1);
                m_doc.Create.NewElbowFitting(conn1, conn2);
                Connector conn3 = Utils.FindConnector(cableTray2, offsetPoint2);
                Connector conn4 = Utils.FindConnector(cableTray3, offsetPoint2);
                m_doc.Create.NewElbowFitting(conn3, conn4);

                // 起点、终点连接件
                Connector startConn = Utils.FindConnectedTo(cableTray, startPoint);
                Connector endConn = Utils.FindConnectedTo(cableTray, endPoint);

                // 【2】创建起点处桥架
                CableTray startCT = CableTray.Create(m_doc, cabletrayType, startPoint, pickPoint1, levelId);
                if (null != startConn)
                {
                    startConn.ConnectTo(Utils.FindConnector(startCT, startPoint));
                }
                // 复制参数
                Utils.CopyParameters(cableTray, startCT);
                // 创建弯头
                Connector connStart1 = Utils.FindConnector(startCT, pickPoint1);
                Connector connStart2 = Utils.FindConnector(cableTray1, pickPoint1);
                m_doc.Create.NewElbowFitting(connStart1, connStart2);

                // 【3】创建终点处桥架
                CableTray endCT = CableTray.Create(m_doc, cabletrayType, endPoint, pickPoint2, levelId);
                if (null != endConn)
                {
                    endConn.ConnectTo(Utils.FindConnector(endCT, endPoint));
                }
                // 复制参数
                Utils.CopyParameters(cableTray, endCT);
                // 创建弯头
                Connector connEnd1 = Utils.FindConnector(endCT, pickPoint2);
                Connector connEnd2 = Utils.FindConnector(cableTray3, pickPoint2);
                m_doc.Create.NewElbowFitting(connEnd1, connEnd2);

                // 删除原桥架
                m_doc.Delete(cableTray.Id);
            }
            #endregion

            #region 线管
            else if (mepCurve is Conduit)
            {
                Conduit conduit = mepCurve as Conduit;
                ElementId conduitType = conduit.GetTypeId();

                // 【1】创建U型线管
                Conduit conduit1 = Conduit.Create(m_doc, conduitType, pickPoint1, offsetPoint1, levelId);
                Conduit conduit2 = Conduit.Create(m_doc, conduitType, offsetPoint1, offsetPoint2, levelId);
                Conduit conduit3 = Conduit.Create(m_doc, conduitType, offsetPoint2, pickPoint2, levelId);
                // 复制参数
                Utils.CopyParameters(conduit, conduit1);
                Utils.CopyParameters(conduit, conduit2);
                Utils.CopyParameters(conduit, conduit3);
                // 创建弯头
                Connector conn1 = Utils.FindConnector(conduit1, offsetPoint1);
                Connector conn2 = Utils.FindConnector(conduit2, offsetPoint1);
                m_doc.Create.NewElbowFitting(conn1, conn2);
                Connector conn3 = Utils.FindConnector(conduit2, offsetPoint2);
                Connector conn4 = Utils.FindConnector(conduit3, offsetPoint2);
                m_doc.Create.NewElbowFitting(conn3, conn4);

                // 起点、终点连接件
                Connector startConn = Utils.FindConnectedTo(conduit, startPoint);
                Connector endConn = Utils.FindConnectedTo(conduit, endPoint);

                // 【2】创建起点处线管
                Conduit startConduit = Conduit.Create(m_doc, conduitType, startPoint, pickPoint1, levelId);
                if (null != startConn)
                {
                    startConn.ConnectTo(Utils.FindConnector(startConduit, startPoint));
                }
                // 复制参数
                Utils.CopyParameters(conduit, startConduit);
                // 创建弯头
                Connector connStart1 = Utils.FindConnector(startConduit, pickPoint1);
                Connector connStart2 = Utils.FindConnector(conduit1, pickPoint1);
                m_doc.Create.NewElbowFitting(connStart1, connStart2);

                // 【3】创建终点处线管
                Conduit endConduit = Conduit.Create(m_doc, conduitType, endPoint, pickPoint2, levelId);
                if (null != endConn)
                {
                    endConn.ConnectTo(Utils.FindConnector(endConduit, endPoint));
                }
                // 复制参数
                Utils.CopyParameters(conduit, endConduit);
                // 创建弯头
                Connector connEnd1 = Utils.FindConnector(endConduit, pickPoint2);
                Connector connEnd2 = Utils.FindConnector(conduit3, pickPoint2);
                m_doc.Create.NewElbowFitting(connEnd1, connEnd2);

                // 删除原线管
                m_doc.Delete(conduit.Id);
            }
            #endregion

        }
        #endregion

        #region 单侧带配件偏移
        /// <summary>
        /// 单侧带配件偏移
        /// </summary>
        /// <param name="mepCurve1"></param>
        /// <param name="mepCurve2"></param>
        private void OneSideOffsetWithFitting(MEPCurve mepCurve1, MEPCurve mepCurve2)
        {
            OneSideOffset(mepCurve1);
        }
        #endregion

        #region 两侧带配件偏移
        /// <summary>
        /// 两侧带配件偏移
        /// </summary>
        /// <param name="mepCurve1"></param>
        /// <param name="mepCurve2"></param>
        private void TwoSideOffsetWithFitting(MEPCurve mepCurve1, MEPCurve mepCurve2)
        {
            // 原始属性
            Parameter parameter = mepCurve1.get_Parameter(BuiltInParameter.RBS_START_LEVEL_PARAM);
            ElementId levelId = parameter.AsElementId();

            #region 管道
            if (mepCurve1 is Pipe && mepCurve2 is Pipe)
            {
                Pipe pipe1 = mepCurve1 as Pipe;
                Pipe pipe2 = mepCurve2 as Pipe;
                ElementId systemTypeId = pipe1.MEPSystem.GetTypeId();
                PipeType pipeType = pipe1.PipeType;

                // 【1】创建两侧管道
                Pipe side1 = Pipe.Create(m_doc, systemTypeId, pipeType.Id, levelId, pickPoint1, offsetPoint1);
                Pipe side2 = Pipe.Create(m_doc, systemTypeId, pipeType.Id, levelId, offsetPoint2, pickPoint2);
                // 复制参数
                Utils.CopyParameters(pipe1, side1);
                Utils.CopyParameters(pipe2, side2);

                // 起点、终点连接件
                Connector startConn = Utils.FindConnectedTo(pipe1, startPoint);
                Connector endConn = Utils.FindConnectedTo(pipe2, endPoint);
                // 配件两端连接件
                Connector fittingConn1 = Utils.FindConnectedTo(pipe1, fittingPoint1);
                Connector fittingConn2 = Utils.FindConnectedTo(pipe2, fittingPoint2);

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
                FamilyInstance f1=m_doc.Create.NewElbowFitting(connStart1, connStart2);

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
                FamilyInstance f2= m_doc.Create.NewElbowFitting(connEnd1, connEnd2);

                // 【4】偏移
                if (offset1.IsAlmostEqualTo(offset2))
                {
                    ElementTransformUtils.MoveElement(m_doc, pipe1.Id, offset1);
                }
                else
                {
                    ElementTransformUtils.MoveElement(m_doc, pipe1.Id, offset1);
                    ElementTransformUtils.MoveElement(m_doc, pipe2.Id, offset2);
                }

                //【5】创建配件两边的管道
                if (fittingConn1.Origin.IsAlmostEqualTo(fittingPoint1) || fittingConn2.Origin.IsAlmostEqualTo(fittingPoint2))
                {
                    // 说明没有被移动上来
                    TaskDialog.Show("警告", "不支持该操作");
                    m_doc.Delete(side1.Id);
                    m_doc.Delete(side2.Id);
                    m_doc.Delete(startPipe.Id);
                    m_doc.Delete(endPipe.Id);
                    m_doc.Delete(f1.Id);
                    m_doc.Delete(f2.Id);
                    if (offset1.IsAlmostEqualTo(offset2))
                    {
                        ElementTransformUtils.MoveElement(m_doc, pipe1.Id, -1 * offset1);
                    }
                    else
                    {
                        ElementTransformUtils.MoveElement(m_doc, pipe1.Id, -1 * offset1);
                        ElementTransformUtils.MoveElement(m_doc, pipe2.Id, -1 * offset2);
                    }
                    return;
                }
                Pipe fittingSide1 = Pipe.Create(m_doc, pipeType.Id, levelId, fittingConn1, offsetPoint1);
                Pipe fittingSide2 = Pipe.Create(m_doc, pipeType.Id, levelId, fittingConn2, offsetPoint2);
                // 复制参数
                Utils.CopyParameters(pipe1, fittingSide1);
                Utils.CopyParameters(pipe2, fittingSide2);
                // 创建弯头
                Connector conn1 = Utils.FindConnector(side1, offsetPoint1);
                Connector conn2 = Utils.FindConnector(fittingSide1, offsetPoint1);
                m_doc.Create.NewElbowFitting(conn1, conn2);
                Connector conn3 = Utils.FindConnector(side2, offsetPoint2);
                Connector conn4 = Utils.FindConnector(fittingSide2, offsetPoint2);
                m_doc.Create.NewElbowFitting(conn3, conn4);

                // 【6】删除原管道
                m_doc.Delete(pipe1.Id);
                m_doc.Delete(pipe2.Id);
            }
            #endregion

            #region 风管
            else if (mepCurve1 is Duct && mepCurve2 is Duct)
            {
                Duct duct1 = mepCurve1 as Duct;
                Duct duct2 = mepCurve2 as Duct;
                ElementId systemTypeId = duct1.MEPSystem.GetTypeId();
                DuctType ductType = duct1.DuctType;

                // 【1】创建两侧风管
                Duct side1 = Duct.Create(m_doc, systemTypeId, duct1.DuctType.Id, levelId, pickPoint1, offsetPoint1);
                RotateFix(side1, duct1);
                Duct side2 = Duct.Create(m_doc, systemTypeId, duct2.DuctType.Id, levelId, offsetPoint2, pickPoint2);
                RotateFix(side2, duct2);
                // 复制参数
                Utils.CopyParameters(duct1, side1);
                Utils.CopyParameters(duct2, side2);

                // 起点、终点连接件
                Connector startConn = Utils.FindConnectedTo(duct1, startPoint);
                Connector endConn = Utils.FindConnectedTo(duct2, endPoint);
                // 配件两端连接件
                Connector fittingConn1 = Utils.FindConnectedTo(duct1, fittingPoint1);
                Connector fittingConn2 = Utils.FindConnectedTo(duct2, fittingPoint2);

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
                FamilyInstance f1= m_doc.Create.NewElbowFitting(connStart1, connStart2);

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
                FamilyInstance f2= m_doc.Create.NewElbowFitting(connEnd1, connEnd2);

                // 【4】偏移
                if (offset1.IsAlmostEqualTo(offset2))
                {
                    ElementTransformUtils.MoveElement(m_doc, duct1.Id, offset1);
                }
                else
                {
                    ElementTransformUtils.MoveElement(m_doc, duct1.Id, offset1);
                    ElementTransformUtils.MoveElement(m_doc, duct2.Id, offset2);
                }

                //【5】创建配件两边的风管
                if (fittingConn1.Origin.IsAlmostEqualTo(fittingPoint1) || fittingConn2.Origin.IsAlmostEqualTo(fittingPoint2))
                {
                    // 说明没有被移动上来
                    TaskDialog.Show("警告", "不支持该操作");
                    m_doc.Delete(side1.Id);
                    m_doc.Delete(side2.Id);
                    m_doc.Delete(startDuct.Id);
                    m_doc.Delete(endDuct.Id);
                    m_doc.Delete(f1.Id);
                    m_doc.Delete(f2.Id);
                    if (offset1.IsAlmostEqualTo(offset2))
                    {
                        ElementTransformUtils.MoveElement(m_doc, duct1.Id, -1*offset1);
                    }
                    else
                    {
                        ElementTransformUtils.MoveElement(m_doc, duct1.Id, -1*offset1);
                        ElementTransformUtils.MoveElement(m_doc, duct2.Id, -1*offset2);
                    }
                    return;
                }
                Duct fittingSide1 = Duct.Create(m_doc, systemTypeId, duct1.DuctType.Id, levelId, fittingConn1.Origin, offsetPoint1);
                fittingConn1.ConnectTo(Utils.FindConnector(fittingSide1, fittingConn1.Origin));
                Duct fittingSide2 = Duct.Create(m_doc, systemTypeId, duct2.DuctType.Id, levelId, fittingConn2.Origin, offsetPoint2);
                fittingConn2.ConnectTo(Utils.FindConnector(fittingSide2, fittingConn2.Origin));
                // 复制参数
                Utils.CopyParameters(duct1, fittingSide1);
                Utils.CopyParameters(duct2, fittingSide2);
                // 创建弯头
                Connector conn1 = Utils.FindConnector(side1, offsetPoint1);
                Connector conn2 = Utils.FindConnector(fittingSide1, offsetPoint1);
                m_doc.Create.NewElbowFitting(conn1, conn2);
                Connector conn3 = Utils.FindConnector(side2, offsetPoint2);
                Connector conn4 = Utils.FindConnector(fittingSide2, offsetPoint2);
                m_doc.Create.NewElbowFitting(conn3, conn4);

                // 【6】删除原风管
                m_doc.Delete(duct1.Id);
                m_doc.Delete(duct2.Id);
            }
            #endregion

            #region 桥架
            else if (mepCurve1 is CableTray && mepCurve2 is CableTray)
            {
                CableTray cableTray1 = mepCurve1 as CableTray;
                CableTray cableTray2 = mepCurve2 as CableTray;
                ElementId cabletrayType = cableTray1.GetTypeId();

                // 【1】创建两侧桥架
                CableTray side1 = CableTray.Create(m_doc, cableTray1.GetTypeId(), pickPoint1, offsetPoint1, levelId);
                RotateFix(side1, cableTray1);
                CableTray side2 = CableTray.Create(m_doc, cableTray2.GetTypeId(), offsetPoint2, pickPoint2, levelId);
                RotateFix(side2, cableTray2);
                // 复制参数
                Utils.CopyParameters(cableTray1, side1);
                Utils.CopyParameters(cableTray2, side2);

                // 起点、终点连接件
                Connector startConn = Utils.FindConnectedTo(cableTray1, startPoint);
                Connector endConn = Utils.FindConnectedTo(cableTray2, endPoint);
                // 配件两端连接件
                Connector fittingConn1 = Utils.FindConnectedTo(cableTray1, fittingPoint1);
                Connector fittingConn2 = Utils.FindConnectedTo(cableTray2, fittingPoint2);

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
                FamilyInstance f1= m_doc.Create.NewElbowFitting(connStart1, connStart2);

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
                FamilyInstance f2=m_doc.Create.NewElbowFitting(connEnd1, connEnd2);

                // 【4】偏移
                if (offset1.IsAlmostEqualTo(offset2))
                {
                    ElementTransformUtils.MoveElement(m_doc, cableTray1.Id, offset1);
                }
                else
                {
                    ElementTransformUtils.MoveElement(m_doc, cableTray1.Id, offset1);
                    ElementTransformUtils.MoveElement(m_doc, cableTray2.Id, offset2);
                }

                //【5】创建配件两边的桥架
                if (fittingConn1.Origin.IsAlmostEqualTo(fittingPoint1) || fittingConn2.Origin.IsAlmostEqualTo(fittingPoint2))
                {
                    // 说明没有被移动上来
                    TaskDialog.Show("警告", "不支持该操作");
                    m_doc.Delete(side1.Id);
                    m_doc.Delete(side2.Id);
                    m_doc.Delete(startCT.Id);
                    m_doc.Delete(endCT.Id);
                    m_doc.Delete(f1.Id);
                    m_doc.Delete(f2.Id);
                    if (offset1.IsAlmostEqualTo(offset2))
                    {
                        ElementTransformUtils.MoveElement(m_doc, cableTray1.Id, -1*offset1);
                    }
                    else
                    {
                        ElementTransformUtils.MoveElement(m_doc, cableTray1.Id, -1*offset1);
                        ElementTransformUtils.MoveElement(m_doc, cableTray2.Id, -1*offset2);
                    }
                    return;
                }
                CableTray fittingSide1 = CableTray.Create(m_doc, cableTray1.GetTypeId(), fittingConn1.Origin, offsetPoint1, levelId);
                fittingConn1.ConnectTo(Utils.FindConnector(fittingSide1, fittingConn1.Origin));
                CableTray fittingSide2 = CableTray.Create(m_doc, cableTray2.GetTypeId(), fittingConn2.Origin, offsetPoint2, levelId);
                fittingConn2.ConnectTo(Utils.FindConnector(fittingSide2, fittingConn2.Origin));
                // 复制参数
                Utils.CopyParameters(cableTray1, fittingSide1);
                Utils.CopyParameters(cableTray2, fittingSide2);
                // 创建弯头
                Connector conn1 = Utils.FindConnector(side1, offsetPoint1);
                Connector conn2 = Utils.FindConnector(fittingSide1, offsetPoint1);
                m_doc.Create.NewElbowFitting(conn1, conn2);
                Connector conn3 = Utils.FindConnector(side2, offsetPoint2);
                Connector conn4 = Utils.FindConnector(fittingSide2, offsetPoint2);
                m_doc.Create.NewElbowFitting(conn3, conn4);

                //【6】删除原桥架
                m_doc.Delete(cableTray1.Id);
                m_doc.Delete(cableTray2.Id);
            }
            #endregion

            #region 线管
            else if (mepCurve1 is Conduit && mepCurve2 is Conduit)
            {
                Conduit conduit1 = mepCurve1 as Conduit;
                Conduit conduit2 = mepCurve2 as Conduit;
                ElementId conduitType = conduit1.GetTypeId();

                // 【1】创建两侧线管
                Conduit side1 = Conduit.Create(m_doc, conduit1.GetTypeId(), pickPoint1, offsetPoint1, levelId);
                Conduit side2 = Conduit.Create(m_doc, conduit2.GetTypeId(), offsetPoint2, pickPoint2, levelId);
                // 复制参数
                Utils.CopyParameters(conduit1, side1);
                Utils.CopyParameters(conduit2, side2);

                // 起点、终点连接件
                Connector startConn = Utils.FindConnectedTo(conduit1, startPoint);
                Connector endConn = Utils.FindConnectedTo(conduit2, endPoint);
                // 配件两端连接件
                Connector fittingConn1 = Utils.FindConnectedTo(conduit1, fittingPoint1);
                Connector fittingConn2 = Utils.FindConnectedTo(conduit2, fittingPoint2);

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
                FamilyInstance f1=m_doc.Create.NewElbowFitting(connStart1, connStart2);

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
                FamilyInstance f2= m_doc.Create.NewElbowFitting(connEnd1, connEnd2);

                // 【4】偏移
                if (offset1.IsAlmostEqualTo(offset2))
                {
                    ElementTransformUtils.MoveElement(m_doc, conduit1.Id, offset1);
                }
                else
                {
                    ElementTransformUtils.MoveElement(m_doc, conduit1.Id, offset1);
                    ElementTransformUtils.MoveElement(m_doc, conduit2.Id, offset2);
                }

                //【5】创建配件两边的线管
                if (fittingConn1.Origin.IsAlmostEqualTo(fittingPoint1) || fittingConn2.Origin.IsAlmostEqualTo(fittingPoint2))
                {
                    // 说明没有被移动上来
                    TaskDialog.Show("警告", "不支持该操作");
                    m_doc.Delete(side1.Id);
                    m_doc.Delete(side2.Id);
                    m_doc.Delete(startConduit.Id);
                    m_doc.Delete(endConduit.Id);
                    m_doc.Delete(f1.Id);
                    m_doc.Delete(f2.Id);
                    if (offset1.IsAlmostEqualTo(offset2))
                    {
                        ElementTransformUtils.MoveElement(m_doc, conduit1.Id, -1*offset1);
                    }
                    else
                    {
                        ElementTransformUtils.MoveElement(m_doc, conduit1.Id, -1 * offset1);
                        ElementTransformUtils.MoveElement(m_doc, conduit2.Id, -1 * offset2);
                    }
                    return;
                }
                Conduit fittingSide1 = Conduit.Create(m_doc, conduit1.GetTypeId(), fittingConn1.Origin, offsetPoint1, levelId);
                fittingConn1.ConnectTo(Utils.FindConnector(fittingSide1, fittingConn1.Origin));
                Conduit fittingSide2 = Conduit.Create(m_doc, conduit2.GetTypeId(), fittingConn2.Origin, offsetPoint2, levelId);
                fittingConn2.ConnectTo(Utils.FindConnector(fittingSide2, fittingConn2.Origin));
                // 复制参数
                Utils.CopyParameters(conduit1, fittingSide1);
                Utils.CopyParameters(conduit2, fittingSide2);
                // 创建弯头
                Connector conn1 = Utils.FindConnector(side1, offsetPoint1);
                Connector conn2 = Utils.FindConnector(fittingSide1, offsetPoint1);
                m_doc.Create.NewElbowFitting(conn1, conn2);
                Connector conn3 = Utils.FindConnector(side2, offsetPoint2);
                Connector conn4 = Utils.FindConnector(fittingSide2, offsetPoint2);
                m_doc.Create.NewElbowFitting(conn3, conn4);

                // 【6】删除原线管
                m_doc.Delete(conduit1.Id);
                m_doc.Delete(conduit2.Id);
            }
            #endregion

        }
        #endregion

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
