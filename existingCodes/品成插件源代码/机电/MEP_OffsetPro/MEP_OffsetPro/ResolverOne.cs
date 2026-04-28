using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.DB.Mechanical;

namespace MEP_OffsetPro
{

    class ResolverOne
    {
        #region 字段属性

        private UIApplication m_uiapp;
        private Document m_doc;

        // 错误信息
        private static string _message;
        public static string Message
        {
            get { return ResolverOne._message; }
            set { ResolverOne._message = value; }
        }

        // 升降距离
        private static double _distance;
        public static double Distance
        {
            get { return ResolverOne._distance; }
            set { ResolverOne._distance = value; }
        }

        #endregion
        // 构造函数
        public ResolverOne(ExternalCommandData commandData)
        {
            m_uiapp = commandData.Application;
            m_doc = m_uiapp.ActiveUIDocument.Document;
        }
        //方法
        public void Resolve(Reference r0, Reference r1)
        {
            // 原配件
            FamilyInstance familyinstance = m_doc.GetElement(r0) as FamilyInstance;
            Location location = familyinstance.Location;
            LocationPoint locationPoint = location as LocationPoint;

            // 原管线
            MEPCurve mepCurve1 = m_doc.GetElement(r1) as MEPCurve;
            // 原管线中心线
            Line mepLine1 = (mepCurve1.Location as LocationCurve).Curve as Line;

            // 原始属性
            Parameter parameter = mepCurve1.get_Parameter(BuiltInParameter.RBS_START_LEVEL_PARAM);
            ElementId levelId = parameter.AsElementId();

            Pipe pipe1 = mepCurve1 as Pipe;
            ElementId systemTypeId = pipe1.MEPSystem.GetTypeId();
            PipeType pipeType = pipe1.PipeType;

            // 喷淋支管需升降的距离
            XYZ offset1 = XYZ.BasisZ * Distance / 304.8;
            // 生成立管的两点
            XYZ familyinstancePoint = new XYZ();
            XYZ otherPoint = new XYZ();
            familyinstancePoint = locationPoint.Point;
            otherPoint = new XYZ(familyinstancePoint.X, familyinstancePoint.Y, familyinstancePoint.Z + Distance / 304.8);

            // 原配件上的连接件
            ConnectorSet connectorSet = Utils.GetConSet(m_doc.GetElement(r0));
            List<Connector> conList = new List<Connector>();
            List<Connector> connTee3ZList = new List<Connector>();
            Connector connTee3Z;
            //得到原配件主管上的两个连接件
            //得到原配件支管上的一个连接件
            foreach (Connector conn in connectorSet)
            {
                if (Utils.FindConnectedTo(conn).Owner.Id.IntegerValue != pipe1.Id.IntegerValue)
                {
                    conList.Add(conn);//得到原配件主管上的两个连接件
                }
                else
                {
                    connTee3ZList.Add(conn);//得到原配件支管上的一个连接件
                }
            }
            connTee3Z = connTee3ZList[0];
            //if (conList[0].Origin.Z - conList[1].Origin.Z < 0.05)
            //{
            //    connTee3Z = conList[2];
            //}
            //else if (conList[0].Origin.Z - conList[2].Origin.Z < 0.05)
            //{
            //    connTee3Z = conList[1];
            //}
            //else
            //{
            //    connTee3Z = conList[0];
            //}



            //得到与原配件主管上与其重合的两个连接件
            Connector connTee1 = Utils.FindConnectedTo(conList[0]);
            Connector connTee2 = Utils.FindConnectedTo(conList[1]);
            List<Connector> conTeeList = new List<Connector>();
            conTeeList.Add(connTee1);
            conTeeList.Add(connTee2);



            // 判断主管上的连接件的所有者是配件
            List<Connector> confittingList = new List<Connector>();
            List<Connector> conpipeList = new List<Connector>();
            foreach (Connector conn in conTeeList)
            {
                if (!(conn.Owner is Pipe))
                {
                    confittingList.Add(conn);
                }
                else
                {
                    conpipeList.Add(conn);
                }
            }


            //得到与原配件支管上其重合的一个连接件
            //TaskDialog.Show("a", conList1.Count.ToString() + "/" + conList.Count.ToString());
            Connector connTee3Zc = Utils.FindConnectedTo(connTee3Z);


            //【1】判断点击的配件与主管之间是否已有爬升,如果有

            //double dis = mepLine1.Origin.Z-familyinstancePoint.Z;
            //if (dis >0.05)
            //{
            //    //【1.1删除配件、立管、弯头,将支管移到与主管同一高度位置】
                
            //    //立管
            //    Element e1 = connTee3Zc.Owner;

            //    // 立管的连接件
            //    ConnectorSet connectorSetL = Utils.GetConSet(connTee3Zc.Owner);
            //    List<Connector> conListL = new List<Connector>();
            //    //得到立管上的另一个连接件
            //    foreach (Connector conn in connectorSetL)
            //    {
            //        if (conn != connTee3Zc)
            //        {
            //            conListL.Add(conn);
            //        }
            //    }
            //    //得到与其重合的一个连接件
            //    Connector connTeeW = Utils.FindConnectedTo(conListL[0]);
            //    //弯头
            //    Element e2 = connTeeW.Owner;

            //    //删除配件
            //    m_doc.Delete(familyinstance.Id);
            //    //删除立管
            //    m_doc.Delete(e1.Id);
            //    //删除弯头
            //    m_doc.Delete(e2.Id);

            //    ElementTransformUtils.MoveElement(m_doc, pipe1.Id, XYZ.BasisZ * dis);

            //}
            //else
            //{
               
            //}

            //【1】删除配件
            m_doc.Delete(familyinstance.Id);
            //【2】移动喷淋支管
            ElementTransformUtils.MoveElement(m_doc, pipe1.Id, offset1);
            //【3】创建立管
            Pipe LPipe = null;
            LPipe = Pipe.Create(m_doc, systemTypeId, pipe1.PipeType.Id, levelId, familyinstancePoint, otherPoint);
            //     复制参数
            Utils.CopyParameters(pipe1, LPipe);

            //【4】创建喷淋支管处弯头
            Connector conn1 = Utils.FindConnector(LPipe, otherPoint);
            Connector conn2 = Utils.FindConnector(pipe1, otherPoint);
            FamilyInstance f1 = m_doc.Create.NewElbowFitting(conn1, conn2);

            #region 【5】创建主管处三通
            //【5】创建主管处三通
            FamilyInstance f2;
            Connector connTee3 = Utils.FindConnector(LPipe, familyinstancePoint);
            //【5.1】如果主管上有配件
            if (confittingList.Count != 0)
            {
                //配件需移动的距离
                XYZ offset2 = (confittingList[0].Origin - familyinstancePoint) * 100 / 304.8;
                XYZ x = confittingList[0].Origin;

                // 主管
                MEPCurve mepCurve2 = conpipeList[0].Owner as MEPCurve;
                // 原主管线中心线
                Line mepLine2 = (mepCurve2.Location as LocationCurve).Curve as Line;
                Pipe pipe2 = mepCurve2 as Pipe;
                ElementId systemTypeId2 = pipe2.MEPSystem.GetTypeId();
                PipeType pipeType2 = pipe2.PipeType;
                // 原始属性
                Parameter parameter2 = mepCurve2.get_Parameter(BuiltInParameter.RBS_START_LEVEL_PARAM);
                ElementId levelId2 = parameter2.AsElementId();

                //【5.1.1】移动配件
                ElementTransformUtils.MoveElement(m_doc, confittingList[0].Owner.Id, offset2);
                //找到配件距离支管近的连接件
                Connector connectorfitting = Utils.FindConnectorCloseToPoint(confittingList[0].Owner, familyinstancePoint);
                //【5.1.2】补充主管
                Pipe ZPipe1 = null;
                ZPipe1 = Pipe.Create(m_doc, systemTypeId2, pipe2.PipeType.Id, levelId2, x, connectorfitting.Origin);
                //     复制参数
                Utils.CopyParameters(pipe2, ZPipe1);
                //找到补充主管上距离支管近的连接件
                Connector connectorZPipe = Utils.FindConnectorCloseToPoint(ZPipe1, familyinstancePoint);
                //【5.1.3】创建主管处三通
                f2 = m_doc.Create.NewTeeFitting(conpipeList[0], connectorZPipe, connTee3);

                m_doc.Delete(ZPipe1.Id);
                Connector connectorf21 = Utils.FindConnectorFarToPoint(f2, connectorfitting.Origin);
                connectorfitting.ConnectTo(connectorf21);

            }
            //【5.2】如果主管上没有有配件，直接创建主管处三通
            else
            {
                f2 = m_doc.Create.NewTeeFitting(connTee1, connTee2, connTee3);
            }

            #endregion

        }
    }
}
