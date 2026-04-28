---
kind: method
id: M:Autodesk.Revit.DB.ScheduleFilter.#ctor(Autodesk.Revit.DB.ScheduleFieldId,Autodesk.Revit.DB.ScheduleFilterType,System.String)
source: html/6ec07804-d396-ad9b-d0b8-08b37b3b9ae7.htm
---
# Autodesk.Revit.DB.ScheduleFilter.#ctor Method

Creates a new ScheduleFilter.

## Syntax (C#)
```csharp
public ScheduleFilter(
	ScheduleFieldId fieldId,
	ScheduleFilterType filterType,
	string value
)
```

## Parameters
- **fieldId** (`Autodesk.Revit.DB.ScheduleFieldId`) - The ID of the field used to filter the schedule.
- **filterType** (`Autodesk.Revit.DB.ScheduleFilterType`) - The filter type.
- **value** (`System.String`) - The filter value for a filter using a string value.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

