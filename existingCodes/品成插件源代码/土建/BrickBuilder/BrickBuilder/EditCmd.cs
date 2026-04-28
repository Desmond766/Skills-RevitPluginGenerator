using System;
using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.Attributes;
using System.Windows.Forms;

//TODO:
//添加导墙砖

namespace BrickBuilder
{
    [Transaction(TransactionMode.Manual)]
    public class EditCmd : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;

            //第一次点击
            Reference r1 = null;
            try
            {
                r1 = sel.PickObject(ObjectType.Element, new BrickSelectFilter());
            }
            catch
            {
                MessageBox.Show("取消选择，程序结束！");
                return Result.Failed;
            }
            var pick1 = doc.GetElement(r1);
            var bbox1 = pick1.get_BoundingBox(doc.ActiveView);

            //第二次点击
            Reference r2 = null;
            try
            {
                r2 = sel.PickObject(ObjectType.Element, new BrickSelectFilter());
            }
            catch
            {
                MessageBox.Show("取消选择，程序结束！");
                return Result.Failed;
            }
            var pick2 = doc.GetElement(r2);
            var bbox2 = pick2.get_BoundingBox(doc.ActiveView);

            //两次点击范围
            Outline range = new Outline(bbox1.Min, bbox1.Max);
            range.AddPoint(bbox2.Min);
            range.AddPoint(bbox2.Max);

            //范围框过滤器
            var bboxFilter = new BoundingBoxIntersectsFilter(range, -0.01);//收缩范围，避免选中转角的墙

            //收集要删除的砖
            var collector = new FilteredElementCollector(doc).WherePasses(bboxFilter).OfClass(typeof(FamilyInstance));
            var brickToDel = new List<ElementId>();
            var brickSizeList = new List<string>();
            foreach (var id in collector.ToElementIds())
            {
                var e = doc.GetElement(id);
                if (e.get_Parameter(BuiltInParameter.ELEM_FAMILY_PARAM).AsValueString() == "PC_普通砖_水平")
                {
                    brickToDel.Add(id);
                }
            }
            if (brickToDel.Count == 0)
            {
                MessageBox.Show("未找到需要重绘的砖块！");
                return Result.Failed;
            }

            //找到墙
            var wallCollector = new FilteredElementCollector(doc).WherePasses(bboxFilter).OfClass(typeof(Wall));
            Wall wall = null;
            if (wallCollector.Count() == 0)
            {
                MessageBox.Show("未找到宿主墙！");
                return Result.Failed;
            }
            else if (wallCollector.Count() == 1)
            {
                wall = doc.GetElement(wallCollector.ToElementIds().First()) as Wall;
            }
            else
            {
                //手动拾取宿主墙
                MessageBox.Show("未能正确判断宿主墙，请手动拾取！");
                Reference wallReference = null;
                try
                {
                    wallReference = sel.PickObject(ObjectType.Element, new WallSelectFilter());
                }
                catch
                {
                    MessageBox.Show("取消选择，程序结束！");
                    return Result.Failed;
                }
                wall = doc.GetElement(wallReference) as Wall;
            }
            var brickWall = new BrickWall(wall);
            
            //收集所需的数据
            var brickInfo = wall.get_Parameter(BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS).AsString();
            if (string.IsNullOrEmpty(brickInfo))
            {
                MessageBox.Show("未找到排砖信息！");
                return Result.Failed;
            }
            string[] infoArray = null;
            Brick mainBrick = null;//完整的砖
            double brickOffset = 0.0;
            double hTickness = 0.0;
            double vTickness = 0.0;
            bool flip = false;
            try
            {
                //材质_砖长*砖宽*砖高_错缝_水平灰缝_垂直灰缝_是否翻转
                infoArray = brickInfo.Split('_');
                mainBrick = new Brick(string.Format("{0}_{1}", infoArray[0], infoArray[1]));
                brickOffset = double.Parse(infoArray[2]);
                hTickness = double.Parse(infoArray[3]) / 304.8;
                vTickness = double.Parse(infoArray[4]) / 304.8;
                flip = bool.Parse(infoArray[5]);
            }
            catch
            {
                MessageBox.Show("排砖信息不正确！");
                return Result.Failed;
            }
            brickWall.HTickness = hTickness;
            brickWall.VTickness = vTickness;

            if (flip)
            {
                brickWall.FlipWall();
            }

            //基准点-砖块右上角顶点
            var pt1 = (pick1.Location as LocationPoint).Point;
            var pt2 = (pick2.Location as LocationPoint).Point;
            Element pickAbove = null;//右上角的砖
            Element pickBelow = null;//左下角的砖
            if (Math.Abs(pt1.Z - pt2.Z) < 0.00001)//pt1.Z == pt2.Z
            {
                MessageBox.Show("暂不支持调整单排砖！");
                return Result.Failed;
            }
            if (pt1.Z > pt2.Z)
            {
                pickAbove = pick1;
                pickBelow = pick2;
            }
            else
            {
                pickAbove = pick2;
                pickBelow = pick1;
            }
            //右上角砖
            var brick1 = new Brick(pickAbove as FamilyInstance);
            //根据右上角砖定位点计算得到的basePoint
            var basePoint = CalBasePoint(brickWall, mainBrick, brick1);

            //弹出对话框
            BrickOffsetCalculator calculator = new BrickOffsetCalculator(brickWall, mainBrick);
            using (EditSettingForm esf = new EditSettingForm())
            {
                if (DialogResult.OK != esf.ShowDialog())
                {
                    return Result.Failed;
                }
                calculator.CalOffset(esf.HOffsetVaule, esf.VOffsetVaule);
            }
            //根据输入值偏移basePoint
            basePoint += calculator.HOffset + calculator.VOffset;

            //左下角砖
            var brick2 = new Brick(pickBelow as FamilyInstance);
            //墙高
            var wallHeight = basePoint.Z - brick2.InsertPoint.Z + brick2.Tickness + 2 * hTickness;
            //将basePoint降到与basePointBelow一样高度，根据它们之间的距离，计算墙长
            var ptTemp = new XYZ(basePoint.X, basePoint.Y, brick2.InsertPoint.Z);
            var wallLength = ptTemp.DistanceTo(brick2.InsertPoint) + brick2.Length + 2 * vTickness;

            //输出并重绘
            using (Transaction t = new Transaction(doc, "t"))
            {
                t.Start();

                //删除砖块
                doc.Delete(brickToDel);
                //重绘砖墙
                Builder builder = new Builder(doc, brickWall);
                var idList = builder.BuildWithLevelBrick(
                    mainBrick.Length,
                    mainBrick.Width,
                    mainBrick.Tickness,
                    brickOffset,
                    wallHeight,
                    wallLength,
                    mainBrick.Material,
                    range,
                    basePoint);
                //防重叠偏移
                builder.DisOverLapOffset(idList);

                t.Commit();
            }
 
            return Result.Succeeded;
        }

        #region 根据右上角砖定位点计算得到的basePoint
        /// <summary>
        /// 根据右上角砖定位点计算得到的basePoint
        /// </summary>
        /// <param name="brickWall"></param>
        /// <param name="mainBrick"></param>
        /// <param name="cornerBrick"></param>
        /// <returns></returns>
        private XYZ CalBasePoint(BrickWall brickWall, Brick mainBrick, Brick cornerBrick)
        {
            //根据右上角的插入点找到坐下角的点
            //*默认左下角的插入点不变
            var pt = cornerBrick.InsertPoint;
            pt += brickWall.Direction * cornerBrick.Length;
            pt += XYZ.BasisZ.Negate() * cornerBrick.Tickness;
            //再偏移整砖尺寸
            pt += brickWall.Direction.Negate() * mainBrick.Length;
            pt += XYZ.BasisZ * mainBrick.Tickness;
            //向内偏移1mm
            pt += brickWall.Normal.Negate() * (1 / 304.8);
            return pt;
        }
        #endregion

    }

    /// <summary>
    /// 砖块偏移计算
    /// </summary>
    public class BrickOffsetCalculator
    {
        public XYZ HOffset { get; set; }
        public XYZ VOffset { get; set; }

        private BrickWall m_brickWall;
        private Brick m_brick;

        public BrickOffsetCalculator(BrickWall brickWall, Brick brick)
        {
            m_brickWall = brickWall;
            m_brick = brick;
        }

        #region 计算偏移
        /// <summary>
        /// 计算偏移
        /// </summary>
        /// <param name="hOffsetVaule"></param>
        /// <param name="vOffsetVaule"></param>
        public void CalOffset(double hOffsetVaule, double vOffsetVaule)
        {
            if (hOffsetVaule > 0.0)
            {
                HOffset = m_brickWall.Direction.Negate() * hOffsetVaule;
            }
            else
            {
                //相当于向右移动=步长-(x除以步长的余数)
                var offsetVaule = m_brick.Length + m_brickWall.VTickness - (Math.Abs(hOffsetVaule) % (m_brick.Length + m_brickWall.VTickness));
                HOffset = m_brickWall.Direction.Negate() * offsetVaule;
            }
            if (vOffsetVaule > 0.0)
            {
                VOffset = XYZ.BasisZ * vOffsetVaule;
            }
            else
            {
                //相当于向上移动=2*步长-(x除以(2*步长)的余数)
                var offsetVaule = 2 * (m_brick.Tickness + m_brickWall.HTickness) - (Math.Abs(vOffsetVaule) % (2 * (m_brick.Tickness + m_brickWall.HTickness)));
                VOffset = XYZ.BasisZ * offsetVaule;
            }
        }
        #endregion
        
    }
}
