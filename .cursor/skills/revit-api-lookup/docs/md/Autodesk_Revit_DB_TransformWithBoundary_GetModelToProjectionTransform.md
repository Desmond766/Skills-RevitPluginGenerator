---
kind: method
id: M:Autodesk.Revit.DB.TransformWithBoundary.GetModelToProjectionTransform
source: html/1742945f-53f5-1843-8781-6f4c7d363788.htm
---
# Autodesk.Revit.DB.TransformWithBoundary.GetModelToProjectionTransform Method

Gets the model space to view projection space transform.

## Syntax (C#)
```csharp
public Transform GetModelToProjectionTransform()
```

## Returns
The model space to view projection space transformation.

## Remarks
The transform can be used to transform points from model space to view projection space. Model space is the global 3D coordinate space in which the 3D geometry of the model lives. View projection space is the 3D Euclidean space with a coordinate system such that
 X and Y are horizontal and vertical directions in the view projection plane and Z
 is the cross product of X and Y. Distances in the projection space are the same as
 would be measured on paper if the view is printed without additional scaling. For uncropped views all model space points can be transformed to projection space using
 the this transform. For cropped views only model points which lie inside the boundary returned by GetBoundary () () () 
 should be transformed to projection space using this transform.

