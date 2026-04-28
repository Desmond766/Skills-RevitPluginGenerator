---
kind: property
id: P:Autodesk.Revit.DB.ScheduleSortGroupField.ShowFooterTitle
source: html/92f06ca6-e6a9-9cf6-d08c-2d6583db1283.htm
---
# Autodesk.Revit.DB.ScheduleSortGroupField.ShowFooterTitle Property

Indicates if the footer row should display a title.

## Syntax (C#)
```csharp
public bool ShowFooterTitle { get; set; }
```

## Remarks
The title consists of the value of the field that the
 schedule is grouped by. ShowFooterTitle can only be enabled if ShowFooter is enabled.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: Display of footer rows is not enabled.

