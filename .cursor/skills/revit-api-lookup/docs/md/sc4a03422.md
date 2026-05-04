---
kind: method
id: M:Autodesk.Revit.DB.ScheduleDefinition.GetSortGroupField(System.Int32)
source: html/169f1ab2-6b87-9e27-ae4d-ec36bc463f44.htm
---
# Autodesk.Revit.DB.ScheduleDefinition.GetSortGroupField Method

Gets a sorting/grouping field.

## Syntax (C#)
```csharp
public ScheduleSortGroupField GetSortGroupField(
	int index
)
```

## Parameters
- **index** (`System.Int32`) - The index of the sorting/grouping field.

## Returns
A copy of the sorting/grouping field.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - index is not a valid sorting/grouping field index.

