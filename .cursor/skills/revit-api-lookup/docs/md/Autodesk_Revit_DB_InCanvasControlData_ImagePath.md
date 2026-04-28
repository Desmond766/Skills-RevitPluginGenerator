---
kind: property
id: P:Autodesk.Revit.DB.InCanvasControlData.ImagePath
source: html/35ae5240-5ed5-909b-9e89-3bd17eff90fd.htm
---
# Autodesk.Revit.DB.InCanvasControlData.ImagePath Property

The path to the image file to be used.
 This must be an absolute path to a location on disk.

## Syntax (C#)
```csharp
public string ImagePath { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The file format specified by imagePath is an unsupported format - only *.bmp files are supported.
 -or-
 When setting this property: The file path specified by imagePath is not absolute.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null
- **Autodesk.Revit.Exceptions.FileArgumentNotFoundException** - When setting this property: The file specified by imagePath doesn't exist.

