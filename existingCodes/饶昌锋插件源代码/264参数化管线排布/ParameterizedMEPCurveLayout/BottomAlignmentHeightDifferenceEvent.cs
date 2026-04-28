using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ParameterizedMEPCurveLayout
{
    public class BottomAlignmentHeightDifferenceEvent : IExternalEventHandler
    {
        public IList<MEPCurve> mEPCurves { get; set; }
        public void Execute(UIApplication app)
        {
            //TaskDialog.Show("Ada",  "asdas");
            Document doc = app.ActiveUIDocument.Document;
            //排序分组写入到MEPCurveGroup类
            List<MEPCurveGroup> groups = mEPCurves.GroupBy(x => getOffsetParam(x).AsValueString()).OrderByDescending(x => x.Key).Select(x => new MEPCurveGroup() { list = x.ToList() }).ToList();
            //TaskDialog.Show("sda",groups.Count().ToString());
            using (Transaction tran = new Transaction(doc, "调整高度间距及下对齐"))                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   
            {
                tran.Start();
                bool flag = true;
                //遍历MEPCurveGroup中的List 获取上一个的底部高程和下一个的顶部高程
                if (groups.Count==1)
                {
                    foreach (MEPCurve item in groups[0].list)
                    {
                        MEPCurve bottomElevationMEPC = groups[0].list.OrderBy(x => getBottomParam(x).AsDouble()).ToList().First();
                        getBottomParam(item).Set(getBottomParam(bottomElevationMEPC).AsDouble());
                    }
                }
                for (int i = 1; i < groups.Count; i++)
                {
                    MEPCurve bottomElevationMEPC = groups[i - 1].list.OrderBy(x => getBottomParam(x).AsDouble()).ToList().First();
                    MEPCurve topElevationMEPC = groups[i].list.OrderByDescending(x => getTopParam(x).AsDouble()).ToList().First();
                    //TaskDialog.Show("asda", topElevationMEPC.Id.ToString());
                    getTopParam(topElevationMEPC).Set(getBottomParam(bottomElevationMEPC).AsDouble() - 100 / 304.8);
                    //第一行只执行一次
                    if (flag)
                    {
                        foreach (MEPCurve item in groups[0].list)
                        {
                            getBottomParam(item).Set(getBottomParam(bottomElevationMEPC).AsDouble());
                        }
                        flag = false;
                    }
                    //修改底部高程相同
                    foreach (MEPCurve item in groups[i].list)
                    {
                        getBottomParam(item).Set(getBottomParam(topElevationMEPC).AsDouble());
                    }
                }
                tran.Commit();
            }
        }

        public string GetName()
        {
            return "";
        }


        /// <summary>
        /// 获取底部高程
        /// </summary>
        /// <param name="mEP"></param>
        /// <returns></returns>
        public Parameter getBottomParam(MEPCurve mEP)
        {
            Parameter result = null;
            foreach (Parameter item in mEP.Parameters)
            {
                if (item.Definition.Name == "底部高程")
                {
                    result = item;
                }
            }
            return result;
        }

        /// <summary>
        /// 获取顶部高程
        /// </summary>
        /// <param name="mEP"></param>
        /// <returns></returns>
        public Parameter getTopParam(MEPCurve mEP)
        {
            Parameter result = null;
            foreach (Parameter item in mEP.Parameters)
            {
                if (item.Definition.Name == "顶部高程")
                {
                    result = item;
                }
            }
            return result;
        }

        /// <summary>
        /// 获取中间高程
        /// </summary>
        /// <param name="mEP"></param>
        /// <returns></returns>
        public Parameter getOffsetParam(MEPCurve mEP)
        {
            Parameter result = null;
            foreach (Parameter item in mEP.Parameters)
            {
                if (item.Definition.Name == "中间高程")
                {
                    result = item;
                }
            }
            return result;
        }
    }
}
