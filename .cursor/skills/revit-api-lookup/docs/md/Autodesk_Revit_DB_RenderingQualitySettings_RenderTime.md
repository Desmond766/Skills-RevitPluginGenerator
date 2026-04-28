---
kind: property
id: P:Autodesk.Revit.DB.RenderingQualitySettings.RenderTime
source: html/58d15d61-8c04-b686-c13a-067ae7edd36f.htm
---
# Autodesk.Revit.DB.RenderingQualitySettings.RenderTime Property

The render target time as a numerical value between 1 and 32768.

## Syntax (C#)
```csharp
public int RenderTime { get; set; }
```

## Remarks
Increase this value to increase render time.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The value is not valid RenderTime.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: The RenderingQualitySettings does not use custom quality currently.
 To use custom quality, set RenderingQuality property to RenderingQuality.Custom.

