---
kind: method
id: M:Autodesk.Revit.DB.Curve.ComputeNormalizedParameter(System.Double)
zh: 曲线
source: html/d42c45a0-7525-aab6-2527-16148dd6dcc1.htm
---
# Autodesk.Revit.DB.Curve.ComputeNormalizedParameter Method

**中文**: 曲线

Computes the normalized curve parameter from the raw parameter.

## Syntax (C#)
```csharp
public double ComputeNormalizedParameter(
	double rawParameter
)
```

## Parameters
- **rawParameter** (`System.Double`) - The raw parameter.

## Returns
The real number equal to the normalized curve parameter.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when rawParameter is infinite.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the curve is unbound.

