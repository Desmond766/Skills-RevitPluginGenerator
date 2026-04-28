using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BrickBuilder
{
    public class Builder
    {
        Document m_doc;
        BrickWall wallInfo;
        List<ElementId> brickIdList;

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="info"></param>
        public Builder(Document doc, BrickWall info)
        {
            m_doc = doc;
            wallInfo = info;
            brickIdList = new List<ElementId>();
        }
        #endregion

        #region 砌墙
        /// <summary>
        /// 砌墙
        /// </summary>
        /// <param name="hitPoint"></param>
        /// <returns></returns>
        public bool Build(bool flip)
        {
            if (flip)
            {
                wallInfo.FlipWall();
            }

            //顶部
            var b1 = BuildWithSlopeBrick(wallInfo.TopWall);
            //中间
            var b2 = BuildWithLevelBrick(wallInfo.MiddleWall);
            //底部
            var b3 = BuildWithLevelBrick(wallInfo.BottomWall);
            //防重叠偏移
            DisOverLapOffset(brickIdList);
            //添加排砖参数
            //材质_砖长*砖宽*砖高_错缝_水平灰缝_垂直灰缝_是否翻转
            wallInfo.HostWall.get_Parameter(BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS).Set(
                string.Format("{0}_{1}_{2}_{3}_{4}",
                wallInfo.MiddleWall.Brick.ToString(),
                wallInfo.MiddleWall.BrickOffset.ToString(),
                (wallInfo.VTickness * 304.8).ToString("0"),
                (wallInfo.HTickness * 304.8).ToString("0"),
                flip.ToString()
                ));

            return true;
        }
        #endregion

        #region 水平砖砌墙
        /// <summary>
        /// 水平砖砌墙
        /// </summary>
        /// <param name="partWall"></param>
        /// <returns></returns>
        private List<ElementId> BuildWithLevelBrick(PartWall partWall)
        {
            return BuildWithLevelBrick
               (
               partWall.Brick.Length,
               partWall.Brick.Width,
               partWall.Brick.Tickness,
               partWall.BrickOffset,
               partWall.Height,
               wallInfo.Length,
               partWall.Brick.Material,
               wallInfo.Range,
               partWall.BasePoint
               );
        }
        #endregion

        #region 水平砖砌墙
        /// <summary>
        /// 水平砖砌墙
        /// </summary>
        /// <param name="brickLength"></param>
        /// <param name="brickWidth"></param>
        /// <param name="brickTickness"></param>
        /// <param name="brickOffset"></param>
        /// <param name="wallHeight"></param>
        /// <param name="wallLength"></param>
        /// <param name="brickMaterial"></param>
        /// <param name="range"></param>
        /// <param name="basePoint"></param>
        /// <returns></returns>
        public List<ElementId> BuildWithLevelBrick(
            double brickLength,
            double brickWidth,
            double brickTickness,
            double brickOffset,
            double wallHeight,
            double wallLength,
            string brickMaterial,
            Outline range,
            XYZ basePoint
            )
        {
            var instanceIdList = new List<ElementId>();
            //水平普通砖族
            var brickFamilyName = "PC_普通砖_水平";
            var brickFamily = Utils.FindFamilyByName(m_doc, brickFamilyName);
            if (null == brickFamily)
            {
                MessageBox.Show(string.Format("未找到名为【{0}】的族！", brickFamilyName));
                return null;
            }
            //垂直步距
            var verticalStep = brickTickness + wallInfo.HTickness;
            //垂直砖块数量
            var verticalBrickNum = int.Parse(Math.Floor(wallHeight / verticalStep).ToString());//*垂直砖块往下取整
            //水平步距
            var horizontalStep = brickLength + wallInfo.VTickness;
            //水平砖块数量
            var horizontalBrickNum = int.Parse(Math.Ceiling(wallLength / horizontalStep).ToString()) + 1;//*水平砖块往上取证*因为错缝砖往右偏移所以砖数+1

            for (int i = 0; i < verticalBrickNum; i++)
            {
                for (int j = 0; j < horizontalBrickNum; j++)
                {
                    //计算四个角点
                    var pt1 = basePoint
                        + XYZ.BasisZ.Negate() * i * verticalStep
                        + wallInfo.Direction * j * horizontalStep;

                    if (i % 2 != 0)
                    {
                        //砖块错缝偏移
                        pt1 += wallInfo.Direction.Negate() * (brickLength * brickOffset + wallInfo.VTickness);
                    }

                    var pt2 = pt1 + XYZ.BasisZ.Negate() * brickTickness;
                    var pt3 = pt2 + wallInfo.Direction * brickLength;
                    var pt4 = pt1 + wallInfo.Direction * brickLength;

                    //根据四个角点，返回应该填充的砖块集合
                    var brickList = SplitBirck(pt1, pt2, pt3, pt4, range);
                    if (brickList.Count > 0)
                    {
                        foreach (var brick in brickList)
                        {
                            brick.Width = brickWidth;
                            brick.Material = brickMaterial;
                            var brickSymbol = GetLevelBrickSymbol(brickFamily, brick);
                            var brickInstance = AddLevelBrick(brick.InsertPoint, brickSymbol);
                            if (null != brickInstance)
                            {
                                instanceIdList.Add(brickInstance.Id);
                            }
                        }
                    }
                }
            }
            return instanceIdList;
        }
        #endregion

        #region 斜砖砌墙
        /// <summary>
        /// 斜砖砌墙
        /// </summary>
        /// <param name="partWall"></param>
        /// <returns></returns>
        private List<ElementId> BuildWithSlopeBrick(PartWall partWall)
        {
            var instanceIdList = new List<ElementId>();
            //不绘制斜墙
            if (partWall.Height == 0.0)
            {
                //修正其他墙高
                FixWallHeight(partWall.Height);
                return instanceIdList;
            }

            //*复杂三角函数
            //A=asinα+bcosα=√(a²+b²)sin(α+φ) 其中tanφ=b/a
            //那么arcsin(A/√(a²+b²))=α+arctan(b/a)
            //那么α=arcsin(A/√(a²+b²))-arctan(b/a)
            //其中A=partWall.Height - wallInfo.HTickness a=partWall.Brick.Length b=partWall.Brick.Tickness
            var A = partWall.Height - wallInfo.HTickness;
            var a = partWall.Brick.Length;
            var b = partWall.Brick.Tickness;
            var angle = Math.Asin(A / Math.Sqrt(a * a + b * b)) - Math.Atan(b / a);
            if (double.IsNaN(angle))
            {
                angle = Math.PI / 4.0;//默认值
            }
            if (angle * 180.0 / Math.PI < 20.0)
            {
                MessageBox.Show("塞缝砖高度过小，以至砖倾斜角度过大，请重新设置！");
                return instanceIdList;
            }

            //倾斜倾斜砖族
            var brickFamilyName = "PC_普通砖_倾斜";
            var brickFamily = Utils.FindFamilyByName(m_doc, brickFamilyName);
            if (null == brickFamily)
            {
                MessageBox.Show(string.Format("未找到名为【{0}】的族！", brickFamilyName));
                return instanceIdList;
            }

            //水平步距
            var horizontalStep = (partWall.Brick.Tickness + wallInfo.HTickness) / Math.Sin(angle);
            //水平砖块数量
            var horizontalBrickNum = int.Parse(Math.Ceiling(wallInfo.Length / horizontalStep).ToString());

            for (int i = 0; i < horizontalBrickNum; i++)
            {
                //砖起点
                var startPoint = partWall.BasePoint
                    + wallInfo.Direction * (Math.Sin(angle) * partWall.Brick.Tickness)//第一块砖偏移
                    + wallInfo.Direction * i * horizontalStep;
                //砖终点
                var endPoint = startPoint + wallInfo.Direction * partWall.Brick.Length;
                //砖起点是否在墙内
                var startPointInside = Utils.PointIsInsideFace(startPoint, wallInfo.Face);
                //砖终点是否在墙内 *这里计算的是桩长*cos(倾斜角)是否在墙内
                var endPointInside = Utils.PointIsInsideFace(
                    startPoint + wallInfo.Direction * (partWall.Brick.Length * Math.Cos(angle)),
                    wallInfo.Face);
                //起点终点都在墙内----BUG!
                if (startPointInside && endPointInside)
                {
                    //获得砖类型
                    var brickSymbol = GetSlopeBrickSymbol(
                        brickFamily,
                        partWall.Brick.Material,
                        partWall.Brick.Length,
                        partWall.Brick.Width,
                        partWall.Brick.Tickness,
                        angle * 180.0 / Math.PI
                        );
                    var brick = AddLevelBrick(startPoint, brickSymbol);
                    instanceIdList.Add(brick.Id);
                }
            }

            //斜墙高度
            var slopeWallHeight = wallInfo.HTickness
                + Math.Sin(angle) * (partWall.Brick.Length + partWall.Brick.Tickness / Math.Tan(angle));
            if (partWall.Height - slopeWallHeight < 0.001)
            {
                //修正其他墙高
                FixWallHeight(partWall.Height);
                return instanceIdList;
            }
            //斜墙下水平砖墙
            var levelWallHeight = partWall.Height - slopeWallHeight;
            var levelWallBasePoint = partWall.BasePoint + XYZ.BasisZ.Negate() * slopeWallHeight;
            var levelInstanceIdList = BuildWithLevelBrick(
                partWall.Brick.Length,
                partWall.Brick.Width,
                partWall.Brick.Tickness,
                0.5,
                levelWallHeight,
                wallInfo.Length,
                partWall.Brick.Material,
                wallInfo.Range,
                levelWallBasePoint
                );
            instanceIdList.AddRange(levelInstanceIdList);

            //修正其他墙高
            var verticalStep = partWall.Brick.Tickness + wallInfo.HTickness;
            var levelBrickNum = Math.Floor(levelWallHeight / verticalStep);
            var topWallHeight = slopeWallHeight + levelBrickNum * verticalStep;
            FixWallHeight(topWallHeight);

            return instanceIdList;
        }
        #endregion

        #region 根据塞缝砖墙真实高度，修正其他墙高及基点
        /// <summary>
        /// 根据塞缝砖墙真实高度，修正其他墙高及基点
        /// </summary>
        /// <param name="topWallHeight"></param>
        private void FixWallHeight(double topWallHeight)
        {
            //剩余高度
            var remainHeight = wallInfo.Height - topWallHeight;
            //垂直步距
            var verticalStep = wallInfo.MiddleWall.Brick.Tickness + wallInfo.HTickness;
            //砌块砖数量
            var middleBrickNum = Math.Floor(remainHeight / verticalStep);
            //砌块砖墙高
            wallInfo.MiddleWall.Height = middleBrickNum * verticalStep;
            //砌块砖墙基点
            wallInfo.MiddleWall.BasePoint = wallInfo.TopWall.BasePoint + XYZ.BasisZ.Negate() * topWallHeight;
            //导墙高
            wallInfo.BottomWall.Height = remainHeight - wallInfo.MiddleWall.Height;
            //导墙基点
            wallInfo.BottomWall.BasePoint = wallInfo.MiddleWall.BasePoint + XYZ.BasisZ.Negate() * wallInfo.MiddleWall.Height;
        }
        #endregion

        #region 获得水平砖类型
        /// <summary>
        ///  获得水平砖类型
        /// </summary>
        /// <param name="brickFamily"></param>
        /// <param name="brick"></param>
        /// <returns></returns>
        private FamilySymbol GetLevelBrickSymbol(Family brickFamily, Brick brick)
        {
            return GetLevelBrickSymbol(
                brickFamily,
                brick.Material,
                brick.Length,
                brick.Width,
                brick.Tickness);
        }
        #endregion

        #region 获得水平砖类型
        /// <summary>
        /// 获得水平砖类型
        /// </summary>
        /// <param name="brickFamily"></param>
        /// <param name="material"></param>
        /// <param name="length"></param>
        /// <param name="width"></param>
        /// <param name="tickness"></param>
        /// <returns></returns>
        private FamilySymbol GetLevelBrickSymbol(Family brickFamily, string material, double length, double width, double tickness)
        {
            if (length < 0.001 || width < 0.001 || tickness < 0.001)
            {
                return null;
            }
            //砖类型
            string brickSymbolName = string.Format(
                "{0}_{1}*{2}*{3}",
                material,
                (length * 304.8).ToString("0"),
                (width * 304.8).ToString("0"),
                (tickness * 304.8).ToString("0"));
            FamilySymbol brickSymbol = null;

            //循环查找砖类型
            foreach (var id in brickFamily.GetFamilySymbolIds())
            {
                if (m_doc.GetElement(id).Name == brickSymbolName)
                {
                    return m_doc.GetElement(id) as FamilySymbol;
                }
            }
            //如果不存在复制一个
            var sourceSymbol = m_doc.GetElement(brickFamily.GetFamilySymbolIds().First()) as FamilySymbol;
            brickSymbol = sourceSymbol.Duplicate(brickSymbolName) as FamilySymbol;
            //修改参数
            var paramsList1 = brickSymbol.GetParameters("长");
            if (paramsList1.Count == 0)
            {
                return null;
            }
            paramsList1[0].Set(length);
            var paramsList2 = brickSymbol.GetParameters("宽");
            if (paramsList2.Count == 0)
            {
                return null;
            }
            paramsList2[0].Set(width);
            var paramsList3 = brickSymbol.GetParameters("厚");
            if (paramsList3.Count == 0)
            {
                return null;
            }
            paramsList3[0].Set(tickness);

            return brickSymbol;
        }
        #endregion

        #region 获得斜砖类型
        /// <summary>
        /// 获得斜砖类型
        /// </summary>
        /// <param name="brickFamily"></param>
        /// <param name="material"></param>
        /// <param name="length"></param>
        /// <param name="width"></param>
        /// <param name="tickness"></param>
        /// <param name="angle"></param>
        /// <returns></returns>
        private FamilySymbol GetSlopeBrickSymbol(Family brickFamily, string material, double length, double width, double tickness, double angle)
        {
            if (length < 0.001 || width < 0.001 || tickness < 0.001)
            {
                return null;
            }
            //砖类型
            string brickSymbolName = string.Format(
                "{0}_{1}*{2}*{3}_{4}",
                material,
                (length * 304.8).ToString("0"),
                (width * 304.8).ToString("0"),
                (tickness * 304.8).ToString("0"),
                angle.ToString("0")
                );
            FamilySymbol brickSymbol = null;

            //循环查找砖类型
            foreach (var id in brickFamily.GetFamilySymbolIds())
            {
                if (m_doc.GetElement(id).Name == brickSymbolName)
                {
                    return m_doc.GetElement(id) as FamilySymbol;
                }
            }
            //如果不存在复制一个
            var sourceSymbol = m_doc.GetElement(brickFamily.GetFamilySymbolIds().First()) as FamilySymbol;
            brickSymbol = sourceSymbol.Duplicate(brickSymbolName) as FamilySymbol;
            //修改参数
            var paramsList1 = brickSymbol.GetParameters("长");
            if (paramsList1.Count == 0)
            {
                return null;
            }
            paramsList1[0].Set(length);
            var paramsList2 = brickSymbol.GetParameters("宽");
            if (paramsList2.Count == 0)
            {
                return null;
            }
            paramsList2[0].Set(width);
            var paramsList3 = brickSymbol.GetParameters("厚");
            if (paramsList3.Count == 0)
            {
                return null;
            }
            paramsList3[0].Set(tickness);
            var paramsList4 = brickSymbol.GetParameters("角度");
            if (paramsList4.Count == 0)
            {
                return null;
            }
            paramsList4[0].Set(Math.PI * angle / 180.0);

            return brickSymbol;
        }
        #endregion

        #region 添加水平砖
        /// <summary>
        /// 添加水平砖
        /// </summary>
        /// <param name="startPoint"></param>
        /// <param name="brickSymbol"></param>
        private FamilyInstance AddLevelBrick(XYZ startPoint, FamilySymbol brickSymbol)
        {
            if (null == brickSymbol)
            {
                return null;
            }
            //创建砖
            var brick = m_doc.Create.NewFamilyInstance(startPoint, brickSymbol, StructuralType.NonStructural);
            //试旋转
            //1、默认逆时针旋转
            //2、AngleTo结果在0-180之间
            var rotate = Transform.CreateRotation(XYZ.BasisZ, XYZ.BasisY.AngleTo(wallInfo.Direction));
            var rotateTest = rotate.OfVector(XYZ.BasisY);
            if (rotateTest.AngleTo(wallInfo.Direction) < 0.001)
            {
                ElementTransformUtils.RotateElement(m_doc, brick.Id, Line.CreateBound(startPoint, startPoint + XYZ.BasisZ), XYZ.BasisY.AngleTo(wallInfo.Direction));
            }
            else
            {
                ElementTransformUtils.RotateElement(m_doc, brick.Id, Line.CreateBound(startPoint, startPoint + XYZ.BasisZ), -XYZ.BasisY.AngleTo(wallInfo.Direction));
            }
            brickIdList.Add(brick.Id);

            return brick;
        }
        #endregion

        //BUG!当4个点不全在范围内的时候，重新计算4个点，除了根据墙边界找交点，还要根据OutLine范围找交点！
        //未考虑：
        //砖跨过构造柱的情况
        //4个点均不在墙内，但是应该生成砖的情况
        //未排除IntersertPoint找不到的情况

        #region 根据四个交点切割砖块，返回砖块集合
        /// <summary>
        /// 根据四个交点切割砖块，返回砖块集合
        /// *砖块Index如下（左上角起顺时针）
        /// ....4......1....
        /// ....【砖块】....
        /// ....3......2....
        /// </summary>
        /// <param name="pt1"></param>
        /// <param name="pt2"></param>
        /// <param name="pt3"></param>
        /// <param name="pt4"></param>
        private List<Brick> SplitBirck(XYZ pt1, XYZ pt2, XYZ pt3, XYZ pt4, Outline range)
        {
            var brickList = new List<Brick>();
            
            //既要在墙内也要在范围内
            var inside1 = Utils.PointIsInsideFace(pt1, wallInfo.Face) && range.Contains(pt1, 0.01);
            var inside2 = Utils.PointIsInsideFace(pt2, wallInfo.Face) && range.Contains(pt2, 0.01);
            var inside3 = Utils.PointIsInsideFace(pt3, wallInfo.Face) && range.Contains(pt3, 0.01);
            var inside4 = Utils.PointIsInsideFace(pt4, wallInfo.Face) && range.Contains(pt4, 0.01);

            if (inside1 && inside2 && inside3 && inside4)
            {
                //这里做一个简陋的判断
                //如果两个三等分点都在面内才算完整砖
                //否则按照判定为砖横跨构造柱的情况--BUG!
                //*是否考虑每一块砖发射射线的方式？
                var center12 = (pt1 + pt2) / 2.0;
                var offset = wallInfo.Direction * (pt1.DistanceTo(pt4) / 3.0);
                var trisection1 = center12 + offset;
                var trisection2 = trisection1 + offset;
                var t1Inside = Utils.PointIsInsideFace(trisection1, wallInfo.Face);
                var t2Inside = Utils.PointIsInsideFace(trisection2, wallInfo.Face);

                //两个三等分点也在面内
                if (t1Inside && t2Inside)
                {
                    var brick = new Brick()
                    {
                        Length = pt1.DistanceTo(pt4),
                        Tickness = pt1.DistanceTo(pt2),
                        InsertPoint = pt1
                    };
                    brickList.Add(brick);
                }
                //
                else
                {
                    //!inside1 && !inside2 && inside3 && inside4
                    {
                        var ip = Utils.FindIntersectionPoint(m_doc, wallInfo.HostWall, pt4, wallInfo.Direction.Negate());
                        var brick = new Brick()
                        {
                            Length = ip.DistanceTo(pt4) - wallInfo.VTickness,
                            Tickness = pt3.DistanceTo(pt4),
                            InsertPoint = ip + wallInfo.Direction * wallInfo.VTickness
                        };
                        brickList.Add(brick);
                    }
                    //inside1 && inside2 && !inside3 && !inside4
                    {
                        var ip = Utils.FindIntersectionPoint(m_doc, wallInfo.HostWall, pt1, wallInfo.Direction);
                        var brick = new Brick()
                        {
                            Length = ip.DistanceTo(pt1) - wallInfo.VTickness,
                            Tickness = pt1.DistanceTo(pt2),
                            InsertPoint = pt1
                        };
                        brickList.Add(brick);
                    }
                }
            }
            else if (!inside1 && inside2 && inside3 && inside4)
            {
                var ip1 = Utils.FindIntersectionPoint(m_doc, wallInfo.HostWall, pt1, wallInfo.Direction);
                var ip2 = Utils.FindIntersectionPoint(m_doc, wallInfo.HostWall, pt2, XYZ.BasisZ);
                var brick1 = new Brick()
                {
                    Length = ip1.DistanceTo(pt1),
                    Tickness = ip2.DistanceTo(pt2) - wallInfo.HTickness,
                    InsertPoint = ip2 + XYZ.BasisZ.Negate() * wallInfo.HTickness
                };
                brickList.Add(brick1);
                var brick2 = new Brick()
                {
                    Length = ip1.DistanceTo(pt4) - wallInfo.VTickness,
                    Tickness = pt3.DistanceTo(pt4),
                    InsertPoint = ip1 + wallInfo.Direction * wallInfo.VTickness
                };
                brickList.Add(brick2);
            }
            else if (inside1 && !inside2 && inside3 && inside4)
            {
                var ip1 = Utils.FindIntersectionPoint(m_doc, wallInfo.HostWall, pt2, wallInfo.Direction);
                var ip2 = Utils.FindIntersectionPoint(m_doc, wallInfo.HostWall, pt1, XYZ.BasisZ.Negate());
                var brick1 = new Brick()
                {
                    Length = ip1.DistanceTo(pt2),
                    Tickness = ip2.DistanceTo(pt1) - wallInfo.HTickness,
                    InsertPoint = pt1
                };
                brickList.Add(brick1);
                var brick2 = new Brick()
                {
                    Length = ip1.DistanceTo(pt3) - wallInfo.VTickness,
                    Tickness = pt3.DistanceTo(pt4),
                    InsertPoint = pt1 + wallInfo.Direction * (ip1.DistanceTo(pt2) + wallInfo.VTickness)
                };
                brickList.Add(brick2);
            }
            else if (inside1 && inside2 && !inside3 && inside4)
            {
                var ip1 = Utils.FindIntersectionPoint(m_doc, wallInfo.HostWall, pt3, wallInfo.Direction.Negate());
                var ip2 = Utils.FindIntersectionPoint(m_doc, wallInfo.HostWall, pt4, XYZ.BasisZ.Negate());
                var brick1 = new Brick()
                {
                    Length = ip1.DistanceTo(pt3),
                    Tickness = ip2.DistanceTo(pt4) - wallInfo.HTickness,
                    InsertPoint = pt4 + wallInfo.Direction.Negate() * (ip1.DistanceTo(pt3))
                };
                brickList.Add(brick1);
                var brick2 = new Brick()
                {
                    Length = ip1.DistanceTo(pt2) - wallInfo.VTickness,
                    Tickness = pt1.DistanceTo(pt2),
                    InsertPoint = pt1
                };
                brickList.Add(brick2);
            }
            else if (inside1 && inside2 && inside3 && !inside4)
            {
                var ip1 = Utils.FindIntersectionPoint(m_doc, wallInfo.HostWall, pt4, wallInfo.Direction.Negate());
                var ip2 = Utils.FindIntersectionPoint(m_doc, wallInfo.HostWall, pt3, XYZ.BasisZ);
                var brick1 = new Brick()
                {
                    Length = ip1.DistanceTo(pt4),
                    Tickness = ip2.DistanceTo(pt3) - wallInfo.HTickness,
                    InsertPoint = ip1 + XYZ.BasisZ.Negate() * (ip2.DistanceTo(pt4) + wallInfo.VTickness)
                };
                brickList.Add(brick1);
                var brick2 = new Brick()
                {
                    Length = ip1.DistanceTo(pt1) - wallInfo.HTickness,
                    Tickness = pt1.DistanceTo(pt2),
                    InsertPoint = pt1
                };
                brickList.Add(brick2);
            }
            else if (!inside1 && !inside2 && inside3 && inside4)
            {
                var ip = Utils.FindIntersectionPoint(m_doc, wallInfo.HostWall, pt4, wallInfo.Direction.Negate());
                var brick = new Brick()
                {
                    Length = ip.DistanceTo(pt4) - wallInfo.VTickness,
                    Tickness = pt3.DistanceTo(pt4),
                    InsertPoint = ip + wallInfo.Direction * wallInfo.VTickness
                };
                brickList.Add(brick);
            }
            else if (!inside1 && inside2 && !inside3 && inside4)
            {
                //不考虑
            }
            else if (!inside1 && inside2 && inside3 && !inside4)
            {
                var ip = Utils.FindIntersectionPoint(m_doc, wallInfo.HostWall, pt2, XYZ.BasisZ);
                var brick = new Brick()
                {
                    Length = pt2.DistanceTo(pt3),
                    Tickness = ip.DistanceTo(pt2) - wallInfo.HTickness,
                    InsertPoint = ip + XYZ.BasisZ.Negate() * wallInfo.HTickness
                };
                brickList.Add(brick);
            }
            else if (inside1 && !inside2 && !inside3 && inside4)
            {
                var ip = Utils.FindIntersectionPoint(m_doc, wallInfo.HostWall, pt1, XYZ.BasisZ.Negate());
                var brick = new Brick()
                {
                    Length = pt1.DistanceTo(pt4),
                    Tickness = ip.DistanceTo(pt1) - wallInfo.HTickness,
                    InsertPoint = pt1
                };
                brickList.Add(brick);
            }
            else if (inside1 && !inside2 && inside3 && !inside4)
            {
                //不考虑
            }
            else if (inside1 && inside2 && !inside3 && !inside4)
            {
                var ip = Utils.FindIntersectionPoint(m_doc, wallInfo.HostWall, pt1, wallInfo.Direction);
                var brick = new Brick()
                {
                    Length = ip.DistanceTo(pt1) - wallInfo.VTickness,
                    Tickness = pt1.DistanceTo(pt2),
                    InsertPoint = pt1
                };
                brickList.Add(brick);
            }
            else if (!inside1 && !inside2 && !inside3 && inside4)
            {
                var ip1 = Utils.FindIntersectionPoint(m_doc, wallInfo.HostWall, pt4, wallInfo.Direction.Negate());
                var ip2 = Utils.FindIntersectionPoint(m_doc, wallInfo.HostWall, pt4, XYZ.BasisZ.Negate());
                var brick = new Brick()
                {
                    Length = ip1.DistanceTo(pt4) - wallInfo.VTickness,
                    Tickness = ip2.DistanceTo(pt4) - wallInfo.HTickness,
                    InsertPoint = ip1 + wallInfo.Direction * wallInfo.VTickness
                };
                brickList.Add(brick);
            }
            else if (!inside1 && !inside2 && inside3 && !inside4)
            {
                var ip1 = Utils.FindIntersectionPoint(m_doc, wallInfo.HostWall, pt3, wallInfo.Direction.Negate());
                var ip2 = Utils.FindIntersectionPoint(m_doc, wallInfo.HostWall, pt3, XYZ.BasisZ);
                var brick = new Brick()
                {
                    Length = ip1.DistanceTo(pt3) - wallInfo.VTickness,
                    Tickness = ip2.DistanceTo(pt3) - wallInfo.HTickness,
                    InsertPoint = ip1 + XYZ.BasisZ * (ip2.DistanceTo(pt3) - wallInfo.HTickness) + wallInfo.Direction * wallInfo.VTickness
                };
                brickList.Add(brick);
            }
            else if (!inside1 && inside2 && !inside3 && !inside4)
            {
                var ip1 = Utils.FindIntersectionPoint(m_doc, wallInfo.HostWall, pt2, wallInfo.Direction);
                var ip2 = Utils.FindIntersectionPoint(m_doc, wallInfo.HostWall, pt2, XYZ.BasisZ);
                var brick = new Brick()
                {
                    Length = ip1.DistanceTo(pt2) - wallInfo.VTickness,
                    Tickness = ip2.DistanceTo(pt2) - wallInfo.HTickness,
                    InsertPoint = ip2 + XYZ.BasisZ.Negate() * wallInfo.HTickness
                };
                brickList.Add(brick);
            }
            else if (inside1 && !inside2 && !inside3 && !inside4)
            {
                var ip1 = Utils.FindIntersectionPoint(m_doc, wallInfo.HostWall, pt1, wallInfo.Direction);
                var ip2 = Utils.FindIntersectionPoint(m_doc, wallInfo.HostWall, pt1, XYZ.BasisZ.Negate());
                var brick = new Brick()
                {
                    Length = ip1.DistanceTo(pt1) - wallInfo.VTickness,
                    Tickness = ip2.DistanceTo(pt1) - wallInfo.HTickness,
                    InsertPoint = pt1
                };
                brickList.Add(brick);
            }
            else
            {
                //四个角点均不在墙内
            }
            return brickList;
        }
        #endregion

        #region 防止重叠偏移
        /// <summary>
        /// 防止重叠偏移
        /// </summary>
        /// <param name="brickIdList"></param>
        public void DisOverLapOffset(List<ElementId> idList)
        {
            if (null == idList)
            {
                return;
            }
            if (0 == idList.Count)
            {
                return;
            }
            ElementTransformUtils.MoveElements(m_doc, idList, wallInfo.Normal * (1 / 304.8));
        }
        #endregion

        public void OffsetToFront(List<ElementId> idList, double brickWidth)
        {
            if (null == idList)
            {
                return;
            }
            if (0 == idList.Count)
            {
                return;
            }
            var offset = wallInfo.Normal.Negate() * (wallInfo.HostWall.Width - brickWidth + 2 / 304.8);
            ElementTransformUtils.MoveElements(m_doc, idList, offset);
        }

    }
}
