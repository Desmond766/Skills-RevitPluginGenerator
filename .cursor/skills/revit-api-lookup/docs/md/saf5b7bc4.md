---
kind: method
id: M:Autodesk.Revit.DB.View3D.ShowGridsOnLevels(System.Collections.Generic.ISet{Autodesk.Revit.DB.ElementId})
zh: 三维视图、3d视图
source: html/688b29ae-f365-3395-8bb9-46ed14b45eb1.htm
---
# Autodesk.Revit.DB.View3D.ShowGridsOnLevels Method

**中文**: 三维视图、3d视图

This method displays the grid lines in this 3D view on the given Levels.

## Syntax (C#)
```csharp
public void ShowGridsOnLevels(
	ISet<ElementId> levelsIds
)
```

## Parameters
- **levelsIds** (`System.Collections.Generic.ISet < ElementId >`) - Levels ids where grids lines will be displayed.

## Remarks
Previously selected Levels for showing grids will be replaced with the new ids.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

