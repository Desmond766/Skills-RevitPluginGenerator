---
kind: method
id: M:Autodesk.Revit.DB.ViewPlan.GetUnderlayTopLevel
zh: 平面视图、平面图
source: html/5d401ec0-ead1-39bd-459b-2dca075b2797.htm
---
# Autodesk.Revit.DB.ViewPlan.GetUnderlayTopLevel Method

**中文**: 平面视图、平面图

Returns the element id of the level that defines the top of the underlay range.

## Syntax (C#)
```csharp
public ElementId GetUnderlayTopLevel()
```

## Returns
If the underlay base level is a valid level, and this method returns InvalidElementId, then the underlay range is unbounded,
 and consists of everything above the underlay base level.

