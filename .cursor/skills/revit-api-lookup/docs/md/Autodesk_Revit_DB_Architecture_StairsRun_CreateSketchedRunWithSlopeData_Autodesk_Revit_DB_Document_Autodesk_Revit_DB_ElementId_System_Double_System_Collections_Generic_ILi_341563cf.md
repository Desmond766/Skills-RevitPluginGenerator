---
kind: method
id: M:Autodesk.Revit.DB.Architecture.StairsRun.CreateSketchedRunWithSlopeData(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,System.Double,System.Collections.Generic.IList{Autodesk.Revit.DB.SketchedStairsCurveData},System.Collections.Generic.IList{Autodesk.Revit.DB.Curve},System.Collections.Generic.IList{Autodesk.Revit.DB.Curve})
source: html/617ef98f-bb7b-c4ec-0342-bf2b4d743ff8.htm
---
# Autodesk.Revit.DB.Architecture.StairsRun.CreateSketchedRunWithSlopeData Method

Creates a sketched run in the project document by providing a group of boundary curves and riser curves, specifying slope type and height for boundary curves.

## Syntax (C#)
```csharp
public static StairsRun CreateSketchedRunWithSlopeData(
	Document document,
	ElementId stairsId,
	double baseElevation,
	IList<SketchedStairsCurveData> boundaryCurves,
	IList<Curve> riserCurves,
	IList<Curve> stairsPath
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **stairsId** (`Autodesk.Revit.DB.ElementId`) - The stairs that the new stairs run will belong to.
- **baseElevation** (`System.Double`) - Base elevation of the new stairs run. It has following restrictions:
 The base elevation is relative to the base elevation of the stairs. The base elevation will be rounded automatically to a multiple of the riser height.
- **boundaryCurves** (`System.Collections.Generic.IList < SketchedStairsCurveData >`) - The boundary curves of the new stairs run, specifying slope type and height. The curves have following restriction:
 The curves should consist of bound Line or Arc curves only. The curves should be a pair of curve chains(two sets of curves which connect end-to-end
 to form the left and right boundaries). The left and right boundary chain curves should not connect to each other. They can be single curves or multi-segmented curves(for example, straight lines and
 arcs connected).
- **riserCurves** (`System.Collections.Generic.IList < Curve >`) - The riser curves of the new stairs run. The curves have following restriction:
 The curves should consist of bound Line or Arc curves only. The curves should be able to make at least two curve chains. The curves in each chain should connect between the left and right boundaries.
- **stairsPath** (`System.Collections.Generic.IList < Curve >`) - The stair path curves of the new stairs run. The curves have following restriction:
 The curves should consist of bound Line or Arc curves only. The curves should be able to make one curve chain. The curve chain should have intersection with all riser curve chains. The curves should connect between the first and last riser chain curves.

## Returns
The new stairs run.

## Remarks
The run type of the new stairs run will be determined by the specified stairs.
 The new stairs run and the document will be regenerated.
 This should be run from within an open transaction.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The stairsId is not a valid stairs element.
 -or-
 The input riserCurves is empty.
 -or-
 The input stairsPath is empty.
 -or-
 The input boundaryCurves is empty.
 The input boundaryCurves contains at least one curve which is not a bound Line or bound Arc
 and is not supported for this operation.
 -or-
 The input riserCurves contains at least one curve which is not a bound Line or bound Arc
 and is not supported for this operation.
 -or-
 The input stairsPath contains at least one curve which is not a bound Line or bound Arc
 and is not supported for this operation.
 -or-
 The riserCurves or boundaryCurves or stairsPath don't meet restrictions to create sketch run.
 -or-
 The boundaryCurves has invalid curve used as sketch boundary curve.
 -or-
 The riserCurves has invalid curve used as sketch riser curve.
 -or-
 The stairsPath has invalid curve used as sketch stairspath curve.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The given value for baseElevation must be no more than 30000 feet in absolute value.
 -or-
 The baseElevation doesn't meet the restriction that bottom of run should not be lower than bottom of stairs.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The stairs element represented by stairsId is not in an active StairsEditScope.
 New components cannot be added to it.
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.
- **Autodesk.Revit.Exceptions.RegenerationFailedException** - The boundaryCurves, riserCurves, stairsPath don't meet restrictions to generate sketch run.

