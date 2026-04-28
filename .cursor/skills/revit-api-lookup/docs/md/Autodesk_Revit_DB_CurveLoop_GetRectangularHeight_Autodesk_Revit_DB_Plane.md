---
kind: method
id: M:Autodesk.Revit.DB.CurveLoop.GetRectangularHeight(Autodesk.Revit.DB.Plane)
source: html/f4bafc6a-1218-6c24-e806-c4d92204cbaa.htm
---
# Autodesk.Revit.DB.CurveLoop.GetRectangularHeight Method

Returns the width of a curve loop if it is rectangular with respect to the projection plane.

## Syntax (C#)
```csharp
public double GetRectangularHeight(
	Plane plane
)
```

## Parameters
- **plane** (`Autodesk.Revit.DB.Plane`) - The plane to which the curves will be projected.

## Returns
The height.

## Remarks
The height is determined by the V extents of the UV curve created by from the curve loop plane.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The curve loop is not rectangular when projected to the input plane.

