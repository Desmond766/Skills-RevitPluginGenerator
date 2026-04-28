---
kind: method
id: M:Autodesk.Revit.DB.ViewSchedule.GetSegmentCount
zh: 明细表
source: html/0c3b2044-370c-e551-38a8-bdc980dfd64d.htm
---
# Autodesk.Revit.DB.ViewSchedule.GetSegmentCount Method

**中文**: 明细表

Gets the total count of schedule segments.

## Syntax (C#)
```csharp
public int GetSegmentCount()
```

## Returns
The total count of schedule segments. 1 means the schedule is not split yet.

## Remarks
There will be at least one segment for a schedule.

