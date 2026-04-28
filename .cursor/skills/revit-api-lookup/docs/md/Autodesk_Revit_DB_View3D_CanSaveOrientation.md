---
kind: method
id: M:Autodesk.Revit.DB.View3D.CanSaveOrientation
zh: 三维视图、3d视图
source: html/c53a1ac2-8f2d-154d-aa48-24846186525e.htm
---
# Autodesk.Revit.DB.View3D.CanSaveOrientation Method

**中文**: 三维视图、3d视图

Returns true if the View3D's orientation can be saved, false otherwise.

## Syntax (C#)
```csharp
public bool CanSaveOrientation()
```

## Returns
True if the View3D's orientation can be saved, false otherwise.

## Remarks
The saved orientation of the default 3D view cannot be overwritten. To convert the default 3D view into a normal 3D view, rename the default 3D view.

