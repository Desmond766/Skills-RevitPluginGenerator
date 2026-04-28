---
kind: method
id: M:Autodesk.Revit.DB.ScheduleFilter.#ctor(Autodesk.Revit.DB.ScheduleFieldId,Autodesk.Revit.DB.ScheduleFilterType,Autodesk.Revit.DB.ElementId)
source: html/4ac7ace5-54dd-ef66-3e7d-b9503c5a7f75.htm
---
# Autodesk.Revit.DB.ScheduleFilter.#ctor Method

Creates a new ScheduleFilter.

## Syntax (C#)
```csharp
public ScheduleFilter(
	ScheduleFieldId fieldId,
	ScheduleFilterType filterType,
	ElementId value
)
```

## Parameters
- **fieldId** (`Autodesk.Revit.DB.ScheduleFieldId`) - The ID of the field used to filter the schedule.
- **filterType** (`Autodesk.Revit.DB.ScheduleFilterType`) - The filter type.
- **value** (`Autodesk.Revit.DB.ElementId`) - The filter value for a filter using an ElementId value.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

