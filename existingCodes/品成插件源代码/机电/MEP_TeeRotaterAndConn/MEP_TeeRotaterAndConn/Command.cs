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

namespace MEP_TeeRotaterAndConn
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public static string rbtn_Direction = "向上";
        public static string rbtn_Angle = "30";
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {

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

            // 配件的插入点
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
            //Line axis = Line.CreateBound(connTee1.Origin, connTee2.Origin);
            Line axis = Line.CreateBound(connTee1.Origin, new XYZ(connTee2.Origin.X, connTee2.Origin.Y, connTee1.Origin.Z));

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

                //  新生支管
                Pipe LPipe = null;
                XYZ secondPo = connfitting1.Origin + (connfitting1.Origin - familyinstancePoint) * 500 / 304.8;
                LPipe = Pipe.Create(doc, systemTypeId, pipe1.PipeType.Id, levelId, connfitting1.Origin, secondPo);
                
                //     复制参数
                Utils.CopyParameters(pipe1, LPipe);
                Connector con1 = Utils.FindConnector(LPipe, connfitting1.Origin);
                con1.ConnectTo(connfitting1);

                //  判断三通支管与是否目标支管对齐
                //  得到构件上的点
                LocationCurve locationCurve1 = doc.GetElement(r1).Location as LocationCurve;
                //目标支管上的两点
                XYZ firstPo = locationCurve1.Curve.GetEndPoint(0);
                XYZ firstPo1 = new XYZ(locationCurve1.Curve.GetEndPoint(1).X, locationCurve1.Curve.GetEndPoint(1).Y, firstPo.Z);
                //新生支管上一点在直线上的投影点
                XYZ pLine = Utils.GetProjectivePoint(firstPo, firstPo1, secondPo);
                //Utils.DrawModelCurve(doc, secondPo, pLine);

                //新生支管上一点与投影点的距离
                double dAB = pLine.DistanceTo(secondPo);
                //TaskDialog.Show("a", (dAB*304.8).ToString());


                Connector connEnd1 = Utils.FindConnectorCloseToPoint(LPipe, secondPo);
                Connector connEnd2 = Utils.FindConnectorCloseToPoint(pipe1, familyinstancePoint);

                ////如果距离不等于0，移动新生支管,再创建弯头
                if (dAB < 0.1)
                {
                    try
                    {
                        //  否则，直接创建弯头
                        doc.Create.NewElbowFitting(connEnd1, connEnd2);
                    }
                    catch (Exception)
                    {
                        TaskDialog.Show("提示", "空间太小，无法自动生成弯头，请手动连接；或返回修改三通旋转角度");
                    }
                }
                else
                {
                    TaskDialog.Show("提示：", "请确保三通与支管对齐。");
                    return Result.Cancelled;

                }

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
