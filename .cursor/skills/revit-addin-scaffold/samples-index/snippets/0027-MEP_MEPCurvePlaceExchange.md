# Sample Snippet: MEP_MEPCurvePlaceExchange

Source project: `existingCodes\品成插件源代码\机电\MEP_MEPCurvePlaceExchange\MEP_MEPCurvePlaceExchange`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
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

```

## Utils.cs

```csharp
using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MEP_MEPCurvePlaceExchange
{
    class Utils
    {
        #region 传入直线上两点和线外一点，得到线外点在直线上的投影点
        public static XYZ GetProjectivePoint(XYZ standardStartPoint, XYZ standardEndPoint, XYZ modifyStartPoint)
        {
            XYZ pLine = new XYZ();
            double k = (standardEndPoint.Y - standardStartPoint.Y) / (standardEndPoint.X - standardStartPoint.X);
            if (Math.Abs(k) < 0.1) //if (k == 0)
            {
                pLine = new XYZ(modifyStartPoint.X, standardStartPoint.Y, modifyStartPoint.Z);

            }
            else if (Math.Abs(standardEndPoint.X - standardStartPoint.X) < 0.1)
            {
                pLine = new XYZ(standardEndPoint.X, modifyStartPoint.Y, modifyStartPoint.Z);
            }
            else
            {
                double x = (k * (standardStartPoint.X) + ((modifyStartPoint.X) / k) + modifyStartPoint.Y - standardStartPoint.Y) / (1 / k + k);
                double y = -1 / k * (x - modifyStartPoint.X) + modifyStartPoint.Y;
                pLine = new XYZ(x, y, modifyStartPoint.Z);

            }
            return pLine;
        }

        #endregion

    }
}

```

