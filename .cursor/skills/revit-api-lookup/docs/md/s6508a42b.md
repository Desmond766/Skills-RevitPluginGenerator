---
kind: type
id: T:Autodesk.Revit.DB.RuledSurface
source: html/9a33fec9-bbcd-f035-3194-cf36122b6cc6.htm
---
# Autodesk.Revit.DB.RuledSurface

A ruled surface is created by sweeping a line between two profile curves or between a curve and a point (a point and a curve).
 Input curve(s) must be bounded or have natural bounds.

## Syntax (C#)
```csharp
public class RuledSurface : Surface
```

## Remarks
Both curves are evaluated in normalized parameters [0, 1]
 The parametric equations of a ruled surface are:
 Curve C1 and curve C2 : S(u, v) = C1(u) + v * (C2(u) - C1(u)); Point P1 and curve C2 : S(u, v) = P1 + v * (C2(u) - P1); Curve C1 and point P2 : S(u, v) = C1(u) + v * (P2 - C1(u)); 
 The point/point case is not allowed as that would define a degenerate ruled surface.

