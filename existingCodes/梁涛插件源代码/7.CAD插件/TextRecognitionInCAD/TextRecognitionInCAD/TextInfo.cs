using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRecognitionInCAD
{
    public class TextInfo
    {
        public string DBText { get; }
        public Point3d Point3D { get; }
        public TextInfo(string dBText, Point3d point3D)
        {
            DBText = dBText;
            Point3D = point3D;
        }
    }
}
