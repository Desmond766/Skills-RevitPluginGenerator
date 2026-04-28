---
kind: method
id: M:Autodesk.Revit.DB.ScheduleDefinition.AddField(Autodesk.Revit.DB.ScheduleFieldType)
source: html/35b2f716-edd7-8d1b-1c16-dd52be928be7.htm
---
# Autodesk.Revit.DB.ScheduleDefinition.AddField Method

Adds a regular field at the end of the list.

## Syntax (C#)
```csharp
public ScheduleField AddField(
	ScheduleFieldType fieldType
)
```

## Parameters
- **fieldType** (`Autodesk.Revit.DB.ScheduleFieldType`) - The type of data displayed by the field.

## Returns
The new field.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The field specified by fieldType may not included in this ScheduleDefinition.
 -or-
 The field specified by fieldType is already included in this ScheduleDefinition.
 -or-
 The fieldType can't be CustomField. To add a CustomField, you should create a Schedulable field and add it.
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

