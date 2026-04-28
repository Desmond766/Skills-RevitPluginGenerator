using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI.Selection;
using System.Windows.Forms;

namespace PipeSetSlopeWithTerrian
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        bool _autoMode = false;
        double _offset = 500 / 304.8;

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;

            //过滤出管道
            List<MEPCurve> meps = new List<MEPCurve>();
            foreach (var item in sel.GetElementIds())
            {
                Element elem = doc.GetElement(item);
                if (elem is MEPCurve)
                {
                    meps.Add(elem as MEPCurve);
                }
            }
            if (meps.Count == 0)
            {
                message = "请先选择管道再运行插件";
                return Result.Cancelled;
            }

            //弹出对话框
            SettingForm sf = new SettingForm();
            if (DialogResult.OK != sf.ShowDialog())
            {
                return Result.Cancelled;
            }
            _autoMode = sf._autoMode;
            _offset = sf._offset;

            //起点集合终点集合
            List<XYZ> startPoints = new List<XYZ>();
            List<XYZ> endPoints = new List<XYZ>();

            if (!_autoMode)
            {
                //手动指定模式，指定要往下偏移的一侧
                XYZ pickPoint = sel.PickObject(ObjectType.Element).GlobalPoint;
                SeparateEndPoint(meps, pickPoint, ref startPoints, ref endPoints);
                using (Transaction tran = new Transaction(doc, "slopePipeSet_CustomMode"))
                {
                    tran.Start();
                    for (int i = 0; i < meps.Count; i++)
                    {
                        MEPHelper.Create(doc, meps[i],
                            startPoints[i] + XYZ.BasisZ.Negate() * _offset,
                            endPoints[i]);
                    }
                    tran.Commit();
                }
                return Result.Succeeded;
            }

            //找到最高的管道
            double highest = -10000.0;
            MEPCurve topCurve = null;
            XYZ startPoint = null;
            foreach (var mep in meps)
            {
                XYZ pt = (mep.Location as LocationCurve).Curve.GetEndPoint(0);

                //加上范围框的高度/2
                BoundingBoxXYZ bbox = mep.get_BoundingBox(doc.ActiveView);
                double halfTickness = (bbox.Max.Z - bbox.Min.Z) / 2.0;

                if (pt.Z + halfTickness > highest)
                {
                    highest = pt.Z + halfTickness;
                    topCurve = mep;
                    startPoint = pt + XYZ.BasisZ * halfTickness;
                }
            }
            //终点
            XYZ endPoint = (topCurve.Location as LocationCurve).Curve.GetEndPoint(1);
            endPoint = new XYZ(endPoint.X, endPoint.Y, startPoint.Z);//加上范围框的高度/2

            //根据起点终点分为两组
            SeparateEndPoint(meps, startPoint, ref startPoints, ref endPoints);

            //最高点向下反射
            XYZ reflectStartPoint = GetReflectPoint(doc.ActiveView as View3D, startPoint, XYZ.BasisZ.Negate());
            double startOffset = 0.0;
            if (null != reflectStartPoint)
            {
                startOffset = reflectStartPoint.DistanceTo(startPoint);
            }
            XYZ reflectEndPoint = GetReflectPoint(doc.ActiveView as View3D, endPoint, XYZ.BasisZ.Negate());
            double endOffset = 0.0;
            if (null != reflectEndPoint)
            {
                endOffset = reflectEndPoint.DistanceTo(endPoint);
            }

            
            //没必要偏移
            if (startOffset == 0.0 && endOffset == 0.0)
            {
                message = "没找到投影下的板！";
                return Result.Cancelled;
            }
            //相当于平移下来
            if (startOffset == 0.0)
            {
                startOffset = endOffset;
            }
            if (endOffset == 0.0)
            {
                endOffset = startOffset;
            }
            //加上自定义_offset
            startOffset += _offset;
            endOffset += _offset;

            //重新生成管道
            using (Transaction tran = new Transaction(doc, "slopePipeSet_AutoMode"))
            {
                tran.Start();
                for (int i = 0; i < meps.Count; i++)
                {
                    MEPHelper.Create(doc,meps[i],
                        startPoints[i] + XYZ.BasisZ.Negate() * startOffset,
                        endPoints[i] + XYZ.BasisZ.Negate() * endOffset);
                }
                tran.Commit();
            }

            return Result.Succeeded;
        }

        #region 指定一个点及方向，返回反射点
        /// <summary>
        /// 指定一个点及方向，返回反射点
        /// </summary>
        /// <param name="view">当前文档</param>
        /// <param name="point">指定点</param>
        /// <param name="direction">指定方向</param>
        /// <returns>反射点</returns>
        private XYZ GetReflectPoint(View3D view, XYZ point, XYZ direction)
        {
            XYZ offsetPoint = point + direction.Normalize() * 0.00001;

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
            ReferenceWithContext referenceWithContext = referenceIntersector.FindNearest(offsetPoint, direction);
            return null == referenceWithContext ? null : referenceWithContext.GetReference().GlobalPoint;
        }
        #endregion

        #region 根据指定点将管线起点终点分为两组
        private void SeparateEndPoint(
            List<MEPCurve> meps,
            XYZ point,
            ref List<XYZ> startPoints,
            ref List<XYZ> endPoints)
        {
            startPoints = new List<XYZ>();
            endPoints = new List<XYZ>();
            foreach (var mep in meps)
            {
                Curve curve = (mep.Location as LocationCurve).Curve;
                XYZ pt0 = curve.GetEndPoint(0);
                XYZ pt1 = curve.GetEndPoint(1);
                if (point.DistanceTo(pt0) < point.DistanceTo(pt1))
                {
                    startPoints.Add(pt0);
                    endPoints.Add(pt1);
                }
                else
                {
                    startPoints.Add(pt1);
                    endPoints.Add(pt0);
                }
            }
        }
        #endregion

    }
}
