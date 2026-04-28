---
kind: method
id: M:Autodesk.Revit.DB.ViewPlan.SetUnderlayRange(Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId)
zh: 平面视图、平面图
source: html/7d86a306-a362-5526-e84d-e5eae8437175.htm
---
# Autodesk.Revit.DB.ViewPlan.SetUnderlayRange Method

**中文**: 平面视图、平面图

Sets the underlay base and underlay top to the specified levels.

## Syntax (C#)
```csharp
public void SetUnderlayRange(
	ElementId baseLevelId,
	ElementId topLevelId
)
```

## Parameters
- **baseLevelId** (`Autodesk.Revit.DB.ElementId`) - The element id of a level in the project or InvalidElementId. If InvalidElementId,
 then the underlay base level is not set and no elements will be displayed as underlay.
- **topLevelId** (`Autodesk.Revit.DB.ElementId`) - The element id of a level in the project or InvalidElementId. If InvalidElementId,
 then the underlay range is unbounded.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The ElementId baseLevelId does not correspond to a Level in the project.
 -or-
 The ElementId topLevelId does not correspond to a Level in the project.
 -or-
 The elevation of level topLevelId must be greater than the elevation of level baseLevelId.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

