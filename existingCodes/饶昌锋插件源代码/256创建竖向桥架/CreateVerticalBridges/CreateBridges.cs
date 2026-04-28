using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Autodesk.Revit.DB.Plumbing;
using System.Xml.Linq;

namespace CreateVerticalBridges
{
    public class DimFilter : ISelectionFilter
    {
        public bool AllowElement(Element elem)
        {
            if (elem is Dimension)
            {
                return true;
            }return false;
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            return true;
        }
    }

    public class CreateBridges
    {
        public static bool CreateStart(UIApplication uiApp, Document doc, int createType)
        {
            UIDocument uidoc = uiApp.ActiveUIDocument;
            MEPCurve element1 = null;
            MEPCurve element2 = null;
            Connector conn1;
            Connector conn2;
            CableTrayFilter cableTrayFilter = new CableTrayFilter();
            try
            {
                //获取两根桥架
                Reference reference1 = uidoc.Selection.PickObject(ObjectType.Element, cableTrayFilter, "请选择主桥架(被垂直的桥架)");
                element1 = doc.GetElement(reference1) as MEPCurve;
                Reference reference2 = uidoc.Selection.PickObject(ObjectType.Element, cableTrayFilter, "请选择支线桥架");
                element2 = doc.GetElement(reference2) as MEPCurve;
            }
            catch (Autodesk.Revit.Exceptions.OperationCanceledException)
            {
                return false;
            }
            double width = 0;
            double height = 0;
            width += element2.get_Parameter(BuiltInParameter.RBS_CABLETRAY_WIDTH_PARAM).AsDouble();
            height += element2.get_Parameter(BuiltInParameter.RBS_CABLETRAY_HEIGHT_PARAM).AsDouble();
            //判断是否有高差
            if (element1.get_Parameter(BuiltInParameter.RBS_END_OFFSET_PARAM).AsDouble() == element2.get_Parameter(BuiltInParameter.RBS_END_OFFSET_PARAM).AsDouble())
            {
                TaskDialog.Show("提示", "无高差");
                return false;
            }
            //直线型的创建
            if (createType == 1)
            {
                //element1是高的
                if (element1.get_Parameter(BuiltInParameter.RBS_END_OFFSET_PARAM).AsDouble() < element2.get_Parameter(BuiltInParameter.RBS_END_OFFSET_PARAM).AsDouble())
                {
                    MEPCurve temp = element1;
                    element1 = element2;
                    element2 = temp;
                }
                //获取距离近的两个连接器
                Util.GetClosePoint(element1, element2, out conn1, out conn2);
                double elementTop = element1.get_Parameter(BuiltInParameter.RBS_CTC_TOP_ELEVATION).AsDouble() - element1.get_Parameter(BuiltInParameter.RBS_OFFSET_PARAM).AsDouble();
                //double elementBottom = element2.get_Parameter(BuiltInParameter.RBS_CTC_BOTTOM_ELEVATION).AsDouble() - element2.get_Parameter(BuiltInParameter.RBS_OFFSET_PARAM).AsDouble();
                double elementBottom = int.Parse(element2.get_Parameter(BuiltInParameter.RBS_CTC_BOTTOM_ELEVATION).AsValueString()) - int.Parse(element2.get_Parameter(BuiltInParameter.RBS_OFFSET_PARAM).AsValueString());
                //TaskDialog.Show("Asda0",elementBottom.ToString());
                //创建竖向桥架
                using (Transaction tran = new Transaction(doc, "创建桥架"))
                {
                    tran.Start();
                    CableTray cable2 = CableTray.Create(doc, element2.GetTypeId(), conn2.OtherConn().Origin, new XYZ(conn1.Origin.X, conn1.Origin.Y, conn2.Origin.Z), element1.LevelId);
                    cable2.get_Parameter(BuiltInParameter.RBS_CABLETRAY_WIDTH_PARAM).Set(width);
                    cable2.get_Parameter(BuiltInParameter.RBS_CABLETRAY_HEIGHT_PARAM).Set(height);
                    doc.Delete(element2.Id);
                    CableTray cableTray = CableTray.Create(doc, element1.GetTypeId(), conn1.Origin, new XYZ(conn1.Origin.X, conn1.Origin.Y, conn2.Origin.Z), element1.LevelId);
                    //CableTray cableTray = CableTray.Create(doc, element1.GetTypeId(), conn1.Origin + new XYZ(0, 0, elementTop), new XYZ(conn1.Origin.X, conn1.Origin.Y, conn2.Origin.Z + elementBottom / 304.8), element1.LevelId);
                    //连接器连接桥架
                    //foreach (Connector item in cableTray.ConnectorManager.Connectors)
                    //{
                    //    if (item.Id == 0)
                    //    {
                    //        item.ConnectTo(conn2);
                    //    }
                    //    else
                    //    {
                    //        item.ConnectTo(conn1);
                    //    }
                    //}
                    Util.RotatingBridge(doc, cableTray, conn1, conn2);
                    Parameter widthParameter = cableTray.get_Parameter(BuiltInParameter.RBS_CABLETRAY_WIDTH_PARAM);
                    Parameter heightParameter = cableTray.get_Parameter(BuiltInParameter.RBS_CABLETRAY_HEIGHT_PARAM);
                    widthParameter.Set(width);
                    heightParameter.Set(height);
                    tran.Commit();
                }
            }
            //T型的创建
            if (createType == 2)
            {
                //element1被垂直的管  element2垂直的管
                Line mEPCurve1Line = (element1.Location as LocationCurve).Curve as Line;
                Line mEPCurve2Line = (element2.Location as LocationCurve).Curve as Line;
                Connector connector = null;
                double distanceMin = double.MaxValue;
                foreach (Connector item in element2.ConnectorManager.Connectors)
                {
                    if (mEPCurve1Line.Distance(item.Origin) < distanceMin)
                    {
                        connector = item;
                        distanceMin = mEPCurve1Line.Distance(item.Origin);
                    }
                }

                //垂直管在被垂直管的上的投影点
                XYZ projectPoint = mEPCurve1Line.Project(connector.Origin).XYZPoint;
                // 被垂直桥架相对支线桥架的高度
                bool createDown = false;
                if (projectPoint.Z < connector.Origin.Z) createDown = true;

                using (Transaction tran = new Transaction(doc, "创建桥架"))
                {
                    tran.Start();
                    double elem1Z = projectPoint.Z;
                    double elem2Z = connector.Origin.Z;
                    //CableTray cableTray = CableTray.Create(doc, element1.GetTypeId(), new XYZ(projectPoint.X, projectPoint.Y, (element1.Location as LocationCurve).Curve.GetEndPoint(0).Z + element1.Height / 2 + 20 / 304.8), new XYZ(projectPoint.X, projectPoint.Y, connector.Origin.Z), element1.LevelId == ElementId.InvalidElementId ? element1.get_Parameter(BuiltInParameter.RBS_START_LEVEL_PARAM).AsElementId() : element1.LevelId);
                    CableTray cableTray = CableTray.Create(doc, element1.GetTypeId(), new XYZ(projectPoint.X, projectPoint.Y, elem1Z), new XYZ(projectPoint.X, projectPoint.Y, elem2Z), element1.LevelId == ElementId.InvalidElementId ? element1.get_Parameter(BuiltInParameter.RBS_START_LEVEL_PARAM).AsElementId() : element1.LevelId);
                    Parameter widthParameter = cableTray.get_Parameter(BuiltInParameter.RBS_CABLETRAY_WIDTH_PARAM);
                    Parameter heightParameter = cableTray.get_Parameter(BuiltInParameter.RBS_CABLETRAY_HEIGHT_PARAM);
                    widthParameter.Set(width);
                    heightParameter.Set(height);
                    Util.RotatingBridge(doc, cableTray, element2, createDown, GetConnector(element2, 0));
                    //CableTray cableTray = CableTray.Create(doc, element1.GetTypeId(), projectPoint, new XYZ(projectPoint.X, projectPoint.Y, connector.Origin.Z), element1.LevelId);
                    //CableTray cableTray = CableTray.Create(doc, element1.GetTypeId(), new XYZ(projectPoint.X, projectPoint.Y, (projectPoint.Z + connector.Origin.Z) / 2), new XYZ(projectPoint.X, projectPoint.Y, connector.Origin.Z), element1.LevelId);
                    
                    // 监听桥架跟随移动事件
                    //ListenerBridges listenerBridges = new ListenerBridges(cableTray, element1, uiApp);
                    //listenerBridges.Executer();

                    //Parameter widthParameter = cableTray.get_Parameter(BuiltInParameter.RBS_CABLETRAY_WIDTH_PARAM);
                    //Parameter heightParameter = cableTray.get_Parameter(BuiltInParameter.RBS_CABLETRAY_HEIGHT_PARAM);
                    //widthParameter.Set(width);
                    //heightParameter.Set(height);
                    //Util.RotatingBridge(doc, cableTray, element2);

                    tran.Commit();
                }
            }
            //L型创建
            if (createType == 3)
            {
                if (element1.get_Parameter(BuiltInParameter.RBS_END_OFFSET_PARAM).AsDouble() < element2.get_Parameter(BuiltInParameter.RBS_END_OFFSET_PARAM).AsDouble())
                {
                    MEPCurve temp = element1;
                    element1 = element2;
                    element2 = temp;
                }
                //获取距离近的两个连接器
                Util.GetClosePoint(element1, element2, out conn1, out conn2);
                double elementTop = element1.get_Parameter(BuiltInParameter.RBS_CTC_TOP_ELEVATION).AsDouble() - element1.get_Parameter(BuiltInParameter.RBS_OFFSET_PARAM).AsDouble();
                double elementBottom = element2.get_Parameter(BuiltInParameter.RBS_CTC_BOTTOM_ELEVATION).AsDouble() - element2.get_Parameter(BuiltInParameter.RBS_OFFSET_PARAM).AsDouble();
                //double elementBottom = int.Parse(element2.get_Parameter(BuiltInParameter.RBS_CTC_BOTTOM_ELEVATION).AsValueString()) - int.Parse(element2.get_Parameter(BuiltInParameter.RBS_OFFSET_PARAM).AsValueString());
                using (Transaction tran = new Transaction(doc, "创建桥架"))
                {
                    tran.Start();
                    CableTray cable1 = null;
                    CableTray cable2 = null;
                    if (Math.Abs( conn1.Origin.X - conn1.OtherConn().Origin.X)>0.000001)
                    {
                        cable1 = CableTray.Create(doc, element1.GetTypeId(), conn1.OtherConn().Origin, new XYZ(conn2.Origin.X, conn1.Origin.Y, conn1.Origin.Z), element1.LevelId);
                        cable2 = CableTray.Create(doc, element2.GetTypeId(), conn2.OtherConn().Origin, new XYZ(conn2.Origin.X, conn1.Origin.Y, conn2.Origin.Z), element2.LevelId);
                    }
                    else
                    {
                        cable1 = CableTray.Create(doc, element1.GetTypeId(), conn1.OtherConn().Origin, new XYZ(conn1.Origin.X, conn2.Origin.Y, conn1.Origin.Z), element1.LevelId);
                        cable2 = CableTray.Create(doc, element2.GetTypeId(), conn2.OtherConn().Origin, new XYZ(conn1.Origin.X, conn2.Origin.Y, conn2.Origin.Z), element2.LevelId);
                    }

                    cable1.get_Parameter(BuiltInParameter.RBS_CABLETRAY_WIDTH_PARAM).Set(element1.get_Parameter(BuiltInParameter.RBS_CABLETRAY_WIDTH_PARAM).AsDouble());
                    cable1.get_Parameter(BuiltInParameter.RBS_CABLETRAY_HEIGHT_PARAM).Set(element1.get_Parameter(BuiltInParameter.RBS_CABLETRAY_HEIGHT_PARAM).AsDouble());
                    cable2.get_Parameter(BuiltInParameter.RBS_CABLETRAY_WIDTH_PARAM).Set(element2.get_Parameter(BuiltInParameter.RBS_CABLETRAY_WIDTH_PARAM).AsDouble());
                    cable2.get_Parameter(BuiltInParameter.RBS_CABLETRAY_HEIGHT_PARAM).Set(element2.get_Parameter(BuiltInParameter.RBS_CABLETRAY_HEIGHT_PARAM).AsDouble());
                    doc.Delete(element1.Id);
                    doc.Delete(element2.Id);
                    Util.GetClosePoint(cable1, cable2, out conn1, out conn2);
                    //CableTray cableTray = CableTray.Create(doc, cable1.GetTypeId(), conn1.Origin + new XYZ(0, 0, elementTop), new XYZ(conn1.Origin.X, conn1.Origin.Y, conn2.Origin.Z + elementBottom), cable1.LevelId);
                    CableTray cableTray = CableTray.Create(doc, cable1.GetTypeId(), conn1.Origin, new XYZ(conn1.Origin.X, conn1.Origin.Y, conn2.Origin.Z), cable1.LevelId);

                    Util.RotatingBridge(doc, cableTray, conn1, conn2);
                    Parameter widthParameter = cableTray.get_Parameter(BuiltInParameter.RBS_CABLETRAY_WIDTH_PARAM);
                    Parameter heightParameter = cableTray.get_Parameter(BuiltInParameter.RBS_CABLETRAY_HEIGHT_PARAM);
                    widthParameter.Set(width);
                    heightParameter.Set(height);
                    tran.Commit();
                }
            }
            return true;
        }
        public static bool CreateStart2(UIApplication uiApp, Document doc, int createType)
        {
            UIDocument uidoc = uiApp.ActiveUIDocument;
            MEPCurve element1 = null;
            MEPCurve element2 = null;
            Connector conn1;
            Connector conn2;

            //string below = "testText";

            //Reference refer;
            //try
            //{
            //    refer = uidoc.Selection.PickObject(ObjectType.PointOnElement, new DimFilter(), "111");
            //}
            //catch (Exception)
            //{
            //    return false;
            //}
            //Element element = doc.GetElement(refer);
            //Dimension dimension = element as Dimension;
            //List<DimensionSegment> dimensionSegments = dimension.Segments.Cast<DimensionSegment>().ToList();
            ////TaskDialog.Show("revit", (element is Dimension) + "\n" + refer.GlobalPoint);
            //DimensionSegment ds = dimensionSegments.OrderBy(d => d.TextPosition.DistanceTo(refer.GlobalPoint)).FirstOrDefault();
            //using (Transaction t = new Transaction(doc, "dimAnnotation"))
            //{
            //    t.Start();
            //    ds.Below = below;
            //    t.Commit();
            //}

            //return true;


            CableTrayFilter cableTrayFilter = new CableTrayFilter();
            try
            {
                //获取两根桥架
                Reference reference1 = uidoc.Selection.PickObject(ObjectType.Element, cableTrayFilter, "请选择主桥架(被垂直的桥架)");
                element1 = doc.GetElement(reference1) as MEPCurve;
                Reference reference2 = uidoc.Selection.PickObject(ObjectType.Element, cableTrayFilter, "请选择支线桥架");
                element2 = doc.GetElement(reference2) as MEPCurve;
            }
            catch (Autodesk.Revit.Exceptions.OperationCanceledException)
            {
                return false;
            }
            double width = 0;
            double height = 0;
            width += element2.get_Parameter(BuiltInParameter.RBS_CABLETRAY_WIDTH_PARAM).AsDouble();
            height += element2.get_Parameter(BuiltInParameter.RBS_CABLETRAY_HEIGHT_PARAM).AsDouble();
            //判断是否有高差
            if (element1.get_Parameter(BuiltInParameter.RBS_END_OFFSET_PARAM).AsDouble() == element2.get_Parameter(BuiltInParameter.RBS_END_OFFSET_PARAM).AsDouble())
            {
                TaskDialog.Show("提示", "无高差");
                return false;
            }
            //直线型的创建
            if (createType == 1)
            {
                TransactionGroup TG = new TransactionGroup(doc, "创建桥架");
                TG.Start();
                using (Transaction t = new Transaction(doc, "对齐直线型桥架"))
                {
                    t.Start();
                    Line line = Util.GetAlignHorLine(element1, element2);
                    (element2.Location as LocationCurve).Curve = line;
                    t.Commit();
                }

                //element1是高的
                if (element1.get_Parameter(BuiltInParameter.RBS_END_OFFSET_PARAM).AsDouble() < element2.get_Parameter(BuiltInParameter.RBS_END_OFFSET_PARAM).AsDouble())
                {
                    MEPCurve temp = element1;
                    element1 = element2;
                    element2 = temp;
                }

                CableTrayType cableTrayType = doc.GetElement(element1.GetTypeId()) as CableTrayType;
                ElementId oldElbowId1 = cableTrayType.get_Parameter(BuiltInParameter.RBS_CURVETYPE_DEFAULT_ELBOWUP_PARAM).AsElementId();
                ElementId oldElbowId2 = cableTrayType.get_Parameter(BuiltInParameter.RBS_CURVETYPE_DEFAULT_ELBOWDOWN_PARAM).AsElementId();

                FamilySymbol verSymbol = new FilteredElementCollector(doc).WhereElementIsElementType().OfCategory(BuiltInCategory.OST_CableTrayFitting).Cast<FamilySymbol>()
                    .Where(s => s.FamilyName == "直线型桥架竖向弯头连接件").FirstOrDefault(s => s.Name == cableTrayType.Name);
                if (verSymbol == null)
                {
                    try
                    {
                        Util.LoadFamily(doc, Resource1.直线型桥架竖向弯头连接件, "直线型桥架竖向弯头连接件");
                        verSymbol = new FilteredElementCollector(doc).WhereElementIsElementType().OfCategory(BuiltInCategory.OST_CableTrayFitting).Cast<FamilySymbol>()
                    .Where(s => s.FamilyName == "直线型桥架竖向弯头连接件").FirstOrDefault(s => s.Name == cableTrayType.Name);
                    }
                    catch { }
                }

                if (verSymbol == null)
                {
                    TaskDialog.Show("提示", $"未找到指定桥架连接件: 直线型桥架竖向弯头连接件->{cableTrayType.Name}，无法进行连接");
                    return false;
                }

                Util.GetClosePoint(element1, element2, out conn1, out conn2);

                
                //创建竖向桥架
                using (Transaction tran = new Transaction(doc, "创建桥架"))
                {
                    tran.Start();

                    if (!verSymbol.IsActive)
                    {
                        verSymbol.Activate();
                    }

                    // 设置桥架弯通和T型三通使用的连接件
                    // 弯通
                    cableTrayType.get_Parameter(BuiltInParameter.RBS_CURVETYPE_DEFAULT_ELBOWUP_PARAM).Set(verSymbol.Id);
                    cableTrayType.get_Parameter(BuiltInParameter.RBS_CURVETYPE_DEFAULT_ELBOWDOWN_PARAM).Set(verSymbol.Id);

                    CableTray cableTray = CableTray.Create(doc, cableTrayType.Id, conn1.Origin - conn1.CoordinateSystem.BasisY.Negate() * (element1.Height / 2), conn2.Origin + conn2.CoordinateSystem.BasisY.Negate() * (element2.Height / 2), element1.LevelId == ElementId.InvalidElementId ? element1.get_Parameter(BuiltInParameter.RBS_START_LEVEL_PARAM).AsElementId() : element1.LevelId);
                    cableTray.get_Parameter(BuiltInParameter.RBS_CABLETRAY_WIDTH_PARAM).Set(element1.Width);
                    cableTray.get_Parameter(BuiltInParameter.RBS_CABLETRAY_HEIGHT_PARAM).Set(element1.Height);
                    Util.RotatingBridge(doc, cableTray, element2, true, GetConnector(element1, 0));

                    doc.Create.NewElbowFitting(conn1, GetConnector(cableTray, 0));
                    doc.Create.NewElbowFitting(conn2, GetConnector(cableTray, 1));

                    ////连接器连接桥架
                    //foreach (Connector item in cableTray.ConnectorManager.Connectors)
                    //{
                    //    if (item.Id == 0)
                    //    {
                    //        doc.Create.NewElbowFitting(item, GetConnector(cable2, conn2.Id));
                    //        //item.ConnectTo(conn2);
                    //    }
                    //    else
                    //    {
                    //        doc.Create.NewElbowFitting(item, GetConnector(element1, conn1.Id));
                    //        //item.ConnectTo(conn1);
                    //    }
                    //}

                    // 恢复桥架原来使用的弯通和三通连接件
                    cableTrayType.get_Parameter(BuiltInParameter.RBS_CURVETYPE_DEFAULT_ELBOWUP_PARAM).Set(oldElbowId1);
                    cableTrayType.get_Parameter(BuiltInParameter.RBS_CURVETYPE_DEFAULT_ELBOWDOWN_PARAM).Set(oldElbowId2);

                    tran.Commit();
                }
                TG.Assimilate();
            }
            //T型的创建
            if (createType == 2)
            {
                //element1被垂直的管  element2垂直的管
                Line mEPCurve1Line = (element1.Location as LocationCurve).Curve as Line;
                Line mEPCurve2Line = (element2.Location as LocationCurve).Curve as Line;
                Connector connector = null;
                double distanceMin = double.MaxValue;
                foreach (Connector item in element2.ConnectorManager.Connectors)
                {
                    if (mEPCurve1Line.Distance(item.Origin) < distanceMin)
                    {
                        connector = item;
                        distanceMin = mEPCurve1Line.Distance(item.Origin);
                    }
                }

                CableTrayType cableTrayType = doc.GetElement(element1.GetTypeId()) as CableTrayType;
                ElementId oldConId1 = cableTrayType.get_Parameter(BuiltInParameter.RBS_CURVETYPE_DEFAULT_ELBOWUP_PARAM).AsElementId();
                ElementId oldConId2 = cableTrayType.get_Parameter(BuiltInParameter.RBS_CURVETYPE_DEFAULT_ELBOWDOWN_PARAM).AsElementId();
                ElementId oldConId3 = cableTrayType.get_Parameter(BuiltInParameter.RBS_CURVETYPE_DEFAULT_TEE_PARAM).AsElementId();

                FamilySymbol verSymbol = new FilteredElementCollector(doc).WhereElementIsElementType().OfCategory(BuiltInCategory.OST_CableTrayFitting).Cast<FamilySymbol>()
                    .Where(s => s.FamilyName == "桥架竖向弯头连接件").FirstOrDefault(s => s.Name == cableTrayType.Name);
                FamilySymbol teeSymbol = new FilteredElementCollector(doc).WhereElementIsElementType().OfCategory(BuiltInCategory.OST_CableTrayFitting).Cast<FamilySymbol>()
                    .Where(s => s.FamilyName == "桥架竖向三通连接件").FirstOrDefault(s => s.Name == cableTrayType.Name);

                if (verSymbol == null)
                {
                    try
                    {
                        Util.LoadFamily(doc, Resource1.桥架竖向弯头连接件, "桥架竖向弯头连接件");
                        verSymbol = new FilteredElementCollector(doc).WhereElementIsElementType().OfCategory(BuiltInCategory.OST_CableTrayFitting).Cast<FamilySymbol>()
                    .Where(s => s.FamilyName == "桥架竖向弯头连接件").FirstOrDefault(s => s.Name == cableTrayType.Name);
                    }
                    catch { }
                }
                if (teeSymbol == null)
                {
                    try
                    {
                        Util.LoadFamily(doc, Resource1.桥架竖向三通连接件, "桥架竖向三通连接件");
                        teeSymbol = new FilteredElementCollector(doc).WhereElementIsElementType().OfCategory(BuiltInCategory.OST_CableTrayFitting).Cast<FamilySymbol>()
                    .Where(s => s.FamilyName == "桥架竖向三通连接件").FirstOrDefault(s => s.Name == cableTrayType.Name);
                    }
                    catch { }
                }
                //Util.LoadFamily(doc, Resource1.L型桥架竖向弯头连接件, "L型桥架竖向弯头连接件");
                //Util.LoadFamily(doc, Resource1.直线型桥架竖向弯头连接件, "直线型桥架竖向弯头连接件");

                if (verSymbol == null || teeSymbol == null)
                {
                    TaskDialog.Show("提示", "未找到指定桥架连接件，无法进行连接");
                    return false;
                }

                //垂直管在被垂直管的上的投影点
                XYZ projectPoint = mEPCurve1Line.Project(connector.Origin).XYZPoint;
                // 被垂直桥架相对支线桥架的高度
                bool createDown = false;
                if (projectPoint.Z < connector.Origin.Z) createDown = true;

                using (Transaction tran = new Transaction(doc, "创建桥架"))
                {
                    tran.Start();

                    if (!verSymbol.IsActive)
                    {
                        verSymbol.Activate();
                    }
                    if (!teeSymbol.IsActive)
                    {
                        teeSymbol.Activate();
                    }

                    // 设置桥架弯通和T型三通使用的连接件
                    // 弯通
                    cableTrayType.get_Parameter(BuiltInParameter.RBS_CURVETYPE_DEFAULT_ELBOWUP_PARAM).Set(verSymbol.Id);
                    cableTrayType.get_Parameter(BuiltInParameter.RBS_CURVETYPE_DEFAULT_ELBOWDOWN_PARAM).Set(verSymbol.Id);
                    // T
                    cableTrayType.get_Parameter(BuiltInParameter.RBS_CURVETYPE_DEFAULT_TEE_PARAM).Set(teeSymbol.Id);

                    // 三通
                    FamilyInstance familyInstance = doc.Create.NewFamilyInstance(projectPoint, teeSymbol, Autodesk.Revit.DB.Structure.StructuralType.NonStructural);
                    familyInstance.LookupParameter("桥架宽度 1")?.Set(element1.Width);
                    familyInstance.LookupParameter("桥架宽度 3")?.Set(element2.Width);
                    familyInstance.LookupParameter("桥架高度")?.Set(element1.Height);

                    XYZ dir1 = ((element1.Location as LocationCurve).Curve as Line).Direction;
                    XYZ dir2 = familyInstance.GetTransform().OfVector(XYZ.BasisX);
                    double angle = dir1.AngleTo(dir2);
                    ElementTransformUtils.RotateElement(doc, familyInstance.Id, Line.CreateBound(projectPoint, projectPoint + XYZ.BasisZ), angle);
                    if (!((element1.Location as LocationCurve).Curve as Line).Direction.IsAlmostEqualTo(familyInstance.GetTransform().OfVector(XYZ.BasisX)))
                    {
                        ElementTransformUtils.RotateElement(doc, familyInstance.Id, Line.CreateBound(projectPoint, projectPoint + XYZ.BasisZ), -angle * 2);
                    }

                    //TaskDialog.Show("revit",(element1.GetTypeId() == null) + "\n" + (familyInstance.get_BoundingBox(doc.ActiveView) == null) + "\n" + (element1.LevelId == ElementId.InvalidElementId) + "\n" + element1.get_Parameter(BuiltInParameter.RBS_START_LEVEL_PARAM).AsElementId());

                    CableTray cableTray = CableTray.Create(doc, element1.GetTypeId(), new XYZ(projectPoint.X, projectPoint.Y, (element1.Location as LocationCurve).Curve.GetEndPoint(0).Z + element1.Height / 2 + 20 / 304.8), new XYZ(projectPoint.X, projectPoint.Y, connector.Origin.Z), element1.LevelId == ElementId.InvalidElementId ? element1.get_Parameter(BuiltInParameter.RBS_START_LEVEL_PARAM).AsElementId() : element1.LevelId);
                    Parameter widthParameter = cableTray.get_Parameter(BuiltInParameter.RBS_CABLETRAY_WIDTH_PARAM);
                    Parameter heightParameter = cableTray.get_Parameter(BuiltInParameter.RBS_CABLETRAY_HEIGHT_PARAM);
                    widthParameter.Set(width);
                    heightParameter.Set(height);
                    Util.RotatingBridge(doc, cableTray, element2, createDown, GetConnector(element2, 0));
                    //CableTray cableTray = CableTray.Create(doc, element1.GetTypeId(), projectPoint, new XYZ(projectPoint.X, projectPoint.Y, connector.Origin.Z), element1.LevelId);
                    //CableTray cableTray = CableTray.Create(doc, element1.GetTypeId(), new XYZ(projectPoint.X, projectPoint.Y, (projectPoint.Z + connector.Origin.Z) / 2), new XYZ(projectPoint.X, projectPoint.Y, connector.Origin.Z), element1.LevelId);
                    foreach (Connector item in cableTray.ConnectorManager.Connectors)
                    {
                        if (item.Id == 1)
                        {
                            //item.ConnectTo(connector);

                            FamilyInstance fit = doc.Create.NewElbowFitting(item, connector);
                            fit.LookupParameter("桥架宽度")?.Set(element1.Width);
                            fit.LookupParameter("桥架高度")?.Set(element1.Height);

                            ElementId id = ElementTransformUtils.CopyElement(doc, element1.Id, XYZ.Zero).First();
                            CableTray newCableTray = doc.GetElement(id) as CableTray;
                            (newCableTray.Location as LocationCurve).Curve = Line.CreateBound(projectPoint, mEPCurve1Line.GetEndPoint(1));
                            (element1.Location as LocationCurve).Curve = Line.CreateBound(mEPCurve1Line.GetEndPoint(0), projectPoint);

                            Connector con1 = GetConnector(element1, 1);
                            Connector con2 = GetConnector(newCableTray, 0);
                            Connector con3 = GetConnector(cableTray, 0);
                            //FamilyInstance familyInstance = doc.Create.NewTeeFitting(con1, con2, con3);

                            con1.ConnectTo(GetConnector(familyInstance, 1));
                            con2.ConnectTo(GetConnector(familyInstance, 2));
                            if (createDown)
                                con3.ConnectTo(GetConnector(familyInstance, 4)); // 上
                            else con3.ConnectTo(GetConnector(familyInstance, 5));// 下

                            //GetConnector(familyInstance, 3).ConnectTo(con3);

                            ElementTransformUtils.MoveElement(doc, familyInstance.Id, XYZ.BasisZ);
                            ElementTransformUtils.MoveElement(doc, familyInstance.Id, XYZ.BasisZ.Negate());
                        }
                    }

                    // 恢复桥架原来使用的弯通和三通连接件
                    cableTrayType.get_Parameter(BuiltInParameter.RBS_CURVETYPE_DEFAULT_ELBOWUP_PARAM).Set(oldConId1);
                    cableTrayType.get_Parameter(BuiltInParameter.RBS_CURVETYPE_DEFAULT_ELBOWDOWN_PARAM).Set(oldConId2);
                    cableTrayType.get_Parameter(BuiltInParameter.RBS_CURVETYPE_DEFAULT_TEE_PARAM).Set(oldConId3);

                    tran.Commit();
                }
            }
            //L型创建
            if (createType == 3)
            {
                //element1是高的
                if (element1.get_Parameter(BuiltInParameter.RBS_END_OFFSET_PARAM).AsDouble() < element2.get_Parameter(BuiltInParameter.RBS_END_OFFSET_PARAM).AsDouble())
                {
                    MEPCurve temp = element1;
                    element1 = element2;
                    element2 = temp;
                }

                CableTrayType cableTrayType = doc.GetElement(element1.GetTypeId()) as CableTrayType;
                ElementId oldElbowId1 = cableTrayType.get_Parameter(BuiltInParameter.RBS_CURVETYPE_DEFAULT_ELBOWUP_PARAM).AsElementId();
                ElementId oldElbowId2 = cableTrayType.get_Parameter(BuiltInParameter.RBS_CURVETYPE_DEFAULT_ELBOWDOWN_PARAM).AsElementId();

                FamilySymbol verSymbol = new FilteredElementCollector(doc).WhereElementIsElementType().OfCategory(BuiltInCategory.OST_CableTrayFitting).Cast<FamilySymbol>()
                    .Where(s => s.FamilyName == "L型桥架竖向弯头连接件").FirstOrDefault(s => s.Name == cableTrayType.Name);
                if (verSymbol == null)
                {
                    try
                    {
                        Util.LoadFamily(doc, Resource1.L型桥架竖向弯头连接件, "L型桥架竖向弯头连接件");
                        verSymbol = new FilteredElementCollector(doc).WhereElementIsElementType().OfCategory(BuiltInCategory.OST_CableTrayFitting).Cast<FamilySymbol>()
                    .Where(s => s.FamilyName == "L型桥架竖向弯头连接件").FirstOrDefault(s => s.Name == cableTrayType.Name);
                    }
                    catch { }
                }

                if (verSymbol == null)
                {
                    TaskDialog.Show("提示", $"未找到指定桥架连接件: L型桥架竖向弯头连接件->{cableTrayType.Name}，无法进行连接");
                    return false;
                }

                Util.GetClosePoint(element1, element2, out conn1, out conn2);


                //创建竖向桥架
                using (Transaction tran = new Transaction(doc, "创建桥架"))
                {
                    tran.Start();

                    if (!verSymbol.IsActive)
                    {
                        verSymbol.Activate();
                    }
                    // 特殊角度或两桥架未完全对齐时创建L型桥架失败
                    XYZ point = GetProjectPoint(conn1.Origin, element2);
                    FamilyInstance familyInstance = CreateFit(doc, element1, conn1, verSymbol, point, true);
                    XYZ point2 = GetProjectPoint(conn2.Origin, element1);
                    FamilyInstance familyInstance2 = CreateFit(doc, element2, conn2, verSymbol, point2, false);

                    conn1.ConnectTo(GetConnector(familyInstance, 6));
                    conn2.ConnectTo(GetConnector(familyInstance2, 6));

                    ElementId id = ElementTransformUtils.CopyElement(doc, element1.Id, XYZ.Zero).First();
                    CableTray newCableTray = doc.GetElement(id) as CableTray;
                    (newCableTray.Location as LocationCurve).Curve = Line.CreateBound(GetConnector(familyInstance, 5).Origin, GetConnector(familyInstance2, 5).Origin);

                    GetConnector(familyInstance, 5).ConnectTo(GetConnector(newCableTray, 0));
                    GetConnector(familyInstance2, 5).ConnectTo(GetConnector(newCableTray, 1));

                    ElementTransformUtils.MoveElement(doc, familyInstance.Id, XYZ.BasisZ);
                    ElementTransformUtils.MoveElement(doc, familyInstance.Id, XYZ.BasisZ.Negate());
                    ElementTransformUtils.MoveElement(doc, familyInstance2.Id, XYZ.BasisZ);
                    ElementTransformUtils.MoveElement(doc, familyInstance2.Id, XYZ.BasisZ.Negate());

                    tran.Commit();
                }
                return true;



                if (element1.get_Parameter(BuiltInParameter.RBS_END_OFFSET_PARAM).AsDouble() < element2.get_Parameter(BuiltInParameter.RBS_END_OFFSET_PARAM).AsDouble())
                {
                    MEPCurve temp = element1;
                    element1 = element2;
                    element2 = temp;
                }
                //获取距离近的两个连接器
                Util.GetClosePoint(element1, element2, out conn1, out conn2);
                double elementTop = element1.get_Parameter(BuiltInParameter.RBS_CTC_TOP_ELEVATION).AsDouble() - element1.get_Parameter(BuiltInParameter.RBS_OFFSET_PARAM).AsDouble();
                double elementBottom = element2.get_Parameter(BuiltInParameter.RBS_CTC_BOTTOM_ELEVATION).AsDouble() - element2.get_Parameter(BuiltInParameter.RBS_OFFSET_PARAM).AsDouble();
                //double elementBottom = int.Parse(element2.get_Parameter(BuiltInParameter.RBS_CTC_BOTTOM_ELEVATION).AsValueString()) - int.Parse(element2.get_Parameter(BuiltInParameter.RBS_OFFSET_PARAM).AsValueString());
                using (Transaction tran = new Transaction(doc, "创建桥架"))
                {
                    tran.Start();
                    CableTray cable1 = null;
                    CableTray cable2 = null;
                    if (Math.Abs(conn1.Origin.X - conn1.OtherConn().Origin.X) > 0.000001)
                    {
                        cable1 = CableTray.Create(doc, element1.GetTypeId(), conn1.OtherConn().Origin, new XYZ(conn2.Origin.X, conn1.Origin.Y, conn1.Origin.Z), element1.LevelId);
                        cable2 = CableTray.Create(doc, element2.GetTypeId(), conn2.OtherConn().Origin, new XYZ(conn2.Origin.X, conn1.Origin.Y, conn2.Origin.Z), element2.LevelId);
                    }
                    else
                    {
                        cable1 = CableTray.Create(doc, element1.GetTypeId(), conn1.OtherConn().Origin, new XYZ(conn1.Origin.X, conn2.Origin.Y, conn1.Origin.Z), element1.LevelId);
                        cable2 = CableTray.Create(doc, element2.GetTypeId(), conn2.OtherConn().Origin, new XYZ(conn1.Origin.X, conn2.Origin.Y, conn2.Origin.Z), element2.LevelId);
                    }

                    cable1.get_Parameter(BuiltInParameter.RBS_CABLETRAY_WIDTH_PARAM).Set(element1.get_Parameter(BuiltInParameter.RBS_CABLETRAY_WIDTH_PARAM).AsDouble());
                    cable1.get_Parameter(BuiltInParameter.RBS_CABLETRAY_HEIGHT_PARAM).Set(element1.get_Parameter(BuiltInParameter.RBS_CABLETRAY_HEIGHT_PARAM).AsDouble());
                    cable2.get_Parameter(BuiltInParameter.RBS_CABLETRAY_WIDTH_PARAM).Set(element2.get_Parameter(BuiltInParameter.RBS_CABLETRAY_WIDTH_PARAM).AsDouble());
                    cable2.get_Parameter(BuiltInParameter.RBS_CABLETRAY_HEIGHT_PARAM).Set(element2.get_Parameter(BuiltInParameter.RBS_CABLETRAY_HEIGHT_PARAM).AsDouble());
                    doc.Delete(element1.Id);
                    doc.Delete(element2.Id);
                    Util.GetClosePoint(cable1, cable2, out conn1, out conn2);
                    CableTray cableTray = CableTray.Create(doc, cable1.GetTypeId(), conn1.Origin + new XYZ(0, 0, elementTop), new XYZ(conn1.Origin.X, conn1.Origin.Y, conn2.Origin.Z + elementBottom), cable1.LevelId);
                    //连接器连接桥架
                    //foreach (Connector item in cableTray.ConnectorManager.Connectors)
                    //{
                    //    if (item.Id == 0)
                    //    {
                    //        item.ConnectTo(conn2);
                    //    }
                    //    else
                    //    {
                    //        item.ConnectTo(conn1);
                    //    }
                    //}

                    Util.RotatingBridge(doc, cableTray, conn1, conn2);
                    Parameter widthParameter = cableTray.get_Parameter(BuiltInParameter.RBS_CABLETRAY_WIDTH_PARAM);
                    Parameter heightParameter = cableTray.get_Parameter(BuiltInParameter.RBS_CABLETRAY_HEIGHT_PARAM);
                    widthParameter.Set(width);
                    heightParameter.Set(height);
                    tran.Commit();
                }
            }
            return true;
        }
        public static XYZ GetProjectPoint(XYZ point, MEPCurve mEPCurve)
        {
            XYZ pp;
            Line line = (mEPCurve.Location as LocationCurve).Curve as Line;
            line.MakeUnbound();
            pp = line.Project(point).XYZPoint;
            pp = new XYZ(pp.X, pp.Y, point.Z);

            return pp;
        }
        /// <summary>
        /// 创建连接件（内部无事务）
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="element"></param>
        /// <param name="con"></param>
        /// <param name="verSymbol"></param>
        /// <returns></returns>
        public static FamilyInstance CreateFit(Document doc, MEPCurve element, Connector con, FamilySymbol verSymbol, XYZ point, bool IsUp)
        {
            FamilyInstance familyInstance = doc.Create.NewFamilyInstance(point, verSymbol, Autodesk.Revit.DB.Structure.StructuralType.NonStructural);
            familyInstance.LookupParameter("桥架宽度").Set(element.Width);
            familyInstance.LookupParameter("桥架高度").Set(element.Height);
            Transform transform = familyInstance.GetTransform();
            XYZ dir = transform.OfVector(XYZ.BasisX);
            Line roLine = Line.CreateUnbound(point, dir);
            if (IsUp) familyInstance.Location.Rotate(roLine, -con.CoordinateSystem.BasisZ.AngleTo(transform.OfVector(XYZ.BasisZ)));
            else familyInstance.Location.Rotate(roLine, con.CoordinateSystem.BasisZ.AngleTo(transform.OfVector(XYZ.BasisZ)));

            XYZ dir2 = familyInstance.GetTransform().OfVector(XYZ.BasisZ);
            XYZ conNeDir = con.CoordinateSystem.BasisZ.Negate();
            double angle = dir2.AngleTo(conNeDir);
            XYZ crossDir = dir2.CrossProduct(conNeDir).Normalize();
            Line roLine2;
            if (crossDir.GetLength() == 0)
            {
                //return familyInstance;
                roLine2 = Line.CreateUnbound(point, familyInstance.GetTransform().OfVector(XYZ.BasisY));
            }
            else
            {
                roLine2 = Line.CreateUnbound(point, crossDir);
            }

            familyInstance.Location.Rotate(roLine2, angle);
            //TaskDialog.Show("revit", conNeDir + "\n" + dir2 + "\n" + angle + "\n" + roLine2.Direction + "\n" + crossDir.GetLength());

            return familyInstance;
        }
        public static Connector GetConnector(Element element, int id)
        {
            Connector connector = null;

            if (element is MEPCurve mEP)
            {
                foreach (Connector con in mEP.ConnectorManager.Connectors)
                {
                    if (con.Id == id)
                    {
                        connector = con;
                        break;
                    }
                }
            }
            else if (element is FamilyInstance familyInstance)
            {
                var cm = familyInstance.MEPModel.ConnectorManager;
                if (cm != null)
                {
                    foreach (Connector con in cm.Connectors)
                    {
                        if (con.Id == id)
                        {
                            connector = con;
                            break;
                        }
                    }
                }
            }
            


            return connector;
        }
    }
}
