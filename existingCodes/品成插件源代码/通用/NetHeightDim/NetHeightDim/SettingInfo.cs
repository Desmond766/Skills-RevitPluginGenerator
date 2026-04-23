using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetHeightDim
{
    public class SettingInfo
    {
        //选择模式
        public string SelectMode { get; set; }//SelectCurrent SelectLink
        //射线起点
        public string RayStart { get; set; }//Middle Bottom
        //反射面
        public string DatumMode { get; set; }//SlabDatum PickDatum
        //标高
        public string Elevation { get; set; }//3.000 -
        //是否保留标签
        public string NoteMode { get; set; }//DeleteNote keepNote




    }
}
