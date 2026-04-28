---
kind: method
id: M:Autodesk.Revit.DB.ViewSheet.GetAllPlacedViews
zh: 图纸
source: html/816db942-4e9c-7278-7f59-53048becc46a.htm
---
# Autodesk.Revit.DB.ViewSheet.GetAllPlacedViews Method

**中文**: 图纸

Returns the ElementIds of Views placed on this sheet.

## Syntax (C#)
```csharp
public ISet<ElementId> GetAllPlacedViews()
```

## Returns
The ids of the views on this sheet.

## Remarks
Schedules on the sheet are not returned by this method. Use ScheduleSheetInstance.OwnerViewId to find the sheet on which a schedule is placed.

