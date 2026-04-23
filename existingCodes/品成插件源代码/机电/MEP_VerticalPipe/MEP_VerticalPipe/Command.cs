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

namespace MEP_VerticalPipe
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        #region 字段属性
        private static PipeType _selectPipeType;
        public static PipeType SelectPipeType
        {
            get { return Command._selectPipeType; }
            set { Command._selectPipeType = value; }
        }

        private static Element _selectPipeSystem;
        public static Element SelectPipeSystem
        {
            get { return Command._selectPipeSystem; }
            set { Command._selectPipeSystem = value; }
        }

        private static double _diam;
        public static double Diam
        {
            get { return Command._diam; }
            set { Command._diam = value; }
        }

        private static Level _selectLevel1;
        public static Level SelectLevel1
        {
            get { return Command._selectLevel1; }
            set { Command._selectLevel1 = value; }
        }

        private static double _offset1;
        public static double Offset1
        {
            get { return Command._offset1; }
            set { Command._offset1 = value; }
        }

        private static Level _selectLevel2;
        public static Level SelectLevel2
        {
            get { return Command._selectLevel2; }
            set { Command._selectLevel2 = value; }
        }

        private static double _offset2;
        public static double Offset2
        {
            get { return Command._offset2; }
            set { Command._offset2 = value; }
        }

        private static List<Level> _levelList;
        public static List<Level> LevelList
        {
            get { return Command._levelList; }
            set { Command._levelList = value; }
        }

        #endregion

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
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;
            // 弹出对话框
            using (SettingForm sf = new SettingForm(commandData))
            {
                if (DialogResult.OK != sf.ShowDialog())
                {
                    return Result.Failed;
                }
            }
            // 判断参数是否可用
            if (null == SelectPipeType || null == SelectPipeSystem)
            {
                message = "未指定【管道类型】或【管道系统】";
                return Result.Failed;
            }
            if (null == LevelList || LevelList.Count == 0)
            {
                message = "没有可用的【标高】";
                return Result.Failed;
            }

            XYZ location;
            XYZ startPoint;
            XYZ endPoint;
            Pipe newPipe;
            while (true)
            {
                try
                {
                    // 拾取点
                    location = sel.PickPoint();
                    // 计算关键点
                    if (null != SelectLevel1)
                    {
                        startPoint = new XYZ(location.X, location.Y, SelectLevel1.Elevation + Offset1);
                    }
                    else
                    {
                        startPoint = new XYZ(location.X, location.Y, Offset1);
                    }
                    if (null != SelectLevel2)
                    {
                        endPoint = new XYZ(location.X, location.Y, SelectLevel2.Elevation + Offset2);
                    }
                    else
                    {
                        endPoint = new XYZ(location.X, location.Y, Offset2);
                    }
                    // 绘制立管
                    using (Transaction t = new Transaction(doc, "BimtransMEPTools.VerticalPipe"))
                    {
                        t.Start();
                        if (null == SelectLevel1 && null == SelectLevel2)
                        {
                            newPipe = Pipe.Create(doc, SelectPipeSystem.Id, SelectPipeType.Id, LevelList[0].Id, startPoint, endPoint);
                        }
                        else
                        {
                            newPipe = Pipe.Create(doc, SelectPipeSystem.Id, SelectPipeType.Id, SelectLevel1.Id, startPoint, endPoint);
                        }
                        // 修改立管尺寸
                        newPipe.get_Parameter(BuiltInParameter.RBS_PIPE_DIAMETER_PARAM).Set(Diam);
                        t.Commit();
                    }
                }
                catch
                {
                    break;
                }
            }

            return Result.Succeeded;
        }
    }
}
