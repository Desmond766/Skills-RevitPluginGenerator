---
kind: property
id: P:Autodesk.Revit.DB.ScheduleDefinition.IsFilteredBySheet
source: html/cb831874-15f8-aaa0-f2e5-aafef137f0af.htm
---
# Autodesk.Revit.DB.ScheduleDefinition.IsFilteredBySheet Property

Indicates if the schedule is set to filter by sheet.

## Syntax (C#)
```csharp
public bool IsFilteredBySheet { get; set; }
```

## Remarks
If the schedule is set to filter by sheet, and it is placed on a particular sheet, the
 instance created will present only the elements visible in the Viewport(s) on that sheet.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: The schedule category is not supported to use filter by sheet.
 -or-
 When setting this property: The Schedule is split already.

