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


    class ResolverTwo
    {
        #region 字段属性

        private UIApplication m_uiapp;
        private Document m_doc;

        // 错误信息
        private static string _message;
        public static string Message
        {
            get { return ResolverTwo._message; }
            set { ResolverTwo._message = value; }
        }


        // 升降距离
        private static double _distance;
        public static double Distance
        {
            get { return ResolverTwo._distance; }
            set { ResolverTwo._distance = value; }
        }

        // 立管管径
        private static double _diameter;
        public static double Diameter
        {
            get { return ResolverTwo._diameter; }
            set { ResolverTwo._diameter = value; }
        }

        #endregion

        // 构造函数
        public ResolverTwo(ExternalCommandData commandData)
        {
            m_uiapp = commandData.Application;
            m_doc = m_uiapp.ActiveUIDocument.Document;
        }
        //方法
        public void Resolve(Reference r0, Reference r1, Reference r2)
        {
            // 原配件
            FamilyInstance familyinstance = m_doc.GetElement(r0) as FamilyInstance;
            Location location = familyinstance.Location;
            LocationPoint locationPoint = location as LocationPoint;


            // 原管线
            MEPCurve mepCurve1 = m_doc.GetElement(r1) as MEPCurve;
            MEPCurve mepCurve2 = m_doc.GetElement(r2) as MEPCurve;
            // 原管线中心线
            Line mepLine1 = (mepCurve1.Location as LocationCurve).Curve as Line;
            Line mepLine2 = (mepCurve2.Location as LocationCurve).Curve as Line;

            // 原始属性
            Parameter parameter = mepCurve1.get_Parameter(BuiltInParameter.RBS_START_LEVEL_PARAM);
            ElementId levelId = parameter.AsElementId();
            // 原始属性
            Parameter parameter2 = mepCurve2.get_Parameter(BuiltInParameter.RBS_START_LEVEL_PARAM);
            ElementId levelId2 = parameter2.AsElementId();

            Pipe pipe1 = mepCurve1 as Pipe;
            ElementId systemTypeId = pipe1.MEPSystem.GetTypeId();
            PipeType pipeType = pipe1.PipeType;

            Pipe pipe2 = mepCurve2 as Pipe;
            ElementId systemTypeId2 = pipe2.MEPSystem.GetTypeId();
            PipeType pipeType2 = pipe2.PipeType;


            // 喷淋支管需升降的距离
            XYZ offset1 = XYZ.BasisZ * Distance / 304.8;
            // 生成立管的两点
            XYZ familyinstancePoint = new XYZ();
            XYZ otherPoint = new XYZ();
            familyinstancePoint = locationPoint.Point;
            otherPoint = new XYZ(familyinstancePoint.X, familyinstancePoint.Y, familyinstancePoint.Z + Distance / 304.8);

            // 原配件上的四个连接件
            ConnectorSet connectorSet = Utils.GetConSet(m_doc.GetElement(r0));
            if (connectorSet.Size != 4)
            {
                TaskDialog.Show("提示：", "若在设置时点选“双侧”，请选择四通");
                return;
            }




            //原配件上的四个连接件，其中，conList存放主管方向上的两个连接件
            List<Connector> conList = new List<Connector>();
            List<Connector> conZList = new List<Connector>();

            //得到与原配件主管上与其重合的两个连接件
            Connector connTee1;
            Connector connTee2;
            // 得到原配件主管上的两个连接件
            foreach (Connector conn in connectorSet)
            {
                if ((Utils.FindConnectedTo(conn).Owner.Id.IntegerValue != pipe1.Id.IntegerValue) && (Utils.FindConnectedTo(conn).Owner.Id.IntegerValue != pipe2.Id.IntegerValue))
                {
                    conList.Add(conn);//有可能大于2，因为原四通配件主管和支管上都有可能有变径配件,把支管上的连接件也加进去了
                }
            }
            //TaskDialog.Show("a", conList.Count.ToString());


            if (conList.Count > 2)
            //    支管上有配件
            {
                foreach (Connector conn in conList)
                {
                    if (Utils.FindConnectedTo((Utils.FindConnectorFarToPoint(Utils.FindConnectedTo(conn).Owner, familyinstancePoint))) != null)
                    {
                        if ((Utils.FindConnectedTo((Utils.FindConnectorFarToPoint(Utils.FindConnectedTo(conn).Owner, familyinstancePoint))).Owner.Id.IntegerValue != pipe1.Id.IntegerValue)
                            && (Utils.FindConnectedTo((Utils.FindConnectorFarToPoint(Utils.FindConnectedTo(conn).Owner, familyinstancePoint))).Owner.Id.IntegerValue != pipe2.Id.IntegerValue))
                        {
                            conZList.Add(conn);
                        }
                    }
                    else
                    {
                        conZList.Add(conn);
                    }
                }
                //TaskDialog.Show("a", conZList.Count.ToString());

                connTee1 = Utils.FindConnectedTo(conZList[0]);
                connTee2 = Utils.FindConnectedTo(conZList[1]);
            }
            else
            {
                connTee1 = Utils.FindConnectedTo(conList[0]);
                connTee2 = Utils.FindConnectedTo(conList[1]);
            }

            List<Connector> conTeeList = new List<Connector>();
            conTeeList.Add(connTee1);
            conTeeList.Add(connTee2);


            //【1】删除配件
            m_doc.Delete(familyinstance.Id);
            //【2】移动喷淋支管
            ElementTransformUtils.MoveElement(m_doc, pipe1.Id, offset1);
            ElementTransformUtils.MoveElement(m_doc, pipe2.Id, offset1);
            //【3】创建立管
            Pipe LPipe = null;
            LPipe = Pipe.Create(m_doc, systemTypeId, pipe1.PipeType.Id, levelId, new XYZ( familyinstancePoint.X,familyinstancePoint.Y,familyinstancePoint.Z+0.2), otherPoint);
            //     复制参数
            Utils.CopyParameters1(pipe1, LPipe);
            LPipe.get_Parameter(BuiltInParameter.RBS_PIPE_DIAMETER_PARAM).Set(Diameter / 304.8);

            #region 【4】创建喷淋支管处三通
            //【4】创建喷淋支管处三通
            FamilyInstance f1;
            Connector conn3 = Utils.FindConnector(LPipe, otherPoint);
            //Connector conn4;

            Connector conn1;
            Connector conn2;
            conn1 = Utils.FindConnector(pipe1, otherPoint);
            conn2 = Utils.FindConnector(pipe2, otherPoint);
            f1 = m_doc.Create.NewTeeFitting(conn1, conn2, conn3);
            #region
            //判断喷淋支管上要生成的三通处是否有配件
            //【4.1】如果喷淋支管上有配件
            //if (conn1 == null && conn2 != null)
            //{
            //    //找到支管上距中心近的连接件
            //    conn1 = Utils.FindConnectorCloseToPoint(m_doc.GetElement(r1), otherPoint);

            //    //配件
            //    Element ele = (Utils.FindConnectedTo(conn1)).Owner;

            //    //找到配件距中心近的连接件
            //    conn4 = Utils.FindConnectorCloseToPoint(ele, otherPoint);
            //    //记住这个点的位置
            //    XYZ x = conn4.Origin;

            //    //配件需移动的距离
            //    XYZ offset3 = (conn1.Origin - otherPoint) * 200 / 304.8;

            //    //【4.1.1】移动配件
            //    ElementTransformUtils.MoveElement(m_doc, ele.Id, offset3);
            //    //【4.1.2】补充支管
            //    Pipe ZPipe1 = null;
            //    ZPipe1 = Pipe.Create(m_doc, pipe2.PipeType.Id, levelId2, conn4, x);
            //    ////        复制参数
            //    //Utils.CopyParameters(pipe2, ZPipe1);
            //    //【4.1.3】创建三通
            //    conn1 = Utils.FindConnectorCloseToPoint(ZPipe1, otherPoint);
            //    f1 = m_doc.Create.NewTeeFitting(conn1, conn2, conn3);
            //}
            //else if (conn2 == null && conn1 != null)
            //{
            //    //找到支管上距中心近的连接件
            //    conn2 = Utils.FindConnectorCloseToPoint(m_doc.GetElement(r2), otherPoint);

            //    //配件
            //    Element ele = (Utils.FindConnectedTo(conn2)).Owner;

            //    //找到配件距中心近的连接件
            //    conn4 = Utils.FindConnectorCloseToPoint(ele, otherPoint);
            //    //记住这个点的位置
            //    XYZ x = conn4.Origin;

            //    //配件需移动的距离
            //    XYZ offset3 = (conn2.Origin - otherPoint) * 200 / 304.8;

            //    //【4.1.1】移动配件
            //    ElementTransformUtils.MoveElement(m_doc, ele.Id, offset3);
            //    //【4.1.2】补充支管
            //    Pipe ZPipe1 = null;
            //    ZPipe1 = Pipe.Create(m_doc, pipe1.PipeType.Id, levelId, conn4, x);
            //    //    //        复制参数
            //    //    Utils.CopyParameters(pipe2, ZPipe1);
            //    //【4.1.3】创建三通
            //    conn2 = Utils.FindConnectorCloseToPoint(ZPipe1, otherPoint);
            //    f1 = m_doc.Create.NewTeeFitting(conn1, conn2, conn3);
            //}
            //else
            ////【4.2】如果喷淋支管上没有配件
            //{
            //f1 = m_doc.Create.NewTeeFitting(conn1, conn2, conn3);
            //}
            #endregion
            #endregion

            #region 【5】创建主管处三通
            //【5】创建主管处三通
            FamilyInstance f2;
            Connector connTee3 = Utils.FindConnector(LPipe, familyinstancePoint);

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

            //【5.1】如果主管上有配件
            if (confittingList.Count != 0)
            {
                //配件需移动的距离
                XYZ offset2 = (confittingList[0].Origin - familyinstancePoint) * 600 / 304.8;
                XYZ x = confittingList[0].Origin;

                // 主管
                MEPCurve mepCurve0 = conpipeList[0].Owner as MEPCurve;
                // 原主管线中心线
                Line mepLine0 = (mepCurve0.Location as LocationCurve).Curve as Line;
                Pipe pipe0 = mepCurve0 as Pipe;
                ElementId systemTypeId0 = pipe0.MEPSystem.GetTypeId();
                PipeType pipeType0 = pipe0.PipeType;
                // 原始属性
                Parameter parameter0 = mepCurve0.get_Parameter(BuiltInParameter.RBS_START_LEVEL_PARAM);
                ElementId levelId0 = parameter0.AsElementId();

                //【5.1.1】移动配件
                ElementTransformUtils.MoveElement(m_doc, confittingList[0].Owner.Id, offset2);
                //找到配件距离支管近的连接件
                ConnectorSet connectorfittingSet = Utils.GetConSet(confittingList[0].Owner);
                List<Connector> connectorfittingList = new List<Connector>();
                Connector connectorfitting;
                foreach (Connector conn in connectorfittingSet)
                {
                    //double d = conn.Origin.DistanceTo(familyinstancePoint);
                    connectorfittingList.Add(conn);
                }
                if ((connectorfittingList[0].Origin.DistanceTo(familyinstancePoint)) < (connectorfittingList[1].Origin.DistanceTo(familyinstancePoint)))
                {
                    connectorfitting = connectorfittingList[0];
                }
                else
                {
                    connectorfitting = connectorfittingList[1];
                }
                //【5.1.2】补充主管
                Pipe ZPipe1 = null;
                ZPipe1 = Pipe.Create(m_doc, systemTypeId0, pipe0.PipeType.Id, levelId0, x, connectorfitting.Origin);
                //     复制参数
                Utils.CopyParameters(pipe0, ZPipe1);
                //找到补充主管上距离支管近的连接件
                ConnectorSet connectorZPipeSet = Utils.GetConSet(ZPipe1);
                List<Connector> connectorZPipeList = new List<Connector>();
                Connector connectorZPipe;
                foreach (Connector conn in connectorZPipeSet)
                {
                    connectorZPipeList.Add(conn);
                }
                if ((connectorZPipeList[0].Origin.DistanceTo(familyinstancePoint)) < (connectorZPipeList[1].Origin.DistanceTo(familyinstancePoint)))
                {
                    connectorZPipe = connectorZPipeList[0];
                }
                else
                {
                    connectorZPipe = connectorZPipeList[1];
                }
                //【5.1.3】创建主管处三通
                f2 = m_doc.Create.NewTeeFitting(conpipeList[0], connectorZPipe, connTee3);
            }
            //【5.2】如果主管上没有有配件，直接创建主管处三通
            else
            {
                f2 = m_doc.Create.NewTeeFitting(connTee1, connTee2, connTee3);
            }

            //Utils.DrawModelCurve(m_doc, familyinstancePoint, connTee1.Origin);
            //Utils.DrawModelCurve(m_doc, familyinstancePoint, connTee2.Origin);
            //Utils.DrawModelCurve(m_doc, familyinstancePoint, connTee3.Origin);
            #endregion

        }
    }
}