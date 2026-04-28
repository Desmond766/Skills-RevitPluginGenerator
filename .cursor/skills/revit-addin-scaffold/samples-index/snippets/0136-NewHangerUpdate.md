# Sample Snippet: NewHangerUpdate

Source project: `existingCodes\梁涛插件源代码\4.吊架布置\NewHangerUpdate\NewHangerUpdate`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using RevitUtils;
using System.Windows.Controls;
using System.Windows.Forms;
using Autodesk.Revit.Exceptions;
using OperationCanceledException = Autodesk.Revit.Exceptions.OperationCanceledException;

namespace NewHangerUpdate
{
    [Transaction(TransactionMode.Manual)]
    [Serializable]
    public class Command : MarshalByRefObject, IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;

            //var refers = sel.PickObjects(ObjectType.Element, new MEPFilter());
            //var meps = refers.Select(r1 => doc.GetElement(r1) as MEPCurve).ToList();
            //MEPCurve mEPCurve1;
            //MEPCurve mEPCurve2;
            //Utils.GetOutermostMEPCurves(meps, out mEPCurve1, out mEPCurve2);
            //if (mEPCurve1 != null)
            //{
            //    sel.SetElementIds(new ElementId[] { mEPCurve1.Id, mEPCurve2.Id });
            //}

            //var hangerReference = sel.PickObject(ObjectType.Element);
            //Element hanger2 = doc.GetElement(hangerReference);
            //XYZ point2 = (hanger2.Location as LocationPoint).Point;
            //point2 = new XYZ(point2.X, point2.Y, 0);

            //XYZ cp = Utils.GetMEPCenterPoint(point2, mEPCurve1, mEPCurve2);
            //TaskDialog.Show("revit", cp + "\n" + point2);

            //using (Transaction t = new Transaction(doc, "Move"))
            //{
            //    t.Start();

            //    hanger2.Location.Move(cp - point2);

            //    t.Commit();
            //}


            //return Result.Succeeded;

            View3D view3d = null;
            if (doc.ActiveView is View3D view3D) view3d = view3D;
            else view3d = ViewUtils.SelectView3D(doc);

            if (view3d == null)
            {
                return Result.Cancelled;
            }

            if (view3d.get_Parameter(BuiltInParameter.VIEW_DETAIL_LEVEL).AsInteger() != (int)ViewDetailLevel.Fine)
            {
                using (Transaction t = new Transaction(doc, "三维视图详细程度设置"))
                {
                    t.Start();
                    view3d.get_Parameter(BuiltInParameter.VIEW_DETAIL_LEVEL).Set((int)ViewDetailLevel.Fine);
                    t.Commit();
                }
            }

            bool isManualSelection;
            double r = 0;
            double rayDis = 0;

            SelWindow selWindow = new SelWindow();
            selWindow.ShowDialog();
            if (selWindow.DialogResult == false)
            {
                return Result.Cancelled;
            }
            isManualSelection = selWindow.IsManualSelection;
// ... truncated ...
```

## Utils.cs

```csharp
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NewHangerUpdate
{
    public class Utils
    {
        public static bool GetOutermostMEPCurves(List<MEPCurve> mEPCurves, out MEPCurve min, out MEPCurve max, out double bottomElevation)
        {
            min = null;
            max = null;
            bottomElevation = double.NaN;
            double minBottom = double.MaxValue;
            if (mEPCurves.Count == 0) return false;

            XYZ lineDir = ((mEPCurves.First().Location as LocationCurve).Curve as Line).Direction;
            XYZ verDir = lineDir.CrossProduct(XYZ.BasisZ).Normalize();

            Dictionary<MEPCurve, double> mepProjections = new Dictionary<MEPCurve, double>();
            foreach (var mepCurve in mEPCurves)
            {
                // 获取最低底部高程
                var bottomPara = mepCurve.LookupParameter("底部高程");
                if (bottomPara != null && bottomPara.StorageType == StorageType.Double && bottomPara.AsDouble() < minBottom)
                {
                    minBottom = bottomPara.AsDouble();
                }

                // 获取管道的中心点（使用定位线的中点）
                LocationCurve locationCurve = mepCurve.Location as LocationCurve;
                if (locationCurve != null)
                {
                    Curve curve = locationCurve.Curve;
                    XYZ pipeCenterPoint = (curve.GetEndPoint(0) + curve.GetEndPoint(1)) / 2.0;

                    double projectionValue = pipeCenterPoint.DotProduct(verDir);

                    mepProjections.Add(mepCurve, projectionValue);
                }
            }

            bottomElevation = minBottom;

            double minProjection = double.MaxValue;
            double maxProjection = double.MinValue;

            foreach (var kvp in mepProjections)
            {
                if (kvp.Value < minProjection)
                {
                    minProjection = kvp.Value;
                    min = kvp.Key;
                }
                if (kvp.Value > maxProjection)
                {
                    maxProjection = kvp.Value;
                    max = kvp.Key;
                }
            }
            return true;
        }

        /// <summary>
        /// 获取两mep之间的中心坐标点
        /// </summary>
        /// <param name="mEPCurve1"></param>
        /// <param name="mEPCurve2"></param>
        /// <returns></returns>
        public static XYZ GetMEPCenterPoint(XYZ point, MEPCurve mEPCurve1, MEPCurve mEPCurve2, out double distance)
        {
            point = new XYZ(point.X, point.Y, 0);

            double halfWidth1;
            double halfWidth2;
            if (mEPCurve1 is Pipe)
            {
                //halfWidth1 = mEPCurve1.get_Parameter(BuiltInParameter.RBS_PIPE_DIAMETER_PARAM).AsDouble() / 2;
                halfWidth1 = mEPCurve1.get_Parameter(BuiltInParameter.RBS_PIPE_OUTER_DIAMETER).AsDouble() / 2;
            }
            else
            {
                halfWidth1 = (mEPCurve1.LookupParameter("直径")?.AsDouble() ?? mEPCurve1.Width) / 2;
            }
// ... truncated ...
```

