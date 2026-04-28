using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System.Collections.Generic;

namespace ParameterizedMEPCurveLayout
{
    /// <summary>
    /// 主程序 废弃！ 未使用
    /// </summary>
    public class StatrApplication
    {
        public static void Main(UIDocument uidoc)
        {
            Document doc = uidoc.Document;
            //过滤管线 框选元素 并单机获取一点
            MEPCurveFilter filter = new MEPCurveFilter();
            IList<Reference> refs = uidoc.Selection.PickObjects(ObjectType.Element, filter, "请框选管线");
            XYZ point = uidoc.Selection.PickPoint();
            //截断的中间管线
            IList<MEPCurve> mEPCurves = new List<MEPCurve>();
            //遍历元素 打断管线
            List<MEPCurveGroup> mEPCurveGroups = new List<MEPCurveGroup>();
            using (Transaction tran = new Transaction(doc, "打断管线"))
            {
                tran.Start();
                foreach (Reference item in refs)
                {
                    MEPCurve elem = doc.GetElement(item) as MEPCurve;
                    Curve curve = (elem.Location as LocationCurve).Curve;
                    //获取投影点
                    XYZ breakCurve = curve.Project(point).XYZPoint;
                    XYZ point1 = new XYZ(breakCurve.X - 1000 / 304.8, breakCurve.Y, breakCurve.Z);
                    XYZ point2 = new XYZ(breakCurve.X + 1000 / 304.8, breakCurve.Y, breakCurve.Z);
                    if (!Tools.HorizontalDirection(elem))
                    {
                        XYZ temp = point1;
                        point1 = point2;
                        point2 = temp;
                    }
                    MEPCurve newMEPCurve1 = MEPCurveOperation.BreakCurve(doc, elem, point1);
                    MEPCurve newMEPCurve2 = MEPCurveOperation.BreakCurve(doc, newMEPCurve1, point2);
                    //mEPCurves.Add(elem);
                    MEPCurveGroup mEPCurveGroup = new MEPCurveGroup();
                    mEPCurveGroup.code = newMEPCurve1.Id.ToString();
                    mEPCurveGroup.list = new List<MEPCurve> { elem, newMEPCurve1, newMEPCurve2 };
                    mEPCurves.Add(newMEPCurve1);
                    mEPCurveGroups.Add(mEPCurveGroup);
                    //mEPCurves.Add(newMEPCurve2);
                }
                tran.Commit();
            }
            MEPCurveOperation.MEPCurveGroupSort(doc, mEPCurves, 1);
            using (Transaction tran = new Transaction(doc, "重新连接排序"))
            {
                tran.Start();
                foreach (MEPCurveGroup item in mEPCurveGroups)
                {
                    Connector startConnector = null;
                    Connector endConnector = null;
                    foreach (Connector con in item.list[0].ConnectorManager.Connectors)
                    {
                        if (con.Id == 1)
                        {
                            startConnector = con;
                        }
                    }
                    foreach (Connector con in item.list[2].ConnectorManager.Connectors)
                    {
                        if (con.Id == 0)
                        {
                            endConnector = con;
                        }
                    }
                    foreach (Connector con in item.list[1].ConnectorManager.Connectors)
                    {
                        if (con.Id == 0)
                        {
                            startConnector.ConnectTo(con);
                        }
                        if (con.Id == 1)
                        {
                            endConnector.ConnectTo(con);
                        }
                    }
                }
                foreach (MEPCurve mEP in mEPCurves)
                {
                    XYZ targetPoint = Tools.GetMEPCurveCentrePoint(mEP);
                    Tools.MoveMEPCurve(doc, mEP, new XYZ(targetPoint.X, targetPoint.Y + 1, targetPoint.Z));
                    Tools.MoveMEPCurve(doc, mEP, new XYZ(targetPoint.X, targetPoint.Y - 1, targetPoint.Z));
                }
                tran.Commit();
            }
        }
    }
}
