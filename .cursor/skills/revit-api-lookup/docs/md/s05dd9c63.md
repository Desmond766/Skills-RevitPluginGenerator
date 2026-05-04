---
kind: method
id: M:Autodesk.Revit.DB.Curve.GetEndParameter(System.Int32)
zh: 曲线
source: html/0f4b2c25-35f8-4e3c-c71a-0d41fb6935ce.htm
---
# Autodesk.Revit.DB.Curve.GetEndParameter Method

**中文**: 曲线

Returns the raw parameter value at the start or end of this curve.

## Syntax (C#)
```csharp
public double GetEndParameter(
	int index
)
```

## Parameters
- **index** (`System.Int32`) - 0 for the start or 1 for end of the curve.

## Returns
The parameter.

## Remarks
The start and end value of the parameter can be any value (as it is determined by the system based on the inputs).
 For curves with regular curvature like lines and arcs, the raw parameter can be used to measure along the curve in Revit's default units (feet).
 Raw parameters are also the only way to evaluate points along unbound curves.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - curve is unbound and does not have start and end points.
 -or-
 index must be 0 for the start of the curve or 1 for the end.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was NULL

