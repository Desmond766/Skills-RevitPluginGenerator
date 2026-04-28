---
kind: method
id: M:Autodesk.Revit.DB.Wall.GetStackedWallMemberIds
zh: 墙、墙体
source: html/66ec8d4e-25cd-1e14-3b25-d9d3a0f5cce9.htm
---
# Autodesk.Revit.DB.Wall.GetStackedWallMemberIds Method

**中文**: 墙、墙体

Get the sub walls which belongs to the wall.

## Syntax (C#)
```csharp
public IList<ElementId> GetStackedWallMemberIds()
```

## Returns
If the wall is a stacked wall, the Ids of the sub will be returned in bottom-top order.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This wall isn't a consistent stacked wall.

