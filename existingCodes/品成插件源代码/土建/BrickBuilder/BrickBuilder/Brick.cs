using Autodesk.Revit.DB;

namespace BrickBuilder
{
    public class Brick
    {
        public double Length { get; set; }
        public double Width { get; set; }
        public double Tickness { get; set; }
        public string Material { get; set; }
        public XYZ InsertPoint { get; set; }

        public Brick()
        {
            //无参构造函数
        }

        public Brick(FamilyInstance brickInstance)
        {
            //加气混凝土砌块_600*180*200
            var infoArray = brickInstance.Symbol.Name.Split('_');
            Material = infoArray[0];
            Length = double.Parse(infoArray[1].Split('*')[0]) / 304.8;
            Width = double.Parse(infoArray[1].Split('*')[1]) / 304.8;
            Tickness = double.Parse(infoArray[1].Split('*')[2]) / 304.8;
            InsertPoint = (brickInstance.Location as LocationPoint).Point;
        }

        public Brick(string brickInfo)
        {
            //加气混凝土砌块_600*180*200
            var infoArray = brickInfo.Split('_');
            Material = infoArray[0];
            Length = double.Parse(infoArray[1].Split('*')[0]) / 304.8;
            Width = double.Parse(infoArray[1].Split('*')[1]) / 304.8;
            Tickness = double.Parse(infoArray[1].Split('*')[2]) / 304.8;
        }

        public override string ToString()
        {
            return string.Format("{0}_{1}*{2}*{3}",
                Material,
                (Length * 304.8).ToString("0"),
                (Width * 304.8).ToString("0"),
                (Tickness * 304.8).ToString("0"));
        }
    }
}
