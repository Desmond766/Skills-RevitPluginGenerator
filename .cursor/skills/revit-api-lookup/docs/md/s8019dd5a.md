---
kind: property
id: P:Autodesk.Revit.DB.ImageTypeOptions.Resolution
source: html/858dcd6b-5231-fb9b-b43a-7c1397c4265e.htm
---
# Autodesk.Revit.DB.ImageTypeOptions.Resolution Property

The Resolution of the image is expressed in dots-per-inch and hence determines the size of a pixel in the image.

## Syntax (C#)
```csharp
public double Resolution { get; set; }
```

## Remarks
For raster based image formats (*.bmp, *.jpg, *.jpeg, *.png, *.tif)
 the Resolution is used to calculate the size of the image from the number
 of pixels in the horizontal and vertical directions.
For PDF files, which have a known paper size, the Resolution is used
 to control the amount of detail to capture in the image.
 Increasing the Resolution of PDF based images will add more
 detail to the image, but will also increase the amount of
 data stored in the project file.
The default value of this property is 72 dpi.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The given value for resolution must be positive.

