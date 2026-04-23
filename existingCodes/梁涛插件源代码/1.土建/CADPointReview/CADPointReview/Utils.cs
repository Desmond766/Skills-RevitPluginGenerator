using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CADPointReview
{
    public class Utils
    {
        public static Solid CreateSolid(XYZ centerP, double r, double halfHeight)
        {
            Solid solid;

            centerP = centerP - XYZ.BasisZ * halfHeight;

            XYZ p1 = centerP - XYZ.BasisX * r + XYZ.BasisY * r;
            XYZ p2 = centerP + XYZ.BasisX * r + XYZ.BasisY * r;
            XYZ p3 = centerP + XYZ.BasisX * r - XYZ.BasisY * r;
            XYZ p4 = centerP - XYZ.BasisX * r - XYZ.BasisY * r;

            //放样
            List<CurveLoop> loops = new List<CurveLoop>();
            List<Curve> curveList = new List<Curve> { Line.CreateBound(p1, p2), Line.CreateBound(p2, p3), Line.CreateBound(p3, p4), Line.CreateBound(p4, p1) };
            CurveLoop curveLoop = CurveLoop.Create(curveList);
            loops.Add(curveLoop);
            //拉伸
            solid = GeometryCreationUtilities.CreateExtrusionGeometry(loops, XYZ.BasisZ, halfHeight * 2);
            ElementIntersectsSolidFilter filter = new ElementIntersectsSolidFilter(solid);

            return solid;
        }
        public static ElementIntersectsSolidFilter CreateSolidFilter(XYZ centerP, double r, double halfHeight)
        {
            Solid solid = CreateSolid(centerP, r, halfHeight);
            return new ElementIntersectsSolidFilter(solid);
        }
        public static BoundingBoxIntersectsFilter CreateBoxFilter(XYZ centerP, double r, double halfHeight)
        {
            XYZ min = centerP - XYZ.BasisX * r - XYZ.BasisY * r - XYZ.BasisZ * halfHeight;
            XYZ max = centerP + XYZ.BasisX * r + XYZ.BasisY * r + XYZ.BasisZ * halfHeight;

            return new BoundingBoxIntersectsFilter(new Outline(min, max));
        }
        /// <summary>
        /// 针对项目的结构柱过滤器
        /// </summary>
        /// <returns></returns>
        public static ElementFilter CreateColumnFilter(Param param, int paramValue)
        {
            ElementFilter elementFilter;

            ElementCategoryFilter categoryFilter = new ElementCategoryFilter(BuiltInCategory.OST_StructuralColumns);
            // 创建一个过滤器过滤出存在参数“结构”且strongtype为int32且值为1的元素
            ElementId ruleParamId = new ElementId((int)param);
            FilterRule filteRule = ParameterFilterRuleFactory.CreateEqualsRule(ruleParamId, paramValue);
            ElementParameterFilter paramFilter = new ElementParameterFilter(filteRule);

            elementFilter = new LogicalAndFilter(categoryFilter, paramFilter);
            return elementFilter;
        }
        public static ElementFilter CreateColumnFilter(List<Param> columnParams, int paramValue)
        {
            ElementFilter elementFilter;

            ElementCategoryFilter categoryFilter = new ElementCategoryFilter(BuiltInCategory.OST_StructuralColumns);
            if (columnParams.Count == 0) return categoryFilter;

            List<ElementFilter> elementFilters = new List<ElementFilter>();
            foreach (var param in columnParams)
            {
                // 创建一个过滤器过滤出存在参数“结构”且strongtype为int32且值为1的元素
                ElementId ruleParamId = new ElementId((int)param);
                FilterRule filteRule = ParameterFilterRuleFactory.CreateEqualsRule(ruleParamId, paramValue);
                ElementParameterFilter paramFilter = new ElementParameterFilter(filteRule);
                elementFilters.Add(paramFilter);
            }
            LogicalOrFilter orFilter = new LogicalOrFilter(elementFilters);

            elementFilter = new LogicalAndFilter(categoryFilter, orFilter);
            return elementFilter;
        }
        /// <summary>
        /// 获取选择geo对应的块参照名称
        /// </summary>
        /// <param name="geoSel">手动选择的元素部分</param>
        /// <param name="importInstance">链接CAD</param>
        /// <returns></returns>
        public static string GetSelBlockName(GeometryObject geoSel, ImportInstance importInstance)
        {
            string result = null;

            GeometryElement gee = importInstance.get_Geometry(new Options());
            foreach (var geo in gee)
            {
                // importInstance
                if (geo is GeometryInstance geometryInstance)
                {
                    Transform importTransform = geometryInstance.Transform;

                    foreach (var blockGeo in geometryInstance.GetSymbolGeometry())
                    {
                        // blockReference
                        if (blockGeo is GeometryInstance blockGeoIns)
                        {
                            Transform blockTransform1 = blockGeoIns.Transform;
                            foreach (var blockGeo2 in blockGeoIns.GetSymbolGeometry())
                            {
                                // result
                                if (blockGeo2.GetHashCode() == geoSel.GetHashCode())
                                {
                                    result = blockGeoIns.Symbol.Name;
                                    return result;
                                }
                                // subBlockReference
                                else if (blockGeo2 is GeometryInstance blockGeoIns2)
                                {
                                    Transform blockTransform2 = blockGeoIns2.Transform;
                                    foreach (var finalGeo in blockGeoIns2.GetSymbolGeometry())
                                    {
                                        // result
                                        if (finalGeo.GetHashCode() == geoSel.GetHashCode())
                                        {
                                            result = blockGeoIns2.Symbol.Name;
                                            return result;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return result;
        }
        /// <summary>
        /// 获取链接CAD中所有与指定名称匹配的块参照（GeometryInstance）的坐标点
        /// </summary>
        /// <param name="blockName">指定块参照名称</param>
        /// <param name="importInstance">链接CAD</param>
        /// <returns></returns>
        public static List<XYZ> GetSelBlockPoints(string blockName, ImportInstance importInstance)
        {
            List<XYZ> result = new List<XYZ>();

            GeometryElement gee = importInstance.get_Geometry(new Options());
            foreach (var geo in gee)
            {
                // importInstance
                if (geo is GeometryInstance geometryInstance)
                {
                    Transform importTransform = geometryInstance.Transform;

                    foreach (var blockGeo in geometryInstance.GetSymbolGeometry())
                    {
                        // blockReference
                        if (blockGeo is GeometryInstance blockGeoIns)
                        {
                            Transform blockTransform = blockGeoIns.Transform;
                            if (blockGeoIns.Symbol.Name == blockName)
                            {
                                //XYZ point = blockTransform.Multiply(importTransform).Origin;
                                XYZ point = importTransform.Multiply(blockTransform).Origin;
                                result.Add(point);
                            }
                            else
                            {
                                foreach (var blockGeo2 in blockGeoIns.GetSymbolGeometry())
                                {
                                    // subBlockReference
                                    if (blockGeo2 is GeometryInstance blockGeoIns2)
                                    {
                                        Transform subBlockTransform = blockGeoIns2.Transform;
                                        if (blockGeoIns2.Symbol.Name == blockName)
                                        {
                                            //XYZ point = subBlockTransform.Multiply(blockTransform).Multiply(importTransform).Origin;
                                            XYZ point = importTransform.Multiply(blockTransform).Multiply(subBlockTransform).Origin;
                                            result.Add(point);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return result;
        }
        public static XYZ GetPoint(Element element)
        {
            XYZ result = null;

            if (element.Location == null || !(element.Location is LocationPoint))
            {
                return result;
            }
            result = (element.Location as LocationPoint).Point;

            return result;
        }
        public static UV GetUVPoint(XYZ point, int? round = null)
        {
            double x = point.X;
            double y = point.Y;
            if (round != null)
            {
                x = Math.Round(x, (int)round);
                y = Math.Round(y, (int)round);
            }
            return new UV(x, y);
        }
        public static double GetDistanceToFloorByRay(XYZ point, View3D view3D, XYZ direction, bool findLink)
        {
            double distance = double.NaN;

            List<ElementFilter> filters = new List<ElementFilter>();
            filters.Add(new ElementCategoryFilter(BuiltInCategory.OST_Floors));
            filters.Add(new ElementCategoryFilter(BuiltInCategory.OST_Ceilings));
            filters.Add(new ElementCategoryFilter(BuiltInCategory.OST_StructuralFoundation));
            filters.Add(new ElementCategoryFilter(BuiltInCategory.OST_RvtLinks));
            LogicalOrFilter orFilter = new LogicalOrFilter(filters);

            ReferenceIntersector intersector = new ReferenceIntersector(orFilter, FindReferenceTarget.Element, view3D);
            intersector.FindReferencesInRevitLinks = findLink;
            ReferenceWithContext referenceWithContext = intersector.FindNearest(point, direction);

            if (referenceWithContext != null)
            {
                distance = referenceWithContext.GetReference().GlobalPoint.DistanceTo(point);
            }

            return distance;
        }
        #region 根据族实例实体获取族实例最低点坐标

        public static XYZ GetMinPointBySolid(Element element)
        {
            XYZ reslut = null;
            bool foundPoint = false;

            Options options = new Options();
            options.ComputeReferences = true;
            options.DetailLevel = ViewDetailLevel.Fine;
            //options.View = doc.ActiveView;

            GeometryElement geometryElement = element.get_Geometry(options);
            foreach (var geo in geometryElement)
            {
                if (geo is GeometryInstance geometryInstance)
                {
                    foreach (var geo2 in geometryInstance.GetInstanceGeometry())
                    {
                        if (geo2 is Solid solid && solid.SurfaceArea > 0)
                        {
                            XYZ solidBoxMin = solid.GetBoundingBox().Transform.OfPoint(solid.GetBoundingBox().Min);
                            UpdateLowestPoint(solidBoxMin, ref reslut, ref foundPoint);
                        }
                    }
                }
                else if (geo is Solid solid1 && solid1.SurfaceArea > 0)
                {
                    XYZ solidBoxMin = solid1.GetBoundingBox().Transform.OfPoint(solid1.GetBoundingBox().Min);
                    UpdateLowestPoint(solidBoxMin, ref reslut, ref foundPoint);
                }
            }


            return reslut;
        }
        public static XYZ GetMinPointByGeo(FamilyInstance familyInstance, View view = null)
        {
            Document doc = familyInstance.Document;

            // 1. 创建选项并设置视图细节级别
            Options geomOptions = new Options();
            if (view != null)
            {
                geomOptions.View = view; // 如果指定视图，则获取相对于该视图的几何（如剪切后的）
            }
            geomOptions.ComputeReferences = true; // 如果需要参考，可以计算
            geomOptions.DetailLevel = ViewDetailLevel.Fine; // 获取最精细的几何细节

            // 2. 获取族实例的几何元素
            GeometryElement geometryElement = familyInstance.get_Geometry(geomOptions);

            if (geometryElement == null)
                throw new InvalidOperationException("无法获取该族实例的几何图形。");

            // 3. 初始化一个非常大的点作为初始最低点，以及一个标志
            XYZ lowestPoint = null;
            bool foundPoint = false;

            // 4. 遍历几何元素中的每个对象
            foreach (GeometryObject geomObj in geometryElement)
            {
                // 4.1 处理 GeometryInstance（常见于族实例）
                if (geomObj is GeometryInstance geomInst)
                {
                    // 获取实例几何，这里已经包含了到模型坐标的转换
                    GeometryElement instGeometry = geomInst.GetInstanceGeometry();
                    Transform instTransform = geomInst.Transform; // 获取转换矩阵

                    // 遍历实例几何中的对象
                    foreach (GeometryObject instObj in instGeometry)
                    {
                        ProcessGeometryObject(instObj, instTransform, ref lowestPoint, ref foundPoint);
                    }
                }
                // 4.2 处理直接的 Solid 或其它几何对象
                else
                {
                    // 使用恒等变换，因为这些几何可能已经在模型坐标下
                    ProcessGeometryObject(geomObj, Transform.Identity, ref lowestPoint, ref foundPoint);
                }
            }

            if (!foundPoint)
                throw new InvalidOperationException("未在此族实例的几何图形中找到任何点。");

            return lowestPoint;
        }

        // 辅助方法：处理具体的几何对象（如Solid），更新最低点
        private static void ProcessGeometryObject(GeometryObject geomObj, Transform transform, ref XYZ lowestPoint, ref bool foundPoint)
        {
            if (geomObj is Solid solid)
            {
                // Solid 由面、边和顶点组成
                foreach (Face face in solid.Faces)
                {
                    Mesh mesh = face.Triangulate(); // 将面三角化
                    foreach (XYZ vertex in mesh.Vertices)
                    {
                        // 应用坐标转换：将族内的局部坐标点转换为模型坐标点
                        //XYZ pointInModelCoords = transform.OfPoint(vertex);
                        XYZ pointInModelCoords = vertex;
                        UpdateLowestPoint(pointInModelCoords, ref lowestPoint, ref foundPoint);
                    }
                }
            }
            //else if (geomObj is Curve curve)
            //{
            //    // 处理曲线，获取起点和终点
            //    ProcessPoint(curve.GetEndPoint(0), transform, ref lowestPoint, ref foundPoint);
            //    ProcessPoint(curve.GetEndPoint(1), transform, ref lowestPoint, ref foundPoint);
            //}
            //else if (geomObj is Point point)
            //{
            //    // 处理点
            //    ProcessPoint(point.Coord, transform, ref lowestPoint, ref foundPoint);
            //}
            // 可以根据需要处理 Mesh, Line, etc.
        }

        // 辅助方法：处理单个点并应用转换
        private static void ProcessPoint(XYZ point, Transform transform, ref XYZ lowestPoint, ref bool foundPoint)
        {
            XYZ transformedPoint = transform.OfPoint(point);
            UpdateLowestPoint(transformedPoint, ref lowestPoint, ref foundPoint);
        }

        // 辅助方法：更新当前找到的最低点
        private static void UpdateLowestPoint(XYZ candidatePoint, ref XYZ currentLowest, ref bool foundAny)
        {
            if (!foundAny)
            {
                currentLowest = candidatePoint;
                foundAny = true;
            }
            else
            {
                // 比较Z坐标，取更小的（Revit中Z向上，所以"最低"是Z值最小）
                if (candidatePoint.Z < currentLowest.Z)
                {
                    currentLowest = candidatePoint;
                }
            }
        }
        private static void UpdateHighestPoint(XYZ candidatePoint, ref XYZ currentHighest, ref bool foundAny)
        {
            if (!foundAny)
            {
                currentHighest = candidatePoint;
                foundAny = true;
            }
            else
            {
                // 比较Z坐标，取更小的（Revit中Z向上，所以"最低"是Z值最小）
                if (candidatePoint.Z > currentHighest.Z)
                {
                    currentHighest = candidatePoint;
                }
            }
        }

        #endregion
        public static XYZ GetMaxPointBySolid(Element element)
        {
            XYZ reslut = null;
            bool foundPoint = false;

            Options options = new Options();
            options.ComputeReferences = true;
            options.DetailLevel = ViewDetailLevel.Fine;

            GeometryElement geometryElement = element.get_Geometry(options);
            foreach (var geo in geometryElement)
            {
                if (geo is GeometryInstance geometryInstance)
                {
                    foreach (var geo2 in geometryInstance.GetInstanceGeometry())
                    {
                        if (geo2 is Solid solid && solid.SurfaceArea > 0)
                        {
                            XYZ solidBoxMin = solid.GetBoundingBox().Transform.OfPoint(solid.GetBoundingBox().Max);
                            UpdateHighestPoint(solidBoxMin, ref reslut, ref foundPoint);
                        }
                    }
                }
                else if (geo is Solid solid1 && solid1.SurfaceArea > 0)
                {
                    XYZ solidBoxMin = solid1.GetBoundingBox().Transform.OfPoint(solid1.GetBoundingBox().Max);
                    UpdateHighestPoint(solidBoxMin, ref reslut, ref foundPoint);
                }
            }


            return reslut;
        }
    }
}
