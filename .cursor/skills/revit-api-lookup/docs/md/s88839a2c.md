---
kind: method
id: M:Autodesk.Revit.DB.ScheduleDefinition.AddEmbeddedSchedule(Autodesk.Revit.DB.ElementId)
source: html/99ec6015-c787-231c-547f-40b432403c5a.htm
---
# Autodesk.Revit.DB.ScheduleDefinition.AddEmbeddedSchedule Method

Adds an embedded ScheduleDefinition.

## Syntax (C#)
```csharp
public void AddEmbeddedSchedule(
	ElementId categoryId
)
```

## Parameters
- **categoryId** (`Autodesk.Revit.DB.ElementId`) - The category ID of elements to display in the embedded schedule.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - categoryId is not the ID of a category that can be used for an embedded
 ScheduleDefinition in this ScheduleDefinition.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.DisabledDisciplineException** - None of the following disciplines is enabled: Mechanical Electrical Piping.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This ScheduleDefinition is not a kind of schedule that supports adding an embedded
 ScheduleDefinition.
 -or-
 This ScheduleDefinition already has an embedded ScheduleDefinition.

