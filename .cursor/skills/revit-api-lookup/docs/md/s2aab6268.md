---
kind: method
id: M:Autodesk.Revit.DB.RenderingSettings.GetBackgroundSettings
source: html/26870ca6-9b40-73d7-0ac0-0bcb650bf39c.htm
---
# Autodesk.Revit.DB.RenderingSettings.GetBackgroundSettings Method

Returns an object that represents the rendering background settings.

## Syntax (C#)
```csharp
public BackgroundSettings GetBackgroundSettings()
```

## Returns
The rendering background settings.

## Remarks
Different kind of settings object will be returned according to different background style.
 It could be SkyBackgroundSettings, ColorBackgroundSettings, or ImageBackgroundSettings.

