---
kind: type
id: T:Autodesk.Revit.DB.ConicalSurface
source: html/bcc299b6-ff1a-7f0c-c5da-8b040a326899.htm
---
# Autodesk.Revit.DB.ConicalSurface

A Conical Surface.

## Syntax (C#)
```csharp
public class ConicalSurface : Surface
```

## Remarks
The parametric equation of the cone is S(u, v) = center + v*[sin(halfAngle)(cos(u)*xVec + sin(u)*yVec) + cos(halfAngle)*zVec]. Only the branch of the cone with v >= 0 should be used.

