---
kind: method
id: M:Autodesk.Revit.DB.ScheduleDefinition.GetFilter(System.Int32)
source: html/bfd1a738-9b18-d4dd-f487-eac4566e8484.htm
---
# Autodesk.Revit.DB.ScheduleDefinition.GetFilter Method

Gets a filter.

## Syntax (C#)
```csharp
public ScheduleFilter GetFilter(
	int index
)
```

## Parameters
- **index** (`System.Int32`) - The index of the filter.

## Returns
A copy of the filter.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - index is not a valid filter index.

