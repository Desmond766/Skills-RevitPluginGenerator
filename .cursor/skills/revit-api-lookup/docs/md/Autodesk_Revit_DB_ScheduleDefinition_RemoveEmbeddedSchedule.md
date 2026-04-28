---
kind: method
id: M:Autodesk.Revit.DB.ScheduleDefinition.RemoveEmbeddedSchedule
source: html/a2d3836a-8f83-0e97-5229-8b949132a3f1.htm
---
# Autodesk.Revit.DB.ScheduleDefinition.RemoveEmbeddedSchedule Method

Removes the embedded ScheduleDefinition.

## Syntax (C#)
```csharp
public void RemoveEmbeddedSchedule()
```

## Exceptions
- **Autodesk.Revit.Exceptions.DisabledDisciplineException** - None of the following disciplines is enabled: Mechanical Electrical Piping.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This ScheduleDefinition does not have an embedded ScheduleDefinition.

