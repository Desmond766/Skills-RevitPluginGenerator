---
kind: property
id: P:Autodesk.Revit.DB.PDFExportOptions.PaperOrientation
source: html/3ccb2457-63ec-c918-abfa-94662ce6650f.htm
---
# Autodesk.Revit.DB.PDFExportOptions.PaperOrientation Property

Paper orientation - Portrait/Landscape/Auto

## Syntax (C#)
```csharp
public PageOrientationType PaperOrientation { get; set; }
```

## Remarks
Ignored when the PaperFormat is ExportPaperFormat.Default, which means "Use Sheet Size".

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: A value passed for an enumeration argument is not a member of that enumeration

