---
kind: method
id: M:Autodesk.Revit.DB.BoundaryValidation.IsValidBoundaryOnView(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,System.Collections.Generic.IList{Autodesk.Revit.DB.CurveLoop})
source: html/35ee6236-a777-c509-f53a-f169eb5ecee8.htm
---
# Autodesk.Revit.DB.BoundaryValidation.IsValidBoundaryOnView Method

Indicates if the given curve loops compose a valid boundary on the view's detail sketch plane.

## Syntax (C#)
```csharp
public static bool IsValidBoundaryOnView(
	Document document,
	ElementId viewId,
	IList<CurveLoop> curveLoops
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **viewId** (`Autodesk.Revit.DB.ElementId`) - The view Id.
- **curveLoops** (`System.Collections.Generic.IList < CurveLoop >`) - The curve loops to be checked.

## Returns
True if the given curve loops are valid as described above, false otherwise.

## Remarks
The curve loops are valid if projections of the loops onto the views's detail sketch plane do not intersect each other;
 each curve loop is closed; input curves do not contain any helical curve;
 and each loop is planar and lies on a plane parallel to the views's detail sketch plane, but not necessarily the same plane.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

