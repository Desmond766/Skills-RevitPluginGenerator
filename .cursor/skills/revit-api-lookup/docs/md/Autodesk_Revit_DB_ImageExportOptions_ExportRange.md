---
kind: property
id: P:Autodesk.Revit.DB.ImageExportOptions.ExportRange
source: html/10472c5c-13f5-abf1-ee1d-751094b0a7cb.htm
---
# Autodesk.Revit.DB.ImageExportOptions.ExportRange Property

The export range defining which view(s) will be exported.

## Syntax (C#)
```csharp
public ExportRange ExportRange { get; set; }
```

## Remarks
Note that SetOfViews is not an acceptable value if these options are used to save an image to a project as a new view.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: A value passed for an enumeration argument is not a member of that enumeration

