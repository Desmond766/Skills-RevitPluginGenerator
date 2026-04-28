---
kind: method
id: M:Autodesk.Revit.DB.View3D.HideGridsOnLevel(Autodesk.Revit.DB.ElementId)
zh: 三维视图、3d视图
source: html/3ff8dc79-5d01-4d2b-8dcc-a9c28880048e.htm
---
# Autodesk.Revit.DB.View3D.HideGridsOnLevel Method

**中文**: 三维视图、3d视图

This method hides the grid lines in this 3D view on the given Level.

## Syntax (C#)
```csharp
public void HideGridsOnLevel(
	ElementId levelId
)
```

## Parameters
- **levelId** (`Autodesk.Revit.DB.ElementId`) - The id of the Level where grids will not be displayed.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

