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
using System.IO;

namespace Com_PointGridLocation
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        private static string s;
        public static string S
        {
            get { return Command.s; }
            set { Command.s = value; }
        }
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
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;

            //选取的点位置
            Reference reference = sel.PickObject(ObjectType.PointOnElement);
            XYZ point = reference.GlobalPoint;

            //收集模型中所有的轴网（无法收集到链接的）
            FilteredElementCollector gridCollector = new FilteredElementCollector(doc);
            gridCollector.OfClass(typeof(Grid)).OfCategory(BuiltInCategory.OST_Grids);

            //收集离选取点的位置最近的4根轴网
            //用来收集轴网、轴网离选取点的坐标距离
            Dictionary<Grid, double> gridLeftDic = new Dictionary<Grid, double>();
            Dictionary<Grid, double> gridRightDic = new Dictionary<Grid, double>();
            Dictionary<Grid, double> gridTopDic = new Dictionary<Grid, double>();
            Dictionary<Grid, double> gridDownDic = new Dictionary<Grid, double>();
            //用来收集轴网离选取点的坐标距离
            List<double> gridLeft = new List<double>();
            List<double> gridRight = new List<double>();
            List<double> gridTop = new List<double>();
            List<double> gridDown = new List<double>();
            //收集4根轴网的值
            string gridLeftValue = "";
            string gridRightValue = "";
            string gridTopValue = "";
            string gridDownValue = "";
            //将collector里面的元素加到list
            List<Grid> list = new List<Grid>();
            foreach (Grid item in gridCollector)
            {
                list.Add(item);
            }
            if (list.Count < 4)
            {
                TaskDialog.Show("提示", "请确认是否导入轴网模型。");
                return Result.Failed;
            }

            #region 用坐标比较的方法

            foreach (Grid item in gridCollector)
            {
                Line line = item.Curve as Line;
                XYZ point0 = line.GetEndPoint(0);
                XYZ point1 = line.GetEndPoint(1);
                if (Math.Abs(point0.X - point1.X) < 0.3)
                {
                    if (point.X - point0.X >= 0)
                    {
                        Parameter gridLeftParam = item.get_Parameter(BuiltInParameter.DATUM_TEXT);
                        gridLeftDic.Add(item, point.X - point0.X);
                        gridLeft.Add(point.X - point0.X);
                    }
                    else
                    {
                        Parameter gridRightParam = item.get_Parameter(BuiltInParameter.DATUM_TEXT);
                        gridRightDic.Add(item, point0.X - point.X);
                        gridRight.Add(point0.X - point.X);
                    }
                }
                if (Math.Abs(point0.Y - point1.Y) < 0.3)
                {
                    if (point.Y - point0.Y >= 0)
                    {
                        Parameter gridTopParam = item.get_Parameter(BuiltInParameter.DATUM_TEXT);
                        gridTopDic.Add(item, point.Y - point0.Y);
                        gridTop.Add(point.Y - point0.Y);
                    }
                    else
                    {
                        Parameter gridDownParam = item.get_Parameter(BuiltInParameter.DATUM_TEXT);
                        gridDownDic.Add(item, point0.Y - point.Y);
                        gridDown.Add(point0.Y - point.Y);
                    }
                }
            }
            gridLeft.Sort();
            gridRight.Sort();
            gridTop.Sort();
            gridDown.Sort();

            foreach (KeyValuePair<Grid, double> kv in gridLeftDic)
            {
                if (Math.Abs(kv.Value - gridLeft[0]) < 0.00001)
                {
                    gridLeftValue = kv.Key.get_Parameter(BuiltInParameter.DATUM_TEXT).AsString();
                }
            }
            foreach (KeyValuePair<Grid, double> kv in gridRightDic)
            {
                if (Math.Abs(kv.Value - gridRight[0]) < 0.00001)
                {
                    gridRightValue = kv.Key.get_Parameter(BuiltInParameter.DATUM_TEXT).AsString();
                }
            }
            foreach (KeyValuePair<Grid, double> kv in gridTopDic)
            {
                if (Math.Abs(kv.Value - gridTop[0]) < 0.00001)
                {
                    gridTopValue = kv.Key.get_Parameter(BuiltInParameter.DATUM_TEXT).AsString();
                }
            }
            foreach (KeyValuePair<Grid, double> kv in gridDownDic)
            {
                if (Math.Abs(kv.Value - gridDown[0]) < 0.00001)
                {
                    gridDownValue = kv.Key.get_Parameter(BuiltInParameter.DATUM_TEXT).AsString();
                }
            }

            #endregion

            #region 用点到线段距离的方法
            //foreach (Grid item in gridCollector)
            //{
            //    Line line = item.Curve as Line;
            //    XYZ point0 = line.GetEndPoint(0);
            //    XYZ point1 = line.GetEndPoint(1);
            //    Line l = Line.CreateBound(point0, point1);


            //}
            #endregion

            s = gridLeftValue + "~" + gridRightValue + "/" + gridTopValue + "~" + gridDownValue;
            
                using (ResultForm rf = new ResultForm())
                {
                    rf.ShowDialog();
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
