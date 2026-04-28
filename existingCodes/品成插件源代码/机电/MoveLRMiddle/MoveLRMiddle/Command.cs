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
using Autodesk.Revit.DB.Plumbing;

namespace MoveLRMiddle
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public static double distance = 100;
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
                        //得到构件上的点
                        LocationCurve locationCurve1 = firstEle.Location as LocationCurve;
                        XYZ firstDir = (locationCurve1.Curve as Line).Direction;
                        XYZ firstPo = locationCurve1.Curve.GetEndPoint(0);
                        XYZ firstPo1 = locationCurve1.Curve.GetEndPoint(1);
                        LocationCurve locationCurve2 = secondEle.Location as LocationCurve;
                        XYZ secondDir = (locationCurve2.Curve as Line).Direction;
                        XYZ secondPo = locationCurve2.Curve.GetEndPoint(0);

                        XYZ newLocation = new XYZ();
                        //判断构件是否平行
                        if (!firstDir.IsAlmostEqualTo(secondDir, 1.5))
                        {
                            TaskDialog.Show("警告", "所选构件不平行");
                        }
                        else  //平行，进入程序
                        {
                            //弹出对话框，输入希望移动第二个构件后，两个构件的最后距离
                            using (SettingForm form = new SettingForm())
                            {
                                if (form.ShowDialog() != DialogResult.OK)
                                {
                                    return Result.Failed;
                                }
                            }

                            XYZ pLine = GetProjectivePoint(firstPo, firstPo1, secondPo);

                            double dAB = pLine.DistanceTo(secondPo);
                            double dAC;
                            if (distance > 0)
                            {
                                dAC = dAB - distance / 304.8;
                            }
                            else
                            {
                                dAC = dAB + (Math.Abs(distance)) / 304.8;
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

                    firstEle = secondEle;
                    try
                    {
                        while (true)
                        {
                            Reference thirdPick = sel.PickObject(ObjectType.Element, new MEPCurveSelectionFilter());
                            Element thirdEle = doc.GetElement(thirdPick);
                            secondEle = thirdEle;
                            MoveLRLR(firstEle, secondEle, doc);
                            firstEle = thirdEle;
                        }
                    }
                    catch
                    {

                    }
                }
            }
            catch
            {

            }

            return Result.Succeeded;
        }

        private void MoveLRLR(Element firstEle, Element secondEle, Document doc)
        {
            //判断选择的构件是否有效
            if (firstEle.Id == secondEle.Id)
            {
                TaskDialog.Show("警告", "选择的是同一个构件！");
            }
            else
            {
                //得到构件上的点
                LocationCurve locationCurve1 = firstEle.Location as LocationCurve;
                XYZ firstDir = (locationCurve1.Curve as Line).Direction;
                XYZ firstPo = locationCurve1.Curve.GetEndPoint(0);
                XYZ firstPo1 = locationCurve1.Curve.GetEndPoint(1);
                LocationCurve locationCurve2 = secondEle.Location as LocationCurve;
                XYZ secondDir = (locationCurve2.Curve as Line).Direction;
                XYZ secondPo = locationCurve2.Curve.GetEndPoint(0);

                XYZ newLocation = new XYZ();
                //判断构件是否平行
                if (!firstDir.IsAlmostEqualTo(secondDir, 1.5))
                {
                    TaskDialog.Show("警告", "所选构件不平行");
                }
                else  //平行，进入程序
                {
                    XYZ pLine = GetProjectivePoint(firstPo, firstPo1, secondPo);
                
                    double dAB = pLine.DistanceTo(secondPo);
                    double dAC;
                    if (distance > 0)
                    {
                        dAC = dAB - distance / 304.8;
                    }
                    else
                    {
                        dAC = dAB + (Math.Abs(distance)) / 304.8;
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

        #region 传入Element和其上一点，得到两边y坐标值  没用到
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
            return w;
        }
        #endregion

        #region 传入直线上两点和线外一点，得到线外点在直线上的投影点
        /// <summary>
        /// 获得点q在直线p1p2上的投影点坐标

        public static XYZ GetProjectivePoint(XYZ p1, XYZ p2, XYZ q)
        {
            XYZ u = p2 - p1;
            XYZ pq = q - p1;
            XYZ w2 = pq - u.Multiply(pq.DotProduct(u) / (u.GetLength() * u.GetLength()));
            XYZ point = q - w2;
            XYZ point1 = new XYZ(point.X, point.Y, q.Z);
            return point1;
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

        #region 隔热层

        /// <summary>
        /// Return pipe insulation from given pipe.
        /// </summary>
        PipeInsulation GetPipeInslationFromPipe(Pipe pipe)
        {
            if (pipe == null)
            {
                throw new ArgumentNullException("pipe");
            }

            Document doc = pipe.Document;

            FilteredElementCollector fec = new FilteredElementCollector(doc).OfClass(typeof(PipeInsulation));

            PipeInsulation pipeInsulation = null;

            foreach (PipeInsulation pi in fec)
            {
                // Find the pipe that has this inulation

                if (pi.HostElementId == pipe.Id)
                    pipeInsulation = pi;
            }
            return pipeInsulation;
        }

        /// <summary>
        /// Return material from given pipe insulation.
        /// </summary>
        Material GetMaterialFromPipeInsulation(PipeInsulation pipeInsulation)
        {
            if (pipeInsulation == null)
            {
                throw new ArgumentNullException("pipeInsulation");
            }

            Document doc = pipeInsulation.Document;

            PipeInsulationType pipeInsulationType = doc.GetElement(pipeInsulation.GetTypeId()) as PipeInsulationType;
            TaskDialog.Show("a", pipeInsulationType.Id.ToString());

            Parameter p = pipeInsulationType.get_Parameter(BuiltInParameter.MATERIAL_ID_PARAM);

            return null == p ? null : doc.GetElement(p.AsElementId()) as Material;
        }


        /// <summary>
        /// Prompt user to select a pipe, retrieve its 
        /// insulation and insulation material, 
        /// and report the results.
        /// </summary>
        void GetInsulationFromSelection(Element e)
        {
            if (null != e)
            {
                if (e is Pipe)
                {
                    PipeInsulation pi = GetPipeInslationFromPipe(e as Pipe);

                    if (null == pi)
                    {
                        TaskDialog.Show("提示", "Insulation not found");
                    }
                    else
                    {
                        Material material = GetMaterialFromPipeInsulation(pi);

                        if (null == material)
                        {
                            TaskDialog.Show("提示", "Material not found");
                        }
                        else
                        {
                            TaskDialog.Show("提示", string.Format("Material '{0}' <{1}>", material.Name, material.Id));
                        }
                    }
                }
                else
                {
                    TaskDialog.Show("提示", "Not a pipe");
                }
            }
        }
        #endregion

    }
}