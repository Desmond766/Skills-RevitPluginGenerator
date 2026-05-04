---
kind: method
id: M:Autodesk.Revit.DB.HermiteSpline.Create(System.Collections.Generic.IList{Autodesk.Revit.DB.XYZ},System.Boolean,Autodesk.Revit.DB.HermiteSplineTangents)
zh: 创建、新建、生成、建立、新增
source: html/c710affa-a545-38d1-f94e-b569c40a8875.htm
---
# Autodesk.Revit.DB.HermiteSpline.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a Hermite spline with specified tangency at its endpoints.

## Syntax (C#)
```csharp
public static HermiteSpline Create(
	IList<XYZ> controlPoints,
	bool periodic,
	HermiteSplineTangents tangents
)
```

## Parameters
- **controlPoints** (`System.Collections.Generic.IList < XYZ >`) - The control points of the Hermite spline.
- **periodic** (`System.Boolean`) - True if the Hermite spline is to be periodic, false otherwise.
- **tangents** (`Autodesk.Revit.DB.HermiteSplineTangents`) - The object which indicates tangency at the start, the end, or both ends of the curve.

## Returns
The new HermiteSpline object.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The control points array is invalid, because it doesn't contain the minimum number of points (2).
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was NULL
- **Autodesk.Revit.Exceptions.ArgumentsInconsistentException** - Curve length is too small for Revit's tolerance (as identified by Application.ShortCurveTolerance).
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Unable to construct valid HermiteSpline from given inputs.

