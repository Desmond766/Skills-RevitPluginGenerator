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

namespace BeamColorInLink
{
    class Utils
    {

        #region 获得梁底净高 考虑高低板
        public static double GetBeamClearHeight(Document doc, FamilyInstance f)
        {

            LocationCurve beamLocationCurve = f.Location as LocationCurve;
            Line beamLine = beamLocationCurve.Curve as Line;
            XYZ point1 = beamLine.GetEndPoint(0);
            XYZ point2 = beamLine.GetEndPoint(1);
            //梁的计算点point_Do 
            XYZ point_Up = new XYZ((point1.X + point2.X) / 2, (point1.Y + point2.Y) / 2, (point1.Z + point2.Z) / 2);
            BoundingBoxXYZ beamBoundingBox = f.get_BoundingBox(doc.ActiveView);
            XYZ point = new XYZ(point_Up.X, point_Up.Y, (beamBoundingBox.Min).Z);
            XYZ point_Do = new XYZ(point_Up.X, point_Up.Y, point.Z - (1000 / 304.8));//减1000是为了防止梁交叉位置刚好是梁中点时，向下反射找到交叉的梁


            List<ElementFilter> filterList = new List<ElementFilter>();
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_Floors));
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_Ceilings));
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_StructuralFoundation));
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_RvtLinks));

            LogicalOrFilter floorOrCeiling = new LogicalOrFilter(filterList);

            View3D view = doc.ActiveView as View3D;
            //相交
            ReferenceIntersector referenceIntersector = new ReferenceIntersector(floorOrCeiling, FindReferenceTarget.All, view);
            referenceIntersector.FindReferencesInRevitLinks = true;

            ReferenceWithContext referenceWithContext = referenceIntersector.FindNearest(point_Do, XYZ.BasisZ.Negate());
            double distance = 0.0;

            Reference r2 = referenceWithContext.GetReference();

            if (null != r2)
            {
                List<ElementFilter> filterList1 = new List<ElementFilter>();
                filterList1.Add(new ElementCategoryFilter(BuiltInCategory.OST_StructuralFraming));
                LogicalOrFilter structuralFraming = new LogicalOrFilter(filterList1);
                //相交
                ReferenceIntersector referenceIntersector1 = new ReferenceIntersector(structuralFraming, FindReferenceTarget.All, view);
                referenceIntersector1.FindReferencesInRevitLinks = true;

                ReferenceWithContext referenceWithContext1 = referenceIntersector1.FindNearest(r2.GlobalPoint, XYZ.BasisZ);
                Reference r3 = referenceWithContext1.GetReference();
                distance = r3.GlobalPoint.DistanceTo(r2.GlobalPoint) * 304.8;

            }
            return Math.Round(distance, 0);

        }
        #endregion

        #region 获得梁底净高 考虑高低板（304）
        //public static double GetBeamClearHeight(Document doc, FamilyInstance f)
        //{

        //    LocationCurve beamLocationCurve = f.Location as LocationCurve;
        //    Line beamLine = beamLocationCurve.Curve as Line;
        //    XYZ point1 = beamLine.GetEndPoint(0);
        //    XYZ point2 = beamLine.GetEndPoint(1);
        //    //梁的中点
        //    XYZ point = new XYZ((point1.X + point2.X) / 2, (point1.Y + point2.Y) / 2, (point1.Z + point2.Z) / 2);


        //    List<ElementFilter> filterList = new List<ElementFilter>();
        //    filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_Floors));
        //    filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_Ceilings));
        //    filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_StructuralFoundation));
        //    filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_RvtLinks));

        //    LogicalOrFilter floorOrCeiling = new LogicalOrFilter(filterList);

        //    View3D view = doc.ActiveView as View3D;
        //    //相交
        //    ReferenceIntersector referenceIntersector = new ReferenceIntersector(floorOrCeiling, FindReferenceTarget.All, view);
        //    referenceIntersector.FindReferencesInRevitLinks = true;

        //    ReferenceWithContext referenceWithContext = referenceIntersector.FindNearest(point, XYZ.BasisZ.Negate());
        //    Reference r2 = referenceWithContext.GetReference();

        //    double h = 0.0;
        //    foreach (Parameter p in f.Symbol.Parameters)
        //    {
        //        if (p.Definition.Name == "h")
        //        {
        //            h = double.Parse(p.AsValueString());
        //            break;
        //        }
        //    }
        //    double h1 = 0.0;
        //    double h2 = 0.0;
        //    foreach (Parameter p in f.Parameters)
        //    {
        //        if (p.Definition.Name == "Z 轴偏移值")
        //        {
        //            h1 = double.Parse(p.AsValueString());
        //        }
        //        if (p.Definition.Name == "Z 轴对正")
        //        {
        //            if (p.AsValueString() == "顶")
        //            {
        //                h2 = h;
        //            }
        //            else if (p.AsValueString() == "底")
        //            {
        //                h2 = 0.0;
        //            }
        //            else
        //            {
        //                h2 = h / 2;
        //            }
        //        }
        //    }
        //    double distance = r2.GlobalPoint.DistanceTo(point) * 304.8 + h1 - h2;
        //    return Math.Round(distance, 0);

        //}
        #endregion

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

        #region 点所在平面
        /// <summary>
        /// 点所在平面
        /// </summary>
        /// <param name="point"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        public static Autodesk.Revit.DB.Plane ToPlane(XYZ point, XYZ other)
        {
            var v = other - point;
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
        #endregion
    }
}

