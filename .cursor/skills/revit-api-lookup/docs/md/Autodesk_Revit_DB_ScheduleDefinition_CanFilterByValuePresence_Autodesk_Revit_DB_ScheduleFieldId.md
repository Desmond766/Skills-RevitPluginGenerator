---
kind: method
id: M:Autodesk.Revit.DB.ScheduleDefinition.CanFilterByValuePresence(Autodesk.Revit.DB.ScheduleFieldId)
source: html/fe946287-80cf-93ab-a10a-4b11f3064c33.htm
---
# Autodesk.Revit.DB.ScheduleDefinition.CanFilterByValuePresence Method

Checks whether a field can be used with a value presence-based filter.

## Syntax (C#)
```csharp
public bool CanFilterByValuePresence(
	ScheduleFieldId fieldId
)
```

## Parameters
- **fieldId** (`Autodesk.Revit.DB.ScheduleFieldId`) - The ID of the field to check.

## Returns
True if the field can be used with a value presence filter, false otherwise.

## Remarks
The value presence filter types are HasValue and HasNoValue.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - fieldId is not the ID of a field in this ScheduleDefinition.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

