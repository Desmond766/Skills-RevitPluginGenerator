using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.DB.Events;
using Autodesk.Revit.DB.Structure;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Application = Autodesk.Revit.ApplicationServices.Application;

namespace FindLightPath
{
    // 将桥架与桥架配件翻成拓扑线与拓扑节点
    [Transaction(TransactionMode.Manual)]
    public class ConnectAllCableTrayCmd : IExternalCommand
    {
        public List<Connector> fitHasConnect = new List<Connector>();

        public List<Connector> cabletrayHasConnect = new List<Connector>();

        ConduitType conduitType = null;

        ElementId levelId = null;

        FamilySymbol familySymbol = null;
        // 拓扑线实例集合
        List<Conduit> topologicalLines = new List<Conduit>();

        View3D view3D = null;
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Application app = commandData.Application.Application;
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;

            if (doc.ActiveView is View3D)
            {
                view3D = doc.ActiveView as View3D;
            }
            else
            {
                TaskDialog.Show("错误", "请在三维视图中运行插件");
                return Result.Cancelled;
            }

            DateTime beforDT = DateTime.Now;

            // 拓扑线族类型
            using (var conduitTypeCol = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Conduit).OfClass(typeof(ConduitType)))
            {
                conduitType = conduitTypeCol.Cast<ConduitType>().Where(x => x.Name == "品成-拓扑线").FirstOrDefault();
            }

            TransactionGroup TG2 = new TransactionGroup(doc, "载入族");
            if (conduitType == null)
            {

                TG2.Start();
                bool succeed = AddNewConduitType(doc);
                string dllPath = Assembly.GetExecutingAssembly().Location;

                string nodeFamilyPath = dllPath.Replace("QuantityTools.dll", "品成-拓扑节点.rfa");
                LoadFamily(doc, nodeFamilyPath);
                TG2.Assimilate();
                if (!succeed) return Result.Cancelled;
                using (var conduitTypeCol = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Conduit).OfClass(typeof(ConduitType)))
                {
                    conduitType = conduitTypeCol.Cast<ConduitType>().Where(x => x.Name == "品成-拓扑线").FirstOrDefault();
                }

            }
            // 拓扑节点族类型
            familySymbol = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_GenericModel).WhereElementIsElementType().Where(x => x.Name == "品成-拓扑节点").Cast<FamilySymbol>().FirstOrDefault();
            if (familySymbol == null)
            {
                TaskDialog.Show("Error", "未找到拓扑节点族");
                return Result.Cancelled;
            }
            // 添加拓扑线和节点需要用到的参数
            using (TransactionGroup TG3 = new TransactionGroup(doc, "添加项目参数"))
            {
                TG3.Start();

                Utils.AddProjectParameterToSystemFamily(doc, "对应桥架ID", ParameterType.Integer, BuiltInCategory.OST_Conduit);
                Utils.AddProjectParameterToSystemFamily(doc, "路由", ParameterType.Text, BuiltInCategory.OST_Conduit);
                Utils.AddProjectParameterToSystemFamily(doc, "对应桥架系统", ParameterType.Text, BuiltInCategory.OST_Conduit);
                Utils.AddProjectParameterToSystemFamily(doc, "灯具编号", ParameterType.Text, BuiltInCategory.OST_GenericModel);

                TG3.Commit();
            }

            List<ElementId> typeIds = new List<ElementId>();
            // 隔离选中元素并将后续方法作为外部事件来运行
            using (var cableCol = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_CableTray).OfClass(typeof(CableTray)))
            {
                var typeGroup = cableCol.GroupBy(c => c.GetTypeId());
                foreach (var item in typeGroup)
                {
                    if (!typeIds.Contains(item.Key)) typeIds.Add(item.Key);
                }
            }

            // -1.对没有全部连接竖向桥架进行隐藏

            HideVerCableTrays(doc);

            // 0.对水平相距非常近的桥架进行连接处理

            using (TransactionGroup TG4 = new TransactionGroup(doc, "基础桥架连接"))
            {
                TG4.Start();
                BasicConnect(doc);
                TG4.Assimilate();
            }
            // 桥架配件实例集合
            List<FamilyInstance> familyInstances = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_CableTrayFitting).WhereElementIsNotElementType().Cast<FamilyInstance>().ToList();
            // 桥架实例集合
            List<CableTray> cableTrays = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_CableTray).WhereElementIsNotElementType().Cast<CableTray>().ToList();
            // 标高
            levelId = cableTrays.First().LookupParameter("参照标高").AsElementId();

            // 拓扑节点实例集合
            List<FamilyInstance> nodes = new List<FamilyInstance>();

            List<HasConnectInfo> connectInfos = new List<HasConnectInfo>();

            TransactionGroup TG = new TransactionGroup(doc, "寻找最优路径");
            TG.Start();
            using (Transaction t = new Transaction(doc, "激活族类型"))
            {
                t.Start();
                if (!familySymbol.IsActive)
                {
                    familySymbol.Activate();
                }
                t.Commit();
            }

            // 1.基础连接
            // (1)创建拓扑节点并记录对应管件
            using (Transaction t1 = new Transaction(doc, "创建拓扑节点"))
            {
                t1.Start();
                foreach (var item in familyInstances)
                {
                    if (item.Symbol.FamilyName.Contains("异径"))
                    {
                        XYZ point1 = item.GetConnector(1).Origin;
                        FamilyInstance node1 = doc.Create.NewFamilyInstance(point1, familySymbol, StructuralType.NonStructural);
                        node1.LookupParameter("桥架配件ID").Set(item.Id.IntegerValue);
                        nodes.Add(node1);
                        XYZ point2 = item.GetConnector(2).Origin;
                        FamilyInstance node2 = doc.Create.NewFamilyInstance(point2, familySymbol, StructuralType.NonStructural);
                        node2.LookupParameter("桥架配件ID").Set(item.Id.IntegerValue);
                        nodes.Add(node2);

                        Conduit conduit = Conduit.Create(doc, conduitType.Id, point1, point2, levelId);
                        conduit.get_Parameter(BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS).Set("拓扑线");
                        conduit.get_Parameter(BuiltInParameter.RBS_CONDUIT_DIAMETER_PARAM).Set(6 / 304.8);

                        topologicalLines.Add(conduit);
                    }
                    else
                    {
                        XYZ point = (item.Location as LocationPoint).Point;
                        FamilyInstance node = doc.Create.NewFamilyInstance(point, familySymbol, StructuralType.NonStructural);
                        node.LookupParameter("桥架配件ID").Set(item.Id.IntegerValue);
                        nodes.Add(node);
                    }

                }
                t1.Commit();
            }

            // (2)如果是两管件连接，就在对应节点之间创建拓扑线
            foreach (var item in familyInstances)
            {
                foreach (Connector con in item.MEPModel.ConnectorManager.Connectors)
                {
                    if (con.IsConnected && !connectInfos.Any(x => x.FitId == item.Id && x.FitConId == con.Id))
                    {
                        Connector conRef = con.AllRefs.Cast<Connector>().First();
                        Element elem = conRef.Owner;
                        if (elem is FamilyInstance fit)
                        {
                            using (Transaction t2 = new Transaction(doc, "两连接管件相连"))
                            {
                                t2.Start();

                                connectInfos.Add(new HasConnectInfo() { FitConId = conRef.Id, FitId = elem.Id });
                                XYZ point1 = (item.Location as LocationPoint).Point;
                                XYZ point2 = (elem.Location as LocationPoint).Point;

                                if (point1.DistanceTo(point2) > 20 / 304.8)
                                {
                                    Conduit conduit = Conduit.Create(doc, conduitType.Id, point1, point2, levelId);
                                    conduit.get_Parameter(BuiltInParameter.RBS_CONDUIT_DIAMETER_PARAM).Set(6 / 304.8);
                                    conduit.get_Parameter(BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS).Set("拓扑线");
                                }


                                FamilyInstance node1 = nodes.First(x => x.LookupParameter("桥架配件ID").AsInteger() == item.Id.IntegerValue);
                                FamilyInstance node2 = nodes.First(x => x.LookupParameter("桥架配件ID").AsInteger() == elem.Id.IntegerValue);

                                string info = node1.Id.ToString() + "," + node2.Id.ToString();

                                t2.Commit();
                            }
                        }
                    }
                }
            }

            // (3)创建桥架对应拓扑线
            foreach (var item in cableTrays)
            {
                using (Transaction t3 = new Transaction(doc, "创建拓扑线"))
                {
                    t3.Start();
                    Curve curve = (item.Location as LocationCurve).Curve;
                    XYZ sp = curve.GetEndPoint(0);
                    XYZ ep = curve.GetEndPoint(1);

                    List<FamilyInstance> nodeInstances = new List<FamilyInstance>();

                    foreach (Connector con in item.ConnectorManager.Connectors)
                    {
                        if (!con.IsConnected) continue;
                        foreach (Connector conRef in con.AllRefs)
                        {
                            if (conRef.Owner is FamilyInstance fit)
                            {
                                if (fit.Symbol.FamilyName.Contains("异径"))
                                {
                                    FamilyInstance nodeInstance = nodes.Where(n => n.LookupParameter("桥架配件ID").AsInteger() == fit.Id.IntegerValue)
                                        .OrderBy(x => (x.Location as LocationPoint).Point.DistanceTo(con.Origin)).FirstOrDefault();
                                    if (nodeInstance == null) goto next;
                                    nodeInstances.Add(nodeInstance);


                                    XYZ fitP = (nodeInstance.Location as LocationPoint).Point;
                                    if (con.Id == 0)
                                    {
                                        sp = fitP;
                                    }
                                    else
                                    {
                                        ep = fitP;
                                    }
                                }
                                else
                                {
                                    FamilyInstance nodeInstance = nodes.Where(n => n.LookupParameter("桥架配件ID").AsInteger() == fit.Id.IntegerValue).FirstOrDefault();
                                    if (nodeInstance == null) goto next;
                                    nodeInstances.Add(nodeInstance);


                                    XYZ fitP = (fit.Location as LocationPoint).Point;
                                    if (con.Id == 0)
                                    {
                                        sp = fitP;
                                    }
                                    else
                                    {
                                        ep = fitP;
                                    }
                                }
                            }
                        }
                    }
                    Conduit conduit = Conduit.Create(doc, conduitType.Id, sp, ep, levelId);
                    conduit.get_Parameter(BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS).Set("拓扑线");
                    conduit.get_Parameter(BuiltInParameter.RBS_CONDUIT_DIAMETER_PARAM).Set(6 / 304.8);

                    conduit.LookupParameter("对应桥架ID").Set(item.Id.IntegerValue);

                    topologicalLines.Add(conduit);

                next:
                    t3.Commit();
                }
            }

            // (4)桥架上有连接的线管
            foreach (var item in cableTrays)
            {
                foreach (Connector con in item.ConnectorManager.Connectors)
                {
                    if (con.IsConnected && con.ConnectorType == ConnectorType.Curve)
                    {
                        var lines = topologicalLines.Where(x => x.LookupParameter("对应桥架ID").AsInteger() == item.Id.IntegerValue);

                        var breakLine = lines.Where(l => l.GetLine().Project(con.Origin).XYZPoint.IsPointOnLine(l.GetLine())).FirstOrDefault();
                        if (breakLine == null) continue;


                        using (Transaction t = new Transaction(doc, "打断拓扑线"))
                        {
                            t.Start();

                            ElementId newId = breakLine.BreakCurve(breakLine.GetLine().Project(con.Origin).XYZPoint, doc);
                            topologicalLines.Add(newId.GetElement(doc) as Conduit);

                            t.Commit();
                        }


                        foreach (Connector conRef in con.AllRefs)
                        {
                            if (conRef.Owner is Conduit conduit)
                            {
                                var points = new List<XYZ>();
                                var ids = new List<ElementId>();
                                points.Add(con.Origin);
                                GetAllConnect(conduit, ref ids);

                                foreach (var id in ids)
                                {
                                    Element elem = id.GetElement(doc);
                                    if (elem is FamilyInstance)
                                    {
                                        points.Add((elem.Location as LocationPoint).Point);
                                    }
                                }
                                if (ids.Last().GetElement(doc) is Conduit conduit1)
                                {
                                    foreach (Connector connector in conduit1.ConnectorManager.Connectors)
                                    {
                                        if (!connector.IsConnected)
                                        {
                                            points.Add(connector.Origin);
                                            break;
                                        }
                                        else if (connector.IsConnected)
                                        {
                                            foreach (Connector conRef1 in connector.AllRefs)
                                            {
                                                if (conRef1.Owner is FamilyInstance familyInstance && familyInstance.Symbol.FamilyName.Contains("接线盒"))
                                                {
                                                    points.Add(conRef1.Origin);
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                }
                                using (Transaction t = new Transaction(doc, "创建拓扑节点/线"))
                                {
                                    t.Start();
                                    for (int i = 0; i < points.Count - 1; i++)
                                    {
                                        XYZ p1 = points[i];
                                        XYZ p2 = points[i + 1];
                                        FamilyInstance node = doc.Create.NewFamilyInstance(p1, familySymbol, StructuralType.NonStructural);
                                        nodes.Add(node);
                                        Conduit newConduit = Conduit.Create(doc, conduitType.Id, p1, p2, levelId);
                                        newConduit.get_Parameter(BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS).Set("拓扑线");
                                        newConduit.get_Parameter(BuiltInParameter.RBS_CONDUIT_DIAMETER_PARAM).Set(6 / 304.8);
                                    }
                                    //FamilyInstance node2 = doc.Create.NewFamilyInstance(points.Last(), familySymbol, StructuralType.NonStructural);
                                    //nodes.Add(node2);
                                    t.Commit();
                                }
                            }
                        }
                    }
                }
            }
            DateTime afterDT = DateTime.Now;

            // 2.射线寻找管件
            ConnectFittingsWithRay(doc, nodes);

            DateTime afterDT2 = DateTime.Now;

            // 3.桥架间水平连接
            ParallelConnect(doc);

            DateTime afterDT3 = DateTime.Now;

            // 4.高差桥架间连接
            HighConnect(doc);

            DateTime afterDT4 = DateTime.Now;

            // 剩下未连接桥架配件的连接器
            List<Connector> otherFitCons = new List<Connector>();
            using (FilteredElementCollector fitCol = new FilteredElementCollector(doc))
            {
                var fits = fitCol.OfCategory(BuiltInCategory.OST_CableTrayFitting).WhereElementIsNotElementType().
                Cast<FamilyInstance>();
                foreach (var item in fits)
                {
                    foreach (Connector con in item.MEPModel.ConnectorManager.Connectors)
                    {
                        if (!con.IsConnected && !fitHasConnect.IsContains(con))
                        {
                            otherFitCons.Add(con);
                        }
                    }
                }
            }
            // 剩下未连接桥架的连接器
            List<Connector> otherCableCons = new List<Connector>();
            using (FilteredElementCollector cableCol = new FilteredElementCollector(doc))
            {
                var fits = cableCol.OfCategory(BuiltInCategory.OST_CableTray).WhereElementIsNotElementType().
                Cast<CableTray>();
                foreach (var item in fits)
                {
                    foreach (Connector con in item.ConnectorManager.Connectors)
                    {
                        if (!con.IsConnected && !cabletrayHasConnect.IsContains(con))
                        {
                            otherCableCons.Add(con);
                        }
                    }
                }
            }

            // 5.剩余未连接的桥架连接器判断连接(桥架配件与桥架)
            FinalCabletrayConnect(doc, otherCableCons, ref otherFitCons);

            DateTime afterDT5 = DateTime.Now;

            // 6.剩余未连接的桥架配件连接器判断连接（非平行的配件与配件，剩余的配件与桥架）
            FinalFittingsConnect(doc, ref otherFitCons);

            DateTime afterDT6 = DateTime.Now;

            //// 7.配电箱连接
            //ElectricBoxConnect(doc, routeInfos);

            DateTime afterDT7 = DateTime.Now;

            TG.Assimilate();

            // 8.收集未连接节点的拓扑线
            List<ElementId> conduitIds = GetUnconnectedLines(doc);
            var unConInfos = new List<UnconnectedInfo>();
            string text = "";
            foreach (var item in conduitIds)
            {
                unConInfos.Add(new UnconnectedInfo() { LineID = item });
                text += item.ToString() + "\n";
            }

            //System.IO.File.AppendAllText(@"C:\Users\Administrator\Desktop\新建文本文档 (3).txt", text);
            UnconnectedWindow unconnectedWindow = new UnconnectedWindow(unConInfos, uidoc);
            GlobalResources.UnconnectedWindow1 = unconnectedWindow;
            app.DocumentChanged += OnDocumentChanged;
            unconnectedWindow.Show();

            DateTime afterDT8 = DateTime.Now;

            TimeSpan ts = afterDT.Subtract(beforDT);
            TimeSpan ts2 = afterDT2.Subtract(afterDT);
            TimeSpan ts3 = afterDT3.Subtract(afterDT2);
            TimeSpan ts4 = afterDT4.Subtract(afterDT3);
            TimeSpan ts5 = afterDT5.Subtract(afterDT4);
            TimeSpan ts6 = afterDT6.Subtract(afterDT5);
            TimeSpan ts7 = afterDT7.Subtract(afterDT6);
            TimeSpan ts8 = afterDT8.Subtract(afterDT7);
            TimeSpan tsTotal = afterDT8.Subtract(beforDT);
            string info2 = "步骤一时长：" + ts.Minutes + ":" + ts.Seconds + "\n"
                + "步骤二时长：" + ts2 + "\n"
                + "步骤三时长：" + ts3 + "\n"
                + "步骤四时长：" + ts4 + "\n"
                + "步骤五时长：" + ts5 + "\n"
                + "步骤六时长：" + ts6 + "\n"
                + "步骤七时长：" + ts7 + "\n"
                + "步骤八时长：" + ts8 + "\n"
                + "总时长：" + tsTotal + "\n";
            TaskDialog.Show("DateTime总共花费", info2);


            return Result.Succeeded;
        }

        /// <summary>
        /// 对相距很近的同系统桥架进行合并操作
        /// </summary>
        /// <param name="doc"></param>
        private void BasicConnect(Document doc)
        {
            var basicCableCol = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_CableTray).OfClass(typeof(CableTray));
            List<CableTray> cableTrays = basicCableCol.Cast<CableTray>().ToList();
            basicCableCol.Dispose();

            List<ElementId> hasCons = new List<ElementId>();
            foreach (var cableTray in cableTrays)
            {
                try
                {
                    if (hasCons.Contains(cableTray.Id)) continue;
                }
                catch (Exception)
                {
                    continue;
                }
                ExclusionFilter exclusionFilter = new ExclusionFilter(new ElementId[] { cableTray.Id });
                ElementCategoryFilter categoryFilter = new ElementCategoryFilter(BuiltInCategory.OST_CableTray);


                //Next:
                //CableTray forCableTray = doc.GetElement(cableTray.Id) as CableTray;
                foreach (Connector con in cableTray.ConnectorManager.Connectors)
                {
                    ElementId elementId = cableTray.Id;
                    if (!con.IsConnected && !hasCons.Contains(elementId))
                    {
                        var insertFilter = CreateIntersectsFilter(con.Origin, 20 / 304.8);

                        ElementIntersectsSolidFilter solidFilter = GetSolidFilter(con.Origin, null, 20 / 304.8, 20 / 304.8);

                        var elemFilters = new List<ElementFilter>()
                        {
                            exclusionFilter, categoryFilter, insertFilter/*, solidFilter*/
                        };
                        LogicalAndFilter andFilter = new LogicalAndFilter(elemFilters);

                        using (var cableCol = new FilteredElementCollector(doc, doc.ActiveView.Id).OfClass(typeof(CableTray)).WherePasses(andFilter))
                        {
                            //cableCol.WherePasses(solidFilter);
                            //var leachCableTrays = cableCol.Cast<CableTray>().Where(x => x.Name == cableTray.Name && Math.Abs(x.Width - cableTray.Width) < 0.001).ToList();
                            List<ElementId> filterIds = cableCol.Select(c => c.Id).ToList();
                            if (filterIds.Count == 0) continue;

                            var filterCableCol = new FilteredElementCollector(doc, filterIds).WherePasses(solidFilter);
                            var leachCableTrays = filterCableCol.Cast<CableTray>().Where(x => x.Name == cableTray.Name && Math.Abs(x.Width - cableTray.Width) < 0.001).ToList();
                            filterCableCol.Dispose();

                            if (leachCableTrays.Count() > 0)
                            {
                                Connector nearCon;
                                CableTray nearCable = con.GetNearCableTray(leachCableTrays, out nearCon);
                                if (nearCon.IsConnected/* || hasCons.Contains(nearCable.Id)*/) continue;
                                XYZ dir1 = cableTray.GetLine().Direction;
                                XYZ dir2 = nearCable.GetLine().Direction;
                                if ((dir1.IsAlmostEqualTo(dir2, 0.1) || dir1.Negate().IsAlmostEqualTo(dir2, 0.1)) && Math.Abs(con.Origin.Z - nearCon.Origin.Z) < 0.001)
                                {
                                    XYZ p1 = cableTray.GetConnector((con.Id + 1) % 2).Origin;
                                    var nearCon2 = nearCable.GetConnector((nearCon.Id + 1) % 2);
                                    XYZ p2 = nearCon2.Origin;

                                    using (Transaction t = new Transaction(doc, "基础连接"))
                                    {
                                        t.Start();

                                        //con.ConnectTo(nearCon);

                                        Line newLine;
                                        if ((con.Id + 1) % 2 == 0)
                                        {
                                            newLine = Line.CreateBound(p1, p2);
                                        }
                                        else
                                        {
                                            newLine = Line.CreateBound(p2, p1);
                                        }
                                        //newLine = Line.CreateBound(p1, p2);
                                        (cableTray.Location as LocationCurve).Curve = newLine;

                                        Connector otherCon = null;
                                        if (nearCon2.IsConnected)
                                        {
                                            foreach (Connector item in nearCon2.AllRefs)
                                            {
                                                if (item.Owner.Id != nearCon2.Owner.Id)
                                                {
                                                    otherCon = item;
                                                    break;
                                                }
                                            }
                                        }
                                        hasCons.Add(nearCable.Id);
                                        doc.Delete(nearCable.Id);
                                        if (otherCon != null)
                                        {
                                            otherCon.ConnectTo(con);
                                        }

                                        t.Commit();
                                    }
                                    //goto Next;

                                }
                            }
                        }

                    }
                }
            }
        }

        /// <summary>
        /// 隐藏视图中所有未完全连接的竖向桥架(内部带事务)
        /// </summary>
        /// <param name="doc"></param>
        private void HideVerCableTrays(Document doc)
        {
            var hideIds = new List<ElementId>();
            // 获取垂直的桥架
            List<CableTray> cableTrays = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_CableTray).OfClass(typeof(CableTray)).Cast<CableTray>().Where(x => x.IsVertical()).ToList();
            foreach (var cableTray in cableTrays)
            {
                foreach (Connector con in cableTray.ConnectorManager.Connectors)
                {
                    if (!con.IsConnected)
                    {
                        hideIds.Add(con.Owner.Id);
                        break;
                    }
                }
            }
            if (hideIds.Count > 0)
            {
                using (Transaction t = new Transaction(doc, "临时隐藏竖向桥架"))
                {
                    t.Start();
                    doc.ActiveView.HideElementsTemporary(hideIds);
                    t.Commit();
                }
            }
        }

        private List<ElementId> GetUnconnectedLines(Document doc)
        {
            List<ElementId> ids = new List<ElementId>();
            // 获取所有拓扑节点
            List<FamilyInstance> nodes = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_GenericModel).OfClass(typeof(FamilyInstance)).Cast<FamilyInstance>().Where(x => x.Symbol.Name == "品成-拓扑节点").ToList();
            // 获取所有拓扑线
            List<Conduit> topologyLines = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_Conduit).OfClass(typeof(Conduit)).Cast<Conduit>().Where(p => (p.GetTypeId().GetElement(doc) as ConduitType).Name == "品成-拓扑线").ToList();
            // 获取所有配电箱/柜
            //var electricBoxs = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_ElectricalEquipment).OfClass(typeof(FamilyInstance))
            // .Cast<FamilyInstance>().Where(x => x.Symbol.FamilyName.Contains("配电箱") || x.Symbol.FamilyName.Contains("配电柜") || x.Symbol.FamilyName.Contains("控制箱"));
            // 快速过滤获取末端不存在节点或配电箱的拓扑线
            foreach (var conduit in topologicalLines)
            {
                ElementCategoryFilter categoryFilter = new ElementCategoryFilter(BuiltInCategory.OST_GenericModel);
                ElementCategoryFilter categoryFilter2 = new ElementCategoryFilter(BuiltInCategory.OST_ElectricalEquipment);
                LogicalOrFilter orFilter = new LogicalOrFilter(categoryFilter, categoryFilter2);

                Line line = conduit.GetLine();
                XYZ p0 = line.GetEndPoint(0);
                XYZ p1 = line.GetEndPoint(1);

                using (FilteredElementCollector nodeOrBoxCol = new FilteredElementCollector(doc, doc.ActiveView.Id))
                {
                    nodeOrBoxCol.WherePasses(orFilter).WherePasses(new BoundingBoxContainsPointFilter(p0)).WherePasses(new ElementIntersectsElementFilter(conduit));
                    if (nodeOrBoxCol.Count() == 0)
                    {
                        ids.Add(conduit.Id);
                        continue;
                    }
                }
                using (FilteredElementCollector nodeOrBoxCol = new FilteredElementCollector(doc, doc.ActiveView.Id))
                {
                    nodeOrBoxCol.WherePasses(orFilter).WherePasses(new BoundingBoxContainsPointFilter(p1)).WherePasses(new ElementIntersectsElementFilter(conduit));
                    if (nodeOrBoxCol.Count() == 0)
                    {
                        ids.Add(conduit.Id);
                    }
                }

            }
            return ids;
        }


        // 获取邻接表
        public Dictionary<ElementId, List<ElementId>> GetNeighborList(Document doc)
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
        /// <summary>
        /// 获取从起点到终点的所有路径
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="neighborList"></param>
        /// <param name="staElemId"></param>
        /// <param name="endElemId"></param>
        /// <param name="runNum">每条回路循环寻找路径次数</param>
        /// <returns>paths</returns>
        public List<List<ElementId>> GetAllPaths(UIDocument uidoc, Document doc, Dictionary<ElementId, List<ElementId>> neighborList, ElementId staElemId, ElementId endElemId, out int count, int runNum)
        {
            //var timeStart = DateTime.Now;
            List<List<ElementId>> result = new List<List<ElementId>>();
            Queue<List<ElementId>> queue = new Queue<List<ElementId>>();

            List<ElementId> firstList = new List<ElementId>() { staElemId };
            queue.Enqueue(firstList);

            count = 0;
            int firstFind = -1;
            //int sum = 0;
            while (queue.Count > 0)
            {
                count++;
                //if (count > 1000000)
                if (count >= runNum || (firstFind != -1 && firstFind < count))
                {
                    //TaskDialog.Show("revit", ">1000000"); // 10s(100000/1s)
                    return result;
                }
                List<ElementId> path = queue.Dequeue();
                ElementId lastNode = path.Last();
                //如果从队列中取出id的最后一项等于结尾id，则返回完整路径的所有元素id
                if (lastNode == endElemId)
                {
                    result.Add(path);
                    firstFind = count + 20000;
                    //return result;
                    //TaskDialog.Show("findPath", DateTime.Now.Subtract(timeStart).ToString());
                    //timeStart = DateTime.Now;
                    //if (count >= 200000) return result;// 节点最少路径非最短距离路径
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
                            //if (result.Count > 0)
                            //{
                            //    double resLength = result.Last().GetPathLength(doc);
                            //    double length = newList.GetPathLength(doc);
                            //    if (resLength >= length) queue.Enqueue(newList);
                            //}
                            //else
                            //{
                            //    queue.Enqueue(newList);
                            //}
                            queue.Enqueue(newList);

                            //uidoc.ShowElements(newList);
                            //uidoc.Selection.SetElementIds(newList);
                            //string info = "";
                            //foreach (var item in newList)
                            //{
                            //    info += item + "\n";
                            //}
                            //TaskDialog.Show("rvi", info);
                        }
                    }
                }
            }
            //TaskDialog.Show("rr", sum.ToString());
            //TaskDialog.Show("finally", DateTime.Now.Subtract(timeStart).ToString());
            return result;
        }

        // 剩余桥架配件连接器判断连接（配件与桥架都寻找，之前只判断了两平行配件）
        private void FinalFittingsConnect(Document doc, ref List<Connector> otherFitCons)
        {
            foreach (var item in otherFitCons)
            {
                string symbolName = item.Owner.Name;
                XYZ elemP = (item.Owner.Location as LocationPoint).Point;
                Element element = FindCableAndFitWithRay(doc, symbolName, 400 / 304.8, item);
                if (element == null) continue;

                if (element is FamilyInstance fit)
                {
                    XYZ fitP = (fit.Location as LocationPoint).Point;
                    using (Transaction t = new Transaction(doc, "创建拓扑节点"))
                    {
                        var failure = new DelFailuresPreProcess();
                        DelFailuresPreProcess.SetFailedHandlerBeforeTransaction(failure, t);
                        t.Start();
                        FamilyInstance node = doc.Create.NewFamilyInstance(item.Origin, familySymbol, StructuralType.NonStructural);
                        t.Commit();
                    }
                    using (Transaction t = new Transaction(doc, "创建线"))
                    {
                        //var failure = new BeeFaceFailureHandler();
                        //BeeFaceFailureHandler.SetFailedHandlerBeforeTransaction(failure, t);
                        t.Start();
                        //FamilyInstance node = doc.Create.NewFamilyInstance(item.Origin, familySymbol, StructuralType.NonStructural);
                        if (item.Origin.DistanceTo(elemP) > 0.1)
                        {
                            Conduit conduit = Conduit.Create(doc, conduitType.Id, item.Origin, elemP, levelId);
                            conduit.get_Parameter(BuiltInParameter.RBS_CONDUIT_DIAMETER_PARAM).Set(6 / 304.8);
                            conduit.get_Parameter(BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS).Set("拓扑线");
                        }

                        // TODO：25.2.18 调试时报错，创建拓扑线的距离过短，原因未知，暂时添加距离来过滤
                        if (item.Origin.DistanceTo(fitP) > 0.1)
                        {
                            Conduit conduit2 = Conduit.Create(doc, conduitType.Id, item.Origin, fitP, levelId);
                            conduit2.get_Parameter(BuiltInParameter.RBS_CONDUIT_DIAMETER_PARAM).Set(6 / 304.8);
                            conduit2.get_Parameter(BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS).Set("拓扑线");
                        }

                        t.Commit();
                    }
                }
                else if (element is CableTray cableTray)
                {
                    Line cableLine = (cableTray.Location as LocationCurve).Curve as Line;
                    XYZ pp = cableLine.Project(item.Origin).XYZPoint;
                    using (Transaction t = new Transaction(doc, "创建节点/线"))
                    {
                        Element conduitFind = topologicalLines.Where(x => x.LookupParameter("对应桥架ID").AsInteger() == cableTray.Id.IntegerValue).FirstOrDefault(y => pp.IsPointOnLine(y.GetLine()));
                        if (conduitFind == null) continue;

                        var failure = new BeeFaceFailureHandler();
                        BeeFaceFailureHandler.SetFailedHandlerBeforeTransaction(failure, t);
                        t.Start();

                        ElementId id = (conduitFind as MEPCurve).BreakCurve(pp, doc);
                        topologicalLines.Add(id.GetElement(doc) as Conduit);

                        if (pp.DistanceTo(item.Origin) < 20 / 304.8)
                        {
                            FamilyInstance node = doc.Create.NewFamilyInstance(pp, familySymbol, StructuralType.NonStructural);

                            Conduit conduit = Conduit.Create(doc, conduitType.Id, pp, elemP, levelId);
                            conduit.get_Parameter(BuiltInParameter.RBS_CONDUIT_DIAMETER_PARAM).Set(6 / 304.8);
                            conduit.get_Parameter(BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS).Set("拓扑线");
                        }
                        else
                        {
                            FamilyInstance node1 = doc.Create.NewFamilyInstance(pp, familySymbol, StructuralType.NonStructural);

                            Conduit conduit = Conduit.Create(doc, conduitType.Id, pp, item.Origin, levelId);
                            conduit.get_Parameter(BuiltInParameter.RBS_CONDUIT_DIAMETER_PARAM).Set(6 / 304.8);
                            conduit.get_Parameter(BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS).Set("拓扑线");

                            if (elemP.DistanceTo(item.Origin) > 20 / 304.8)
                            {
                                FamilyInstance node2 = doc.Create.NewFamilyInstance(item.Origin, familySymbol, StructuralType.NonStructural);
                                Conduit conduit2 = Conduit.Create(doc, conduitType.Id, elemP, item.Origin, levelId);
                                conduit2.get_Parameter(BuiltInParameter.RBS_CONDUIT_DIAMETER_PARAM).Set(6 / 304.8);
                                conduit.get_Parameter(BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS).Set("拓扑线");
                            }
                        }



                        t.Commit();
                    }
                }
            }
        }

        private Element FindCableAndFitWithRay(Document doc, string symbolName, double height, Connector con)
        {
            Element cableOrFit = null;

            ExclusionFilter exclusionFilter = new ExclusionFilter(new ElementId[] { con.Owner.Id });

            ElementCategoryFilter categoryFilter1 = new ElementCategoryFilter(BuiltInCategory.OST_CableTray);
            ElementCategoryFilter categoryFilter2 = new ElementCategoryFilter(BuiltInCategory.OST_CableTrayFitting);
            LogicalOrFilter orFilter = new LogicalOrFilter(categoryFilter1, categoryFilter2);

            XYZ conP = con.Origin;
            XYZ min = conP - XYZ.BasisX * height - XYZ.BasisY * height - XYZ.BasisZ * height;
            XYZ max = conP + XYZ.BasisX * height + XYZ.BasisY * height + XYZ.BasisZ * height;
            Outline outline = new Outline(min, max);
            BoundingBoxIntersectsFilter intersectsFilter = new BoundingBoxIntersectsFilter(outline);

            LogicalAndFilter andFilter = new LogicalAndFilter(new ElementFilter[] { orFilter, exclusionFilter, intersectsFilter });

            ReferenceIntersector intersector = new ReferenceIntersector(andFilter, FindReferenceTarget.Element, view3D);
            var withContext1 = intersector.Find(conP, XYZ.BasisZ);
            var withContext2 = intersector.Find(conP, XYZ.BasisZ.Negate());
            List<ReferenceWithContext> withContexts = new List<ReferenceWithContext>();
            withContexts.AddRange(withContext1);
            withContexts.AddRange(withContext2);

            List<Element> elems = withContexts.Select(w => w.GetReference().GetElement(doc)).ToList();
            elems = elems.Where(x => x.Name == symbolName).ToList();
            if (elems.Count > 0)
            {
                cableOrFit = elems.OrderBy(e => e.GetZDis(conP.Z)).First();
            }

            return cableOrFit;
        }

        // 剩余桥架连接器判断连接（只寻找桥架配件，桥架之间寻找前面已做判断）
        private void FinalCabletrayConnect(Document doc, List<Connector> otherCableCons, ref List<Connector> otherFitCons)
        {

            foreach (var con in otherCableCons)
            {
                double width = con.Width;
                XYZ min = con.Origin - XYZ.BasisX * width - XYZ.BasisY * width - XYZ.BasisZ * (400 / 304.8);
                XYZ max = con.Origin + XYZ.BasisX * width + XYZ.BasisY * width + XYZ.BasisZ * (400 / 304.8);
                Outline outline = new Outline(min, max);
                BoundingBoxIntersectsFilter intersectsFilter = new BoundingBoxIntersectsFilter(outline);

                ElementCategoryFilter categoryFilter = new ElementCategoryFilter(BuiltInCategory.OST_CableTrayFitting);

                LogicalAndFilter andFilter = new LogicalAndFilter(intersectsFilter, categoryFilter);

                CableTray cableTray = con.Owner.Id.GetElement(doc) as CableTray;
                double halfWidth = cableTray.Width / 2;
                ElementIntersectsSolidFilter solidFilter = GetSolidFilter(con.Origin, con, halfWidth, 400 / 304.8);


                FamilyInstance fit;
                using (var idCol = new FilteredElementCollector(doc, doc.ActiveView.Id).WherePasses(andFilter))
                {
                    var fitIds = idCol.Select(x => x.Id).ToList();
                    if (fitIds.Count == 0) continue;
                    using (var filterFitCol = new FilteredElementCollector(doc, fitIds).WherePasses(solidFilter).OfClass(typeof(FamilyInstance)))
                    {
                        var fitCol = filterFitCol.Cast<FamilyInstance>().ToList();
                        fitCol = fitCol.Where(x => x.Name == con.Owner.Name).ToList();

                        if (fitCol.Count == 0) continue;

                        if (fitCol.Count == 1)
                        {
                            fit = fitCol.First();
                        }
                        else
                        {
                            fit = GetNearFit(fitCol, con.Origin);
                        }
                    }
                }




                XYZ fitP = (fit.Location as LocationPoint).Point;
                // TODO: 25.6.19 新增距离小等于0.1英尺时就不创建节点与线
                if (con.Origin.DistanceTo(fitP) <= 0.1) goto NoCreate;
                using (Transaction t = new Transaction(doc, "创建拓扑节点"))
                {
                    var failure = new DelFailuresPreProcess();
                    DelFailuresPreProcess.SetFailedHandlerBeforeTransaction(failure, t);
                    t.Start();
                    FamilyInstance node = doc.Create.NewFamilyInstance(con.Origin, familySymbol, StructuralType.NonStructural);
                    t.Commit();
                }
                using (Transaction t = new Transaction(doc, "创建节点/线"))
                {
                    //var failure = new BeeFaceFailureHandler();
                    //BeeFaceFailureHandler.SetFailedHandlerBeforeTransaction(failure, t);
                    try
                    {
                        t.Start();
                        //FamilyInstance node = doc.Create.NewFamilyInstance(con.Origin, familySymbol, StructuralType.NonStructural);
                        Conduit conduit = Conduit.Create(doc, conduitType.Id, con.Origin, fitP, levelId);
                        conduit.get_Parameter(BuiltInParameter.RBS_CONDUIT_DIAMETER_PARAM).Set(6 / 304.8);
                        conduit.get_Parameter(BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS).Set("拓扑线");
                        t.Commit();
                    }
                    catch (Exception)
                    {
                        throw;
                    }

                }
            NoCreate:
                List<Connector> cons = otherFitCons.Where(x => x.Owner.Id == fit.Id).ToList();
                if (cons.Count > 0)
                {
                    XYZ dir = (con.Origin - fitP).Normalize();
                    foreach (var item in cons)
                    {
                        if (item.CoordinateSystem.BasisZ.IsAlmostEqualTo(dir, 0.26) || item.CoordinateSystem.BasisZ.IsAlmostEqualTo(dir.Negate(), 0.26))
                        {
                            otherFitCons.Remove(item);
                            break;
                        }
                    }
                }
            }
        }

        private FamilyInstance GetNearFit(List<FamilyInstance> fitCol, XYZ origin)
        {
            double minVal = double.MaxValue;
            FamilyInstance familyInstance = null;
            foreach (var item in fitCol)
            {
                XYZ p = (item.Location as LocationPoint).Point;
                if (p.DistanceTo(origin) < minVal)
                {
                    minVal = p.DistanceTo(origin);
                    familyInstance = item;
                }
            }
            return familyInstance;
        }

        // 存在高差的两管件连接
        private void ConnectFittingsWithRay(Document doc, List<FamilyInstance> topoNodes)
        {

            List<FamilyInstance> ebInstances = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_CableTrayFitting)
                .WhereElementIsNotElementType().Cast<FamilyInstance>().ToList();

            foreach (FamilyInstance instance in ebInstances)
            {
                ConnectorManager connectorManager = instance.MEPModel.ConnectorManager;
                if (connectorManager == null) continue;
                foreach (Connector con in connectorManager.Connectors)
                {
                    if (!con.IsConnected && !fitHasConnect.IsContains(con))
                    {
                        XYZ conDir = con.CoordinateSystem.BasisZ;

                        ExclusionFilter exclusionFilter = new ExclusionFilter(new ElementId[] { con.Owner.Id });
                        ElementCategoryFilter categoryFilter1 = new ElementCategoryFilter(BuiltInCategory.OST_CableTrayFitting);

                        LogicalAndFilter andFilter = new LogicalAndFilter(categoryFilter1, exclusionFilter);

                        ReferenceIntersector referenceIntersector = new ReferenceIntersector(andFilter, FindReferenceTarget.Element, view3D);
                        ReferenceWithContext referenceWithContext = referenceIntersector.FindNearest(con.Origin, conDir);
                        FamilyInstance familyInstance;
                        if (referenceWithContext == null)
                        {
                            XYZ max = instance.get_BoundingBox(doc.ActiveView).Max;
                            XYZ min = instance.get_BoundingBox(doc.ActiveView).Min;
                            Outline outline = new Outline(min, max);
                            BoundingBoxIntersectsFilter intersectsFilter = new BoundingBoxIntersectsFilter(outline);
                            LogicalAndFilter andFilter2 = new LogicalAndFilter(intersectsFilter, exclusionFilter);

                            familyInstance = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_CableTrayFitting).WhereElementIsNotElementType()
                                .WherePasses(andFilter2).Cast<FamilyInstance>().Where(x => x.GetTypeId().GetElement(doc).Name == instance.GetTypeId().GetElement(doc).Name)
                                .OrderBy(y => (y.Location as LocationPoint).Point.DistanceTo((instance.Location as LocationPoint).Point)).FirstOrDefault();

                        }
                        else
                        {
                            Element element = referenceWithContext.GetReference().GetElement(doc);
                            familyInstance = (FamilyInstance)element;
                        }
                        if (familyInstance == null) continue;

                        foreach (Connector ebCon in familyInstance.MEPModel.ConnectorManager.Connectors)
                        {
                            if (ebCon.CoordinateSystem.BasisZ.Negate().IsAlmostEqualTo(conDir, 0.26) && !ebCon.IsConnected)
                            {
                                FamilyInstance node1 = topoNodes.FirstOrDefault(x => x.LookupParameter("桥架配件ID").AsInteger() == instance.Id.IntegerValue);
                                FamilyInstance node2 = topoNodes.FirstOrDefault(x => x.LookupParameter("桥架配件ID").AsInteger() == familyInstance.Id.IntegerValue);
                                if (node1 == null || node2 == null) continue;
                                XYZ p1 = (node1.Location as LocationPoint).Point;
                                XYZ p2 = (node2.Location as LocationPoint).Point;


                                using (Transaction t = new Transaction(doc, "拓扑节点间创建拓扑线"))
                                {
                                    t.Start();
                                    Conduit conduit = Conduit.Create(doc, conduitType.Id, p1, p2, levelId);
                                    conduit.get_Parameter(BuiltInParameter.RBS_CONDUIT_DIAMETER_PARAM).Set(6 / 304.8);
                                    conduit.get_Parameter(BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS).Set("拓扑线");
                                    t.Commit();
                                }
                                fitHasConnect.Add(con);
                                fitHasConnect.Add(ebCon);
                            }
                        }
                    }
                }
            }
        }
        // 高差桥架连接
        public void HighConnect(Document doc)
        {
            List<CableTray> cableTrays = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_CableTray)
                .WhereElementIsNotElementType().Cast<CableTray>().ToList();
            foreach (var item in cableTrays)
            {
                foreach (Connector con in item.ConnectorManager.Connectors)
                {
                    //忽略垂直的桥架
                    // 高差T
                    if (con.IsConnected || cabletrayHasConnect.IsContains(con) || con.CoordinateSystem.BasisZ.IsAlmostEqualTo(XYZ.BasisZ, 0.25) || con.CoordinateSystem.BasisZ.IsAlmostEqualTo(XYZ.BasisZ.Negate(), 0.25)) continue;

                    double width = item.Width;
                    XYZ min = con.Origin - XYZ.BasisX * width - XYZ.BasisY * width - XYZ.BasisZ * (650 / 304.8);
                    XYZ max = con.Origin + XYZ.BasisX * width + XYZ.BasisY * width + XYZ.BasisZ * (650 / 304.8);
                    Outline outline = new Outline(min, max);
                    BoundingBoxIntersectsFilter intersectsFilter = new BoundingBoxIntersectsFilter(outline);
                    ExclusionFilter exclusionFilter = new ExclusionFilter(new ElementId[] { item.Id });
                    LogicalAndFilter andFilter = new LogicalAndFilter(exclusionFilter, intersectsFilter);

                    ElementIntersectsSolidFilter solidFilter = GetSolidFilter(con.Origin, con, width, 650 / 304.8);

                    FilteredElementCollector collectors;
                    List<CableTray> filterCables = new List<CableTray>();
                    try
                    {
                        using (var idCol = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_CableTray).WhereElementIsNotElementType().WherePasses(andFilter))
                        {
                            // 只保留相同类型的桥架在后续进行碰撞检测
                            var colIds = idCol.Where(y => y.GetTypeId() == item.GetTypeId()).Select(x => x.Id).ToList();
                            //if (colIds.Count == 0) continue;
                            if (colIds.Count > 0)
                            {
                                collectors = new FilteredElementCollector(doc, colIds).WherePasses(solidFilter);

                                // TODO:加上判断桥架是否为高差交叉 25/2/21
                                if (collectors.Count() > 0)
                                {
                                    filterCables = collectors.Cast<CableTray>().ToList();
                                    collectors.Dispose();
                                }

                            }
                            //保留碰撞后相同族类型的桥架
                            //filterCables = filterCables.Where(x => x.GetTypeId() == item.GetTypeId()).ToList();
                        }

                    }
                    catch (Exception)
                    {

                        continue;
                    }

                    XYZ minBox;
                    try
                    {
                        minBox = item.get_BoundingBox(null).Min;
                    }
                    catch (Exception)
                    {
                        minBox = item.get_BoundingBox(doc.ActiveView).Min;
                    }
                    minBox = new XYZ(minBox.X, minBox.Y, -200000);
                    XYZ maxBox;
                    try
                    {
                        maxBox = item.get_BoundingBox(null).Max;
                    }
                    catch (Exception)
                    {
                        maxBox = item.get_BoundingBox(doc.ActiveView).Max;
                    }
                    maxBox = new XYZ(maxBox.X, maxBox.Y, 200000);
                    var boxFilter = new BoundingBoxIntersectsFilter(new Outline(minBox, maxBox));
                    // TODO:加上判断桥架是否为高差交叉 25/2/21
                    if (filterCables.Count == 0)
                    {
                        using (var cableCol = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_CableTray).WhereElementIsNotElementType().WherePasses(exclusionFilter))
                        {
                            var cables = cableCol.Where(x => x.GetTypeId() == item.GetTypeId()).Cast<MEPCurve>()
                                .Where(y => !y.GetLine().Direction.IsAlmostEqualTo(XYZ.BasisZ, 0.25) && !y.GetLine().Direction.IsAlmostEqualTo(XYZ.BasisZ.Negate(), 0.25));
                            cables = cables.OrderBy(x => con.Origin.DistanceTo(x.GetLine().Origin));

                            Line lineCable = item.GetLine();
                            XYZ p0 = lineCable.GetEndPoint(0);
                            XYZ p1 = lineCable.GetEndPoint(1);
                            Line lineCableZ0 = Line.CreateBound(new XYZ(p0.X, p0.Y, 0), new XYZ(p1.X, p1.Y, 0));
                            foreach (var cable in cables)
                            {
                                Line forCableLine = cable.GetLine();
                                XYZ fP0 = forCableLine.GetEndPoint(0);
                                XYZ fP1 = forCableLine.GetEndPoint(1);
                                Line forCableLineZ0 = Line.CreateBound(new XYZ(fP0.X, fP0.Y, 0), new XYZ(fP1.X, fP1.Y, 0));
                                //forCableLineZ0.MakeUnbound();
                                // TODO:(待完成) 添加一个两桥架无高差交叉点但在平面视图上有碰撞体积的判断 25/2/21
                                //var firstFindConduit = topologicalLines.Where(x => x.LookupParameter("对应桥架ID").AsInteger() == cable.Id.IntegerValue).FirstOrDefault(y => y.GetLine().ZeroZ().Intersect(lineCableZ0) == SetComparisonResult.Overlap);
                                //if (firstFindConduit != null)
                                //{
                                //    firstFindConduit.GetLine().ZeroZ().Intersect(lineCableZ0, out var res);
                                //    var interP = res.get_Item(0).XYZPoint;
                                //    var mainFindConduit = topologicalLines.Where(x => x.LookupParameter("对应桥架ID").AsInteger() == item.Id.IntegerValue).FirstOrDefault(y => y.GetLine().ZeroZ().Intersect(firstFindConduit.GetLine().ZeroZ()) == SetComparisonResult.Overlap);
                                //    if (mainFindConduit != null)
                                //    {
                                //        var interP1 = firstFindConduit.GetLine().Project(interP).XYZPoint;
                                //        var interP2 = mainFindConduit.GetLine().Project(interP).XYZPoint;
                                //        if (interP1.DistanceTo(interP2) < 0.1 || !interP1.IsPointOnLine(firstFindConduit.GetLine()) || !interP2.IsPointOnLine(mainFindConduit.GetLine())) break;
                                //        try
                                //        {

                                //        }
                                //        catch (Exception)
                                //        {
                                //            //TaskDialog.Show("dss", item.Id.ToString());
                                //        }
                                //        using (Transaction t = new Transaction(doc, "创建高差交叉桥架拓扑线/节点"))
                                //        {
                                //            t.Start();

                                //            var id1 = firstFindConduit.BreakCurve(interP1, doc);
                                //            var id2 = mainFindConduit.BreakCurve(interP2, doc);
                                //            topologicalLines.Add(id1.GetElement(doc) as Conduit);
                                //            topologicalLines.Add(id2.GetElement(doc) as Conduit);

                                //            FamilyInstance node1 = doc.Create.NewFamilyInstance(interP1, familySymbol, StructuralType.NonStructural);
                                //            FamilyInstance node2 = doc.Create.NewFamilyInstance(interP2, familySymbol, StructuralType.NonStructural);

                                //            Conduit conduit = Conduit.Create(doc, conduitType.Id, interP1, interP2, levelId);
                                //            conduit.get_Parameter(BuiltInParameter.RBS_CONDUIT_DIAMETER_PARAM).Set(6 / 304.8);
                                //            conduit.get_Parameter(BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS).Set("拓扑线"); // "注释"参数

                                //            t.Commit();
                                //        }

                                //        break;
                                //    }
                                //}
                                if (lineCableZ0.Intersect(forCableLineZ0, out var resultArray) == SetComparisonResult.Overlap)
                                {
                                    XYZ intersectP = resultArray.get_Item(0).XYZPoint;
                                    Conduit conduitFind1 = null;
                                    Conduit conduitFind2 = null;
                                    conduitFind1 = topologicalLines.Where(x => x.LookupParameter("对应桥架ID").AsInteger() == item.Id.IntegerValue).FirstOrDefault(y => y.GetLine().Project(intersectP).XYZPoint.IsPointOnLine(y.GetLine()));
                                    conduitFind2 = topologicalLines.Where(x => x.LookupParameter("对应桥架ID").AsInteger() == cable.Id.IntegerValue).FirstOrDefault(y => y.GetLine().Project(intersectP).XYZPoint.IsPointOnLine(y.GetLine()));

                                    if (conduitFind1 == null || conduitFind2 == null) break;

                                    XYZ finalP1 = conduitFind1.GetLine().Project(intersectP).XYZPoint;
                                    XYZ finalP2 = conduitFind2.GetLine().Project(intersectP).XYZPoint;

                                    if (finalP1.DistanceTo(finalP2) < 0.1) break;

                                    using (Transaction t = new Transaction(doc, "创建高差交叉桥架拓扑线/节点"))
                                    {
                                        t.Start();

                                        var id1 = conduitFind1.BreakCurve(finalP1, doc);
                                        var id2 = conduitFind2.BreakCurve(finalP2, doc);
                                        topologicalLines.Add(id1.GetElement(doc) as Conduit);
                                        topologicalLines.Add(id2.GetElement(doc) as Conduit);

                                        FamilyInstance node1 = doc.Create.NewFamilyInstance(finalP1, familySymbol, StructuralType.NonStructural);
                                        FamilyInstance node2 = doc.Create.NewFamilyInstance(finalP2, familySymbol, StructuralType.NonStructural);

                                        Conduit conduit = Conduit.Create(doc, conduitType.Id, finalP1, finalP2, levelId);
                                        conduit.get_Parameter(BuiltInParameter.RBS_CONDUIT_DIAMETER_PARAM).Set(6 / 304.8);
                                        conduit.get_Parameter(BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS).Set("拓扑线"); // "注释"参数

                                        t.Commit();
                                    }


                                    break;
                                }
                                else
                                {
                                    bool succeed = false;
                                    using (var singleCable = new FilteredElementCollector(doc, new ElementId[] { cable.Id }).WherePasses(boxFilter))
                                    {
                                        if (singleCable.Count() == 0) continue;

                                        var conduits1 = topologicalLines.Where(x => x.LookupParameter("对应桥架ID").AsInteger() == item.Id.IntegerValue).ToList();
                                        var conduits2 = topologicalLines.Where(x => x.LookupParameter("对应桥架ID").AsInteger() == cable.Id.IntegerValue).ToList();
                                        for (int i = 0; i < conduits1.Count(); i++)
                                        {
                                            for (int j = 0; j < conduits2.Count(); j++)
                                            {
                                                if (conduits1[i].GetLine().ZeroZ().Intersect(conduits2[j].GetLine().ZeroZ(), out var res) == SetComparisonResult.Overlap)
                                                {
                                                    XYZ intersectP = res.get_Item(0).XYZPoint;
                                                    Conduit conduitFind1 = conduits1[i];
                                                    Conduit conduitFind2 = conduits2[j];

                                                    //if (!intersectP.IsPointOnLine(conduitFind1.GetLine()) || !intersectP.IsPointOnLine(conduitFind2.GetLine())) break;

                                                    XYZ finalP1 = conduitFind1.GetLine().Project(intersectP).XYZPoint;
                                                    XYZ finalP2 = conduitFind2.GetLine().Project(intersectP).XYZPoint;

                                                    if (!finalP1.IsPointOnLine(conduitFind1.GetLine()) || !finalP2.IsPointOnLine(conduitFind2.GetLine())) break;

                                                    if (finalP1.DistanceTo(finalP2) < 0.1) break;

                                                    using (Transaction t = new Transaction(doc, "创建高差交叉桥架拓扑线/节点"))
                                                    {
                                                        t.Start();
                                                        var id1 = conduitFind1.BreakCurve(finalP1, doc);
                                                        var id2 = conduitFind2.BreakCurve(finalP2, doc);
                                                        topologicalLines.Add(id1.GetElement(doc) as Conduit);
                                                        topologicalLines.Add(id2.GetElement(doc) as Conduit);

                                                        FamilyInstance node1 = doc.Create.NewFamilyInstance(finalP1, familySymbol, StructuralType.NonStructural);
                                                        FamilyInstance node2 = doc.Create.NewFamilyInstance(finalP2, familySymbol, StructuralType.NonStructural);

                                                        Conduit conduit = Conduit.Create(doc, conduitType.Id, finalP1, finalP2, levelId);
                                                        conduit.get_Parameter(BuiltInParameter.RBS_CONDUIT_DIAMETER_PARAM).Set(6 / 304.8);
                                                        conduit.get_Parameter(BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS).Set("拓扑线"); // "注释"参数

                                                        succeed = true;
                                                        t.Commit();
                                                    }
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                    if (succeed) break;
                                }

                            }
                        }


                        continue;
                    }



                    CableTray cableTray;
                    Connector nearCon;


                    if (filterCables.Count == 1)
                    {
                        cableTray = filterCables.First();
                        nearCon = con.GetNearConnector(cableTray);
                    }
                    else
                    {
                        cableTray = con.GetNearCableTray(filterCables, out nearCon);
                    }

                    Line line = (cableTray.Location as LocationCurve).Curve as Line;
                    Line lineCopy = (Line)line.Clone();
                    lineCopy.MakeUnbound();
                    XYZ pp = lineCopy.Project(con.Origin).XYZPoint;

                    using (Transaction t = new Transaction(doc, "创建拓扑节点/线"))
                    {
                        if (pp.IsPointOnLine(line))
                        {
                            //Element conduitFind = topologicalLines.Where(x => x.LookupParameter("对应桥架ID").AsInteger() == cableTray.Id.IntegerValue).FirstOrDefault(y => pp.IsPointOnLine(y.GetLine()));
                            Element conduitFind = topologicalLines.Where(x => x.LookupParameter("对应桥架ID").AsInteger() == cableTray.Id.IntegerValue).FirstOrDefault(y => y.GetLine().Project(con.Origin).XYZPoint.IsPointOnLine(y.GetLine()));
                            // TODO:待验证新获取conduitFind方法是否正确
                            // TODO:正常情况不会出现为null的情况，待修改
                            // 出现null情况是因为pp坐标点应该为con坐标点投影到桥架对应线管的Line上的坐标点而不是投影到桥架Line上的坐标点
                            if (conduitFind == null) continue;

                            var failure = new BeeFaceFailureHandler();
                            BeeFaceFailureHandler.SetFailedHandlerBeforeTransaction(failure, t);
                            t.Start();

                            ElementId id = (conduitFind as MEPCurve).BreakCurve(pp, doc);
                            topologicalLines.Add(id.GetElement(doc) as Conduit);

                            if (pp.DistanceTo(con.Origin) < 20 / 304.8)
                            {
                                FamilyInstance node = doc.Create.NewFamilyInstance(pp.Add(con.Origin) / 2, familySymbol, StructuralType.NonStructural);
                            }
                            else
                            {
                                FamilyInstance node1 = doc.Create.NewFamilyInstance(pp, familySymbol, StructuralType.NonStructural);
                                FamilyInstance node2 = doc.Create.NewFamilyInstance(con.Origin, familySymbol, StructuralType.NonStructural);

                                Conduit conduit = Conduit.Create(doc, conduitType.Id, pp, con.Origin, levelId);
                                conduit.get_Parameter(BuiltInParameter.RBS_CONDUIT_DIAMETER_PARAM).Set(6 / 304.8);
                                conduit.get_Parameter(BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS).Set("拓扑线");
                            }


                            cabletrayHasConnect.Add(con);

                            t.Commit();
                            continue;
                        }
                    }

                    // 高差L，平行
                    // TODO:存在三个高差L型桥架末端在同一XY平面上需注释才能正常生成 24/12/26
                    if (nearCon.IsConnected /*|| cabletrayHasConnect.IsContains(nearCon)*/ || Math.Abs(nearCon.Origin.Z - con.Origin.Z) < 20 / 304.8) continue;


                    using (Transaction t = new Transaction(doc, "创建拓扑节点/拓扑线"))
                    {
                        XYZ planeP1 = new XYZ(con.Origin.X, con.Origin.Y, 0);
                        XYZ planeP2 = new XYZ(nearCon.Origin.X, nearCon.Origin.Y, 0);
                        double maxWidth = item.Width > cableTray.Width ? item.Width : cableTray.Width;

                        var failure = new BeeFaceFailureHandler();
                        BeeFaceFailureHandler.SetFailedHandlerBeforeTransaction(failure, t);
                        t.Start();
                        if (planeP1.DistanceTo(planeP2) < maxWidth / 2)
                        {
                            XYZ p1 = nearCon.Origin;
                            XYZ p2 = con.Origin;
                            FamilyInstance node1 = doc.Create.NewFamilyInstance(p1, familySymbol, StructuralType.NonStructural);
                            FamilyInstance node2 = doc.Create.NewFamilyInstance(p2, familySymbol, StructuralType.NonStructural);
                            Conduit conduit = Conduit.Create(doc, conduitType.Id, p1, p2, levelId);
                            conduit.get_Parameter(BuiltInParameter.RBS_CONDUIT_DIAMETER_PARAM).Set(6 / 304.8);
                            conduit.get_Parameter(BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS).Set("拓扑线");
                            cabletrayHasConnect.Add(con);
                            cabletrayHasConnect.Add(nearCon);
                        }
                        t.Commit();
                    }
                }
            }
        }
        // 无高差的两桥架对应拓扑线连接(高差小于20mm)
        private void ParallelConnect(Document doc)
        {
            List<CableTray> cableTrays = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_CableTray)
                .WhereElementIsNotElementType().Cast<CableTray>().ToList();
            foreach (var item in cableTrays)
            {
                foreach (Connector con in item.ConnectorManager.Connectors)
                {
                    //排除已连接或平行于Z轴的连接器
                    if (con.IsConnected || cabletrayHasConnect.IsContains(con) || con.CoordinateSystem.BasisZ.IsAlmostEqualTo(XYZ.BasisZ, 0.25) || con.CoordinateSystem.BasisZ.IsAlmostEqualTo(XYZ.BasisZ.Negate(), 0.25)) continue;

                    double width = item.Width;
                    XYZ min = con.Origin - XYZ.BasisX * width - XYZ.BasisY * width - XYZ.BasisZ * (10 / 304.8);
                    XYZ max = con.Origin + XYZ.BasisX * width + XYZ.BasisY * width + XYZ.BasisZ * (10 / 304.8);
                    Outline outline = new Outline(min, max);
                    BoundingBoxIntersectsFilter intersectsFilter = new BoundingBoxIntersectsFilter(outline);
                    ExclusionFilter exclusionFilter = new ExclusionFilter(new ElementId[] { item.Id });
                    LogicalAndFilter andFilter = new LogicalAndFilter(exclusionFilter, intersectsFilter);

                    ElementIntersectsSolidFilter solidFilter = GetSolidFilter(con.Origin, con, width, 10 / 304.8);

                    FilteredElementCollector collectors;
                    List<CableTray> filterCables;
                    try
                    {
                        // TODO:25.2.24 修改为using 先过滤类型再使用慢速过滤（solid）；
                        using (var idCol = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_CableTray).WhereElementIsNotElementType().WherePasses(andFilter))
                        {
                            var colIds = idCol.Where(x => x.GetTypeId() == item.GetTypeId()).Select(y => y.Id).ToList();
                            if (colIds.Count == 0) continue;
                            collectors = new FilteredElementCollector(doc, colIds).WherePasses(solidFilter);

                            if (collectors.Count() == 0) continue;

                            filterCables = collectors.Cast<CableTray>().ToList();
                        }

                        //保留碰撞后相同族类型的桥架
                        //filterCables = filterCables.Where(x => x.GetTypeId() == item.GetTypeId()).ToList();
                    }
                    catch (Exception)
                    {

                        continue;
                    }



                    if (filterCables.Count == 0) continue;

                    collectors.Dispose();

                    CableTray cableTray;
                    Connector nearCon;

                    if (filterCables.Count == 1)
                    {
                        cableTray = filterCables.First();
                        nearCon = con.GetNearConnector(cableTray);
                    }
                    else
                    {
                        cableTray = con.GetNearCableTray(filterCables, out nearCon);
                    }

                    //Line line = (cableTray.Location as LocationCurve).Curve as Line;
                    //Line lineCopy = (Line)line.Clone();
                    //lineCopy.MakeUnbound();
                    //XYZ pp = lineCopy.Project(con.Origin).XYZPoint;
                    //if (pp.IsPointOnLine(line))
                    //{
                    //    PlumbingUtils.BreakCurve(doc, , pp)
                    //}

                    //判断桥架连接器是否已连接
                    if (nearCon.IsConnected || cabletrayHasConnect.IsContains(nearCon) || Math.Abs(nearCon.Origin.Z - con.Origin.Z) >= 20 / 304.8) continue;

                    using (Transaction t = new Transaction(doc, "创建拓扑节点/拓扑线"))
                    {
                        //var failure = new BeeFaceFailureHandler();
                        //BeeFaceFailureHandler.SetFailedHandlerBeforeTransaction(failure, t);
                        XYZ planeP1 = new XYZ(con.Origin.X, con.Origin.Y, 0);
                        XYZ planeP2 = new XYZ(nearCon.Origin.X, nearCon.Origin.Y, 0);
                        double maxWidth = item.Width > cableTray.Width ? item.Width : cableTray.Width;

                        var failure = new BeeFaceFailureHandler();
                        BeeFaceFailureHandler.SetFailedHandlerBeforeTransaction(failure, t);
                        t.Start();
                        if (nearCon.Origin.DistanceTo(con.Origin) < 20 / 304.8)
                        {
                            XYZ createPoint = nearCon.Origin.Add(con.Origin) / 2;
                            FamilyInstance node = doc.Create.NewFamilyInstance(createPoint, familySymbol, StructuralType.NonStructural);
                            cabletrayHasConnect.Add(con);
                            cabletrayHasConnect.Add(nearCon);
                        }
                        else if (planeP1.DistanceTo(planeP2) < maxWidth / 2)
                        {
                            XYZ p1 = nearCon.Origin;
                            XYZ p2 = con.Origin;
                            FamilyInstance node1 = doc.Create.NewFamilyInstance(p1, familySymbol, StructuralType.NonStructural);
                            FamilyInstance node2 = doc.Create.NewFamilyInstance(p2, familySymbol, StructuralType.NonStructural);
                            Conduit conduit = Conduit.Create(doc, conduitType.Id, p1, p2, levelId);
                            conduit.get_Parameter(BuiltInParameter.RBS_CONDUIT_DIAMETER_PARAM).Set(6 / 304.8);
                            conduit.get_Parameter(BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS).Set("拓扑线");
                            cabletrayHasConnect.Add(con);
                            cabletrayHasConnect.Add(nearCon);
                        }
                        t.Commit();
                    }
                }
            }
        }
        // 创建solid过滤器
        public static ElementIntersectsSolidFilter GetSolidFilter(XYZ conP, Connector con, double width, double height)
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

        /// <summary>
        /// 创建盒过滤器（正方形）
        /// </summary>
        /// <param name="point">outline中心点</param>
        /// <param name="length"></param>
        /// <returns>盒的一半边长（单位：英尺）</returns>
        public static BoundingBoxIntersectsFilter CreateIntersectsFilter(XYZ point, double length)
        {
            XYZ min = point - XYZ.BasisX * length - XYZ.BasisY * length - XYZ.BasisZ * length;
            XYZ max = point + XYZ.BasisX * length + XYZ.BasisY * length + XYZ.BasisZ * length;
            Outline outline = new Outline(min, max);
            BoundingBoxIntersectsFilter intersectsFilter = new BoundingBoxIntersectsFilter(outline);
            return intersectsFilter;
        }

        // 载入族
        public Family LoadFamily(Document doc, string familyPath)
        {
            Family family = null;
            using (Transaction trans = new Transaction(doc, "载入拓扑族"))
            {
                trans.Start();

                // 尝试载入族文件
                try
                {
                    doc.LoadFamily(familyPath, out family);
                }
                catch (Exception)
                {
                    TaskDialog.Show("Error", "未在指定路径找到拓扑节点族，无法载入");
                }

                //if (doc.LoadFamily(familyPath, out family))
                //{
                //    TaskDialog.Show("Family Loaded", "族已成功载入: " + family.Name);
                //}
                //else
                //{
                //    TaskDialog.Show("Load Failed", "族载入失败，可能是族文件路径无效或族已存在于项目中。");
                //}

                trans.Commit();
            }

            return family;
        }

        // 复制线管类型
        public bool AddNewConduitType(Document doc)
        {
            using (Transaction trans = new Transaction(doc, "复制管道类型并重命名"))
            {
                trans.Start();

                // 查找当前的管道类型（以默认管道类型为例）
                ConduitType originalConduitType = new FilteredElementCollector(doc)
                    .OfClass(typeof(ConduitType))
                    .FirstOrDefault() as ConduitType;

                if (originalConduitType == null)
                {
                    TaskDialog.Show("Error", "未找到任何线管类型。");
                    return false;
                }
                // 复制管道类型并重命名
                ConduitType newConduitType = originalConduitType.Duplicate("品成-拓扑线") as ConduitType;
                trans.Commit();
            }
            return true;
        }

        /// <summary>
        /// 创建实例参数
        /// </summary>
        /// <param name="parameterDefinition"></param>
        /// <param name="document"></param>
        /// <param name="category"></param>
        public static void CreateInstanceBinding(Definition parameterDefinition, Document document, Category category)
        {
            var parameterBindings = document.ParameterBindings;

            //获取当前的绑定
            var binding = parameterBindings.get_Item(parameterDefinition);

            //判断是否是实例绑定
            var instanceBinding = binding as InstanceBinding;

            //假如绑定为null
            if (instanceBinding == null)
            {
                //创建一个新类别集合
                var categorySet = document.Application.Create.NewCategorySet();
                //插入类别
                categorySet.Insert(category);
                //创建一个新的绑定
                instanceBinding = document.Application.Create.NewInstanceBinding(categorySet);

                //添加到当前的绑定中
                if (!parameterBindings.Insert(parameterDefinition, instanceBinding,
                    BuiltInParameterGroup.PG_DATA))
                {
                    throw new Exception("进行参数绑定失败");
                }
            }
            else
            {
                if (instanceBinding == null)
                {
                    throw new Exception("实例绑定对象不存在");
                }
                //假如已经存在绑定，则添加一个类别后，重新绑定
                if (!instanceBinding.Categories.Contains(category))
                {
                    instanceBinding.Categories.Insert(category);

                    if (!parameterBindings.ReInsert(parameterDefinition, instanceBinding, BuiltInParameterGroup.PG_DATA))
                    {
                        throw new Exception("像实例参数中，添加新类别失败");
                    }
                }
            }
        }
        /// <summary>
        /// 创建共享参数
        /// </summary>
        /// <param name="doc"></param>
        public void AddProjectParameterToSystemFamily(Document doc, string paraName, ParameterType type)
        {
            // 获取 Document 的参数绑定
            BindingMap bindingMap = doc.ParameterBindings;
            Application app = doc.Application;

            // 定义参数名称
            string parameterName = paraName;

            //// 检查参数是否已存在
            //Definition existingDef = bindingMap.Cast<DefinitionBinding>().FirstOrDefault(b => b.Key.Name == parameterName);
            //if (existingDef != null)
            //{
            //    TaskDialog.Show("参数已存在", "参数已经存在于项目中");
            //    return;
            //}

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
            categorySet.Insert(doc.Settings.Categories.get_Item(BuiltInCategory.OST_Conduit)); // 例如绑定到线管

            InstanceBinding instanceBinding = app.Create.NewInstanceBinding(categorySet);

            using (Transaction trans = new Transaction(doc, "添加项目参数"))
            {
                trans.Start();
                bindingMap.Insert(definition, instanceBinding, BuiltInParameterGroup.INVALID);
                trans.Commit();
            }

            //TaskDialog.Show("完成", "成功添加项目参数到系统族");
        }
        /// <summary>
        /// 获取管道/管件通路上所有元素ID
        /// </summary>
        /// <param name="element"></param>
        /// <param name="ids"></param>
        /// <returns></returns>
        private List<ElementId> GetAllConnect(Element element, ref List<ElementId> ids)
        {
            List<ElementId> result = new List<ElementId>();
            if (element is FamilyInstance familyInstance)
            {
                if (!ids.Contains(familyInstance.Id)) ids.Add(familyInstance.Id);
                foreach (Connector item in familyInstance.MEPModel.ConnectorManager.Connectors)
                {
                    if (item.ConnectorType == ConnectorType.End && item.IsConnected)
                    {
                        foreach (Connector conRef in item.AllRefs)
                        {
                            if (!ids.Contains(conRef.Owner.Id))
                            {
                                ids.Add(conRef.Owner.Id);
                                //ids.AddRange(GetAllConnect(conRef.Owner, ids));
                                GetAllConnect(conRef.Owner, ref ids);
                            }
                        }
                    }
                }
            }
            else if (element is Conduit conduit)
            {
                if (!ids.Contains(conduit.Id)) ids.Add(conduit.Id);
                foreach (Connector item in conduit.ConnectorManager.Connectors)
                {
                    if (item.ConnectorType == ConnectorType.End && item.IsConnected)
                    {
                        foreach (Connector conRef in item.AllRefs)
                        {
                            if (conRef.Owner.Id != item.Owner.Id)
                            {
                                if (!ids.Contains(conRef.Owner.Id) && !conRef.Owner.Name.Contains("接线盒") && !(conRef.Owner is CableTray))
                                {
                                    ids.Add(conRef.Owner.Id);
                                    //ids.AddRange(GetAllConnect(conRef.Owner, ids));
                                    GetAllConnect(conRef.Owner, ref ids);
                                }
                            }
                        }
                    }
                }
            }


            return ids;
        }
        public static void OnDocumentChanged(object sender, DocumentChangedEventArgs e)
        {
            Document doc = e.GetDocument();

            List<ElementId> elementIds = e.GetDeletedElementIds().ToList();


            foreach (var delId in elementIds)
            {
                //TaskDialog.Show("revit", delId.ToString());
                var delTopLines = GlobalResources.UnconnectedWindow1.UnconnectedInfos.Where(x => x.LineID.Equals(delId)).ToList();
                if (delTopLines.Count > 0)
                {
                    delTopLines.ForEach(delLine => GlobalResources.UnconnectedWindow1.UnconnectedInfos.Remove(delLine));
                }
            }
            GlobalResources.UnconnectedWindow1.list.Items.Refresh();
        }
    }

    //数据源
    public class PathListVM : INotifyPropertyChanged
    {
        // ListBox展示信息
        private string _pathInfo;
        public string PathInfo { get { return _pathInfo; } set { _pathInfo = value; OnPropertyChanged(nameof(PathInfo)); } }
        // 路径ID集合
        public List<ElementId> InternalPath { get; set; }
        // 路径长度
        private double _pathLength;
        public double PathLength { get => _pathLength; set { _pathLength = value; OnPropertyChanged(nameof(PathLength)); } }
        // 回路编号
        public string RouteNumber { get; set; }
        // 路径是否被赋值(在导出的使用的字段属性)
        public string HasWrite { get; set; } = "否";
        // 自定义路径ID集合
        public List<ElementId> CustomPathIds { get; set; } = new List<ElementId>();
        // 配电箱
        public string Start { get; set; }
        // 用电名称
        public string End { get; set; }
        // 结果
        private string _findResult;
        public string FindResult
        {
            get => _findResult;
            set
            {
                if (_findResult != value)
                {
                    _findResult = value;
                    OnPropertyChanged(nameof(FindResult));
                }
            }
        }
        private string _status;
        public string Status
        {
            get { return _status; }
            set
            {
                if (_status != value)
                {
                    _status = value;
                    OnPropertyChanged(nameof(Status));
                }
            }

        }
        // 循环次数（广度优先）
        private int _cycleCount;
        public int CycleCount { get => _cycleCount; set { _cycleCount = value; OnPropertyChanged(nameof(CycleCount)); } }
        // 路径数量
        private int _findCount;
        public int FindCount { get => _findCount; set { _findCount = value; OnPropertyChanged(nameof(FindCount)); } }
        public PathListVM(List<ElementId> path, string pathInfo, double pathLength, string routeNumber, int cycleCount, int findCount)
        {
            PathLength = Math.Round(pathLength * 0.3048, 2); //M
            _pathInfo = pathInfo;
            InternalPath = path;
            RouteNumber = routeNumber;
            CycleCount = cycleCount;
            FindCount = findCount;

        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(String name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }
    }
    public static class GlobalResources
    {
        public static UnconnectedWindow UnconnectedWindow1 { get; set; }
    }
    public class UnconnectedInfo
    {
        public ElementId LineID { get; set; }
    }
    public class HasConnectInfo
    {
        public ElementId FitId { get; set; }
        public int FitConId { get; set; }
    }
    public class DelFailuresPreProcess : IFailuresPreprocessor
    {
        public FailureProcessingResult PreprocessFailures(FailuresAccessor failuresAccessor)
        {
            var failureMessages = failuresAccessor.GetFailureMessages();
            foreach (var failure in failureMessages)
            {
                if (failure.GetSeverity() == FailureSeverity.Warning && failure.GetFailureDefinitionId() == BuiltInFailures.OverlapFailures.DuplicateInstances)
                {
                    //if (failuresAccessor.IsElementsDeletionPermitted(failure.GetFailingElementIds().ToList()))
                    //{
                    //    failuresAccessor.DeleteElements(new ElementId[] { failure.GetFailingElementIds().OrderByDescending(x => x.IntegerValue).First() });
                    //    TaskDialog.Show("revit", failure.GetFailingElementIds().Count.ToString());
                    //}
                    failuresAccessor.DeleteWarning(failure);
                }
            }
            return FailureProcessingResult.Continue;
        }

        [Description("这个方法用在事务开始前，在FailureHandler初始化后调用")]
        /// <summary>
        /// 这个方法用在事务开始前，在FailureHandler初始化后调用
        /// </summary>
        public static void SetFailedHandlerBeforeTransaction(IFailuresPreprocessor failureHandler, Transaction transaction)
        {
            FailureHandlingOptions failureHandlingOptions = transaction.GetFailureHandlingOptions();
            failureHandlingOptions.SetFailuresPreprocessor(failureHandler);
            // 这句话是关键  
            //failureHandlingOptions.SetClearAfterRollback(true);
            transaction.SetFailureHandlingOptions(failureHandlingOptions);
        }
    }
    public class BeeFaceFailureHandler : IFailuresPreprocessor
    {
        public string ErrorMessage { set; get; }
        public string ErrorSeverity { set; get; }

        public BeeFaceFailureHandler()
        {
            ErrorMessage = "";
            ErrorSeverity = "";
        }
        public FailureProcessingResult PreprocessFailures(FailuresAccessor failuresAccessor)
        {
            IList<FailureMessageAccessor> failureMessages = failuresAccessor.GetFailureMessages();
            foreach (FailureMessageAccessor failureMessageAccessor in failureMessages)
            {
                FailureDefinitionId id = failureMessageAccessor.GetFailureDefinitionId();
                try
                {
                    ErrorMessage = failureMessageAccessor.GetDescriptionText();
                }
                catch
                {
                    ErrorMessage = "Unknown Error";
                }
                try
                {
                    FailureSeverity failureSeverity = failureMessageAccessor.GetSeverity();
                    ErrorSeverity = failureSeverity.ToString();
                    if (failureSeverity == FailureSeverity.Warning)
                    {
                        // 如果是警告，则禁止消息框  
                        failureMessageAccessor.GetDefaultResolutionCaption();

                        failuresAccessor.DeleteWarning(failureMessageAccessor);
                    }
                }
                catch (Exception ex)
                {
                }
            }
            return FailureProcessingResult.Continue;
        }
        [Description("这个方法用在事务开始前，在FailureHandler初始化后调用")]
        /// <summary>
        /// 这个方法用在事务开始前，在FailureHandler初始化后调用
        /// </summary>
        public static void SetFailedHandlerBeforeTransaction(IFailuresPreprocessor failureHandler, Transaction transaction)
        {
            FailureHandlingOptions failureHandlingOptions = transaction.GetFailureHandlingOptions();
            failureHandlingOptions.SetFailuresPreprocessor(failureHandler);
            // 这句话是关键  
            //failureHandlingOptions.SetClearAfterRollback(true);
            transaction.SetFailureHandlingOptions(failureHandlingOptions);
        }
    }
}
