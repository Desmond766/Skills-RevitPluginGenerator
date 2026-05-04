---
kind: property
id: P:Autodesk.Revit.DB.ViewSchedule.HeaderTextTypeId
zh: 明细表
source: html/615568b8-7f0e-7680-7560-e5e475220396.htm
---
# Autodesk.Revit.DB.ViewSchedule.HeaderTextTypeId Property

**中文**: 明细表

Defines the default text style used in the column headers in the body section of the schedule.

## Syntax (C#)
```csharp
public ElementId HeaderTextTypeId { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The text type id doesn't represent a valid text type element.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

