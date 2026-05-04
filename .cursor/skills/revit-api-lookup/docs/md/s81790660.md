---
kind: method
id: M:Autodesk.Revit.DB.Face.ComputeNormal(Autodesk.Revit.DB.UV)
source: html/15377d5b-d369-2e09-98ef-ca0eb0af86a1.htm
---
# Autodesk.Revit.DB.Face.ComputeNormal Method

Returns the normal vector for the face at the given point.

## Syntax (C#)
```csharp
public XYZ ComputeNormal(
	UV point
)
```

## Parameters
- **point** (`Autodesk.Revit.DB.UV`) - The parameters to be evaluated, in natural parameterization of the face.

## Returns
The normal vector. This vector will be normalized.

## Remarks
Differs from the normal returned from ComputeDerivatives(UV) in that this vector is the "face normal" vector. 
It will always be oriented to point out of a solid that contains the face.

