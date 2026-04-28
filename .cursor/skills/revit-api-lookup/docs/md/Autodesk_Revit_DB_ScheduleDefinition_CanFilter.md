---
kind: method
id: M:Autodesk.Revit.DB.ScheduleDefinition.CanFilter
source: html/dd530b25-e1a6-be9e-8a9e-c10a4616fbc1.htm
---
# Autodesk.Revit.DB.ScheduleDefinition.CanFilter Method

Checks whether filters can be added to this ScheduleDefinition.

## Syntax (C#)
```csharp
public bool CanFilter()
```

## Returns
True if this ScheduleDefinition supports filters, false otherwise.

## Remarks
Key schedules and revision schedules do not support filters.

