---
kind: method
id: M:Autodesk.Revit.DB.ScheduleDefinition.CanSortByField(Autodesk.Revit.DB.ScheduleFieldId)
source: html/a9bb153f-3ef7-f4f8-b8be-9aac0d3148d6.htm
---
# Autodesk.Revit.DB.ScheduleDefinition.CanSortByField Method

Checks whether a field can be used for sorting/grouping.

## Syntax (C#)
```csharp
public bool CanSortByField(
	ScheduleFieldId fieldId
)
```

## Parameters
- **fieldId** (`Autodesk.Revit.DB.ScheduleFieldId`) - The ID of the field to check.

## Returns
True if the field can be used for sorting/grouping, false otherwise.

## Remarks
Schedules cannot be sorted/grouped by the Count field, Percentage
 fields, or Formula fields that depend on Percentage fields because
 those types of fields don't have meaningful values until after
 sorting and grouping takes place.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - fieldId is not the ID of a field in this ScheduleDefinition.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

