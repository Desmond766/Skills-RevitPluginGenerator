---
kind: property
id: P:Autodesk.Revit.DB.ScheduleDefinition.IsMaterialTakeoff
source: html/6e0766f0-1676-38b0-0582-5c0ed69e491a.htm
---
# Autodesk.Revit.DB.ScheduleDefinition.IsMaterialTakeoff Property

Indicates if the schedule is a material takeoff.

## Syntax (C#)
```csharp
public bool IsMaterialTakeoff { get; }
```

## Remarks
A material takeoff is a schedule that displays information about
 the materials that make up elements in the model. Unlike regular
 schedules where each row (before grouping) represents a single
 element, each row in a material takeoff represents a single
 <element, material> pair.

