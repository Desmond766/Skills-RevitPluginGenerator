---
kind: method
id: M:Autodesk.Revit.DB.ScheduleDefinition.GetField(System.Int32)
source: html/7c22bcc4-c5be-daea-fb4c-77ef3a7773ab.htm
---
# Autodesk.Revit.DB.ScheduleDefinition.GetField Method

Gets a field.

## Syntax (C#)
```csharp
public ScheduleField GetField(
	int index
)
```

## Parameters
- **index** (`System.Int32`) - The index of the field.

## Returns
The field.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - index is not a valid field index in this ScheduleDefinition.

