---
kind: method
id: M:Autodesk.Revit.DB.View.GetModelToProjectionTransforms
zh: 视图
source: html/593acdf3-9c82-d12a-4fc3-f15a636fd3d9.htm
---
# Autodesk.Revit.DB.View.GetModelToProjectionTransforms Method

**中文**: 视图

Gets the transforms from the model space to the view projection space.

## Syntax (C#)
```csharp
public IList<TransformWithBoundary> GetModelToProjectionTransforms()
```

## Returns
The transformations from the model space to view projection space.

## Remarks
Model space is the global 3D coordinate space in which the geometry
 of the model lives. View projection space is the 3D Euclidean space with a coordinate system such that
 X and Y are horizontal and vertical directions in the view projection plane and Z
 is the cross product of X and Y. Distances in the projection space are the same as
 would be measured on paper if the view is printed without additional scaling. Most views will return just one TransformWithBoundary . The exceptions are
 views with split crop regions. Split crop regions can be independently moved and therefore
 each region of a split crop gets its own transform and boundary. You can check if a view has split crop
 regions by getting the ViewCropRegionShapeManager and calling [!:ViewCropRegionShapeManager.IsSplit()] . When the view's crop region is split, many TransformWithBoundary objects will be returned.
 Each TransformWithBoundary corresponds to one region of the split crop. To determine which
 TransformWithBoundary to use when converting a model point into view projection space,
 first test to see which split crop region boundary contains the model point.
 See [!:TransformWithBoundary.GetBoundary()] .

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The view does not return transforms.
 -or-
 The view is a perspective view.

