---
kind: method
id: M:Autodesk.Revit.DB.SchedulableField.#ctor(Autodesk.Revit.DB.ScheduleFieldType,Autodesk.Revit.DB.ElementId)
source: html/5d22ee48-76dd-c314-a551-b6f722eb49a3.htm
---
# Autodesk.Revit.DB.SchedulableField.#ctor Method

Creates a new SchedulableField.

## Syntax (C#)
```csharp
public SchedulableField(
	ScheduleFieldType fieldType,
	ElementId parameterId
)
```

## Parameters
- **fieldType** (`Autodesk.Revit.DB.ScheduleFieldType`) - The type of data displayed by the field.
- **parameterId** (`Autodesk.Revit.DB.ElementId`) - The ID of the parameter displayed by the field.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - fieldType is not a schedulable field type
 -or-
 The fieldType can't be CustomField. To create a CustomField, you should use the constructor which receives the custom field server id as a parameter.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

