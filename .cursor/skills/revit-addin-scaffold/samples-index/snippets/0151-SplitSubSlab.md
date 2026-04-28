# Sample Snippet: SplitSubSlab

Source project: `existingCodes\梁涛插件源代码\6.不常用\SplitSubSlab\SplitSubSlab`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SplitSubSlab
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication application = commandData.Application;
            Document document = application.ActiveUIDocument.Document;
            Selection selection = application.ActiveUIDocument.Selection;
            //Floor floor1 = document.GetElement(application.ActiveUIDocument.Selection.PickObject(ObjectType.Element)) as Floor;
            //IList<ElementId> elementIds = floor1.GetDependentElements(null);
            //foreach (var item in elementIds)
            //{
            //    Element element = document.GetElement(item);
            //    if (element == null || element.Name == null || element.Category == null) continue;
            //    if (element.Category.Id.IntegerValue == -2000045 && element.Name == "坡度箭头")
            //    {
            //        TaskDialog.Show("p", element.GetType().ToString());
            //    }
            //}
            //return Result.Succeeded;
            bool flag = !(document.ActiveView is View3D);
            Result result;
            if (flag)
            {
                message = "请在三维视图下运行！";
                result =  Result.Cancelled;
            }
            else
            {
                while (true)
                {
                    try
                    {
                        Reference reference = selection.PickObject(ObjectType.Element, new OpeningSelectFilter());
                        Opening opening = document.GetElement(reference) as Opening;
                        Floor floor = opening.Host as Floor;
                        //Transaction transaction1 = new Transaction(document, "111");
                        //transaction1.Start();
                        //ElementTransformUtils.RotateElement(document, floor.Id, Line.CreateBound(new XYZ(), new XYZ() + XYZ.BasisY), 0.5);
                        //transaction1.Commit();
                        ElementId elementId = floor.get_Parameter(BuiltInParameter.LEVEL_PARAM).AsElementId();
                        Level level = document.GetElement(elementId) as Level;
                        FloorType floorType = floor.FloorType;
                        double num = floor.get_Parameter(BuiltInParameter.FLOOR_HEIGHTABOVELEVEL_PARAM).AsDouble();
                        List<XYZ> list = new List<XYZ>();
                        List<Curve> list2 = new List<Curve>();
                        foreach (Curve item in opening.BoundaryCurves)
                        {
                            list2.Add(item);
                        }
                        CurveUtils.SortCurvesContiguous(document.Application, list2, false);
                        CurveArray curveArray = application.Application.Create.NewCurveArray();
                        foreach (Curve current in list2)
                        {
                            list.Add(current.GetEndPoint(0));
                            curveArray.Append(current.CreateTransformed(Transform.CreateTranslation(XYZ.BasisZ * 10.0)));
                        }
                        Floor floor2 = null;
                        TransactionGroup transactionGroup = new TransactionGroup(document, "洞口填板");
                        transactionGroup.Start();
                        bool hasSlopeArrow = false;
                        //Level floorLevel = document.GetElement(floor.LevelId) as Level;
                        double floorHigh = level.Elevation;
                        foreach (ElementId item in floor.GetDependentElements(null))
                        {
                            Element element = document.GetElement(item);
                            if (element is ModelLine && element.Name.Contains("坡度箭头"))
                            {
                                hasSlopeArrow = true;
                                ModelLine modelLine = (ModelLine)element;
                                Line slopedArrow = (modelLine.Location as LocationCurve).Curve as Line;
                                double newZ = slopedArrow.Origin.Z;
                                double slope;
                                if (modelLine.get_Parameter(BuiltInParameter.SPECIFY_SLOPE_OR_OFFSET).AsValueString().Equals("坡度"))
                                {
                                    double newLineSZ;
                                    if (modelLine.LookupParameter("最低处标高").AsValueString().Equals("默认"))
// ... truncated ...
```

## CurveUtils.cs

```csharp
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitSubSlab
{
    internal class CurveUtils
    {
        public enum FailureCondition
        {
            Success,
            CurvesNotContigous,
            CurveLoopAboveTarget,
            NoIntersection
        }
        private const double _inch = 0.083333333333333329;
        private const double _sixteenth = 0.005208333333333333;
        public static bool IsSupported(Curve curve)
        {
            return curve is Line || curve is Arc;
        }
        private static Curve CreateReversedCurve(Application creapp, Curve orig)
        {
            bool flag = !CurveUtils.IsSupported(orig);
            if (flag)
            {
                throw new NotImplementedException("CreateReversedCurve for type " + orig.GetType().Name);
            }
            bool flag2 = orig is Line;
            Curve result;
            if (flag2)
            {
                result = Line.CreateBound(orig.GetEndPoint(1), orig.GetEndPoint(0));
            }
            else
            {
                bool flag3 = orig is Arc;
                if (!flag3)
                {
                    throw new Exception("CreateReversedCurve - Unreachable");
                }
                result = Arc.Create(orig.GetEndPoint(1), orig.GetEndPoint(0), orig.Evaluate(0.5, true));
            }
            return result;
        }
        public static void SortCurvesContiguous(Application creapp, IList<Curve> curves, bool debug_output)
        {
            int count = curves.Count;
            for (int i = 0; i < count; i++)
            {
                Curve curve = curves[i];
                XYZ endPoint = curve.GetEndPoint(1);
                if (debug_output)
                {
                }
                bool flag = i + 1 >= count;
                for (int j = i + 1; j < count; j++)
                {
                    XYZ endPoint2 = curves[j].GetEndPoint(0);
                    bool flag2 = 0.005208333333333333 > endPoint2.DistanceTo(endPoint);
                    if (flag2)
                    {
                        bool flag3 = i + 1 == j;
                        if (flag3)
                        {
                            if (debug_output)
                            {
                                Debug.Print("{0} start point match, no need to swap", new object[]
                                {
                                    j,
                                    i + 1
                                });
                            }
                        }
                        else
                        {
                            if (debug_output)
                            {
                                Debug.Print("{0} start point, swap with {1}", new object[]
                                {
                                    j,
                                    i + 1
                                });
                            }
                            Curve value = curves[i + 1];
// ... truncated ...
```

