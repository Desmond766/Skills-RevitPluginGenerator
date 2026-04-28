---
kind: method
id: M:Autodesk.Revit.DB.Curve.Evaluate(System.Double,System.Boolean)
zh: 曲线
source: html/1145f18e-3e01-60df-e438-e176c38c3ce9.htm
---
# Autodesk.Revit.DB.Curve.Evaluate Method

**中文**: 曲线

Evaluates and returns the point that matches a parameter along the curve.

## Syntax (C#)
```csharp
public XYZ Evaluate(
	double parameter,
	bool normalized
)
```

## Parameters
- **parameter** (`System.Double`) - The parameter to be evaluated.
- **normalized** (`System.Boolean`) - If false, param is interpreted as natural parameterization of the curve.
 If true, param is expected to be in [0,1] interval mapped to the bounds of the curve. Setting to true is valid only if the curve is bound.

## Returns
The point evaluated along the curve.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given value for parameter is not finite
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The curve cannot be evaluated as normalized because it is unbound.
 -or-
 The parameter is not a valid value for normalized evaluation.

