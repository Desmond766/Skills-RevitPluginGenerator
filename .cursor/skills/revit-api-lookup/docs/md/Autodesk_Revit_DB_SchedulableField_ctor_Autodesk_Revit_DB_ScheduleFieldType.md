---
kind: method
id: M:Autodesk.Revit.DB.SchedulableField.#ctor(Autodesk.Revit.DB.ScheduleFieldType)
source: html/f07ddbfd-5220-2b63-4a65-468650114979.htm
---
# Autodesk.Revit.DB.SchedulableField.#ctor Method

Creates a new SchedulableField.

## Syntax (C#)
```csharp
public SchedulableField(
	ScheduleFieldType fieldType
)
```

## Parameters
- **fieldType** (`Autodesk.Revit.DB.ScheduleFieldType`) - The type of data displayed by the field.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - fieldType is not a schedulable field type
 -or-
 The fieldType can't be CustomField. To create a CustomField, you should use the constructor which receives the custom field server id as a parameter.
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

