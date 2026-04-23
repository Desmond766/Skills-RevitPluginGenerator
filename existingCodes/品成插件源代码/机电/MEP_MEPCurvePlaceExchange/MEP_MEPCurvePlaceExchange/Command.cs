using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;
using System.Collections;
using System.Diagnostics;
using System.IO;

namespace MEP_MEPCurvePlaceExchange
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {

        public Autodesk.Revit.UI.Result Execute(Autodesk.Revit.UI.ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            #region 判断加密
            //注册验证
            string licFile = string.Format("{0}\\Key.lic",
    System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
            if (!BTAddInHelper.Utils.CheckReg(licFile))
            {
                return Result.Cancelled;
            }
            #endregion

            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;

            while (true)
            {
                try
                {
                    Reference firstPick = sel.PickObject(ObjectType.Element, new MEPCurveSelectionFilter());
                    Element firstEle = doc.GetElement(firstPick);
                    Reference secondPick = sel.PickObject(ObjectType.Element, new MEPCurveSelectionFilter());
                    Element secondEle = doc.GetElement(secondPick);

                    if (firstEle.Id == secondEle.Id)
                    {
                        TaskDialog.Show("警告", "选择的是同一个构件！");
                    }
                    else
                    {
                        //得到构件上的点
                        LocationCurve locationCurve1 = firstEle.Location as LocationCurve;
                        XYZ firstPo = locationCurve1.Curve.GetEndPoint(0);
                        XYZ firstPo1 = locationCurve1.Curve.GetEndPoint(1);
                        LocationCurve locationCurve2 = secondEle.Location as LocationCurve;
                        XYZ secondPo = locationCurve2.Curve.GetEndPoint(0);

                        XYZ newLocation = new XYZ();

                        //构件2在构件1上的投影点
                        XYZ pLine = Utils.GetProjectivePoint(firstPo, firstPo1, secondPo);

                        newLocation = pLine - secondPo;
                        using (Transaction t = new Transaction(doc, "交换位置"))
                        {
                            t.Start();
                            locationCurve2.Move(newLocation);
                            locationCurve1.Move(newLocation.Negate());
                            t.Commit();
                        }
                    }
                }

                catch (Exception ex)
                {
                    if (ex.Message == "The user aborted the pick operation.")
                    {
                        break;
                    }
                }
            }
            return Result.Succeeded;
        }
    }
}
