using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ReviewDoorClearHeight
{
    public class ClearHeightInfo
    {
        public double OpenClearHeight { get; set; }
        public string OpenClearHeightInScope { get; set; }
        public string OpenColor { get; set; }
        public string OpenFontColor { get; set; } = System.Drawing.ColorTranslator.ToHtml(System.Drawing.Color.Black);
        public FontWeight OpenFontWeight { get; set; } = FontWeights.Normal;
        public double InstallClearHeight { get; set; }
        public string InstallClearHeightInScope { get; set; }
        public string InstallColor { get; set; }
        public string InstallFontColor { get; set; } = System.Drawing.ColorTranslator.ToHtml(System.Drawing.Color.Black);
        public FontWeight InstallFontWeight { get; set; } = FontWeights.Normal;
        public FamilyInstance Door { get; set; }
        public ElementId DoorId { get; set; }
        public XYZ Point { get; set; }
        public ClearHeightInfo(double openClearHeight, string openClearHeightInScope, string openColor, double installClearHeight, string installClearHeightInScope, string installColor)
        {
            OpenClearHeight = openClearHeight;
            OpenClearHeightInScope = openClearHeightInScope;
            OpenColor = openColor;
            InstallClearHeight = installClearHeight;
            InstallClearHeightInScope = installClearHeightInScope;
            InstallColor = installColor;
        }
        public ClearHeightInfo() { }
    }
}
