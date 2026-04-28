---
kind: property
id: P:Autodesk.Revit.DB.ScheduleDefinition.IsItemized
source: html/10fc3753-29a0-8b1a-2f21-77f2634a4b9f.htm
---
# Autodesk.Revit.DB.ScheduleDefinition.IsItemized Property

Indicates if the schedule displays each element on a separate row or
 combines multiple grouped elements onto the same row.

## Syntax (C#)
```csharp
public bool IsItemized { get; set; }
```

## Remarks
In an itemized schedule, each scheduled element is displayed on
 a separate row. In a non-itemized schedule, elements that are grouped together
 according to the schedule's grouping criteria are combined onto a
 single row. For example, if a schedule is grouped by Level and Type,
 elements having the same Level and Type will appear on the same row.
 In non-itemized schedules, the Count field can be used to display
 the number of elements on the row, and totaled fields will display
 the sum of the values from all elements on the row. If a field is
 not totaled and the elements on the row have different values for
 the field, an empty cell will be displayed.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: This ScheduleDefinition is a key schedule.

