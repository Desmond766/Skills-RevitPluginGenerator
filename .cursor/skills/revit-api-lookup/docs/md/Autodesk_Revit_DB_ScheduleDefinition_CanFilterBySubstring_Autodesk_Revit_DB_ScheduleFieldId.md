---
kind: method
id: M:Autodesk.Revit.DB.ScheduleDefinition.CanFilterBySubstring(Autodesk.Revit.DB.ScheduleFieldId)
source: html/0c064cb7-9f20-749e-072a-5d6e45e64cf6.htm
---
# Autodesk.Revit.DB.ScheduleDefinition.CanFilterBySubstring Method

Checks whether a field can be used with a substring-based filter.

## Syntax (C#)
```csharp
public bool CanFilterBySubstring(
	ScheduleFieldId fieldId
)
```

## Parameters
- **fieldId** (`Autodesk.Revit.DB.ScheduleFieldId`) - The ID of the field to check.

## Returns
True if the field can be used with a substring-based filter, false otherwise.

## Remarks
The substring-based filter types are Contains, NotContains,
 BeginsWith, NonBeginsWith, EndsWith and NotEndsWith. Only string parameters can be filtered by substring.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - fieldId is not the ID of a field in this ScheduleDefinition.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

