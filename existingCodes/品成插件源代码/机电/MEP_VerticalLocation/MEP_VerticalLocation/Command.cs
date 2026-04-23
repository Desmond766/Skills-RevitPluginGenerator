using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using System.Windows.Forms;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI.Selection;
using System.Diagnostics;

namespace MEP_VerticalLocation
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        #region 字段属性
        private static XYZ _direction;
        public static XYZ Direction
        {
            get { return Command._direction; }
            set { Command._direction = value; }
        }
        private static string _distance;
        public static string Distance
        {
            get { return Command._distance; }
            set { Command._distance = value; }
        }
        #endregion

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
            //判断是否存在三维视图
            View3D view = Get3DView(doc);
            if (null == view)
            {
                message = "错误1：未找到｛三维｝视图！";
                return Result.Failed;
            }
            //判断选择集非空
            Selection selection = uiapp.ActiveUIDocument.Selection;
            List<ElementId> elementIds = selection.GetElementIds() as List<ElementId>;
            if (elementIds.Count == 0)
            {
                message = "错误2：未选择任何构件！";
                return Result.Failed;
            }
            //弹出对话框提示用户输入
            using (SettingForm sf = new SettingForm())
            {
                if (DialogResult.OK != sf.ShowDialog())
                {
                    return Result.Failed;
                }
            }
            //距离必须不为空且为数值型
            if (string.IsNullOrEmpty(Distance))
            {
                message = "错误3：距离不能为空！";
                return Result.Failed;
            }
            try
            {
                double distance = double.Parse(Distance);
            }
            catch
            {
                message = "错误4：输入的距离必须为数值！";
                return Result.Failed;
            }
            //计时开始
            Stopwatch sw = new Stopwatch();
            sw.Start();
            //主程序开始
            int num_Done = 0;
            int num_Pass = 0;
            using (Transaction t = new Transaction(doc, "LocateElement"))
            {
                t.Start();
                foreach (ElementId id in elementIds)
                {
                    Element element = doc.GetElement(id);
                    XYZ point;
                    Parameter offset;
                    if (null != element.Location as LocationPoint)//点型元素，其偏移量参数名为INSTANCE_FREE_HOST_OFFSET_PARAM
                    {
                        point = (element.Location as LocationPoint).Point;
                        offset = element.get_Parameter(BuiltInParameter.INSTANCE_FREE_HOST_OFFSET_PARAM);
                    }
                    else if (null != element.Location as LocationCurve)//线型元素，其偏移量参数名为RBS_OFFSET_PARAM
                    {
                        Curve curve = (element.Location as LocationCurve).Curve;
                        if (curve.GetEndPoint(0).Z == curve.GetEndPoint(1).Z)
                        {
                            point = curve.GetEndPoint(0);
                        }
                        else
                        {
                            point = (curve.GetEndPoint(0) + curve.GetEndPoint(1)) / 2.0;
                        }
                        offset = element.get_Parameter(BuiltInParameter.RBS_OFFSET_PARAM);
                    }
                    else//未知的Location类型，跳过
                    {
                        num_Pass += 1;
                        continue;
                    }
                    try
                    {
                        //需要移动的距离
                        double distanceToMove = GetDistance(view, point, Direction) * 304.8 - double.Parse(Distance);
                        if (Direction.Z > 0)
                        {
                            offset.SetValueString((double.Parse(offset.AsValueString()) + distanceToMove).ToString());
                        }
                        else
                        {
                            offset.SetValueString((double.Parse(offset.AsValueString()) - distanceToMove).ToString());
                        }
                        num_Done += 1;
                    }
                    catch//如果没有找到反射点，跳过
                    {
                        num_Pass += 1;
                        continue;
                    }
                }
                t.Commit();
            }
            //结束计时
            sw.Stop();
            //输出程序运行结果
            string info = "成功定位" + num_Done.ToString() + "个构件\n跳过" + num_Pass.ToString() + "个构件\n用时：" + sw.Elapsed.ToString();
            MessageBox.Show(info, "垂直定位V1.0.0");
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
            return point.DistanceTo(referenceWithContext.GetReference().GlobalPoint);
        }
        #endregion

    }
}
