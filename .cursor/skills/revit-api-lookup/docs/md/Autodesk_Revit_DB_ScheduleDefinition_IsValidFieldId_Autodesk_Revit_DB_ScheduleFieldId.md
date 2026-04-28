---
kind: method
id: M:Autodesk.Revit.DB.ScheduleDefinition.IsValidFieldId(Autodesk.Revit.DB.ScheduleFieldId)
source: html/4f9df0e1-7853-4161-19e1-274424d77445.htm
---
# Autodesk.Revit.DB.ScheduleDefinition.IsValidFieldId Method

Checks whether a ScheduleFieldId is the ID of a field in this ScheduleDefinition.

## Syntax (C#)
```csharp
public bool IsValidFieldId(
	ScheduleFieldId fieldId
)
```

## Parameters
- **fieldId** (`Autodesk.Revit.DB.ScheduleFieldId`) - The field ID to check.

## Returns
True if the field ID is valid, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

