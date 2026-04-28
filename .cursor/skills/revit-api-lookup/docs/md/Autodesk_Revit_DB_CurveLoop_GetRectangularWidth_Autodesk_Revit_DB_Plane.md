---
kind: method
id: M:Autodesk.Revit.DB.CurveLoop.GetRectangularWidth(Autodesk.Revit.DB.Plane)
source: html/dc6685c1-6c19-34a7-dd7f-5d37b7446649.htm
---
# Autodesk.Revit.DB.CurveLoop.GetRectangularWidth Method

Returns the width of a curve loop if it is rectangular with respect to the projection plane.

## Syntax (C#)
```csharp
public double GetRectangularWidth(
	Plane plane
)
```

## Parameters
- **plane** (`Autodesk.Revit.DB.Plane`) - The plane to which the curves will be projected.

## Returns
The width.

## Remarks
The width is determined by the U extents of the UV curve created by from the curve loop plane.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The curve loop is not rectangular when projected to the input plane.

