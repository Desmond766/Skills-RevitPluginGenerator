---
kind: method
id: M:Autodesk.Revit.DB.Level.FindAssociatedPlanViewId
zh: 标高
source: html/ff23277a-3bb1-253d-e158-983b23aaf04a.htm
---
# Autodesk.Revit.DB.Level.FindAssociatedPlanViewId Method

**中文**: 标高

Finds the id of the first available associated floor or structural plan view associated with this level.

## Syntax (C#)
```csharp
public ElementId FindAssociatedPlanViewId()
```

## Remarks
The view id returned is determined by the same rules associated with the Revit tool "Go to Floor Plan".
 Many levels may actually have more than one associated floor plan id and this routine will only return
 the first one found. If no associated view is found, InvalidElementId is returned.

