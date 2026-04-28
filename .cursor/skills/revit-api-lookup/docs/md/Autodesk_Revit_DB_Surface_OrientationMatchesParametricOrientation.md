---
kind: property
id: P:Autodesk.Revit.DB.Surface.OrientationMatchesParametricOrientation
source: html/451b549f-2bc4-4f37-9f32-981fe18868a8.htm
---
# Autodesk.Revit.DB.Surface.OrientationMatchesParametricOrientation Property

Indicates whether this Surface's orientation is the same as or opposite to its parametric orientation.

## Syntax (C#)
```csharp
public bool OrientationMatchesParametricOrientation { get; }
```

## Remarks
(Revit uses only orientable surfaces).
 At any point on a surface, the surface's orientation is specified by a choice of the direction for the normal vector
 at that point.The direction can either match or be opposite to the direction of the parametric normal vector,
 which is the cross product of the surface's first partial derivatives: dS/du x dS/dv.
 The parametric normal vectors define the parametric orientation.
 A surface's orientation is then defined by getOrientationMatchesParametricOrientation() -
 if getOrientationMatchesParametricOrientation() is true, the surface's orientation is the same as its
 parametric orientation; otherwise it is opposite to its parametric orientation.
 The purpose of this information to an API user:
 Some systems, Industry Foundation Classes (IFC) for example, may only have parametric orientation for its surfaces.
 In such a system, the surface normal will always be the parametric normal, whereas
 in Revit, the surface normal will be the same as or opposite to the parametric normal according as
 getOrientationMatchesParametricOrientation is true or false.
 A user who is not familiar with Revit's orientation conventions might assume that Revit's normal vector is
 the same as the parametric normal, which is not always correct. Hence, this information is needed if and when
 the user tries to export Revit Geometry to IFC, for example.
 See also Face::OrientationMatchesSurfaceOrientation.

