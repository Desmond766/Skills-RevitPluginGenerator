---
kind: property
id: P:Autodesk.Revit.DB.RenderingImageExposureSettings.WhitePoint
source: html/5b3927f6-7554-85f5-d860-be43520a9d61.htm
---
# Autodesk.Revit.DB.RenderingImageExposureSettings.WhitePoint Property

The white point value.

## Syntax (C#)
```csharp
public double WhitePoint { get; set; }
```

## Remarks
Specify the white balance of the rendering(measured in Kelvin). Incandescent lighting:2800 K; Daylight 6500K.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The value of white point is not valid. The valid range is 1800 to 15000.

