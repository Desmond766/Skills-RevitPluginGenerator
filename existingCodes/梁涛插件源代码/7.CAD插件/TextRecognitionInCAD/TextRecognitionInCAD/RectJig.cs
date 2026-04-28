using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.GraphicsInterface;
using Autodesk.AutoCAD.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRecognitionInCAD
{
    public class RectJig : DrawJig // 显示鼠标框选范围
    {
        public Line line_1;
        public Line line_2;
        public Line line_3;
        public Line line_4;
        public Point3d BasePnt;
        public Point3d AcquirePnt;
        public RectJig(Point3d _basePnt)
        {
            line_1 = new Line();
            line_2 = new Line();
            line_3 = new Line();
            line_4 = new Line();

            BasePnt = _basePnt;
        }
        public RectJig() { }
        protected override SamplerStatus Sampler(JigPrompts prompts)
        {
            JigPromptPointOptions JPPO = new JigPromptPointOptions();
            JPPO.Message = "输入矩形另一个对角点：";
            JPPO.UserInputControls = (UserInputControls.Accept3dCoordinates | UserInputControls.NullResponseAccepted | UserInputControls.AnyBlankTerminatesInput);

            PromptPointResult PR = prompts.AcquirePoint(JPPO);

            if (PR.Status != PromptStatus.OK)
                return SamplerStatus.Cancel;

            if (PR.Value == AcquirePnt)
                return SamplerStatus.NoChange;

            AcquirePnt = PR.Value;
            return SamplerStatus.OK;
        }

        protected override bool WorldDraw(WorldDraw draw)
        {
            Point3d point_1 = new Point3d(BasePnt.X, BasePnt.Y, 0);
            Point3d point_2 = new Point3d(AcquirePnt.X, BasePnt.Y, 0);
            line_1.StartPoint = point_1;
            line_1.EndPoint = point_2;

            point_1 = new Point3d(BasePnt.X, BasePnt.Y, 0);
            point_2 = new Point3d(BasePnt.X, AcquirePnt.Y, 0);
            line_2.StartPoint = point_1;
            line_2.EndPoint = point_2;

            point_1 = new Point3d(BasePnt.X, AcquirePnt.Y, 0);
            point_2 = new Point3d(AcquirePnt.X, AcquirePnt.Y, 0);
            line_3.StartPoint = point_1;
            line_3.EndPoint = point_2;

            point_1 = new Point3d(AcquirePnt.X, BasePnt.Y, 0);
            point_2 = new Point3d(AcquirePnt.X, AcquirePnt.Y, 0);
            line_4.StartPoint = point_1;
            line_4.EndPoint = point_2;

            draw.Geometry.Draw(line_1);
            draw.Geometry.Draw(line_2);
            draw.Geometry.Draw(line_3);
            draw.Geometry.Draw(line_4);

            return true;
        }
    }
}
