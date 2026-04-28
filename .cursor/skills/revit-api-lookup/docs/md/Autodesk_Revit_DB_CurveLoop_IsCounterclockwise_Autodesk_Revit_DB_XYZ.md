---
kind: method
id: M:Autodesk.Revit.DB.CurveLoop.IsCounterclockwise(Autodesk.Revit.DB.XYZ)
source: html/ca966f5d-7db8-b28a-928e-12063dd143e6.htm
---
# Autodesk.Revit.DB.CurveLoop.IsCounterclockwise Method

Determines if this CurveLoop is oriented counter-clockwise (CCW) or clockwise (CW) with
 respect to the specified 3D direction.

## Syntax (C#)
```csharp
public bool IsCounterclockwise(
	XYZ normal
)
```

## Parameters
- **normal** (`Autodesk.Revit.DB.XYZ`) - The normal vector to the plane used for this determination.

## Returns
True if the curve loop is oriented counter-clockwise with respect to the specified 3D direction,
 false if the loop is oriented clockwise.

## Remarks
CCW means that the projection of the CurveLoop onto a plane having "normal" as its oriented normal is CCW.
 This method should only be called if the loop is closed and has a non-singular projection onto the plane
 (i.e., the projection should have no self-intersections and should not be degenerate or even
 nearly degenerate). The return value in other cases is indeterminate.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The curve loop is open or consists of a single unbound curve; counterclockwise determination has no meaning.

