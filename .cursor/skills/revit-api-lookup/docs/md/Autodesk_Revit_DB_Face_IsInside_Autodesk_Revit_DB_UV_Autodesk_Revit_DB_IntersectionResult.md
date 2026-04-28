---
kind: method
id: M:Autodesk.Revit.DB.Face.IsInside(Autodesk.Revit.DB.UV,Autodesk.Revit.DB.IntersectionResult@)
source: html/646e7606-b2e6-b3cc-d808-e4b157e5ffa7.htm
---
# Autodesk.Revit.DB.Face.IsInside Method

Indicates whether the specified point is within this face and outputs additional information about the point location.

## Syntax (C#)
```csharp
public bool IsInside(
	UV point,
	out IntersectionResult result
)
```

## Parameters
- **point** (`Autodesk.Revit.DB.UV`) - The parameters to be evaluated, in natural parameterization of the face.
- **result** (`Autodesk.Revit.DB.IntersectionResult %`) - Provides more information only when the point is on the edge; otherwise, Nothing nullptr a null reference ( Nothing in Visual Basic) .

## Returns
True if within this face or on its boundary, otherwise False.

## Remarks
The following is the meaning of the IntersectionResult members when the point is on the edge:
 EdgeObject is the edge that the point lies on EdgeParameter is the parameter of the point on the edge nearest to the UV point UV is the specified point

