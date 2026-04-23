using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace RevitUtils // revit api dll version : 2020
{
    // 视图相关工具
    public class ViewUtils
    {
        /// <summary>
        /// 跳转到指定三维视图
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        public static View3D SelectView3D(Document doc)
        {
            View3D view3D = null;
            JumpViewWpf jumpViewWindow = new JumpViewWpf(doc);
            jumpViewWindow.ShowDialog();
            if (jumpViewWindow.DialogResult == true)
                view3D = (jumpViewWindow.list.SelectedItem as ViewInfo).View3D;


            return view3D;
        }
        #region 打开或关闭某一个视图（通常用来提升碰撞/射线相关的运行速度）（两个方法搭配使用）
        /// <summary>
        /// 打开指定视图
        /// </summary>
        /// <param name="uidoc"></param>
        /// <param name="targetView">目标视图</param>
        /// <param name="originalView">原视图</param>
        /// <returns>要打开的视图原先是否已经被打开</returns>
        public static bool OpenView(UIDocument uidoc, View targetView, out View originalView)
        {
            bool hasOpen = true;
            originalView = uidoc.ActiveView;
            bool findView = uidoc.GetOpenUIViews().FirstOrDefault(x => x.ViewId == targetView.Id) != null;
            if (!findView) hasOpen = false;

            uidoc.ActiveView = targetView;
            uidoc.ActiveView = originalView;
            return !hasOpen;
        }
        /// <summary>
        /// 关闭指定视图
        /// </summary>
        /// <param name="uidoc"></param>
        /// <param name="closeView">要关闭的视图</param>
        /// <returns>是否成功关闭视图</returns>
        public static bool CloseView(UIDocument uidoc, View closeView)
        {
            IList<UIView> openViews = uidoc.GetOpenUIViews();
            var closeUIView = openViews.FirstOrDefault(x => x.ViewId == closeView.Id);
            if (closeUIView != null)
            {
                closeUIView.Close();
                return true;
            }
            return false;

        }
        #endregion
        /// <summary>
        /// 跳转到指定视图
        /// </summary>
        /// <param name="uidoc"></param>
        /// <param name="view">目标视图</param>
        public static void JumpView(UIDocument uidoc, View view)
        {
            uidoc.ActiveView = view;
        }
        #region 元素可见性设置
        /// <summary>
        /// 对可能影响元素可见性的几个参数属性进行设置（内部无事务）
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="view">视图</param>
        /// <param name="isShow">显示或隐藏元素</param>
        /// <param name="name">自定义过滤器</param>
        /// <param name="categoryId">类别id</param>
        /// <param name="worksetId">工作集id</param>
        /// <param name="regulation">规程</param>
        public static void SetViewVisibility(Document doc, View view, bool isShow, string name = "", ElementId categoryId = null, WorksetId worksetId = null, Regulation regulation = Regulation.无)
        {
            // 1.设置自定义过滤器可见性
            // 获取视图中所有过滤器
            if (!string.IsNullOrEmpty(name))
            {
                var filterIds = view.GetFilters();
                foreach (var id in filterIds)
                {
                    // 获取过滤器的名称
                    var filterName = doc.GetElement(id).Name;
                    if (filterName.Contains(name))
                    {
                        // 判断过滤器是否选择
                        view.GetFilterVisibility(id);
                        // 设置过滤器可见性
                        view.SetFilterVisibility(id, isShow);
                    }
                }
            }


            // 2.设置类别过滤器可见性
            if (categoryId != null)
            {
                // 判断视图中某个类别元素是否可见
                view.GetCategoryHidden(categoryId);
                // 设置视图中某个类别元素的可见性
                view.SetCategoryHidden(categoryId, isShow);
            }


            // 3.设置工作集可见性
            if (worksetId != null)
            {
                WorksetVisibility visibility = isShow ? WorksetVisibility.Visible : WorksetVisibility.Hidden;
                view.SetWorksetVisibility(worksetId, visibility);
            }


            // 4.设置规程
            if (regulation !=  Regulation.无)
            {
                int i = (int)regulation;
                view.get_Parameter(BuiltInParameter.VIEW_DISCIPLINE).Set(i);
            }

        }
        public static TipWindow SetRevitTip(string tipInfo, UIDocument uidoc)
        {
            TipWindow window = new TipWindow(tipInfo, uidoc);

            return window;
        }
        public enum Regulation
        {
            无 = -1,
            建筑 = 1,
            结构 = 2,
            机械 = 4,
            电气 = 8,
            卫浴 = 16,
            协调 = 4096
        }
        #endregion
         
        
    }
}
