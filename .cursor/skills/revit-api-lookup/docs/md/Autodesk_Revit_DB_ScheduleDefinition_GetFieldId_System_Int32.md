---
kind: method
id: M:Autodesk.Revit.DB.ScheduleDefinition.GetFieldId(System.Int32)
source: html/c48bf97b-6d47-7b55-6844-91f9c1da85e0.htm
---
# Autodesk.Revit.DB.ScheduleDefinition.GetFieldId Method

Converts a field index to the corresponding field ID.

## Syntax (C#)
```csharp
public ScheduleFieldId GetFieldId(
	int index
)
```

## Parameters
- **index** (`System.Int32`) - The field index.

## Returns
The field ID.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - index is not a valid field index in this ScheduleDefinition.

