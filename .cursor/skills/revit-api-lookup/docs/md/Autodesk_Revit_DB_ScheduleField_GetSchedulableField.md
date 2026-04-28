---
kind: method
id: M:Autodesk.Revit.DB.ScheduleField.GetSchedulableField
source: html/cf6a6ae1-a693-a35b-3051-b34475ea574c.htm
---
# Autodesk.Revit.DB.ScheduleField.GetSchedulableField Method

Gets a SchedulableField object representing this field.

## Syntax (C#)
```csharp
public SchedulableField GetSchedulableField()
```

## Returns
The SchedulableField object.

## Remarks
A ScheduleableField cannot be obtained for:
 - Calculated fields
 - Combined parameters

## Exceptions
- **Autodesk.Revit.Exceptions.InapplicableDataException** - This ScheduleField is not a schedulable field by type(non-calculated/non-combined-parameter).

