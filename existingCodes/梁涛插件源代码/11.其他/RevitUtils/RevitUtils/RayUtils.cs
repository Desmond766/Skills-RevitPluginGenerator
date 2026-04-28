using Autodesk.Revit.DB;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitUtils
{
    public class RayUtils
    {
        /// <summary>
        /// 射线法获取元素
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="view3D">进行射线的三维视图</param>
        /// <param name="rayPoint">射线起始点</param>
        /// <param name="rayDirection">射线方向</param>
        /// <param name="builtInCategories">寻找的类别</param>
        /// <param name="findLink">是否寻找链接中的元素</param>
        /// <param name="linkTransform">若元素为链接中元素返回链接模型的transform</param>
        /// <returns>通过找到的元素（默认值为null）</returns>
        public static Element GetElementByRay(Document doc, View3D view3D, XYZ rayPoint, XYZ rayDirection, List<BuiltInCategory> builtInCategories, bool findLink, out Transform linkTransform)
        {
            Element element = null;
            linkTransform = null;

            //ElementMulticategoryFilter multicategoryFilter = new ElementMulticategoryFilter(builtInCategories);

            //var intersector = new ReferenceIntersector(multicategoryFilter, FindReferenceTarget.Element, view3D);
            //intersector.FindReferencesInRevitLinks = findLink; // 是否寻找链接中的元素
            //var rw = intersector.FindNearest(rayPoint, rayDirection);
            Reference reference = GetReferenceByRay(view3D, rayPoint, rayDirection, builtInCategories, findLink);
            if (reference != null)
            {
                //var reference = rw.GetReference();
                var elem = doc.GetElement(reference);
                if (elem is RevitLinkInstance linkInstance)
                {
                    linkTransform = linkInstance.GetTransform();
                    Document linkDoc = linkInstance.GetLinkDocument();
                    element = linkDoc.GetElement(reference.LinkedElementId);
                }
                else
                {
                    element = elem;
                }
            }

            return element;
        }
        /// <summary>
        /// 射线获取指定类型元素的引用
        /// </summary>
        /// <param name="view3D">三维视图</param>
        /// <param name="rayPoint">射线起始点</param>
        /// <param name="rayDirection">射线方向</param>
        /// <param name="builtInCategories">过滤的元素类型集合</param>
        /// <param name="findLink">是否寻找链接模型中的元素</param>
        /// <returns>元素的引用（默认值为null）</returns>
        public static Reference GetReferenceByRay(View3D view3D, XYZ rayPoint, XYZ rayDirection, List<BuiltInCategory> builtInCategories, bool findLink, FindReferenceTarget target = FindReferenceTarget.Element)
        {

            ElementMulticategoryFilter multicategoryFilter = new ElementMulticategoryFilter(builtInCategories);

            var intersector = new ReferenceIntersector(multicategoryFilter, target, view3D);
            intersector.FindReferencesInRevitLinks = findLink; // 是否寻找链接中的元素
            var rw = intersector.FindNearest(rayPoint, rayDirection);
            if (rw != null) return rw.GetReference();
            return null;
        }
        /// <summary>
        /// 射线获取坐标点到指定类型元素的距离
        /// </summary>
        /// <param name="view3D">三维视图</param>
        /// <param name="rayPoint">射线起始点</param>
        /// <param name="rayDirection">射线方向</param>
        /// <param name="builtInCategories">过滤的元素类型集合</param>
        /// <param name="findLink">是否寻找链接模型中的元素</param>
        /// <returns>距离（默认值为-1）</returns>
        public static double GetDistanceByRay(View3D view3D, XYZ rayPoint, XYZ rayDirection, List<BuiltInCategory> builtInCategories, bool findLink, FindReferenceTarget target = FindReferenceTarget.Element)
        {
            Reference reference = GetReferenceByRay(view3D, rayPoint, rayDirection, builtInCategories, findLink, target);
            if (reference == null) return -1;
            return reference.GlobalPoint.DistanceTo(rayPoint);
        }
        /// <summary>
        /// 射线获取坐标点到指定元素集合的最近距离
        /// </summary>
        /// <param name="point">射线起始点</param>
        /// <param name="findIds">元素集合</param>
        /// <param name="view3D">三维视图</param>
        /// <param name="direction">射线方向</param>
        /// <param name="findLink">是否寻找链接模型中的元素</param>
        /// <returns>距离(若未找到返回double.NaN)</returns>
        public static double GetDistanceByRay(XYZ point, List<ElementId> findIds, View3D view3D, XYZ direction, bool findLink, FindReferenceTarget target = FindReferenceTarget.Element)
        {
            double dis = double.NaN;

            ReferenceIntersector intersector = new ReferenceIntersector(findIds, target, view3D);
            intersector.FindReferencesInRevitLinks = findLink;
            var rw = intersector.FindNearest(point, direction);
            if (rw != null)
            {
                dis = rw.GetReference().GlobalPoint.DistanceTo(point);
            }
            return dis;
        }
        /// <summary>
        /// 射线获取起始点到符合指定过滤器最近的元素的距离
        /// </summary>
        /// <param name="point">射线起始点</param>
        /// <param name="elementFilter">过滤器</param>
        /// <param name="view3D">三维视图</param>
        /// <param name="direction">射线方向</param>
        /// <param name="findLink">是否寻找链接模型中的元素</param>
        /// <returns>距离(若未找到返回double.NaN)</returns>
        public static double GetDistanceByRay(XYZ point, ElementFilter elementFilter, View3D view3D, XYZ direction, bool findLink, FindReferenceTarget target = FindReferenceTarget.Element)
        {
            double dis = double.NaN;

            ReferenceIntersector intersector = new ReferenceIntersector(elementFilter, target, view3D);
            intersector.FindReferencesInRevitLinks = findLink;
            var rw = intersector.FindNearest(point, direction);
            if (rw != null)
            {
                dis = rw.GetReference().GlobalPoint.DistanceTo(point);

            }
            return dis;
        }
    }
}
