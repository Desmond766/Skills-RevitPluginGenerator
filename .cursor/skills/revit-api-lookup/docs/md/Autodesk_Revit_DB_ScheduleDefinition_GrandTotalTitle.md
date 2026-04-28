---
kind: property
id: P:Autodesk.Revit.DB.ScheduleDefinition.GrandTotalTitle
source: html/9ae55f67-836c-d62d-8613-33a300bac264.htm
---
# Autodesk.Revit.DB.ScheduleDefinition.GrandTotalTitle Property

The title name is used to display at the grand total row. The name is "Grand total", expressed in the Revit session language, by default.

## Syntax (C#)
```csharp
public string GrandTotalTitle { get; set; }
```

## Remarks
GrandTotalTitle can only be set when both ShowGrandTotal and ShowGrandTotalTitle are enabled.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: Display of a grand total row is not enabled.
 -or-
 When setting this property: Display of grand total title is not enabled.

