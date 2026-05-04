---
kind: property
id: P:Autodesk.Revit.DB.ScheduleField.TotalByAssemblyType
source: html/672a1283-cdb4-f7fb-b697-f67238c8755c.htm
---
# Autodesk.Revit.DB.ScheduleField.TotalByAssemblyType Property

In an assembly schedule view, indicates if totals are calculated for all
 assembly instances of the same type or only for a single instance.

## Syntax (C#)
```csharp
public bool TotalByAssemblyType { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: This ScheduleField cannot be totaled by assembly type.
 -or-
 When setting this property: Totals are not enabled for this ScheduleField.

