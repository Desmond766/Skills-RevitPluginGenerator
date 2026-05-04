---
kind: property
id: P:Autodesk.Revit.DB.Face.OrientationMatchesSurfaceOrientation
source: html/1e6f8718-982a-c6fa-3b0f-bef04301a57e.htm
---
# Autodesk.Revit.DB.Face.OrientationMatchesSurfaceOrientation Property

Returns true if this face's orientation matches the orientation of the face's surface, 
false if they have opposite orientations.

## Syntax (C#)
```csharp
public bool OrientationMatchesSurfaceOrientation { get; }
```

## Remarks
(Revit uses only orientable faces and surfaces).
At any point on a face or surface, the face's or surface's orientation is specified by 
the normal vector at that point.
The face's normal vector can be the same or opposite to that of its surface.
If OrientationMatchesSurfaceOrientation() is true, then the face’s normal vector is the same as 
that of its surface at each point on the face, otherwise the normal vectors are opposite.
See also Surface::OrientationMatchesParametricOrientation.

