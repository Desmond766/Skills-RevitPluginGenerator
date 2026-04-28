using Autodesk.Revit.DB;
using Autodesk.Revit.Exceptions;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OperationCanceledException = Autodesk.Revit.Exceptions.OperationCanceledException;

namespace ParameterizedMEPCurveLayout
{
    public class GetTargetMEPCurve
    {
        /// <summary>
        /// 获取元素 并打断
        /// </summary>
        /// <param name="uidoc"></param>
        /// <param name="mEPCurves"></param>
        /// <param name="mEPCurveGroups"></param>
        public static void GetMEPCurveElement(UIDocument uidoc, ref IList<MEPCurve> mEPCurves, ref List<MEPCurveGroup> mEPCurveGroups)
        {
            Document doc = uidoc.Document;
            //过滤管线 框选元素 并单机获取一点
            MEPCurveFilter filter = new MEPCurveFilter();
            IList<Reference> refs;
            RevitUtils.ListenUtils listenUtils = new RevitUtils.ListenUtils();
            try
            {
                listenUtils.startListen();
                refs = uidoc.Selection.PickObjects(ObjectType.Element, filter, "请框选管线（按空格键完成框选，ESC键取消）");
                listenUtils.stopListen();
            }
            catch (OperationCanceledException)
            {
                listenUtils.stopListen();
                throw;
            }
            XYZ point = uidoc.Selection.PickPoint();
            ////截断的中间管线
            //IList<MEPCurve> mEPCurves = new List<MEPCurve>();
            ////遍历元素 打断管线
            //List<MEPCurveGroup> mEPCurveGroups = new List<MEPCurveGroup>();
            using (Transaction tran = new Transaction(doc, "打断管线"))
            {
                tran.Start();
                foreach (Reference item in refs)
                {
                    MEPCurve elem = doc.GetElement(item) as MEPCurve;
                    Curve curve = (elem.Location as LocationCurve).Curve;
                    //获取投影点
                    XYZ breakCurve = curve.Project(point).XYZPoint;
                    XYZ point1;
                    XYZ point2;
                    if (Tools.IsHorizontal(elem))
                    {
                        point1 = new XYZ(breakCurve.X - 150 / 304.8, breakCurve.Y, breakCurve.Z);
                        point2 = new XYZ(breakCurve.X + 150 / 304.8, breakCurve.Y, breakCurve.Z);
                        if (!Tools.HorizontalDirection(elem))
                        {
                            XYZ temp = point1;
                            point1 = point2;
                            point2 = temp;
                        }
                    }
                    else
                    {
                        point1 = new XYZ(breakCurve.X, breakCurve.Y - 150 / 304.8, breakCurve.Z);
                        point2 = new XYZ(breakCurve.X, breakCurve.Y + 150 / 304.8, breakCurve.Z);
                        if (!Tools.VerticalDirection(elem))
                        {
                            XYZ temp = point1;
                            point1 = point2;
                            point2 = temp;
                        }
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
        }
    }
}
