---
kind: method
id: M:Autodesk.Revit.DB.Curve.ComputeDerivatives(System.Double,System.Boolean)
zh: 曲线
source: html/93092a44-85f1-15be-a618-817c763f8994.htm
---
# Autodesk.Revit.DB.Curve.ComputeDerivatives Method

**中文**: 曲线

Returns the vectors describing the curve at the specified parameter.

## Syntax (C#)
```csharp
public Transform ComputeDerivatives(
	double parameter,
	bool normalized
)
```

## Parameters
- **parameter** (`System.Double`) - The parameter to be evaluated.
- **normalized** (`System.Boolean`) - If false, param is interpreted as natural parameterization of the curve.
 If true, param is expected to be in [0,1] interval mapped to the bounds of the curve. Setting to true is valid only if the curve is bound.

## Returns
The transformation containing the point on the curve, the tangent vector, derivative of tangent vector, and bi-normal vector.

## Remarks
The following is the meaning of the transformation members:
 Origin is the point on the curve (equivalent to Evaluate(Double, Boolean) ).BasisX is the tangent vector (the first derivative).BasisY is the second derivative. Note that for curves where this cannot be uniquely determined (e.g. lines), this will be a Zero vector.BasisZ is the bi-normal vector (tangent x normal). Note that for curves where normal cannot be uniquely determined (e.g. lines), this will be a Zero vector.
 None of the vectors are normalized.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given value for parameter is not finite
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The curve cannot be evaluated as normalized because it is unbound.
 -or-
 The parameter is not a valid value for normalized evaluation.

