using System;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI.Selection;
using System.Windows.Forms;


//类说明：
//Brick--砖块类，存储砖块尺寸、材质、插入点信息
//PartWall--子墙父类，存储子墙砖块、砖块错缝、子墙高、基点
//BrickWall--砖墙类，存储塞缝墙、砌块墙、导墙、墙高、墙编号、灰缝及Revit墙的一系列信息
//Builder--砌墙类，由构造函数传入BrickWall，主函数Build()
//Utils--工具类
//SettingForm--窗口类，收集用户输入信息，构建BrickWall并返回给Command

//TODO:
//1、目前仅从起点往终点排，最好是是翻转能改变--改在点击的面上
//2、指定范围布置
//3、不够的填塞缝砖-需要把塞缝砖信息也加入的墙上
//4、目前只能左下角到右上角这样选择

namespace BrickBuilder
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
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
            Selection sel = uiapp.ActiveUIDocument.Selection;
            
            //获得三维视图
            var view3d = doc.ActiveView as View3D;
            if (null == view3d)
            {
                message = "请在三维模式下运行插件！";
                return Result.Failed;
            }

            //选择直线建筑墙
            Reference reference = null;
            try
            {
                reference = sel.PickObject(ObjectType.Element, new WallSelectFilter());
            }
            catch (Exception)
            {
                //取消选择，程序结束
                return Result.Cancelled;
            }
            var wall = doc.GetElement(reference) as Wall;
            var locationCurve = wall.Location as LocationCurve;
            if (null == locationCurve)
            {
                message = "仅支持【直线墙】！";
                return Result.Failed;
            }
            var wallLine = locationCurve.Curve as Line;
            if (null == wallLine)
            {
                message = "仅支持【直线墙】！";
                return Result.Failed;
            }

            //弹出设置对话框
            BrickWall wallInfo = null;
            using (SettingForm sf = new SettingForm(wall))
            {
                if (DialogResult.OK == sf.ShowDialog())
                {
                    wallInfo = sf.wallInfo;
                }
                else
                {
                    //取消设置，程序结束
                    return Result.Cancelled;
                }
            
            }

            //绘制砖块
            using (Transaction t = new Transaction(doc, "Bimtrans-BuildBrick"))
            {
                t.Start();

                var builder = new Builder(doc, wallInfo);
                var flip = NeedToFlip(wallInfo, reference.GlobalPoint);
                builder.Build(flip);
                
                t.Commit();
            }

            return Result.Succeeded;
        }

        /// <summary>
        /// 判断是否点击在墙的正面
        /// </summary>
        /// <param name="wallInfo"></param>
        /// <param name="pt"></param>
        /// <returns></returns>
        private bool NeedToFlip(BrickWall wallInfo, XYZ pt)
        {
            var start = wallInfo.Line.GetEndPoint(0);
            var end = wallInfo.Line.GetEndPoint(1);
            var iResult = wallInfo.Line.Project(pt);
            if (null == iResult)
            {
                return true;
            }
            var project1 = iResult.XYZPoint;
            var project2 = new XYZ(pt.X, pt.Y, start.Z);
            var direct = (project2 - project1).Normalize();
            return direct.IsAlmostEqualTo(wallInfo.Normal.Negate());
        }

    }
}
