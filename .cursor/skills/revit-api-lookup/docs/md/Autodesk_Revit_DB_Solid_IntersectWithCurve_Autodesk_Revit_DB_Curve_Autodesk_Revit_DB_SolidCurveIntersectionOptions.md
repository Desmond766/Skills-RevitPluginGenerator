---
kind: method
id: M:Autodesk.Revit.DB.Solid.IntersectWithCurve(Autodesk.Revit.DB.Curve,Autodesk.Revit.DB.SolidCurveIntersectionOptions)
source: html/8e04f956-b262-7f3e-59cb-d2c02c2769d7.htm
---
# Autodesk.Revit.DB.Solid.IntersectWithCurve Method

Calculates and returns the intersection between a curve and this solid.

## Syntax (C#)
```csharp
public SolidCurveIntersection IntersectWithCurve(
	Curve curve,
	SolidCurveIntersectionOptions options
)
```

## Parameters
- **curve** (`Autodesk.Revit.DB.Curve`) - The curve.
- **options** (`Autodesk.Revit.DB.SolidCurveIntersectionOptions`) - The options. If NULL, the default options will be used.

## Returns
The intersection results.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input curve is not bound.
 -or-
 The input solid is not a closed volume.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was NULL

