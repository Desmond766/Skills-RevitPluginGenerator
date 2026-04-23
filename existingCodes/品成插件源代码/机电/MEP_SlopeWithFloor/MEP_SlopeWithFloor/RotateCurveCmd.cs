using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI.Selection;
using System.Windows.Forms;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.DB.Electrical;

namespace MEP_SlopeWithFloor
{
    [Transaction(TransactionMode.Manual)]
    public class RotateCurveCmd : IExternalCommand
    {
        public static double Distance { get; set; }
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;

            // 判断是否存在三维视图
            //View3D view = Get3DView(doc);
            View3D view = doc.ActiveView as View3D;
            if (null == view)
            {
                message = "错误1：请在三维视图下执行程序！";
                return Result.Failed;
            }

            //弹出对话框
            using (SettingForm sf = new SettingForm())
            {
                if (DialogResult.OK != sf.ShowDialog())
                {
                    return Result.Failed;
                }
            }

            //过滤出选中的管道
            Selection selection = uiapp.ActiveUIDocument.Selection;
            var targetElements = selection.GetElementIds();
            List<Element> meps = new List<Element>();
            meps = selection.GetElementIds()
                .Select(u => doc.GetElement(u))
                .Where(u => u is MEPCurve).ToList();
            if (meps.Count == 0)
            {
                message = "错误2：请先选择管道进行偏移！";
                return Result.Cancelled;
                ////过滤出机电管线
                //FilteredElementCollector mepCollector = new FilteredElementCollector(doc, doc.ActiveView.Id);
                //meps = mepCollector.OfClass(typeof(MEPCurve)).WhereElementIsNotElementType().ToList();
            }

            

            //选择垂直坡度方向
            XYZ flatDir = XYZ.Zero;
            Reference edgeRef = selection.PickObject(ObjectType.Edge, "选择垂直坡度方向");
            Edge edge = doc.GetElement(edgeRef).GetGeometryObjectFromReference(edgeRef) as Edge;
            if (null != edge)
            {
                Curve curve = edge.AsCurve();
                flatDir = (curve as Line).Direction;
            }
            else
            {
                Curve curve = (doc.GetElement(edgeRef).Location as LocationCurve).Curve;
                flatDir = (curve as Line).Direction;
            }

            //选择待旋转的管道方向
            Reference firstRef = selection.PickObject(ObjectType.Element, "选择需要旋转的管道方向");
            Curve firstCurve = (doc.GetElement(firstRef).Location as LocationCurve).Curve;
            XYZ firstDir = (firstCurve as Line).Direction;
            //Element firstElem = meps[0];
            //MEPCurve firstMEP = firstElem as MEPCurve;
            //Curve firstCurve = (firstMEP.Location as LocationCurve).Curve;
            //XYZ firstDir = (firstCurve as Line).Direction;

            using (Transaction trans = new Transaction(doc, "SlopeWithFloor2"))
            {
                trans.Start();

                if (firstDir.IsAlmostEqualTo(XYZ.BasisZ) ||
                    firstDir.IsAlmostEqualTo(XYZ.BasisZ.Negate()))
                {
                    //排除垂直管道
                    message = "错误3：不支持垂直管道！";
                    return Result.Cancelled;
                }
                if (firstDir.IsAlmostEqualTo(flatDir)
                    || firstDir.IsAlmostEqualTo(flatDir.Negate()))
                {
                    //平行于坡道
                }
                else
                {
                    double d1 = GetDistance(view, firstCurve.GetEndPoint(0), XYZ.BasisZ);
                    double d2 = GetDistance(view, firstCurve.GetEndPoint(1), XYZ.BasisZ);
                    XYZ slabDir = (firstCurve.GetEndPoint(1) + XYZ.BasisZ * d2
                        - (firstCurve.GetEndPoint(0) + XYZ.BasisZ * d1)).Normalize();
                    XYZ axisXYZ = firstDir.CrossProduct(XYZ.BasisZ);
                    Line axisLine = Line.CreateBound(firstCurve.GetEndPoint(0), firstCurve.GetEndPoint(0) + axisXYZ);
                    //试旋转
                    Transform rotate = Transform.CreateRotation(axisXYZ, slabDir.AngleTo(firstDir));
                    if (rotate.OfVector(firstDir).IsAlmostEqualTo(slabDir))
                    {
                        ElementTransformUtils.RotateElements(doc, targetElements, axisLine, slabDir.AngleTo(firstDir));
                    }
                    else
                    {
                        ElementTransformUtils.RotateElements(doc, targetElements, axisLine, -slabDir.AngleTo(firstDir));
                    }
                    ElementTransformUtils.MoveElements(doc, targetElements, XYZ.BasisZ * (d1 - Distance));

                }
                trans.Commit();
            }

            return Result.Succeeded;
        }

        #region 指定一个点及方向，返回该点到板的距离
        /// <summary>
        /// 指定一个点及方向，返回该点到板的距离
        /// </summary>
        /// <param name="view">当前文档</param>
        /// <param name="point">指定点</param>
        /// <param name="direction">指定方向</param>
        /// <returns>点到板的距离</returns>
        private double GetDistance(View3D view, XYZ point, XYZ direction)
        {
            List<ElementFilter> filterList = new List<ElementFilter>();
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_Floors));
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_Ceilings));
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_StructuralFoundation));
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_RvtLinks));
            LogicalOrFilter floorOrCeiling = new LogicalOrFilter(filterList);
            ReferenceIntersector referenceIntersector = new ReferenceIntersector(floorOrCeiling, FindReferenceTarget.All, view);
            //此处存在BUG，仅仅将RvtLink当做一类构件进行判断，而不是进入RvtLink去判断文件中的各个类
            //详见Using ReferenceIntersector in Linked Files
            //http://thebuildingcoder.typepad.com/blog/2015/07/using-referenceintersector-in-linked-files.html
            referenceIntersector.FindReferencesInRevitLinks = true;
            ReferenceWithContext referenceWithContext = referenceIntersector.FindNearest(point, direction);
            if (null == referenceWithContext)
            {
                return -1.0;
            }
            return point.DistanceTo(referenceWithContext.GetReference().GlobalPoint);
        }
        #endregion
    }
}
