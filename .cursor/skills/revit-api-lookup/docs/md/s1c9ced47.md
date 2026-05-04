---
kind: method
id: M:Autodesk.Revit.DB.ScheduleFilter.#ctor(Autodesk.Revit.DB.ScheduleFieldId,Autodesk.Revit.DB.ScheduleFilterType,System.Int32)
source: html/979e8984-99f3-587c-648d-9dd21db7ef90.htm
---
# Autodesk.Revit.DB.ScheduleFilter.#ctor Method

Creates a new ScheduleFilter.

## Syntax (C#)
```csharp
public ScheduleFilter(
	ScheduleFieldId fieldId,
	ScheduleFilterType filterType,
	int value
)
```

## Parameters
- **fieldId** (`Autodesk.Revit.DB.ScheduleFieldId`) - The ID of the field used to filter the schedule.
- **filterType** (`Autodesk.Revit.DB.ScheduleFilterType`) - The filter type.
- **value** (`System.Int32`) - The filter value for a filter using an integer value.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

