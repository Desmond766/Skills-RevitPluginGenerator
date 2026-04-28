using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.DB.Mechanical;

namespace MEP_FittingOffsetSlope
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
        XYZ startConnPoint;
        XYZ endConnPoint;
        XYZ fittingPoint1;
        XYZ fittingPoint2;
        XYZ pickPoint1;
        XYZ pickPoint2;
        XYZ pickPoint3;
        XYZ offsetPoint1;
        XYZ offsetPoint2;
        XYZ offset1;
        //XYZ angleOffset1;
        //XYZ angleOffset2;
        #endregion

        // 构造函数
        public Resolver(ExternalCommandData commandData)
        {
            m_uiapp = commandData.Application;
            m_doc = m_uiapp.ActiveUIDocument.Document;
        }

        public void Resolve(Reference r0, Reference r1, Reference r2, Reference r3)
        {
          
            #region 原管线

            // 原管线
            MEPCurve mepCurve1 = m_doc.GetElement(r1) as MEPCurve;
            MEPCurve mepCurve2 = m_doc.GetElement(r2) as MEPCurve;
            MEPCurve mepCurve3 = m_doc.GetElement(r3) as MEPCurve;

            // 原管线中心线
            Line mepLine1 = (mepCurve1.Location as LocationCurve).Curve as Line;
            Line mepLine2 = (mepCurve2.Location as LocationCurve).Curve as Line;
            Line mepLine3 = (mepCurve3.Location as LocationCurve).Curve as Line;

            // 拾取点
            pickPoint1 = Utils.GetProjectivePoint(mepLine1, r1.GlobalPoint);
            pickPoint2 = Utils.GetProjectivePoint(mepLine2, r2.GlobalPoint);
            pickPoint3 = Utils.GetProjectivePoint(mepLine3, r3.GlobalPoint);
           
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
            offset1 = XYZ.BasisZ * _distance / 304.8;

            //// 角度产生的偏移
            //if (_angle == 90.0)
            //{
            //    angleOffset1 = angleOffset2 = XYZ.Zero;
            //}
            //else
            //{
            //    angleOffset1 = forward1.Normalize() * (Math.Abs(_distance / 304.8) / Math.Tan(Math.PI * _angle / 180.0));
            //    angleOffset2 = forward2.Normalize() * (Math.Abs(_distance / 304.8) / Math.Tan(Math.PI * _angle / 180.0));
            //}
            // 偏移后的点
            //offsetPoint1 = pickPoint1 + offset1 + angleOffset1;
            //offsetPoint2 = pickPoint2 + offset1 - angleOffset2;
            offsetPoint1 = pickPoint1 + offset1 ;
            offsetPoint2 = pickPoint2 + offset1 ;
            
            // 原始属性
            Parameter parameter = mepCurve1.get_Parameter(BuiltInParameter.RBS_START_LEVEL_PARAM);
            ElementId levelId = parameter.AsElementId();

            #endregion -------------------------------------------------------------------------------------------------------------------------------------------------------------------------

            #region 原三通

            //原三通
            FamilyInstance familyinstance = m_doc.GetElement(r0) as FamilyInstance;
            Location location = familyinstance.Location;
            LocationPoint locationPoint = location as LocationPoint;
            XYZ familyinstancePoint = locationPoint.Point;
           

            //原三通的连接件
            ConnectorSet connectorSet = Utils.GetConSet(m_doc.GetElement(r0));
            List<Connector> conList = new List<Connector>();
            List<Connector> con3List = new List<Connector>();

            //原三通主管上的两个连接件，原三通支管上不连支管
            foreach (Connector conn in connectorSet)
            {
                if (Utils.FindConnectedTo(conn) != null)
                {
                    conList.Add(conn);//主管上的两个连接件(原三通上)
                }
                else
                {
                    con3List.Add(conn);
                }
            }
            //得到支管上的连接件(原三通上)
            Connector connfitting1 = con3List[0];
            //得到主管上与原三通重合的两个连接件（原主管上）
            Connector connTee1;
            Connector connTee2;
            connTee1 = Utils.FindConnectedTo(conList[0]);
            connTee2 = Utils.FindConnectedTo(conList[1]);
            

            //判断起点、终点
            if (connTee1.Origin.DistanceTo(startPoint)<connTee2.Origin.DistanceTo(startPoint))
            {
                startConnPoint = connTee1.Origin;
                endConnPoint = connTee2.Origin;
            }
            else
            {
                startConnPoint = connTee2.Origin;
                endConnPoint = connTee1.Origin;
            }

            #endregion -------------------------------------------------------------------------------------------------------------------------------------------------------------------

            #region 桥架
            if (mepCurve1 is CableTray && mepCurve2 is CableTray)
            {
                CableTray cableTray1 = mepCurve1 as CableTray;
                CableTray cableTray2 = mepCurve2 as CableTray;
                CableTray cableTray3 = mepCurve3 as CableTray;

                ElementId cableTrayType = cableTray1.GetTypeId();

                // 【1】创建原三通三侧桥架（水平，与拾取的第三根管线同一个高度）
                XYZ familyinstancePointZ = new XYZ(familyinstancePoint.X, familyinstancePoint.Y, pickPoint3.Z);

                XYZ teeCT1_1 = new XYZ(startConnPoint.X, startConnPoint.Y, pickPoint3.Z);
                XYZ teeCT1_2 = teeCT1_1 + (teeCT1_1 - familyinstancePointZ).Normalize() * 300 / 304.8;

                XYZ teeCT2_1 = new XYZ(endConnPoint.X, endConnPoint.Y, pickPoint3.Z);
                XYZ teeCT2_2 = teeCT2_1 + (teeCT2_1 - familyinstancePointZ).Normalize() * 300 / 304.8;

                XYZ teeCT3_1 = new XYZ(connfitting1.Origin.X, connfitting1.Origin.Y, pickPoint3.Z);
                XYZ teeCT3_2 = teeCT3_1 + (teeCT3_1 - familyinstancePointZ).Normalize() * 300 / 304.8;
                CableTray side1 = CableTray.Create(m_doc, cableTray1.GetTypeId(), teeCT1_1, teeCT1_2, levelId);
                CableTray side2 = CableTray.Create(m_doc, cableTray2.GetTypeId(), teeCT2_1, teeCT2_2, levelId);
                CableTray side3 = CableTray.Create(m_doc, cableTray3.GetTypeId(), teeCT3_1, teeCT3_2, levelId);

                // 复制参数
                Utils.CopyParameters(cableTray1, side1);
                Utils.CopyParameters(cableTray2, side2);
                Utils.CopyParameters(cableTray3, side3);

                // 【2】创建水平三通
                Connector tee1 = Utils.FindConnector(side1, Utils.GetClosedPt(side1, familyinstancePointZ));
                Connector tee2 = Utils.FindConnector(side2, Utils.GetClosedPt(side2, familyinstancePointZ));
                Connector tee3 = Utils.FindConnector(side3, Utils.GetClosedPt(side3, familyinstancePointZ));
                m_doc.Create.NewTeeFitting(tee1, tee2, tee3);

                // 【3】重绘原始主管
                XYZ ct1 = fittingPoint1 + (startPoint - fittingPoint1).Normalize() * 600 / 304.8;
                XYZ ct2 = fittingPoint2 + (endPoint - fittingPoint2).Normalize() * 600 / 304.8;

                CableTray newCT1 = CableTray.Create(m_doc, cableTray1.GetTypeId(), startPoint, ct1, levelId);
                CableTray newCT2 = CableTray.Create(m_doc, cableTray2.GetTypeId(), endPoint, ct2, levelId);
                // 起点、终点连接件
                Connector startConn = Utils.FindConnectedTo(cableTray1, startPoint);
                Connector endConn = Utils.FindConnectedTo(cableTray2, endPoint);
                if (null != startConn)
                {
                    startConn.ConnectTo(Utils.FindConnector(newCT1, startPoint));
                }
                if (null != endConn)
                {
                    endConn.ConnectTo(Utils.FindConnector(newCT2, endPoint));
                }
                // 复制参数
                Utils.CopyParameters(cableTray1, newCT1);
                Utils.CopyParameters(cableTray2, newCT2);

                // 【4】补斜管
                XYZ xiect1 = Utils.GetClosedPt(side1, startPoint);
                XYZ xiect2 = Utils.GetClosedPt(side2, endPoint);
                CableTray xieCT1 = CableTray.Create(m_doc, cableTray1.GetTypeId(), xiect1, ct1, levelId);
                CableTray xieCT2 = CableTray.Create(m_doc, cableTray2.GetTypeId(), xiect2, ct2, levelId);
                // 复制参数
                Utils.CopyParameters(cableTray1, xieCT1);
                Utils.CopyParameters(cableTray2, xieCT2);

                // 【5】创建弯头
                Connector startct1 = Utils.FindConnector(newCT1, ct1);
                Connector startct2 = Utils.FindConnector(xieCT1, ct1);
                m_doc.Create.NewElbowFitting(startct1, startct2);
                Connector startfitting1 = Utils.FindConnector(xieCT1, xiect1);
                Connector startfitting2 = Utils.FindConnector(side1, xiect1);
                m_doc.Create.NewElbowFitting(startfitting1, startfitting2);
                Connector endct1 = Utils.FindConnector(newCT2, ct2);
                Connector endct2 = Utils.FindConnector(xieCT2, ct2);
                m_doc.Create.NewElbowFitting(endct1, endct2);
                Connector endfitting1 = Utils.FindConnector(xieCT2, xiect2);
                Connector endfitting2 = Utils.FindConnector(side2, xiect2);
                m_doc.Create.NewElbowFitting(endfitting1, endfitting2);

                // 【6】删除原管道
                m_doc.Delete(cableTray1.Id);
                m_doc.Delete(cableTray2.Id);
                m_doc.Delete(familyinstance.Id);

                
            }
            #endregion--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

            if (mepCurve1 is Duct && mepCurve2 is Duct)
            {
                Duct duct1 = mepCurve1 as Duct;
                Duct duct2 = mepCurve2 as Duct;
                Duct duct3 = mepCurve3 as Duct;

                // 【1】创建原三通三侧桥架（水平，与拾取的第三根管线顶平）
                
                double d1 = Utils.GetHalfHeight(m_doc.GetElement(r3)) - Utils.GetHalfHeight(m_doc.GetElement(r1));
                XYZ teeCT1_1 = new XYZ(startConnPoint.X, startConnPoint.Y, pickPoint3.Z + d1 / 304.8);
                XYZ familyinstancePointZ1 = new XYZ(familyinstancePoint.X, familyinstancePoint.Y, teeCT1_1.Z);
                XYZ teeCT1_2 = teeCT1_1 + (teeCT1_1 - familyinstancePointZ1).Normalize() * 300 / 304.8;
               
                double d2 = Utils.GetHalfHeight(m_doc.GetElement(r3)) - Utils.GetHalfHeight(m_doc.GetElement(r2));
                XYZ teeCT2_1 = new XYZ(endConnPoint.X, endConnPoint.Y, pickPoint3.Z + d2 / 304.8);
                XYZ familyinstancePointZ2 = new XYZ(familyinstancePoint.X, familyinstancePoint.Y, teeCT2_1.Z);
                XYZ teeCT2_2 = teeCT2_1 + (teeCT2_1 - familyinstancePointZ2).Normalize() * 300 / 304.8;

                XYZ teeCT3_1 = new XYZ(connfitting1.Origin.X, connfitting1.Origin.Y, pickPoint3.Z);
                XYZ familyinstancePointZ = new XYZ(familyinstancePoint.X, familyinstancePoint.Y, pickPoint3.Z);
                XYZ teeCT3_2 = teeCT3_1 + (teeCT3_1 - familyinstancePointZ).Normalize() * 300 / 304.8;

                Duct side1 = Duct.Create(m_doc, duct1.MEPSystem.GetTypeId(),duct1.DuctType.Id,duct1.ReferenceLevel.Id, teeCT1_1, teeCT1_2);
                Duct side2 = Duct.Create(m_doc, duct2.MEPSystem.GetTypeId(), duct2.DuctType.Id, duct2.ReferenceLevel.Id, teeCT2_1, teeCT2_2);
                Duct side3 = Duct.Create(m_doc, duct3.MEPSystem.GetTypeId(), duct3.DuctType.Id, duct3.ReferenceLevel.Id, teeCT3_1, teeCT3_2);
                // 复制参数
                Utils.CopyParameters(duct1, side1);
                Utils.CopyParameters(duct2, side2);
                Utils.CopyParameters(duct3, side3);
                //// 【2】创建水平三通
                //Connector tee1 = Utils.FindConnector(side1, Utils.GetClosedPt(side1, familyinstancePointZ));
                //Connector tee2 = Utils.FindConnector(side2, Utils.GetClosedPt(side2, familyinstancePointZ));
                //Connector tee3 = Utils.FindConnector(side3, Utils.GetClosedPt(side3, familyinstancePointZ));
                //m_doc.Create.NewTeeFitting(tee1, tee2, tee3);

                // 【3】重绘原始主管
                XYZ ct1 = fittingPoint1 + (startPoint - fittingPoint1).Normalize() * 600 / 304.8;
                XYZ ct2 = fittingPoint2 + (endPoint - fittingPoint2).Normalize() * 600 / 304.8;

                Duct newCT1 = Duct.Create(m_doc, duct1.MEPSystem.GetTypeId(),duct1.DuctType.Id,duct1.ReferenceLevel.Id, startPoint, ct1);
                Duct newCT2 = Duct.Create(m_doc, duct2.MEPSystem.GetTypeId(),duct2.DuctType.Id,duct2.ReferenceLevel.Id, endPoint, ct2);
                // 起点、终点连接件
                Connector startConn = Utils.FindConnectedTo(duct1, startPoint);
                Connector endConn = Utils.FindConnectedTo(duct2, endPoint);
                if (null != startConn)
                {
                    startConn.ConnectTo(Utils.FindConnector(newCT1, startPoint));
                }
                if (null != endConn)
                {
                    endConn.ConnectTo(Utils.FindConnector(newCT2, endPoint));
                }
                // 复制参数
                Utils.CopyParameters(duct1, newCT1);
                Utils.CopyParameters(duct2, newCT2);
                
                // 【4】补斜管
                XYZ xiect1 = Utils.GetClosedPt(side1, startPoint);
                XYZ xiect2 = Utils.GetClosedPt(side2, endPoint);
                Duct xieCT1 = Duct.Create(m_doc, duct1.MEPSystem.GetTypeId(), duct1.DuctType.Id, duct1.ReferenceLevel.Id, xiect1, ct1);
                Duct xieCT2 = Duct.Create(m_doc, duct2.MEPSystem.GetTypeId(), duct2.DuctType.Id, duct2.ReferenceLevel.Id, xiect2, ct2);
                // 复制参数
                Utils.CopyParameters(duct1, xieCT1);
                Utils.CopyParameters(duct2, xieCT2);
                // 【5】创建弯头
                Connector startct1 = Utils.FindConnector(newCT1, ct1);
                Connector startct2 = Utils.FindConnector(xieCT1, ct1);
                m_doc.Create.NewElbowFitting(startct1, startct2);
                Connector startfitting1 = Utils.FindConnector(xieCT1, xiect1);
                Connector startfitting2 = Utils.FindConnector(side1, xiect1);
                m_doc.Create.NewElbowFitting(startfitting1, startfitting2);
                Connector endct1 = Utils.FindConnector(newCT2, ct2);
                Connector endct2 = Utils.FindConnector(xieCT2, ct2);
                m_doc.Create.NewElbowFitting(endct1, endct2);
                Connector endfitting1 = Utils.FindConnector(xieCT2, xiect2);
                Connector endfitting2 = Utils.FindConnector(side2, xiect2);
                m_doc.Create.NewElbowFitting(endfitting1, endfitting2);

                // 【6】删除原管道
                m_doc.Delete(duct1.Id);
                m_doc.Delete(duct2.Id);

                // 【7】旋转三通到水平
                Line slope = Line.CreateBound(familyinstancePoint, familyinstancePoint+(endPoint-startPoint).Normalize()*300/304.8);
                Line level = Line.CreateBound(familyinstancePoint, familyinstancePoint + (teeCT2_1 - familyinstancePointZ2).Normalize() * 300 / 304.8);
                double angle = slope.Direction.AngleTo(level.Direction);

                Line axis = Line.CreateBound(familyinstancePoint, familyinstancePoint +(teeCT3_1 - teeCT3_2).Normalize() * 300 / 304.8);
                //TaskDialog.Show("a", (angle*180/Math.PI).ToString());
                ElementTransformUtils.RotateElement(m_doc, m_doc.GetElement(r0).Id, axis, angle);
                //三通主管上的两个连接件

                //Utils.DrawModelCurve(m_doc, xyzconnTee1, (Utils.GetClosedPt(m_doc.GetElement(r0), startConnPoint)));

                //判断旋转是否正确
                if (endPoint.Z<startPoint.Z)
                {
                    if (endConnPoint.Z < (Utils.GetClosedPt(m_doc.GetElement(r0), endConnPoint).Z))
                    {
                        ElementTransformUtils.RotateElement(m_doc, m_doc.GetElement(r0).Id, axis, 0 * angle);
                    }
                    else
                    {
                        ElementTransformUtils.RotateElement(m_doc, m_doc.GetElement(r0).Id, axis, -2 * angle);
                    }
                }
                else
                {
                    if (endConnPoint.Z > (Utils.GetClosedPt(m_doc.GetElement(r0), endConnPoint).Z))
                    {
                        ElementTransformUtils.RotateElement(m_doc, m_doc.GetElement(r0).Id, axis, 0 * angle);
                    }
                    else
                    {
                        ElementTransformUtils.RotateElement(m_doc, m_doc.GetElement(r0).Id, axis, -2 * angle);
                    }
                }

                // 【8】调整三通高度
                ElementTransformUtils.MoveElement(m_doc, m_doc.GetElement(r0).Id, familyinstancePointZ - familyinstancePoint);


                // 【9】连接三通与水平管
                //找连接件
                Connector startConnSide1 = Utils.FindConnector(side1, teeCT1_1);
                Connector endConnSide1 = Utils.FindConnector(m_doc.GetElement(r0), Utils.GetClosedPt(m_doc.GetElement(r0), teeCT1_1));
                Connector startConnSide2 = Utils.FindConnector(side2, teeCT2_1);
                Connector endConnSide2 = Utils.FindConnector(m_doc.GetElement(r0), Utils.GetClosedPt(m_doc.GetElement(r0), teeCT2_1));
                Connector startConnSide3 = Utils.FindConnector(side3, teeCT3_1);
                Connector endConnSide3 = Utils.FindConnector(m_doc.GetElement(r0), Utils.GetClosedPt(m_doc.GetElement(r0), teeCT3_1));

                if (Math.Abs( startConnSide1.Origin.Z - endConnSide1.Origin.Z)>0.01)
                {
                    ElementTransformUtils.MoveElement(m_doc, m_doc.GetElement(r0).Id, startConnSide1.Origin - endConnSide1.Origin);
                    startConnSide1.ConnectTo(endConnSide1);
                    startConnSide2.ConnectTo(endConnSide2);
                    startConnSide3.ConnectTo(endConnSide3);
                }
                else
                {
                    startConnSide1.ConnectTo(endConnSide1);
                    startConnSide2.ConnectTo(endConnSide2);
                    startConnSide3.ConnectTo(endConnSide3);
                }
                
                
               
                
               // m_doc.Delete(familyinstance.Id);

            }
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
