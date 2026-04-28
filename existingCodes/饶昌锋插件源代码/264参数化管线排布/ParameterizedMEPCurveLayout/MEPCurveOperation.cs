using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParameterizedMEPCurveLayout
{
    /// <summary>
    /// 对管线进行打断 分组 并排序
    /// </summary>
    public static class MEPCurveOperation
    {
        /// <summary>
        /// 单点打断管线
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="mEPCurve"></param>
        /// <param name="breakXYZ"></param>
        /// <returns></returns>
        public static MEPCurve BreakCurve(Document doc, MEPCurve mEPCurve, XYZ breakXYZ)
        {
            //拷贝一根管
            ICollection<ElementId> ids = ElementTransformUtils.CopyElement(doc, mEPCurve.Id, new XYZ(0, 0, 0));
            ElementId newId = ids.FirstOrDefault();
            MEPCurve mEPCurveCopy = doc.GetElement(newId) as MEPCurve;


            //原来管的线
            Curve curve = (mEPCurve.Location as LocationCurve).Curve;
            XYZ startXYZ = curve.GetEndPoint(0);
            XYZ endXYZ = curve.GetEndPoint(1);


            //给原来的管用的线
            Line line = Line.CreateBound(startXYZ, breakXYZ);

            //拷贝管用的线
            Line line2 = Line.CreateBound(breakXYZ, endXYZ);

            //管1连接的连接器
            Connector otherCon = null;
            //解除管1连接的连接器 并获得连接的其它连接器
            foreach (Connector con in mEPCurve.ConnectorManager.Connectors)
            {
                bool isBreak = false;
                if (con.Id == 1 && con.IsConnected)
                {
                    foreach (Connector con2 in con.AllRefs)
                    {
                        if (con2.Owner is FamilyInstance)
                        {
                            con.DisconnectFrom(con2);
                            otherCon = con2;
                            isBreak = true;
                            break;
                        }
                    }
                }
                if (isBreak)
                {
                    break;
                }
            }


            //改原来的管
            (mEPCurve.Location as LocationCurve).Curve = line;

            //改现在的管
            (mEPCurveCopy.Location as LocationCurve).Curve = line2;

            //让拷贝的管连接原来管连接的连接器
            if (otherCon != null)
            {

                foreach (Connector con in mEPCurveCopy.ConnectorManager.Connectors)
                {
                    if (con.Id == 1)
                    {
                        con.ConnectTo(otherCon);
                    }
                }
            }
            return mEPCurveCopy;
        }


        /// <summary>
        /// 对管线进行分组并排序 
        /// </summary>
        /// <param name="mEPCurves"></param>
        public static void MEPCurveGroupSort(Document doc, IList<MEPCurve> mEPCurves, int sheetIndex)
        {
            //根据不同类型对元素进行分组
            List<MEPCurveGroup> mEPCurveGroups = mEPCurves.GroupBy(x => x.Category.Id).Select(x => new MEPCurveGroup() { code = x.First().Category.Id.ToString(), list = x.ToList() }).ToList();
            using (Transaction tran = new Transaction(doc, "管线排序"))
            {
                int i = 0;
                tran.Start();
                if (Tools.IsHorizontal(mEPCurves.First()))
                {
                    //获取目前排序最前的元素位置
                    MEPCurve firstMEPCurve = mEPCurves.OrderByDescending(x => (x.Location as LocationCurve).Curve.GetEndPoint(0).Y).First();
                    XYZ targetPoint = Tools.GetMEPCurveCentrePoint(firstMEPCurve);
                    List<MEPCurve> newList = new List<MEPCurve>();
                    foreach (MEPCurveGroup item in mEPCurveGroups)
                    {
                        //根据不同类型使用不同的builtInParameter
                        BuiltInParameter builtInParameter = new BuiltInParameter();
                        if (item.code == "-2008130")
                        {
                            builtInParameter = BuiltInParameter.RBS_CABLETRAY_WIDTH_PARAM;
                        }
                        if (item.code == "-2008044")
                        {
                            builtInParameter = BuiltInParameter.RBS_PIPE_DIAMETER_PARAM;
                        }
                        if (item.code == "-2008000")
                        {
                            builtInParameter = BuiltInParameter.RBS_CURVE_WIDTH_PARAM;
                        }
                        List<MEPCurve> list = item.list.OrderBy(x => x.get_Parameter(builtInParameter).AsDouble() * 304.8).ToList();
                        //TaskDialog.Show("Asda", item.code);
                        foreach (MEPCurve mEP in list)
                        {
                            string row = null;
                            string col = null;
                            //XYZ targetPoint = targetList[i];
                            if (i >= 1)
                            {
                                //获取Excel数据
                                row = Tools.FiltratePipeline(newList[i - 1]);
                                col = Tools.FiltratePipeline(mEP);
                                int interval = ReadExcelFile.GetData(row, col, sheetIndex);
                                //TaskDialog.Show("Asdas",interval.ToString());
                                targetPoint = new XYZ(targetPoint.X, targetPoint.Y - newList[i - 1].ParameterWidth() - mEP.ParameterWidth() - interval / 304.8, targetPoint.Z);
                            }
                            Tools.MoveMEPCurve(doc, mEP, targetPoint);
                            i++;
                            newList.Add(mEP);
                        }
                        //Tools.MoveMEPCurve(doc, newList.First(), targetPoint);
                    }
                }
                else
                {
                    //获取目前排序最前的元素位置
                    MEPCurve firstMEPCurve = mEPCurves.OrderBy(x => (x.Location as LocationCurve).Curve.GetEndPoint(0).X).First();
                    XYZ targetPoint = Tools.GetMEPCurveCentrePoint(firstMEPCurve);
                    List<MEPCurve> newList = new List<MEPCurve>();
                    foreach (MEPCurveGroup item in mEPCurveGroups)
                    {
                        //根据不同类型使用不同的builtInParameter
                        BuiltInParameter builtInParameter = new BuiltInParameter();
                        if (item.code == "-2008130")
                        {
                            builtInParameter = BuiltInParameter.RBS_CABLETRAY_WIDTH_PARAM;
                        }
                        if (item.code == "-2008044")
                        {
                            builtInParameter = BuiltInParameter.RBS_PIPE_DIAMETER_PARAM;
                        }
                        if (item.code == "-2008000")
                        {
                            builtInParameter = BuiltInParameter.RBS_CURVE_WIDTH_PARAM;
                        }
                        List<MEPCurve> list = item.list.OrderBy(x => x.get_Parameter(builtInParameter).AsDouble() * 304.8).ToList();
                        //TaskDialog.Show("Asda", item.code);
                        foreach (MEPCurve mEP in list)
                        {
                            string row = null;
                            string col = null;
                            //XYZ targetPoint = targetList[i];
                            if (i >= 1)
                            {
                                //获取Excel数据
                                row = Tools.FiltratePipeline(newList[i - 1]);
                                col = Tools.FiltratePipeline(mEP);
                                int interval = ReadExcelFile.GetData(row, col, sheetIndex);
                                //TaskDialog.Show("Asdas",interval.ToString());
                                targetPoint = new XYZ(targetPoint.X + newList[i - 1].ParameterWidth() + mEP.ParameterWidth() + interval / 304.8, targetPoint.Y, targetPoint.Z);
                            }
                            Tools.MoveMEPCurve(doc, mEP, targetPoint);
                            i++;
                            newList.Add(mEP);
                        }
                        //Tools.MoveMEPCurve(doc, newList.First(), targetPoint);
                    }
                }
                tran.Commit();
            }
        }

        /// <summary>
        /// 获取管线的宽度的一半
        /// </summary>
        /// <param name="mEPCurve"></param>
        /// <returns></returns>
        public static double ParameterWidth(this MEPCurve mEPCurve)
        {
            double width = 0;
            if (mEPCurve.Category.Id.ToString() == "-2008000")
            {
                width = mEPCurve.get_Parameter(BuiltInParameter.RBS_CURVE_WIDTH_PARAM).AsDouble() / 2;
            }
            if (mEPCurve.Category.Id.ToString() == "-2008044")
            {
                width = mEPCurve.get_Parameter(BuiltInParameter.RBS_PIPE_OUTER_DIAMETER).AsDouble() / 2;
            }
            if (mEPCurve.Category.Id.ToString() == "-2008130")
            {
                width = mEPCurve.get_Parameter(BuiltInParameter.RBS_CABLETRAY_WIDTH_PARAM).AsDouble() / 2;
            }
            return width;
        }
    }
}
