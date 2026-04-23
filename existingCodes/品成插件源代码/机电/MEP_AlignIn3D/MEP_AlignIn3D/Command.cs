//【三维对齐】
//功能介绍：点击一个构件为参照，点击另一个构件与参照构件对齐
//V1.0.0
//初始版本
//V1.0.1
//增加功能:点型构件与线型构件对齐
//增加功能：连续
//20171106
//添加新的加密方式
//20171115
//添加新的加密方式
using System;
using System.Collections.Generic;
using System.Text;
using Autodesk.Revit;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI.Selection;
using System.IO;

namespace MEP_AlignIn3D
{

    #region 空间状态枚举
    public enum Pose
    {
        Vertical,
        Horizontal,
        Unknow,
        Error
    }
    #endregion

    [Transaction(TransactionMode.Manual)]
    class Command : IExternalCommand
    {
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
            Selection selection = uiapp.ActiveUIDocument.Selection;

            try
            {
                while (true)
                {
                    Element firstElem = null;
                    Element secondElem = null;
                    Pose firstPose = Pose.Unknow;
                    Pose secondPose = Pose.Unknow;

                    //try
                    //{
                    //第一次选择
                    firstElem = doc.GetElement(selection.PickObject(ObjectType.Element));
                    firstPose = VerticalOrHorizontal(firstElem);
                    if (firstPose == Pose.Error)
                    {
                        message = "仅支持对齐垂直或水平的【线型】构件！";
                        return Result.Failed;
                    }
                    else if (firstPose == Pose.Unknow)
                    {
                        message = "仅支持对齐【垂直】或【水平】的线型构件！";
                        return Result.Failed;
                    }
                    //第二次选择
                    secondElem = doc.GetElement(selection.PickObject(ObjectType.Element));
                    secondPose = VerticalOrHorizontal(secondElem);
                    if (secondPose == Pose.Error)
                    {
                        message = "仅支持对齐垂直或水平的【线型】构件！";
                        return Result.Failed;
                    }
                    else if (secondPose == Pose.Unknow)
                    {
                        message = "仅支持对齐【垂直】或【水平】的线型构件！";
                        return Result.Failed;
                    }
                    //}
                    //catch
                    //{
                    //    message = "取消选择，程序结束";
                    //    return Result.Cancelled;
                    //}

                    //关键点坐标
                    XYZ start_FirstElem = GetLocationInfo(firstElem)[0];
                    XYZ end_FirstElem = GetLocationInfo(firstElem)[1];
                    XYZ start_SecondElem = GetLocationInfo(secondElem)[0];
                    XYZ end_SecondElem = GetLocationInfo(secondElem)[1];
                    //位移向量
                    XYZ end_Transform;
                    XYZ start_Transform;

                    using (Transaction t = new Transaction(doc, "三维对齐AlignIn3D"))
                    {
                        t.Start();
                        //第一次选择立管
                        if (firstPose == Pose.Vertical)
                        {
                            end_Transform = new XYZ(start_FirstElem.X, start_FirstElem.Y, start_SecondElem.Z);
                            start_Transform = Utils.GetProjectivePoint(start_SecondElem, end_SecondElem, end_Transform);
                            ElementTransformUtils.MoveElement(doc, secondElem.Id, end_Transform - start_Transform);
                        }
                        //第一次选择水平管，第二次选择立管
                        else if (firstPose == Pose.Horizontal && secondPose == Pose.Vertical)
                        {
                            start_Transform = new XYZ(start_SecondElem.X, start_SecondElem.Y, start_FirstElem.Z);
                            end_Transform = Utils.GetProjectivePoint(start_FirstElem, end_FirstElem, start_Transform);
                            ElementTransformUtils.MoveElement(doc, secondElem.Id, end_Transform - start_Transform);
                        }
                        //第一次选择水平管，第二次选择水平管
                        else
                        {
                            //平移变形量
                            start_Transform = new XYZ(start_SecondElem.X, start_SecondElem.Y, start_FirstElem.Z);
                            end_Transform = Utils.GetProjectivePoint(start_FirstElem, end_FirstElem, start_Transform);
                            XYZ transform = end_Transform - start_Transform;

                            Line newCurve = null;
                            //将第一根水平管中心向量赋值第二根水平管的长度，获得新的中心向量
                            XYZ newCenter = (end_FirstElem - start_FirstElem).Normalize().Multiply(start_SecondElem.DistanceTo(end_SecondElem));
                            //分别将这个中心向量、这个中心向量反向量移动到起点位置，判断终点与原终点的距离
                            //距离小的方向正确
                            //获得最终的管中心线
                            if (end_SecondElem.DistanceTo(start_SecondElem + newCenter) <= end_SecondElem.DistanceTo(start_SecondElem + newCenter.Negate()))
                            {
                                newCurve = Line.CreateBound(start_SecondElem + transform, start_SecondElem + newCenter + transform);
                            }
                            else
                            {
                                newCurve = Line.CreateBound(start_SecondElem + transform, start_SecondElem + newCenter.Negate() + transform);
                            }
                            //将最终获得的管中心线赋值给第二根管
                            (secondElem.Location as LocationCurve).Curve = newCurve;
                        }
                        t.Commit();
                    }

                }
            }
            catch
            {
            }


            return Result.Succeeded;
        }

        #region 获得构件的定位线信息
        /// <summary>
        /// 获得构件的定位线信息
        /// </summary>
        /// <param name="element">构件</param>
        /// <returns>定位线信息</returns>
        private List<XYZ> GetLocationInfo(Element element)
        {
            List<XYZ> locationInfo = null;
            LocationCurve locationCurve = element.Location as LocationCurve;
            if (null != locationCurve)
            {
                locationInfo = new List<XYZ>();
                locationInfo.Add(locationCurve.Curve.GetEndPoint(0));
                locationInfo.Add(locationCurve.Curve.GetEndPoint(1));
            }
            return locationInfo;
        }
        #endregion

        #region 获得构件在空间中的位置状态
        /// <summary>
        /// 获得构件在空间中的位置状态
        /// </summary>
        /// <param name="element">构件</param>
        /// <returns>位置状态</returns>
        private Pose VerticalOrHorizontal(Element element)
        {
            List<XYZ> locationInfo = GetLocationInfo(element);
            double different = 0.00001;
            if (null != locationInfo)
            {
                //XY坐标相同，垂直
                if (Math.Abs(locationInfo[0].X - locationInfo[1].X) < different && Math.Abs(locationInfo[0].Y - locationInfo[1].Y) < different)
                {
                    return Pose.Vertical;
                }
                //Z坐标相同，平行
                else if (Math.Abs(locationInfo[0].Z - locationInfo[1].Z) < different)
                {
                    return Pose.Horizontal;
                }
                //任意方向
                else
                {
                    return Pose.Unknow;
                }
            }
            else
            {
                return Pose.Error;
            }
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
