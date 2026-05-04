# Sample Snippet: MEP_OffsetCanceller

Source project: `existingCodes\品成插件源代码\机电\MEP_OffsetCanceller\MEP_OffsetCanceller`

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

namespace MEP_OffsetCanceller
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
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
                    Reference r = sel.PickObject(ObjectType.Element, "拾取翻弯部分的水平管线");
                    Element elem = doc.GetElement(r);
                    if (elem is MEPCurve)
                    {
                        Resolver resolver = new Resolver(commandData);
                        using (Transaction t = new Transaction(doc, "取消翻弯"))
                        {
                            t.Start();
                            resolver.Resolve(r);
                            t.Commit();

                        }
                    }
                    else if (elem is FamilyInstance)
                    {
                        ConnectorSet connSet =Utils.GetConSet(elem);
                        List<Connector> connList = Utils.GetConList(connSet);
                       
                        if (connList.Count==3)//三通
                        {
                            bool b1 = Utils.IsAlmostEqual(connList[0].Origin.Z, connList[1].Origin.Z);
                            bool b2 = Utils.IsAlmostEqual(connList[0].Origin.Z, connList[2].Origin.Z);
                            if (b1 == true && b2 == true)//水平三通
                            {
                                ResolverForHorTee resolverForHorTee = new ResolverForHorTee(commandData);
                                using (Transaction t = new Transaction(doc, "取消水平三通翻弯"))
                                {
                                    t.Start();
                                    resolverForHorTee.Resolver(r);
                                    t.Commit();
                                }
                            }
                            else//垂直三通
                            {
                                ResolverForVerTee resolverForVerTee = new ResolverForVerTee(commandData);
                                using (Transaction t = new Transaction(doc, "取消垂直三通翻弯"))
                                {
                                    t.Start();
                                    resolverForVerTee.Resolver(r);
                                    t.Commit();
                                }
                                
                            }
                        }
                        if (connList.Count == 4)//四通
                        {
                            ResolverForCross resolverForCross = new ResolverForCross(commandData);
                            using (Transaction t = new Transaction(doc, "取消四通翻弯"))
                            {
                                t.Start();
                                resolverForCross.Resolver(r);
                                t.Commit();
// ... truncated ...
```

## MEPHelper.cs

```csharp
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.DB.Plumbing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEP_OffsetCanceller
{
    class MEPHelper
    {
        public static MEPCurve Create(Document doc, MEPCurve mepCurve, XYZ startPoint, XYZ endPoint)
        {
            MEPCurve newCurve = null;

            //标高
            Parameter parameter = mepCurve.get_Parameter(BuiltInParameter.RBS_START_LEVEL_PARAM);
            ElementId levelId = parameter.AsElementId();

            if (mepCurve is Pipe)
            {
                Pipe pipe = mepCurve as Pipe;
                ElementId systemTypeId = pipe.MEPSystem.GetTypeId();
                PipeType pipeType = pipe.PipeType;
                //创建管道
                newCurve = Pipe.Create(doc, systemTypeId, pipeType.Id, levelId, startPoint, endPoint);
                //复制参数
                Utils.CopyParameters(pipe, newCurve as Pipe);
            }
            else if (mepCurve is Duct)
            {
                Duct duct = mepCurve as Duct;
                ElementId systemTypeId = duct.MEPSystem.GetTypeId();
                DuctType ductType = duct.DuctType;
                //创建风管
                newCurve = Duct.Create(doc, systemTypeId, ductType.Id, levelId, startPoint, endPoint);
                //复制参数
                Utils.CopyParameters(duct, newCurve as Duct);
                RotateFix(doc, newCurve, duct);
            }
            else if (mepCurve is CableTray)
            {
                CableTray cableTray = mepCurve as CableTray;
                ElementId cabletrayType = cableTray.GetTypeId();
                //创建桥架
                newCurve = CableTray.Create(doc, cabletrayType, startPoint, endPoint, levelId);
                //复制参数
                Utils.CopyParameters(cableTray, newCurve as CableTray);
                RotateFix(doc, newCurve, cableTray);
            }
            else if (mepCurve is Conduit)
            {
                Conduit conduit = mepCurve as Conduit;
                ElementId conduitType = conduit.GetTypeId();
                //创建线管
                newCurve = Conduit.Create(doc, conduitType, startPoint, endPoint, levelId);
                //复制参数
                Utils.CopyParameters(conduit, newCurve as Conduit);
            }

            //删除参考管线
            //doc.Delete(mepCurve.Id);

            return newCurve;
        }

        public static MEPCurve Create(Document document, MEPCurve mepCurve, Connector startConn, XYZ endPoint)
        {
            MEPCurve newCurve = Create(document, mepCurve, startConn.Origin, endPoint);
            Connector con = Utils.FindConnector(newCurve, startConn.Origin);
            startConn.ConnectTo(con);
            return newCurve;
        }

        public static MEPCurve Create(Document document, MEPCurve mepCurve, XYZ startPoint, Connector endConn)
        {
            MEPCurve newCurve = Create(document, mepCurve, startPoint, endConn.Origin);
            Connector con = Utils.FindConnector(newCurve, endConn.Origin);
            endConn.ConnectTo(con);
            return newCurve;
        }

        public static MEPCurve Create(Document document, MEPCurve mepCurve, Connector startConn, Connector endConn)
        {
            MEPCurve newCurve = Create(document, mepCurve, startConn.Origin, endConn.Origin);
            Connector con1 = Utils.FindConnector(newCurve, startConn.Origin);
            Connector con2 = Utils.FindConnector(newCurve, endConn.Origin);
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

namespace MEP_OffsetCanceller
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
// ... truncated ...
```

