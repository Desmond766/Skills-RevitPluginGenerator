---
kind: type
id: T:Autodesk.Revit.DB.ScheduleSortGroupField
source: html/526680eb-ea68-35a7-b0c5-d63459fac04d.htm
---
# Autodesk.Revit.DB.ScheduleSortGroupField

A field that is used for sorting and/or grouping in a schedule.

## Syntax (C#)
```csharp
public class ScheduleSortGroupField : IDisposable
```

## Remarks
A schedule may be sorted or grouped by one or more of the
 schedule's fields. The ScheduleSortGroupField class represents
 one of the fields that the schedule is sorted or grouped by. Sorting and grouping are related operations. In either case,
 elements appearing in the schedule are sorted based on their values
 for the field that the schedule is sorted/grouped by, which automatically
 causes elements with identical values to be grouped together.
 By enabling extra header, footer, or blank rows, visual separation
 between groups can be achieved. If ScheduleDefinition.IsItemized is false, elements having the
 same values for all of the fields used for sorting/grouping will be
 combined onto the same row. A schedule can be sorted or grouped by data that is not displayed
 in the schedule by marking the field used for sorting/grouping as hidden
 using the ScheduleField.IsHidden property.

