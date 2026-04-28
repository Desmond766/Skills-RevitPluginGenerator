---
kind: method
id: M:Autodesk.Revit.DB.ViewSheet.GetAllViewports
zh: 图纸
source: html/8bec6dbb-2487-d3b3-e664-62ec31a2185c.htm
---
# Autodesk.Revit.DB.ViewSheet.GetAllViewports Method

**中文**: 图纸

Returns the ElementIds of Viewports on this sheet.

## Syntax (C#)
```csharp
public ICollection<ElementId> GetAllViewports()
```

## Returns
The Viewports on this sheet.

## Remarks
Schedules on the sheet are not returned by this method. Use ScheduleSheetInstance.OwnerViewId to find the sheet on which a schedule is placed.

