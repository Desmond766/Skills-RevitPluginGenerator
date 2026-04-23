using Autodesk.Revit.DB;

namespace BrickBuilder
{
    /// <summary>
    /// 子墙父类
    /// </summary>
    public class PartWall
    {
        //属性
        public Brick Brick { get; set; }
        public double Height { get; set; }
        public double BrickOffset { get; set; }
        public XYZ BasePoint { get; set; }
    }

    public class TopWall : PartWall
    {
        //
    }

    public class MiddleWall : PartWall
    {
        //
    }

    public class BottomWall : PartWall
    {
        //
    }

}
