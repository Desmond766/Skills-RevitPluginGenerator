---
kind: property
id: P:Autodesk.Revit.DB.ScheduleDefinition.CategoryId
source: html/ec498b0e-3040-fc49-b3cf-9f81c842f271.htm
---
# Autodesk.Revit.DB.ScheduleDefinition.CategoryId Property

The category ID of elements appearing in the schedule.

## Syntax (C#)
```csharp
public ElementId CategoryId { get; }
```

## Remarks
Most schedules show elements of a single category. In multi-category
 schedules, the category ID is InvalidElementId. In key schedules,
 the schedule's category is the category of elements that the keys are
 associated with.

