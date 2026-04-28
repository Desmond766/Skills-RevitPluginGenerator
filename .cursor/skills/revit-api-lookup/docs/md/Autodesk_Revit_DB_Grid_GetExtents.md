---
kind: method
id: M:Autodesk.Revit.DB.Grid.GetExtents
zh: 轴网
source: html/0eb62261-77ba-455f-5f7b-0d2a984df1df.htm
---
# Autodesk.Revit.DB.Grid.GetExtents Method

**中文**: 轴网

Gets the extents of the grid in the model.

## Syntax (C#)
```csharp
public Outline GetExtents()
```

## Returns
The extents are the 3D bounding box surrounding the grid. The Z coordinates of the box are used by
 Revit to determine if the grid should be displayed in a corresponding view plan (if the grid is linear). The
 extents are not used for arc grids.

