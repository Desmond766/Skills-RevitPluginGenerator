using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System.IO;
using Autodesk.Revit.DB.Plumbing;
using System.Windows.Forms;

namespace MEP_OffsetProBefore
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public static double distance;
        public Result Execute(ExternalCommandData commandData, ref string message, Autodesk.Revit.DB.ElementSet elements)
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

            SettingForm sf = new SettingForm();
            if (DialogResult.OK != sf.ShowDialog())
            {
                return Result.Failed;
            }






            try
            {
                //选择配件
                while (true)
                {





                    Reference r0 = sel.PickObject(ObjectType.Element, new FamilyinstanceSelectionFilter(), "配件");

                    FamilyInstance familyinstance = doc.GetElement(r0) as FamilyInstance;
                    Location location = familyinstance.Location;
                    LocationPoint locationPoint = location as LocationPoint;


                    //配件的插入点
                    XYZ familyinstancePoint = locationPoint.Point;
                    XYZ otherPoint = new XYZ(familyinstancePoint.X, familyinstancePoint.Y, familyinstancePoint.Z + distance / 304.8);

                    //配件的连接件
                    ConnectorSet connectorSet = Utils.GetConSet(doc.GetElement(r0));
                    List<Connector> conList = new List<Connector>();
                    //配件主管上的两个连接件
                    foreach (Connector conn in connectorSet)
                    {
                        if (Utils.FindConnectedTo(conn) != null)
                        {
                            conList.Add(conn);
                        }
                    }
                    //得到与配件主管上与其重合的两个连接件
                    Connector connTee1;
                    Connector connTee2;
                    connTee1 = Utils.FindConnectedTo(conList[0]);
                    connTee2 = Utils.FindConnectedTo(conList[1]);

                    List<Connector> conTeeList = new List<Connector>();
                    conTeeList.Add(connTee1);
                    conTeeList.Add(connTee2);

                    //判断与其重合的两个连接件的所有者是配件
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


                    //找到配件连接到的主管
                    Element e = conpipeList[0].Owner;

                    // 管线
                    MEPCurve mepCurve1 = e as MEPCurve;
                    // 管线中心线
                    Line mepLine1 = (mepCurve1.Location as LocationCurve).Curve as Line;

                    // 原始属性
                    Parameter parameter = mepCurve1.get_Parameter(BuiltInParameter.RBS_START_LEVEL_PARAM);
                    ElementId levelId = parameter.AsElementId();

                    Pipe pipe1 = mepCurve1 as Pipe;
                    ElementId systemTypeId = pipe1.MEPSystem.GetTypeId();
                    PipeType pipeType = pipe1.PipeType;

                    using (Transaction t = new Transaction(doc, "喷淋升降分支"))
                    {
                        t.Start();

                        //【1】删除配件
                        doc.Delete(familyinstance.Id);
                        //【2】创建立管
                        Pipe LPipe = null;
                        LPipe = Pipe.Create(doc, systemTypeId, pipe1.PipeType.Id, levelId, familyinstancePoint, otherPoint);
                        //     复制参数
                        Utils.CopyParameters1(pipe1, LPipe);
                        LPipe.get_Parameter(BuiltInParameter.RBS_PIPE_DIAMETER_PARAM).Set(32 / 304.8);


                        //【3】创建主管处三通
                        FamilyInstance f2;
                        Connector connTee3 = Utils.FindConnector(LPipe, familyinstancePoint);
                        //【3.1】如果主管上有配件
                        if (confittingList.Count != 0)
                        {
                            //配件需移动的距离
                            XYZ offset2 = (confittingList[0].Origin - familyinstancePoint) * 600 / 304.8;
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

                            //【3.1.1】移动配件
                            ElementTransformUtils.MoveElement(doc, confittingList[0].Owner.Id, offset2);
                            //找到配件距离支管近的连接件
                            Connector connectorfitting = Utils.FindConnectorCloseToPoint(confittingList[0].Owner, familyinstancePoint);

                            //【3.1.2】补充主管
                            Pipe ZPipe1 = null;
                            ZPipe1 = Pipe.Create(doc, systemTypeId2, pipe2.PipeType.Id, levelId2, x, connectorfitting.Origin);
                            //     复制参数
                            Utils.CopyParameters(pipe2, ZPipe1);
                            //找到补充主管上距离支管近的连接件
                            Connector connectorZPipe = Utils.FindConnectorCloseToPoint(ZPipe1, familyinstancePoint);
                            //【3.1.3】创建主管处三通
                            f2 = doc.Create.NewTeeFitting(conpipeList[0], connectorZPipe, connTee3);
                        }
                        else
                        //【3.2】如果主管上没有配件
                        {
                            f2 = doc.Create.NewTeeFitting(connTee1, connTee2, connTee3);
                        }

                        //【4】创建喷淋支管处三通

                        //分别求出两侧喷淋支管的两点

                        XYZ fx = ((connTee1.Origin - connTee2.Origin).CrossProduct(otherPoint - familyinstancePoint)).Normalize();
                        XYZ ffx = fx.Negate();
                        XYZ z1Point1 = otherPoint + 100 / 304.8 * fx;
                        XYZ z1Point2 = otherPoint + 300 / 304.8 * fx;

                        XYZ z2Point1 = otherPoint + 100 / 304.8 * ffx;
                        XYZ z2Point2 = otherPoint + 300 / 304.8 * ffx;

                        //【4.1】补充两侧喷淋支管
                        Pipe zPipe1 = null;
                        zPipe1 = Pipe.Create(doc, systemTypeId, pipe1.PipeType.Id, levelId, z1Point1, z1Point2);
                        //     复制参数
                        Utils.CopyParameters1(pipe1, zPipe1);
                        zPipe1.get_Parameter(BuiltInParameter.RBS_PIPE_DIAMETER_PARAM).Set(32 / 304.8);

                        Pipe zPipe2 = null;
                        zPipe2 = Pipe.Create(doc, systemTypeId, pipe1.PipeType.Id, levelId, z2Point1, z2Point2);
                        //     复制参数
                        Utils.CopyParameters1(pipe1, zPipe2);
                        zPipe2.get_Parameter(BuiltInParameter.RBS_PIPE_DIAMETER_PARAM).Set(32 / 304.8);

                        //【4.2】创建喷淋支管处三通
                        FamilyInstance f1;
                        Connector zconn1 = Utils.FindConnectorCloseToPoint(zPipe1, otherPoint);
                        Connector zconn2 = Utils.FindConnectorCloseToPoint(zPipe2, otherPoint);
                        Connector zconn3 = Utils.FindConnectorCloseToPoint(LPipe, otherPoint);
                        f1 = doc.Create.NewTeeFitting(zconn1, zconn2, zconn3);

                        //【4.3】删除补充的两侧喷淋支管
                        doc.Delete(zPipe1.Id);
                        doc.Delete(zPipe2.Id);


                        t.Commit();
                    }






                }
            }
            catch (Exception)
            {
            }




            return Result.Succeeded;


        }



        class FamilyinstanceSelectionFilter : ISelectionFilter
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
}
