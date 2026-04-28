# Sample Snippet: SplitSubSlab

Source project: `existingCodes\品成插件源代码\土建\SplitSubSlab\SplitSubSlab`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI.Selection;

namespace SplitSubSlab
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;

            //视图判断
            if (!(doc.ActiveView is View3D))
            {
                message = "请在三维视图下运行！";
                return Result.Cancelled;
            }

            ////洞口多loop情况
            //Reference reference = sel.PickObject(ObjectType.Element, new OpeningSelectFilter());
            //Opening ops = doc.GetElement(reference) as Opening;
            //List<List<Curve>> loops = DivideBoundaryLoops(ops.BoundaryCurves);
            //TaskDialog.Show("R", loops.Count().ToString());

            while (true)
            {
                try
                {
                    //选择洞口
                    Reference reference = sel.PickObject(ObjectType.Element, new OpeningSelectFilter());
                    Opening ops = doc.GetElement(reference) as Opening;

                    //宿主板
                    Floor hostFloor = ops.Host as Floor;
                    ElementId levelId = hostFloor.get_Parameter(BuiltInParameter.LEVEL_PARAM).AsElementId();
                    Level level = doc.GetElement(levelId) as Level;
                    FloorType floorType = hostFloor.FloorType;
                    double baseOffset = hostFloor.get_Parameter(BuiltInParameter.FLOOR_HEIGHTABOVELEVEL_PARAM).AsDouble();

                    List<XYZ> vertexs = new List<XYZ>();

                    //CurveArray profile = ops.BoundaryCurves;
                    //洞口的BoundaryCurves返回的CurveArray顺序打乱了，需要重排
                    //Q:Autodesk Revit Argument Exception, The curves do not form a closed contiguous loop
                    //A:Your curves are probably not sorted into the correct contiguous order.
                    //https://stackoverflow.com/questions/48271079/autodesk-revit-argument-exception-the-curves-do-not-form-a-closed-contiguous-lo
                    //https://github.com/jeremytammik/RoomEditorApp/blob/master/RoomEditorApp/ContiguousCurveSorter.cs
                    List<Curve> curves = new List<Curve>();
                    foreach (Curve item in ops.BoundaryCurves)
                    {
                        curves.Add(item);
                    }
                    CurveUtils.SortCurvesContiguous(doc.Application.Create, curves, false);
                    CurveArray profile = uiapp.Application.Create.NewCurveArray();
                    foreach (Curve item in curves)
                    {
                        //收集顶点
                        vertexs.Add(item.GetEndPoint(0));
                        profile.Append(item.CreateTransformed(Transform.CreateTranslation(XYZ.BasisZ * 10.0)));
                    }

                    //创建板
                    Floor newFloor = null;
                    using (Transaction tran = new Transaction(doc, "SubSlab_Create"))
                    {
                        tran.Start();
                        newFloor = doc.Create.NewFloor(profile, floorType, level, false, XYZ.BasisZ);
                        newFloor.get_Parameter(BuiltInParameter.FLOOR_HEIGHTABOVELEVEL_PARAM).Set(baseOffset);
                        tran.Commit();
                    }

                    //如果宿主板是平的，已经可以了
                    if (null != hostFloor.SlabShapeEditor)
                    {
                        if (hostFloor.SlabShapeEditor.SlabShapeVertices.Size == 0)
                        {
                            continue;
                        }
                    }
                    else
// ... truncated ...
```

## ContiguousCurveSorter.cs

```csharp
using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SplitSubSlab
{
    static class CurveGetEnpointExtension
    {
        static public XYZ GetEndPoint(
          this Curve curve,
          int i)
        {
            return curve.GetEndPoint(i);
        }
    }

    /// <summary>
    /// Curve loop utilities supporting resorting and 
    /// orientation of curves to form a contiguous 
    /// closed loop.
    /// </summary>
    class CurveUtils
    {
        const double _inch = 1.0 / 12.0;
        const double _sixteenth = _inch / 16.0;

        public enum FailureCondition
        {
            Success,
            CurvesNotContigous,
            CurveLoopAboveTarget,
            NoIntersection
        };

        /// <summary>
        /// Predicate to report whether the given curve 
        /// type is supported by this utility class.
        /// </summary>
        /// <param name="curve">The curve.</param>
        /// <returns>True if the curve type is supported, 
        /// false otherwise.</returns>
        public static bool IsSupported(
          Curve curve)
        {
            return curve is Line || curve is Arc;
        }

        /// <summary>
        /// Create a new curve with the same 
        /// geometry in the reverse direction.
        /// </summary>
        /// <param name="orig">The original curve.</param>
        /// <returns>The reversed curve.</returns>
        /// <throws cref="NotImplementedException">If the 
        /// curve type is not supported by this utility.</throws>
        static Curve CreateReversedCurve(
          Autodesk.Revit.Creation.Application creapp,
          Curve orig)
        {
            if (!IsSupported(orig))
            {
                throw new NotImplementedException(
                  "CreateReversedCurve for type "
                  + orig.GetType().Name);
            }

            if (orig is Line)
            {
                return Line.CreateBound(
                  orig.GetEndPoint(1),
                  orig.GetEndPoint(0));
            }
            else if (orig is Arc)
            {
                return Arc.Create(orig.GetEndPoint(1),
                  orig.GetEndPoint(0),
                  orig.Evaluate(0.5, true));
            }
            else
            {
                throw new Exception(
                  "CreateReversedCurve - Unreachable");
            }
        }

// ... truncated ...
```

