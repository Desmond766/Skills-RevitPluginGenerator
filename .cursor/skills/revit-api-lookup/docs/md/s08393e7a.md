---
kind: method
id: M:Autodesk.Revit.DB.ScheduleDefinition.RemoveFilter(System.Int32)
source: html/57b69056-4175-3de4-511f-c1a1af280300.htm
---
# Autodesk.Revit.DB.ScheduleDefinition.RemoveFilter Method

Removes a filter.

## Syntax (C#)
```csharp
public void RemoveFilter(
	int index
)
```

## Parameters
- **index** (`System.Int32`) - The index of the filter to remove.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - index is not a valid filter index.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This ScheduleDefinition does not support filters.

