using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ParameterizedMEPCurveLayout
{
    public class ReOrderAndIntervalEvent : IExternalEventHandler
    {
        public int sheetIndex { get; set; }
        public string structDistance { get; set; }
        public void Execute(UIApplication app)
        {
            //TaskDialog.Show("asda", mEPCurves.Count().ToString());
            UIDocument uidoc = app.ActiveUIDocument;
            Document doc = uidoc.Document;
            //过滤管线 框选元素 并单击获取一点
            MEPCurveFilter filter = new MEPCurveFilter();
            IList<Reference> refs = uidoc.Selection.PickObjects(ObjectType.Element, filter, "请框选管线");
            IList<MEPCurve> mEPs = refs.Select(x => doc.GetElement(x) as MEPCurve).ToList();
            if (Tools.IsHorizontal(mEPs.First()))
            {
                mEPs = mEPs.OrderByDescending(x => Tools.GetMEPCurveCentrePoint(x).Y).ToList();
                //对选中的管线进行排序
                using (Transaction tran = new Transaction(doc, "重新排序"))
                {
                    tran.Start();
                    for (int i = 1; i < mEPs.Count; i++)
                    {
                        string row = Tools.FiltratePipeline(mEPs[i - 1]);
                        string col = Tools.FiltratePipeline(mEPs[i]);
                        int interval = ReadExcelFile.GetData(row, col, sheetIndex);
                        XYZ previousPoint = Tools.GetMEPCurveCentrePoint(mEPs[i - 1]);
                        XYZ targetPoint = new XYZ(previousPoint.X, previousPoint.Y - mEPs[i - 1].ParameterWidth() - mEPs[i].ParameterWidth() - interval / 304.8, previousPoint.Z);
                        Tools.MoveMEPCurve(doc, mEPs[i], targetPoint);
                    }
                    tran.Commit();
                }
            }
            else
            {
                mEPs = mEPs.OrderBy(x => Tools.GetMEPCurveCentrePoint(x).X).ToList();
                //对选中的管线进行排序
                using (Transaction tran = new Transaction(doc, "重新排序"))
                {
                    tran.Start();
                    for (int i = 1; i < mEPs.Count; i++)
                    {
                        string row = Tools.FiltratePipeline(mEPs[i - 1]);
                        string col = Tools.FiltratePipeline(mEPs[i]);
                        int interval = ReadExcelFile.GetData(row, col, sheetIndex);
                        XYZ previousPoint = Tools.GetMEPCurveCentrePoint(mEPs[i - 1]);
                        XYZ targetPoint = new XYZ(previousPoint.X + mEPs[i - 1].ParameterWidth() + mEPs[i].ParameterWidth() + interval / 304.8, previousPoint.Y, previousPoint.Z);
                        Tools.MoveMEPCurve(doc, mEPs[i], targetPoint);
                    }
                    tran.Commit();
                }
            }


            GroupAndWrap.MEPWraping(doc, mEPs, int.Parse(structDistance));

        }

        public string GetName()
        {
            return "";
        }
    }
}
