using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Structure;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.DB.Architecture;

namespace ArrangeHangerAccordingToNozzle
{
    [Transaction(TransactionMode.Manual)]
    public class AddPipeHanger : IExternalCommand
    {
        //int count3 = 0;
        UIDocument uIDoc = null;
        Document doc = null;
        View3D view3D = null;
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            
            uIDoc = commandData.Application.ActiveUIDocument;
            doc = uIDoc.Document;
            //判断视图
            if (!(doc.ActiveView is ViewPlan))
            {
                TaskDialog.Show("提示", "请在平面视图中运行插件！");
                return Result.Cancelled;
            }

            View view = doc.ActiveView;

            //程序在3D 支吊架视图中完成
            //改为
            //先找当前视图 对应的3D视图， 找不到再用3D 支吊架，命名规则 3D {当前视图名称}
            View3D default3Dview = null;
            View3D target3Dview = null;
            FilteredElementCollector fristCollector = new FilteredElementCollector(doc).OfClass(typeof(View3D));
            foreach (View3D view3 in fristCollector)
            {
                if ("3D 支吊架".Equals(view3.Name))
                {
                    default3Dview = view3;
                }
                if (string.Format("3D {0}", doc.ActiveView.Name).Equals(view3.Name))
                {
                    target3Dview = view3;
                }
            }
            if (null != target3Dview)
            {
                view3D = target3Dview;
            }
            else
            {
                if (null != default3Dview)
                {
                    view3D = default3Dview;
                }
                else
                {
                    message = string.Format("未找到3D视图： 3D 支吊架 或 3D {0}", doc.ActiveView.Name);
                    return Result.Cancelled;
                }
            }

            Reference reference = null;
            try
            {
                //reference = uIDoc.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.Element, new PipeFilter(), "选择一根起始点竖直的管");
                reference = uIDoc.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.Element, new SprinklerFilter(), "选择一根起始点的喷头");
            }
            catch (Exception)
            {
                TaskDialog.Show("提示", "已取消布置");
                return Result.Cancelled;
            }
            FamilyInstance sprinkler = doc.GetElement(reference) as FamilyInstance;
            Pipe pipe = null;
            foreach (Connector item in sprinkler.MEPModel.ConnectorManager.Connectors)
            {
                foreach (Connector item2 in item.AllRefs)
                {
                    if (item2.Owner.Category.Name.Equals("管道"))
                    {
                        pipe = item2.Owner as Pipe;
                    }
                    if (item2.Owner.Category.Name.Equals("管件"))
                    {
                        FamilyInstance familyInstance = item2.Owner as FamilyInstance;
                        foreach (Connector item3 in familyInstance.MEPModel.ConnectorManager.Connectors)
                        {
                            foreach (Connector item4 in item3.AllRefs)
                            {
                                if (item4.Owner.Category.Name.Equals("管道"))
                                {
                                    pipe = item4.Owner as Pipe;
                                }
                            }
                        }
                    }
                }
            }
            if (pipe == null)
            {
                TaskDialog.Show("revit", "未找到与喷头连接的管道，请检查喷头是否与管道正确连接");
                return Result.Failed;
            }
            HashSet<ElementId> newpipeIds = new HashSet<ElementId>();
            HashSet<ElementId> famids = new HashSet<ElementId>();
            famids = SearchMethod(pipe, newpipeIds, famids);
            using (Transaction tran = new Transaction(doc, "AddPipeHanger"))
            {
                tran.Start();
                AddHanger(famids);
                tran.Commit();
            }
            return Result.Succeeded;
        }
        XYZ direction = null;
        //获取点击水管连接的所有连接器
        private HashSet<ElementId> SearchMethod(Pipe pipe, HashSet<ElementId> pipeIds, HashSet<ElementId> famids)
        {
            //count3++;
            ConnectorSet connectorSet = pipe.ConnectorManager.Connectors;
            foreach (Connector item in connectorSet)
            {
                foreach (Connector item1 in item.AllRefs)
                {
                    if (item1.Owner is Pipe && !pipeIds.Contains(item1.Owner.Id))
                    {
                        pipeIds.Add(item1.Owner.Id);
                    }
                    if (item1.Owner is FamilyInstance && item1.Owner.Category.Name.Contains("管件") && !famids.Contains(item1.Owner.Id))
                    {
                        famids.Add(item1.Owner.Id);
                        if (direction == null)
                        {
                            double minValue = double.MaxValue;
                            double maxValue = double.MinValue;
                            XYZ p1 = null;
                            XYZ p2 = null;
                            foreach (Connector item2 in ((item1.Owner as FamilyInstance).MEPModel).ConnectorManager.Connectors)
                            {
                                if (item2.Origin.Z > maxValue)
                                {
                                    maxValue = item2.Origin.Z;
                                    p1 = item2.Origin;
                                }
                                if (item2.Origin.Z < minValue)
                                {
                                    minValue = item2.Origin.Z;
                                    p2 = item2.Origin;
                                }
                            }
                            XYZ xYZ = p2 - new XYZ(p1.X, p1.Y, p2.Z);
                            direction = xYZ.Normalize();
                        }
                        // 创建一个用于存储连接器坐标点的列表
                        List<XYZ> connectorPoints = new List<XYZ>();
                        var connectorSet1 = new List<Connector>();
                            
                        //List<Connector> connectors = new List<Connector>();
                        //获取每个管件的连接器
                        List<Connector> connectors1 = new List<Connector>();
                        // 遍历连接器并获取坐标点
                        foreach (Connector connector in ((item1.Owner as FamilyInstance).MEPModel).ConnectorManager.Connectors)
                        {
                            connectorSet1.Add(connector);

                            // 获取连接器的坐标点
                            XYZ point = connector.Origin;

                            // 将坐标点添加到列表中
                            connectorPoints.Add(point);
                        }
                        //如果管件为三通，则只取与起始点纯方向相等的两个连接器
                        if (connectorPoints.Count == 3)
                        {
                            Connector connector1 = null;
                            Connector connector2 = null;
                            bool noParallelism = true;
                            bool down = false;
                            for (int i = 0; i < connectorPoints.Count - 1; i++)
                            {
                                for (int j = i + 1; j < connectorPoints.Count; j++)
                                {
                                    XYZ point1 = connectorPoints[i];
                                    XYZ point2 = connectorPoints[j];
                                    XYZ direction1 = point1 - point2;
                                    if (direction1.Normalize().IsAlmostEqualTo(direction) || direction1.Normalize().Negate().IsAlmostEqualTo(direction))
                                    {
                                        noParallelism = false;
                                        foreach (Connector item2 in ((item1.Owner as FamilyInstance).MEPModel).ConnectorManager.Connectors)
                                        {
                                            if (item2.Origin.IsAlmostEqualTo(point1))
                                            {
                                                connector1 = item2;
                                            }
                                            if (item2.Origin.IsAlmostEqualTo(point2))
                                            {
                                                connector2 = item2;
                                            }
                                        }
                                        foreach (XYZ item2 in connectorPoints)
                                        {
                                            if (!(item2.IsAlmostEqualTo(point1) || item2.IsAlmostEqualTo(point2)))
                                            {
                                                XYZ point3 = item2;
                                                if (Math.Abs(point3.Z-point1.Z) > 0.0001 && point1.Z > point3.Z + 0.0001)
                                                {
                                                    down = true;
                                                }
                                            }
                                        }
                                    }
                                    if (connector1 != null && connector2 != null)
                                    {
                                        connectors1.Add(connector1);
                                        connectors1.Add(connector2);
                                        connectorSet1 = connectors1;
                                    }
                                }
                            }
                            //如果没有两个点的方向和初始管件的方向平行或三通的另一个连接器朝向为向下则不判断该管件
                            if (noParallelism || down)
                            {
                                famids.Remove(item1.Owner.Id);
                                continue;
                            }
                        }
                        //如果管件为四通，则只取与起始点纯方向相等的两个连接器
                        if (connectorPoints.Count == 4)
                        {
                            Connector connector1 = null;
                            Connector connector2 = null;
                            for (int i = 0; i < connectorPoints.Count - 1; i++)
                            {
                                for (int j = i+1; j < connectorPoints.Count; j++)
                                {
                                    XYZ point1 = connectorPoints[i];
                                    XYZ point2 = connectorPoints[j];
                                    XYZ direction1 = point1 - point2;
                                    if (direction1.Normalize().IsAlmostEqualTo(direction) || direction1.Normalize().Negate().IsAlmostEqualTo(direction))
                                    {
                                        foreach (Connector item2 in ((item1.Owner as FamilyInstance).MEPModel).ConnectorManager.Connectors)
                                        {
                                            if (item2.Origin.IsAlmostEqualTo(point1))
                                            {
                                                connector1 = item2;
                                            }
                                            if (item2.Origin.IsAlmostEqualTo(point2))
                                            {
                                                connector2 = item2;
                                            }
                                        }
                                    }
                                    if (connector1 != null && connector2 != null)
                                    {
                                        connectors1.Add(connector1);
                                        connectors1.Add(connector2);
                                        connectorSet1 = connectors1;
                                    }
                                }
                            }
                        }
                        
                        if (connectorPoints.Count == 2)
                        {
                            XYZ direction1 = (connectorPoints[0] - connectorPoints[1]).Normalize();
                            //如果两头弯头的连接器的Z轴坐标相等且两个坐标形成的纯方向不与初始点的纯方向相等就不判断该弯头连接的管道
                            if (Math.Abs(connectorPoints[0].Z - connectorPoints[1].Z) < 0.0001 && !(direction1.IsAlmostEqualTo(direction) || direction1.Negate().IsAlmostEqualTo(direction)))
                            {
                                famids.Remove(item1.Owner.Id);
                                continue;
                            }
                            //如果两头弯头Z坐标不相等且弯头上方没有喷头就不判断该弯头连接的管道    并在famids中移除该弯头id
                            else if (!(Math.Abs(connectorPoints[0].Z - connectorPoints[1].Z) < 0.0001))
                            {
                                ElementCategoryFilter elementCategoryFilter = new ElementCategoryFilter(BuiltInCategory.OST_Sprinklers);
                                ReferenceIntersector referenceIntersector = new ReferenceIntersector(elementCategoryFilter, FindReferenceTarget.All, view3D);
                                ReferenceWithContext referenceWithContext = referenceIntersector.FindNearest(connectorPoints[0], XYZ.BasisZ);
                                ReferenceWithContext referenceWithContext1 = referenceIntersector.FindNearest(connectorPoints[1], XYZ.BasisZ);
                                if (referenceWithContext == null && referenceWithContext1 == null)
                                {
                                    famids.Remove(item1.Owner.Id);
                                    continue;
                                }
                            }
                        }
                        //不将四通的管件加入喷头判断
                        //if (connectorPoints.Count != 4)
                        //{

                        //}
                        foreach (Connector item2 in connectorSet1)
                        {

                            foreach (Connector item3 in item2.AllRefs)
                            {
                                if (item3.Owner.Category.Name.Contains("喷头") || item3.Owner.Category.Name.Equals("管道系统"))
                                {
                                    continue;
                                }
                                Pipe newPipe = null; 
                                //判断管件的一边是否为另一个管件且入口直径小于65mm
                                if (item3.Owner.Category.Name.Contains("管件") /*&& item3.Owner.LookupParameter("入口直径").AsDouble() < (65 / 304.8)*/)
                                {
                                    famids.Add(item3.Owner.Id);
                                    foreach (Connector item4 in ((item3.Owner as FamilyInstance).MEPModel).ConnectorManager.Connectors)
                                    {
                                        foreach(Connector item5 in item4.AllRefs)
                                        {
                                            if (item5.Owner.Category.Name.Contains("管道") && item5.Owner.get_Parameter(BuiltInParameter.RBS_PIPE_DIAMETER_PARAM).AsDouble() <= (65 / 304.8))
                                            {
                                                Pipe pipe1 = item5.Owner as Pipe;
                                                if (newPipe == null || pipe1.get_Parameter(BuiltInParameter.RBS_PIPE_DIAMETER_PARAM).AsDouble() < newPipe.get_Parameter(BuiltInParameter.RBS_PIPE_DIAMETER_PARAM).AsDouble())
                                                {
                                                    newPipe = pipe1;
                                                }
                                                //newPipe = item5.Owner as Pipe;
                                                //break;
                                            }

                                        }
                                        //if (newPipe != null)
                                        //{
                                        //    break;
                                        //}
                                    }
                                }
                                if (item3.Owner.Category.Name.Contains("管道"))
                                {
                                    newPipe = item3.Owner as Pipe;
                                }
                                //else
                                //{
                                //    newPipe = item3.Owner as Pipe;
                                //}
                                if (!pipeIds.Contains(newPipe.Id) && newPipe.get_Parameter(BuiltInParameter.RBS_PIPE_DIAMETER_PARAM).AsDouble() < (65 /304.8))
                                {
                                    pipeIds.Add(newPipe.Id);
                                    SearchMethod(newPipe, pipeIds,famids);
                                }
                            }
                        }
                    }
                    if (item1.Owner is FamilyInstance && item1.Owner.Category.Name.Contains("管道附件"))
                    {
                        foreach (Connector item2 in ((item1.Owner as FamilyInstance).MEPModel).ConnectorManager.Connectors)
                        {
                            foreach (Connector item3 in item2.AllRefs)
                            {
                                if (item3.Owner.Category.Name.Contains("喷头"))
                                {
                                    continue;
                                }
                                Pipe newPipe = item3.Owner as Pipe;
                                if (!pipeIds.Contains(newPipe.Id))
                                {
                                    SearchMethod(newPipe, pipeIds, famids);
                                }
                            }
                        }
                    }
                }
            }
            return famids;
          //return pipeIds;
        }
        //根据喷头判断是否需要添加吊架
        private void AddHanger(HashSet<ElementId> famids)
        {
          //Level level = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Levels).OfClass(typeof(Level)).WhereElementIsNotElementType().ToElements().Where(m => m.Name == "B1(-5.600=-0.800)").ToList().FirstOrDefault() as Level;
            double min = double.MaxValue;
            double max = double.MinValue;
            XYZ sxp1 = null;
            XYZ fx = null;
            XYZ centerPoint = null;
            XYZ norDirection = null;
            int count = famids.Count;
            FamilySymbol familySymbol1 = new FilteredElementCollector(doc).OfClass(typeof(FamilySymbol)).WhereElementIsElementType().Where(x => x.Name == "喷淋").First() as FamilySymbol;
            if (!familySymbol1.IsActive)
            {
                familySymbol1.Activate();
            }
            //FamilySymbol familySymbol1 = doc.GetElement(new ElementId(7196226)) as FamilySymbol;
            //FamilySymbol familySymbol1 = (doc.GetElement(reference1) as FamilyInstance).Symbol;
            FamilySymbol familySymbol2 = new FilteredElementCollector(doc).OfClass(typeof(FamilySymbol)).WhereElementIsElementType().Where(x => x.Name == "照明和喷淋吊架-平行").First() as FamilySymbol;
            if (!familySymbol2.IsActive)
            {
                familySymbol2.Activate();
            }
            foreach (ElementId elementId in famids)
            {
                ////若最后一个管件只有两个连接器则不检测
                count--;
                ConnectorSet connectorSet = (doc.GetElement(elementId) as FamilyInstance).MEPModel.ConnectorManager.Connectors;
                //if (count == 0)
                //{
                //    int count1 = 0;
                //    foreach (Connector item in connectorSet)
                //    {
                //        count1++;
                //    }
                //    if (count1 == 2)
                //    {
                //        break;
                //    }
                //}
                min = double.MaxValue;
                max = double.MinValue;
                // 创建一个用于存储连接器坐标点的列表
                List<XYZ> connectorPoints = new List<XYZ>();
                // 遍历连接器并获取坐标点
                foreach (Connector connector in connectorSet)
                {
                    // 获取连接器的坐标点
                    XYZ point = connector.Origin;

                    // 将坐标点添加到列表中
                    connectorPoints.Add(point);
                }
                //如果管件的连接器数量等于4就直接跳过，不再判断该管件上方是否存在喷头
                if (connectorPoints.Count == 4)
                {
                    continue;
                }
                //若管件的连接器数量为3，该三通垂直的那个连接器方向不为垂直向上时不再判断该管件上方是否存在喷头
                //if (connectorPoints.Count == 3)
                //{
                //    XYZ p = null;
                //    foreach (XYZ point in connectorPoints)
                //    {
                //        if (!(Math.Abs(centerPoint.Z - point.Z) < 0.0001) && centerPoint.Z - point.Z > 0.0001)
                //        {
                //            p = point;
                //        }
                //    }
                //    if(p == null)
                //    {
                //        continue;
                //    }
                //}
                ConnectorSet connectors = (doc.GetElement(elementId) as FamilyInstance).MEPModel.ConnectorManager.Connectors;
                foreach (Connector connector in connectors)
                {
                    if (connector.Origin.Z > max)
                    {
                        max = connector.Origin.Z;
                        sxp1 = connector.Origin;
                    }
                    if (connector.Origin.Z < min)
                    {
                        min = connector.Origin.Z;
                        fx = connector.Origin;
                    }
                }
                if (centerPoint == null)
                {
                    centerPoint = new XYZ(sxp1.X, sxp1.Y, fx.Z);
                }
                XYZ directionVector = new XYZ(sxp1.X, sxp1.Y, fx.Z) - fx;
                if (norDirection == null)
                {
                    norDirection = directionVector.Normalize().Negate();
                }
                //判断射线点上方是否存在喷头
                ElementCategoryFilter elementCategoryFilter = new ElementCategoryFilter(BuiltInCategory.OST_Sprinklers);
                ReferenceIntersector referenceIntersector = new ReferenceIntersector(elementCategoryFilter, FindReferenceTarget.All, view3D);
                ReferenceWithContext referenceWithContext = referenceIntersector.FindNearest(sxp1, XYZ.BasisZ);
                if (referenceWithContext == null)
                {
                    continue;
                }
                sxp1 = new XYZ(sxp1.X, sxp1.Y, fx.Z);
                bool reverse = true;
                //此时sxp1为吊架插入点
                if (count != 0)
                {
                    sxp1 = sxp1 + norDirection * (500 / 304.8);
                }
                if (count == 0)
                {
                    sxp1 = sxp1 + norDirection * (500 / 304.8);
                    ElementCategoryFilter elementCategoryFilter3 = new ElementCategoryFilter(BuiltInCategory.OST_PipeCurves);
                    ReferenceIntersector referenceIntersector3 = new ReferenceIntersector(elementCategoryFilter3, FindReferenceTarget.All, view3D);
                    ReferenceWithContext referenceWithContext3 = referenceIntersector3.FindNearest(sxp1, XYZ.BasisZ);
                    //if (referenceWithContext3 == null)
                    //{
                    //    Plane plane = Plane.CreateByNormalAndOrigin(new XYZ(1, 0, 0), sxp1);
                    //    SketchPlane sketchPlane = SketchPlane.Create(doc, plane);
                    //    Line line = Line.CreateBound(sxp1, sxp1 + XYZ.BasisZ * (500/304.8));
                    //    ModelCurve curve = doc.Create.NewModelCurve(line, sketchPlane);
                    //}
                    if (referenceWithContext3 != null)
                    {
                        Reference reference = referenceWithContext3.GetReference();
                        Pipe pipe1 = doc.GetElement(reference) as Pipe;
                        double length = pipe1.get_Parameter(BuiltInParameter.CURVE_ELEM_LENGTH).AsDouble();
                        List<ElementId> ids = new List<ElementId>();
                        foreach (Connector item in connectorSet)
                        {
                            foreach (Connector item2 in item.AllRefs)
                            {
                                if (item2.Owner is Pipe)
                                {
                                    ids.Add(item2.Owner.Id);
                                }
                            }
                        }
                        if (length > (500 / 304.8) && ids.Contains(pipe1.Id))
                        {
                            reverse = false;
                        }
                    }
                    if (reverse)
                    {
                        sxp1 = sxp1 - norDirection * (1000 / 304.8);
                    }
                    //sxp1 = sxp1 - norDirection * (500 / 304.8);
                }
                ////获取吊架插入点到下楼板的距离
                //XYZ lowFloorPoint = Utils.GetClearHeightPoint(view3D, doc, sxp1);
                //XYZ dfd = Utils.GetClearHeightPoint1(view3D, doc, sxp1);
                ////创建模型线
                ////Plane plane = Plane.CreateByNormalAndOrigin(new XYZ(1, 0, 0), sxp1);
                ////SketchPlane sketchPlane = SketchPlane.Create(doc, plane);
                ////Line line = Line.CreateBound(sxp1, dfd);
                ////ModelCurve curve = doc.Create.NewModelCurve(line, sketchPlane);
                //double lowFloorDistance = sxp1.DistanceTo(lowFloorPoint);
                ////获取吊架插入点到上楼板的距离
                double upFloorDistance = Utils.GetClearHeightUp(view3D, doc, sxp1);
                ////a_楼板底高的参数
                //double heightFloor = lowFloorDistance + upFloorDistance;
                //获取旋转吊架需要的参数
                double angle = directionVector.AngleTo(XYZ.BasisX);
                Line axis = Line.CreateBound(sxp1,new XYZ(sxp1.X,sxp1.Y, 0));
                //用射线找到被吊架布置的管
                ElementCategoryFilter elementCategoryFilter2 = new ElementCategoryFilter(BuiltInCategory.OST_PipeCurves);
                ReferenceIntersector referenceIntersector2 = new ReferenceIntersector(elementCategoryFilter2, FindReferenceTarget.All, view3D);
                ReferenceWithContext referenceWithContext2 = referenceIntersector2.FindNearest(sxp1, XYZ.BasisZ);
               //IList<ReferenceWithContext> referenceWithContext45 = referenceIntersector2.Find(sxp1, XYZ.BasisZ);
               // foreach (var item in referenceWithContext45)
               // {
               //     TaskDialog.Show("fdf", doc.GetElement(item.GetReference()).Id.ToString());
               // }
               // TaskDialog.Show("sd", referenceWithContext45.Count.ToString());
                if (referenceWithContext2 == null)
                {
                    referenceWithContext2 = referenceIntersector2.FindNearest(sxp1,XYZ.BasisZ.Negate());
                }
                Pipe pipe = doc.GetElement(referenceWithContext2.GetReference()) as Pipe;
                //获取管道标高作为吊架的标高
                string levelName = pipe.get_Parameter(BuiltInParameter.RBS_START_LEVEL_PARAM).AsValueString();
                Level level = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Levels).OfClass(typeof(Level)).WhereElementIsNotElementType().ToElements().Where(m => m.Name == levelName).ToList().FirstOrDefault() as Level;
                //判断下方有无桥架以使用不同的吊架
                ElementCategoryFilter elementCategoryFilter1 = new ElementCategoryFilter(BuiltInCategory.OST_CableTray);
                ReferenceIntersector referenceIntersector1 = new ReferenceIntersector(elementCategoryFilter1, FindReferenceTarget.All, view3D);
                ReferenceWithContext referenceWithContext1 = referenceIntersector1.FindNearest(sxp1, XYZ.BasisZ.Negate());
                bool name = true;
                if (referenceWithContext1 != null)
                {
                    Reference reference = referenceWithContext1.GetReference();
                    CableTray cableTray = doc.GetElement(reference) as CableTray;
                    if (!cableTray.Name.Equals("照明线槽"))
                    {
                        name = false;
                    }
                }
                if (referenceWithContext1 == null || !name)
                {
                    ///获取管道的直径和中间高程
                    double diameter = pipe.get_Parameter(BuiltInParameter.RBS_PIPE_DIAMETER_PARAM).AsDouble();
                    double middleElevation = pipe.get_Parameter(BuiltInParameter.RBS_END_OFFSET_PARAM).AsDouble();
                    //Line axis = Line.CreateBound(new XYZ(sxp1.X, sxp1.Y, fx.Z), fx);
                    //FamilySymbol familySymbol = doc.GetElement(new ElementId(6264779)) as FamilySymbol;
                    //FamilySymbol familySymbol = doc.GetElement(new ElementId(5957568)) as FamilySymbol;
                    FamilyInstance familyInstance = doc.Create.NewFamilyInstance(sxp1, familySymbol1, level, StructuralType.NonStructural);
                    //ElementTransformUtils.RotateElement(doc, familyInstance.Id, axis,0.5 * Math.PI);
                    //设置与楼板有关参数
                    familyInstance.get_Parameter(BuiltInParameter.INSTANCE_FREE_HOST_OFFSET_PARAM).Set(0);
                    //familyInstance.LookupParameter("a_楼板底高").Set(heightFloor + 200 / 304.8);
                    familyInstance.LookupParameter("a_楼板底高").Set(middleElevation + upFloorDistance);
                    //设置与管道有关参数
                    familyInstance.LookupParameter("管道公称直径").Set(diameter);
                    familyInstance.LookupParameter("管道中心标高").Set(middleElevation);
                    //旋转吊架
                    if (angle > 0.5 * Math.PI)
                    {
                        angle = Math.PI - angle;
                    }
                    ElementTransformUtils.RotateElement(doc, familyInstance.Id, axis, 0.5 * Math.PI - angle);
                    Transform transform = familyInstance.GetTransform();

                    if (Math.Abs(transform.OfVector(XYZ.BasisX).AngleTo(directionVector) - 0.5 * Math.PI) > 0.001)
                    {
                        ElementTransformUtils.RotateElement(doc, familyInstance.Id, axis, -2 * (0.5 * Math.PI - angle));
                        //ElementTransformUtils.RotateElement(doc, familyInstance.Id, axis, 0.5 * Math.PI);
                    }
                }
                else if (referenceWithContext1 != null && name)
                {
                    //获取管道的直径和中间高程
                    double diameter = pipe.get_Parameter(BuiltInParameter.RBS_PIPE_DIAMETER_PARAM).AsDouble();
                    double middleElevation = pipe.get_Parameter(BuiltInParameter.RBS_END_OFFSET_PARAM).AsDouble();
                    //获取找到的桥架的参数用以设置吊架参数
                    Reference reference = referenceWithContext1.GetReference();
                    CableTray cableTray = doc.GetElement(reference) as CableTray;
                    //获取桥架的底标高和宽度
                    double lowLevel = cableTray.get_Parameter(BuiltInParameter.RBS_CTC_BOTTOM_ELEVATION).AsDouble();
                    double width = cableTray.get_Parameter(BuiltInParameter.RBS_CABLETRAY_WIDTH_PARAM).AsDouble();
                    //Line axis = Line.CreateBound(new XYZ(sxp1.X, sxp1.Y, fx.Z), fx);
                    //ElementTransformUtils.RotateElement(doc, familyInstance.Id, axis,0.5 * Math.PI);
                    //ElementId为族实例id时用这个方法获取族类型
                    //FamilySymbol familySymbol = (doc.GetElement(new ElementId(6275133)) as FamilyInstance).Symbol;
                    //ElementId为族类型id时用这个方法获取族类型
                    //FamilySymbol familySymbol = doc.GetElement(new ElementId(6275133)) as FamilySymbol;
                    FamilyInstance familyInstance = doc.Create.NewFamilyInstance(sxp1, familySymbol2, level, StructuralType.NonStructural);
                    //设置布置吊架的参数
                    //设置与楼板有关参数
                    familyInstance.get_Parameter(BuiltInParameter.INSTANCE_FREE_HOST_OFFSET_PARAM).Set(0);
                    //familyInstance.LookupParameter("a_楼板底高").Set(heightFloor);
                    familyInstance.LookupParameter("a_楼板底高").Set(middleElevation + upFloorDistance);
                    //设置与管道有关参数
                    familyInstance.LookupParameter("管道公称直径").Set(diameter);
                    familyInstance.LookupParameter("管道中心标高").Set(middleElevation);
                    //设置与桥架有关参数
                    familyInstance.LookupParameter("桥架底标高").Set(lowLevel);
                    familyInstance.LookupParameter("吊架套筒长度").Set(width);
                    //旋转吊架
                    if (angle > 0.5 * Math.PI)
                    {
                        angle = Math.PI - angle;
                    }
                    ElementTransformUtils.RotateElement(doc, familyInstance.Id, axis, 0.5 * Math.PI - angle);
                    Transform transform = familyInstance.GetTransform();

                    if (Math.Abs(transform.OfVector(XYZ.BasisX).AngleTo(directionVector) - 0.5 * Math.PI) > 0.001)
                    {
                        ElementTransformUtils.RotateElement(doc, familyInstance.Id, axis, -2 * (0.5 * Math.PI - angle));
                    }
                }
            }
        }

    }
}
