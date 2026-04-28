---
kind: method
id: M:Autodesk.Revit.DB.ScheduleDefinition.IsSchedulableField(Autodesk.Revit.DB.SchedulableField)
source: html/f08c6d5b-600d-8770-1e02-31d4c31641f0.htm
---
# Autodesk.Revit.DB.ScheduleDefinition.IsSchedulableField Method

Checks whether a non-calculated/non-combined field is eligible to be included in
 this schedule.

## Syntax (C#)
```csharp
public bool IsSchedulableField(
	SchedulableField schedulableField
)
```

## Parameters
- **schedulableField** (`Autodesk.Revit.DB.SchedulableField`) - The field to check.

## Returns
True if the field may be included in the schedule, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

