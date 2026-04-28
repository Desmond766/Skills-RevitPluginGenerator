---
kind: property
id: P:Autodesk.Revit.DB.ScheduleSortGroupField.ShowFooterCount
source: html/1ddd65b4-729d-d8d5-6667-aec627e3e3e4.htm
---
# Autodesk.Revit.DB.ScheduleSortGroupField.ShowFooterCount Property

Indicates if the footer row should display a count of elements in the group.

## Syntax (C#)
```csharp
public bool ShowFooterCount { get; set; }
```

## Remarks
ShowFooterCount can only be enabled if ShowFooter is enabled.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: Display of footer rows is not enabled.

