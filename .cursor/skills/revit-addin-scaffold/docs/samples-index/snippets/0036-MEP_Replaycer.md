# Sample Snippet: MEP_Replaycer

Source project: `existingCodes\品成插件源代码\机电\MEP_Replaycer\MEP_Replaycer`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System.Windows.Forms;
using System.IO;


namespace MEP_Replaycer
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public static string type = "标高刷";
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
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
                while (true)
                {
                    if (type == "标高刷")
                    {
                        ReplaycerForOffset replaycerForOffset = new ReplaycerForOffset(commandData);
                        using (Transaction t = new Transaction(doc, "标高刷"))
                        {
                            t.Start();

                            //选择管线
                            Reference reference = sel.PickObject(ObjectType.Element, new MEPCurveSelectionFilter(), "请选择一根管线,收集标高");
                            replaycerForOffset.Replaycer(reference);

                            t.Commit();
                        }
                    }
                    else if (type == "系统刷")
                    {
                        RepalycerForSystemType replaycerForSystemType = new RepalycerForSystemType(commandData);
                        using (Transaction t = new Transaction(doc, "系统刷"))
                        {
                            t.Start();

                            //选择管线
                            Reference reference = sel.PickObject(ObjectType.Element, new MEPCurveSelectionFilter(), "请选择一根管线,收集系统");
                            replaycerForSystemType.Replaycer(reference);

                            t.Commit();
                        }
                    }
                    else
                    {
                        ReplaycerForSize replaycerForSize = new ReplaycerForSize(commandData);
                        using (Transaction t = new Transaction(doc, "管径刷"))
                        {
                            t.Start();

                            //选择管线
                            Reference reference = sel.PickObject(ObjectType.Element, new MEPCurveSelectionFilter(), "请选择一根管线,收集管径");
                            replaycerForSize.Replaycer(reference);

                            t.Commit();
                        }
                    }
                }
            }
            catch (Exception)
            {

            }


            return Result.Succeeded;
        }
    }
}
// ... truncated ...
```

## Utils.cs

```csharp
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MEP_Replaycer
{
    enum FittingType { Transition, Elbow, Tee, Cross };
    enum DuctElbowType { ElbowPlane, ElbowOffset };

    class Utils
    {
        #region 获得点在直线上的投影点坐标
        /// <summary>
        /// 获得点在直线上的投影点坐标
        /// </summary>
        /// <param name="p1">直线起点</param>
        /// <param name="p2">直线终点</param>
        /// <param name="q">直线外的点</param>
        /// <returns>投影点</returns>
        public static XYZ GetProjectivePoint(XYZ p1, XYZ p2, XYZ q)
        {
            XYZ u = p2 - p1;
            XYZ pq = q - p1;
            XYZ w2 = pq - u.Multiply(pq.DotProduct(u) / (u.GetLength() * u.GetLength()));
            XYZ point = q - w2;
            return point;
        }

        /// <summary>
        /// 获得点在直线上的投影点坐标
        /// </summary>
        /// <param name="l">直线</param>
        /// <param name="q">直线外的点</param>
        /// <returns>投影点</returns>
        public static XYZ GetProjectivePoint(Line l, XYZ q)
        {
            XYZ u = l.Direction;
            XYZ pq = q - l.GetEndPoint(0);
            XYZ w2 = pq - u.Multiply(pq.DotProduct(u) / (u.GetLength() * u.GetLength()));
            XYZ point = q - w2;
            return point;
        }

        #endregion

        #region 获得指定位置处管道的连接件
        /// <summary>
        /// 获得指定位置处管道的连接件
        /// </summary>
        /// <param name="pipe">管道</param>
        /// <param name="conXYZ">位置</param>
        /// <returns>连接件</returns>
        public static Connector FindConnector(MEPCurve curve, XYZ conXYZ)
        {
            ConnectorSet conns = curve.ConnectorManager.Connectors;
            foreach (Connector conn in conns)
            {
                if (conn.Origin.IsAlmostEqualTo(conXYZ))
                {
                    return conn;
                }
            }
            return null;
        }
        #endregion

        #region 获得指定位置处管道连接对象的连接件
        /// <summary>
        /// 获得指定位置处管道连接对象的连接件
        /// </summary>
        /// <param name="pipe">管道</param>
        /// <param name="conXYZ">位置</param>
        /// <returns>连接件</returns>
        public static Connector FindConnectedTo(MEPCurve curve, XYZ conXYZ)
        {
            Connector connItself = FindConnector(curve, conXYZ);
            ConnectorSet connSet = connItself.AllRefs;
            foreach (Connector conn in connSet)
            {
                if (conn.Owner.Id.IntegerValue != curve.Id.IntegerValue &&
                    conn.ConnectorType == ConnectorType.End)
// ... truncated ...
```

