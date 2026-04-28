---
kind: method
id: M:Autodesk.Revit.DB.Curve.Project(Autodesk.Revit.DB.XYZ)
zh: 项目
source: html/b87fc3e4-ea25-2a75-5b5a-53065b099d2a.htm
---
# Autodesk.Revit.DB.Curve.Project Method

**中文**: 项目

Projects the specified point on this curve.

## Syntax (C#)
```csharp
public IntersectionResult Project(
	XYZ point
)
```

## Parameters
- **point** (`Autodesk.Revit.DB.XYZ`) - The point to be projected.

## Returns
Geometric information if projection is successful.

## Remarks
The following is the meaning of every IntersectionResult's members:
 XYZPoint is the nearest point on the curve; Parameter is the unnormalized parameter on the curve (use ComputeNormalizedParameter to compute the normalized value) Distance is the distance from the point to the curve (equivalent to Distance).

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the curve is an arc and either its radius is zero or the input point is the center of the arc.
Thrown when the curve is an elliptical arc and the input point is one of the foci of the elliptical arc.

