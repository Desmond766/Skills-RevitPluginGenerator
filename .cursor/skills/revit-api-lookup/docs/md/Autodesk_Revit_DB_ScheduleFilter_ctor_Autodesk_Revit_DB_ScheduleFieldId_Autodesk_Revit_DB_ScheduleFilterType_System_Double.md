---
kind: method
id: M:Autodesk.Revit.DB.ScheduleFilter.#ctor(Autodesk.Revit.DB.ScheduleFieldId,Autodesk.Revit.DB.ScheduleFilterType,System.Double)
source: html/1eedd87b-7ab3-e586-411d-241c5fa15eca.htm
---
# Autodesk.Revit.DB.ScheduleFilter.#ctor Method

Creates a new ScheduleFilter.

## Syntax (C#)
```csharp
public ScheduleFilter(
	ScheduleFieldId fieldId,
	ScheduleFilterType filterType,
	double value
)
```

## Parameters
- **fieldId** (`Autodesk.Revit.DB.ScheduleFieldId`) - The ID of the field used to filter the schedule.
- **filterType** (`Autodesk.Revit.DB.ScheduleFilterType`) - The filter type.
- **value** (`System.Double`) - The filter value for a filter using a double value.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

