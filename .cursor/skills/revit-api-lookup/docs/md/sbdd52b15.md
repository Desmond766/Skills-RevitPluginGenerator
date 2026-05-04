---
kind: property
id: P:Autodesk.Revit.DB.ScheduleField.PercentageOf
source: html/12f76318-e8fa-d5b8-d52e-434a07f159f9.htm
---
# Autodesk.Revit.DB.ScheduleField.PercentageOf Property

The ID of the field to calculate percentages of.

## Syntax (C#)
```csharp
public ScheduleFieldId PercentageOf { get; set; }
```

## Remarks
A Percentage field calculates what percent of the total of another field
 each element represents. PercentageOf is the ID of the field used to
 calculate percentages. If PercentageOf is InvalidScheduleFieldId,
 no data is displayed. Percentages can only be calculated for numeric fields. The Count
 field and other percentage fields cannot be used to calculate percentages.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: percentageOf is not InvalidScheduleFieldId or the ID of a field that can be
 used to calculated percentages.
 -or-
 When setting this property: percentageOf would create a circular chain of references.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: This ScheduleField is not a percentage field.

