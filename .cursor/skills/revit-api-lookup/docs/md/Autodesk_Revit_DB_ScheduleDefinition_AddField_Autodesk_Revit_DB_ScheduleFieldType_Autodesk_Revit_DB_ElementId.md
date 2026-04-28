---
kind: method
id: M:Autodesk.Revit.DB.ScheduleDefinition.AddField(Autodesk.Revit.DB.ScheduleFieldType,Autodesk.Revit.DB.ElementId)
source: html/bf7f777f-c9c1-5037-afeb-ab291bb24197.htm
---
# Autodesk.Revit.DB.ScheduleDefinition.AddField Method

Adds a regular field at the end of the list.

## Syntax (C#)
```csharp
public ScheduleField AddField(
	ScheduleFieldType fieldType,
	ElementId parameterId
)
```

## Parameters
- **fieldType** (`Autodesk.Revit.DB.ScheduleFieldType`) - The type of data displayed by the field.
- **parameterId** (`Autodesk.Revit.DB.ElementId`) - The ID of the parameter displayed by the field.

## Returns
The new field.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.ArgumentsInconsistentException** - The field specified by fieldType and parameterId may not included in this ScheduleDefinition.
 -or-
 The field specified by fieldType and parameterId is already included in this ScheduleDefinition.

