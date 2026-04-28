---
kind: type
id: T:Autodesk.Revit.DB.RevolvedSurface
source: html/ce0b47e0-2b24-61f5-1434-87fe3ff70390.htm
---
# Autodesk.Revit.DB.RevolvedSurface

A surface of revolution defined by a profile curve and a local coordinate system.
 The surface is obtained by rotating the curve around Z axis of the local coordinate system.

## Syntax (C#)
```csharp
public class RevolvedSurface : Surface
```

## Remarks
The parametric equation of a surface of revolution is S(u, v) = center + C1(v)*cos(u)*xVec + C1(v)*sin(u)*yVec + C2(v)*zVec,
 where the profile curve in the SurfRev's xz plane has the parametric equation (C1(t), C2(t)).
 Note that the direction of X axis may agree or disagree with the chosen orientation of the surface.

