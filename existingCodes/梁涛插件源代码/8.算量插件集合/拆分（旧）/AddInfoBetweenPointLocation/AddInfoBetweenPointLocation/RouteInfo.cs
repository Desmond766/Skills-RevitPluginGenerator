using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddInfoBetweenPointLocation
{
    public class RouteInfo
    {
        // 配电箱
        public string Start { get; set; }
        // 用电名称
        public string End { get; set; }
        // 回路编号
        public string RouteNumber { get; set; }
        // 所属系统
        public string System { get; set; }
        // 电缆型号.规格
        public string ModelSpecifications { get; set; }
    }
}
