---
kind: method
id: M:Autodesk.Revit.DB.ScheduleDefinition.InsertField(Autodesk.Revit.DB.ScheduleFieldType,Autodesk.Revit.DB.ElementId,System.Int32)
source: html/443f3eed-9d4c-a729-a0d4-20e52a9bdd14.htm
---
# Autodesk.Revit.DB.ScheduleDefinition.InsertField Method

Adds a regular field at the specified position in the list.

## Syntax (C#)
```csharp
public ScheduleField InsertField(
	ScheduleFieldType fieldType,
	ElementId parameterId,
	int index
)
```

## Parameters
- **fieldType** (`Autodesk.Revit.DB.ScheduleFieldType`) - The type of data displayed by the field.
- **parameterId** (`Autodesk.Revit.DB.ElementId`) - The ID of the parameter displayed by the field.
- **index** (`System.Int32`) - The index in the list of fields.

## Returns
The new field.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - index is not a valid insert position.
 -or-
 A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.ArgumentsInconsistentException** - The field specified by fieldType and parameterId may not included in this ScheduleDefinition.
 -or-
 The field specified by fieldType and parameterId is already included in this ScheduleDefinition.

