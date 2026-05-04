---
kind: method
id: M:Autodesk.Revit.DB.Face.ComputeDerivatives(Autodesk.Revit.DB.UV)
source: html/77ca18ef-783e-9db5-a37a-2d76f637d1a1.htm
---
# Autodesk.Revit.DB.Face.ComputeDerivatives Method

Returns the first partial derivatives of the underlying surface at the specified point.

## Syntax (C#)
```csharp
public Transform ComputeDerivatives(
	UV point
)
```

## Parameters
- **point** (`Autodesk.Revit.DB.UV`) - The parameters to be evaluated, in natural parameterization of the face.

## Returns
A transformation containing tangent vectors and a normal vector.

## Remarks
The following is the meaning of the transformation members:
 Origin is the point on the face (equivalent to Evaluate(UV) ); BasisX is the tangent vector along the U coordinate (partial derivative with respect to U). BasisY is the tangent vector along the V coordinate (partial derivative with respect to V). BasisZ is the underlying surface's normal vector. This is not necessarily aligned with the normal vector pointing out of a
solid that contains the face, to get that value use ComputeNormal(UV) . 
None of the vectors are normalized.

