---
kind: type
id: T:Autodesk.Revit.DB.ScheduleField
source: html/3d6b0eb5-ed36-278d-a5df-38b6d600e876.htm
---
# Autodesk.Revit.DB.ScheduleField

A field in a schedule.

## Syntax (C#)
```csharp
public class ScheduleField : IDisposable
```

## Remarks
The ScheduleField class represents a single field in a ScheduleDefinition's
 list of fields. Each (non-hidden) field becomes a column in the schedule. Most commonly, a field represents an instance or type parameter of
 elements appearing in the schedule. Some fields represent parameters
 of other related elements, like the room that a scheduled element belongs to.
 Fields can also represent data calculated from other fields in the schedule,
 specifically Formula and Percentage fields.
 Another type of field is Custom Field. For this one, the value for each row is
 computed based on the (sub)elements that are grouped on that row and can have a
 graphic representation when the schedule is placed on a sheet.

