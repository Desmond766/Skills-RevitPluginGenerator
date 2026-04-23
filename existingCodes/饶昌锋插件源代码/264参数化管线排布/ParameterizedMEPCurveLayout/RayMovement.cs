using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Plumbing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ParameterizedMEPCurveLayout
{
    /// <summary>
    /// 射线调整到结构柱的距离
    /// </summary>
    public class RayMovement
    {
        public static void SelectLinkPost(Document doc, double inputInterval, IList<MEPCurve> mEPCurves)
        {
            View3D view3D = null;
            FilteredElementCollector viewCollector = new FilteredElementCollector(doc).OfClass(typeof(View3D));
            foreach (Element element in viewCollector)
            {
                View3D view3 = element as View3D;

                if (view3.Name.Equals("3D 支吊架"))
                {
                    // 将获取到的3D视图添加到列表中
                    view3D = view3;
                }
            }
            XYZ direction;
            if (Tools.IsHorizontal(mEPCurves.First()))
            {
                mEPCurves = mEPCurves.OrderByDescending(x => Tools.GetMEPCurveCentrePoint(x).Y).ToList();
                direction = XYZ.BasisY;
            }
            else
            {
                mEPCurves = mEPCurves.OrderBy(x => Tools.GetMEPCurveCentrePoint(x).X).ToList();
                direction = -XYZ.BasisX;
            }

            XYZ centerPoint = Tools.GetMEPCurveCentrePoint(mEPCurves.First());

            // 创建一条射线，方向为Y轴方向

            // 进行射线检测，获取第一个与射线相交的结构柱元素
            ElementCategoryFilter filter = new ElementCategoryFilter(BuiltInCategory.OST_StructuralColumns);
            // 使用ReferenceIntersector进行射线与模型元素的交互检测
            ReferenceIntersector referenceIntersector = new ReferenceIntersector(filter, FindReferenceTarget.Face, view3D);
            referenceIntersector.FindReferencesInRevitLinks = true;
            ReferenceWithContext referenceWithContext = referenceIntersector.FindNearest(centerPoint, direction);
            double interval = 0;

            if (referenceWithContext != null)
            {
                interval = referenceWithContext.Proximity;

                XYZ offset;
                if (Tools.IsHorizontal(mEPCurves.First()))
                {
                    offset = new XYZ(0, interval - inputInterval / 304.8 - mEPCurves.First().ParameterWidth(), 0);
                }
                else
                {
                    offset = new XYZ(-(interval - inputInterval / 304.8 - mEPCurves.First().ParameterWidth()), 0, 0);
                }
                foreach (MEPCurve mEP in mEPCurves)
                {
                    Tools.MoveMEPCurve(doc, mEP, Tools.GetMEPCurveCentrePoint(mEP) + offset);
                }
            }

        }
    }
}
