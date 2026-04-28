---
kind: method
id: M:Autodesk.Revit.DB.ScheduleDefinition.SetFilters(System.Collections.Generic.IList{Autodesk.Revit.DB.ScheduleFilter})
source: html/db0674e3-8d0d-9753-2938-652e1f7f46cb.htm
---
# Autodesk.Revit.DB.ScheduleDefinition.SetFilters Method

Replaces all filters in this ScheduleDefinition.

## Syntax (C#)
```csharp
public void SetFilters(
	IList<ScheduleFilter> filters
)
```

## Parameters
- **filters** (`System.Collections.Generic.IList < ScheduleFilter >`) - The new list of filters.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The resulting filter count would be greater than 8.
 -or-
 A field ID is not the ID of a field in this ScheduleDefinition.
 -or-
 A field and filter type cannot be used to filter this ScheduleDefinition.
 -or-
 A filter value is not valid for the field and filter type.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This ScheduleDefinition does not support filters.

