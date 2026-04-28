---
kind: property
id: P:Autodesk.Revit.DB.ScheduleDefinition.ShowGrandTotalTitle
source: html/64bb930d-0a17-347b-dfba-94c7b6a279d5.htm
---
# Autodesk.Revit.DB.ScheduleDefinition.ShowGrandTotalTitle Property

Indicates if the grand total row should display a title.

## Syntax (C#)
```csharp
public bool ShowGrandTotalTitle { get; set; }
```

## Remarks
The title consists of the text "Grand total". ShowGrandTotalTitle can only be enabled if ShowGrandTotal
 is enabled.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: Display of a grand total row is not enabled.

