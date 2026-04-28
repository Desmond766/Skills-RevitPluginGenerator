---
kind: property
id: P:Autodesk.Revit.DB.ViewSchedule.BodyTextTypeId
zh: 明细表
source: html/980d0623-f826-bfee-7f68-78d1db70d663.htm
---
# Autodesk.Revit.DB.ViewSchedule.BodyTextTypeId Property

**中文**: 明细表

Defines the default text style used for the data section of the schedule.

## Syntax (C#)
```csharp
public ElementId BodyTextTypeId { get; set; }
```

## Remarks
Columns may override the default style.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The text type id doesn't represent a valid text type element.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

