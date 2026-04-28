---
kind: method
id: M:Autodesk.Revit.DB.ScheduleDefinition.AddFilter(Autodesk.Revit.DB.ScheduleFilter)
source: html/1acf54fa-2304-396b-8f4b-077cda826b6f.htm
---
# Autodesk.Revit.DB.ScheduleDefinition.AddFilter Method

Adds a new filter at the end of the list.

## Syntax (C#)
```csharp
public void AddFilter(
	ScheduleFilter filter
)
```

## Parameters
- **filter** (`Autodesk.Revit.DB.ScheduleFilter`) - The filter to add.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The field ID is not the ID of a field in this ScheduleDefinition.
 -or-
 The field and filter type cannot be used to filter this ScheduleDefinition.
 -or-
 The filter value is not valid for the field and filter type.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This ScheduleDefinition does not support filters.
 -or-
 The resulting filter count would be greater than 8.

