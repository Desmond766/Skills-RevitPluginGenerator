---
kind: method
id: M:Autodesk.Revit.DB.ScheduleDefinition.GetField(Autodesk.Revit.DB.ScheduleFieldId)
source: html/3507e623-c9a5-a82b-5c44-15756cdc0c3a.htm
---
# Autodesk.Revit.DB.ScheduleDefinition.GetField Method

Gets a field.

## Syntax (C#)
```csharp
public ScheduleField GetField(
	ScheduleFieldId fieldId
)
```

## Parameters
- **fieldId** (`Autodesk.Revit.DB.ScheduleFieldId`) - The ID of the field.

## Returns
The field.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - fieldId is not the ID of a field in this ScheduleDefinition.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

