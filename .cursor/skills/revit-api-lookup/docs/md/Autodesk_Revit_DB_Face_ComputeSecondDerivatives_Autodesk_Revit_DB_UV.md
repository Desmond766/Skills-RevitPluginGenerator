---
kind: method
id: M:Autodesk.Revit.DB.Face.ComputeSecondDerivatives(Autodesk.Revit.DB.UV)
source: html/e1b6ec4d-cc6b-16dc-d442-fe0ee9491a8b.htm
---
# Autodesk.Revit.DB.Face.ComputeSecondDerivatives Method

Returns the second partial derivatives of the face at the specified point.

## Syntax (C#)
```csharp
public FaceSecondDerivatives ComputeSecondDerivatives(
	UV point
)
```

## Parameters
- **point** (`Autodesk.Revit.DB.UV`) - The parameters to be evaluated, in natural parameterization of the face.

## Returns
The second partial derivatives of the face at the specified point.

## Remarks
It does not take the bounding edge loops into account.

