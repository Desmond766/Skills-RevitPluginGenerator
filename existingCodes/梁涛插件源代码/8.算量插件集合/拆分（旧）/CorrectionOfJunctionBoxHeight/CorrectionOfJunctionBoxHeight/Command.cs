using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Interop;
using System.Xml.Linq;
using CheckBox = System.Windows.Controls.CheckBox;
using Floor = Autodesk.Revit.DB.Floor;
using Line = Autodesk.Revit.DB.Line;
using Outline = Autodesk.Revit.DB.Outline;

namespace CorrectionOfJunctionBoxHeight
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uIDoc = commandData.Application.ActiveUIDocument;
            UIApplication uIApp = commandData.Application;
            Document doc = uIDoc.Document;
            Selection sel = uIDoc.Selection;

            var fec = new FilteredElementCollector(doc).OfClass(typeof(RevitLinkInstance)).First(x => x.Name.Contains("结构"));
            RevitLinkInstance revitLinkInstance = fec as RevitLinkInstance;
            Document linkDoc = revitLinkInstance.GetLinkDocument();
            FilteredElementCollector linkElems = new FilteredElementCollector(linkDoc);
            linkElems.OfClass(typeof(Wall));
            Transform transform = revitLinkInstance.GetTransform();
            
            List<WallInfo> wallInfos = new List<WallInfo>();
            foreach (var linkElem in linkElems)
            {
                Line line = (linkElem.Location as LocationCurve).Curve as Line;
                XYZ p0 = line.GetEndPoint(0);
                XYZ p1 = line.GetEndPoint(1);
                p0 = transform.OfPoint(p0);
                p1 = transform.OfPoint(p1);
                Line newLine = Line.CreateBound(new XYZ(p0.X, p0.Y, 0), new XYZ(p1.X, p1.Y, 0));
                var solids = GetElementSolid(linkElem);
                if (solids.Count == 1)
                {
                    Solid solid = SolidUtils.CreateTransformed(solids.First(), transform);
                    wallInfos.Add(new WallInfo() { Line = newLine, Solid = solid, Width = (linkElem as Wall).Width, Wall = linkElem as Wall });
                }
            }
            //Element element = doc.GetElement(sel.PickObject(ObjectType.Element));
            //WallInfo wallInfo = wallInfos.First(w => w.Wall.Id.IntegerValue == 4306132);
            //XYZ p = (element.Location as LocationPoint).Point;
            //XYZ pp = wallInfo.Line.Project(p).XYZPoint;
            //p = new XYZ(p.X, p.Y, 0);
            //TaskDialog.Show("revit", p + "\n" + pp + "\n" + p.DistanceTo(pp) + "\n" + wallInfo.Wall.Id);
            //GetNearestWall(element as FamilyInstance, wallInfos);
            //return Result.Succeeded;

            // 旋转 25.1.22
            //Element element = doc.GetElement(sel.PickObject(ObjectType.Element));
            //using (Transaction t = new Transaction(doc, "旋转"))
            //{
            //    t.Start();
            //    XYZ p = (element.Location as LocationPoint).Point;
            //    ElementTransformUtils.RotateElement(doc, element.Id, Line.CreateBound(p, p + XYZ.BasisZ * 1), 1.57);

            //    t.Commit();
            //}


            // 自动获取引用参照 25.1.22
            //Reference reference = sel.PickObject(ObjectType.Element);
            //Element element = doc.GetElement(reference);
            //Reference reference1 = sel.PickObject(ObjectType.Element);
            //Element element1 = doc.GetElement(reference1);
            //using (Transaction t = new Transaction(doc, "尺寸标注"))
            //{
            //    t.Start();

            //    Reference newRef1 = GetSpecialFamilyReference(doc, element as FamilyInstance, FamilyInstanceReferenceType.CenterFrontBack);
            //    Reference newRef2 = GetSpecialFamilyReference(doc, element1 as FamilyInstance, FamilyInstanceReferenceType.CenterFrontBack);
            //    ReferencePlane line1 = doc.GetElement(newRef1) as ReferencePlane;
            //    TaskDialog.Show("revit", line1.Name.ToString());

            //    ReferenceArray array = new ReferenceArray();
            //    array.Append(newRef1);
            //    array.Append(newRef2);
            //    doc.Create.NewDimension(doc.ActiveView, Line.CreateBound((element.Location as LocationPoint).Point, (element1.Location as LocationPoint).Point), array);
            //    t.Commit();
            //}

            //string[] refTokens = sampleStableRef.Split(new char[] { ':' });
            //string customStableRef = refTokens[0] + ":" + refTokens[1] + ":" + refTokens[2] + ":" + refTokens[3] + ":1";
            //Reference newRef = Reference.ParseFromStableRepresentation(doc, customStableRef);
            //if (newRef == null)
            //{
            //    TaskDialog.Show("ref", "null");
            //}
            //else
            //{
            //    Element element1 = doc.GetElement(reference);
            //    GeometryObject geo = element1.GetGeometryObjectFromReference(newRef);
            //    var geo2 = doc.GetElement(reference).GetGeometryObjectFromReference(reference);
            //    bool tu = geo.Equals(geo2);
            //    FamilyInstanceReferenceType referenceType = FamilyInstanceReferenceType.CenterLeftRight;

            //    TaskDialog.Show("ref", element1.Name + tu + element1.Id + geo.GetType());
            //}
            //Reference reference2 = element.get_Geometry(new Options()).OfType<Point>().Select<Point, Reference>(o => o.Reference).First();

            //return Result.Succeeded;

            bool changeBox = false;

            View3D view3D = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Views).WhereElementIsNotElementType()
                .Where(x => x is View3D).Cast<View3D>().FirstOrDefault(y => y.Name.Contains("{三维 - Administrator}"));
            if (view3D == null)
            {
                if (doc.ActiveView is View3D)
                {
                    view3D = doc.ActiveView as View3D;
                }
                else
                {
                    view3D = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Views).WhereElementIsNotElementType()
                    .Where(x => x is View3D).Cast<View3D>().FirstOrDefault();
                }
                if (view3D == null)
                {
                    TaskDialog.Show("提示", "未找到三维视图");
                    return Result.Cancelled;
                }

            }

            MainWindow window = new MainWindow();
            window.ShowDialog();

            if (window.Cancel)
            {
                return Result.Cancelled;
            }

            // 打开指定视图中楼板的可见性
            var openIds = DisplayFloor(doc, view3D, out bool isHidden);

            List<CheckBox> checkBoxes = window.CheckBoxes;
            checkBoxes = checkBoxes.Where(X => X.IsChecked == true).ToList();
            List<ElementFilter> elementFilters = new List<ElementFilter>();
            foreach (var item in checkBoxes)
            {
                Categorys id;
                if (Enum.TryParse(item.Name, out id))
                {
                    //TaskDialog.Show("re", id.ToString() + "\n" + ((BuiltInCategory)id));
                    if ((BuiltInCategory)id == BuiltInCategory.OST_ElectricalFixtures)
                    {
                        changeBox = true;
                    }
                    else
                    {
                        elementFilters.Add(new ElementCategoryFilter((BuiltInCategory)id));
                    }

                }
            }


            //sele:
            //    FamilyInstance element;
            //    Wall wall;
            //    try
            //    {
            //        element = sel.PickObject(ObjectType.Element).GetElement(doc) as FamilyInstance;
            //        wall = sel.PickObject(ObjectType.Element).GetElement(doc) as Wall;
            //    }
            //    catch (Exception)
            //    {

            //        return Result.Succeeded;
            //    }
            //    using (Transaction t = new Transaction(doc, "贴墙"))
            //    {
            //        t.Start();
            //        RotateElement(element, wall, doc);
            //        MoveElement(element, wall, doc);
            //        XYZ point = (element.Location as LocationPoint).Point;
            //        XYZ dir = GetHorizontalDirection(wall, point);
            //        if (element.FacingOrientation.IsAlmostEqualTo(dir)) ElementTransformUtils.RotateElement(doc, element.Id, Line.CreateBound(point, point + XYZ.BasisZ), Math.PI);

            //        t.Commit();
            //    }
            //    goto sele;



            List<Conduit> conduits = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Conduit).WhereElementIsNotElementType().Cast<Conduit>()
                .OrderByDescending(c => c.LookupParameter("中间高程").AsDouble()).ToList();

            FilteredElementCollector collector1;
            FilteredElementCollector collector2;
            FilteredElementCollector collector3;
            if (window.RB_ActiveView.IsChecked == true)
            {
                collector1 = new FilteredElementCollector(doc, doc.ActiveView.Id);
                collector2 = new FilteredElementCollector(doc, doc.ActiveView.Id);
                collector3 = new FilteredElementCollector(doc, doc.ActiveView.Id);
            }
            else
            {
                collector1 = new FilteredElementCollector(doc);
                collector2 = new FilteredElementCollector(doc);
                collector3 = new FilteredElementCollector(doc);
            }

            //接线盒（电气装置）

            List<FamilyInstance> familyInstances = collector1.OfCategory(BuiltInCategory.OST_ElectricalFixtures).WhereElementIsNotElementType()
                .Where(x => x.Name.Contains("接线盒") && x.Name.Contains("板内")).Cast<FamilyInstance>().ToList();
            List<FamilyInstance> familyInstances2 = collector2.OfCategory(BuiltInCategory.OST_ElectricalFixtures).WhereElementIsNotElementType()
                .Where(x => x.Name.Contains("接线盒") && x.Name.Contains("墙内")).Cast<FamilyInstance>().ToList();
            //通讯、数据、火警、照明、护理呼叫、安全、电话设备
            //List<ElementFilter> elementFilters = new List<ElementFilter>()
            //{
            //    new ElementCategoryFilter(BuiltInCategory.OST_CommunicationDevices),
            //    new ElementCategoryFilter(BuiltInCategory.OST_DataDevices),
            //    new ElementCategoryFilter(BuiltInCategory.OST_FireAlarmDevices),
            //    new ElementCategoryFilter(BuiltInCategory.OST_LightingFixtures),
            //    new ElementCategoryFilter(BuiltInCategory.OST_NurseCallDevices),
            //    new ElementCategoryFilter(BuiltInCategory.OST_SecurityDevices),
            //    new ElementCategoryFilter(BuiltInCategory.OST_TelephoneDevices)
            //};
            List<FamilyInstance> otherInstances;
            if (elementFilters.Count == 0) otherInstances = new List<FamilyInstance>();
            else
            {
                LogicalOrFilter orFilter = new LogicalOrFilter(elementFilters);
                otherInstances = collector3.WherePasses(orFilter).WhereElementIsNotElementType().Cast<FamilyInstance>().ToList();
            }



            //TaskDialog.Show("ssss", (conduits.Count + familyInstances.Count).ToString());

            //记录已修正高度的族实例
            List<ElementId> hasChange = new List<ElementId>();

            TransactionGroup TG = new TransactionGroup(doc, "设备智能贴墙/嵌板");
            TG.Start();

            if (!changeBox) goto next;
            //1.接线盒（板内）
            using (Transaction t = new Transaction(doc, "接线盒 线管 高度修正"))
            {
                t.Start();
                foreach (var item in familyInstances)
                {
                    if (hasChange.Contains(item.Id)) continue;

                    XYZ point = (item.Location as LocationPoint).Point;
                    double moveLength = GetHeightToFloor(view3D, point, doc, XYZ.BasisZ);
                    if (moveLength == -1)
                    {
                        moveLength = GetHeightToFloor(view3D, point, doc);
                        if (moveLength == -1) continue;
                    }
                    XYZ moveZ = new XYZ(0, 0, moveLength);

                    List<ElementId> changeIds = new List<ElementId>();
                    GetAllConnect(item, ref changeIds);

                    if (changeIds.Count == 1)
                    {
                        item.Location.Move(moveZ);
                    }
                    else if (changeIds.Count > 1)
                    {
                        ElementTransformUtils.MoveElements(doc, changeIds, moveZ);
                        hasChange.AddRange(changeIds);
                    }

                }
                foreach (var item in conduits)
                {
                    if (hasChange.Contains(item.Id)) continue;

                    foreach (Connector con in item.ConnectorManager.Connectors)
                    {
                        if (!con.IsConnected) continue;
                        foreach (Connector conRef in con.AllRefs)
                        {
                            if (conRef.Owner.Name.Contains("接线盒")) goto ThisWay;
                        }
                    }
                    Line line = (item.Location as LocationCurve).Curve as Line;
                    XYZ p0 = line.GetEndPoint(0);
                    XYZ p1 = line.GetEndPoint(1);
                    if (Math.Abs(p0.Z - p1.Z) > 0.0001) continue;
                    double height = GetHeightToFloor(view3D, p0, doc, XYZ.BasisZ);
                    if (height == -1)
                    {
                        height = GetHeightToFloor(view3D, p0, doc);
                        if (height == -1) continue;
                    }
                    height += 20 / 304.8;
                    XYZ moveZ = new XYZ(0, 0, height);

                    List<ElementId> changeIds = new List<ElementId>();
                    GetAllConnect(item, ref changeIds);
                    if (changeIds.Count == 1)
                    {
                        item.Location.Move(moveZ);
                    }
                    else if (changeIds.Count > 1)
                    {
                        ElementTransformUtils.MoveElements(doc, changeIds, moveZ);
                        hasChange.AddRange(changeIds);
                    }

                //item.Location.Move(new XYZ(0, 0, height + 20 / 304.8));

                //List<ElementId> ids = GetAllConnect(item, ref hasChange);
                ThisWay:;
                }

                t.Commit();
            }
            //2.接线盒（墙内）
            using (Transaction t = new Transaction(doc, "接线盒贴墙"))
            {
                t.Start();
                foreach (var item in familyInstances2)
                {
                    //1.射线向四周寻找离得最近的墙
                    XYZ point = (item.Location as LocationPoint).Point;
                    Reference wallRef = GetNearestWallRefWithRay(item, view3D, doc);
                    if (wallRef == null) continue;
                    Wall linkWall = wallRef.GetLinkElement(doc) as Wall;

                    RotateElement(item, linkWall, doc);
                    MoveElement(item, linkWall, doc);
                    XYZ wallToPDir = GetHorizontalDirection(linkWall, point);
                    if (item.FacingOrientation.IsAlmostEqualTo(wallToPDir.Negate()))
                    {
                        ElementTransformUtils.RotateElement(doc, item.Id, Line.CreateBound(point, point + XYZ.BasisZ), Math.PI);
                    }


                    //2.旋转接线盒使接线盒贴合墙且在墙内

                }
                t.Commit();
            }
        next:
            //3.其他设备
            using (Transaction t = new Transaction(doc, "其他设备贴墙/贴板"))
            {
                t.Start();
                // TODO:修改为根据Excel表格获取参数“吸顶”的属性值来进行判断
                //List<string> importFamilyNames = null;
                List<string> importSymbolNames = null;
                
                //if (window.Import) importNames = window.DataTable.Rows.Cast<DataRow>().Where(r => !string.IsNullOrEmpty(r["构件名称"].ToString())).Select(dr => dr["构件名称"].ToString()).ToList();
                //if (window.Import) importFamilyNames = window.DataTable.Rows.Cast<DataRow>().Where(r => !string.IsNullOrEmpty(r["族名称"].ToString())).Select(dr => dr["族名称"].ToString()).ToList();
                if (window.Import) importSymbolNames = window.DataTable.Rows.Cast<DataRow>().Where(r => !string.IsNullOrEmpty(r["构件名称"].ToString())).Select(dr => dr["构件名称"].ToString()).ToList();
                //DateTime dateTime = DateTime.Now;
                // 吸顶比壁装耗时，13s/0.5s
                foreach (var item in otherInstances)
                {
                    //string symbolName = item.Symbol.Name;
                    string familyName = item.Symbol.FamilyName;
                    string symbolName = item.Symbol.Name;
                    var para = item.LookupParameter("吸顶");
                    //if (importFamilyNames != null && importFamilyNames.Any(x => !string.IsNullOrEmpty(x) && familyName.Contains(x)))
 
                    if (importSymbolNames != null && importSymbolNames.Any(x => !string.IsNullOrEmpty(x) && symbolName.Equals(x)))
                    {
                        //var dataRow = window.DataTable.Rows.Cast<DataRow>().FirstOrDefault(r => !string.IsNullOrEmpty(r["构件名称"].ToString()) && familyName.Contains(r["构件名称"].ToString()));
                        var dataRow = window.DataTable.Rows.Cast<DataRow>().FirstOrDefault(dr => !string.IsNullOrEmpty(dr["构件名称"].ToString()) && symbolName.Equals(dr["构件名称"].ToString()));
                        string installHigh = dataRow["安装高度"].ToString();
                        if (installHigh == "吸顶")
                        {
                            ChangeFloorPointLocation(item, view3D, doc);
                        }
                        else if (!string.IsNullOrEmpty(dataRow["安装高度"].ToString()))
                        {
                            double high = Convert.ToDouble(dataRow["安装高度"].ToString()) / 0.3048;
                            //ChangeWallPointLocation(item, view3D, doc);
                            ChangeWallPointLocation2(item, doc, wallInfos);
                            ChangeWallPointLocationHigh(item, view3D, doc, high);
                            //ChangeFloorPointLocation(item, view3D, doc, high);
                        }
                    }
                    else if (para != null)
                    {
                        if (para.AsInteger() == 1)
                        {
                            ChangeFloorPointLocation(item, view3D, doc);
                        }
                        else
                        {
                            ChangeWallPointLocation2(item, doc, wallInfos);
                        }
                    }
                }
                //DateTime dateTime1 = DateTime.Now;
                //TaskDialog.Show("revit", otherInstances.Count + "\n" + dateTime1.Subtract(dateTime));

                //DateTime dateTime = DateTime.Now;
                //if (window.RB_Wall.IsChecked == true)
                //{
                //    foreach (var item in otherInstances)
                //    {
                //        //1.判断是贴墙还是贴板
                //        //2.射线向四周/上找离得最近的墙/板
                //        //3.判断朝向，使设备能够贴合且朝向墙/板外
                //        XYZ point = (item.Location as LocationPoint).Point;
                //        Reference wallRef = GetNearestWallRefWithRay(item, view3D, doc);
                //        if (wallRef == null) continue;
                //        Wall linkWall = wallRef.GetLinkElement(doc) as Wall;

                //        RotateElement(item, linkWall, doc);
                //        MoveElement(item, linkWall, doc);
                //        XYZ wallToPDir = GetHorizontalDirection(linkWall, point);
                //        if (item.FacingOrientation.IsAlmostEqualTo(wallToPDir))
                //        {
                //            ElementTransformUtils.RotateElement(doc, item.Id, Line.CreateBound(point, point + XYZ.BasisZ), Math.PI);
                //        }
                //    }
                //}
                //else
                //{
                //    foreach (var item in otherInstances)
                //    {
                //        XYZ point = (item.Location as LocationPoint).Point;
                //        Reference floorRef = GetElemetWithRay(XYZ.BasisZ, new ElementId(-2000032), point, view3D);
                //        if (floorRef == null)
                //        {
                //            floorRef = GetElemetWithRay(XYZ.BasisZ.Negate(), new ElementId(-2000032), point, view3D, 2000 / 304.8);
                //            if (floorRef == null) continue;
                //            Floor linkFloor = floorRef.GetLinkElement(doc) as Floor;
                //            XYZ pp = floorRef.GlobalPoint;
                //            double dis = pp.DistanceTo(point);
                //            double high = linkFloor.get_Parameter(BuiltInParameter.FLOOR_ATTR_THICKNESS_PARAM).AsDouble();
                //            dis += high;
                //            item.Location.Move(XYZ.BasisZ.Negate() * dis);
                //        }
                //        else
                //        {
                //            Floor linkFloor = floorRef.GetLinkElement(doc) as Floor;
                //            XYZ pp = floorRef.GlobalPoint;
                //            double dis = pp.DistanceTo(point);
                //            item.Location.Move(XYZ.BasisZ * dis);
                //        }

                //    }
                //}
                //DateTime dateTime1 = DateTime.Now;
                //TaskDialog.Show("revit", otherInstances.Count + "\n" + dateTime1.Subtract(dateTime));
                t.Commit();
            }

            TG.Assimilate();
            //TaskDialog.Show("re", hasChange.Count.ToString());

            // 恢复视图中楼板的可见性
            HiddenFloor(doc, view3D, openIds, isHidden);

            return Result.Succeeded;
        }
        /// <summary>
        /// 获取元素的所有Solid
        /// </summary>
        /// <param name="elem"></param>
        /// <returns></returns>
        private List<Solid> GetElementSolid(Element elem)
        {
            List<Solid> lstSolid = new List<Solid>();
            Options opt = new Options();
            opt.ComputeReferences = true;
            opt.IncludeNonVisibleObjects = true;
            GeometryElement ge = elem.get_Geometry(opt);
            if (ge != null)
                lstSolid.AddRange(GetSolid(ge));
            return lstSolid;
        }
        private List<Solid> GetSolid(GeometryElement ge)
        {
            List<Solid> lstSolid = new List<Solid>();
            foreach (GeometryObject go in ge)
            {
                if (go is Solid)
                {
                    Solid solid = go as Solid;
                    if (solid.SurfaceArea > 0 && solid.Volume > 0 && solid.Faces.Size > 1 && solid.Edges.Size > 1)
                        lstSolid.Add(solid);
                }
                else if (go is GeometryInstance)
                {
                    GeometryElement ge2 = (go as GeometryInstance).GetInstanceGeometry();
                    lstSolid.AddRange(GetSolid(ge2));
                }
            }
            return lstSolid;
        }

        public static Reference GetSpecialFamilyReference(Document doc, FamilyInstance instance, FamilyInstanceReferenceType ReferenceType)
        {
            Reference indexReference = null;
            int index = (int)ReferenceType;

            Options geomOptions = new Options();
            geomOptions.ComputeReferences = true;
            geomOptions.DetailLevel = ViewDetailLevel.Fine;
            geomOptions.IncludeNonVisibleObjects = true;
            //geomOptions.View = doc.ActiveView;

            GeometryElement geoElement = instance.get_Geometry(geomOptions);
            foreach (GeometryObject obj in geoElement)
            {
                if (obj is GeometryInstance)
                {
                    GeometryInstance geoInstance = obj as GeometryInstance;

                    String sampleStableRef = null;

                    if (geoInstance != null)
                    {
                        GeometryElement geoSymbol = geoInstance.GetSymbolGeometry();

                        if (geoSymbol != null)
                        {
                            foreach (GeometryObject geomObj in geoSymbol)
                            {
                                if (geomObj is Solid)
                                {
                                    Solid solid = geomObj as Solid;
                                    //TaskDialog.Show("revit", geoSymbol.Count().ToString());
                                    if (solid.Faces.Size > 0)
                                    {
                                        Face face = solid.Faces.get_Item(0);

                                        sampleStableRef = face.Reference.ConvertToStableRepresentation(doc);
                                        break;
                                    }
                                }
                                if (geomObj is Line line)
                                {
                                    sampleStableRef = line.Reference.ConvertToStableRepresentation(doc);
                                    //TaskDialog.Show("revit", sampleStableRef);
                                    break;
                                }

                            }
                        }

                        if (sampleStableRef != null)
                        {
                            String[] refTokens = sampleStableRef.Split(new char[] { ':' });

                            String customStableRef = refTokens[0] + ":" + refTokens[1] + ":" + refTokens[2] + ":" + refTokens[3] + ":" + index.ToString();
                            indexReference = Reference.ParseFromStableRepresentation(doc, customStableRef);

                        }
                        break;
                    }
                    else
                    {

                    }
                }
            }

            return indexReference;
        }
        private void HiddenFloor(Document doc, View3D view3D, List<ElementId> openIds, bool isHidden)
        {
            using (Transaction t = new Transaction(doc, "可见性设置"))
            {
                t.Start();
                try
                {
                    foreach (var id in openIds)
                    {
                        view3D.SetFilterVisibility(id, false);
                    }
                    if (isHidden) view3D.SetCategoryHidden(new ElementId(-2000032), true);
                }
                catch (Exception)
                {
                    t.RollBack();
                    return;
                }

                t.Commit();
            }
        }

        private List<ElementId> DisplayFloor(Document doc, View view3D, out bool isHidden)
        {
            var closeIds = new List<ElementId>();
            var filterIds = view3D.GetFilters();
            using (Transaction t = new Transaction(doc, "可见性设置"))
            {
                t.Start();

                try
                {
                    foreach (var id in filterIds)
                    {
                        var filter = doc.GetElement(id);
                        if (filter.Name.Contains("结构板") || filter.Name.Contains("楼板"))
                        {
                            if (view3D.GetFilterVisibility(id)) continue;
                            view3D.SetFilterVisibility(id, true);
                            closeIds.Add(id);
                        }
                    }
                    //TaskDialog.Show("revit", view3D.GetCategoryHidden(new ElementId(-2000032)).ToString());
                    isHidden = view3D.GetCategoryHidden(new ElementId(-2000032));
                    if (isHidden) view3D.SetCategoryHidden(new ElementId(-2000032), false);
                }
                catch (Exception)
                {
                    isHidden = false;
                    closeIds = new List<ElementId>();
                    t.RollBack();
                    return closeIds;
                }

                t.Commit();
            }
            return closeIds;
        }

        /// <summary>
        /// 壁装点位与墙的距离、角度修正
        /// </summary>
        public bool ChangeWallPointLocation(FamilyInstance familyInstance, View3D view3D, Document doc)
        {
            XYZ point = (familyInstance.Location as LocationPoint).Point;
            Reference wallRef = GetNearestWallRefWithRay(familyInstance, view3D, doc);
            if (wallRef == null) return false;
            Wall linkWall = wallRef.GetLinkElement(doc) as Wall;

            RotateElement(familyInstance, linkWall, doc);
            MoveElement(familyInstance, linkWall, doc);
            XYZ wallToPDir = GetHorizontalDirection(linkWall, point);
            if (familyInstance.FacingOrientation.IsAlmostEqualTo(wallToPDir))
            {
                ElementTransformUtils.RotateElement(doc, familyInstance.Id, Line.CreateBound(point, point + XYZ.BasisZ), Math.PI);
            }
            return true;
        }
        public bool ChangeWallPointLocation2(FamilyInstance familyInstance, Document doc, List<WallInfo> wallInfos)
        {
            XYZ point = (familyInstance.Location as LocationPoint).Point;
            //Reference wallRef = GetNearestWallRefWithRay(familyInstance, view3D, doc);
            //if (wallRef == null) return false;
            //Wall linkWall = wallRef.GetLinkElement(doc) as Wall;
            WallInfo wallInfo = GetNearestWall(familyInstance, wallInfos);


            RotateElement(familyInstance, wallInfo.Line, doc);
            MoveElement(familyInstance, wallInfo);
            
            bool isIntersect = IsElementIntersect(wallInfo.Solid, familyInstance.Id, doc);
            if (isIntersect)
            {
                XYZ newPoint = (familyInstance.Location as LocationPoint).Point;
                ElementTransformUtils.RotateElement(doc, familyInstance.Id, Line.CreateBound(newPoint, newPoint + XYZ.BasisZ), Math.PI);
            }
            return true;
        }

        /// <summary>
        /// 判断元素是否与solid有相交部分
        /// </summary>
        /// <param name="wallSolid"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private bool IsElementIntersect(Solid wallSolid, ElementId id, Document doc)
        {
            var solids = GetElementSolid(doc.GetElement(id));
            foreach (var solid in solids)
            {
                try
                {
                    Solid intersectSolid = BooleanOperationsUtils.ExecuteBooleanOperation(solid, wallSolid, BooleanOperationsType.Intersect);
                    if (intersectSolid.Volume > 0)
                    {
                        return true;
                    }
                }
                catch (Exception)
                {
                    continue;
                }
            }
            return false;
        }

        /// <summary>
        /// 吸顶点位高度修正
        /// </summary>
        public bool ChangeFloorPointLocation(FamilyInstance familyInstance, View3D view3D, Document doc)
        {
            XYZ point = (familyInstance.Location as LocationPoint).Point;
            Reference floorRef = GetElemetWithRay(XYZ.BasisZ, new ElementId(-2000032), point, view3D);
            if (floorRef == null)
            {
                floorRef = GetElemetWithRay(XYZ.BasisZ.Negate(), new ElementId(-2000032), point, view3D, 2000 / 304.8);
                if (floorRef == null) return false;
                Floor linkFloor = floorRef.GetLinkElement(doc) as Floor;
                XYZ pp = floorRef.GlobalPoint;
                double dis = pp.DistanceTo(point);
                double high = linkFloor.get_Parameter(BuiltInParameter.FLOOR_ATTR_THICKNESS_PARAM).AsDouble();
                dis += high;
                //dis += distanceToFloor;
                familyInstance.Location.Move(XYZ.BasisZ.Negate() * dis);
            }
            else
            {
                Floor linkFloor = floorRef.GetLinkElement(doc) as Floor;
                XYZ pp = floorRef.GlobalPoint;
                double dis = pp.DistanceTo(point);
                //dis -= distanceToFloor;
                familyInstance.Location.Move(XYZ.BasisZ * dis);
            }
            return true;
        }

        /// <summary>
        /// 调整壁挂点位高度
        /// </summary>
        public bool ChangeWallPointLocationHigh(FamilyInstance familyInstance, View3D view3D, Document doc, double pointHigh)
        {
            XYZ point = (familyInstance.Location as LocationPoint).Point;
            var box = familyInstance.get_BoundingBox(view3D);
            double minZ = box.Min.Z;
            point = new XYZ(point.X, point.Y, minZ);

            Reference floorRef = GetElemetWithRay(XYZ.BasisZ.Negate(), new ElementId(-2000032), point, view3D);
            if (floorRef != null)
            {
                Floor linkFloor = floorRef.GetLinkElement(doc) as Floor;
                XYZ pp = floorRef.GlobalPoint;
                double dis = pp.DistanceTo(point);
                dis -= pointHigh;
                familyInstance.Location.Move(XYZ.BasisZ.Negate() * dis);
                return true;
            }
            return false;

        }

        private Reference GetNearestWallRefWithRay(FamilyInstance familyInstance, View3D view3D, Document doc)
        {
            XYZ point = (familyInstance.Location as LocationPoint).Point;

            List<Reference> references = new List<Reference>();
            Reference wallRef1 = GetElemetWithRay(XYZ.BasisX, new ElementId(-2000011), point, view3D); if (wallRef1 != null) references.Add(wallRef1);
            Reference wallRef2 = GetElemetWithRay(XYZ.BasisX.Negate(), new ElementId(-2000011), point, view3D); if (wallRef2 != null) references.Add(wallRef2);
            Reference wallRef3 = GetElemetWithRay(XYZ.BasisY, new ElementId(-2000011), point, view3D); if (wallRef3 != null) references.Add(wallRef3);
            Reference wallRef4 = GetElemetWithRay(XYZ.BasisY.Negate(), new ElementId(-2000011), point, view3D); if (wallRef4 != null) references.Add(wallRef4);
            if (references.Count == 0) return null;
            Reference reference = references.OrderBy(x => GetHorizontalLength(x, point, doc)).First();


            return reference;
        }
        private WallInfo GetNearestWall(FamilyInstance familyInstance, List<WallInfo> wallInfos)
        {
            
            XYZ p = (familyInstance.Location as LocationPoint).Point;
            XYZ pZ0 = new XYZ(p.X, p.Y, 0);
            WallInfo wallInfo = wallInfos.OrderBy(w => w.Line.Project(pZ0).XYZPoint.DistanceTo(pZ0)).First();


            return wallInfo;
        }

        private double GetHorizontalLength(Reference reference, XYZ point, Document doc)
        {
            double length = 0;

            Element element = reference.GetLinkElement(doc);
            Location location = element.Location;
            if (!(location is LocationCurve)) return length;
            Line line = (location as LocationCurve).Curve as Line;
            XYZ pp = line.Project(point).XYZPoint;
            pp = new XYZ(pp.X, pp.Y, point.Z);
            length = pp.DistanceTo(point);
            return length;
        }
        public XYZ GetHorizontalDirection(Wall wall, XYZ point)
        {
            Line line = (wall.Location as LocationCurve).Curve as Line;
            XYZ pp = line.Project(point).XYZPoint;
            pp = new XYZ(pp.X, pp.Y, point.Z);
            XYZ dir = (pp - point).Normalize().Negate();
            return dir;
        }
        public XYZ GetHorizontalDirection(Line wallLine, XYZ point)
        {
            XYZ pp = wallLine.Project(point).XYZPoint;
            pp = new XYZ(pp.X, pp.Y, point.Z);
            XYZ dir = (pp - point).Normalize().Negate();
            return dir;
        }

        /// <summary>
        /// 指定坐标点往指定方向寻找指定类型的元素
        /// </summary>
        /// <typeparam name="Reference"></typeparam>
        /// <param name="direction">射线方向</param>
        /// <param name="categoryId">类型ID</param>
        /// <param name="point">射线点</param>
        /// <param name="view3D">进行射线法查找的三维视图</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private Reference GetElemetWithRay(XYZ direction, ElementId categoryId, XYZ point, View3D view3D)
        {
            //T element = default(T);
            Reference reference = null;

            ElementCategoryFilter categoryFilter = new ElementCategoryFilter(categoryId);
            ReferenceIntersector intersector = new ReferenceIntersector(categoryFilter, FindReferenceTarget.Face, view3D);
            intersector.FindReferencesInRevitLinks = true;
            ReferenceWithContext referenceWithContext = intersector.FindNearest(point, direction);

            if (referenceWithContext == null)
            {
                //if (!direction.IsAlmostEqualTo(XYZ.BasisZ))
                //{
                //    return reference;
                //}
                //else
                //{
                //    XYZ min = point - XYZ.BasisX * 2 - XYZ.BasisY * 2 - XYZ.BasisZ * (2000 / 304.8);
                //    Outline outline = new Outline(min, point);
                //    BoundingBoxIntersectsFilter intersectsFilter = new BoundingBoxIntersectsFilter(outline);
                //    LogicalAndFilter andFilter = new LogicalAndFilter(categoryFilter, intersectsFilter);
                //    ReferenceIntersector intersector2 = new ReferenceIntersector(andFilter, FindReferenceTarget.Face, view3D);
                //    intersector2.FindReferencesInRevitLinks = true;
                //    ReferenceWithContext rWC = intersector2.FindNearest(point, direction.Negate());
                //    if (rWC == null) return reference;
                //    else
                //    {
                //        reference = rWC.GetReference();
                //        return reference;
                //    }
                //}
                return reference;
            }
            reference = referenceWithContext.GetReference();

            return reference;
        }
        //向下一定范围射线查看
        private Reference GetElemetWithRay(XYZ direction, ElementId categoryId, XYZ point, View3D view3D, double slope)
        {
            //T element = default(T);
            Reference reference = null;

            ElementCategoryFilter categoryFilter = new ElementCategoryFilter(categoryId);

            XYZ min = point - XYZ.BasisX * 2 - XYZ.BasisY * 2 - XYZ.BasisZ * slope;
            Outline outline = new Outline(min, point);
            BoundingBoxIntersectsFilter intersectsFilter = new BoundingBoxIntersectsFilter(outline);

            LogicalAndFilter andFilter = new LogicalAndFilter(categoryFilter, intersectsFilter);

            ReferenceIntersector intersector = new ReferenceIntersector(andFilter, FindReferenceTarget.Face, view3D);
            intersector.FindReferencesInRevitLinks = true;
            ReferenceWithContext referenceWithContext = intersector.FindNearest(point, direction);

            if (referenceWithContext == null) return reference;
            reference = referenceWithContext.GetReference();

            return reference;
        }
        /// <summary>
        /// 移动元素至与宿主元素贴合
        /// </summary>
        /// <param name="element"></param>
        /// <param name="hostElem"></param>
        /// <param name="doc"></param>
        public void MoveElement(Element element, Element hostElem, Document doc)
        {
            XYZ point = (element.Location as LocationPoint).Point;

            if (hostElem is Wall wall)
            {
                Line wallLine = (wall.Location as LocationCurve).Curve as Line;

                XYZ pp = wallLine.Project(point).XYZPoint;
                pp = new XYZ(pp.X, pp.Y, point.Z);
                double distance = pp.DistanceTo(point);
                distance -= wall.Width / 2;
                XYZ moveDir = (pp - point).Normalize();
                element.Location.Move(moveDir * distance);
            }

        }
        public void MoveElement(Element element, WallInfo wallInfo)
        {
            XYZ point = (element.Location as LocationPoint).Point;

            Line wallLine = wallInfo.Line;

            XYZ pp = wallLine.Project(point).XYZPoint;
            pp = new XYZ(pp.X, pp.Y, point.Z);
            double distance = pp.DistanceTo(point);
            distance -= wallInfo.Width / 2;
            XYZ moveDir = (pp - point).Normalize();
            element.Location.Move(moveDir * distance);
        }
        /// <summary>
        /// 旋转元素使其与指定面平行
        /// </summary>
        /// <param name="familyInstance"></param>
        /// <param name="wall"></param>
        /// <param name="doc"></param>
        public void RotateElement(FamilyInstance familyInstance, Wall wall, Document doc)
        {
            Transform transform = familyInstance.GetTransform();
            XYZ point2 = (familyInstance.Location as LocationPoint).Point;
            XYZ boxDir = transform.OfVector(XYZ.BasisX);

            Line line1 = (wall.Location as LocationCurve).Curve as Line;
            XYZ wallDir = line1.Direction;
            double angle = boxDir.AngleTo(wallDir);
            //if (angle > Math.PI / 2) angle = Math.PI - angle;
            ElementTransformUtils.RotateElement(doc, familyInstance.Id, Line.CreateBound(point2, point2 + XYZ.BasisZ), angle);
            if (!familyInstance.GetTransform().OfVector(XYZ.BasisX).IsAlmostEqualTo(wallDir))
            {
                ElementTransformUtils.RotateElement(doc, familyInstance.Id, Line.CreateBound(point2, point2 + XYZ.BasisZ.Negate()), angle * 2);
            }
        }
        public void RotateElement(FamilyInstance familyInstance, Line line, Document doc)
        {
            Transform transform = familyInstance.GetTransform();
            XYZ point2 = (familyInstance.Location as LocationPoint).Point;
            XYZ boxDir = transform.OfVector(XYZ.BasisX);

            XYZ wallDir = line.Direction;
            double angle = boxDir.AngleTo(wallDir);
            //if (angle > Math.PI / 2) angle = Math.PI - angle;
            ElementTransformUtils.RotateElement(doc, familyInstance.Id, Line.CreateBound(point2, point2 + XYZ.BasisZ), angle);
            if (!familyInstance.GetTransform().OfVector(XYZ.BasisX).IsAlmostEqualTo(wallDir))
            {
                ElementTransformUtils.RotateElement(doc, familyInstance.Id, Line.CreateBound(point2, point2 + XYZ.BasisZ.Negate()), angle * 2);
            }
        }
        /// <summary>
        /// 获取该元素所在通路的所有元素
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
            }


            return ids;
        }
        /// <summary>
        /// 获取坐标点到楼板的距离（自定义方向）
        /// </summary>
        /// <param name="view3D"></param>
        /// <param name="point"></param>
        /// <param name="doc"></param>
        /// <param name="dir"></param>
        /// <returns></returns>
        public double GetHeightToFloor(View3D view3D, XYZ point, Document doc, XYZ dir)
        {
            List<ElementFilter> filterList = new List<ElementFilter>();
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_Floors));
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_Ceilings));
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_StructuralFoundation));
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_RvtLinks));

            LogicalOrFilter floorOrCeiling = new LogicalOrFilter(filterList);
            ReferenceIntersector referenceIntersector = new ReferenceIntersector(floorOrCeiling, FindReferenceTarget.Element, view3D);
            referenceIntersector.FindReferencesInRevitLinks = true;
            ReferenceWithContext referenceWithContext = referenceIntersector.FindNearest(point, dir);

            if (referenceWithContext != null)
            {
                Element elem = referenceWithContext.GetReference().GetElement(doc);

                ReferenceWithContext referenceWith2 = referenceIntersector.FindNearest(point, dir.Negate());
                if (referenceWith2 != null)
                {
                    Element elem2 = referenceWith2.GetReference().GetElement(doc);
                    if (elem.Id == elem2.Id)
                    {
                        double neHeight = referenceWith2.GetReference().GlobalPoint.DistanceTo(point);
                        neHeight -= 50 / 304.8;
                        return -neHeight;
                    }
                }


                RevitLinkInstance revitLinkInstance = elem as RevitLinkInstance;
                Document linkDoc = revitLinkInstance.GetLinkDocument();
                Floor floor = referenceWithContext.GetReference().LinkedElementId.GetElement(linkDoc) as Floor;


                double height = referenceWithContext.GetReference().GlobalPoint.DistanceTo(point);

                height += 50 / 304.8;
                return height;
            }
            return -1;
        }
        /// <summary>
        /// 获取坐标点到楼板的距离（下）
        /// </summary>
        /// <param name="view3D"></param>
        /// <param name="point"></param>
        /// <param name="doc"></param>
        /// <returns></returns>
        public double GetHeightToFloor(View3D view3D, XYZ point, Document doc)
        {
            List<ElementFilter> filterList = new List<ElementFilter>();
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_Floors));
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_Ceilings));
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_StructuralFoundation));
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_RvtLinks));

            LogicalOrFilter floorOrCeiling = new LogicalOrFilter(filterList);
            ReferenceIntersector referenceIntersector = new ReferenceIntersector(floorOrCeiling, FindReferenceTarget.Element, view3D);
            referenceIntersector.FindReferencesInRevitLinks = true;
            ReferenceWithContext referenceWithContext = referenceIntersector.FindNearest(point, XYZ.BasisZ.Negate());

            if (referenceWithContext != null)
            {
                Element elem = referenceWithContext.GetReference().GetElement(doc);

                RevitLinkInstance revitLinkInstance = elem as RevitLinkInstance;
                Document linkDoc = revitLinkInstance.GetLinkDocument();
                Floor floor = referenceWithContext.GetReference().LinkedElementId.GetElement(linkDoc) as Floor;



                double height = referenceWithContext.GetReference().GlobalPoint.DistanceTo(point);

                height = height + floor.get_Parameter(BuiltInParameter.FLOOR_ATTR_THICKNESS_PARAM).AsDouble() - 50 / 304.8;
                return -height;
            }

            return -1;
        }
    }
    public class DevicesFilter : ISelectionFilter
    {
        public bool AllowElement(Element elem)
        {
            List<int> categoryIntValues = new List<int>()
            {
                (int)BuiltInCategory.OST_CommunicationDevices,
                (int)BuiltInCategory.OST_DataDevices,
                (int)BuiltInCategory.OST_FireAlarmDevices,
                (int)BuiltInCategory.OST_LightingFixtures,
                (int)BuiltInCategory.OST_NurseCallDevices,
                (int)BuiltInCategory.OST_SecurityDevices,
                (int)BuiltInCategory.OST_TelephoneDevices
                };
            if (categoryIntValues.Contains(elem.Category.Id.IntegerValue))
            {
                return true;
            }
            return false;
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            throw new NotImplementedException();
        }
    }
    public class WallInfo
    {
        // 创建墙体时的Line（经过坐标转换）
        public Line Line { get; set; }
        // 经过坐标转换后的墙体的Solid
        public Solid Solid { get; set; }
        // 墙的宽度
        public double Width { get; set; }
        public Wall Wall { get; set; }
    }
    public enum Categorys
    {
        D1 = BuiltInCategory.OST_ElectricalFixtures,
        D2 = BuiltInCategory.OST_CommunicationDevices,
        D3 = BuiltInCategory.OST_DataDevices,
        D4 = BuiltInCategory.OST_FireAlarmDevices,
        D5 = BuiltInCategory.OST_LightingFixtures,
        D6 = BuiltInCategory.OST_SecurityDevices,
        D7 = BuiltInCategory.OST_TelephoneDevices,
        D8 = BuiltInCategory.OST_NurseCallDevices
    }
}
