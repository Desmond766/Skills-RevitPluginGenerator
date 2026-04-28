---
kind: method
id: M:Autodesk.Revit.DB.TransformWithBoundary.GetBoundary
source: html/5f38a440-a539-f5b0-2b48-1aefb8bf03a4.htm
---
# Autodesk.Revit.DB.TransformWithBoundary.GetBoundary Method

Returns the boundary for the model space to view projection space transform.

## Syntax (C#)
```csharp
public CurveLoop GetBoundary()
```

## Returns
A closed loop in model space representing the region of model space to which the model space to view projection space transform applies.

## Remarks
Before you transform a model point to view projection space using the transform returned by GetModelToProjectionTransform () () () ,
 test to make sure the model point is visible through this 2D boundary. The model space to view projection space transform is only valid for points in 3D model
 space that can be seen through the 2D boundary, when looking in the direction of [!:View.ViewDirection] . The boundary is one enclosed region of the view's crop. For uncropped views 'null' is returned. For cropped views that do not have split crop regions, the boundary is the shape of the view crop. Typically the boundary is
 rectangular, but more complex shapes are supported. For cropped views that have split crop regions, the boundary is one rectangular region of the split view crop. Even though the boundary represents the view crop - a 2D polygon drawn on the view's cut plane - any point in 3D model space
 that can be seen through the boundary when looking in the direction of the view (see [!:View.ViewDirection] ) is considered
 to be inside the boundary and can be transformed using the model space to view projection space transform returned by
 GetModelToProjectionTransform () () () . For example, if the shape of the CurveLoop is a circle, then there is an infinite
 cylinder in 3D model space and any point inside that cylinder can be transformed with the model space to view projection space transform. To test if a point in 3D model space is within the boundary, first project the point and the CurveLoop onto a
 plane which is perpendicular to the view direction. Then use a point-in-polygon algorithm to check if the projected
 point is inside the polygon described by the CurveLoop. It is guaranteed that the boundary CurveLoop lies on a plane which is perpendicular to [!:View.ViewDirection] and
 that the CurveLoop does not self-intersect and is closed. It is also guaranteed that the boundaries of different
 TransformWithBoundary regions of the same view don't overlap with each other.

