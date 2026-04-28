---
kind: method
id: M:Autodesk.Revit.DB.Architecture.SiteSubRegion.IsValidBoundary(System.Collections.Generic.IList{Autodesk.Revit.DB.CurveLoop})
source: html/3013294c-0670-b5b5-8ff3-2552e0b76750.htm
---
# Autodesk.Revit.DB.Architecture.SiteSubRegion.IsValidBoundary Method

Identifies whether the given curve loops compose a valid boundary.

## Syntax (C#)
```csharp
public static bool IsValidBoundary(
	IList<CurveLoop> curveLoops
)
```

## Parameters
- **curveLoops** (`System.Collections.Generic.IList < CurveLoop >`) - The curve loops to be checked.

## Returns
True if the given curve loops don't intersect with each other; each curve loop is closed;
 and each loop is planar and lies on a plane parallel to the horizontal(XY) plane.
 Any requirement above is not satisfied or no curve loops contained, returns false.

## Remarks
The curve loops are valid if they don't intersect with each other; each curve loop is closed;
 and each loop is planar and lies on a plane parallel to the horizontal(XY) plane.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

