# Sample Snippet: MEP_OffsetOverturner

Source project: `existingCodes\品成插件源代码\机电\MEP_OffsetOverturner\MEP_OffsetOverturner`

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
using System.IO;

namespace MEP_OffsetOverturner
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, Autodesk.Revit.DB.ElementSet elements)
        {
            #region 判断加密
            //注册验证
            string licFile = string.Format("{0}\\Key.lic",
    System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
            if (!BTAddInHelper.Utils.CheckReg(licFile))
            {
                return Result.Cancelled;
            }
            #endregion

            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;

            try
            {
                while (true)
                {

                    //拾取翻起部分的水平管线
                    Reference r = sel.PickObject(ObjectType.Element,"拾取原翻弯部分的水平管线");
                    Element elem = doc.GetElement(r);
                    if (elem is MEPCurve)
                    {
                        Resolver resolver = new Resolver(commandData);
                        using (Transaction t = new Transaction(doc, "翻转翻弯"))
                        {
                            t.Start();
                            resolver.Resolve(r);
                            t.Commit();

                        }
                    }
                    else if (elem is FamilyInstance)
                    {
                        ConnectorSet connSet = Utils.GetConSet(elem);
                        List<Connector> connList = Utils.GetConList(connSet);
                        if (connList.Count == 3)//三通
                        {
                            bool b1 = Utils.IsAlmostEqual(connList[0].Origin.Z, connList[1].Origin.Z);
                            bool b2 = Utils.IsAlmostEqual(connList[0].Origin.Z, connList[2].Origin.Z);
                            if (b1 == true && b2 == true)//水平三通
                            {
                                ResolverForHorTee resolverForHorTee = new ResolverForHorTee(commandData);
                                using (Transaction t = new Transaction(doc, "翻转水平三通翻弯"))
                                {
                                    t.Start();
                                    resolverForHorTee.Resolver(r);
                                    t.Commit();

                                }
                               
                            }
                            else//垂直三通
                            {
                                ResolverForVerTee resolverForVerTee = new ResolverForVerTee(commandData);
                                using (Transaction t = new Transaction(doc, "取消水平三通翻弯"))
                                {
                                    t.Start();
                                    resolverForVerTee.Resolver(r);
                                    t.Commit();
                                }
                            }
                        }
                        else if (connList.Count == 4)//四通
                        {
                            ResolverForCross resolverForCross = new ResolverForCross(commandData);
                            using (Transaction t = new Transaction(doc, "翻转四通翻弯"))
                            {
                                t.Start();
                                resolverForCross.Resolver(r);
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

namespace MEP_OffsetOverturner
{
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

        #region 获得指定连接件连接到的构件
        /// <summary>
        /// 获得指定连接件连接到的构件
        /// </summary>
        /// <param name="pipe">管道</param>
        /// <param name="conXYZ">位置</param>
        /// <returns>连接件</returns>
        public static Element FindConnectorToElem(Element elem, XYZ conXYZ)
        {
            Element goalElem = null;
            List<Element> elemList = FindConnectedToList(elem);
            foreach (Element element in elemList)
            {
                ConnectorSet connSet = GetConSet(element);
                foreach (Connector conn in connSet)
                {
                    if (conn.Origin.IsAlmostEqualTo(conXYZ))
                    {
                        goalElem = conn.Owner;
                    }
                }
            }

            return goalElem;
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
// ... truncated ...
```

