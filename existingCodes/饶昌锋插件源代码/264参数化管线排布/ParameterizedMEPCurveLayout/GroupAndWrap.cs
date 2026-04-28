using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParameterizedMEPCurveLayout
{
    public class GroupAndWrap
    {
        public static void MEPGrouping()
        {

        }

        public static void MEPWraping(Document doc, IList<MEPCurve> mEPCurves, int structDistance)
        {
            if (Tools.IsHorizontal(mEPCurves.First()))
            {
                double pointY = Tools.GetMEPCurveCentrePoint(mEPCurves.First()).Y + mEPCurves.First().ParameterWidth() - structDistance / 304.8;
                //TaskDialog.Show("asda", mEPCurves.First().Id.ToString());
                bool flag = false;
                using (Transaction tran = new Transaction(doc, "管线换行"))
                {
                    tran.Start();
                    XYZ tarPoint = null;
                    for (int i = 1; i < mEPCurves.Count; i++)
                    {
                        if (flag)
                        {
                            tarPoint += new XYZ(0, -mEPCurves[i].ParameterWidth() - mEPCurves[i - 1].ParameterWidth() - 100 / 304.8, 0);
                            Tools.MoveMEPCurve(doc, mEPCurves[i], tarPoint);
                        }
                        if (Tools.GetMEPCurveCentrePoint(mEPCurves[i]).Y - mEPCurves[i].ParameterWidth() < pointY)
                        {
                            //TaskDialog.Show("asd",Tools.GetMEPCurveCentrePoint(mEPCurves[i]).Y+"   "+ mEPCurves[i].ParameterWidth()+"    "+pointY);
                            XYZ offset = new XYZ(0, mEPCurves.First().ParameterWidth() - mEPCurves[i].ParameterWidth(), -100 / 304.8 - mEPCurves[i].ParameterWidth() - mEPCurves.First().ParameterWidth());
                            tarPoint = Tools.GetMEPCurveCentrePoint(mEPCurves.First()) + offset;
                            Tools.MoveMEPCurve(doc, mEPCurves[i], tarPoint);
                            flag = true;
                        }
                    }
                    tran.Commit();
                }
            }
            else

            {
                double pointX = Tools.GetMEPCurveCentrePoint(mEPCurves.First()).X + mEPCurves.First().ParameterWidth() + structDistance / 304.8;
                //TaskDialog.Show("asda", mEPCurves.First().Id.ToString());
                bool flag = false;
                using (Transaction tran = new Transaction(doc, "管线换行"))
                {
                    tran.Start();
                    XYZ tarPoint = null;
                    for (int i = 1; i < mEPCurves.Count; i++)
                    {
                        if (flag)
                        {
                            tarPoint += new XYZ(mEPCurves[i].ParameterWidth() + mEPCurves[i - 1].ParameterWidth() + 100 / 304.8, 0, 0);
                            Tools.MoveMEPCurve(doc, mEPCurves[i], tarPoint);
                        }
                        if (Tools.GetMEPCurveCentrePoint(mEPCurves[i]).X + mEPCurves[i].ParameterWidth() > pointX)
                        {
                            //TaskDialog.Show("asd",Tools.GetMEPCurveCentrePoint(mEPCurves[i]).Y+"   "+ mEPCurves[i].ParameterWidth()+"    "+pointY);
                            XYZ offset = new XYZ(mEPCurves.First().ParameterWidth() - mEPCurves[i].ParameterWidth(), 0, -100 / 304.8 - mEPCurves[i].ParameterWidth() - mEPCurves.First().ParameterWidth());
                            tarPoint = Tools.GetMEPCurveCentrePoint(mEPCurves.First()) + offset;
                            Tools.MoveMEPCurve(doc, mEPCurves[i], tarPoint);
                            flag = true;
                        }
                    }
                    tran.Commit();
                }
            }
        }

    }
}
