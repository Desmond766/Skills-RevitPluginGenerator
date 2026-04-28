---
kind: method
id: M:Autodesk.Revit.DB.Viewport.GetProjectionToSheetTransform
source: html/3c55684a-b4fd-851e-3b32-6a3eb1e9eb3b.htm
---
# Autodesk.Revit.DB.Viewport.GetProjectionToSheetTransform Method

Returns the transform from the view's projection space to the sheet space.

## Syntax (C#)
```csharp
public Transform GetProjectionToSheetTransform()
```

## Returns
The transform from the view's projection space to the sheet space.

## Remarks
This transform accounts for the position and rotation of a
 viewport on a sheet. The transforms from the model space to the view projection space
 are returned by [!:View.GetModelToProjectionTransforms()] .

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The viewport is not on a sheet.
 -or-
 The viewport does not have transforms.

