---
kind: property
id: P:Autodesk.Revit.DB.PDFExportOptions.ZoomType
source: html/4ed01f69-6d62-03fb-575f-86d90ceab522.htm
---
# Autodesk.Revit.DB.PDFExportOptions.ZoomType Property

Zoom type of either fit to page or on a specific percentage.

## Syntax (C#)
```csharp
public ZoomType ZoomType { get; set; }
```

## Remarks
This property would be ignored if the PaperFormat is Default.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: A value passed for an enumeration argument is not a member of that enumeration

