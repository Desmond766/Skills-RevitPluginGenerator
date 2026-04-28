---
kind: method
id: M:Autodesk.Revit.DB.ScheduleDefinition.AddField(Autodesk.Revit.DB.SchedulableField)
source: html/2e28946e-7264-977b-c868-996b4a839048.htm
---
# Autodesk.Revit.DB.ScheduleDefinition.AddField Method

Adds a regular field at the end of the list.

## Syntax (C#)
```csharp
public ScheduleField AddField(
	SchedulableField schedulableField
)
```

## Parameters
- **schedulableField** (`Autodesk.Revit.DB.SchedulableField`) - A SchedulableField object representing the field.

## Returns
The new field.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The field specified by schedulableField may not included in this ScheduleDefinition.
 -or-
 The field specified by schedulableField is already included in this ScheduleDefinition.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

