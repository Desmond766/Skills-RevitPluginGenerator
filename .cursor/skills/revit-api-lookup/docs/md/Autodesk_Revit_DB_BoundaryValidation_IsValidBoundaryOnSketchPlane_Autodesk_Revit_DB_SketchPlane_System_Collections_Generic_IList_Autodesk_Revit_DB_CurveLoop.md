---
kind: method
id: M:Autodesk.Revit.DB.BoundaryValidation.IsValidBoundaryOnSketchPlane(Autodesk.Revit.DB.SketchPlane,System.Collections.Generic.IList{Autodesk.Revit.DB.CurveLoop})
source: html/b7569e51-3390-b666-1d92-b3994f1b863c.htm
---
# Autodesk.Revit.DB.BoundaryValidation.IsValidBoundaryOnSketchPlane Method

Indicates if the given curve loops compose a valid boundary on the sketch plane.

## Syntax (C#)
```csharp
public static bool IsValidBoundaryOnSketchPlane(
	SketchPlane sketchPlane,
	IList<CurveLoop> curveLoops
)
```

## Parameters
- **sketchPlane** (`Autodesk.Revit.DB.SketchPlane`) - The sketch plane.
- **curveLoops** (`System.Collections.Generic.IList < CurveLoop >`) - The curve loops to be checked.

## Returns
True if the given curve loops are valid as described above, false otherwise.

## Remarks
The curve loops are valid if projections of the loops onto the sketch plane do not intersect each other;
 each curve loop is closed; input curves do not contain any helical curve;
 and each loop is planar and lies on a plane parallel to the sketch plane, but not necessarily the same plane.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

