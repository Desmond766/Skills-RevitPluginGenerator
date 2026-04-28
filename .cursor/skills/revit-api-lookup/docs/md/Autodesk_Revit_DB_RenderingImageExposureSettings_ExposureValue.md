---
kind: property
id: P:Autodesk.Revit.DB.RenderingImageExposureSettings.ExposureValue
source: html/67fd3e82-d717-98b7-1f35-19b47550f29c.htm
---
# Autodesk.Revit.DB.RenderingImageExposureSettings.ExposureValue Property

The value of rendering image exposure.

## Syntax (C#)
```csharp
public double ExposureValue { get; set; }
```

## Remarks
Default exposure value based on Lighting Scheme.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The value of rendering image exposure is not valid. The valid range is 0 to 21.

