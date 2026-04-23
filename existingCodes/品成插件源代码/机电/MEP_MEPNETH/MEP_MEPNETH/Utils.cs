using System;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEP_MEPNETH
{
    class Utils
    {
        #region 获得管线净高 考虑高低板
        public static double GetClearHeight(View3D view, Document doc, XYZ point_Do)
        {
            double distance = 0.0;
            //梁的计算点point_Do 

            List<ElementFilter> filterList = new List<ElementFilter>();
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_Floors));
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_Ceilings));
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_StructuralFoundation));
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_RvtLinks));

            LogicalOrFilter floorOrCeiling = new LogicalOrFilter(filterList);


            //相交
            ReferenceIntersector referenceIntersector = new ReferenceIntersector(floorOrCeiling, FindReferenceTarget.All, view);
            referenceIntersector.FindReferencesInRevitLinks = true;

            ReferenceWithContext referenceWithContext = referenceIntersector.FindNearest(point_Do, XYZ.BasisZ.Negate());



            Reference r2 = referenceWithContext.GetReference();

            if (null != r2)
            {
                List<ElementFilter> filterList1 = new List<ElementFilter>();
                filterList1.Add(new ElementCategoryFilter(BuiltInCategory.OST_DuctCurves));
                filterList1.Add(new ElementCategoryFilter(BuiltInCategory.OST_CableTray));
                filterList1.Add(new ElementCategoryFilter(BuiltInCategory.OST_PipeCurves));
                LogicalOrFilter structuralFraming = new LogicalOrFilter(filterList1);
                //相交
                ReferenceIntersector referenceIntersector1 = new ReferenceIntersector(structuralFraming, FindReferenceTarget.All, view);
                referenceIntersector1.FindReferencesInRevitLinks = true;

                ReferenceWithContext referenceWithContext1 = referenceIntersector1.FindNearest(r2.GlobalPoint, XYZ.BasisZ);
                Reference r3 = referenceWithContext1.GetReference();
                distance = r3.GlobalPoint.DistanceTo(r2.GlobalPoint) * 304.8;
            }
            else
            {
                TaskDialog.Show("报错原因", "放射方法r2为空");
            }
            return Math.Round(distance, 0);

        }
        #endregion


        #region 得到Z 小的点

        public static XYZ GetMinZPoint(XYZ point1, XYZ point2)
        {
            double d = point1.Z - point2.Z;
            if (d > 0)
            {
                return point2;
            }
            else
            {
                return point1;
            }


        }
        #endregion


    }
}
