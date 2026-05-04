---
kind: method
id: M:Autodesk.Revit.DB.ScheduleDefinition.CanFilterByParameterExistence(Autodesk.Revit.DB.ScheduleFieldId)
source: html/76000e8b-6c6a-fe38-379c-0a6ee7332c90.htm
---
# Autodesk.Revit.DB.ScheduleDefinition.CanFilterByParameterExistence Method

Checks whether a field can be used with a HasParameter filter.

## Syntax (C#)
```csharp
public bool CanFilterByParameterExistence(
	ScheduleFieldId fieldId
)
```

## Parameters
- **fieldId** (`Autodesk.Revit.DB.ScheduleFieldId`) - The ID of the field to check.

## Returns
True if the field can be used with a HasParameter filter, false otherwise.

## Remarks
The HasParameter filter type only supports shared parameters,
 and only with the Instance or ElementType field types.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - fieldId is not the ID of a field in this ScheduleDefinition.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

