---
kind: property
id: P:Autodesk.Revit.UI.FileDialog.Filter
zh: 筛选、过滤
source: html/a67923df-362a-52de-944f-c6ef0532cd59.htm
---
# Autodesk.Revit.UI.FileDialog.Filter Property

**中文**: 筛选、过滤

The filter string representing a collection of extensions allowed by the dialog.

## Syntax (C#)
```csharp
public string Filter { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The input filter string does not meet the minimal requirements for a valid filter string.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

