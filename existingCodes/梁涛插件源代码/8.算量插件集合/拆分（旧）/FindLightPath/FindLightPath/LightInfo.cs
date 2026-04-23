using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindLightPath
{
    public class LightInfo
    {
        // 灯具
        public FamilyInstance Light { get; set; }
        // 灯具的宿主
        public Element HostElem { get; set; }
    }
}
