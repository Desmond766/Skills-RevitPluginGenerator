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
    public class Command : IExternalCommand
    {
        public static double Distance { get; set; }
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            #region 判断加密
            //        //注册验证
            //        string licFile = string.Format("{0}\\Key.lic",
            //System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
            //        if (!BTAddInHelper.Utils.CheckReg(licFile))
            //        {
            //            return Result.Cancelled;
            //        }
            #endregion

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
            //插件运行前先选择机电管线（可框选，插件会过滤处机电管线）
            //否则搜索当前视图中可见的机电管线
            Selection selection = uiapp.ActiveUIDocument.Selection;
            List<Element> meps = new List<Element>();
            meps = selection.GetElementIds()
                .Select(u => doc.GetElement(u))
                .Where(u => u is MEPCurve).ToList();
            if (meps.Count == 0)
            {
                //过滤出机电管线
                FilteredElementCollector mepCollector = new FilteredElementCollector(doc, doc.ActiveView.Id);
                meps = mepCollector.OfClass(typeof(MEPCurve)).WhereElementIsNotElementType().ToList();
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

            //收集起点、终点连接件最后删掉
            List<ElementId> fittingIdList = new List<ElementId>();
            using (Transaction trans = new Transaction(doc, "SlopeWithFloor"))
            {
                trans.Start();
                foreach (var elem in meps)
                {
                    MEPCurve mepCurve = elem as MEPCurve;
                    // 起点、终点连接件
                    List<ElementId> connToIdList = Utils.FindConnectedToList(mepCurve).Select(u => u.Id).ToList();
                    fittingIdList.AddRange(connToIdList);
                    //doc.Delete(connToIdList);

                    Curve cur = (mepCurve.Location as LocationCurve).Curve;
                    XYZ mepDir = (cur as Line).Direction;

                    //排除垂直管道
                    if (mepDir.IsAlmostEqualTo(XYZ.BasisZ) ||
                        mepDir.IsAlmostEqualTo(XYZ.BasisZ.Negate()))
                    {
                        continue;
                    }
                    //延伸管道至配件中心
                    Curve extendCurve = GetExtendCurve(mepCurve);
                    if (mepDir.IsAlmostEqualTo(flatDir)
                        || mepDir.IsAlmostEqualTo(flatDir.Negate()))
                    {
                        
                        //整体偏移
                        double disToFloor = GetDistance(view, extendCurve.GetEndPoint(0), XYZ.BasisZ);
                        if (disToFloor != -1.0)
                        {
                            XYZ pt1 = extendCurve.GetEndPoint(0) + XYZ.BasisZ * (disToFloor - Distance);
                            XYZ pt2 = extendCurve.GetEndPoint(1) + XYZ.BasisZ * (disToFloor - Distance);
                            MEPOffset(doc, mepCurve, pt1, pt2);
                        }
                    }
                    else
                    {
                        //两点偏移
                        double dis1 = GetDistance(view, extendCurve.GetEndPoint(0), XYZ.BasisZ);
                        double dis2 = GetDistance(view, extendCurve.GetEndPoint(1), XYZ.BasisZ);
                        if (dis1 != -1.0 && dis2 != -1.0)
                        {
                            XYZ pt1 = extendCurve.GetEndPoint(0) + XYZ.BasisZ * (dis1 - Distance);
                            XYZ pt2 = extendCurve.GetEndPoint(1) + XYZ.BasisZ * (dis2 - Distance);
                            MEPOffset(doc, mepCurve, pt1, pt2);
                        }
                    }
                }
                doc.Delete(fittingIdList);
                trans.Commit();
            }

            return Result.Succeeded;
        }

        #region 获得三维视图
        /// <summary>
        /// 获得三维视图
        /// </summary>
        /// <param name="doc">当前文档</param>
        /// <returns>三维视图</returns>
        public View3D Get3DView(Document doc)
        {
            View3D view = null;
            List<Element> list = new List<Element>();
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            list.AddRange(collector.OfClass(typeof(View3D)).ToElements());
            foreach (Autodesk.Revit.DB.View3D v in list)
            {
                if (v != null && !v.IsTemplate && v.Name == "{三维}")
                {
                    view = v as View3D;
                    break;
                }
            }
            return view;
        }
        #endregion

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

        private void MEPOffset(Document doc, MEPCurve mepCurve, XYZ pt1, XYZ pt2)
        {
            // 原始属性
            Parameter parameter = mepCurve.get_Parameter(BuiltInParameter.RBS_START_LEVEL_PARAM);
            ElementId levelId = parameter.AsElementId();

            #region 水管
            if (mepCurve is Pipe)
            {
                Pipe pipe = mepCurve as Pipe;
                ElementId systemTypeId = pipe.MEPSystem.GetTypeId();
                PipeType pipeType = pipe.PipeType;

                Pipe newPipe = Pipe.Create(doc, systemTypeId, pipeType.Id, levelId, pt1, pt2);
                // 复制参数
                Utils.CopyParameters(pipe, newPipe);
                // 删除原管道
                doc.Delete(pipe.Id);
            }
            #endregion

            #region 风管
            else if (mepCurve is Duct)
            {
                Duct duct = mepCurve as Duct;
                double height = duct.get_Parameter(BuiltInParameter.RBS_CURVE_HEIGHT_PARAM).AsDouble();
                ElementId systemTypeId = duct.MEPSystem.GetTypeId();
                DuctType ductType = duct.DuctType;

                Duct newDuct = Duct.Create(doc, systemTypeId, ductType.Id, levelId,
                    pt1 - XYZ.BasisZ * height / 2.0,
                    pt2 - XYZ.BasisZ * height / 2.0);//风管顶平
                // 复制参数
                Utils.CopyParameters(duct, newDuct);
                RotateFix(doc, newDuct, duct);
                // 删除原风管
                doc.Delete(duct.Id);
            }
            #endregion

            #region 桥架
            else if (mepCurve is CableTray)
            {
                CableTray cableTray = mepCurve as CableTray;
                double height = cableTray.get_Parameter(BuiltInParameter.RBS_CABLETRAY_HEIGHT_PARAM).AsDouble();
                ElementId cabletrayType = cableTray.GetTypeId();

                CableTray newCableTray = CableTray.Create(doc, cabletrayType,
                    pt1 - XYZ.BasisZ * height / 2.0, 
                    pt2 - XYZ.BasisZ * height / 2.0, 
                    levelId);//桥架顶平
                // 复制参数
                Utils.CopyParameters(cableTray, newCableTray);
                RotateFix(doc, newCableTray, cableTray);
                // 删除原桥架
                doc.Delete(cableTray.Id);
            }
            #endregion

            #region 线管
            else if (mepCurve is Conduit)
            {
                Conduit conduit = mepCurve as Conduit;
                ElementId conduitType = conduit.GetTypeId();

                Conduit newConduit = Conduit.Create(doc, conduitType, pt1, pt2, levelId);
                // 复制参数
                Utils.CopyParameters(conduit, newConduit);
                // 删除原线管
                doc.Delete(conduit.Id);
            }
            #endregion
        }

        #region 修正风管、桥架旋转角度
        /// <summary>
        /// 修正（矩形）风管、桥架旋转角度
        /// </summary>
        /// <param name="targetToRotate"></param>
        /// <param name="alignCurve"></param>
        private void RotateFix(Document doc, MEPCurve targetToRotate, MEPCurve alignCurve)
        {
            //旋转
            Line tLine = (targetToRotate.Location as LocationCurve).Curve as Line;
            if (tLine.Direction.IsAlmostEqualTo(XYZ.BasisZ) || tLine.Direction.IsAlmostEqualTo(XYZ.BasisZ.Negate()))
            {
                Line aLine = (alignCurve.Location as LocationCurve).Curve as Line;
                double angleToRotate = aLine.Direction.AngleTo(XYZ.BasisY);
                // 利用XYZ.BasisY预旋转
                Transform tran = Transform.CreateRotation(tLine.Direction, angleToRotate);
                XYZ preRotate = tran.OfVector(XYZ.BasisY);
                if (preRotate.IsAlmostEqualTo(aLine.Direction) || preRotate.IsAlmostEqualTo(aLine.Direction.Negate()))
                {
                    ElementTransformUtils.RotateElement(doc, targetToRotate.Id, tLine, aLine.Direction.AngleTo(XYZ.BasisY));
                }
                else
                {
                    ElementTransformUtils.RotateElement(doc, targetToRotate.Id, tLine, aLine.Direction.AngleTo(XYZ.BasisY) * -1.0);
                }
            }
        }
        #endregion

        #region 将管线延伸至配件中心
        private Curve GetExtendCurve(MEPCurve mepCurve)
        {

            Curve cur = (mepCurve.Location as LocationCurve).Curve;
            XYZ pt1 = cur.GetEndPoint(0);
            XYZ pt2 = cur.GetEndPoint(1);
            var conn1 = Utils.FindConnectedTo(mepCurve, cur.GetEndPoint(0));
            if (conn1 != null)
            {
                pt1 = (conn1.Owner.Location as LocationPoint).Point;
            }
            var conn2 = Utils.FindConnectedTo(mepCurve, cur.GetEndPoint(1));
            if (conn2 != null)
            {
                pt2 = (conn2.Owner.Location as LocationPoint).Point;
            }
            return Line.CreateBound(pt1, pt2);
        }
        #endregion

    }
}
