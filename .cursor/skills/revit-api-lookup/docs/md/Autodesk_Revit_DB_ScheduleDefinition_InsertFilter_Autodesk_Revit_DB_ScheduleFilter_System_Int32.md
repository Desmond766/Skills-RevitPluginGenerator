---
kind: method
id: M:Autodesk.Revit.DB.ScheduleDefinition.InsertFilter(Autodesk.Revit.DB.ScheduleFilter,System.Int32)
source: html/72a77aba-919c-7436-d057-759163d92c35.htm
---
# Autodesk.Revit.DB.ScheduleDefinition.InsertFilter Method

Adds a new filter at the specified position in the list.

## Syntax (C#)
```csharp
public void InsertFilter(
	ScheduleFilter filter,
	int index
)
```

## Parameters
- **filter** (`Autodesk.Revit.DB.ScheduleFilter`) - The filter to add.
- **index** (`System.Int32`) - The index in the list of filters.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The field ID is not the ID of a field in this ScheduleDefinition.
 -or-
 The field and filter type cannot be used to filter this ScheduleDefinition.
 -or-
 The filter value is not valid for the field and filter type.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - index is not a valid insert position.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This ScheduleDefinition does not support filters.
 -or-
 The resulting filter count would be greater than 8.

