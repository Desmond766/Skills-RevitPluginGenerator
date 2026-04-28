---
kind: method
id: M:Autodesk.Revit.DB.BoundaryValidation.IsValidHorizontalBoundary(System.Collections.Generic.IList{Autodesk.Revit.DB.CurveLoop})
source: html/4bd740a2-fa9e-24c5-eb53-c0dac642f1e9.htm
---
# Autodesk.Revit.DB.BoundaryValidation.IsValidHorizontalBoundary Method

Identifies whether the given curve loops compose a valid horizontal boundary.

## Syntax (C#)
```csharp
public static bool IsValidHorizontalBoundary(
	IList<CurveLoop> curveLoops
)
```

## Parameters
- **curveLoops** (`System.Collections.Generic.IList < CurveLoop >`) - The curve loops to be checked.

## Returns
True if the given curve loops are valid as described above, false otherwise.

## Remarks
The curve loops are valid if projections of the loops onto a horizontal(XY) plane do not intersect each other;
 each curve loop is closed; input curves do not contain any helical curve;
 and each loop is planar and lies on a plane parallel to the horizontal(XY) plane, but not necessarily the same plane.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

