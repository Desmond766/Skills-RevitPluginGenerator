---
kind: property
id: P:Autodesk.Revit.DB.NurbsSurfaceData.ReverseOrientation
source: html/57ca8156-bae7-58fc-89a4-88f08aa1f756.htm
---
# Autodesk.Revit.DB.NurbsSurfaceData.ReverseOrientation Property

If true, the surface's orientation is opposite to the canonical parametric orientation, otherwise it is the same.
 The canonical parametric orientation is a counter-clockwise sense of rotation in the uv-parameter plane.
 Extrinsically, the oriented normal vector for the canonical parametric orientation points in the direction of
 the cross product dS/du x dS/dv, which S(u, v) is the parameterized surface.

## Syntax (C#)
```csharp
public bool ReverseOrientation { get; }
```

