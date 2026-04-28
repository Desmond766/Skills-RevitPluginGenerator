using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace WallColumnLevelBeamFloor
{
    public class CutUtils
    {
        bool LevelBeam;
        bool LevelFloor;
        View3D View3D;
        ElementParameterFilter ParamFilter;

        public CutUtils(bool levelBeam, bool levelFloor, View3D view3D, ElementParameterFilter parameterFilter)
        {
            LevelBeam = levelBeam;
            LevelFloor = levelFloor;
            View3D = view3D;
            ParamFilter = parameterFilter;
        }
        public void LevelWall(Document doc, List<Element> walls, ref int count)
        {
            ElementFilter elementFilter = GetFilter();
            if (elementFilter == null) return;


            foreach (Element wall in walls)
            {
                // 25.7.10 墙中点坐标超过梁导致计算结果错误 || 楼板/梁被墙剪切导致射线结果出现问题
                //double dis = GetDistanceByRay(doc, wall, elementFilter, View3D, FindDirection.BasisZ, out string elemName);
                double dis = GetUpDistanceByRay(doc, wall, elementFilter, View3D, out string elemName);
                //TaskDialog.Show("revit", (dis*304.8).ToString());
                if (dis.Equals(double.NaN)) continue;
                using (Transaction t = new Transaction(doc, $"{elemName}切墙(上齐)"))
                {
                    t.Start();

                    if (null == doc.GetElement(wall.get_Parameter(BuiltInParameter.WALL_HEIGHT_TYPE).AsElementId()) as Level)
                    {
                        //墙无连接高度
                        wall.get_Parameter(BuiltInParameter.WALL_USER_HEIGHT_PARAM).Set(wall.get_Parameter(BuiltInParameter.WALL_USER_HEIGHT_PARAM).AsDouble() + dis);

                    }
                    else
                    {
                        //墙顶部偏移
                        wall.get_Parameter(BuiltInParameter.WALL_TOP_OFFSET).Set(wall.get_Parameter(BuiltInParameter.WALL_TOP_OFFSET).AsDouble() + dis);
                    }


                    t.Commit();
                }
                count++;
            }

        }
        public void LevelColumns(Document doc, List<Element> columns, ref int count)
        {
            ElementFilter elementFilter = GetFilter();
            if (elementFilter == null) return;

            foreach (Element column in columns)
            {

                double dis = GetUpDistanceByRay(doc, column, elementFilter, View3D, out string elemName);
                if (dis.Equals(double.NaN)) continue;

                using (Transaction t = new Transaction(doc, $"{elemName}切柱(上齐)"))
                {
                    t.Start();

                    column.get_Parameter(BuiltInParameter.FAMILY_TOP_LEVEL_OFFSET_PARAM).Set(column.get_Parameter(BuiltInParameter.FAMILY_TOP_LEVEL_OFFSET_PARAM).AsDouble() + dis);

                    t.Commit();
                }
                count++;
            }
        }
        public void DownLevelWall(Document doc, List<Element> walls, ref int count)
        {
            ElementFilter elementFilter = GetFilter();
            if (elementFilter == null) return;


            foreach (Element wall in walls)
            {

                double dis = GetDownDistanceByRay(doc, wall, elementFilter, View3D, out string elemName);
                if (dis.Equals(double.NaN)) continue;
                using (Transaction t = new Transaction(doc, $"{elemName}切墙(下齐)"))
                {
                    t.Start();
                    if (null == doc.GetElement(wall.get_Parameter(BuiltInParameter.WALL_HEIGHT_TYPE).AsElementId()) as Level)
                    {
                        //TaskDialog.Show("ds", "11");
                        wall.get_Parameter(BuiltInParameter.WALL_BASE_OFFSET).Set(wall.get_Parameter(BuiltInParameter.WALL_BASE_OFFSET).AsDouble() - dis);
                        //墙无连接高度
                        wall.get_Parameter(BuiltInParameter.WALL_USER_HEIGHT_PARAM).Set(wall.get_Parameter(BuiltInParameter.WALL_USER_HEIGHT_PARAM).AsDouble() + dis);

                    }
                    else
                    {
                        //TaskDialog.Show("ds", ((wall.get_Parameter(BuiltInParameter.WALL_BASE_OFFSET).AsDouble() - dis)*304.8).ToString());
                        //墙底部偏移
                        wall.get_Parameter(BuiltInParameter.WALL_BASE_OFFSET).Set(wall.get_Parameter(BuiltInParameter.WALL_BASE_OFFSET).AsDouble() - dis);
                    }


                    t.Commit();
                }
                count++;
            }
        }
        public void DownLevelColumns(Document doc, List<Element> columns, ref int count)
        {
            ElementFilter elementFilter = GetFilter();
            if (elementFilter == null) return;

            foreach (Element column in columns)
            {

                double dis = GetDownDistanceByRay(doc, column, elementFilter, View3D, out string elemName);
                if (dis.Equals(double.NaN)) continue;

                using (Transaction t = new Transaction(doc, $"{elemName}切柱(下齐)"))
                {
                    t.Start();

                    column.get_Parameter(BuiltInParameter.FAMILY_BASE_LEVEL_OFFSET_PARAM).Set(column.get_Parameter(BuiltInParameter.FAMILY_BASE_LEVEL_OFFSET_PARAM).AsDouble() - dis);

                    t.Commit();
                }
                count++;
            }
        }
        private double GetDistanceByRay(Element e, List<ElementId> findIds, View3D view3D, FindDirection findDirection)
        {
            double dis = double.NaN;

            XYZ direction;

            var box = e.get_BoundingBox(null);
            double halfBoxHeight = (box.Max.Z - box.Min.Z) / 2;
            XYZ p = box.Min.Add(box.Max) / 2;
            if (findDirection == FindDirection.BasisZ)
            {
                direction = XYZ.BasisZ;
                //p = new XYZ(p.X, p.Y, box.Min.Z);
            }
            else
            {
                direction = XYZ.BasisZ.Negate();
                //p = new XYZ(p.X, p.Y, box.Max.Z);
            }
            ReferenceIntersector intersector = new ReferenceIntersector(findIds, FindReferenceTarget.Element, view3D);
            intersector.FindReferencesInRevitLinks = true;
            var rw = intersector.FindNearest(p, direction);
            if (rw != null)
            {
                dis = rw.GetReference().GlobalPoint.DistanceTo(p) - halfBoxHeight;
            }
            return dis;
        }
        private double GetDownDistanceByRay(Document doc, Element e, ElementFilter elementFilter, View3D view3D, out string elemName)
        {
            double dis = double.NaN;

            elemName = "";

            XYZ direction = XYZ.BasisZ.Negate();

            var box = e.get_BoundingBox(null);
            double halfBoxHeight = (box.Max.Z - box.Min.Z) / 2;
            XYZ p = box.Min.Add(box.Max) / 2;
            //if (findDirection == FindDirection.BasisZ)
            //{
            //    direction = XYZ.BasisZ;
            //}
            //else
            //{
            //    direction = XYZ.BasisZ.Negate();
            //}
            ReferenceIntersector intersector = new ReferenceIntersector(elementFilter, FindReferenceTarget.Element, view3D);
            intersector.FindReferencesInRevitLinks = true;
            var rw = intersector.FindNearest(p, direction);
            // 1.
            if (rw != null)
            {
                dis = rw.GetReference().GlobalPoint.DistanceTo(p) - halfBoxHeight;
                //TaskDialog.Show("revit", rw.GetReference().GlobalPoint.DistanceTo(p) + "\n" + rw.GetReference().GlobalPoint + "\n" + p + "\n" + halfBoxHeight);
                if (doc.GetElement(rw.GetReference()) is RevitLinkInstance linkInstance)
                {
                    Document linkDoc = linkInstance.GetLinkDocument();
                    Element linkElem = linkDoc.GetElement(rw.GetReference().LinkedElementId);
                    if (linkElem is Floor) elemName = "链接楼板";
                    else elemName = "链接梁";
                    // 2.
                    var rw2 = intersector.FindNearest(p, direction.Negate());
                    if (rw2 != null && rw2.GetReference().LinkedElementId.Equals(rw.GetReference().LinkedElementId))
                    {
                        dis = -(box.Max.Z - rw2.GetReference().GlobalPoint.Z);
                    }
                }
                else
                {
                    Element element = doc.GetElement(rw.GetReference());
                    if (element is Floor)
                        elemName = "楼板";
                    else
                        elemName = "梁";
                    // 2.
                    var rw2 = intersector.FindNearest(p, direction.Negate());
                    //TaskDialog.Show("ee", "3" + "\n" + (dis * 304.8) + "\n" + (rw2 == null) + "\n" + (rw2 != null && rw2.GetReference().ElementId.Equals(rw.GetReference().ElementId)));
                    if (JoinGeometryUtils.AreElementsJoined(doc, e, element) && JoinGeometryUtils.IsCuttingElementInJoin(doc, e, element))
                    {
                        //TaskDialog.Show("ds", "1");
                        dis = -(box.Max.Z - element.get_BoundingBox(null).Min.Z);
                    }
                    else if (rw2 != null && rw2.GetReference().ElementId.Equals(rw.GetReference().ElementId))
                    {
                        //TaskDialog.Show("ds", "22" + "\n" + box.Max.Z + "\n" + rw2.GetReference().GlobalPoint.Z);
                        dis = -(box.Max.Z - rw2.GetReference().GlobalPoint.Z);
                    }
                    // 3.非链接模型
                    else if ((rw2 == null || (rw2 != null && !rw2.GetReference().ElementId.Equals(rw.GetReference().ElementId))) && Math.Abs(element.get_BoundingBox(null).Max.Z - rw.GetReference().GlobalPoint.Z) < 0.001)
                    {
                        //TaskDialog.Show("ds", "3");
                        //var res = JoinGeometryUtils.AreElementsJoined(doc, e, element) && JoinGeometryUtils.IsCuttingElementInJoin(doc, e, element);
                        dis = box.Min.Z - element.get_BoundingBox(null).Max.Z;
                    }
                    //TaskDialog.Show("revittt", (rw2 == null) + "\n" + element.get_BoundingBox(null).Min.Z + "\n" + rw.GetReference().GlobalPoint.Z + "\n" + rw2.GetReference().ElementId +"\n" + rw.GetReference().ElementId);
                }
                //TaskDialog.Show("revit", (dis * 304.8).ToString());
            }
            return dis;
        }
        private double GetUpDistanceByRay(Document doc, Element e, ElementFilter elementFilter, View3D view3D, out string elemName)
        {
            double dis = double.NaN;

            elemName = "";

            XYZ direction = XYZ.BasisZ;

            var box = e.get_BoundingBox(null);
            double halfBoxHeight = (box.Max.Z - box.Min.Z) / 2;
            XYZ p = box.Min.Add(box.Max) / 2;

            ReferenceIntersector intersector = new ReferenceIntersector(elementFilter, FindReferenceTarget.Element, view3D);
            intersector.FindReferencesInRevitLinks = true;
            ReferenceWithContext rw = null;
            // UPDATE: 26.3.19墙柱上方同时存在梁板时优先齐楼板
            if (LevelBeam && LevelFloor)
            {
                var rws = intersector.Find(p, direction);
                if (rws.Count > 0)
                {
                    rw = rws.FirstOrDefault(r => GetElementCategoryName(doc, r.GetReference()) == "楼板");
                    if (rw == null) rw = rws.First();
                }
            }
            else
            {
                rw = intersector.FindNearest(p, direction);
            }
            // 1.
            if (rw != null)
            {
                dis = rw.GetReference().GlobalPoint.DistanceTo(p) - halfBoxHeight;
                //TaskDialog.Show("revit", rw.GetReference().GlobalPoint.DistanceTo(p) + "\n" + rw.GetReference().GlobalPoint + "\n" + p + "\n" + halfBoxHeight);
                if (doc.GetElement(rw.GetReference()) is RevitLinkInstance linkInstance)
                {
                    Document linkDoc = linkInstance.GetLinkDocument();
                    Element linkElem = linkDoc.GetElement(rw.GetReference().LinkedElementId);
                    if (linkElem is Floor) elemName = "链接楼板";
                    else elemName = "链接梁";
                    // 2.
                    var rw2 = intersector.FindNearest(p, direction.Negate());
                    if (rw2 != null && rw2.GetReference().LinkedElementId.Equals(rw.GetReference().LinkedElementId))
                    {
                        dis = -(box.Max.Z - rw2.GetReference().GlobalPoint.Z);
                    }
                }
                else
                {
                    Element element = doc.GetElement(rw.GetReference());
                    if (element is Floor)
                        elemName = "楼板";
                    else
                        elemName = "梁";
                    // 2.
                    var rw2 = intersector.FindNearest(p, direction.Negate());
                    //TaskDialog.Show("ee", "3" + "\n" + (dis * 304.8) + "\n" + (rw2 == null) + "\n" + (rw2 != null && rw2.GetReference().ElementId.Equals(rw.GetReference().ElementId)));
                    if (JoinGeometryUtils.AreElementsJoined(doc, e, element) && JoinGeometryUtils.IsCuttingElementInJoin(doc, e, element))
                    {
                        //TaskDialog.Show("ds", "1");
                        dis = -(box.Max.Z - element.get_BoundingBox(null).Min.Z);
                    }
                    else if (rw2 != null && rw2.GetReference().ElementId.Equals(rw.GetReference().ElementId))
                    {
                        //TaskDialog.Show("ds", "2");
                        dis = -(box.Max.Z - rw2.GetReference().GlobalPoint.Z);
                    }
                    // 3.非链接模型
                    else if ((rw2 == null || (rw2 != null && !rw2.GetReference().ElementId.Equals(rw.GetReference().ElementId))) && Math.Abs(element.get_BoundingBox(null).Min.Z - rw.GetReference().GlobalPoint.Z) < 0.001)
                    {
                        //TaskDialog.Show("ds", "3" + "\n" + (rw2 == null) + "\n" + element.get_BoundingBox(null).Min.Z + "\n" + rw.GetReference().GlobalPoint.Z);
                        //var res = JoinGeometryUtils.AreElementsJoined(doc, e, element) && JoinGeometryUtils.IsCuttingElementInJoin(doc, e, element);
                        dis = - (box.Max.Z - element.get_BoundingBox(null).Min.Z);
                    }
                }
                //TaskDialog.Show("revit", (dis * 304.8).ToString() +"\n" + doc.GetElement(rw.GetReference()).Id);
            }
            return dis;
        }
        private string GetElementCategoryName(Document doc, Reference reference)
        {
            string result = "";

            Element element = doc.GetElement(reference);
            if (element is RevitLinkInstance linkInstance)
            {
                Document linkDoc = linkInstance.GetLinkDocument();
                Element linkElem = linkDoc.GetElement(reference.LinkedElementId);
                if (linkElem is Floor)
                {
                    result = "楼板";
                }
                else
                {
                    result = "梁";
                }
            }
            else
            {
                if (element is Floor)
                {
                    result = "楼板";
                }
                else
                {
                    result = "梁";
                }
            }

            return result;
        }
        private ElementFilter GetFilter()
        {
            ElementFilter elementFilter = null;
            if (LevelBeam && LevelFloor)
            {
                LogicalAndFilter andFilter = new LogicalAndFilter(new ElementCategoryFilter(BuiltInCategory.OST_Floors), ParamFilter);
                LogicalOrFilter orFilter = new LogicalOrFilter(andFilter, new ElementCategoryFilter(BuiltInCategory.OST_StructuralFraming));
                elementFilter = orFilter;
            }
            else if (!LevelBeam && LevelFloor)
            {
                elementFilter = new LogicalAndFilter(new ElementCategoryFilter(BuiltInCategory.OST_Floors), ParamFilter);
            }
            else if (LevelBeam && !LevelFloor)
            {
                elementFilter = new ElementCategoryFilter(BuiltInCategory.OST_StructuralFraming);
            }
            return elementFilter;
        }
        enum FindDirection
        {
            BasisZ,
            Negate
        }
    }
}
