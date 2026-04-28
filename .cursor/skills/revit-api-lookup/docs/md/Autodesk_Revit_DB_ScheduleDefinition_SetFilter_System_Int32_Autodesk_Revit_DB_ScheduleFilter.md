---
kind: method
id: M:Autodesk.Revit.DB.ScheduleDefinition.SetFilter(System.Int32,Autodesk.Revit.DB.ScheduleFilter)
source: html/4432b9a9-a1ed-17c1-90a4-9c87d1a4fdcc.htm
---
# Autodesk.Revit.DB.ScheduleDefinition.SetFilter Method

Replaces a filter.

## Syntax (C#)
```csharp
public void SetFilter(
	int index,
	ScheduleFilter filter
)
```

## Parameters
- **index** (`System.Int32`) - The index of the filter to replace.
- **filter** (`Autodesk.Revit.DB.ScheduleFilter`) - The new filter.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The field ID is not the ID of a field in this ScheduleDefinition.
 -or-
 The field and filter type cannot be used to filter this ScheduleDefinition.
 -or-
 The filter value is not valid for the field and filter type.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - index is not a valid filter index.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This ScheduleDefinition does not support filters.

