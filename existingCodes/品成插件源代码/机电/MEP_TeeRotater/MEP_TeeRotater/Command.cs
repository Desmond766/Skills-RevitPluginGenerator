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
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.DB.Electrical;

namespace MEP_TeeRotater
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public static string rbtn_Direction = "向上";
        public static string rbtn_Angle = "30";

        public Result Execute(ExternalCommandData commandData, ref string message, Autodesk.Revit.DB.ElementSet elements)
        {

            //        //注册验证
            //        string licFile = string.Format("{0}\\Key.lic",
            //System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
            //        if (!BTAddInHelper.Utils.CheckReg(licFile))
            //        {
            //            return Result.Cancelled;
            //        }

            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;


            //弹出设置窗口
            using (SettingForm sf = new SettingForm())
            {
                if (DialogResult.OK != sf.ShowDialog())
                {
                    return Result.Failed;
                }
            }
           
           
            //r0选择的三通，r1选择的支管
            Reference r0 = sel.PickObject(ObjectType.Element, new FamilyinstanceSelectionFilter(), "请选择要旋转的三通");
            Reference r1 = sel.PickObject(ObjectType.Element, "请选择要与三通连接的支管");

            FamilyInstance familyinstance = doc.GetElement(r0) as FamilyInstance;
            Location location = familyinstance.Location;
            LocationPoint locationPoint = location as LocationPoint;

            //配件的插入点
            XYZ familyinstancePoint = locationPoint.Point;

            // 原管线
            MEPCurve mepCurve1 = doc.GetElement(r1) as MEPCurve;
            // 原管线中心线
            Line mepLine1 = (mepCurve1.Location as LocationCurve).Curve as Line;

            // 原始属性
            Parameter parameter = mepCurve1.get_Parameter(BuiltInParameter.RBS_START_LEVEL_PARAM);
            ElementId levelId = parameter.AsElementId();

            Pipe pipe1 = mepCurve1 as Pipe;
            ElementId systemTypeId = pipe1.MEPSystem.GetTypeId();
            PipeType pipeType = pipe1.PipeType;



            //得到管线距离配件近的连接件
            Connector connPipe1 = Utils.FindConnectorCloseToPoint(doc.GetElement(r1), familyinstancePoint);

            //配件的连接件
            ConnectorSet connectorSet = Utils.GetConSet(doc.GetElement(r0));
            List<Connector> conList = new List<Connector>();
            List<Connector> con3List = new List<Connector>();
            //配件主管上的两个连接件
            foreach (Connector conn in connectorSet)
            {
                if (Utils.FindConnectedTo(conn) != null)
                {
                    conList.Add(conn);
                }
                else
                {
                    con3List.Add(conn);
                }
            }
            //得到与配件主管上与其重合的两个连接件
            Connector connTee1;
            Connector connTee2;
            connTee1 = Utils.FindConnectedTo(conList[0]);
            connTee2 = Utils.FindConnectedTo(conList[1]);

            //得到配件支管上的连接件
            Connector connfitting1 = con3List[0];
            XYZ x = connfitting1.Origin;

            //旋转轴
            Line axis = Line.CreateBound(connTee1.Origin, connTee2.Origin);

            //旋转角度
            double angle = Math.PI * ((double.Parse(rbtn_Angle.ToString())) / 180.0);



            using (Transaction t = new Transaction(doc, "旋转三通"))
            {
                t.Start();

                ElementTransformUtils.RotateElement(doc, doc.GetElement(r0).Id, axis, angle);
                //配件主管上的两个连接件
                foreach (Connector conn in connectorSet)
                {
                    if (Utils.FindConnectedTo(conn) != null)
                    {
                        conList.Add(conn);
                    }
                    else
                    {
                        con3List.Add(conn);
                    }
                }
                connfitting1 = con3List[0];
                //Utils.DrawModelCurve(doc, x, connfitting1.Origin);

                if (rbtn_Direction == "向上")
                {
                    if (connfitting1.Origin.Z > x.Z)
                    {
                        ElementTransformUtils.RotateElement(doc, doc.GetElement(r0).Id, axis, 0 * angle);
                    }
                    else
                    {
                        ElementTransformUtils.RotateElement(doc, doc.GetElement(r0).Id, axis, -2 * angle);
                    }

                }
                else
                {
                    if (connfitting1.Origin.Z < x.Z)
                    {
                        ElementTransformUtils.RotateElement(doc, doc.GetElement(r0).Id, axis, 0 * angle);
                    }
                    else
                    {
                        ElementTransformUtils.RotateElement(doc, doc.GetElement(r0).Id, axis, -2 * angle);
                    }
                }

                //Pipe LPipe = null;
                //LPipe = Pipe.Create(doc, systemTypeId, pipe1.PipeType.Id, levelId, connfitting1.Origin, connfitting1.Origin + (connfitting1.Origin - familyinstancePoint) * 500 / 304.8);

                ////     复制参数
                //Utils.CopyParameters(pipe1, LPipe);
                //Connector con1 = Utils.FindConnector(LPipe, connfitting1.Origin);
                //con1.ConnectTo(connfitting1);

                ////  创建弯头
                //Connector connEnd1 = Utils.FindConnector(LPipe, connfitting1.Origin + (connfitting1.Origin - familyinstancePoint) * 500 / 304.8);
                //Connector connEnd2 = Utils.FindConnectorCloseToPoint(pipe1, familyinstancePoint);
                //doc.Create.NewElbowFitting(connEnd1, connEnd2);

                t.Commit();
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
