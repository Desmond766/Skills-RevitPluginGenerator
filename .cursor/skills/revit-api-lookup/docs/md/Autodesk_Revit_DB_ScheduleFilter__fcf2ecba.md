---
kind: type
id: T:Autodesk.Revit.DB.ScheduleFilter
source: html/a5dfec9f-1efd-b507-d079-eabcbf5032f8.htm
---
# Autodesk.Revit.DB.ScheduleFilter

A filter in a schedule.

## Syntax (C#)
```csharp
public class ScheduleFilter : IDisposable
```

## Remarks
The ScheduleFilter class represents a single filter in a schedule.
 A filter is a condition that must be satisfied for an element to
 appear in the schedule. All filters must be satisfied for an element
 to appear in the schedule. A schedule can be filtered by data that is not displayed
 in the schedule by marking the field used for filtering as hidden
 using the ScheduleField.IsHidden property.

