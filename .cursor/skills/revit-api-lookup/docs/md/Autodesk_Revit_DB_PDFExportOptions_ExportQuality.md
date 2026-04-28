---
kind: property
id: P:Autodesk.Revit.DB.PDFExportOptions.ExportQuality
source: html/2ee4b042-4df2-1c59-9429-1ed3bf829e82.htm
---
# Autodesk.Revit.DB.PDFExportOptions.ExportQuality Property

The preferred export quality (DPI).

## Syntax (C#)
```csharp
public PDFExportQualityType ExportQuality { get; set; }
```

## Remarks
This quality setting is the equivalent of printer resolution found in advanced printer settings.
 An effect of the setting is to control tessellation quality.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: A value passed for an enumeration argument is not a member of that enumeration

