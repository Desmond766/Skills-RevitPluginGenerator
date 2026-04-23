using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.DB.Mechanical;

namespace MEP_SmartOffset
{
    class Resolver
    {
        #region 字段属性
        private UIApplication m_uiapp;
        private Document m_doc;

        // 角度
        private static double _angle;
        public static double Angle
        {
            get { return Resolver._angle; }
            set { Resolver._angle = value; }
        }

        // 爬升距离
        private static double _distance;
        public static double Distance
        {
            get { return Resolver._distance; }
            set { Resolver._distance = value; }
        }

        //水平间距
        private static double _distanceHor;
        public static double DistanceHor
        {
            get { return Resolver._distanceHor; }
            set { Resolver._distanceHor = value; }
        }

        // 关键点
        XYZ intersetPtMax;
        XYZ intersetPtMin;
        XYZ startPoint;
        XYZ endPoint;
        XYZ pickPoint1;
        XYZ pickPoint2;
        XYZ offset;
        XYZ offsetPoint1;
        XYZ offsetPoint2;
        XYZ angleOffset;
        


        #endregion

        #region 构造函数
        // 构造函数
        public Resolver(ExternalCommandData commandData)
        {
            m_uiapp = commandData.Application;
            m_doc = m_uiapp.ActiveUIDocument.Document;
        }
        #endregion

        //方法
        public void Resolve(Reference r1,IList<Reference> iList)
        {
            //找到与其碰撞的管线
            //List<Element> listIntersetEle = Utils.FindInterset(m_doc, m_doc.GetElement(r1));

            List<Element> listIntersetEle = new List<Element>();
            foreach (var reference in iList)
            {
                Element e = m_doc.GetElement(reference);
                listIntersetEle.Add(e);
            }

            //障碍构件的box
            BoundingBoxXYZ boxR1 = m_doc.GetElement(r1).get_BoundingBox(m_doc.ActiveView);
            XYZ r1PtMax = boxR1.Max;
            XYZ r1PtMin = boxR1.Min;

            //


            //List<Element> list = new List<Element>();
            //TaskDialog.Show("a", list.Count.ToString());



            foreach (Element intersetEle in listIntersetEle)
            {
                if (intersetEle is MEPCurve)
                {
                    // 原管线
                    MEPCurve mepCurve = intersetEle as MEPCurve;
                    // 原管线中心线 
                    Line mepLine = (mepCurve.Location as LocationCurve).Curve as Line;

                    intersetPtMax = Utils.GetProjectivePoint(mepLine, r1PtMax);
                    intersetPtMin = Utils.GetProjectivePoint(mepLine, r1PtMin);
                    // 设置起点终点
                    if (mepLine.GetEndPoint(0).DistanceTo(intersetPtMax) < mepLine.GetEndPoint(0).DistanceTo(intersetPtMin))
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
                    
                    // 障碍管道与要爬升管道的碰撞高度
                    double d = 0.0;
                    // 计算得出管道要爬升的高度
                    double dis = 0.0;
                    if (_distance>0)
                    {
                        d = (r1PtMax.Z - intersetPtMax.Z) * 304.8;
                    }
                    else
                    {
                        d = ( r1PtMin.Z-intersetPtMin.Z ) * 304.8;//负数
                    }
                    dis = _distance + d;

                    // 根据爬升距离计算偏移量
                    offset = XYZ.BasisZ * dis / 304.8;
                
                    // 根据水平间距计算两个爬升点
                    offsetPoint1 = intersetPtMax + (startPoint - intersetPtMax).Normalize() * _distanceHor / 304.8 + offset;
                    offsetPoint2 = intersetPtMin + (endPoint - intersetPtMin).Normalize() * _distanceHor / 304.8 + offset;

                    // 角度产生的偏移
                    if (_angle == 90.0)
                    {
                        angleOffset = XYZ.Zero;
                    }
                    else
                    {
                        angleOffset = forward.Normalize() * (Math.Abs(dis / 304.8) / Math.Tan(Math.PI * _angle / 180.0));
                    }
                    //根据角度计算拾取点
                    pickPoint1 = intersetPtMax + (startPoint - intersetPtMax).Normalize() * _distanceHor / 304.8 - angleOffset;
                    pickPoint2 = intersetPtMin + (endPoint - intersetPtMin).Normalize() * _distanceHor / 304.8 + angleOffset;

                    // 起点、终点连接件
                    Connector startConn = Utils.FindConnectedTo(mepCurve, startPoint);
                    Connector endConn = Utils.FindConnectedTo(mepCurve, endPoint);

                    //生成管道
                    MEPCurve g1 = null;
                    MEPCurve g2 = null;
                    if (startConn != null)
                    {
                        g1 = MEPHelper.CreateMEPCurve(m_doc, mepCurve, startConn, pickPoint1);
                    }
                    else
                    {
                        g1 = MEPHelper.CreateMEPCurve(m_doc, mepCurve, startPoint, pickPoint1);
                    }

                    MEPCurve zhiG1 = MEPHelper.CreateMEPCurve(m_doc, mepCurve, pickPoint1, offsetPoint1);
                    MEPCurve zhiG = MEPHelper.CreateMEPCurve(m_doc, mepCurve, offsetPoint1, offsetPoint2);
                    MEPCurve zhiG2 = MEPHelper.CreateMEPCurve(m_doc, mepCurve, pickPoint2, offsetPoint2);
                    if (endConn != null)
                    {
                        g2 = MEPHelper.CreateMEPCurve(m_doc, mepCurve, pickPoint2, endConn);
                    }
                    else
                    {
                        g2 = MEPHelper.CreateMEPCurve(m_doc, mepCurve, pickPoint2, endPoint);
                    }

                    //生成弯头
                    MEPHelper.CreateElbowFitting(m_doc, pickPoint1, g1, zhiG1);
                    MEPHelper.CreateElbowFitting(m_doc, offsetPoint1, zhiG1, zhiG);
                    MEPHelper.CreateElbowFitting(m_doc, offsetPoint2, zhiG, zhiG2);
                    MEPHelper.CreateElbowFitting(m_doc, pickPoint2, zhiG2, g2);

                    // 删除原管道
                    m_doc.Delete(intersetEle.Id);

                    //Utils.DrawModelCurve(m_doc, startPoint, pickPoint1);
                    //Utils.DrawModelCurve(m_doc, pickPoint1, offsetPoint1);
                    //Utils.DrawModelCurve(m_doc, offsetPoint1, offsetPoint2);
                    //Utils.DrawModelCurve(m_doc, offsetPoint2, pickPoint2);
                    //Utils.DrawModelCurve(m_doc, pickPoint2, endPoint);
                }
            }


        }

    }
}
