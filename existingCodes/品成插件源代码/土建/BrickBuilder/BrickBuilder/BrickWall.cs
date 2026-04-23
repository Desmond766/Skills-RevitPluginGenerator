using Autodesk.Revit.DB;

namespace BrickBuilder
{
    /// <summary>
    /// 砌体墙
    /// </summary>
    public class BrickWall
    {
        //属性
        public Wall HostWall { get; set; }
        public double Height { get; set; }
        public double Length { get; set; }
        public double Tickness { get; set; }
        public Line Line { get; set; }
        public XYZ Direction { get; set; }
        public XYZ Normal { get; set; }
        public XYZ Start { get; set; }
        public PlanarFace Face { get; set; }
        public Outline Range { get; set; }

        //墙编号
        public string Serial { get; set; }
        //塞缝墙
        public TopWall TopWall { get; set; }
        //砌块墙
        public MiddleWall MiddleWall { get; set; }
        //导墙
        public BottomWall BottomWall { get; set; }
        //灰缝
        public double HTickness { get; set; }
        public double VTickness { get; set; }

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="wall"></param>
        public BrickWall(Wall wall)
        {
            HostWall = wall;
            Line = (wall.Location as LocationCurve).Curve as Line;
            Direction = Line.Direction;
            Normal = HostWall.Flipped ? wall.Orientation.Negate() : wall.Orientation;//wall.Orientation指示前进方向左侧
            Height = wall.get_Parameter(BuiltInParameter.WALL_USER_HEIGHT_PARAM).AsDouble();
            Length = Line.Length;
            Tickness = wall.Width;
            //获得墙侧面
            var wallFaceReference = HostObjectUtils.GetSideFaces(HostWall, ShellLayerType.Interior)[0];
            Face = wall.GetGeometryObjectFromReference(wallFaceReference) as PlanarFace;
            //起始点
            Start = Line.GetEndPoint(0);
            //半墙厚偏移
            var halfTicknessOffset = Normal * (wall.Width / 2.0);
            //底部偏移
            var baseOffset = XYZ.BasisZ * (wall.get_Parameter(BuiltInParameter.WALL_BASE_OFFSET).AsDouble());
            //墙高偏移
            var heightOffset = XYZ.BasisZ * Height;
            //更新起始点
            Start += halfTicknessOffset + baseOffset + heightOffset;
            //墙范围
            var wallBBox = wall.get_BoundingBox(wall.Document.ActiveView);
            Range = new Outline(wallBBox.Min, wallBBox.Max);

        }
        #endregion

        public void FlipWall()
        {
            Direction = Direction.Negate();
            Normal = Normal.Negate();

            //获得墙侧面
            var wallFaceReference = HostObjectUtils.GetSideFaces(HostWall, ShellLayerType.Exterior)[0];
            Face = HostWall.GetGeometryObjectFromReference(wallFaceReference) as PlanarFace;
            //起始点
            Start = Line.GetEndPoint(1);
            //半墙厚偏移
            var halfTicknessOffset = Normal * (HostWall.Width / 2.0);
            //底部偏移
            var baseOffset = XYZ.BasisZ * (HostWall.get_Parameter(BuiltInParameter.WALL_BASE_OFFSET).AsDouble());
            //墙高偏移
            var heightOffset = XYZ.BasisZ * Height;
            //更新起始点
            Start += halfTicknessOffset + baseOffset + heightOffset;

            if (null != TopWall)
            {
                TopWall.BasePoint = Start;
            }
        }

    }
}
