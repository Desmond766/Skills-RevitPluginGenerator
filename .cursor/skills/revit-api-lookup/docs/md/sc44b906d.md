---
kind: property
id: P:Autodesk.Revit.DB.ScheduleField.SheetColumnWidth
source: html/999e9e46-2259-19f4-cfc1-9c52509a2385.htm
---
# Autodesk.Revit.DB.ScheduleField.SheetColumnWidth Property

The width of the column on a sheet, measured in feet.

## Syntax (C#)
```csharp
public double SheetColumnWidth { get; set; }
```

## Remarks
In a schedule with an embedded ScheduleDefinition, a column may
 display two fields, one from each ScheduleDefinition. In that case,
 the larger of the two widths is used. It is always aligned with the GridColumnWidth.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: sheetColumnWidth is negative.

