---
kind: method
id: M:Autodesk.Revit.DB.ScheduleDefinition.GetFieldIndex(Autodesk.Revit.DB.ScheduleFieldId)
source: html/ef2e335a-9ca7-2a88-97ec-1509710f8c2e.htm
---
# Autodesk.Revit.DB.ScheduleDefinition.GetFieldIndex Method

Converts a field ID to the corresponding field index.

## Syntax (C#)
```csharp
public int GetFieldIndex(
	ScheduleFieldId fieldId
)
```

## Parameters
- **fieldId** (`Autodesk.Revit.DB.ScheduleFieldId`) - The field ID.

## Returns
The field index.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - fieldId is not the ID of a field in this ScheduleDefinition.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

