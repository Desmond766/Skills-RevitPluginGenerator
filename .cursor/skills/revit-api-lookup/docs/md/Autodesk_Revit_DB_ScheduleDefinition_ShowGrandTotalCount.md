---
kind: property
id: P:Autodesk.Revit.DB.ScheduleDefinition.ShowGrandTotalCount
source: html/9b08fabf-a499-1b15-3b9d-f669f6c601d8.htm
---
# Autodesk.Revit.DB.ScheduleDefinition.ShowGrandTotalCount Property

Indicates if the grand total row should display a count of elements
 in the schedule.

## Syntax (C#)
```csharp
public bool ShowGrandTotalCount { get; set; }
```

## Remarks
ShowGrandTotalCount can only be enabled if ShowGrandTotal is enabled.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: Display of a grand total row is not enabled.

