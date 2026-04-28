---
kind: property
id: P:Autodesk.Revit.DB.View3D.ProjectGridsOnSectionBox
zh: 三维视图、3d视图
source: html/71f2c027-0b36-1deb-2df9-b3e51f04b06e.htm
---
# Autodesk.Revit.DB.View3D.ProjectGridsOnSectionBox Property

**中文**: 三维视图、3d视图

This option projects all grids from the current 3d view on the bottom face of the section box.
 Only grids that are inside or intersects the section box

## Syntax (C#)
```csharp
public bool ProjectGridsOnSectionBox { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Returns true if the view is not a view template.

