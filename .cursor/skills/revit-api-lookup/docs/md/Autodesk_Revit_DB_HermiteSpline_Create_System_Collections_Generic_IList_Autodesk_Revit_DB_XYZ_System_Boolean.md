---
kind: method
id: M:Autodesk.Revit.DB.HermiteSpline.Create(System.Collections.Generic.IList{Autodesk.Revit.DB.XYZ},System.Boolean)
zh: 创建、新建、生成、建立、新增
source: html/89eb1cc7-515a-839c-dc7a-9d52879b451f.htm
---
# Autodesk.Revit.DB.HermiteSpline.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a Hermite spline with default tangency at its endpoints.

## Syntax (C#)
```csharp
public static HermiteSpline Create(
	IList<XYZ> controlPoints,
	bool periodic
)
```

## Parameters
- **controlPoints** (`System.Collections.Generic.IList < XYZ >`) - The control points of the Hermite spline.
- **periodic** (`System.Boolean`) - True if the Hermite spline is to be periodic, false otherwise.

## Returns
The new HermiteSpline object.

## Remarks
The tangents at the ends of the spline are computed from the control points.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The control points array is invalid, because it doesn't contain the minimum number of points (2).
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was NULL
- **Autodesk.Revit.Exceptions.ArgumentsInconsistentException** - Curve length is too small for Revit's tolerance (as identified by Application.ShortCurveTolerance).
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Unable to construct valid HermiteSpline from given inputs.

