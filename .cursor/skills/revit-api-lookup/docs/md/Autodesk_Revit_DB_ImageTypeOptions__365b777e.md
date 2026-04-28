---
kind: type
id: T:Autodesk.Revit.DB.ImageTypeOptions
source: html/981135c3-777b-df9b-747f-60a35b74e00e.htm
---
# Autodesk.Revit.DB.ImageTypeOptions

Represents the options used in ImageType::Create(Document, ImageTypeOptions) 
 and ImageType.ReloadFrom(ImageTypeOptions) methods.

## Syntax (C#)
```csharp
public class ImageTypeOptions : IDisposable
```

## Remarks
ImageTypeOptions are used to describe how an ImageType should be created from
 an image file. ImageTypeOptions are used to specify the location of the image file to use for the image
 using either a string path or an ExternalResourceReference . ImageTypeOptions are used to specify if the file path should be stored as an absolute path,
 or a relative path. A relative path is relative to the location of the project file,
 unless the file is workshared, in which case the relative path is relative to the location of the central file.
 Note that the relative path option is only available if the project file has been saved. ImageTypeOptions are used to specify whether the image should be imported or linked.
 For imported images the image data is added to the Revit project file.
 For linked images the image data is reloaded everytime the project file is opened.
 Linked images are only available if they were reloaded successfully, while imported images are always available. For PDF files the ImageTypeOptions can be used to specify which page in the PDF file to use for the image.
 For raster based image files the page number must be 1 (the default). ImageTypeOptions can be used to specify the resolution (in pixels per inch) to use for the image.
 For PDF files the resolution is used to determine how many pixels to use
 when rasterizing the PDF page. Using a higher resolution will increase the number of pixels.
 This will add more detail, but it will also make rendering the image slower.
 In addition, it will likely increase the amount of data stored in the project when the image is imported. Raster based images have a fixed number of pixels.
 As a result, the resolution has no effect on the amount of detail or the amount of data that is stored.
 The resolution is only used to determine the size of image.
 Doubling the resolution will make the image appear half the size. When a file is accessed with the help of an external server, it is likely that a local cache of the file will
 be created temporarily. ImageTypeOptions may refer to the cached copy of the file internally. For this
 reason, ImageTypeOptions should be treated as a transient object whose purpose is to become an argument to
 ImageType.Create(Document, ImageTypeOptions) 
 or ImageType.ReloadFrom(ImageTypeOptions) .
 An application should not create an ImageTypeOptions object and hold onto it for a long time.

