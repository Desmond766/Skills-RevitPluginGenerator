---
kind: method
id: M:Autodesk.Revit.DB.ScheduleFilter.#ctor(Autodesk.Revit.DB.ScheduleFieldId,Autodesk.Revit.DB.ScheduleFilterType)
source: html/cdde2306-7abe-15d5-dc37-39b23f916dbd.htm
---
# Autodesk.Revit.DB.ScheduleFilter.#ctor Method

Creates a new ScheduleFilter.

## Syntax (C#)
```csharp
public ScheduleFilter(
	ScheduleFieldId fieldId,
	ScheduleFilterType filterType
)
```

## Parameters
- **fieldId** (`Autodesk.Revit.DB.ScheduleFieldId`) - The ID of the field used to filter the schedule.
- **filterType** (`Autodesk.Revit.DB.ScheduleFilterType`) - The filter type.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

