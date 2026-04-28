using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;

namespace CreateMaskByHeight
{
    public class FloorFilter : ISelectionFilter
    {
        public bool AllowElement(Element elem)
        {
            if (elem.Name.Contains("A-PB-地坪漆")|| elem.Name.Contains("A-PB-停车位区域"))
            {
                return false;
            }
            return elem is Floor && elem.Name.Contains("A-PB");
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            return true;
        }
    }

    public class PathListVM
    {
        public string PathInfo { get; }
        public List<ElementId> InternalPath { get; }
        public double PathLength { get; }

        public PathListVM(List<ElementId> path, int pathNumber, double pathLength)
        {
            PathLength = pathLength * 304.8;

            PathInfo = "路径：" + pathNumber.ToString() + " 号  =>  " +
                $"路径长度为：{(PathLength / 1000).ToString("#0.00")} m";

            InternalPath = path;
        }
    }
    public class Product188
    {
        /// <summary>
        /// 管道id
        public ElementId eidd { set; get; }
        /// </summary>
        public string idd { set; get; }
        public Element elemt { set; get; }
        /// <summary>
        /// 管道射线距离
        /// </summary>
        public double length { set; get; }
        public string name { set; get; }
        public XYZ end_zuobiao { set; get; }

    }
    class Data
    {
    }
    public class Row_attr
    {
        public ElementId eid { set; get; }
        public double row_height { set; get; }
        public XYZ center_point { set; get; }
        public XYZ end_point { set; get; }
        public string ename { set; get; }
        public XYZ start_p { set; get; }
        public XYZ end_p { set; get; }
    }
    public class Product88
    {
        public ElementId eid { set; get; }
        /// <summary>
        /// 管道射线距离
        /// </summary>
        public double row_height { set; get; }

        public string e_id { set; get; }
    }
}
