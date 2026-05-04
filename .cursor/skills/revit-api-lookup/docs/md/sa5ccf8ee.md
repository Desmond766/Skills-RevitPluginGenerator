---
kind: property
id: P:Autodesk.Revit.DB.ScheduleField.DisplayType
source: html/ca5cd7f7-081e-65f3-b671-2a1c780a5b09.htm
---
# Autodesk.Revit.DB.ScheduleField.DisplayType Property

Indicates the chosen display type for the field.

## Syntax (C#)
```csharp
public ScheduleFieldDisplayType DisplayType { get; set; }
```

## Remarks
This replaces the hasTotals property from 2017.
 The hasTotals = true is same as DisplayType::Totals;
 hasTotals = false is the same as DisplayType::Standard.
 This also adds the ability to see Min/Max for grouped elements.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: This ScheduleField cannot display minimum and maximum values.
 -or-
 When setting this property: This ScheduleField cannot be totaled.

