---
kind: property
id: P:Autodesk.Revit.DB.ImageExportOptions.PixelSize
source: html/558f150d-0b11-26cc-0516-19af55eea2a4.htm
---
# Autodesk.Revit.DB.ImageExportOptions.PixelSize Property

The pixel size of an image in one direction. Used only if ZoomType is FitToPage.

## Syntax (C#)
```csharp
public int PixelSize { get; set; }
```

## Remarks
The default is 512 pixels.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The PixelSize value is outside the permitted range.

