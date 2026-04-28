---
kind: method
id: M:Autodesk.Revit.DB.Edge.ComputeDerivatives(System.Double)
source: html/42136b97-800d-5311-df26-3c7876049c68.htm
---
# Autodesk.Revit.DB.Edge.ComputeDerivatives Method

Returns the vectors describing the edge at the specified parameter.

## Syntax (C#)
```csharp
public Transform ComputeDerivatives(
	double parameter
)
```

## Parameters
- **parameter** (`System.Double`) - The parameter to be evaluated.

## Returns
The transformation containing a tangent vector, derivative of tangent vector, and bi-normal vector.

## Remarks
The following is the meaning of the transformation members:
 Origin is the point on the edge (equivalent to Evaluate); BasisX is the tangent vector (the first derivative); BasisY is the second derivative; BasisZ is the bi-normal vector (tangent x normal). Normal and bi-normal are zero if the edge is straight at the point.
None of the vectors are normalized.

