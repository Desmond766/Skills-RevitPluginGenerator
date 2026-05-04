---
kind: method
id: M:Autodesk.Revit.DB.ViewPlan.SetUnderlayBaseLevel(Autodesk.Revit.DB.ElementId)
zh: 平面视图、平面图
source: html/68a95ba8-b6ff-6275-eb2b-2b54fe6d9e62.htm
---
# Autodesk.Revit.DB.ViewPlan.SetUnderlayBaseLevel Method

**中文**: 平面视图、平面图

Sets the level whose elevation will determine the bottom of the underlay range.
 The elevation of the next highest level will be used to determine the top of the underlay range.

## Syntax (C#)
```csharp
public void SetUnderlayBaseLevel(
	ElementId levelId
)
```

## Parameters
- **levelId** (`Autodesk.Revit.DB.ElementId`) - The element id of a level in the project or else InvalidElementId.

## Remarks
If the level specified is the highest level, the underlay range will be unbounded.
 The underlay range will consist of everything above the specified level.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The ElementId levelId does not correspond to a Level in the project.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

