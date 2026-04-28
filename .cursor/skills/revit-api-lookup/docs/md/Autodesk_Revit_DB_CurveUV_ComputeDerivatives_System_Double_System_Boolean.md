---
kind: method
id: M:Autodesk.Revit.DB.CurveUV.ComputeDerivatives(System.Double,System.Boolean)
source: html/ed10dba7-d0e6-fc6f-9cf6-f1e28946eb2f.htm
---
# Autodesk.Revit.DB.CurveUV.ComputeDerivatives Method

Computes the first derivative, the second derivative and the unit tangent vector at the specified parameter along the curve.

## Syntax (C#)
```csharp
public IList<UV> ComputeDerivatives(
	double parameter,
	bool normalized
)
```

## Parameters
- **parameter** (`System.Double`) - The specified parameter along the curve.
- **normalized** (`System.Boolean`) - If false, parameter is interpreted as natural parameterization of the curve. If true, param is expected to be in [0,1] interval mapped to the bounds of the curve. Setting to true is valid only if the curve is bound.

## Returns
The array containing three members: the first derivative (at index [0]), the second derivative (at index [1]) and the unit tangent vector (at index [2]).

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given value for parameter is not finite
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The curve cannot be evaluated as normalized because it is unbound.
 -or-
 The parameter is not a valid value for normalized evaluation.

