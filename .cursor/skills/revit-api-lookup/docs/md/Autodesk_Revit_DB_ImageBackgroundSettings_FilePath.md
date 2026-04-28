---
kind: property
id: P:Autodesk.Revit.DB.ImageBackgroundSettings.FilePath
source: html/23339d72-1c7c-0cc2-ee44-67cde7150eeb.htm
---
# Autodesk.Revit.DB.ImageBackgroundSettings.FilePath Property

File path of the image for the rendering background.

## Syntax (C#)
```csharp
public string FilePath { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The file specified by path is not an image file.
 A valid image file should be in one of the following formats: bmp, jpg, jpeg, png, tif.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null
- **Autodesk.Revit.Exceptions.FileArgumentNotFoundException** - When setting this property: The file specified by path doesn't exist.

