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
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.Attributes;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;

namespace MoveUD
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        #region 声明字段和属性
        public static double distance = 100;
        ////声明一个私有的静态的【距离】字段
        //private static double _distance;
        ////声明一个公用的静态的【距离】属性
        //public static double Distance
        //{
        //    get { return Command._distance; }
        //    set { Command._distance = value; }
        //}
        #endregion
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
            try
            {
                while (true)
                {
                    //选择两个构件
                    Reference firstPick = sel.PickObject(ObjectType.Element, new MEPCurveSelectionFilter());
                    Element firstEle = doc.GetElement(firstPick);
                    Reference secondPick = sel.PickObject(ObjectType.Element, new MEPCurveSelectionFilter());
                    Element secondEle = doc.GetElement(secondPick);

                    //判断选择的构件是否有效
                    if (firstEle.Id == secondEle.Id)
                    {
                        TaskDialog.Show("警告", "选择的是同一个构件！");
                    }
                    else
                    {
                       
                            //得到两构件的底部和顶部高程
                            List<double> firstList = FindLevel(firstEle);
                            firstList.Sort();
                            List<double> secondList = FindLevel(secondEle);
                            secondList.Sort();

                            //弹出对话框，输入希望移动第二个构件后，两个构件的最后距离
                            using (Form1 form = new Form1())
                            {
                                if (form.ShowDialog() != DialogResult.OK)
                                {
                                    return Result.Failed;
                                }
                            }

                            //计算移动第二个构件的向量newLocation
                            double d;
                            double origionDis = firstList[0] - secondList[1];
                            if (distance > 0)
                            {
                                if (origionDis > 0)
                                {
                                    d = (origionDis - distance) / 304.8;
                                }
                                else
                                {
                                    d = (secondList[0] - firstList[1] - distance) / -304.8;
                                }
                            }
                            else
                            {
                                if (origionDis > 0)
                                {
                                    d = (firstList[1] - secondList[0] + Math.Abs(distance)) / 304.8;
                                }
                                else
                                {
                                    d = (secondList[1] - firstList[0] + Math.Abs(distance)) / -304.8;
                                }
                            }
                            
                            XYZ newLocation = new XYZ(0, 0, d);
                            LocationCurve locationCurve = secondEle.Location as LocationCurve;

                            //移动第二个构件
                            using (Transaction t = new Transaction(doc, "垂直移动"))
                            {
                                t.Start();
                                locationCurve.Move(newLocation);
                                t.Commit();
                            }
                    }
                }
            }
            catch
            {

            }

            return Result.Succeeded;
        }

        #region 判断所选构件是否为机电管线
        private bool YorN(Element e1, Element e2)
        {
            if ((e1.Category.Id.IntegerValue == (int)BuiltInCategory.OST_CableTray
                || e1.Category.Id.IntegerValue == (int)BuiltInCategory.OST_DuctCurves
                || e1.Category.Id.IntegerValue == (int)BuiltInCategory.OST_PipeCurves
                || e1.Category.Id.IntegerValue == (int)BuiltInCategory.OST_Conduit)
                &&
                e2.Category.Id.IntegerValue == (int)BuiltInCategory.OST_CableTray
                || e2.Category.Id.IntegerValue == (int)BuiltInCategory.OST_DuctCurves
                || e2.Category.Id.IntegerValue == (int)BuiltInCategory.OST_PipeCurves
                || e2.Category.Id.IntegerValue == (int)BuiltInCategory.OST_Conduit)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region 传入Elment算出底部高程和顶部高程
        private List<double> FindLevel(Element e)
        {
            List<double> list = new List<double>();

            if (e.Category.Id.IntegerValue == (int)BuiltInCategory.OST_DuctCurves
                || e.Category.Id.IntegerValue == (int)BuiltInCategory.OST_CableTray
                || e.Category.Id.IntegerValue == (int)BuiltInCategory.OST_Conduit)
            {
                foreach (Parameter p in e.Parameters)
                {
                    if (p.Definition.Name == "底部高程" || p.Definition.Name == "顶部高程")
                    {
                        list.Add(double.Parse(p.AsValueString()));
                    }
                }
            }
            else if (e.Category.Id.IntegerValue == (int)BuiltInCategory.OST_PipeCurves)
            {
                double py = 0.0;
                double cc = 0.0;
                foreach (Parameter p in e.Parameters)
                {
                    if (p.Definition.Name == "开始偏移")
                    {
                        py = double.Parse(p.AsValueString());
                    }
                    if (p.Definition.Name == "外径")
                    {
                        string s = p.AsValueString();
                        int idx = s.LastIndexOf(" ");
                        string value = s.Substring(0, idx);
                        cc = double.Parse(value);
                    }
                }
                double h1 = (py - cc / 2);
                double h2 = (py + cc / 2);
                list.Add(h1);
                list.Add(h2);
            }
            else
            {
                TaskDialog.Show("a", "未找到标高");
            }
            return list;
        }

        #endregion

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
