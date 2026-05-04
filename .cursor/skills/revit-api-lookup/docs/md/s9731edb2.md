---
kind: type
id: T:Autodesk.Revit.DB.PointClouds.PointCloudColorSettings
source: html/5f7af794-d52e-76a2-c38b-33eed5242484.htm
---
# Autodesk.Revit.DB.PointClouds.PointCloudColorSettings

The color settings which are applied to a PointCloudInstance element, or one of its scans.

## Syntax (C#)
```csharp
public class PointCloudColorSettings : IDisposable
```

## Remarks
For different color modes (PointCloudColorMode), the color settings mean different things:
 for single color, color1 means the display color for other modes (intensity, elevation), color1 and color2 form a gradient from min to max for no overrides and normals, color1 and color2 are not used

