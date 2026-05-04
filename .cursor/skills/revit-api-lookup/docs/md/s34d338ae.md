---
kind: property
id: P:Autodesk.Revit.DB.ScheduleField.GridColumnWidth
source: html/061bfa96-9775-32a8-f66d-858990d96f3b.htm
---
# Autodesk.Revit.DB.ScheduleField.GridColumnWidth Property

The width of the column in the editable grid view, measured in feet.

## Syntax (C#)
```csharp
public double GridColumnWidth { get; set; }
```

## Remarks
In a schedule with an embedded ScheduleDefinition, a column may
 display two fields, one from each ScheduleDefinition. In that case,
 the larger of the two widths is used. It is always aligned with the SheetColumnWidth.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: gridColumnWidth is negative.

