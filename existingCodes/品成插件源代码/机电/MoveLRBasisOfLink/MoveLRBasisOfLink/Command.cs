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

namespace MoveLRBasisOfLink
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
                    //选择第一个构件（链接的墙）
                    //Reference firstPick = sel.PickObject(ObjectType.LinkedElement);
                    Reference firstPick = sel.PickObject(ObjectType.PointOnElement, new LinkElemFilter(doc), "选择链接模型中的墙或柱（柱需选择一条边）");
                    RevitLinkInstance linkIns = doc.GetElement(firstPick) as RevitLinkInstance;
                    Transform linkTransform = linkIns.GetTransform();
                    Element firstEle = linkIns.GetLinkDocument().GetElement(firstPick.LinkedElementId);
                    bool b1 = YorNWallOrColumn(firstEle);
                    if (b1 == false)
                    {
                        TaskDialog.Show("警告", "选择的不是墙/柱");
                    }
                    else
                    {
                        //选择第二个构件（机电管线）
                        Reference secondPick = sel.PickObject(ObjectType.Element, new MEPCurveSelectionFilter(), "选择机电管线");
                        Element secondEle = doc.GetElement(secondPick);

                        //得到构件上的点
                        XYZ firstDir;
                        XYZ firstPo;
                        XYZ firstPo1;
                        if (firstEle.Location != null && firstEle.Location is LocationCurve)
                        {
                            LocationCurve locationCurve1 = firstEle.Location as LocationCurve;
                            firstDir = (locationCurve1.Curve as Line).Direction;
                            firstPo = locationCurve1.Curve.GetEndPoint(0);
                            firstPo1 = locationCurve1.Curve.GetEndPoint(1);
                        }
                        else if (firstEle.Location != null && firstEle.Location is LocationPoint)
                        {
                            GeometryObject linkGeo = firstEle.GetGeometryObjectFromReference(firstPick.CreateReferenceInLink());
                            Line line;
                            if (linkGeo is Line)
                            {
                                line = (linkGeo as Line).CreateTransformed(linkTransform) as Line;
                            }
                            else
                            {
                                Edge edge = linkGeo as Edge;
                                line = (edge.AsCurve() as Line).CreateTransformed(linkTransform) as Line;
                            }


                            firstDir = line.Direction;
                            firstPo = line.GetEndPoint(0);
                            firstPo1 = line.GetEndPoint(1);
                        }
                        else
                        {
                            continue;
                        }
                        

                        LocationCurve locationCurve2 = secondEle.Location as LocationCurve;
                        XYZ secondDir = (locationCurve2.Curve as Line).Direction;
                        XYZ secondPo = locationCurve2.Curve.GetEndPoint(0);

                        XYZ newLocation = new XYZ();
                        List<double> firstList = new List<double>();

                        //判断构件是否平行
                        if (!firstDir.IsAlmostEqualTo(secondDir, 0.18) && !firstDir.IsAlmostEqualTo(secondDir.Negate(), 0.18))
                        {
                            TaskDialog.Show("警告", "所选构件不平行");
                        }
                        else  //平行，进入程序
                        {
                            //弹出对话框，输入希望移动第二个构件后，两个构件的最后距离
                            using (Form1 form = new Form1())
                            {
                                if (form.ShowDialog() != DialogResult.OK)
                                {
                                    return Result.Failed;
                                }
                            }
                            XYZ pLine = GetProjectivePoint(firstPo, firstPo1, secondPo);
                            double w1 = GetHalfWidth(firstEle);
                            double w2 = GetHalfWidth(secondEle);
                            double w = (w1 + w2) / 304.8;
                            double dAB = pLine.DistanceTo(secondPo);
                            double dAC;
                            if (distance > 0)
                            {
                                dAC = dAB - w - distance / 304.8;
                            }
                            else
                            {
                                dAC = dAB + w + (Math.Abs(distance)) / 304.8;
                            }
                            newLocation = (pLine - secondPo).Normalize() * dAC;

                            using (Transaction t = new Transaction(doc, "水平移动"))
                            {
                                t.Start();
                                locationCurve2.Move(newLocation);
                                t.Commit();
                            }
                        }
                    }
                }
            }
            catch
            {
                //throw;
            }

            return Result.Succeeded;
        }

        #region 判断所选构件是否为链接的墙
        private bool YorNWallOrColumn(Element e)
        {
            if (e.Category.Id.IntegerValue == (int)BuiltInCategory.OST_Walls || e.Category.Id.IntegerValue == -2001330)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region 判断所选构件是否为机电管线
        private bool YorN(Element e)
        {
            if (e.Category.Id.IntegerValue == (int)BuiltInCategory.OST_CableTray
                || e.Category.Id.IntegerValue == (int)BuiltInCategory.OST_DuctCurves
                || e.Category.Id.IntegerValue == (int)BuiltInCategory.OST_PipeCurves
                || e.Category.Id.IntegerValue == (int)BuiltInCategory.OST_Conduit)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region 传入Element和其上一点，得到两边y坐标值  //没用到
        private List<double> FindEdge(Element e, XYZ point)
        {
            List<double> list = new List<double>();
            if (e.Category.Id.IntegerValue == (int)BuiltInCategory.OST_CableTray)
            {
                foreach (Parameter p in e.Parameters)
                {
                    if (p.Definition.Name == "宽度")
                    {
                        string s = p.AsValueString();
                        int idx = s.LastIndexOf(" ");
                        string value = s.Substring(0, idx);
                        double w = double.Parse(value);
                        list.Add(point.Y + (w / 2) / 304.8);
                        list.Add(point.Y - (w / 2) / 304.8);
                    }
                }
            }
            else if (e.Category.Id.IntegerValue == (int)BuiltInCategory.OST_DuctCurves)
            {
                foreach (Parameter p in e.Parameters)
                {
                    if (p.Definition.Name == "宽度")
                    {
                        double w = double.Parse(p.AsValueString());
                        list.Add(point.Y + (w / 2) / 304.8);
                        list.Add(point.Y - (w / 2) / 304.8);
                    }
                }
            }
            else if (e.Category.Id.IntegerValue == (int)BuiltInCategory.OST_PipeCurves
                || e.Category.Id.IntegerValue == (int)BuiltInCategory.OST_Conduit)
            {
                foreach (Parameter p in e.Parameters)
                {
                    if (p.Definition.Name == "外径")
                    {
                        string s = p.AsValueString();
                        int idx = s.LastIndexOf(" ");
                        string value = s.Substring(0, idx);
                        double w = double.Parse(value);
                        list.Add(point.Y + (w / 2) / 304.8);
                        list.Add(point.Y - (w / 2) / 304.8);
                    }
                }
            }
            else if (e.Category.Id.IntegerValue == (int)BuiltInCategory.OST_Walls)
            {
                Wall wall = e as Wall;
                Parameter p = wall.WallType.get_Parameter(BuiltInParameter.WALL_ATTR_WIDTH_PARAM);
                double w = double.Parse(p.AsValueString());
                list.Add(point.Y + (w / 2) / 304.8);
                list.Add(point.Y - (w / 2) / 304.8);
            }
            return list;
        }

        #endregion    

        #region 传入Element,得到其一半的宽度值
        private double GetHalfWidth(Element e)
        {
            double w = 0.0;
            if (e.Category.Id.IntegerValue == (int)BuiltInCategory.OST_CableTray)
            {
                foreach (Parameter p in e.Parameters)
                {
                    if (p.Definition.Name == "宽度")
                    {
                        string s = p.AsValueString();
                        int idx = s.LastIndexOf(" ");
                        string value = s.Substring(0, idx);
                        w = double.Parse(value) / 2;
                    }
                }
            }
            else if (e.Category.Id.IntegerValue == (int)BuiltInCategory.OST_DuctCurves)
            {
                foreach (Parameter p in e.Parameters)
                {
                    if (p.Definition.Name == "宽度")
                    {
                        w = double.Parse(p.AsValueString()) / 2;
                    }
                }
            }
            else if (e.Category.Id.IntegerValue == (int)BuiltInCategory.OST_PipeCurves
                || e.Category.Id.IntegerValue == (int)BuiltInCategory.OST_Conduit)
            {
                foreach (Parameter p in e.Parameters)
                {
                    if (p.Definition.Name == "外径")
                    {
                        string s = p.AsValueString();
                        int idx = s.LastIndexOf(" ");
                        string value = s.Substring(0, idx);
                        w = double.Parse(value) / 2;

                    }
                }
            }
            else if (e.Category.Id.IntegerValue == (int)BuiltInCategory.OST_Walls)
            {
                Wall wall = e as Wall;
                Parameter p = wall.WallType.get_Parameter(BuiltInParameter.WALL_ATTR_WIDTH_PARAM);
                w = double.Parse(p.AsValueString()) / 2;
            }
            return w;
        }
        #endregion

        #region 传入直线上两点和线外一点，得到线外点在直线上的投影点
        private XYZ GetProjectivePoint(XYZ standardStartPoint, XYZ standardEndPoint, XYZ modifyStartPoint)
        {
            XYZ pLine = new XYZ();
            double k = (standardEndPoint.Y - standardStartPoint.Y) / (standardEndPoint.X - standardStartPoint.X);
            if (Math.Abs(k) < 0.1) //if (k == 0)
            {
                pLine = new XYZ(modifyStartPoint.X, standardStartPoint.Y, modifyStartPoint.Z);

            }
            else if (standardEndPoint.X - standardStartPoint.X == 0)
            {
                pLine = new XYZ(standardEndPoint.X, modifyStartPoint.Y, modifyStartPoint.Z);
            }
            else
            {
                double x = (k * (standardStartPoint.X) + ((modifyStartPoint.X) / k) + modifyStartPoint.Y - standardStartPoint.Y) / (1 / k + k);
                double y = -1 / k * (x - modifyStartPoint.X) + modifyStartPoint.Y;
                pLine = new XYZ(x, y, modifyStartPoint.Z);

            }
            return pLine;
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
    public class LinkElemFilter : ISelectionFilter
    {
        public Document Doc { get; set; }
        public LinkElemFilter(Document doc)
        {
            Doc = doc;
        }
        public bool AllowElement(Element elem)
        {
            return true;
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            Element elem = Doc.GetElement(reference);
            if (elem is RevitLinkInstance linkInstance)
            {
                Document linkDoc = linkInstance.GetLinkDocument();
                Element linkElem = linkDoc.GetElement(reference.LinkedElementId);

                //var linkGeo = linkElem.GetGeometryObjectFromReference(reference.CreateReferenceInLink());
                //if (linkGeo is Edge || linkGeo is Curve) return true;

                if (linkElem is Wall)
                {
                    //GeometryObject geo = linkElem.GetGeometryObjectFromReference(reference.CreateReferenceInLink());
                    //if (geo is Line || geo is Edge edge && edge.AsCurve() is Line) return true;
                    return true;
                }
                else if (linkElem.Category.Id.IntegerValue == -2001330)
                {
                    //return true;
                    Reference linkRefer = reference.CreateReferenceInLink();
                    GeometryObject geo = linkElem.GetGeometryObjectFromReference(linkRefer);
                    if (geo is Line || geo is Edge edge && edge.AsCurve() is Line) return true;
                }
            }
            return false;
        }
    }
}
