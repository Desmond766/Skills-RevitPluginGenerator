using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParameterizedMEPCurveLayout
{
    /// <summary>
    /// 管线分组实体类
    /// </summary>
    public class MEPCurveGroup
    {
        public string code { get; set; }
        public List<MEPCurve> list { get; set; }

    }
}
