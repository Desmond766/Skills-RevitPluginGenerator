---
kind: method
id: M:Autodesk.Revit.DB.RevolvedSurface.Create(Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.Curve)
zh: 创建、新建、生成、建立、新增
source: html/98484dd5-746c-02e1-d8d8-5ad18e250810.htm
---
# Autodesk.Revit.DB.RevolvedSurface.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a Surface object coincident with the surface of revolution defined by an axis and a profile curve.

## Syntax (C#)
```csharp
public static Surface Create(
	XYZ axisBasePoint,
	XYZ axisDirection,
	Curve profileCurve
)
```

## Parameters
- **axisBasePoint** (`Autodesk.Revit.DB.XYZ`) - The base point of the axis of revolution. Expected to lie within the Revit design limits IsWithinLengthLimits(XYZ) .
- **axisDirection** (`Autodesk.Revit.DB.XYZ`) - The direction of the axis.
- **profileCurve** (`Autodesk.Revit.DB.Curve`) - The profile curve, which should satisfy the following conditions:
 It is bounded and non-degenerate. It is co-planar with the axis of revolution. It lies on only one side of the axis. Only the end points of the profile curve can touch the axis.

## Returns
The created surface. Note that this surface may not be of type RevolvedSurface.

## Remarks
The returned surface may not be of type RevolvedSurface - this function will create a surface of the simplest possible
 type (Plane, Cylinder, etc.) that can be used to represent the required surface of revolution.
 Given that the surface may be simplified, this function does not guarantee any particular parameterization of the surface.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input point lies outside of Revit design limits.
 -or-
 The input profile curve is not valid to create a surface revolution around the given axis.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - axisDirection has zero length.

