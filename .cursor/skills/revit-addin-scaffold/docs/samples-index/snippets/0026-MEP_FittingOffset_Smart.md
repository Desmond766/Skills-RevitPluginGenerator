# Sample Snippet: MEP_FittingOffset_Smart

Source project: `existingCodes\品成插件源代码\机电\MEP_FittingOffset_Smart\MEP_FittingOffset_Smart`

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

namespace MEP_FittingOffset_Smart
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
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

            //选择桥架三通
            //多选
            IList<Reference> allRef = sel.PickObjects(ObjectType.Element, new CTTeeSelectionFilter(),"框选要排列的桥架三通");
            List<Element> list = new List<Element>();
            foreach (Reference item in allRef)
            {
                list.Add(doc.GetElement(item));
            }

            //选择基准三通
            Reference firstPick = sel.PickObject(ObjectType.Element, new CTTeeSelectionFilter(), "选择基准三通");
            Element firstEle = doc.GetElement(firstPick);


            //排序要爬升的三通
            list = list.OrderBy(u => (u.Location as LocationPoint).Point.DistanceTo((firstEle.Location as LocationPoint).Point)).ToList();
            if (list[0].Id == firstEle.Id)
            {
                list.RemoveAt(0);//将基准三通移出要移动的list
            }

            

            Resolver resolver = new Resolver(commandData);
            int index = 0;
            double _distance = 200;

            using (Transaction t = new Transaction(doc, "机电管线避让"))
            {
                t.Start();
                //while (true)
                //{
                //    try
                //    {
                //        Reference r1 = sel.PickObject(ObjectType.Element, "选择桥架三通");
                //        index++;
                //        _distance = 200 * index;
                //        resolver.Resolve(r1, _distance);
                //    }
                //    catch (Exception ex)
                //    {

                //        if (ex.Message == "The user aborted the pick operation.")
                //        {
                //            break;
                //        }
                //    }
                //}

                foreach (Element ele in list)
                {
                    index++;
                    _distance = 200 * index;
                    resolver.Resolve(ele, _distance);
                }

                t.Commit();
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

namespace MEP_FittingOffset_Smart
{
    class Utils
    {
        #region 获得连接到的构件
        /// <summary>
        /// 获得连接到的构件
        /// </summary>
        /// <param name="elem"></param>
        public static List<Element> FindConnectedToList(Element elem)
        {
            List<Element> connToList = new List<Element>();
            // 获得conSet
            ConnectorSet conSet = Utils.GetConSet(elem);
            foreach (Connector con in conSet)
            {
                Connector connToCon = Utils.FindConnectedTo(con);
                if (null != connToCon)
                {
                    connToList.Add(connToCon.Owner);
                }
            }
            return connToList;
        }
        #endregion

        #region 获得ConSet
        /// <summary>
        /// 获得ConSet
        /// </summary>
        /// <param name="elem"></param>
        /// <returns></returns>
        public static ConnectorSet GetConSet(Element elem)
        {
            // 获得conSet
            ConnectorSet conSet = null;
            if (elem is MEPCurve)
            {
                conSet = (elem as MEPCurve).ConnectorManager.Connectors;
            }
            else if (elem is FamilyInstance)
            {
                conSet = (elem as FamilyInstance).MEPModel.ConnectorManager.Connectors;
            }
            return conSet;
        }
        #endregion

        #region FindConnectedTo
        /// <summary>
        /// FindConnectedTo
        /// </summary>
        /// <param name="curve"></param>
        /// <param name="conXYZ"></param>
        /// <returns></returns>
        public static Connector FindConnectedTo(Connector connItself)
        {
            ConnectorSet connSet = connItself.AllRefs;
            foreach (Connector conn in connSet)
            {
                if (conn.Owner.Id.IntegerValue != connItself.Owner.Id.IntegerValue
                    && conn.ConnectorType != ConnectorType.Logical)//&& conn.ConnectorType == ConnectorType.End
                {
                    return conn;
                }
            }
            return null;
        }
        #endregion

        #region 获得两段线的端点，按顺序排列
        /// <summary>
        /// 获得两段线的端点，按顺序排列
        /// </summary>
        /// <param name="line1"></param>
        /// <param name="line2"></param>
        /// <returns></returns>
        public static List<XYZ> GetEndPoint(Line line1, Line line2)
// ... truncated ...
```

