---
kind: method
id: M:Autodesk.Revit.DB.Face.Project(Autodesk.Revit.DB.XYZ)
zh: 项目
source: html/4bee3e30-74fa-3103-c2f4-d07618fbcedf.htm
---
# Autodesk.Revit.DB.Face.Project Method

**中文**: 项目

Projects the specified point on the face.

## Syntax (C#)
```csharp
public IntersectionResult Project(
	XYZ point
)
```

## Parameters
- **point** (`Autodesk.Revit.DB.XYZ`) - The point to be projected.

## Returns
Geometric information if projection is successful;
if projection fails or the nearest point is outside of this face, returns Nothing nullptr a null reference ( Nothing in Visual Basic) .

## Remarks
The following is the meaning of IntersectionResult's members:
 XYZPoint is the nearest point to the projected point on the face. UVPoint is the UV coordinates of the nearest point on the face. Distance is the distance from the point to the face. EdgeObject is the edge if projected point is near an edge. EdgeParameter is the parameter of the nearest point on the edge.

