---
kind: property
id: P:Autodesk.Revit.DB.CameraInfo.TargetDistance
source: html/46b7abd3-5ec1-939a-3f92-170fb6c87233.htm
---
# Autodesk.Revit.DB.CameraInfo.TargetDistance Property

Distance from eye point along view direction to target plane.

## Syntax (C#)
```csharp
public double TargetDistance { get; }
```

## Remarks
This value is appropriate for perspective views only.
 Attempts to get this value for an orthographic view can
 be made, but the obtained value is to be ignored.

