---
kind: method
id: M:Autodesk.Revit.DB.ScheduleDefinition.InsertField(Autodesk.Revit.DB.SchedulableField,System.Int32)
source: html/57376e72-79c9-da97-6b1c-6f4e40f00252.htm
---
# Autodesk.Revit.DB.ScheduleDefinition.InsertField Method

Adds a regular field at the specified position in the list.

## Syntax (C#)
```csharp
public ScheduleField InsertField(
	SchedulableField schedulableField,
	int index
)
```

## Parameters
- **schedulableField** (`Autodesk.Revit.DB.SchedulableField`) - A SchedulableField object representing the field.
- **index** (`System.Int32`) - The index in the list of fields.

## Returns
The new field.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The field specified by schedulableField may not included in this ScheduleDefinition.
 -or-
 The field specified by schedulableField is already included in this ScheduleDefinition.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - index is not a valid insert position.

