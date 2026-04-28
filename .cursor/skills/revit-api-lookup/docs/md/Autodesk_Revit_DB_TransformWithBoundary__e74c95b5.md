---
kind: type
id: T:Autodesk.Revit.DB.TransformWithBoundary
source: html/5d7db6ff-8538-2c84-8e39-d683e0de9ca5.htm
---
# Autodesk.Revit.DB.TransformWithBoundary

This class contains the transform from model space to projection space for a view and the
 boundary in model space in which the transform is valid.

## Syntax (C#)
```csharp
public class TransformWithBoundary : IDisposable
```

## Remarks
Use the model-to-projection transform returned by GetModelToProjectionTransform () () () to transform model points to
 the view's projection space. The model-to-projection transform is only valid for points in 3D model space that that can be seen
 through the 2D boundary returned by GetBoundary () () () , when looking in the direction of [!:View.ViewDirection] . For views that are placed on sheets, you can combine the View's model-to-projection transform and the Viewport's
 projection-to-sheet transform to transform model points to sheet space: sheetXYZ = projectionToSheetTransform * modelToProjectionTransform * modelXYZ Model space is the global 3D coordinate space in which the 3D geometry of the model lives. View projection space is the 3D Euclidean space with a coordinate system such that
 X and Y are horizontal and vertical directions in the view projection plane and Z
 is the cross product of X and Y. Distances in the projection space are the same as
 would be measured on paper if the view is printed without additional scaling. Sheet space is the coordinate space of one sheet. This is the space in which viewports and
 titleblocks are arranged on the sheet.

