---
kind: method
id: M:Autodesk.Revit.DB.Curve.Distance(Autodesk.Revit.DB.XYZ)
zh: 曲线
source: html/95efa592-d444-acb8-6460-e2757b96e053.htm
---
# Autodesk.Revit.DB.Curve.Distance Method

**中文**: 曲线

Returns the shortest distance from the specified point to this curve.

## Syntax (C#)
```csharp
public double Distance(
	XYZ point
)
```

## Parameters
- **point** (`Autodesk.Revit.DB.XYZ`) - The specified point.

## Returns
The real number equal to the shortest distance.

## Remarks
Returns the distance from the closest point on the curve to the specified point.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when failed to find the closest point on the curve.

