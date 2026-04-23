//【管线避让】
//功能介绍：拾取一根或两根直线型机电管线，根据设置智能避让
//V1.0.0
//初始版本
//V1.0.1
//功能增加:拓展到所有机电管线
//20171106
//添加新的加密方式
//20171115
//添加新的加密方式
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System.Windows.Forms;
using System.IO;

namespace MEP_Offset
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public static string rbtn_Direction = "升降";
        public static string rbtn_Type = "单侧";
        public static string rbtn_Angle = "90度";
        public static double cbx_Distance = 200;

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            #region 判断加密
            //注册验证
            string licFile = string.Format("{0}\\Key.lic",
    System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
            if (!BTAddInHelper.Utils.CheckReg(licFile))
            {
                return Result.Cancelled;
            }
            #endregion

            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;

            //弹出设置窗口
            using (SettingForm sf = new SettingForm())
            {
                if (DialogResult.OK != sf.ShowDialog())
                {
                    return Result.Failed;
                }
            }
            try
            {
                while (true)
                {
                    //选择机电管线
                    Reference r1 = null;
                    Reference r2 = null;
                    //try
                    //{
                    r1 = sel.PickObject(ObjectType.Element, new MEPCurveSelectionFilter(), "选择机电管线");
                    r2 = sel.PickObject(ObjectType.Element, new MEPCurveSelectionFilter(), "选择机电管线");
                    //}
                    //catch
                    //{
                    //    message = "取消选择，程序结束！";
                    //    return Result.Cancelled;
                    //}
                    //避让爬升
                    Resolver resolver = new Resolver(commandData);
                    try
                    {
                        using (Transaction t = new Transaction(doc, "机电管线避让"))
                        {
                            t.Start();
                            resolver.Resolve(r1, r2);
                            if (!string.IsNullOrEmpty(Resolver.Message))
                            {
                                message = Resolver.Message;
                                return Result.Failed;
                            }
                            else
                            {
                                t.Commit();
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        message = e.Message;
                        return Result.Failed;
                    }
                }
            }
            catch
            {
            }

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
    }
}