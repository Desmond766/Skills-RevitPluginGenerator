---
kind: method
id: M:Autodesk.Revit.DB.ScheduleDefinition.SetSortGroupField(System.Int32,Autodesk.Revit.DB.ScheduleSortGroupField)
source: html/37b78a55-2926-62c9-7c53-5beabc3852da.htm
---
# Autodesk.Revit.DB.ScheduleDefinition.SetSortGroupField Method

Replaces a sorting/grouping field.

## Syntax (C#)
```csharp
public void SetSortGroupField(
	int index,
	ScheduleSortGroupField sortGroupField
)
```

## Parameters
- **index** (`System.Int32`) - The index of the sorting/grouping field to replace.
- **sortGroupField** (`Autodesk.Revit.DB.ScheduleSortGroupField`) - The new sorting/grouping field.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The field ID is not the ID of a field in this ScheduleDefinition.
 -or-
 The field cannot be used for sorting/grouping.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - index is not a valid sorting/grouping field index.

