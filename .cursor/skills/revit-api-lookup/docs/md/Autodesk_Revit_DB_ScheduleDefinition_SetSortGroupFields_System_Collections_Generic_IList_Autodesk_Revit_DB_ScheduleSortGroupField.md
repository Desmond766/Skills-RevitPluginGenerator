---
kind: method
id: M:Autodesk.Revit.DB.ScheduleDefinition.SetSortGroupFields(System.Collections.Generic.IList{Autodesk.Revit.DB.ScheduleSortGroupField})
source: html/e45815f2-fc16-9686-9bf8-f1d3b5976cfa.htm
---
# Autodesk.Revit.DB.ScheduleDefinition.SetSortGroupFields Method

Replaces all sorting/grouping fields in this ScheduleDefinition.

## Syntax (C#)
```csharp
public void SetSortGroupFields(
	IList<ScheduleSortGroupField> sortGroupFields
)
```

## Parameters
- **sortGroupFields** (`System.Collections.Generic.IList < ScheduleSortGroupField >`) - The new list of sorting/grouping fields.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The resulting sorting/grouping field count would be greater than 4.
 -or-
 A field ID is not the ID of a field in this ScheduleDefinition.
 -or-
 A field cannot be used for sorting/grouping.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

