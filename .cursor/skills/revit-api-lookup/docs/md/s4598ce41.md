---
kind: method
id: M:Autodesk.Revit.DB.RuledSurface.Create(Autodesk.Revit.DB.Curve,Autodesk.Revit.DB.Curve)
zh: 创建、新建、生成、建立、新增
source: html/55c2212e-c46e-4009-bd47-eb64d5667dcd.htm
---
# Autodesk.Revit.DB.RuledSurface.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a Surface object coincident with the ruled surface joining two bounded generating curves.

## Syntax (C#)
```csharp
public static Surface Create(
	Curve profileCurve1,
	Curve profileCurve2
)
```

## Parameters
- **profileCurve1** (`Autodesk.Revit.DB.Curve`) - The first profile curve; must be bounded and non-degenerate.
- **profileCurve2** (`Autodesk.Revit.DB.Curve`) - The second profile curve; must be bounded and non-degenerate.

## Returns
The created surface. Note that this surface may not be of type RuledSurf.

## Remarks
The returned surface may not be of type RuledSurf - this function will create a surface of the simplest possible
 type (Plane, CylindricalSurface, etc.) that can be used to represent the given ruled surface.
 Given that the surface may be simplified, this function does not guarantee any particular parameterization of the surface.
 The curves should be such that a ruled surface whose rulings connect points on the two curves with the same
 normalized coordinates has no self-intersections or interior singularities.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input profileCurve1 is not bound.
 -or-
 The profileCurve1 is degenerate (its length is too close to zero).
 -or-
 The input profileCurve2 is not bound.
 -or-
 The profileCurve2 is degenerate (its length is too close to zero).
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

