using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrangeHangerAccordingToNozzle
{
    public class Utils
    {
        #region 获得向下投影到楼板的点
        public static XYZ GetClearHeightPoint(View3D view, Document doc, XYZ point_Do)
        {
            XYZ point;
            //梁的计算点point_Do 

            List<ElementFilter> filterList = new List<ElementFilter>();
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_Floors));
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_Ceilings));
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_StructuralFoundation));
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_RvtLinks));

            LogicalOrFilter floorOrCeiling = new LogicalOrFilter(filterList);
            //change
            //FilterRule filterRule = ParameterFilterRuleFactory.CreateHasValueParameterRule(new ElementId((int)BuiltInParameter.STRUCTURAL_ELEVATION_AT_TOP));
            FilterRule filterRule = ParameterFilterRuleFactory.CreateHasValueParameterRule(new ElementId(-1001598));
            ElementParameterFilter elementParameterFilter = new ElementParameterFilter(filterRule);
            LogicalAndFilter logicalAndFilter = new LogicalAndFilter(floorOrCeiling, elementParameterFilter);

            //相交                                                                    change
            //ReferenceIntersector referenceIntersector = new ReferenceIntersector(elementParameterFilter, FindReferenceTarget.All, view);
            //referenceIntersector.FindReferencesInRevitLinks = true;

            //ReferenceWithContext referenceWithContext = referenceIntersector.FindNearest(point_Do, XYZ.BasisZ.Negate());

            ReferenceIntersector referenceIntersector1 = new ReferenceIntersector(floorOrCeiling, FindReferenceTarget.All, view);
            referenceIntersector1.FindReferencesInRevitLinks = true;
            ReferenceWithContext referenceWithContext1 = referenceIntersector1.FindNearest(point_Do, XYZ.BasisZ.Negate());
            Reference r3 = referenceWithContext1.GetReference();
            XYZ point1 = r3.GlobalPoint;
            //Floor floor1 = doc.GetElement(r3) as Floor;

            //Reference r2 = referenceWithContext.GetReference();
            //point = r2.GlobalPoint;
            //Floor floor = doc.GetElement(r2) as Floor;
            //if (!(floor.get_Parameter(BuiltInParameter.FLOOR_ATTR_THICKNESS_PARAM).AsValueString().Equals(floor1.get_Parameter(BuiltInParameter.FLOOR_ATTR_THICKNESS_PARAM).AsValueString())))
            //{
            //    point = point + new XYZ(0, 0, floor1.get_Parameter(BuiltInParameter.FLOOR_ATTR_THICKNESS_PARAM).AsDouble());
            //}
            //DrawModelCurve(doc, point_Do, r2.GlobalPoint);

            return point1;

        }
        #endregion
        #region 获得向上投影到楼板的点
        public static XYZ GetClearHeightPoint1(View3D view, Document doc, XYZ point_Do)
        {
            XYZ point;
            //梁的计算点point_Do 

            List<ElementFilter> filterList = new List<ElementFilter>();
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_Floors));
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_Ceilings));
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_StructuralFoundation));
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_RvtLinks));

            LogicalOrFilter floorOrCeiling = new LogicalOrFilter(filterList);
            //change
            //FilterRule filterRule = ParameterFilterRuleFactory.CreateHasValueParameterRule(new ElementId((int)BuiltInParameter.STRUCTURAL_ELEVATION_AT_TOP));
            FilterRule filterRule = ParameterFilterRuleFactory.CreateHasValueParameterRule(new ElementId(-1001598));
            ElementParameterFilter elementParameterFilter = new ElementParameterFilter(filterRule);
            LogicalAndFilter logicalAndFilter = new LogicalAndFilter(floorOrCeiling, elementParameterFilter);

            //相交                                                                    change
            //ReferenceIntersector referenceIntersector = new ReferenceIntersector(elementParameterFilter, FindReferenceTarget.All, view);
            //referenceIntersector.FindReferencesInRevitLinks = true;

            //ReferenceWithContext referenceWithContext = referenceIntersector.FindNearest(point_Do, XYZ.BasisZ.Negate());

            ReferenceIntersector referenceIntersector1 = new ReferenceIntersector(floorOrCeiling, FindReferenceTarget.All, view);
            referenceIntersector1.FindReferencesInRevitLinks = true;
            ReferenceWithContext referenceWithContext1 = referenceIntersector1.FindNearest(point_Do, XYZ.BasisZ);
            Reference r3 = referenceWithContext1.GetReference();
            XYZ point1 = r3.GlobalPoint;
            //Floor floor1 = doc.GetElement(r3) as Floor;

            //Reference r2 = referenceWithContext.GetReference();
            //point = r2.GlobalPoint;
            //Floor floor = doc.GetElement(r2) as Floor;
            //if (!(floor.get_Parameter(BuiltInParameter.FLOOR_ATTR_THICKNESS_PARAM).AsValueString().Equals(floor1.get_Parameter(BuiltInParameter.FLOOR_ATTR_THICKNESS_PARAM).AsValueString())))
            //{
            //    point = point + new XYZ(0, 0, floor1.get_Parameter(BuiltInParameter.FLOOR_ATTR_THICKNESS_PARAM).AsDouble());
            //}
            //DrawModelCurve(doc, point_Do, r2.GlobalPoint);

            return point1;

        }
        #endregion
        #region 获得管线向上投影的净高
        public static double GetClearHeightUp(View3D view, Document doc, XYZ point_Do)
        {
            double distance = 0.0;
            //梁的计算点point_Do 

            List<ElementFilter> filterList = new List<ElementFilter>();
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_Floors));
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_StructuralFraming));
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_Ceilings));
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_StructuralFoundation));
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_RvtLinks));

            LogicalOrFilter floorOrCeiling = new LogicalOrFilter(filterList);


            //相交
            ReferenceIntersector referenceIntersector = new ReferenceIntersector(floorOrCeiling, FindReferenceTarget.All, view);
            referenceIntersector.FindReferencesInRevitLinks = true;

            ReferenceWithContext referenceWithContext = referenceIntersector.FindNearest(point_Do, XYZ.BasisZ);

            Reference r2 = referenceWithContext.GetReference();
            distance = r2.GlobalPoint.DistanceTo(point_Do);
            //DrawModelCurve(doc, point_Do, r2.GlobalPoint);

            return distance;

        }
        #endregion
        public static List<XYZ> NewMethod(Element fitfm)
        {
            List<XYZ> dirList = new List<XYZ>();
            // XYZ rayDirection1 = new XYZ(0, 0, 1);//向上的法向量

            LocationCurve locationCureve = fitfm.Location as LocationCurve;
            Curve curve = locationCureve.Curve;
            XYZ start = curve.GetEndPoint(0);
            XYZ end = curve.GetEndPoint(1);

            XYZ vect1 = start.CrossProduct(end);     //两向量组成面的法向量
            XYZ rayDirection2 = new XYZ(vect1.X, vect1.Y, 0);

            XYZ vect2 = end.CrossProduct(start);
            XYZ rayDirection3 = new XYZ(vect2.X, vect2.Y, 0);

            dirList.Add(rayDirection2);
            dirList.Add(rayDirection3);
            return dirList;
        }
        public static bool CheckVertical(Document doc, Element reference)
        {
            LocationCurve locationCureve = reference.Location as LocationCurve;
            Curve curve = locationCureve.Curve;


            XYZ start = curve.GetEndPoint(0);
            XYZ end = curve.GetEndPoint(1);
            //if (Math.Abs(start.X - end.Z) < 0.00001) 
            if(start.X==end.X)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// 拿到当前项目里面的所有链接模型
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        public static List<RevitLinkInstance> GetRevitLinks(Document doc)
        {
            List<RevitLinkInstance> links = new List<RevitLinkInstance>();
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            links = collector.OfClass(typeof(RevitLinkInstance)).Cast<RevitLinkInstance>().ToList();

            return links;
        }

        /// <summary>
        /// 拿到链接模型里面所有的管线
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        public static FilteredElementCollector GetLinkPipe(RevitLinkInstance revitLink,BuiltInCategory bc)
        {
            List<Pipe> pipes = new List<Pipe>();
            Document linkDoc = revitLink.GetLinkDocument();
            FilteredElementCollector collector = new FilteredElementCollector(linkDoc);
            collector.OfCategory(bc); //OST_PipeCurves  OST_CableTray  OST_DuctCurves
            return collector;
        }
        public static Autodesk.Revit.DB.Plane ToPlane(XYZ point, XYZ other)
        {
            var v = other - point;
            if (v.Normalize().IsAlmostEqualTo(XYZ.BasisX)
                || v.Normalize().IsAlmostEqualTo(XYZ.BasisX.Negate()))
            {
                return Autodesk.Revit.DB.Plane.CreateByNormalAndOrigin(XYZ.BasisZ, point);
            }
            var angle = v.AngleTo(XYZ.BasisX);
            var norm = v.CrossProduct(XYZ.BasisX).Normalize();

            if (Math.Abs(angle - 0) < 1e-4)
            {
                angle = v.AngleTo(XYZ.BasisY);
                norm = v.CrossProduct(XYZ.BasisY).Normalize();
            }

            if (Math.Abs(angle - 0) < 1e-4)
            {
                angle = v.AngleTo(XYZ.BasisZ);
                norm = v.CrossProduct(XYZ.BasisZ).Normalize();
            }
            //return new Autodesk.Revit.DB.Plane(norm, point);
            return Autodesk.Revit.DB.Plane.CreateByNormalAndOrigin(norm, point);//2018
        }
        #region 绘制模型线
        /// <summary>
        /// 绘制模型线
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        public static void CreateModelLine(Document doc, XYZ p1, XYZ p2)
        {
            using (var line = Line.CreateBound(p1, p2))
            {
                using (var skPlane = SketchPlane.Create(doc, ToPlane(p1, p2)))
                {
                    if (doc.IsFamilyDocument)
                    {
                        doc.FamilyCreate.NewModelCurve(line, skPlane);
                    }
                    else
                    {
                        doc.Create.NewModelCurve(line, skPlane);
                    }
                }
            }
        }
        #endregion

        public static void setLeft(double val, Element fitfm)
        {

            if (fitfm.Category.Name == "风管")
            {
                Parameter Flength1 = fitfm.LookupParameter("风管左间距");
                Flength1.SetValueString(val.ToString());

            }
            if (fitfm.Category.Name == "电缆桥架")
            {
                Parameter Flength1 = fitfm.LookupParameter("桥架左间距");
                Flength1.SetValueString(val.ToString());
                Parameter Flength21 = fitfm.LookupParameter("桥架检修运算");
                Flength21.Set("运算完成");
            }
            if (fitfm.Category.Name == "管道")
            {
                Parameter Flength1 = fitfm.LookupParameter("管道左间距");
                Flength1.SetValueString(val.ToString());
            }
            if (fitfm.Category.Name == "管道附件")
            {
                Parameter Flength1 = fitfm.LookupParameter("阀门左间距");
                Flength1.SetValueString(val.ToString());
                Parameter Flength22 = fitfm.LookupParameter("阀门检修运算");
                Flength22.Set("运算完成");
            }
        }
        public static void setRight(double val, Element fitfm)
        {
            if (fitfm.Category.Name == "风管")
            {
                Parameter Flength2 = fitfm.LookupParameter("风管右间距");
                Flength2.SetValueString(val.ToString());
            }
            if (fitfm.Category.Name == "电缆桥架")
            {
                Parameter Flength2 = fitfm.LookupParameter("桥架右间距");
                Flength2.SetValueString(val.ToString());
            }
            if (fitfm.Category.Name == "管道")
            {
                Parameter Flength2 = fitfm.LookupParameter("管道右间距");
                Flength2.SetValueString(val.ToString());
            }
            if (fitfm.Category.Name == "管道附件")
            {
                Parameter Flength1 = fitfm.LookupParameter("阀门右间距");
                Flength1.SetValueString(val.ToString());
                Parameter Flength23 = fitfm.LookupParameter("阀门检修运算");
                Flength23.Set("运算完成");
            }


        }
        public static void setUP(double val, Element fitfm)
        {
            if (fitfm.Category.Name == "风管")
            {
                Parameter Flength3 = fitfm.LookupParameter("风管上间距");
                Flength3.SetValueString(val.ToString());
            }
            if (fitfm.Category.Name == "电缆桥架")
            {
                Parameter Flength3 = fitfm.LookupParameter("桥架上间距");
                Flength3.SetValueString(val.ToString());
                Parameter Flength222 = fitfm.LookupParameter("桥架检修运算");
                Flength222.Set("运算完成");
            }
            if (fitfm.Category.Name == "管道")
            {
                Parameter Flength3 = fitfm.LookupParameter("管道上间距");
                Flength3.SetValueString(val.ToString());
            }
            if (fitfm.Category.Name == "管道附件")
            {
                Parameter Flength1 = fitfm.LookupParameter("阀门上间距");
                Flength1.SetValueString(val.ToString());
                Parameter Flength200 = fitfm.LookupParameter("阀门检修运算");
                Flength200.Set("运算完成");
            }
        }

        /// <summary>
        /// 拿到房间边线
        /// </summary>
        /// <param name="room"></param>
        /// <returns></returns>
        public static List<CurveLoop> GetRoomLoop(Room room)
        {
            var boudaries = room.GetBoundarySegments(new SpatialElementBoundaryOptions() { SpatialElementBoundaryLocation = SpatialElementBoundaryLocation.Finish });
            List<CurveLoop> loops = new List<CurveLoop>();
            foreach (var boundarys in boudaries)
            {
                List<Curve> curves = new List<Curve>();
                foreach (var boundary in boundarys)
                {
                    curves.Add(boundary.GetCurve());
                }
                CurveLoop loop = CurveLoop.Create(curves);
                loops.Add(loop);
            }
            return loops;
        }
        public static double GetHalfWide(Element mep)
        {
            double wide = 0.0;
            //风管
            if (mep.Category.Id.IntegerValue == (int)BuiltInCategory.OST_DuctCurves)
            {
                wide = mep.get_Parameter(BuiltInParameter.RBS_CURVE_WIDTH_PARAM).AsDouble() / 2;
            }
            //水管
            else if (mep.Category.Id.IntegerValue == (int)BuiltInCategory.OST_PipeCurves)
            {
                wide = mep.get_Parameter(BuiltInParameter.RBS_PIPE_OUTER_DIAMETER).AsDouble() / 2;
            }
            //线槽
            else if (mep.Category.Id.IntegerValue == (int)BuiltInCategory.OST_CableTray)
            {
                wide = mep.get_Parameter(BuiltInParameter.RBS_CABLETRAY_WIDTH_PARAM).AsDouble() / 2;
            }

            return wide;
        }
        public static double GetWide(Element mep)
        {
            double wide = 0.0;
            //风管
            if (mep.Category.Id.IntegerValue == (int)BuiltInCategory.OST_DuctCurves)
            {
                wide = mep.get_Parameter(BuiltInParameter.RBS_CURVE_WIDTH_PARAM).AsDouble();
            }
            //水管
            else if (mep.Category.Id.IntegerValue == (int)BuiltInCategory.OST_PipeCurves)
            {
                wide = mep.get_Parameter(BuiltInParameter.RBS_PIPE_OUTER_DIAMETER).AsDouble();
            }
            //线槽
            else if (mep.Category.Id.IntegerValue == (int)BuiltInCategory.OST_CableTray)
            {
                wide = mep.get_Parameter(BuiltInParameter.RBS_CABLETRAY_WIDTH_PARAM).AsDouble();
            }

            return wide;
        }
        /// <summary>
        /// 过滤出与solid相交的模型
        /// </summary>
        /// <param name="solid"></param>
        /// <param name="collector"></param>
        /// <returns></returns>
        public static List<Element> LinkElementIntersetSolid(Solid solid, FilteredElementCollector collector)
        {
            List<Element> pipes = new List<Element>();
            ElementIntersectsSolidFilter solidFilter = new ElementIntersectsSolidFilter(solid);
            collector.WherePasses(solidFilter);
            pipes = collector.ToList();
            return pipes;
        }
        public static void Write(string cont)
        {
            FileStream fs = null;
            string filePath = "D:\\file1.txt";
            //将待写的入数据从字符串转换为字节数组
            Encoding encoder = Encoding.UTF8;
            byte[] bytes = encoder.GetBytes(cont + " \n\r");
            try
            {
                fs = File.OpenWrite(filePath);
                //设定书写的开始位置为文件的末尾
                fs.Position = fs.Length;
                //将待写入内容追加到文件末尾
                fs.Write(bytes, 0, bytes.Length);
            }
            catch (Exception ex)
            {
                Console.WriteLine("文件打开失败{0}", ex.ToString());
            }
            finally
            {
                fs.Close();
            }
            Console.ReadLine();
        }

        public static List<XYZ> setDir()
        {
            List<XYZ> dirList = new List<XYZ>();

            XYZ rayDirection = new XYZ(0, -1, 0); //风管的右边
            XYZ rayDirection2 = new XYZ(0, 1, 0);//风管的左边
            XYZ rayDirection3 = new XYZ(0, 0, 1);//风管的上边

            dirList.Add(rayDirection);
            dirList.Add(rayDirection2);
            dirList.Add(rayDirection3);
            return dirList;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        public static View3D set3D(Document doc)
        {
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            Func<View3D, bool> isNotTemplate = v3 => !(v3.IsTemplate);
            View3D view3D = collector.OfClass(typeof(View3D)).Cast<View3D>().First<View3D>(isNotTemplate);
            return view3D;
        }
        public static List<ElementCategoryFilter> all_Cure()
        {
            List<ElementCategoryFilter> catFilterList = new List<ElementCategoryFilter>();
            ElementCategoryFilter catFilter = new ElementCategoryFilter(BuiltInCategory.OST_DuctCurves);
            ElementCategoryFilter catFilter2 = new ElementCategoryFilter(BuiltInCategory.OST_PipeCurves);
            ElementCategoryFilter catFilter3 = new ElementCategoryFilter(BuiltInCategory.OST_Walls);
            ElementCategoryFilter catFilter4 = new ElementCategoryFilter(BuiltInCategory.OST_CableTray);
            catFilterList.Add(catFilter);
            catFilterList.Add(catFilter2);
            catFilterList.Add(catFilter3);
            catFilterList.Add(catFilter4);
            return catFilterList;
        }
    }
}
