//20171106
//添加新的加密方式
//20171115
//添加新的加密方式
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;
using System.Windows.Forms;
using System.IO;

namespace MEP_SectionBox
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        private static BoundingBoxXYZ m_box;
        public static BoundingBoxXYZ Box
        {
            get { return Command.m_box; }
            set { Command.m_box = value; }
        }

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
         
            #region 判断加密
            //注册验证
    //        string licFile = string.Format("{0}\\Key.lic",
    //System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
    //        if (!BTAddInHelper.Utils.CheckReg(licFile))
    //        {
    //            return Result.Cancelled;
    //        }

            #endregion
            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;

            View3D view3D = doc.ActiveView as View3D;
            if (null == view3D)
            {
                message = "请切换至三维视图运行！";
                return Result.Failed;
            }

            SettingForm sf = new SettingForm(doc);
            if (DialogResult.OK != sf.ShowDialog())
            {
                return Result.Failed;
            }
            //View3D view3D = doc.ActiveView as View3D;
            using (Transaction t = new Transaction(doc, "SetSectionBox"))
            {
                t.Start();
                view3D.SetSectionBox(Box);
                t.Commit();
            }
            if (doc.ActiveView.Id.IntegerValue != view3D.Id.IntegerValue)
            {
                uiapp.ActiveUIDocument.ActiveView = view3D;
            }

            //view3D.SetSectionBox(Box);

            return Result.Succeeded;
        }
        #region 找到不同盘符的共享盘
        /// <summary>
        /// 找到不同盘符的共享盘
        /// </summary>
        /// <param name="specifiedPath">指定的路径</param>
        /// <returns>大家电脑上可以识别到的路径</returns>
        public static string SharedPath(string path)
        {
            //列出用户共享盘可能的盘符
            List<string> strList = new List<string>()
        {
            "A", "B", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", 
            "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"
        };
            for (int i = 0; i < strList.Count; i++)
            {
                string SharePath = path.Replace("X", strList[i]);
                if (Directory.Exists(SharePath))
                {
                    path = SharePath;
                    break;
                }
            }
            return path;
        }

        #endregion

        //#region 获得三维视图
        ///// <summary>
        ///// 获得三维视图
        ///// </summary>
        ///// <param name="doc">当前文档</param>
        ///// <returns>三维视图</returns>
        //public View3D Get3DView(Document doc)
        //{
        //    FilteredElementCollector collector = new FilteredElementCollector(doc);
        //    collector.OfClass(typeof(View3D));
        //    foreach (View3D v in collector)
        //    {
        //        if (v != null && !v.IsTemplate && v.Name == "{三维}")
        //        {
        //            return v as View3D;
        //        }
        //    }
        //    return null;
        //}
        //#endregion
    }
}
