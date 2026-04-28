---
kind: method
id: M:Autodesk.Revit.DB.Curve.MakeBound(System.Double,System.Double)
zh: 曲线
source: html/f9bc51b4-50a3-de79-4d7e-401ab2dbebb2.htm
---
# Autodesk.Revit.DB.Curve.MakeBound Method

**中文**: 曲线

Changes the bounds of this curve to the specified values.

## Syntax (C#)
```csharp
public void MakeBound(
	double startParameter,
	double endParameter
)
```

## Parameters
- **startParameter** (`System.Double`) - The new parameter of the start point.
- **endParameter** (`System.Double`) - The new parameter of the end point.

## Remarks
If the curve is marked as read-only (because it was extracted directly from
a Revit element or collection/aggregation object), calling this method
causes the object to be changed to carry a disconnected copy of the original curve. The
modification will not affect the original curve or the object that supplied it.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the specified values are infinite.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when endParameter is smaller than startParameter.

