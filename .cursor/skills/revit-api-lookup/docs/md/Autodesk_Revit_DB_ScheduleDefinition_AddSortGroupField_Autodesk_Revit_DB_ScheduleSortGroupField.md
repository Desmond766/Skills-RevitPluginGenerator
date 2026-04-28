---
kind: method
id: M:Autodesk.Revit.DB.ScheduleDefinition.AddSortGroupField(Autodesk.Revit.DB.ScheduleSortGroupField)
source: html/dec080e9-104d-1e1b-b436-b9d60a322815.htm
---
# Autodesk.Revit.DB.ScheduleDefinition.AddSortGroupField Method

Adds a new sorting/grouping field at the end of the list.

## Syntax (C#)
```csharp
public void AddSortGroupField(
	ScheduleSortGroupField sortGroupField
)
```

## Parameters
- **sortGroupField** (`Autodesk.Revit.DB.ScheduleSortGroupField`) - The sorting/grouping field to add.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The field ID is not the ID of a field in this ScheduleDefinition.
 -or-
 The field cannot be used for sorting/grouping.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The resulting sorting/grouping field count would be greater than 4.

