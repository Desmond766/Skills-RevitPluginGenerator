---
kind: method
id: M:Autodesk.Revit.DB.ScheduleDefinition.InsertField(Autodesk.Revit.DB.ScheduleFieldType,System.Int32)
source: html/914f1282-2b24-5479-0784-1ab5329dba1c.htm
---
# Autodesk.Revit.DB.ScheduleDefinition.InsertField Method

Adds a regular field at the specified position in the list.

## Syntax (C#)
```csharp
public ScheduleField InsertField(
	ScheduleFieldType fieldType,
	int index
)
```

## Parameters
- **fieldType** (`Autodesk.Revit.DB.ScheduleFieldType`) - The type of data displayed by the field.
- **index** (`System.Int32`) - The index in the list of fields.

## Returns
The new field.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The field specified by fieldType may not included in this ScheduleDefinition.
 -or-
 The field specified by fieldType is already included in this ScheduleDefinition.
 -or-
 The fieldType can't be CustomField. To add a CustomField, you should create a Schedulable field and add it.
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - index is not a valid insert position.
 -or-
 A value passed for an enumeration argument is not a member of that enumeration

