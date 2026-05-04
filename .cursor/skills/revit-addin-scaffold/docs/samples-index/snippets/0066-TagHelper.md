# Sample Snippet: TagHelper

Source project: `existingCodes\品成插件源代码\机电\TagHelper\TagHelper`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.DB.Plumbing;

namespace TagHelper
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;

            //【1】判断视图————————————————————————————————————————————————————————————————————————————————————————————————————————————————
            if (!(doc.ActiveView is ViewPlan))
            {
                TaskDialog.Show("Revit", "请在平面视图中运行插件！");
                return Result.Cancelled;
            }
            View view = doc.ActiveView;

            //【2】选择三点————————————————————————————————————————————————————————————————————————————————————————————————————————————————
            XYZ pt1 = XYZ.Zero;
            XYZ pt2 = XYZ.Zero;
            XYZ pt3 = XYZ.Zero;
            try
            {
                pt1 = sel.PickPoint();
                pt2 = sel.PickPoint();
                pt3 = sel.PickPoint();
            }
            catch
            {
                TaskDialog.Show("Revit", "取消选择，程序结束！");
                return Result.Cancelled;
            }

            //根据三点创建拉伸Solid
            Solid solid = null;
            try
            {
                XYZ pt4 = pt2 + (pt3 - pt2).Normalize() * 10/304.8;

                Curve c1 = Line.CreateBound(pt1, pt2);
                Curve c2 = Line.CreateBound(pt2, pt4);
                Curve c3 = Line.CreateBound(pt4, pt1);
                List<Curve> curveList = new List<Curve>() { c1, c2, c3 };
                CurveLoop curveLoop = CurveLoop.Create(curveList);
                List<CurveLoop> curveLoopList = new List<CurveLoop>() { curveLoop };
                //向上拉伸5000
                solid = GeometryCreationUtilities.CreateExtrusionGeometry(curveLoopList, XYZ.BasisZ, 5000.0/ 304.8);
            }
            catch
            {
                TaskDialog.Show("Revit", "不合法的三个点，无法形成三角形，请重新选择！");
                return Result.Cancelled;
            }

            //【3】根据创建的solid查找管线（水管）————————————————————————————————————————————————————————————————————————————————————————————————————————————————
            ElementIntersectsSolidFilter filter = new ElementIntersectsSolidFilter(solid);
            FilteredElementCollector collector = new FilteredElementCollector(doc, doc.ActiveView.Id);
            collector.WherePasses(filter).OfClass(typeof(Pipe));
            if (collector.Count() == 0)
            {
                TaskDialog.Show("Revit", "未找到要标注的管线！\n注意：插件仅寻找当前标高以下的管线！");
                return Result.Cancelled;
            }

            //【4】管线方向向量，判断管线是否平行————————————————————————————————————————————————————————————————————————————————————————————————————————————————
            Curve mepCurve = ((collector.First() as MEPCurve).Location as LocationCurve).Curve;
            if (!(mepCurve is Line))
            {
                TaskDialog.Show("Revit", "仅支持直线管线！");
                return Result.Cancelled;
            }
            Line mepLine = mepCurve as Line;
            XYZ mepDirection = mepLine.Direction;

            //判断管线方向是否一致
            
            //XYZ firstDirection = mepDirection;
            //bool isSameDirection = false;
            //foreach (ElementId id in collector.ToElementIds())
// ... truncated ...
```

## Utils.cs

```csharp
using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace TagHelper
{
    class Utils
    {

        #region 根据族名称找族
        /// <summary>
        /// 根据族名称找族
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="familyName"></param>
        /// <returns></returns>
        public static Family FindFamilyByName(Document doc, string familyName)
        {
            var collector = new FilteredElementCollector(doc);
            var ids = collector.OfClass(typeof(Family)).ToElementIds();
            foreach (var id in ids)
            {
                if (doc.GetElement(id).Name == familyName)
                {
                    return doc.GetElement(id) as Family;
                }
            }
            return null;
        }
        #endregion


        #region 根据族名称找族下某类型名称ID

        public static ElementId FindTypeIdByFamilyName(Document doc,string familyName)
        {
            Family family = FindFamilyByName(doc, familyName);
            ISet<ElementId> iSetFamily = family.GetFamilySymbolIds();
            List<ElementId> listFamily = new List<ElementId>();
            foreach (var item in iSetFamily)
            {
                listFamily.Add(item);
            }
            ElementId elementId = listFamily[0];
            return elementId;

        }

        #endregion

        #region 获得点在直线上的投影点坐标
        /// <summary>
        /// 获得点在直线上的投影点坐标
        /// </summary>
        /// <param name="p1">直线起点</param>
        /// <param name="p2">直线终点</param>
        /// <param name="q">直线外的点</param>
        /// <returns>投影点</returns>
        public static XYZ GetProjectivePoint(XYZ p1, XYZ p2, XYZ q)
        {
            XYZ u = p2 - p1;
            XYZ pq = q - p1;
            XYZ w2 = pq - u.Multiply(pq.DotProduct(u) / (u.GetLength() * u.GetLength()));
            XYZ point = q - w2;
            return point;
        }

        /// <summary>
        /// 获得点在直线上的投影点坐标
        /// </summary>
        /// <param name="l">直线</param>
        /// <param name="q">直线外的点</param>
        /// <returns>投影点</returns>
        public static XYZ GetProjectivePoint(Line l, XYZ q)
        {
            XYZ u = l.Direction;
            XYZ pq = q - l.GetEndPoint(0);
            XYZ w2 = pq - u.Multiply(pq.DotProduct(u) / (u.GetLength() * u.GetLength()));
            XYZ point = q - w2;
            return point;
        }

        #endregion
    }
}

```

