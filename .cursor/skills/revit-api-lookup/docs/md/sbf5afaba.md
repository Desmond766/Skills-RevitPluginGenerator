---
kind: method
id: M:Autodesk.Revit.DB.CurveUV.Evaluate(System.Double,System.Boolean)
source: html/ea7d15ea-e248-e217-2900-662be2e4d274.htm
---
# Autodesk.Revit.DB.CurveUV.Evaluate Method

Evaluates and returns the point at the specified parameter along the curve.

## Syntax (C#)
```csharp
public UV Evaluate(
	double parameter,
	bool normalized
)
```

## Parameters
- **parameter** (`System.Double`) - The specified parameter along the curve.
- **normalized** (`System.Boolean`) - If false, parameter is interpreted as natural parameterization of the curve. If true, param is expected to be in [0,1] interval mapped to the bounds of the curve. Setting to true is valid only if the curve is bound.

## Returns
The point evaluated along the curve.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given value for parameter is not finite
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The curve cannot be evaluated as normalized because it is unbound.
 -or-
 The parameter is not a valid value for normalized evaluation.

