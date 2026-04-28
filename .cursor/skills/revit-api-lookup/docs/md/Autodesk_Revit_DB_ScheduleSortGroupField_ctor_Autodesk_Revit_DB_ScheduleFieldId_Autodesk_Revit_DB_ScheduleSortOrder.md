---
kind: method
id: M:Autodesk.Revit.DB.ScheduleSortGroupField.#ctor(Autodesk.Revit.DB.ScheduleFieldId,Autodesk.Revit.DB.ScheduleSortOrder)
source: html/2b5860f6-1c26-a27d-ed4c-208c4d6512cc.htm
---
# Autodesk.Revit.DB.ScheduleSortGroupField.#ctor Method

Creates a new ScheduleSortGroupField.

## Syntax (C#)
```csharp
public ScheduleSortGroupField(
	ScheduleFieldId fieldId,
	ScheduleSortOrder sortOrder
)
```

## Parameters
- **fieldId** (`Autodesk.Revit.DB.ScheduleFieldId`) - The ID of the field that the schedule will be sorted or grouped by.
- **sortOrder** (`Autodesk.Revit.DB.ScheduleSortOrder`) - The sort order, ascending or descending.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

