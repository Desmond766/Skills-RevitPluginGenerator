using System;
using System.Collections.Generic;
using System.Text;
using Autodesk.Revit;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.DB.Structure;
using System.Diagnostics;

namespace ARC_SlopeBeam
{
     [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {

            //注册验证
            string licFile = string.Format("{0}\\Key.lic",
    System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
            if (!BTAddInHelper.Utils.CheckReg(licFile))
            {
                return Result.Cancelled;
            }

            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection selection = uiapp.ActiveUIDocument.Selection;

            // 判断是否存在三维视图
            View3D view =Get3DView(doc);
            if (null == view)
            {
                message = "错误1：未找到｛三维｝视图！";
                return Result.Failed;
            }
            // 梁过滤器
            FilteredElementCollector beamCollector;
            // 柱过滤器
            FilteredElementCollector columnCollector;
            if (selection.GetElementIds().Count == 0)
            {
                beamCollector = new FilteredElementCollector(doc);
                columnCollector = new FilteredElementCollector(doc);
            }
            else
            {
                beamCollector = new FilteredElementCollector(doc, selection.GetElementIds());
                columnCollector = new FilteredElementCollector(doc, selection.GetElementIds());
            }
            beamCollector.OfCategory(BuiltInCategory.OST_StructuralFraming).OfClass(typeof(FamilyInstance));
            columnCollector.OfCategory(BuiltInCategory.OST_StructuralColumns).OfClass(typeof(FamilyInstance));

            // 开始
            int num_Done = 0;
            int num_Pass = 0;
            using (Transaction t = new Transaction(doc, "SlopeBeam"))
            {
                t.Start();
                foreach (FamilyInstance familyInstance in beamCollector)
                {
                    try
                    {
                        XYZ zOffset = new XYZ(0, 0, familyInstance.get_Parameter(BuiltInParameter.Z_OFFSET_VALUE).AsDouble());
                        Curve curve = (familyInstance.Location as LocationCurve).Curve;
                        // 原来的偏移量
                        double end0_Base_Offset = familyInstance.get_Parameter(BuiltInParameter.STRUCTURAL_BEAM_END0_ELEVATION).AsDouble();
                        double end1_Base_Offset = familyInstance.get_Parameter(BuiltInParameter.STRUCTURAL_BEAM_END1_ELEVATION).AsDouble();
                        // 计算得到的需要偏移的量
                        double end0_Offset = GetDistance(view, curve.GetEndPoint(0) + zOffset);
                        double end1_Offset = GetDistance(view, curve.GetEndPoint(1) + zOffset);
                        if (end0_Offset > 0.00001)
                        {
                            familyInstance.get_Parameter(BuiltInParameter.STRUCTURAL_BEAM_END0_ELEVATION).Set(end0_Base_Offset + end0_Offset);
                        }
                        if (end1_Offset > 0.00001)
                        {
                            familyInstance.get_Parameter(BuiltInParameter.STRUCTURAL_BEAM_END1_ELEVATION).Set(end1_Base_Offset + end1_Offset);
                        }
                        num_Done += 1;
                    }
                    catch
                    {
                        num_Pass += 1;
                        continue;
                    }
                }
                foreach (FamilyInstance familyInstance in columnCollector)
                {
                    try
                    {
                        XYZ locationPoint = (familyInstance.Location as LocationPoint).Point;
                        // 顶部标高与偏移
                        double topLevel = (doc.GetElement(familyInstance.get_Parameter(BuiltInParameter.SCHEDULE_TOP_LEVEL_PARAM).AsElementId()) as Level).Elevation;
                        double topOffset = familyInstance.get_Parameter(BuiltInParameter.SCHEDULE_TOP_LEVEL_OFFSET_PARAM).AsDouble();
                        // 发射点
                        XYZ point = new XYZ(locationPoint.X, locationPoint.Y, topLevel + topOffset);
                        // 计算得到的需要偏移的量
                        double distanceToOffset = GetDistance(view, point);
                        if (distanceToOffset > 0.00001)
                        {
                            familyInstance.get_Parameter(BuiltInParameter.SCHEDULE_TOP_LEVEL_OFFSET_PARAM).Set(topOffset + distanceToOffset);
                        }
                        num_Done += 1;
                    }
                    catch
                    {
                        num_Pass += 1;
                        continue;
                    }
                }
                t.Commit();
            }
            // 计时结束，输出结果
            string info = "成功定位" + num_Done.ToString() + "个构件；\n跳过" + num_Pass.ToString() + "个构件";
            TaskDialog.Show("Revit", info);
            return Result.Succeeded;
        }

        #region 指定一个点及方向，返回该点到最顶上板的距离
        /// <summary>
        /// 指定一个点及方向，返回该点到最顶上板的距离
        /// </summary>
        /// <param name="view">当前文档</param>
        /// <param name="point">指定点</param>
        /// <param name="direction">指定方向</param>
        /// <returns>点到板的距离</returns>
        private double GetDistance(View3D view, XYZ point)
        {
            List<ElementFilter> filterList = new List<ElementFilter>();
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_Floors));
            //filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_Ceilings));
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_StructuralFoundation));
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_Roofs));
            //filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_RvtLinks));
            LogicalOrFilter floorOrCeiling = new LogicalOrFilter(filterList);
            ReferenceIntersector referenceIntersector = new ReferenceIntersector(floorOrCeiling, FindReferenceTarget.All, view);
            referenceIntersector.FindReferencesInRevitLinks = true;
            IList<ReferenceWithContext> referenceWithContexts = referenceIntersector.Find(point, XYZ.BasisZ);
            double max = 0.0;
            XYZ intersection = null;
            foreach (ReferenceWithContext r in referenceWithContexts)
            {
                Reference reference = r.GetReference();
                double distance = point.DistanceTo(reference.GlobalPoint);
                if (distance > max)
                {
                    max = distance;
                    intersection = reference.GlobalPoint;
                }
            }
            return point.DistanceTo(intersection);
        }
        #endregion

        #region 获得三维视图
        /// <summary>
        /// 获得三维视图
        /// </summary>
        /// <param name="doc">当前文档</param>
        /// <returns>三维视图</returns>
        public static View3D Get3DView(Document doc)
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
    }
}
