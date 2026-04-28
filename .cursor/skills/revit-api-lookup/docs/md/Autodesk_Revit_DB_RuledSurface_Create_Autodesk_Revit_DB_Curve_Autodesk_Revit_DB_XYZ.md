---
kind: method
id: M:Autodesk.Revit.DB.RuledSurface.Create(Autodesk.Revit.DB.Curve,Autodesk.Revit.DB.XYZ)
zh: 创建、新建、生成、建立、新增
source: html/5dc0d801-bff6-e9d8-98b1-f3f3dbe475c2.htm
---
# Autodesk.Revit.DB.RuledSurface.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a Surface object coincident with the ruled surface joining a bounded generating curve to a point.

## Syntax (C#)
```csharp
public static Surface Create(
	Curve profileCurve,
	XYZ point
)
```

## Parameters
- **profileCurve** (`Autodesk.Revit.DB.Curve`) - The profile curve; must be bounded and non-degenerate.
- **point** (`Autodesk.Revit.DB.XYZ`) - The point. Expected to lie within the Revit design limits IsWithinLengthLimits(XYZ) .

## Returns
The created surface. Note that this surface may not be of type RuledSurf.

## Remarks
The returned surface may not be of type RuledSurf - this function will create a surface of the simplest possible
 type (Plane, CylindricalSurface, etc.) that can be used to represent the given ruled surface.
 Given that the surface may be simplified, this function does not guarantee any particular parameterization of the surface.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input profileCurve is not bound.
 -or-
 The profileCurve is degenerate (its length is too close to zero).
 -or-
 The input point lies outside of Revit design limits.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

