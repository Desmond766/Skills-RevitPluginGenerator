using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitUtils
{
    public static class SolidUtils
    {
        public static Solid CreateSolid(this Element elem, double halfWidth, double halfLength, XYZ zDir, double height)
        {
            Solid solid;

            XYZ lineDir = elem.GetLine().Direction;
            XYZ verDir = elem.GetVerDireciton();
            XYZ cp = elem.GetCreatePoint();

            solid = CreateSolid(lineDir, cp, halfWidth, halfLength, zDir, height);

            return solid;
        }
        public static Solid CreateSolid(this XYZ elemDir, XYZ elemPoint, double halfWidth, double halfLength, XYZ zDir, double height)
        {
            Solid solid;

            XYZ lineDir = elemDir;
            XYZ verDir = lineDir.GetVerDireciton();
            XYZ cp = elemPoint;

            XYZ p1 = cp + lineDir * halfLength + verDir * halfWidth;
            XYZ p2 = cp + lineDir * halfLength - verDir * halfWidth;
            XYZ p3 = cp - lineDir * halfLength - verDir * halfWidth;
            XYZ p4 = cp - lineDir * halfLength + verDir * halfWidth;

            //放样
            List<CurveLoop> loops = new List<CurveLoop>();
            List<Curve> curveList = new List<Curve> { Line.CreateBound(p1, p2), Line.CreateBound(p2, p3), Line.CreateBound(p3, p4), Line.CreateBound(p4, p1) };
            CurveLoop curveLoop = CurveLoop.Create(curveList);
            loops.Add(curveLoop);
            //拉伸
            solid = GeometryCreationUtilities.CreateExtrusionGeometry(loops, zDir, height);
            return solid;
        }
    }
}
