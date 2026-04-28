---
kind: method
id: M:Autodesk.Revit.DB.ScheduleDefinition.CanFilterByGlobalParameters(Autodesk.Revit.DB.ScheduleFieldId)
source: html/0ab1f8d7-489c-ac18-d262-be359377e523.htm
---
# Autodesk.Revit.DB.ScheduleDefinition.CanFilterByGlobalParameters Method

Checks whether a field can be used with a global parameter-based filter.

## Syntax (C#)
```csharp
public bool CanFilterByGlobalParameters(
	ScheduleFieldId fieldId
)
```

## Parameters
- **fieldId** (`Autodesk.Revit.DB.ScheduleFieldId`) - The ID of the field to check.

## Returns
True if the field can be used with a global parameter-based filter, false otherwise.

## Remarks
The global parameter-based filter types are IsAsociatedWith, IsNotAssociatedWith. Only parameters which have a compatible type with at least one existing global parameter
 can be filtered.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - fieldId is not the ID of a field in this ScheduleDefinition.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

