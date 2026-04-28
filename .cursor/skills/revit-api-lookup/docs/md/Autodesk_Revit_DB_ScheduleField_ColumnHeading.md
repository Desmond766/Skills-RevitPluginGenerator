---
kind: property
id: P:Autodesk.Revit.DB.ScheduleField.ColumnHeading
source: html/3890f745-6f24-f81a-9f8f-d8b47c8e3f94.htm
---
# Autodesk.Revit.DB.ScheduleField.ColumnHeading Property

The column heading text.

## Syntax (C#)
```csharp
public string ColumnHeading { get; set; }
```

## Remarks
On initial creation of a ScheduleField, the column heading is
 initialized based on the field name (typically a parameter name).

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

