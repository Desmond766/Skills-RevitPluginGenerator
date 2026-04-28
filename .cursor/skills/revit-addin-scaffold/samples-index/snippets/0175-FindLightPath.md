# Sample Snippet: FindLightPath

Source project: `existingCodes\梁涛插件源代码\8.算量插件集合\拆分（旧）\FindLightPath\FindLightPath`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.Exceptions;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using Application = Microsoft.Office.Interop.Excel.Application;
using ArgumentException = Autodesk.Revit.Exceptions.ArgumentException;
using DataTable = System.Data.DataTable;
using Line = Autodesk.Revit.DB.Line;
using Outline = Autodesk.Revit.DB.Outline;
using View = Autodesk.Revit.DB.View;
using Application2 = Autodesk.Revit.ApplicationServices.Application;
using Parameter = Autodesk.Revit.DB.Parameter;

/* 1.选择导入CAD图中的分区多段线
 * 2.获取指定分区范围内的配电箱与灯具
 * 3.导入Excel表格，根据配电箱编号寻找经过灯具的主路由与副路由
 * 4.根据路径生成拓扑节点与拓扑线，并给拓扑线的路由参数赋值
 * （主路由赋值一次，副路由则需要赋值两次）
 */
namespace FindLightPath
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;
            ElementId levelId;
            string lightRoutePara;
            string boxRoutePara;
            string routeNum;

            // 收集灯具
            List<FamilyInstance> lightFixs = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_LightingFixtures).OfClass(typeof(FamilyInstance)).Cast<FamilyInstance>().ToList();

            // 收集照明线槽
            List<CableTray> lightCables = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_CableTray).OfClass(typeof(CableTray)).Where(c => c.Name.Contains("照明")).Cast<CableTray>().ToList();
            levelId = lightCables.First().get_Parameter(BuiltInParameter.RBS_START_LEVEL_PARAM).AsElementId();

            ConduitType BTConduitType = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Conduit).OfClass(typeof(ConduitType)).Cast<ConduitType>().Where(x => x.Name == "品成-拓扑线").FirstOrDefault();
            if (BTConduitType == null) AddNewConduitType(doc);
            BTConduitType = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Conduit).OfClass(typeof(ConduitType)).Cast<ConduitType>().Where(x => x.Name == "品成-拓扑线").FirstOrDefault();

            var startBoxRefer = sel.PickObject(ObjectType.Element, new BoxFilter(), "选择起始配电箱");
            var beginLightRefer = sel.PickObject(ObjectType.Element, new LightFilter(), "选择起始灯具");
            // 起始配电箱
            FamilyInstance startBox = doc.GetElement(startBoxRefer) as FamilyInstance;
            var boxPara = startBox.LookupParameter("电气-配电箱编号");
            if (boxPara != null && !string.IsNullOrEmpty(boxPara.AsString()))
                boxRoutePara = boxPara.AsString();
            else boxRoutePara = startBox.LookupParameter("路由").AsString();
            // 起始灯具
            FamilyInstance startLight = doc.GetElement(beginLightRefer) as FamilyInstance;
            var lightPara = startLight.LookupParameter("灯具编号");
            if (lightPara != null && !string.IsNullOrEmpty(lightPara.AsString()))
                lightRoutePara = lightPara.AsString();
            else lightRoutePara = startLight.LookupParameter("路由").AsString();

            // 拓扑线添加指定参数
            AddProjectParameterToSystemFamily(doc, "路由", ParameterType.Text);
            routeNum = boxRoutePara + ":" + lightRoutePara;

            //Element hostElem = startLight.Host;
            Element hostElem = startLight.GetHostElement(doc, XYZ.BasisZ, 2000 / 304.8);

            if (hostElem == null)
            {
                TaskDialog.Show("提示", "未找到被该灯具附着的照明线槽");
                return Result.Failed;
            }

            #region 获取灯具对应的宿主元素
            List<LightInfo> lightInfos = new List<LightInfo>();
            foreach (var light in lightFixs)
            {
// ... truncated ...
```

## RouteUtils.cs

```csharp
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using RevitApplication = Autodesk.Revit.ApplicationServices.Application;

namespace FindLightPath
{
    public class RouteUtils
    {
        /// <summary>
        /// 获取从起点到终点的所有路径
        /// </summary>
        /// <param name="neighborList">邻接表</param>
        /// <param name="staElemId">起始节点ID</param>
        /// <param name="endElemId">末端节点ID</param>
        /// <param name="runNum">每条回路循环寻找路径次数</param>
        /// <returns>paths</returns>
        public static List<List<ElementId>> GetAllPaths(Dictionary<ElementId, List<ElementId>> neighborList, ElementId staElemId, ElementId endElemId, out int count, int runNum)
        {
            List<List<ElementId>> result = new List<List<ElementId>>();
            Queue<List<ElementId>> queue = new Queue<List<ElementId>>();

            List<ElementId> firstList = new List<ElementId>() { staElemId };
            queue.Enqueue(firstList);

            count = 0;
            int firstFind = -1;

            while (queue.Count > 0)
            {
                count++;
                if (count >= runNum || (firstFind != -1 && firstFind < count))
                {
                    return result;
                }
                List<ElementId> path = queue.Dequeue();
                ElementId lastNode = path.Last();
                //如果从队列中取出id的最后一项等于结尾id，则返回完整路径的所有元素id
                if (lastNode == endElemId)
                {
                    result.Add(path);
                    firstFind = count + 20000;
                }
                else
                {
                    //如果当前领接表中没有任何key等于当前路径的元素id，则表示该路径不可到达终点，跳过
                    if (!neighborList.Keys.Contains(lastNode))
                    {
                        continue;
                    }
                    List<ElementId> neighbors = neighborList[lastNode];
                    foreach (ElementId neighborId in neighbors)
                    {
                        //sum++;
                        List<ElementId> newList = (from id in path select id).ToList();
                        if (!newList.Contains(neighborId))
                        {
                            newList.Add(neighborId);
                            queue.Enqueue(newList);
                        }
                    }
                }
            }
            return result;
        }
        // 获取邻接表
        public static Dictionary<ElementId, List<ElementId>> GetNeighborList(Document doc)
        {
            Dictionary<ElementId, List<ElementId>> neighborList = new Dictionary<ElementId, List<ElementId>>();

            List<FamilyInstance> nodes = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_GenericModel).OfClass(typeof(FamilyInstance)).Cast<FamilyInstance>().Where(x => x.Symbol.Name == "品成-拓扑节点").ToList();

            List<Conduit> topologyLines = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_Conduit).OfClass(typeof(Conduit)).Cast<Conduit>().Where(p => (p.GetTypeId().GetElement(doc) as ConduitType).Name == "品成-拓扑线").ToList();

            foreach (var node in nodes)
            {
                XYZ nodeP = (node.Location as LocationPoint).Point;
                BoundingBoxIntersectsFilter intersectsFilter = CreateIntersectsFilter(nodeP, 20 / 304.8);

                Solid solid = null;
                var gee = node.get_Geometry(new Options());
                foreach (var geo in gee)
                {
                    if (geo is GeometryInstance gei)
                    {
// ... truncated ...
```

## Utils.cs

```csharp
using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.DB.Macros;

namespace FindLightPath
{
    public static class CpoyUtils
    {
        /// <summary>
        /// 判断集合中是否包含该连接器
        /// </summary>
        /// <param name="createInfos"></param>
        /// <param name="connector"></param>
        /// <returns></returns>
        public static bool IsContains(this List<Connector> createInfos, Connector connector)
        {
            foreach (var item in createInfos)
            {
                if (item.Id == connector.Id && item.Owner.Id == connector.Owner.Id)
                {
                    return true;
                }
            }
            return false;
        }
        public static XYZ GetProjectionPoint(this XYZ point, Line line)
        {
            return line.Project(point).XYZPoint;
        }
        // 判断使用Line创建的族实例是否垂直
        public static bool IsVertical(this Element element)
        {
            if (element.Location is LocationCurve curve)
// ... truncated ...
```

