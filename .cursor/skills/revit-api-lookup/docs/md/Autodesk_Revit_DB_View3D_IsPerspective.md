---
kind: property
id: P:Autodesk.Revit.DB.View3D.IsPerspective
zh: 三维视图、3d视图
source: html/b9d49b93-a2f5-cf17-0b69-8c66be8a9a46.htm
---
# Autodesk.Revit.DB.View3D.IsPerspective Property

**中文**: 三维视图、3d视图

Identifies whether this is a perspective view.

## Syntax (C#)
```csharp
public bool IsPerspective { get; }
```

## Remarks
In a perspective view, view direction is variable - it is the direction that connects a particular point on the model with the eye position.
 The property ViewDirection becomes less meaningful -
 it only describes the general orientation of the camera.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Returns true if the view is not a view template.

