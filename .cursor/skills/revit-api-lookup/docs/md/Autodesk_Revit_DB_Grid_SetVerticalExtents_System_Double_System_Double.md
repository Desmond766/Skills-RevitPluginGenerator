---
kind: method
id: M:Autodesk.Revit.DB.Grid.SetVerticalExtents(System.Double,System.Double)
zh: 轴网
source: html/9c367024-cc8a-157b-6984-3883b690c474.htm
---
# Autodesk.Revit.DB.Grid.SetVerticalExtents Method

**中文**: 轴网

Adjusts the grid to extend through only the vertical range between bottom and top.

## Syntax (C#)
```csharp
public void SetVerticalExtents(
	double bottom,
	double top
)
```

## Parameters
- **bottom** (`System.Double`) - The bottom range of the grid extents. It must be a valid number and below the top range.
- **top** (`System.Double`) - The top range of the grid extents. It must be a valid number and above the bottom range.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The bottom and top ranges are reversed for the extents.
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The given value for bottom must be no more than 30000 feet in absolute value.
 -or-
 The given value for top must be no more than 30000 feet in absolute value.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Couldn't change the extents of the grid.

