---
kind: method
id: M:Autodesk.Revit.DB.View3D.ShowGridsOnLevel(Autodesk.Revit.DB.ElementId)
zh: 三维视图、3d视图
source: html/72ed89c3-546e-c6d8-78ef-95ce7530de98.htm
---
# Autodesk.Revit.DB.View3D.ShowGridsOnLevel Method

**中文**: 三维视图、3d视图

This method displays the grid lines in this 3DView on the given Level.

## Syntax (C#)
```csharp
public void ShowGridsOnLevel(
	ElementId levelId
)
```

## Parameters
- **levelId** (`Autodesk.Revit.DB.ElementId`) - The id of the Level where grids should be displayed.

## Remarks
Grids will be displayed only if they intersects Level's plane.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

