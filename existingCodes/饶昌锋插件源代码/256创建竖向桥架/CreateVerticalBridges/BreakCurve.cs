using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace CreateVerticalBridges
{
    public class BreakCurve
    {
        /// <summary>
        /// 一个点打断管
        /// </summary>
        public static MEPCurve BreakMEPCurve(Document doc, MEPCurve mEPCurve, XYZ breakXYZ)
        {

            //拷贝一根管
            ICollection<ElementId> ids = ElementTransformUtils.CopyElement(doc, mEPCurve.Id, new XYZ(0, 0, 0));
            ElementId newId = ids.FirstOrDefault();
            MEPCurve mEPCurveCopy = doc.GetElement(newId) as MEPCurve;


            //原来管的线
            Curve curve = (mEPCurve.Location as LocationCurve).Curve;
            XYZ startXYZ = curve.GetEndPoint(0);
            XYZ endXYZ = curve.GetEndPoint(1);

            //映射点
            breakXYZ = curve.Project(breakXYZ).XYZPoint;

            //给原来的管用的线
            Line line = Line.CreateBound(startXYZ, breakXYZ);

            //拷贝管用的线
            Line line2 = Line.CreateBound(breakXYZ, endXYZ);

            //管1连接的连接器
            Connector otherCon = null;
            //解除管1连接的连接器 并获得连接的其它连接器
            foreach (Connector con in mEPCurve.ConnectorManager.Connectors)
            {
                bool isBreak = false;
                if (con.Id == 1 && con.IsConnected)
                {
                    foreach (Connector con2 in con.AllRefs)
                    {
                        if (con2.Owner is FamilyInstance)
                        {
                            con.DisconnectFrom(con2);
                            otherCon = con2;
                            isBreak = true;
                            break;
                        }
                    }
                }
                if (isBreak)
                {
                    break;
                }
            }


            //改原来的管
            (mEPCurve.Location as LocationCurve).Curve = line;

            //改现在的管
            (mEPCurveCopy.Location as LocationCurve).Curve = line2;

            //让拷贝的管连接原来管连接的连接器
            if (otherCon != null)
            {

                foreach (Connector con in mEPCurveCopy.ConnectorManager.Connectors)
                {
                    if (con.Id == 1)
                    {
                        con.ConnectTo(otherCon);
                    }
                }
            }
            return mEPCurveCopy;
        }
    }
}
