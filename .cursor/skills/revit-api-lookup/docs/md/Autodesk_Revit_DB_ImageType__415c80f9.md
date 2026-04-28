---
kind: type
id: T:Autodesk.Revit.DB.ImageType
source: html/c6213f81-8dc8-158e-0522-70f87e9bdbb9.htm
---
# Autodesk.Revit.DB.ImageType

Represents a type containing a raster based image. ImageInstances of this type can be placed in 2D views, sheets, and schedules.

## Syntax (C#)
```csharp
public class ImageType : ElementType
```

## Remarks
ImageType elements are created with the ImageType.Create(Document, ImageTypeOptions) method. ImageType elements can be loaded from the following file types: *.bmp, *.jpg, *.jpeg, *.png, *.tif. In addition, when PDF support is available, ImageType elements can also be loaded from *.pdf files.
 See: IsPDFImportAvailable () () ()

