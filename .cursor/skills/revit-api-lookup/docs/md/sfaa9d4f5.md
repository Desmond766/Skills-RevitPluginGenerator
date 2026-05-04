---
kind: property
id: P:Autodesk.Revit.DB.ScheduleField.PercentageBy
source: html/7c606b36-212f-0392-6eb5-799ab748a330.htm
---
# Autodesk.Revit.DB.ScheduleField.PercentageBy Property

The ID of the grouped schedule field used to calculate percentage totals.

## Syntax (C#)
```csharp
public ScheduleFieldId PercentageBy { get; set; }
```

## Remarks
A Percentage field calculates what percent of the total of another field
 each element represents. If PercentageBy is InvalidScheduleFieldId,
 the total is of all elements in the schedule. If PercentageBy is the
 ID of one of the fields that the schedule is grouped by, the total is
 of all elements in that group.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: percentageBy is not InvalidScheduleFieldId or the ID of a field that the
 schedule is grouped by.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: This ScheduleField is not a percentage field.

