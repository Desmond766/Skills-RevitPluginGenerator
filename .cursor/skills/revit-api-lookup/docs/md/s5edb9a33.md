---
kind: property
id: P:Autodesk.Revit.DB.RenderingQualitySettings.LightAndMaterialAccuracyMode
source: html/112f6cda-981d-8bc2-e10c-872f426acd81.htm
---
# Autodesk.Revit.DB.RenderingQualitySettings.LightAndMaterialAccuracyMode Property

A value that controls light and material accuracy mode.

## Syntax (C#)
```csharp
public LightAndMaterialAccuracyMode LightAndMaterialAccuracyMode { get; set; }
```

## Remarks
The method of the renderer engine dealing with materials and shadows.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: The RenderingQualitySettings does not use custom quality currently.
 To use custom quality, set RenderingQuality property to RenderingQuality.Custom.

