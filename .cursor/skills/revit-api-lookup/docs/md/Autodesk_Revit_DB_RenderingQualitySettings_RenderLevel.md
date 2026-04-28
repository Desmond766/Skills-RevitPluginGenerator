---
kind: property
id: P:Autodesk.Revit.DB.RenderingQualitySettings.RenderLevel
source: html/38930ddb-16e7-e0a3-e67f-241ab4e635c6.htm
---
# Autodesk.Revit.DB.RenderingQualitySettings.RenderLevel Property

The render target level as a numerical value between 1 and 40.

## Syntax (C#)
```csharp
public int RenderLevel { get; set; }
```

## Remarks
Increase this value to increase render level.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The value is not valid for RenderLevel.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: The RenderingQualitySettings does not use custom quality currently.
 To use custom quality, set RenderingQuality property to RenderingQuality.Custom.

