---
kind: method
id: M:Autodesk.Revit.DB.View3D.ToggleToPerspective
zh: 三维视图、3d视图
source: html/dae3ab33-0bfa-eb96-0491-c7e520bc9470.htm
---
# Autodesk.Revit.DB.View3D.ToggleToPerspective Method

**中文**: 三维视图、3d视图

Toggles this view to perspective.

## Syntax (C#)
```csharp
public void ToggleToPerspective()
```

## Remarks
This view can only be toggled to perspective if no view specific elements are contained.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This view cannot be toggled.

