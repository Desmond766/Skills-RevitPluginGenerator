---
kind: method
id: M:Autodesk.Revit.DB.ScheduleDefinition.CanHaveEmbeddedSchedule
source: html/722b2643-158f-f306-90a5-f8c61ec56334.htm
---
# Autodesk.Revit.DB.ScheduleDefinition.CanHaveEmbeddedSchedule Method

Indicates if this ScheduleDefinition can have an embedded ScheduleDefinition
 added.

## Syntax (C#)
```csharp
public bool CanHaveEmbeddedSchedule()
```

## Returns
True if this ScheduleDefinition can have an embedded ScheduleDefinition,
 false otherwise.

## Remarks
Only schedules of the following categories can have an embedded
 ScheduleDefinition: Rooms Spaces Electrical Circuits Duct Systems Piping Systems Mechanical Equipment Sets MEP Fabrication Ductwork Fabrication Ductwork Stiffeners Key schedules cannot have embedded schedules.

