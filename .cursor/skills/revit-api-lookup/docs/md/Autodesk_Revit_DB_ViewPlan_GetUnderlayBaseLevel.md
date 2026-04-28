---
kind: method
id: M:Autodesk.Revit.DB.ViewPlan.GetUnderlayBaseLevel
zh: 平面视图、平面图
source: html/5f57beea-7d43-f37f-6843-6e9ad882f90e.htm
---
# Autodesk.Revit.DB.ViewPlan.GetUnderlayBaseLevel Method

**中文**: 平面视图、平面图

Returns the element id of the level that defines the bottom of the underlay range.

## Syntax (C#)
```csharp
public ElementId GetUnderlayBaseLevel()
```

## Returns
If InvalidElementId is returned, then the underlay base level is not set and no elements will be displayed as underlay.

