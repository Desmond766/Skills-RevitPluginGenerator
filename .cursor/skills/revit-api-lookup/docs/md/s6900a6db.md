---
kind: method
id: M:Autodesk.Revit.DB.ViewSchedule.IsDataOutOfDate
zh: 明细表
source: html/32ac23ad-5e1e-f8b4-3d11-17e2df82724d.htm
---
# Autodesk.Revit.DB.ViewSchedule.IsDataOutOfDate Method

**中文**: 明细表

Indicates whether the schedule data is out of date.

## Syntax (C#)
```csharp
public bool IsDataOutOfDate()
```

## Returns
True if the schedule data is out of date, false otherwise.

## Remarks
To improve performance, the ViewSchedule may contain TableSections that are only updated on demand. For example,
 the body section of a schedule is not updated when the ViewSchedule is closed. In this case, you need to call
 RefreshData to avoid getting the stale data.

