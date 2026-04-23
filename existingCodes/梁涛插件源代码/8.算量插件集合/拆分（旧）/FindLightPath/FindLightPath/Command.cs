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
                Element host = light.GetHostElement(doc, XYZ.BasisZ, 1000 / 304.8);
                lightInfos.Add(new LightInfo() { Light = light, HostElem = host });
            }
            #endregion
            //List<FamilyInstance> filterLights = lightFixs.Where(x => x.Id != startLight.Id && x.Host != null && x.Host.Id == hostElem.Id).ToList();
            //filterLights = filterLights.OrderBy(x => x.GetDistance(startLight)).ToList();
            List<FamilyInstance> filterLights = lightInfos.Where(lf => lf.HostElem != null && lf.HostElem.Id == hostElem.Id && lf.Light.Id != startLight.Id && HaveSameParaValue(lf.Light, lightRoutePara))
                .Select(nl => nl.Light).OrderBy(l => l.GetDistance(startLight)).ToList();

            #region 在灯具之间创建拓扑线连接
            TransactionGroup TG = new TransactionGroup(doc, "连续连接灯具");
            TG.Start();
            using (Transaction t = new Transaction(doc, "创建拓扑线"))
            {
                t.Start();

                for (int i = 0; i < filterLights.Count; i++)
                {
                    if (i == 0)
                    {
                        Conduit conduit = Conduit.Create(doc, BTConduitType.Id, startLight.GetCenterPoint(), filterLights[i].GetCenterPoint(), levelId);
                        conduit.get_Parameter(BuiltInParameter.RBS_CONDUIT_DIAMETER_PARAM).Set(6 / 304.8);
                        conduit.LookupParameter("路由").Set(routeNum);

                    }
                    else
                    {
                        Conduit conduit = Conduit.Create(doc, BTConduitType.Id, filterLights[i - 1].GetCenterPoint(), filterLights[i].GetCenterPoint(), levelId);
                        conduit.get_Parameter(BuiltInParameter.RBS_CONDUIT_DIAMETER_PARAM).Set(6 / 304.8);
                        conduit.LookupParameter("路由").Set(routeNum);
                    }

                    
                }

                t.Commit();
                if (filterLights.Count > 0) startLight = filterLights.Last();
            }
            Next:
            CableTray nextCable;
            try
            {
                nextCable = doc.GetElement(sel.PickObject(ObjectType.Element, new CableFilter(), "选择下一个照明线槽")) as CableTray;
                hostElem = nextCable;
                //filterLights = lightFixs.Where(x => x.Host != null && x.Host.Id == hostElem.Id).OrderBy(l => l.GetDistance(nextLight)).ToList();
                filterLights = lightInfos.Where(lf => lf.HostElem != null && lf.HostElem.Id == hostElem.Id && HaveSameParaValue(lf.Light, lightRoutePara))
                .Select(nl => nl.Light).OrderBy(l => l.GetDistance(startLight)).ToList();
            }
            catch (Exception)
            {
                TG.Assimilate();
                TaskDialog.Show("Revit", "结束布置");
                return Result.Succeeded;
            }
            using (Transaction t = new Transaction(doc, "创建拓扑线"))
            {
                t.Start();

                for (int i = 0; i < filterLights.Count; i++)
                {
                    if (i == 0)
                    {
                        Conduit conduit = Conduit.Create(doc, BTConduitType.Id, startLight.GetCenterPoint(), filterLights[i].GetCenterPoint(), levelId);
                        conduit.get_Parameter(BuiltInParameter.RBS_CONDUIT_DIAMETER_PARAM).Set(6 / 304.8);
                        conduit.LookupParameter("路由").Set(routeNum);
                    }
                    else
                    {
                        Conduit conduit = Conduit.Create(doc, BTConduitType.Id, filterLights[i - 1].GetCenterPoint(), filterLights[i].GetCenterPoint(), levelId);
                        conduit.get_Parameter(BuiltInParameter.RBS_CONDUIT_DIAMETER_PARAM).Set(6 / 304.8);
                        conduit.LookupParameter("路由").Set(routeNum);
                    }


                }
                t.Commit();
                if (filterLights.Count > 0) startLight = filterLights.Last();
            }
            goto Next;
            #endregion

            TG.Commit();
            return Result.Succeeded;

            View view = doc.ActiveView;
            Transform viewTransform = view.CropBox.Transform;

            // 获取分区多段线
            Reference reference = sel.PickObject(ObjectType.PointOnElement, new PolyLineFilter(), "选择一个分区多段线");
            ImportInstance importInstance = doc.GetElement(reference) as ImportInstance;
            Transform transform = importInstance.GetTransform();
            PolyLine polyLine = importInstance.GetGeometryObjectFromReference(reference) as PolyLine; // 获取到的polyline位置不正确与是否在块参照中有关(若多段线在块参照中可以先炸开)

            var geoE = importInstance.get_Geometry(new Options());
            foreach (var item in geoE)
            {
                if (item is GeometryInstance geometryInstance)
                {
                    var geoE2 = geometryInstance.GetSymbolGeometry();
                    //TaskDialog.Show("revitee", geoE2.Cast<GeometryObject>().Where(g => g is GeometryInstance).Count().ToString());
                    foreach (var item2 in geoE2)
                    {
                        if (item2 is GeometryInstance geo2)
                        {
                            //foreach (var item3 in geo2.GetInstanceGeometry())
                            //{
                            //    if (item3 is PolyLine poly2 && poly2.GetHashCode() == polyLine.GetHashCode())
                            //    {
                            //        TaskDialog.Show("revit", geo2.Symbol.Name);
                            //    }
                            //}
                            foreach (var item3 in geo2.GetSymbolGeometry()) // 获取多段线所在块参照对应的transform
                            {
                                if (item3 is PolyLine poly2 && poly2.GetHashCode() == polyLine.GetHashCode())
                                {
                                    transform = geo2.Transform.Multiply(geometryInstance.Transform); // TODO: 25.4.11 测试有无相乘状态下的transform差距
                                    //TaskDialog.Show("reit", geo2.Transform.Origin + "\n" + geometryInstance.Transform.Origin+ "\n" + transform.Origin);
                                    polyLine = poly2;
                                    break;
                                    //TaskDialog.Show("revit", geo2.Symbol.Name);
                                }
                            }
                        }
                    }
                }
            }
            //TaskDialog.Show("po", polyLine.GetCoordinates().Count + "\n" + polyLine.GetHashCode());
            //return Result.Succeeded;

            // 1.获取分区范围中所有的灯具
            Outline outline = polyLine.GetOutline();
            XYZ min = outline.MinimumPoint;
            XYZ max = outline.MaximumPoint;
            min = new XYZ(min.X, min.Y, -2000);
            max = new XYZ(max.X, max.Y, 2000);
            min = transform.OfPoint(min);
            max = transform.OfPoint(max);

            outline = new Outline(min, max);
            BoundingBoxIntersectsFilter intersectsFilter = new BoundingBoxIntersectsFilter(outline);

            List<Line> lines = new List<Line>();
            var points = polyLine.GetCoordinates();
            // TODO:坐标转换后还是不正确
            //points = points.Select(p => viewTransform.Inverse.OfPoint(transform.OfPoint(p))).ToList();
            points = points.Select(p => transform.OfPoint(p)).ToList();

            for (int i = 0; i < points.Count - 1; i++)
            {
                try
                {
                    lines.Add(Line.CreateBound(points[i], points[i + 1]));
                }
                catch (ArgumentsInconsistentException)
                {
                    lines.Remove(lines.Last());
                    lines.Add(Line.CreateBound(points[i - 1], points[i + 1]));
                }
                if (i == points.Count - 2)
                {
                    try
                    {
                        lines.Add(Line.CreateBound(points[points.Count - 1], points[0]));
                    }
                    catch (ArgumentsInconsistentException)
                    {
                        //TaskDialog.Show("er", points[points.Count - 1].DistanceTo(points[0]).ToString());
                    }

                }
            }

            //var ids = new List<ElementId>();
            //using (Transaction t = new Transaction(doc, "test"))
            //{
            //    t.Start();

            //    Plane plane = Plane.CreateByNormalAndOrigin(XYZ.BasisZ, lines.First().GetEndPoint(0));
            //    SketchPlane sketchPlane = SketchPlane.Create(doc, plane);
            //    foreach (var item in lines)
            //    {

            //        ModelCurve modelCurve = doc.Create.NewModelCurve(item, sketchPlane);
            //        ids.Add(modelCurve.Id);
            //    }

            //    t.Commit();
            //}
            //uidoc.ShowElements(ids);
            //sel.SetElementIds(ids);

            //ids.ForEach(id =>
            //{
            //    ModelCurve element= doc.GetElement(id) as ModelCurve;
            //    Curve curve = (element.Location as LocationCurve).Curve;
            //    File.AppendAllText(@"C:\Users\Administrator\Desktop\新建文本文档 (3).txt", curve.Tessellate()[0] + curve.Tessellate()[1] +"\n");
            //});
            //File.AppendAllText(@"C:\Users\Administrator\Desktop\新建文本文档 (3).txt", "\n\n");
            //lines.ForEach(l => File.AppendAllText(@"C:\Users\Administrator\Desktop\新建文本文档 (3).txt", l.Tessellate()[0] + l.Tessellate()[1] + "\n"));

            //return Result.Succeeded;

            var newLines = new List<Line>();
            foreach (var line in lines)
            {
                XYZ p0 = line.GetEndPoint(0);
                XYZ p1 = line.GetEndPoint(1);
                p0 = new XYZ(Math.Round(p0.X, 3), Math.Round(p0.Y, 3), -2000);
                p1 = new XYZ(Math.Round(p1.X, 3), Math.Round(p1.Y, 3), -2000);
                Line newLine = Line.CreateBound(p0, p1);
                newLines.Add(newLine);
            }

            //放样
            List<CurveLoop> loops = new List<CurveLoop>();
            List<Curve> curveList = new List<Curve>();

            newLines.ForEach(line => curveList.Add(line));

            CurveLoop curveLoop = CurveLoop.Create(curveList);
            loops.Add(curveLoop);

            //newLines.ForEach(l => File.AppendAllText(@"C:\Users\Administrator\Desktop\新建文本文档 (3).txt", l.GetEndPoint(0) + "||" + l.GetEndPoint(1) + "\n"));
            //return Result.Succeeded;

            //拉伸
            Solid solid1 = null;
            try
            {
                solid1 = GeometryCreationUtilities.CreateExtrusionGeometry(loops, XYZ.BasisZ, 4000);
            }
            catch (ArgumentException e)
            {
                TaskDialog.Show("错误", "所选多段线无法形成一个闭合的区域，请重新选择。");
                return Result.Failed;
            }
            ElementIntersectsSolidFilter filter = new ElementIntersectsSolidFilter(solid1);
            ElementCategoryFilter categoryFilter = new ElementCategoryFilter(BuiltInCategory.OST_LightingFixtures);
            ElementCategoryFilter categoryFilter2 = new ElementCategoryFilter(BuiltInCategory.OST_ElectricalEquipment);

            LogicalAndFilter andFilter = new LogicalAndFilter(intersectsFilter, categoryFilter);
            LogicalAndFilter andFilter2 = new LogicalAndFilter(intersectsFilter, categoryFilter2);
            //TaskDialog.Show("revit", solid1.Volume.ToString());

            // 在范围内的灯具
            var lights = new FilteredElementCollector(doc, doc.ActiveView.Id).WherePasses(andFilter).WherePasses(filter).WhereElementIsNotElementType();
            // 在范围内的电气设备（配电箱）
            var boxs = new FilteredElementCollector(doc, doc.ActiveView.Id).WherePasses(andFilter2).WherePasses(filter).WhereElementIsNotElementType();

            uidoc.ShowElements(lights.Select(x => x.Id).ToList());
            sel.SetElementIds(lights.Select(x => x.Id).ToList());
            TaskDialog.Show("result", lights.Count() + "\n" + boxs.Count());
            return Result.Succeeded;
            // 在范围内的所有桥架
            // 获取范围内桥架与灯具对应关系（一对多）


            //// 2.导入回路表并获取回路表信息
            //string path = SelectPath();
            //if (path == string.Empty) return Result.Cancelled;
            //DataTable dt = ReadExcelFile(path);
            //dt.TableName = "灯具回路表";


            //// 3.按照回路表对指定灯具到配电箱之间的路径进行赋值
            //foreach (DataRow dr in dt.Rows)
            //{
            //    if (string.IsNullOrEmpty(dr["配电箱???"].ToString()) || string.IsNullOrEmpty(dr["回路编号???"].ToString())) continue;
            //    string boxName = dr["配电箱???"].ToString();
            //    string routeName = dr["回路编号???"].ToString();
            //    var filterLights = lights.Where(l => l.LookupParameter("回路编号???") != null && l.LookupParameter("回路编号???").AsString().Equals(routeName));
            //    var filterBoxs = boxs.Where(b => b.LookupParameter("配电箱编号???") != null && b.LookupParameter("配电箱编号???").AsString().Equals(boxName));
            //    if (filterLights.Count() == 0 || filterBoxs.Count() == 0) continue;

            //}
            // 根据桥架生成对应拓扑线
            // 桥架ID，拓扑线ID
            Dictionary<ElementId, ElementId> cableConduit = new Dictionary<ElementId, ElementId>();
            // 拓扑线ID，附着灯具ID
            Dictionary<ElementId, List<ElementId>> conduitLights = new Dictionary<ElementId, List<ElementId>>();
            // 拓扑线ID，相连拓扑线/线管配件ID
            Dictionary<ElementId, List<ElementId>> connectConduits = new Dictionary<ElementId, List<ElementId>>();

            ConduitType conduitType = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Conduit).OfClass(typeof(ConduitType)).Cast<ConduitType>().Where(x => x.Name == "品成-拓扑线").FirstOrDefault();
            if (conduitType == null) AddNewConduitType(doc);
            conduitType = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Conduit).OfClass(typeof(ConduitType)).Cast<ConduitType>().Where(x => x.Name == "品成-拓扑线").FirstOrDefault();

            LogicalAndFilter andFilter3 = new LogicalAndFilter(new ElementCategoryFilter(BuiltInCategory.OST_CableTray), intersectsFilter);
            var cableTrays = new FilteredElementCollector(doc, doc.ActiveView.Id).WherePasses(andFilter3).WherePasses(filter).Cast<CableTray>();
            cableTrays = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_CableTray).WhereElementIsNotElementType().Cast<CableTray>();
            using (Transaction t = new Transaction(doc, "创建拓扑线"))
            {
                t.Start();

                foreach (var cable in cableTrays)
                {
                    Location location = cable.Location;
                    if (location == null) continue;
                    double halfHeight = cable.Height / 2;
                    Line line = (location as LocationCurve).Curve as Line;
                    XYZ newP0 = line.GetEndPoint(0) - halfHeight * XYZ.BasisZ;
                    XYZ newP1 = line.GetEndPoint(1) - halfHeight * XYZ.BasisZ;

                    Conduit conduit = Conduit.Create(doc, conduitType.Id, newP0, newP1, new ElementId(4364654));
                    conduit.get_Parameter(BuiltInParameter.RBS_CONDUIT_DIAMETER_PARAM).Set(6 / 304.8);

                    var filterLightIds = lights.Cast<FamilyInstance>().Where(l => l.Host.Id.IntegerValue == cable.Id.IntegerValue).Select(x => x.Id).ToList();
                    conduitLights.Add(conduit.Id, filterLightIds);
                    cableConduit.Add(cable.Id, conduit.Id);
                }

                t.Commit();
            }

            foreach (var cable in cableTrays)
            {
                foreach (Connector con in cable.ConnectorManager.Connectors)
                {
                    foreach (Connector conRef in con.AllRefs)
                    {
                        if (conRef.Owner.Id.IntegerValue != con.Owner.Id.IntegerValue)
                        {

                        }
                    }
                }
            }

            // 创建一个列表，保存桥架与拓扑线的对应关系并且记录拓扑线两端连接信息

            TaskDialog.Show("25.2.8", lights.Count().ToString());
            return Result.Succeeded;
        }

        private bool HaveSameParaValue(FamilyInstance light, string startLightRoutePara)
        {
            string lightRoutePara;
            var lightPara = light.LookupParameter("灯具编号");
            if (lightPara != null && !string.IsNullOrEmpty(lightPara.AsString()))
                lightRoutePara = lightPara.AsString();
            else if (light.LookupParameter("路由") != null)
                lightRoutePara = light.LookupParameter("路由").AsString();
            else
                return false;
            if (lightRoutePara.Equals(startLightRoutePara)) return true;
            return false;
        }

        public static System.Data.DataTable ReadExcelFile(string filePath)
        {
            DataTable dt = new DataTable();


            Application excelApp = new Application();
            Workbook workbook = excelApp.Workbooks.Open(filePath);
            Worksheet worksheet = workbook.Sheets[1];

            Range usedRange = worksheet.UsedRange;

            int unknown = 0;
            for (int col = 1; col < usedRange.Columns.Count + 1; col++)
            {
                var value = (usedRange.Cells[1, col] as Range)?.Value2;
                if (value != null)
                {
                    DataColumn dc = new DataColumn(value.ToString().Trim());
                    dt.Columns.Add(dc);
                }
                else
                {
                    unknown++;
                    DataColumn dc = new DataColumn($"未知{unknown}");
                    dt.Columns.Add(dc);
                }
            }
            for (int row = 2; row <= usedRange.Rows.Count; row++) // 从第二行开始，假设第一行为标题
            {
                DataRow dr = dt.NewRow();
                for (int col = 1; col < usedRange.Columns.Count + 1; col++)
                {
                    var value = (usedRange.Cells[row, col] as Range)?.Value2;
                    if (value != null)
                    {
                        dr[col - 1] = value.ToString();
                    }
                }
                dt.Rows.Add(dr);
            }

            workbook.Close(false);
            excelApp.Quit();

            return dt;
        }
        private string SelectPath()
        {
            string path = string.Empty;
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                /*Filter = "Files (*.csv)|*.csv"*///如果需要筛选txt文件（"Files (*.txt)|*.txt"）
                Filter = "Excel Files|*.xls;*.xlsx;*.csv",
                Title = "选择要导入的回路表"
            };

            //var result = openFileDialog.ShowDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog.FileName;
            }

            return path;
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
        /// 创建共享参数
        /// </summary>
        /// <param name="doc"></param>
        public void AddProjectParameterToSystemFamily(Document doc, string paraName, ParameterType type)
        {
            // 获取 Document 的参数绑定
            BindingMap bindingMap = doc.ParameterBindings;
            Application2 app = doc.Application;

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
    }
    public class PolyLineFilter : ISelectionFilter
    {
        Element Element { get; set; }
        public bool AllowElement(Element elem)
        {
            Element = elem;
            if (elem is ImportInstance)
            {
                return true;
            }
            return false;
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            var geometryObject = Element.GetGeometryObjectFromReference(reference);
            if (geometryObject is PolyLine)
            {
                return true;
            }
            return false;
        }
    }
}
