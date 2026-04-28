using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitUtils
{
    public static class ElementUtils
    {
        /// <summary>
        /// 根据ID获取元素
        /// </summary>
        /// <param name="elementId"></param>
        /// <param name="doc"></param>
        /// <returns></returns>
        public static Element GetElement(this ElementId elementId, Document doc)
        {
            return doc.GetElement(elementId);
        }
        /// <summary>
        /// 根据引用获取元素
        /// </summary>
        /// <param name="reference"></param>
        /// <param name="doc"></param>
        /// <returns></returns>
        public static Element GetElement(this Reference reference, Document doc)
        {
            return doc.GetElement(reference);
        }
        /// <summary>
        /// 获取链接模型中的元素
        /// </summary>
        /// <param name="reference">链接模型中元素上的一点</param>
        /// <param name="doc"></param>
        /// <returns></returns>
        public static Element GetLinkElement(this Reference reference, Document doc)
        {
            Element linkElem = null;
            Element elem = doc.GetElement(reference);
            if (elem is RevitLinkInstance linkInstance)
            {
                Document linkDoc = linkInstance.GetLinkDocument();
                linkElem = linkDoc.GetElement(reference.LinkedElementId);
            }

            return linkElem;
        }

        /// <summary>
        /// 获取灯具的宿主元素
        /// </summary>
        /// <param name="element"></param>
        /// <param name="doc"></param>
        /// <param name="zDir"></param>
        /// <param name="findHeight"></param>
        /// <returns></returns>
        public static Element GetHostElement(this Element element, Document doc, XYZ zDir, double findHeight)
        {
            Element hostElem = null;

            var boundingBox = element.get_BoundingBox(null);
            XYZ min = boundingBox.Min;
            XYZ max = boundingBox.Max;
            Outline outline = new Outline(min, new XYZ(max.X, max.Y, max.Z + findHeight));

            XYZ cp = element.GetCreatePoint();
            Solid solid = SolidUtils.CreateSolid(XYZ.BasisX, cp, 50 / 304.8, 50 / 304.8, zDir, findHeight);

            List<Element> lightCables = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_CableTray).OfClass(typeof(CableTray)).WherePasses(new BoundingBoxIntersectsFilter(outline))
                .WherePasses(new ElementIntersectsSolidFilter(solid)).ToList();
            lightCables = lightCables.OrderBy(x => x.GetLine().Project(cp).XYZPoint.DistanceTo(cp)).ToList();
            hostElem = lightCables.FirstOrDefault();
            return hostElem;
        }
    }
}
