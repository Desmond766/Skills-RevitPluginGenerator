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
                        foreach (var item in gei.GetInstanceGeometry())
                        {
                            if (item is Solid solid1 && solid1.Volume > 0)
                            {
                                solid = solid1;
                                break;
                            }
                        }
                    }
                }
                ElementIntersectsSolidFilter solidFilter = new ElementIntersectsSolidFilter(solid);
                using (FilteredElementCollector conduitCol = new FilteredElementCollector(doc, doc.ActiveView.Id))
                {
                    List<ElementId> conduitIds = conduitCol.OfCategory(BuiltInCategory.OST_Conduit).OfClass(typeof(Conduit)).WherePasses(intersectsFilter).WherePasses(solidFilter).Cast<Conduit>().Where(p => (p.GetTypeId().GetElement(doc) as ConduitType).Name == "品成-拓扑线").Select(x => x.Id).ToList();
                    List<ElementId> conduitIdsCopy = conduitIds.Select(x => x).ToList();
                    //List<ElementId> conduitIdsCopy = (from id in conduitIds select id).ToList();
                    foreach (var item in conduitIdsCopy)
                    {
                        Conduit conduit = item.GetElement(doc) as Conduit;
                        Line line = conduit.GetLine();
                        XYZ sP = line.GetEndPoint(0);
                        XYZ eP = line.GetEndPoint(1);
                        if (nodeP.DistanceTo(sP) > 20 / 304.8 && nodeP.DistanceTo(eP) > 20 / 304.8)
                        {
                            conduitIds.Remove(item);
                        }
                    }
                    neighborList.Add(node.Id, conduitIds);
                }
            }
            foreach (var conduit in topologyLines)
            {
                List<ElementId> nodeIds = new List<ElementId>();

                Line line = (conduit.Location as LocationCurve).Curve as Line;
                XYZ point0 = line.GetEndPoint(0);
                XYZ point1 = line.GetEndPoint(1);
                BoundingBoxIntersectsFilter intersectsFilter0 = CreateIntersectsFilter(point0, 20 / 304.8);
                BoundingBoxIntersectsFilter intersectsFilter1 = CreateIntersectsFilter(point1, 20 / 304.8);
                ElementIntersectsSolidFilter solidFilter0 = GetSolidFilter(point0, null, 10 / 304.8, 10 / 304.8);
                ElementIntersectsSolidFilter solidFilter1 = GetSolidFilter(point1, null, 10 / 304.8, 10 / 304.8);
                LogicalOrFilter orFilter = new LogicalOrFilter(intersectsFilter0, intersectsFilter1);
                using (FilteredElementCollector nodeCol = new FilteredElementCollector(doc, doc.ActiveView.Id))
                {
                    nodeCol.OfCategory(BuiltInCategory.OST_GenericModel).OfClass(typeof(FamilyInstance)).WherePasses(orFilter).WherePasses(new ElementIntersectsElementFilter(conduit));

                    if (nodeCol.Count() > 0)
                    {
                        List<ElementId> nodeIds0 = nodeCol.Cast<FamilyInstance>().Where(x => x.Symbol.Name == "品成-拓扑节点").Select(y => y.Id).ToList();
                        nodeIds.AddRange(nodeIds0);
                    }

                }
                neighborList.Add(conduit.Id, nodeIds);
            }

            return neighborList;
        }
        // 创建盒过滤器
        private static BoundingBoxIntersectsFilter CreateIntersectsFilter(XYZ point, double length)
        {
            XYZ min = point - XYZ.BasisX * length - XYZ.BasisY * length - XYZ.BasisZ * length;
            XYZ max = point + XYZ.BasisX * length + XYZ.BasisY * length + XYZ.BasisZ * length;
            Outline outline = new Outline(min, max);
            BoundingBoxIntersectsFilter intersectsFilter = new BoundingBoxIntersectsFilter(outline);
            return intersectsFilter;
        }
        // 创建solid过滤器
        private static ElementIntersectsSolidFilter GetSolidFilter(XYZ conP, Connector con, double width, double height)
        {
            XYZ dir1 = XYZ.BasisX;
            XYZ dir2 = XYZ.BasisY;
            XYZ upDir = XYZ.BasisZ;
            XYZ conDownP = conP - upDir * height;
            XYZ p1 = conDownP + dir1 * width + dir2 * width;
            XYZ p2 = conDownP - dir1 * width + dir2 * width;
            XYZ p3 = conDownP - dir1 * width - dir2 * width;
            XYZ p4 = conDownP + dir1 * width - dir2 * width;
            //放样
            List<CurveLoop> loops = new List<CurveLoop>();
            List<Curve> curveList = new List<Curve> { Line.CreateBound(p1, p2), Line.CreateBound(p2, p3), Line.CreateBound(p3, p4), Line.CreateBound(p4, p1) };
            CurveLoop curveLoop = CurveLoop.Create(curveList);
            loops.Add(curveLoop);
            //拉伸
            //Solid solid = GeometryCreationUtilities.CreateExtrusionGeometry(loops, XYZ.BasisZ, cableTray.Height);
            Solid solid = GeometryCreationUtilities.CreateExtrusionGeometry(loops, upDir, height * 2);
            ElementIntersectsSolidFilter solidFilter = new ElementIntersectsSolidFilter(solid);

            return solidFilter;
        }
    }
    public static class Utils
    {
        // 获取路径长度
        public static double GetPathLength(this List<ElementId> ids, Document doc)
        {
            double length = 0;
            foreach (var id in ids)
            {
                if (id.GetElement(doc) is MEPCurve mepCurve)
                {
                    length += (mepCurve.Location as LocationCurve).Curve.Length;
                }
            }
            return length;
        }

        /// <summary>
        /// 获取组成该族实例的所有solid
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static List<Solid> GetAllSolids(Element element)
        {
            List<Solid> solids = new List<Solid>();

            // 设置几何选项，确保获取详细几何
            Options geomOptions = new Options
            {
                ComputeReferences = true,
                DetailLevel = ViewDetailLevel.Fine,
                IncludeNonVisibleObjects = false
            };

            GeometryElement geomElem = element.get_Geometry(geomOptions);

            if (geomElem != null)
            {
                foreach (GeometryObject geomObj in geomElem)
                {
                    if (geomObj is Solid solid && solid != null && solid.Volume > 0)
                    {
                        solids.Add(solid);
                    }
                    else if (geomObj is GeometryInstance geomInst)
                    {
                        ProcessGeometryInstance(geomInst, solids);
                    }
                }
            }

            return solids;
        }
        private static void ProcessGeometryInstance(GeometryInstance geomInst, List<Solid> solids)
        {
            // 获取实例的变换矩阵
            Transform transform = geomInst.Transform;

            // 获取实例的符号几何
            GeometryElement instGeomElem = geomInst.GetInstanceGeometry();

            foreach (GeometryObject instGeomObj in instGeomElem)
            {
                if (instGeomObj is Solid instSolid && instSolid != null && instSolid.Volume > 0)
                {
                    solids.Add(instSolid);
                }
                // 可根据需要处理其他几何类型，如Curve、Mesh等
            }
        }
        /// <summary>
        /// 创建共享参数
        /// </summary>
        /// <param name="doc"></param>
        public static void AddProjectParameterToSystemFamily(Document doc, string paraName, ParameterType type, BuiltInCategory builtInCategory)
        {
            // 获取 Document 的参数绑定
            BindingMap bindingMap = doc.ParameterBindings;
            RevitApplication app = doc.Application;

            // 定义参数名称
            string parameterName = paraName;

            // 创建 Shared Parameter Definition
            DefinitionFile defFile = app.OpenSharedParameterFile();
            if (defFile == null)
            {
                TaskDialog.Show("错误", "请先设置共享参数文件");
                return;
            }

            DefinitionGroup group = defFile.Groups.get_Item("MyParameters") ?? defFile.Groups.Create("MyParameters");
            Definition definition = group.Definitions.get_Item(parameterName) ??
                                    //group.Definitions.Create(parameterName, ParameterType.Text, true);
                                    group.Definitions.Create(new ExternalDefinitionCreationOptions(parameterName, type));

            // 将参数绑定到系统族（如墙、楼板）
            CategorySet categorySet = app.Create.NewCategorySet();
            categorySet.Insert(doc.Settings.Categories.get_Item(builtInCategory)); // 例如绑定到线管

            InstanceBinding instanceBinding = app.Create.NewInstanceBinding(categorySet);

            using (Transaction trans = new Transaction(doc, "添加项目参数"))
            {
                trans.Start();
                bindingMap.Insert(definition, instanceBinding, BuiltInParameterGroup.INVALID);
                trans.Commit();
            }

            //TaskDialog.Show("完成", "成功添加项目参数到系统族");
        }
    }

}
