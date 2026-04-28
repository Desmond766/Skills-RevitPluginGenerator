---
kind: method
id: M:Autodesk.Revit.DB.ScheduleDefinition.InsertSortGroupField(Autodesk.Revit.DB.ScheduleSortGroupField,System.Int32)
source: html/8e9b2895-7627-7430-6db4-0ed0e25ffa60.htm
---
# Autodesk.Revit.DB.ScheduleDefinition.InsertSortGroupField Method

Adds a new sorting/grouping field at the specified position in the list.

## Syntax (C#)
```csharp
public void InsertSortGroupField(
	ScheduleSortGroupField sortGroupField,
	int index
)
```

## Parameters
- **sortGroupField** (`Autodesk.Revit.DB.ScheduleSortGroupField`) - The sorting/grouping field to add.
- **index** (`System.Int32`) - The index in the list of sorting/grouping fields.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The field ID is not the ID of a field in this ScheduleDefinition.
 -or-
 The field cannot be used for sorting/grouping.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - index is not a valid insert position.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The resulting sorting/grouping field count would be greater than 4.

