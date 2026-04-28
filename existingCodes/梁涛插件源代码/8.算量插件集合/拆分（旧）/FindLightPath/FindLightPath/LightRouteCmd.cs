using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.Exceptions;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Application = System.Windows.Forms.Application;
using OperationCanceledException = Autodesk.Revit.Exceptions.OperationCanceledException;

namespace FindLightPath
{
    // 寻找指定灯具编号的最优（短）回路，计算长度
    [Transaction(TransactionMode.Manual)]
    public class LightRouteCmd : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;

            Reference powerBoxRefer;
            try
            {
                 powerBoxRefer = sel.PickObject(ObjectType.Element, new PowerBoxFilter(), "选择起始配电箱");
            }
            catch (OperationCanceledException)
            {
                TaskDialog.Show("提示", "已取消操作");
                return Result.Cancelled;
            }
            // TODO: 25.7.21 根据选择的配电箱获取第一个通电的灯具节点 做个窗口选择循环次数和要获取的灯具编号对应回路
            Element powerBox = doc.GetElement(powerBoxRefer);

            string selLightNum = string.Empty;
            if (powerBox.Category.Id.IntegerValue == -2000151)
            {
                selLightNum = powerBox.LookupParameter("灯具编号").AsString();
            }

            SelWindow selWindow = new SelWindow(doc, selLightNum);
            selWindow.ShowDialog();
            if (selWindow.DialogResult == false)
            {
                return Result.Cancelled;
            }

            List<FamilyInstance> nodes = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_GenericModel).Cast<FamilyInstance>().ToList();

            List<FamilyInstance> unpowerLights = nodes.Where(n => n.LookupParameter("灯具编号") != null && !string.IsNullOrEmpty(n.LookupParameter("灯具编号").AsString()) && n.LookupParameter("灯具编号").AsString().Equals(selWindow.LightNum)).ToList();

            List<ElementId> powerLightIds = new List<ElementId>();
            List<ElementId> unpowerLightIds = unpowerLights.Select(x => x.Id).ToList();
            // 邻接表
            var neighborList = RouteUtils.GetNeighborList(doc);

            double length = 0;

            if (powerBox.Category.Id.IntegerValue == -2000151)
            {
                powerLightIds.Add(powerBox.Id);
                unpowerLightIds.Remove(powerBox.Id);
            }
            else
            {
                ElementId firstPowerLightId = FindFirstPowerLight(doc, neighborList, powerBox, selWindow.LightNum, selWindow.RunNum, out List<ElementId> shortPath);
                if (firstPowerLightId == null)
                {
                    TaskDialog.Show("提示", "未能找到与该配电箱连接的灯具节点");
                    return Result.Failed;
                }
                powerLightIds.Add(firstPowerLightId);
                unpowerLightIds.Remove(firstPowerLightId);
                length += shortPath.GetPathLength(doc);
            }
            //TaskDialog.Show("revit", powerLightIds.First().ToString() + "\n" + powerLightIds.Count + "\n" + unpowerLightIds.Count);
            //return Result.Succeeded;

            List<LightRouteInfo> lightRouteInfos = new List<LightRouteInfo>();

            while (unpowerLightIds.Count > 0)
            {
                List<ElementId> finalPath = null;
                ElementId nextPowerLight = null;
                ElementId beforePowerLight = null;

                foreach (var item in powerLightIds)
                {
                    var powerLight = doc.GetElement(item);
                    //XYZ lp = (powerLight.Location as LocationPoint).Point;
                    Dictionary<ElementId, double> keyValuePairs = new Dictionary<ElementId, double>();
                    foreach (var item2 in unpowerLightIds)
                    {

                        var allPaths = RouteUtils.GetAllPaths(neighborList, item2, item, out int count, selWindow.RunNum);
                        if (allPaths.Count == 0) continue;
                        var shortPath = allPaths.OrderBy(p => p.GetPathLength(doc)).First();
                        if (finalPath == null || finalPath.GetPathLength(doc) > shortPath.GetPathLength(doc))
                        {
                            nextPowerLight = item2;
                            beforePowerLight = item;
                            finalPath = shortPath;
                        }
                    }
                }

                bool res;
                try
                {
                    res = unpowerLightIds.Remove(nextPowerLight);
                    powerLightIds.Add(nextPowerLight);
                }
                catch (Exception ex)
                {
                    TaskDialog.Show("revit", "未找到下一最近未通电灯具");
                    foreach (var unPower in unpowerLightIds)
                    {
                        lightRouteInfos.Add(new LightRouteInfo() { Length = 0, UnPowerLightId = unPower.IntegerValue });
                    }
                    goto Final;
                }

                if (!res && nextPowerLight != null)
                {
                    TaskDialog.Show("reivt", "移除失败");
                    return Result.Failed;
                }

                if (finalPath != null)
                {
                    length += finalPath.GetPathLength(doc);
                    lightRouteInfos.Add(new LightRouteInfo() { PowerLightId = beforePowerLight.IntegerValue, PathIds = finalPath, Length = Math.Round(finalPath.GetPathLength(doc) * 0.3048, 2), UnPowerLightId = nextPowerLight.IntegerValue, IsConnect = "是" });
                }
                else
                {
                    TaskDialog.Show("revit", "未找到下一最近未通电灯具");
                    foreach (var unPower in unpowerLightIds)
                    {
                        lightRouteInfos.Add(new LightRouteInfo() { Length = 0, UnPowerLightId = unPower.IntegerValue });
                    }
                    goto Final;
                }
                Application.DoEvents();
                //GC.Collect();
            }
            //TaskDialog.Show("revit", unpowerLightIds.Count + "\n" + length + "\n" + (Math.Round(length * 0.3048, 2) + 7.9));

        Final:

            LightRouteWindow lightRouteWindow = new LightRouteWindow(lightRouteInfos, uidoc, Math.Round(length * 0.3048, 2), selWindow.LightNum, powerBox);
            lightRouteWindow.Show();

            return Result.Succeeded;
        }

        private ElementId FindFirstPowerLight(Document doc, Dictionary<ElementId, List<ElementId>> neighborList,Element powerBox, string lightNodeNum, int runNum, out List<ElementId> resultPath)
        {
            ElementId result = null;
            resultPath = new List<ElementId>();

            ElementId conduitId = null;
            XYZ min = powerBox.get_BoundingBox(doc.ActiveView).Min;
            XYZ max = powerBox.get_BoundingBox(doc.ActiveView).Max;
            // 获取与配电箱相连的拓扑线
            using (var conduitCol1 = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_Conduit).OfClass(typeof(Conduit)).WherePasses(new BoundingBoxIntersectsFilter(new Outline(min, max))))
            {
                var conduits1 = conduitCol1.Where(x => x.Name == "品成-拓扑线").ToList();
                if (conduits1.Count() == 0)
                {
                    return result;
                }
                else
                {
                    var solids = Utils.GetAllSolids(powerBox);
                    
                    foreach (var conduit in conduits1)
                    {
                        try
                        {
                            var conduitSolids = Utils.GetAllSolids(conduit);
                            if (conduitSolids.Count == 0) continue;
                            Solid conduitSolid = conduitSolids.First();
                            if (solids.Any(s => BooleanOperationsUtils.ExecuteBooleanOperation(s, conduitSolid, BooleanOperationsType.Intersect).Volume > 0))
                            {
                                conduitId = conduit.Id;
                                break;
                            }
                        }
                        catch (Exception)
                        {
                            continue;
                        }
                    }

                }
            }
            if (conduitId == null) return result;

            // 获取所有指定编号的灯具节点，选取离配电箱直线距离最近的五个灯具节点，判断其回路
            List<Element> filterLights = new List<Element>();
            using (var lightNodeCol = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_GenericModel))
            {
                var lightNodes = lightNodeCol.Where(x => x.LookupParameter("灯具编号") != null && !string.IsNullOrEmpty(x.LookupParameter("灯具编号").AsString()) && x.LookupParameter("灯具编号").AsString().Equals(lightNodeNum)).ToList();

                if (lightNodes.Count() <= 5) filterLights = lightNodes.Select(x => x).ToList();
                else
                {
                    XYZ point = (powerBox.Location as LocationPoint).Point;
                    filterLights = lightNodes.OrderBy(x => (x.Location as LocationPoint).Point.DistanceTo(point)).Take(5).ToList();
                }
            }

            List<ElementId> shortPath = null;
            foreach (var filterLight in filterLights)
            {
                var allPath = RouteUtils.GetAllPaths(neighborList, conduitId, filterLight.Id, out int count, runNum);
                if (allPath.Count > 0)
                {
                    var finalPath = allPath.OrderBy(p => p.GetPathLength(doc)).First();
                    if (shortPath == null || shortPath.GetPathLength(doc) > finalPath.GetPathLength(doc))
                    {
                        shortPath = finalPath;
                        resultPath = finalPath;
                        result = filterLight.Id;
                    }
                }
            }

            return result;
        }
    }
    public class LightRouteInfo
    {
        public List<ElementId> PathIds { get; set; }
        public double Length { get; set; }
        public int PowerLightId { get; set; }
        public int UnPowerLightId { get; set; }
        public string IsConnect { get; set; } = "否";
    }
    public class PowerBoxOrLightNodeFilter : ISelectionFilter
    {
        public bool AllowElement(Element elem)
        {
            if(elem is FamilyInstance
                && (elem.LookupParameter("电气-配电箱编号") != null && !string.IsNullOrEmpty(elem.LookupParameter("电气-配电箱编号").AsString()) 
                || elem.LookupParameter("灯具编号") != null && !string.IsNullOrEmpty(elem.LookupParameter("灯具编号").AsString()))) return true;
            return false;
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            return false;
        }
    }
    public class PowerBoxFilter : ISelectionFilter
    {
        public bool AllowElement(Element elem)
        {
            if(elem is FamilyInstance && (elem.LookupParameter("电气-配电箱编号") != null && !string.IsNullOrEmpty(elem.LookupParameter("电气-配电箱编号").AsString()))) return true;
            return false;
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            return false;
        }
    }
}
