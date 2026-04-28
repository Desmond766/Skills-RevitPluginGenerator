---
kind: property
id: P:Autodesk.Revit.DB.PDFExportOptions.PaperFormat
source: html/76b7ab91-364a-aa06-9dbb-89fee0527665.htm
---
# Autodesk.Revit.DB.PDFExportOptions.PaperFormat Property

Paper format.

## Syntax (C#)
```csharp
public ExportPaperFormat PaperFormat { get; set; }
```

## Remarks
When the PaperFormat is ExportPaperFormat.Default, which means "Use Sheet Size".

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The input paper format is invalid

