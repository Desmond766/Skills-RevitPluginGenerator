---
kind: method
id: M:Autodesk.Revit.DB.View3D.ResetCameraTarget
zh: 三维视图、3d视图
source: html/0b7261c6-6f54-fdd2-9978-31b1c823f12d.htm
---
# Autodesk.Revit.DB.View3D.ResetCameraTarget Method

**中文**: 三维视图、3d视图

Resets the camera target to the center of the field of view.

## Syntax (C#)
```csharp
public void ResetCameraTarget()
```

## Remarks
The camera target can only be reset for perspective view.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The camera target cannot be reset for the view.

