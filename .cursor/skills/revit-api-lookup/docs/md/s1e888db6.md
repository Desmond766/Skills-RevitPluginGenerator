---
kind: method
id: M:Autodesk.Revit.DB.ScheduleDefinition.RemoveField(Autodesk.Revit.DB.ScheduleFieldId)
source: html/8c187115-7055-7a59-edb4-ea073df1002b.htm
---
# Autodesk.Revit.DB.ScheduleDefinition.RemoveField Method

Removes a field.

## Syntax (C#)
```csharp
public void RemoveField(
	ScheduleFieldId fieldId
)
```

## Parameters
- **fieldId** (`Autodesk.Revit.DB.ScheduleFieldId`) - The ID of the field to remove.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - fieldId is not the ID of a field in this ScheduleDefinition.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

