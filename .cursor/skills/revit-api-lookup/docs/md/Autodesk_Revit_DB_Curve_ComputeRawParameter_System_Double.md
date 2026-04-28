---
kind: method
id: M:Autodesk.Revit.DB.Curve.ComputeRawParameter(System.Double)
zh: 曲线
source: html/ac00deb9-9e8d-6bcb-60ac-b6f6a7520ea2.htm
---
# Autodesk.Revit.DB.Curve.ComputeRawParameter Method

**中文**: 曲线

Computes the raw parameter from the normalized parameter.

## Syntax (C#)
```csharp
public double ComputeRawParameter(
	double normalizedParameter
)
```

## Parameters
- **normalizedParameter** (`System.Double`) - The normalized parameter.

## Returns
The real number equal to the raw curve parameter.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when normalizedParameter is infinite.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the curve is unbound.

