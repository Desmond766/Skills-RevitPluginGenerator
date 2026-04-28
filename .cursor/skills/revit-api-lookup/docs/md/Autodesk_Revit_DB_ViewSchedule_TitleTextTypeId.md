---
kind: property
id: P:Autodesk.Revit.DB.ViewSchedule.TitleTextTypeId
zh: 明细表
source: html/5dc9d891-f903-edac-33fa-30dda043b711.htm
---
# Autodesk.Revit.DB.ViewSchedule.TitleTextTypeId Property

**中文**: 明细表

Defines the default text style used in the header section of the schedule.

## Syntax (C#)
```csharp
public ElementId TitleTextTypeId { get; set; }
```

## Remarks
Cells may override the default style.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The text type id doesn't represent a valid text type element.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

