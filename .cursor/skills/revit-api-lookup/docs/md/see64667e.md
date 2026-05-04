---
kind: method
id: M:Autodesk.Revit.DB.View3D.ToggleToIsometric
zh: 三维视图、3d视图
source: html/9b9a964f-0b04-dc22-6215-79da2a131515.htm
---
# Autodesk.Revit.DB.View3D.ToggleToIsometric Method

**中文**: 三维视图、3d视图

Toggles this view to isometric.

## Syntax (C#)
```csharp
public void ToggleToIsometric()
```

## Remarks
This view can only be toggled to isometric if no view specific elements are contained.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This view cannot be toggled.

